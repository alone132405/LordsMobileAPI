using Binarysharp.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace LordsAPI
{
    public class LordsMobileAPI
    {
        public class Settings
        {
            public static Process GetProcess()
            {
                return Process.GetProcessesByName("Lords Mobile").FirstOrDefault(); // Game process
            }
            public class Resolution
            {
                public static bool Change(Size size)
                {
                    MemorySharp sharp = new MemorySharp(LordsMobileAPI.Settings.GetProcess());
                    Binarysharp.MemoryManagement.Windows.RemoteWindow window = sharp.Windows.MainWindow;
                    window.Width = size.Width;
                    window.Height = size.Height;
                    sharp.Dispose();
                    return true;
                }
                public static async Task<bool> ChangeAsync(Size size)
                {
                    return await Task.Run(() => Change(size));
                }
                public static Size Get()
                {
                    MemorySharp sharp = new MemorySharp(LordsMobileAPI.Settings.GetProcess());
                    Binarysharp.MemoryManagement.Windows.RemoteWindow window = sharp.Windows.MainWindow;
                    sharp.Dispose();
                    return new Size(window.Width, window.Height);
                }
                public static async Task<Size> GetAsync()
                {
                    return await Task.Run(() => Get());
                }
            }
        }
        public class MysteryBox
        {
            public class Actions
            {
                public static bool ClickMysteryBox(LordsMobileAPI.UserInfo.Location location)
                {
                    if (location.type == UserInfo.Location.Locations.Castle)
                    {
                        Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                        MemorySharp sharp = new MemorySharp(LordsMobileAPI.Settings.GetProcess());
                        Binarysharp.MemoryManagement.Windows.RemoteWindow window = sharp.Windows.MainWindow;
                        window.Mouse.MoveTo(game.Width - 175, game.Height - 225);
                        window.Mouse.ClickLeft();
                        sharp.Dispose();
                        return true;
                    }
                    else return false;
                }
                public static bool Colect()
                {
                    Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                    MemorySharp sharp = new MemorySharp(LordsMobileAPI.Settings.GetProcess());
                    Binarysharp.MemoryManagement.Windows.RemoteWindow window = sharp.Windows.MainWindow;
                    window.Mouse.MoveTo(game.Width - 830, game.Height - 225);
                    window.Mouse.ClickLeft();
                    sharp.Dispose();
                    return true;
                }
                public static async Task<bool> ClickMysteryBoxAsync(LordsMobileAPI.UserInfo.Location location)
                {
                    return await Task.Run(() => ClickMysteryBox(location));
                }
                public static async Task<bool> ColectAsync()
                {
                    return await Task.Run(() => Colect());
                }
            }
            public class Get
            { 
                public static string Time()
                {
                    Tesseract.EngineMode mode = Tesseract.EngineMode.Default;
                    Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));

                    Bitmap crop = Utils.Crop(game, new Rectangle(game.Width - 235, game.Height - 185, 100, 30));
                    crop.Save("Crop.png", System.Drawing.Imaging.ImageFormat.Png);
                    string power = Utils.GetTextFromImage(crop, mode);
                    power = power.Replace("_", "");
                    string power2 = Utils.TruncateLongString(power, 7, "");
                    power = power.Replace("L", "");
                    if (power2 == "3a6paTs" && power.Contains("3a6paTs"))
                    {
                        return "Done";
                    }
                    else if (power.Contains(":"))
                    {
                        power2 = Utils.TruncateLongString(power, 5, "");
                        return power2;
                    }
                    else return string.Empty;
                }
                public async static Task<string> TimeAsync()
                {
                    return await Task.Run(() => Time());
                }
            }
        }
        public class MerchantShip
        {
            public class Actions
            {
                public enum BuySlots
                {
                    Slot1,
                    Slot2,
                    Slot3,
                    Slot4,
                }
                public static bool Buy(LordsMobileAPI.UserInfo.Location location, BuySlots slot)
                {
                    if (location.type == UserInfo.Location.Locations.MerchantShip)
                    {
                        Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                        MemorySharp sharp = new MemorySharp(LordsMobileAPI.Settings.GetProcess());
                        Binarysharp.MemoryManagement.Windows.RemoteWindow window = sharp.Windows.MainWindow;
                        if (slot == BuySlots.Slot1)
                            window.Mouse.MoveTo(game.Width - (450 + 713), game.Height - 365);
                        else if (slot == BuySlots.Slot2)
                        {
                            window.Mouse.MoveTo(game.Width - 450, game.Height - 365);
                        }
                        else if (slot == BuySlots.Slot3)
                            window.Mouse.MoveTo(game.Width - (450 + 713), game.Height - (365 - 250));
                        else if (slot == BuySlots.Slot4)
                            window.Mouse.MoveTo(game.Width - 450, game.Height - (365 - 250));
                        window.Activate();
                        window.PostMessage(Binarysharp.MemoryManagement.Native.WindowsMessages.LButtonDown, UIntPtr.Zero, UIntPtr.Zero);
                        window.PostMessage(Binarysharp.MemoryManagement.Native.WindowsMessages.LButtonUp, UIntPtr.Zero, UIntPtr.Zero);
                        sharp.Dispose();
                        return true;
                    }
                    else return false;
                }
                public static async Task<bool> BuyAsync(LordsMobileAPI.UserInfo.Location location, BuySlots slot)
                {
                    return await Task.Run(() => Buy(location, slot));
                }
                public static bool ClickConfirm()
                {
                    Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                    MemorySharp sharp = new MemorySharp(LordsMobileAPI.Settings.GetProcess());
                    Binarysharp.MemoryManagement.Windows.RemoteWindow window = sharp.Windows.MainWindow;
                    window.Mouse.MoveTo(game.Width - 650, game.Height - (365 - 250));
                    window.Mouse.ClickLeft();
                    sharp.Dispose();
                    return true;
                }
                public static async Task<bool> ClickConfirmAsync()
                {
                    return await Task.Run(() => ClickConfirm());
                }
                public static bool NeedResourse()
                {

                    Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                    game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    Bitmap find = Utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\MerchantShip\\NeedResourse.png"));
                    List<Rectangle> done = Utils.Find(game, find);
                    if (done.Count >= 1)
                    {
                        return true;
                    }
                    else return false;
                }
            }
        }

        public class UserInfo
        {
            public class Location
            {
                public string name;
                public Locations type;
                public enum Locations
                {
                    Unknown,

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
                    Guild,
                    GuildShop,
                }
                public static Location GetLocation()
                {
                    
                    Bitmap game = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                    game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    Bitmap find = Utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\gomap.png"));
                    List<Rectangle> done = Utils.Find(game, find);
                    if (done.Count >= 1)
                    {
                        return new Location { name = Locations.Castle.ToString(), type = Locations.Castle };
                    }
                    else
                    {
                        Bitmap game2 = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                        game2.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        Bitmap find2 = Utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\gocastle.png"));
                        List<Rectangle> done2 = Utils.Find(game2, find2);
                        if (done2.Count >= 1)
                        {
                            return new Location { name = Locations.Map.ToString(), type = Locations.Map };
                        }
                        else
                        {
                            Bitmap game3 = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                            game3.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            Bitmap find3 = Utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\BarracksMenuDetect.png"));
                            List<Rectangle> done3 = Utils.Find(game3, find3);
                            if (done3.Count >= 1)
                            {
                                return new Location { name = Locations.Barracks.ToString(), type = Locations.Barracks };
                            }
                            else
                            {
                                Bitmap game4 = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                                game4.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                Bitmap find4 = Utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\SacredTowerMenuDetect.png"));
                                List<Rectangle> done4 = Utils.Find(game4, find4);
                                if (done4.Count >= 1)
                                {
                                    return new Location { name = Locations.SacredTower.ToString(), type = Locations.SacredTower };
                                }
                                else
                                {
                                    Bitmap game5 = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                                    game5.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                    Bitmap find5 = Utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\QuestsMenuDetect.png"));
                                    List<Rectangle> done5 = Utils.Find(game5, find5);
                                    if (done5.Count >= 1)
                                    {
                                        return new Location { name = Locations.Quests.ToString(), type = Locations.Quests };
                                    }
                                    else
                                    {
                                        Bitmap game6 = Utils.ConvertImagePixelType(Utils.GetProgrammImage(LordsMobileAPI.Settings.GetProcess()));
                                        game6.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                        Bitmap find6 = Utils.ConvertImagePixelType((Bitmap)Bitmap.FromFile("game\\MerchantShipMenuDetect.png"));
                                        List<Rectangle> done6 = Utils.Find(game6, find6);
                                        if (done6.Count >= 1)
                                        {
                                            return new Location { name = Locations.MerchantShip.ToString(), type = Locations.MerchantShip };
                                        }
                                        else
                                        {
                                            return new Location { name = Locations.Unknown.ToString(), type = Locations.Unknown };
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                public static async Task<Location> GetLocationAsync()
                {
                    return await Task.Run(() => GetLocation());
                }
            }

            public class Resources
            {
                private static readonly int Width = 160;
                private static readonly int X = 99;
                private static readonly Tesseract.EngineMode mode = Tesseract.EngineMode.Default;
                private static string Replacer(string text)
                {
                    return text.Replace("|", "").Replace(" ", "").Replace(Environment.NewLine, "").Trim();
                }
                public class Food
                {
                    public static double GetCount()
                    {
                        double hpint = 0;
                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x0222B9F8, 0x280, 0x428, 0x78, 0x6b0, 0x10 });
                        hpint = vam.ReadDouble(hp);
                        return hpint;
                    }
                    public static async Task<double> GetCountAsync()
                    {
                        return await Task.Run(() => GetCount());
                    }
                }
                public class Stone
                {
                    public static double GetCount()
                    {
                        double hpint = 0;
                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F6800, 0xb8, 0x0, 0x4d0, 0x5d8, 0x6a0 });
                        hpint = vam.ReadDouble(hp);
                        return hpint;
                    }
                    public static async Task<double> GetCountAsync()
                    {
                        return await Task.Run(() => GetCount());
                    }
                }
                public class Wood
                {
                    public static double GetCount()
                    {
                        double hpint = 0;
                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021DA058, 0x28, 0x730, 0x0, 0x7d0, 0x100 });
                        hpint = vam.ReadDouble(hp);
                        return hpint;
                    }
                    public static async Task<double> GetCountAsync()
                    {
                        return await Task.Run(() => GetCount());
                    }

                }
                public class Ore
                {
                    public static double GetCount()
                    {
                        double hpint = 0;
                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021DA058, 0x28, 0x7d0, 0x0, 0x798, 0xb0 });
                        hpint = vam.ReadDouble(hp);
                        return hpint;
                    }
                    public static async Task<double> GetCountAsync()
                    {
                        return await Task.Run(() => GetCount());
                    }
                }
                public class Gold
                {
                    public static double GetCount()
                    {
                        double hpint = 0;
                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F67B0, 0xb8, 0x18, 0xe8, 0x798, 0x650 });
                        hpint = vam.ReadDouble(hp);
                        return hpint;
                    }
                    public static async Task<double> GetCountAsync()
                    {
                        return await Task.Run(() => GetCount());
                    }
                }
            }
            public class Statistic
            {
                
                public class Stamina
                {
                   public static int Get()
                   {
                       int hpint = 0;
                       VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                       var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x550, 0x260, 0x40, 0x20, 0x328 });
                       hpint = vam.ReadInt32(hp);
                       return hpint;
                   }
                    public static async Task<int> GetAsync()
                    {
                        return await Task.Run(() => Get());
                    }
                }
                public class Power
                {
                    public static int Get()
                    {
                        int hpint = 0;
                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x2b0, 0x180, 0x40, 0x20, 0x3d8 });
                        hpint = vam.ReadInt32(hp);
                        return hpint;
                    }
                    public static async Task<int> GetAsync()
                    {
                        return await Task.Run(() => Get());
                    }
                }
                public class Energy
                {
                    public static int Get()
                    {
                        int hpint = 0;
                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x2b0, 0x470 });
                        hpint = vam.ReadInt32(hp);
                        return hpint;
                    }
                    public static async Task<int> GetAsync()
                    {
                        return await Task.Run(() => Get());
                    }
                }
                public class Gems
                {
                    public static int Get()
                    {
                        int hpint = 0;
                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x4e0, 0x198, 0x40, 0x20, 0x364 });
                        hpint = vam.ReadInt32(hp);
                        return hpint;
                    }
                    public static async Task<int> GetAsync()
                    {
                        return await Task.Run(() => Get());
                    }
                }
                public class Level
                {
                    public class Experience
                    {
                        public class Need
                        {
                            public static int Get()
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x0222B988, 0x210, 0x330, 0x78, 0x30, 0x38c });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                            public static async Task<int> GetAsync()
                            {
                                return await Task.Run(() => Get());
                            }
                        }

                        public static int Get()
                        {
                            int hpint = 0;
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x240, 0x198, 0x40, 0x90, 0x324 });
                            hpint = vam.ReadInt32(hp);
                            return hpint;
                        }
                        public static async Task<int> GetAsync()
                        {
                            return await Task.Run(() => Get());
                        }
                    }
                }
            }
        }
    }
}
