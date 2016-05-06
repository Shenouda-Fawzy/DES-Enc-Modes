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
        long myKey, iv; // changed by generate8ByteKey(), generateIV().
        byte[] key,myIv;

        public Form1()
        {
            InitializeComponent();
            des = new DESCryptoServiceProvider();
            //this.keyLabel.Text = "";
            this.ivLable.Text = "";
            this.key = generate8ByteKey();
            this.myIv = generateIV();

            myKey = BitConverter.ToInt64(key, 0); // Int64 = Long.
            this.keyLabel.Text = "Key: " + myKey;
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


        private void checkButton(object sender, EventArgs arg) 
        {

            // 1. Convert the Bitmap Image to stream of byte im Memory to encrypt it.
            // 2. Set the block encryptoin mode.
            // 3. Split to [Header] and [Data].
            // 4. Create a encryptor to encrypt [Data] using a 8-byte KEY .
            // 5. Combine the [Header] with the encrypted [Data] .
            // 6. Extract the Image back from the stream you created in Setp-2 .
            // -------------------------------------------------------------------------------------

            Button btn = (Button)sender; //Check which button is clicked.
            MemoryStream stream = new MemoryStream();
            OriginalPicBox.Image.Save(stream, ImageFormat.Bmp);
            //DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            switch (btn.Name) 
            {
                case "ECBBtn":
                    des.Mode = CipherMode.ECB;
                    break;
                case "CBCBtn":
                    des.Mode = CipherMode.CBC;
                    break;
                case "CFBBtn":
                    des.Mode = CipherMode.CFB;
                    break;
                default:
                    break;
            }

            myKey = BitConverter.ToInt64(key, 0); // Int64 = Long.
            this.keyLabel.Text = "Key: " + myKey;
            

            iv = BitConverter.ToInt64(des.IV, 0);
            this.ivLable.Text = "IV: " + iv;
            //des.IV = myIv;
            ICryptoTransform cryptor = des.CreateEncryptor(this.key, myIv); // 8-byte key.
            byte[] encryptedImage = encryptImage(cryptor);
            stream = new MemoryStream(encryptedImage); // retrive the image from the stream.
            EncryptedPicBox.Image = Image.FromStream(stream); // Display the imag to picbox.
            stream.Close(); // Releas any resources.

        }


        byte[] encryptImage(ICryptoTransform crypto) 
        {
            MemoryStream stream = new MemoryStream();
            OriginalPicBox.Image.Save(stream, ImageFormat.Bmp);
            byte[] imageHeader = stream.ToArray().Take(54).ToArray(); // save the header of the image.
            byte[] imageDate = stream.ToArray().Skip(54).ToArray(); // Skip the first 54 byte (Header), then return the remaining.
            byte[] encryptedDate = crypto.TransformFinalBlock(imageDate, 0, imageDate.Length); // Encrypt the data.
            byte[] encryptedImage = Combine(imageHeader, encryptedDate);
            return encryptedImage;
        }
        private void ChageKeyBtn_Click(object sender, EventArgs e)
        {
            key = generate8ByteKey();
            myKey = BitConverter.ToInt64(key, 0); // Int64 = Long.
            this.keyLabel.Text = "Key: " + myKey;
        }

        private byte [] generateIV() 
        {
            Random rand = new Random();
            ulong least = (ulong)rand.Next(); // 8 bytes

            byte[] myIV = BitConverter.GetBytes(least);
            myIv = myIV;
            return myIV;
        }

        private void CTRMode() 
        {
            // This mode is for every block we use the same key with increametal counter.
            // 1. Get the stream of byte
            // 2. Devied the bytes of 8-byte block each.
            // 3. Encrypt the counter with the KEY .
            // 4. XOR the enctypted counter with the image block.
            // 5. Combine the encrypted block.
// -----------------------------------------------------------------------------------
            ICryptoTransform cryptor = des.CreateEncryptor(this.key, null);// Set key for the encryption.
            
// Step 1:
            MemoryStream stream = new MemoryStream();
            OriginalPicBox.Image.Save(stream, ImageFormat.Bmp);
            byte[] imageHeader = stream.ToArray().Take(54).ToArray();
            byte[] imageData = stream.ToArray().Skip(54).ToArray(); // Skip 54 byte then return the remaining.

            byte[] dataBlock = new byte[8]; // 64-bit block
            byte[] encryptedBlock = new byte[8]; // after encrypting the data.

            int padding = 0;
            if(dataBlock.Length % 8 != 0)
                padding = 8 - (dataBlock.Length % 8);
            List<byte> encryptedImg = new List<byte>(imageData.Length + padding);

            int j = 0;
            byte[] buffer = new byte[8];
            long counter = 0;
            byte[] cntr = BitConverter.GetBytes(counter);
// Step 2,3:
            for (int i = 0; i < imageData.Length; i++) 
            {
                dataBlock[j] = imageData[i];
                if (i % 7 == 0 && i != 0) 
                {
                    des.IV = cntr;
                    counter++;
                    cntr = BitConverter.GetBytes(counter);
                    byte[] encryptedCounter = cryptor.TransformFinalBlock(cntr, 0, cntr.Length);
// Step 4:
                    long encBlock = BitConverter.ToInt64(encryptedCounter, 0) ^ BitConverter.ToInt64(dataBlock, 0);
                    encryptedBlock = BitConverter.GetBytes(encBlock);
// Step 5:
                    encryptedImg.AddRange(encryptedBlock); // Put encrypted image.
                    j = 0;
                }
                j++;
            } // end of loop
            byte[] image = Combine(imageHeader, encryptedImg.ToArray());
            stream = new MemoryStream(image);
            EncryptedPicBox.Image = Image.FromStream(stream);
            stream.Close(); // Releas any resources.

        } // end of CTRMode Method.

        private void CTRBtn_Click(object sender, EventArgs e)
        {
            CTRMode();
        }

        private void ChangeIVBtn_Click(object sender, EventArgs e)
        {
            myIv = generateIV();
            iv = BitConverter.ToInt64(myIv, 0);
            this.ivLable.Text = "IV: " + iv;
        }

    } // end of class.
}
