using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using SpawnCreator.Properties;
using System.Threading;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace SpawnCreator
{
    public partial class ControlPanel : Form
    {
        //private string CompilePath = String.Empty;
        private Process authProc;
        //private bool compileFinishSuccess;
        //private bool isDevenv;

        //private int restartAttempts;
        //private bool stopButtonPressed;
        private Process worldProc;
        private Process mysqlProc;

        //bool authExists = false;
        //bool worldExists = false;
        //int authPid = 0;
        //int worldPid = 0;
        Form_MainMenu mm = new Form_MainMenu();

        public ControlPanel()
        {
            InitializeComponent();
        }

        private readonly Form_MainMenu form_MM;
        public ControlPanel(Form_MainMenu form_MainMenu)
        {
            InitializeComponent();
            form_MM = form_MainMenu;
        }

        //[global::System.Configuration.UserScopedSetting()]
        //[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        //[global::System.Configuration.DefaultSettingValue("")]
        //public string trinityFolder
        //{
        //    get
        //    {
        //        return ((string)(this["trinityFolder"]));
        //    }
        //    set
        //    {
        //        this["trinityFolder"] = value;
        //    }
        //}

        //private void BeginStartServer()
        //{
        //    bool authExists = false;
        //    bool worldExists = false;
        //    int authPid = 0;
        //    int worldPid = 0;

        //    foreach (Process p in Process.GetProcesses())
        //    {
        //        if (p.ProcessName == "authserver")
        //        {
        //            authExists = true;
        //            authPid = p.Id;
        //        }

        //        if (p.ProcessName == "worldserver")
        //        {
        //            worldExists = true;
        //            worldPid = p.Id;
        //        }
        //    }

        //    if (!authExists && !worldExists)
        //    {
        //        if (!File.Exists(Path.Combine(Settings.Default.trinityFolder, "authserver.exe")))
        //        {
        //            TaskDialog.Show(new TaskDialogInfo("Error", eTaskDialogIcon.Stop, "Not Found",
        //            "Could not find authserver.exe.", eTaskDialogButton.Ok));

        //            return;
        //        }

        //        if (!File.Exists(Path.Combine(Settings.Default.trinityFolder, "worldserver.exe")))
        //        {
        //            TaskDialog.Show(new TaskDialogInfo("Error", eTaskDialogIcon.Stop, "Not Found",
        //            "Could not find worldserver.exe.", eTaskDialogButton.Ok));

        //            return;
        //        }

        //        StartServerThread();
        //    }
        //    else
        //        if (authExists && worldExists)
        //    {
        //        eTaskDialogButton button = eTaskDialogButton.Yes;

        //        button |= eTaskDialogButton.No;

        //        eTaskDialogResult result =
        //        TaskDialog.Show(new TaskDialogInfo("Already Running", eTaskDialogIcon.Information,
        //        "Authserver and Worldserver are currently running", "Stop it?",
        //        button));

        //        if (result == eTaskDialogResult.Yes)
        //        {
        //            Process authServerProc = Process.GetProcessById(authPid);
        //            Process worldServerProc = Process.GetProcessById(worldPid);

        //            authServerProc.Kill();
        //            worldServerProc.Kill();

        //            authServerProc.Dispose();
        //            worldServerProc.Dispose();
        //        }
        //    }
        //    else
        //            if (authExists)
        //    {
        //        eTaskDialogButton button = eTaskDialogButton.Yes;

        //        button |= eTaskDialogButton.No;

        //        eTaskDialogResult result =
        //        TaskDialog.Show(new TaskDialogInfo("Already Running", eTaskDialogIcon.Information,
        //        "Authserver is currently running", "Stop it?", button));

        //        if (result == eTaskDialogResult.Yes)
        //        {
        //            using (Process authServerProc = Process.GetProcessById(authPid))
        //            {
        //                authServerProc.Kill();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        eTaskDialogButton button = eTaskDialogButton.Yes;

        //        button |= eTaskDialogButton.No;

        //        eTaskDialogResult result = TaskDialog.Show(new TaskDialogInfo("Already Running", eTaskDialogIcon.Information, "Worldserver is currently running", "Stop it?", button));

        //        if (result == eTaskDialogResult.Yes)
        //        {
        //            using (Process worldServerProc = Process.GetProcessById(worldPid))
        //            {
        //                worldServerProc.Kill();
        //            }
        //        }
        //    }
        //}

        private void StartServerThread()
        {
            var serverThread = new Thread(StartServer) { IsBackground = true };

            serverThread.Start();
        }

        private void StartServer()
        {
            string authServerFName = Path.Combine(textBox_auth_and_world_path.Text, "authserver.exe");

            //Invoke((MethodInvoker)delegate
            //{
            //    startServerButtonItem.Enabled = false;
            //    stopServerButtonItem.Enabled = true;
            //});

            if (File.Exists(authServerFName))
            {
                ////////////////////////////////////////////Auth Server///////////////////////////////////////////


                try
                {
                    var psi = new ProcessStartInfo(authServerFName);

                    psi.WorkingDirectory = textBox_auth_and_world_path.Text;

                    psi.UseShellExecute = false;

                    if (checkBox1.Checked)
                    {
                        psi.CreateNoWindow = true;
                        psi.WindowStyle = ProcessWindowStyle.Hidden;
                    }
                    else
                    {
                        psi.CreateNoWindow = false;
                        psi.WindowStyle = ProcessWindowStyle.Normal;
                    }


                    authProc = new Process();
                    authProc.StartInfo = psi;

                    authProc.Start();

                    dot_authserver.ForeColor = Color.LawnGreen;
                    //textBox4.Text = "Initializing Authserver... \n" + Environment.NewLine +
                    //                "Authserver is running. \n";
                 

                    //Invoke((MethodInvoker)delegate
                    //{
                    //    authServerLabelItem.Image = Resources.checkmark_16;
                    //});

                    authProc.EnableRaisingEvents = true;

                    //authProc.Exited += authServerProc_Exited;
                }
                catch (Exception ex)
                {
                    //TaskDialog.Show(new TaskDialogInfo("Error", eTaskDialogIcon.Stop, "An error has occured", ex.Message,
                    //eTaskDialogButton.Ok));
                    MessageBox.Show(Convert.ToString(ex));
                    //textBox4.Text = "Initializing Authserver... \n" + Environment.NewLine +
                    //                "ERROR: Authserver cannot be started. \n";
                }
            }
            else
            {
                MessageBox.Show("Cannot find authserver.exe in current directory.", "Error!", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                return;
            }


            ////////////////////////////////////////////World Server///////////////////////////////////////////

            // E:\TrinityCore335\build\bin\Release
            string worldServerFName = Path.Combine(textBox_auth_and_world_path.Text, "worldserver.exe");


            if (File.Exists(worldServerFName))
            {
                try
                {
                    var psi = new ProcessStartInfo(worldServerFName);

                    psi.WorkingDirectory = textBox_auth_and_world_path.Text;

                    //psi.RedirectStandardOutput = true;
                    //psi.RedirectStandardInput = true;

                    psi.UseShellExecute = false;

                    psi.CreateNoWindow = false;
                    //psi.CreateNoWindow = true;
                    //psi.WindowStyle = ProcessWindowStyle.Hidden;

                    worldProc = new Process();
                    worldProc.StartInfo = psi;

                    worldProc.Start();
                    dot_worldserver.ForeColor = Color.LawnGreen;

                    //string sent = textBox4.Text;

                    //textBox4.AppendText(sent);
                    //textBox4.AppendText(Environment.NewLine);

                    //Invoke((MethodInvoker)delegate
                    //{
                    //    worldServerLabelItem.Image = Resources.checkmark_16;

                    //    EnableDisableFeatures(true);

                    //    if (restartAttempts != 0)
                    //        WriteConsoleOutput(String.Format("Restart Attempt: {0}",
                    //        restartAttempts));
                    //});

                    worldProc.EnableRaisingEvents = true;

                   // worldProc.Exited += worldServerProc_Exited;


                    //worldProc.BeginOutputReadLine();
                    //worldProc.OutputDataReceived += worldProc_OutputDataReceived;

                    //worldProc.WaitForExit();
                    //worldProc.Close();
                    //worldProc.Dispose();
                }
                catch (Exception ex)
                {
                    //TaskDialog.Show(new TaskDialogInfo("Error", eTaskDialogIcon.Stop, "An error has occured", ex.Message,
                    //eTaskDialogButton.Ok));
                    MessageBox.Show(Convert.ToString(ex));
                }
            }
            else
            {
                MessageBox.Show("Cannot find worldserver.exe in current directory.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async void WaitOneSec()
        {
            await Task.Delay(1000);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //ProcessStartInfo psi = new ProcessStartInfo("cmd");
            //psi.UseShellExecute = false;
            //psi.RedirectStandardOutput = true;
            //psi.CreateNoWindow = true;
            //psi.RedirectStandardInput = true;

            //var proc = Process.Start(psi);

            //// cd /d E:\TrinityCore335\build\bin\Release & authserver.exe
            //proc.StandardInput.WriteLine(@"cd E:\TrinityCore335\build\bin\Release & authserver.exe");
            //proc.StandardInput.WriteLine("exit");
            //string str = proc.StandardOutput.ReadToEnd();

            //textBox4.Text = str;


            //=========================================================================
            //string file_name = textBox_auth_and_world_path.Text + "\\Logs\\Server.log";
            //string textLine = "";

            //StreamReader objReader;
            //objReader = new StreamReader(file_name);

            //do
            //{
            //    textLine = textLine + objReader.ReadLine() + "\r\n";
                
            //} while (objReader.Peek() != -1);

            //textBox1.Text = textLine;

            //objReader.Close();
            //=========================================================================
            //timer2.Start();

            StartServer();
        }

        private void worldProc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                WriteConsoleOutput(e.Data);
            });
        }

        private void WriteConsoleOutput(string output)
        {
            //textBox4.AppendText(output + Environment.NewLine);
            //textBox4.SelectionStart = textBox4.Text.Length;
            //textBox4.ScrollToCaret();
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            timer1.Start(); // Check if authserver, worldserver and mysql are running

            textBox_mysql_path.Text = Settings.Default.MySQL_Path;
            textBox_auth_and_world_path.Text = Settings.Default.AuthAndWorldPath;
        }

        private void ControlPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
             Settings.Default.MySQL_Path = textBox_mysql_path.Text;
             Settings.Default.AuthAndWorldPath = textBox_auth_and_world_path.Text;
             Settings.Default.Save();
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();

            //Hide();
            //mm.Show();
        }

        private void textBox_auth_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_auth_and_world_path.Text = fbd.SelectedPath;
            }
        }

        private void textBox_mysql_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_mysql_path.Text = fbd.SelectedPath;
            }

            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "MySQL.bat|*.bat";

            //if
            // (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    textBox_mysql_path.Text = dialog.FileName;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var authserver in Process.GetProcessesByName("authserver"))
            {
                authserver.Kill();
                dot_authserver.ForeColor = Color.Gray;
                //textBox4.Text = "Closing Authserver... \n" + Environment.NewLine +
                //                "Authserver is closed. \n";
            }
            //===================================================================
            foreach (var worldserver in Process.GetProcessesByName("worldserver"))
            {
                worldserver.Kill();
                dot_worldserver.ForeColor = Color.Gray;
                //textBox4.Text = "Closing Worldserver... \n" + Environment.NewLine +
                //                "Worldserver is closed. \n";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] authserver = Process.GetProcessesByName("authserver");
            if (authserver.Length == 0)
            {
                dot_authserver.ForeColor = Color.Gray;
                toolTip1.SetToolTip(dot_authserver, "Authserver is Closed");
                //textBox4.Text = "Authserver is closed. \n";
            }
                
            else
            {
                dot_authserver.ForeColor = Color.LawnGreen;
                toolTip1.SetToolTip(dot_authserver, "Authserver is Running");
                //textBox4.Text = "Authserver is running. \n";
            }
                

            //===========================================================

            Process[] worldserver = Process.GetProcessesByName("worldserver");
            if (worldserver.Length == 0)
            {
                dot_worldserver.ForeColor = Color.Gray;
                toolTip1.SetToolTip(dot_worldserver, "Worldserver is Closed");
                //textBox4.Text = "Worldserver is closed. \n";
            }
            else
            {
                dot_worldserver.ForeColor = Color.LawnGreen;
                toolTip1.SetToolTip(dot_worldserver, "Worldserver is Running");
                
                //textBox4.Text = "Worldserver is running. \n";
            }
                

            //===========================================================

            Process[] mysql = Process.GetProcessesByName("mysqld");
            if (mysql.Length == 0)
            {
                dot_mysql.ForeColor = Color.Gray;
                toolTip1.SetToolTip(dot_mysql, "MySQL is Closed");
            }
                
            else
            {
                dot_mysql.ForeColor = Color.LawnGreen;
                toolTip1.SetToolTip(dot_mysql, "MySQL is Running");
            }
                
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Form size = 880, 433

            if (TB_BTN.Text == "0")
            {
                panel1.Location = new Point(854, 0);
                TB_BTN.Text = "1";
            }
            else if (TB_BTN.Text == "1")
            {
                panel1.Location = new Point(711, 0);
                TB_BTN.Text = "0";
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.SteelBlue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.SkyBlue;
        }

        private void label_worldserver_Click(object sender, EventArgs e)
        {
            
        }

        private void label_worldserver_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void label_worldserver_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*   Start MySQL   */

            //string mysqlFileName = textBox_mysql_path.Text;
            string mysqlFileName = Path.Combine(textBox_mysql_path.Text, "MySQL.bat");

            if (File.Exists(mysqlFileName))
            {
                try
                {
                    var psi = new ProcessStartInfo(mysqlFileName);

                    psi.WorkingDirectory = textBox_mysql_path.Text;

                    psi.UseShellExecute = false;

                    if (checkBox2.Checked)
                    {
                        // Hide MySQL Console
                        psi.CreateNoWindow = true;
                        psi.WindowStyle = ProcessWindowStyle.Hidden;
                    }
                    else
                    {
                        // Show MySQL Console
                        psi.CreateNoWindow = false;
                        psi.WindowStyle = ProcessWindowStyle.Normal;
                    }

                    mysqlProc = new Process();
                    mysqlProc.StartInfo = psi;

                    mysqlProc.Start();
                    dot_mysql.ForeColor = Color.LawnGreen;

                    mysqlProc.EnableRaisingEvents = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
            }
            else
            {
                return;
            }

            //=========================================================

            //string xamppMySQLFileName = Path.Combine(textBox_mysql_path.Text, "mysql_start.bat");
            //if (File.Exists(xamppMySQLFileName))
            //{
            //    try
            //    {
            //        var psi2 = new ProcessStartInfo(xamppMySQLFileName);

            //        psi2.WorkingDirectory = textBox_mysql_path.Text;

            //        psi2.UseShellExecute = false;

            //        if (checkBox2.Checked)
            //        {
            //            // Hide MySQL Console
            //            psi2.CreateNoWindow = true;
            //            psi2.WindowStyle = ProcessWindowStyle.Hidden;
            //        }
            //        else
            //        {
            //            // Show MySQL Console
            //            psi2.CreateNoWindow = false;
            //            psi2.WindowStyle = ProcessWindowStyle.Normal;
            //        }

            //        mysqlProc = new Process();
            //        mysqlProc.StartInfo = psi2;

            //        mysqlProc.Start();
            //        dot_mysql.ForeColor = Color.LawnGreen;

            //        mysqlProc.EnableRaisingEvents = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(Convert.ToString(ex));
            //    }
            //}
            //else
            //{
            //    return;
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*  Close MySQL  */

            foreach (var mysqld in Process.GetProcessesByName("mysqld"))
            {
                mysqld.Kill();
                dot_mysql.ForeColor = Color.Gray;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();

            mm.Show();
        }

        private void textBox_mysql_path_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //string file_name = textBox_auth_and_world_path.Text + "\\Logs\\Server.log";
            //string textLine = "";

            //StreamReader objReader;
            //objReader = new StreamReader(file_name);

            //do
            //{
            //    textLine = textLine + objReader.ReadLine() + "\r\n";
            //} while (objReader.Peek() != -1);

            //textBox1.Text = textLine;

            //objReader.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /* Restart Worldserver */

            // First step - Close WorldServer
            foreach (var worldserver in Process.GetProcessesByName("worldserver"))
            {
                worldserver.Kill();
                dot_worldserver.ForeColor = Color.Gray;
            }

            // Second step - Start WorldServer
            string worldServerFName = Path.Combine(textBox_auth_and_world_path.Text, "worldserver.exe");

            if (File.Exists(worldServerFName))
            {
                try
                {
                    var psi = new ProcessStartInfo(worldServerFName);

                    psi.WorkingDirectory = textBox_auth_and_world_path.Text;

                    psi.UseShellExecute = false;

                    //Show worldserver console
                    psi.CreateNoWindow = false;

                    worldProc = new Process();
                    worldProc.StartInfo = psi;

                    worldProc.Start();
                    dot_worldserver.ForeColor = Color.LawnGreen;

                    worldProc.EnableRaisingEvents = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
            }
            else
            {
                return;
            }
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            label_worldserver.BackColor = Color.Red;
            label_worldserver.ForeColor = Color.White;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            label_worldserver.BackColor = Color.Gainsboro;
            label_worldserver.ForeColor = Color.Black;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }
    }
}
