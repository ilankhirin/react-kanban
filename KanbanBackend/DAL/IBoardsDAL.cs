using System.Collections.Generic;

interface IBoardsDAL
{
    IEnumerable<Board> GetAll();
    void UpdateBoard(Board board);
    void DeleteBoard(string boardId);
}