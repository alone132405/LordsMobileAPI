using LordsAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LordsAPI_Example.Forms
{
    public partial class Guild : Form
    {
        public Guild()
        {
            InitializeComponent();
        }

        private void Guild_Load(object sender, EventArgs e)
        {
            new Thread(() => {
                label1.Invoke((MethodInvoker)(() => label1.Text = "Money: " + LordsMobileAPI.API.LocalUser.Guild.Shop.Money));
            }).Start();
            new Thread(() => {
                label2.Invoke((MethodInvoker)(() => label2.Text = "Power: " + LordsMobileAPI.API.LocalUser.Guild.Statistic.Power));
            }).Start();
            new Thread(() => {
                label4.Invoke((MethodInvoker)(() => label4.Text = "Keys: " + LordsMobileAPI.API.LocalUser.Guild.Gifts.Keys)); 
            }).Start();
            new Thread(() => {
                label3.Invoke((MethodInvoker)(() => label3.Text = "Help: " + LordsMobileAPI.API.LocalUser.Guild.Help.OtherUser.Count));
            }).Start();
        }
    }
}
