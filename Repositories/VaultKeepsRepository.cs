using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<VaultKeep> Get()
    {
      string sql = "SELECT * FROM vaultkeeps WHERE isPrivate = 0;";
      return _db.Query<VaultKeep>(sql);
    }

    internal VaultKeep Get(int Id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { Id });
    }

    public VaultKeep Create(VaultKeep newVaultKeeps)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      ( VaultId, KeepId, Userid)
      VALUES
      ( @VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID()";
      newVaultKeeps.Id = _db.ExecuteScalar<int>(sql, newVaultKeeps);
      return newVaultKeeps;

    }



    internal bool Delete(int Id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @Id LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }
  }
}