using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;
using Logic.Enums;

namespace Circustrein_algoritme
{
    public partial class Form1 : Form
    {
        Train train = new Train();

        public Form1()
        {
            InitializeComponent();

            //zorgt ervoor dat de comboboxes de values hebben uit de enums uit de logic laag
            comboBox1.DataSource = Enum.GetValues(typeof(AnimalSize));
            comboBox2.DataSource = Enum.GetValues(typeof(AnimalEatOptions));
        }

        private void Brn_AddAnimal_Click(object sender, EventArgs e)
        {
            //maakt 2 enum variabele aan op basis van geselecteerde item in combobox
            Enum.TryParse(comboBox1.Text.ToString(), out AnimalSize myAnimalSize);
            Enum.TryParse(comboBox2.Text.ToString(), out AnimalEatOptions myAnimalEatOptions);

            train.CreateAndAddAnimal(myAnimalSize, myAnimalEatOptions);
            RefreshListBox1();
        }

        private void Btn_Sort_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            train.Sort();
            foreach(var w in train.GetWagons())
            {
                listBox2.Items.Add(w);
            }
        }

        private void RefreshListBox1()
        {
            listBox1.Items.Clear();
            
            foreach(var a in train.GetAnimals())
            {
                listBox1.Items.Add(a);
            }
        }
    }
}
