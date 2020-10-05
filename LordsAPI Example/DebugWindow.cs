using Binarysharp.MemoryManagement;
using LordsAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LordsAPI_Example
{
    public partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        private async void DebugWindow_Load(object sender, EventArgs e)
        {
            //Size resolution = await LordsMobileAPI.Settings.Resolution.GetAsync();
            //if (resolution.Width != 1616 && resolution.Height != 939)
            //    await LordsMobileAPI.Settings.Resolution.ChangeAsync(new Size(1616, 939));

            Bitmap image = Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess());
            pictureBox1.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap image = Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess());
            pictureBox1.Image = image;
        }
        bool hold = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                MemorySharp sharp = new MemorySharp(Process.GetProcessesByName("Lords Mobile").FirstOrDefault());
                var window = sharp.Windows.MainWindow;
                window.SendMessage(Binarysharp.MemoryManagement.Native.WindowsMessages.LButtonDown, UIntPtr.Zero, IntPtr.Zero);
                hold = true;
                sharp.Dispose();
                Bitmap image = Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess());
                pictureBox1.Image = image;
            }
            else
            {
                int x, y;
                StringBuilder sb = new StringBuilder();
                double ratio = 1.0 * pictureBox1.Width / pictureBox1.Image.Width;
                x = (int)(e.X / ratio);
                y = (int)(e.Y / ratio);
                Bitmap bmp = new Bitmap(pictureBox1.Image, pictureBox1.Image.Size.Width, pictureBox1.Image.Size.Height);
                bmp.SetResolution(pictureBox1.Image.HorizontalResolution, pictureBox1.Image.VerticalResolution);
                sb.Append(e.X);
                sb.Append(' ');
                sb.Append(e.Y);
                sb.Append("\r\n");
                sb.Append(bmp.GetPixel(x, y));
                sb.Append("\r\n");
                sb.Append(ratio);

                MessageBox.Show(sb.ToString());
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (hold)
                {
                    MemorySharp sharp = new MemorySharp(LordsMobileAPI.Settings.GetProcess());
                    var window = sharp.Windows.MainWindow;
                    window.SendMessage(Binarysharp.MemoryManagement.Native.WindowsMessages.LButtonUp, UIntPtr.Zero, IntPtr.Zero);
                    hold = false;
                    sharp.Dispose();
                    Bitmap image = Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess());
                    pictureBox1.Image = image;
                }
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            Size resolution = await LordsMobileAPI.Settings.Resolution.GetAsync();
            if (resolution.Width != 1616 && resolution.Height != 939)
                await LordsMobileAPI.Settings.Resolution.ChangeAsync(new Size(1616, 939));

            Bitmap image = Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess());
            pictureBox1.Image = image;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox2.Checked;
        }
    }
}
