using Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Server
{
    public abstract class ApiControllerBase<T> : Controller where T : DataModelBase
    {
        readonly IRepository<T> Repo;

        protected ApiControllerBase(IRepository<T> Repo)
        {
            this.Repo = Repo;
        }

        [HttpGet("{id}")]
        public async Task<T> GetAsync(string Id)
        {
           var e = await Repo.Search(a => a.Id.Equals(Id));

            return e.FirstOrDefault();            
        }

        [HttpGet]
        public async Task<IEnumerable<T>> GetAsync()
        {
            var e = await Repo.Search();

            return e;   
        }
    }
}
