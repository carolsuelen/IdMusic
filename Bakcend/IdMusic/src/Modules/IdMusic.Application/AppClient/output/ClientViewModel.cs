using IdMusic.Domain.Entities;
using System;


namespace IdMusic.Application.AppClient.output
{
  public class ClientViewModel
  {
    public int Id { get;  set; }
    public string Name { get;  set; }

    public string Email { get; set; }

    public Genre Genre { get; set; }

    public DateTime Birthday { get; set; }

    public string Photo { get; set; }

    public string PhotoCapa { get; set; }

    public string Biografy { get; set; }

    public string Band { get; set; }
  }
}
