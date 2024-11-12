using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Models;
using System.Security.Claims;

namespace NoteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly NoteAppContext _context;

        public NotesController(NoteAppContext context)
        {
            _context = context;
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
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Claim subClaim = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);
            long userId = Convert.ToInt64(subClaim.Value);

            var toGet = _context.Notes.Find(id);

            if (toGet != null && toGet.UserId == userId)
            {
                return Ok(toGet);
            }
            return NotFound();
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
        /// <returns>Returns all notes in the database.</returns>
        [HttpGet()]
        public IActionResult GetAll()
        {
            Claim subClaim = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);
            long userId = Convert.ToInt64(subClaim.Value);

            // search in DB for entries with the given user Id
            return Ok(_context.Notes.Where(n => n.UserId == userId));
        }


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
        [HttpPost()]
        public IActionResult Post(Note note)
        {
            Claim subClaim = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);
            note.UserId = Convert.ToInt64(subClaim.Value);

            var newNote = _context.Notes.Add(note);
            _context.SaveChanges();
            return Ok(newNote.Entity);
        }

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
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] long id, [FromBody] Note note)
        {
            Claim subClaim = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);
            long userId = Convert.ToInt64(subClaim.Value);

            var toEdit = _context.Notes.Find(id);

            if (toEdit != null && toEdit.UserId == userId)
            {
                toEdit.CompletionDate = note.CompletionDate;
                toEdit.DueDate = note.DueDate;
                toEdit.Name = note.Name;
                toEdit.Description = note.Description;
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }


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
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Claim subClaim = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);
            long userId = Convert.ToInt64(subClaim.Value);

            var toDelete = _context.Notes.Find(id);

            if (toDelete != null && toDelete.UserId == userId)
            {
                _context.Notes.Remove(toDelete);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}