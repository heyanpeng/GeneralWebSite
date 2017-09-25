using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using AnHuiSiteDAL;
namespace AnHuiSiteDAL
{
    //T_UserRole
    public partial class T_UserRole
    {

        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_UserRole");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(string pUserId, string pRoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_UserRole");
            strSql.Append(" where ");
            strSql.Append(" UserId = @UserId and");
            strSql.Append(" RoleId = @RoleId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,32),
                                        new SqlParameter("@RoleId", SqlDbType.VarChar,32)};
            parameters[0].Value = pUserId;
            parameters[1].Value = pRoleId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(AnHuiSiteModel.T_UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_UserRole(");
            strSql.Append("Id,UserId,RoleId");
            strSql.Append(") values (");
            strSql.Append("@Id,@UserId,@RoleId");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@UserId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@RoleId", SqlDbType.VarChar,32)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.RoleId;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_UserRole set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" RoleId = @RoleId  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@UserId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@RoleId", SqlDbType.VarChar,32)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.RoleId;
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
            strSql.Append("delete from T_UserRole ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string pUserId, string pRoleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_UserRole ");
            strSql.Append(" where ");
            strSql.Append(" UserId = @UserId and");
            strSql.Append(" RoleId = @RoleId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,32),
                                        new SqlParameter("@RoleId", SqlDbType.VarChar,32)};
            parameters[0].Value = pUserId;
            parameters[1].Value = pRoleId;

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
        public AnHuiSiteModel.T_UserRole GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, UserId, RoleId  ");
            strSql.Append("  from T_UserRole ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;


            AnHuiSiteModel.T_UserRole model = new AnHuiSiteModel.T_UserRole();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                model.RoleId = ds.Tables[0].Rows[0]["RoleId"].ToString();

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
            strSql.Append(" FROM T_UserRole ");
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
            strSql.Append(" FROM T_UserRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

