using LordsAPI.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
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
                public static string IP
                {
                    get
                    {
                        string ip = "";
                        VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                        var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AF3A8, 0x40, 0x98, 0x118, 0x18, 0xB8, 0xD8, 0x14 });
                        ip = vam.ReadStringUnicode(hp, 42);
                        return ip;
                    }
                }
                public static async Task<string> IPAsync()
                {
                    return await Task.Run(() => IP);
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
            public class LocalUser
            {
                public class Chat
                {
                    public class Guild
                    {
                        public static string LastMessage
                        {
                            get
                            {
                                string ip = "";
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AE928, 0xB8, 0x30, 0x90, 0x880, 0xA0, 0x78, 0xAD4 });
                                ip = vam.ReadStringUnicode(hp, 512);
                                return ip;
                            }
                        }
                    }
                    public class Global
                    {
                        public static string LastMessage
                        {
                            get
                            {
                                string ip = "";
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x021EEF98, 0x420, 0x48, 0x10, 0x4A4 });
                                ip = vam.ReadStringUnicode(hp, 512);
                                return ip;
                            }
                        }
                    }
                }
                public class Map
                {
                    public int TropsSended
                    {
                        get
                        {
                            int hpint = 0;
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AF970, 0x40, 0xB8, 0x0, 0x18, 0x490, 0x18, 0xA6C });
                            hpint = vam.ReadInt32(hp);
                            return hpint;
                        }
                    }
                }
                public class PromoCodes
                {
                    public static string[] All
                    {
                        get
                        {
                            List<string> promos = new List<string>();
                            try
                            {
                                string promo;
                                using (WebClient wc = new WebClient())
                                {
                                    promo = wc.DownloadString("https://raw.githubusercontent.com/Nekiplay/LordsMobileAPI/master/ServerSide/WorkingPromoCodes.txt");
                                }
                                foreach (string prom in promo.Split(Environment.NewLine.ToCharArray()))
                                {
                                    if (prom != "")
                                        promos.Add(prom);
                                }
                                return promos.ToArray();
                            } catch { return promos.ToArray(); }
                        }
                    }
                }
                public class Auth
                {
                    public static string IGG_ID
                    {
                        get
                        {
                            string doneid = "";
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022A6F50, 0xB8, 0x18, 0x18, 0x100, 0x228, 0x8E0, 0x14 });
                            string iggid = vam.ReadStringUnicode(hp, 26);
                            StringBuilder sb = new StringBuilder(iggid.Length);

                            foreach (char ch in iggid)
                            {
                                if (ch >= '0' && ch <= '9')
                                {

                                    sb.Append(ch);
                                }
                            }

                            doneid = sb.ToString();

                            return doneid;
                        }
                    }
                    public static async Task<string> IGG_IDAsync()
                    {
                        return await Task.Run(() => IGG_ID);
                    }
                }

                public class Statistic
                {
                    public class Stamina
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

                    public class Power
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

                    public class Energy
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
                    public class Gems
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
                    public class Level
                    {
                        public static int Current
                        {
                            get
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AE928, 0x48, 0x40, 0xB8, 0x38, 0x40, 0x38, 0x614 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                        }
                    }
                }
                public class Guild
                {
                    public class Statistic
                    {
                        public static int Power
                        {
                            get
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AE928, 0x40, 0xB8, 0x38, 0x38, 0x40, 0x90, 0x530 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                        }
                        public static async Task<int> PowerAsync()
                        {
                            return await Task.Run(() => Power);
                        }
                    }

                    public class Shop
                    {
                        public static int Money
                        {
                            get
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AE928, 0xB8, 0x18, 0x228, 0x20, 0x40, 0x20, 0x538 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                        }
                        public static async Task<int> MoneyAsync()
                        {
                            return await Task.Run(() => Money);
                        }
                    }

                    public class Gifts
                    {
                        public static int Keys
                        {
                            get
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x0229D578, 0xA98, 0xB8, 0x0, 0x1E8, 0x40, 0x20, 0x558 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                        }
                        public static async Task<int> KeysAsync()
                        {
                            return await Task.Run(() => Keys);
                        }
                        public static int Count
                        {
                            get
                            {
                                int hpint = 0;
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022C9980, 0xF4 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                        }
                    }

                    public class Help
                    {
                        public class OtherUser
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
                public class WatchTower
                {
                    public static int Level
                    {
                        get
                        {
                            int hpint = 0;
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022B8458, 0xB8, 0x0, 0x1E0, 0x88, 0xA0, 0x10, 0x1B4 });
                            hpint = vam.ReadInt32(hp);
                            return hpint;
                        }
                    }
                }
                public class WorkShop
                {
                    public static int Level
                    {
                        get
                        {
                            int hpint = 0;
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022B8458, 0xB8, 0x0, 0x1D8, 0x38, 0xA0, 0x10, 0x1F0 });
                            hpint = vam.ReadInt32(hp);
                            return hpint;
                        }
                    }
                }
                public class Factory
                {
                    public static int Level
                    {
                        get
                        {
                            int hpint = 0;
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022B8458, 0xB8, 0x0, 0x1E0, 0x88, 0xA0, 0x10, 0x234 });
                            hpint = vam.ReadInt32(hp);
                            return hpint;
                        }
                    }
                }
                public class Cellar
                {
                    public static int Level
                    {
                        get
                        {
                            int hpint = 0;
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022B8458, 0xB8, 0x0, 0x1E0, 0x88, 0xA0, 0x10, 0x134 });
                            hpint = vam.ReadInt32(hp);
                            return hpint;
                        }
                    }
                }
                public class Wall
                {
                    public static int Level
                    {
                        get
                        {
                            int hpint = 0;
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AE928, 0x40, 0xB8, 0x38, 0x90, 0x20, 0x10, 0x194 });
                            hpint = vam.ReadInt32(hp);
                            return hpint;
                        }
                    }
                }
                public class Castle
                {
                    public static int Level
                    {
                        get
                        {
                            int hpint = 0;
                            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                            var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AE928, 0x40, 0xB8, 0x38, 0x90, 0x20, 0x10, 0x114 });
                            hpint = vam.ReadInt32(hp);
                            return hpint;
                        }
                    }
                    public class Attack
                    {
                        public class Status
                        {
                            public static int AttackCount
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AA4B8, 0xB8, 0x0, 0x20, 0x490, 0x100, 0xDD0, 0x644 });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                            public static int ScoutingCount
                            {
                                get
                                {
                                    int hpint = 0;
                                    VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x0229D5C8, 0xD20, 0xC8, 0x10, 0xB8, 0x20, 0x11C });
                                    hpint = vam.ReadInt32(hp);
                                    return hpint;
                                }
                            }
                        }
                    }
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
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x0224DC50, 0x40, 0xC0, 0xF8, 0x18, 0xB8, 0x20, 0x24 });
                                hpint = vam.ReadInt32(hp);
                                return hpint;
                            }
                        }
                        public static async Task<int> RangAsync()
                        {
                            return await Task.Run(() => Rank);
                        }
                    }
                    
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

                    public class MysteryBox
                    {
                        public static string Time
                        {
                            get
                            {
                                string hpint = "00:00:00";
                                VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess);
                                var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022AECB0, 0xB8, 0x10, 0x20, 0x768, 0x18, 0x14 });
                                hpint = vam.ReadStringUnicode(hp, 14);
                                return hpint;
                            }
                        }
                        public static async Task<string> TimeAsync()
                        {
                            return await Task.Run(() => Time);
                        }
                    }
                    
                    public class Resources
                    {
                        public class Food
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

                        public class Stone
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
                        public class Wood
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
                        public class Ore
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

                        public class Gold
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
                        public class Anima
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
                                    var hp = Utils.PointRead(Utils.getModuleAdress("GameAssembly.dll", LordsMobileAPI.Settings.GetProcess), new[] { 0x022ABC78, 0x98, 0x28, 0x18, 0xB8, 0x48, 0x98, 0x8D8 });
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
