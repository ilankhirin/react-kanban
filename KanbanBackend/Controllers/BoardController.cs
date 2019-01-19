using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigins")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardsDAL _boardsDAL;

        public BoardController(KanbanDbContext dbContext)
        {
            _boardsDAL = new EntityFrameworkBoardsDAL(dbContext);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Board>> Get()
        {
            List<Board> boards = _boardsDAL.GetAll().ToList();
            return new ActionResult<IEnumerable<Board>>(boards);
        }

        [HttpPut]
        public void Put([FromBody] Board board)
        {
            _boardsDAL.UpdateBoard(board);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _boardsDAL.DeleteBoard(id);
        }
    }
}
