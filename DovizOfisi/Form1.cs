using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace DovizOfisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(bugun);

            string dolarAlis = xmlDocument.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lblDolarAlıs.Text = dolarAlis;

            string dolarSatis = xmlDocument.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDolarSatis.Text = dolarSatis;

            string euroAlis = xmlDocument.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEuroAlis.Text = euroAlis;

            string euroSatis = xmlDocument.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroSat.Text = euroSatis;
        }

        private void btnDolarAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarAlıs.Text;
            btnIslem.Text = "SAT";
            lblTutar.Text = "TUTAR(TL)";
        }

        private void btnDolarSat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarSatis.Text;
            btnIslem.Text = "AL";
            lblTutar.Text = "TUTAR($)";
        }

        private void btnEuroAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroAlis.Text;
            btnIslem.Text = "SAT";
            lblTutar.Text = "TUTAR(TL)";
        }

        private void btnEuroSat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroSat.Text;
            btnIslem.Text = "AL";
            lblTutar.Text = "TUTAR(€)";
        }

        private void txtKur_TextChanged(object sender, EventArgs e)
        {
            txtKur.Text = txtKur.Text.Replace(".", ",");
            txtMiktar.Clear();
            txtTutar.Clear();
        }

        private void btnIslem_Click(object sender, EventArgs e)
        {
            if (btnIslem.Text=="SAT")
            {
                decimal kur = Convert.ToDecimal(txtKur.Text);
                decimal miktar = Convert.ToDecimal(txtMiktar.Text);
                txtTutar.Text = (kur * miktar).ToString("#.##");
            }
            else if (btnIslem.Text=="AL")
            {
                decimal kur = Convert.ToDecimal(txtKur.Text);
                decimal miktar = Convert.ToDecimal(txtMiktar.Text);
                txtTutar.Text = (miktar / kur).ToString("#.##");
            }
        }
    }
}
