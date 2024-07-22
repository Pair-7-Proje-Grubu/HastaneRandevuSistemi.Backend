using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules : BaseBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task AddUniqueClaim(string name)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Name == name);
            if(operationClaim == null)
            {
                throw new BusinessException("Aynı isimde rol eklenemez");
            }
        }
    }
}
