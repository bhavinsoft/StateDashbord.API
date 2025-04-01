﻿using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Persistence
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MySqlConnection");
        }

        public DbConnection CreateConnection() => new MySqlConnection(_connectionString);

        private async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, object parameters, CommandType commandType, IDbTransaction dbTransaction = null)
        {
            try
            {
                using (var dbConnection = CreateConnection())
                {
                    await dbConnection.OpenAsync();
                    return await dbConnection.QueryAsync<T>(query, parameters, dbTransaction, commandType: commandType);
                }
            }
            catch (Exception ex)
            {
                // Log error
                // ErrorLogger.Error($"Error in query => {query} \r\n CommandType = {commandType}", ex.ToString());
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetListResultAsync<T>(string query, CommandType commandType, Dictionary<string, object> parameters = null, IDbTransaction dbTransaction = null)
        {
            return await ExecuteQueryAsync<T>(query, new DynamicParameters(parameters), commandType, dbTransaction);
        }

        public async Task<IEnumerable<T>> GetMultipleListResultAsync<T>(string query, CommandType commandType, List<Dictionary<string, object>> parametersList, IDbTransaction dbTransaction = null)
        {
            var results = new List<T>();
            foreach (var parameters in parametersList)
            {
                results.AddRange(await ExecuteQueryAsync<T>(query, new DynamicParameters(parameters), commandType, dbTransaction));
            }
            return results;
        }

        public async Task<List<IEnumerable<dynamic>>> GetDynamicMultipleResultSetsAsync(string spQuery, Dictionary<string, object> parameters)
        {
            try
            {
                using (var dbConnection = CreateConnection())
                {
                    await dbConnection.OpenAsync();
                    var dynamicParams = new DynamicParameters(parameters);
                    using (var multi = await dbConnection.QueryMultipleAsync(spQuery, dynamicParams, commandType: CommandType.StoredProcedure))
                    {
                        var resultSets = new List<IEnumerable<dynamic>>();
                        while (!multi.IsConsumed)
                        {
                            resultSets.Add(await multi.ReadAsync());
                        }
                        return resultSets;
                    }
                }
            }
            catch (Exception ex)
            {
                // ErrorLogger.Error($"Error in {spQuery}", ex.ToString());
                throw;
            }
        }

        public async Task<bool> ExecuteWithoutResultAsync(string storedProcedureName, CommandType commandType, Dictionary<string, object> parameters = null, IDbTransaction dbTransaction = null)
        {
            try
            {
                using (var dbConnection = CreateConnection())
                {
                    await dbConnection.OpenAsync();
                    await dbConnection.ExecuteAsync(storedProcedureName, new DynamicParameters(parameters), dbTransaction, commandType: commandType);
                    return true;
                }
            }
            catch (Exception ex)
            {
                // ErrorLogger.Error($"Error in stored procedure => {storedProcedureName} \r\n CommandType = {commandType}", ex.ToString());
                return false;
            }
        }

        public async Task<int> ExecuteAndReturnIdAsync(string storedProcedureName, CommandType commandType, Dictionary<string, object> parameters = null, IDbTransaction dbTransaction = null)
        {
            try
            {
                using (var dbConnection = CreateConnection())
                {
                    await dbConnection.OpenAsync();
                    return await dbConnection.ExecuteScalarAsync<int>(storedProcedureName, new DynamicParameters(parameters), dbTransaction, commandType: commandType);
                }
            }
            catch (Exception ex)
            {
                // ErrorLogger.Error($"Error in stored procedure => {storedProcedureName} \r\n CommandType = {commandType}", ex.ToString());
                return -1;  // Return -1 to indicate failure
            }
        }
    }
}
