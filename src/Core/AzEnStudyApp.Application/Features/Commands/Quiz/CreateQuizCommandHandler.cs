using System.Threading;
using System.Threading.Tasks;
using AzEnStudyApp.Application.Interfaces.Repository;
using AzEnStudyApp.Application.Wrappers;
using MediatR;

namespace AzEnStudyApp.Application.Features.Commands.Quiz
{
    public class CreateQuizCommandHandler:IRequestHandler<CreateQuizCommand,ServiceResponse<long>>
    {
        private readonly IQuizRepository _quizRepository;
        
        

        public CreateQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        
        
        public async  Task<ServiceResponse<long>> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            //var quiz = _mapper.Map<Domain.Entities.Quiz>(request);
            var entity = new Domain.Entities.Quiz
            {
                Hostid = request.Hostid,
                Title = request.Title,
                Metatitle = request.Metatitle,
                Slug = request.Slug,
                Summary = request.Summary,
                Type = request.Type,
                Score = request.Score,
                Published = request.Published,
                Createdat = request.Createdat
                

            };
         

             await _quizRepository.AddAsync(entity);
              

            return new ServiceResponse<long>( 25);
         

        }
    } 
} 