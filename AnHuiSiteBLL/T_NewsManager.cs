using System;
using System.Text;
using System.Collections.Generic;
using System.Data;


namespace AnHuiSiteBLL
{
    //T_News
    public partial class T_NewsManager
    {

        private readonly AnHuiSiteDAL.T_News dal = new AnHuiSiteDAL.T_News();
        public T_NewsManager()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(AnHuiSiteModel.T_News model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_News model)
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AnHuiSiteModel.T_News GetModel(string Id)
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
        public List<AnHuiSiteModel.T_News> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_News> GetModelList(int top, string strWhere, string filedOrder)
        {
            DataSet ds = dal.GetList(top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_News> DataTableToList(DataTable dt)
        {
            List<AnHuiSiteModel.T_News> modelList = new List<AnHuiSiteModel.T_News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AnHuiSiteModel.T_News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AnHuiSiteModel.T_News();
                        model.Id = dt.Rows[n]["Id"].ToString().ToString();
                    if (dt.Rows[n]["T_M_Id"].ToString() != "")
                    {
                        model.T_M_Id = dt.Rows[n]["T_M_Id"].ToString();
                    }
                    model.PicAddress = dt.Rows[n]["PicAddress"].ToString();
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.Content = dt.Rows[n]["Content"].ToString();
                    if (dt.Rows[n]["ScanAmount"].ToString() != "")
                    {
                        model.ScanAmount = int.Parse(dt.Rows[n]["ScanAmount"].ToString());
                    }
                    if (dt.Rows[n]["IsTop"].ToString() != "")
                    {
                        model.IsTop = int.Parse(dt.Rows[n]["IsTop"].ToString());
                    }
                    if (dt.Rows[n]["IsHot"].ToString() != "")
                    {
                        model.IsHot = int.Parse(dt.Rows[n]["IsHot"].ToString());
                    }
                    if (dt.Rows[n]["IsNew"].ToString() != "")
                    {
                        model.IsNew = int.Parse(dt.Rows[n]["IsNew"].ToString());
                    }
                    if (dt.Rows[n]["IsCheck"].ToString() != "")
                    {
                        model.IsCheck = int.Parse(dt.Rows[n]["IsCheck"].ToString());
                    }
                    model.UId = dt.Rows[n]["UId"].ToString();
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["Source"].ToString() != "")
                    {
                        model.Source = dt.Rows[n]["Source"].ToString();
                    }
                    if (dt.Rows[n]["ModifyTime"].ToString() != "")
                    {
                        model.ModifyTime = DateTime.Parse(dt.Rows[n]["ModifyTime"].ToString());
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

        public void UpdateScanAmount(string id)
        {
            dal.UpdateScanAmount(id);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}