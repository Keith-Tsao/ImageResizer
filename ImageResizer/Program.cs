using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output");


            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();

            destinationPath = Path.Combine(Environment.CurrentDirectory, "output_async");
            imageProcess.Clean(destinationPath);

            Stopwatch swAsync = new Stopwatch();
            swAsync.Start();
            await imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            swAsync.Stop();

            Console.WriteLine($"調整前花費時間: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"調整後花費時間: {swAsync.ElapsedMilliseconds} ms");

            Console.WriteLine($"提升: {((sw.ElapsedMilliseconds - swAsync.ElapsedMilliseconds) / (double)sw.ElapsedMilliseconds * 100).ToString("0.00")} %");

            Console.ReadKey();
        }
    }
}
