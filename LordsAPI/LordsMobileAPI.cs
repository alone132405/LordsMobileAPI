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
        public class Offsets
        { 

        }
        public class API
        {
            public class Server
            {
                public class Get
                {
                    public static string IP()
                    {
                        string ip = "";
                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021DA058, 0xb0, 0x6e0, 0x2c0, 0x7b8, 0x14 });
                        ip = vam.ReadStringUnicode(hp, 22);
                        return ip;
                    }
                    public static async Task<string> IPAsync()
                    {
                        return await Task.Run(() => IP());
                    }
                }
            }
            public class LocalUser
            {
                public class Auth
                {
                    public class Get
                    {
                        public static string IGGID()
                        {
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021DA058, 0xb0, 0x6e0, 0x2c0, 0x710, 0x14 });
                            string iggid = vam.ReadStringUnicode(hp, 26);
                            return iggid;
                        }
                        public static async Task<string> IGGIDAsync()
                        {
                            return await Task.Run(() => IGGID());
                        }
                    }
                }
                public class Statistic
                {
                    public class Stamina
                    {
                        public class Get
                        {
                            public static int Count()
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x550, 0x260, 0x40, 0x20, 0x328 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                            public static async Task<int> CountAsync()
                            {
                                return await Task.Run(() => Count());
                            }
                        }
                    }
                    public class Power
                    {
                        public class Get
                        {
                            public static int Count()
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x550, 0x180, 0x40, 0x20, 0x3d8 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                            public static async Task<int> CountAsync()
                            {
                                return await Task.Run(() => Count());
                            }
                        }
                    }
                    public class Energy
                    {
                        public class Get
                        {
                            public static int Count()
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                var hp = Utils.PointRead(Utils.getModuleAdress("UnityPlayer.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x014E16E0, 0x510, 0x4f0, 0x130, 0x20, 0x470 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                            public static async Task<int> CountAsync()
                            {
                                return await Task.Run(() => Count());
                            }
                        }
                    }
                    public class Gems
                    {
                        public class Get
                        {
                            public static int Count()
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x630, 0x198, 0x40, 0x20, 0x364 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                            public static async Task<int> CountAsync()
                            {
                                return await Task.Run(() => Count());
                            }
                        }
                    }
                    public class Level
                    {
                        public class Experience
                        {
                            public class Get
                            {
                                public static int Count()
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x550, 0x188, 0x40, 0x20, 0x324 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                                public static async Task<int> CountAsync()
                                {
                                    return await Task.Run(() => Count());
                                }
                            }
                        }
                    }
                }
                public class Guild
                {
                    public class Shop
                    {
                        public class Get
                        {
                            public static int Money()
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x550, 0x60, 0x40, 0x20, 0x528 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                            public static async Task<int> MoneyAsync()
                            {
                                return await Task.Run(() => Money());
                            }
                        }
                    }
                    public class Gifts
                    {
                        public class Get
                        {
                            public static int Keys()
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F06C8, 0x550, 0x188, 0x40, 0x20, 0x548 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                            public static async Task<int> KeysAsync()
                            {
                                return await Task.Run(() => Keys());
                            }
                        }
                    }
                    public class Help
                    {
                        public class OtherUser
                        {
                            public class Get
                            {
                                public static int Count()
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021EFCF0, 0x40, 0x50, 0xb8, 0x28, 0x7f8 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                                public static async Task<int> CountAsync()
                                {
                                    return await Task.Run(() => Count());
                                }
                            }
                        }
                    }
                }
                public class Castle
                {
                    public class Coliseum
                    {
                        public class Get
                        {
                            public static int Gems
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021FDA50, 0x98, 0x468, 0x88, 0xc0, 0x40 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                            public static async Task<int> GemsAsync()
                            {
                                return await Task.Run(() => Gems);
                            }
                            public static int Rank
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021FD170, 0x40, 0x40, 0xb8, 0x130, 0x24 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                            public static async Task<int> RangAsync()
                            {
                                return await Task.Run(() => Rank);
                            }
                        }
                    }
                    public class Get
                    {
                        public static string DistanceToCaste
                        {
                            get
                            {
                                string hpint = "4.4 км";
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x0222B9F8, 0x280, 0x2d8, 0x158, 0x18, 0x14 });
                                hpint = vam.ReadStringUnicode(hp, 32);
                                if (string.IsNullOrEmpty(hpint))
                                    hpint = "4.4 км";
                                return hpint;
                            }
                        }
                        public static async Task<string> DistanceToCasteAsync()
                        {
                            return await Task.Run(() => DistanceToCaste);
                        }
                    }
                    public class MysteryBox
                    {
                        public class Get
                        {
                            public static string Time
                            {
                                get
                                {
                                    string hpint = "00:00:00";
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x0222B9F8, 0x280, 0x2d8, 0x760, 0xc0, 0x14 });
                                    hpint = vam.ReadStringUnicode(hp, 14);
                                    return hpint;
                                }
                            }
                            public static async Task<string> TimeAsync()
                            {
                                return await Task.Run(() => Time);
                            }
                        }
                    }
                    public class Resources
                    {
                        public class Food
                        {
                            public class Get
                            {
                                public static double Count
                                {
                                    get
                                    {
                                        double hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x0222B9F8, 0x280, 0x428, 0x78, 0x6b0, 0x10 });
                                        hpint = vam.ReadDouble(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<double> CountAsync()
                                {
                                    return await Task.Run(() => Count);
                                }
                                public static int Maximum
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021E7AD0, 0x90, 0x0, 0x90, 0x0, 0x90, 0x0, 0xb8, 0x8, 0x28, 0x388 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<int> MaximumAsync()
                                {
                                    return await Task.Run(() => Maximum);
                                }
                            }
                        }
                        public class Stone
                        {
                            public class Get
                            {
                                public static double Count
                                {
                                    get
                                    {
                                        double hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x0222B9F8, 0x3d0, 0x678, 0x20, 0x620, 0x600 });
                                        hpint = vam.ReadDouble(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<double> CountAsync()
                                {
                                    return await Task.Run(() => Count);
                                }
                                public static int Maximum
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x02210BA8, 0x158 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<int> MaximumAsync()
                                {
                                    return await Task.Run(() => Maximum);
                                }
                            }
                        }
                        public class Wood
                        {
                            public class Get
                            {
                                public static double Count
                                {
                                    get
                                    {
                                        double hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021DA058, 0x28, 0x730, 0x0, 0x7d0, 0x100 });
                                        hpint = vam.ReadDouble(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<double> CountAsync()
                                {
                                    return await Task.Run(() => Count);
                                }
                                public static int Maximum
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021DA058, 0x28, 0x780, 0x0, 0x7e8, 0x108 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<int> MaximumAsync()
                                {
                                    return await Task.Run(() => Maximum);
                                }
                            }
                        }
                        public class Ore
                        {
                            public class Get
                            {
                                public static double Count
                                {
                                    get
                                    {
                                        double hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021DA058, 0x28, 0x7d0, 0x0, 0x798, 0xb0 });
                                        hpint = vam.ReadDouble(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<double> CountAsync()
                                {
                                    return await Task.Run(() => Count);
                                }
                                public static int Maximum
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021DA058, 0x28, 0x780, 0x0, 0x7e8, 0xb8 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<int> MaximumAsync()
                                {
                                    return await Task.Run(() => Maximum);
                                }
                            }
                        }
                        public class Gold
                        {
                            public class Get
                            {
                                public static double Count
                                {
                                    get
                                    {
                                        double hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F67B0, 0xb8, 0x18, 0xe8, 0x798, 0x650 });
                                        hpint = vam.ReadDouble(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<double> CountAsync()
                                {
                                    return await Task.Run(() => Count);
                                }
                                public static int Maximum
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x02210BA8, 0x68 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<int> MaximumAsync()
                                {
                                    return await Task.Run(() => Maximum);
                                }
                            }
                        }
                        public class Anima
                        {
                            public class Get
                            {
                                public static double Count
                                {
                                    get
                                    {
                                        double hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021F6C50, 0xb8, 0x0, 0xd8, 0x200, 0xb0 });
                                        hpint = vam.ReadDouble(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<double> CountAsync()
                                {
                                    return await Task.Run(() => Count);
                                }
                                public static int Maximum
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess()), new[] { 0x021FF888, 0x688, 0x250, 0x18, 0x708, 0x158 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<int> MaximumAsync()
                                {
                                    return await Task.Run(() => Maximum);
                                }
                            }
                        }
                    }
                }
                public class Map
                {

                }
            }
        }

        public class Settings
        {
            public static Process GetProcess()
            {
                Process[] processes = Process.GetProcessesByName("Lords Mobile");
                if (processes.Count() > 0)
                    return processes[0];
                else return Process.GetCurrentProcess();
            }
        }
    }
}
