using FirstApi.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamsContext db;
        public TeamsController(TeamsContext _db)
        {
            db = _db;

        }
        [HttpGet]
        public IActionResult GetTeams()
        {
            return Ok(db.Teams.ToList());
        }

        //public IActionResult Addteam(Team team)
        //{
        //    var addedTeam = db.Add(team);
        //    db.SaveChanges();
        //    return Ok(addedTeam.Entity);
        //}
        [HttpPost]

        public IActionResult CreateTeam(TeamDTO teamDTO)
        {
            if (ModelState.IsValid)
            {
                Team newTeam = new Team()
                {
                    Name = teamDTO.Name,
                    Description = teamDTO.Description,
                };

                var addedTeam = db.Teams.Add(newTeam);
                db.SaveChanges();
                return Ok(addedTeam);
            }
            else
            {
                return BadRequest("Invalid Data");
            }
        }

        [HttpPut]
        public IActionResult EditTeam(int id, TeamDTO teamDTO)
        {
            var teamData = db.Teams.FirstOrDefault(a => a.Id == id);
            if (teamData != null)
            {
                teamData.Name = teamDTO.Name;
                teamData.Description = teamDTO.Description;
                var editedTeam = db.Teams.Update(teamData);
                db.SaveChanges();
                return Ok(editedTeam.Entity);
            }
            else
            {
                return NotFound("Invalid User");
            }
        }

        [HttpDelete]

        public IActionResult DeleteTeam(int id)
        {
            var teamData = db.Teams.FirstOrDefault(a => a.Id == id);
            if (teamData != null)
            {
                var deletedTeam = db.Teams.Remove(teamData);
                db.SaveChanges();
                return Ok(deletedTeam.Entity);
            }
            else
            {
                return NotFound("Invalid User");
            }
        }

        [HttpGet("{name?}/{id:int?}")]
        public IActionResult DetailTeam(string name = null, int? id = null)
        {
            var Detail = db.Teams.FirstOrDefault(a => (name != null && a.Name == name) || (id.HasValue && a.Id == id));

            if (Detail != null)
            {
                return Ok(Detail);
            }
            else
            {
                return NotFound("Invalid Team");
            }
        }


    }
}
