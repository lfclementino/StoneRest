using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoneRest.Util;

namespace StoneRest.Monitor
{
    public partial class MonitorApp : Form
    {
        private string DB_Name = "DBCities.db";

        public MonitorApp()
        {
            InitializeComponent();
        }

        private void cbOnOff_CheckedChanged(object sender, EventArgs e)
        {
            tUpdateCities.Enabled = ((CheckBox)sender).Checked;

            if (((CheckBox)sender).Checked)
            {
                tUpdateCities.Interval = (3600000 - (DateTime.Now.Minute * 60000) - (DateTime.Now.Second * 1000) - DateTime.Now.Millisecond);

                ((CheckBox)sender).Text = "On";
                ((CheckBox)sender).BackColor = Color.LightGreen;

                txtNext.Text = DateTime.Now.AddMilliseconds(tUpdateCities.Interval).ToString("yyyy-MM-dd HH:mm:ss");

                AddLog("Timer On");
            }
            else
            {
                ((CheckBox)sender).Text = "Off";
                ((CheckBox)sender).BackColor = Color.Red;

                AddLog("Timer Off");
            }
        }

        private void MonitorApp_Load(object sender, EventArgs e)
        {
            if (CheckDataBasePath(DB.dbConn(DB_Name)))
            {
                AddLog(DB.dbConn(DB_Name));
            }
            else
            {
                MessageBox.Show("Banco de dados não encontrado. Esse aplicado deve ser executado da pasta da API Web.", "StoneRest.Monitor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void AddLog(string text)
        {
            txtLog.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + text + Environment.NewLine);
        }

        private bool CheckDataBasePath(string db_path)
        {
            try
            {
                return System.IO.File.Exists(db_path);
            }
            catch
            {
                return false;
            }
        }

        private void UpdateTemperatures()
        {
            AddLog("Atualizando a temperatura das cidades.");
            if (DB.UpdateTemperatures(DB_Name))
            {
                AddLog("Atualização completa.");
            }
            else
            {
                AddLog("Erro!.");
            }
        }

        private void tUpdateCities_Tick(object sender, EventArgs e)
        {
            txtLast.Text = txtNext.Text;
            UpdateTemperatures();
            ((Timer)sender).Interval = (3600000 - (DateTime.Now.Minute * 60000) - (DateTime.Now.Second * 1000) - DateTime.Now.Millisecond);
            txtNext.Text = DateTime.Now.AddMilliseconds(tUpdateCities.Interval).ToString("yyyy-MM-dd HH:mm:ss");
        }

    }
}
