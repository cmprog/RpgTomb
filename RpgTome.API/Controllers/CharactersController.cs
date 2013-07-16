using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RpgTome.Model;
using RpgTome.Repositories;

namespace RpgTome.API.Controllers
{
    public class CharactersController : ApiController
    {
        private readonly IRepository mRepository;

        public CharactersController(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.mRepository = repository;
        }

        // GET api/characters
        public IEnumerable<Character> Get()
        {
            return this.mRepository.FindAll<Character>();
        }

        // GET api/characters/5
        public Character Get(int id)
        {
            return this.mRepository.Get<Character>(id);
        }

        // POST api/characters
        public void Post([FromBody]string value)
        {
        }

        // PUT api/characters/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/characters/5
        public void Delete(int id)
        {
        }
    }
}
