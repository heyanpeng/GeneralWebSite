using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace AnHuiSiteDAL
{
    //T_User
    public partial class T_User
    {
        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_User");
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
        public int Add(AnHuiSiteModel.T_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_User(");
            strSql.Append("Id,UserName,UserPwd,DisplayName,CreateTime,ModifyTime");
            strSql.Append(") values (");
            strSql.Append("@Id,@UserName,@UserPwd,@DisplayName,@CreateTime,@ModifyTime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserPwd", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@DisplayName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserPwd;
            parameters[3].Value = model.DisplayName;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.ModifyTime;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_User set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" UserPwd = @UserPwd , ");
            strSql.Append(" DisplayName = @DisplayName , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" ModifyTime = @ModifyTime  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserPwd", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@DisplayName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserPwd;
            parameters[3].Value = model.DisplayName;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.ModifyTime;
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
            strSql.Append("delete from T_User ");
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



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AnHuiSiteModel.T_User GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, UserName, UserPwd, DisplayName, CreateTime, ModifyTime  ");
            strSql.Append("  from T_User ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;


            AnHuiSiteModel.T_User model = new AnHuiSiteModel.T_User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserPwd = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                model.DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyTime"].ToString());
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
            strSql.Append(" FROM T_User ");
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
            strSql.Append(" FROM T_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据详情列表
        /// </summary>
        public DataSet GetDetailList()
        {
            string strSql = "select t1.*,t2.MenuName from t_user t1 left join t_menus t2 on t1.district=t2.id";
            return DbHelperSQL.Query(strSql);
        }
    }
}

