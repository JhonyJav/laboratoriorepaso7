using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laboratoriorepaso7
{
    public partial class Form1 : Form
    {
        List<casas> casa = new List<casas>();
        List<personas> persona = new List<personas>();
        public Form1()
        {
            InitializeComponent();
        }
        private void leerpersonas()
        {
            FileStream stream = new FileStream("propietarios.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                personas personas = new personas();
                personas.Dpi1 = Convert.ToInt32(reader.ReadLine());
                personas.Nombre = reader.ReadLine();
                personas.Apellido = reader.ReadLine();
                persona.Add(personas);
            }
            reader.Close();

        }
        private void leercasas()
        {
            FileStream stream = new FileStream("casas.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                casas casas = new casas();
                casas.Casa = reader.ReadLine();
                casas.Dpi = Convert.ToInt32(reader.ReadLine());
                casas.Cuota = Convert.ToInt32(reader.ReadLine());
                casa.Add(casas);

            }
            reader.Close();


        }

        private void Mostrarpersonas()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = persona;
            dataGridView1.Refresh();

        }
        private void mostrarcasas()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = casa;
            dataGridView2.Refresh();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            leercasas();
            mostrarcasas();
           leerpersonas();
            Mostrarpersonas();
        }
    }
}
