using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuebraCabeça
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string optionPuzzle;
        private string[] convertedImages = new string[10];
        private void Form1_Load(object sender, EventArgs e)
        {
            setR2d2Puzzle();
            randomizePieces();
            puzzlePiece1.AllowDrop = true;
            puzzlePiece2.AllowDrop = true;
            puzzlePiece3.AllowDrop = true;
            puzzlePiece4.AllowDrop = true;
            puzzlePiece5.AllowDrop = true;
            puzzlePiece6.AllowDrop = true;
            puzzlePiece7.AllowDrop = true;
            puzzlePiece8.AllowDrop = true;
            puzzlePiece9.AllowDrop = true;
        }
        private void randomizePieces()
        {
            var index = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random rnd = new Random();
            index = Enumerable.Range(1, 9).OrderBy(r => rnd.Next()).ToArray();
            piece1.Image = Image.FromFile("../Imagens/" + optionPuzzle + "/" + index[0].ToString() + ".png");
            piece2.Image = Image.FromFile("../Imagens/" + optionPuzzle + "/" + index[1].ToString() + ".png");
            piece3.Image = Image.FromFile("../Imagens/" + optionPuzzle + "/" + index[2].ToString() + ".png");
            piece4.Image = Image.FromFile("../Imagens/" + optionPuzzle + "/" + index[3].ToString() + ".png");
            piece5.Image = Image.FromFile("../Imagens/" + optionPuzzle + "/" + index[4].ToString() + ".png");
            piece6.Image = Image.FromFile("../Imagens/" + optionPuzzle + "/" + index[5].ToString() + ".png");
            piece7.Image = Image.FromFile("../Imagens/" + optionPuzzle + "/" + index[6].ToString() + ".png");
            piece8.Image = Image.FromFile("../Imagens/" + optionPuzzle + "/" + index[7].ToString() + ".png");
            piece9.Image = Image.FromFile("../Imagens/" + optionPuzzle + "/" + index[8].ToString() + ".png");
        }
        private bool verifyIsAllImageFilled()
        {
            return puzzlePiece1.Image != null && puzzlePiece2.Image != null && puzzlePiece3.Image != null && puzzlePiece4.Image != null && puzzlePiece5.Image != null &&
                puzzlePiece6.Image != null && puzzlePiece7.Image != null && puzzlePiece8.Image != null && puzzlePiece9.Image != null;
        }
        private void setC3poPuzzle()
        {
            optionPuzzle = "c3po";
            namePuzzle.Text = "C3PO";
            restartPuzzle();
        }

        private void setLukePuzzle()
        {
            optionPuzzle = "luke";
            namePuzzle.Text = "LUKE";
            restartPuzzle();
        }
        private void setVaderPuzzle()
        {
            optionPuzzle = "vader";
            namePuzzle.Text = "VADER";
            restartPuzzle();
        }

        private void setR2d2Puzzle()
        {
            optionPuzzle = "r2d2";
            namePuzzle.Text = "R2D2";
            restartPuzzle();
        }
        private void restartPuzzle()
        {
            convertImagesToHash();
            finalImage.Visible = false;
            setImageToNull(puzzlePiece1);
            setImageToNull(puzzlePiece2);
            setImageToNull(puzzlePiece3);
            setImageToNull(puzzlePiece4);
            setImageToNull(puzzlePiece5);
            setImageToNull(puzzlePiece6);
            setImageToNull(puzzlePiece7);
            setImageToNull(puzzlePiece8);
            setImageToNull(puzzlePiece9);

        }
        private void setImageToNull(PictureBox pictureBox)
        {
            if(pictureBox.Image != null)
            {
                PictureBox pictureBoxPartner = getImageByHash(GetImageHash((Bitmap)pictureBox.Image));
                pictureBoxPartner.Visible = true;
                pictureBox.Image = null;
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void imagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setC3poPuzzle();
            randomizePieces();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void vaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVaderPuzzle();
            randomizePieces();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private PictureBox getImageByHash(string hash)
        {
            if (hash == null)
            {
                return null;
            }
            else if (GetImageHash((Bitmap)piece1.Image) == hash)
            {
                return piece1;
            }
            else if (GetImageHash((Bitmap)piece2.Image) == hash)
            {
                return piece2;
            }
            else if (GetImageHash((Bitmap)piece3.Image) == hash)
            {
                return piece3;
            }
            else if (GetImageHash((Bitmap)piece4.Image) == hash)
            {
                return piece4;
            }
            else if (GetImageHash((Bitmap)piece5.Image) == hash)
            {
                return piece5;
            }
            else if (GetImageHash((Bitmap)piece6.Image) == hash)
            {
                return piece6;
            }
            else if (GetImageHash((Bitmap)piece7.Image) == hash)
            {
                return piece7;
            }
            else if (GetImageHash((Bitmap)piece8.Image) == hash)
            {
                return piece8;
            }
            else if (GetImageHash((Bitmap)piece9.Image) == hash)
            {
                return piece9;
            }
            return null;
        }
        private void lukeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLukePuzzle();
            randomizePieces();
        }

        private void r2d2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setR2d2Puzzle();
            randomizePieces();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            randomizePieces();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void puzzlePiece1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        private void convertImagesToHash()
        {
            for (int i = 1; i <= 9; i++)
            {
                convertedImages[i] = GetImageHash((Bitmap)Image.FromFile("../Imagens/" + optionPuzzle + "/" + i.ToString() + ".png"));
            }
        }
        private bool isSuccessPuzzle()
        {
            if (!verifyIsAllImageFilled())
            {
                return false;
            }
            string test = GetImageHash((Bitmap)puzzlePiece1.Image);
            string test2 = GetImageHash((Bitmap)Image.FromFile("../Imagens/r2d2/1.png"));
            
            return convertedImages[1] == GetImageHash((Bitmap)puzzlePiece1.Image) &&
                 convertedImages[2] == GetImageHash((Bitmap)puzzlePiece2.Image) &&
                  convertedImages[3] == GetImageHash((Bitmap)puzzlePiece3.Image) &&
                   convertedImages[4] == GetImageHash((Bitmap)puzzlePiece4.Image) &&
                    convertedImages[5] == GetImageHash((Bitmap)puzzlePiece5.Image) &&
                     convertedImages[6] == GetImageHash((Bitmap)puzzlePiece6.Image) &&
                      convertedImages[7] == GetImageHash((Bitmap)puzzlePiece7.Image) &&
                       convertedImages[8] == GetImageHash((Bitmap)puzzlePiece8.Image) &&
                        convertedImages[9] == GetImageHash((Bitmap)puzzlePiece9.Image);
        }
        private void doDragAndDropAction(PictureBox pictureBox)
        {
            puzzlePiece1.DoDragDrop(pictureBox.Image, DragDropEffects.Copy | DragDropEffects.Move);
            puzzlePiece2.DoDragDrop(pictureBox.Image, DragDropEffects.Copy | DragDropEffects.Move);
            puzzlePiece3.DoDragDrop(pictureBox.Image, DragDropEffects.Copy | DragDropEffects.Move);
            puzzlePiece4.DoDragDrop(pictureBox.Image, DragDropEffects.Copy | DragDropEffects.Move);
            puzzlePiece5.DoDragDrop(pictureBox.Image, DragDropEffects.Copy | DragDropEffects.Move);
            puzzlePiece6.DoDragDrop(pictureBox.Image, DragDropEffects.Copy | DragDropEffects.Move);
            puzzlePiece7.DoDragDrop(pictureBox.Image, DragDropEffects.Copy | DragDropEffects.Move);
            puzzlePiece8.DoDragDrop(pictureBox.Image, DragDropEffects.Copy | DragDropEffects.Move);
            puzzlePiece9.DoDragDrop(pictureBox.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }
        private void doDragEnterAction(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void dragAndDropAction(PictureBox currentPictureBox, DragEventArgs e)
        {
            currentPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            if (currentPictureBox.Image != null)
            {
                PictureBox pictureBoxPartner = getImageByHash(GetImageHash((Bitmap)currentPictureBox.Image));
                pictureBoxPartner.Visible = true;
            }
            currentPictureBox.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            PictureBox pictureBox = getImageByHash(GetImageHash((Bitmap)currentPictureBox.Image));
            pictureBox.Visible = false;
            if (isSuccessPuzzle())
            {
                setSuccessFlow();
            }
        }
        private void piece1_MouseDown(object sender, MouseEventArgs e)
        {
            doDragAndDropAction(piece1);
        }
        private void setSuccessFlow()
        {
            finalImage.Visible = true;
            finalImage.Image = Image.FromFile("../Imagens/" + optionPuzzle + "/" + optionPuzzle + ".png");
            MessageBox.Show("SUCESSO! QUE A FORÇA ESTEJA COM VOCÊ");
        }
        private void puzzlePiece1_DragEnter(object sender, DragEventArgs e)
        {
            doDragEnterAction(e);
        }
        private string GetImageHash(Bitmap bmpSource)
        {
             List<byte> colorList = new List<byte>();
            string hash;
            colorList.Clear();
            int i, j;
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16)); //create new image with 16x16 pixel
            for (j = 0; j < bmpMin.Height; j++)
            {
                for (i = 0; i < bmpMin.Width; i++)
                {
                    colorList.Add(bmpMin.GetPixel(i, j).R);
                }
            }
            SHA1Managed sha = new SHA1Managed();
            byte[] checksum = sha.ComputeHash(colorList.ToArray());
            hash = BitConverter.ToString(checksum).Replace("-", String.Empty);
            sha.Dispose();
            bmpMin.Dispose();
            return hash;
        }
        private void puzzlePiece1_DragDrop(object sender, DragEventArgs e)
        {
            dragAndDropAction(puzzlePiece1, e);
        }

        private void puzzlePiece1_DoubleClick(object sender, EventArgs e)
        {
            setImageToNull(puzzlePiece1);
        }

        private void piece2_MouseDown(object sender, MouseEventArgs e)
        {
            doDragAndDropAction(piece2);
        }

        private void piece3_MouseDown(object sender, MouseEventArgs e)
        {
            doDragAndDropAction(piece3);
        }

        private void piece4_MouseDown(object sender, MouseEventArgs e)
        {
            doDragAndDropAction(piece4);
        }

        private void piece5_MouseDown(object sender, MouseEventArgs e)
        {
            doDragAndDropAction(piece5);
        }

        private void piece6_MouseDown(object sender, MouseEventArgs e)
        {
            doDragAndDropAction(piece6);
        }

        private void piece7_MouseDown(object sender, MouseEventArgs e)
        {
            doDragAndDropAction(piece7);
        }

        private void piece8_MouseDown(object sender, MouseEventArgs e)
        {
            doDragAndDropAction(piece8);
        }

        private void piece9_MouseDown(object sender, MouseEventArgs e)
        {
            doDragAndDropAction(piece9);
        }
        
        private void puzzlePiece2_DragEnter(object sender, DragEventArgs e)
        {
            doDragEnterAction(e);
        }

        private void puzzlePiece2_DragDrop(object sender, DragEventArgs e)
        {
            dragAndDropAction(puzzlePiece2, e);
        }

        private void puzzlePiece3_DragEnter(object sender, DragEventArgs e)
        {
            doDragEnterAction(e);
        }

        private void puzzlePiece3_DragDrop(object sender, DragEventArgs e)
        {
            dragAndDropAction(puzzlePiece3, e);
        }

        private void puzzlePiece4_DragEnter(object sender, DragEventArgs e)
        {
            doDragEnterAction(e);
        }

        private void puzzlePiece4_DragDrop(object sender, DragEventArgs e)
        {
            dragAndDropAction(puzzlePiece4, e);
        }

        private void puzzlePiece5_DragEnter(object sender, DragEventArgs e)
        {
            doDragEnterAction(e);
        }

        private void puzzlePiece5_DragDrop(object sender, DragEventArgs e)
        {
            dragAndDropAction(puzzlePiece5, e);
        }

        private void puzzlePiece6_DragEnter(object sender, DragEventArgs e)
        {
            doDragEnterAction(e);
        }

        private void puzzlePiece6_DragDrop(object sender, DragEventArgs e)
        {
            dragAndDropAction(puzzlePiece6, e);
        }

        private void puzzlePiece7_DragEnter(object sender, DragEventArgs e)
        {
            doDragEnterAction(e);
        }

        private void puzzlePiece7_DragDrop(object sender, DragEventArgs e)
        {
            dragAndDropAction(puzzlePiece7, e);
        }

        private void puzzlePiece8_DragEnter(object sender, DragEventArgs e)
        {
            doDragEnterAction(e);
        }

        private void puzzlePiece8_DragDrop(object sender, DragEventArgs e)
        {
            dragAndDropAction(puzzlePiece8, e);
        }

        private void puzzlePiece9_DragEnter(object sender, DragEventArgs e)
        {
            doDragEnterAction(e);
        }

        private void puzzlePiece9_DragDrop(object sender, DragEventArgs e)
        {
            dragAndDropAction(puzzlePiece9, e);
        }

        private void puzzlePiece2_DoubleClick(object sender, EventArgs e)
        {
            setImageToNull(puzzlePiece2);
        }

        private void puzzlePiece3_DoubleClick(object sender, EventArgs e)
        {
            setImageToNull(puzzlePiece3);
        }

        private void puzzlePiece4_DoubleClick(object sender, EventArgs e)
        {
            setImageToNull(puzzlePiece4);
        }

        private void puzzlePiece5_DoubleClick(object sender, EventArgs e)
        {
            setImageToNull(puzzlePiece5);
        }

        private void puzzlePiece6_DoubleClick(object sender, EventArgs e)
        {
            setImageToNull(puzzlePiece6);
        }

        private void puzzlePiece7_DoubleClick(object sender, EventArgs e)
        {
            setImageToNull(puzzlePiece7);
        }

        private void puzzlePiece8_DoubleClick(object sender, EventArgs e)
        {
            setImageToNull(puzzlePiece8);
        }

        private void puzzlePiece9_DoubleClick(object sender, EventArgs e)
        {
            setImageToNull(puzzlePiece9);
        }
    }
}
