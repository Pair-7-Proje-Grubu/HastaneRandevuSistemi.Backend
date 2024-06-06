using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Delete
{
    public class DeleteTitleCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteTitleCommandHandler : IRequestHandler<DeleteTitleCommand>
        {
            private ITitleRepository _titleRepository;
            private readonly IMapper _mapper;

            public DeleteTitleCommandHandler(ITitleRepository titleRepository, IMapper mapper)
            {
                _titleRepository = titleRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteTitleCommand request, CancellationToken cancellationToken)
            {
                Title? title = _mapper.Map<Title>(request);

                if (title is null)
                    throw new Exception("Silinecek title bulunamadı.");

                await _titleRepository.DeleteAsync(title);
            }
        }
    }
}
