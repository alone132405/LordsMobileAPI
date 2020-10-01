using Binarysharp.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LordsAPI
{
    public class LordsMobileAPI
    {
        public string Get(GetTypes type)
        {
            Utils utils = new Utils();
            Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
            if (type == GetTypes.PlayerPower)
            {
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                // Get the window
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\power.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = utils.Find(game, find, 0.7);
                if (done.Count >= 1)
                {
                    //window.Mouse.MoveTo(done[0].X + 135, done[0].Y + 3);
                    Bitmap crop = utils.Crop(game, new Rectangle(done[0].X + 135, done[0].Y + 3, 200, 30));
                    crop.Save("Crop.png", System.Drawing.Imaging.ImageFormat.Png);
                    string power = utils.GetTextFromImage(crop);
                    return power;
                }
                else return string.Empty;
            }
            else if (type == GetTypes.PlayerGems)
            {
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                // Get the window
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\power.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = utils.Find(game, find, 0.7);
                if (done.Count >= 1)
                {
                    Bitmap crop = utils.Crop(game, new Rectangle(done[0].X + 155, done[0].Y + 55, 200, 30));
                    crop.Save("Crop.png", System.Drawing.Imaging.ImageFormat.Png);
                    string power = utils.GetTextFromImage(crop);
                    return power.Replace("Mt ", "").Replace("‘", "");
                }
                else return string.Empty;
            }
            else if (type == GetTypes.PlayerLevel)
            {
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                // Get the window
                Bitmap find = (Bitmap)Bitmap.FromFile(@"game\\power.png");
                find.Save("find.png", System.Drawing.Imaging.ImageFormat.Png);
                List<Rectangle> done = utils.Find(game, find, 0.7);
                if (done.Count >= 1)
                {
                    //window.Mouse.MoveTo(done[0].X + 10, done[0].Y + 156);
                    Bitmap crop = utils.Crop(game, new Rectangle(done[0].X + 10, done[0].Y + 156, 33, 25));
                    crop.Save("Crop.png", System.Drawing.Imaging.ImageFormat.Png);
                    string power = utils.GetTextFromImage(crop);
                    return utils.TruncateLongString(power, 2, "");
                }
                else return string.Empty;
            }
            else if (type == GetTypes.MysteryBox)
            {
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));

                Bitmap crop = utils.Crop(game, new Rectangle(game.Width - 235, game.Height - 185, 100, 30));
                crop.Save("Crop.png", System.Drawing.Imaging.ImageFormat.Png);
                string power = utils.GetTextFromImage(crop);
                string power2 = utils.TruncateLongString(power, 7, "");
                power = power.Replace("L", "");
                if (power2 == "3a6paTs" && power.Contains("3a6paTs"))
                {
                    return "Done";
                }
                else if (power.Contains(":"))
                {
                    power2 = utils.TruncateLongString(power, 5, "");
                    return power2;
                }
                else return string.Empty;
            }
            else if (type == GetTypes.Location)
            {
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find = utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\gomap.png"));
                List<Rectangle> done = utils.Find(game, find);
                if (done.Count >= 1)
                {
                    return Locations.Castle.ToString();
                }
                else
                {
                    Bitmap game2 = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                    game2.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    Bitmap find2 = utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\gocastle.png"));
                    List<Rectangle> done2 = utils.Find(game2, find2);
                    if (done2.Count >= 1)
                    {
                        return Locations.Map.ToString();
                    }
                    else
                    {
                        Bitmap game3 = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                        game3.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        Bitmap find3 = utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\BarracksMenuDetect.png"));
                        List<Rectangle> done3 = utils.Find(game3, find3);
                        if (done3.Count >= 1)
                        {
                            return Locations.Barracks.ToString();
                        }
                        else
                        {
                            Bitmap game4 = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                            game4.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            Bitmap find4 = utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\SacredTowerMenuDetect.png"));
                            List<Rectangle> done4 = utils.Find(game4, find4);
                            if (done4.Count >= 1)
                            {
                                return Locations.SacredTower.ToString();
                            }
                            else
                            {
                                Bitmap game5 = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                                game5.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                Bitmap find5 = utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\QuestsMenuDetect.png"));
                                List<Rectangle> done5 = utils.Find(game5, find5);
                                if (done5.Count >= 1)
                                {
                                    return Locations.Quests.ToString();
                                }
                                else
                                {
                                    return string.Empty;
                                }
                            }
                        }
                    }
                }
            }
            else return string.Empty;
        }
        public async Task<string> GetAsync(GetTypes type)
        {
            return await Task.Run(() => Get(type));
        }
        public string Action(Actions action, bool WindowStateBack)
        {
            Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
            Utils utils = new Utils();
            if (action == Actions.EnterTheCastle)
            {
                string location = Get(GetTypes.Location);
                if (location == "Map")
                {
                    MemorySharp sharp = new MemorySharp(process);
                    var window = sharp.Windows.MainWindow;
                    bool activate = window.IsActivated;
                    Point cursor2 = Cursor.Position;
                    if (window.State != Binarysharp.MemoryManagement.Native.WindowStates.Show && window.State != Binarysharp.MemoryManagement.Native.WindowStates.ShowDefault)
                    {
                        window.Activate();
                    }
                    window.Mouse.MoveTo(window.Width - 1500, window.Height - 85);
                    window.Mouse.ClickLeft();
                    if (!activate && WindowStateBack)
                    {
                        Thread.Sleep(20);
                        window.State = Binarysharp.MemoryManagement.Native.WindowStates.Minimize;
                    }
                    Cursor.Position = cursor2;
                    sharp.Dispose();
                    return "Object pressed";
                }
                else { return "You need to be on the map for this action"; }
            }
            else if (action == Actions.EnterTheMap)
            {
                string location = Get(GetTypes.Location);
                if (location == "Castle")
                {
                    MemorySharp sharp = new MemorySharp(process);
                    var window = sharp.Windows.MainWindow;
                    bool activate = window.IsActivated;
                    Point cursor2 = Cursor.Position;
                    if (window.State != Binarysharp.MemoryManagement.Native.WindowStates.Show && window.State != Binarysharp.MemoryManagement.Native.WindowStates.ShowDefault)
                    {
                        window.Activate();
                    }
                    window.Mouse.MoveTo(window.Width - 1500, window.Height - 85);
                    window.Mouse.ClickLeft();
                    if (!activate && WindowStateBack)
                    {
                        Thread.Sleep(20);
                        window.State = Binarysharp.MemoryManagement.Native.WindowStates.Minimize;
                    }
                    Cursor.Position = cursor2;
                    sharp.Dispose();
                    return "Object pressed";
                }
                else { return "You need to be on the castle for this action"; }
            }
            else { return "Unknown action"; }
        }
        public enum Actions
        {
            EnterTheCastle,
            EnterTheMap,
        }

        public enum Locations
        {
            Castle,
            Map,
            MerchantShip,
            Coliseum,
            Menagerie,
            SacredTower,
            Aviary,
            Academy,
            Barracks,
            Quests,
        }

        public enum GetTypes
        {
            Location,
            PlayerPower,
            PlayerGems,
            PlayerLevel,
            MysteryBox,
        }
    }
}
