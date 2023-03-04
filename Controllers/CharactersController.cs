using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Nintendo.Data;
using Nintendo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nintendo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly AppDbContext context;

        public CharactersController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<CharactersController>
        [HttpGet]
        public ActionResult<IEnumerable<CharacterModel>> Get()
        {
            return Ok(context.Characters.ToList());
        }

        // GET api/<CharactersController>/5
        [HttpGet("{id}")]
        public CharacterModel? Get(int id)
        {
            return context.Characters.FirstOrDefault(c => c.Id == id);
        }

        // POST api/<CharactersController>
        [HttpPost]
        public IActionResult Post([FromBody] CharacterModel character)
        {
            List<CharacterModel> characters = context.Characters.ToList();
            CharacterModel? foundCharacter = characters.FirstOrDefault(c => c.Name == character.Name);

            if(foundCharacter == null)
            {
                context.Characters.Add(character);
                context.SaveChanges();
                return Ok();
            } 
            else
            {
                return BadRequest("Character already exists!");
            }

        }

        // PUT api/<CharactersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CharactersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
