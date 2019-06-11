using System.Collections.Generic;

namespace SitkoCRM.Components.API
{
    public class RestResponse
    {
        public RestResponse(int code, IEnumerable<IErrorInterface> errors = null)
        {
            Code = code;
            if (errors != null)
            {
                Errors = errors;
            }
        }

        public int Code { get; protected set; }

        public IEnumerable<IErrorInterface> Errors { get; protected set; }

        public RestResponse SetErrors(int code, IEnumerable<IErrorInterface> errors = null)
        {
            Code = code;
            Errors = errors;
            return this;
        }
    }
}
