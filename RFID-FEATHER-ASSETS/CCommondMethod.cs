using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UHFDemo
{
    class CCommondMethod
    {
        /// <summary>
        /// Turn hex ​​string arrays, strings, separated by spaces
        /// </summary>
        /// <param name="strHexValue"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string strHexValue)
        {
            string[] strAryHex = strHexValue.Split(' ');
            byte[] btAryHex = new byte[strAryHex.Length];

            try
            {
                int nIndex = 0;
                foreach (string strTemp in strAryHex)
                {
                    btAryHex[nIndex] = Convert.ToByte(strTemp, 16);
                    nIndex++;
                }
            }
            catch (System.Exception ex)
            {
            	
            }

            return btAryHex;
        }

        /// <summary>
        /// An array of characters into hexadecimal arrays
        /// </summary>
        /// <param name="strAryHex"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        public static byte[] StringArrayToByteArray(string[] strAryHex, int nLen)
        {
            if (strAryHex.Length < nLen)
            {
                nLen = strAryHex.Length;
            }

            byte[] btAryHex = new byte[nLen];

            try
            {
                int nIndex = 0;
                foreach (string strTemp in strAryHex)
                {
                    btAryHex[nIndex] = Convert.ToByte(strTemp, 16);
                    nIndex++;
                }
            }
            catch (System.Exception ex)
            {
            	
            }

            return btAryHex;
        }

        /// <summary>
        /// Hexadecimal characters turn into an array of strings
        /// </summary>
        /// <param name="btAryHex"></param>
        /// <param name="nIndex"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] btAryHex, int nIndex, int nLen)
        {
            if (nIndex + nLen > btAryHex.Length)
            {
                nLen = btAryHex.Length - nIndex;
            }

            string strResult = string.Empty;

            for (int nloop = nIndex; nloop < nIndex + nLen; nloop++ )
            {
                string strTemp = string.Format(" {0:X2}", btAryHex[nloop]);

                strResult += strTemp;
            }

            return strResult;
        }

        /// <summary>
        /// The interception of the specified string length and transfers for an array of characters , spaces are ignored
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string[] StringToStringArray(string strValue, int nLength)
        {
            string[] strAryResult = null;

            if (!string.IsNullOrEmpty(strValue))
            {
                System.Collections.ArrayList strListResult = new System.Collections.ArrayList();
                string strTemp = string.Empty;
                int nTemp = 0;

                for (int nloop = 0; nloop < strValue.Length; nloop++ )
                {
                    if (strValue[nloop] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        nTemp++;

                        //Check character is taken in A ~ F, 0 ~ 9 range, is not directly exit
                        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^(([A-F])*(\d)*)$");
                        if (!reg.IsMatch(strValue.Substring(nloop, 1)))
                        {
                            return strAryResult;
                        }

                        strTemp += strValue.Substring(nloop, 1);

                        //To determine whether the length of the interception arrival
                        if ((nTemp == nLength) || (nloop == strValue.Length - 1 && !string.IsNullOrEmpty(strTemp)))
                        {
                            strListResult.Add(strTemp);
                            nTemp = 0;
                            strTemp = string.Empty;
                        }
                    }
                }

                if (strListResult.Count > 0)
                {
                    strAryResult = new string[strListResult.Count];
                    strListResult.CopyTo(strAryResult);
                }
            }

            return strAryResult;
        }

        public static string FormatErrorCode(byte btErrorCode)
        {
            string strErrorCode = "";
            switch (btErrorCode)
            {
                case 0x10:
                    strErrorCode = "Error";
                    break;
                case 0x11:
                    strErrorCode = "Command fails";
                    break;
                case 0x20:
                    strErrorCode = "CPU Reset Error";
                    break;
                case 0x21:
                    strErrorCode = "Open CW error";
                    break;
                case 0x22:
                    strErrorCode = "Antenna not connected";
                    break;
                case 0x23:
                    strErrorCode = "Flash write error";
                    break;
                case 0x24:
                    strErrorCode = "Flash read error";
                    break;
                case 0x25:
                    strErrorCode = "Set the transmit power error";
                    break;
                case 0x31:
                    strErrorCode = "Inventory tag mistakes";
                    break;
                case 0x32:
                    strErrorCode = "Error reading tag";
                    break;
                case 0x33:
                    strErrorCode = "Write tag mistakes";
                    break;
                case 0x34:
                    strErrorCode = "Lock Label Error";
                    break;
                case 0x35:
                    strErrorCode = "Inactivated label error";
                    break;
                case 0x36:
                    strErrorCode = "There is no error handling label";
                    break;
                case 0x37:
                    strErrorCode = "But the success of inventory access failure";
                    break;
                case 0x38:
                    strErrorCode = "The cache is empty";
                    break;
                case 0x40:
                    strErrorCode = "Access tag error or access password error";
                    break;
                case 0x41:
                    strErrorCode = "Invalid parameter";
                    break;
                case 0x42:
                    strErrorCode = "wordCnt Parameter exceeds a predetermined length";
                    break;
                case 0x43:
                    strErrorCode = "MemBank Parameter out of range";
                    break;
                case 0x44:
                    strErrorCode = "Lock Data area parameter out of range";
                    break;
                case 0x45:
                    strErrorCode = "LockType Parameter out of range";
                    break;
                case 0x46:
                    strErrorCode = "Reader address is invalid";
                    break;
                case 0x47:
                    strErrorCode = "Antenna_id Out of range";
                    break;
                case 0x48:
                    strErrorCode = "Output parameter out of range";
                    break;
                case 0x49:
                    strErrorCode = "RF parameter out of range specification area";
                    break;
                case 0x4A:
                    strErrorCode = "The baud rate parameter exceeds the range";
                    break;
                case 0x4B:
                    strErrorCode = "Buzzer setting parameters out of range";
                    break;
                case 0x4C:
                    strErrorCode = "EPC Length of cross-border match";
                    break;
                case 0x4D:
                    strErrorCode = "EPC Match length error";
                    break;
                case 0x4E:
                    strErrorCode = "EPC Matching parameter out of range";
                    break;
                case 0x4F:
                    strErrorCode = "Frequency range setting parameter error";
                    break;
                case 0x50:
                    strErrorCode = "You can not receive a tagRN16";
                    break;
                case 0x51:
                    strErrorCode = "DRM Setting parameter error";
                    break;
                case 0x52:
                    strErrorCode = "PLL Not lock";
                    break;
                case 0x53:
                    strErrorCode = "RF chip unresponsive";
                    break;
                case 0x54:
                    strErrorCode = "Output can not reach the specified output power";
                    break;
                case 0x55:
                    strErrorCode = "Not by copyright authentication";
                    break;
                case 0x56:
                    strErrorCode = "Spectrum policy settings error";
                    break;
                case 0x57:
                    strErrorCode = "Output power is too low";
                    break;
                case 0xFF:
                    strErrorCode = "unknown mistake";
                    break;

                default:
                    break;
            }

            return strErrorCode;
        }
    }    
}
