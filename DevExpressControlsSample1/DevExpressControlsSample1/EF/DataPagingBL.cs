using DevExpressControlsSample1.Uti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressControlsSample1.EF
{
    public class DataPagingBL : IDisposable
    {

        private readonly Model1 context;

        public DataPagingBL()
        {
            context = new Model1();
        }

        public List<ELMAH_Error> GetElmahErrorLog(ELMAH_Error_SearchModel search)
        {
            Expression<Func<ELMAH_Error, bool>> expr = this.BuildSearchCriteria(search);
            IQueryable<ELMAH_Error> resultQuery = context.ELMAH_Error.Where(expr).SortWith(search.SortBy, search.SortDirection);
            search.RecordCount = resultQuery.Count();
            resultQuery = resultQuery.Skip(search.PageSkip).Take(search.PageSize);
            //Message = MessageModel.LoadSuccess();
            //return this.ConvertToViewModelList(resultQuery);
            return resultQuery.ToList(); //真正执行query的脚本，IQueryable是延时执行
        }

        private List<ELMAH_Error> ConvertToViewModelList(IQueryable<ELMAH_Error> queryResult)
        {
            List<ELMAH_Error> result = new List<ELMAH_Error>();
            foreach (var item in queryResult)
            {
                //result.Add(ConvertToViewModel(Qualificaiton));
                result.Add(item);
            }
            return result;
        }

        private Expression<Func<ELMAH_Error, bool>> BuildSearchCriteria(ELMAH_Error_SearchModel search)
        {
            Expression<Func<ELMAH_Error, bool>> expr = null;
            DynamicLambda<ELMAH_Error> bulid = new DynamicLambda<ELMAH_Error>();
            //if (!string.IsNullOrEmpty(search.StatusCode))
            if (search.StatusCode > 0)
            {
                Expression<Func<ELMAH_Error, bool>> temp = s => (s.StatusCode == search.StatusCode);
                expr = bulid.BuildQueryAnd(expr, temp);
            }
            Expression<Func<ELMAH_Error, bool>> solidFilter = s => (s.Sequence > 0);
            expr = bulid.BuildQueryAnd(expr, solidFilter);
            return expr;
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
