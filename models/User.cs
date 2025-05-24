using System.ComponentModel.DataAnnotations;
using Azure;

namespace UserApi.models
{
        
    public class User{

        [Key]     
        public int Id { get; set; }   
        public string? prompt{ get; set; }
        public string? api_response { get; set; }
       
    }
}


