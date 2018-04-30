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
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO.Ports;
using System.Diagnostics;

namespace Emgu_Example
{
    public partial class Serialout : Form
    {
        private VideoCapture _capture;
        private Thread _captureThread;

        int Threshold = 150;
        TimeSpan TurnTime = new TimeSpan(0, 0, 2);
        int yellowThreshold = 100;
        int TurnAround = 3000;
        double LeftSide = 33;
        double RightSide = 33;
        double LeftSideSide = 0;
        double RightSideSide = 0;

        int blackcount = 0, whitecount = 0, pixelcount = 0;
        int[] whiteLocation = new int[3] { 0, 0, 0 };
        int[] blackLocation = new int[3] { 0, 0, 0 };
        int[] yellowLocation = new int[3] { 0, 0, 0 };

        const byte STOP = 0x7F;
        const byte FLOAT = 0x0F;
        const byte FORWARD = 0x6f;
        const byte BACKWARD = 0x5F;
        const byte FORL = 0x01;
        const byte FORR = 0x03;
        const byte BACKL = 0x02;
        const byte BACKR = 0x04;
        const byte SPEED = 200;

        byte leftMotor = STOP;
        byte rightMotor = STOP;

        Stopwatch stopWatch = new Stopwatch();

        public Serialout()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeftBar.Value = 33;
            RightBar.Value = 33;
            Output.Invoke(new Action(() => CountLeft.Text = LeftSide.ToString()));
            Output.Invoke(new Action(() => CountRight.Text = RightSide.ToString()));

            _capture = new VideoCapture(1);
            _captureThread = new Thread(DisplayWebcam);
            _captureThread.Start();
        }

        private void DisplayWebcam()
        {
            SerialPort _serialPort = new SerialPort("COM3", 115200);
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.Two;


            _serialPort.Open();


            Input.Invoke(new Action(() => Input.Text = Threshold.ToString()));

            while (_capture.IsOpened)
            {
                Mat other = _capture.QueryFrame();
                CvInvoke.Resize(other, other, pictureBox2.Size);
                CvInvoke.Flip(other, other, Emgu.CV.CvEnum.FlipType.Horizontal);
                pixelcount = other.Width * other.Height;

                Mat grey = _capture.QueryFrame();
                CvInvoke.Resize(grey, grey, pictureBox3.Size);
                CvInvoke.Flip(grey, grey, Emgu.CV.CvEnum.FlipType.Horizontal);


                Image<Bgr, Byte> useImage = other.ToImage<Bgr, Byte>();
                Image<Gray, Byte> gray = grey.ToImage<Gray, Byte>();

                //Tests each pixel in the image
                for (int x = 0; x < useImage.Width; x++)
                {
                    for (int y = 0; y < useImage.Height; y++)
                    {


                        //Find and set Other Pixels
                        if (useImage.Data[y, x, 2] > yellowThreshold && useImage.Data[y, x, 1] < yellowThreshold && useImage.Data[y, x, 0] < yellowThreshold)
                        {
                            useImage.Data[y, x, 0] = 0;
                            useImage.Data[y, x, 1] = 0;
                            useImage.Data[y, x, 2] = 255;
                            pixelLocation(x, y, 'Y', useImage.Width, useImage.Height);
                        }

                        //Set pixel value as black or white within the bounds, Blackout outside of outer bounds
                        else if (gray.Data[y, x, 0] < Threshold || x < (LeftSideSide / 100) * useImage.Width || x > useImage.Width - (RightSideSide / 100) * useImage.Width)
                        {
                            useImage.Data[y, x, 0] = 0;
                            useImage.Data[y, x, 1] = 0;
                            useImage.Data[y, x, 2] = 0;
                            pixelLocation(x, y, 'B', useImage.Width, useImage.Height);
                        }
                        else
                        {
                            useImage.Data[y, x, 0] = 255;
                            useImage.Data[y, x, 1] = 255;
                            useImage.Data[y, x, 2] = 255;
                            pixelLocation(x, y, 'W', useImage.Width, useImage.Height);
                        }

                        //Set Center Bounds Line
                        if (x < (LeftSide / 100) * useImage.Width + 1 && x > (LeftSide / 100) * useImage.Width - 1)
                        {
                            useImage.Data[y, x, 0] = 255;
                            useImage.Data[y, x, 1] = 0;
                            useImage.Data[y, x, 2] = 0;
                        }
                        if (x < useImage.Width - ((RightSide / 100) * useImage.Width) + 1 && x > useImage.Width - (RightSide / 100) * useImage.Width - 1)
                        {
                            useImage.Data[y, x, 0] = 255;
                            useImage.Data[y, x, 1] = 0;
                            useImage.Data[y, x, 2] = 0;
                        }

                        //Outer Bounds Blackout Line
                        /*if (x < (LeftSideSide / 100) * useImage.Width + 1 && x > (LeftSideSide / 100) * useImage.Width - 1)
                        {
                            useImage.Data[y, x, 0] = 0;
                            useImage.Data[y, x, 1] = 0;
                            useImage.Data[y, x, 2] = 255;
                        }
                        if (x < useImage.Width - ((RightSideSide / 100) * useImage.Width) + 1 && x > useImage.Width - (RightSideSide / 100) * useImage.Width - 1)
                        {
                            useImage.Data[y, x, 0] = 0;
                            useImage.Data[y, x, 1] = 0;
                            useImage.Data[y, x, 2] = 255;
                        }*/

                    }
                }


                Output.Invoke(new Action(() => CountCenter.Text = yellowLocation[1].ToString()));

                if (yellowLocation[1] + yellowLocation[2] > TurnAround) //Turn around if there is enough red pixels
                {
                    Turnaround();
                    byte[] buffer = { leftMotor, SPEED, rightMotor, SPEED };
                    _serialPort.Write(buffer, 0, 4);
                    stopWatch.Start();
                    while (stopWatch.Elapsed < TurnTime)
                    { }
                    stopWatch.Reset();
                }
                else
                {
                    LaneFollow(false);
                    byte[] buffer = { leftMotor, SPEED, rightMotor, SPEED };
                    _serialPort.Write(buffer, 0, 4);
                }

                pictureBox2.Image = useImage.Bitmap;
                pictureBox3.Image = gray.Bitmap;

                Reset();
            }
        }

