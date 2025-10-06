using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.GuideTbl.ToList(); // bütün listeyi döndürücek
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GuideTbl guide = new GuideTbl();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.GuideTbl.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla kaydedildi.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue = db.GuideTbl.Find(id);
            db.GuideTbl.Remove(removeValue);
            db.SaveChanges() ;
            MessageBox.Show("Rehber başarıyla silindi.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.GuideTbl.Find(id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellendi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.GuideTbl.Where(x=> x.GuideId==id).ToList();
            dataGridView1.DataSource=values;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
