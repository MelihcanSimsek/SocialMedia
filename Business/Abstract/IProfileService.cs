
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProfileService
    {
        IResult Add(Profile profile);
        IResult Delete(Profile profile);
        IResult Update(Profile profile);
        IDataResult<UserProfileDto> GetProfileByUserId(int id);
        IResult UpdateProfileImage(IFormFile formFile, Profile profile);
        IResult UpdateBackgroundImage(IFormFile formFile, Profile profile);
    }
}
