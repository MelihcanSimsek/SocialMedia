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
        IProfileService _profileService;

        public AuthManager(ITokenHelper tokenHelper,IUserService userService,IProfileService profileService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
            _profileService = profileService;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var roles = _userService.GetRoles(user).Data;
            var accessToken = _tokenHelper.CreateToken(user,roles);
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

            if (userToCheck.Data.Status == false)
            {
                return new ErrorDataResult<User>(Messages.UserBanned);
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
            var newUser = _userService.GetByEmail(registerDto.Email).Data;
            var result = _profileService.Add(new Profile { UserId = newUser.Id });
            return new SuccessDataResult<User>(newUser,Messages.UserRegistered);
        }

        public IResult UpdateUserPassword(UserForUpdateDto userForUpdateDto)
        {
            var user = _userService.GetByUserId(userForUpdateDto.Id).Data;
            if (!HashingHelper.VerifyPassword(userForUpdateDto.OldPassword, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }

            return UpdatePassword(user, userForUpdateDto);

        }

        private IResult UpdatePassword(User user,UserForUpdateDto userForUpdateDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(userForUpdateDto.NewPassword, out passwordHash, out passwordSalt);

            var newUser = new User
            {
                Id = user.Id,
                BanDate = user.BanDate,
                CreationDate = user.CreationDate,
                Email = user.Email,
                Name = user.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = user.Status
            };

            _userService.Update(newUser);
            return new SuccessResult();

        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByEmail(email).Data;
            if(result != null)
            {
                return new SuccessResult(Messages.UserAlreadyExists);
            }
            return new ErrorResult();
        }
    }
}
