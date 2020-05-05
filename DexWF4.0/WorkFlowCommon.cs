using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.DurableInstancing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using DevExpress.XtraGrid;

namespace DexWF4._0
{
    public enum RecoveryFlowState
    {
        Done,
        NoSaveInstance,
        OthersInUse
    }

    public static class WorkFlowCommon
    {
        public static GridControl gCtl { get; set; }

        private static SqlWorkflowInstanceStore _instanceStore;
        public static SqlWorkflowInstanceStore InstanceStore
        {
            get
            {
                if (_instanceStore == null)
                {
                    _instanceStore = new SqlWorkflowInstanceStore(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
                    InstanceView instanceView = _instanceStore.Execute(_instanceStore.CreateInstanceHandle(), new CreateWorkflowOwnerCommand(), TimeSpan.FromSeconds(30));
                    _instanceStore.DefaultInstanceOwner = instanceView.InstanceOwner;
                }
                return _instanceStore;
            }
        }

        /// <summary>
        /// 创建新的工作流窗口
        /// </summary>
        /// <typeparam name="T">工作流类型</typeparam>
        /// <typeparam name="K">挂载窗体类型</typeparam>
        /// <param name="dir">工作流参数</param>
        /// <param name="StoreSource">持久化数据库</param>
        public static void CreateWorkFlow<T, K>(Dictionary<string, object> dir = null, SqlWorkflowInstanceStore StoreSource = null) where T : Activity, new() where K : Frm_BaseFlow, new()
        {
            var Frm = new K() { ActivityType = typeof(T) };
            var inputs = new Dictionary<string, object>() { };
            if (dir != null)
                inputs = new Func<Dictionary<string, object>>(() =>
                {
                    List<KeyValuePair<string, object>> inputls = inputs.ToList();
                    inputls.AddRange(dir);
                    return inputls.ToDictionary(key => key.Key, value => value.Value);
                })();

            Frm.Instance = new WorkflowApplication(new T(), inputs);
            BindLifeCycle(Frm, Frm.Instance, StoreSource);
            gCtl.DataSource = new DAL.FlowService().GetList();
        }

        /// <summary>
        /// 绑定工作流生命周期
        /// </summary>
        /// <param name="Frm">工作流挂载窗体</param>
        /// <param name="Instance">工作流实例</param>
        /// <param name="StoreSource">持久化数据库</param>
        public static void BindLifeCycle(Frm_BaseFlow Frm, WorkflowApplication Instance, SqlWorkflowInstanceStore StoreSource = null)
        {
            if (StoreSource != null) Frm.Instance.InstanceStore = StoreSource;
            Instance.Completed = Frm.Completed;
            Instance.OnUnhandledException = Frm.OnUnhandledException;
            Instance.Unloaded = Frm.Unloaded;
            Instance.Aborted = Frm.Aborted;
            Instance.Idle = Frm.Idle;
            Instance.PersistableIdle = Frm.PersistableIdle;
            Frm.Show();
        }

        /// <summary>
        /// (从数据库中)恢复工作流
        /// </summary>
        /// <param name="ActivityType">工作流类型</param>
        /// <param name="WorkFlowID">要恢复的工作流ID</param>
        /// <param name="BookName">恢复的书签节点</param>
        /// <param name="Value">传入的值</param>
        public static RecoveryFlowState AwakenWorkFlow(Type ActivityType, Guid WorkFlowID, string BookName, object Value, Frm_BaseFlow Frm)
        {
            WorkflowApplication Instance = new WorkflowApplication((Activity)Activator.CreateInstance(ActivityType));
            Instance.InstanceStore = new SqlWorkflowInstanceStore("Data Source=.;Initial Catalog=MyOA;Integrated Security=True");
            BindLifeCycle(Frm, Instance);
            try
            {
                Instance.Load(WorkFlowID);
                Instance.ResumeBookmark(BookName, Value);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("尚未保留到实例存储区") > 0)
                {
                    return RecoveryFlowState.NoSaveInstance;
                }
                if (ex.Message.IndexOf("其他实例所有者锁定了实例") > 0)
                {
                    return RecoveryFlowState.OthersInUse;
                }
            }
            return RecoveryFlowState.Done;
        }
    }
}
