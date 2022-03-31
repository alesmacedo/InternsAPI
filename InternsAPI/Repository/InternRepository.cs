using InternsAPI.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace InternsAPI.Repository
{
    public class InternRepository
    {
        string _connectionString = @"Data Source=LAPTOP-F79UVNP0\SQLEXPRESS;Initial Catalog=InternAPI;Integrated Security=True";
        SqlConnection _sqlConnection;

        public InternRepository()
        {
            _sqlConnection = new SqlConnection(_connectionString);
        }
        public List<InternEntity> GetAllInterns(string interns)
        {
            _sqlConnection.Open();

            string displayAllQuery = "SELECT * FROM InternTable";
            SqlCommand displayAllCommand = new SqlCommand(displayAllQuery, _sqlConnection);
            var reader = displayAllCommand.ExecuteReader();

            List<InternEntity> list = new List<InternEntity>();
            while (reader.Read())
            {
                InternEntity internEntity = new InternEntity()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Age = reader.GetInt32(2),
                    Squad = reader.GetString(3),
                    Leader = reader.GetString(4)
                };
                list.Add(internEntity);
            }

            _sqlConnection.Close();

            var result = FilterList(list, "Alessandro");

            return list;
        }
        public InternEntity GetIntern(int id)
        {
            _sqlConnection.Open();

            string displayQuery = "SELECT ID, Name, Age, Squad, Leader FROM InternTable WHERE ID =" + id;
            SqlCommand displayCommand = new SqlCommand(displayQuery, _sqlConnection);
            var reader = displayCommand.ExecuteReader();

            InternEntity internEntity = new InternEntity();
            while (reader.Read())
            {
                internEntity.Id = reader.GetInt32(0);
                internEntity.Name = reader.GetString(1);
                internEntity.Age = reader.GetInt32(2);
                internEntity.Squad = reader.GetString(3);
                internEntity.Leader = reader.GetString(4);
            }

            _sqlConnection.Close();

            return internEntity;
        }
        public InternEntity CreateIntern(InternEntity internEntity)
        {
            _sqlConnection.Open();

            string insertQuery =
                "INSERT INTO InternTable(Name,Age,Squad,Leader) " +
                "OUTPUT INSERTED.*" +
                $"VALUES('{internEntity.Name}', {internEntity.Age}, '{internEntity.Squad}', '{internEntity.Leader}') ";

            SqlCommand insertCommand = new SqlCommand(insertQuery, _sqlConnection);

            var reader = insertCommand.ExecuteReader();

            InternEntity intern = new InternEntity();
            while (reader.Read())
            {
                intern.Id = reader.GetInt32(0);
                intern.Name = reader.GetString(1);
                intern.Age = reader.GetInt32(2);
                intern.Squad = reader.GetString(3);
                intern.Leader = reader.GetString(4);
            }

            _sqlConnection.Close();

            return intern;
        }
        public InternEntity UpdateIntern(InternEntity internEntity)
        {
            _sqlConnection.Open();

            string updateQuery = $"UPDATE InternTable SET Name='{internEntity.Name}', Age={internEntity.Age}," +
                $"Squad='{internEntity.Squad}', Leader='{internEntity.Leader}' WHERE ID=" + internEntity.Id;
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

                string deleteQuery = "DELETE FROM InternTable WHERE ID =" + id;
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
        private List<InternEntity> FilterList(List<InternEntity> rawList,string filterParam)
        {
            List<InternEntity> filteredList = new List<InternEntity>();
            foreach (var raw in rawList)
            {
                if(raw.Name == filterParam)
                    filteredList.Add(raw);
            }
            return filteredList;
        }
    }
}
