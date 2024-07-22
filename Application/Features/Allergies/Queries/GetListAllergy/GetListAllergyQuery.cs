using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Allergies.Queries.GetListAllergy
{
    public class GetListAllergyQuery : IRequest<GetListAllergyResponse>
    {
        public class GetListAllergyQueryHandler  :IRequestHandler<GetListAllergyQuery, GetListAllergyResponse>
        {
            private readonly IAllergyRepository _allergyRepository;

            public GetListAllergyQueryHandler(IAllergyRepository allergyRepository, IMapper mapper)
            {
                _allergyRepository = allergyRepository;
            }

            public async Task<GetListAllergyResponse> Handle(GetListAllergyQuery request, CancellationToken cancellationToken)
            {
                GetListAllergyResponse response = new();
                response.Allergies = await _allergyRepository.GetListAsync();
                return response;
            }
        }
    }
}
