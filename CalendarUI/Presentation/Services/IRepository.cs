using Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CalendarUI.Presentation
{
    public interface IRepository<T> where T : DataModelBase
    {
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate = null);
        Task<bool> Save(T Entity);
    }

    public class EFRepository<T> : IRepository<T> where T : DataModelBase
    {
        readonly DbSet<T> Dbset;
        readonly ILogger Logger;
        readonly CalendarDbContext Context;

        public EFRepository(
            ILogger Logger,
            CalendarDbContext Context)
        {
            this.Logger = Logger;
            this.Context = Context;
            Dbset = Context.Set<T>();
        }

        public async Task<bool> Save(T Entity)
        {
            try
            {
                var existingEntity = await Dbset.FindAsync(Entity.Id);
                if(existingEntity == null)
                {
                    Entity.CreatedDate = DateTime.UtcNow;
                    Entity.ModifiedDate = DateTime.UtcNow;

                    Dbset.Add(Entity);
                }
                else
                {
                    Entity.ModifiedDate = DateTime.UtcNow;
                    Dbset.Update(Entity);
                }

                Context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}
