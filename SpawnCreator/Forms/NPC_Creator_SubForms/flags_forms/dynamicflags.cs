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
    public partial class dynamicflags : Form
    {
        public dynamicflags()
        {
            InitializeComponent();
        }

        private void dynamicflags_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DynamicFlags))
            {
                string[] checkedIndicies = Properties.Settings.Default.DynamicFlags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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

        private void dynamicflags_FormClosing(object sender, FormClosingEventArgs e)
        {
            string idx = string.Empty;
            for (int i1 = 0; i1 < checkedListBox1.CheckedIndices.Count; i1++)
                idx += (string.IsNullOrEmpty(idx) ? string.Empty : ",") + Convert.ToString(checkedListBox1.CheckedIndices[i1]);
            Properties.Settings.Default.DynamicFlags = idx;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Int32 totalvalue = 0;
            ////Loop through items in checkboxlist
            //for (int i = 0; i < checkedListBox1.Items.Count; i++)
            //{
            //    //check if particular items is selected or not
            //    if (checkedListBox1.Items[i] == checkedListBox1.SelectedValue)
            //    {
            //        //If selected then add the values to textbox
            //        totalvalue += Convert.ToInt32(checkedListBox1.SelectedValue);

            //        textBox1.Text = totalvalue.ToString();
            //    }
            //}


        }
    }
}
