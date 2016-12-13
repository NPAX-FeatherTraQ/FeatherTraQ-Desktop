using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace ClouReaderDemo.Helper
{
    public class MyXmlHelper
    {
        public MyXmlHelper()
        {
        }

        public static String GetXMLPath(string name)
        {
            String path = "";
            try
            {
                if (!string.IsNullOrEmpty(name))
                {

                    path = Environment.CurrentDirectory+"\\"+name;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AssemblyHelper.GetXMLPath(string)->" + ex.Message);
                // throw ex;
            }
            return path;
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">父节点</param>
        /// <param name="attribute">读取节点</param>
        /// <returns>string</returns>
        public static string ReadInnerText(string path, string rootNode , string selectNode)
        {
            string str1 = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(GetXMLPath(path));
                XmlNodeList nodeList = doc.SelectSingleNode(rootNode).ChildNodes;//获取NewDataSet节点的所有子节点
                foreach (XmlNode xn in nodeList)//遍历所有子节点
                {
                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                    if (xe.Name == selectNode)
                    {
                        str1 = xe.InnerText;
                        continue;
                    }
                }
                return str1;
            }
            catch (Exception ex) { string aaa = ex.ToString(); }
            finally 
            {
            }
            return str1;
        }


        public static void UpdateInnerText(string path, string rootNode, string selectNode, string text) 
        {
            try
            {
                Boolean isSearch = false;
                XmlDocument doc = new XmlDocument();
                string filPath = GetXMLPath(path);
                doc.Load(filPath);
                XmlNode xn = doc.SelectSingleNode(rootNode);
                XmlNodeList nodeList = xn.ChildNodes;//获取NewDataSet节点的所有子节点
                foreach (XmlNode xxn in nodeList)//遍历所有子节点
                {
                    XmlElement xe = (XmlElement)xxn;//将子节点类型转换为XmlElement类型
                    if (xe.Name == selectNode)
                    {
                        xe.InnerText = text;
                        isSearch = true;
                        continue;
                    }
                }
                if (!isSearch)
                {
                    XmlElement newxe = doc.CreateElement(selectNode);
                    newxe.InnerText = text;
                    xn.AppendChild(newxe);
                }
                doc.Save(filPath);
            }
            catch (Exception ex) { string aaa = ex.ToString(); }
        }
        
    }
}
