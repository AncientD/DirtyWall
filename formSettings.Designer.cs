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
            this.lb_Search_Category = new System.Windows.Forms.ListBox();
            this.tb_category = new System.Windows.Forms.TextBox();
            this.BT_Add_category = new System.Windows.Forms.Button();
            this.BT_remove = new System.Windows.Forms.Button();
            this.nud_interval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_interval)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Search_Category
            // 
            this.lb_Search_Category.FormattingEnabled = true;
            this.lb_Search_Category.ItemHeight = 16;
            this.lb_Search_Category.Items.AddRange(new object[] {
            "jtdyjd",
            "yjd",
            "tyj",
            "dty",
            "jd",
            "tyjdt",
            "yj"});
            this.lb_Search_Category.Location = new System.Drawing.Point(12, 12);
            this.lb_Search_Category.Name = "lb_Search_Category";
            this.lb_Search_Category.Size = new System.Drawing.Size(308, 308);
            this.lb_Search_Category.TabIndex = 0;
            // 
            // tb_category
            // 
            this.tb_category.Location = new System.Drawing.Point(15, 327);
            this.tb_category.Name = "tb_category";
            this.tb_category.Size = new System.Drawing.Size(116, 22);
            this.tb_category.TabIndex = 2;
            // 
            // BT_Add_category
            // 
            this.BT_Add_category.Location = new System.Drawing.Point(164, 326);
            this.BT_Add_category.Name = "BT_Add_category";
            this.BT_Add_category.Size = new System.Drawing.Size(75, 23);
            this.BT_Add_category.TabIndex = 3;
            this.BT_Add_category.Text = "Add";
            this.BT_Add_category.UseVisualStyleBackColor = true;
            this.BT_Add_category.Click += new System.EventHandler(this.BT_Add_category_Click);
            // 
            // BT_remove
            // 
            this.BT_remove.Location = new System.Drawing.Point(245, 326);
            this.BT_remove.Name = "BT_remove";
            this.BT_remove.Size = new System.Drawing.Size(75, 23);
            this.BT_remove.TabIndex = 4;
            this.BT_remove.Text = "Remove";
            this.BT_remove.UseVisualStyleBackColor = true;
            this.BT_remove.Click += new System.EventHandler(this.BT_remove_Click);
            // 
            // nud_interval
            // 
            this.nud_interval.Location = new System.Drawing.Point(83, 366);
            this.nud_interval.Name = "nud_interval";
            this.nud_interval.Size = new System.Drawing.Size(120, 22);
            this.nud_interval.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Interval";
            // 
            // BT_ok
            // 
            this.BT_ok.Location = new System.Drawing.Point(231, 417);
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
            this.ClientSize = new System.Drawing.Size(332, 454);
            this.Controls.Add(this.BT_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nud_interval);
            this.Controls.Add(this.BT_remove);
            this.Controls.Add(this.BT_Add_category);
            this.Controls.Add(this.tb_category);
            this.Controls.Add(this.lb_Search_Category);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "formSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nud_interval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Search_Category;
        private System.Windows.Forms.TextBox tb_category;
        private System.Windows.Forms.Button BT_Add_category;
        private System.Windows.Forms.Button BT_remove;
        private System.Windows.Forms.NumericUpDown nud_interval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_ok;
    }
}