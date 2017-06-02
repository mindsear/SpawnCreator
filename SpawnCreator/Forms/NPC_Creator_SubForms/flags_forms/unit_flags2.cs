using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpawnCreator
{
    public partial class unit_flags2 : Form
    {
        public unit_flags2()
        {
            InitializeComponent();
        }

        private void unit_flags2_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.UnitFlags2))
            {
                string[] checkedIndicies = Properties.Settings.Default.UnitFlags2.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i1 = 0; i1 < checkedIndicies.Length; i1++)
                {
                    int idx;
                    if ((int.TryParse(checkedIndicies[i1], out idx)) && (checkedListBox1.Items.Count >= (idx + 1)))
                    {
                        checkedListBox1.SetItemChecked(idx, true);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }

        private void unit_flags2_FormClosing(object sender, FormClosingEventArgs e)
        {
            string idx = string.Empty;
            for (int i1 = 0; i1 < checkedListBox1.CheckedIndices.Count; i1++)
                idx += (string.IsNullOrEmpty(idx) ? string.Empty : ",") + Convert.ToString(checkedListBox1.CheckedIndices[i1]);
            Properties.Settings.Default.UnitFlags2 = idx;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
