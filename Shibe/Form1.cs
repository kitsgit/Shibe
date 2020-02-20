using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using unirest_rt.http;
namespace Shibe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /* private void button1_Click(object sender, EventArgs e)
         {

             var request = WebRequest.Create("https://cdn.shibe.online/shibes/c66201475fd466efb7ab21015f32504cf7febe93.jpg");

             using (var response = request.GetResponse())
             using (var stream = response.GetResponseStream())
             {
                 pictureBox1.Image = Bitmap.FromStream(stream);
                 pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
             }
         }*/

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest wr = WebRequest.Create("http://shibe.online/api/shibes?count=1");//+ string.Join("+", this.textBox1.Text.Split(' ')));
            WebResponse res = wr.GetResponse();
            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                dynamic images = JsonConvert.DeserializeObject(json);
                string s = images.ToString();
                
                s = s.Replace(" ", String.Empty);
                s = s.Replace("[", String.Empty);
                s = s.Replace("]", String.Empty);
                s = s.Replace("\"", String.Empty);
              //  s = s.Replace(" ", String.Empty);
               // richTextBox1.Text = s;
                this.pictureBox1.Load(s);//(images["0"].imglink.Value);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                // pictureBox1.ImageLocation = imgLink;
                // pictureBox1.Image = Bitmap.FromStream(stream);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
