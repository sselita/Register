using Application.DTOs;
using Application.Services;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace Register.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
      
            private readonly IUserService _userService;

            public AccountController(IUserService userService)
            {
                _userService = userService;
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
                var success = await _userService.VerifyMobileAsync(mobileNumber, code,mobileVerificationCode);
                return (System.Web.Http.IHttpActionResult)Ok(success);
            }

            [HttpPost]
            [Route("verify/email")]
            public async Task<System.Web.Http.IHttpActionResult> VerifyEmail(string email, string code, string emailVerificationCode)
            {
                var success = await _userService.VerifyEmailAsync(email, code, emailVerificationCode);
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
    }
    }


