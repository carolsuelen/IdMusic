using System;
using System.Collections.Generic;
using System.Text;

namespace IdMusic.Domain.Entities
{
  public class Friends
  {
    public Friends (int clientId,
                    int friendId)
    {
      ClientId = clientId;
      FriendId = friendId;
    }

    public Friends(int id,
                   int clientId,
                   int friendId)
    {
      Id = id;
      ClientId = clientId;
      FriendId = friendId;
    }

    public int Id { get; private set; }
    public int FriendId { get; private set; }
    public int ClientId { get; private set; }

    public void SetId(int id)
    {
      Id = id;
    }
  }
}
