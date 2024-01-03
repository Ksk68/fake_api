using System.ComponentModel.DataAnnotations;

namespace UserApi.models
{
        
    public class noGoodResponse{
        [Key]  
        public string? title { get; set; }
        public int status { get; set; }
        public string? detail { get; set; }

    }
}