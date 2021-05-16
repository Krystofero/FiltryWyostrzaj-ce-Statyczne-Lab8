using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdytorZdjec_v1
{
    public partial class Form1 : Form
    {
        private int szer=0, wys=0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
                pictureBox2.Image = new Bitmap(szer, wys);
            }
        }

//Roberts'a poziomy
        private void button8_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int[,] maska = new int[3, 3];
            maska[0, 0] = 0;
            maska[0, 1] = 0;
            maska[0, 2] = 0;
            maska[1, 0] = 0;
            maska[1, 1] = 1;
            maska[1, 2] = -1;
            maska[2, 0] = 0;
            maska[2, 1] = 0;
            maska[2, 2] = 0;
            

            int norm = 0;
            for (int i = 0; i < 3; i++)    //normowanie maski(czyli dzielenie przez sumę elementów)
                for (int j = 0; j < 3; j++)
                    norm += maska[i, j];

            int R, G, B;
            Color k;

            for (int i = 1; i < szer - 1; i++) //(od 1 bo piksele brzegowe wyjdą poza obraz)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    R = B = G = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            k = b1.GetPixel(i + x - 1, j + y - 1); //piksel lewy
                            R += k.R * maska[x, y];
                            G += k.G * maska[x, y];
                            B += k.B * maska[x, y];
                        }
                    }

                    if (norm != 0)
                    {
                        R /= norm;
                        G /= norm;
                        B /= norm;
                    }

                    if (R < 0) R = 0;
                    if (R > 255) R = 255;

                    if (G < 0) G = 0;
                    if (G > 255) G = 255;

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;


                    b2.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }

            pictureBox2.Invalidate();

            Cursor = Cursors.Default;
        }

//Roberts'a pionowy
        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int[,] maska = new int[3, 3];
            maska[0, 0] = 0;
            maska[0, 1] = 0;
            maska[0, 2] = 0;
            maska[1, 0] = 0;
            maska[1, 1] = 1;
            maska[1, 2] = 0;
            maska[2, 0] = 0;
            maska[2, 1] = -1;
            maska[2, 2] = 0;

            int norm = 0;
            for (int i = 0; i < 3; i++)    //normowanie maski(czyli dzielenie przez sumę elementów)
                for (int j = 0; j < 3; j++)
                    norm += maska[i, j];

            int R, G, B;
            Color k;

            for (int i = 1; i < szer - 1; i++) //(od 1 bo piksele brzegowe wyjdą poza obraz)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    R = B = G = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            k = b1.GetPixel(i + x - 1, j + y - 1); //piksel lewy
                            R += k.R * maska[x, y];
                            G += k.G * maska[x, y];
                            B += k.B * maska[x, y];
                        }
                    }

                    if (norm != 0)
                    {
                        R /= norm;
                        G /= norm;
                        B /= norm;
                    }

                    if (R < 0) R = 0;
                    if (R > 255) R = 255;

                    if (G < 0) G = 0;
                    if (G > 255) G = 255;

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;


                    b2.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }

            pictureBox2.Invalidate();

            Cursor = Cursors.Default;
        }

//Prewitt'a poziomy
        private void button9_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int[,] maska = new int[3, 3];
            maska[0, 0] = 1;
            maska[0, 1] = 1;
            maska[0, 2] = 1;
            maska[1, 0] = 0;
            maska[1, 1] = 0;
            maska[1, 2] = 0;
            maska[2, 0] = -1;
            maska[2, 1] = -1;
            maska[2, 2] = -1;          

            int norm = 0;
            for (int i = 0; i < 3; i++)    //normowanie maski(czyli dzielenie przez sumę elementów)
                for (int j = 0; j < 3; j++)
                    norm += maska[i, j];

            int R, G, B;
            Color k;

            for (int i = 1; i < szer - 1; i++) //(od 1 bo piksele brzegowe wyjdą poza obraz)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    R = B = G = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            k = b1.GetPixel(i + x - 1, j + y - 1); //piksel lewy
                            R += k.R * maska[x, y];
                            G += k.G * maska[x, y];
                            B += k.B * maska[x, y];
                        }
                    }

                    if (norm != 0)
                    {
                        R /= norm;
                        G /= norm;
                        B /= norm;
                    }

                    if (R < 0) R = 0;
                    if (R > 255) R = 255;

                    if (G < 0) G = 0;
                    if (G > 255) G = 255;

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;


                    b2.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }

            pictureBox2.Invalidate();

            Cursor = Cursors.Default;
        }

