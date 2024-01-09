using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFavService
    {
        IResult Add(Fav fav);
        IResult Delete(Fav fav);
        IResult Update(Fav fav);
        IDataResult<int> GetPostFavNumber(int postid);
        IDataResult<List<int>> GetUserFavedPosts(int id);
        IDataResult<List<int>> GetPostCommentsFav(int userId, int postId);
        IDataResult<List<int>> GetUserPostsFavs(int userId, int targetId);
        IDataResult<List<int>> GetUserCommentsFavs(int userId, int targetId);
        IDataResult<List<int>> GetUserFavPostsFavs(int userId, int targetId);
        IResult DeleteAllUserFav(int id);
    }
}
