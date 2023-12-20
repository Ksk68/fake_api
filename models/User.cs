namespace UserApi.models;

public class User{

    public int Id { get; set; }

    public List<Chat> ChatMessages { get; set; } = new List<Chat>();
}

