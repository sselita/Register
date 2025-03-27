using System.Net.NetworkInformation;
using Application.DTOs;
using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;



namespace Register.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
      
            private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public AccountController(IUserService userService, IUserRepository userRepository)
            {
                _userService = userService;
            _userRepository = userRepository;
            }

            [HttpPost]
            [Route("create")]
            public async Task<System.Web.Http.IHttpActionResult> CreateAccount(CreateAccountDto dto)
            {
            // Generate verification codes and send them
            var mobileVerificationCode = new Random().Next(100000, 999999).ToString();
            var emailVerificationCode = new Random().Next(100000, 999999).ToString();
            List<string>codes = new List<string>();
            codes.Add(mobileVerificationCode);
            codes.Add(emailVerificationCode);
            codes.Add(dto.MobileNumber);
            codes.Add(dto.Email);   
            var user = await _userService.CreateAccountAsync(dto,mobileVerificationCode,emailVerificationCode);
                return (System.Web.Http.IHttpActionResult)Ok(codes);
            }


            [HttpPost]
            [Route("verify/mobile")]
            public async Task<System.Web.Http.IHttpActionResult> VerifyMobile(string mobileNumber, string code , string mobileVerificationCode)
            {
            if (code != mobileVerificationCode)
            {
                return (System.Web.Http.IHttpActionResult)BadRequest("Code is not correct.Incorrect OTP");
            }
            var success = await _userService.VerifyMobileAsync(mobileNumber, code);
                return (System.Web.Http.IHttpActionResult)Ok(success);
            }

            [HttpPost]
            [Route("verify/email")]
            public async Task<System.Web.Http.IHttpActionResult> VerifyEmail(string email, string code, string emailVerificationCode)
            {
            if (code != emailVerificationCode)
            {
                return (System.Web.Http.IHttpActionResult)BadRequest("Code is not correct.Incorrect OTP");
            }
            var success = await _userService.VerifyEmailAsync(email, code);
                return (System.Web.Http.IHttpActionResult)Ok(success);
            }

            [HttpPost]
            [Route("set-pin")]
        public async Task<System.Web.Http.IHttpActionResult> SetPin(string mobileNumber, string pin, string confirmPin)
        {
            if (pin != confirmPin)
            {
                return (System.Web.Http.IHttpActionResult)BadRequest("PIN and Confirm PIN do not match.");
            }

            var success = await _userService.SetPinAsync(mobileNumber, pin);
            return (System.Web.Http.IHttpActionResult)Ok(success);
        }
        [HttpPost]
        [Route("login")]
        public async Task<System.Web.Http.IHttpActionResult> Login(string ICNumber)
        {
            var user = new User();
            var success = await _userService.VerifyUserAsync(ICNumber);
            if (success)
            {
                user = await _userRepository.GetUserByICNuberAsync(ICNumber);
            }
             
            return (System.Web.Http.IHttpActionResult)Ok(user);
        }
        [HttpPost]
        [Route("privacy-policy")]
        public async Task<System.Web.Http.IHttpActionResult> PrivacyPolicy(string ICNumber)
        {
            var user = await _userRepository.GetUserByICNuberAsync(ICNumber);
            user.PrivacyPolicy = true;
     
            return (System.Web.Http.IHttpActionResult)Ok("Privacy Policy agreed");
        }
    }
    }


