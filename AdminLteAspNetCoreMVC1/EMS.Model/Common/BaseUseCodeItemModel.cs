﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.Common
{
    public class BaseSearchModel : IPager
    {
        private int _PageNum;
        public int PageNum
        {
            get
            {
                if (_PageNum <= 0)
                {
                    return 1;
                }
                return _PageNum;
            }
            set
            {
                _PageNum = value;
            }
        }


        private int _PageSize;
        public int PageSize
        {
            get
            {
                if (_PageSize <= 0)
                {
                    _PageSize = 10;
                }
                return _PageSize;
            }
            set
            {
                if (_PageSize <= 0)
                {
                    throw new ArgumentOutOfRangeException("PageSize", "PageSize can not set less than 1.");
                }
                _PageSize = value;
            }
        }

        private int _PagerItemCount;
        /// <summary>
        /// How many Pager button will be shown, it is must be odd number.
        /// </summary>
        public int PagerItemCount
        {
            get
            {
                if (_PagerItemCount <= 0)
                {
                    _PagerItemCount = 9;
                }
                return _PagerItemCount;
            }
            set
            {
                if (_PagerItemCount <= 0)
                {
                    throw new ArgumentOutOfRangeException("PagerItemCount", "PagerItemCount can not set less than 1.");
                }
                _PagerItemCount = value;
            }

        }

        private int _RecordCount;
        public int RecordCount
        {
            get { return _RecordCount; }
            set
            {
                TotalPage = value / PageSize + (value % PageSize > 0 ? 1 : 0);
                //如果当前页大于总页数,那么当前页取最大页
                if (PageNum >= TotalPage)
                {
                    PageNum = TotalPage;
                }

                //如果当前页小于1,那么当前页取1
                if (PageNum < 1)
                {
                    PageNum = 1;
                }
                SetPageSkip();
                _RecordCount = value;
            }
        }
        public int TotalPage { get; set; }
        public int PageSkip { get; set; }

        private void SetPageSkip()
        {
            PageSkip = (PageNum - 1) * PageSize;
        }

        public string SortBy { get; set; }
        public string SortDirection { get; set; }

        public string PreSearchCriteria { get; set; }

        //public int CompanyId { get; set; }
        //public List<int> OrgUnitIds { get; set; }

        //private bool? _IsDelete;
        //public bool? IsDelete
        //{
        //    get
        //    {
        //        if (!IsDelete.HasValue)
        //            return false;
        //        else
        //            return _IsDelete;
        //    }
        //    set
        //    {
        //        _IsDelete = value;
        //    }
        //}

        //[DataType(DataType.Date, ErrorMessageResourceName = "EquipItem_NextWorkshopServiceDate_Format", ErrorMessageResourceType = typeof(MessageResource))]
        [DataType(DataType.Date, ErrorMessage = "日期格式错误！")]
        public DateTime? StartDate { get; set; }

        //[DataType(DataType.Date, ErrorMessageResourceName = "EquipItem_NextWorkshopServiceDate_Format", ErrorMessageResourceType = typeof(MessageResource))]
        [DataType(DataType.Date, ErrorMessage = "日期格式错误！")]
        public DateTime? EndDate { get; set; }

        public int RoleId { get; set; }
    }

}
