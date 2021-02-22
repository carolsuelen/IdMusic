using IdMusic.Domain.Entities;
using IdMusic.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IdMusic.Repositories
{
  public class GenreRepository : IGenreRepository
  {
    private readonly IConfiguration _configuration;

    public GenreRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public async Task<Genre> GetByIdAsync(int id)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @$"SELECT
                              Id,
	                            Description
                        FROM 
	                            Genre
                        WHERE 
	                            Id= {id}";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;
          con.Open();

          var reader = await cmd
                              .ExecuteReaderAsync()
                              .ConfigureAwait(false);

          while (reader.Read())
          {

            var genre = new Genre(reader["Description"].ToString());
            genre.SetId(int.Parse(reader["id"].ToString()));

            return genre;
          }

          return default;
        }
      }
    }
  }
}
