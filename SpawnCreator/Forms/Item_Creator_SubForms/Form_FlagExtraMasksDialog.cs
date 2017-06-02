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
    public partial class Form_FlagExtraMasksDialog : Form
    {
        public Form_FlagExtraMasksDialog()
        {
            InitializeComponent();
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

        private void Form_FlagExtraMasksDialog_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.FlagExtraMasks))
            {
                string[] checkedIndicies = Properties.Settings.Default.FlagExtraMasks.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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

        private void Form_FlagExtraMasksDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            string idx = string.Empty;
            for (int i1 = 0; i1 < checkedListBox1.CheckedIndices.Count; i1++)
                idx += (string.IsNullOrEmpty(idx) ? string.Empty : ",") + Convert.ToString(checkedListBox1.CheckedIndices[i1]);
            Properties.Settings.Default.FlagExtraMasks = idx;
            Properties.Settings.Default.Save();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
