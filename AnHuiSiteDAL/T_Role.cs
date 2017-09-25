using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using AnHuiSiteDAL;
namespace Maticsoft.DAL
{
    //T_Role
    public partial class T_Role
    {

        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Role");
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
        public void Add(AnHuiSiteModel.T_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Role(");
            strSql.Append("Id,ParentId,RoleName");
            strSql.Append(") values (");
            strSql.Append("@Id,@ParentId,@RoleName");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@ParentId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@RoleName", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.RoleName;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Role set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" ParentId = @ParentId , ");
            strSql.Append(" RoleName = @RoleName  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@ParentId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@RoleName", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.RoleName;
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
            strSql.Append("delete from T_Role ");
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
        public AnHuiSiteModel.T_Role GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, ParentId, RoleName  ");
            strSql.Append("  from T_Role ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;


            AnHuiSiteModel.T_Role model = new AnHuiSiteModel.T_Role();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.ParentId = ds.Tables[0].Rows[0]["ParentId"].ToString();
                model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();

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
            strSql.Append(" FROM T_Role ");
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
            strSql.Append(" FROM T_Role ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

