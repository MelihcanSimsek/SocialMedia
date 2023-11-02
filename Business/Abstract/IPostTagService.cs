using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostTagService
    {
        IResult Add(PostTag postTag);
        IResult Delete(PostTag postTag);
        IResult Update(PostTag postTag);
        IDataResult<PostTag> GetPostTagByPostId(int id);
    }
}
