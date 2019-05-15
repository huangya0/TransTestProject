using EMS.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BL.Common
{
    public delegate void MessageEventHandler(BaseBusinessLogic sender, MessageModel message);
    public class BaseBusinessLogic
    {
        #region =====Message============

        private MessageModel _Message;
        public MessageModel Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
                if (SetMessage != null)
                {
                    SetMessage(this, value);
                }
            }
        }

        public event MessageEventHandler SetMessage;

        #endregion

        //public UserIdentityType UserIdentity { get; set; }
    }

}