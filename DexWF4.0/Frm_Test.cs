using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DexWF4._0
{
    public partial class Frm_Test : DexWF4._0.Frm_BaseFlow
    {
        public Frm_Test()
        {
            InitializeComponent();
        }

        public override void Completed(WorkflowApplicationCompletedEventArgs e)
        {
            base.Completed(e);
            Close();
            Dispose();
        }
    }
}
