using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using bricks.Models;

namespace bricks.Repositories
{
  public class BrickRepository
  {
    private readonly IDbConnection _db;
    public BrickRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Brick> GetAll()
    {
      return _db.Query<Brick>("SELECT * FROM bricks");
    }

    public Brick GetById(int id)
    {
      string query = "SELECT * FROM bricks WHERE id = @id";
      Brick brick = _db.QueryFirstOrDefault<Brick>(query, new { id });
      if (brick == null) throw new Exception("Invalid Id");
      return brick;
    }

    public Brick Create(Brick data)
    {
      string query = @"INSERT INTO bricks (shape ) VALUES (@Shape );
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, data);
      data.Id = id;
      return data;
    }

    public Brick Update(Brick data)
    {
      string query = @"UPDATE bricks
                SET
                    shape = @Shape
                WHERE id = @Id;
      SELECT * FROM bricks WHERE id = @Id
            ";
      return _db.QueryFirstOrDefault<Brick>(query, data);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM bricks WHERE id = @id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted.";
    }
  }
}