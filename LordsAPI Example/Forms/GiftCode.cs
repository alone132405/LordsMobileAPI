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

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            LordsAPI_GiftActivator.LordsMobileGift.Methods method = LordsAPI_GiftActivator.LordsMobileGift.Methods.IGG_ID;
            Enum.TryParse(comboBox1.Text, out method);
            await Task.Run(async() =>
            {
                string s1 = textBox1.Text;
                string s2 = textBox2.Text;
                LordsAPI_GiftActivator.LordsMobileGift.Results complitestatus = LordsAPI_GiftActivator.LordsMobileGift.Activate(method, s1, s2);
                if (method == LordsAPI_GiftActivator.LordsMobileGift.Methods.IGG_ID)
                    Console.WriteLine("[Gift Result] Method: " + method + " IGG ID: " + s1 + " Code: " + s2 + " Result: " + complitestatus);
                if (method == LordsAPI_GiftActivator.LordsMobileGift.Methods.Nickname)
                    Console.WriteLine("[Gift Result] Method: " + method + " Nickname: " + s1 + " Code: " + s2 + " Result: " + complitestatus);
            });
        }
    }
}
