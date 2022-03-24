using InternsAPI.Domain;
using Microsoft.Data.SqlClient;
using System;

namespace InternsAPI.Repository
{
    public class InternRepository
    {
        string _connectionString = @"Data Source=LAPTOP-F79UVNP0\SQLEXPRESS;Initial Catalog=InternManagerDb;Integrated Security=True";
        SqlConnection _sqlConnection;

        public InternRepository()
        {
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public InternEntity CreateIntern(InternEntity internEntity)
        {
            _sqlConnection.Open();

            string insertQuery = "INSERT INTO DETAILSINTERN(user_name,user_age,user_squad,user_leader) " +
                $"VALUES('{internEntity.Name}', {internEntity.Age}, '{internEntity.Squad}', '{internEntity.Leader}')";
            SqlCommand insertCommand = new SqlCommand(insertQuery, _sqlConnection);
            insertCommand.ExecuteNonQuery(); 

            _sqlConnection.Close();

            return internEntity;
        }

        public InternEntity UpdateIntern(InternEntity internEntity)
        {
            
                _sqlConnection.Open();
            string updateQuery = "UPDATE DETAILSINTERN SET user_name='{internEntity.Name}', user_age={internEntity.Age}," +
           "user_squad='{internEntity.Squad}', user_leader='{internEntity.Leader}';";
                SqlCommand updateCommand = new SqlCommand(updateQuery, _sqlConnection);
                updateCommand.ExecuteNonQuery();

                _sqlConnection.Close();

                return internEntity;
           
        }

        public bool DeleteIntern(int id)
        {
            try
            {
                _sqlConnection.Open();
                string deleteQuery = "DELETE FROM DETAILSINTERN WHERE user_id =" + id;
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, _sqlConnection);
                deleteCommand.ExecuteNonQuery();

                _sqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
