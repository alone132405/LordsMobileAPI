
using Binarysharp.MemoryManagement;
using LordsAPI;
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
using Tesseract;

namespace LordsAPI_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private LordsMobileAPI api = new LordsMobileAPI();
        private void button3_Click(object sender, EventArgs e)
        {
            Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
            MemorySharp sharp = new MemorySharp(process);
            // Get the window
            var window = sharp.Windows.MainWindow;
            Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(process));
            //Console.WriteLine(game.Width);
            //Console.WriteLine(game.Height);
            game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Bitmap find = Utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile(@"game\\gotocastle.png"));
            List<Rectangle> done = Utils.Find(game, find);
            if (done.Count == 1)
            {
                Point cursor = Cursor.Position;
                window.Activate();
                window.Mouse.MoveTo(done[0].X, done[0].Y);
                window.Mouse.ClickLeft();
                Thread.Sleep(5);
                window.Mouse.MoveTo(cursor.X, cursor.Y);
            }
            else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                MemorySharp sharp = new MemorySharp(process);
                // Get the window
                var window = sharp.Windows.MainWindow;
                Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(process));
                //Console.WriteLine(game.Width);
                //Console.WriteLine(game.Height);
                game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\wood2.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = Utils.Find(game, find, 0.5);
                Console.WriteLine("Деревьев: " + done.Count);
                if (done.Count >= 1)
                {
                    window.Activate();
                    window.Mouse.MoveTo(done[0].X + 64, done[0].Y + 64);
                    window.Mouse.ClickLeft();
                }
                else
                {

                }
            }
            if (checkBox1.Checked == true && checkBox3.Checked == true)
            {
                Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                MemorySharp sharp = new MemorySharp(process);
                // Get the window
                var window = sharp.Windows.MainWindow;
                Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(process));
                //Console.WriteLine(game.Width);
                //Console.WriteLine(game.Height);
                game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\gold2.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = Utils.Find(game, find, 0.5f);
                if (done.Count >= 1)
                {
                    window.Activate();
                    window.Mouse.MoveTo(done[0].X + 64, done[0].Y + 64);
                    window.Mouse.ClickLeft();
                }
                else
                {

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
            MemorySharp sharp = new MemorySharp(process);
            // Get the window
            var window = sharp.Windows.MainWindow;
            Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(process));
            //Console.WriteLine(game.Width);
            //Console.WriteLine(game.Height);
            game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\gaterbutton.png");
            find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
            List<Rectangle> done = Utils.Find(game, find, 0.6);
            if (done.Count >= 1)
            {
                window.Activate();
                window.Mouse.MoveTo(done[0].X + 32, done[0].Y + 32);
                window.Mouse.ClickLeft();
            }
            else
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (1 != 0)
            {
                Process process2 = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                MemorySharp sharp = new MemorySharp(process2);
                // Get the window
                var window2 = sharp.Windows.MainWindow;
                Bitmap game2 = Utils.ConvertImagePixelType(Utils.GetProgrammImage(process2));
                //Console.WriteLine(game.Width);
                //Console.WriteLine(game.Height);
                game2.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find2 = (Bitmap)Bitmap.FromFile(@"game\\armyhave1.png");
                find2.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done2 = Utils.Find(game2, find2, 0.6);
                if (done2.Count >= 1)
                {

                }
                else
                {
                    if (1 != 0)
                    {
                        Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        // Get the window
                        var window = sharp.Windows.MainWindow;
                        Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(process));
                        //Console.WriteLine(game.Width);
                        //Console.WriteLine(game.Height);
                        game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\typevishkabutton.png");
                        find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                        List<Rectangle> done = Utils.Find(game, find, 0.6);
                        if (done.Count >= 1)
                        {
                            window.Activate();
                            window.Mouse.MoveTo(done[0].X + 32, done[0].Y + 32);
                            window.Mouse.ClickLeft();
                        }
                        else
                        {

                        }
                    }
                    if (1 != 0)
                    {
                        Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        // Get the window
                        var window = sharp.Windows.MainWindow;
                        Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(process));
                        //Console.WriteLine(game.Width);
                        //Console.WriteLine(game.Height);
                        game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\goattackbutton.png");
                        find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                        List<Rectangle> done = Utils.Find(game, find, 0.6);
                        if (done.Count >= 1)
                        {
                            window.Activate();
                            window.Mouse.MoveTo(done[0].X + 128, done[0].Y + 128);
                            window.Mouse.ClickLeft();
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (1 != 0)
            {
                Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                MemorySharp sharp = new MemorySharp(process);
                // Get the window
                var window = sharp.Windows.MainWindow;
                Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(process));
                //Console.WriteLine(game.Width);
                //Console.WriteLine(game.Height);
                game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\hand.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = Utils.Find(game, find, 0.4);
                if (done.Count >= 1)
                {
                    window.Activate();
                    window.Mouse.MoveTo(done[0].X, done[0].Y);
                    window.Mouse.ClickLeft();
                }
                else
                {

                }
                sharp.Dispose();
            }
            Thread.Sleep(1000);
            if (1 != 0)
            {
                Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                MemorySharp sharp = new MemorySharp(process);
                // Get the window
                var window = sharp.Windows.MainWindow;
                Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(process));
                //Console.WriteLine(game.Width);
                //Console.WriteLine(game.Height);
                game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\handall.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = Utils.Find(game, find, 0.6);
                if (done.Count >= 1)
                {
                    window.Activate();
                    window.Mouse.MoveTo(done[0].X + 12, done[0].Y + 12);
                    window.Mouse.ClickLeft();
                }
                else
                {

                }
                sharp.Dispose();
            }
        }
        private async void button8_Click(object sender, EventArgs e)
        {
            int energy = await LordsMobileAPI.UserInfo.Statistic.Energy.GetAsync();
            label11.Text = "Энергия: " + energy.ToString();
            int stamina = await LordsMobileAPI.UserInfo.Statistic.Stamina.GetAsync();
            label10.Text = "Выносливость: " + stamina.ToString() + "/120";
            int gems = await LordsMobileAPI.UserInfo.Statistic.Gems.GetAsync();
            label2.Text = "Самоцветы: " + gems.ToString();
            int power = await LordsMobileAPI.UserInfo.Statistic.Power.GetAsync();
            label1.Text = "Сила: " + power.ToString();
            int xp = await LordsMobileAPI.UserInfo.Statistic.Level.Experience.GetAsync();
            int xpneed = await LordsMobileAPI.UserInfo.Statistic.Level.Experience.Need.GetAsync();
            label12.Text = "Опыт: " + xp.ToString() + "/" + xpneed.ToString();
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
            double food = await LordsMobileAPI.UserInfo.Resources.Food.GetCountAsync();
            double food1 = Math.Round(food, round);
            Console.WriteLine("Еда: " + food1);
            label5.Text = "Еда: " + food1;
            double stone = await LordsMobileAPI.UserInfo.Resources.Stone.GetCountAsync();
            double stone1 = Math.Round(stone, round);
            Console.WriteLine("Камень: " + stone1);
            label7.Text = "Камень: " + stone1;
            double wood = await LordsMobileAPI.UserInfo.Resources.Wood.GetCountAsync();
            double wood1 = Math.Round(wood, round);
            Console.WriteLine("Дерево: " + wood1);
            label6.Text = "Дерево: " + wood1;
            double ore = await LordsMobileAPI.UserInfo.Resources.Ore.GetCountAsync();
            double ore1 = Math.Round(ore, round);
            Console.WriteLine("Руда: " + ore1);
            label8.Text = "Руда: " + ore1;
            double gold = await LordsMobileAPI.UserInfo.Resources.Gold.GetCountAsync();
            double gold1 = Math.Round(gold, round);
            Console.WriteLine("Золото: " + gold1);
            label9.Text = "Золото: " + gold1;
            double anima = await LordsMobileAPI.UserInfo.Resources.Anima.GetCountAsync();
            double anima1 = Math.Round(anima, round);
            label18.Text = "Анима: " + anima1;
            //}
            //else
            //{
            //    Console.WriteLine(location);
            //}
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
            string time = await LordsMobileAPI.MysteryBox.Get.TimeAsync();
            if (time == "Забрать")
                time = "Done";
            label4.Text = "Коробка: " + time;
            string time2 = await LordsMobileAPI.Academy.GetResearchTimeAsync();
            label13.Text = "Иследование: " + time2;
            string time3 = await LordsMobileAPI.Build.GetBuildAsync();
            label14.Text = "Строительство: " + time3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button9_Click(object sender, EventArgs e)
        {
            bool click = await LordsMobileAPI.MysteryBox.Actions.ClickMysteryBoxAsync(await LordsMobileAPI.UserInfo.Location.GetLocationAsync());
                if (click)
                await LordsMobileAPI.MysteryBox.Actions.ColectAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            LordsMobileAPI.UserInfo.Location location = await LordsMobileAPI.UserInfo.Location.GetLocationAsync();
            if (location.type == LordsMobileAPI.UserInfo.Location.Locations.MerchantShip)
            {
                await LordsMobileAPI.MerchantShip.Actions.BuyAsync(location, LordsMobileAPI.MerchantShip.Actions.BuySlots.Slot1);
            }
            else MessageBox.Show("Вы не находитесь в торгов корабле");
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            LordsMobileAPI.UserInfo.Location location = await LordsMobileAPI.UserInfo.Location.GetLocationAsync();
            if (location.type == LordsMobileAPI.UserInfo.Location.Locations.MerchantShip)
                await LordsMobileAPI.MerchantShip.Actions.BuyAsync(location, LordsMobileAPI.MerchantShip.Actions.BuySlots.Slot2);
            else MessageBox.Show("Вы не находитесь в торгов корабле");
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            LordsMobileAPI.UserInfo.Location location = await LordsMobileAPI.UserInfo.Location.GetLocationAsync();
            if (location.type == LordsMobileAPI.UserInfo.Location.Locations.MerchantShip)
                await LordsMobileAPI.MerchantShip.Actions.BuyAsync(location, LordsMobileAPI.MerchantShip.Actions.BuySlots.Slot3);
            else MessageBox.Show("Вы не находитесь в торгов корабле");
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            LordsMobileAPI.UserInfo.Location location = await LordsMobileAPI.UserInfo.Location.GetLocationAsync();
            if (location.type == LordsMobileAPI.UserInfo.Location.Locations.MerchantShip)
                await LordsMobileAPI.MerchantShip.Actions.BuyAsync(location, LordsMobileAPI.MerchantShip.Actions.BuySlots.Slot4);
            else MessageBox.Show("Вы не находитесь в торгов корабле");
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            DebugWindow debugWindow = new DebugWindow();
            debugWindow.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Console.WriteLine(LordsMobileAPI.UserInfo.Statistic.Energy.Get());
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void button9_Click_1(object sender, EventArgs e)
        {
            int money = await LordsMobileAPI.Guild.GetMoneyCountAsync();
            label17.Text = "Монет: " + money;
            int keys = await LordsMobileAPI.Guild.GetKeysCountAsync();
            label15.Text = "Ключей: " + keys;
            label16.Text = "Сила: " + await LordsMobileAPI.Guild.GetPowerCountAsync();
        }
    }
}
