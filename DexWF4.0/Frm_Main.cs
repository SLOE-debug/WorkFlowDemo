using DexWF4._0.WorkFlowActivity;
using MyOA.Model;
using System;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DexWF4._0
{
    public partial class Frm_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void bar_btn_Crate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FlowID = new DAL.FlowService().CreateFlow(new Flow() { F_Title = "新的工作流", F_U_ID = 1, F_State = false, F_FlowInstanceID = default(Guid).ToString(), F_CurrentInfo = "流程已创建", F_CreateTime = DateTime.Now });
            WorkFlowCommon.CreateWorkFlow<BaseActivity, Frm_Test>(new Dictionary<string, object> { { "FlowID", FlowID }, { "BookMarks", new int[] { 1, 2 } } }, WorkFlowCommon.InstanceStore);
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            WorkFlowCommon.gCtl = gCtl_FlowList;
            WorkFlowCommon.gCtl.DataSource = new DAL.FlowService().GetList();
        }
    }
}
