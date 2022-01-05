using AzEnStudyApp.Application.Interfaces.Repository;
using AzEnStudyApp.Domain.Entities;
using AzEnStudyApp.Infrastructure.AppContext;

namespace AzEnStudyApp.Infrastructure.Repositories                                                                                                                                                                         
{
    public class QuizRepository:GenericRepository<Quiz>,IQuizRepository        
    {
        public QuizRepository(EnglishAzQuizApplicationContext context):base(context)
        {
            
        }
    }
}