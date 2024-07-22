using Application.Repositories;
using Application.Services.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Feedbacks.Queries.GetListFeedback
{
    public class GetListFeedbackQuery : PaginationParams, IRequest<PagedResponse<List<GetListFeedbackResponse>>>
    {
        public class GetListFeedbackQueryHandler : IRequestHandler<GetListFeedbackQuery, PagedResponse<List<GetListFeedbackResponse>>>
        {
            private readonly IFeedbackRepository _feedbackRepository;
            private readonly IMapper _mapper;

            public GetListFeedbackQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
            {
                _feedbackRepository = feedbackRepository;
                _mapper = mapper;
            }

            public async Task<PagedResponse<List<GetListFeedbackResponse>>> Handle(GetListFeedbackQuery request, CancellationToken cancellationToken)
            {
                List<Feedback> feedback = await _feedbackRepository.GetListAsync();
                List<GetListFeedbackResponse> response = _mapper.Map<List<GetListFeedbackResponse>>(feedback);

                return response.ToPagedResponse(request);
            }
        }
    }
}
