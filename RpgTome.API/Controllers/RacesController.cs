using System;
using System.Collections.Generic;
using System.Web.Http;
using RpgTome.Model;
using RpgTome.Repositories;

namespace RpgTome.API.Controllers
{
    public class RacesController : ApiController
    {
        private readonly IRepository mRepository;

        public RacesController(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.mRepository = repository;
        }

        // GET api/races
        public IEnumerable<Race> Get()
        {
            return this.mRepository.FindAll<Race>();
        }

        // GET api/races/5
        public Race Get(int id)
        {
            return this.mRepository.Get<Race>(id);
        }

        // POST api/races
        public void Post([FromBody]string value)
        {
        }

        // PUT api/races/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/races/5
        public void Delete(int id)
        {
        }
    }
}
