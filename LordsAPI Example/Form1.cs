
using Binarysharp.MemoryManagement;
using LordsAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Utils utils = new Utils();
            Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
            //Console.WriteLine(game.Width);
            //Console.WriteLine(game.Height);
            game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Bitmap find = utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile(@"game\\gotocastle.png"));
            List<Rectangle> done = utils.Find(game, find);
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
                Utils utils = new Utils();
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                //Console.WriteLine(game.Width);
                //Console.WriteLine(game.Height);
                game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\wood2.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = utils.Find(game, find, 0.5);
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
                Utils utils = new Utils();
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                //Console.WriteLine(game.Width);
                //Console.WriteLine(game.Height);
                game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\gold2.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = utils.Find(game, find, 0.5f);
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
            Utils utils = new Utils();
            Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
            //Console.WriteLine(game.Width);
            //Console.WriteLine(game.Height);
            game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\gaterbutton.png");
            find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
            List<Rectangle> done = utils.Find(game, find, 0.6);
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
                Utils utils2 = new Utils();
                Bitmap game2 = utils2.ConvertImagePixelType(utils2.GetProgrammImage(process2));
                //Console.WriteLine(game.Width);
                //Console.WriteLine(game.Height);
                game2.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find2 = (Bitmap)Bitmap.FromFile(@"game\\armyhave1.png");
                find2.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done2 = utils2.Find(game2, find2, 0.6);
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
                        Utils utils = new Utils();
                        Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                        //Console.WriteLine(game.Width);
                        //Console.WriteLine(game.Height);
                        game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\typevishkabutton.png");
                        find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                        List<Rectangle> done = utils.Find(game, find, 0.6);
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
                        Utils utils = new Utils();
                        Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                        //Console.WriteLine(game.Width);
                        //Console.WriteLine(game.Height);
                        game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\goattackbutton.png");
                        find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                        List<Rectangle> done = utils.Find(game, find, 0.6);
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
                Utils utils = new Utils();
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                //Console.WriteLine(game.Width);
                //Console.WriteLine(game.Height);
                game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\hand.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = utils.Find(game, find, 0.4);
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
                Utils utils = new Utils();
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                //Console.WriteLine(game.Width);
                //Console.WriteLine(game.Height);
                game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\handall.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = utils.Find(game, find, 0.6);
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
            LordsMobileAPI.UserInfo.Location location = await LordsMobileAPI.UserInfo.Location.GetLocationAsync();
            Console.WriteLine(location);
            if (location.type == LordsMobileAPI.UserInfo.Location.Locations.Castle || location.type == LordsMobileAPI.UserInfo.Location.Locations.Map)
            {
                string level = await LordsMobileAPI.UserInfo.Statistic.GetInfomationAsync(LordsMobileAPI.UserInfo.Statistic.Statistics.Level);
                Console.WriteLine("Уровень: " + level);
                label3.Text = "Уровень: " + level;
                string power = await LordsMobileAPI.UserInfo.Statistic.GetInfomationAsync(LordsMobileAPI.UserInfo.Statistic.Statistics.Power);
                Console.WriteLine("Сила: " + power);
                label1.Text = "Сила: " + power;
                string gems = await LordsMobileAPI.UserInfo.Statistic.GetInfomationAsync(LordsMobileAPI.UserInfo.Statistic.Statistics.Gems);
                Console.WriteLine("Самоцветы: " + gems);
                label2.Text = "Самоцветы: " + gems;
                /* Resource */
                string food = await LordsMobileAPI.UserInfo.Resources.Food.GetCountAsync();
                Console.WriteLine("Еда: " + food);
                label5.Text = "Еда: " + food;
                string stone = await LordsMobileAPI.UserInfo.Resources.Stone.GetCountAsync();
                Console.WriteLine("Камень: " + stone);
                label7.Text = "Камень: " + stone;
                string wood = await LordsMobileAPI.UserInfo.Resources.Wood.GetCountAsync();
                Console.WriteLine("Дерево: " + wood);
                label6.Text = "Дерево: " + wood;
                string ore = await LordsMobileAPI.UserInfo.Resources.Ore.GetCountAsync();
                Console.WriteLine("Руда: " + ore);
                label8.Text = "Руда: " + ore;
                string gold = await LordsMobileAPI.UserInfo.Resources.Gold.GetCountAsync();
                Console.WriteLine("Золото: " + gold);
                label9.Text = "Золото: " + gold;
            }
            else
            {
                Console.WriteLine(location);
            }
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
            LordsMobileAPI.UserInfo.Location location = await LordsMobileAPI.UserInfo.Location.GetLocationAsync();
            if (location.type == LordsMobileAPI.UserInfo.Location.Locations.Castle)
            {
                label4.Text = "Коробка: " + await LordsMobileAPI.UserInfo.Statistic.GetInfomationAsync(LordsMobileAPI.UserInfo.Statistic.Statistics.MysteryBox);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (1 != 0)
            {
                Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                MemorySharp sharp = new MemorySharp(process);
                // Get the window
                var window = sharp.Windows.MainWindow;
                Utils utils = new Utils();
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));

                Bitmap crop = utils.Crop(game, new Rectangle(game.Width - 235, game.Height - 185, 100, 30));
                crop.Save("Crop.png", System.Drawing.Imaging.ImageFormat.Png);
                string power = utils.GetTextFromImage(crop);
                string power2 = utils.TruncateLongString(power, 7, "");
                if (power2 == "3a6paTs" && power.Contains("3a6paTs"))
                {
                    game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                    window.Activate();
                    window.Mouse.MoveTo(game.Width - 175, game.Height - 225);
                    window.Mouse.ClickLeft();
                }
                else if (power.Contains(":"))
                {
                    power2 = utils.TruncateLongString(power, 5, "");
                    label4.Text = "Коробка: " + power2;
                }
                Console.WriteLine(power);
                sharp.Dispose();
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            LordsMobileAPI.UserInfo.Location location = await LordsMobileAPI.UserInfo.Location.GetLocationAsync();
            if (location.type == LordsMobileAPI.UserInfo.Location.Locations.Map || location.type == LordsMobileAPI.UserInfo.Location.Locations.Castle)
            {
                string food = await LordsMobileAPI.UserInfo.Resources.Food.GetCountAsync();
                Console.WriteLine("Еда: " + food);
                label5.Text = "Еда: " + food;
                string stone = await LordsMobileAPI.UserInfo.Resources.Stone.GetCountAsync();
                Console.WriteLine("Камень: " + stone);
                label7.Text = "Камень: " + stone;
                string wood = await LordsMobileAPI.UserInfo.Resources.Wood.GetCountAsync();
                Console.WriteLine("Дерево: " + wood);
                label6.Text = "Дерево: " + wood;
                string ore = await LordsMobileAPI.UserInfo.Resources.Ore.GetCountAsync();
                Console.WriteLine("Руда: " + ore);
                label8.Text = "Руда: " + ore;
                string gold = await LordsMobileAPI.UserInfo.Resources.Gold.GetCountAsync();
                Console.WriteLine("Золото: " + gold);
                label9.Text = "Золото: " + gold;
            }
        }
    }
}
