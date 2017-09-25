using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace AnHuiSiteDAL
{
    //T_Messages
    public partial class T_Messages
    {

        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Messages");
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
        public int Add(AnHuiSiteModel.T_Messages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Messages(");
            strSql.Append("Id,T_M_Id,UserName,Email,PhoneNum,Subject,Content,CreateTime,UId,ReplyContent,ReplyTime,Visibility,IsSolve");
            strSql.Append(") values (");
            strSql.Append("@Id,@T_M_Id,@UserName,@Email,@PhoneNum,@Subject,@Content,@CreateTime,@UId,@ReplyContent,@ReplyTime,@Visibility,@IsSolve");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@T_M_Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PhoneNum", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Subject", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Content", SqlDbType.Text) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UId", SqlDbType.VarChar,32) ,     
                        new SqlParameter("@ReplyContent", SqlDbType.Text) ,            
                        new SqlParameter("@ReplyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Visibility", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsSolve", SqlDbType.Bit,1)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.T_M_Id;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.PhoneNum;
            parameters[5].Value = model.Subject;
            parameters[6].Value = model.Content;
            parameters[7].Value = model.CreateTime;
            parameters[8].Value = model.UId;
            parameters[9].Value = model.ReplyContent;
            parameters[10].Value = model.ReplyTime;
            parameters[11].Value = model.Visibility;
            parameters[12].Value = model.IsSolve;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_Messages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Messages set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" T_M_Id = @T_M_Id , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" PhoneNum = @PhoneNum , ");
            strSql.Append(" Subject = @Subject , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" UId = @UId , ");
            strSql.Append(" ReplyContent = @ReplyContent , ");
            strSql.Append(" ReplyTime = @ReplyTime , ");
            strSql.Append(" Visibility = @Visibility , ");
            strSql.Append(" IsSolve = @IsSolve  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@T_M_Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PhoneNum", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Subject", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Content", SqlDbType.Text) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@ReplyContent", SqlDbType.Text) ,            
                        new SqlParameter("@ReplyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Visibility", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsSolve", SqlDbType.Bit,1)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.T_M_Id;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.PhoneNum;
            parameters[5].Value = model.Subject;
            parameters[6].Value = model.Content;
            parameters[7].Value = model.CreateTime;
            parameters[8].Value = model.UId;
            parameters[9].Value = model.ReplyContent;
            parameters[10].Value = model.ReplyTime;
            parameters[11].Value = model.Visibility;
            parameters[12].Value = model.IsSolve;
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
            strSql.Append("delete from T_Messages ");
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
        public AnHuiSiteModel.T_Messages GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, T_M_Id, UserName, Email, PhoneNum, Subject, Content, CreateTime, UId, ReplyContent, ReplyTime, Visibility, IsSolve  ");
            strSql.Append("  from T_Messages ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;


            AnHuiSiteModel.T_Messages model = new AnHuiSiteModel.T_Messages();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.T_M_Id = ds.Tables[0].Rows[0]["T_M_Id"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.PhoneNum = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                model.Subject = ds.Tables[0].Rows[0]["Subject"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                model.UId = ds.Tables[0].Rows[0]["UId"].ToString();
                model.ReplyContent = ds.Tables[0].Rows[0]["ReplyContent"].ToString();
                if (ds.Tables[0].Rows[0]["ReplyTime"].ToString() != "")
                {
                    model.ReplyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReplyTime"].ToString());
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
                if (ds.Tables[0].Rows[0]["IsSolve"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsSolve"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsSolve"].ToString().ToLower() == "true"))
                    {
                        model.IsSolve = true;
                    }
                    else
                    {
                        model.IsSolve = false;
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
            strSql.Append(" FROM T_Messages ");
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
            strSql.Append(" FROM T_Messages ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

