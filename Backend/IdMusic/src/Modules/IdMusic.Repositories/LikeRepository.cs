using IdMusic.Domain.Entities;
using IdMusic.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IdMusic.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly IConfiguration _configuration;

        public LikeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task DeleteAsync(int id)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = $@"DELETE 
                                FROM
                                Likes
                               WHERE 
                                Id={id}";

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

        public async Task<Like> GetByClientIdAndPostageIdAsync(int clientId, int postageId)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT Id,
	                                   ClientId
                                       PostageId
                                FROM 
	                                Likes
                                WHERE 
	                                ClientId= '{clientId}'
                                AND 
                                    PostageId= '{postageId}'";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                        .ExecuteReaderAsync()
                                        .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var liker = new Like(int.Parse(reader["Id"].ToString()),
                                                int.Parse(reader["PostageId"].ToString()),
                                                int.Parse(reader["ClientId"].ToString()));

                        return liker;
                    }

                    return default;
                }
            }
        }

        public async Task<int> GetQuantityOfLikeByPostageIdAsync(int postageId)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT
                                    COUNT(*) AS Quantidade
                                FROM 
	                                Likes
                                WHERE 
	                                PostageId={postageId}";

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

        public async Task<int> InsertAsync(Like like)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @"INSERT INTO
                                Likes (ClientId,
                                           PostageId)
                                VALUES (@clientId,
                                        @postageId); SELECT scope_identity();";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("clientId", like.ClientId);
                    cmd.Parameters.AddWithValue("postageId", like.PostageId);

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

