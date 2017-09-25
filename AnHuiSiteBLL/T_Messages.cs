using System;
using System.Text;
using System.Collections.Generic;
using System.Data;


namespace AnHuiSiteBLL
{
    //T_Messages
    public partial class T_MessagesManager
    {

        private readonly AnHuiSiteDAL.T_Messages dal = new AnHuiSiteDAL.T_Messages();
        public T_MessagesManager()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(AnHuiSiteModel.T_Messages model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_Messages model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Id)
        {

            return dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AnHuiSiteModel.T_Messages GetModel(string Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_Messages> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_Messages> DataTableToList(DataTable dt)
        {
            List<AnHuiSiteModel.T_Messages> modelList = new List<AnHuiSiteModel.T_Messages>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AnHuiSiteModel.T_Messages model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AnHuiSiteModel.T_Messages();
                    model.Id = dt.Rows[n]["Id"].ToString();
                    model.T_M_Id = dt.Rows[n]["T_M_Id"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.PhoneNum = dt.Rows[n]["PhoneNum"].ToString();
                    model.Subject = dt.Rows[n]["Subject"].ToString();
                    model.Content = dt.Rows[n]["Content"].ToString();
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    model.UId = dt.Rows[n]["UId"].ToString();
                    model.ReplyContent = dt.Rows[n]["ReplyContent"].ToString();
                    if (dt.Rows[n]["ReplyTime"].ToString() != "")
                    {
                        model.ReplyTime = DateTime.Parse(dt.Rows[n]["ReplyTime"].ToString());
                    }
                    if (dt.Rows[n]["Visibility"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Visibility"].ToString() == "1") || (dt.Rows[n]["Visibility"].ToString().ToLower() == "true"))
                        {
                            model.Visibility = true;
                        }
                        else
                        {
                            model.Visibility = false;
                        }
                    }
                    if (dt.Rows[n]["IsSolve"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsSolve"].ToString() == "1") || (dt.Rows[n]["IsSolve"].ToString().ToLower() == "true"))
                        {
                            model.IsSolve = true;
                        }
                        else
                        {
                            model.IsSolve = false;
                        }
                    }


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        #endregion

    }
}