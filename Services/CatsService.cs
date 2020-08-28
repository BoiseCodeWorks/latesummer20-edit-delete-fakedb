using System;
using System.Collections;
using System.Collections.Generic;
using catsAPI.DB;
using catsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace catsAPI.Services
{
  public class CatsService
  {
    public IEnumerable<Cat> GetCats()
    {
      return FakeDB.Cats;
    }

    public Cat GetById(string id)
    {
      Cat foundCat = FakeDB.Cats.Find(cat => cat.Id == id);
      if (foundCat != null)
      {
        return foundCat;
      }
      throw new Exception("Opps no cat by that Id");
    }

    internal object Create(Cat newCat)
    {
      FakeDB.Cats.Add(newCat);
      return newCat;
    }

    internal Cat Edit(Cat editCat)
    {
      var current = FakeDB.Cats.Find(c => c.Id == editCat.Id);
      if (current == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDB.Cats.Remove(current);
      FakeDB.Cats.Add(editCat);
      return editCat;
    }

    internal String Delete(string id)
    {
      var current = FakeDB.Cats.Find(c => c.Id == id);
      if (current == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDB.Cats.Remove(current);
      return current.Name + " ran away";
    }
  }
}