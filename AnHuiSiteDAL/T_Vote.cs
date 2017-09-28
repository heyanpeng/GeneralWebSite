using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using AnHuiSiteDAL;

namespace AnHuiSiteDAL
{
    //T_Vote
    public partial class T_Vote
    {

        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Vote");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.VarChar,32)           };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(AnHuiSiteModel.T_Vote model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Vote(");
            strSql.Append("Id,T_M_Id,Question,Status,BeginDateTime,EndDateTime,IsMultiSelect,IsPublic,UId,CreateTime,ModifyTime,IsLimitIP,IsLimitTime");
            strSql.Append(") values (");
            strSql.Append("@Id,@T_M_Id,@Question,@Status,@BeginDateTime,@EndDateTime,@IsMultiSelect,@IsPublic,@UId,@CreateTime,@ModifyTime,@IsLimitIP,@IsLimitTime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.VarChar,32) ,    
                        new SqlParameter("@T_M_Id", SqlDbType.VarChar,32) ,    
                        new SqlParameter("@Question", SqlDbType.VarChar,100) ,
                        new SqlParameter("@Status", SqlDbType.Int,4) ,
                        new SqlParameter("@BeginDateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@EndDateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@IsMultiSelect", SqlDbType.Int,4) ,
                        new SqlParameter("@IsPublic", SqlDbType.Int,4) ,
                        new SqlParameter("@UId", SqlDbType.VarChar,32) ,
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime) ,
                        new SqlParameter("@IsLimitIP", SqlDbType.Int,4) ,
                        new SqlParameter("@IsLimitTime", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.T_M_Id;
            parameters[2].Value = model.Question;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.BeginDateTime;
            parameters[5].Value = model.EndDateTime;
            parameters[6].Value = model.IsMultiSelect;
            parameters[7].Value = model.IsPublic;
            parameters[8].Value = model.UId;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.ModifyTime;
            parameters[11].Value = model.IsLimitIP;
            parameters[12].Value = model.IsLimitTime;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_Vote model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Vote set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" T_M_Id = @T_M_Id , ");
            strSql.Append(" Question = @Question , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" BeginDateTime = @BeginDateTime , ");
            strSql.Append(" EndDateTime = @EndDateTime , ");
            strSql.Append(" IsMultiSelect = @IsMultiSelect , ");
            strSql.Append(" IsPublic = @IsPublic , ");
            strSql.Append(" UId = @UId , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" ModifyTime = @ModifyTime , ");
            strSql.Append(" IsLimitIP = @IsLimitIP , ");
            strSql.Append(" IsLimitTime = @IsLimitTime  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.VarChar,32) ,  
                        new SqlParameter("@T_M_Id", SqlDbType.VarChar,32) ,     
                        new SqlParameter("@Question", SqlDbType.VarChar,100) ,
                        new SqlParameter("@Status", SqlDbType.Int,4) ,
                        new SqlParameter("@BeginDateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@EndDateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@IsMultiSelect", SqlDbType.Int,4) ,
                        new SqlParameter("@IsPublic", SqlDbType.Int,4) ,
                        new SqlParameter("@UId", SqlDbType.VarChar,32) ,
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime) ,
                        new SqlParameter("@IsLimitIP", SqlDbType.Int,4) ,
                        new SqlParameter("@IsLimitTime", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.T_M_Id;
            parameters[2].Value = model.Question;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.BeginDateTime;
            parameters[5].Value = model.EndDateTime;
            parameters[6].Value = model.IsMultiSelect;
            parameters[7].Value = model.IsPublic;
            parameters[8].Value = model.UId;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.ModifyTime;
            parameters[11].Value = model.IsLimitIP;
            parameters[12].Value = model.IsLimitTime;
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
            strSql.Append("delete from T_Vote ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.VarChar,32)           };
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
        public AnHuiSiteModel.T_Vote GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,T_M_Id, Question, Status, BeginDateTime, EndDateTime, IsMultiSelect, IsPublic, UId, CreateTime, ModifyTime, IsLimitIP, IsLimitTime  ");
            strSql.Append("  from T_Vote ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.VarChar,32)           };
            parameters[0].Value = Id;


            AnHuiSiteModel.T_Vote model = new AnHuiSiteModel.T_Vote();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.T_M_Id = ds.Tables[0].Rows[0]["T_M_Id"].ToString();
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BeginDateTime"].ToString() != "")
                {
                    model.BeginDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndDateTime"].ToString() != "")
                {
                    model.EndDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsMultiSelect"].ToString() != "")
                {
                    model.IsMultiSelect = int.Parse(ds.Tables[0].Rows[0]["IsMultiSelect"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsPublic"].ToString() != "")
                {
                    model.IsPublic = int.Parse(ds.Tables[0].Rows[0]["IsPublic"].ToString());
                }
                model.UId = ds.Tables[0].Rows[0]["UId"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLimitIP"].ToString() != "")
                {
                    model.IsLimitIP = int.Parse(ds.Tables[0].Rows[0]["IsLimitIP"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLimitTime"].ToString() != "")
                {
                    model.IsLimitTime = int.Parse(ds.Tables[0].Rows[0]["IsLimitTime"].ToString());
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
            strSql.Append(" FROM T_Vote ");
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
            strSql.Append(" FROM T_Vote ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
                strSql.Append("order by T." + orderby);
            else
                strSql.Append("order by T.CreateTime ASC");
            strSql.Append(")AS Row, T.*  from T_Vote T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql.Append(" WHERE " + strWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

