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
            new Thread(() =>
            {
                label6.Invoke((MethodInvoker)(() => label6.Text = "IGG ID: " + LordsMobileAPI.API.LocalUser.Auth.Get.IGG_ID));
            }).Start();
            new Thread(() =>
            {
                label7.Invoke((MethodInvoker)(() => label7.Text = "Gems in the colosseum: " + LordsMobileAPI.API.LocalUser.Castle.Coliseum.Get.Gems));
            }).Start();
            /* Resourses */
            new Thread(() =>
            {
                label9.Invoke((MethodInvoker)(() => label9.Text = "Food: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Food.Get.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Food.Get.Maximum));
            }).Start();
            new Thread(() =>
            {
                label12.Invoke((MethodInvoker)(() => label12.Text = "Stone: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Stone.Get.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Stone.Get.Maximum));
            }).Start();
            new Thread(() =>
            {
                label13.Invoke((MethodInvoker)(() => label13.Text = "Wood: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Wood.Get.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Wood.Get.Maximum));
            }).Start();
            new Thread(() =>
            {
                label8.Invoke((MethodInvoker)(() => label8.Text = "Ore: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Ore.Get.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Ore.Get.Maximum));
            }).Start();
            new Thread(() =>
            {
                label11.Invoke((MethodInvoker)(() => label11.Text = "Gold: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Gold.Get.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Gold.Get.Maximum));
            }).Start();
            new Thread(() =>
            {
                label10.Invoke((MethodInvoker)(() => label10.Text = "Anima: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Anima.Get.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Anima.Get.Maximum));
            }).Start();
        }
    }
}
