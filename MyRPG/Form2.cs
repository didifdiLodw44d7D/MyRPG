using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Net;
using System.IO;

namespace MyRPG
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            panel1.BackgroundImageLayout = ImageLayout.Zoom;

            string szUri = "https://koneko.tokyo/MyRPG/0001/p068b.png";

            // Create WebRequest 
            WebRequest w = WebRequest.Create(szUri);
            WebResponse r = w.GetResponse();
            Stream respstream = r.GetResponseStream();

            if (respstream.CanRead)
            {
                panel1.BackgroundImage = System.Drawing.Image.FromStream(respstream);
            }

            panel1.BackColor = Color.Aquamarine;

            listBox1.Items.Add("こうげき");
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                var row = listBox1.SelectedIndex;

                // 0 こうげき
                if (0 == row)
                {
                    listBox2.Items.Add("こねこまろ、のこうげき");
                }
                // 1 ぼうぎょ
                else if (1 == row)
                {
                    listBox2.Items.Add("こねこまろは、ぼうぎょのしせいをとっている");
                }
                // 2 まほう
                else if (2 == row)
                {
                    listBox2.Items.Add("こねこまろは、まほうをとなえた");
                }
            }
        }
    }
}

//https://dobon.net/vb/dotnet/graphics/creategraphics.html