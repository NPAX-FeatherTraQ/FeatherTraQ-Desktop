using ClouReaderAPI.ClouInterface;
using ClouReaderAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm
{
    /// <summary>
    /// RFID_lx
    /// </summary>
    public delegate void AddDevice(Device_Mode model, DataGridViewRow dgvr);
    public partial class SearchDevice : BaseOption, ISearchDevice
    {
        SingleMainForm contextForm = null;
        private Int32 nowDebugMessageCount = 0;                             // 当前调试信息条数
        private List<Device_Mode> listDevice = new List<Device_Mode>();     // 设备调试列表
        Dictionary<String, DataGridViewRow> dic_Rows = new Dictionary<string, DataGridViewRow>(); // 在DataGridView中显示标签数据
        
        public SearchDevice()
        {
            InitializeComponent();
        }

        public SearchDevice(SingleMainForm contextMainForm)
            : this()
        {
            this.contextForm = contextMainForm;
        }

        #region 通用辅助方法

        public void WriteDebugMsg(string msg) 
        {
            try
            {
                if (tb_Msg.InvokeRequired)
                {
                    tb_Msg.BeginInvoke(new WriteDebug(WriteDebugMsg), msg);
                    return;
                }
                if (nowDebugMessageCount >= 10000)
                {
                    nowDebugMessageCount = 0;
                    tb_Msg.Clear();
                }
                tb_Msg.AppendText(msg + Environment.NewLine);
                nowDebugMessageCount++;
            }
            catch (Exception ex) { }
        }

        #endregion

        #region 接口实现方法

        public void DeviceInfo(Device_Mode model)
        {
            string sRowKey = model.MAC + "|" + model.IP;
            if (!dic_Rows.ContainsKey(sRowKey)) 
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.CreateCells(dgv_Devices, model.MAC, model.IP, model.ServerPort, model.RemoteIP, model.RemotePort, model.WorkingMode, model.ConnectMode, model.DeviceType);
                foreach (String item in dic_Rows.Keys)
                {
                    if (item.IndexOf(model.MAC) >= 0 || item.IndexOf(model.IP) >= 0)
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                dic_Rows.Add(sRowKey, dgvr);
                AddSingleTag(model, dgvr);
            }
        }

        public void DebugMsg(string msg)
        {
            WriteDebugMsg(msg);
        }

        #endregion

        #region DataGridView操作

        public void AddSingleTag(Device_Mode model, DataGridViewRow dgvr) 
        {
            if (this.dgv_Devices.InvokeRequired)
            {
                this.dgv_Devices.BeginInvoke(new AddDevice(AddSingleTag), model, dgvr);
            }
            else 
            {
                this.dgv_Devices.Rows.Add(dgvr);
            }
        }

        private void dgv_Devices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dgvr = dgv_Devices.Rows[e.RowIndex];
                    string sWorkingMode = dgvr.Cells["clm_WorkingMode"].Value.ToString();
                    if (sWorkingMode.Equals("SERVER"))
                    {
                        contextForm.searchDeviceConnect(dgvr.Cells["clm_IP"].Value.ToString() + ":" + dgvr.Cells["clm_ServerPort"].Value.ToString());
                    }
                    else 
                    {
                        ShowMessage("Server Model，Error！");
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region 窗体事件

        private void SearchDevice_Load(object sender, EventArgs e)
        {
            if (!ClouReaderAPI.CLReader.StartSearchDevice(this))
            {
                ShowMessage("Start Search Failure!");
            }
           
        }

        // 停止搜索设备
        private void btn_StopSearch_Click(object sender, EventArgs e)
        {
            ClouReaderAPI.CLReader.StopSearchDevice();
        }
        // 清空搜索列表
        private void btn_ClearList_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgv_Devices.Rows.Clear();
                dic_Rows.Clear();
            }
            catch (Exception ex) { }
        }

        private void SearchDevice_FormClosing(object sender, FormClosingEventArgs e)
        {
            btn_StopSearch_Click(null, null);
        }

        #endregion

    }
}
