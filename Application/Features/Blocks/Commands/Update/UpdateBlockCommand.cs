using Application.Features.Doctors.Commands.UpdateDoctor;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blocks.Commands.Update
{
    public class UpdateBlockCommand : IRequest<UpdateBlockResponse>
    {
        public int Id { get; set; }

        public int No { get; set; }

        public class UpdateBlockCommandHandler : IRequestHandler<UpdateBlockCommand, UpdateBlockResponse>
        {
            private readonly IBlockRepository _blockRepository;
            private readonly IMapper _mapper;

            public UpdateBlockCommandHandler(IBlockRepository blockRepository, IMapper mapper)
            {
                _blockRepository = blockRepository;
                _mapper = mapper;
            }

            public async Task<UpdateBlockResponse> Handle(UpdateBlockCommand request, CancellationToken cancellationToken)
            {
                Block? block = await _blockRepository.GetAsync(p => p.Id == request.Id);

                if (block is null)
                    throw new ValidationException("Böyle bir veri bulunamadı.");

                Block mappedBlock = _mapper.Map<Block>(request);

                await _blockRepository.UpdateAsync(mappedBlock);

                UpdateBlockResponse response = new UpdateBlockResponse();

                return response;
            }
        }
    }
}
