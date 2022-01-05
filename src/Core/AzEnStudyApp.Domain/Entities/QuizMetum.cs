using System;
using System.Collections.Generic;

#nullable disable

namespace AzEnStudyApp.Domain.Entities
{
    public  class QuizMetum
    {
        public long Id { get; set; }
        public long Quizid { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }

        public virtual Quiz Quiz { get; set; }
    }
}
