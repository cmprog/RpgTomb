using System;
using System.Collections.Generic;
using System.Web.Http;
using RpgTome.Model;
using RpgTome.Repositories;

namespace RpgTome.API.Controllers
{
    public class AbilitiesController : ApiController
    {
        private readonly IRepository mRepository;

        public AbilitiesController(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.mRepository = repository;
        }

        // GET api/abilities
        public IEnumerable<Ability> Get()
        {
            return this.mRepository.FindAll<Ability>();
        }

        // GET api/abilities/5
        public Ability Get(int id)
        {
            return this.mRepository.Get<Ability>(id);
        }

        // POST api/abilities
        public void Post([FromBody]string value)
        {
        }

        // PUT api/abilities/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/abilities/5
        public void Delete(int id)
        {
        }
    }
}
