using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal Keep Get(int Id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { Id });
    }

    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      ( Name, Description, Img, IsPrivate, Userid)
      VALUES
      ( @Name, @Description, @Img, @IsPrivate, @UserId);
      SELECT LAST_INSERT_ID()";
      newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
      return newKeep;

    }

    internal void Edit(Keep updatedKeep)
    {
      string sql = @"
        UPDATE keeps
        SET
        views = @Views,
        shares = @Shares,
        keeps = @Keeps,
        isPrivate = @isPrivate,
        name = @Name,
        description = @Description
        WHERE id = @id
        ";
      _db.Execute(sql, updatedKeep);

    }

    internal bool Delete(int Id)
    {
      string sql = "DELETE FROM keeps WHERE id = @Id LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int Id)
    {
      string sql = @"
SELECT keeps.* FROM vaultkeeps 
INNER JOIN keeps ON keeps.id = vaultkeeps.keepId
WHERE vaultId = @Id;";
      return _db.Query<Keep>(sql, new { Id });


    }
  }
}