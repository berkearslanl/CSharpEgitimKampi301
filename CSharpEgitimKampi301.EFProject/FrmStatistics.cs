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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            // LOKASYON SAYISI
            lblLocationCount.Text = db.LocationTbl.Count().ToString();
            
            //KAPASİTELERİN TOPLAMI
            lblSumCapacity.Text = db.LocationTbl.Sum(x=> x.Capacity).ToString();
            
            // REHBER SAYISI
            lblGuideCount.Text = db.GuideTbl.Count().ToString();
            
            //KAPASİTELERİN ORTALAMASI
            lblAvgCapacity.Text = db.LocationTbl.Average(x=> x.Capacity).ToString();
            
            // FİYATLARIN ORTALAMASI. value ve F2 ekledik çünkü virgülden sonra 2 basamak olmasını istiyoruz
            lblAvgLocationPrice.Text = db.LocationTbl.Average(x=> x.Price).Value.ToString("F2") + " TL"; 
            
            //TABLOYA SON EKLENEN ÜLKENİN ADI
            int lastCountryId = db.LocationTbl.Max(x => x.LocationId); //en yüksek numaraya sahip lokasyon id'sini bulduk
            //lokasyon id'si lastcountryıd ye eşit olan veriyi getir ve bu verideki ülkenin ismini seç. sondaki metot da bütün bir veriyi değil sadece tek bir veriyi getirmek için kullandık
            lblLastCountry.Text = db.LocationTbl.Where(x=> x.LocationId == lastCountryId).Select(y=> y.Country).FirstOrDefault();
            
            //kapadokya tur kapasitesi
            lblCapadociaLocationCapacity.Text = db.LocationTbl.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            //TÜRKİYEDEKİ TURLARIN ORTALAMA KAPASİTESİ
            lblTurkeyCapacityAvg.Text = db.LocationTbl.Where(x=>x.Country=="Türkiye").Average(y=>y.Capacity).ToString();

            //ROMA TURUNDAKİ REHBERİN ADI
            //bu satırda city ismi roma turistik olan satırın guideıd'sini yakaladık
            var romeGuideId = db.LocationTbl.Where(x=>x.City== "Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();
            //bu satırda ise id'si üstteki ile aynı olan satırın seçilen değerlerini getirme işlemi yaptık
            lblRomeGuideName.Text = db.GuideTbl.Where(x=>x.GuideId==romeGuideId).Select(y=>y.GuideName+" "+y.GuideSurname).FirstOrDefault();

            //EN YÜKSEK KAPASİTELİ TUR
            var maxCapacity = db.LocationTbl.Max(x=>x.Capacity);//en yüksek kapasiteyi bulduk
            lblMaxCapacityLocation.Text = db.LocationTbl.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();

            //EN PAHALI TUR
            var maxPrice = db.LocationTbl.Max(x => x.Price);//en yüksek fiyat
            lblMaxPriceLocation.Text = db.LocationTbl.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault().ToString();

            //AYŞEGÜL ÇINAR'IN TUR SAYISI
            //guide tablosunda adı ayşegül çınar olan kişinin guideid'sini çek
            var guideIdByAysegulCinar = db.GuideTbl.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text = db.LocationTbl.Where(x => x.GuideId == guideIdByAysegulCinar).Count().ToString();


        }
    }
}
