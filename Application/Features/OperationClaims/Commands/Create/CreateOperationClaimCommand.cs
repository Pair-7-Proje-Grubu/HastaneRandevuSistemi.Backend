using Application.Features.OperationClaims.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.Create
{
    public class CreateOperationClaimCommand : IRequest<CreateOperationClaimResponse>, ISecuredRequest
    {
        public string Name { get; set; }
        public string[] RequiredRoles => ["Admin"];

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreateOperationClaimResponse>
        {
            private readonly IMapper _mapper;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public CreateOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _mapper = mapper;
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<CreateOperationClaimResponse> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.AddUniqueClaim(request.Name);

                OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);

                await _operationClaimRepository.AddAsync(operationClaim);

                CreateOperationClaimResponse response = _mapper.Map<CreateOperationClaimResponse>(operationClaim);

                return response;
            }
        }
    }
}
