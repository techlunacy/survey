using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Survey.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        internal void Save()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("Insertuser", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = this.Name;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = this.Phone;
                connection.Open();
                this.Id = int.Parse(command.ExecuteScalar().ToString());
                connection.Dispose();

            }
        }
    }
}