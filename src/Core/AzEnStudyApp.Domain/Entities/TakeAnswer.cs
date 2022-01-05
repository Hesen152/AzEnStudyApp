using System;
using System.Collections.Generic;

#nullable disable

namespace AzEnStudyApp.Domain.Entities
{
    public  class TakeAnswer
    {
        public long Id { get; set; }
        public long Takeid { get; set; }
        public long Questionid { get; set; }
        public long Answerid { get; set; }
        public short Active { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
        public string Content { get; set; }

        public virtual QuizAnswer Answer { get; set; }
        public virtual QuizQuestion Question { get; set; }
        public virtual Take Take { get; set; }
    }
}
