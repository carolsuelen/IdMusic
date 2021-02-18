using IdMusic.Application.AppClient.input;
using IdMusic.Application.AppClient.interfaces;
using IdMusic.Application.AppClient.output;
using IdMusic.Domain.Entities;
using IdMusic.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace IdMusic.Application.AppClient
{
  public class ClientAppService : IClientAppService

  {
    private readonly IGenreRepository _genreRepository;
    private readonly IClientRepository _clientRepository;
    public ClientAppService(IGenreRepository genreRepository,
                            IClientRepository clientRepository)
    {
      _genreRepository = genreRepository;
      _clientRepository = clientRepository;
    }
      public async Task<ClientViewModel> GetByIdAsync(int id)
    {
      var client = await _clientRepository
                               .GetByIdAsync(id)
                               .ConfigureAwait(false);

      if (client is null)
        return default;

      return new ClientViewModel()
      {
        Id = client.Id,
        Name = client.Name,
        Birthday = client.Birthday,
        Email = client.Email,
        Genre = client.Genre,
        Photo = client.Photo,
        PhotoCapa = client.PhotoCapa,
        Biografy = client.Biografy,
        Band = client.Band
      };
    }

    public async Task<ClientViewModel> InsertAsync(ClientInput input)
    {
      var genre = await _genreRepository
                        .GetByIdAsync(input.GenreId)
                        .ConfigureAwait(false);

      if (genre is null)
      {
        throw new ArgumentException("O genero que está tentando associar ao usuário não existe!");
      }

      var client = new Client(input.Name,
                              input.Email,
                              input.Password,
                              input.Birthday,
                              new Genre (genre.Id, genre.Description),
                              input.Photo,
                              input.PhotoCapa,
                              input.Biografy,
                              input.Band);

      if (!client.IsValid())
      {
        throw new ArgumentException("Existem dados que são obrigatórios e não foram preenchidos");
      }

      var id = await _clientRepository
                              .InsertAsync(client)
                               .ConfigureAwait(false);

      return new ClientViewModel()
      {
        Id = id,
        Name = client.Name,
        Birthday = client.Birthday,
        Email = client.Email,
        Genre = client.Genre,
        Photo = client.Photo,
        PhotoCapa = client.PhotoCapa,
        Biografy = client.Biografy,
        Band = client.Band
      };
    }
    public async Task<ClientViewModel> UpdateAsync(int id, ClientInput input)
    {
      var client = await _clientRepository
                               .GetByIdAsync(id)
                               .ConfigureAwait(false);
      if (client is null)
      {
        throw new Exception("Cliente não encontrado");
      }

      client.UpdateInfo(
                        input.Name,
                        input.Email,
                        input.Password,
                        input.Birthday,
                        input.GenreId,
                        input.Photo,
                        input.PhotoCapa,
                        input.Biografy,
                        input.Band);

      await _clientRepository
        .UpdateAsync(id, client)
        .ConfigureAwait(false);



      return new ClientViewModel()
      {
        Id = id,
        Name = client.Name,
        Birthday = client.Birthday,
        Email = client.Email,
        Genre = client.Genre,
        Photo = client.Photo,
        PhotoCapa = client.PhotoCapa,
        Biografy = client.Biografy,
        Band = client.Band
      };
    }

    public async Task DeleteAsync(int id)
    {

      var user = await _clientRepository
                         .GetByIdAsync(id)
                         .ConfigureAwait(false);
      if (user is null)
      {
        throw new Exception("Cliente não encontrado");
      }

      await _clientRepository
        .DeleteAsync(id)
        .ConfigureAwait(false);
    }




  }
}
