using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SitkoCRM.Components.Repository
{
    [UsedImplicitly]
    public class RepositoryContext<TEntity, TEntityPk, TDbContext> where TEntity : class, IEntity<TEntityPk>
        where TDbContext : DbContext
    {
        public RepositoryContext(TDbContext dbContext,
            ILogger<Repository<TEntity, TEntityPk, TDbContext>> logger,
            IEnumerable<IRepositoryFilter> filters = default,
            IEnumerable<IValidator<TEntity>> validators = default)
        {
            DbContext = dbContext;
            Logger = logger;
            Filters = filters?.ToList();
            Validators = validators?.ToList();
        }

        internal TDbContext DbContext { get; }
        public ILogger<Repository<TEntity, TEntityPk, TDbContext>> Logger { get; }
        public List<IRepositoryFilter> Filters { get; }
        public List<IValidator<TEntity>> Validators { get; }
    }
}
