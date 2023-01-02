using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ResumeBuilder
{
    public partial class SettingsForm : Form
    {
        AppControllers appControllers = new AppControllers();

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void exportJsonDataButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.CreatePrompt = true;
            save.InitialDirectory = @"D:\";
            save.Title = "Save Json File";
            save.DefaultExt = "json";
            save.Filter = "json files (*.json)|*.json|All Files(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(save.FileName);
                sw.WriteLine(appControllers.exportJsonData().ToString().Trim());
                sw.Close();
                MessageBox.Show("Saved!\nYou can import this file when you need edit.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Clearing all data.", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                appControllers.insertDataSql("delete from Person; delete from Job; delete from Education; delete from MoreDetails");
            }
        }
    }
}
