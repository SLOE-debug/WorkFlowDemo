namespace DexWF4._0
{
    partial class Frm_BaseFlow
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
            this.btn_Resume = new System.Windows.Forms.Button();
            this.txt_BookName = new System.Windows.Forms.TextBox();
            this.txt_Value = new System.Windows.Forms.TextBox();
            this.txt_Guid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Resume
            // 
            this.btn_Resume.Location = new System.Drawing.Point(12, 68);
            this.btn_Resume.Name = "btn_Resume";
            this.btn_Resume.Size = new System.Drawing.Size(75, 23);
            this.btn_Resume.TabIndex = 0;
            this.btn_Resume.Text = "触发";
            this.btn_Resume.UseVisualStyleBackColor = true;
            // 
            // txt_BookName
            // 
            this.txt_BookName.Location = new System.Drawing.Point(12, 12);
            this.txt_BookName.Name = "txt_BookName";
            this.txt_BookName.Size = new System.Drawing.Size(100, 22);
            this.txt_BookName.TabIndex = 1;
            // 
            // txt_Value
            // 
            this.txt_Value.Location = new System.Drawing.Point(12, 40);
            this.txt_Value.Name = "txt_Value";
            this.txt_Value.Size = new System.Drawing.Size(100, 22);
            this.txt_Value.TabIndex = 2;
            // 
            // txt_Guid
            // 
            this.txt_Guid.Location = new System.Drawing.Point(140, 12);
            this.txt_Guid.Name = "txt_Guid";
            this.txt_Guid.Size = new System.Drawing.Size(100, 22);
            this.txt_Guid.TabIndex = 3;
            // 
            // Frm_BaseFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 176);
            this.Controls.Add(this.txt_Guid);
            this.Controls.Add(this.txt_Value);
            this.Controls.Add(this.txt_BookName);
            this.Controls.Add(this.btn_Resume);
            this.Name = "Frm_BaseFlow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新的工作流";
            this.Load += new System.EventHandler(this.Frm_BaseFlow_LoadAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_Resume;
        public System.Windows.Forms.TextBox txt_BookName;
        public System.Windows.Forms.TextBox txt_Value;
        public System.Windows.Forms.TextBox txt_Guid;
    }
}