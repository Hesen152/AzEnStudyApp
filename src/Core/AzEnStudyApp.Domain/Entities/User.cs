using System;
using System.Collections.Generic;

#nullable disable

namespace AzEnStudyApp.Domain.Entities
{
    public  class User
    {
        public User()
        {
            Quizzes = new HashSet<Quiz>();
            Takes = new HashSet<Take>();
        }

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Passwordhash { get; set; }
        public short Host { get; set; }
        public DateTime Registeredat { get; set; }
        public DateTime? Lastlogin { get; set; }
        public string Intro { get; set; }
        public string Profile { get; set; }
        public string Passwordsalt { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Take> Takes { get; set; }
    }
}
