using AForge.Imaging;
using Binarysharp.MemoryManagement;
using IronOcr;
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

namespace LordsMobile_by_Nekiplay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
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
            Bitmap find = utils.ConvertImagePixelType(AForge.Imaging.Image.FromFile("game\\gomap.png"));
            List<Rectangle> done = utils.Find(game, find);
            foreach (Rectangle rec in done)
            {
                window.Activate();
                window.Mouse.MoveTo(rec.X + 64, rec.Y + 32);
                window.Mouse.ClickLeft();
                Console.WriteLine(rec.X);
                Console.WriteLine(rec.Y);

            }
            //done.Save("test.jpg");

        }

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
            Bitmap find = utils.ConvertImagePixelType(AForge.Imaging.Image.FromFile(@"game\\gotocastle.png"));
            List<Rectangle> done = utils.Find(game, find);
            if (done.Count == 1)
            {
                window.Activate();
                window.Mouse.MoveTo(done[0].X, done[0].Y);
                window.Mouse.ClickLeft();
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
                Bitmap find = AForge.Imaging.Image.FromFile(@"game\\wood2.png");
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
                Bitmap find = AForge.Imaging.Image.FromFile(@"game\\gold2.png");
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
            Bitmap find = AForge.Imaging.Image.FromFile(@"game\\gaterbutton.png");
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
                Bitmap find2 = AForge.Imaging.Image.FromFile(@"game\\armyhave1.png");
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
                        Bitmap find = AForge.Imaging.Image.FromFile(@"game\\typevishkabutton.png");
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
                        Bitmap find = AForge.Imaging.Image.FromFile(@"game\\goattackbutton.png");
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
                Bitmap find = AForge.Imaging.Image.FromFile(@"game\\hand.png");
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
            }
            Thread.Sleep(500);
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
                Bitmap find = AForge.Imaging.Image.FromFile(@"game\\handall.png");
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
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
            MemorySharp sharp = new MemorySharp(process);
            var window = sharp.Windows.MainWindow;
            Utils utils = new Utils();
            if (1 != 0)
            {
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                // Get the window
                Bitmap find = AForge.Imaging.Image.FromFile(@"game\\power.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = utils.Find(game, find, 0.7);
                string energy = "";
                if (done.Count >= 1)
                {
                    //window.Mouse.MoveTo(done[0].X + 135, done[0].Y + 3);
                    Bitmap crop = utils.Crop(game, new Rectangle(done[0].X + 135, done[0].Y + 3, 200, 30));
                    crop.Save("Crop.png", System.Drawing.Imaging.ImageFormat.Png);
                    string power = utils.GetTextFromImage(crop);
                    label1.Text = "Сила: " + power;
                }
                else
                {

                }
                sharp.Dispose();
            }
            if (1 != 0)
            {
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                // Get the window
                Bitmap find = AForge.Imaging.Image.FromFile(@"game\\power.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = utils.Find(game, find, 0.7);
                if (done.Count >= 1)
                {
                    Bitmap crop = utils.Crop(game, new Rectangle(done[0].X + 155, done[0].Y + 55, 200, 30));
                    crop.Save("Crop.png", System.Drawing.Imaging.ImageFormat.Png);
                    string power = utils.GetTextFromImage(crop);
                    label2.Text = "Самоцветы: " + power.Replace("Mt ", "");
                }
                else
                {
            
                }
                sharp.Dispose();
            }
            if (1 != 0)
            {
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                // Get the window
                Bitmap find = AForge.Imaging.Image.FromFile(@"game\\power.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = utils.Find(game, find, 0.7);
                if (done.Count >= 1)
                {
                    //window.Mouse.MoveTo(done[0].X + 10, done[0].Y + 156);
                    Bitmap crop = utils.Crop(game, new Rectangle(done[0].X + 10, done[0].Y + 156, 33, 25));
                    crop.Save("Crop.png", System.Drawing.Imaging.ImageFormat.Png);
                    string power = utils.GetTextFromImage(crop);
                    label3.Text = "Уровень: " + utils.TruncateLongString(power, 2, "");
                }
                else
                {
            
                }
                sharp.Dispose();
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
    }
}
