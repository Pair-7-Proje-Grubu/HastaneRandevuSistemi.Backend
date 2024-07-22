using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Titles.Commands.Update
{
    public class UpdateTitleCommand : IRequest<UpdateTitleResponse>
    {
        public int Id { get; set; }
        public string TitleName { get; set; }

        public class UpdateTitleCommandHandler : IRequestHandler<UpdateTitleCommand, UpdateTitleResponse>
        {
            private readonly ITitleRepository _titleRepository;
            private readonly IMapper _mapper;

            public UpdateTitleCommandHandler(ITitleRepository titleRepository, IMapper mapper)
            {
                _titleRepository = titleRepository;
                _mapper = mapper;
            }

            public async Task<UpdateTitleResponse> Handle(UpdateTitleCommand request, CancellationToken cancellationToken)
            {
                Title title = _mapper.Map<Title>(request);
                await _titleRepository.UpdateAsync(title);
                UpdateTitleResponse response = _mapper.Map<UpdateTitleResponse>(title);
                return response;
            }
        }
    }
}
