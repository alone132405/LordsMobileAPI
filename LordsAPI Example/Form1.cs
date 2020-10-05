
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
        private async void button8_Click(object sender, EventArgs e)
        {
            int energy = await LordsMobileAPI.UserInfo.Statistic.Energy.GetAsync();
            Console.WriteLine("Энергия: " + energy);
            label11.Text = "Энергия: " + energy.ToString();
            int stamina = await LordsMobileAPI.UserInfo.Statistic.Stamina.GetAsync();
            label10.Text = "Выносливость: " + stamina.ToString() + "/120";
            int gems = await LordsMobileAPI.UserInfo.Statistic.Gems.GetAsync();
            label2.Text = "Самоцветы: " + gems.ToString();
            int power = await LordsMobileAPI.UserInfo.Statistic.Power.GetAsync();
            label1.Text = "Сила: " + power.ToString();
            int xp = await LordsMobileAPI.UserInfo.Statistic.Level.Experience.GetAsync();
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
                time = "Collect";
            label4.Text = "Коробка: " + time;
            label20.Text = "Дистанция: " + await LordsMobileAPI.UserInfo.Location.GetDistanceToCasteAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            label19.Text = "Рук: " + await LordsMobileAPI.Guild.GetHelpOtherUsersCountAsync();
        }
    }
}
