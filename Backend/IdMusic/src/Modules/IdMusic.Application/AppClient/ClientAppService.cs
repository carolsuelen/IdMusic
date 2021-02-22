using IdMusic.Application.AppClient.input;
using IdMusic.Application.AppClient.interfaces;
using IdMusic.Application.AppClient.output;
using IdMusic.Domain.Core.interfaces;
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
    private readonly ILogged _logged;
    public ClientAppService(IGenreRepository genreRepository,
                            IClientRepository clientRepository,
                            ILogged logged)
    {
      _genreRepository = genreRepository;
      _clientRepository = clientRepository;
      _logged = logged;
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
    public async Task<ClientViewModel> UpdateAsync( ClientInput input)
    {
      var IdClient = _logged.GetClientLoggedId();

      var client = await _clientRepository
                               .GetByIdAsync(IdClient)
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
        .UpdateAsync(IdClient, client)
        .ConfigureAwait(false);



      return new ClientViewModel()
      {
        Id = IdClient,
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
      var IdClient = _logged.GetClientLoggedId();
      var client = await _clientRepository
                         .GetByIdAsync(IdClient)
                         .ConfigureAwait(false);
      if (client is null)
      {
        throw new Exception("Cliente não encontrado");
      }

      await _clientRepository
        .DeleteAsync(IdClient)
        .ConfigureAwait(false);
    }




  }
}
