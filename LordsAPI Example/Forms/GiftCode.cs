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
                LordsAPI_GiftActivator.LordsMobileGift.Results complitestatus = LordsAPI_GiftActivator.LordsMobileGift.Activate(method, textBox1.Text, textBox2.Text);
                if (method == LordsAPI_GiftActivator.LordsMobileGift.Methods.IGG_ID)
                    Console.WriteLine("[Gift Result] Method: " + method + " IGG ID: " + textBox1.Text + " Code: " + textBox2.Text + " Result: " + complitestatus);
                if (method == LordsAPI_GiftActivator.LordsMobileGift.Methods.Nickname)
                    Console.WriteLine("[Gift Result] Method: " + method + " Nickname: " + textBox1.Text + " Code: " + textBox2.Text + " Result: " + complitestatus);
            });
        }
    }
}
