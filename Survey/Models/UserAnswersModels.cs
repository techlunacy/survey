using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Survey.Models
{
    public class UserAnswersModel
    {
        public int UserId;
        public int QuestionId;
        public int AnswerId;
        internal void Save()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("InsertuserAnswer", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@User_id", SqlDbType.Int).Value = this.UserId;
                command.Parameters.Add("@question_id", SqlDbType.Int).Value = this.QuestionId;
                command.Parameters.Add("@answer_id", SqlDbType.Int).Value = this.AnswerId;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Dispose();

            }
        }

    }
}