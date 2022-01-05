using System;
using System.Collections.Generic;

#nullable disable

namespace AzEnStudyApp.Domain.Entities
{
    public  class Take
    {
        public Take()
        {
            TakeAnswers = new HashSet<TakeAnswer>();
        }

        public long Id { get; set; }
        public long Userid { get; set; }
        public long Quizid { get; set; }
        public short Status { get; set; }
        public short Score { get; set; }
        public short Published { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
        public DateTime? Startedat { get; set; }
        public DateTime? Finishedat { get; set; }
        public string Content { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TakeAnswer> TakeAnswers { get; set; }
    }
}
