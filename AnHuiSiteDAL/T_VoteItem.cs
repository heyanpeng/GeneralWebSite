using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AnHuiSiteDAL;

namespace AnHuiSiteDAL
{
    //T_VoteItem
    public partial class T_VoteItem
    {

        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_VoteItem");
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
        public void Add(AnHuiSiteModel.T_VoteItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_VoteItem(");
            strSql.Append("Id,VoteId,Content,Count,SortIndex");
            strSql.Append(") values (");
            strSql.Append("@Id,@VoteId,@Content,@Count,@SortIndex");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.VarChar,32) ,
                        new SqlParameter("@VoteId", SqlDbType.VarChar,100) ,
                        new SqlParameter("@Content", SqlDbType.VarChar,100) ,
                        new SqlParameter("@Count", SqlDbType.Int,4) ,
                        new SqlParameter("@SortIndex", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.VoteId;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Count;
            parameters[4].Value = model.SortIndex;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_VoteItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_VoteItem set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" VoteId = @VoteId , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" Count = @Count , ");
            strSql.Append(" SortIndex = @SortIndex  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.VarChar,32) ,
                        new SqlParameter("@VoteId", SqlDbType.VarChar,100) ,
                        new SqlParameter("@Content", SqlDbType.VarChar,100) ,
                        new SqlParameter("@Count", SqlDbType.Int,4) ,
                        new SqlParameter("@SortIndex", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.VoteId;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Count;
            parameters[4].Value = model.SortIndex;
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
            strSql.Append("delete from T_VoteItem ");
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
        public AnHuiSiteModel.T_VoteItem GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, VoteId, Content, Count, SortIndex  ");
            strSql.Append("  from T_VoteItem ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.VarChar,32)           };
            parameters[0].Value = Id;


            AnHuiSiteModel.T_VoteItem model = new AnHuiSiteModel.T_VoteItem();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.VoteId = ds.Tables[0].Rows[0]["VoteId"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["Count"].ToString() != "")
                {
                    model.Count = int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SortIndex"].ToString() != "")
                {
                    model.SortIndex = int.Parse(ds.Tables[0].Rows[0]["SortIndex"].ToString());
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
            strSql.Append(" FROM T_VoteItem ");
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
            strSql.Append(" FROM T_VoteItem ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

