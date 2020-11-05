using LordsAPI.Memory;
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
                    public static string[] ActatedPromoCodes
                    {
                        get
                        {
                            List<string> codes = new List<string>();
                            codes.Add("LM001");
                            codes.Add("LM648");
                            codes.Add("3N7YUXV6");
                            codes.Add("6XEK34RJ");
                            codes.Add("8FBC9J");
                            return codes.ToArray();

                        }
                    }
                    public static string[] PromoCodes
                    {
                        get
                        {
                            string ip = "";
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022B3138, 0x58, 0x50, 0x48, 0xE38, 0x78, 0xB20 });
                            ip = vam.ReadStringUnicode(hp, 9000);
                            List<string> codes = new List<string>();
                            ip = ip.Replace(" ", "");
                            codes.AddRange(ip.Split(','));
                            return codes.ToArray();
                        }
                    }
                    public static string Version
                    {
                        get
                        {
                            string ip = "";
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AA630, 0x98, 0x58, 0x18, 0xB8, 0x88, 0xA0, 0x14 });
                            ip = vam.ReadStringUnicode(hp, 22);
                            return ip;
                        }
                    }
                    public static string IPandPort
                    {
                        get
                        {
                            string ip = "";
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AF3A8, 0x40, 0x98, 0x118, 0x18, 0xB8, 0xD8, 0x14 });
                            ip = vam.ReadStringUnicode(hp, 42);
                            return ip + ":5991";
                        }
                    }
                    public static async Task<string> IPAsync()
                    {
                        return await Task.Run(() => IPandPort);
                    }
                    public static string Nickname
                    {
                        get
                        {
                            string ip = "";
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x0222B9F8, 0x280, 0x450, 0x108, 0x760, 0x4d4 });
                            ip = vam.ReadStringUnicode(hp, 22);
                            return ip;
                        }
                    }
                    public static async Task<string> NicknameAsync()
                    {
                        return await Task.Run(() => Nickname);
                    }
                }
            }
            public class LocalUser
            {
                public class Auth
                {
                    public class Get
                    {
                        public static string IGG_ID
                        {
                            get
                            {
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022A6F50, 0xB8, 0x18, 0x18, 0x100, 0x228, 0x8E0, 0x14 });
                                string iggid = vam.ReadStringUnicode(hp, 26);
                                return iggid;
                            }
                        }
                        public static async Task<string> IGG_IDAsync()
                        {
                            return await Task.Run(() => IGG_ID);
                        }
                    }
                }
                public class Statistic
                {
                    public class Stamina
                    {
                        public class Get
                        {
                            public static int Count
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AE928, 0x40, 0xB8, 0x18, 0x200, 0x40, 0x20, 0x330 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                            public static async Task<int> CountAsync()
                            {
                                return await Task.Run(() => Count);
                            }
                        }
                    }
                    public class Power
                    {
                        public class Get
                        {
                            public static int Count
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AE928, 0x40, 0xB8, 0x18, 0x160, 0x40, 0x20, 0x3E8 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                            public static async Task<int> CountAsync()
                            {
                                return await Task.Run(() => Count);
                            }
                        }
                    }
                    public class Energy
                    {
                        public class Get
                        {
                            public static int Count
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AE928, 0x40, 0xB8, 0x18, 0x118, 0x40, 0x20, 0x480 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                            public static async Task<int> CountAsync()
                            {
                                return await Task.Run(() => Count);
                            }
                        }
                    }
                    public class Gems
                    {
                        public class Get
                        {
                            public static int Count
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AEEF8, 0xB8, 0x18, 0x68, 0x198, 0x40, 0x20, 0x374 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                            public static async Task<int> CountAsync()
                            {
                                return await Task.Run(() => Count);
                            }
                        }
                    }
                    public class Level
                    {
                        public class Experience
                        {
                            public class Get
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x021F06C8, 0x550, 0x188, 0x40, 0x20, 0x324 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<int> CountAsync()
                                {
                                    return await Task.Run(() => Count);
                                }
                            }
                        }
                    }
                }
                public class Guild
                {
                    public class Statistic
                    {
                        public class Get
                        {
                            public static int Power
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x021F1978, 0x40, 0xb8, 0x6a0, 0x7a0, 0x590 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                            public static async Task<int> PowerAsync()
                            {
                                return await Task.Run(() => Power);
                            }
                        }

                    }
                    public class Shop
                    {
                        public class Get
                        {
                            public static int Money
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x02211878, 0xa0, 0x40, 0x20, 0x528 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                            public static async Task<int> MoneyAsync()
                            {
                                return await Task.Run(() => Money);
                            }
                        }
                    }
                    public class Gifts
                    {
                        public class Get
                        {
                            public static int Keys
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x02211878, 0x1c8, 0x40, 0x20, 0x548 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                            public static async Task<int> KeysAsync()
                            {
                                return await Task.Run(() => Keys);
                            }
                        }
                    }
                    public class Help
                    {
                        public class OtherUser
                        {
                            public class Get
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x021EFCF0, 0x40, 0x50, 0xb8, 0x28, 0x7f8 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                                public static async Task<int> CountAsync()
                                {
                                    return await Task.Run(() => Count);
                                }
                            }
                        }
                    }
                }
                public class Castle
                {
                    public class Army
                    {
                        public static int TotalCount
                        {
                            get
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AE928, 0x40, 0xB8, 0x18, 0x188, 0x40, 0x20, 0xC30 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                        }
                        public class Infantry
                        {
                            public class T1
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022CD9D0, 0x920 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                            public class T2
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022DB5F8, 0xB8, 0x18, 0x10, 0xCB0 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                            public class T3
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022A24D8, 0x98, 0x38, 0x18, 0xB8, 0xF0, 0x70, 0xD40 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                        }
                        public class Archer
                        {
                            public class T1
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022CD9D0, 0x924 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                            public class T2
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022DB5F8, 0xB8, 0x18, 0x10, 0xCB4 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                            public class T3
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022A24D8, 0x98, 0x38, 0x18, 0xB8, 0xF0, 0x70, 0xD44 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                        }
                        public class Rider
                        {
                            public class T1
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022CD9D0, 0x928 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                            public class T2
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022DB5F8, 0xB8, 0x18, 0x10, 0xCB8 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                            public class T3
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022A24D8, 0x98, 0x38, 0x18, 0xB8, 0xF0, 0x70, 0xD48 });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                        }
                        public class Ballista
                        {
                            public class T1
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022CD9D0, 0x92C });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                            public class T2
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022DB5F8, 0xB8, 0x18, 0x10, 0xCBC });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                            public class T3
                            {
                                public static int Count
                                {
                                    get
                                    {
                                        int hpint = 0;
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022A24D8, 0x98, 0x38, 0x18, 0xB8, 0xF0, 0x70, 0xD4C });
                                        hpint = vam.ReadInt32(hp);
                                        return hpint;
                                    }
                                }
                            }
                        }
                    }

                    public class Coliseum
                    {
                        public class Get
                        {
                            public static int Gems
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AFC18, 0x90, 0x0, 0x80, 0x70, 0xB8, 0x0, 0x40 });
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
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x021E7C30, 0x40, 0x40, 0xb8, 0x50, 0x24 });
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
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x0222B9F8, 0x280, 0x2d8, 0x158, 0x18, 0x14 });
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
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022B6928, 0xB8, 0x0, 0x10, 0x7A0, 0x348, 0xC8, 0x14 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AF3C0, 0xB8, 0x28, 0x40, 0x20, 0xDB0, 0x90, 0x150 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x02211110, 0x138, 0x98, 0xD0, 0x18, 0xB8, 0xB8, 0x1A8 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022CD778, 0x150 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022DB670, 0x40, 0xB8, 0x8, 0x80, 0xD8, 0x3D8 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x021EEE10, 0x8D8, 0x200, 0xD8, 0x380 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022CD778, 0x108 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x0229D5C0, 0xE20, 0xB8, 0x18, 0xB0 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022CD778, 0xB8 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x0229D5C8, 0x100, 0x98, 0x10, 0xB8, 0xB8, 0xB8, 0x60 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022CD778, 0x68 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022047F0, 0xC0, 0x20, 0x20, 0x98, 0x18, 0x1E8, 0x8D0 });
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
                                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x021F6798, 0xb8, 0x0, 0x5b0, 0x378, 0x7e8 });
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
            public static Process GetProcess
            {
                get
                {
                    Process[] processes = Process.GetProcessesByName("Lords Mobile");
                    if (processes.Count() > 0)
                        return processes[0];
                    else return Process.GetCurrentProcess();
                }
            }
        }
    }
}
