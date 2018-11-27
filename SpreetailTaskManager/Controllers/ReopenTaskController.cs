using SpreetailTaskManager.Models;
using System.Linq;
using System.Web.Http;

namespace SpreetailTaskManager.Controllers
{
    [Authorize]
    public class ReopenTaskController : ApiController
    {
        private ApplicationDbContext _context;

        public ReopenTaskController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult TaskReopen([FromBody] int taskId)
        {
            var result = _context.DevTasks.SingleOrDefault(t => t.Id == taskId);

            if (result != null)
            {
                result.IsComplete = 0;
                _context.SaveChanges();
            }

            return Ok();
        }
    }
}
