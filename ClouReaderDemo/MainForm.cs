using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClouReaderAPI.ClouInterface;
using ClouReaderAPI;
using System.Threading;
using ClouReaderAPI.Models;

namespace ClouReaderDemo
{
    public delegate void WriteDebug(string msg);
    public partial class MainForm : BaseForm, IAsynchronousMessage
    {
        private const int MAX_DEBUG_MESSAGE = 1000;     // 调试消息大于1000条时，自动清空
        private int nowDebugMessageCount = 0;
        private bool IsFlush = true;

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        #region 菜单栏事件
        // 打开串口连接
        private void tsmi_SerialConn_Click(object sender, EventArgs e)
        {
            // CLReader.CreateSerialConn("COM2:115200:n:8:1", this);
            // StartFlush();
        }
        // 打开TCP连接
        private void tsmi_TCPClient_Click(object sender, EventArgs e)
        {
            // CLReader.CreateTcpConn("10.8.170.120:7206", this);
            // StartFlush();
        }

        private void tsmi_RFIDParam_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region 根节点右建菜单事件

        // 右键菜单打开事件
        private void contextMSforTree_Opening(object sender, CancelEventArgs e)
        {
            TreeNode tn = tv_ConnectList.SelectedNode;
            if (tn.Name.Equals("SerialRoot"))
            {
                contextItem_addConn.Text = "添加串口连接";
            }
            else if (tn.Name.Equals("RootTcpClient"))
            {
                contextItem_addConn.Text = "添加TCP客户端连接";
            }
            else if (tn.Name.Equals("RootTcpServer"))
            {
                contextItem_addConn.Text = "添加TCP服务器监听";
            }
            else 
            {
                contextItem_addConn.Text = "添加连接";
            }
        }
        // 添加连接事件
        private void contextItem_addConn_Click(object sender, EventArgs e)
        {
            DialogResult dr = DialogResult.No;
            TreeNode tn = tv_ConnectList.SelectedNode;
            // 
            if(tn.Name.Equals("SerialRoot"))
            {
                MyForm.Dialog.AddSerial dialog = new MyForm.Dialog.AddSerial(this);
                dr = dialog.ShowDialog(this);
            }
            else if(tn.Name.Equals("RootTcpClient"))
            {
                CLReader.CreateTcpConn("10.8.170.120:7206", this);
            }
            else if(tn.Name.Equals("RootTcpServer"))
            {
                
            }
            else
            {
                
            }
            if (dr == DialogResult.OK)
            {
                FlushTreeView();
            }
        }
        // 左击、右击都为选中状态
        private void tv_ConnectList_MouseClick(object sender, MouseEventArgs e)
        {
            TreeView tv = sender as TreeView;
            TreeNode select = tv.GetNodeAt(e.Location);
            if (select != null)
            {
                // 如果选择节点不是null，就设置为你的“选取结点
                tv.SelectedNode = select;
            }
        }

        #endregion

        #region 连接节点右键菜单事件

        // 根据连接配置读写器信息
        private void tsmi_cms_ReaderParam_Click(object sender, EventArgs e)
        {
            TreeNode tn = tv_ConnectList.SelectedNode;
            MyForm.RFID_Option rfid_Option_Form = new MyForm.RFID_Option(tn.Text.Trim(), this);
            rfid_Option_Form.Show();
        }
        // 关闭当前选中的连接
        private void tsmi_Connect_Close_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode tn = tv_ConnectList.SelectedNode;
                CLReader.DIC_CONNECT[tn.Text.Trim()].CloseConnect();
                CLReader.DIC_CONNECT.Remove(tn.Text.Trim());
                FlushTreeView();
            }
            catch { }
        }

        #endregion

        #region 实现接口方法
        /// <summary>
        /// 输出调试信息
        /// </summary>
        /// <param name="msg">调试信息</param>
        public void WriteDebugMsg(string msg)
        {
            if (tb_DebugMsg.InvokeRequired)
            {
                tb_DebugMsg.BeginInvoke(new WriteDebug(WriteDebugMsg), msg);
            }
            else
            {
                if (nowDebugMessageCount >= 1000)
                {
                    nowDebugMessageCount = 0;
                    tb_DebugMsg.Clear();
                }
                tb_DebugMsg.AppendText(msg + Environment.NewLine);
                nowDebugMessageCount++;
            }
        }

        public void WriteLog(string msg)
        {

        }

        public void PortConneting(String connID)
        {
            throw new NotImplementedException();
        }

        public void PortClosing(String connID)
        {
            throw new NotImplementedException();
        }

        public void OutPutTags(Tag_Model tag)
        {
            throw new NotImplementedException();
        }


        public void OutPutTagsOver()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刷新TreeView控件
        /// </summary>
        public void FlushTreeView() 
        {
            tv_ConnectList.Nodes["SerialRoot"].Nodes.Clear();
            tv_ConnectList.Nodes["RootTcpClient"].Nodes.Clear();
            foreach (var item in CLReader.DIC_CONNECT)
            {
                if (item.Value.ConnectType.Equals(1))
                {
                    TreeNode rn = new TreeNode();
                    rn.Text = item.Key; rn.Name = item.Key;
                    rn.Tag = "LeafNode";                                        // 用来响应事件的标识，很重要
                    rn.ContextMenuStrip = contextMSForConn;
                    tv_ConnectList.Nodes["SerialRoot"].Nodes.Add(rn);
                }
                else
                {
                    TreeNode rn = new TreeNode();
                    rn.Text = item.Key; rn.Name = item.Key;
                    rn.Tag = "LeafNode";                                        // 用来响应事件的标识
                    rn.ContextMenuStrip = contextMSForConn;
                    tv_ConnectList.Nodes["RootTcpClient"].Nodes.Add(rn);
                }
            }
        }
        public void GPIControlMsg(int gpiIndex, int gpiState, int startOrStop)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// 更新状态栏
        /// </summary>
        public void StartFlush() 
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
            {
                while (IsFlush)
                {
                    try
                    {
                        this.tssl_ReceiveCount.Text = CLReader.DIC_CONNECT["10.8.170.120:7206"].ProcessCount.ToString();
                        this.tssl_CacheSize.Text = CLReader.DIC_CONNECT["10.8.170.120:7206"].receiveBufferManager.DataCount.ToString(); ;
                        System.Threading.Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }));
        }
    }
}
