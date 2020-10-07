using DirectX_Renderer;
using LordsAPI;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Factory = SharpDX.Direct2D1.Factory;
using FontFactory = SharpDX.DirectWrite.Factory;
namespace LordsAPI_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private LordsMobileAPI api = new LordsMobileAPI();
        private async void button8_Click(object sender, EventArgs e)
        {

            int energy = await LordsMobileAPI.API.LocalUser.Statistic.Energy.Get.CountAsync();
            Console.WriteLine("Энергия: " + energy);
            label11.Text = "Энергия: " + energy.ToString();
            int stamina = await LordsMobileAPI.API.LocalUser.Statistic.Stamina.Get.CountAsync();
            label10.Text = "Выносливость: " + stamina.ToString() + "/120";
            int gems = await LordsMobileAPI.API.LocalUser.Statistic.Gems.Get.CountAsync();
            label2.Text = "Самоцветы: " + gems.ToString();
            int power = await LordsMobileAPI.API.LocalUser.Statistic.Power.Get.CountAsync();
            label1.Text = "Сила: " + power.ToString();
            int xp = await LordsMobileAPI.API.LocalUser.Statistic.Level.Experience.Get.CountAsync();
            label12.Text = "Опыт: " + xp.ToString();
            //Size resolution = await LordsMobileAPI.Settings.Resolution.GetAsync();
            //if (resolution.Width != 1616 && resolution.Height != 939)
            //    await LordsMobileAPI.Settings.Resolution.ChangeAsync(new Size(1616, 939));
            //
            //LordsMobileAPI.UserInfo.Location location = await LordsMobileAPI.UserInfo.Location.GetLocationAsync();
            //Console.WriteLine(location);
            //if (location.type == LordsMobileAPI.UserInfo.Location.Locations.Castle || location.type == LordsMobileAPI.UserInfo.Location.Locations.Map)
            //{
            //
            //    //label10.Text = LordsMobileAPI.UserInfo.Statistic.Stamina.Get();
            //    int energy = await LordsMobileAPI.UserInfo.Statistic.Energy.GetAsync();
            //    label11.Text = energy.ToString();
            /* Resource */
            int round = 0;
            double food = await LordsMobileAPI.API.LocalUser.Castle.Resources.Food.Get.CountAsync();
            double food1 = Math.Round(food, round);
            Console.WriteLine("Еда: " + food1);
            label5.Text = "Еда: " + food1 + "/" + await LordsMobileAPI.API.LocalUser.Castle.Resources.Food.Get.MaximumAsync();
            double stone = await LordsMobileAPI.API.LocalUser.Castle.Resources.Stone.Get.CountAsync();
            double stone1 = Math.Round(stone, round);
            Console.WriteLine("Камень: " + stone1);
            label7.Text = "Камень: " + stone1 + "/" + await LordsMobileAPI.API.LocalUser.Castle.Resources.Stone.Get.MaximumAsync();
            double wood = await LordsMobileAPI.API.LocalUser.Castle.Resources.Wood.Get.CountAsync();
            double wood1 = Math.Round(wood, round);
            Console.WriteLine("Дерево: " + wood1);
            label6.Text = "Дерево: " + wood1 + "/" + await LordsMobileAPI.API.LocalUser.Castle.Resources.Wood.Get.MaximumAsync();
            double ore = await LordsMobileAPI.API.LocalUser.Castle.Resources.Ore.Get.CountAsync();
            double ore1 = Math.Round(ore, round);
            Console.WriteLine("Руда: " + ore1);
            label8.Text = "Руда: " + ore1 + "/" + await LordsMobileAPI.API.LocalUser.Castle.Resources.Ore.Get.MaximumAsync();
            double gold = await LordsMobileAPI.API.LocalUser.Castle.Resources.Gold.Get.CountAsync();
            double gold1 = Math.Round(gold, round);
            Console.WriteLine("Золото: " + gold1);
            label9.Text = "Золото: " + gold1 + "/" + await LordsMobileAPI.API.LocalUser.Castle.Resources.Gold.Get.MaximumAsync();
            double anima = await LordsMobileAPI.API.LocalUser.Castle.Resources.Anima.Get.CountAsync();
            double anima1 = Math.Round(anima, round);
            label18.Text = "Анима: " + anima1 + "/" + await LordsMobileAPI.API.LocalUser.Castle.Resources.Anima.Get.MaximumAsync();

            label13.Text = "IGG ID: " + await LordsMobileAPI.API.LocalUser.Auth.Get.IGG_IDAsync();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string time = await LordsMobileAPI.API.LocalUser.Castle.MysteryBox.Get.TimeAsync();
            if (time == "Забрать")
                time = "Collect";
            label4.Text = "Коробка: " + time;
            label20.Text = "Дистанция: " + await LordsMobileAPI.API.LocalUser.Castle.Get.DistanceToCasteAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void button9_Click_1(object sender, EventArgs e)
        {
            int money = await LordsMobileAPI.API.LocalUser.Guild.Shop.Get.MoneyAsync();
            label17.Text = "Монет: " + money;
            int keys = await LordsMobileAPI.API.LocalUser.Guild.Gifts.Get.KeysAsync();
            label15.Text = "Ключей: " + keys;
            label19.Text = "Рук: " + await LordsMobileAPI.API.LocalUser.Guild.Help.OtherUser.Get.CountAsync();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Overlay_SharpDX overlay = new Overlay_SharpDX(LordsMobileAPI.Settings.GetProcess);
            Thread thread1 = new Thread(() => {
                while (true)
                {
                    if (overlay != null && overlay.device != null)
                    {
                        if (!Utils.ProcessUtils.IsActivate(LordsMobileAPI.Settings.GetProcess))
                        {
                            overlay.device.BeginDraw();
                            overlay.device.Clear(new SharpDX.Mathematics.Interop.RawColor4(0, 0, 0, 0));
                            overlay.device.EndDraw();
                        }
                        else
                        {
                            overlay.Invoke((MethodInvoker)delegate
                            {
                                overlay.UpdatePos();
                            });

                            overlay.device.BeginDraw();
                            overlay.device.Clear(new SharpDX.Mathematics.Interop.RawColor4(0, 0, 0, 0));
                            overlay.device.TextAntialiasMode = SharpDX.Direct2D1.TextAntialiasMode.Cleartype;

                            overlay.device.FillRectangle(new SharpDX.Mathematics.Interop.RawRectangleF(0, 0, 200, 65), new SolidColorBrush(overlay.device, new SharpDX.Mathematics.Interop.RawColor4(0, 0, 132, 256)));
                            overlay.device.DrawText("Гемов в колизей: " + LordsMobileAPI.API.LocalUser.Castle.Coliseum.Get.Gems, new TextFormat(new FontFactory(), "Arial", 15.0f), new SharpDX.Mathematics.Interop.RawRectangleF(15, 10, 300, 0), new SolidColorBrush(overlay.device, new SharpDX.Mathematics.Interop.RawColor4(0, 255, 0, 255)));
                            overlay.device.DrawText("Ранг в колизей: " + LordsMobileAPI.API.LocalUser.Castle.Coliseum.Get.Rank, new TextFormat(new FontFactory(), "Arial", 15.0f), new SharpDX.Mathematics.Interop.RawRectangleF(15, 30, 300, 15), new SolidColorBrush(overlay.device, new SharpDX.Mathematics.Interop.RawColor4(0, 255, 0, 255)));
                            overlay.device.DrawText("Коробка: " + LordsMobileAPI.API.LocalUser.Castle.MysteryBox.Get.Time, new TextFormat(new FontFactory(), "Arial", 15.0f), new SharpDX.Mathematics.Interop.RawRectangleF(15, 60, 300, 30), new SolidColorBrush(overlay.device, new SharpDX.Mathematics.Interop.RawColor4(0, 255, 0, 255)));
                            overlay.device.DrawText("Анима: " + Math.Round(LordsMobileAPI.API.LocalUser.Castle.Resources.Anima.Get.Count, 0), new TextFormat(new FontFactory(), "Arial", 15.0f), new SharpDX.Mathematics.Interop.RawRectangleF(15, 90, 300, 45), new SolidColorBrush(overlay.device, new SharpDX.Mathematics.Interop.RawColor4(0, 255, 0, 255)));

                            overlay.device.EndDraw();
                        }
                    }
                }
            });
            thread1.Priority = ThreadPriority.Highest;
            thread1.IsBackground = true;
            if (checkBox1.Checked)
            {
                overlay.Show();
                thread1.Start();
            }
            else
            {
                
                overlay.Exit(null, null);
                thread1.Abort();
            }
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }
    }
}
