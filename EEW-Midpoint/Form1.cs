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
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Interfaces.Server;
using Grapevine.Shared;

namespace EEW_Midpoint
{
    public partial class Form1 : Form
    {

        private RestServer server;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            //数字と空白しか入力できないようにする
            this.maskedTextBox1.Mask = "9999";
            //Int32型に変換できるか検証する
            this.maskedTextBox1.ValidatingType = typeof(int);
            //TypeValidationCompletedイベントハンドラを追加する
            this.maskedTextBox1.TypeValidationCompleted +=
                maskedTextBox1_TypeValidationCompleted;

            textBox1.Text = "[EEW-Midpoint v1.0]起動しました";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServerSettings settings = new ServerSettings()
            {
                Port = maskedTextBox1.Text,
                PublicFolder = new PublicFolder("web"),

            };
            server = new RestServer(settings);
            server.Start();
            sv_stat.Text = "起動中";
            sv_stat.ForeColor = Color.LimeGreen;
            textBox1.Text = $"{textBox1.Text}\r\n[EEW-Midpoint v1.0]簡易Webサーバを起動しました。[ポート番号:{maskedTextBox1.Text}]";
            button1.Enabled = false;
            button2.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            server.Stop();
            sv_stat.Text = "停止中";
            sv_stat.ForeColor = Color.Crimson;
            textBox1.Text = $"{textBox1.Text}\r\n[EEW-Midpoint v1.0]簡易Webサーバを停止しました。";
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            //Int32型に変換できるか確かめる
            if (!e.IsValidInput)
            {
                //Int32型への変換に失敗した時は、フォーカスが移動しないようにする
                MessageBox.Show("数値を入力してください");
                e.Cancel = true;
            }
        }

        System.Net.WebClient downloadClient = null;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try 
            { 
                DateTime dt = DateTime.Now;
                DateTime dt2 = dt.AddSeconds(-2);
                var time = dt2.ToString("yyyyMMddhhmmss");

                string fileName = @"web/kyomoni.json";
                Uri u = new Uri($"http://www.kmoni.bosai.go.jp/webservice/hypo/eew/{time}.json");

                downloadClient = new WebClient();
                downloadClient.DownloadFile(u, fileName);
                label5.Text = "正常";
                label5.ForeColor = Color.LimeGreen;
            }
            catch
            {
                label5.Text = "接続失敗";
                label5.ForeColor = Color.Crimson;
            }
        }
    }
}