using System.Text.Json.Serialization;

namespace NoteApp.Models
{
    public class Note
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        [JsonIgnore] public long UserId { get; set; }
        [JsonIgnore] public virtual User? User { get; set; }
    }
}
