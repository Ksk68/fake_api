using System.ComponentModel.DataAnnotations;

namespace UserApi.models;

public class Chat{


    [Key]
    public int ChatId { get; set; }
     public List<Chat> ChatMessages { get; set; } = new List<Chat>();
}

