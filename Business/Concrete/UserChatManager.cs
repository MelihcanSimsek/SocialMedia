using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserChatManager : IUserChatService
    {

        IUserChatDal _userChatDal;
        public UserChatManager(IUserChatDal userChatDal)
        {
            _userChatDal = userChatDal;
        }
        public IResult Add(UserChat userChat)
        {
            _userChatDal.Add(userChat);
            return new SuccessResult();
        }

        public IDataResult<ChatResponseDto> CheckUsersHaveaChatRoom(int firstUserId, int secondUserId)
        {
            var firstUserChatRooms = _userChatDal.GetAll(p => p.UserId == firstUserId).Select(p => p.ChatId).ToList();
            var secondUserChatRooms = _userChatDal.GetAll(p => p.UserId == secondUserId).Select(p => p.ChatId).ToList();
            var commonChatRooms = firstUserChatRooms.Intersect(secondUserChatRooms).ToList();
            
            if (commonChatRooms.Count > 0)
            {
               
                return new SuccessDataResult<ChatResponseDto>(new ChatResponseDto { ChatId = commonChatRooms.FirstOrDefault(), Open = true });
            }
            return new SuccessDataResult<ChatResponseDto>(new ChatResponseDto { ChatId = commonChatRooms.FirstOrDefault(), Open = false });
        }

        public IResult Delete(UserChat userChat)
        {
            _userChatDal.Delete(userChat);
            return new SuccessResult();
        }

        public IDataResult<List<ChatProfileDto>> GetUserMessageList(int id)
        {
            List<ChatProfileDto> profileDto = new List<ChatProfileDto>();
            List<int> userIdList = new List<int>();
            var chatList = _userChatDal.GetAll(p=> p.UserId == id).Select(p=>p.ChatId).ToList();
            if (chatList != null)
            {
                foreach (var chatId in chatList)
                 {
                userIdList.Add(_userChatDal.Get(p => p.UserId != id && p.ChatId == chatId).UserId);
                 }

           
                for(int i=0;i<chatList.Count;i++)
                {
                    profileDto.Add(_userChatDal.GetChatProfile(userIdList[i], chatList[i],id));
                }
            }

            var result =  profileDto.OrderByDescending(p => p.LastMessageDate).ToList();

            return new SuccessDataResult<List<ChatProfileDto>>(result);
        }

      

        public IResult Update(UserChat userChat)
        {
            _userChatDal.Update(userChat);
            return new SuccessResult();
        }
    }
}