//Prewitt'a pionowy
        private void button10_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int[,] maska = new int[3, 3];
            maska[0, 0] = 1;
            maska[0, 1] = 0;
            maska[0, 2] = -1;
            maska[1, 0] = 1;
            maska[1, 1] = 0;
            maska[1, 2] = -1;
            maska[2, 0] = 1;
            maska[2, 1] = 0;
            maska[2, 2] = -1;

            int norm = 0;
            for (int i = 0; i < 3; i++)    //normowanie maski(czyli dzielenie przez sumę elementów)
                for (int j = 0; j < 3; j++)
                    norm += maska[i, j];

            int R, G, B;
            Color k;

            for (int i = 1; i < szer - 1; i++) //(od 1 bo piksele brzegowe wyjdą poza obraz)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    R = B = G = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            k = b1.GetPixel(i + x - 1, j + y - 1); //piksel lewy
                            R += k.R * maska[x, y];
                            G += k.G * maska[x, y];
                            B += k.B * maska[x, y];
                        }
                    }

                    if (norm != 0)
                    {
                        R /= norm;
                        G /= norm;
                        B /= norm;
                    }

                    if (R < 0) R = 0;
                    if (R > 255) R = 255;

                    if (G < 0) G = 0;
                    if (G > 255) G = 255;

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;


                    b2.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }

            pictureBox2.Invalidate();

            Cursor = Cursors.Default;
        }

//Sobel'a poziomy
        private void button11_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int[,] maska = new int[3, 3];
            maska[0, 0] = 1;
            maska[0, 1] = 2;
            maska[0, 2] = 1;
            maska[1, 0] = 0;
            maska[1, 1] = 0;
            maska[1, 2] = 0;
            maska[2, 0] = -1;
            maska[2, 1] = -2;
            maska[2, 2] = -1;

            int norm = 0;
            for (int i = 0; i < 3; i++)    //normowanie maski(czyli dzielenie przez sumę elementów)
                for (int j = 0; j < 3; j++)
                    norm += maska[i, j];

            int R, G, B;
            Color k;

            for (int i = 1; i < szer - 1; i++) //(od 1 bo piksele brzegowe wyjdą poza obraz)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    R = B = G = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            k = b1.GetPixel(i + x - 1, j + y - 1); //piksel lewy
                            R += k.R * maska[x, y];
                            G += k.G * maska[x, y];
                            B += k.B * maska[x, y];
                        }
                    }

                    if (norm != 0)
                    {
                        R /= norm;
                        G /= norm;
                        B /= norm;
                    }

                    if (R < 0) R = 0;
                    if (R > 255) R = 255;

                    if (G < 0) G = 0;
                    if (G > 255) G = 255;

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;


                    b2.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }

            pictureBox2.Invalidate();

            Cursor = Cursors.Default;
        }

