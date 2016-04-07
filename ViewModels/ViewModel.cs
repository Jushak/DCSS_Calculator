using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace DCSS_Calculator.ViewModels
{
    class ViewModel : ViewModelBase
    {
        #region Item sources

        public ObservableCollection<String> races { get; set;  }
        public ObservableCollection<String> armours { get; set; }
        public ObservableCollection<String> weapons { get; set; }
        public ObservableCollection<String> shields { get; set; }

        #endregion

        #region Bindings
        // Values used for calculations.
        String race;
        int level = 1;
        String armour;
        String weapon;
        String shield;
        Boolean helmet;
        Boolean gloves;
        Boolean boots;
        Boolean barding;
        Boolean cloak;
        int strength;
        int dexterity;
        int intelligence;
        int enchantment;
        int weaponSkill;
        int armourSkill;
        int shieldSkill;
        int dodgingSkill;
        int spellcasting;
        int spellLevel = 1;
        int numberOfSchools = 1;
        int school1;
        int school2;
        int school3;

        // Values used to store calculation results.
        int totalAC;
        double spellFailure;
        int guaranteedReduction;

        // Gets the total AC value of current setup.
        public int TotalAC
        {
            get 
            {
                this.totalAC = calculateAC();
                return (this.totalAC); 
            }
        }

        // Gets the spell failure chance of current setup.
        public double SpellFail
        {
            get
            {
                this.spellFailure = calculateSpellFail();
                return (this.spellFailure);
            }
        }

        // Gets whether or not a race that can use barding has been selected.
        public bool AllowBarding
        {
            get 
            {
                if (this.race == "Centaur" || this.race == "Naga")
                {
                    return true;
                }
                else
                {
                    barding = false;
                    this.NotifyPropertyChanged("BardingOn");
                    return false;
                }

            }
        }

        // Get whether or not a race that can use helmet has been selected.
        public bool AllowHelmet
        {
            get
            {
                if (this.race == "Draconian" || this.race == "Felid" || this.race == "Formicid" ||
                    this.race == "Minotaur" || this.race == "Octopede" || this.race == "Ogre" ||
                    this.race == "Tengu" || this.race == "Troll")
                {
                    helmet = false;
                    this.NotifyPropertyChanged("HelmetOn");
                    return false;
                }
                return true;
            }
        }

        // Get whether or not a race that can use gloves has been selected.
        public bool AllowGloves
        {
            get
            {
                if (this.race == "Ogre" || this.race == "Troll" || this.race == "Spriggan" ||
                    this.race == "Octopede" || this.race == "Felid")
                {
                    gloves = false;
                    this.NotifyPropertyChanged("GlovesOn");
                    return false;
                }
                return true;
            }
        }

        // Get whether or not a race that can use boots has been selected.
        public bool AllowBoots
        {
            get
            {
                if (this.race == "Centaur" || this.race == "Naga" || this.race == "Spriggan" ||
                    this.race == "Felid" || this.race == "Octopede" || this.race == "Ogre" ||
                    this.race == "Troll" || this.race == "Tengu")
                {
                    boots = false;
                    this.NotifyPropertyChanged("BootsOn");
                    return false;
                }
                return true;
            }
        }

        // Get or Set selected race.
        public String SelectedRace
        {
            get { return (this.race); }
            set
            {
                this.race = value;
                this.NotifyPropertyChanged("AllowBarding");
                this.NotifyPropertyChanged("TotalAC");
            }
        }

        // Get or Set character level-value.
        public int LevelValue
        {
            get { return (this.level); }
            set
            {
                this.level = value;
                this.NotifyPropertyChanged("TotalAC");
            }
        }

        // Get or Set selected armour.
        public String SelectedArmour
        {
            get { return (this.armour); }
            set
            {
                this.armour = value;
                this.NotifyPropertyChanged("TotalAC");
                this.NotifyPropertyChanged("SpellFail");
            }
        }

        // Get or Set selected weapon.
        public String SelectedWeapon
        {
            get { return (this.weapon); }
            set
            {
                this.weapon = value;
            }
        }

        // Get or Set selected shield.
        public String SelectedShield
        {
            get { return (this.shield); }
            set
            {
                this.shield = value;
            }
        }

        // Get or Set whether or not helmet is toggled on.
        public Boolean HelmetOn
        {
            get { return (this.helmet); }
            set
            {
                this.helmet = value;
                this.NotifyPropertyChanged("TotalAC");
            }
        }

        // Get or Set whether or not boots are toggled on.
        public Boolean BootsOn
        {
            get { return (this.boots); }
            set
            {
                this.boots = value;
                this.NotifyPropertyChanged("TotalAC");
            }
        }

        // Get or Set whether or not gloves are toggled on.
        public Boolean GlovesOn
        {
            get { return (this.gloves); }
            set
            {
                this.gloves = value;
                this.NotifyPropertyChanged("TotalAC");
            }
        }
        
        // Get or Set whether or not cloak is toggled on.
        public Boolean CloakOn
        {
            get { return (this.cloak); }
            set
            {
                this.cloak = value;
                this.NotifyPropertyChanged("TotalAC");
            }
        }

        // Get or Set whether or not barding is toggled on.
        public Boolean BardingOn
        {
            get { return (this.barding); }
            set
            {
                this.barding = value;
                this.NotifyPropertyChanged("TotalAC");
            }
        }

        // Get or Set strength-value.
        public int StrValue
        {
            get { return (this.strength); }
            set
            {
                this.strength = value;
            }
        }

        // Get or Set dexterity-value.
        public int DexValue
        {
            get { return (this.dexterity); }
            set
            {
                this.dexterity = value;
            }
        }

        // Get or Set intelligence-value.
        public int IntValue
        {
            get { return (this.intelligence); }
            set
            {
                this.intelligence = value;
            }
        }

        // Get or Set weapon skill-value.
        public int WeaponValue
        {
            get { return (this.weaponSkill); }
            set
            {
                this.weaponSkill = value;
            }
        }

        // Get or Set enchantment-value.
        public int EnchantValue
        {
            get { return (this.enchantment); }
            set
            {
                this.enchantment = value;
                this.NotifyPropertyChanged("TotalAC");
            }
        }

        // Get or Set armour skill-value.
        public int ArmourValue
        {
            get { return (this.armourSkill); }
            set
            {
                this.armourSkill = value;
                this.NotifyPropertyChanged("TotalAC");
            }
        }

        // Get or Set shield skill-value.
        public int ShieldValue
        {
            get { return (this.shieldSkill); }
            set
            {
                this.shieldSkill= value;
            }
        }

        // Get or Set dodging skill-value
        public int DodgeValue
        {
            get { return (this.dodgingSkill); }
            set
            {
                this.dodgingSkill = value;
            }
        }

        // Get or Set spellcasting skill-value.
        public int CastingValue
        {
            get { return (this.spellcasting); }
            set
            {
                this.spellcasting = value;
            }
        }

        // Get or Set level of the spell used for calculations.
        public int SpellLevelValue
        {
            get { return (this.spellLevel); }
            set
            {
                this.spellLevel = value;
            }
        }

        // Get or Set the number of schools used for calculations.
        public int SchoolsUsed
        {
            get { return (this.numberOfSchools); }
            set
            {
                this.numberOfSchools = value;
            }
        }

        // Get or Set primary spell school skill-value.
        public int School1Value
        {
            get { return (this.school1); }
            set
            {
                this.school1 = value;
            }
        }

        // Get or Set secondary spell school skill-value.
        public int School2Value
        {
            get { return (this.school2); }
            set
            {
                this.school2 = value;
            }
        }

        // Get or Set tertiary spell school skill-value.
        public int School3Value
        {
            get { return (this.school3); }
            set
            {
                this.school3 = value;
            }
        }

        #endregion

        #region Constructors
        public ViewModel()
        {
            // Instantiate item sources.
            this.races = new ObservableCollection<string>(); 
            this.armours = new ObservableCollection<string>(); 
            this.weapons = new ObservableCollection<string>();
            this.shields = new ObservableCollection<string>();

            // Populate sources.
            this.populateSources();
        }
        #endregion

        #region Calculations

        // Calculates total AC
        public int calculateAC()
        {
            Double AC = 0;
            if (armour == "Robe" || armour == "Animal skin" || armour == "Troll hide" ||
                armour == "Steam dragon hide")
            { 
                AC = 2;
            }
            else if ( armour == "Leather armour" || armour == "Mottled dragon hide" ||
                armour == "Swamp dragon hide" || armour == "Fire dragon hide" ||
                armour == "Pearl dragon hide")
            {
                AC = 3;
            }
            else if ( armour == "Troll leather armour" || armour == "Ice dragon hide" ||
                armour == "Storm dragon hide" || armour == "Gold dragon hide")
            {
                AC = 4;
            }
            else if ( armour == "Ring mail" || armour == "Steam dragon armour" ||
                armour == "Quicksilver dragon hide" || armour == "Shadow dragon hide")
            {
                AC = 5;
            }
            else if (armour == "Scale mail" || armour == "Mottled dragon armour")
            {
                AC = 6;
            }
            else if (armour == "Swamp dragon armour")
            {
                AC = 7;
            }
            else if (armour == "Fire dragon armour")
            {
                AC = 8;
            }
            else if (armour == "Ice dragon armour" || armour == "Chain mail" )
            {
                AC = 9;
            }
            else if (armour == "Plate armour" || armour == "Quicksilver dragon armour" ||
                armour == "Pearl dragon armour" || armour == "Storm dragon armour" ||
                armour == "Shadow dragon armour")
            {
                AC = 10;
            }
            else if (armour == "Gold dragon armour")
            {
                AC = 12;
            }
            else if (armour == "Crystal plate armour")
            {
                AC = 14;
            }

            // Add bonuses from armour skill
            AC = AC + AC * 0.04 * armourSkill;

            // Races with deformed body receive only half the benefit from body armour.
            if (race == "Centaur" || race == "Naga")
            {
                AC = AC / 2;
            }
            
            if (helmet)
            {
                AC++;
            }
            if (gloves)
            {
                AC++;
            }
            if (boots)
            {
                AC++;
            }
            if (cloak)
            {
                AC++;
            }
            if (barding)
            {
                AC = AC + 4;
            }

            // Apply AC modifier from armour skill.
            AC = AC * (22 + armourSkill) / 22;

            // Apply AC bonus/malus from enchantments.
            AC = AC + enchantment;

            // Add race-specific bonuses.
            switch (race) 
            {
                case "Centaur":
                case "Troll":
                    AC = AC+3;
                    break;
                case "Naga":
                case "Draconian":
                    AC = AC + (Math.Floor(System.Convert.ToDouble(level)/3));
                    break;
                case "Felid":
                    AC++;
                    if ( level >= 6) {
                        AC++;
                    }
                    if ( level >= 12 ) {
                        AC++;
                    }
                    break;
                case "Gargoyle":
                    AC = AC + gargoyleAC();
                    break;
                case "Octopede":
                case "Ogre":
                    AC++;
                    break;
            };
            return System.Convert.ToInt16(AC);
        }

        // Calculates the chance of spell resulting in failure, using given.
        public double calculateSpellFail()
        {
            // Calculate average of school skills.
            double schoolAverage = 0;
            if (numberOfSchools == 1)
            {
                schoolAverage = school1;
            }
            else if (numberOfSchools == 2)
            {
                schoolAverage = (school1 + school2) / 2;
            }
            else if (numberOfSchools == 3)
            {
                schoolAverage = (school1 + school2 + school3) / 3;
            }

            // Calculate spell skill value
            double S_0 = spellcasting/2 + schoolAverage*2;
            double spellSkills = 50 * Math.Log(1 + S_0 / 50, 2);

            double failure = 0;
            

            return Math.Round(failure, 2);
        }

        // Calculate armour/shield penalties.
        public double calculateEncumberance()
        {

            return 0;
        }

        // Helper function that returns encumbrance rating of currently selected armour.
        public double armourEncumbrance()
        {
            switch (SelectedArmour)
            {
                case "Robe":
                case "Animal skin":
                case "Steam dragon hide":
                case "Steam dragon armour":
                    return 0;
                case "Leather armor":
                case "Troll hide":
                case "Troll leather armour":
                    return -4;
                case "Mottled dragon hide":
                case "Mottled dragon armour":
                    return -5;
                case "Ring mail":
                case "Swamp dragon hide":
                case "Swamp dragon armour":
                case "Quicksilver dragon hide":
                case "Quicksilver dragon armour":
                    return -7;
                case "Scale mail":
                    return -10;
                case "Fire dragon hide":
                case "Fire dragon armour":
                case "Ice dragon hide":
                case "Ice dragon armour":
                case "Pearl dragon hide":
                case "Pearl dragon armour":
                case "Storm dragon hide":
                    return -11;
                case "Chain mail":
                case "Shadow dragon hide":
                case "Shadow dragon armour":
                    return -15;
                case "Storm dragon armour":
                case "Gold dragon hide":
                    return -17;
                case "Plate armour":
                    return -18;
                case "Crystal plate armour":
                    return -23;
                case "Gold dragon armour":
                    return -25;
                    
            }
            return 0;
        }

        // Helper function that returns spell difficulty of currently selected spell level.
        public double spellDifficulty()
        {
            switch (spellLevel)
            {
                case 1:
                    return 3;
                case 2:
                    return 15;
                case 3:
                    return 35;
                case 4:
                    return 70;
                case 5:
                    return 100;
                case 6:
                    return 150;
                case 7:
                    return 200;
                case 8:
                    return 260;
                case 9:
                    return 330;
            }
            return 0;
        }

        // Helper function that returns Gargoyle's AC bonus for current character level.
        public double gargoyleAC()
        {
            switch (level)
            {
                case 1:
                case 2:
                    return 2;
                case 3:
                case 4:
                    return 3;
                case 5:
                case 6:
                case 7:
                    return 4;
                case 8:
                case 9:
                    return 5;
                case 10:
                case 11:
                    return 7;
                case 12:
                    return 8;
                case 13:
                case 14:
                    return 9;
                case 15:
                case 16:
                    return 11;
                case 17:
                    return 12;
                case 18:
                case 19:
                    return 13;
                case 20:
                case 21:
                    return 15;
                case 22:
                    return 16;
                case 23:
                case 24:
                    return 17;
                case 25:
                case 26:
                    return 19;
                case 27:
                    return 20;
            }
            return 0;
        }

        #endregion

        // Function to populate collections used by the calculator.
        private void populateSources()
        {
            this.races = new ObservableCollection<string> { "Centaur", "Deep dwarf", "Deep elf",
                "Demigod", "Demonspawn", "Draconian", "Felid", "Formicid", "Gargoyle", "Ghoul",
                "Halfling", "High elf", "Hill orc", "Human", "Kobold", "Merfolk", "Minotaur", 
                "Mummy", "Naga", "Octopede", "Ogre", "Spriggan", "Tengu", "Troll", "Vampire",
                "Vine stalker" };
            this.armours = new ObservableCollection<string> { "Unarmored", "Robe", "Leather armour",
                "Ring mail", "Scale mail", "Chain mail", "Plate armour", "Crystal plate armour",
                "Animal skin", "Troll hide", "Troll leather armour", "Steam dragon hide",
                "Steam dragon armour", "Mottled dragon hide", "Mottled dragon armour",
                "Swamp dragon hide", "Swamp dragon armour", "Quicksilver dragon hide",
                "Quicksilver dragon armour", "Fire dragon hide", "Fire dragon armour",
                "Ice dragon hide", "Ice dragon armour", "Pearl dragon hide", "Pearl dragon armour",
                "Shadow dragon hide", "Shadow dragon armour", "Storm dragon hide",
                "Storm dragon armour", "Gold dragon hide", "Gold dragon armour" };
            this.weapons = new ObservableCollection<string> { "Unarmed", "Dagger", "Quick blade",
                "Short sword", "Rapier", "Falchion", "Long sword", "Scimitar", "Demon blade",
                "Eudemon blade", "Double sword", "Great sword", "Triple sword", "Hand axe",
                "War axe", "Broad axe", "Battleaxe", "Executioner's axe", "Whip", "Club", "Hammer",
                "Mace", "Morningstar", "Demon whip", "Sacred scourge", "Dire flail", "Eveningstar",
                "Great mace", "Giant club", "Giant spiked club", "Spear", "Trident", "Halberd",
                "Scythe", "Demon trident", "Trishula", "Glaive", "Bardiche", "Staff",
                "Quarterstaff", "Lajatang" };
            this.shields = new ObservableCollection<string> { "No shield", "Buckler", "shield",
                "Large Shield" };
        }
    }
}
