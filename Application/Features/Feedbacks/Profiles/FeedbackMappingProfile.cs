using Application.Features.Feedbacks.Commands.Create;
using Application.Features.Feedbacks.Queries.GetByIdFeedback;
using Application.Features.Feedbacks.Queries.GetListFeedback;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Feedbacks.Profiles
{
    public class FeedbackMappingProfile : Profile
    {
        public FeedbackMappingProfile()
        {
            CreateMap<Feedback, CreateFeedbackCommand>().ReverseMap();
            CreateMap<Feedback, CreateFeedbackResponse>().ReverseMap();
            CreateMap<Feedback, GetByIdFeedbackResponse>().ReverseMap();
            CreateMap<Feedback, GetListFeedbackResponse>().ReverseMap();
        }
    }
}
