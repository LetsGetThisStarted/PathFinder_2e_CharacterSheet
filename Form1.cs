using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinder_2e_CharacterSheet
{
    public partial class Form1 : Form
    {
        public Character currentChar = new Character();

        // Default values for character
        /* private int STR;
        private int DEX;
        private int CON;
        private int INT;
        private int WIS;
        private int CHA;
        private int STRScore;
        private int DEXScore;
        private int CONScore;
        private int INTScore;
        private int WISScore;
        private int CHAScore;
        private int healthPoints;
        private int armorClass;
        private int classDC;
        // Actual values for character
        private int STR_temp;
        private int DEX_temp;
        private int CON_temp;
        private int INT_temp;
        private int WIS_temp;
        private int CHA_temp;
        private int STRScore_temp;
        private int DEXScore_temp;
        private int CONScore_temp;
        private int INTScore_temp;
        private int WISScore_temp;
        private int CHAScore_temp;
        private int healthPoints_temp;
        private int armorClass_temp;
        private int classDC_temp;

        enum proficiency
        {
            untrained = 0,
            trained = 2,
            expert = 4,
            master = 6,
            legendary = 8
        } */


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_IntMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ChaMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ConMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_DexMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_WisMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar_clicked(object sender, EventArgs e)
        {
            ProgressBar pBar = sender as ProgressBar;
            if (pBar.Value >= pBar.Maximum)
            {
                pBar.Value = 0;
            }
            else
            {
                pBar.Value += 1;
            }

        }

        private void textBox_CharacterName_TextChanged(object sender, EventArgs e)
        {
            currentChar.CharacterName = textBox_CharacterName.Text;
        }

        private void textBox_PlayerName_TextChanged(object sender, EventArgs e)
        {
            currentChar.PlayerName = textBox_PlayerName.Text;
        }

        private void textBox_XPCurrent_TextChanged(object sender, EventArgs e)
        {
            currentChar.XpCurrent = (int)numericUpDown_xpCurrent.Value;
        }

        private void comboBox_Background_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentChar.Background = comboBox_Background.Text;
        }

        private void comboBox_Alignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentChar.Alignment = comboBox_Alignment.Text;
        }

        private void comboBox_Deity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentChar.Deity = comboBox_Deity.Text;
        }

        private void numericUpDown_level_ValueChanged(object sender, EventArgs e)
        {
            currentChar.Level = (int)numericUpDown_level.Value;
        }
    }
}
