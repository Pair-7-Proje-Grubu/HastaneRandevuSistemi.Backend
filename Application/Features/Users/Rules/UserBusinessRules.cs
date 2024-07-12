using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserIdShouldExistWhenSelected(int id)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (user is null)
                throw new BusinessException("Kullanıcı bulunamadı!");
        }
        public async Task UserEmailShouldExistWhenSelected(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == u.Email);
            if (user is null)
                throw new BusinessException("Kullanıcı bulunamadı!");
        }

    }
}
