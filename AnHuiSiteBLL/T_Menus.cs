using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

using AnHuiSiteModel;
namespace AnHuiSiteBLL {
	 	//T_Menus
		public partial class T_Menus
	{
   		     
		private readonly AnHuiSiteDAL.T_Menus dal=new AnHuiSiteDAL.T_Menus();
		public T_Menus()
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
		public void  Add(AnHuiSiteModel.T_Menus model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(AnHuiSiteModel.T_Menus model)
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
		/// 得到一个对象实体
		/// </summary>
		public AnHuiSiteModel.T_Menus GetModel(int Id)
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
		public List<AnHuiSiteModel.T_Menus> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<AnHuiSiteModel.T_Menus> DataTableToList(DataTable dt)
		{
			List<AnHuiSiteModel.T_Menus> modelList = new List<AnHuiSiteModel.T_Menus>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				AnHuiSiteModel.T_Menus model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new AnHuiSiteModel.T_Menus();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["TypeId"].ToString()!="")
				{
					model.TypeId=int.Parse(dt.Rows[n]["TypeId"].ToString());
				}
																																if(dt.Rows[n]["Level"].ToString()!="")
				{
					model.Level=int.Parse(dt.Rows[n]["Level"].ToString());
				}
																																if(dt.Rows[n]["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(dt.Rows[n]["ParentId"].ToString());
				}
																																				model.MenuName= dt.Rows[n]["MenuName"].ToString();
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