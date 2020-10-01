using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobile_by_Nekiplay
{
    public class API
    {
        public string Get(GetTypes type)
        {
            Process process = Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
            Utils utils = new Utils();
            if (type == GetTypes.PlayerPower)
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
                    return power;
                }
                else return string.Empty;
            }
            else if (type == GetTypes.PlayerGems)
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
                    return power.Replace("Mt ", "").Replace("‘", "");
                }
                else return string.Empty;
            }
            else if (type == GetTypes.PlayerLevel)
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
                    return utils.TruncateLongString(power, 2, "");
                }
                else return string.Empty;
            }
            else if (type == GetTypes.Location)
            {
                Bitmap game = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                game.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap find = utils.ConvertImagePixelType(AForge.Imaging.Image.FromFile("game\\gomap.png"));
                List<Rectangle> done = utils.Find(game, find);
                if (done.Count >= 1)
                {
                    return Locations.Castle.ToString();
                }
                else
                {
                    Bitmap game2 = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                    game2.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    Bitmap find2 = utils.ConvertImagePixelType(AForge.Imaging.Image.FromFile("game\\gocastle.png"));
                    List<Rectangle> done2 = utils.Find(game2, find2);
                    if (done2.Count >= 1)
                    {
                        return Locations.Map.ToString();
                    }
                    else
                    {
                        Bitmap game3 = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                        game3.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        Bitmap find3 = utils.ConvertImagePixelType(AForge.Imaging.Image.FromFile("game\\BarracksMenuDetect.png"));
                        List<Rectangle> done3 = utils.Find(game3, find3);
                        if (done3.Count >= 1)
                        {
                            return Locations.Barracks.ToString();
                        }
                        else
                        {
                            Bitmap game4 = utils.ConvertImagePixelType(utils.GetProgrammImage(process));
                            game4.Save("game.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            Bitmap find4 = utils.ConvertImagePixelType(AForge.Imaging.Image.FromFile("game\\SacredTowerMenuDetect.png"));
                            List<Rectangle> done4 = utils.Find(game4, find4);
                            if (done4.Count >= 1)
                            {
                                return Locations.SacredTower.ToString();
                            }
                            else return string.Empty;
                        }
                    }
                }
            }
            else  return string.Empty;
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
        }

        public enum GetTypes
        {
            Location,
            PlayerPower,
            PlayerGems,
            PlayerLevel,
        }

    }
}
