using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
namespace Application.Services
{
  

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        public UserService(IUserRepository userRepository, IEmailService emailService, ISmsService smsService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _smsService = smsService;
        }

        public async Task<User> CreateAccountAsync(CreateAccountDto createAccountDto, string mobileVerificationCode, string emailVerificationCode)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                ICNumber = createAccountDto.ICNumber,
                MobileNumber = createAccountDto.MobileNumber,
                Email = createAccountDto.Email,
                IsMobileVerified = false,
                IsEmailVerified = false,
                Pin = "null"
            };

            await _userRepository.AddUserAsync(user);

      
         
            await _smsService.SendVerificationSms(user.MobileNumber, mobileVerificationCode);
            await _emailService.SendVerificationEmail(user.Email, emailVerificationCode);

            return user;
        }

        public async Task<bool> VerifyMobileAsync(string ICNumber)
        {
          
            var user = await _userRepository.GetUserByICNuberAsync(ICNumber);
            if (user == null) return false;

            user.IsMobileVerified = true;
            await _userRepository.UpdateUserAsync(user);

            return true;
        }

        public async Task<bool> VerifyEmailAsync(string ICNumber)
        {
          
            var user = await _userRepository.GetUserByICNuberAsync(ICNumber);
            if (user == null) return false;

            user.IsEmailVerified = true;
            await _userRepository.UpdateUserAsync(user);

            return true;
        }

        public async Task<bool> SetPinAsync(string mobileNumber, string pin)
        {
            var user = await _userRepository.GetUserByMobileNumberAsync(mobileNumber);
            if (user == null || !user.IsMobileVerified || !user.IsEmailVerified) return false;

            user.Pin = pin;
            await _userRepository.UpdateUserAsync(user);

            return true;
        }
        public async Task<bool> VerifyUserAsync(string ICnumber)
        {

            var user = await _userRepository.GetUserByICNuberAsync(ICnumber);
            if (user == null) return false;

          
          

            return true;
        }
    }
}

