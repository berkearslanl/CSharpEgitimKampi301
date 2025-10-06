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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities(); // db nesnesi oluşturma
        private void btnList_Click(object sender, EventArgs e)
        {
            //veritabanındaki verileri listele
            var values =db.LocationTbl.ToList(); // location tablosunu listele
            dataGridView1.DataSource = values; // listelediğimiz tabloyu datagrid'de göster
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            //form çalıştığında combobox'un text'i

            var values = db.GuideTbl.Select(x=> new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();//fullname değerini biz belirledik.
            /*
            comboBox1.DisplayMember = "GuideName" + " " + "GuideSurname";
            bunu yazınca hata aldığımız için ayrı bi yerde tanımladık
             */
            cmbGuide.DisplayMember = "FullName"; // gösterilecek değer
            cmbGuide.ValueMember = "GuideId"; // combobox'un arka planda çalışan değer
            cmbGuide.DataSource = values;
                
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //tabloya yeni bir veri ekleme
            LocationTbl location = new LocationTbl();
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.LocationTbl.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //İD'ye göre silme işlemi
            int id = int.Parse(txtId.Text);
            var deletedValue = db.LocationTbl.Find(id);//id'yi bulduk
            db.LocationTbl.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedValue = db.LocationTbl.Find(id);
            updatedValue.DayNight = txtDayNight.Text;
            updatedValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updatedValue.City = txtCity.Text;
            updatedValue.Country = txtCountry.Text;
            updatedValue.Price = decimal.Parse(txtPrice.Text);
            updatedValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }
    }
}
