using System;
using System.Collections.Generic;

#nullable disable

namespace AzEnStudyApp.Domain.Entities
{
    public  class Quiz
    {
        public Quiz()
        {
            QuizAnswers = new HashSet<QuizAnswer>();
            QuizMeta = new HashSet<QuizMetum>();
            QuizQuestions = new HashSet<QuizQuestion>();
            Takes = new HashSet<Take>();
        }

        public long Id { get; set; }
        public long Hostid { get; set; }
        public string Title { get; set; }
        public string Metatitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public short Type { get; set; }
        public short Score { get; set; }
        public short Published { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
        public DateTime? Publishedat { get; set; }
        public DateTime? Startsat { get; set; }
        public DateTime? Endsat { get; set; }
        public string Content { get; set; }

        public virtual User Host { get; set; }
        public virtual ICollection<QuizAnswer> QuizAnswers { get; set; }
        public virtual ICollection<QuizMetum> QuizMeta { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
        public virtual ICollection<Take> Takes { get; set; }
    }
}
