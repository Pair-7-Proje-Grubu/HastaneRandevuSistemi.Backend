using Application.Repositories;
using Application.Services.EmailService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Commands.Create
{
    public class CreateFeedbackCommand : IRequest<CreateFeedbackResponse>
    {
        public string UserMail { get; set; }

        public string UserFeedback { get; set; }
    }

    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, CreateFeedbackResponse>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper, IEmailService emailService)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateFeedbackResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            Feedback feedback = _mapper.Map<Feedback>(request);

            await _feedbackRepository.AddAsync(feedback);

            await _emailService.SendFeedbackRequestEmailAsync(feedback.UserMail, feedback.UserFeedback);

            return new CreateFeedbackResponse() 
            { 
                Id = feedback.Id, 
                UserMail = feedback.UserMail, 
                UserFeedback = feedback.UserFeedback,
            };
        }
    }
}