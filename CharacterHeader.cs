﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinder_2e_CharacterSheet
{
    public class Character
    {
        // Main Character Values
        private string characterName;
        private string playerName;
        private int xpCurrent;
        private int xpMax;
        private string ancestry;
        private string background;
        private CharacterClass cClass;
        private string size;
        private string alignment;
        private object traits;
        private string deity;
        private int level;
        private int heroPoints;

        // Ability Scores
        private int strScore;
        private int strMod;
        private int dexScore;
        private int dexMod;
        private int conScore;
        private int conMod;
        private int intScore;
        private int intMod;
        private int wisScore;
        private int wisMod;
        private int chaScore;
        private int chaMod;

        // Class DC
        private int dc;
        private int dcKey;
        private Proficiency dcProf;
        private int dcItem;

        // Armor Class
        private int ac;
        private int acKey;
        private Proficiency acProf;
        private int acItem;
        private Proficiency unarmoredProf;
        private Proficiency lightProf;
        private Proficiency mediumProf;
        private Proficiency heavyProf;
        private int shieldBonus;
        private int shieldHardness;
        private int shieldMaxHP;
        private int shieldBT;
        private int shieldCurrentHP;

        // Saving Throws
        private int fortitude;
        private int fortitudeItem;
        private Proficiency fortitudeProf;
        private int reflex;
        private int reflexItem;
        private Proficiency reflexProf;
        private int will;
        private int willItem;
        private Proficiency willProf;
        private string notesSavingThrows;

        // Hit Points
        private int maxHP;
        private int currentHP;
        private int temporaryHP;
        private object dying;
        private object wounded;
        private object resistAndImmune;
        private object conditions;

        // Perception
        private int perception;
        private int perceptionItem;
        private Proficiency perceptionProf;
        private object senses;

        // Speed
        private int speed;
        private object movementTypes;
        private string notesSpeed;

        // Melee Strikes
        private string melee1Name;
        private int melee1Aim;
        private Proficiency melee1Prof;
        private int melee1Item;
        private object melee1Dice;
        private WeaponType melee1Type;
        private int melee1WSpec;
        private string melee1Other;
        private object melee1Traits;
        private string melee1Notes;

        private string melee2Name;
        private int melee2Aim;
        private Proficiency melee2Prof;
        private int melee2Item;
        private object melee2Dice;
        private WeaponType melee2Type;
        private int melee2WSpec;
        private string melee2Other;
        private object melee2Traits;
        private string melee2Notes;

        private string melee3Name;
        private int melee3Aim;
        private Proficiency melee3Prof;
        private int melee3Item;
        private object melee3Dice;
        private WeaponType melee3Type;
        private int melee3WSpec;
        private string melee3Other;
        private object melee3Traits;
        private string melee3Notes;

        // Ranged Strikes
        private string ranged1Name;
        private int ranged1Aim;
        private Proficiency ranged1Prof;
        private int ranged1Item;
        private object ranged1Dice;
        private string ranged1Special;
        private WeaponType ranged1Type;
        private int ranged1WSpec;
        private string ranged1Other;
        private object ranged1Traits;
        private string ranged1Notes;

        private string ranged2Name;
        private int ranged2Aim;
        private Proficiency ranged2Prof;
        private int ranged2Item;
        private object ranged2Dice;
        private string ranged2Special;
        private WeaponType ranged2Type;
        private int ranged2WSpec;
        private string ranged2Other;
        private object ranged2Traits;
        private string ranged2Notes;

        private string ranged3Name;
        private int ranged3Aim;
        private Proficiency ranged3Prof;
        private int ranged3Item;
        private object ranged3Dice;
        private string ranged3Special;
        private WeaponType ranged3Type;
        private int ranged3WSpec;
        private string ranged3Other;
        private object ranged3Traits;
        private string ranged3Notes;

        // Weapon Proficiencies
        private Proficiency simpleWeaponProf;
        private Proficiency martialWeaponProf;
        private string otherWeaponName1;
        private Proficiency otherWeaponProf1;
        private string otherWeaponName2;
        private Proficiency otherWeaponProf2;

        // Skills
        private Skill acrobatics;
        private Skill arcana;
        private Skill athletics;
        private Skill crafting;
        private Skill deception;
        private Skill diplomacy;
        private Skill intimidation;
        private Skill lore1;
        private Skill lore2;
        private Skill medicine;
        private Skill nature;
        private Skill occultism;
        private Skill performance;
        private Skill religion;
        private Skill society;
        private Skill stealth;
        private Skill survival;
        private Skill thievery;

        // Languages
        private object languages;

        // Getters and Setters - Auto Generated
        public string CharacterName { get => characterName; set => characterName = value; }
        public string PlayerName { get => playerName; set => playerName = value; }
        public int XpCurrent { get => xpCurrent; set => xpCurrent = value; }
        public int XpMax { get => xpMax; set => xpMax = value; }
        public string Ancestry { get => ancestry; set => ancestry = value; }
        public string Background { get => background; set => background = value; }
        public CharacterClass CClass { get => cClass; set => cClass = value; }
        public string Size { get => size; set => size = value; }
        public string Alignment { get => alignment; set => alignment = value; }
        public object Traits { get => traits; set => traits = value; }
        public string Deity { get => deity; set => deity = value; }
        public int Level { get => level; set => level = value; }
        public int HeroPoints { get => heroPoints; set => heroPoints = value; }
        public int StrScore { get => strScore; set => strScore = value; }
        public int StrMod { get => strMod; set => strMod = value; }
        public int DexScore { get => dexScore; set => dexScore = value; }
        public int DexMod { get => dexMod; set => dexMod = value; }
        public int ConScore { get => conScore; set => conScore = value; }
        public int ConMod { get => conMod; set => conMod = value; }
        public int IntScore { get => intScore; set => intScore = value; }
        public int IntMod { get => intMod; set => intMod = value; }
        public int WisScore { get => wisScore; set => wisScore = value; }
        public int WisMod { get => wisMod; set => wisMod = value; }
        public int ChaScore { get => chaScore; set => chaScore = value; }
        public int ChaMod { get => chaMod; set => chaMod = value; }
        public int Dc { get => dc; set => dc = value; }
        public int DcKey { get => dcKey; set => dcKey = value; }
        public int DcItem { get => dcItem; set => dcItem = value; }
        public int Ac { get => ac; set => ac = value; }
        public int AcKey { get => acKey; set => acKey = value; }
        public int AcItem { get => acItem; set => acItem = value; }
        public int ShieldBonus { get => shieldBonus; set => shieldBonus = value; }
        public int ShieldHardness { get => shieldHardness; set => shieldHardness = value; }
        public int ShieldMaxHP { get => shieldMaxHP; set => shieldMaxHP = value; }
        public int ShieldBT { get => shieldBT; set => shieldBT = value; }
        public int ShieldCurrentHP { get => shieldCurrentHP; set => shieldCurrentHP = value; }
        public int Fortitude { get => fortitude; set => fortitude = value; }
        public int FortitudeItem { get => fortitudeItem; set => fortitudeItem = value; }
        public int Reflex { get => reflex; set => reflex = value; }
        public int ReflexItem { get => reflexItem; set => reflexItem = value; }
        public int Will { get => will; set => will = value; }
        public int WillItem { get => willItem; set => willItem = value; }
        public string NotesSavingThrows { get => notesSavingThrows; set => notesSavingThrows = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int CurrentHP { get => currentHP; set => currentHP = value; }
        public int TemporaryHP { get => temporaryHP; set => temporaryHP = value; }
        public object Dying { get => dying; set => dying = value; }
        public object Wounded { get => wounded; set => wounded = value; }
        public object ResistAndImmune { get => resistAndImmune; set => resistAndImmune = value; }
        public object Conditions { get => conditions; set => conditions = value; }
        public int Perception { get => perception; set => perception = value; }
        public int PerceptionItem { get => perceptionItem; set => perceptionItem = value; }
        public object Senses { get => senses; set => senses = value; }
        public int Speed { get => speed; set => speed = value; }
        public object MovementTypes { get => movementTypes; set => movementTypes = value; }
        public string NotesSpeed { get => notesSpeed; set => notesSpeed = value; }
        public string Melee1Name { get => melee1Name; set => melee1Name = value; }
        public int Melee1Aim { get => melee1Aim; set => melee1Aim = value; }
        public int Melee1Item { get => melee1Item; set => melee1Item = value; }
        public object Melee1Dice { get => melee1Dice; set => melee1Dice = value; }
        public int Melee1WSpec { get => melee1WSpec; set => melee1WSpec = value; }
        public string Melee1Other { get => melee1Other; set => melee1Other = value; }
        public object Melee1Traits { get => melee1Traits; set => melee1Traits = value; }
        public string Melee1Notes { get => melee1Notes; set => melee1Notes = value; }
        public string Melee2Name { get => melee2Name; set => melee2Name = value; }
        public int Melee2Aim { get => melee2Aim; set => melee2Aim = value; }
        public int Melee2Item { get => melee2Item; set => melee2Item = value; }
        public object Melee2Dice { get => melee2Dice; set => melee2Dice = value; }
        public int Melee2WSpec { get => melee2WSpec; set => melee2WSpec = value; }
        public string Melee2Other { get => melee2Other; set => melee2Other = value; }
        public object Melee2Traits { get => melee2Traits; set => melee2Traits = value; }
        public string Melee2Notes { get => melee2Notes; set => melee2Notes = value; }
        public string Melee3Name { get => melee3Name; set => melee3Name = value; }
        public int Melee3Aim { get => melee3Aim; set => melee3Aim = value; }
        public int Melee3Item { get => melee3Item; set => melee3Item = value; }
        public object Melee3Dice { get => melee3Dice; set => melee3Dice = value; }
        public int Melee3WSpec { get => melee3WSpec; set => melee3WSpec = value; }
        public string Melee3Other { get => melee3Other; set => melee3Other = value; }
        public object Melee3Traits { get => melee3Traits; set => melee3Traits = value; }
        public string Melee3Notes { get => melee3Notes; set => melee3Notes = value; }
        public string Ranged1Name { get => ranged1Name; set => ranged1Name = value; }
        public int Ranged1Aim { get => ranged1Aim; set => ranged1Aim = value; }
        public int Ranged1Item { get => ranged1Item; set => ranged1Item = value; }
        public object Ranged1Dice { get => ranged1Dice; set => ranged1Dice = value; }
        public string Ranged1Special { get => ranged1Special; set => ranged1Special = value; }
        public int Ranged1WSpec { get => ranged1WSpec; set => ranged1WSpec = value; }
        public string Ranged1Other { get => ranged1Other; set => ranged1Other = value; }
        public object Ranged1Traits { get => ranged1Traits; set => ranged1Traits = value; }
        public string Ranged1Notes { get => ranged1Notes; set => ranged1Notes = value; }
        public string Ranged2Name { get => ranged2Name; set => ranged2Name = value; }
        public int Ranged2Aim { get => ranged2Aim; set => ranged2Aim = value; }
        public int Ranged2Item { get => ranged2Item; set => ranged2Item = value; }
        public object Ranged2Dice { get => ranged2Dice; set => ranged2Dice = value; }
        public string Ranged2Special { get => ranged2Special; set => ranged2Special = value; }
        public int Ranged2WSpec { get => ranged2WSpec; set => ranged2WSpec = value; }
        public string Ranged2Other { get => ranged2Other; set => ranged2Other = value; }
        public object Ranged2Traits { get => ranged2Traits; set => ranged2Traits = value; }
        public string Ranged2Notes { get => ranged2Notes; set => ranged2Notes = value; }
        public string Ranged3Name { get => ranged3Name; set => ranged3Name = value; }
        public int Ranged3Aim { get => ranged3Aim; set => ranged3Aim = value; }
        public int Ranged3Item { get => ranged3Item; set => ranged3Item = value; }
        public object Ranged3Dice { get => ranged3Dice; set => ranged3Dice = value; }
        public string Ranged3Special { get => ranged3Special; set => ranged3Special = value; }
        public int Ranged3WSpec { get => ranged3WSpec; set => ranged3WSpec = value; }
        public string Ranged3Other { get => ranged3Other; set => ranged3Other = value; }
        public object Ranged3Traits { get => ranged3Traits; set => ranged3Traits = value; }
        public string Ranged3Notes { get => ranged3Notes; set => ranged3Notes = value; }
        public string OtherWeaponName1 { get => otherWeaponName1; set => otherWeaponName1 = value; }
        public string OtherWeaponName2 { get => otherWeaponName2; set => otherWeaponName2 = value; }
        public Skill Acrobatics { get => acrobatics; set => acrobatics = value; }
        public Skill Arcana { get => arcana; set => arcana = value; }
        public Skill Athletics { get => athletics; set => athletics = value; }
        public Skill Crafting { get => crafting; set => crafting = value; }
        public Skill Deception { get => deception; set => deception = value; }
        public Skill Diplomacy { get => diplomacy; set => diplomacy = value; }
        public Skill Intimidation { get => intimidation; set => intimidation = value; }
        public Skill Lore1 { get => lore1; set => lore1 = value; }
        public Skill Lore2 { get => lore2; set => lore2 = value; }
        public Skill Medicine { get => medicine; set => medicine = value; }
        public Skill Nature { get => nature; set => nature = value; }
        public Skill Occultism { get => occultism; set => occultism = value; }
        public Skill Performance { get => performance; set => performance = value; }
        public Skill Religion { get => religion; set => religion = value; }
        public Skill Society { get => society; set => society = value; }
        public Skill Stealth { get => stealth; set => stealth = value; }
        public Skill Survival { get => survival; set => survival = value; }
        public Skill Thievery { get => thievery; set => thievery = value; }
        internal Proficiency DcProf { get => dcProf; set => dcProf = value; }
        internal Proficiency AcProf { get => acProf; set => acProf = value; }
        internal Proficiency UnarmoredProf { get => unarmoredProf; set => unarmoredProf = value; }
        internal Proficiency LightProf { get => lightProf; set => lightProf = value; }
        internal Proficiency MediumProf { get => mediumProf; set => mediumProf = value; }
        internal Proficiency HeavyProf { get => heavyProf; set => heavyProf = value; }
        internal Proficiency FortitudeProf { get => fortitudeProf; set => fortitudeProf = value; }
        internal Proficiency ReflexProf { get => reflexProf; set => reflexProf = value; }
        internal Proficiency WillProf { get => willProf; set => willProf = value; }
        internal Proficiency PerceptionProf { get => perceptionProf; set => perceptionProf = value; }
        internal Proficiency Melee1Prof { get => melee1Prof; set => melee1Prof = value; }
        internal WeaponType Melee1Type { get => melee1Type; set => melee1Type = value; }
        internal Proficiency Melee2Prof { get => melee2Prof; set => melee2Prof = value; }
        internal WeaponType Melee2Type { get => melee2Type; set => melee2Type = value; }
        internal Proficiency Melee3Prof { get => melee3Prof; set => melee3Prof = value; }
        internal WeaponType Melee3Type { get => melee3Type; set => melee3Type = value; }
        internal Proficiency Ranged1Prof { get => ranged1Prof; set => ranged1Prof = value; }
        internal WeaponType Ranged1Type { get => ranged1Type; set => ranged1Type = value; }
        internal Proficiency Ranged2Prof { get => ranged2Prof; set => ranged2Prof = value; }
        internal WeaponType Ranged2Type { get => ranged2Type; set => ranged2Type = value; }
        internal Proficiency Ranged3Prof { get => ranged3Prof; set => ranged3Prof = value; }
        internal WeaponType Ranged3Type { get => ranged3Type; set => ranged3Type = value; }
        internal Proficiency SimpleWeaponProf { get => simpleWeaponProf; set => simpleWeaponProf = value; }
        internal Proficiency MartialWeaponProf { get => martialWeaponProf; set => martialWeaponProf = value; }
        internal Proficiency OtherWeaponProf1 { get => otherWeaponProf1; set => otherWeaponProf1 = value; }
        internal Proficiency OtherWeaponProf2 { get => otherWeaponProf2; set => otherWeaponProf2 = value; }
    }

    public class CharacterClass
    {
        private string name;

    }

    public class Skill
    {
        private string name;
        private string subType;
        private int value;
        private string abilityScoreName;
        private int abilityScoreValue;
        private Proficiency prof;
        private int item;
        private int armorMod;
    }

    // Enumerations
    enum WeaponType
    {
        None,
        Blunt,
        Pierce,
        Sharp
    }

    enum Proficiency
    {
        None,
        Trained,
        Expert,
        Master,
        Legendary
    }


}