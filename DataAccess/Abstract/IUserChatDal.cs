using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserChatDal:IEntityRepository<UserChat>
    {
        ChatProfileDto GetChatProfile(int userId, Guid chatId,int currentUserId);
    }
}
