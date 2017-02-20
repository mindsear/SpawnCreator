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
    public partial class Predefined_SAI_Templates : Form
    {
        public Predefined_SAI_Templates()
        {
            InitializeComponent();
            Individual();
        }

        public void Individual()
        {
            
            dataGridView1.Rows.Add("SMARTAI_TEMPLATE_BASIC", "0");
            dataGridView1.Rows.Add("SMARTAI_TEMPLATE_CASTER", "1", "spellid", "repeatMin", "repeatMax", "range", "manaPCT", "+JOIN: target_param1 as castFlag");
            dataGridView1.Rows.Add("SMARTAI_TEMPLATE_TURRET", "2", "spellid", "repeatMin", "repeatMax", "range", "manaPCT", "+JOIN: target_param1 as castFlag");
            dataGridView1.Rows.Add("SMARTAI_TEMPLATE_PASSIVE", "3");
            dataGridView1.Rows.Add("SMARTAI_TEMPLATE_CAGED_GO_PART", "4", "creatureID", "give credit at point end (0/1)");
            dataGridView1.Rows.Add("SMARTAI_TEMPLATE_CAGED_NPC_PART", "5", "gameObjectID", "despawntime", "run (0/1)", "dist", "TextGroupID");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Predefined_SAI_Templates_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Width = 228; // Description_Name
            dataGridView1.Columns[1].Width = 55; // Value_Param1
            dataGridView1.Columns[3].Width = 150; // Param3
            dataGridView1.Columns[4].Width = 70; // Param4
            dataGridView1.Columns[5].Width = 60; // Param5
            dataGridView1.Columns[6].Width = 70; // Param6
            dataGridView1.Columns[7].Width = 180; // Comment

        }
    }
}
