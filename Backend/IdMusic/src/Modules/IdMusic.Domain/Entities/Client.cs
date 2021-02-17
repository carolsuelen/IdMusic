using IdMusic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdMusic.Domain.Entities
{
    public class Client
    {

    public Client(string name,
                  string email,
                  string password,
                  DateTime birthday,
                  Genre genre,
                  string photo,
                  string photocapa,
                  string biografy,
                  string band)
    {
      Name = name;
      Email = email;
      CriptografyPassword(password);
      Password = password;
      Birthday = birthday;
      Genre = genre;
      Photo = photo;
      PhotoCapa = photocapa;
      Biografy = biografy;
      Band = band;

    }

    public Client(string name,
                  DateTime birthday,
                  Genre genre,
                  string photo,
                  string photocapa,
                  string biografy,
                  string band)
    {
      Name = name;
      Birthday = birthday;
      Genre = genre;
      Photo = photo;
      PhotoCapa = photocapa;
      Biografy = biografy;
      Band = band;

    }
    public int Id { get; private set; }
    public string Name { get; private set; }

    public string Email { get; private set; }

    public string Password { get; private set; }

    public Genre  Genre { get; private set; }

    public DateTime Birthday { get; private set; }

    public string Photo { get; private set; }

    public string PhotoCapa  { get; private set; }

    public string Biografy { get; private set; }

    public string Band { get; private set; }

    public bool IsValid()
    {
      bool valid = true;

      if (string.IsNullOrEmpty(Name) ||
          Birthday.ToShortDateString() == "01/01/0001" ||
          Genre.Id <= 0 ||
          string.IsNullOrEmpty(Photo))
      {
        valid = false;
      }

      return valid;
    }

    private void CriptografyPassword(string password)
    {
      Password = PasswordHasher.Hash(password);
    }

    public bool IsEqualPassword(string password)
    {
      return PasswordHasher.Verify(password, Password);
    }

    public void InformationLoginClient(string email, string password)
    {
      Email = email;
      Password = password;
    }

    public void SetId(int id)
    {
      Id = id;
    }

  }
}
