using EMS.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BL.Common
{
    public interface IMessageModel
    {
        MessageModel Message { get; set; }
        event MessageEventHandler SetMessage;
    }
}
