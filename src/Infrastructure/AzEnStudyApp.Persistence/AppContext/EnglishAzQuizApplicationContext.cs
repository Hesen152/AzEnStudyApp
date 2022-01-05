using System;
using System.Reflection;
using AzEnStudyApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace AzEnStudyApp.Infrastructure.AppContext
{
        public  class EnglishAzQuizApplicationContext : DbContext
        {
            public EnglishAzQuizApplicationContext()
            {
            }

            public EnglishAzQuizApplicationContext(DbContextOptions<EnglishAzQuizApplicationContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Quiz> Quizzes { get; set; }
            public virtual DbSet<QuizAnswer> QuizAnswers { get; set; }
            public virtual DbSet<QuizMetum> QuizMeta { get; set; }
            public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }
            public virtual DbSet<Take> Takes { get; set; }
            public virtual DbSet<TakeAnswer> TakeAnswers { get; set; }
            public virtual DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                    optionsBuilder.UseNpgsql(
                        "Host=localhost;Database=EnglishAzQuizApplication;Username=postgres;Password=12345");
                }
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnglishAzQuizApplicationContext).Assembly);

                
                
                modelBuilder.Entity<Quiz>(entity =>
                {
                    entity.ToTable("quiz", "quiz");

                    entity.HasIndex(e => e.Hostid, "idx_quiz_host");

                    entity.HasIndex(e => e.Slug, "uq_slug")
                        .IsUnique();

                    entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('quiz.quiz_seq'::regclass)");

                    entity.Property(e => e.Content).HasColumnName("content");

                    entity.Property(e => e.Createdat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("createdat");

                    entity.Property(e => e.Endsat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("endsat")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.Property(e => e.Hostid).HasColumnName("hostid");

                    entity.Property(e => e.Metatitle)
                        .HasMaxLength(100)
                        .HasColumnName("metatitle");

                    entity.Property(e => e.Published).HasColumnName("published");

                    entity.Property(e => e.Publishedat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("publishedat")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.Property(e => e.Score).HasColumnName("score");

                    entity.Property(e => e.Slug)
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnName("slug");

                    entity.Property(e => e.Startsat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("startsat")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.Property(e => e.Summary).HasColumnName("summary");

                    entity.Property(e => e.Title)
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnName("title");

                    entity.Property(e => e.Type).HasColumnName("type");

                    entity.Property(e => e.Updatedat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("updatedat")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.HasOne(d => d.Host)
                        .WithMany(p => p.Quizzes)
                        .HasForeignKey(d => d.Hostid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_quiz_host");
                });

                modelBuilder.Entity<QuizAnswer>(entity =>
                {
                    entity.ToTable("quiz_answer", "quiz");

                    entity.HasIndex(e => e.Questionid, "idx_answer_question")
                        .IsUnique();

                    entity.HasIndex(e => e.Quizid, "idx_answer_quiz");

                    entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('quiz.quiz_answer_seq'::regclass)");

                    entity.Property(e => e.Active).HasColumnName("active");

                    entity.Property(e => e.Content).HasColumnName("content");

                    entity.Property(e => e.Correct).HasColumnName("correct");

                    entity.Property(e => e.Createdat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("createdat");

                    entity.Property(e => e.Questionid).HasColumnName("questionid");

                    entity.Property(e => e.Quizid).HasColumnName("quizid");

                    entity.Property(e => e.Updatedat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("updatedat")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.HasOne(d => d.Question)
                        .WithOne(p => p.QuizAnswer)
                        .HasForeignKey<QuizAnswer>(d => d.Questionid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_answer_question");

                    entity.HasOne(d => d.Quiz)
                        .WithMany(p => p.QuizAnswers)
                        .HasForeignKey(d => d.Quizid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_answer_quiz");
                });

                modelBuilder.Entity<QuizMetum>(entity =>
                {
                    entity.ToTable("quiz_meta", "quiz");

                    entity.HasIndex(e => e.Quizid, "idx_meta_quiz");

                    entity.HasIndex(e => new { e.Quizid, e.Key }, "uq_quiz_meta")
                        .IsUnique();

                    entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('quiz.quiz_meta_seq'::regclass)");

                    entity.Property(e => e.Content).HasColumnName("content");

                    entity.Property(e => e.Key)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("key");

                    entity.Property(e => e.Quizid).HasColumnName("quizid");

                    entity.HasOne(d => d.Quiz)
                        .WithMany(p => p.QuizMeta)
                        .HasForeignKey(d => d.Quizid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_meta_quiz");
                });

                modelBuilder.Entity<QuizQuestion>(entity =>
                {
                    entity.ToTable("quiz_question", "quiz");

                    entity.HasIndex(e => e.Quizid, "idx_question_quiz");

                    entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('quiz.quiz_question_seq'::regclass)");

                    entity.Property(e => e.Active).HasColumnName("active");

                    entity.Property(e => e.Content).HasColumnName("content");

                    entity.Property(e => e.Createdat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("createdat");

                    entity.Property(e => e.Level).HasColumnName("level");

                    entity.Property(e => e.Quizid).HasColumnName("quizid");

                    entity.Property(e => e.Score).HasColumnName("score");

                    entity.Property(e => e.Type)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("type");

                    entity.Property(e => e.Updatedat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("updatedat")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.HasOne(d => d.Quiz)
                        .WithMany(p => p.QuizQuestions)
                        .HasForeignKey(d => d.Quizid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_question_quiz");
                });

                modelBuilder.Entity<Take>(entity =>
                {
                    entity.ToTable("take", "quiz");

                    entity.HasIndex(e => e.Quizid, "idx_take_quiz");

                    entity.HasIndex(e => e.Userid, "idx_take_user");

                    entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('quiz.take_seq'::regclass)");

                    entity.Property(e => e.Content).HasColumnName("content");

                    entity.Property(e => e.Createdat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("createdat");

                    entity.Property(e => e.Finishedat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("finishedat")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.Property(e => e.Published).HasColumnName("published");

                    entity.Property(e => e.Quizid).HasColumnName("quizid");

                    entity.Property(e => e.Score).HasColumnName("score");

                    entity.Property(e => e.Startedat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("startedat")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.Property(e => e.Status).HasColumnName("status");

                    entity.Property(e => e.Updatedat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("updatedat")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.Property(e => e.Userid).HasColumnName("userid");

                    entity.HasOne(d => d.Quiz)
                        .WithMany(p => p.Takes)
                        .HasForeignKey(d => d.Quizid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_take_quiz");

                    entity.HasOne(d => d.User)
                        .WithMany(p => p.Takes)
                        .HasForeignKey(d => d.Userid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_take_user");
                });

                modelBuilder.Entity<TakeAnswer>(entity =>
                {
                    entity.ToTable("take_answer", "quiz");

                    entity.HasIndex(e => e.Takeid, "idx_answer_take");

                    entity.HasIndex(e => e.Answerid, "idx_tanswer_answer");

                    entity.HasIndex(e => e.Questionid, "idx_tanswer_question");

                    entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('quiz.take_answer_seq'::regclass)");

                    entity.Property(e => e.Active).HasColumnName("active");

                    entity.Property(e => e.Answerid).HasColumnName("answerid");

                    entity.Property(e => e.Content).HasColumnName("content");

                    entity.Property(e => e.Createdat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("createdat");

                    entity.Property(e => e.Questionid).HasColumnName("questionid");

                    entity.Property(e => e.Takeid).HasColumnName("takeid");

                    entity.Property(e => e.Updatedat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("updatedat")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.HasOne(d => d.Answer)
                        .WithMany(p => p.TakeAnswers)
                        .HasForeignKey(d => d.Answerid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tanswer_answer");

                    entity.HasOne(d => d.Question)
                        .WithMany(p => p.TakeAnswers)
                        .HasForeignKey(d => d.Questionid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tanswer_question");

                    entity.HasOne(d => d.Take)
                        .WithMany(p => p.TakeAnswers)
                        .HasForeignKey(d => d.Takeid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_answer_take");
                });

                modelBuilder.Entity<User>(entity =>
                {
                    entity.ToTable("user", "quiz");

                    entity.HasIndex(e => e.Email, "uq_email")
                        .IsUnique();

                    entity.HasIndex(e => e.Mobile, "uq_mobile")
                        .IsUnique();

                    entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('quiz.user_seq'::regclass)");

                    entity.Property(e => e.Email)
                        .HasMaxLength(50)
                        .HasColumnName("email");

                    entity.Property(e => e.Firstname)
                        .HasMaxLength(50)
                        .HasColumnName("firstname")
                        .HasDefaultValueSql("NULL::character varying");

                    entity.Property(e => e.Host).HasColumnName("host");

                    entity.Property(e => e.Intro).HasColumnName("intro");

                    entity.Property(e => e.Lastlogin)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("lastlogin")
                        .HasDefaultValueSql("NULL::timestamp without time zone");

                    entity.Property(e => e.Lastname)
                        .HasMaxLength(50)
                        .HasColumnName("lastname")
                        .HasDefaultValueSql("NULL::character varying");

                    entity.Property(e => e.Middlename)
                        .HasMaxLength(50)
                        .HasColumnName("middlename")
                        .HasDefaultValueSql("NULL::character varying");

                    entity.Property(e => e.Mobile)
                        .HasMaxLength(15)
                        .HasColumnName("mobile");

                    entity.Property(e => e.Passwordhash)
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnName("passwordhash");

                    entity.Property(e => e.Passwordsalt)
                        .HasMaxLength(36)
                        .HasColumnName("passwordsalt");

                    entity.Property(e => e.Profile).HasColumnName("profile");

                    entity.Property(e => e.Registeredat)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("registeredat");
                });

                modelBuilder.HasSequence("quiz_answer_seq", "quiz");

                modelBuilder.HasSequence("quiz_meta_seq", "quiz");

                modelBuilder.HasSequence("quiz_question_seq", "quiz");

                modelBuilder.HasSequence("quiz_seq", "quiz");

                modelBuilder.HasSequence("take_answer_seq", "quiz");

                modelBuilder.HasSequence("take_seq", "quiz");

                modelBuilder.HasSequence("user_seq", "quiz");

                base.OnModelCreating(modelBuilder);
            }

            //void OnModelCreatingPartial(ModelBuilder modelBuilder);
        }
    }


