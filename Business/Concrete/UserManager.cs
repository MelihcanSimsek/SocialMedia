using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IUserReportService _userReportService;

        public UserManager(IUserDal userDal, IUserReportService userReportService)
        {
            _userDal = userDal;
            _userReportService = userReportService;
        }
        public IResult Add(User user)
        {
             _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Ban(int id)
        {
            
            var user = _userDal.Get(u => u.Id == id);

            var newUser = new User()
            {
                Id = user.Id,
                PasswordHash = user.PasswordHash,
                Status = false,
                CreationDate = user.CreationDate,
                Email = user.Email,
                Name = user.Name,
                PasswordSalt = user.PasswordSalt,
                BanDate = DateTime.Now
            };
            this.Update(newUser);
            _userReportService.DeleteAllUserReportByUserId(id);
            return new SuccessResult();
        }

        public IDataResult<User> ChangeUserName(string name, int id)
        {
            var oldUser = _userDal.Get(u => u.Id == id);
            var newUser = new User()
            {
                CreationDate = oldUser.CreationDate,
                Email = oldUser.Email,
                Id = oldUser.Id,
                Name = name,
                PasswordHash = oldUser.PasswordHash,
                PasswordSalt = oldUser.PasswordSalt,
                Status = oldUser.Status
            };
            _userDal.Update(newUser);
            return new SuccessDataResult<User>(newUser);
        }

        public IResult Delete(User user)
        {
          
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result);
        }

        public IDataResult<List<UserBanDto>> GetBannedUsers()
        {
            var result = _userDal.GetUserProfileDetails(p => p.Status == false);
            return new SuccessDataResult<List<UserBanDto>>(result);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetByUserId(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<Role>> GetRoles(User user)
        {
            var result = _userDal.GetRoles(user);
            return new SuccessDataResult<List<Role>>(result);
        }

        public IDataResult<int> GetSearchUserTotalCount(string filter)
        {
            var result = _userDal.GetAllUserProfiles().Where(user => Regex.IsMatch(user.Name, filter, RegexOptions.IgnoreCase)).ToList().Count;
            return new SuccessDataResult<int>(result);
        }

        public IDataResult<List<UserProfileDto>> SearchUser(string filter, int currentPage, int perPageNumber)
        {
            List<UserProfileDto> newList = new List<UserProfileDto>();
            var result = _userDal.GetAllUserProfiles().Where(user => Regex.IsMatch(user.Name, filter, RegexOptions.IgnoreCase)).OrderByDescending(p => p.CreationDate).Reverse().ToArray();
            int totalCount = result.Length;
            int startIndex = (currentPage - 1) * perPageNumber;

            for (int i = startIndex; i < Math.Min(startIndex + perPageNumber, totalCount); i++)
            {
                newList.Add(result[i]);
            }
            return new SuccessDataResult<List<UserProfileDto>>(newList);
        }

        public IResult Unban(int id)
        {
            var result = _userDal.Get(p => p.Id == id);
            var newUser = new User
            {
                Id = result.Id,
                BanDate = null,
                CreationDate = result.CreationDate,
                Email = result.Email,
                Name = result.Name,
                PasswordHash = result.PasswordHash,
                PasswordSalt = result.PasswordSalt,
                Status = true
            };
            _userDal.Update(newUser);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
