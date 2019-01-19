using System;
using System.Collections.Generic;
using Nest;

public class ElasticSearchBoardsDAL : IBoardsDAL
{
    private const string BoardsIndex = "boards";

    private readonly string _connectionString;
    private readonly IElasticClient _elasticClient;

    public ElasticSearchBoardsDAL(string connectionString)
    {
        _connectionString = connectionString;
        ConnectionSettings connectionSettings = new ConnectionSettings(new Uri(_connectionString));
        _elasticClient = new ElasticClient(connectionSettings);
    }

    public void DeleteBoard(string boardId)
    {
        _elasticClient.Delete(new DocumentPath<Board>(boardId).Index(BoardsIndex));
    }

    public IEnumerable<Board> GetAll()
    {
        return _elasticClient.Search<Board>(x => x.Index(BoardsIndex)).Documents;
    }

    public void UpdateBoard(Board board)
    {
        _elasticClient.Index(board, x => x.Index(BoardsIndex));
    }
}