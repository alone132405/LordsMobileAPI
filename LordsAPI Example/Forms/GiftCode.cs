using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LordsAPI_Example.Forms
{
    public partial class GiftCode : Form
    {
        public GiftCode()
        {
            InitializeComponent();
        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text += "\n";
            LordsAPI_GiftActivator.LordsMobileGift.Methods method = LordsAPI_GiftActivator.LordsMobileGift.Methods.IGG_ID;
            Enum.TryParse(comboBox1.Text, out method);
            await Task.Run(async() =>
            {
                string s1 = textBox1.Text;
                string s2 = textBox2.Text;
                var complitestatus = LordsAPI_GiftActivator.LordsMobileGift.Activate(method, s1, s2);
                if (method == LordsAPI_GiftActivator.LordsMobileGift.Methods.IGG_ID)
                {
                    richTextBox2.Invoke((MethodInvoker)(() => richTextBox2.Text += "[Gift Result] IGG ID: " + s1 + ", Code: " + s2 + ", Result: " + complitestatus.Result + Environment.NewLine));
                    Console.WriteLine("[Gift Result] IGG ID: " + s1 + ", Code: " + s2 + ", Result: " + complitestatus.Result);
                }
                else if (method == LordsAPI_GiftActivator.LordsMobileGift.Methods.Nickname)
                {
                    richTextBox2.Invoke((MethodInvoker)(() => richTextBox2.Text += "[Gift Result] Nickname: " + s1 + ", Code: " + s2 + ", Power: " + complitestatus.Power + ", Kingdom:" + complitestatus.Kingdom + ", Result: " + complitestatus.Result + Environment.NewLine));
                    Console.WriteLine("[Gift Result] Nickname: " + s1 + ", Code: " + s2 + ", Power: " + complitestatus.Power + ", Kingdom:" + complitestatus.Kingdom + ", Result: " + complitestatus.Result);
                }
            });
        }

        public bool Activate(string methodst, string s1, string s2)
        {
            LordsAPI_GiftActivator.LordsMobileGift.Methods method = LordsAPI_GiftActivator.LordsMobileGift.Methods.IGG_ID;
            Enum.TryParse(methodst, out method);
            var complitestatus = LordsAPI_GiftActivator.LordsMobileGift.Activate(method, s1, s2);
            if (method == LordsAPI_GiftActivator.LordsMobileGift.Methods.IGG_ID)
            {
                richTextBox2.Invoke((MethodInvoker)(() => richTextBox2.Text += "[Gift Result] IGG ID: " + s1 + ", Code: " + s2 + ", Result: " + complitestatus.Result + Environment.NewLine));
                Console.WriteLine("[Gift Result] IGG ID: " + s1 + ", Code: " + s2 + ", Result: " + complitestatus.Result);
            }
            else if(method == LordsAPI_GiftActivator.LordsMobileGift.Methods.Nickname)
            {
                richTextBox2.Invoke((MethodInvoker)(() => richTextBox2.Text += "[Gift Result] Nickname: " + s1 + ", Code: " + s2 + ", Power: " + complitestatus.Power + ", Kingdom:" + complitestatus.Kingdom + ", Result: " + complitestatus.Result + Environment.NewLine));
                Console.WriteLine("[Gift Result] Nickname: " + s1 + ", Code: " + s2 + ", Power: " + complitestatus.Power + ", Kingdom:" + complitestatus.Kingdom + ", Result: " + complitestatus.Result);
            }
            return true;
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            string met = comboBox1.Text;
            foreach (string prom in richTextBox1.Text.Split(Environment.NewLine.ToCharArray()))
            {
                if (prom != "")
                {
                    Thread th = new Thread(() =>
                    {
                        Activate(met, s1, prom);
                    });
                    th.Start();
                }
            }            
        }

        private void GiftCode_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Join("\n", LordsAPI.LordsMobileAPI.API.LocalUser.PromoCodes.All);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.SelectionStart = richTextBox2.Text.Length;
            // scroll it automatically
            richTextBox2.ScrollToCaret();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
