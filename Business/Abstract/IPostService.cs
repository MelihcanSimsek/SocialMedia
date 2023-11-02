using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService
    {
        IResult Add(Post post);
        IResult Delete(Post post);
        IResult Update(Post post);
        IDataResult<List<Post>> GetAll();

        IDataResult<Post> GetPostById(int id);
    }
}
