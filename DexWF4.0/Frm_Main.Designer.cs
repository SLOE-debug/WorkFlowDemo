namespace DexWF4._0
{
    partial class Frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bar_btn_Crate = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gCtl_FlowList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCol_Title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Urgency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_CurrentInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_State = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtl_FlowList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bar_btn_Crate});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(884, 147);
            // 
            // bar_btn_Crate
            // 
            this.bar_btn_Crate.Caption = "新的工作流";
            this.bar_btn_Crate.Id = 1;
            this.bar_btn_Crate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_btn_Crate.ImageOptions.Image")));
            this.bar_btn_Crate.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_btn_Crate.ImageOptions.LargeImage")));
            this.bar_btn_Crate.Name = "bar_btn_Crate";
            this.bar_btn_Crate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_btn_Crate_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bar_btn_Crate);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // gCtl_FlowList
            // 
            this.gCtl_FlowList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtl_FlowList.Location = new System.Drawing.Point(0, 147);
            this.gCtl_FlowList.MainView = this.gridView1;
            this.gCtl_FlowList.MenuManager = this.ribbonControl1;
            this.gCtl_FlowList.Name = "gCtl_FlowList";
            this.gCtl_FlowList.Size = new System.Drawing.Size(884, 241);
            this.gCtl_FlowList.TabIndex = 5;
            this.gCtl_FlowList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCol_Title,
            this.gCol_Urgency,
            this.gCol_CurrentInfo,
            this.gCol_State});
            this.gridView1.GridControl = this.gCtl_FlowList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gCol_Title
            // 
            this.gCol_Title.Caption = "流程标题";
            this.gCol_Title.FieldName = "F_Title";
            this.gCol_Title.Name = "gCol_Title";
            this.gCol_Title.Visible = true;
            this.gCol_Title.VisibleIndex = 0;
            // 
            // gCol_Urgency
            // 
            this.gCol_Urgency.Caption = "流程紧急性";
            this.gCol_Urgency.FieldName = "F_UrgencyLeavel";
            this.gCol_Urgency.Name = "gCol_Urgency";
            this.gCol_Urgency.Visible = true;
            this.gCol_Urgency.VisibleIndex = 1;
            // 
            // gCol_CurrentInfo
            // 
            this.gCol_CurrentInfo.Caption = "流程当前信息";
            this.gCol_CurrentInfo.FieldName = "F_CurrentInfo";
            this.gCol_CurrentInfo.Name = "gCol_CurrentInfo";
            this.gCol_CurrentInfo.Visible = true;
            this.gCol_CurrentInfo.VisibleIndex = 2;
            // 
            // gCol_State
            // 
            this.gCol_State.Caption = "流程当前状态";
            this.gCol_State.FieldName = "F_State";
            this.gCol_State.Name = "gCol_State";
            this.gCol_State.Visible = true;
            this.gCol_State.VisibleIndex = 3;
            // 
            // Frm_Main
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 388);
            this.Controls.Add(this.gCtl_FlowList);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Frm_Main";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkFlow";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtl_FlowList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bar_btn_Crate;
        private DevExpress.XtraGrid.GridControl gCtl_FlowList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Title;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_CurrentInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Urgency;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_State;
    }
}

