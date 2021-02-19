using System;
using System.Collections.Generic;
using System.Text;

namespace IdMusic.Domain.Entities
{
  public class Postage
  {
    public Postage(string text,
                    int clientId)
    {
      Text = text;
      ClientId = clientId;

      Created = DateTime.Now;
    }

    public Postage(int id,
                    string text,
                    string photo,
                    string video,
                    int clientId,
                    DateTime created)
    {
      Id = id;
      Text = text;
      Photo = photo;
      Video = video;
      ClientId = clientId;
      Created = created;
    }

    public int Id { get; private set; }
    public int ClientId { get; private set; }
    public string Text { get; private set; }
    public string Photo { get; private set; }
    public string Video { get; private set; }
    public DateTime Created { get; private set; }
    public void UpdateInfo(string text,
                           string photo,
                           string video)
    {
      Text = text;
      Photo = photo;
      Video = video;
    }
    public void SetId(int id)
    {
      Id = id;
    }

  }
}
