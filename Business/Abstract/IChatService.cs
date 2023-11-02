using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IChatService
    {
        IResult Add(Chat chat);
        IResult Delete(Chat chat);
        IResult Update(Chat chat);
        IDataResult<List<Chat>> GetAllChatMessagesByUsersId(int firstid, int secondid);
    }
}
