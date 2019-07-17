using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using bricks.Models;

namespace bricks.Repositories
{
  public class SetRepository
  {
    private readonly IDbConnection _db;
    public SetRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Set> GetAll()
    {
      return _db.Query<Set>("SELECT * FROM sets");
    }

    public Set GetById(int id)
    {
      string query = "SELECT * FROM sets WHERE id = @id";
      Set set = _db.QueryFirstOrDefault<Set>(query, new { id });
      if (set == null) throw new Exception("Invalid Id");
      return set;
    }

    public IEnumerable<Brick> GetBricks(int id)
    {
      string query = @"
      SELECT * FROM bricksets bs
      INNER JOIN bricks b on b.id = bs.brickId
      WHERE setId = @id
      ";
      return _db.Query<Brick>(query, new { id });
    }

    public string AddBrickToSet(BrickSet bs)
    {
      string query = @"
      INSERT INTO bricksets (setId, brickId)
      VALUES (@SetId, @BrickId);";
      int changedRows = _db.Execute(query, bs);
      if (changedRows < 1) throw new Exception("Invalid Ids");
      return "Successfully added Brick to Set";
    }

    public Set Create(Set data)
    {
      string query = @"INSERT INTO sets (title, info, genreId) VALUES (@Title,@Info,@GenreId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, data);
      data.Id = id;
      return data;
    }

    public Set Update(Set data)
    {
      string query = @"UPDATE sets
                SET
                    title = @Title,
                    info = @Info
                    genreId = @GenreId
                WHERE id = @Id;
      SELECT * FROM sets WHERE id = @Id
            ";
      return _db.QueryFirstOrDefault<Set>(query, data);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM sets WHERE id = @id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted.";
    }
  }
}