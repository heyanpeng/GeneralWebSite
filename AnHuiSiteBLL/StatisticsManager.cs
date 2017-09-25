using AnHuiSiteDAL;
using AnHuiSiteModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AnHuiSiteBLL
{
    public class StatisticsManager
    {
        public static DataTable GetStatistics()
        {
            string sql = @"select count(*)  from T_News
                            union all
                            select count(*)  from T_News where Datediff(d,CreateTime,getdate())=0
                            union all
                            select count(*) from T_News t1 where exists(
                            select Id from t_menus t2 where parentid=23 and t1.MenuId=t2.Id)
                            union all
                            select count(*) from T_News t1 where exists(
                            select Id from t_menus t2 where parentid=23 and t1.MenuId=t2.Id and Datediff(d,t1.CreateTime,getdate())=0)
                            union all
                            select count(*) from T_Messages
                            union all
                            select count(*) from T_Messages where Datediff(d,CreateTime,getdate())=0
                            union all 
                            select count(*) from T_Files
                            union all
                            select count(*) from T_Files where Datediff(d,CreateTime,getdate())=0
                            union all
                            select sum(ScanAmount) from T_News
                            union all 
                            select sum(DAmount) from T_Files";
            var dt=DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }

        public static string GetMessageStatistics()
        {
            string result = string.Empty;

            List<ChartModel> chartModels = new List<ChartModel>();

            var messageDic = new Dictionary<string, int>();
            string sql = @"select MenuName,count(*) data
                             from T_Messages t1 inner join T_Menus t2 on t1.MenuId=t2.Id
                             group by MenuName";
            var dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                int index = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    ChartModel chartModel = new ChartModel();
                    chartModel.label = dr[0].ToString();
                    chartModel.data = double.Parse(dr[1].ToString());
                    if (index < 8)
                    {
                        chartModel.color = ChartModel.colorList[index];
                    }
                    else
                    {
                        var tempIndex = index % 8;
                        chartModel.color = ChartModel.colorList[tempIndex];
                    }
                    chartModels.Add(chartModel);
                    index++;
                }
            }

            result = JsonConvert.SerializeObject(chartModels);
            return result;
        }

    }
}
