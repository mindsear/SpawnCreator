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
    public partial class Form_ItemPreview : Form
    {
        public Form_ItemPreview()
        {
            InitializeComponent();
        }

        private Color GetQualityColor(int index)
        {
            Color _color = Color.Black;

            switch(index)
            {
                case 0: // poor
                    _color = System.Drawing.ColorTranslator.FromHtml("#9d9d9d");
                    break;
                case 1: // Common
                    _color = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    break;
                case 2: // uncommon
                    _color = System.Drawing.ColorTranslator.FromHtml("#1eff00");
                    break;
                case 3: // rare
                    _color = System.Drawing.ColorTranslator.FromHtml("#0070ff");
                    break;
                case 4: // epic
                    _color = System.Drawing.ColorTranslator.FromHtml("#a335ee");
                    break;
                case 5: // legendary
                    _color = System.Drawing.ColorTranslator.FromHtml("#ff8000");
                    break;
                case 6: // artifact
                    _color = System.Drawing.ColorTranslator.FromHtml("#e6cc80");
                    break;
                case 7: // bind to account
                    _color = System.Drawing.ColorTranslator.FromHtml("#e6cc80");
                    break;
            }

            return _color;
        }

        private string GetItemBindingString(int index)
        {
            string btext = "No bounds";
            switch (index)
            {
                case 1:
                    btext = "Binds when picked up";
                    break;
                case 2:
                    btext = "Binds when equipped";
                    break;
                case 3:
                    btext = "Binds when used";
                    break;
                case 4:
                    btext = "Quest Item";
                    break;
                case 5:
                    btext = "Quest Item 1";
                    break;
            }

            return btext;
        }

        private string GetInvetoryTypeString(int index)
        {
            string string_it = "Non Equipable";
            switch (index)
            {
                case 1:
                    string_it = "Head";
                    break;
                case 2:
                    string_it = "Neck";
                    break;
                case 3:
                    string_it = "Shoulder";
                    break;
                case 4:
                    string_it = "Shirt";
                    break;
                case 5:
                    string_it = "Chest";
                    break;
                case 6:
                    string_it = "Waist";
                    break;
                case 7:
                    string_it = "Legs";
                    break;
                case 8:
                    string_it = "Feet";
                    break;
                case 9:
                    string_it = "Wrists";
                    break;
                case 10:
                    string_it = "Hands";
                    break;
                case 11:
                    string_it = "Finger";
                    break;
                case 12:
                    string_it = "Trinket";
                    break;
                case 13:
                    string_it = "Weapon";
                    break;
                case 14:
                    string_it = "Shield";
                    break;
                case 15:
                    string_it = "Ranged (Bows)";
                    break;
                case 16:
                    string_it = "Back";
                    break;
                case 17:
                    string_it = "Two-Handed";
                    break;
                case 18:
                    string_it = "Bag";
                    break;
                case 19:
                    string_it = "Tabard";
                    break;
                case 20:
                    string_it = "Robe";
                    break;
                case 21:
                    string_it = "Main Hand";
                    break;
                case 22:
                    string_it = "Off Hand";
                    break;
                case 23:
                    string_it = "Holdable (Tome)";
                    break;
                case 24:
                    string_it = "Ammo";
                    break;
                case 25:
                    string_it = "Thrown";
                    break;
                case 26:
                    string_it = "Ranged right (Wands, Guns)";
                    break;
                case 27:
                    string_it = "Quiver";
                    break;
                case 28:
                    string_it = "Relic";
                    break;
            }
            return string_it;
        }

        private string GetItemMaterialString(int index)
        {
            string string_im = "Not Defined";
            switch(index)
            {
                case 0:
                    string_im = "Consumables";
                    break;
                case 1:
                    string_im = "";
                    break;
                case 2:
                    string_im = "Metal";
                    break;
                case 3:
                    string_im = "Wood";
                    break;
                case 4:
                    string_im = "Liquid";
                    break;
                case 5:
                    string_im = "Jewelry";
                    break;
                case 6:
                    string_im = "Chain";
                    break;
                case 7:
                    string_im = "Plate";
                    break;
                case 8:
                    string_im = "Cloth";
                    break;
                case 9:
                    string_im = "Leather";
                    break;
                case 10:
                    string_im = "Quiver";
                    break;
                case 11:
                    string_im = "Relic";
                    break;
            }
            return string_im;
        }

        private string GetItemTypeString(int index)
        {
            string string_itype = "Stamina";
            switch(index)
            {
                case 0:
                    string_itype = "Mana";
                    break;
                case 1:
                    string_itype = "Health";
                    break;
                case 2:
                    string_itype = "Agility";
                    break;
                case 3:
                    string_itype = "Strength";
                    break;
                case 4:
                    string_itype = "Intelect";
                    break;
                case 5:
                    string_itype = "Spirit";
                    break;
                case 6:
                    string_itype = "Stamina";
                    break;
                case 7:
                    string_itype = "Defense Skill Rating";
                    break;
                case 8:
                    string_itype = "Dodge Rating";
                    break;
                case 9:
                    string_itype = "Parry Rating";
                    break;
                case 10:
                    string_itype = "Block Rating";
                    break;
                case 11:
                    string_itype = "Hit Melee Rating";
                    break;
                case 12:
                    string_itype = "Hit Ranged Rating";
                    break;
                case 13:
                    string_itype = "Hit Spell Rating";
                    break;
                case 14:
                    string_itype = "Crit Melee Rating";
                    break;
                case 15:
                    string_itype = "Crit Ranged Rating";
                    break;
                case 16:
                    string_itype = "Crit Spell Rating";
                    break;
                case 17:
                    string_itype = "Hit Taken Melee Rating";
                    break;
                case 18:
                    string_itype = "Hit Taken Ranged Rating";
                    break;
                case 19:
                    string_itype = "Hit Taken Spell Rating";
                    break;
                case 20:
                    string_itype = "Crit Taken Melee Rating";
                    break;
                case 21:
                    string_itype = "Crit Taken Ranged Rating";
                    break;
                case 22:
                    string_itype = "Crit Taken Spell Rating";
                    break;
                case 23:
                    string_itype = "Haste Melee Rating";
                    break;
                case 24:
                    string_itype = "Haste Ranged Rating";
                    break;
                case 25:
                    string_itype = "Haste Spell Rating";
                    break;
                case 26:
                    string_itype = "Hit Rating";
                    break;
                case 27:
                    string_itype = "Crit Rating";
                    break;
                case 28:
                    string_itype = "Hit Taken Rating";
                    break;
                case 29:
                    string_itype = "Crit Taken Rating";
                    break;
                case 30:
                    string_itype = "Resilience Rating";
                    break;
                case 31:
                    string_itype = "Haste Rating";
                    break;
                case 32:
                    string_itype = "Expertise Rating";
                    break;
                case 33:
                    string_itype = "Attack Power";
                    break;
                case 34:
                    string_itype = "Ranged Attack Power";
                    break;
                case 35:
                    string_itype = "Feral Attack Power";
                    break;
                case 36:
                    string_itype = "Spell Healing Done";
                    break;
                case 37:
                    string_itype = "Spell Damage Done";
                    break;
                case 38:
                    string_itype = "Mana Regeneration";
                    break;
                case 39:
                    string_itype = "Armor Penetration Rating";
                    break;
                case 40:
                    string_itype = "Spell Power";
                    break;
                case 41:
                    string_itype = "Health Regeneration";
                    break;
                case 42:
                    string_itype = "Spell Penetration";
                    break;
                case 43:
                    string_itype = "Block Value";
                    break;
            }
            return string_itype;
        }

        private Bitmap SocketColorImage(int index)
        {
            Bitmap bm = Properties.Resources.socket_prismatic;
            switch (index)
            {
                case 1:
                    bm = Properties.Resources.socket_prismatic;
                    break;
                case 2:
                    bm = Properties.Resources.socket_red;
                    break;
                case 3:
                    bm = Properties.Resources.socket_yellow;
                    break;
                case 4:
                    bm = Properties.Resources.socket_blue;
                    break;
            }
            return bm;
        }

        private string SocketColorString(int index)
        {
            string i_socketcolorstring =  "Prismatic Socket";
            switch (index)
            {
                case 1:
                    i_socketcolorstring = "Prismatic Socket";
                    break;
                case 2:
                    i_socketcolorstring = "Red Socket";
                    break;
                case 3:
                    i_socketcolorstring = "Yellow Socket";
                    break;
                case 4:
                    i_socketcolorstring = "Blue Socket";
                    break;
            }
            return i_socketcolorstring;
        }

        private void Form_ItemPreview_Load(object sender, EventArgs e)
        {
            Form_ItemCreator form2 = new Form_ItemCreator();
            string this_title = "ITEM[";
            this_title += Definers.output_itemEntry;
            this_title += "]: ";
            this_title += Definers.output_itemName;

            this.Text = this_title;
            label1.ForeColor = GetQualityColor(Definers.output_itemQuality);
            label1.Text = "[" + Definers.output_itemName + "]";
            label2.Text = "Item Level " + Definers.output_itemlevel;
            label3.Text = "\"" + Definers.output_itemDescription + "\"";
            label4.Text = GetItemBindingString(Definers.output_itembinding);
            label5.Text = GetInvetoryTypeString(Definers.output_iteminvetorytype);
            label6.Text = GetItemMaterialString(Definers.output_itemmaterial);

            if (Definers.output_itemarmor > 0)
                label7.Text = Definers.output_itemarmor.ToString();
            else
            {
                label7.Hide();
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - 14);
            }

            // load stats
            int p1_stats_count = 0;
            int p2_stats_count = 0;
            int p3_stats_count = 0;

            Label lb_value1 = new Label(); // stat value 1
            lb_value1.AutoSize = true;

            Label lb_value2 = new Label(); // stat value 2
            lb_value2.AutoSize = true;

            Label lb_value3 = new Label(); // stat value 3
            lb_value3.AutoSize = true;

            Label lb_value4 = new Label(); // stat value 4
            lb_value4.AutoSize = true;

            Label lb_value5 = new Label(); // stat value 5
            lb_value5.AutoSize = true;

            Label lb_value6 = new Label(); // stat value 6
            lb_value6.AutoSize = true;

            Label lb_value7 = new Label(); // stat value 7
            lb_value7.AutoSize = true;

            Label lb_value8 = new Label(); // stat value 8
            lb_value8.AutoSize = true;

            Label lb_value9 = new Label(); // stat value 9
            lb_value9.AutoSize = true;

            Label lb_value10 = new Label(); // stat value 10
            lb_value10.AutoSize = true;

            // stats value 1
            if (Definers.output_itemstatvalue1 > 0)
            {
                if (Definers.output_itemtype1 > 6) // green stats
                {
                    p2_stats_count += 1;
                    panel3.Controls.Add(lb_value1);
                }
                else
                {
                    p1_stats_count += 1;
                    panel2.Controls.Add(lb_value1);
                }
                lb_value1.Text = "+" + Definers.output_itemstatvalue1.ToString() + " " + GetItemTypeString(Definers.output_itemtype1);
                lb_value1.ForeColor = Definers.output_itemtype1 > 6 ? Color.FromArgb(30, 255, 0) : Color.White;
            }
            // stats value 2
            if (Definers.output_itemstatvalue2 > 0)
            {
                if (Definers.output_itemtype2 > 6) // green stats
                {
                    p2_stats_count += 1;
                    panel3.Controls.Add(lb_value2);
                    lb_value2.Location = new Point(lb_value2.Location.X, lb_value2.Location.Y + ((p2_stats_count - 1) * 20));
                }
                else
                {
                    p1_stats_count += 1;
                    panel2.Controls.Add(lb_value2);
                    lb_value2.Location = new Point(lb_value2.Location.X, lb_value2.Location.Y + ((p1_stats_count - 1) * 20));
                }
                lb_value2.Text = "+" + Definers.output_itemstatvalue2.ToString() + " " + GetItemTypeString(Definers.output_itemtype2);
                lb_value2.ForeColor = Definers.output_itemtype2 > 6 ? Color.FromArgb(30, 255, 0) : Color.White;
            }
            // stats value 3
            if (Definers.output_itemstatvalue3 > 0)
            {
                if (Definers.output_itemtype3 > 6) // green stats
                {
                    p2_stats_count += 1;
                    panel3.Controls.Add(lb_value3);
                    lb_value3.Location = new Point(lb_value3.Location.X, lb_value3.Location.Y + ((p2_stats_count - 1) * 20));
                }
                else
                {
                    p1_stats_count += 1;
                    panel2.Controls.Add(lb_value3);
                    lb_value3.Location = new Point(lb_value3.Location.X, lb_value3.Location.Y + ((p1_stats_count - 1) * 20));
                }
                lb_value3.Text = "+" + Definers.output_itemstatvalue3.ToString() + " " + GetItemTypeString(Definers.output_itemtype3);
                lb_value3.ForeColor = Definers.output_itemtype3 > 6 ? Color.FromArgb(30, 255, 0) : Color.White;
            }
            // stats value 4
            if (Definers.output_itemstatvalue4 > 0)
            {
                if (Definers.output_itemtype4 > 6) // green stats
                {
                    p2_stats_count += 1;
                    panel3.Controls.Add(lb_value4);
                    lb_value4.Location = new Point(lb_value4.Location.X, lb_value4.Location.Y + ((p2_stats_count - 1) * 20));
                }
                else
                {
                    p1_stats_count += 1;
                    panel2.Controls.Add(lb_value4);
                    lb_value4.Location = new Point(lb_value4.Location.X, lb_value4.Location.Y + ((p1_stats_count - 1) * 20));
                }
                lb_value4.Text = "+" + Definers.output_itemstatvalue4.ToString() + " " + GetItemTypeString(Definers.output_itemtype4);
                lb_value4.ForeColor = Definers.output_itemtype4 > 6 ? Color.FromArgb(30, 255, 0) : Color.White;
            }
            // stats value 5
            if (Definers.output_itemstatvalue5 > 0)
            {
                if (Definers.output_itemtype5 > 6) // green stats
                {
                    p2_stats_count += 1;
                    panel3.Controls.Add(lb_value5);
                    lb_value5.Location = new Point(lb_value5.Location.X, lb_value5.Location.Y + ((p2_stats_count - 1) * 20));
                }
                else
                {
                    p1_stats_count += 1;
                    panel2.Controls.Add(lb_value5);
                    lb_value5.Location = new Point(lb_value5.Location.X, lb_value5.Location.Y + ((p1_stats_count - 1) * 20));
                }
                lb_value5.Text = "+" + Definers.output_itemstatvalue5.ToString() + " " + GetItemTypeString(Definers.output_itemtype5);
                lb_value5.ForeColor = Definers.output_itemtype5 > 6 ? Color.FromArgb(30, 255, 0) : Color.White;
            }
            // stats value 6
            if (Definers.output_itemstatvalue6 > 0)
            {
                if (Definers.output_itemtype6 > 6) // green stats
                {
                    p2_stats_count += 1;
                    panel3.Controls.Add(lb_value6);
                    lb_value6.Location = new Point(lb_value6.Location.X, lb_value6.Location.Y + ((p2_stats_count - 1) * 20));
                }
                else
                {
                    p1_stats_count += 1;
                    panel2.Controls.Add(lb_value6);
                    lb_value6.Location = new Point(lb_value6.Location.X, lb_value6.Location.Y + ((p1_stats_count - 1) * 20));
                }
                lb_value6.Text = "+" + Definers.output_itemstatvalue6.ToString() + " " + GetItemTypeString(Definers.output_itemtype6);
                lb_value6.ForeColor = Definers.output_itemtype6 > 6 ? Color.FromArgb(30, 255, 0) : Color.White;
            }
            // stats value 7
            if (Definers.output_itemstatvalue7 > 0)
            {
                if (Definers.output_itemtype7 > 6) // green stats
                {
                    p2_stats_count += 1;
                    panel3.Controls.Add(lb_value7);
                    lb_value7.Location = new Point(lb_value7.Location.X, lb_value7.Location.Y + ((p2_stats_count - 1) * 20));
                }
                else
                {
                    p1_stats_count += 1;
                    panel2.Controls.Add(lb_value7);
                    lb_value7.Location = new Point(lb_value7.Location.X, lb_value7.Location.Y + ((p1_stats_count - 1) * 20));
                }
                lb_value7.Text = "+" + Definers.output_itemstatvalue7.ToString() + " " + GetItemTypeString(Definers.output_itemtype7);
                lb_value7.ForeColor = Definers.output_itemtype7 > 6 ? Color.FromArgb(30, 255, 0) : Color.White;
            }
            // stats value 8
            if (Definers.output_itemstatvalue8 > 0)
            {
                if (Definers.output_itemtype8 > 6) // green stats
                {
                    p2_stats_count += 1;
                    panel3.Controls.Add(lb_value8);
                    lb_value8.Location = new Point(lb_value8.Location.X, lb_value8.Location.Y + ((p2_stats_count - 1) * 20));
                }
                else
                {
                    p1_stats_count += 1;
                    panel2.Controls.Add(lb_value8);
                    lb_value8.Location = new Point(lb_value8.Location.X, lb_value8.Location.Y + ((p1_stats_count - 1) * 20));
                }
                lb_value8.Text = "+" + Definers.output_itemstatvalue8.ToString() + " " + GetItemTypeString(Definers.output_itemtype8);
                lb_value8.ForeColor = Definers.output_itemtype8 > 6 ? Color.FromArgb(30, 255, 0) : Color.White;
            }
            // stats value 9
            if (Definers.output_itemstatvalue9 > 0)
            {
                if (Definers.output_itemtype9 > 6) // green stats
                {
                    p2_stats_count += 1;
                    panel3.Controls.Add(lb_value9);
                    lb_value9.Location = new Point(lb_value9.Location.X, lb_value9.Location.Y + ((p2_stats_count - 1) * 20));
                }
                else
                {
                    p1_stats_count += 1;
                    panel2.Controls.Add(lb_value9);
                    lb_value9.Location = new Point(lb_value9.Location.X, lb_value9.Location.Y + ((p1_stats_count - 1) * 20));
                }
                lb_value9.Text = "+" + Definers.output_itemstatvalue9.ToString() + " " + GetItemTypeString(Definers.output_itemtype9);
                lb_value9.ForeColor = Definers.output_itemtype9 > 6 ? Color.FromArgb(30, 255, 0) : Color.White;
            }
            // stats value 10
            if (Definers.output_itemstatvalue10 > 0)
            {
                if (Definers.output_itemtype10 > 6) // green stats
                {
                    p2_stats_count += 1;
                    panel3.Controls.Add(lb_value10);
                    lb_value10.Location = new Point(lb_value10.Location.X, lb_value10.Location.Y + ((p2_stats_count - 1) * 20));
                }
                else
                {
                    p1_stats_count += 1;
                    panel2.Controls.Add(lb_value10);
                    lb_value10.Location = new Point(lb_value10.Location.X, lb_value10.Location.Y + ((p1_stats_count - 1) * 20));
                }
                lb_value10.Text = "+" + Definers.output_itemstatvalue10.ToString() + " " + GetItemTypeString(Definers.output_itemtype10);
                lb_value10.ForeColor = Definers.output_itemtype10 > 6 ? Color.FromArgb(30, 255, 0) : Color.White;
            }

            if (p1_stats_count > 0)
            {
                if (p1_stats_count > 1)
                    panel2.Height += (p1_stats_count - 1) * 20;
            }
            else
                panel2.Hide();

            if (p2_stats_count > 0)
            {
                if (p2_stats_count > 1)
                    panel3.Height += (p2_stats_count - 1) * 20;
            }
            else
                panel3.Hide();
            // end of load stats

            if (panel2.Visible)
                panel3.Location = new Point(panel2.Location.X, panel2.Location.Y + panel2.Height);
            else
                panel3.Location = new Point(panel2.Location.X, panel2.Location.Y);

            // socket display
            PictureBox pic_socket1 = new PictureBox(); // socket color picture 1
            pic_socket1.Size = new Size(14, 14);

            PictureBox pic_socket2 = new PictureBox(); // socket color picture 2
            pic_socket2.Size = new Size(14, 14);

            PictureBox pic_socket3 = new PictureBox(); // socket color picture 3
            pic_socket3.Size = new Size(14, 14);

            Label lb_socketColor1 = new Label(); // socket color label 1
            lb_socketColor1.AutoSize = true;
            lb_socketColor1.ForeColor = Color.FromArgb(157,157,157);

            Label lb_socketColor2 = new Label();// socket color label 2
            lb_socketColor2.AutoSize = true;
            lb_socketColor2.ForeColor = Color.FromArgb(157, 157, 157);

            Label lb_socketColor3 = new Label();// socket color label 3
            lb_socketColor3.AutoSize = true;
            lb_socketColor3.ForeColor = Color.FromArgb(157, 157, 157);

            if (Definers.output_itemsocketcolor1 > 0)
            {
                p3_stats_count += 1;
                pic_socket1.Image = SocketColorImage(Definers.output_itemsocketcolor1);
                lb_socketColor1.Location = new Point(lb_socketColor1.Location.X + 15, lb_socketColor1.Location.Y);
                lb_socketColor1.Text = SocketColorString(Definers.output_itemsocketcolor1);
                panel4.Controls.Add(lb_socketColor1);
                panel4.Controls.Add(pic_socket1);
            }
            if (Definers.output_itemsocketcolor2 > 0)
            {
                p3_stats_count += 1;
                pic_socket2.Image = SocketColorImage(Definers.output_itemsocketcolor2);
                pic_socket2.Location = new Point(pic_socket2.Location.X, pic_socket2.Location.Y + ((p3_stats_count -1) * 21));
                lb_socketColor2.Location = new Point(lb_socketColor2.Location.X + 15, lb_socketColor2.Location.Y + ((p3_stats_count - 1) * 21));
                lb_socketColor2.Text = SocketColorString(Definers.output_itemsocketcolor2);
                panel4.Controls.Add(lb_socketColor2);
                panel4.Controls.Add(pic_socket2);
            }
            if (Definers.output_itemsocketcolor3 > 0)
            {
                p3_stats_count += 1;
                pic_socket3.Image = SocketColorImage(Definers.output_itemsocketcolor3);
                pic_socket3.Location = new Point(pic_socket3.Location.X, pic_socket3.Location.Y + ((p3_stats_count -1 ) * 21));
                lb_socketColor3.Location = new Point(lb_socketColor3.Location.X + 15, lb_socketColor3.Location.Y + ((p3_stats_count - 1) * 21));
                lb_socketColor3.Text = SocketColorString(Definers.output_itemsocketcolor3);
                panel4.Controls.Add(lb_socketColor3);
                panel4.Controls.Add(pic_socket3);
            }

            if (p3_stats_count > 0)
            {
                if (p3_stats_count > 1)
                    panel4.Height += (p3_stats_count - 1) * 21;
            }
            else
                panel4.Hide();
            // end of socket display

            if (panel3.Visible)
                panel4.Location = new Point(panel3.Location.X, panel3.Location.Y + panel3.Height);
            else
                panel4.Location = new Point(panel3.Location.X, panel3.Location.Y);

            // item durability
            if (Definers.output_itemdurability > 0)
                label8.Text = "Durability " + Definers.output_itemdurability.ToString() + "/" + Definers.output_itemdurability.ToString();
            else
                label8.Hide();

            if (panel4.Visible)
                label8.Location = new Point(panel4.Location.X, panel4.Location.Y + panel4.Height);
            else
                label8.Location = new Point(panel4.Location.X, panel4.Location.Y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(207,207,207)),
            e.ClipRectangle.Left,
            e.ClipRectangle.Top,
            e.ClipRectangle.Width - 1,
            e.ClipRectangle.Height -1);
            base.OnPaint(e);
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
    }
}
