﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Collections.Generic;

namespace PathFinder_2e_CharacterSheet
{
    public partial class Form1 : Form
    {
        public Character currentChar = new Character();

        // Database variables
        public string provider;
        public string connectionString;
        
        public Form1()
        {
            InitializeComponent();
        }

        public string LoadConnectionString(string id = "Default")
        {
            connectionString = ConfigurationManager.ConnectionStrings[id].ConnectionString;
            return connectionString;
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

        private void UpdateSheetAcrobatics(Character thisChar)
        {
            progressBar_Acrobatics.Value = (int)thisChar.Acrobatics.Prof;
            label_Acrobatics.Text = thisChar.Acrobatics.Value.ToString();
            label_AcrobaticsASMod.Text = thisChar.Acrobatics.AbilityScoreValue.ToString();
            textBox_AcrobaticsProfMod.Text = thisChar.Acrobatics.Prof.ToString();
            textBox_AcrobaticsItemMod.Text = thisChar.Acrobatics.Item.ToString();
            textBox_AcrobaticsArmorMod.Text = thisChar.Acrobatics.ArmorMod.ToString();
        }

        private void UpdateSheetArcana(Character thisChar)
        {
            progressBar_Arcana.Value = (int)thisChar.Arcana.Prof;
            textBox_ArcanaItemMod.Text = thisChar.Arcana.Item.ToString();
            textBox_ArcanaProfMod.Text = thisChar.Arcana.Prof.ToString();
            label_ArcanaASMod.Text = thisChar.Acrobatics.AbilityScoreValue.ToString();
            label_Arcana.Text = thisChar.Arcana.Value.ToString();
        }

        private void UpdateSheetAthletics(Character thisChar)
        {
            progressBar_Athletics.Value = (int)thisChar.Athletics.Prof;
            textBox_AthleticsArmorMod.Text = thisChar.Athletics.ArmorMod.ToString();
            textBox_AthleticsItemMod.Text = thisChar.Athletics.Item.ToString();
            textBox_AthleticsProfMod.Text = thisChar.Athletics.Prof.ToString();
            label_AthleticsASMod.Text = thisChar.Athletics.AbilityScoreValue.ToString();
            label_Athletics.Text = thisChar.Athletics.Value.ToString();
        }

        private void UpdateSheetCrafting(Character thisChar)
        {
            progressBar_Crafting.Value = (int)thisChar.Crafting.Prof;
            textBox_CraftingItemMod.Text = thisChar.Crafting.Item.ToString();
            textBox_CraftingProfMod.Text = thisChar.Crafting.Prof.ToString();
            label_CraftingASMod.Text = thisChar.Crafting.AbilityScoreValue.ToString();
            label_Crafting.Text = thisChar.Crafting.Value.ToString();
        }

        private void UpdateSheetDeception(Character thisChar) 
        {
            label_Deception.Text = thisChar.Deception.Value.ToString();
            progressBar_Deception.Value = (int)thisChar.Deception.Prof;
            textBox_DeceptionItemMod.Text = thisChar.Deception.Item.ToString();
            textBox_DeceptionProfMod.Text = thisChar.Deception.Prof.ToString();
            label_DeceptionASMod.Text = thisChar.Deception.AbilityScoreValue.ToString();
        }

        private void UpdateSheetDiplomacy(Character thisChar)
        {
            progressBar_Diplomacy.Value = (int)thisChar.Diplomacy.Prof;
            textBox_DiplomacyItemMod.Text = thisChar.Diplomacy.Item.ToString();
            textBox_DiplomacyProfMod.Text = thisChar.Diplomacy.Prof.ToString();
            label_DiplomacyASMod.Text = thisChar.Diplomacy.AbilityScoreValue.ToString();
            label_Diplomacy.Text = thisChar.Diplomacy.Value.ToString();
        }

        private void UpdateSheetIntimidation(Character thisChar)
        {
            progressBar_Intimidation.Value = (int)thisChar.Intimidation.Prof;
            textBox_IntimidationItemMod.Text = thisChar.Intimidation.Item.ToString();
            textBox_IntimidationProfMod.Text = thisChar.Intimidation.Prof.ToString();
            label_IntimidationASMod.Text = thisChar.Intimidation.AbilityScoreValue.ToString();
            label_Intimidation.Text = thisChar.Intimidation.Value.ToString();
        }

        private void UpdateSheetLore1(Character thisChar)
        {
            progressBar_Lore1.Value = (int)thisChar.Lore1.Prof;
            textBox_Lore1ItemMod.Text = thisChar.Lore1.Item.ToString();
            textBox_Lore1ProfMod.Text = thisChar.Lore1.Prof.ToString();
            label_Lore1ASMod.Text = thisChar.Lore1.AbilityScoreValue.ToString();
            label_Lore1.Text = thisChar.Lore1.Value.ToString(); ;
            textBox_Lore1SubType.Text = thisChar.Lore1.SubType.ToString();
        }

        private void UpdateSheetLore2(Character thisChar)
        {
            progressBar_Lore2.Value = (int)thisChar.Lore2.Prof;
            textBox_Lore2ItemMod.Text = thisChar.Lore2.Item.ToString();
            textBox_Lore2ProfMod.Text = thisChar.Lore2.Prof.ToString();
            label_Lore2ASMod.Text = thisChar.Lore2.AbilityScoreValue.ToString();
            label_Lore2.Text = thisChar.Lore2.Value.ToString();
            textBox_Lore2SubType.Text = thisChar.Lore2.SubType.ToString();
        }

        private void UpdateSheetMedicine(Character thisChar)
        {
            progressBar_Medicine.Value = (int)thisChar.Medicine.Prof;
            textBox_MedicineItemMod.Text = thisChar.Medicine.Item.ToString();
            textBox_MedicineProfMod.Text = thisChar.Medicine.Prof.ToString();
            label_MedicineASMod.Text = thisChar.Medicine.AbilityScoreValue.ToString();
            label_Medicine.Text = thisChar.Medicine.Value.ToString();
        }

        private void UpdateSheetNature(Character thisChar)
        {
            progressBar_Nature.Value = (int)thisChar.Nature.Prof;
            textBox_NatureItemMod.Text = thisChar.Nature.Item.ToString();
            textBox_NatureProfMod.Text = thisChar.Nature.Prof.ToString();
            label_NatureASMod.Text = thisChar.Nature.AbilityScoreValue.ToString();
            label_Nature.Text = thisChar.Nature.Value.ToString();
        }

        private void UpdateSheetOccultism(Character thisChar)
        {
            progressBar_Occultism.Value = (int)thisChar.Occultism.Prof;
            textBox_OccultismItemMod.Text = thisChar.Occultism.Item.ToString();
            textBox_OccultismProfMod.Text = thisChar.Occultism.Prof.ToString();
            label_OccultismASMod.Text = thisChar.Occultism.AbilityScoreValue.ToString();
            label_Occultism.Text = thisChar.Occultism.Value.ToString();
        }

        private void UpdateSheetPerformance(Character thisChar)
        {
            progressBar_Performance.Value = (int)thisChar.Performance.Prof;
            textBox_PerformanceItemMod.Text = thisChar.Performance.Item.ToString();
            textBox_PerformanceProfMod.Text = thisChar.Performance.Prof.ToString();
            label_PerformanceASMod.Text = thisChar.Performance.AbilityScoreValue.ToString();
            label_Performance.Text = thisChar.Performance.Value.ToString();
        }

        private void UpdateSheetReligion(Character thisChar)
        {
            progressBar_Religion.Value = (int)thisChar.Religion.Prof;
            textBox_ReligionItemMod.Text = thisChar.Religion.Item.ToString();
            textBox_ReligionProfMod.Text = thisChar.Religion.Prof.ToString();
            label_ReligionASMod.Text = thisChar.Religion.AbilityScoreValue.ToString();
            label_Religion.Text = thisChar.Religion.Value.ToString();
        }

        private void UpdateSheetSociety(Character thisChar)
        {
            progressBar_Society.Value = (int)thisChar.Society.Prof;
            textBox_SocietyItemMod.Text = thisChar.Society.Item.ToString();
            textBox_SocietyProfMod.Text = thisChar.Society.Prof.ToString();
            label_SocietyASMod.Text = thisChar.Society.AbilityScoreValue.ToString();
            label_Society.Text = thisChar.Society.Value.ToString();
        }

        private void UpdateSheetStealth(Character thisChar)
        {
            progressBar_Stealth.Value = (int)thisChar.Stealth.Prof;
            textBox_StealthItemMod.Text = thisChar.Stealth.Item.ToString();
            textBox_StealthProfMod.Text = thisChar.Stealth.Prof.ToString();
            label_StealthASMod.Text = thisChar.Stealth.AbilityScoreValue.ToString();
            label_Stealth.Text = thisChar.Stealth.Value.ToString();
            textBox_StealthArmorMod.Text = thisChar.Stealth.ArmorMod.ToString();
        }

        private void UpdateSheetSurvival(Character thisChar)
        {
            progressBar_Survival.Value = (int)thisChar.Survival.Prof;
            textBox_SurvivalItemMod.Text = thisChar.Survival.Item.ToString();
            textBox_SurvivalProfMod.Text = thisChar.Survival.Prof.ToString();
            label_SurvivalASMod.Text = thisChar.Survival.AbilityScoreValue.ToString();
            label_Survival.Text = thisChar.Survival.Value.ToString();
        }

        private void UpdateSheetThievery(Character thisChar)
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
            UpdateSheetAcrobatics(thisChar);
            UpdateSheetArcana(thisChar);
            UpdateSheetAthletics(thisChar);
            UpdateSheetCrafting(thisChar);
            UpdateSheetDeception(thisChar);
            UpdateSheetDiplomacy(thisChar);
            UpdateSheetIntimidation(thisChar);
            UpdateSheetLore1(thisChar);
            UpdateSheetLore2(thisChar);
            UpdateSheetMedicine(thisChar);
            UpdateSheetNature(thisChar);
            UpdateSheetOccultism(thisChar);
            UpdateSheetPerformance(thisChar);
            UpdateSheetReligion(thisChar);
            UpdateSheetSociety(thisChar);
            UpdateSheetStealth(thisChar);
            UpdateSheetSurvival(thisChar);
            UpdateSheetThievery(thisChar);
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

        private void UpdateCharacterFromSheet(Character thisChar)
        {
            // Assuming 'textBox_PlayerName', 'textBox_CharacterName', etc., are your input controls
            thisChar.PlayerName = textBox_PlayerName.Text;
            thisChar.CharacterName = textBox_CharacterName.Text;
            thisChar.Deity = comboBox_Deity.Text;
            thisChar.Alignment = comboBox_Alignment.Text;
            thisChar.Background = comboBox_Background.Text;

            // Abilities
            thisChar.DexMod = Convert.ToInt32(label_DexMod.Text);
            thisChar.ConMod = Convert.ToInt32(label_ConMod.Text);
            thisChar.IntMod = Convert.ToInt32(label_IntMod.Text);
            thisChar.WisMod = Convert.ToInt32(label_WisMod.Text);
            thisChar.ChaMod = Convert.ToInt32(label_ChaMod.Text);
            thisChar.StrMod = Convert.ToInt32(label_StrMod.Text);

            // Class DC
            thisChar.Dc = Convert.ToInt32(label_DC.Text);
            thisChar.DcProf = (Proficiency)progressBar_ClassDC.Value;
            thisChar.DcKey = Convert.ToInt32(textBox_DCKey.Text);
            thisChar.DcItem = Convert.ToInt32(textBox_DCItem.Text);

            // AC
            thisChar.Ac = Convert.ToInt32(label_AC.Text);
            thisChar.UnarmoredProf = (Proficiency)progressBar_Unarmored.Value;
            thisChar.LightProf = (Proficiency)progressBar_Light.Value;
            thisChar.MediumProf = (Proficiency)progressBar_Medium.Value;
            thisChar.HeavyProf = (Proficiency)progressBar_Heavy.Value;
            thisChar.AcProf = (Proficiency)progressBar_ArmorClass.Value;
            thisChar.DexMod = Convert.ToInt32(textBox_ACDex.Text);
            thisChar.AcItem = Convert.ToInt32(textBox_ACItem.Text);

            // Saving Throws
                // Fortitude
            thisChar.FortitudeProf = (Proficiency)progressBar_Fortitude.Value;
            thisChar.Fortitude = Convert.ToInt32(label_Fortitude.Text);
            thisChar.FortitudeItem = Convert.ToInt32(textBox_FortitudeItem.Text);
                // Reflex
            thisChar.ReflexProf = (Proficiency)progressBar_Reflex.Value;
            thisChar.Reflex = Convert.ToInt32(label_Reflex.Text);
            thisChar.ReflexItem = Convert.ToInt32(textBox_ReflexItem.Text);
                // Will
            thisChar.WillProf = (Proficiency)progressBar_Will.Value;
            thisChar.Will = Convert.ToInt32(label_Will.Text);
            thisChar.WillItem = Convert.ToInt32(textBox_WillItem.Text);

            // HP
            thisChar.MaxHP = Convert.ToInt32(textBox_HitPointsMax.Text);
            thisChar.CurrentHP = Convert.ToInt32(textBox_HitPointsCurrent.Text);
            thisChar.TemporaryHP = Convert.ToInt32(textBox_HitPointsTemp.Text);

            // Perception
            thisChar.PerceptionProf = (Proficiency)progressBar_Perception.Value;
            thisChar.Perception = Convert.ToInt32(label_Perception.Text);
            thisChar.PerceptionItem = Convert.ToInt32(textBox_PerceptionItem.Text);

            // Speed
            thisChar.Speed = Convert.ToInt32(textBox_Speed.Text);

            // Melee
            thisChar.Melee1Prof = (Proficiency)progressBar_Melee1.Value;
            thisChar.Melee2Prof = (Proficiency)progressBar_Melee2.Value;
            thisChar.Melee3Prof = (Proficiency)progressBar_Melee3.Value;

            // Ranged
            thisChar.Ranged1Prof = (Proficiency)progressBar_Ranged1.Value;
            thisChar.Ranged2Prof = (Proficiency)progressBar_Ranged2.Value;
            thisChar.Ranged3Prof = (Proficiency)progressBar_Ranged3.Value;

            // Weapon Prof
            thisChar.SimpleWeaponProf = (Proficiency)progressBar_WeaponSimple.Value;
            thisChar.MartialWeaponProf = (Proficiency)progressBar_WeaponMartial.Value;
            thisChar.OtherWeaponProf1 = (Proficiency)progressBar_WeaponOther1.Value;
            thisChar.OtherWeaponProf2 = (Proficiency)progressBar_WeaponOther2.Value;

            // Skills
            UpdateCharacterSkillsFromSheet(thisChar);
        }

        private void UpdateCharacterSkillsFromSheet(Character thisChar)
        {
            // Update skills individually, similar to the update methods
            UpdateCharacterAcrobaticsFromSheet(thisChar);
            UpdateCharacterArcanaFromSheet(thisChar);
            UpdateCharacterAthleticsFromSheet(thisChar);
            UpdateCharacterCraftingFromSheet(thisChar);
            UpdateCharacterDeceptionFromSheet(thisChar);
            UpdateCharacterDiplomacyFromSheet(thisChar);
            UpdateCharacterIntimidationFromSheet(thisChar);
            UpdateCharacterLore1FromSheet(thisChar);
            UpdateCharacterLore2FromSheet(thisChar);
            UpdateCharacterMedicineFromSheet(thisChar);
            UpdateCharacterNatureFromSheet(thisChar);
            UpdateCharacterOccultismFromSheet(thisChar);
            UpdateCharacterPerformanceFromSheet(thisChar);
            UpdateCharacterReligionFromSheet(thisChar);
            UpdateCharacterSocietyFromSheet(thisChar);
            UpdateCharacterStealthFromSheet(thisChar);
            UpdateCharacterSurvivalFromSheet(thisChar);
            UpdateCharacterThieveryFromSheet(thisChar);
        }

        private void UpdateCharacterAcrobaticsFromSheet(Character thisChar)
        {
            thisChar.Acrobatics.Prof = (Proficiency)progressBar_Acrobatics.Value;
            thisChar.Acrobatics.Value = Convert.ToInt32(label_Acrobatics.Text);
            thisChar.Acrobatics.AbilityScoreValue = Convert.ToInt32(label_AcrobaticsASMod.Text);
            thisChar.Acrobatics.Prof = (Proficiency)Convert.ToInt32(textBox_AcrobaticsProfMod.Text);
            thisChar.Acrobatics.Item = Convert.ToInt32(textBox_AcrobaticsItemMod.Text);
            thisChar.Acrobatics.ArmorMod = Convert.ToInt32(textBox_AcrobaticsArmorMod.Text);
        }

        // Arcana
        private void UpdateCharacterArcanaFromSheet(Character thisChar)
        {
            thisChar.Arcana.Prof = (Proficiency)progressBar_Arcana.Value;
            thisChar.Arcana.Value = Convert.ToInt32(label_Arcana.Text);
            thisChar.Arcana.AbilityScoreValue = Convert.ToInt32(label_ArcanaASMod.Text);
            thisChar.Arcana.Prof = (Proficiency)Convert.ToInt32(textBox_ArcanaProfMod.Text);
            thisChar.Arcana.Item = Convert.ToInt32(textBox_ArcanaItemMod.Text);
        }

        // Athletics
        private void UpdateCharacterAthleticsFromSheet(Character thisChar)
        {
            thisChar.Athletics.Prof = (Proficiency)progressBar_Athletics.Value;
            thisChar.Athletics.Value = Convert.ToInt32(label_Athletics.Text);
            thisChar.Athletics.AbilityScoreValue = Convert.ToInt32(label_AthleticsASMod.Text);
            thisChar.Athletics.Prof = (Proficiency)Convert.ToInt32(textBox_AthleticsProfMod.Text);
            thisChar.Athletics.Item = Convert.ToInt32(textBox_AthleticsItemMod.Text);
            thisChar.Athletics.ArmorMod = Convert.ToInt32(textBox_AthleticsArmorMod.Text);
        }

        // Crafting
        private void UpdateCharacterCraftingFromSheet(Character thisChar)
        {
            thisChar.Crafting.Prof = (Proficiency)progressBar_Crafting.Value;
            thisChar.Crafting.Value = Convert.ToInt32(label_Crafting.Text);
            thisChar.Crafting.AbilityScoreValue = Convert.ToInt32(label_CraftingASMod.Text);
            thisChar.Crafting.Prof = (Proficiency)Convert.ToInt32(textBox_CraftingProfMod.Text);
            thisChar.Crafting.Item = Convert.ToInt32(textBox_CraftingItemMod.Text);
        }

        // Deception
        private void UpdateCharacterDeceptionFromSheet(Character thisChar)
        {
            thisChar.Deception.Value = Convert.ToInt32(label_Deception.Text);
            thisChar.Deception.Prof = (Proficiency)progressBar_Deception.Value;
            thisChar.Deception.Item = Convert.ToInt32(textBox_DeceptionItemMod.Text);
            thisChar.Deception.Prof = (Proficiency)Convert.ToInt32(textBox_DeceptionProfMod.Text);
            thisChar.Deception.AbilityScoreValue = Convert.ToInt32(label_DeceptionASMod.Text);
        }

        // Diplomacy
        private void UpdateCharacterDiplomacyFromSheet(Character thisChar)
        {
            thisChar.Diplomacy.Prof = (Proficiency)progressBar_Diplomacy.Value;
            thisChar.Diplomacy.Item = Convert.ToInt32(textBox_DiplomacyItemMod.Text);
            thisChar.Diplomacy.Prof = (Proficiency)Convert.ToInt32(textBox_DiplomacyProfMod.Text);
            thisChar.Diplomacy.AbilityScoreValue = Convert.ToInt32(label_DiplomacyASMod.Text);
            thisChar.Diplomacy.Value = Convert.ToInt32(label_Diplomacy.Text);
        }

        // Intimidation
        private void UpdateCharacterIntimidationFromSheet(Character thisChar)
        {
            thisChar.Intimidation.Prof = (Proficiency)progressBar_Intimidation.Value;
            thisChar.Intimidation.Item = Convert.ToInt32(textBox_IntimidationItemMod.Text);
            thisChar.Intimidation.Prof = (Proficiency)Convert.ToInt32(textBox_IntimidationProfMod.Text);
            thisChar.Intimidation.AbilityScoreValue = Convert.ToInt32(label_IntimidationASMod.Text);
            thisChar.Intimidation.Value = Convert.ToInt32(label_Intimidation.Text);
        }

        // Lore1
        private void UpdateCharacterLore1FromSheet(Character thisChar)
        {
            thisChar.Lore1.Prof = (Proficiency)progressBar_Lore1.Value;
            thisChar.Lore1.Item = Convert.ToInt32(textBox_Lore1ItemMod.Text);
            thisChar.Lore1.Prof = (Proficiency)Convert.ToInt32(textBox_Lore1ProfMod.Text);
            thisChar.Lore1.AbilityScoreValue = Convert.ToInt32(label_Lore1ASMod.Text);
            thisChar.Lore1.Value = Convert.ToInt32(label_Lore1.Text);
            thisChar.Lore1.SubType = textBox_Lore1SubType.Text;
        }

        // Lore2
        private void UpdateCharacterLore2FromSheet(Character thisChar)
        {
            thisChar.Lore2.Prof = (Proficiency)progressBar_Lore2.Value;
            thisChar.Lore2.Item = Convert.ToInt32(textBox_Lore2ItemMod.Text);
            thisChar.Lore2.Prof = (Proficiency)Convert.ToInt32(textBox_Lore2ProfMod.Text);
            thisChar.Lore2.AbilityScoreValue = Convert.ToInt32(label_Lore2ASMod.Text);
            thisChar.Lore2.Value = Convert.ToInt32(label_Lore2.Text);
            thisChar.Lore2.SubType = textBox_Lore2SubType.Text;
        }

        // Medicine
        private void UpdateCharacterMedicineFromSheet(Character thisChar)
        {
            thisChar.Medicine.Prof = (Proficiency)progressBar_Medicine.Value;
            thisChar.Medicine.Item = Convert.ToInt32(textBox_MedicineItemMod.Text);
            thisChar.Medicine.Prof = (Proficiency)Convert.ToInt32(textBox_MedicineProfMod.Text);
            thisChar.Medicine.AbilityScoreValue = Convert.ToInt32(label_MedicineASMod.Text);
            thisChar.Medicine.Value = Convert.ToInt32(label_Medicine.Text);
        }

        // Nature
        private void UpdateCharacterNatureFromSheet(Character thisChar)
        {
            thisChar.Nature.Prof = (Proficiency)progressBar_Nature.Value;
            thisChar.Nature.Item = Convert.ToInt32(textBox_NatureItemMod.Text);
            thisChar.Nature.Prof = (Proficiency)Convert.ToInt32(textBox_NatureProfMod.Text);
            thisChar.Nature.AbilityScoreValue = Convert.ToInt32(label_NatureASMod.Text);
            thisChar.Nature.Value = Convert.ToInt32(label_Nature.Text);
        }

        // Occultism
        private void UpdateCharacterOccultismFromSheet(Character thisChar)
        {
            thisChar.Occultism.Prof = (Proficiency)progressBar_Occultism.Value;
            thisChar.Occultism.Item = Convert.ToInt32(textBox_OccultismItemMod.Text);
            thisChar.Occultism.Prof = (Proficiency)Convert.ToInt32(textBox_OccultismProfMod.Text);
            thisChar.Occultism.AbilityScoreValue = Convert.ToInt32(label_OccultismASMod.Text);
            thisChar.Occultism.Value = Convert.ToInt32(label_Occultism.Text);
        }

        // Performance
        private void UpdateCharacterPerformanceFromSheet(Character thisChar)
        {
            thisChar.Performance.Prof = (Proficiency)progressBar_Performance.Value;
            thisChar.Performance.Item = Convert.ToInt32(textBox_PerformanceItemMod.Text);
            thisChar.Performance.Prof = (Proficiency)Convert.ToInt32(textBox_PerformanceProfMod.Text);
            thisChar.Performance.AbilityScoreValue = Convert.ToInt32(label_PerformanceASMod.Text);
            thisChar.Performance.Value = Convert.ToInt32(label_Performance.Text);
        }

        // Religion
        private void UpdateCharacterReligionFromSheet(Character thisChar)
        {
            thisChar.Religion.Prof = (Proficiency)progressBar_Religion.Value;
            thisChar.Religion.Item = Convert.ToInt32(textBox_ReligionItemMod.Text);
            thisChar.Religion.Prof = (Proficiency)Convert.ToInt32(textBox_ReligionProfMod.Text);
            thisChar.Religion.AbilityScoreValue = Convert.ToInt32(label_ReligionASMod.Text);
            thisChar.Religion.Value = Convert.ToInt32(label_Religion.Text);
        }

        // Society
        private void UpdateCharacterSocietyFromSheet(Character thisChar)
        {
            thisChar.Society.Prof = (Proficiency)progressBar_Society.Value;
            thisChar.Society.Item = Convert.ToInt32(textBox_SocietyItemMod.Text);
            thisChar.Society.Prof = (Proficiency)Convert.ToInt32(textBox_SocietyProfMod.Text);
            thisChar.Society.AbilityScoreValue = Convert.ToInt32(label_SocietyASMod.Text);
            thisChar.Society.Value = Convert.ToInt32(label_Society.Text);
        }

        // Stealth
        private void UpdateCharacterStealthFromSheet(Character thisChar)
        {
            thisChar.Stealth.Prof = (Proficiency)progressBar_Stealth.Value;
            thisChar.Stealth.Item = Convert.ToInt32(textBox_StealthItemMod.Text);
            thisChar.Stealth.Prof = (Proficiency)Convert.ToInt32(textBox_StealthProfMod.Text);
            thisChar.Stealth.AbilityScoreValue = Convert.ToInt32(label_StealthASMod.Text);
            thisChar.Stealth.Value = Convert.ToInt32(label_Stealth.Text);
            thisChar.Stealth.ArmorMod = Convert.ToInt32(textBox_StealthArmorMod.Text);
        }

        // Survival
        private void UpdateCharacterSurvivalFromSheet(Character thisChar)
        {
            thisChar.Survival.Prof = (Proficiency)progressBar_Survival.Value;
            thisChar.Survival.Item = Convert.ToInt32(textBox_SurvivalItemMod.Text);
            thisChar.Survival.Prof = (Proficiency)Convert.ToInt32(textBox_SurvivalProfMod.Text);
            thisChar.Survival.AbilityScoreValue = Convert.ToInt32(label_SurvivalASMod.Text);
            thisChar.Survival.Value = Convert.ToInt32(label_Survival.Text);
        }

        // Thievery
        private void UpdateCharacterThieveryFromSheet(Character thisChar)
        {
            thisChar.Thievery.Prof = (Proficiency)progressBar_Thievery.Value;
            thisChar.Thievery.Item = Convert.ToInt32(textBox_ThieveryItemMod.Text);
            thisChar.Thievery.Prof = (Proficiency)Convert.ToInt32(textBox_ThieveryProfMod.Text);
            thisChar.Thievery.AbilityScoreValue = Convert.ToInt32(label_ThieveryASMod.Text);
            thisChar.Thievery.Value = Convert.ToInt32(label_Thievery.Text);
            thisChar.Thievery.ArmorMod = Convert.ToInt32(textBox_ThieveryArmorMod.Text);
        }

        private void label_Diplomacy_Click(object sender, EventArgs e)
        {

        }

        public void SaveCharacterAsJson(Character thisChar)
        {
            string test = JsonSerializer.Serialize(thisChar);
            Console.WriteLine(test);
            Character character = JsonSerializer.Deserialize<Character>(test);
            Console.WriteLine(character.PlayerName);
        }

        public void LoadCharacterFromJson(string jsonFile)
        {
            
        }

        private void button_SaveCharacter_Click(object sender, EventArgs e)
        {
            UpdateSheetAllValues(currentChar);

            // Open connection, then close when finished
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var sql = String.Format("Insert into Character (PlayerName, CharacterName) values (\"{0}\",\"{1}\")", currentChar.PlayerName, currentChar.CharacterName);
                var executeSQL = cnn.Execute(sql);
            }
        }

        private void button_LoadCharacter_Click(object sender, EventArgs e)
        {
            // Open connection, then close when finished
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var reader = cnn.ExecuteReader("select * from Character;");

                while (reader.Read()) 
                {
                    Console.WriteLine(reader.GetInt32(0));
                    Console.WriteLine(reader.GetValue(1).ToString());
                    Console.WriteLine(LoadConnectionString().ToString());
                }

                reader.Close();
            }
        }

        private void button_NewCharacter_Click(object sender, EventArgs e)
        {
            SaveCharacterAsJson(currentChar);
        }
    }
}
