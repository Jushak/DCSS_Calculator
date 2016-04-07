using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace DCSS_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void initializeData()
        {
            /*raceComboBox.ItemsSource = new List<string> { "Centaur", "Deep dwarf", "Deep elf",
                "Demigod", "Demonspawn", "Draconian", "Felid", "Formicid", "Gargoyle", "Ghoul",
                "Halfling", "High elf", "Hill orc", "Human", "Kobold", "Merfolk", "Minotaur", 
                "Mummy", "Naga", "Octopede", "Ogre", "Spriggan", "Tengu", "Troll", "Vampire",
                "Vine stalker" };
            raceComboBox.SelectedItem = "Human";
            armourComboBox.ItemsSource = new List<string> { "Unarmored", "Robe", "Leather armour",
                "Ring mail", "Scale mail", "Chain mail", "Plate armor", "Crystal plate",
                "Animal skin", "Troll hide", "Troll leather armour", "Steam dragon hide",
                "Steam dragon armour", "Mottled dragon hide", "Mottled dragon armour",
                "Swamp dragon hide", "Swamp dragon armour", "Quicksilver dragon hide",
                "Quicksilver dragon armour", "Fire dragon hide", "Fire dragon armour",
                "Ice dragon hide", "Ice dragon armour", "Pearl dragon hide", "Pearl dragon armour",
                "Shadow dragon hide", "Shadow dragon armour", "Storm dragon hide",
                "Storm dragon armour", "Gold dragon hide", "Gold dragon armour" };
            armourComboBox.SelectedItem = "Unarmored";
            weaponComboBox.ItemsSource = new List<string> { "Unarmed", "Dagger", "Quick blade",
                "Short sword", "Rapier", "Falchion", "Long sword", "Scimitar", "Demon blade",
                "Eudemon blade", "Double sword", "Great sword", "Triple sword", "Hand axe",
                "War axe", "Broad axe", "Battleaxe", "Executioner's axe", "Whip", "Club", "Hammer",
                "Mace", "Morningstar", "Demon whip", "Sacred scourge", "Dire flail", "Eveningstar",
                "Great mace", "Giant club", "Giant spiked club", "Spear", "Trident", "Halberd",
                "Scythe", "Demon trident", "Trishula", "Glaive", "Bardiche", "Staff",
                "Quarterstaff", "Lajatang" };
            weaponComboBox.SelectedItem = "Unarmed";
            shieldComboBox.ItemsSource = new List<string> { "No shield", "Buckler", "shield",
                "Large Shield" };
            shieldComboBox.SelectedItem = "No shield";*/
        }

        public void initializeBindings()
        {
        }
    }
}
