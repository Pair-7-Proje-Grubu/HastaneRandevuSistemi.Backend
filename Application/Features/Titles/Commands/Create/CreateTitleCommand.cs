using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Repositories;

namespace Application.Features.Titles.Commands.Create
{
    public class CreateTitleCommand : IRequest<CreateTitleResponse>
    {
        public string TitleName { get; set; }


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
