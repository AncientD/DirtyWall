using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dirtywall
{
    public partial class formSettings : Form
    {
        public formSettings(string query, int interval)
        {
            InitializeComponent();
            this.nud_interval.Maximum = 200;
            this.nud_interval.Minimum = 1;
            this.nud_interval.Value = interval;

            string[] keywords = query.Split(new string[] { "|" }, StringSplitOptions.None);
            this.lb_Search_Category.Items.Clear();
            foreach (string item in keywords)
                this.lb_Search_Category.Items.Add(item);
        }

        private void BT_remove_Click(object sender, EventArgs e)
        {
            if (this.lb_Search_Category.SelectedItems.Count == 1)
                this.lb_Search_Category.Items.Remove(this.lb_Search_Category.SelectedItem);
        }

        private void BT_Add_category_Click(object sender, EventArgs e)
        {
            if (this.tb_category.Text.Length > 1)
                this.lb_Search_Category.Items.Add(this.tb_category.Text);
        }

        private void BT_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            string str = "";
            for (int i = 0; i < this.lb_Search_Category.Items.Count; i++)
            {
                str += this.lb_Search_Category.Items[i];
                if (i+1 < this.lb_Search_Category.Items.Count)
                    str += "|";
            }
            Dirtywall.Program.searchQuery = str;
            Dirtywall.Program.interval = Convert.ToInt32(this.nud_interval.Value);

            Close();
        }
    }
}
