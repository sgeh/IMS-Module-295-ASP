using Microsoft.AspNetCore.Mvc;

namespace NoteApp.Controllers
{
    public class Note
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
    }


    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private static List<Note> _notes = new List<Note> { // CAUTION: Do not use that approach in production code!
            new Note { Id = 1, Name="Homework", Description = "Do some homework for M295." }
        };

        public NotesController()
        {
        }

        /// <summary>
        /// GET: api/notes
        /// </summary>
        /// <example>
        ///  <code>
        ///  async function getNotes() {
        ///    const request = await fetch('http://localhost:4200/api/notes/', {
        ///      headers: {
        ///        'Accept': 'application/json'
        ///        },
        ///      method: 'GET'
        ///    });
        ///    const data = await request.json();
        ///    console.log(data);
        ///  }
        ///  </code>
        /// </example>
        /// <returns>Returns all notes stored in the database.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_notes);
        }

        /// <summary>
        /// GET: api/notes/5
        /// </summary>
        /// <example>
        ///  <code>
        ///  async function getNote() {
        ///    const request = await fetch('http://localhost:4200/api/notes/1', {
        ///      headers: {
        ///        'Accept': 'application/json'
        ///        },
        ///      method: 'GET'
        ///    });
        ///    const data = await request.json();
        ///    console.log(data);
        ///  }
        ///  </code>
        /// </example>
        /// <param name="id">ID of the note to retrieve.</param>
        /// <returns>Returns the note associated to the given id.</returns>
        /// TODO: add [Http...?] Annotation and uncomment Method definition:
        ///   public IActionResult Get(long id) { }


        /// <summary>
        /// POST: api/notes
        /// </summary>
        /// <example>
        ///  <code>
        ///  async function addNote() {
        ///    const request = await fetch('http://localhost:4200/api/notes/', {
        ///      headers: {
        ///        'Accept': 'application/json',
        ///        'Content-Type': 'application/json'
        ///        },
        ///      method: 'POST',
        ///      body: JSON.stringify({ todo: 'new todo', dueDate: '2023-08-19T18:31:35.294Z', completionDate: '2023-08-19T18:31:35.294Z' }),
        ///    });
        ///    const data = await request.json();
        ///    console.log(data);
        ///  }
        ///  </code>
        /// </example>
        /// <param name="note">Note data to be stored.</param>
        /// <returns>Returns the created note.</returns>
        /// TODO: add [Http...?] Annotation and uncomment Method definition:
        ///   public IActionResult Post(Note note) { }


        /// <summary>
        /// PUT: api/notes/5
        /// </summary>
        /// <example>
        ///  <code>
        ///  async function updateNote() {
        ///    const request = await fetch('http://localhost:4200/api/notes/1', {
        ///      headers: {
        ///        'Accept': 'application/json',
        ///        'Content-Type': 'application/json'
        ///        },
        ///      method: 'PUT',
        ///      body: JSON.stringify({ id: 1, todo: 'overwrite todo', dueDate: '2023-08-20T18:31:35.294Z', completionDate: '2023-08-20T18:31:35.294Z' }),
        ///    });
        ///    const data = request.status;
        ///    console.log(data);
        ///  }
        ///  </code>
        /// </example>
        /// <param name="id">ID of the note to be edited.</param>
        /// <param name="note">Note data to be stored.</param>
        /// <returns>Nothing, see HTTP status code.</returns>
        /// TODO: add [Http...?] Annotation and uncomment Method definition:
        ///   public IActionResult Put([FromRoute] long id, [FromBody] Note note)


        /// <summary>
        /// DELETE: api/notes/5
        /// </summary>
        /// <example>
        ///  <code>
        ///  async function deleteNote() {
        ///    const request = await fetch('http://localhost:4200/api/notes/1', {
        ///      headers: {
        ///        'Accept': 'application/json',
        ///        'Content-Type': 'application/json'
        ///        },
        ///      method: 'DELETE'
        ///    });
        ///    const data = request.status;
        ///    console.log(data);
        ///  }
        ///  </code>
        /// </example>
        /// <param name="id">ID of the note to be deleted.</param>
        /// <returns>Nothing, see HTTP status code.</returns>
        /// TODO: add [Http...?] Annotation and uncomment Method definition:
        ///   public IActionResult Delete(long id) { }
    }
}