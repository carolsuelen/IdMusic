using System;
using System.Collections.Generic;
using System.Text;

namespace IdMusic.Domain.Entities
{
  public class Genre
  {
    public Genre(string description)
    {
      Description = description;
    }

    public Genre(int id,
                 string description)
    {
      Id = id;
      Description = description;
    }
    public int Id { get; private set; }
    public string Description { get; private set; }

    public bool IsValid()
    {
      bool valid = true;
      if (string.IsNullOrEmpty(Description))
        {
        valid = false;
      }
      return valid;
    }

    public void SetId(int id)
    {
      Id = id;
    }
  }
}
