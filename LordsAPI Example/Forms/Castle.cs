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
                label45.Invoke((MethodInvoker)(() => label45.Text = "IP: " + LordsMobileAPI.API.Server.IP));
            }).Start();
            new Thread(() =>
            {
                label1.Invoke((MethodInvoker)(() => label1.Text = "Gems: " + LordsMobileAPI.API.LocalUser.Statistic.Gems.Count));
            }).Start();
            new Thread(() =>
            {
                label2.Invoke((MethodInvoker)(() => label2.Text = "Power: " + LordsMobileAPI.API.LocalUser.Statistic.Power.Count));
            }).Start();
            new Thread(() =>
            {
                label3.Invoke((MethodInvoker)(() => label3.Text = "Energy: " + LordsMobileAPI.API.LocalUser.Statistic.Energy.Count));
            }).Start();
            new Thread(() =>
            {
                string treasurebox = LordsMobileAPI.API.LocalUser.Castle.MysteryBox.Time;
                if (treasurebox.Contains(":"))
                    iconPictureBox4.Invoke((MethodInvoker)(() => iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Box));
                else
                    iconPictureBox4.Invoke((MethodInvoker)(() => iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.BoxOpen));
                label4.Invoke((MethodInvoker)(() => label4.Text = "Treasure box: " + treasurebox));
            }).Start();
            new Thread(() =>
            {
                label5.Invoke((MethodInvoker)(() => label5.Text = "Stamina: " + LordsMobileAPI.API.LocalUser.Statistic.Stamina.Count));
            }).Start();
            new Thread(() =>
            {
                label6.Invoke((MethodInvoker)(() => label6.Text = "IGG ID: " + LordsMobileAPI.API.LocalUser.Auth.IGG_ID));
            }).Start();
            new Thread(() =>
            {
                label7.Invoke((MethodInvoker)(() => label7.Text = "Gems: " + LordsMobileAPI.API.LocalUser.Castle.Coliseum.Gems));
            }).Start();
            /* Resourses */
            new Thread(() =>
            {
                label9.Invoke((MethodInvoker)(() => label9.Text = "Food: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Food.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Food.Maximum));
            }).Start();
            new Thread(() =>
            {
                label12.Invoke((MethodInvoker)(() => label12.Text = "Stone: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Stone.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Stone.Maximum));
            }).Start();
            new Thread(() =>
            {
                label13.Invoke((MethodInvoker)(() => label13.Text = "Wood: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Wood.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Wood.Maximum));
            }).Start();
            new Thread(() =>
            {
                label8.Invoke((MethodInvoker)(() => label8.Text = "Ore: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Ore.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Ore.Maximum));
            }).Start();
            new Thread(() =>
            {
                label11.Invoke((MethodInvoker)(() => label11.Text = "Gold: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Gold.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Gold.Maximum));
            }).Start();
            new Thread(() =>
            {
                label10.Invoke((MethodInvoker)(() => label10.Text = "Anima: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Anima.Count, 0) + "/" + LordsMobileAPI.API.LocalUser.Castle.Resources.Anima.Maximum));
            }).Start();
            new Thread(() =>
            {
                label17.Invoke((MethodInvoker)(() => label17.Text = "Rank: " + LordsMobileAPI.API.LocalUser.Castle.Coliseum.Rank));
            }).Start();
            new Thread(() =>
            {
                label44.Invoke((MethodInvoker)(() => label44.Text = "Version: " + LordsMobileAPI.API.Server.Version));
            }).Start();
            /* Army */
            new Thread(() =>
            {
                label20.Invoke((MethodInvoker)(() => label20.Text = "Infantry: " + LordsMobileAPI.API.LocalUser.Castle.Army.Infantry.T1.Count));
            }).Start();
            new Thread(() =>
            {
                label21.Invoke((MethodInvoker)(() => label21.Text = "Archer: " + LordsMobileAPI.API.LocalUser.Castle.Army.Archer.T1.Count));
            }).Start();
            new Thread(() =>
            {
                label22.Invoke((MethodInvoker)(() => label22.Text = "Rider: " + LordsMobileAPI.API.LocalUser.Castle.Army.Rider.T1.Count));
            }).Start();
            new Thread(() =>
            {
                label23.Invoke((MethodInvoker)(() => label23.Text = "Ballista: " + LordsMobileAPI.API.LocalUser.Castle.Army.Ballista.T1.Count));
            }).Start();
            new Thread(() =>
            {
                label24.Invoke((MethodInvoker)(() => label24.Text = "Ballista: " + LordsMobileAPI.API.LocalUser.Castle.Army.Ballista.T2.Count));
            }).Start();
            new Thread(() =>
            {
                label25.Invoke((MethodInvoker)(() => label25.Text = "Rider: " + LordsMobileAPI.API.LocalUser.Castle.Army.Rider.T2.Count));
            }).Start();
            new Thread(() =>
            {
                label26.Invoke((MethodInvoker)(() => label26.Text = "Archer: " + LordsMobileAPI.API.LocalUser.Castle.Army.Archer.T2.Count));
            }).Start();
            new Thread(() =>
            {
                label27.Invoke((MethodInvoker)(() => label27.Text = "Infantry: " + LordsMobileAPI.API.LocalUser.Castle.Army.Infantry.T2.Count));
            }).Start();
            new Thread(() =>
            {
                label32.Invoke((MethodInvoker)(() => label32.Text = "Infantry: " + LordsMobileAPI.API.LocalUser.Castle.Army.Infantry.T3.Count));
            }).Start();
            new Thread(() =>
            {
                label31.Invoke((MethodInvoker)(() => label31.Text = "Archer: " + LordsMobileAPI.API.LocalUser.Castle.Army.Archer.T3.Count));
            }).Start();
            new Thread(() =>
            {
                label30.Invoke((MethodInvoker)(() => label30.Text = "Rider: " + LordsMobileAPI.API.LocalUser.Castle.Army.Rider.T3.Count));
            }).Start();
            new Thread(() =>
            {
                label29.Invoke((MethodInvoker)(() => label29.Text = "Ballista: " + LordsMobileAPI.API.LocalUser.Castle.Army.Ballista.T3.Count));
            }).Start();
            new Thread(() =>
            {
                label47.Invoke((MethodInvoker)(() => label47.Text = "Total: " + LordsMobileAPI.API.LocalUser.Castle.Army.TotalCount));
            }).Start();
            new Thread(() =>
            {
                label46.Invoke((MethodInvoker)(() => label46.Text = "All: " + string.Join(", ", LordsMobileAPI.API.LocalUser.PromoCodes.All)));
            }).Start();
            new Thread(() =>
            {
                label49.Invoke((MethodInvoker)(() => label49.Text = "Attacks: " + LordsMobileAPI.API.LocalUser.Castle.Attack.Status.AttackCount));
            }).Start();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
