using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteBLL
{
    //T_VoteItem
    public partial class T_VoteItemManager
    {

        private readonly AnHuiSiteDAL.T_VoteItem dal = new AnHuiSiteDAL.T_VoteItem();
        public T_VoteItemManager()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(AnHuiSiteModel.T_VoteItem model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_VoteItem model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Id)
        {

            return dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AnHuiSiteModel.T_VoteItem GetModel(string Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_VoteItem> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_VoteItem> DataTableToList(DataTable dt)
        {
            List<AnHuiSiteModel.T_VoteItem> modelList = new List<AnHuiSiteModel.T_VoteItem>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AnHuiSiteModel.T_VoteItem model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AnHuiSiteModel.T_VoteItem();
                    model.Id = dt.Rows[n]["Id"].ToString();
                    model.VoteId = dt.Rows[n]["VoteId"].ToString();
                    model.Content = dt.Rows[n]["Content"].ToString();
                    if (dt.Rows[n]["Count"].ToString() != "")
                    {
                        model.Count = int.Parse(dt.Rows[n]["Count"].ToString());
                    }
                    if (dt.Rows[n]["SortIndex"].ToString() != "")
                    {
                        model.SortIndex = int.Parse(dt.Rows[n]["SortIndex"].ToString());
                    }


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        #endregion

    }
}