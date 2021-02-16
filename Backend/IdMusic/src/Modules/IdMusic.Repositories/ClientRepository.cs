using IdMusic.Domain.Entities;
using IdMusic.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace IdMusic.Repositories
{
  public class ClientRepository : IClientRepository
  {

    private readonly IConfiguration _configuration;

    public ClientRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public async Task<Client> GetByIdAsync(int id)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @$"SELECT u.Id,
	                             u.Name,
	                             u.Email,
	                             u.Password,
                               u.Birthday,
                               u.Photo,
                               u.PhotoCapa,
                               u.Biografy,
                               u.Band,
	                             g.Id as GenreId,
	                             g.Description
                        FROM
                              Usuario u
                          INNER JOIN 
	                            Genre g ON g.Id = u.GenreId
                          WHERE 
	                            u.Id= '{id}'";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;
          con.Open();

          var reader = await cmd
                              .ExecuteReaderAsync()
                              .ConfigureAwait(false);

          while (reader.Read())
          {

            var client = new Client(reader["Name"].ToString(),
                                      DateTime.Parse(reader["Birthday"].ToString()),
                                      new Genre(reader["Description"].ToString()),
                                      reader["Photo"].ToString(),
                                      reader["PhotoCapa"].ToString(),
                                      reader["Biografy"].ToString(),
                                      reader["Band"].ToString());


            client.InformationLoginClient(reader["Email"].ToString(), reader["Password"].ToString());
            client.SetId(int.Parse(reader["id"].ToString()));
            client.Genre.SetId(int.Parse(reader["GenreId"].ToString()));

            return client;
          }

          return default;
        }
      }
    }

    public async Task<Client> GetByLoginAsync(string login)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @$"SELECT c.Id,
	                                 c.Name,
	                                 c.Email,
	                                 c.Password,
                                   c.Birthday,
                                   c.Photo,
                                   c.PhotoCapa,
                                   c.Biografy,
                                   c.Band,
	                                 g.Id as GenreId,
	                                 g.Description
                                FROM
	                                Client c
                                INNER JOIN 
	                                Genre g ON g.Id = u.GenreId
                                WHERE 
	                                c.Email= '{login}'";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;
          con.Open();

          var reader = await cmd
                              .ExecuteReaderAsync()
                              .ConfigureAwait(false);

          while (reader.Read())
          {

            var client = new Client(reader["Name"].ToString(),
                                      DateTime.Parse(reader["Birthday"].ToString()),
                                      new Genre(reader["Description"].ToString()),
                                      reader["Photo"].ToString(),
                                      reader["PhotoCapa"].ToString(),
                                      reader["Biografy"].ToString(),
                                      reader["Band"].ToString());
                                    

            client.InformationLoginClient(reader["Email"].ToString(), reader["Password"].ToString());
            client.SetId(int.Parse(reader["id"].ToString()));
            client.Genre.SetId(int.Parse(reader["GenreId"].ToString()));

            return client;
          }

          return default;
        }
      }
    }

    public async Task<int> InsertAsync(Client client)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @"INSERT INTO
                                Client (GenreId,
                                           Name,
                                           Email,
                                           Password,
                                           Birthday,
                                           Photo,
                                           PhotoCapa,
                                           Biografy,
                                           Band)
                                VALUES (@genreId,
                                        @name,
                                        @email,
                                        @password,
                                        @birthday,
                                        @photo,
                                        @photocapa,
                                        @biografy,
                                        @band); SELECT scope_identity();";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;

          cmd.Parameters.AddWithValue("genreId", client.Genre.Id);
          cmd.Parameters.AddWithValue("name", client.Name);
          cmd.Parameters.AddWithValue("email", client.Email);
          cmd.Parameters.AddWithValue("password", client.Password);
          cmd.Parameters.AddWithValue("birthday", client.Birthday);
          cmd.Parameters.AddWithValue("photo", client.Photo);
          cmd.Parameters.AddWithValue("photocapa", client.PhotoCapa);
          cmd.Parameters.AddWithValue("biografy", client.Biografy);
          cmd.Parameters.AddWithValue("band", client.Band);

          con.Open();
          var id = await cmd
                          .ExecuteScalarAsync()
                          .ConfigureAwait(false);

          return int.Parse(id.ToString());
        }
      }
    }
  }
}
