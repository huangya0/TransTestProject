using EMS.BL.Common;
using EMS.GlobalResources;
using EMS.Model.Common;
using EMS.Model.Role;
using EMS.Utility.Log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AdminLteAspNetMVC1.Common
{
    public class BaseController : Controller
    {
        public IBaseControllerBLL BaseBLL = new BaseControllerBLL();
        public IForUserHelper UserHelp = new ForUserHelper();
        public IStaticMethod StaticMethod = new StaticMethodHelper();
        public IForCommonHelper CommonHelp = new ForCommonHelper();

        #region Permission Module

        //private CompanyPermissionManagement permissionManagement;
        //protected CompanyPermissionManagement PermissionManagement
        //{
        //    get
        //    {
        //        if (permissionManagement == null)
        //        {
        //            permissionManagement = new PermissionService(this.SimpleCompany.Id, UserHelp.GetCurrentRole().Select(c => c.Key).ToArray()).CompanyPermissionMamagement;
        //        }
        //        return permissionManagement;
        //    }
        //}

        /// <summary>
        /// 获取当前用户拥有该模块的功能
        /// </summary>
        /// <param name="permissionLevel"></param>
        /// <returns></returns>
        //public ModulePermissionHelper GetPermissionHelper(string permissionLevel)
        //{
        //    return PermissionManagement.GetCurrentUserPermission(permissionLevel);
        //}
        #endregion



        #region ========Language============
        public static string[] SupportLanguage = new string[] { "en-us", "zh-cn", "zh-hk" };
        [AllowAnonymous]
        public ActionResult ChangeLanguage(string lang)
        {
            // 1. valid the lang
            if (!SupportLanguage.Contains(lang.ToLower()))
            {
                throw new ArgumentException(MessageResource.Language_NotSupport);
            }

            // 2. set the thread culture
            CultureInfo culture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            // 3. set the language to cookie
            var langCookie = Request.Cookies["lang"];
            if (langCookie == null)
            {
                langCookie = new HttpCookie("lang", lang);
                Response.Cookies.Add(langCookie);
            }
            else
            {
                langCookie.Value = lang;
            }
            langCookie.Expires.AddYears(1);
            Response.Cookies.Add(langCookie);

            // 4. get the request url, and postback
            if (Request.UrlReferrer == null)
            {
                return Redirect("~/");
            }
            var returnURL = Request.UrlReferrer.OriginalString;
            return Redirect(returnURL);
        }

        /// <summary>
        /// Get Language
        /// </summary>
        /// <returns></returns>
        public string GetCurrentLanguage()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        #endregion

        #region ======RecordMeg==============

        public void InitUpdateMessage<T>(T model) where T : BaseModel
        {
            var user = UserHelp.GetCurrentUser();
            model.UpdatedBy = user == null ? "" : user.LogonName;
            model.UpdatedDate = DateTime.Now;
            if (user == null)
                model.UpdatedByID = null;
            else
                model.UpdatedByID = user.ID;
        }

        public void InitCreateMessage<T>(T model) where T : BaseModel
        {
            var user = UserHelp.GetCurrentUser();
            model.CreatedBy = user == null ? "" : user.LogonName;
            model.CreatedDate = DateTime.Now;
            if (user == null)
                model.CreatedByID = null;
            else
                model.CreatedByID = user.ID;

            model.UpdatedBy = user == null ? "" : user.LogonName;
            model.UpdatedDate = DateTime.Now;
            if (user == null)
                model.UpdatedByID = null;
            else
                model.UpdatedByID = user.ID;
        }

        //public void InitProgressBar<T>(T model, float filesize = 0) where T : BaseModel
        //{
        //    model.AttachmentProgressBar = new AttachmentProgressBar();
        //    model.AttachmentProgressBar.IsShowProgressBar = false;
        //    model.AttachmentProgressBar.IsHaveProgressBar = false;
        //    if (SimpleCompany.TotalAttachLimited != null && SimpleCompany.TotalAttachLimited != 0)
        //    {
        //        model.AttachmentProgressBar.IsHaveProgressBar = true;
        //        if (!(SimpleCompany.IsShowProgressBar.HasValue && SimpleCompany.IsShowProgressBar.Value == false))
        //        {
        //            model.AttachmentProgressBar.IsShowProgressBar = true;
        //        }
        //        if (Request.Params["ActualTotalAttachLimitedRemain"] != null && Request.Params["ActualTotalAttachLimitedRemain"] != "" && Request.Params["ActualTotalAttachLimitedRemain"] != "0" && Convert.ToDouble((string)Request.Params["ActualTotalAttachLimitedRemain"]) != 0)
        //        {
        //            model.AttachmentProgressBar.ActualTotalAttachLimitedRemain = Convert.ToDouble((string)Request.Params["ActualTotalAttachLimitedRemain"]) - filesize;
        //            model.AttachmentProgressBar.TotalAttachLimitedRemain = Convert.ToDouble((string)Request.Params["ActualTotalAttachLimitedRemain"]) - filesize;
        //        }
        //        else
        //        {
        //            model.AttachmentProgressBar.ActualTotalAttachLimitedRemain = SimpleCompany.TotalAttachLimitedRemain - filesize;
        //            model.AttachmentProgressBar.TotalAttachLimitedRemain = SimpleCompany.TotalAttachLimitedRemain - filesize;
        //        }
        //        model.AttachmentProgressBar.TotalAttachLimited = SimpleCompany.TotalAttachLimited;
        //    }
        //}

        //public void InitProgressBar(AttachmentProgressBar model, float filesize = 0)
        //{
        //    model.IsShowProgressBar = false;
        //    model.IsHaveProgressBar = false;
        //    if (SimpleCompany.TotalAttachLimited != null && SimpleCompany.TotalAttachLimited != 0)
        //    {
        //        model.IsHaveProgressBar = true;
        //        if (!(SimpleCompany.IsShowProgressBar.HasValue && SimpleCompany.IsShowProgressBar.Value == false))
        //        {
        //            model.IsShowProgressBar = true;
        //        }
        //        if (Request.Params["ActualTotalAttachLimitedRemain"] != null && Request.Params["ActualTotalAttachLimitedRemain"] != "" && Request.Params["ActualTotalAttachLimitedRemain"] != "0" && Convert.ToDouble((string)Request.Params["ActualTotalAttachLimitedRemain"]) != 0)
        //        {
        //            model.ActualTotalAttachLimitedRemain = Convert.ToDouble((string)Request.Params["ActualTotalAttachLimitedRemain"]) - filesize;
        //            model.TotalAttachLimitedRemain = Convert.ToDouble((string)Request.Params["ActualTotalAttachLimitedRemain"]) - filesize;
        //        }
        //        else
        //        {
        //            model.ActualTotalAttachLimitedRemain = SimpleCompany.TotalAttachLimitedRemain - filesize;
        //            model.TotalAttachLimitedRemain = SimpleCompany.TotalAttachLimitedRemain - filesize;
        //        }
        //        model.TotalAttachLimited = SimpleCompany.TotalAttachLimited;
        //    }
        //}

        #endregion

        #region ======Company===============

        //public string GetAreaName(int areaID)
        //{
        //    string name = string.Empty;
        //    name = BaseBLL.GetAreaName(areaID);
        //    return name;
        //}
        //public string DateFormate(DateTime? dateTime)
        //{
        //    if (dateTime.HasValue)
        //    {
        //        return dateTime.Value.ToString((string)BaseBLL.GetCurrentCompany(GetCurrentCompanyCode()).DateFormatString);
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}


        //Get the report logo image update by neal 2014-5-21 
        //public Image GetReportLogoImage()
        //{
        //    Image logoImage;
        //    var companyCode = GetCurrentCompanyCode();
        //    var logoData = BaseBLL.GetReportLogo(companyCode);
        //    if (logoData != null)
        //    {
        //        logoImage = ByteArrayToImage(logoData);
        //    }
        //    else
        //    {
        //        var companylogodata = BaseBLL.GetCompanyLogo(companyCode);
        //        if (companylogodata != null)
        //        {
        //            logoImage = ByteArrayToImage(companylogodata);
        //        }
        //        else
        //        {
        //            var filePath = System.Web.HttpContext.Current.Server.MapPath(BasicParam.Default_CompanyLogoUrl);
        //            logoImage = System.Drawing.Image.FromFile(filePath);
        //        }

        //    }
        //    return logoImage;
        //}

        //Convert to image type update by neal 2014-5-21 
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        //public SimpleCompanyModel SimpleCompany
        //{
        //    get
        //    {
        //        if (null == _simpleCompany)
        //        {
        //            string code = this.GetCurrentCompanyCode();
        //            //ICacheHelper cacheHelper = new CacheHelper(BasicParam.SimpleCompanyModelKey);
        //            var cacheContainer = CacheContainer.GetInstance();
        //            _simpleCompany = Enumerable.FirstOrDefault<SimpleCompanyModel>(cacheContainer.GetAllCompany(), i => string.Compare(i.Code, code, true) == 0);
        //            if (null == _simpleCompany)
        //            {
        //                LogHelper.AddInfoLog("SimpleCompany is null and company code= '" + code + "'", "base.SimpleCompany");
        //                _simpleCompany = new SimpleCompanyModel();
        //            }
        //        }
        //        return _simpleCompany;
        //    }
        //}

        //private SimpleCompanyModel _simpleCompany;

        //public List<SimpleCompanyModel> GetAllCompany()
        //{
        //    var cacheContainer = CacheContainer.GetInstance();
        //    return cacheContainer.GetAllCompany();
        //}

        //public CompanyDisplayHelper GetCompanyDisplayAttribute()
        //{
        //    string code = this.GetCurrentCompanyCode();
        //    CompanyDisplayHelper company;

        //    //ICacheHelper cacheHelper = new CacheHelper(BasicParam.CompanyDisplayAttributeKey);
        //    var cacheContainer = CacheContainer.GetInstance();
        //    List<CompanyDisplayHelper> companyDisplayHelperList = cacheContainer.GetCompanyDisplayAttributeList();//cacheHelper.GetLinqCahce<CompanyDisplayHelper>(BaseBLL.GetCompanyDisplayAttributeList());
        //    company = companyDisplayHelperList.First(i => string.Compare(code, i.Code, true) == 0);

        //    return company;
        //}

        //public void ClearCompanyDisplayHelper(string companyCode)
        //{
        //    var companyDisplayHelperList = (List<CompanyDisplayHelper>)HttpContext.Cache[BasicParam.CompanyDisplayAttributeKey] ?? new List<CompanyDisplayHelper>();
        //    var companyDisplay = companyDisplayHelperList.FirstOrDefault(c => c.Code == companyCode);
        //    if (companyDisplay != null)
        //    {
        //        companyDisplayHelperList.Remove(companyDisplay);
        //        HttpContext.Cache[BasicParam.CompanyDisplayAttributeKey] = companyDisplayHelperList;
        //    }
        //}

        //public void ClearCompanyDisplayHelper(int companyId)
        //{
        //    var companyDisplayHelperList = (List<CompanyDisplayHelper>)HttpContext.Cache[BasicParam.CompanyDisplayAttributeKey] ?? new List<CompanyDisplayHelper>();
        //    var companyDisplay = companyDisplayHelperList.FirstOrDefault(c => c.Id == companyId);
        //    if (companyDisplay != null)
        //    {
        //        companyDisplayHelperList.Remove(companyDisplay);
        //        HttpContext.Cache[BasicParam.CompanyDisplayAttributeKey] = companyDisplayHelperList;
        //    }
        //}

        //public void ClearCompanyDisplayHelper()
        //{
        //    string code = this.GetCurrentCompanyCode();
        //    ClearCompanyDisplayHelper(code);
        //}

        //public CompanyItemModel GetCurrentCompany()
        //{
        //    string code = this.GetCurrentCompanyCode();
        //    return BaseBLL.GetCurrentCompany(code);
        //}

        //public bool GetDisplayCreateOrUpdate()
        //{
        //    //bool result = true;
        //    //int companyId = this.GetCurrentCompanyId();
        //    //if (companyId > 0)
        //    //{
        //    //    result = BaseBLL.GetCurrentCompanyDisplayCreateOrUpdate(companyId);
        //    //}
        //    //return result;
        //    if (this.SimpleCompany == null)
        //        return true;
        //    else
        //        return this.SimpleCompany.IsShowAdditionalField;
        //}

        //public bool GetDisplayCreateOrUpdate(int companyId)
        //{
        //    bool result = true;
        //    //if (companyId > 0)
        //    //{
        //    //    result = BaseBLL.GetCurrentCompanyDisplayCreateOrUpdate(companyId);
        //    //}
        //    if (this.SimpleCompany != null)
        //    {
        //        result = this.SimpleCompany.IsShowAdditionalField;
        //    }
        //    return result;
        //}

        //public string GetCurrentCompanyName()
        //{
        //    //var company = this.GetCurrentCompany();
        //    //if (company == null || string.IsNullOrEmpty(company.Name))
        //    //    return "Admin";
        //    //else
        //    //    return this.GetCurrentCompany().Name;
        //    if (this.SimpleCompany == null || string.IsNullOrEmpty(this.SimpleCompany.Name))
        //    {
        //        return "Admin";
        //    }
        //    else
        //    {
        //        return this.SimpleCompany.Name;
        //    }
        //}

        //public string GetCurrentCompanyDisplayName()
        //{
        //    //var company = this.GetCurrentCompany();
        //    //if (company == null || string.IsNullOrEmpty(company.Name))
        //    //    return "Admin";
        //    //else
        //    //    return this.GetCurrentCompany().Name;
        //    if (this.SimpleCompany == null || string.IsNullOrEmpty(this.SimpleCompany.DisplayName))
        //    {
        //        return "Admin";
        //    }
        //    else
        //    {
        //        return this.SimpleCompany.DisplayName;
        //    }
        //}
        //public List<string> GetCurrentUserComapanyCodes(int userId)
        //{
        //    return BaseBLL.GetCurrentUserComapanyCodes(userId);
        //}
        //public List<string> GetAllCompanyCode()
        //{
        //    return BaseBLL.GetAllCompanyCode();
        //}

        //public string GetCurrentCompanyCode()
        //{
        //    var company = this.ControllerContext.RouteData.Values["company"];
        //    string companyCode = company == null ? "" : company.ToString();
        //    return companyCode;
        //}

        //public string GetCompanyDateFormat()
        //{
        //    if (this.SimpleCompany == null)
        //    {
        //        return BasicParam.ShortDatetimeFormat;
        //    }
        //    if (!string.IsNullOrEmpty(this.SimpleCompany.DateFormatString))
        //    {
        //        return this.SimpleCompany.DateFormatString;
        //    }
        //    else
        //    {
        //        return BasicParam.ShortDatetimeFormat;
        //    }
        //}

        public DateTimeFormatInfo GetClientCultureDateFormate()
        {
            DateTimeFormatInfo dateTimeFormatInfo;
            try
            {
                var languages = Request.UserLanguages;

                if (languages == null && languages.Count() == 0)
                {
                    //CultureInfo.InvariantCulture.DateTimeFormat
                    dateTimeFormatInfo = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                }
                else
                {
                    dateTimeFormatInfo = CultureInfo.GetCultureInfo(languages[0]).DateTimeFormat;
                }
                ViewBag.DateTimeFormatInfo = dateTimeFormatInfo;
                return Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            }
            catch (Exception ex)
            {
                LogHelper.AddErrorLog("Not support this culture.", this.ToString(), ex);
                dateTimeFormatInfo = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                ViewBag.DateTimeFormatInfo = dateTimeFormatInfo;
                return Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            }
        }

        //public string GetCompanyDateFormat(int companyId)
        //{
        //    if (this.SimpleCompany != null && !string.IsNullOrEmpty(this.SimpleCompany.DateFormatString))
        //    {
        //        return this.SimpleCompany.DateFormatString;
        //    }
        //    else
        //    {
        //        return BasicParam.ShortDatetimeFormat;
        //    }
        //    //return BaseBLL.GetCompanyDateFormat(companyId);
        //}


        /// <returns>if not record exist, return 0</returns>
        //public int GetCurrentCompanyId()
        //{
        //    return this.SimpleCompany.Id;
        //}

        //public double GetTotalAttachmentSizeLimitRemain()
        //{
        //    double totalAttachmentSizeLimitedRemain = this.SimpleCompany.TotalAttachLimitedRemain.HasValue ? this.SimpleCompany.TotalAttachLimitedRemain.Value : 0;
        //    return totalAttachmentSizeLimitedRemain;
        //}

        //public int GetAttachLimited()
        //{
        //    int result = this.SimpleCompany.AttachLimited.HasValue ? this.SimpleCompany.AttachLimited.Value * 1024 : 0;
        //    if (result == 0)
        //    {
        //        HttpRuntimeSection section = (HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime");
        //        result = section.MaxRequestLength - 100;
        //    }

        //    return result;

        //}

        //public int GetConfigAttachLimit()
        //{
        //    HttpRuntimeSection section = (HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime");
        //    return section.MaxRequestLength - 100;
        //}

        //public string GetEmailSender()
        //{
        //    string code = GetCurrentCompanyCode();
        //    return BaseBLL.GetEmailSender(code);
        //}
        
        #endregion


        #region==============域登录=========
        public String ADLogonName
        {
            get
            {
                int len = Request.LogonUserIdentity.Name.IndexOf('\\', 0);
                var adLogonName = Request.LogonUserIdentity.Name.Substring(len + 1);
                return adLogonName;
            }
        }
        public String ADDomain
        {
            get
            {
                int len = Request.LogonUserIdentity.Name.IndexOf('\\', 0);
                var adDomain = Request.LogonUserIdentity.Name.Substring(0, len);
                return adDomain;
            }
        }
        #endregion==========================
        

        #region ==========User==========
        //public ActionResult GetAllUserItem(string currentIds, UserSearchModel search, string searchName)
        //{
        //    var company = new Company();
        //    var userID = UserHelp.GetCurrentUser().ID;
        //    var companyID = GetCurrentCompanyId();
        //    var models = company.GetAllUserItem(search, searchName, userID, companyID);
        //    ViewBag.CurrentIds = currentIds;
        //    UserModel userModel = new UserModel();
        //    userModel.ItemList = models;
        //    userModel.Search = search;
        //    return PartialView("UserListContainer", userModel);
        //}

        public int GetLongonUserRole()
        {
            return BaseBLL.GetLongonUserRole(UserHelp.GetCurrentUser().ID);
        }

        public List<RoleItemModel> GetLongonUserRoles()
        {
            return BaseBLL.GetLongonUserRoles(UserHelp.GetCurrentUser().ID);
        }

        //public UserRole GetUserRole()
        //{
        //    int companyId = this.GetCurrentCompanyId();
        //    UserIdentityType userIdentityType = UserHelp.GetUserIdentityType(companyId);
        //    UserRole userRole = new UserRole(userIdentityType);
        //    return userRole;
        //}

        #endregion


        #region 用于设置报表保存路径和报名名称
        /// <summary>
        /// 用于设置报表保存路径和报名名称
        /// </summary>
        /// <param name="exportType"></param>
        /// <returns></returns>
        //public ExportReportParams GetExportReportParams(EnumExportType exportType)
        //{
        //    if (this is IExportReport)
        //    {
        //        var exportReportParams = new ExportReportParams
        //        {
        //            ControllerName = RouteData.Values["Controller"].ToString(),
        //            FolderPath = Server.MapPath(BasicParam.ReportTempFilePath),
        //            EnumExportType = exportType,
        //            IsReporting = true
        //        };
        //        return exportReportParams;
        //    }
        //    throw new Exception(this.GetType() + " isn't implete IReportController, can not export Report.");
        //}
        //public void ExportSavePatchSetting(CommonExportReportController export, string fileName, EnumExportType exportType)
        //{
        //    Guid guid = Guid.NewGuid();
        //    export.FileName = string.Format("{0}{1}_{2}{3}", fileName, DateTime.Now.ToString("yyyyMMdd"), guid.ToString().Replace("-", ""), export.GetExtension(exportType)); ;
        //    export.SavePath = Server.MapPath(string.Format(BasicParam.ReportTempFilePath + "\\{0}", export.FileName));
        //    export.FolderPath = Server.MapPath(BasicParam.ReportTempFilePath);
        //}
        #endregion

        #region 用于设置删除报表第一列后的列宽度

        /// <summary>
        /// 下面为处理删除报表特定列的操作, 由于报表有一列只用于ReportSite的网站, Airwave的网站不需要这一列, 为避免打印的excel出现列合并导致不能调用office
        /// 排序, 需要删除特定列, 并将除该特定列外的所有列向左移动, 补齐删除列所留的空当
        /// </summary>
        /// <param name="table">需删除列的Devexpress报表的table</param>
        /// <param name="removeColumnIndex">需删除第几列的Index, 从0开始</param>
        //protected void SetColumnPositionAfterRemoveReportSiteColumn(XRTable table, int removeColumnIndex = 0)
        //{
        //    if (!(this is IExportReport))
        //    {
        //        throw new Exception(this.GetType() + " isn't implete IReportController, can not user function name 'SetColumnPositionAfterRemoveReportSiteColumn'.");
        //    }
        //    if (table == null) return;
        //    var tableCells = table.Rows[0].Cells;
        //    //取第一列宽度
        //    var firstColumnWidth = tableCells[0].WidthF;
        //    //取特定列宽度
        //    var removeColumnWidth = tableCells[removeColumnIndex].WidthF;
        //    //取移动距离, 实际上为特定列后一列的宽度
        //    var moveDistance = tableCells[removeColumnIndex + 1].WidthF;

        //    //取特定列的x轴定位长度
        //    var removeColumnLeftF = tableCells[removeColumnIndex].LeftF;
        //    //删除特定列, 原特定列后一列移到特定列的位置
        //    tableCells.RemoveAt(removeColumnIndex);
        //    var cellIndexCount = tableCells.Count;
        //    for (int index = removeColumnIndex; index < cellIndexCount; index++)
        //    {
        //        tableCells[index].LeftF -= moveDistance;
        //    }
        //    //由于删了一列, 其他列会自动增长宽度, 需重新设置第一列宽度
        //    if (removeColumnIndex > 0)
        //    {
        //        tableCells[0].WidthF = firstColumnWidth;
        //    }
        //    //设置宽度
        //    tableCells[removeColumnIndex].WidthF = removeColumnWidth;
        //    //设置左边距设为0
        //    tableCells[removeColumnIndex].LeftF = removeColumnLeftF;
        //}

        #endregion

        #region ========Company Attachment Setting=======

        //public bool GetIsDisplayProgressBar()
        //{
        //    if (this.SimpleCompany.TotalAttachLimited != null && this.SimpleCompany.TotalAttachLimited != 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        #endregion

        #region 保存Devexpress GridView的页码在Cookies中
        public void SetGridViewPageRowSizeInCookies(string gridViewName, int pageRowSize)
        {
            Dictionary<string, int> model = new Dictionary<string, int>();
            model.Add(gridViewName, pageRowSize);
            CommonHelp.SaveObjectInCookie(EMS.Utility.Web.ConfigurationHelper.GetAppSetting("GridViewPageRowSizeCookiesKey"), model);
        }
        #endregion

        //public MessageModel Message { get; set; }

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

        //public bool ValidModel<TModel>(TModel model) where TModel : class
        //{
        //    if (model == null)
        //    {
        //        throw new ArgumentNullException("model");
        //    }
        //    Predicate<string> predicate = propertyName => (new BindAttribute()).IsPropertyAllowed(propertyName);
        //    IModelBinder binder = this.Binders.GetBinder(typeof(TModel));
        //    ModelBindingContext context2 = new ModelBindingContext
        //    {
        //        ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, typeof(TModel)),
        //        ModelName = "abc",
        //        ModelState = this.ModelState,
        //        PropertyFilter = predicate,
        //        ValueProvider = this.ValueProvider
        //    };
        //    ModelBindingContext bindingContext = context2;
        //    binder.BindModel(this.ControllerContext, bindingContext);
        //    return this.ModelState.IsValid;
        //}
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

        //public void InitCompanyIdentity()
        //{
        //    BusinessLogic.SimpleCompany = this.SimpleCompany;
        //    BusinessLogic.UserIdentity = this.UserIdentity;
        //}
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

