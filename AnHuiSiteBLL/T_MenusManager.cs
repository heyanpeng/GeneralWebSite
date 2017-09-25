using System;
using System.Text;
using System.Collections.Generic;
using System.Data;


namespace AnHuiSiteBLL
{
    //T_Menus
    public partial class T_MenusManager
    {

        private readonly AnHuiSiteDAL.T_Menus dal = new AnHuiSiteDAL.T_Menus();
        public T_MenusManager()
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
        public int Add(AnHuiSiteModel.T_Menus model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_Menus model)
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
        public AnHuiSiteModel.T_Menus GetModel(string Id)
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByID(string strWhere)
        {
            return dal.GetListByID(strWhere);
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
        public List<AnHuiSiteModel.T_Menus> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_Menus> DataTableToList(DataTable dt)
        {
            List<AnHuiSiteModel.T_Menus> modelList = new List<AnHuiSiteModel.T_Menus>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AnHuiSiteModel.T_Menus model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AnHuiSiteModel.T_Menus();
                    model.Id = dt.Rows[n]["Id"].ToString();
                    model.TypeId = dt.Rows[n]["TypeId"].ToString();
                    if (dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                    }
                    model.ParentId = dt.Rows[n]["ParentId"].ToString();
                    model.MenuName = dt.Rows[n]["MenuName"].ToString();
                    if (dt.Rows[n]["SortIndex"].ToString() != "")
                    {
                        model.SortIndex = int.Parse(dt.Rows[n]["SortIndex"].ToString());
                    }
                    if (dt.Rows[n]["Visibility"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Visibility"].ToString() == "1") || (dt.Rows[n]["Visibility"].ToString().ToLower() == "true"))
                        {
                            model.Visibility = true;
                        }
                        else
                        {
                            model.Visibility = false;
                        }
                    }
                    model.LinkSrc = dt.Rows[n]["LinkSrc"].ToString();
                    if (dt.Rows[n]["EnableLinkSrc"].ToString() != "")
                    {
                        if ((dt.Rows[n]["EnableLinkSrc"].ToString() == "1") || (dt.Rows[n]["EnableLinkSrc"].ToString().ToLower() == "true"))
                        {
                            model.EnableLinkSrc = true;
                        }
                        else
                        {
                            model.EnableLinkSrc = false;
                        }
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["ModifyTime"].ToString() != "")
                    {
                        model.ModifyTime = DateTime.Parse(dt.Rows[n]["ModifyTime"].ToString());
                    }
                    if (dt.Rows[n]["IsMainNav"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsMainNav"].ToString() == "1") || (dt.Rows[n]["IsMainNav"].ToString().ToLower() == "true"))
                        {
                            model.IsMainNav = true;
                        }
                        else
                        {
                            model.IsMainNav = false;
                        }
                    }
                    model.PicAddress = dt.Rows[n]["PicAddress"].ToString();


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
            return GetList(string.Empty);
        }

        public DataSet GetDetailList()
        {
            return dal.GetDetailList();
        }

        public bool Update(string id, string menuName, int sortIndex)
        {
            return dal.Update(id, menuName, sortIndex);
        }

        #endregion


    }
}