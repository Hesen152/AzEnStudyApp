using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AzEnStudyApp.Application.Dto;
using AzEnStudyApp.Application.Interfaces.Repository;
using MediatR;

namespace AzEnStudyApp.Application.Features.Queries.GetAllQuiz
{
    public class GetAllQuizQueryHandler:IRequestHandler<GetAllQuizQuery,List<QuizViewDto>>
    {
        private readonly IQuizRepository _repository;
        private readonly IMapper _mapper;

        public GetAllQuizQueryHandler(IQuizRepository quizRepository,IMapper mapper)
        {
            _repository = quizRepository;
            _mapper = mapper;
        }
        public async  Task<List<QuizViewDto>> Handle(GetAllQuizQuery request, CancellationToken cancellationToken)
        {

            var quizzes =  await _repository.GetAllAsync();
            var viewModel = _mapper.Map<List<QuizViewDto>>(quizzes);
            return new List<QuizViewDto>(viewModel);
            
        }
    }
}