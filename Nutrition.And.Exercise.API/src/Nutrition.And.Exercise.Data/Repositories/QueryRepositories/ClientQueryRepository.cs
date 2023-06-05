using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.Data;
using Nutrition.And.Exercise.Borders.Interfaces.Repositories.QueryRepositories;
using Nutrition.And.Exercise.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Data.Repositories.QueryRepositories
{
    public class ClientQueryRepository : IClientQueryRepository
    {
        private readonly DataContext _context;

        public ClientQueryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task InsertCustomer(Client client)
        {
            //using (SqlConnection connection = new SqlConnection(_context.ConnectionString))
            //{
            try
            {
                string sql = @"INSERT INTO [dbo].[Customers] (Id, Nome, DataNascimento) 
                                    VALUES (@id, @nome, @DataNascimento)";

                DynamicParameters parameters = new();
                parameters.Add("@id", client.Id, DbType.Guid);
                parameters.Add("@nome", client.Nome, DbType.AnsiString, size: 255);
                parameters.Add("@DataNascimento", client.DataNascimento, DbType.DateTime);

                using SqlConnection connection = new SqlConnection(_context.ConnectionString);
                await connection.ExecuteAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao realizar a consulta" + ex.Message);
            }
            //}
        }

        //public async Task<IEnumerable<Client>> GetCustomersAsync()
        //{

        //}

        public async Task<Client?> GetClientAsync(Guid id)
        {
            try
            {
                string sql = @"SELECT
                                Id,
                                Nome,
                                DataNascimento
                             FROM [dbo].[Customers] C
                             WHERE C.Id = @id";

                DynamicParameters parameters = new();
                parameters.Add("@id", id, DbType.Guid);

                using SqlConnection connection = new SqlConnection(_context.ConnectionString);
                return await connection.QueryFirstOrDefaultAsync<Client?>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao realizar a consulta" + ex.Message);
            }
        }
    }
}
