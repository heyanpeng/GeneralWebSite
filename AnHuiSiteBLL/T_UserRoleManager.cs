using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteBLL
{
    //T_UserRoleManager
    public partial class T_UserRoleManager
    {

        private readonly AnHuiSiteDAL.T_UserRole dal = new AnHuiSiteDAL.T_UserRole();
        public T_UserRoleManager()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Id)
        {
            return dal.Exists(Id);
        }

        public bool Exists(string pUserId, string pRoleId)
        {
            return dal.Exists(pUserId, pRoleId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(AnHuiSiteModel.T_UserRole model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_UserRole model)
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string pUserId, string pRoleId)
        {

            return dal.Delete(pUserId, pRoleId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AnHuiSiteModel.T_UserRole GetModel(string Id)
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
        public List<AnHuiSiteModel.T_UserRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_UserRole> DataTableToList(DataTable dt)
        {
            List<AnHuiSiteModel.T_UserRole> modelList = new List<AnHuiSiteModel.T_UserRole>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AnHuiSiteModel.T_UserRole model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AnHuiSiteModel.T_UserRole();
                    model.Id = dt.Rows[n]["Id"].ToString();
                    model.UserId = dt.Rows[n]["UserId"].ToString();
                    model.RoleId = dt.Rows[n]["RoleId"].ToString();


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