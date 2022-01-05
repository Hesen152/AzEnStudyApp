using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzEnStudyApp.Application.Dto;
using AzEnStudyApp.Application.Features.Commands.Quiz;
using AzEnStudyApp.Application.Features.Queries.GetAllQuiz;
using AzEnStudyApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AzEnStudyApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController:ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }

         [HttpGet]
        public async Task<IActionResult> GetAll()
          { 
              var query = new GetAllQuizQuery();
         
                 return Ok(await _mediator.Send(query));
        
        
         } 
         
        //Create  Quiz
        [HttpPost]
        public async Task<IActionResult> CreateQuiz(CreateQuizCommand  command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
       
        
        

    }
}