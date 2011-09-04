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
    public class QuestionModel
    {
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
        public List<AnswerModel> Answers
        {
            get { return AnswerModel.LoadByQuestion(this.Id); }
            set { throw new NotImplementedException(); }
        }

        public static List<QuestionModel> GetAll()
        {
            var questionList = new List<QuestionModel>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetAllQuestions", connection) { CommandType = CommandType.StoredProcedure };

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    questionList = PopulateQuestions(reader);
                }
                connection.Dispose();
                return questionList;
            }
        }

        private static List<QuestionModel> PopulateQuestions(SqlDataReader reader)
        {
            List<QuestionModel> questionList = new List<QuestionModel>();
            while (reader.Read())
            {
                var question = new QuestionModel
                                   {
                                       Id = int.Parse(reader["id"].ToString()),
                                       Value = reader["value"].ToString()
                                   };
                questionList.Add(question);
            }
            return questionList;
        }

        public void Save()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("InsertQuestion", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@value", SqlDbType.VarChar).Value = this.Value;
                connection.Open();
                this.Id = int.Parse(command.ExecuteScalar().ToString());
                connection.Dispose();

            }
        }

        internal static QuestionModel GetById(int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                List<QuestionModel> questionList = new List<QuestionModel>();
                SqlCommand command = new SqlCommand("GetQuestion", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    questionList = PopulateQuestions(reader);
                }
                connection.Dispose();

                if (questionList.Count == 1)
                {
                    return questionList[0];
                }
                else
                {
                    return new QuestionModel();
                }
            }
        }
    }
}