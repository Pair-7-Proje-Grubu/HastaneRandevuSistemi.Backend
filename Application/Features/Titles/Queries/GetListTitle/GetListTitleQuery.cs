using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Titles.Queries.GetListTitle
{
    public class GetListTitleQuery : IRequest<List<GetListTitleResponse>>
    { 
        public class GetListTitleQueryHandler : IRequestHandler<GetListTitleQuery, List<GetListTitleResponse>>
        {

            private readonly ITitleRepository _titleRepository;
            private readonly IMapper _mapper;

            public GetListTitleQueryHandler(ITitleRepository titleRepository, IMapper mapper)
            {
                _titleRepository = titleRepository;
                _mapper = mapper;
            }


            public async Task<List<GetListTitleResponse>> Handle(GetListTitleQuery request, CancellationToken cancellationToken)
            {
                List<Title> titles = await _titleRepository.GetListAsync();

                List<GetListTitleResponse> response = _mapper.Map<List<GetListTitleResponse>>(titles);
                return response;
            }
        }
    }
}

