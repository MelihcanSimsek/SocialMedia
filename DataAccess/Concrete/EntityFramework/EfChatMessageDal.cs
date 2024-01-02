using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfChatMessageDal : EfEntityFrameworkBase<ChatMessage, SocialMediaContext>, IChatMessageDal
    {
        public List<MessageDto> GetAllMessageDetail(Guid chadId)
        {
            using (var context = new SocialMediaContext())
            {
                var result = from user in context.Users
                             join message in context.ChatMessages
                             on user.Id equals message.UserId
                             where message.ChatId == chadId
                             select new MessageDto
                             {
                                 ChatId = chadId,
                                 UserId = user.Id,
                                 ImagePath = message.ImagePath,
                                 Content = message.Content,
                                 CreationDate = message.CreationDate,
                                 MessageId = message.Id,
                                 Name = user.Name,
                                 SeenAt = message.SeenAt,
                                 Type = message.Type
                             };

                return result.ToList();
            }
        }
    }
}
