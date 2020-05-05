using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Activities;
using System.Activities.DurableInstancing;
using DexWF4._0.WorkFlowActivity;

namespace DexWF4._0
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public partial class Frm_BaseFlow : XtraForm
    {
        public WorkflowApplication Instance { get; set; } = default;
        public Guid InstanceID { get; set; } = default;
        public Type ActivityType { get; set; } = default;
        public Frm_BaseFlow()
        {
            if (!DesignMode)
                InitializeComponent();
        }

        private void Frm_BaseFlow_LoadAsync(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Instance.Run();
                foreach (Control ctl in Controls)
                {
                    if (ctl is Button && ctl.Name.IndexOf("Resume") > 0)
                    {
                        ctl.Click += (object s, EventArgs ear) =>
                        {
                            if (txt_Guid.Text != "")
                            {
                                Instance = new WorkflowApplication((Activity)Activator.CreateInstance(ActivityType));
                                Instance.InstanceStore = WorkFlowCommon.InstanceStore;
                                var RecoverState = WorkFlowCommon.AwakenWorkFlow(ActivityType, Guid.Parse(txt_Guid.Text), txt_BookName.Text, txt_Value.Text, this);
                                if (RecoverState == RecoveryFlowState.NoSaveInstance)
                                {

                                }
                            }
                            else
                            {
                                if (InstanceID != default)
                                {
                                    Instance = new WorkflowApplication((Activity)Activator.CreateInstance(ActivityType));
                                    Instance.InstanceStore = WorkFlowCommon.InstanceStore;
                                    WorkFlowCommon.AwakenWorkFlow(ActivityType, InstanceID, txt_BookName.Text, txt_Value.Text, this);
                                }
                            }
                            if (Instance.GetBookmarks().Count(b => b.BookmarkName == txt_BookName.Text) == 1)
                            {
                                Instance.ResumeBookmark(txt_BookName.Text, txt_Value.Text);
                            }
                        };
                    }
                }
            }
        }
        public virtual void Completed(WorkflowApplicationCompletedEventArgs e)
        {
            Console.WriteLine("工作流 {0} 完成.", e.InstanceId);
            new DAL.FlowService().EndFlowByFlowID(int.Parse(e.Outputs["FlowID"].ToString()));
        }

        public virtual UnhandledExceptionAction OnUnhandledException(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            Console.WriteLine("工作流出现异常！ID：{0}\n异常信息：{1}",
            e.InstanceId,
            e.UnhandledException.Message);
            return UnhandledExceptionAction.Terminate;
        }

        public virtual void Unloaded(WorkflowApplicationEventArgs e)
        {
            Console.WriteLine("工作流 {0} 卸载.", e.InstanceId);
        }

        public virtual void Aborted(WorkflowApplicationAbortedEventArgs e)
        {
            Console.WriteLine(e.Reason.Message);
            Console.WriteLine("工作流 {0} 终止.", e.InstanceId);
        }

        public virtual void Idle(WorkflowApplicationIdleEventArgs e)
        {
            Console.WriteLine("工作流 {0} 空闲.", e.InstanceId);
        }

        public virtual PersistableIdleAction PersistableIdle(WorkflowApplicationIdleEventArgs e)
        {
            Console.WriteLine("工作流 {0} 持久化", e.InstanceId);
            InstanceID = e.InstanceId;
            return PersistableIdleAction.Unload;
        }

        ~Frm_BaseFlow()
        {
            Instance = null;
        }
    }
}