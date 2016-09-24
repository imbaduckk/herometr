using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerometrForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnHui_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                MessageBox.Show("Хуй");
            }

        }

        List<Label> labels = new List<Label>();
        static Random rand = new Random();
        int ind = 2;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Label lbl = new Label()
            {
                AutoSize = true,
                Text = "хуй",
                Location = new Point(rand.Next(0, this.Width), rand.Next(0, this.Height)),
                Visible = true,
                TabIndex = ind++    
            };
            this.Controls.Add(lbl);
            labels.Add(lbl);
            this.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = Math.Max(1, this.timer1.Interval -10);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.timer1.Interval = Math.Max(1, this.timer1.Interval + 10);
        }

        Font font = new Font("Arial", 100);
        private void button3_Click(object sender, EventArgs e)
        {
            labels.ForEach(x => { x.Font = font; });
        }
    }
}
