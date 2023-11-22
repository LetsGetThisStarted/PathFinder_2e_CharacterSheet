using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinder_2e_CharacterSheet
{
    public partial class Form1 : Form
    {
        public Character currentChar = new Character();

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

        private void numericUpDown_heroPoints_ValueChanged(object sender, EventArgs e)
        {
            currentChar.HeroPoints = (int)numericUpDown_heroPoints.Value;
        }

        private void listBox_ResistAndImmune_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateSheetHeader(Character thisChar)
        {
            textBox_PlayerName.Text = thisChar.PlayerName;
            textBox_CharacterName.Text = thisChar.CharacterName;
            comboBox_Deity.Text = thisChar.Deity;
            comboBox_Alignment.Text = thisChar.Alignment;
            comboBox_Background.Text = thisChar.Background;
        }

        private void UpdateSheetAbilityScores(Character thisChar)
        {
            label_DexMod.Text = thisChar.DexMod.ToString();
            label_ConMod.Text = thisChar.ConMod.ToString();
            label_IntMod.Text = thisChar.IntMod.ToString();
            label_WisMod.Text = thisChar.WisMod.ToString();
            label_ChaMod.Text = thisChar.ChaMod.ToString();
            label_StrMod.Text = thisChar.StrMod.ToString();
        }

        private void UpdateSheetClassDC(Character thisChar)
        {
            label_DC.Text = thisChar.Dc.ToString();
            progressBar_ClassDC.Value = (int)thisChar.DcProf;
            textBox_DCKey.Text = thisChar.DcKey.ToString();
            textBox_DCProf.Text = thisChar.DcProf.ToString();
            textBox_DCItem.Text = thisChar.DcItem.ToString();
        }

        private void UpdateSheetAC(Character thisChar)
        {
            label_AC.Text = thisChar.Ac.ToString();
            progressBar_Unarmored.Value = (int)thisChar.UnarmoredProf;
            progressBar_Light.Value = (int)thisChar.LightProf;
            progressBar_Medium.Value = (int)thisChar.MediumProf;
            progressBar_Heavy.Value = (int)thisChar.HeavyProf;
            progressBar_ArmorClass.Value = (int)thisChar.AcProf;
            textBox_ACDex.Text = thisChar.DexMod.ToString();
            // textBox_ACCap.Text = thisChar.AC;                            TODO - Find out what this is
            textBox_ACProf.Text = thisChar.AcProf.ToString();
            textBox_ACItem.Text = thisChar.AcItem.ToString();
            // textBox_ACShield.Text = thisChar.AcShield.ToString();        TODO - Add to Shield class
            // textBox_ACHardness.Text = thisChar.AcHardness.ToString();    TODO - Add to Shield class
            // textBox_ACMaxHP.Text = thisChar.AcMaxHP.ToString();          TODO - Add to Shield class
            // textBox_ACBT.Text = thisChar.AcBt.ToString();                TODO - Add to Shield class
            // textBox_ACCurrentHP.Text = thisChar.AcCurrentHp.ToString();  TODO - Add to Shield class
        }

        private void UpdateSheetSavingThrows(Character thisChar)
        {
            progressBar_Fortitude.Value = (int)thisChar.FortitudeProf;
            label_Fortitude.Text = thisChar.Fortitude.ToString();
            textBox_FortitudeCon.Text = thisChar.ConMod.ToString();
            textBox_FortitudeProf.Text = thisChar.FortitudeProf.ToString();
            textBox_FortitudeItem.Text = thisChar.FortitudeItem.ToString();

            progressBar_Reflex.Value = (int)thisChar.ReflexProf;
            textBox_ReflexItem.Text = thisChar.ReflexItem.ToString();
            textBox_ReflexProf.Text = thisChar.ReflexProf.ToString();
            textBox_ReflexDex.Text = thisChar.DexMod.ToString();
            label_Reflex.Text = thisChar.Reflex.ToString();

            progressBar_Will.Value = (int)thisChar.WillProf;
            textBox_WillItem.Text = thisChar.WillItem.ToString();
            textBox_WillProf.Text = thisChar.WillProf.ToString();
            textBox_WillWis.Text = thisChar.WisMod.ToString();
            label_Will.Text = thisChar.Will.ToString();
        }

        private void UpdateSheetHitPoints(Character thisChar)
        {
            textBox_HitPointsMax.Text = thisChar.MaxHP.ToString();
            textBox_HitPointsCurrent.Text = thisChar.CurrentHP.ToString();
            textBox_HitPointsTemp.Text = thisChar.TemporaryHP.ToString();
        }

        private void UpdateSheetPerception(Character thisChar)
        {
            progressBar_Perception.Value = (int)thisChar.PerceptionProf;
            label_Perception.Text = thisChar.Perception.ToString();
            textBox_PercptionWis.Text = thisChar.WisMod.ToString();
            textBox_PerceptionProf.Text = thisChar.PerceptionProf.ToString();
            textBox_PerceptionItem.Text = thisChar.PerceptionItem.ToString();
        }

        private void UpdateSheetSpeed(Character thisChar)
        {
            textBox_Speed.Text = thisChar.Speed.ToString();
        }

        private void UpdateSheetMeleeStrikes(Character thisChar)
        {
            progressBar_Melee1.Value = (int)thisChar.Melee1Prof;
            progressBar_Melee2.Value = (int)thisChar.Melee2Prof;
            progressBar_Melee3.Value = (int)thisChar.Melee3Prof;
        }

        private void UpdateSheetRangedStrikes(Character thisChar)
        {
            progressBar_Ranged1.Value = (int)thisChar.Ranged1Prof;
            progressBar_Ranged2.Value = (int)thisChar.Ranged2Prof;
            progressBar_Ranged3.Value = (int)thisChar.Ranged3Prof;
        }

        private void UpdateSheetWeaponProf(Character thisChar)
        {
            progressBar_WeaponSimple.Value = (int)thisChar.SimpleWeaponProf;
            progressBar_WeaponMartial.Value = (int)thisChar.MartialWeaponProf;
            progressBar_WeaponOther1.Value = (int)thisChar.OtherWeaponProf1;
            progressBar_WeaponOther2.Value = (int)thisChar.OtherWeaponProf2;
        }

        private void UpdateSkillAcrobatics(Character thisChar)
        {
            progressBar_Acrobatics.Value = (int)thisChar.Acrobatics.Prof;
            label_Acrobatics.Text = thisChar.Acrobatics.Value.ToString();
            label_AcrobaticsASMod.Text = thisChar.Acrobatics.AbilityScoreValue.ToString();
            textBox_AcrobaticsProfMod.Text = thisChar.Acrobatics.Prof.ToString();
            textBox_AcrobaticsItemMod.Text = thisChar.Acrobatics.Item.ToString();
            textBox_AcrobaticsArmorMod.Text = thisChar.Acrobatics.ArmorMod.ToString();
        }

        private void UpdateSkillArcana(Character thisChar)
        {
            progressBar_Arcana.Value = (int)thisChar.Arcana.Prof;
            textBox_ArcanaItemMod.Text = thisChar.Arcana.Item.ToString();
            textBox_ArcanaProfMod.Text = thisChar.Arcana.Prof.ToString();
            label_ArcanaASMod.Text = thisChar.Acrobatics.AbilityScoreValue.ToString();
            label_Arcana.Text = thisChar.Arcana.Value.ToString();
        }

        private void UpdateSkillAthletics(Character thisChar)
        {
            progressBar_Athletics.Value = (int)thisChar.Athletics.Prof;
            textBox_AthleticsArmorMod.Text = thisChar.Athletics.ArmorMod.ToString();
            textBox_AthleticsItemMod.Text = thisChar.Athletics.Item.ToString();
            textBox_AthleticsProfMod.Text = thisChar.Athletics.Prof.ToString();
            label_AthleticsASMod.Text = thisChar.Athletics.AbilityScoreValue.ToString();
            label_Athletics.Text = thisChar.Athletics.Value.ToString();
        }

        private void UpdateSkillCrafting(Character thisChar)
        {
            progressBar_Crafting.Value = (int)thisChar.Crafting.Prof;
            textBox_CraftingItemMod.Text = thisChar.Crafting.Item.ToString();
            textBox_CraftingProfMod.Text = thisChar.Crafting.Prof.ToString();
            label_CraftingASMod.Text = thisChar.Crafting.AbilityScoreValue.ToString();
            label_Crafting.Text = thisChar.Crafting.Value.ToString();
        }

        private void UpdateSkillDeception(Character thisChar) 
        {
            label_Deception.Text = thisChar.Deception.Value.ToString();
            progressBar_Deception.Value = (int)thisChar.Deception.Prof;
            textBox_DeceptionItemMod.Text = thisChar.Deception.Item.ToString();
            textBox_DeceptionProfMod.Text = thisChar.Deception.Prof.ToString();
            label_DeceptionASMod.Text = thisChar.Deception.AbilityScoreValue.ToString();
        }

        private void UpdateSkillDiplomacy(Character thisChar)
        {
            progressBar_Diplomacy.Value = (int)thisChar.Diplomacy.Prof;
            textBox_DiplomacyItemMod.Text = thisChar.Diplomacy.Item.ToString();
            textBox_DiplomacyProfMod.Text = thisChar.Diplomacy.Prof.ToString();
            label_DiplomacyASMod.Text = thisChar.Diplomacy.AbilityScoreValue.ToString();
            label_Diplomacy.Text = thisChar.Diplomacy.Value.ToString();
        }

        private void UpdateSkillIntimidation(Character thisChar)
        {
            progressBar_Intimidation.Value = (int)thisChar.Intimidation.Prof;
            textBox_IntimidationItemMod.Text = thisChar.Intimidation.Item.ToString();
            textBox_IntimidationProfMod.Text = thisChar.Intimidation.Prof.ToString();
            label_IntimidationASMod.Text = thisChar.Intimidation.AbilityScoreValue.ToString();
            label_Intimidation.Text = thisChar.Intimidation.Value.ToString();
        }

        private void UpdateSkillLore1(Character thisChar)
        {
            progressBar_Lore1.Value = (int)thisChar.Lore1.Prof;
            textBox_Lore1ItemMod.Text = thisChar.Lore1.Item.ToString();
            textBox_Lore1ProfMod.Text = thisChar.Lore1.Prof.ToString();
            label_Lore1ASMod.Text = thisChar.Lore1.AbilityScoreValue.ToString();
            label_Lore1.Text = thisChar.Lore1.Value.ToString(); ;
            textBox_Lore1SubType.Text = thisChar.Lore1.SubType.ToString();
        }

        private void UpdateSkillLore2(Character thisChar)
        {
            progressBar_Lore2.Value = (int)thisChar.Lore2.Prof;
            textBox_Lore2ItemMod.Text = thisChar.Lore2.Item.ToString();
            textBox_Lore2ProfMod.Text = thisChar.Lore2.Prof.ToString();
            label_Lore2ASMod.Text = thisChar.Lore2.AbilityScoreValue.ToString();
            label_Lore2.Text = thisChar.Lore2.Value.ToString();
            textBox_Lore2SubType.Text = thisChar.Lore2.SubType.ToString();
        }

        private void UpdateSkillMedicine(Character thisChar)
        {
            progressBar_Medicine.Value = (int)thisChar.Medicine.Prof;
            textBox_MedicineItemMod.Text = thisChar.Medicine.Item.ToString();
            textBox_MedicineProfMod.Text = thisChar.Medicine.Prof.ToString();
            label_MedicineASMod.Text = thisChar.Medicine.AbilityScoreValue.ToString();
            label_Medicine.Text = thisChar.Medicine.Value.ToString();
        }

        private void UpdateSkillNature(Character thisChar)
        {
            progressBar_Nature.Value = (int)thisChar.Nature.Prof;
            textBox_NatureItemMod.Text = thisChar.Nature.Item.ToString();
            textBox_NatureProfMod.Text = thisChar.Nature.Prof.ToString();
            label_NatureASMod.Text = thisChar.Nature.AbilityScoreValue.ToString();
            label_Nature.Text = thisChar.Nature.Value.ToString();
        }

        private void UpdateSkillOccultism(Character thisChar)
        {
            progressBar_Occultism.Value = (int)thisChar.Occultism.Prof;
            textBox_OccultismItemMod.Text = thisChar.Occultism.Item.ToString();
            textBox_OccultismProfMod.Text = thisChar.Occultism.Prof.ToString();
            label_OccultismASMod.Text = thisChar.Occultism.AbilityScoreValue.ToString();
            label_Occultism.Text = thisChar.Occultism.Value.ToString();
        }

        private void UpdateSkillPerformance(Character thisChar)
        {
            progressBar_Performance.Value = (int)thisChar.Performance.Prof;
            textBox_PerformanceItemMod.Text = thisChar.Performance.Item.ToString();
            textBox_PerformanceProfMod.Text = thisChar.Performance.Prof.ToString();
            label_PerformanceASMod.Text = thisChar.Performance.AbilityScoreValue.ToString();
            label_Performance.Text = thisChar.Performance.Value.ToString();
        }

        private void UpdateSkillReligion(Character thisChar)
        {
            progressBar_Religion.Value = (int)thisChar.Religion.Prof;
            textBox_ReligionItemMod.Text = thisChar.Religion.Item.ToString();
            textBox_ReligionProfMod.Text = thisChar.Religion.Prof.ToString();
            label_ReligionASMod.Text = thisChar.Religion.AbilityScoreValue.ToString();
            label_Religion.Text = thisChar.Religion.Value.ToString();
        }

        private void UpdateSkillSociety(Character thisChar)
        {
            progressBar_Society.Value = (int)thisChar.Society.Prof;
            textBox_SocietyItemMod.Text = thisChar.Society.Item.ToString();
            textBox_SocietyProfMod.Text = thisChar.Society.Prof.ToString();
            label_SocietyASMod.Text = thisChar.Society.AbilityScoreValue.ToString();
            label_Society.Text = thisChar.Society.Value.ToString();
        }

        private void UpdateSkillStealth(Character thisChar)
        {
            progressBar_Stealth.Value = (int)thisChar.Stealth.Prof;
            textBox_StealthItemMod.Text = thisChar.Stealth.Item.ToString();
            textBox_StealthProfMod.Text = thisChar.Stealth.Prof.ToString();
            label_StealthASMod.Text = thisChar.Stealth.AbilityScoreValue.ToString();
            label_Stealth.Text = thisChar.Stealth.Value.ToString();
            textBox_StealthArmorMod.Text = thisChar.Stealth.ArmorMod.ToString();
        }

        private void UpdateSkillSurvival(Character thisChar)
        {
            progressBar_Survival.Value = (int)thisChar.Survival.Prof;
            textBox_SurvivalItemMod.Text = thisChar.Survival.Item.ToString();
            textBox_SurvivalProfMod.Text = thisChar.Survival.Prof.ToString();
            label_SurvivalASMod.Text = thisChar.Survival.AbilityScoreValue.ToString();
            label_Survival.Text = thisChar.Survival.Value.ToString();
        }

        private void UpdateSkillThievery(Character thisChar)
        {
            progressBar_Thievery.Value = (int)thisChar.Thievery.Prof;
            textBox_ThieveryItemMod.Text = thisChar.Thievery.Item.ToString();
            textBox_ThieveryProfMod.Text = thisChar.Thievery.Prof.ToString();
            label_ThieveryASMod.Text = thisChar.Thievery.AbilityScoreValue.ToString();
            label_Thievery.Text = thisChar.Thievery.Value.ToString();
            textBox_ThieveryArmorMod.Text = thisChar.Thievery.ArmorMod.ToString();
        }

        private void UpdateSheetSkills(Character thisChar)
        {
            UpdateSkillAcrobatics(thisChar);
            UpdateSkillArcana(thisChar);
            UpdateSkillAthletics(thisChar);
            UpdateSkillCrafting(thisChar);
            UpdateSkillDeception(thisChar);
            UpdateSkillDiplomacy(thisChar);
            UpdateSkillIntimidation(thisChar);
            UpdateSkillLore1(thisChar);
            UpdateSkillLore2(thisChar);
            UpdateSkillMedicine(thisChar);
            UpdateSkillNature(thisChar);
            UpdateSkillOccultism(thisChar);
            UpdateSkillPerformance(thisChar);
            UpdateSkillReligion(thisChar);
            UpdateSkillSociety(thisChar);
            UpdateSkillStealth(thisChar);
            UpdateSkillSurvival(thisChar);
            UpdateSkillThievery(thisChar);
        }

        // TODO - Complete update language section
        private void UpdateSheetLanguages(Character thisChar)
        {

        }

        private void UpdateSheetAllValues(Character thisChar)
        {
            //TODO - Copy all values in thisChar to the corrisponding values in the Character Sheet

            UpdateSheetHeader(thisChar);
            UpdateSheetAbilityScores(thisChar);
            UpdateSheetClassDC(thisChar);
            UpdateSheetAC(thisChar);
            UpdateSheetSavingThrows(thisChar);
            UpdateSheetHitPoints(thisChar);
            UpdateSheetPerception(thisChar);
            UpdateSheetSpeed(thisChar);
            UpdateSheetMeleeStrikes(thisChar);
            UpdateSheetRangedStrikes(thisChar);
            UpdateSheetWeaponProf(thisChar);
            UpdateSheetSkills(thisChar);
            UpdateSheetLanguages(thisChar);

            // Unassigned
            /*
            button_AddResistanceImmunity;
            button_AddCondition;
            button_AddSense;
            textBox_Notes;
            button_AddMovement;

            */

            /*

        button1;
        radioButton1;
        groupBox1;
        radioButton2;
        radioButton4;
        groupBox2;
        radioButton3;
        radioButton5;
        radioButton6;
        groupBox3;
        radioButton7;
        radioButton8;
        radioButton9;
        groupBox4;
        radioButton10;
        radioButton11;
        radioButton12;
        groupBox5;
        radioButton13;
        radioButton14;
        radioButton15;
        groupBox6;
        radioButton16;
        radioButton17;
        radioButton18;
        textBox_Melee1Name;
        textBox_Melee2Name;
        textBox_Melee3Name;
        textBox_Ranged1Name;
        textBox_Ranged2Name;
        textBox_Ranged3Name;
        label_Melee1Accuracy;
        label_Melee1AB1;
        textBox_Melee1Prof;
        textBox_Melee1Item;
        textBox_Melee1Dice;
        label_Melee1AB2;
        textBox_Melee1WSpec;
        textBox_Melee1Other;
        textBox12;
        textBox13;
        textBox_Melee2Other;
        textBox_Melee2WSpec;
        label_Melee2AB2;
        textBox_Melee2Dice;
        textBox_Melee2Item;
        textBox_Melee2Prof;
        label_Melee2AB1;
        label_Melee2Accuracy;
        textBox19;
        textBox_Melee3Other;
        textBox_Melee3WSpec;
        label_Melee3AB2;
        textBox_Melee3Dice;
        textBox_Melee3Item;
        textBox_Melee3Prof;
        label_Melee3AB1;
        label_Melee3Accuracy;
        label_Ranged1Accuracy;
        textBox_Ranged1Traits;
        textBox_Ranged1Other;
        textBox_Ranged1WSpec;
        textBox_Ranged1Dice;
        textBox_Ranged1Item;
        textBox_Ranged1Prof;
        label_Ranged1AB;
        textBox_Ranged1Special;
        textBox_Ranged2Special;
        textBox_Ranged2Traits;
        textBox_Ranged2Other;
        textBox_Ranged2WSpec;
        textBox_Ranged2Dice;
        textBox_Ranged2Item;
        textBox_Ranged2Prof;
        label_Ranged2AB;
        label_Ranged2Accuracy;
        textBox_Ranged3Special;
        textBox_Ranged3Traits;
        textBox_Ranged3Other;
        textBox_Ranged3WSpec;
        textBox_Ranged3Dice;
        textBox_Ranged3Item;
        textBox_Ranged3Prof;
        label_Ranged3AB;
        label_Ranged3Accuracy;
        textBox46;
        textBox47;
        textBox_Size;
        numericUpDown_xpCurrent;
        numericUpDown_xpMax;
        numericUpDown_level;
        numericUpDown_heroPoints;
        numericUpDown_strScore;
        numericUpDown_dexScore;
        numericUpDown_conScore;
        numericUpDown_intScore;
        numericUpDown_wisScore;
        numericUpDown_chaScore;
        listBox_ResistAndImmune;
        listBox_Conditions;
        listBox_Senses;
        listBox_Movement;
        textBox_NotesMovement;
        button_NewCharacter;
            */
        }

        private void NewCharacter()
        {
            // TODO - Ask user to save current character

            // Create a new character object
            currentChar = new Character();
        }

        private void label_Diplomacy_Click(object sender, EventArgs e)
        {

        }
    }
}
