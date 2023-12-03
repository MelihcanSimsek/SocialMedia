using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IDataResult<Profile> GetProfileByUserId(int id)
        {
            var result = _profileDal.Get(p => p.UserId == id);
            return new SuccessDataResult<Profile>(result);
        }

        public IResult Update(Profile profile)
        {
            _profileDal.Update(profile);
            return new SuccessResult();
        }
    }
}
