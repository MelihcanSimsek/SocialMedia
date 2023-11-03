using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        ITokenHelper _tokenHelper;
        IUserService _userService;

        public AuthManager(ITokenHelper tokenHelper,IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var accessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }

        public IDataResult<User> Login(LoginDto loginDto)
        {
            var userToCheck = _userService.GetByEmail(loginDto.Email);
            if(userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPassword(loginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data, Messages.LoginSuccess);
        }

        public IDataResult<User> Register(RegisterDto registerDto)
        {
            var userToCheck = _userService.GetByEmail(registerDto.Email);
            if(userToCheck.Data != null)
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExists);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(registerDto.Password, out passwordHash, out passwordSalt);
            var user = new User{
                Email = registerDto.Email,
                CreationDate = DateTime.Now,
                Name = registerDto.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByEmail(email);
            if(result.Data != null)
            {
                return new SuccessResult(Messages.UserAlreadyExists);
            }
            return new ErrorResult();
        }
    }
}
