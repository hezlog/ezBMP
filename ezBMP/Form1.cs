using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    // Token: 0x02000002 RID: 2
    public partial class Form1 : Form
    {
        // Token: 0x06000003 RID: 3 RVA: 0x00002924 File Offset: 0x00000B24
        public Form1()
        {
            this.InitializeComponent();
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002988 File Offset: 0x00000B88
        private void Form1_Load(object sender, EventArgs e)
        {
            base.MouseWheel += this.pictureBox1_MouseWheel;
            this.bmp_org = (Bitmap)this.pictureBox1.Image;
            this.bmp_mod_xy = (this.bmp_mod_a = this.bmp_org);
            this.label3.Text = string.Concat(new object[]
            {
                "S: ",
                this.scale / 100,
                ".",
                this.scale % 100
            });
            this.comboBox_change.SelectedIndex = 5;
            this.statusStrip1.Items[0].Text = "www.ezcircuits.net";
        }

        // Token: 0x06000005 RID: 5 RVA: 0x00002A48 File Offset: 0x00000C48
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string filename = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                this.OpenPicture(filename);
            }
        }

        // Token: 0x06000006 RID: 6 RVA: 0x00002A90 File Offset: 0x00000C90
        private void OpenPicture(string filename)
        {
            try
            {
                Bitmap bitmap = (Bitmap)Image.FromFile(filename);
                int height = bitmap.Height;
                int width = bitmap.Width;
                Bitmap bitmap2 = new Bitmap(width, height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        bitmap2.SetPixel(i, j, bitmap.GetPixel(i, j));
                    }
                }
                this.bmp_org = bitmap2;
                this.bmp_mod_a = this.bmp_org;
                this.bmp_mod_xy = bitmap2;
                this.pictureBox1.Image = this.bmp_mod_a;
                this.file_name = Path.GetFileNameWithoutExtension(filename);
                this.file_path = Path.GetDirectoryName(filename);
                this.label4.Text = this.file_name;
                this.label3.Text = "S: " + this.scale / 100 + "." + this.scale % 100;
                this.statusStrip1.Items[0].Text = "Height = " + height.ToString() + "    Width = " + width.ToString();
            }
            catch
            {
                MessageBox.Show("잘못된 이미지입니다");
            }
        }

        // Token: 0x06000007 RID: 7 RVA: 0x00002C48 File Offset: 0x00000E48
        private void button_save_Click(object sender, EventArgs e)
        {
            if (this.image_data == null)
            {
                MessageBox.Show("변환데이터가 없습니다");
            }
            else
            {
                this.saveFileDialog1.InitialDirectory = this.file_path;
                this.saveFileDialog1.FileName = this.file_name;
                this.saveFileDialog1.DefaultExt = "c";
                this.saveFileDialog1.Filter = "c files (*.c)|*.c";
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    int byteCount = Encoding.Default.GetByteCount(this.image_data);
                    byte[] array = new byte[byteCount];
                    FileStream fileStream = new FileStream(this.saveFileDialog1.FileName, FileMode.Create, FileAccess.ReadWrite);
                    array = Encoding.Default.GetBytes(this.copyright);
                    fileStream.Seek(0L, SeekOrigin.Begin);
                    fileStream.Write(array, 0, array.Length);
                    array = Encoding.Default.GetBytes(this.image_data);
                    fileStream.Write(array, 0, array.Length);
                    array = Encoding.Default.GetBytes(this.image_data1);
                    fileStream.Write(array, 0, array.Length);
                    array = Encoding.Default.GetBytes(this.image_data2);
                    fileStream.Write(array, 0, array.Length);
                    fileStream.Close();
                }
            }
        }

        // Token: 0x06000008 RID: 8 RVA: 0x00002D88 File Offset: 0x00000F88
        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png|All Files (*.*)|*.*";
            this.openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.OpenPicture(this.openFileDialog1.FileName);
            }
        }

        // Token: 0x06000009 RID: 9 RVA: 0x00002DE4 File Offset: 0x00000FE4
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Text = "X: " + e.X.ToString();
            this.label2.Text = "Y: " + e.Y.ToString();
            int x;
            int y;
            if (e == null)
            {
                y = (x = 0);
            }
            else
            {
                x = e.X;
                y = e.Y;
            }
            Color pixel = this.bmp_mod_xy.GetPixel(x, y);
            this.statusStrip1.Items[0].Text = pixel.ToString();
        }

        // Token: 0x0600000A RID: 10 RVA: 0x00002E94 File Offset: 0x00001094
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            bool flag = true;
            if (e.Delta < 0)
            {
                flag = false;
            }
            if (!flag)
            {
                this.scale -= 50;
                if (this.scale < 25)
                {
                    this.scale = 25;
                }
            }
            else
            {
                if (this.scale == 25)
                {
                    this.scale += 25;
                }
                else
                {
                    this.scale += 50;
                }
                if (this.scale > 400)
                {
                    this.scale = 400;
                }
            }
            this.label3.Text = string.Concat(new object[]
            {
                "S: ",
                this.scale / 100,
                ".",
                this.scale % 100
            });
            Bitmap bitmap = new Bitmap(this.bmp_org.Width, this.bmp_org.Height);
            bitmap = this.bmp_mod_a;
            Image image = bitmap;
            bitmap = new Bitmap(image.Width * this.scale / 100, image.Height * this.scale / 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);
            graphics.Dispose();
            this.pictureBox1.Image = bitmap;
            this.bmp_mod_xy = bitmap;
        }

        // Token: 0x0600000B RID: 11 RVA: 0x00003019 File Offset: 0x00001219
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.Text = " ";
            this.label2.Text = " ";
        }

        // Token: 0x0600000C RID: 12 RVA: 0x00003040 File Offset: 0x00001240
        private void button_change_Click(object sender, EventArgs e)
        {
            byte b = 0;
            int height = this.bmp_org.Height;
            int width = this.bmp_org.Width;
            int selectedIndex = this.comboBox_change.SelectedIndex;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            StringBuilder stringBuilder3 = new StringBuilder();
            string str = (string)this.comboBox_change.Items[selectedIndex];
            stringBuilder.Append(string.Concat(new string[]
            {
                "\r\n/*\r\n        Image size H = ",
                Convert.ToString(width, 10),
                "    V = ",
                Convert.ToString(height, 10),
                "\r\n"
            }));
            stringBuilder.Append("\r\n        Convert to " + str + "/pixel");
            int num = 1000;
            int num2 = width;
            if (selectedIndex == 0)
            {
                num = 125;
                if (width % 8 != 0)
                {
                    num2 = (width / 8 + 1) * 8;
                }
                stringBuilder2.Append("\r\n/*\r\nconst unsigned short IMG_" + this.file_name + "_1[] = {");
                stringBuilder3.Append("\r\n/*\r\nconst unsigned char IMG_" + this.file_name + "_2[] = {");
            }
            else if (selectedIndex == 1)
            {
                num = 125;
                if (width % 8 != 0)
                {
                    num2 = (width / 8 + 1) * 8;
                }
                stringBuilder2.Append("\r\n/*\r\nconst unsigned short IMG_" + this.file_name + "_1[] = {");
                stringBuilder3.Append("\r\n/*\r\nconst unsigned char  IMG_" + this.file_name + "_2[] = {");
            }
            else if (selectedIndex == 2)
            {
                num = 250;
                if (width % 4 != 0)
                {
                    num2 = (width / 4 + 1) * 4;
                }
                stringBuilder3.Append("\r\n/*\r\ntext_image = {");
            }
            else if (selectedIndex == 3)
            {
                num = 500;
                if (width % 2 != 0)
                {
                    num2 = (width / 2 + 1) * 2;
                }
                stringBuilder3.Append("\r\n/*\r\nconst unsigned char IMG_" + this.file_name + "_2[] = {");
            }
            else if (selectedIndex == 4)
            {
                num = 1000;
                stringBuilder3.Append("\r\n/*\r\nconst unsigned char IMG_" + this.file_name + "_2[] = {");
            }
            else if (selectedIndex == 5)
            {
                num = 1000;
                stringBuilder3.Append("\r\n/*\r\nconst unsigned char IMG_" + this.file_name + "_2[] = {");
            }
            else if (selectedIndex == 6)
            {
                num = 2000;
                stringBuilder3.Append("\r\n/*\r\nconst unsigned short IMG_" + this.file_name + "_2[] = {");
            }
            stringBuilder.Append("      Total : " + Convert.ToString(num2 * height * num / 1000, 10) + " Bytes\r\n*/");
            stringBuilder.Append("\r\nconst unsigned char IMG_" + this.file_name + "_0[] = {");
            Bitmap bitmap = new Bitmap(this.bmp_org.Width, this.bmp_org.Height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    Color color;
                    if (j < width)
                    {
                        color = this.bmp_org.GetPixel(j, i);
                    }
                    else
                    {
                        color = Color.Black;
                    }
                    if (j == 0)
                    {
                        stringBuilder.Append("\r\n");
                        stringBuilder2.Append("\r\n");
                        stringBuilder3.Append("\r\n");
                    }
                    if (selectedIndex < 5)
                    {
                        byte b3;
                        byte b2 = b3 = color.R;
                        if (color.G > b3)
                        {
                            b3 = color.G;
                        }
                        if (color.B > b3)
                        {
                            b3 = color.B;
                        }
                        if (color.G < b2)
                        {
                            b2 = color.G;
                        }
                        if (color.B < b2)
                        {
                            b2 = color.B;
                        }
                        byte b4 = (byte)((b3 + b2) / 2);
                        if (selectedIndex == 0)
                        {
                            b = (byte)(b << 1);
                            //if (b4 > 127)
                            if ((0.5 <= color.GetBrightness()) && (128 <= color.A))
                            {
                                if (j < width)
                                {
                                    bitmap.SetPixel(j, i, Color.White);
                                }
                                stringBuilder3.Append("X");
                                b |= 1;
                            }
                            else
                            {
                                if (j < width)
                                {
                                    bitmap.SetPixel(j, i, Color.Black);
                                }
                                stringBuilder3.Append("_");
                            }
                            if (j % 8 == 7)
                            {
                                if (j == num2 - 1 && i == height - 1)
                                {
                                    stringBuilder3.Append(" ");
                                    stringBuilder.Append("0x" + Convert.ToString(b, 16).PadLeft(2, '0'));
                                    stringBuilder2.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
                                }
                                else
                                {
                                    stringBuilder3.Append(",");
                                    stringBuilder.Append("0x" + Convert.ToString(b, 16).PadLeft(2, '0') + ",");
                                    if (j % 16 == 15)
                                    {
                                        stringBuilder2.Append(Convert.ToString(b, 16).PadLeft(2, '0') + ",");
                                    }
                                    else
                                    {
                                        stringBuilder2.Append("0x" + Convert.ToString(b, 16).PadLeft(2, '0'));
                                    }
                                }
                            }
                        }
                        if (selectedIndex == 1)
                        {
                            b = (byte)(b << 1);
                            //if (b4 < 128)
                            if ((color.GetBrightness() < 0.5) && (128 <= color.A))
                            {
                                if (j < width)
                                {
                                    bitmap.SetPixel(j, i, Color.White);
                                }
                                stringBuilder3.Append("X");
                                b |= 1;
                            }
                            else
                            {
                                if (j < width)
                                {
                                    bitmap.SetPixel(j, i, Color.Black);
                                }
                                stringBuilder3.Append("_");
                            }
                            if (j % 8 == 7)
                            {
                                if (j == num2 - 1 && i == height - 1)
                                {
                                    stringBuilder3.Append(" ");
                                    stringBuilder.Append("0x" + Convert.ToString(b, 16).PadLeft(2, '0'));
                                    stringBuilder2.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
                                }
                                else
                                {
                                    stringBuilder3.Append(",");
                                    stringBuilder.Append("0x" + Convert.ToString(b, 16).PadLeft(2, '0') + ",");
                                    if (j % 16 == 15)
                                    {
                                        stringBuilder2.Append(Convert.ToString(b, 16).PadLeft(2, '0') + ",");
                                    }
                                    else
                                    {
                                        stringBuilder2.Append("0x" + Convert.ToString(b, 16).PadLeft(2, '0'));
                                    }
                                }
                            }
                        }
                        else if (selectedIndex == 2)
                        {
                            b = (byte)(b << 2);
                            if (j < width)
                            {
                                if (b4 > 192)
                                {
                                    bitmap.SetPixel(j, i, Color.FromArgb(255, 255, 255, 255));
                                    b |= 3;
                                    stringBuilder3.Append(".");
                                }
                                else if (b4 > 127)
                                {
                                    bitmap.SetPixel(j, i, Color.FromArgb(255, 128, 128, 128));
                                    b |= 2;
                                    stringBuilder3.Append(":");
                                }
                                else if (b4 > 63)
                                {
                                    bitmap.SetPixel(j, i, Color.FromArgb(255, 64, 64, 64));
                                    b |= 1;
                                    stringBuilder3.Append("O");
                                }
                                else
                                {
                                    bitmap.SetPixel(j, i, Color.Black);
                                    stringBuilder3.Append("#");
                                }
                            }
                            if (j % 4 == 3)
                            {
                                stringBuilder.Append("0x" + Convert.ToString(b, 16).PadLeft(2, '0'));
                                if (j == width - 1 && i == height - 1)
                                {
                                    stringBuilder.Append(" ");
                                }
                                else
                                {
                                    stringBuilder.Append(",");
                                }
                            }
                        }
                        else if (selectedIndex == 3)
                        {
                            b = (byte)(b << 4);
                            if (j < width)
                            {
                                if (b4 > 240)
                                {
                                    b4 = byte.MaxValue;
                                    b |= 15;
                                }
                                else
                                {
                                    b4 &= 240;
                                    byte b5 = b4;
                                    b |= (byte)(b5 >> 4);
                                }
                                bitmap.SetPixel(j, i, Color.FromArgb(255, (int)b4, (int)b4, (int)b4));
                            }
                            if (j % 2 == 1)
                            {
                                stringBuilder.Append("0x" + Convert.ToString(b, 16).PadLeft(2, '0'));
                                if (j == width - 1 && i == height - 1)
                                {
                                    stringBuilder.Append(" ");
                                }
                                else
                                {
                                    stringBuilder.Append(",");
                                }
                            }
                        }
                        else if (selectedIndex == 4)
                        {
                            bitmap.SetPixel(j, i, Color.FromArgb(255, (int)b4, (int)b4, (int)b4));
                            stringBuilder.Append("0x" + Convert.ToString(b4, 16).PadLeft(2, '0'));
                            if (j == width - 1 && i == height - 1)
                            {
                                stringBuilder.Append(" ");
                            }
                            else
                            {
                                stringBuilder.Append(",");
                            }
                        }
                    }
                    else if (selectedIndex == 5)
                    {
                        byte r = color.R;
                        byte g = color.G;
                        byte b6 = color.B;
                        byte b4 = (byte)((int)(b6 & 224) | (g & 224) >> 3 | (r & 192) >> 6);
                        bitmap.SetPixel(j, i, Color.FromArgb(255, (int)(r & 192), (int)(g & 224), (int)(b6 & 224)));
                        stringBuilder.Append("0x" + Convert.ToString(b4, 16).PadLeft(2, '0'));
                        if (j == width - 1 && i == height - 1)
                        {
                            stringBuilder.Append(" ");
                        }
                        else
                        {
                            stringBuilder.Append(",");
                        }
                    }
                    else if (selectedIndex == 6)
                    {
                        bitmap.SetPixel(j, i, Color.FromArgb(255, (int)(color.R & 248), (int)(color.G & 252), (int)(color.B & 248)));
                        byte b3 = (byte)((int)(color.R & 248) | (color.G & 224) >> 5);
                        byte b2 = (byte)((int)(color.G & 28) << 3 | (color.B & 248) >> 3);
                        stringBuilder.Append("0x" + Convert.ToString(b3, 16).PadLeft(2, '0') + ",0x" + Convert.ToString(b2, 16).PadLeft(2, '0'));
                        stringBuilder3.Append("0x" + Convert.ToString(b3, 16).PadLeft(2, '0') + Convert.ToString(b2, 16).PadLeft(2, '0'));
                        if (j == width - 1 && i == height - 1)
                        {
                            stringBuilder.Append(" ");
                            stringBuilder3.Append(" ");
                        }
                        else
                        {
                            stringBuilder.Append(",");
                            stringBuilder3.Append(",");
                        }
                    }
                }
            }
            stringBuilder.Append("\r\n}; \r\n");
            stringBuilder2.Append("\r\n}; \r\n*/\r\n");
            stringBuilder3.Append("\r\n}; \r\n*/\r\n");
            this.image_data = stringBuilder.ToString();
            if (selectedIndex <= 1)
            {
                this.image_data1 = stringBuilder2.ToString();
            }
            else
            {
                this.image_data1 = "";
            }
            if (selectedIndex == 6 || selectedIndex <= 2)
            {
                this.image_data2 = stringBuilder3.ToString();
            }
            else
            {
                this.image_data2 = "";
            }
            this.bmp_mod_a = bitmap;
            this.scale = 100;
            this.label3.Text = string.Concat(new object[]
            {
                "S: ",
                this.scale / 100,
                ".",
                this.scale % 100
            });
            this.pictureBox1.Image = bitmap;
        }

        // Token: 0x0600000D RID: 13 RVA: 0x00003E5C File Offset: 0x0000205C
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = (DragDropEffects.Copy | DragDropEffects.Scroll);
            }
        }

        // Token: 0x04000010 RID: 16
        private Bitmap bmp_org = new Bitmap(100, 100);

        // Token: 0x04000011 RID: 17
        private Bitmap bmp_mod_a = new Bitmap(100, 100);

        // Token: 0x04000012 RID: 18
        private Bitmap bmp_mod_xy = new Bitmap(100, 100);

        // Token: 0x04000013 RID: 19
        private int scale = 100;

        // Token: 0x04000014 RID: 20
        private string image_data;

        // Token: 0x04000015 RID: 21
        private string image_data1;

        // Token: 0x04000016 RID: 22
        private string image_data2;

        // Token: 0x04000017 RID: 23
        private string file_name;

        // Token: 0x04000018 RID: 24
        private string file_path;

        // Token: 0x04000019 RID: 25
        private string copyright = "/*\r\n        C-file generated by ezCircuit Image Converter ezBMP\r\n*/";
    }
}
