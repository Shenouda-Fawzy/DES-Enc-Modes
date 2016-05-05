using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Numerics;

namespace Cipher_Modes
{
    public partial class Form1 : Form
    {
        DESCryptoServiceProvider des;
        // BigInteger key , iv;
        long myKey;
        byte[] key;
        public Form1()
        {
            InitializeComponent();
            des = new DESCryptoServiceProvider();
            this.keyLabel.Text = "";
            this.ivLable.Text = "";
            this.key = generate8ByteKey();
        }

//Browse btn.
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Bitmap (*.bmp) | *.bmp";
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                imgPath_txt.Text = openFileDialog1.FileName;
                OriginalPicBox.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        public void encrypECPMode() 
        {
            // 1. Set the block encryptoin mode.
            // 2. Convert the Bitmap Image to stream of byte im Memory to encrypt it.
            // 3. Split to [Header] and [Data].
            // 4. Create a encryptor to encrypt [Data] using a 8-byte KEY .
            // 5. Combine the [Header] with the encrypted [Data] .
            // 6. Extract the Image back from the stream you created in Setp-2 .
            // -------------------------------------------------------------------------------------

            des.Mode = CipherMode.ECB;

            MemoryStream stream = new MemoryStream();
            OriginalPicBox.Image.Save(stream,ImageFormat.Bmp);

            //byte[] key = generate8ByteKey();
            myKey = BitConverter.ToInt64(key, 0); // Int64 = Long.
            this.keyLabel.Text = "Key: " + myKey;
            ICryptoTransform cryptor = des.CreateEncryptor(this.key, null);

            byte[] imageHeader = stream.ToArray().Take(54).ToArray(); // save the header of the image.
            byte[] imageDate = stream.ToArray().Skip(54).ToArray(); // Skip the first 54 byte (Header), then return the remaining.
            byte[] encryptedDate = cryptor.TransformFinalBlock(imageDate, 0, imageDate.Length); // Encrypt the data.
            byte[] encryptedImage = Combine(imageHeader, encryptedDate);
            stream = new MemoryStream(encryptedImage);
            EncryptedPicBox.Image = Image.FromStream(stream);
        }

        public byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public static byte[] generate16ByteKey()
        {
            Random rand = new Random();
            ulong least = (ulong)rand.Next(); // 8 bytes
            ulong most = (ulong)rand.Next(); // 8 bytes

            byte[] subKey1 = BitConverter.GetBytes(least);
            byte[] subKey2 = BitConverter.GetBytes(most);

            byte[] myKey = new byte[16];
            for (int i = 0; i < subKey2.Length; i++)
            {
                myKey[i] = subKey2[i];
            }
            int j = 0;
            for (int i = subKey2.Length; i < myKey.Length; i++)
            {
                myKey[i] = subKey1[j];
                j++;
            }

            return myKey;
        }

        public static byte[] generate8ByteKey()
        {
            Random rand = new Random();
            ulong least = (ulong)rand.Next(); // 8 bytes


            byte[] Key = BitConverter.GetBytes(least);

            return Key;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ECBBtn_Click(object sender, EventArgs e)
        {
            encrypECPMode();
        }

        private void ChageKeyBtn_Click(object sender, EventArgs e)
        {
            key = generate8ByteKey();
            myKey = BitConverter.ToInt64(key, 0); // Int64 = Long.
            this.keyLabel.Text = "Key: " + myKey;
        }

    }
}
