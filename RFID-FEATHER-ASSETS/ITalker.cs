﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Reader
{
    public delegate void MessageReceivedEventHandler(byte[] btAryBuffer);

    interface ITalker
    {
        event MessageReceivedEventHandler MessageReceived;    // Receiving the message sent
        bool Connect(IPAddress ip, int port, out string strException);// Connect to the server
        bool SendMessage(byte[] btAryBuffer);                 // Send packets
        void SignOut();                                       // Logout connection
        bool IsConnect();                                    //Verify Connection Server
    }
}
