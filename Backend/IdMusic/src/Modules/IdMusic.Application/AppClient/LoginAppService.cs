using IdMusic.Application.AppClient.interfaces;
using IdMusic.Application.AppClient.output;
using IdMusic.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace IdMusic.Application.AppClient
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IClientRepository _clientRepository;

        public LoginAppService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientViewModel> LoginAsync(string login, string password)
        {
            var client = await _clientRepository
                                .GetByLoginAsync(login)
                                .ConfigureAwait(false);

            if (client is null)
            {
                throw new Exception("Usuário não encontrado");
            }

            if (!client.IsEqualPassword(password))
            {
                return default;
            }

            return new ClientViewModel()
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Genre = client.Genre,
                Birthday = client.Birthday,
                Photo = client.Photo,
                PhotoCapa = client.PhotoCapa,
                Band = client.Band,
                Biografy = client.Biografy

            };
        }
    }
}
