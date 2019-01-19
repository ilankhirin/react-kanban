using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

class EntityFrameworkBoardsDAL : IBoardsDAL
{
    private readonly KanbanDbContext _dbContext;

    public EntityFrameworkBoardsDAL(KanbanDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void DeleteBoard(string boardId)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            RemoveBoard(boardId);
            _dbContext.SaveChanges();
            transaction.Commit();
        }
    }

    public IEnumerable<Board> GetAll()
    {
        return _dbContext.Boards.Include(x => x.Lists).ThenInclude(x => x.Cards);
    }

    public void UpdateBoard(Board board)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            RemoveBoard(board.BoardId);
            _dbContext.Boards.Add(board);
            _dbContext.SaveChanges();
            transaction.Commit();
        }
    }

    private void RemoveBoard(string boardId)
    {
        var boardInDb = _dbContext.Boards.Find(boardId);
        if (boardInDb != null)
        {
            EntityEntry<Board> boardEntry = _dbContext.Entry(boardInDb);
            boardEntry.Collection(x => x.Lists).Load();
            boardEntry.Entity.Lists.ToList().ForEach(DeleteKanbanList);

            _dbContext.Boards.Remove(boardInDb);
        }
    }

    private void DeleteKanbanList(KanbanList list)
    {
        EntityEntry<KanbanList> listEntry = _dbContext.Entry(_dbContext.Lists.Find(list.KanbanListId));
        listEntry.Collection(x => x.Cards).Load();
        listEntry.Entity.Cards.ToList().ForEach(DeleteCard);

        _dbContext.Lists.Remove(list);
    }

    private void DeleteCard(Card card)
    {
        _dbContext.Cards.Remove(card);
    }
}