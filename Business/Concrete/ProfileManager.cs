using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProfileManager:IProfileService
    {
        IProfileDal _profileDal;
        public ProfileManager(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }

        public IResult Add(Profile profile)
        {
            _profileDal.Add(profile);
            return new SuccessResult();
        }

        public IResult Delete(Profile profile)
        {
            var result = _profileDal.Get(p => p.UserId == profile.UserId);
            _profileDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<UserProfileDto> GetProfileByUserId(int id)
        {
            var result = _profileDal.GetUserProfile(id);
            return new SuccessDataResult<UserProfileDto>(result);
        }

        public IResult Update(Profile profile)
        {
            var oldProfile = _profileDal.Get(p => p.Id == profile.Id);
            var newProfile = new Profile()
            {
                Id = profile.Id,
                Description = profile.Description,
                Location = profile.Location,
                BackgroundImage = oldProfile.BackgroundImage,
                ProfileImage = oldProfile.ProfileImage,
                UserId = oldProfile.UserId,
                Status = oldProfile.Status
            };
            _profileDal.Update(newProfile);
            return new SuccessResult();
        }

        public IResult UpdateBackgroundImage(IFormFile formFile, Profile profile)
        {
            var profileToCheck = BackgorundImageCheck(formFile, profile).Data;
            _profileDal.Update(profileToCheck);
            return new SuccessResult(Messages.BackgroundImageUpdated);
        }

        public IResult UpdateProfileImage(IFormFile formFile, Profile profile)
        {
            var profileToCheck = ProfileImageCheck(formFile, profile).Data;
            _profileDal.Update(profileToCheck);
            return new SuccessResult(Messages.ProfileImageUpdated);
        }

        private IDataResult<Profile> ProfileImageCheck(IFormFile file,Profile profile)
        {
            var profileToCheck = _profileDal.Get(p => p.Id == profile.Id);
            if (profileToCheck.ProfileImage != null)
            {
                profileToCheck.ProfileImage = FileHelper.Update(profileToCheck.ProfileImage, file);
            }
            else
            {
                profileToCheck.ProfileImage = FileHelper.Add(file);
            }
            return new SuccessDataResult<Profile>(profileToCheck);
        }

        private IDataResult<Profile> BackgorundImageCheck(IFormFile file,Profile profile)
        {
            var profileToCheck = _profileDal.Get(p => p.Id == profile.Id);
            if (profileToCheck.BackgroundImage != null)
            {
                profileToCheck.BackgroundImage = FileHelper.Update(profileToCheck.BackgroundImage, file);
            }
            else
            {
                profileToCheck.BackgroundImage = FileHelper.Add(file);
            }
            return new SuccessDataResult<Profile>(profileToCheck);
        }
    }
}
