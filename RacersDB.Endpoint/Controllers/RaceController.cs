using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RacersDB.Logic;
using RacersDB.Data.Models;

namespace RacersDB.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        IGetLogic getLogic;
        ISetLogic setLogic;

        public RaceController(IGetLogic getLogic, ISetLogic setLogic)
        {
            this.getLogic = getLogic;
            this.setLogic = setLogic;
        }

        [HttpGet]
        public IEnumerable<Race> ReadAll()
        {
            return getLogic.GetAllRaces();
        }

        [HttpGet("{id}")]
        public Race Read(int id)
        {
            return getLogic.GetOneRace(id);
        }

        [HttpPost]
        public void Create([FromBody] Race raceToAdd)
        {
            setLogic.AddNewRace(raceToAdd);
        }

        [HttpPut]
        public void Update([FromBody] Race raceToUpdate)
        {
            setLogic.UpdateRace(raceToUpdate);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            setLogic.DeleteOldRace(getLogic.GetOneRace(id));
        }
    }
}
