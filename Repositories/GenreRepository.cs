using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using bricks.Models;

namespace bricks.Repositories
{
  public class GenreRepository
  {
    private readonly IDbConnection _db;
    public GenreRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Genre> GetAll()
    {
      return _db.Query<Genre>("SELECT * FROM genres");
    }

    public Genre GetById(int id)
    {
      string query = "SELECT * FROM genres WHERE id = @id";
      Genre genre = _db.QueryFirstOrDefault<Genre>(query, new { id });
      if (genre == null) throw new Exception("Invalid Id");
      return genre;
    }

    public Genre Create(Genre data)
    {
      string query = @"INSERT INTO genres (name) VALUES (@Name);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, data);
      data.Id = id;
      return data;
    }

    public Genre Update(Genre data)
    {
      string query = @"UPDATE genres
                SET
                    name = @Name
                WHERE id = @Id;
      SELECT * FROM genres WHERE id = @Id
            ";
      return _db.QueryFirstOrDefault<Genre>(query, data);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM genres WHERE id = @id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted.";
    }
  }
}