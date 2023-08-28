using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.DapperRepositories;
using System.Data;

namespace Nutrition.And.Exercise.Data.Repositories.DapperRepositories
{
    public class ClientQueriesRepository : IClientQueriesRepository
    {
        private string? ConnectionString;

        public ClientQueriesRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task InsertCustomer(Client client)
        {
            try
            {
                string sql = @"INSERT INTO [dbo].[Clientes] (Id, Nome, DataNascimento) 
                                    VALUES (@id, @nome, @DataNascimento)";

                DynamicParameters parameters = new();
                parameters.Add("@id", client.Id, DbType.Guid);
                parameters.Add("@nome", client.Nome, DbType.AnsiString, size: 255);
                parameters.Add("@DataNascimento", client.DataNascimento, DbType.DateTime);

                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                await connection.ExecuteAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao realizar a consulta" + ex.Message);
            }
        }

        public async Task<ClientResponse> GetClientAsync(Guid id)
        {
            try
            {
                string sql = @"SELECT
                                Id,
                                Nome,
                                DataNascimento,
                                Cpf
                             FROM [dbo].[Clientes] C
                             WHERE C.Id = @id";

                DynamicParameters parameters = new();
                parameters.Add("@id", id, DbType.Guid);

                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<ClientResponse>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao realizar a consulta" + ex.Message);
            }
        }
    }
}