//Sobel'a pionowy
        private void button12_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int[,] maska = new int[3, 3];
            maska[0, 0] = 1;
            maska[0, 1] = 0;
            maska[0, 2] = -1;
            maska[1, 0] = 2;
            maska[1, 1] = 0;
            maska[1, 2] = -2;
            maska[2, 0] = 1;
            maska[2, 1] = 0;
            maska[2, 2] = -1;

            int norm = 0;
            for (int i = 0; i < 3; i++)    //normowanie maski(czyli dzielenie przez sumę elementów)
                for (int j = 0; j < 3; j++)
                    norm += maska[i, j];

            int R, G, B;
            Color k;

            for (int i = 1; i < szer - 1; i++) //(od 1 bo piksele brzegowe wyjdą poza obraz)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    R = B = G = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            k = b1.GetPixel(i + x - 1, j + y - 1); //piksel lewy
                            R += k.R * maska[x, y];
                            G += k.G * maska[x, y];
                            B += k.B * maska[x, y];
                        }
                    }

                    if (norm != 0)
                    {
                        R /= norm;
                        G /= norm;
                        B /= norm;
                    }

                    if (R < 0) R = 0;
                    if (R > 255) R = 255;

                    if (G < 0) G = 0;
                    if (G > 255) G = 255;

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;


                    b2.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }

            pictureBox2.Invalidate();

            Cursor = Cursors.Default;
        }

        //Laplace'a
        private void button13_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int[,] maska = new int[3, 3];

            if (radioButton1.Checked == true)
            {
                maska[0, 0] = 0;
                maska[0, 1] = -1;
                maska[0, 2] = 0;
                maska[1, 0] = -1;
                maska[1, 1] = 4;
                maska[1, 2] = -1;
                maska[2, 0] = 0;
                maska[2, 1] = -1;
                maska[2, 2] = 0;
            }
            else if(radioButton2.Checked == true)
            { 
                maska[0, 0] = -1;
                maska[0, 1] = -1;
                maska[0, 2] = -1;
                maska[1, 0] = -1;
                maska[1, 1] = 8;
                maska[1, 2] = -1;
                maska[2, 0] = -1;
                maska[2, 1] = -1;
                maska[2, 2] = -1;
            }
            else
            {
                maska[0, 0] = -2;
                maska[0, 1] = 1;
                maska[0, 2] = -2;
                maska[1, 0] = 1;
                maska[1, 1] = 4;
                maska[1, 2] = 1;
                maska[2, 0] = -2;
                maska[2, 1] = 1;
                maska[2, 2] = -2;
            }

            int norm = 0;
            for (int i = 0; i < 3; i++)    //normowanie maski(czyli dzielenie przez sumę elementów)
                for (int j = 0; j < 3; j++)
                    norm += maska[i, j];

            int R, G, B;
            Color k;

            for (int i = 1; i < szer - 1; i++) //(od 1 bo piksele brzegowe wyjdą poza obraz)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    R = B = G = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            k = b1.GetPixel(i + x - 1, j + y - 1); //piksel lewy
                            R += k.R * maska[x, y];
                            G += k.G * maska[x, y];
                            B += k.B * maska[x, y];
                        }
                    }

                    if (norm != 0)
                    {
                        R /= norm;
                        G /= norm;
                        B /= norm;
                    }

                    if (R < 0) R = 0;
                    if (R > 255) R = 255;

                    if (G < 0) G = 0;
                    if (G > 255) G = 255;

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;


                    b2.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }

            pictureBox2.Invalidate();

            Cursor = Cursors.Default;
        }

//MIN
        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
            int min_r, min_g, min_b;
            
            for (int i = 1; i < szer - 1; i++)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    min_r = min_g = min_b = 255;
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            k1 = b1.GetPixel(i + x - 1, j + y - 1);
                            if (k1.R < min_r)
                                min_r = k1.R;
                            if (k1.G < min_g)
                                min_g = k1.G;
                            if (k1.B < min_b)
                                min_b = k1.B;
                        }
                    }
                    b2.SetPixel(i, j, Color.FromArgb(min_r, min_g, min_b));
                }
            }
            pictureBox2.Invalidate();

            Cursor = Cursors.Default;
        }

//MAX
        private void button5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
            int max_r, max_g, max_b;
            
            for (int i = 1; i < szer - 1; i++)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    max_r = max_g = max_b = 0;
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            k1 = b1.GetPixel(i + x - 1, j + y - 1);
                            if (k1.R > max_r)
                                max_r = k1.R;
                            if (k1.G > max_g)
                                max_g = k1.G;
                            if (k1.B > max_b)
                                max_b = k1.B;
                        }
                    }
                    b2.SetPixel(i, j, Color.FromArgb(max_r, max_g, max_b));
                }
            }
            pictureBox2.Invalidate();

            Cursor = Cursors.Default;
        }

//Medianowy
        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1;
            int[] tab_R = new int[9];
            int[] tab_G = new int[9];
            int[] tab_B = new int[9];
            int countpixels = 0;

            for (int x = 1; x < szer - 1; x++)
            {
                for (int y = 1; y < wys - 1; y++)
                {
                    countpixels = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            k1 = b1.GetPixel(x + i - 1, y + j - 1);
                            tab_R[countpixels] = k1.R;
                            tab_G[countpixels] = k1.G;
                            tab_B[countpixels] = k1.B;
                            countpixels++;
                        }
                    }
                    Array.Sort(tab_R);
                    Array.Sort(tab_G);
                    Array.Sort(tab_B);
                    b2.SetPixel(x, y, Color.FromArgb(tab_R[4], tab_G[4], tab_B[4]));
                }
            }
            pictureBox2.Invalidate();
        }

        //Wyjście z aplikacji
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Zapisywanie otrzymanego obrazu o nazwie wpisanej w textBox1
        private void button12_Click(object sender, EventArgs e)
        {
            if(pictureBox2.Image != null)
            {
                pictureBox2.Image.Save(textBox1.Text + "(zmienione).jpg", ImageFormat.Jpeg);
            }
            else
            {
                string message = "Nie ma zmienionego obrazu. Anulować operację?";
                string caption = "Error Detected";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                //Wyświetla MassageBox
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }

            }
        }



    }
}
