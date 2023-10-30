using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinder_2e_CharacterSheet
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Character
    {
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
