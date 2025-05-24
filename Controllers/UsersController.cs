using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using UserApi.data;
using UserApi.models;

namespace api.Controllers
{
    [Route("api/UserController")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserContext _context;
        public bool final = false;

        
         private string apiResponse(string prompt){
            prompt = prompt.ToLower();
            string[] randomResponses = { "Lorem ipsum dolor sit amet",
                                        "consectetur adipiscing elit", 
                                         "sed do eiusmod tempor incididunt ", 
                                         "ut labore et dolore magna aliqua", 
                                         "Alea Iacta Est Cogito, Ergo Sum ", 
                                         "In Vino Veritas eiusmod tempor", 
                                         "Amor Vincit Omnia Lorem ipsum", 
                                         "Sic Parvis Magna ut labore", 
                                         "Est Cogito consectetur Magna", 
                                         "Vino Amor Omnia Iacta"};
            string[] promptResponses = {"Hello, how can i help you?", "Good morning, how can i help you?", "Goodbye, hope you come back soon."};
            Random random = new Random();
            string returnValue = "";
            if(prompt == "hello"){
                returnValue = promptResponses[random.Next(0,1)];
            }else if(prompt == "bye"){
                returnValue = promptResponses[2];
            }else if(prompt != "hello" || prompt != "bye"){
                for(int i = 0;i < random.Next(10,20);i++){
                    returnValue += randomResponses[random.Next(0,9)];
                }
            }
            return returnValue;
        }


        public UsersController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id:int}")]
        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id)!;
        }

        
        [HttpPost]
        public IActionResult Post([FromBody]UserPromptDTO userPromptDTO)
        {

            var user = new User{
                api_response = apiResponse(userPromptDTO.prompt!),
                prompt = userPromptDTO.prompt
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var response = new SucessfullResponse{
                api_response = user.api_response
            };

            return Ok(response);

        }

    }

}