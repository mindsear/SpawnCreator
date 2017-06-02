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
    public partial class Form_SocketOptions : Form
    {
        public Form_SocketOptions()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = Form_ItemCreator.output_socketColor1;
            textBox1.Text = Form_ItemCreator.output_socketContent1.ToString();
            listBox2.SelectedIndex = Form_ItemCreator.output_socketColor2;
            textBox2.Text = Form_ItemCreator.output_socketContent2.ToString();
            listBox3.SelectedIndex = Form_ItemCreator.output_socketColor3;
            textBox3.Text = Form_ItemCreator.output_socketContent3.ToString();
            textBox4.Text = Form_ItemCreator.output_socketBonus.ToString();
        }

        private void Form_SocketOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_ItemCreator frm = new Form_ItemCreator();
            frm.GetSocketBonusData(listBox1.SelectedIndex, Convert.ToInt32(textBox1.Text),
                listBox2.SelectedIndex, Convert.ToInt32(textBox2.Text), listBox3.SelectedIndex, Convert.ToInt32(textBox3.Text),
                Convert.ToInt32(textBox4.Text));

            Definers.output_itemsocketcolor1 = listBox1.SelectedIndex;
            Definers.output_itemsocketcolor2 = listBox2.SelectedIndex;
            Definers.output_itemsocketcolor3 = listBox3.SelectedIndex;
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
