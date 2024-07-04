using Application.Features.Clinics.Dtos;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using EllipticCurve;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Queries.GetListFeedback
{
    public class GetListFeedbackQuery : IRequest<List<GetListFeedbackResponse>>
    {
        public class GetListFeedbackQueryHandler : IRequestHandler<GetListFeedbackQuery, List<GetListFeedbackResponse>>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;

            public GetListFeedbackQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListFeedbackResponse>> Handle(GetListFeedbackQuery request, CancellationToken cancellationToken)
            {
                List<Feedback> feedback = await _feedbackRepository.GetListAsync();
                List<GetListFeedbackResponse> response = _mapper.Map<List<GetListFeedbackResponse>>(feedback);

                return response;
            }
        }
    }
}
