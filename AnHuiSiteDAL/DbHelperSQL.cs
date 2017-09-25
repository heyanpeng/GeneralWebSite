using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AnHuiSiteDAL
{
    public static class DbHelperSQL
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #region 执行SQL语句
        /// <summary>
        /// 执行SQL语句，返回DataSet
        /// 用法：DataSet ds = DbHelperSQL.Query("select * from TableName");
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>DataTable</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// 用法：
        /// SqlParameter[] para = new SqlParameter[] { 
        ///     DbHelperSQL.MakeParam("@Param1Name",SqlDbType.VarChar,ParameterDirection.Input,500,"Param1Value"),
        ///     DbHelperSQL.MakeParam("@Param2Name",SqlDbType.Int,ParameterDirection.Output,4,"Param2Value"),
        ///     DbHelperSQL.MakeParam("@Param3Name",SqlDbType.DateTime,ParameterDirection.Input,0,Param3Value),
        /// };
        /// DataSet ds = DbHelperSQL.Query("select * from TableName",para);
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="SQLString">SqlParameter[]参数</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// 用法：
        /// int result = DbHelperSQL.ExecuteSql("select * from TableName",para);
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// 用法：
        /// SqlParameter[] para = new SqlParameter[] { 
        ///     DbHelperSQL.MakeParam("@Param1Name",SqlDbType.VarChar,ParameterDirection.Input,500,"Param1Value"),
        ///     DbHelperSQL.MakeParam("@Param2Name",SqlDbType.Int,ParameterDirection.Output,4,"Param2Value"),
        ///     DbHelperSQL.MakeParam("@Param3Name",SqlDbType.DateTime,ParameterDirection.Input,0,Param3Value),
        /// };
        /// int result = DbHelperSQL.ExecuteSql("select * from TableName",para);
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="SQLString">SqlParameter[]参数</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// 用法：
        /// SqlParameter[] para = new SqlParameter[] { 
        ///     DbHelperSQL.MakeParam("@Param1Name",SqlDbType.VarChar,ParameterDirection.Input,500,"Param1Value"),
        ///     DbHelperSQL.MakeParam("@Param2Name",SqlDbType.Int,ParameterDirection.Output,4,"Param2Value"),
        ///     DbHelperSQL.MakeParam("@Param3Name",SqlDbType.DateTime,ParameterDirection.Input,0,Param3Value),
        /// };
        /// object result = DbHelperSQL.GetSingle("select * from TableName",para);
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                            return null;
                        else
                            return obj;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = DbHelperSQL.GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                cmdresult = 0;
            else
                cmdresult = int.Parse(obj.ToString());
            if (cmdresult == 0)
                return false;
            else
                return true;
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                        parameter.Value = DBNull.Value;
                    cmd.Parameters.Add(parameter);
                }
        }
        #endregion


        #region 执行存储过程
        /// <summary>
        /// 产生SqlParameter参数
        /// </summary>
        /// <param name="ParamName">参数名称</param>
        /// <param name="DbType">数据类型</param>
        /// <param name="Direction">参数类型</param>
        /// <param name="Size">数据大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>SqlParameter</returns>
        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, ParameterDirection Direction, Int32 Size, object Value)
        {
            SqlParameter param;
            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;
            return param;
        }
        /// <summary>
        /// 执行存储过程
        /// 用法：
        /// SqlParameter[] para = new SqlParameter[] { 
        ///     DbHelperSQL.MakeParam("@Param1Name",SqlDbType.VarChar,ParameterDirection.Input,500,"Param1Value"),
        ///     DbHelperSQL.MakeParam("@Param2Name",SqlDbType.Int,ParameterDirection.Output,4,"Param2Value"),
        ///     DbHelperSQL.MakeParam("@Param3Name",SqlDbType.DateTime,ParameterDirection.Input,0,Param3Value),
        /// };
        /// DataTable dt = DbHelperSQL.RunProcedure("storedProcName",para);
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(ds);
                connection.Close();
                return ds;
            }
        }
        /// <summary>
        /// 执行存储过程
        /// 用法：
        /// SqlParameter[] para = new SqlParameter[] { 
        ///     DbHelperSQL.MakeParam("@Param1Name",SqlDbType.VarChar,ParameterDirection.Input,500,"Param1Value"),
        ///     DbHelperSQL.MakeParam("@Param2Name",SqlDbType.Int,ParameterDirection.Output,4,"Param2Value"),
        ///     DbHelperSQL.MakeParam("@Param3Name",SqlDbType.DateTime,ParameterDirection.Input,0,Param3Value),
        /// };
        /// DataTable dt = DbHelperSQL.RunProcedure("storedProcName",para,60);
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="Times">超时时长</param>
        /// <returns>DataTable</returns>
        public static DataTable RunProcedure(string storedProcName, IDataParameter[] parameters, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dt);
                connection.Close();
                return dt;
            }
        }
        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                        parameter.Value = DBNull.Value;
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }
        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedureGetSingle(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                result = command.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }
        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                connection.Close();
                return result;
            }
        }
        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion
    }
}
