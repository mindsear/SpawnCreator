using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnCreator
{
    class SpawnFunctions
    {
        public static void LoadIndexes()
        {
            Form_ItemCreator frm = new Form_ItemCreator();
            Definers.output_itemEntry = Convert.ToInt32(frm.textBox1.Text);
            Definers.output_itemName = frm.textBox2.Text;
            Definers.output_itemlevel = Convert.ToInt32(frm.textBox10.Text);
            Definers.output_itemarmor = Convert.ToInt32(frm.textBox29.Text);
            Definers.output_itemstatvalue1 = Convert.ToInt32(frm.textBox16.Text);
            Definers.output_itemstatvalue2 = Convert.ToInt32(frm.textBox17.Text);
            Definers.output_itemstatvalue3 = Convert.ToInt32(frm.textBox18.Text);
            Definers.output_itemstatvalue4 = Convert.ToInt32(frm.textBox19.Text);
            Definers.output_itemstatvalue5 = Convert.ToInt32(frm.textBox20.Text);
            Definers.output_itemstatvalue6 = Convert.ToInt32(frm.textBox21.Text);
            Definers.output_itemstatvalue7 = Convert.ToInt32(frm.textBox22.Text);
            Definers.output_itemstatvalue8 = Convert.ToInt32(frm.textBox23.Text);
            Definers.output_itemstatvalue9 = Convert.ToInt32(frm.textBox24.Text);
            Definers.output_itemstatvalue10 = Convert.ToInt32(frm.textBox25.Text);
            Definers.output_itemdurability = Convert.ToInt32(frm.textBox31.Text);
        }
    }
}
