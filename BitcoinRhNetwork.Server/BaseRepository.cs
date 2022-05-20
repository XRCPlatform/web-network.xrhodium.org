using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using BitCoinRhNetwork.EF.Interfaces;
using BitCoinRhNetwork.Entities;
using BitCoinRhNetwork.Library;
using System.Linq.Expressions;

namespace BitCoinRhNetwork.Server
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : RichEntity, IIdEntity
    {
		private readonly IAmbientDbContextLocator _ambientDbContextLocator;

		public BitCoinRhNetworkDbContext DbContext
		{
			get
			{
				var dbContext = _ambientDbContextLocator.Get<BitCoinRhNetworkDbContext>();

				if (dbContext == null)
					throw new InvalidOperationException("No ambient DbContext of type UserManagementDbContext found. This means that this repository method has been called outside of the scope of a DbContextScope. A repository must only be accessed within the scope of a DbContextScope, which takes care of creating the DbContext instances that the repositories need and making them available as ambient contexts. This is what ensures that, for any given DbContext-derived type, the same instance is used throughout the duration of a business transaction. To fix this issue, use IDbContextScopeFactory in your top-level business logic service method to create a DbContextScope that wraps the entire business transaction that your service method implements. Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs file for more details.");
				
				return dbContext;
			}
		}

        public BaseRepository(IAmbientDbContextLocator ambientDbContextLocator)
		{
			if (ambientDbContextLocator == null) throw new ArgumentNullException("ambientDbContextLocator");
			_ambientDbContextLocator = ambientDbContextLocator;
		}

        public virtual TEntity GetById(long id)
		{
            return DbContext.Set<TEntity>()
                .FirstOrDefault(e => (e.Id == id) && ((!e.IsDeleted) || (e.IsDeleted)));
		}

      public virtual IQueryable<TEntity> GetAll(bool includeDeleted = false)
        {
            return DbContext.Set<TEntity>()
                .Where(e => (!e.IsDeleted) || (e.IsDeleted && includeDeleted));
        }

     public virtual IQueryable<TEntity> GetByIds(IEnumerable<long> ids, bool includeDeleted = false)
        {
            return DbContext.Set<TEntity>().AsQueryable()
                .Where(e => ids.Contains(e.Id) && ((!e.IsDeleted) || (e.IsDeleted && includeDeleted)));
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate,
            bool includeDeleted = false)
        {
            return DbContext.Set<TEntity>()
                .Where(predicate).Where(e => (!e.IsDeleted) || (e.IsDeleted && includeDeleted));
        }

        public virtual int Add(TEntity entity)
        {
            entity.IfDefined(richEntity =>
            {
                richEntity.CreatorId = GetCurrentActorId();
            });

            DbContext.Entry(entity).State = EntityState.Added;
            return DbContext.SaveChanges();
        }

        public virtual int Update(TEntity entity)
        {
            entity.IfDefined(richEntity =>
            {
                richEntity.UpdatedUtc = DateTime.UtcNow;
                richEntity.UpdaterId = GetCurrentActorId();
            });

            DbContext.Entry(entity).State = EntityState.Modified;
            return DbContext.SaveChanges();
        }

        public virtual int Update(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IfDefined(richEntity =>
                {
                    richEntity.UpdatedUtc = DateTime.UtcNow;
                    richEntity.UpdaterId = GetCurrentActorId();
                });

                DbContext.Entry(entity).State = EntityState.Modified;
            }

            return DbContext.SaveChanges();
        }
        public virtual int Delete(TEntity entity)
        {
            entity.IfDefined(richEntity =>
            {
                richEntity.UpdatedUtc = DateTime.UtcNow;
                richEntity.UpdaterId = GetCurrentActorId();
                richEntity.IsDeleted = true;
            });

            DbContext.Entry(entity).State = EntityState.Modified;
            return DbContext.SaveChanges();
        }

        private long? GetCurrentActorId()
        {
            var context = HttpContext.Current;

            if (context != null && context.User != null && context.User.Identity.IsAuthenticated)
            {
                const string key = "UserIdRequest";

                if (HttpContext.Current.Session[key] == null)
                {
                    var membershipUser = Membership.GetUser(context.User.Identity.Name);
                    if (membershipUser != null)
                    {
                        var providerUserKey = membershipUser.ProviderUserKey;
                        if (providerUserKey != null)
                        {
                            HttpContext.Current.Session[key] = providerUserKey;
                            return (int)providerUserKey;
                        }
                    }
                }
                else
                {
                    return (int)HttpContext.Current.Session[key];
                }
            }

            return null;
        }
    }
}
