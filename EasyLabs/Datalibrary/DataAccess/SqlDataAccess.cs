using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Datalibrary.DataAccess
{

    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "LabDB")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "LabDB")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }



        /*
        private readonly IConfiguration _configuration;
        protected String ConStr;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            ConStr = _configuration.GetConnectionString("LabDB");
        }

        public static string GetConnectionString()
        {
            SqlDataAccess dataAccess = new SqlDataAccess(_configuration);
            return dataAccess.ConStr;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }*/
    }
}
