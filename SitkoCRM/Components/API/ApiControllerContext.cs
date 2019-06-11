using Microsoft.Extensions.Logging;
using SitkoCRM.Components.Repository;
using SitkoCRM.Components.Storage;

namespace SitkoCRM.Components.API
{
    public class ApiControllerContext<TEntity, TEntityPk> : ApiControllerContext
        where TEntity : class, IEntity<TEntityPk>
    {
        public IRepository<TEntity, TEntityPk> Repository { get; }

        public ApiControllerContext(ILoggerFactory loggerFactory,
            IRepository<TEntity, TEntityPk> repository, IStorage storage) : base(
            loggerFactory, storage)
        {
            Repository = repository;
        }
    }

    public class ApiControllerContext
    {
        public ILogger Logger { get; }
        public IStorage Storage;

        public ApiControllerContext(ILoggerFactory loggerFactory, IStorage storage)
        {
            Logger = loggerFactory.CreateLogger(GetType());
            Storage = storage;
        }
    }
}
