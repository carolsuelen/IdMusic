using IdMusic.Domain.Core;
using IdMusic.Domain.Entities;
using IdMusic.Domain.Entities.ValueObject;
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
  public class PostageRepository : IPostageRepository
  {
    private readonly IConfiguration _configuration;

    public PostageRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public async Task<List<Postage>> GetPostageByClientIdAsync(int clientId)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @$"SELECT Id,
	                                   ClientId,
                                     Text,
                                     Creation
                                FROM 
	                                Postage
                                WHERE 
	                                ClientId= '{clientId}'";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;
          con.Open();

          var reader = await cmd
                              .ExecuteReaderAsync()
                              .ConfigureAwait(false);

          var postagesForClient = new List<Postage>();

          while (reader.Read())
          {
            var postage = new Postage(int.Parse(reader["Id"].ToString()),
                                        reader["Text"].ToString(),
                                        reader["Photo"].ToString(),
                                        reader["Video"].ToString(),
                                        int.Parse(reader["ClientId"].ToString()),
                                        DateTime.Parse(reader["Creation"].ToString()));

            postagesForClient.Add(postage);
          }

          return postagesForClient;
        }
      }
    }
    public async Task<Postage> GetPostageByIdAsync(int postageId)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @$"SELECT *
                                FROM 
	                                Postage
                                WHERE 
	                                Id= '{postageId}'";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;
          con.Open();

          var reader = await cmd
                              .ExecuteReaderAsync()
                              .ConfigureAwait(false);

          while (reader.Read())
          {
            var postage = new Postage(int.Parse(reader["Id"].ToString()),
                                        reader["Text"].ToString(),
                                        reader["Photo"].ToString(),
                                        reader["Video"].ToString(),
                                        int.Parse(reader["ClientId"].ToString()),
                                        DateTime.Parse(reader["Creation"].ToString()));
            return postage;
            
          }

          return default;
        }
      }
    }

    public async Task<int> InsertAsync(Postage postage)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @"INSERT INTO
                                Postagem (ClientId,
                                          Text,
                                          Photo,
                                          Video,
                                          Creation)
                                VALUES (@clientId,
                                        @text,
                                        @photo,
                                        @video,
                                        @creation); SELECT scope_identity();";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;

          cmd.Parameters.AddWithValue("clientId", postage.ClientId);
          cmd.Parameters.AddWithValue("text", postage.Text);
          cmd.Parameters.AddWithValue("photo", postage.Photo );
          cmd.Parameters.AddWithValue("video",postage.Video);
          cmd.Parameters.AddWithValue("creation", postage.Created);

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
        var sqlCmd = $@"DELETE from Postage  WHERE id = {id}";

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
    public async Task UpdateAsync(int id, Postage postageInput)
    {
      try
      {
        using (var con = new SqlConnection(_configuration["ConnectionString"]))
        {
          var sqlCmd = $@"UPDATE Postage SET Text = @text,
                                             Photo = @photo,
                                             Video = @video,
                                       WHERE id = {postageInput.Id}";

          using (var cmd = new SqlCommand(sqlCmd, con))
          {
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("text", postageInput.Text);
            cmd.Parameters.AddWithValue("photo", postageInput.Photo);
            cmd.Parameters.AddWithValue("video", postageInput.Video);

            con.Open();
            await cmd
                            .ExecuteScalarAsync()
                            .ConfigureAwait(false);
          }
        }
      }
      catch (SqlException ex)
      {
        throw new Exception(ex.Message);
      }
    }



  }
}
