using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Queries.GetByIdTitle
{
    public class GetByIdTitleQuery : IRequest<GetByIdTitleResponse>
    {
        public int Id { get; set; }

        public class GetByIdTitleQueryHandler : IRequestHandler<GetByIdTitleQuery, GetByIdTitleResponse>
        {

            private ITitleRepository _titleRepository;
            private IMapper _mapper;

            public GetByIdTitleQueryHandler(ITitleRepository titleRepository, IMapper mapper)
            {
                _titleRepository = titleRepository;
                _mapper = mapper;
            }


            public async Task<GetByIdTitleResponse> Handle(GetByIdTitleQuery request, CancellationToken cancellationToken)
            {

                Title? title = await _titleRepository.GetAsync(x => x.Id == request.Id);

                GetByIdTitleResponse response = new GetByIdTitleResponse();
                response.Title = title;

                return response;
            }
        }
    }
}
