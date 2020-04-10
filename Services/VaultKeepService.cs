using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<VaultKeep> Get()
    {

      return _repo.Get();
    }

    internal VaultKeep Get(int id)
    {
      VaultKeep found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    public VaultKeep Create(VaultKeep newVaultKeeps)
    {
      return _repo.Create(newVaultKeeps);

    }

    internal VaultKeep Delete(int id, string userId)
    {
      VaultKeep found = Get(id);
      if (found.UserId != userId)
      {
        throw new Exception("Invalid Request");
      }
      if (_repo.Delete(id))
      {
        return found;
      }
      throw new Exception("This Keep was not able to be deleted.");
    }
  }
}