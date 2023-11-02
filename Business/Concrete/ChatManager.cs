using Business.Abstract;
using Business.Constants;
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
    public class ChatManager : IChatService
    {
        IChatDal _chatDal;
        public ChatManager(IChatDal chatDal)
        {
            _chatDal = chatDal;
        }
        public IResult Add(Chat chat)
        {
            _chatDal.Add(chat);
            return new SuccessResult(Messages.MessageSended);
        }

        public IResult Delete(Chat chat)
        {
            _chatDal.Delete(chat);
            return new SuccessResult(Messages.MessageDeleted);
        }

        public IDataResult<List<Chat>> GetAllChatMessagesByUsersId(int firstid, int secondid)
        {
            var result = _chatDal.GetAll(c => (c.SenderId == firstid && c.ReceiverId == secondid) || (c.SenderId == secondid && c.ReceiverId == firstid));
            return new SuccessDataResult<List<Chat>>(result);
        }

        public IResult Update(Chat chat)
        {
            _chatDal.Update(chat);
            return new SuccessResult(Messages.MessageUpdated);
        }
    }
}
