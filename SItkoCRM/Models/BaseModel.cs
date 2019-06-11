using System;
using System.ComponentModel.DataAnnotations;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Models
{
    public abstract class BaseModel<T> : IEntity<T>
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public object GetId()
        {
            return Id;
        }

        [Key] public virtual T Id { get; set; }
    }
}
