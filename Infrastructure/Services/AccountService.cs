//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Application.DTOs;
//using Core.Entities;

//namespace Infrastructure.Services
//{
//    public class AccountService //: IAccountService
//    {
//        private readonly AppDbContext _context;

//        public AccountService(AppDbContext context)
//        {
//            _context = context;
//        }

//        public string CreateAccount(CreateAccountDto dto)
//        {
//            var user = new User
//            {
//                ICNumber = dto.ICNumber,
//                MobileNumber = dto.MobileNumber,
//                Email = dto.Email,
//                IsMobileVerified = false,
//                IsEmailVerified = false
//            };

//            _context.Users.Add(user);
//            _context.SaveChanges();

//            return "Account created successfully";
//        }

//        public string VerifyMobile(VerifyMobileDto dto)
//        {
//            var user = _context.Users.SingleOrDefault(u => u.MobileNumber == dto.MobileNumber);

//            if (user != null && dto.MobileVerificationCode == "1234")
//            {
//                user.IsMobileVerified = true;
//                _context.SaveChanges();
//                return "Mobile number verified";
//            }

//            return "Verification failed";
//        }

//        public string VerifyEmail(VerifyEmailDto dto)
//        {
//            var user = _context.Users.SingleOrDefault(u => u.Email == dto.Email);

//            if (user != null && dto.EmailVerificationCode == "1234")
//            {
//                user.IsEmailVerified = true;
//                _context.SaveChanges();
//                return "Email verified";
//            }

//            return "Verification failed";
//        }


//    }

   
//}

