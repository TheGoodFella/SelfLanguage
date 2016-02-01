using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using FastDrawing;

namespace OpenCV {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            var f = new FastBitmap(new System.Drawing.Bitmap(@"C:\dressThePeecco\baseBody.bmp"));
            var ran = new Random();
            Stopwatch s = new Stopwatch();
            s.Start();
            //Enumerable.Range(0,(int)Math.Pow(10,7)).ToList().ForEach((pappa)=>f[Convert.ToInt32(ran.Next(f.Width)),Convert.ToInt32(ran.Next(f.Height))]=Color.Black);
            f=f.Zoom(5);
            f.ToBitmap().Save(@"C:\lavoro-temp\l.bmp");
            s.Stop();
            return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
