using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClouReaderDemo.MyForm.Dialog
{
    public partial class SoftUpdate : BaseDialog
    {
        private String ConnID = "";             // 当前连接ID
        private String UpdateType = "";         // 更新文件类型
        private Int32 maxProcess = 0;
        public SoftUpdate()
        {
            InitializeComponent();
        }

        public SoftUpdate(String connID,String updateType)
            : this()
        {
            this.ConnID = connID;
            this.UpdateType = updateType;
            if (this.UpdateType.Equals("Application"))
            {
                this.Text = "Application software upgrade";
            }
            else if (this.UpdateType.Equals("Baseband"))
            {
                this.Text = "Baseband software upgrade";
            }
            this.Width = 500;
            this.Height = 200;
        }

        protected void ProcessPerformStep() 
        {
            if (this.progressBar.InvokeRequired) 
            {
                this.progressBar.BeginInvoke(new MethodInvoker(ProcessPerformStep));
                return;
            }
            progressBar.PerformStep();
            Int32 nowProcessPercentage = (Int32)((Double)progressBar.Value / progressBar.Maximum * 100);
            lb_Progress.Text = nowProcessPercentage + " %";
            if (nowProcessPercentage == 100){ btn_StartUpdate.Enabled = true; }
        }

        protected void SetMaxProcess() 
        {
            if (this.progressBar.InvokeRequired) 
            {
                this.progressBar.BeginInvoke(new MethodInvoker(SetMaxProcess));
                return;
            }
            progressBar.Maximum = maxProcess;
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    tb_file.Text = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    ShowMessage(" " + ex.Message);
                }
            }
        }

        private void btn_StartUpdate_Click(object sender, EventArgs e)
        {
            progressBar.Value = 1;
            if (UpdateType.Equals("Application"))
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(UpdataApplication), null);
            }
            else 
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(UpdataBaseBand), null);
            }
            btn_StartUpdate.Enabled = false;
        }

        private void UpdataApplication(object o)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(tb_file.Text.Trim(), FileMode.Open);
                // byte[] fileBuffer = new byte[fs.Length];
                // fs.Read(fileBuffer, 0, fileBuffer.Length);
                if (!String.IsNullOrEmpty(tb_file.Text))
                {
                    if (fs.Length >= 1024 * 1024 * 100) { throw new Exception("Max File 100M！"); }
                    Int32 fileSize = (Int32)fs.Length;
                    byte[] buffer = new byte[256];
                    UInt32 blockCount = (UInt32)((fileSize % 256) == 0 ? fileSize / 256 : fileSize / 256 + 1);
                    maxProcess = (Int32)blockCount;
                    SetMaxProcess();
                    Int32 copyIndex = 0;
                    String isOK = "";
                    isOK = ClouReaderAPI.CLReader.PARAM_SET.UpdateApplication(ConnID, 0, new byte[0]);
                    if (isOK.EndsWith("0"))
                    {
                        for (UInt32 i = 0; i < blockCount; i++)
                        {
                            Int32 readCount = 0;
                            if (copyIndex + 256 <= fileSize)
                            {
                                readCount = fs.Read(buffer, 0, 256);
                            }
                            else
                            {
                                byte[] lastBuffer = new byte[fileSize - copyIndex];
                                readCount = fs.Read(lastBuffer, 0, fileSize - copyIndex);
                                buffer = lastBuffer;
                            }
                            isOK = ClouReaderAPI.CLReader.PARAM_SET.UpdateApplication(ConnID, i, buffer);
                            if (String.IsNullOrEmpty(isOK)) { throw new Exception("Time Out！"); }
                            else if (isOK.EndsWith("1")) { throw new Exception("return false！"); }
                            copyIndex += 256;
                            ProcessPerformStep();
                        }
                    }
                    else
                    {
                        throw new Exception("upgrade error！");
                    }
                    if (ClouReaderAPI.CLReader.PARAM_SET.UpdateApplication(ConnID, UInt32.MaxValue, new byte[0]).EndsWith("0"))
                    {
                        if (DialogResult.OK == ShowQuestion("upgrade success！now Retart Reader?")) 
                        {
                            ClouReaderAPI.CLReader.PARAM_SET.ReSetReader(ConnID);
                        }
                    }
                    else
                    {
                        ShowMessage("CRC ERROR！");
                    }
                }
                else
                {
                    ShowMessage("please select file!");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void UpdataBaseBand(object o) 
        {
            FileStream fs =null;
            try
            {
                fs = new FileStream(tb_file.Text.Trim(), FileMode.Open);
                byte[] fileBuffer = new byte[fs.Length];
                fs.Read(fileBuffer, 0, fileBuffer.Length);
                fs.Close();
                if (!String.IsNullOrEmpty(tb_file.Text))
                {
                    if (fileBuffer.Length >= 1024 * 1024 * 100) { throw new Exception("Max File 100M！"); }
                    Int32 fileSize = (Int32)fileBuffer.Length;
                    byte[] buffer = new byte[256];
                    UInt32 blockCount = (UInt32)((fileSize % 256) == 0 ? fileSize / 256 : fileSize / 256 + 1);
                    maxProcess = (Int32)blockCount;
                    SetMaxProcess();
                    Int32 copyIndex = 0;
                    String isOK = "";
                    isOK = ClouReaderAPI.CLReader.PARAM_SET.UpdateBaseBand(ConnID, 0, new byte[0]);
                    if (isOK.EndsWith("0"))
                    {
                        for (UInt32 i = 0; i < blockCount; i++)
                        {
                            // Int32 readCount = 0;
                            if (copyIndex + 256 <= fileSize)
                            {
                                Array.Copy(fileBuffer, copyIndex, buffer, 0, 256);
                                // readCount = fs.Read(buffer, 0, 256);
                            }
                            else
                            {
                                byte[] lastBuffer = new byte[fileSize - copyIndex];
                                // readCount = fs.Read(lastBuffer, 0, fileSize - copyIndex);
                                Array.Copy(fileBuffer, copyIndex, lastBuffer, 0, lastBuffer.Length);
                                buffer = lastBuffer;
                            }
                            isOK = ClouReaderAPI.CLReader.PARAM_SET.UpdateBaseBand(ConnID, i, buffer);
                            if (String.IsNullOrEmpty(isOK)) { throw new Exception("Time Out！"); }
                            else if (isOK.EndsWith("1")) { throw new Exception("return false！"); }
                            copyIndex += 256;
                            ProcessPerformStep();
                        }
                    }
                    else
                    {
                        throw new Exception("upgrade error！");
                    }
                    if (ClouReaderAPI.CLReader.PARAM_SET.UpdateBaseBand(ConnID, UInt32.MaxValue, new byte[0]).EndsWith("0"))
                    {
                        if (DialogResult.OK == ShowQuestion("upgrade success！now Retart Reader?"))
                        {
                            ClouReaderAPI.CLReader.PARAM_SET.ReSetReader(ConnID);
                        }
                    }
                    else 
                    {
                        ShowMessage("CRC ERROR！");
                    }
                }
                else
                {
                    ShowMessage("please select file!");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally 
            {
                //if (fs != null) 
                //{
                //    fs.Close();
                //}
            }
        }


    }
}
