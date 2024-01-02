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
    public interface IChatMessageService
    {
        IResult Add(IFormFile? file,ChatMessage chatMessage);
        IResult Delete(ChatMessage chatMessage);
        IResult Update(ChatMessage chatMessage);
        IDataResult<List<MessageDto>> GetAllMessageDetail(Guid id);
        IResult UpdateAllMessagesSeenTime(ChatUserDto chatUserDto);
    }
}
