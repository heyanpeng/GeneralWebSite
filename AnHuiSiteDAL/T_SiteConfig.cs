using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteDAL
{
    //T_SiteConfig
    public partial class T_SiteConfig
    {

        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_SiteConfig");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(AnHuiSiteModel.T_SiteConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_SiteConfig(");
            strSql.Append("SiteName,Copyright,LogoUrl,SiteTitle,Meta_Keywords,Meta_Description,EnableWebSite,Version");
            strSql.Append(") values (");
            strSql.Append("@SiteName,@Copyright,@LogoUrl,@SiteTitle,@Meta_Keywords,@Meta_Description,@EnableWebSite,@Version");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@SiteName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Copyright", SqlDbType.Text) ,            
                        new SqlParameter("@LogoUrl", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SiteTitle", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Meta_Keywords", SqlDbType.Text) ,            
                        new SqlParameter("@Meta_Description", SqlDbType.Text) ,            
                        new SqlParameter("@EnableWebSite", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Version", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.SiteName;
            parameters[1].Value = model.Copyright;
            parameters[2].Value = model.LogoUrl;
            parameters[3].Value = model.SiteTitle;
            parameters[4].Value = model.Meta_Keywords;
            parameters[5].Value = model.Meta_Description;
            parameters[6].Value = model.EnableWebSite;
            parameters[7].Value = model.Version;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_SiteConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_SiteConfig set ");

            strSql.Append(" SiteName = @SiteName , ");
            strSql.Append(" Copyright = @Copyright , ");
            strSql.Append(" LogoUrl = @LogoUrl , ");
            strSql.Append(" SiteTitle = @SiteTitle , ");
            strSql.Append(" Meta_Keywords = @Meta_Keywords , ");
            strSql.Append(" Meta_Description = @Meta_Description , ");
            strSql.Append(" EnableWebSite = @EnableWebSite , ");
            strSql.Append(" Version = @Version  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@SiteName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Copyright", SqlDbType.Text) ,            
                        new SqlParameter("@LogoUrl", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SiteTitle", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Meta_Keywords", SqlDbType.Text) ,            
                        new SqlParameter("@Meta_Description", SqlDbType.Text) ,            
                        new SqlParameter("@EnableWebSite", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Version", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.SiteName;
            parameters[1].Value = model.Copyright;
            parameters[2].Value = model.LogoUrl;
            parameters[3].Value = model.SiteTitle;
            parameters[4].Value = model.Meta_Keywords;
            parameters[5].Value = model.Meta_Description;
            parameters[6].Value = model.EnableWebSite;
            parameters[7].Value = model.Version;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_SiteConfig ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AnHuiSiteModel.T_SiteConfig GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SiteName, Copyright, LogoUrl, SiteTitle, Meta_Keywords, Meta_Description, EnableWebSite, Version  ");
            strSql.Append("  from T_SiteConfig ");


            AnHuiSiteModel.T_SiteConfig model = new AnHuiSiteModel.T_SiteConfig();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SiteName = ds.Tables[0].Rows[0]["SiteName"].ToString();
                model.Copyright = ds.Tables[0].Rows[0]["Copyright"].ToString();
                model.LogoUrl = ds.Tables[0].Rows[0]["LogoUrl"].ToString();
                model.SiteTitle = ds.Tables[0].Rows[0]["SiteTitle"].ToString();
                model.Meta_Keywords = ds.Tables[0].Rows[0]["Meta_Keywords"].ToString();
                model.Meta_Description = ds.Tables[0].Rows[0]["Meta_Description"].ToString();
                if (ds.Tables[0].Rows[0]["EnableWebSite"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["EnableWebSite"].ToString() == "1") || (ds.Tables[0].Rows[0]["EnableWebSite"].ToString().ToLower() == "true"))
                    {
                        model.EnableWebSite = true;
                    }
                    else
                    {
                        model.EnableWebSite = false;
                    }
                }
                model.Version = ds.Tables[0].Rows[0]["Version"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM T_SiteConfig ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM T_SiteConfig ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

