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

namespace Application.Features.Blocks.Commands.Delete
{
    public class DeleteBlockCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteBlockCommandHandler : IRequestHandler<DeleteBlockCommand>
        {
            private IBlockRepository _blockRepository;
            private readonly IMapper _mapper;

            public DeleteBlockCommandHandler(IBlockRepository blockRepository, IMapper mapper)
            {
                _blockRepository = blockRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteBlockCommand request, CancellationToken cancellationToken)
            {
                Block? block = await _blockRepository.GetAsync(i => i.Id == request.Id);
                if (block is null)
                    throw new ValidationException("Böyle bir veri bulunamadı.");

                await _blockRepository.DeleteAsync(block);
            }
        }
    }
}
