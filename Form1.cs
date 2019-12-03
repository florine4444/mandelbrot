using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelgetal
{
    public partial class Form1 : Form
    {
        //we declareren hier alvast de variabelen die de invoerwaarde van de tekstboxen gaan aannemen
        //zodat we ze in meerdere methoden kunnen gebruiken
        int t;
        float huidigXf, huidigYf;
        double invoerX, invoerY, schaal, max, afstand, a, b, olda, huidigX, huidigY, nieuwX, nieuwY;
        public Form1()
        {
            InitializeComponent();
            //we passen de grootte van het scherm handmatig aan zodat we nu de precieze grootte aan kunnen geven in plaats van te slepen in de designer mode
            this.ClientSize = new Size(510,600);
            button1.Click += this.button1_Click;
            this.panel1.Paint += this.panel1_Paint;
            textBox1.Text = "0.1";
            textBox2.Text = "0.01";
            textBox3.Text = "0.3";
            textBox4.Text = "100";

        }
        //event aangemaakt voor als er op de OK knop wordt gedrukt
        private void button1_Click(object sender, EventArgs e)
        {
            //we nemen de invoer uit alle tekstboxen en zetten deze om van string naar double zodat we ermee kunnen rekenen
            this.Invalidate();

        }
        private void panel1_Paint(object sender, PaintEventArgs pea)
        {
            invoerX = double.Parse(textBox1.Text);
            invoerY = double.Parse(textBox3.Text);
            schaal = double.Parse(textBox2.Text);
            max = double.Parse(textBox4.Text);
            a = 0;
            b = 0;
            afstand = 0;
            t = 0;

            for (huidigY = 0; huidigY < panel1.Height; huidigY++)
            {
                for (huidigX = 0; huidigX < panel1.Width; huidigX++)
                {
                    while (afstand < 2 && t <= max)
                    {
                        nieuwY = huidigY * schaal;
                        nieuwX = huidigX * schaal;
                        olda = a;
                        t++;
                        a = a * a - b * b + nieuwX;
                        b = 2 * olda * b + nieuwY;
                        afstand = Math.Sqrt(a * a + b * b);
                    }
                        huidigXf = (float)nieuwX;
                        huidigYf = (float)nieuwY;
                        if (t == max)
                        {
                            pea.Graphics.FillRectangle(Brushes.Black, huidigXf, huidigYf, 1, 1);
                        }
                        else if (t % 2 == 0)
                        {
                            pea.Graphics.FillRectangle(Brushes.White, huidigXf, huidigYf, 1, 1);
                        }
                        else
                        {
                            pea.Graphics.FillRectangle(Brushes.Black, huidigXf, huidigYf, 1, 1);
                        }

                    }
                }
            }
                
  
        }

    }

//problemen: hij begint met tekenen voordat we op OP klikken, hij gebruikt geen wit, hij gaat buiten de panel