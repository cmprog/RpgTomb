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
    public class PlayersController : ApiController
    {
        private readonly IRepository mRepository;

        public PlayersController(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.mRepository = repository;
        }

        // GET api/players
        public IEnumerable<Player> Get()
        {
            return this.mRepository.FindAll<Player>();
        }

        // GET api/players/5
        public Player Get(int id)
        {
            return this.mRepository.Get<Player>(id);
        }

        // POST api/players
        public void Post([FromBody]string value)
        {
        }

        // PUT api/players/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/players/5
        public void Delete(int id)
        {
        }
    }
}
