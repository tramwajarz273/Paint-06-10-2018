using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap img = new Bitmap(500, 500);

        bool drawpen = false;
        Graphics graph;
        Pen p = new Pen(Color.Black, 3);
        SolidBrush b = new SolidBrush(Color.Yellow);
        int x0, y0;
        int xline, yline;
        bool penn = true;
        bool linee = false;
        bool recta = false;
        bool elip = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                ColorPanel.BackColor = colorDialog1.Color;
                p.Color = colorDialog1.Color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            p.Width = WideBar.Value;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ///////
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ///////////
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ////////////////
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawpen&&penn)
            {
                int x = e.X;
                int y = e.Y;
                graph.DrawLine(p, x0, y0, x, y);
                x0 = x; y0 = y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drawpen = true;
            x0 = e.X;
            y0 = e.Y;
            xline = e.X;
            yline = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawpen = false;
            if (linee)
            {
                int x = e.X;
                int y = e.Y;
                graph.DrawLine(p, xline, yline, x, y);
            }
            if (recta)
            {
                int x = e.X;
                int y = e.Y;
                if ((xline < x) && (yline < y))
                {
                    graph.DrawRectangle(p, xline, yline, x - xline, y - yline);
                }
                if ((xline > x) && (yline < y))
                {
                    graph.DrawRectangle(p, x, yline, xline - x, y - yline);
                }
                if ((xline < x) && (yline > y))
                {
                    graph.DrawRectangle(p, xline, y, x - xline, yline - y);
                }
                if ((xline > x) && (yline > y))
                {
                    graph.DrawRectangle(p, x, y, xline - x, yline - y);
                }
            }
            if (elip)
            {
                int x = e.X;
                int y = e.Y;
                if ((xline < x) && (yline < y))
                {
                    graph.DrawEllipse(p, xline, yline, x - xline, y - yline);
                }
                if ((xline > x) && (yline < y))
                {
                    graph.DrawEllipse(p, x, yline, xline - x, y - yline);
                }
                if ((xline < x) && (yline > y))
                {
                    graph.DrawEllipse(p, xline, y, x - xline, yline - y);
                }
                if ((xline > x) && (yline > y))
                {
                    graph.DrawEllipse(p, x, y, xline - x, yline - y);
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.Clear(Color.White);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void PenButton_CheckedChanged(object sender, EventArgs e)
        {
            penn = true;
            linee = false;
            recta = false;
            elip = false;
        }

        private void LineButton_CheckedChanged(object sender, EventArgs e)
        {
            linee = true;
            penn = false;
            recta = false;
            elip = false;
        }

        private void RectButton_CheckedChanged(object sender, EventArgs e)
        {
            recta = true;
            penn = false;
            linee = false;
            elip = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    graph.Clear(Color.White);
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File-loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bm = new Bitmap(500,500,graph);
                    bm.Save(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File-saving error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void instructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void EllipseButton_CheckedChanged(object sender, EventArgs e)
        {
            elip = true;
            penn = false;
            recta = false;
            linee = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graph = pictureBox1.CreateGraphics();
            //Area = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            //pictureBox1.Image = Area;
        }
    }
}
