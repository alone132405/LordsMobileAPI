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

namespace LordsAPI_Example
{
    public partial class Castle : Form
    {
        public Castle()
        {
            InitializeComponent();
        }

        private void Castle_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                label1.Invoke((MethodInvoker)(() => label1.Text = "Gems: " + LordsMobileAPI.API.LocalUser.Statistic.Gems.Get.Count));
            }).Start();
            new Thread(() =>
            {
                label2.Invoke((MethodInvoker)(() => label2.Text = "Power: " + LordsMobileAPI.API.LocalUser.Statistic.Power.Get.Count));
            }).Start();
            new Thread(() =>
            {
                label3.Invoke((MethodInvoker)(() => label3.Text = "Energy: " + LordsMobileAPI.API.LocalUser.Statistic.Energy.Get.Count));
            }).Start();
            new Thread(() =>
            {
                string treasurebox = LordsMobileAPI.API.LocalUser.Castle.MysteryBox.Get.Time;
                if (treasurebox.Contains(":"))
                    iconPictureBox4.Invoke((MethodInvoker)(() => iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Box));
                else
                    iconPictureBox4.Invoke((MethodInvoker)(() => iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.BoxOpen));
                label4.Invoke((MethodInvoker)(() => label4.Text = "Treasure box: " + treasurebox));
            }).Start();
            new Thread(() =>
            {
                label5.Invoke((MethodInvoker)(() => label5.Text = "Stamina: " + LordsMobileAPI.API.LocalUser.Statistic.Stamina.Get.Count));
            }).Start();
        }
    }
}
