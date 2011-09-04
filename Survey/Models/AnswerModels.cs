using System;
using System.Collections.Generic;
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
        internal static List<AnswerModel> LoadByQuestion(int questionId)
        {
            return new List<AnswerModel>();
        }
    }
}