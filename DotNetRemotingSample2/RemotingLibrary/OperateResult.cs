using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingLibrary
{
    /// <summary>
    ///     泛型的结果信息
    /// </summary>
    [Serializable]
    public class OperateResult<T> : OperateResult
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="r">返回结果</param>
        /// <param name="message">结果信息</param>
        /// <param name="returnValue">返回数据对象</param>
        public OperateResult(bool r, string message, T returnValue)
            : base(r, message)
        {
            ReturnValue = returnValue;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="returnValue">返回数据对象</param>
        public OperateResult(T returnValue)
            : this(true, "", returnValue)
        {
            string ss = "test";
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="r">默认结果</param>
        /// <param name="m">信息</param>
        //public OperateResult(bool r, string m)
        //    : this(r, m, default(T))
        //{
        //    ValueTypeName = typeof(T).Name;
        //}

        /// <summary>
        ///     无参构造函数
        /// </summary>
        //public OperateResult()
        //{
        //    ValueTypeName = typeof(T).Name;
        //    Result = true;
        //}

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="r">if set to <c>true</c> [r].</param>
        //public OperateResult(bool r)
        //    : this(r, "")
        //{
        //}

        /// <summary>
        ///     构造函数
        /// </summary>
        //public OperateResult(ApiResult<T> apiResult)
        //{
        //    if (apiResult.Code == ApiResult.Sucess)
        //    {//正确
        //        Result = true;
        //        ReturnValue = apiResult.Data;
        //    }
        //    else if (apiResult.Code >= ApiResult.ArgumentNullOrEmptyException &&
        //        apiResult.Code < ApiResult.RepositoryNotFoundException)
        //    {//参数错误
        //        Result = false;
        //        ErrorMessage = apiResult.Message;
        //    }
        //    else
        //    {
        //        Result = false;
        //        ErrorMessage = apiResult.Message;
        //    }
        //}

        //public OperateResult(IEnumerable<OperateResult> results)
        //{
        //    List<string> errorList = new List<string>();
        //    Result = true;
        //    foreach (var operateResult in results)
        //    {
        //        if (!operateResult.Result)
        //        {
        //            Result = false;
        //            errorList.Add(operateResult.ErrorMessage);
        //        }
        //    }

        //    if (!Result && errorList.Count > 0)
        //        ErrorMessage = string.Join(Environment.NewLine, errorList.ToArray());
        //}

        //public OperateResult(OperateResult res)
        //    : base(res.Result, res.ErrorMessage)
        //{
        //}

        //public OperateResult(OperateResult res, T returnData)
        //    : base(res.Result, res.ErrorMessage)
        //{
        //    ReturnValue = returnData;
        //}

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="e">异常</param>
        //public OperateResult(Exception e)
        //{
        //    Result = false;
        //    ErrorMessage = e.Message;
        //}

        /// <summary>
        ///     带回的数据
        /// </summary>
        /// <value>The return value.</value>
        public T ReturnValue { get; set; }

        /// <summary>
        ///     数据类型名称
        /// </summary>
        /// <value>The name of the value type.</value>
        public string ValueTypeName { get; set; }
    }

    /// <summary>
    ///     泛型的结果信息
    /// </summary>
    [Serializable]
    public class OperateResult
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="r">返回结果</param>
        /// <param name="message">结果信息</param>
        public OperateResult(bool r, string message)
        {
            Result = r;
            ErrorMessage = message;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="e">异常</param>
        public OperateResult(Exception e)
        {
            Result = false;
            ErrorMessage = e.Message;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="r">if set to <c>true</c> [r].</param>
        public OperateResult(bool r)
            : this(r, "")
        {
        }

        public OperateResult(OperateResult operateResult)
        {
            Result = operateResult.Result;
            ErrorMessage = operateResult.ErrorMessage;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        //public OperateResult(ApiResult apiResult)
        //{
        //    if (apiResult.Code == ApiResult.Sucess)
        //    {//正确
        //        Result = true;
        //    }
        //    else if (apiResult.Code >= ApiResult.ArgumentNullOrEmptyException &&
        //             apiResult.Code < ApiResult.RepositoryNotFoundException)
        //    {//参数错误
        //        Result = false;
        //        ErrorMessage = apiResult.Message;
        //    }
        //    else
        //    {
        //        Result = false;
        //        ErrorMessage = apiResult.Message;
        //    }
        //}

        /// <summary>
        ///     无参构造函数
        /// </summary>
        public OperateResult()
        {
            Result = true;
        }

        public OperateResult(IEnumerable<OperateResult> results)
        {
            List<string> errorList = new List<string>();
            Result = true;
            foreach (var operateResult in results)
            {
                if (!operateResult.Result)
                {
                    Result = false;
                    errorList.Add(operateResult.ErrorMessage);
                }
            }

            if (!Result && errorList.Count > 0)
                ErrorMessage = string.Join(Environment.NewLine, errorList.ToArray());
        }

        /// <summary>
        ///     Bool型结果
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        ///     错误或异常信息
        /// </summary>
        public string ErrorMessage { get; set; } = "";

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = "";
    }
}
