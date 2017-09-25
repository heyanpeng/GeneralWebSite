using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace AnHuiSiteDAL
{
    //T_StaticPage
    public partial class T_StaticPage
    {

        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_StaticPage");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(AnHuiSiteModel.T_StaticPage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_StaticPage(");
            strSql.Append("Id,T_M_Id,Content,CreateTime,ModifyTime,Visibility");
            strSql.Append(") values (");
            strSql.Append("@Id,@T_M_Id,@Content,@CreateTime,@ModifyTime,@Visibility");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@T_M_Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@Content", SqlDbType.NText,0) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Visibility", SqlDbType.Bit,1)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.T_M_Id;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.ModifyTime;
            parameters[5].Value = model.Visibility;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_StaticPage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_StaticPage set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" T_M_Id = @T_M_Id , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" ModifyTime = @ModifyTime , ");
            strSql.Append(" Visibility = @Visibility  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@T_M_Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@Content", SqlDbType.Binary,1) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Visibility", SqlDbType.Bit,1)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.T_M_Id;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.ModifyTime;
            parameters[5].Value = model.Visibility;
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
        public bool Delete(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_StaticPage ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;


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

        public bool DeleteByMenuId(string pId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_StaticPage ");
            strSql.Append(" where T_M_Id=@T_M_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@T_M_Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = pId;


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
        public AnHuiSiteModel.T_StaticPage GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, T_M_Id, Content, CreateTime, ModifyTime, Visibility  ");
            strSql.Append("  from T_StaticPage ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;


            AnHuiSiteModel.T_StaticPage model = new AnHuiSiteModel.T_StaticPage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.T_M_Id = ds.Tables[0].Rows[0]["T_M_Id"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Visibility"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Visibility"].ToString() == "1") || (ds.Tables[0].Rows[0]["Visibility"].ToString().ToLower() == "true"))
                    {
                        model.Visibility = true;
                    }
                    else
                    {
                        model.Visibility = false;
                    }
                }

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
            strSql.Append(" FROM T_StaticPage ");
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
            strSql.Append(" FROM T_StaticPage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



    }
}

