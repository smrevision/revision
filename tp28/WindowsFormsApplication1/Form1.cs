using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.DataSet1TableAdapters;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void remplir(int i)
        {
            DataSet1.stagiaireRow s = new stagiaireTableAdapter().GetData().FindByid(i);
            idTextBox.Text = s.id.ToString(); nomTextBox.Text = s.nom; prenomTextBox.Text = s.prenom; int.Parse(groupeComboBox.SelectedValue.ToString()) ;
        }
        public void a()
        {
            stagiaireDataGridView.DataSource = null;
            DataSet1 s = new DataSet1();
            new groupeTableAdapter().Fill(s.groupe);
            new stagiaireTableAdapter().Fill(s.stagiaire);
            stagiaireDataGridView.DataSource = s.stagiaire.ToList<DataSet1.stagiaireRow>(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            a();
            groupeComboBox.DataSource = new groupeTableAdapter().GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stagiaireTableAdapter s = new stagiaireTableAdapter();
            s.Insert(int.Parse(idTextBox.Text), nomTextBox.Text, prenomTextBox.Text, int.Parse(groupeComboBox.SelectedValue.ToString()));
            a();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = (int)stagiaireDataGridView.SelectedCells[0].Value;
            DataSet1.stagiaireRow s = new stagiaireTableAdapter().GetData().FindByid(i);
            s.Delete();
            new stagiaireTableAdapter().Update(s);
            a();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stagiaireDataGridView.CurrentCell = stagiaireDataGridView.Rows[0].Cells[0];
            int id = (int)stagiaireDataGridView.SelectedCells[0].Value;
            remplir(id);
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            stagiaireDataGridView.CurrentCell = stagiaireDataGridView.Rows[stagiaireDataGridView.CurrentCell.RowIndex - 1].Cells[0];
            int id = (int)stagiaireDataGridView.SelectedCells[0].Value; remplir(id);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stagiaireDataGridView.CurrentCell = stagiaireDataGridView.Rows[stagiaireDataGridView.CurrentCell.RowIndex + 1].Cells[0];
            int id = (int)stagiaireDataGridView.SelectedCells[0].Value; remplir(id);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stagiaireDataGridView.CurrentCell = stagiaireDataGridView.Rows[stagiaireDataGridView.Rows.Count - 1].Cells[0];
            int id = (int)stagiaireDataGridView.SelectedCells[0].Value; remplir(id);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int i = (int)stagiaireDataGridView.SelectedCells[0].Value;
            DataSet1.stagiaireRow s = new stagiaireTableAdapter().GetData().FindByid(i);
            s.nom = nomTextBox.Text; s.prenom = prenomTextBox.Text; s.groupe = int.Parse(groupeComboBox.SelectedValue.ToString());
            new stagiaireTableAdapter().Update(s); a();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            idTextBox.Clear(); nomTextBox.Clear(); prenomTextBox.Clear();
        }
    }
}
