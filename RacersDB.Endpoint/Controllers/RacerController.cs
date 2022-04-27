using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RacersDB.Logic;
using RacersDB.Data.Models;

namespace RacersDB.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RacerController : ControllerBase
    {
        IGetLogic getLogic;
        ISetLogic setLogic;

        public RacerController(IGetLogic getLogic, ISetLogic setLogic)
        {
            this.getLogic = getLogic;
            this.setLogic = setLogic;
        }

        [HttpGet]
        public IEnumerable<Racer> ReadAll()
        {
            return getLogic.GetAllRacers();
        }

        [HttpGet("{id}")]
        public Racer Read(int id)
        {
            return getLogic.GetOneRacer(id);
        }

        [HttpPost]
        public void Create([FromBody] Racer racerToAdd)
        {
            setLogic.AddNewRacer(racerToAdd);
        }

        [HttpPut]
        public void Update([FromBody] Racer racerToUpdate)
        {
            setLogic.UpdateRacer(racerToUpdate);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            setLogic.DeleteOldRacer(getLogic.GetOneRacer(id));
        }
    }
}
