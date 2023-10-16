using System.Text.RegularExpressions;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Controls.Add(tb1);
            tb1.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            this.Controls.Add(tb2);
            tb2.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        private void tb_KeyPress(Object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tr obj1 = new Tr(Convert.ToInt32(tb1.Text), Convert.ToInt32(tb2.Text));
            MessageBox.Show($"Площадь: {obj1.Square()} \n" +
                            $"Катеты: {obj1.Out()} \n" +
                            $"Углы: {obj1.Angel()} \n");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 obj = new();
            obj.Show();
        }
    }

    class Tr
    {
        protected double kat1;
        protected double kat2;

        public Tr()
        {
            kat1 = 0;
            kat2 = 0;
        }

        public double Kat1
        {
            set
            {
                if (value < 0) { Console.WriteLine("Длина не может быть отрицательной"); kat1 = 1; }
                else
                {
                    kat1 = value;
                    Console.WriteLine("Значение для первого катета установлено");
                }
            }

            get { return kat1; }
        }

        public double Kat2
        {
            set
            {
                if (value < 0) { Console.WriteLine("Длина не может быть отрицательной"); kat2 = 1; }
                else
                {
                    kat2 = value;
                    Console.WriteLine("Значение для второго катета установлено");
                }
            }

            get { return kat2; }
        }

        public Tr(double x, double y)
        {
            this.kat1 = x;
            this.kat2 = y;
        }

        public Tr(Tr pre)
        {
            kat1 = pre.kat1;
            kat2 = pre.kat2;
        }

        public double Square()
        {
            return ((kat1 * kat2) / 2);
        }

        public Tuple<string, string> Angel()
        {
            double alpha, beta;
            alpha = Math.Atan(kat1 / kat2);
            alpha = alpha * (180 / Math.PI);
            beta = 90 - alpha;
            alpha = Math.Round(alpha, 2);
            beta = Math.Round(beta, 2);
            //Console.WriteLine("Углы равны: 90°; " + alpha + "°; " + beta + "°;");
            return Tuple.Create(alpha + "°", beta + "°");
        }

        public Tuple<double, double> Out()
        {
            //Console.WriteLine("Катеты равны: " + kat1 + ", " + kat2);
            return Tuple.Create(kat1, kat2);
        }
    }
}