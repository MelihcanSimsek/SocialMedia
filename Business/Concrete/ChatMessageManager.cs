using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
        public IResult Add(ChatMessage chatMessage)
        {
            _chatMessageDal.Add(chatMessage);
            return new SuccessResult();
        }

        public IResult Delete(ChatMessage chatMessage)
        {
            _chatMessageDal.Delete(chatMessage);
            return new SuccessResult();
        }

        public IResult Update(ChatMessage chatMessage)
        {
            _chatMessageDal.Update(chatMessage);
            return new SuccessResult();
        }
    }
}
