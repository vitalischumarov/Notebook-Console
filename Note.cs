public class Note
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }

    public Note(int _id, string _title, string _description)
    {
        id = _id;
        title = _title;
        description = _description;
    }
}