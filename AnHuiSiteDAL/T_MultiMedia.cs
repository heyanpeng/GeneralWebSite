using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;

namespace AnHuiSiteDAL  
{
	 	//T_MultiMedia
		public partial class T_MultiMedia
	{

        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_MultiMedia");
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
        public void Add(AnHuiSiteModel.T_MultiMedia model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_MultiMedia(");
            strSql.Append("Id,NewsId,MediaAddress,ScanAmount,CreateTime,ModifyTime,Visibility");
            strSql.Append(") values (");
            strSql.Append("@Id,@NewsId,@MediaAddress,@ScanAmount,@CreateTime,@ModifyTime,@Visibility");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@NewsId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@MediaAddress", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ScanAmount", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Visibility", SqlDbType.Bit,1)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.NewsId;
            parameters[2].Value = model.MediaAddress;
            parameters[3].Value = model.ScanAmount;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.ModifyTime;
            parameters[6].Value = model.Visibility;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_MultiMedia model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_MultiMedia set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" NewsId = @NewsId , ");
            strSql.Append(" MediaAddress = @MediaAddress , ");
            strSql.Append(" ScanAmount = @ScanAmount , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" ModifyTime = @ModifyTime , ");
            strSql.Append(" Visibility = @Visibility  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@NewsId", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@MediaAddress", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ScanAmount", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Visibility", SqlDbType.Bit,1)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.NewsId;
            parameters[2].Value = model.MediaAddress;
            parameters[3].Value = model.ScanAmount;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.ModifyTime;
            parameters[6].Value = model.Visibility;
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
            strSql.Append("delete from T_MultiMedia ");
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
        public AnHuiSiteModel.T_MultiMedia GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, NewsId, MediaAddress, ScanAmount, CreateTime, ModifyTime, Visibility  ");
            strSql.Append("  from T_MultiMedia ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,32)			};
            parameters[0].Value = Id;


            AnHuiSiteModel.T_MultiMedia model = new AnHuiSiteModel.T_MultiMedia();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.NewsId = ds.Tables[0].Rows[0]["NewsId"].ToString();
                model.MediaAddress = ds.Tables[0].Rows[0]["MediaAddress"].ToString();
                if (ds.Tables[0].Rows[0]["ScanAmount"].ToString() != "")
                {
                    model.ScanAmount = int.Parse(ds.Tables[0].Rows[0]["ScanAmount"].ToString());
                }
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
            strSql.Append(" FROM T_MultiMedia ");
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
            strSql.Append(" FROM T_MultiMedia ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


   
	}
}

