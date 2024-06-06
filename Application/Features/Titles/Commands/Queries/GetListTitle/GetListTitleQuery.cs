using Application.Features.Titles.Commands.Queries.GetListTitle;
using Application.Features.Titles.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Queries.GetListTitle
{
    public class GetListTitleQuery : IRequest<GetListTitleResponse>
    { 
        public class GetListTitleQueryHandler : IRequestHandler<GetListTitleQuery, GetListTitleResponse>
        {

            private readonly ITitleRepository _titleRepository;

            public GetListTitleQueryHandler(ITitleRepository titleRepository, IMapper mapper)
            {
                _titleRepository = titleRepository;
            }


            public async Task<GetListTitleResponse> Handle(GetListTitleQuery request, CancellationToken cancellationToken)
            {
                GetListTitleResponse response = new GetListTitleResponse();
                response.Titles = await _titleRepository.GetListAsync();
                return response;
            }
        }
    }
}

