using System;
using System.Collections.Generic;
using System.Text;

namespace IdMusic.Domain.Entities
{
  public class Commentary
  {
    public Commentary(int postageId,
                     int clientId,
                     string text)
    {
      PostageId = postageId;
      ClientId = clientId;
      Text = text;

      Creation = DateTime.Now;
    }

    public Commentary(int id,
                     int postageId,
                     int clientId,
                     string text,
                     DateTime creation)
    {
      Id = id;
      PostageId = postageId;
      ClientId = clientId;
      Text = text;
      Creation = creation;
    }

    public int Id { get; private set; }
    public int PostageId { get; private set; }
    public int ClientId { get; private set; }
    public string Text { get; private set; }
    public DateTime Creation { get; private set; }

    public void SetId(int id)
    {
      Id = id;
    }
  }
}
