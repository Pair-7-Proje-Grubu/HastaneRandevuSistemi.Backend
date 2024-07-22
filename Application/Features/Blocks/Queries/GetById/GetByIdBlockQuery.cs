using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.Blocks.Queries.GetById
{
    public class GetByIdBlockQuery : IRequest<GetByIdBlockResponse>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class GetByIdQueryHandler : IRequestHandler<GetByIdBlockQuery, GetByIdBlockResponse>
        {
            private IBlockRepository _blockRepository;
            private IMapper _mapper;

            public GetByIdQueryHandler(IBlockRepository blockRepository, IMapper mapper)
            {
                _blockRepository = blockRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdBlockResponse> Handle(GetByIdBlockQuery request, CancellationToken cancellationToken)
            {
                Block? block = await _blockRepository.GetAsync(r => r.Id == request.Id);

                if (block is null)
                    throw new Exception("Böyle bir veri bulunamadı.");

                GetByIdBlockResponse response = _mapper.Map<GetByIdBlockResponse>(block);

                return response;
            }
        }
    }
}
