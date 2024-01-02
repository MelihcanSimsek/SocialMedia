using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ChatMessageManager : IChatMessageService
    {
        IChatMessageDal _chatMessageDal;

        public ChatMessageManager(IChatMessageDal chatMessageDal)
        {
            _chatMessageDal = chatMessageDal;
        }
        public IResult Add(IFormFile? file,ChatMessage chatMessage)
        {
            if(file != null)
            {
                chatMessage.ImagePath = FileHelper.Add(file);
            }
            chatMessage.CreationDate = DateTime.Now;
            _chatMessageDal.Add(chatMessage);
            return new SuccessResult();
        }

        public IResult Delete(ChatMessage chatMessage)
        {
            _chatMessageDal.Delete(chatMessage);
            return new SuccessResult();
        }

        public IDataResult<List<MessageDto>> GetAllMessageDetail(Guid id)
        {
            var result = _chatMessageDal.GetAllMessageDetail(id).OrderByDescending(p=>p.CreationDate).Reverse().ToList();

            return new SuccessDataResult<List<MessageDto>>(result);
        }

        public IResult Update(ChatMessage chatMessage)
        {
            _chatMessageDal.Update(chatMessage);
            return new SuccessResult();
        }

        public IResult UpdateAllMessagesSeenTime(ChatUserDto chatUserDto)
        {
            var userMessages = _chatMessageDal.GetAll(p => p.ChatId == chatUserDto.ChatId && p.UserId != chatUserDto.UserId  && p.SeenAt == null);
            if(userMessages != null)
            {
                foreach (var message in userMessages)
                {
                    var newMessage= new ChatMessage
                    {
                        ChatId = message.ChatId,
                        Content = message.Content,
                        CreationDate = message.CreationDate,
                        Id = message.Id,
                        ImagePath = message.ImagePath,
                        SeenAt = DateTime.Now,
                        Type = message.Type,
                        UserId = message.UserId
                    };
                    _chatMessageDal.Update(newMessage);
                }
            }
            return new SuccessResult();

        }
    }
}
