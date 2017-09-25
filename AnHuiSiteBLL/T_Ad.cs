﻿using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;


namespace AnHuiSiteBLL {
	 	//T_Ad
		public partial class T_Ad
	{
   		     
		private readonly AnHuiSiteDAL.T_Ad dal=new AnHuiSiteDAL.T_Ad();
		public T_Ad()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(AnHuiSiteModel.T_Ad model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(AnHuiSiteModel.T_Ad model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AnHuiSiteModel.T_Ad GetModel(int Id)
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<AnHuiSiteModel.T_Ad> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<AnHuiSiteModel.T_Ad> DataTableToList(DataTable dt)
		{
			List<AnHuiSiteModel.T_Ad> modelList = new List<AnHuiSiteModel.T_Ad>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				AnHuiSiteModel.T_Ad model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new AnHuiSiteModel.T_Ad();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["MenuId"].ToString()!="")
				{
					model.MenuId=int.Parse(dt.Rows[n]["MenuId"].ToString());
				}
																																				model.PicAddress= dt.Rows[n]["PicAddress"].ToString();
																												if(dt.Rows[n]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
				}
																																if(dt.Rows[n]["ModifyTime"].ToString()!="")
				{
					model.ModifyTime=DateTime.Parse(dt.Rows[n]["ModifyTime"].ToString());
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