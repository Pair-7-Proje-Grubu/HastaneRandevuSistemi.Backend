using Application.Repositories;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.Feedbacks.Queries.GetByIdFeedback
{
    public class GetByIdFeedbackQuery : IRequest<GetByIdFeedbackResponse>
    {
        public int Id { get; set; }

        public class GetByIdFeedbackQueryHandler : IRequestHandler<GetByIdFeedbackQuery, GetByIdFeedbackResponse>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;

            public GetByIdFeedbackQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdFeedbackResponse> Handle(GetByIdFeedbackQuery request, CancellationToken cancellationToken)
            {
                Feedback? feedback = await _feedbackRepository.GetAsync(x => x.Id == request.Id);

                GetByIdFeedbackResponse response = _mapper.Map<GetByIdFeedbackResponse>(feedback);

                return response;
            }
        }
    }
}
