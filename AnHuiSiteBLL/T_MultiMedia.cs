using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;


namespace AnHuiSiteBLL {
	 	//T_MultiMedia
		public partial class T_MultiMediaManage
	{
   		     
		private readonly AnHuiSiteDAL.T_MultiMedia dal=new AnHuiSiteDAL.T_MultiMedia();
        public T_MultiMediaManage()
		{}

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
        public void Add(AnHuiSiteModel.T_MultiMedia model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AnHuiSiteModel.T_MultiMedia model)
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
        public AnHuiSiteModel.T_MultiMedia GetModel(string Id)
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
        public List<AnHuiSiteModel.T_MultiMedia> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnHuiSiteModel.T_MultiMedia> DataTableToList(DataTable dt)
        {
            List<AnHuiSiteModel.T_MultiMedia> modelList = new List<AnHuiSiteModel.T_MultiMedia>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AnHuiSiteModel.T_MultiMedia model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AnHuiSiteModel.T_MultiMedia();
                    model.Id = dt.Rows[n]["Id"].ToString();
                    model.NewsId = dt.Rows[n]["NewsId"].ToString();
                    model.MediaAddress = dt.Rows[n]["MediaAddress"].ToString();
                    if (dt.Rows[n]["ScanAmount"].ToString() != "")
                    {
                        model.ScanAmount = int.Parse(dt.Rows[n]["ScanAmount"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["ModifyTime"].ToString() != "")
                    {
                        model.ModifyTime = DateTime.Parse(dt.Rows[n]["ModifyTime"].ToString());
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