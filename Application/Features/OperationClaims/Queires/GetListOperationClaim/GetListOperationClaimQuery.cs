using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Queires.GetListOperationClaim
{
    public class GetListOperationClaimQuery : IRequest<List<GetListOperationClaimResponse>>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Admin"];

        public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, List<GetListOperationClaimResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IOperationClaimRepository _operationClaimRepository;

            public GetListOperationClaimQueryHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
            {
                _mapper = mapper;
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<List<GetListOperationClaimResponse>> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
                List<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync();

                List<GetListOperationClaimResponse> response = _mapper.Map<List<GetListOperationClaimResponse>>(operationClaims);

                return response;
            }
        }
    }
}
