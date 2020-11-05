using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LordsAPI_Example.Forms
{
    public partial class GiftCode : Form
    {
        public GiftCode()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            LordsAPI_GiftActivator.LordsMobileGift.Methods method = LordsAPI_GiftActivator.LordsMobileGift.Methods.IGG_ID;
            Enum.TryParse(comboBox1.Text, out method);
            bool complitestatus = LordsAPI_GiftActivator.LordsMobileGift.Activate(method, textBox1.Text, textBox2.Text);
            Console.WriteLine("GiftCode result: " + complitestatus);
        }
    }
}
