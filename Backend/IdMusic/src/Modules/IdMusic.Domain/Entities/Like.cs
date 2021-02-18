namespace IdMusic.Domain.Entities
{
  public class Like
  {
    public Like(int postageId,
                  int clientId)
    {
        PostageId = postageId;
        ClientId = clientId;
    }

    public Like(int id,
                  int postageId,
                  int clientId)
    {
      Id = id;
      PostageId = postageId;
      ClientId = clientId;
    }

    public int Id { get; private set; }
    public int PostageId { get; private set; }
    public int ClientId  { get; private set; }

  }
}