        private void Turnaround()//Turn around Logic
        {
            Output.Invoke(new Action(() => Output.Text = "Turn Around"));
            rightMotor = BACKR;
            leftMotor = FORL;
        }

        private void LineFollow(bool Invert_Direction)//Line Follow Logic
        {
            if (Invert_Direction == false)
            {
                if (whiteLocation[0] > whiteLocation[1] && whiteLocation[0] > whiteLocation[2])
                {
                    Output.Invoke(new Action(() => Output.Text = "Right"));
                    rightMotor = BACKR;
                    leftMotor = FORL;
                }
                else if (whiteLocation[2] > whiteLocation[1] && whiteLocation[2] > whiteLocation[0])
                {
                    Output.Invoke(new Action(() => Output.Text = "Left"));
                    leftMotor = BACKL;
                    rightMotor = FORR;
                }
                else if (whiteLocation[1] > whiteLocation[0] && whiteLocation[1] > whiteLocation[2])
                {
                    Output.Invoke(new Action(() => Output.Text = "Forwards"));
                    rightMotor = FORR;
                    leftMotor = FORL;
                }
                else
                {
                    Output.Invoke(new Action(() => Output.Text = "???"));
                    leftMotor = BACKL;
                    rightMotor = BACKR;
                }
            }

            else
            {
                if (whiteLocation[0] > whiteLocation[1] && whiteLocation[0] > whiteLocation[2])
                {
                    Output.Invoke(new Action(() => Output.Text = "Right"));
                    rightMotor = BACKWARD;
                    leftMotor = FORWARD;
                }
                else if (whiteLocation[2] > whiteLocation[1] && whiteLocation[2] > whiteLocation[0])
                {
                    Output.Invoke(new Action(() => Output.Text = "Left"));
                    leftMotor = FORWARD;
                    rightMotor = BACKWARD;
                }
                else if (whiteLocation[1] > whiteLocation[0] && whiteLocation[1] > whiteLocation[2])
                {
                    Output.Invoke(new Action(() => Output.Text = "Forwards"));
                    rightMotor = FORWARD;
                    leftMotor = FORWARD;
                }
                else
                {
                    Output.Invoke(new Action(() => Output.Text = "???"));
                    leftMotor = BACKWARD;
                    rightMotor = BACKWARD;
                }
            }
        }

