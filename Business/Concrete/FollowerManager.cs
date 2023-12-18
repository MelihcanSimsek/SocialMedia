using Business.Abstract;
using Business.Constants;
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
    public class FollowerManager : IFollowerService
    {
        IFollowerDal _followerDal;

        public FollowerManager(IFollowerDal followerDal)
        {
            _followerDal = followerDal;
        }
        public IResult Add(Follower follower)
        {   
            _followerDal.Add(new Follower() { FollowerId=follower.FollowerId,FollowedId=follower.FollowedId,CreationDate=DateTime.Now});
            return new SuccessResult(Messages.UserFollowed);
        }

        public IResult Delete(Follower follower)
        {
            var result = _followerDal.Get(p => p.FollowerId == follower.FollowerId && p.FollowedId == follower.FollowedId);
            _followerDal.Delete(result);
            return new SuccessResult(Messages.UserUnfollowed);
        }

        public IDataResult<List<int>> GetAllFollowedUseridByUserId(int id)
        {
            var result = _followerDal.GetAll(f => f.FollowerId == id).Select(f => f.FollowedId).ToList();
            return new SuccessDataResult<List<int>>(result);
        }

        public IDataResult<List<int>> GetAllFollowerByUserId(int id)
        {
            var result = _followerDal.GetAll(f => f.FollowedId == id).Select(f=>f.FollowerId).ToList();
            return new SuccessDataResult<List<int>>(result);
        }

        public IResult Update(Follower follower)
        {
            _followerDal.Update(follower);
            return new SuccessResult(Messages.FollowUpdated);
        }
    }
}
