using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blocks.Commands.Create
{
    public class CreateBlockCommand: IRequest<CreateBlockResponse>
    {
        public string No { get; set; }
        public class CreateBlockCommandHandler : IRequestHandler<CreateBlockCommand, CreateBlockResponse>
        {
            private readonly IBlockRepository _blockRepository;
            private readonly IMapper _mapper;
            public CreateBlockCommandHandler(IBlockRepository blockRepository, IMapper mapper)
            {
                _blockRepository = blockRepository;
                _mapper = mapper;
            }
            public async Task<CreateBlockResponse> Handle(CreateBlockCommand request, CancellationToken cancellationToken)
            {
                Block block = _mapper.Map<Block>(request);
                await _blockRepository.AddAsync(block);

                CreateBlockResponse response = _mapper.Map<CreateBlockResponse>(block);
                return response;
            }
        }
    }
}
