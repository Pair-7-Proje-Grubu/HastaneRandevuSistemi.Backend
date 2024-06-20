using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blocks.Queries.GetList
{
    public class GetListBlockQuery : IRequest<List<GetListBlockResponse>>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Admin"];
        public class GetListBlockQueryHandler : IRequestHandler<GetListBlockQuery, List<GetListBlockResponse>>
        {
            private readonly IBlockRepository _blockRepository;
            private readonly IMapper _mapper;

            public GetListBlockQueryHandler(IBlockRepository blockRepository, IMapper mapper)
            {
                _blockRepository = blockRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListBlockResponse>> Handle(GetListBlockQuery request, CancellationToken cancellationToken)
            {
                List<Block> blocks = await _blockRepository.GetListAsync();

                List<GetListBlockResponse> response = _mapper.Map<List<GetListBlockResponse>>(blocks);

                return response;
            }
        }
    }
}
