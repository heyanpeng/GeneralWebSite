using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using AnHuiSiteDAL;
namespace AnHuiSiteBLL
{
    //T_SiteConfigManager
    public partial class T_SiteConfigManager
    {

        private readonly AnHuiSiteDAL.T_SiteConfig dal = new AnHuiSiteDAL.T_SiteConfig();
        public T_SiteConfigManager()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists()
        {
            return dal.Exists();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(AnHuiSiteModel.T_SiteConfig model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_SiteConfig model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {

            return dal.Delete();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AnHuiSiteModel.T_SiteConfig GetModel()
        {

            return dal.GetModel();
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
        public List<AnHuiSiteModel.T_SiteConfig> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_SiteConfig> DataTableToList(DataTable dt)
        {
            List<AnHuiSiteModel.T_SiteConfig> modelList = new List<AnHuiSiteModel.T_SiteConfig>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AnHuiSiteModel.T_SiteConfig model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AnHuiSiteModel.T_SiteConfig();
                    model.SiteName = dt.Rows[n]["SiteName"].ToString();
                    model.Copyright = dt.Rows[n]["Copyright"].ToString();
                    model.LogoUrl = dt.Rows[n]["LogoUrl"].ToString();
                    model.SiteTitle = dt.Rows[n]["SiteTitle"].ToString();
                    model.Meta_Keywords = dt.Rows[n]["Meta_Keywords"].ToString();
                    model.Meta_Description = dt.Rows[n]["Meta_Description"].ToString();
                    if (dt.Rows[n]["EnableWebSite"].ToString() != "")
                    {
                        if ((dt.Rows[n]["EnableWebSite"].ToString() == "1") || (dt.Rows[n]["EnableWebSite"].ToString().ToLower() == "true"))
                        {
                            model.EnableWebSite = true;
                        }
                        else
                        {
                            model.EnableWebSite = false;
                        }
                    }
                    model.Version = dt.Rows[n]["Version"].ToString();


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