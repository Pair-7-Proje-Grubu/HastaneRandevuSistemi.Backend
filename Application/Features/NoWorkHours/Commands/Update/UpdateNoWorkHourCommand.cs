﻿using Application.Features.NoWorkHours.Dtos;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Commands.Update
{
    public class UpdateNoWorkHourCommand : IRequest<UpdateNoWorkHourResponse>
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }

        public class UpdateNoWorkHourCommandHandler : IRequestHandler<UpdateNoWorkHourCommand, UpdateNoWorkHourResponse>
        {
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;

            public UpdateNoWorkHourCommandHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper)
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
            }

            public async Task<UpdateNoWorkHourResponse> Handle(UpdateNoWorkHourCommand request, CancellationToken cancellationToken)
            { 
                NoWorkHour? noWorkHour = await _noWorkHourRepository.GetAsync(h => h.Id == request.Id);
                if (noWorkHour == null)
                    throw new BusinessException("Id'ye ait veri bulunamadı");

                NoWorkHour mappedNoWorkHour = _mapper.Map<NoWorkHour>(request);

                await _noWorkHourRepository.UpdateAsync(mappedNoWorkHour);

                UpdateNoWorkHourResponse response = _mapper.Map<UpdateNoWorkHourResponse>(mappedNoWorkHour);

                return response;
            }
        }
    }
}
