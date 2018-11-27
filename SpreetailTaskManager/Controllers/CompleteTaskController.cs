using SpreetailTaskManager.Models;
using System.Linq;
using System.Web.Http;

namespace SpreetailTaskManager.Controllers
{
    [Authorize]
    public class CompleteTaskController : ApiController
    {
        private ApplicationDbContext _context;

        public CompleteTaskController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult TaskComplete([FromBody] int taskId)
        {
            var result = _context.DevTasks.SingleOrDefault(t => t.Id == taskId);

            if (result != null)
            {
                result.IsComplete = 1;
                _context.SaveChanges();
            }

            return Ok();
        }
    }
}
