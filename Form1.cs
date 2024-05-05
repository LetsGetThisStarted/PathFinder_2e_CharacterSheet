using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PathFinder_2e_CharacterSheet
{
    public partial class Form1 : Form
    {
        public Character currentChar = new Character();

        // Database variables
        public string provider;
        public string connectionString;

        // Form variables
        public Dictionary<object, object> pairedObjects = new Dictionary<object, object>();
        private int armorIndex = 0;
        List<ProgressBar> pBarList; 

        public Form1()
        {
            InitializeComponent();
        }

        public string LoadConnectionString(string id = "Default")
        {
            connectionString = ConfigurationManager.ConnectionStrings[id].ConnectionString;
            return connectionString;
        }

        /// <summary>
        /// Initialize all items needed to link items on the form
        /// </summary>
        private void LinkProgressBars()
        {
            pairedObjects.Add(progressBar_Acrobatics, textBox_AcrobaticsProfMod);
            pairedObjects.Add(progressBar_Arcana, textBox_ArcanaProfMod);
            pairedObjects.Add(progressBar_ArmorClass, textBox_ACProf);
            pairedObjects.Add(progressBar_Athletics, textBox_AthleticsProfMod);
            pairedObjects.Add(progressBar_Crafting, textBox_CraftingProfMod);
            pairedObjects.Add(progressBar_Deception, textBox_DeceptionProfMod);
            pairedObjects.Add(progressBar_Diplomacy, textBox_DiplomacyProfMod);
            pairedObjects.Add(progressBar_Fortitude, textBox_FortitudeProf);
            pairedObjects.Add(progressBar_Intimidation, textBox_IntimidationProfMod);
            pairedObjects.Add(progressBar_Lore1, textBox_Lore1ProfMod);
            pairedObjects.Add(progressBar_Lore2, textBox_Lore2ProfMod);
            pairedObjects.Add(progressBar_Medicine, textBox_MedicineProfMod);
            pairedObjects.Add(progressBar_Melee1, textBox_Melee1Prof);
            pairedObjects.Add(progressBar_Melee2, textBox_Melee2Prof);
            pairedObjects.Add(progressBar_Melee3, textBox_Melee3Prof);
            pairedObjects.Add(progressBar_Nature, textBox_NatureProfMod);
            pairedObjects.Add(progressBar_Occultism, textBox_OccultismProfMod);
            pairedObjects.Add(progressBar_Perception, textBox_PerceptionProf);
            pairedObjects.Add(progressBar_Performance, textBox_PerformanceProfMod);
            pairedObjects.Add(progressBar_Ranged1, textBox_Ranged1Prof);
            pairedObjects.Add(progressBar_Ranged2, textBox_Ranged2Prof);
            pairedObjects.Add(progressBar_Ranged3, textBox_Ranged3Prof);
            pairedObjects.Add(progressBar_Reflex, textBox_ReflexProf);
            pairedObjects.Add(progressBar_Religion, textBox_ReligionProfMod);
            pairedObjects.Add(progressBar_Society, textBox_SocietyProfMod);
            pairedObjects.Add(progressBar_Stealth, textBox_StealthProfMod);
            pairedObjects.Add(progressBar_Survival, textBox_SurvivalProfMod);
            pairedObjects.Add(progressBar_Thievery, textBox_ThieveryProfMod);
            pairedObjects.Add(progressBar_Will, textBox_WillProf);

            // TODO - add all progressbar/textbox connections to 'pairedObjects' dictionary
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LinkProgressBars();
            pBarList = new List<ProgressBar> { progressBar_Unarmored, progressBar_Light, progressBar_Medium, progressBar_Heavy };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar_clicked(object sender, EventArgs e)
        {
            ProgressBar pBar = sender as ProgressBar;
            TextBox tBox;
            Object obj;
            bool pBarPaired;

            if (pBar.Value >= pBar.Maximum)
            {
                pBar.Value = 0;
            }
            else
            {
                pBar.Value += 1;
            }

            pBarPaired = pairedObjects.TryGetValue(pBar, out obj);
            if (!pBarPaired)
            { 
                Console.WriteLine(pBar.Name + " failed to connect to text box");
                return;
            }
            else { tBox = obj as  TextBox; }

            if (pBar.Value > 0) { tBox.Text = "+" + ((pBar.Value * 2) + currentChar.Level).ToString(); }
            else { tBox.Text = "+0"; }

        }

        private void textBox_CharacterName_TextChanged(object sender, EventArgs e)
        {
            UpdateCharacterNameFromSheet(currentChar);
        }

        private void textBox_PlayerName_TextChanged(object sender, EventArgs e)
        {
            UpdatePlayerNameFromSheet(currentChar);
        }

        private void textBox_XPCurrent_TextChanged(object sender, EventArgs e)
        {
            UpdateCurrentXPFromSheet(currentChar);
        }

        private void comboBox_Background_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBackgroundFromSheet(currentChar);
        }

        private void comboBox_Alignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAlignmentFromSheet(currentChar);
        }

        private void comboBox_Deity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateDeityFromSheet(currentChar);
        }

        private void numericUpDown_level_ValueChanged(object sender, EventArgs e)
        {
            UpdateLevelFromSheet(currentChar);
        }

        private void numericUpDown_heroPoints_ValueChanged(object sender, EventArgs e)
        {
            UpdateHeroPointsFromSheet(currentChar);
        }

        private void UpdateSheetHeader(Character thisChar)
        {
            UpdatePlayerNameFromSheet(thisChar);
            UpdateCharacterNameFromSheet(thisChar);
            UpdateDeityFromSheet(thisChar);
            UpdateAlignmentFromSheet(thisChar);
            UpdateBackgroundFromSheet(thisChar);
        }

        private void UpdateSheetAbilityScores(Character thisChar)
        {
            // ability scores
            numericUpDown_dexScore.Value = thisChar.DexScore;
            numericUpDown_conScore.Value = thisChar.ConScore;
            numericUpDown_intScore.Value = thisChar.IntScore;
            numericUpDown_wisScore.Value = thisChar.WisScore;
            numericUpDown_chaScore.Value = thisChar.ChaScore;
            numericUpDown_strScore.Value = thisChar.StrScore;
            
            // ability score modifiers
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

            try
            {
                // Class DC
                thisChar.Dc = Convert.ToInt32(label_DC.Text);
                thisChar.DcProf = (Proficiency)progressBar_ClassDC.Value;
                thisChar.DcKey = Convert.ToInt32(textBox_DCKey.Text);
                thisChar.DcItem = Convert.ToInt32(textBox_DCItem.Text);
            }
            catch { }

            try
            {
                // AC
                thisChar.Ac = Convert.ToInt32(label_AC.Text);
                thisChar.UnarmoredProf = (Proficiency)progressBar_Unarmored.Value;
                thisChar.LightProf = (Proficiency)progressBar_Light.Value;
                thisChar.MediumProf = (Proficiency)progressBar_Medium.Value;
                thisChar.HeavyProf = (Proficiency)progressBar_Heavy.Value;
                thisChar.AcProf = (Proficiency)progressBar_ArmorClass.Value;
                thisChar.DexMod = Convert.ToInt32(textBox_ACDex.Text);
                thisChar.AcItem = Convert.ToInt32(textBox_ACItem.Text);
            }
            catch { }

            try
            {
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
            }
            catch { }

            try
            {
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
            }
            catch { }

            try
            {
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
            }
            catch { }

            try
            {
                // Skills
                UpdateCharacterSkillsFromSheet(thisChar);
            }
            catch { }
        }

        #region Character Update Functions
        #region General
        private void UpdateCharacterNameFromSheet(Character thisChar) { thisChar.CharacterName = textBox_CharacterName.Text; }
        private void UpdatePlayerNameFromSheet(Character thisChar) { thisChar.PlayerName = textBox_PlayerName.Text; }
        private void UpdateCurrentXPFromSheet(Character thisChar) { thisChar.XpCurrent = (int)numericUpDown_xpCurrent.Value; }
        private void UpdateBackgroundFromSheet(Character thisChar) { thisChar.Background = comboBox_Background.Text; }
        private void UpdateAlignmentFromSheet(Character thisChar) { thisChar.Alignment = comboBox_Alignment.Text; }
        private void UpdateDeityFromSheet(Character thisChar) { thisChar.Deity = comboBox_Deity.Text; }
        private void UpdateLevelFromSheet(Character thisChar) { thisChar.Level = (int)numericUpDown_level.Value; }
        private void UpdateHeroPointsFromSheet(Character thisChar) { thisChar.HeroPoints = (int)numericUpDown_heroPoints.Value; }

        #endregion
        #region Skills
        // Acrobatics
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
        #endregion



        #endregion

        #region Update Sheet Skills
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
        #endregion

        private void label_Diplomacy_Click(object sender, EventArgs e)
        {

        }

        public string SaveCharacterAsJson(Character thisChar)
        {
            StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            serializer.Serialize(writer, thisChar);
            string jsonCharacter = writer.ToString();
            Console.WriteLine(jsonCharacter);
            return jsonCharacter;
        }

        public void LoadCharacterFromJson(string jsonFile) 
        {
            
        }

        private void button_SaveCharacter_Click(object sender, EventArgs e)
        {
            // Update character class values
            UpdateCharacterFromSheet(currentChar);

            string jsonCharObj = SaveCharacterAsJson(currentChar);
            Console.WriteLine($"{jsonCharObj}");

            // Open connection, then close when finished
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                Console.WriteLine(cnn.State);
                string query = "Insert into Pathfinder_Character (PlayerName, CharacterName, CharacterObject) values (@playerN, @characterN, @xml)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, cnn))
                {

                    Console.WriteLine(cnn.State);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@playerN", currentChar.PlayerName);
                    cmd.Parameters.AddWithValue("@characterN", currentChar.CharacterName);
                    cmd.Parameters.AddWithValue("@xml", jsonCharObj);
                    var executeSQL = cmd.ExecuteNonQuery();
                    Console.WriteLine(executeSQL.ToString());
                }
                cnn.Close();
            }
        }

        private void button_LoadCharacter_Click(object sender, EventArgs e)
        {
            // Open connection, then close when finished
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var reader = cnn.ExecuteReader("select * from Pathfinder_Character;");

                XmlSerializer serializer = new XmlSerializer(typeof(Character));
                StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
                while (reader.Read()) 
                {
                    Console.WriteLine(reader.GetInt32(0));
                    Console.WriteLine(reader.GetValue(1).ToString());
                    Console.WriteLine(reader.GetValue(2).ToString());
                    var charStr = reader.GetValue(3).ToString();
                    Console.WriteLine(charStr);
                    
                    try
                    {
                        currentChar = Deserialize<Character>(charStr);
                        UpdateSheetAllValues(currentChar);
                    }
                    catch (Exception exception)
                    { 
                        Console.WriteLine(exception.Message);
                    }
                    
                }

                reader.Close();
            }


        }

        private void button_NewCharacter_Click(object sender, EventArgs e)
        {
            SaveCharacterAsJson(currentChar);
        }

        public static T Deserialize<T>(string xml)
        {
            if (String.IsNullOrEmpty(xml)) throw new NotSupportedException("Empty string!!");

            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringReader = new StringReader(xml);
                using (var reader = XmlReader.Create(stringReader))
                {
                    return (T)xmlserializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Converts the raw strength value into the strength modification value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_strScore_ValueChanged(object sender, EventArgs e)
        {
            string value;
            //Update character object strength ability score value and modifier
            currentChar.StrScore = (int)numericUpDown_strScore.Value;
            currentChar.StrMod = ModIntFromASInt(currentChar.StrScore);

            //Create string version of score modifier
            if (currentChar.StrMod >= 0) { value = "+" + currentChar.StrMod.ToString(); }
            else { value = currentChar.StrMod.ToString(); }

            //Update all relavent values that rely on this modification value
            //Direct updates to character sheet
            label_StrMod.Text = value;

            //Calculated updates to character object

            //Calculated updates to character sheet

        }

        /// <summary>
        /// Converts the raw dexterity value into the dexterity modification value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_dexScore_ValueChanged(object sender, EventArgs e)
        {
            string value;
            //Update character object dexterity ability score value and modifier
            currentChar.DexScore = (int)numericUpDown_dexScore.Value;
            currentChar.DexMod = ModIntFromASInt(currentChar.DexScore);

            //Create string version of score modifier
            if (currentChar.DexMod >= 0) { value = "+" + currentChar.DexMod.ToString(); }
            else { value = currentChar.DexMod.ToString(); }

            //Update all relavent values that rely on this modification value
            //Direct updates to character sheet
            label_DexMod.Text = value;
            label_AcrobaticsASMod.Text = value;
            label_AthleticsASMod.Text = value;
            label_StealthASMod.Text = value;
            label_ThieveryASMod.Text = value;

            //Calculated updates to character object

            //Calculated updates to character sheet

        }

        /// <summary>
        /// Converts the raw constitution value into the constitution modification value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_conScore_ValueChanged(object sender, EventArgs e)
        {
            string value;
            //Update character object constitution ability score value and modifier
            currentChar.ConScore = (int)numericUpDown_conScore.Value;
            currentChar.ConMod = ModIntFromASInt(currentChar.ConScore);

            //Create string version of score modifier
            if (currentChar.ConMod >= 0) { value = "+" + currentChar.ConMod.ToString(); }
            else { value = currentChar.ConMod.ToString(); }

            //Update all relavent values that rely on this modification value
            //Direct updates to character sheet
            label_ConMod.Text = value;

            //Calculated updates to character object

            //Calculated updates to character sheet
        }

        /// <summary>
        /// Converts the raw intellegence value into the intellegence modification value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_intScore_ValueChanged(object sender, EventArgs e)
        {
            string value;
            //Update character object intellegence ability score value and modifier
            currentChar.IntScore = (int)numericUpDown_intScore.Value;
            currentChar.IntMod = ModIntFromASInt(currentChar.IntScore);

            //Create string version of score modifier
            if (currentChar.IntMod >= 0) { value = "+" + currentChar.IntMod.ToString(); }
            else { value = currentChar.IntMod.ToString(); }

            //Update all relavent values that rely on this modification value
            //Direct updates to character sheet
            label_IntMod.Text = value;
            label_ArcanaASMod.Text = value;
            label_CraftingASMod.Text = value;
            label_Lore1ASMod.Text = value;
            label_Lore2ASMod.Text = value;
            label_OccultismASMod.Text = value;
            label_SocietyASMod.Text = value;

            //Calculated updates to character object

            //Calculated updates to character sheet

        }

        /// <summary>
        /// Converts the raw wisdom value into the wisdom modification value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_wisScore_ValueChanged(object sender, EventArgs e)
        {
            string value;
            //Update character object wisdom ability score value and modifier
            currentChar.WisScore = (int)numericUpDown_wisScore.Value;
            currentChar.WisMod = ModIntFromASInt(currentChar.WisScore);

            //Create string version of score modifier
            if (currentChar.WisMod >= 0) { value = "+" + currentChar.WisMod.ToString(); }
            else { value = currentChar.WisMod.ToString(); }

            //Update all relavent values that rely on this modification value
            //Direct updates to character sheet
            label_WisMod.Text = value;
            label_MedicineASMod.Text = value;
            label_NatureASMod.Text = value;
            label_ReligionASMod.Text = value;
            label_SurvivalASMod.Text = value;
            
            //Calculated updates to character object

            //Calculated updates to character sheet

        }

        /// <summary>
        /// Converts the raw charisma value into the charisma modification value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_chaScore_ValueChanged(object sender, EventArgs e)
        {
            string value;
            //Update character object charisma ability score value and modifier
            currentChar.ChaScore = (int)numericUpDown_chaScore.Value;
            currentChar.ChaMod = ModIntFromASInt(currentChar.ChaScore);

            //Create string version of score modifier
            if (currentChar.ChaMod >= 0) { value = "+" + currentChar.ChaMod.ToString(); }
            else { value = currentChar.ChaMod.ToString(); }

            //Update all relavent values that rely on this modification value
            //Direct updates to character sheet
            label_ChaMod.Text = value;
            label_DeceptionASMod.Text = value;
            label_DiplomacyASMod.Text = value;
            label_IntimidationASMod.Text = value;
            label_PerformanceASMod.Text = value;
            
            //Calculated updates to character object

            //Calculated updates to character sheet

        }

        private int ModIntFromASInt(int abilityScore)
        {
            int asMod;
            asMod = (int)Math.Floor(((double)abilityScore - 10) / 2);
            return asMod; 
        }

        /// <summary>
        /// Rotates between the different armor professions available. Armor professions not selected are made invisible.
        /// </summary>
        /// <param name="sender">object that sent the event</param>
        /// <param name="e">type of event that was triggered</param>
        private void SelectArmorProf(object sender, EventArgs e)
        {
            ProgressBar progressBar = sender as ProgressBar;
            TextBox tBox;
            Object obj;
            bool pBarPaired;

            pBarList[armorIndex].Visible = false;
            if (armorIndex >= pBarList.Count - 1) { armorIndex = 0; }
            else { armorIndex++; }
            progressBar.Value = pBarList[armorIndex].Value;
            pBarPaired = pairedObjects.TryGetValue(progressBar, out obj);
            if (!pBarPaired)
            {
                Console.WriteLine(progressBar.Name + " failed to connect to text box");
                return;
            }
            else { tBox = obj as TextBox; }

            if (progressBar.Value > 0) { tBox.Text = "+" + ((progressBar.Value * 2) + currentChar.Level).ToString(); }
            else { tBox.Text = "+0"; }

            pBarList[armorIndex].Visible = true;
            
        }
    }
}
