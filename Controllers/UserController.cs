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
    public class UserController : ControllerBase
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
            if(prompt == "hello"|| prompt == "Hello"){
                returnValue = promptResponses[random.Next(0,1)];
            }
            if(prompt != "hello"|| prompt != "Hello"){
                for(int i = 0;i < random.Next(40,70);i++){
                    returnValue += randomResponses[random.Next(0,1)];
                }
                final = true;
            }
            return returnValue;
        }


        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<User> getUser(long id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
               return NotFound();
            }

            return user;
        }
        /*    
        [HttpPost]
         public async Task<ActionResult<User>> newChat(GoodResponse request, User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
 
            var newChat = new GoodResponse{
                id = Guid.NewGuid(),
                response = apiResponse(user.prompt),
                is_final = final
            }; 

            return Ok();
        } */
    }
}