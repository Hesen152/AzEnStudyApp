using System;
using AzEnStudyApp.Application.Wrappers;
using MediatR;

namespace AzEnStudyApp.Application.Features.Commands.Quiz
{
    public class CreateQuizCommand:IRequest<ServiceResponse<long>>
    {
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
        
    } 
}