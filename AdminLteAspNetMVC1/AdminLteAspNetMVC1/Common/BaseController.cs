using EMS.BL.Common;
using EMS.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLteAspNetMVC1.Common
{
    //public IBaseControllerBLL BaseBLL = new BaseControllerBLL();
    public class BaseController : Controller
    {
        public List<MessageModel> _MessageList;
        public List<MessageModel> MessageList
        {
            get
            {
                if (_MessageList == null)
                    _MessageList = new List<MessageModel>();
                return _MessageList;
            }
            set
            {
                _MessageList = value;
            }
        }

    }

    /// <typeparam name="T">your BL class</typeparam>
    public class BaseController<T> : BaseController where T : BaseBusinessLogic, new()
    {
        public T BusinessLogic { get; set; }
        public BaseController()
        {
            BusinessLogic = new T();
            BusinessLogic.SetMessage += BL_SetMessage;
            ViewData["MsgList"] = MessageList;
        }

        void BL_SetMessage(BaseBusinessLogic sender, MessageModel message)
        {
            MessageList.Add(message);
        }

        public void InitCompanyIdentity()
        {
            //BusinessLogic.SimpleCompany = this.SimpleCompany;
            //BusinessLogic.UserIdentity = this.UserIdentity;
        }
    }



    public class BaseController<I, T> : BaseController
        where T : BaseBusinessLogic, I, new()
        where I : IMessageModel
    {
        public I BusinessLogic { get; set; }
        public BaseController()
        {
            BusinessLogic = new T();
            BusinessLogic.SetMessage += BL_SetMessage;
            ViewData["MsgList"] = MessageList;
        }

        void BL_SetMessage(BaseBusinessLogic sender, MessageModel message)
        {
            MessageList.Add(message);
        }
    }
}