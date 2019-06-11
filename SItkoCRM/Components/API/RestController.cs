using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Components.API
{
    [Route("v1/[controller]")]
    [SuppressMessage("ReSharper", "ASP012")]
    public abstract class RestController<TRestModel, TEntity, TEntityPk> : ApiController
        where TEntity : class, IEntity<TEntityPk> where TRestModel : RestModel<TEntity, TEntityPk>
    {
        protected IRepository<TEntity, TEntityPk> Repository { get; }
        
        protected RestController(ApiControllerContext<TEntity, TEntityPk> context) : base(context)
        {
            Repository = context.Repository;
        }

        [HttpGet]
        public virtual async Task<ListResponse<TRestModel>> GetAsync()
        {
            var result = await Repository.GetAllAsync(GetQueryContext());
            return await ListAsync(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<ModelResponse<TRestModel>> GetAsync(TEntityPk id)
        {
            var entity = await Repository.GetByIdAsync(id);
            if (entity == null)
            {
                return EntityNotFound();
            }

            return ModelResponse(StatusCodes.Status200OK, await MapRestModelAsync(entity));
        }

        [HttpGet("new")]
        public virtual async Task<ModelResponse<TRestModel>> NewAsync()
        {
            return ModelResponse(StatusCodes.Status200OK, await MapRestModelAsync(await Repository.NewAsync()));
        }

        [HttpPost]
        public virtual async Task<ModelResponse<TRestModel>> AddAsync(TRestModel item)
        {
            var entity = await MapDomainModelAsync(item, Activator.CreateInstance<TEntity>());

            var result = await Repository.AddAsync(entity);
            if (result.IsSuccess)
            {
                await AfterSaveAsync(item, result.Entity);
                return Created(await MapRestModelAsync(result.Entity));
            }

            return Errors(StatusCodes.Status422UnprocessableEntity,
                result.Errors.Select(e => new ValidationErrorResponse(e.PropertyName, e.ErrorMessage)));
        }

        [HttpPut("{id}")]
        public virtual async Task<ModelResponse<TRestModel>> UpdateAsync(TEntityPk id,
            TRestModel item)
        {
            var entity = await Repository.GetByIdAsync(id);
            if (entity == null)
            {
                return EntityNotFound();
            }

            entity = await MapDomainModelAsync(item, entity);

            var result = await Repository.UpdateAsync(entity);
            if (result.IsSuccess)
            {
                await AfterSaveAsync(item, result.Entity);
                return Updated(await MapRestModelAsync(result.Entity));
            }

            return Errors(StatusCodes.Status422UnprocessableEntity,
                result.Errors.Select(e => new ValidationErrorResponse(e.PropertyName, e.ErrorMessage)));
        }

        [HttpDelete("{id}")]
        public virtual async Task<ModelResponse<TRestModel>> DeleteAsync(TEntityPk id)
        {
            var result = await Repository.DeleteAsync(id);
            if (result) return Deleted();
            return EntityBadRequest();
        }


        protected async Task<ListResponse<TRestModel>> ListAsync(
            (IEnumerable<TEntity> items, int itemsCount) result)
        {
            var restModels = new List<TRestModel>();
            foreach (var item in result.items)
            {
                restModels.Add(await MapRestModelAsync(item));
            }

            return new ListResponse<TRestModel>().SetData(restModels, result.itemsCount);
        }

        protected QueryContext<TEntity, TEntityPk> GetQueryContext()
        {
            var context = new QueryContext<TEntity, TEntityPk>();
            if (HttpContext.Request.Query.ContainsKey("limit"))
            {
                context.Limit = int.Parse(ControllerContext.HttpContext.Request.Query["limit"]);
            }

            if (HttpContext.Request.Query.ContainsKey("offset"))
            {
                context.Offset = int.Parse(ControllerContext.HttpContext.Request.Query["offset"]);
            }

            if (HttpContext.Request.Query.ContainsKey("order"))
            {
                context.SetOrderByString(ControllerContext.HttpContext.Request.Query["order"]);
            }

            if (HttpContext.Request.Query.ContainsKey("filter") &&
                !string.IsNullOrEmpty(ControllerContext.HttpContext.Request.Query["filter"]) &&
                ControllerContext.HttpContext.Request.Query["filter"] != "null")
            {
                var str = ControllerContext.HttpContext.Request.Query["filter"].ToString();
                var mod4 = str.Length % 4;
                if (mod4 > 0)
                {
                    str += new string('=', 4 - mod4);
                }

                var data = Convert.FromBase64String(str);
                var decodedString = HttpUtility.UrlDecode(Encoding.UTF8.GetString(data));
                var where = JsonConvert.DeserializeObject<List<QueryContextConditionsGroup>>(decodedString);
                if (where != null)
                {
                    context.SetWhere(where);
                }
            }

            return context;
        }

        protected virtual Task<TRestModel> MapRestModelAsync(TEntity domainModel)
        {
            var restModel = HttpContext.RequestServices.GetRequiredService<TRestModel>();
            restModel.Id = domainModel.Id;
            restModel.ParseEntity(domainModel);
            return Task.FromResult(restModel);
        }

        protected virtual Task<TEntity> MapDomainModelAsync(TRestModel restModel, TEntity domainModel = null)
        {
            return Task.FromResult(restModel.GetEntity(domainModel));
        }

        protected virtual Task AfterSaveAsync(TRestModel restModel, TEntity domainModel)
        {
            return Task.CompletedTask;
        }

        protected T DoResponse<T>(T response) where T : RestResponse
        {
            HttpContext.Response.StatusCode = response.Code;
            return response;
        }

        protected ModelResponse<TRestModel> Errors(int code, IEnumerable<IErrorInterface> errors)
        {
            var response = new ModelResponse<TRestModel>();
            response.SetErrors(code, errors);
            return DoResponse(response);
        }

        protected ModelResponse<TRestModel> Updated(TRestModel model)
        {
            return DoResponse(ModelResponse(StatusCodes.Status202Accepted, model));
        }

        protected ModelResponse<TRestModel> Deleted()
        {
            return DoResponse(ModelResponse(StatusCodes.Status204NoContent, null));
        }

        protected ModelResponse<TRestModel> EntityNotFound()
        {
            return DoResponse(ModelResponse(StatusCodes.Status404NotFound, null));
        }

        protected ModelResponse<TRestModel> EntityBadRequest()
        {
            return DoResponse(ModelResponse(StatusCodes.Status400BadRequest, null));
        }

        protected ModelResponse<TRestModel> Created(TRestModel model)
        {
            return DoResponse(ModelResponse(StatusCodes.Status201Created, model));
        }

        private ModelResponse<TRestModel> ModelResponse(int code, TRestModel model)
        {
            return DoResponse(new ModelResponse<TRestModel>().SetModel(model, code));
        }
    }
}
