using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitkoCRM.DAL
{
    public abstract class BaseModel
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
