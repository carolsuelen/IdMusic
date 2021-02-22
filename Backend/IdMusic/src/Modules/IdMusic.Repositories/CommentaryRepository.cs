using IdMusic.Domain.Entities;
using IdMusic.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Repositories
{
  public class CommentaryRepository : ICommentaryRepository
  {
    private readonly IConfiguration _configuration;

    public CommentaryRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public async Task<List<Commentary>> GetByPostageIdAsync(int postageId)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @$"SELECT Id,
	                                   ClientId,
                                       PostageId,
                                       Text,
                                       Creation
                                FROM 
	                                Commentary
                                WHERE 
	                                PostageId= '{postageId}'";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;
          con.Open();

          var reader = await cmd
                              .ExecuteReaderAsync()
                              .ConfigureAwait(false);

          var commentariesForPostage = new List<Commentary>();

          while (reader.Read())
          {
            var commentary = new Commentary(int.Parse(reader["Id"].ToString()),
                                        int.Parse(reader["PostageId"].ToString()),
                                        int.Parse(reader["ClientId"].ToString()),
                                        reader["Text"].ToString(),
                                        DateTime.Parse(reader["Creation"].ToString()));

            commentariesForPostage.Add(commentary);
          }

          return commentariesForPostage;
        }
      }
    }
    public async Task<Commentary> GetCommentaryIdAsync(int id)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @$"SELECT * FROM
	                                Commentary
                                WHERE 
	                                PostageId= '{id}'";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;
          con.Open();

          var reader = await cmd
                              .ExecuteReaderAsync()
                              .ConfigureAwait(false);


          while (reader.Read())
          {
            var commentary = new Commentary(int.Parse(reader["Id"].ToString()),
                                        int.Parse(reader["PostageId"].ToString()),
                                        int.Parse(reader["ClientId"].ToString()),
                                        reader["Text"].ToString(),
                                        DateTime.Parse(reader["Creation"].ToString()));
            return commentary;
          }

          return default;
        }
      }
    }

    public async Task<int> InsertAsync(Commentary commentary)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @"INSERT INTO
                                Commentary (ClientId,
                                             PostageId,
                                             Text,
                                             Creation)
                                VALUES (@clientId,
                                        @postageId,
                                        @text,
                                        @creation); SELECT scope_identity();";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;

          cmd.Parameters.AddWithValue("clientId", commentary.ClientId);
          cmd.Parameters.AddWithValue("postageId", commentary.PostageId);
          cmd.Parameters.AddWithValue("text", commentary.Text);
          cmd.Parameters.AddWithValue("creation", commentary.Creation);

          con.Open();
          var id = await cmd
                          .ExecuteScalarAsync()
                          .ConfigureAwait(false);

          return int.Parse(id.ToString());
        }
      }
    }
    public async Task DeleteAsync(int id)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = $@"DELETE from Commentary  WHERE id = {id}";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;


          con.Open();
          await cmd
                .ExecuteScalarAsync()
                .ConfigureAwait(false);
        }
      }
    }

  }
}
