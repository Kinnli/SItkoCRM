using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SitkoCRM.Components.API
{
    public class ListResponse<TEntity> : RestResponse
    {
        public ListResponse() : base(StatusCodes.Status200OK)
        {
        }

        public ListResponse<TEntity> SetData(IEnumerable<TEntity> data, int totalItems)
        {
            Data = data;
            TotalItems = totalItems;
            return this;
        }

        [JsonProperty] public IEnumerable<TEntity> Data { get; private set; }

        [JsonProperty] public int TotalItems { get; private set; }
    }
}
