using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Crawler_Base
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string _conn = "Database='{0}';Data Source='{1}';User Id='{2}';Password='{3}';charset='utf8';pooling=true";
        private string _tableName = "";

        private void btnGo_Click(object sender, EventArgs e)
        {
            _conn = string.Format(_conn, tbDb.Text.Trim(), tbSrc.Text.Trim(), tbUser.Text.Trim(), tbPsw.Text.Trim());
            _tableName = tbTable.Text.Trim();

            CheckDatabase();
            GetLastRecord();

            ThreadPool.QueueUserWorkItem(delegate { GetAllData(); });
        }

        private void CheckDatabase()
        {
            ShowInfo("检查数据库是否存在");
            string createTable = @"CREATE TABLE IF NOT EXISTS `{0}` (
                                `id` int(11) NOT NULL AUTO_INCREMENT,
                                `capture_time` datetime NOT NULL,
                                 PRIMARY KEY (`id`),
                                 KEY `capture_time` (`capture_time`),
                                 KEY `id` (`id`)
                                   ) DEFAULT CHARSET=utf8;";
            MySqlHelper.ExecuteNonQuery(_conn, string.Format(createTable, _tableName));
        }

        private void GetAllData()
        {

        }

        private void LogException(Exception ex)
        {
            ShowInfo(ex.ToString());
            string filename = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Error.txt";
            var sw = File.AppendText(filename);
            sw.Write(ex);
            sw.Close();
        }

        private void GetLastRecord()
        {
            rtbInfo.AppendText("读取上次运行记录\r\n");

            string sql = string.Format("SELECT * FROM `{0}` order by `id`desc limit 1 ", _tableName);

            var row = MySqlHelper.ExecuteDataRow(_conn, sql);

            if (row != null)
            {

            }
        }

        void ShowInfo(params object[] list)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Length; i++)
            {
                sb.Append(list[i]);
            }
            ShowInfo(sb.ToString());
        }

        private void ShowInfo(string s)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => rtbInfo.AppendText(s + "\r\n")));
            else
            {
                rtbInfo.AppendText(s + "\r\n");
            }
        }

    }

}
