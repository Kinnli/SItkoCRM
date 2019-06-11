using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace SitkoCRM.Components.API
{
    public class ModelResponse<TEntity> : RestResponse
    {
        public ModelResponse() : base(StatusCodes.Status200OK)
        {
        }

        public ModelResponse<TEntity> SetModel(TEntity model, int? code = null)
        {
            Model = model;
            if (code != null)
            {
                Code = code.Value;
            }

            return this;
        }

        [UsedImplicitly] public TEntity Model { get; private set; }
    }
}
