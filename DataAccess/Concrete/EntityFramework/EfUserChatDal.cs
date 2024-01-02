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
    public class EfUserChatDal : EfEntityFrameworkBase<UserChat, SocialMediaContext>, IUserChatDal
    {
        public ChatProfileDto GetChatProfile(int userId,Guid chatId, int currentUserId)
        {
            using (var context = new SocialMediaContext())
            {
                var messageList = from chatMessage in context.ChatMessages
                                  where chatMessage.ChatId == chatId
                                  select new ChatMessage
                                  {
                                      ChatId = chatMessage.ChatId,
                                      Content = chatMessage.Content,
                                      Id = chatMessage.Id,
                                      UserId = chatMessage.UserId,
                                      CreationDate = chatMessage.CreationDate,
                                      ImagePath = chatMessage.ImagePath,
                                      Type = chatMessage.Type,
                                      SeenAt = chatMessage.SeenAt
                                  };

                var userNotSeeMessages = messageList.Where(p => p.UserId != currentUserId && p.SeenAt == null).ToList();
                var lastMessage = messageList.OrderByDescending(chatMessage => chatMessage.CreationDate).FirstOrDefault();
    

                var result = from userChat in context.UsersChats
                             join user in context.Users on userChat.UserId equals user.Id
                             join profile in context.Profiles on user.Id equals profile.UserId
                             where user.Id == userId && userChat.ChatId == chatId
                             select new ChatProfileDto
                             {
                               ChatId = userChat.ChatId,
                               Name = user.Name,
                               UserId = user.Id,
                               ProfileImage = profile.ProfileImage,
                               LastMessage = lastMessage == null ? "" : lastMessage.Content,
                               LastMessageDate = lastMessage == null? null : lastMessage.CreationDate,
                               LastMessageType = lastMessage == null ? 1 : lastMessage.Type,
                               NotShowedMessagesCount = userNotSeeMessages == null ? 0 : userNotSeeMessages.Count

                             };


                return result.SingleOrDefault();

            }
        }
    }
}
