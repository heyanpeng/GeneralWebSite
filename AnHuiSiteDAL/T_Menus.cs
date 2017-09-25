using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace AnHuiSiteDAL
{
    //T_Menus
    public partial class T_Menus
    {

        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Menus");
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
        public int Add(AnHuiSiteModel.T_Menus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Menus(");
            strSql.Append("Id,TypeId,Level,ParentId,MenuName,SortIndex,Visibility,LinkSrc,EnableLinkSrc,CreateTime,ModifyTime,IsMainNav,PicAddress");
            strSql.Append(") values (");
            strSql.Append("@Id,@TypeId,@Level,@ParentId,@MenuName,@SortIndex,@Visibility,@LinkSrc,@EnableLinkSrc,@CreateTime,@ModifyTime,@IsMainNav,@PicAddress");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@TypeId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@Level", SqlDbType.Int,4) ,            
                        new SqlParameter("@ParentId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@MenuName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SortIndex", SqlDbType.Int,4) ,            
                        new SqlParameter("@Visibility", SqlDbType.Bit,1) ,            
                        new SqlParameter("@LinkSrc", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@EnableLinkSrc", SqlDbType.Bit,1) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsMainNav", SqlDbType.Bit,1) ,            
                        new SqlParameter("@PicAddress", SqlDbType.VarChar,200)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.Level;
            parameters[3].Value = model.ParentId;
            parameters[4].Value = model.MenuName;
            parameters[5].Value = model.SortIndex;
            parameters[6].Value = model.Visibility;
            parameters[7].Value = model.LinkSrc;
            parameters[8].Value = model.EnableLinkSrc;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.ModifyTime;
            parameters[11].Value = model.IsMainNav;
            parameters[12].Value = model.PicAddress;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_Menus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Menus set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" TypeId = @TypeId , ");
            strSql.Append(" Level = @Level , ");
            strSql.Append(" ParentId = @ParentId , ");
            strSql.Append(" MenuName = @MenuName , ");
            strSql.Append(" SortIndex = @SortIndex , ");
            strSql.Append(" Visibility = @Visibility , ");
            strSql.Append(" LinkSrc = @LinkSrc , ");
            strSql.Append(" EnableLinkSrc = @EnableLinkSrc , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" ModifyTime = @ModifyTime , ");
            strSql.Append(" IsMainNav = @IsMainNav , ");
            strSql.Append(" PicAddress = @PicAddress  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@TypeId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@Level", SqlDbType.Int,4) ,            
                        new SqlParameter("@ParentId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@MenuName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SortIndex", SqlDbType.Int,4) ,            
                        new SqlParameter("@Visibility", SqlDbType.Bit,1) ,            
                        new SqlParameter("@LinkSrc", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@EnableLinkSrc", SqlDbType.Bit,1) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsMainNav", SqlDbType.Bit,1) ,            
                        new SqlParameter("@PicAddress", SqlDbType.VarChar,200)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.Level;
            parameters[3].Value = model.ParentId;
            parameters[4].Value = model.MenuName;
            parameters[5].Value = model.SortIndex;
            parameters[6].Value = model.Visibility;
            parameters[7].Value = model.LinkSrc;
            parameters[8].Value = model.EnableLinkSrc;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.ModifyTime;
            parameters[11].Value = model.IsMainNav;
            parameters[12].Value = model.PicAddress;
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
            strSql.Append("delete from T_Menus ");
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
        public AnHuiSiteModel.T_Menus GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, TypeId, Level, ParentId, MenuName, SortIndex, Visibility, LinkSrc, EnableLinkSrc, CreateTime, ModifyTime, IsMainNav, PicAddress  ");
            strSql.Append("  from T_Menus ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;


            AnHuiSiteModel.T_Menus model = new AnHuiSiteModel.T_Menus();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.TypeId = ds.Tables[0].Rows[0]["TypeId"].ToString();
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }
                model.ParentId = ds.Tables[0].Rows[0]["ParentId"].ToString();
                model.MenuName = ds.Tables[0].Rows[0]["MenuName"].ToString();
                if (ds.Tables[0].Rows[0]["SortIndex"].ToString() != "")
                {
                    model.SortIndex = int.Parse(ds.Tables[0].Rows[0]["SortIndex"].ToString());
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
                model.LinkSrc = ds.Tables[0].Rows[0]["LinkSrc"].ToString();
                if (ds.Tables[0].Rows[0]["EnableLinkSrc"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["EnableLinkSrc"].ToString() == "1") || (ds.Tables[0].Rows[0]["EnableLinkSrc"].ToString().ToLower() == "true"))
                    {
                        model.EnableLinkSrc = true;
                    }
                    else
                    {
                        model.EnableLinkSrc = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsMainNav"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsMainNav"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsMainNav"].ToString().ToLower() == "true"))
                    {
                        model.IsMainNav = true;
                    }
                    else
                    {
                        model.IsMainNav = false;
                    }
                }
                model.PicAddress = ds.Tables[0].Rows[0]["PicAddress"].ToString();

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
            strSql.Append(" FROM T_Menus ");
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
            strSql.Append(" FROM T_Menus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetDetailList()
        {
            string sql = "select t1.*,t2.TypeName from T_Menus t1 inner join T_ContentType t2 on t1.TypeId=t2.Id and t1.Level=1 order by sortindex  desc";
            return DbHelperSQL.Query(sql);
        }

        public DataSet GetListByID(string pId)
        {
            string sql = "select t1.*,t2.TypeName from T_Menus t1 inner join T_ContentType t2 on t1.TypeId=t2.Id and t1.ParentId=@PId order by sortindex desc";
            SqlParameter[] parameters = { 
                                        new SqlParameter("@PId",SqlDbType.NVarChar,32)
                                        };
            parameters[0].Value = pId;
            return DbHelperSQL.Query(sql, parameters);
        }

        public bool Update(string id, string menuName, int sortIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Menus set ");
            strSql.Append(" MenuName = @MenuName , ");
            strSql.Append(" SortIndex = @SortIndex , ");
            strSql.Append(" ModifyTime = @ModifyTime  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@SortIndex", SqlDbType.Int,4) ,            
                        new SqlParameter("@MenuName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = id;
            parameters[1].Value = sortIndex;
            parameters[2].Value = menuName;
            parameters[3].Value = DateTime.Now;

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
    }
}

