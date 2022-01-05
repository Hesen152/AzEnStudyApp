using System;
using System.Collections.Generic;

#nullable disable

namespace AzEnStudyApp.Domain.Entities
{
    public  class QuizAnswer
    {
        public QuizAnswer()
        {
            TakeAnswers = new HashSet<TakeAnswer>();
        }

        public long Id { get; set; }
        public long Quizid { get; set; }
        public long Questionid { get; set; }
        public short Active { get; set; }
        public short Correct { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
        public string Content { get; set; }

        public virtual QuizQuestion Question { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<TakeAnswer> TakeAnswers { get; set; }
    }
}
