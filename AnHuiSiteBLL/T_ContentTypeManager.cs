using System;
using System.Text;
using System.Collections.Generic;
using System.Data;


namespace AnHuiSiteBLL
{
    //T_ContentType
    public partial class T_ContentTypeManager
    {

        private readonly AnHuiSiteDAL.T_ContentType dal = new AnHuiSiteDAL.T_ContentType();
        public T_ContentTypeManager()
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
        public int Add(AnHuiSiteModel.T_ContentType model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_ContentType model)
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
        public AnHuiSiteModel.T_ContentType GetModel(string Id)
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
        public List<AnHuiSiteModel.T_ContentType> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_ContentType> DataTableToList(DataTable dt)
        {
            List<AnHuiSiteModel.T_ContentType> modelList = new List<AnHuiSiteModel.T_ContentType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AnHuiSiteModel.T_ContentType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AnHuiSiteModel.T_ContentType();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = dt.Rows[n]["Id"].ToString();
                    }
                    model.TypeName = dt.Rows[n]["TypeName"].ToString();
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
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

    }
}