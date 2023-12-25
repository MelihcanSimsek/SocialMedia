using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFollowerService
    {
        IResult Add(Follower follower);
        IResult Delete(Follower follower);
        IResult Update(Follower follower);
        IDataResult<List<int>> GetAllFollowerByUserId(int id);
        IDataResult<List<int>> GetAllFollowedUseridByUserId(int id);
        IDataResult<List<UserFollowerDto>> GetAllUserFriends(int id);
        IDataResult<List<UserFollowerDto>> GetAllUserFollowerListWithoutFriends(int id);
        IDataResult<List<UserFollowerDto>> GetAllUserFollowedListWithoutFriends(int id);
    }
}
