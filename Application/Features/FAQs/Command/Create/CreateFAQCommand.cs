using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FAQs.Command.Create
{
    public class CreateFAQCommand : IRequest<CreateFAQResponse>
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public class CreateFAQCommandHandler : IRequestHandler<CreateFAQCommand, CreateFAQResponse>
        {
            private readonly IFAQRepository _faqRepository;
            private readonly IMapper _mapper;
            public CreateFAQCommandHandler(IFAQRepository faqRepository, IMapper mapper)
            {
                _faqRepository = faqRepository;
                _mapper = mapper;
            }

            public async Task<CreateFAQResponse> Handle(CreateFAQCommand request, CancellationToken cancellationToken)
            {
                FAQ faq = _mapper.Map<FAQ>(request);
                await _faqRepository.AddAsync(faq);

                CreateFAQResponse response = _mapper.Map<CreateFAQResponse>(faq);
                return response;
            }
        }

    }
}
