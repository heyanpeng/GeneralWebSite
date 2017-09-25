using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteDAL
{
    //T_AuthInfo
    public partial class T_AuthInfo
    {
        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_AuthInfo");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据角色编号和菜单编号判断是否存在权限记录
        /// </summary>
        public bool ExistsByRoleIdAndMenuId(string pRoleId, string pMenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_AuthInfo");
            strSql.Append(" where ");
            strSql.Append(" RoleId = @RoleId and");
            strSql.Append(" MenuId = @MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@pRoleId", SqlDbType.VarChar,32),
					new SqlParameter("@pMenuId", SqlDbType.VarChar,32)	
                                        };
            parameters[0].Value = pRoleId;
            parameters[1].Value = pMenuId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(AnHuiSiteModel.T_AuthInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_AuthInfo(");
            strSql.Append("Id,RoleId,MenuId,IsAdd,IsEdit,IsDelete,IsCheck,Type");
            strSql.Append(") values (");
            strSql.Append("@Id,@RoleId,@MenuId,@IsAdd,@IsEdit,@IsDelete,@IsCheck,@Type");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@RoleId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@MenuId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@IsAdd", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsEdit", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsDelete", SqlDbType.Bit,1) ,         
                        new SqlParameter("@IsCheck", SqlDbType.Bit,1) ,             
                        new SqlParameter("@Type", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.RoleId;
            parameters[2].Value = model.MenuId;
            parameters[3].Value = model.IsAdd;
            parameters[4].Value = model.IsEdit;
            parameters[5].Value = model.IsDelete;
            parameters[6].Value = model.IsCheck;
            parameters[7].Value = model.Type;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_AuthInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_AuthInfo set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" RoleId = @RoleId , ");
            strSql.Append(" MenuId = @MenuId , ");
            strSql.Append(" IsAdd = @IsAdd , ");
            strSql.Append(" IsEdit = @IsEdit , ");
            strSql.Append(" IsDelete = @IsDelete , ");
            strSql.Append(" IsCheck = @IsCheck , ");
            strSql.Append(" Type = @Type  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@RoleId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@MenuId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@IsAdd", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsEdit", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsDelete", SqlDbType.Bit,1) ,           
                        new SqlParameter("@IsCheck", SqlDbType.Bit,1) ,           
                        new SqlParameter("@Type", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.RoleId;
            parameters[2].Value = model.MenuId;
            parameters[3].Value = model.IsAdd;
            parameters[4].Value = model.IsEdit;
            parameters[5].Value = model.IsDelete;
            parameters[6].Value = model.IsCheck;
            parameters[7].Value = model.Type;
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
            strSql.Append("delete from T_AuthInfo ");
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
        public AnHuiSiteModel.T_AuthInfo GetModel(string pRoleId, string pMenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, RoleId, MenuId, IsAdd, IsEdit, IsDelete ,IsCheck , Type  ");
            strSql.Append("  from T_AuthInfo ");
            strSql.Append(" where ");
            strSql.Append(" RoleId = @RoleId and");
            strSql.Append(" MenuId = @MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.VarChar,32),
					new SqlParameter("@MenuId", SqlDbType.VarChar,32)	
                                        };
            parameters[0].Value = pRoleId;
            parameters[1].Value = pMenuId;
            AnHuiSiteModel.T_AuthInfo model = new AnHuiSiteModel.T_AuthInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return GetModelByDataSet(model, ds);
        }

        private static AnHuiSiteModel.T_AuthInfo GetModelByDataSet(AnHuiSiteModel.T_AuthInfo model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.RoleId = ds.Tables[0].Rows[0]["RoleId"].ToString();
                model.MenuId = ds.Tables[0].Rows[0]["MenuId"].ToString();
                if (ds.Tables[0].Rows[0]["IsAdd"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsAdd"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsAdd"].ToString().ToLower() == "true"))
                    {
                        model.IsAdd = true;
                    }
                    else
                    {
                        model.IsAdd = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsEdit"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsEdit"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsEdit"].ToString().ToLower() == "true"))
                    {
                        model.IsEdit = true;
                    }
                    else
                    {
                        model.IsEdit = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsDelete"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsDelete"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsDelete"].ToString().ToLower() == "true"))
                    {
                        model.IsDelete = true;
                    }
                    else
                    {
                        model.IsDelete = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsCheck"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsCheck"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsCheck"].ToString().ToLower() == "true"))
                    {
                        model.IsCheck = true;
                    }
                    else
                    {
                        model.IsCheck = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AnHuiSiteModel.T_AuthInfo GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, RoleId, MenuId, IsAdd, IsEdit, IsDelete ,IsCheck , Type  ");
            strSql.Append("  from T_AuthInfo ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)
                                        };
            parameters[0].Value = Id;


            AnHuiSiteModel.T_AuthInfo model = new AnHuiSiteModel.T_AuthInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return GetModelByDataSet(model, ds);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM T_AuthInfo ");
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
            strSql.Append(" FROM T_AuthInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

