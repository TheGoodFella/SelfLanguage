using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;

namespace OpenCV {
    public partial class Form1 : Form {
        public ImageViewer imgV { get; set; }
        public Capture capturer { get; set; }
        public int trbase { get; set; }
        public int other { get; set; }
        public Form1() {
            InitializeComponent();
            trbase = 50;
            other = 100;
            TryCV();
        }
        public void TryCV() {
            imgV = new ImageViewer();
            capturer = new Emgu.CV.Capture();
            new Task(() => {
                while (true) {
                    s();
                    imgV.Invoke(new Action(()=>imgV.Text = trbase + "   " + other));
                }  
            }).Start();
            imgV.ShowDialog();
        }
        public void s() {
            var capture = capturer.QueryFrame();
            var img = capture.ToImage<Gray, Byte>();
            imgV.Image = img.Canny(trbase, other);
        }
    }
}
