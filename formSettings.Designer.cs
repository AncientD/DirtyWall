namespace Dirtywall
{
    partial class formSettings
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
            this.components = new System.ComponentModel.Container();
            this.lb_Search_Category = new System.Windows.Forms.ListBox();
            this.cms_CRUD = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nud_interval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_ok = new System.Windows.Forms.Button();
            this.cms_CRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_interval)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Search_Category
            // 
            this.lb_Search_Category.ContextMenuStrip = this.cms_CRUD;
            this.lb_Search_Category.FormattingEnabled = true;
            this.lb_Search_Category.ItemHeight = 16;
            this.lb_Search_Category.Location = new System.Drawing.Point(12, 12);
            this.lb_Search_Category.Name = "lb_Search_Category";
            this.lb_Search_Category.Size = new System.Drawing.Size(308, 308);
            this.lb_Search_Category.TabIndex = 0;
            // 
            // cms_CRUD
            // 
            this.cms_CRUD.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_CRUD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.cms_CRUD.Name = "cms_CRUD";
            this.cms_CRUD.Size = new System.Drawing.Size(139, 82);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // nud_interval
            // 
            this.nud_interval.Location = new System.Drawing.Point(83, 321);
            this.nud_interval.Name = "nud_interval";
            this.nud_interval.Size = new System.Drawing.Size(120, 22);
            this.nud_interval.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Interval";
            // 
            // BT_ok
            // 
            this.BT_ok.Location = new System.Drawing.Point(231, 358);
            this.BT_ok.Name = "BT_ok";
            this.BT_ok.Size = new System.Drawing.Size(89, 33);
            this.BT_ok.TabIndex = 7;
            this.BT_ok.Text = "Ok";
            this.BT_ok.UseVisualStyleBackColor = true;
            this.BT_ok.Click += new System.EventHandler(this.BT_ok_Click);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 402);
            this.Controls.Add(this.BT_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nud_interval);
            this.Controls.Add(this.lb_Search_Category);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "formSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.cms_CRUD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_interval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Search_Category;
        private System.Windows.Forms.NumericUpDown nud_interval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_ok;
        private System.Windows.Forms.ContextMenuStrip cms_CRUD;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}