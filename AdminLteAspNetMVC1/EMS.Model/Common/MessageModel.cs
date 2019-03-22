using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.Common
{
    public class MessageModel
    {
        public bool IsSuccess { get; set; }
        public MessageType MessageType { get; set; }
        public string Message
        {
            get
            {
                if (string.IsNullOrEmpty(_ExtendMessage))
                    return _BaseMessage;
                else
                    return _BaseMessage + "  " + _ExtendMessage;
            }
            set
            {
                _BaseMessage = value;
                _ExtendMessage = "";
            }
        }
        public object ReturnValue { get; set; }
        public int Times { get; set; }
        public int Count { get; set; }

        private string _BaseMessage = "";
        private string _ExtendMessage = "";

        public MessageModel() { }
        public MessageModel(bool isSuccess, MessageType msgType, string baseMsg)
        {
            IsSuccess = isSuccess;
            MessageType = msgType;
            _BaseMessage = baseMsg;
        }
        public MessageModel(bool isSuccess, MessageType msgType, string baseMsg, string extendMsg, int times, int count)
        {
            IsSuccess = isSuccess;
            MessageType = msgType;
            _BaseMessage = baseMsg;
            _ExtendMessage = extendMsg;
            Times = times;
            Count = count;
        }
        public MessageModel(bool isSuccess, string baseMsg)
        {
            IsSuccess = isSuccess;
            _BaseMessage = baseMsg;
            if (isSuccess)
            {
                MessageType = Common.MessageType.Success;
            }
            else
            {
                MessageType = Common.MessageType.Failure;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is MessageModel)
            {
                var model = (MessageModel)obj;
                if (model.IsSuccess == this.IsSuccess && model.MessageType == this.MessageType && model.Message == this.Message)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.IsSuccess.GetHashCode() + this.Message.GetHashCode() + this.MessageType.GetHashCode();
        }

        // 1
        public static MessageModel LoadSuccess(string extendMsg = "", int times = 1, int count = 0)
        {
            //MessageResource.Message_CommonLoadSuccessful 多语言
            return new MessageModel(true, MessageType.SelectSuccess, "MessageResource.Message_CommonLoadSuccessful", extendMsg, times, count);
        }
        // 2
        public static MessageModel LoadFailue(string extendMsg = "", int times = 1, int count = 0)
        {

            return new MessageModel(false, MessageType.SelectFailure, "MessageResource.Message_CommonError", extendMsg, times, count);
        }
        // 3
        public static MessageModel InsertSuccess(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(true, MessageType.InsertSuccess, "MessageResource.Message_CommonInsertSuccessful", extendMsg, times, count);
        }
        // 4
        public static MessageModel InsertFailue(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(false, MessageType.InsertFailure, "MessageResource.Message_CommonInsertFail", extendMsg, times, count);
        }
        // 5
        public static MessageModel UpdateSuccess(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(true, MessageType.UpdateSuccess, "MessageResource.Message_CommonUpdateSuccessful", extendMsg, times, count);
        }
        // 6
        public static MessageModel UpdateFailue(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(false, MessageType.UpdateFailure, "MessageResource.Message_CommonUpdateFail", extendMsg, times, count);
        }
        // 7
        public static MessageModel DeleteSuccess(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(true, MessageType.DeleteSuccess, "MessageResource.Message_CommonDeleteSuccessful", extendMsg, times, count);
        }
        // 8 
        public static MessageModel DeleteFailue(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(false, MessageType.DeleteFailure, "MessageResource.Message_CommonDeleteFail", extendMsg, times, count);
        }
        // 9
        public static MessageModel ValidFailue(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(false, MessageType.ValidFailure, "MessageResource.Message_CommonValidFailure", extendMsg, times, count);
        }
        // 10
        public static MessageModel CommonSuccess(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(true, MessageType.Success, "MessageResource.Message_CommonSuccessful", extendMsg, times, count);
        }
        //11
        public static MessageModel CommonFailue(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(false, MessageType.Failure, "MessageResource.Message_CommonError", extendMsg, times, count);
        }
        //12
        public static MessageModel CustomeSuccess(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(false, MessageType.Success, "", extendMsg, times, count);
        }
        //13
        public static MessageModel CustomeFailue(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(false, MessageType.Failure, "", extendMsg, times, count);
        }
        //14
        public static MessageModel LegalRightPrevent(string extendMsg = "", int times = 1, int count = 0)
        {
            return new MessageModel(false, MessageType.Failure, "MessageResource.Common_NotEnoughRight", extendMsg, times, count);
        }
    }
}
