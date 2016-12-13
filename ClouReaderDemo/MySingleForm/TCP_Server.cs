using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm
{
    public partial class TCP_Server : BaseOption
    {
        /// <summary>
        /// 上下文窗体
        /// </summary>
        SingleMainForm contextForm = null;
        public TCP_Server()
        {
            InitializeComponent();
        }

        private void TCP_Server_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
        }
        public TCP_Server(string readerID, SingleMainForm contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
            Init();
        }

        public void Init()  // 如果当前已经启动监听，则显示当前的监听信息
        {
            try
            {
                
                if (cmb_ServerIP.Items.Count > 0) { cmb_ServerIP.SelectedIndex = 0; }
                if (ClouReaderAPI.CLReader.LISTENER != null && ClouReaderAPI.CLReader.LISTENER.isLisStartOrStop == true)
                {
                    cmb_ServerIP.Text = ClouReaderAPI.CLReader.LISTENER.listenIP.ToString();
                    tb_Port.Text = ClouReaderAPI.CLReader.LISTENER.listenProt.ToString();
                    tb_Port.Enabled = false;
                    cmb_ServerIP.Enabled = false;
                    btn_StartOrStopServer.Text = "Stop";
                    btn_StartOrStopServer.Tag = "1";
                }
                cmb_ServerIP.Items.AddRange(GetAllIP());
            }
            catch { }
        }

        private void btn_StartOrStopServer_Click(object sender, EventArgs e)
        {
            if (btn_StartOrStopServer.Tag.Equals("0"))                     // 启动服务器
            {
                try
                {
                    if (ClouReaderAPI.CLReader.OpenTcpServer(this.cmb_ServerIP.Text.Trim(), this.tb_Port.Text.Trim(), contextForm))
                    {
                        tb_Port.Enabled = false;
                        cmb_ServerIP.Enabled = false;
                        btn_StartOrStopServer.Text = "Stop";
                        btn_StartOrStopServer.Tag = "1";
                        contextForm.WriteDebugMsg("Server Start Success!");
                    }
                    else 
                    {
                        throw new Exception("IP Or Port Rrror!");
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage("Server Start Error：" + ex.Message);
                }
            }
            else 
            {
                ClouReaderAPI.CLReader.CloseTcpServer();
                tb_Port.Enabled = true;
                cmb_ServerIP.Enabled = true;
                btn_StartOrStopServer.Text = "Start";
                btn_StartOrStopServer.Tag = "0";
            }
        }

        public IPAddress[] GetAllIP()
        {
            List<IPAddress> ipList = new List<IPAddress>();
            IPAddress[] ips = GetLocalIP();
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    continue;
                ipList.Add(ip);
            }
            return ipList.ToArray();
        }

        public IPAddress[] GetLocalIP()
        {
            string name = Dns.GetHostName();
            IPHostEntry me = Dns.GetHostEntry(name);
            return me.AddressList;
        }
    }
}
