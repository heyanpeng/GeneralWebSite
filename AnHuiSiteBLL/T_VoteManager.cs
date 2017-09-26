using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteBLL
{
    //T_Vote
    public partial class T_VoteManager
    {

        private readonly AnHuiSiteDAL.T_Vote dal = new AnHuiSiteDAL.T_Vote();
        public T_VoteManager()
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
        public void Add(AnHuiSiteModel.T_Vote model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_Vote model)
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
        public AnHuiSiteModel.T_Vote GetModel(string Id)
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
        public List<AnHuiSiteModel.T_Vote> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_Vote> DataTableToList(DataTable dt)
        {
            List<AnHuiSiteModel.T_Vote> modelList = new List<AnHuiSiteModel.T_Vote>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AnHuiSiteModel.T_Vote model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AnHuiSiteModel.T_Vote();
                    model.Id = dt.Rows[n]["Id"].ToString();
                    if (dt.Rows[n]["T_M_Id"].ToString() != "")
                    {
                        model.T_M_Id = dt.Rows[n]["T_M_Id"].ToString();
                    }
                    model.Question = dt.Rows[n]["Question"].ToString();
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["BeginDateTime"].ToString() != "")
                    {
                        model.BeginDateTime = DateTime.Parse(dt.Rows[n]["BeginDateTime"].ToString());
                    }
                    if (dt.Rows[n]["EndDateTime"].ToString() != "")
                    {
                        model.EndDateTime = DateTime.Parse(dt.Rows[n]["EndDateTime"].ToString());
                    }
                    if (dt.Rows[n]["IsMultiSelect"].ToString() != "")
                    {
                        model.IsMultiSelect = int.Parse(dt.Rows[n]["IsMultiSelect"].ToString());
                    }
                    if (dt.Rows[n]["IsPublic"].ToString() != "")
                    {
                        model.IsPublic = int.Parse(dt.Rows[n]["IsPublic"].ToString());
                    }
                    model.UId = dt.Rows[n]["UId"].ToString();
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["ModifyTime"].ToString() != "")
                    {
                        model.ModifyTime = DateTime.Parse(dt.Rows[n]["ModifyTime"].ToString());
                    }
                    if (dt.Rows[n]["IsLimitIP"].ToString() != "")
                    {
                        model.IsLimitIP = int.Parse(dt.Rows[n]["IsLimitIP"].ToString());
                    }
                    if (dt.Rows[n]["IsLimitTime"].ToString() != "")
                    {
                        model.IsLimitTime = int.Parse(dt.Rows[n]["IsLimitTime"].ToString());
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

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}