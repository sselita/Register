using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAccountAsync(CreateAccountDto createAccountDto, string mobileVerificationCode, string emailVerificationCode);
        Task<bool> SetPinAsync(string mobileNumber, string pin);
        Task<bool> VerifyEmailAsync(string ICNumber);
        Task<bool> VerifyMobileAsync(string ICNumber);
        Task<bool> VerifyUserAsync(string ICnumber);
    }
}
