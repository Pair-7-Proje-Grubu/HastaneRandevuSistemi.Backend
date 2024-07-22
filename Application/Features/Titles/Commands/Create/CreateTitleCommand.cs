using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Repositories;
using Core.Application.Pipelines.Authorization;

namespace Application.Features.Titles.Commands.Create
{
    public class CreateTitleCommand : IRequest<CreateTitleResponse>, ISecuredRequest
    {
        public string TitleName { get; set; }
        public string[] RequiredRoles => ["Admin"]; 


        public class CreateTitleCommandHandler : IRequestHandler<CreateTitleCommand, CreateTitleResponse>
        {
            private readonly ITitleRepository _titleRepository;
            private readonly IMapper _mapper;


            public CreateTitleCommandHandler(ITitleRepository titleRepository, IMapper mapper)
            {
                _titleRepository = titleRepository;
                _mapper = mapper;
            }

            public async Task<CreateTitleResponse> Handle(CreateTitleCommand request, CancellationToken cancellationToken)

            {
                Title title = _mapper.Map<Title>(request);
                await _titleRepository.AddAsync(title);
                return new CreateTitleResponse() { Id = title.Id, TitleName = title.TitleName };
            }


        }
    }
}
