using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace AnHuiSiteDAL
{
    //T_News
    public partial class T_News
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_News");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(AnHuiSiteModel.T_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_News(");
            strSql.Append("Id,T_M_Id,PicAddress,Title,Content,ScanAmount,IsTop,IsHot,IsNew,Source,IsCheck,UId,CreateTime,ModifyTime");
            strSql.Append(") values (");
            strSql.Append("@Id,@T_M_Id,@PicAddress,@Title,@Content,@ScanAmount,@IsTop,@IsHot,@IsNew,@Source,@IsCheck,@UId,@CreateTime,@ModifyTime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@T_M_Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@PicAddress", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Title", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Content", SqlDbType.NText,0) ,            
                        new SqlParameter("@ScanAmount", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsTop", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsHot", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsNew", SqlDbType.Int,4) ,            
                        new SqlParameter("@Source", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@IsCheck", SqlDbType.Int,4) ,            
                        new SqlParameter("@UId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.T_M_Id;
            parameters[2].Value = model.PicAddress;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.ScanAmount;
            parameters[6].Value = model.IsTop;
            parameters[7].Value = model.IsHot;
            parameters[8].Value = model.IsNew;
            parameters[9].Value = model.Source;
            parameters[10].Value = model.IsCheck;
            parameters[11].Value = model.UId;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.ModifyTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_News set ");
            strSql.Append(" T_M_Id = @T_M_Id , ");
            strSql.Append(" Title = @Title , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" ScanAmount = @ScanAmount , ");
            strSql.Append(" IsTop = @IsTop , ");
            strSql.Append(" IsHot = @IsHot , ");
            strSql.Append(" IsNew = @IsNew , ");
            strSql.Append(" IsCheck = @IsCheck , ");
            strSql.Append(" Source = @Source , ");
            strSql.Append(" ModifyTime = @ModifyTime");
            if (!string.IsNullOrEmpty(model.PicAddress))
            {
                strSql.Append(", PicAddress = @PicAddress ");
            }
            strSql.Append(" where Id=@Id ");

            List<SqlParameter> parameters = new List<SqlParameter>() {
			           new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@T_M_Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@Title", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Content", SqlDbType.NText,0) ,            
                        new SqlParameter("@ScanAmount", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsTop", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsHot", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsNew", SqlDbType.Int,4) ,            
                        new SqlParameter("@Source", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@IsCheck", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.T_M_Id;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.ScanAmount;
            parameters[5].Value = model.IsTop;
            parameters[6].Value = model.IsHot;
            parameters[7].Value = model.IsNew;
            parameters[8].Value = model.Source;
            parameters[9].Value = model.IsCheck;
            parameters[10].Value = model.ModifyTime;

            if (!string.IsNullOrEmpty(model.PicAddress))
            {
                parameters.Add(new SqlParameter("@PicAddress", SqlDbType.NVarChar, 200));
                parameters[11].Value = model.PicAddress;
            }
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters.ToArray());
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
            strSql.Append("delete from T_News ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)
			};
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_News ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public AnHuiSiteModel.T_News GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, T_M_Id, PicAddress, Title, Content, ScanAmount, IsTop, IsHot, IsNew, Source, IsCheck, UId, CreateTime, ModifyTime  ");
            strSql.Append("  from T_News ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;


            AnHuiSiteModel.T_News model = new AnHuiSiteModel.T_News();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.T_M_Id = ds.Tables[0].Rows[0]["T_M_Id"].ToString();
                model.PicAddress = ds.Tables[0].Rows[0]["PicAddress"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["ScanAmount"].ToString() != "")
                {
                    model.ScanAmount = int.Parse(ds.Tables[0].Rows[0]["ScanAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsHot"].ToString() != "")
                {
                    model.IsHot = int.Parse(ds.Tables[0].Rows[0]["IsHot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsNew"].ToString() != "")
                {
                    model.IsNew = int.Parse(ds.Tables[0].Rows[0]["IsNew"].ToString());
                }
                model.Source = ds.Tables[0].Rows[0]["Source"].ToString();
                if (ds.Tables[0].Rows[0]["IsCheck"].ToString() != "")
                {
                    model.IsCheck = int.Parse(ds.Tables[0].Rows[0]["IsCheck"].ToString());
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
            strSql.Append(" FROM T_News ");
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
            strSql.Append(" FROM T_News ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        public void UpdateScanAmount(string id)
        {
            string strSql = "update T_News set ScanAmount = ScanAmount + 1 where Id = '" + id + "'";
            DbHelperSQL.ExecuteSql(strSql.ToString());
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
            strSql.Append(")AS Row, T.*  from T_News T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql.Append(" WHERE " + strWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

