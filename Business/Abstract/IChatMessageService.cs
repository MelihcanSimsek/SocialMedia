using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IChatMessageService
    {
        IResult Add(ChatMessage chatMessage);
        IResult Delete(ChatMessage chatMessage);
        IResult Update(ChatMessage chatMessage);
    }
}
