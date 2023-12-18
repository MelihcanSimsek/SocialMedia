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
    public interface IPostService
    {
        IResult Add(IFormFile file,Post post);
        IResult Delete(Post post);
        IResult Update(Post post);
        IDataResult<List<Post>> GetAll();
        IDataResult<Post> GetPostById(int id);
        IDataResult<List<PostDetailDto>> GetAllUserPost(int id);
        IDataResult<List<PostDetailDto>> GetAllUserComment(int id);
        IDataResult<List<PostDetailDto>> GetAllFavedPostUserId(int id);
        IDataResult<List<PostDetailDto>> GetAllPostDetailByUserId(int id);
        IDataResult<List<PostDetailDto>> GetAllPostDetail();
        IDataResult<List<PostDetailDto>> GetAllCommentByPostId(int id);
        IDataResult<PostDetailDto> GetPostDetailById(int id);
        IResult DeleteAllUserPost(int id);
    }
}
