using System;
using System.Collections.Generic;

#nullable disable

namespace AzEnStudyApp.Domain.Entities
{
    public  class QuizQuestion
    {
        public QuizQuestion()
        {
            TakeAnswers = new HashSet<TakeAnswer>();
        }

        public long Id { get; set; }
        public long Quizid { get; set; }
        public string Type { get; set; }
        public short Active { get; set; }
        public short Level { get; set; }
        public short Score { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
        public string Content { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual QuizAnswer QuizAnswer { get; set; }
        public virtual ICollection<TakeAnswer> TakeAnswers { get; set; }
    }
}
