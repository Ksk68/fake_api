using System.ComponentModel.DataAnnotations;
using Azure;

namespace UserApi.models
{
        
    public class User{

        [Key]        
        public string? prompt{ get; set; }
    }
}


