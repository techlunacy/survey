using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Survey.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public QuestionModel Question { get; set; }
        public string answer { get; set; }

        internal static AnswerModel Load(int id)
        {
            return new AnswerModel();
        }
        internal static List<AnswerModel> GetByQuestion(int questionId)
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                var answerList = new List<AnswerModel>();
                SqlCommand command = new SqlCommand("GetAnswersByQuestion", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@question_id", SqlDbType.VarChar).Value = questionId;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    answerList = PopulateAnswers(reader);
                }
                connection.Dispose();
                return answerList;
            }
        }

        private static List<AnswerModel> PopulateAnswers(SqlDataReader reader)
        {
            var answerList = new List<AnswerModel>();
            while (reader.Read())
            {
                var answerModel = new AnswerModel
                                      {
                                          Id = int.Parse(reader["id"].ToString()),
                                          answer = reader["answer"].ToString(),
                                          QuestionId = int.Parse(reader["question_id"].ToString())
                                      };
                answerList.Add(answerModel);
            }
            return answerList;
        }

        internal void Save()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("InsertAnswer", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@answer", SqlDbType.VarChar).Value = this.answer;
                command.Parameters.Add("@question_id", SqlDbType.Int).Value = this.QuestionId;
                connection.Open();
                this.Id = int.Parse(command.ExecuteScalar().ToString());
                connection.Dispose();

            }
        }
    }
}