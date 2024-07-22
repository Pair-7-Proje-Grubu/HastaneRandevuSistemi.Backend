using Application.Repositories;
using Application.Services.EmailService;
using AutoMapper;
using Domain.Entities;
using MediatR;

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