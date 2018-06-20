using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MyRPG
{
    public partial class Form1 : Form
    {
        int x = 0;
        int y = 0;
        int map_size = 1000;
        char[,] map;
        char[,] display;
        int width = 40;     //center = 20 - 1 = [19]
        int height = 20;    //center = 10 - 1 = [9]

        public Form1()
        {
            InitializeComponent();

            pictureBox2.Parent = panel1;

            pictureBox2.Location = new Point(0, 0);

            map = GetMap();

            display = CalcMap1200x600(map, 1, 0);
  
            RenderingMap(display);

            //pictureBox1.BackColor = Color.Blue;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.W == e.KeyCode)
            {
                y-=32;
                EnterBattleMode();
            }
            if (Keys.S == e.KeyCode)
            {
                y+=32;
            }
            if (Keys.D == e.KeyCode)
            {
                x+=32;
            }
            if (Keys.A == e.KeyCode)
            {
                x -= 32;
                //display = CalcMap1200x600(map, 0, 0);
                //RenderingMap(display);
                //panel1.Refresh();
            }

            MoveCharacter();
        }

        private void MoveCharacter()
        {
            pictureBox2.Location = new Point(x, y);
        }

        private char[,] GetMap()
        {
            char[,] map = new char[1000, 1000];

            for(int y=0;y<1000;y++)
            {
                for(int x=0;x<1000;x++)
                {
                    map[x, y] = 'm';
                }
            }

            //テキストマップから読み取る処理
            map[0, 0] = 'i';
            map[1, 0] = 'k';
            map[2, 0] = 'i';
            map[3, 0] = 'k';
            
            return map;
        }

        private void RenderingMap(char[,] display)
        {
            PictureBox[,] map_chip = new PictureBox[width, height];

            int margin = 32;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    map_chip[i, j] = new PictureBox();

                    map_chip[i, j].Parent = panel1;

                    map_chip[i, j].Size = new Size(32, 32);

                    string file_path = null;

                    switch (display[i, j])
                    {
                        case 'm':
                            file_path = @"D:\vs2018\MyRPG\MyRPG\michi.png";
                            break;
                        case 'k':
                            file_path = @"D:\vs2018\MyRPG\MyRPG\kusa.png";
                            break;
                        case 'i':
                            file_path = @"D:\vs2018\MyRPG\MyRPG\iwayama.png";
                            break;
                    }

                    map_chip[i, j].ImageLocation = file_path;

                    map_chip[i, j].Location = new Point((margin * i), (margin * j));
                }
            }
        }

        private char[,] CalcMap1200x600(char[,] map, int x, int y)
        {
            int pos_x = x;
            int pos_y = y;

            char[,] display = new char[width, height];

            for (int j = 0; j < height; j++)
            {
                for (int i = 0;i < width; i++)
                {
                    display[i, j] = map[pos_x, pos_y];

                    pos_x++;
                }

                pos_y++;
            }

            return display;
        }

        private void EnterBattleMode()
        {
            Form2 f2 = new Form2();

            f2.ShowDialog();
        }
    }
}
