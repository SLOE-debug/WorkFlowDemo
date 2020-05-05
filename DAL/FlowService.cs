using MyOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FlowService
    {

        public int UpdateFlowInstanceID(int FlowID, string InstancesID)
        {
            return DBHelper.Update($"update Flow set F_FlowInstanceID = '{InstancesID}' where F_ID = {FlowID}");
        }

        public Flow GetFlowByID(int FlowID)
        {
            return DBHelper.GetEntity<Flow>($"select * from Flow where F_ID = {FlowID}");
        }
        public List<Flow> GetListByAccount(string Account)
        {
            return DBHelper.GetList<Flow>($"select * from Flow as F join FlowExecutor as Fe on Fe.Fe_F_ID = F.F_ID where Fe.Fe_U_Account = '{Account}' and F_State = 0");
        }

        public List<Flow> GetList()
        {
            return DBHelper.GetList<Flow>($"select * from Flow");
        }

        public List<Flow> GetListByCondition(string LikeName = "", DateTime? StartTime = null, DateTime? EndTime = null)
        {
            return DBHelper.GetList<Flow>($"select * from Flow where F_Title like '%{LikeName}%' {(StartTime.HasValue ? "and (Datediff(d,F_CreateTime,'" + StartTime.Value.ToString("yyyy-MM-dd") + "') = 0" : "")} {(EndTime.HasValue ? "and Datediff(d,F_EndTime,'" + EndTime.Value.ToString("yyyy-MM-dd") + "') = 0 or F_EndTime is null)" : "")}");
        }

        public List<Flow> GetListByCurrentUserID(int UserID)
        {
            return DBHelper.GetList<Flow>($"select * from Flow where F_U_ID = '{UserID}' and F_State = 0");
        }

        public int CreateFlow(Flow f)
        {
            var ID = DBHelper.GetOneVlaue<int>($"insert into Flow values('{f.F_Title}',default,{f.F_U_ID},{(f.F_State ? 1 : 0)},'{f.F_FlowInstanceID}','{f.F_CurrentInfo}','{f.F_CreateTime.ToString("yyyy-MM-dd hh:mm:ss")}',NULL);select @@identity");
            DBHelper.Update($"insert into FlowExecutor values({ID},{f.F_U_ID})");
            return ID;
        }

        public int DeleteFlowByFlowID(int FlowID)
        {
            return DBHelper.Update("delete from Flow where F_ID = " + FlowID);
        }

        public int EndFlowByFlowID(int FlowID)
        {
            return DBHelper.Update($"update Flow set F_State = 1,F_EndTime='{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}',F_CurrentInfo='流程已结束' where F_ID = {FlowID}");
        }

        public int UpdateFlowExecutor(int F_ID, params string[] F_U_ID)
        {
            int Rows;
            StringBuilder Sb = new StringBuilder();
            for (int i = 0; i < F_U_ID.Length; i++)
            {
                Sb.Append($"insert into FlowExecutor values({F_ID},'{F_U_ID[i]}');");
            }
            Rows = DBHelper.Update("delete FlowExecutor where Fe_F_ID = " + F_ID + ";" + Sb.ToString());
            return Rows;
        }

        public int UpdateFlowLog(int F_ID, string LogInfo)
        {
            return DBHelper.Update($"insert into FlowLog values({F_ID},'{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}','{LogInfo}')");
        }

        public List<string> GetFlowLog(int F_ID)
        {
            var ls = DBHelper.GetList<FlowLog>("select * from FlowLog where FL_F_ID = " + F_ID);
            List<string> res = new List<string>();
            for (int i = 0; i < ls.Count; i++)
            {
                res.Add("（" + ls[i].Fl_Date + "）==>" + ls[i].Fl_Title);
            }
            return res;
        }
    }
}
