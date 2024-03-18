using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdvertiseService
    {
        IResult Add(IFormFile file, Advertise advertise);
        IDataResult<Advertise> GetUserSideAdvertiseByUserId(int userId);
        IDataResult<Advertise> GetUserMainAdvertiseByUserId(int userId);
    }
}
