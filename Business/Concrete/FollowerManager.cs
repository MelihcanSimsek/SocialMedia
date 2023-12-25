using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections;
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

        public IDataResult<List<UserFollowerDto>> GetAllUserFollowedListWithoutFriends(int id)
        {
            List<UserFollowerDto> followedList = new List<UserFollowerDto>();
            var userFollowerList = _followerDal.GetAll(f => f.FollowedId == id).Select(f => f.FollowerId).ToList();
            var userFollowedList = _followerDal.GetAll(f => f.FollowerId == id).Select(f => f.FollowedId).ToList();
            var friendIdList = userFollowerList.Intersect(userFollowedList).ToList();
            var userFollowedListWithoutFriend = userFollowedList.Except(friendIdList).ToList();
            if (userFollowedListWithoutFriend != null)
            {
                foreach (var userid in userFollowedListWithoutFriend)
                {
                    followedList.Add(_followerDal.GetUser(userid));
                }
            }

            return new SuccessDataResult<List<UserFollowerDto>>(followedList);
        }

        public IDataResult<List<UserFollowerDto>> GetAllUserFollowerListWithoutFriends(int id)
        {
            List<UserFollowerDto> followerList = new List<UserFollowerDto>();
            var userFollowerList = _followerDal.GetAll(f => f.FollowedId == id).Select(f => f.FollowerId).ToList();
            var userFollowedList = _followerDal.GetAll(f => f.FollowerId == id).Select(f => f.FollowedId).ToList();
            var friendIdList = userFollowerList.Intersect(userFollowedList).ToList();
            var userFollowerListWithoutFriend = userFollowerList.Except(friendIdList).ToList();
            if(userFollowerListWithoutFriend != null)
            {
                foreach (var userid in userFollowerListWithoutFriend)
                {
                    followerList.Add(_followerDal.GetUser(userid));
                }
            }

            return new SuccessDataResult<List<UserFollowerDto>>(followerList);
        }

        public IDataResult<List<UserFollowerDto>> GetAllUserFriends(int id)
        {
            List<UserFollowerDto> friendList = new List<UserFollowerDto>();
            var userFollowerList = _followerDal.GetAll(f => f.FollowedId == id).Select(f => f.FollowerId).ToList();
            var userFollowedList = _followerDal.GetAll(f => f.FollowerId == id).Select(f => f.FollowedId).ToList();
            var friendIdList = userFollowerList.Intersect(userFollowedList).ToList();

           if(friendIdList != null)
            {
                foreach (var friendId in friendIdList)
                {
                    friendList.Add(_followerDal.GetUser(friendId));
                }
            }
            return new SuccessDataResult<List<UserFollowerDto>>(friendList);
        }


        public IResult Update(Follower follower)
        {
            _followerDal.Update(follower);
            return new SuccessResult(Messages.FollowUpdated);
        }
    }
}
