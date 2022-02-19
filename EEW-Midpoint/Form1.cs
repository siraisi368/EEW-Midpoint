using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace EEW_Midpoint
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = "[EEW-Midpoint v1.0]起動しました";
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
                
        System.Net.WebClient downloadClient = new WebClient();
        private async void timer1_Tick(object sender, EventArgs e)
        {    
            try 
            {
                DateTime dt = DateTime.Now;
                DateTime dt2 = dt.AddSeconds(-2);
                var time = dt2.ToString("yyyyMMddhhmmss");

                string fileName = @"web/kyomoni.json"; //webのなかみへkyomoni.jsonとしていれる
                Uri u = new Uri($"http://www.kmoni.bosai.go.jp/webservice/hypo/eew/{time}.json"); //天下のNIEDの

                downloadClient.DownloadFile(u, fileName); //uriのファイルをfilenameに保存
                label5.Text = "正常";
                label5.ForeColor = Color.LimeGreen; //みどり
            }
            catch(Exception ex) //死んだとき用
            {
                label5.Text = "接続失敗";
                label5.ForeColor = Color.Crimson; //あか
                textBox1.Text = $"{textBox1.Text}\r\n[EEW-Midpoint v1.0]"+ex.Message;
            }

            try
            {
                string fileName2 = @"web/iedred.json"; //webのなかみへiedred.jsonとしていれる

                Uri u2 = new Uri("https://api.iedred7584.com/eew/json/"); //iedred先輩の
                downloadClient.DownloadFile(u2, fileName2); //uri2のファイルをfilename2に保存
                
                label6.Text = "正常";
                label6.ForeColor = Color.LimeGreen; //みどり
            }
            catch (Exception ex) //死んだとき用 二匹目
            {
                label6.Text = "接続失敗";
                label6.ForeColor = Color.Crimson; //あか
                textBox1.Text = $"{textBox1.Text}\r\n[EEW-Midpoint v1.0]" + ex.Message;
            }
        }
    }
}