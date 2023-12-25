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
    public interface IUserChatService
    {
        IResult Add(UserChat userChat);
        IResult Delete(UserChat userChat);
        IResult Update(UserChat userChat);
        IDataResult<ChatResponseDto> CheckUsersHaveaChatRoom(int firstUserId, int secondUserId);
        IDataResult<List<ChatProfileDto>> GetUserMessageList(int id);
    }
}
