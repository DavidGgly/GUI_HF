using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RacersDB.Logic;
using RacersDB.Data.Models;

namespace RacersDB.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RacetrackController : ControllerBase
    {
        IGetLogic getLogic;
        ISetLogic setLogic;

        public RacetrackController(IGetLogic getLogic, ISetLogic setLogic)
        {
            this.getLogic = getLogic;
            this.setLogic = setLogic;
        }

        [HttpGet]
        public IEnumerable<Racetrack> ReadAll()
        {
            return getLogic.GetAllRacetracks();
        }

        [HttpGet("{id}")]
        public Racetrack Read(int id)
        {
            return getLogic.GetOneRacetrack(id);
        }

        [HttpPost]
        public void Create([FromBody] Racetrack racetrackToAdd)
        {
            setLogic.AddNewRacetrack(racetrackToAdd);
        }

        [HttpPut]
        public void Update([FromBody] Racetrack racetrackToUpdate)
        {
            setLogic.UpdateRacetrack(racetrackToUpdate);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            setLogic.DeleteOldRacetrack(getLogic.GetOneRacetrack(id));
        }
    }
}
