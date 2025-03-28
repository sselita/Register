using System.Net.NetworkInformation;
using Application.DTOs;
using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;



namespace Register.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.OpenApi.Validations;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public AccountController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        // Endpoint to create an account
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto dto)
        {
            // Generate verification codes 
            var mobileVerificationCode = new Random().Next(0, 10000).ToString("D4");
            var emailVerificationCode = new Random().Next(0, 10000).ToString("D4");

            var user = await _userRepository.GetUserByICNuberAsync(dto.ICNumber);
            if (user != null)
            {
                return BadRequest($"User with IC Number: {dto.ICNumber} already exists.");
            }
            user = await _userService.CreateAccountAsync(dto,mobileVerificationCode,emailVerificationCode);

            var response = new CreateAccountResponseDto
            {
                User = user,
                MobileCode = mobileVerificationCode,
                EmailCode = emailVerificationCode
            };

            
            return Ok(response);

        }

        // Verify mobile number
        [HttpPost]
        [Route("verify/mobile")]
        public async Task<IActionResult> VerifyMobile([FromBody] VerifyMobileDto dto)
        {
            if (dto.Code != dto.MobileVerificationCode)
            {
                return BadRequest("Incorrect OTP for mobile verification.");
            }

            var success = await _userService.VerifyMobileAsync(dto.IcNumber);
            return success ? Ok("Mobile number verified successfully.") : BadRequest("Failed to verify mobile number.");
        }

        // Verify email
        [HttpPost]
        [Route("verify/email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailDto dto)
        {
            if (dto.Code != dto.EmailVerificationCode)
            {
                return BadRequest("Incorrect OTP for email verification.");
            }

            var success = await _userService.VerifyEmailAsync(dto.IcNumber);
            return success ? Ok("Email verified successfully.") : BadRequest("Failed to verify email.");
        }

        // Set PIN
        [HttpPost]
        [Route("set-pin")]
        public async Task<IActionResult> SetPin([FromBody] SetPinDto dto)
        {
            if (dto.Pin != dto.ConfirmPin)
            {
                return BadRequest("PIN and Confirm PIN do not match.");
            }

            var success = await _userService.SetPinAsync(dto.MobileNumber, dto.Pin);
            return success ? Ok("PIN set successfully.") : BadRequest("Failed to set PIN.");
        }

        // Login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            // Generate verification codes 
            var mobileVerificationCode = new Random().Next(0, 10000).ToString("D4");
            var emailVerificationCode = new Random().Next(0, 10000).ToString("D4");

            var user = await _userService.VerifyUserAsync(dto.ICNumber);

            if (!user)
            {
                return Unauthorized("Invalid IC Number.");
            }

            var userDetails = await _userRepository.GetUserByICNuberAsync(dto.ICNumber);
            var response = new CreateAccountResponseDto
            {
                User = userDetails,
                MobileCode = mobileVerificationCode,
                EmailCode = emailVerificationCode
            };


            return Ok(response);
        }

        // Agree to Privacy Policy
        [HttpPost]
        [Route("privacy-policy")]
        public async Task<IActionResult> PrivacyPolicy([FromBody] PrivacyPolicyDto dto)
        {
            var user = await _userRepository.GetUserByICNuberAsync(dto.ICNumber);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.PrivacyPolicy = true;
            await _userRepository.UpdateUserAsync(user);

            return Ok("Privacy Policy agreed successfully.");
        }

    
    }
}


