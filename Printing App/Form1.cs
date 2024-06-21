using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Printing_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (PrinterSettings.InstalledPrinters.Count<=0)
            {
                MessageBox.Show("Printer Not Found!");
                return;

            }


            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                cbPrinterslist.Items.Add(printer.ToString());
            }



        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = cbPrinterslist.SelectedItem.ToString();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            pd.Print();



        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            Graphics g = e.Graphics;
            Font font = new Font("Arial",16);
            SolidBrush brush = new SolidBrush(Color.Black);
           // g.DrawString("Hello print",font,brush, new Rectangle(20,20,100,100));
            g.DrawString(btnPrint.Text, font, brush, new Rectangle(20, 20, 100, 100));


        }
    }
}
