using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Maticsoft.BLL
{
    //T_AuthInfo
    public partial class T_AuthInfoManager
    {

        private readonly AnHuiSiteDAL.T_AuthInfo dal = new AnHuiSiteDAL.T_AuthInfo();
        public T_AuthInfoManager()
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
        /// 根据角色编号和菜单编号判断是否存在权限记录
        /// </summary>
        public bool ExistsByRoleIdAndMenuId(string pRoleId, string pMenuId)
        {
            return dal.ExistsByRoleIdAndMenuId(pRoleId, pMenuId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(AnHuiSiteModel.T_AuthInfo model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_AuthInfo model)
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
        public AnHuiSiteModel.T_AuthInfo GetModel(string Id)
        {
            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AnHuiSiteModel.T_AuthInfo GetModel(string pRoleId, string pMenuId)
        {
            return dal.GetModel(pRoleId, pMenuId);
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
        public List<AnHuiSiteModel.T_AuthInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_AuthInfo> DataTableToList(DataTable dt)
        {
            List<AnHuiSiteModel.T_AuthInfo> modelList = new List<AnHuiSiteModel.T_AuthInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AnHuiSiteModel.T_AuthInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AnHuiSiteModel.T_AuthInfo();
                    model.Id = dt.Rows[n]["Id"].ToString();
                    model.RoleId = dt.Rows[n]["RoleId"].ToString();
                    model.MenuId = dt.Rows[n]["MenuId"].ToString();
                    if (dt.Rows[n]["IsAdd"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsAdd"].ToString() == "1") || (dt.Rows[n]["IsAdd"].ToString().ToLower() == "true"))
                        {
                            model.IsAdd = true;
                        }
                        else
                        {
                            model.IsAdd = false;
                        }
                    }
                    if (dt.Rows[n]["IsEdit"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsEdit"].ToString() == "1") || (dt.Rows[n]["IsEdit"].ToString().ToLower() == "true"))
                        {
                            model.IsEdit = true;
                        }
                        else
                        {
                            model.IsEdit = false;
                        }
                    }
                    if (dt.Rows[n]["IsDelete"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsDelete"].ToString() == "1") || (dt.Rows[n]["IsDelete"].ToString().ToLower() == "true"))
                        {
                            model.IsDelete = true;
                        }
                        else
                        {
                            model.IsDelete = false;
                        }
                    }
                    if (dt.Rows[n]["IsCheck"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsCheck"].ToString() == "1") || (dt.Rows[n]["IsCheck"].ToString().ToLower() == "true"))
                        {
                            model.IsCheck = true;
                        }
                        else
                        {
                            model.IsCheck = false;
                        }
                    }
                    if (dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
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