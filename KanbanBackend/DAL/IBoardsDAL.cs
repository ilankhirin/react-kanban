using System.Collections.Generic;

public interface IBoardsDAL
{
    IEnumerable<Board> GetAll();
    void UpdateBoard(Board board);
    void DeleteBoard(string boardId);
}