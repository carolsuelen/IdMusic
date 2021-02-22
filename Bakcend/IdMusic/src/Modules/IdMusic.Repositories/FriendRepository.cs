using System;
using IdMusic.Domain.Entities;
using IdMusic.Domain.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace IdMusic.Repositories
{
  public class FriendRepository : IFriendRepository
  {
    private readonly IConfiguration _configuration;

    public FriendRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public async Task<List<Friends>> GetByFriendIdAsync(int friendId)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @$"SELECT Id,
	                             ClientId,
                               FriendId,
                                FROM 
	                                Friend
                                WHERE 
	                                ClientId= '{friendId}'";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;
          con.Open();

          var reader = await cmd
                              .ExecuteReaderAsync()
                              .ConfigureAwait(false);

          var friendsForClient = new List<Friends>();

          while (reader.Read())
          {
            var friend = new Friends(int.Parse(reader["Id"].ToString()),
                                        int.Parse(reader["ClientId"].ToString()),
                                        int.Parse(reader["FriendId"].ToString()));

            friendsForClient.Add(friend);
          }

          return friendsForClient;
        }
      }
    }
    public async Task<Friends> GetFriendIdAsync(int id)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @$"SELECT * FROM
	                                Friend
                                WHERE 
	                                ClientId= '{id}'";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;
          con.Open();

          var reader = await cmd
                              .ExecuteReaderAsync()
                              .ConfigureAwait(false);


          while (reader.Read())
          {
            var friend = new Friends(int.Parse(reader["Id"].ToString()),
                                        int.Parse(reader["ClientId"].ToString()),
                                        int.Parse(reader["FriendId"].ToString()));
            return friend;
          }

          return default;
        }
      }
    }

    public async Task<int> InsertAsync(Friends friends)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @"INSERT INTO
                                Friend (ClientId,
                                        FriendId,)
                                VALUES (@clientId,
                                        @friendId); SELECT scope_identity();";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;

          cmd.Parameters.AddWithValue("clientId", friends.ClientId);
          cmd.Parameters.AddWithValue("friendId", friends.FriendId);

          con.Open();
          var id = await cmd
                          .ExecuteScalarAsync()
                          .ConfigureAwait(false);

          return int.Parse(id.ToString());
        }
      }
    }
    public async Task<int> GetQuantityOfFriendByIdAsync(int friendId)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = @$"SELECT
                                    COUNT(*) AS Quantidade
                                FROM 
                                 Friends
                                WHERE 
                                 FriendId={friendId}";

        using (var cmd = new SqlCommand(sqlCmd, con))
        {
          cmd.CommandType = CommandType.Text;
          con.Open();

          var reader = await cmd
                              .ExecuteReaderAsync()
                              .ConfigureAwait(false);

          while (reader.Read())
          {
            return int.Parse(reader["Quantidade"].ToString());
          }

          return default;
        }

      }
    }
    public async Task DeleteAsync(int id)
    {
      using (var con = new SqlConnection(_configuration["ConnectionString"]))
      {
        var sqlCmd = $@"DELETE from Friends  WHERE id = {id}";

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
