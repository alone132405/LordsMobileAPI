using DirectX_Renderer;
using LordsAPI;
using LordsAPI_Example.Forms;
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
using System.Runtime.InteropServices;
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

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            this.Text = "";
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private LordsMobileAPI api = new LordsMobileAPI();
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Overlay_SharpDX overlay = new Overlay_SharpDX(LordsMobileAPI.Settings.GetProcess);
            Thread thread1 = new Thread(() =>
            {
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
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        // Drag
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private FontAwesome.Sharp.IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (FontAwesome.Sharp.IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Castle());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new Guild());
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
