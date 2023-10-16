using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = String.Format("Первый катет: {0}", trackBar1.Value);
        }
        private void trackBar2_Scroll_1(object sender, EventArgs e)
        {
            label8.Text = String.Format("Второй катет: {0}", trackBar2.Value);
        }
        private void trackBar3_Scroll_1(object sender, EventArgs e)
        {
            label9.Text = String.Format("Высота: {0}", trackBar3.Value);
        }

        private void button3_Click(object sender, EventArgs e)//1 объект
        {
            TrPr obj1 = new(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            label4.Text = String.Format("Объем: {0}", Math.Round(obj1.Volume, 2));

            label5.Text = String.Format("Площадь поверхности: {0}", Math.Round(obj1.SquareP, 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int l10 = rnd.Next(1, 15);
            label17.Text = String.Format("{0}", l10);
            int l11 = rnd.Next(1, 15);
            label18.Text = String.Format("{0}", l11);
            int l12 = rnd.Next(1, 15);
            label19.Text = String.Format("{0}", l12);

            TrPr obj = new(l10, l11, l12);
            label6.Text = String.Format("Объем: {0}", Math.Round(obj.Volume, 2));
            label7.Text = String.Format("Площадь поверхности: {0}", Math.Round(obj.SquareP, 2));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrPr obj1 = new(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            TrPr obj2 = new(Convert.ToInt32(label17.Text), Convert.ToInt32(label18.Text), Convert.ToInt32(label19.Text));
            bool result = obj1 < obj2;
            if (result == true) { label13.Text = "1 < 2"; }
            else { label13.Text = "1 не < 2"; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrPr obj1 = new(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            TrPr obj2 = new(Convert.ToInt32(label17.Text), Convert.ToInt32(label18.Text), Convert.ToInt32(label19.Text));
            bool result = obj1 > obj2;
            if (result == true) { label14.Text = "1 > 2"; }
            else { label14.Text = "1 не > 2"; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TrPr obj1 = new(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            TrPr obj2 = new(Convert.ToInt32(label17.Text), Convert.ToInt32(label18.Text), Convert.ToInt32(label19.Text));
            bool result = obj1 <= obj2;
            if (result == true) { label15.Text = "1 <= 2"; }
            else { label15.Text = "1 не <= 2"; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TrPr obj1 = new(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            TrPr obj2 = new(Convert.ToInt32(label17.Text), Convert.ToInt32(label18.Text), Convert.ToInt32(label19.Text));
            bool result = obj1 >= obj2;
            if (result == true) { label16.Text = "1 >= 2"; }
            else { label16.Text = "1 не >= 2"; }
        }

        //без перегрузки работает только =
        /*
        private void button7_Click(object sender, EventArgs e)
        {
            TrPr obj1 = new(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            TrPr obj2 = new(Convert.ToInt32(label17.Text), Convert.ToInt32(label18.Text), Convert.ToInt32(label19.Text));
            obj1 = obj2;
        }
        */
    }

    class TrPr : Tr
    {

        private double height;

        public TrPr()
        {
            height = 1;
        }

        public TrPr(double x, double y, double z)
        {
            base.kat1 = x;
            base.kat2 = y;
            height = z;
        }

        public TrPr(double x)
        {
            height = x;
        }

        public double Volume
        {
            get
            {
                return ((base.Square()) * height);
            }
            set
            {

            }
        }

        public double SquareP
        {
            get
            {
                return ((Math.Sqrt((base.kat1 * base.kat1) + (Math.Sqrt(base.kat2 * base.kat2)))) * height + base.kat1 * height + base.kat2 * height + base.Square() * 2);
            }
            set
            {

            }
        }
        public static bool operator >(TrPr obj1, TrPr obj2)
        {
            return obj1.SquareP > obj2.SquareP;
        }
        public static bool operator <(TrPr obj1, TrPr obj2)
        {
            return obj1.SquareP < obj2.SquareP;
        }
        public static bool operator >=(TrPr obj1, TrPr obj2)
        {
            return obj1.SquareP >= obj2.SquareP;
        }
        public static bool operator <=(TrPr obj1, TrPr obj2)
        {
            return obj1.SquareP <= obj2.SquareP;
        }
    }

    /*class Test
    {
        static void Main()
        {
            TrPr test = new TrPr();
            test.Square();
        }
    }*/
}
