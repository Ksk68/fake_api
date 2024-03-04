using System.ComponentModel.DataAnnotations;

namespace UserApi.models
{
        
    public class GoodResponse{
        [Key]  
        public Guid id { get; set; }
        [Required]
        public string? response { get; set; }
        public bool is_final { get; set; }

    }
}