        private void LaneFollow(bool Invert_Direction)//Lane Foolow Logic
        {
            if (Invert_Direction == false)
            {
                if (whiteLocation[0] > whiteLocation[2] && whiteLocation[1] > whiteLocation[2])
                {
                    Output.Invoke(new Action(() => Output.Text = "Right"));
                    rightMotor = BACKR;
                    leftMotor = FORL;
                }
                else if (whiteLocation[2] > whiteLocation[0] && whiteLocation[1] > whiteLocation[0])
                {
                    Output.Invoke(new Action(() => Output.Text = "Left"));
                    leftMotor = BACKL;
                    rightMotor = FORL;
                }
                else if (whiteLocation[0] > whiteLocation[1] && whiteLocation[2] > whiteLocation[1])
                {
                    Output.Invoke(new Action(() => Output.Text = "Forwards"));
                    rightMotor = FORL;
                    leftMotor = FORR;
                }
                else
                {
                    Output.Invoke(new Action(() => Output.Text = "???"));
                    leftMotor = BACKL;
                    rightMotor = BACKR;
                }
            }

            else
            {
                if (whiteLocation[0] > whiteLocation[2] && whiteLocation[1] > whiteLocation[2])
                {
                    Output.Invoke(new Action(() => Output.Text = "Left"));
                    rightMotor = BACKWARD;
                    leftMotor = FORWARD;
                }
                else if (whiteLocation[2] > whiteLocation[0] && whiteLocation[1] > whiteLocation[0])
                {
                    Output.Invoke(new Action(() => Output.Text = "Right"));
                    leftMotor = FORWARD;
                    rightMotor = BACKWARD;
                }
                else if (whiteLocation[0] > whiteLocation[1] && whiteLocation[2] > whiteLocation[1])
                {
                    Output.Invoke(new Action(() => Output.Text = "Forwards"));
                    rightMotor = BACKWARD;
                    leftMotor = BACKWARD;
                }
                else
                {
                    Output.Invoke(new Action(() => Output.Text = "???"));
                    leftMotor = FORWARD;
                    rightMotor = FORWARD;
                }
            }
        }

        private void Reset()//Resets each pixel location count
        {
            whiteLocation[0] = 0; whiteLocation[1] = 0; whiteLocation[2] = 0;
            blackLocation[0] = 0; blackLocation[1] = 0; blackLocation[2] = 0;
            yellowLocation[0] = 0; yellowLocation[1] = 0; yellowLocation[2] = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _captureThread.Abort();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(Input.Text, out Threshold))
            { }
            else
            {
                Input.Text = Threshold.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CountLeft_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            RightSide = RightBar.Value;
            Output.Invoke(new Action(() => CountRight.Text = RightSide.ToString()));
        }

        private void yellowInput_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(yellowInput.Text, out yellowThreshold))
            { }
            else
            {
                yellowInput.Text = yellowThreshold.ToString();
            }
        }

        private void LeftSideBar_Scroll(object sender, EventArgs e)
        {
            LeftSideSide = LeftSideBar.Value;
        }

        private void RightSideBar_Scroll(object sender, EventArgs e)
        {
            RightSideSide = RightSideBar.Value;
        }

        private void CountCenter_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            LeftSide = LeftBar.Value;
            Output.Invoke(new Action(() => CountLeft.Text = LeftSide.ToString()));
        }

        void pixelLocation(int x, int y, char color, int width, int height)//Counts the number of each colored pixel within each bounds area
        {
            switch (color)
            {
                case 'B':
                    if (x < ((LeftSide / 100) * width))
                        ++blackLocation[0];
                    else if (x > width - ((RightSide / 100) * width))
                        ++blackLocation[2];
                    else
                        ++blackLocation[1];
                    break;
                case 'W':
                    if (x < ((LeftSide / 100) * width))
                        ++whiteLocation[0];
                    else if (x > width - ((RightSide / 100) * width))
                        ++whiteLocation[2];
                    else
                        ++whiteLocation[1];
                    break;
                case 'Y':
                    if (x < ((LeftSide / 100) * width))
                        ++yellowLocation[0];
                    else if (x > width - ((RightSide / 100) * width))
                        ++yellowLocation[2];
                    else
                        ++yellowLocation[1];
                    break;
                default:
                    break;
            }
        }

    }
}
