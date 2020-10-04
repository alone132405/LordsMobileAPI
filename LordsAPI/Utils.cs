using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Binarysharp.MemoryManagement;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Tesseract;

namespace LordsAPI
{
    public static class ImageUtils
    {
        public static Bitmap ImageToGray(this Bitmap map)
        {
            int rgb;
            Color c;

            for (int y = 0; y < map.Height; y++)
                for (int x = 0; x < map.Width; x++)
                {
                    c = map.GetPixel(x, y);
                    rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    map.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return map;
        }
    }
    public static class Stringtils
    {
        public static string Format(this string text)
        {
            int countbalance = text.ToCharArray().Length;
            Console.WriteLine(countbalance);
            if (countbalance > 12 & countbalance >= 15)
            {
                int formatedbalanceT = Convert.ToInt32(Regex.Match(text, "(.*)[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]").Groups[1].Value);
                int formatedbalanceB = Convert.ToInt32(Regex.Match(text, formatedbalanceT + "(.*)[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]").Groups[1].Value);
                int formatedbalanceM = Convert.ToInt32(Regex.Match(text, formatedbalanceB + "(.*)[0-9][0-9][0-9][0-9][0-9][0-9]").Groups[1].Value);
                int formatedbalanceK = Convert.ToInt32(Regex.Match(text, formatedbalanceM + "(.*)[0-9][0-9][0-9]").Groups[1].Value);
                text = text + "" + formatedbalanceT + "," + "" + formatedbalanceB + "," + "" + formatedbalanceM + "," + "" + formatedbalanceK + "";
            }
            else if (countbalance > 9)
            {
                int formatedbalanceB = Convert.ToInt32(Regex.Match(text, "(.*)[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]").Groups[1].Value);
                int formatedbalanceM = Convert.ToInt32(Regex.Match(text, formatedbalanceB + "(.*)[0-9][0-9][0-9][0-9][0-9][0-9]").Groups[1].Value);
                int formatedbalanceK = Convert.ToInt32(Regex.Match(text, formatedbalanceM + "(.*)[0-9][0-9][0-9]").Groups[1].Value);
                text = text + "" + formatedbalanceM + "," + "" + formatedbalanceK + "," + "" + formatedbalanceK + "";
            }
            else if (countbalance > 6)
            {
                int formatedbalanceM = Convert.ToInt32(Regex.Match(text, "(.*)[0-9][0-9][0-9][0-9][0-9][0-9]").Groups[1].Value);
                int formatedbalanceK = Convert.ToInt32(Regex.Match(text, formatedbalanceM + "(.*)[0-9][0-9][0-9]").Groups[1].Value);
                text = text + "" + formatedbalanceM + "," + "" + formatedbalanceK + "";
            }
            else if (countbalance > 3)
            {
                int formatedbalanceK = Convert.ToInt32(Regex.Match(text, "(.*)[0-9][0-9][0-9]").Groups[1].Value);
                text = text + "" + formatedbalanceK + "";
            }
            return text;
        }
    }

    public class Utils
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;
        }
        public static Bitmap GetProgrammImage(Process process)
        {
            if (process != null)
            {
                var hwnd = process.MainWindowHandle;
                RECT rect;
                GetWindowRect(hwnd, out rect);
                Bitmap image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top);
                var graphics = Graphics.FromImage(image);
                var hdcBitmap = graphics.GetHdc();
                PrintWindow(hwnd, hdcBitmap, 0);
                graphics.ReleaseHdc(hdcBitmap);
                return image;
            }
            else return null;
        }
        public static Bitmap ConvertImagePixelType(Bitmap orig, System.Drawing.Imaging.PixelFormat format = System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        {
            Bitmap clone = new Bitmap(orig.Width, orig.Height, format);

            using (Graphics gr = Graphics.FromImage(clone))
            {
                gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
            }
            return clone;
        }
        public static string GetTextFromImage(Bitmap imgsource, EngineMode mode = EngineMode.TesseractAndCube)
        {
            var ocrtext = string.Empty;
            using (var engine = new TesseractEngine(@"./tessdata", "eng", mode))
            {
                using (var img = PixConverter.ToPix(imgsource))
                {
                    using (var page = engine.Process(img))
                    {
                        ocrtext = page.GetText();
                    }
                }
            }

            return ocrtext;
        }
        public static Bitmap ResizeImage(Bitmap imgToResize, Size size)
        {
            return (new Bitmap(imgToResize, size));
        }
        public static string TruncateLongString(string inputString, int maxChars, string postfix = "...")
        {
            if (maxChars <= 0)
                throw new ArgumentOutOfRangeException("maxChars");
            if (inputString == null || inputString.Length < maxChars)
                return inputString;

            var truncatedString = inputString.Substring(0, maxChars) + postfix;

            return truncatedString;

        }
        public static List<Rectangle> Find(Bitmap fromimg, Bitmap img, double quality = 0.9)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            Image<Bgr, byte> sourceImage = new Image<Bgr, byte>(fromimg);
            Image<Bgr, byte> templateImage = new Image<Bgr, byte>(img);
            Image<Bgr, byte> imageToShow = sourceImage.Copy();
            using (Image<Gray, float> result = sourceImage.MatchTemplate(templateImage, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                int int2 = 0;
                foreach (Point bd in maxLocations)
                {
                    if (maxValues[int2] > quality)
                        rectangles.Add(new Rectangle(bd, templateImage.Size));
                    int2++;
                }
            }
            imageToShow.Save("результат.bmp");
            return rectangles;
        }
        public static Bitmap Crop(Bitmap image, Rectangle selection)
        {
            Bitmap bmp = image;

            // Check if it is a bitmap:
            if (bmp == null)
                throw new ArgumentException("No valid bitmap");

            // Crop the image:
            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

            // Release the resources:
            image.Dispose();

            return cropBmp;
        }
        public static IntPtr PointRead(IntPtr baseAddres, int[] offsets)
        {
            VAMemory vam = new VAMemory(LordsMobileAPI.Settings.GetProcess().ProcessName);
            for (int i = 0; i < offsets.Count() - 1; i++)
            {
                baseAddres = (IntPtr)vam.ReadInt64(IntPtr.Add(baseAddres, offsets[i]));
            }
            return baseAddres + offsets[offsets.Count() - 1];
        }
        public static IntPtr getModuleAdress(string modulname, Process proc)
        {
            IntPtr result = IntPtr.Zero;
            for (int i = 0; i < proc.Modules.Count; i++)
            {
                if (proc.Modules[i].ModuleName == modulname)
                {
                    result = proc.Modules[i].BaseAddress;
                    Console.WriteLine(result);
                    break;
                }
            }
            return result;
        }
    }
}
