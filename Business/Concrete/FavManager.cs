
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
    public class FavManager : IFavService
    {
        IFavDal _favDal;

        public FavManager(IFavDal favDal)
        {
            _favDal = favDal;
        }
        public IResult Add(Fav fav)
        {
            _favDal.Add(fav);
            return new SuccessResult();
        }

        public IResult Delete(Fav fav)
        {
            _favDal.Delete(fav);
            return new SuccessResult();
        }

        public IResult DeleteAllUserFav(int id)
        {
            var result = _favDal.GetAll(f => f.UserId == id);
            if(result != null)
            {
                foreach (var r in result)
                {
                    _favDal.Delete(r);
                }
            }
            return new SuccessResult();
        }

        public IDataResult<int> GetPostFavNumber(int postid)
        {
            var result = _favDal.GetAll(p => p.PostId == postid);
            return new SuccessDataResult<int>(result.Count);
        }

        public IResult Update(Fav fav)
        {
            _favDal.Update(fav);
            return new SuccessResult();
        }
    }
}
