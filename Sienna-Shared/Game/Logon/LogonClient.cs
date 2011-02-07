﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Net.Sockets;

using Sienna.Network;
using Sienna.zlib;

namespace Sienna.Game
{
    public class LogonClient : Client
    {
        // Base Constructors from abstract server
        public LogonClient() : base() { }

        public LogonClient(Socket Sock) : base(Sock)
        {
            DataStr = new MemoryStream();
            ZStream = new ZOutputStream(DataStr, zlibConst.Z_NO_COMPRESSION);
            ZStream.FlushMode = zlibConst.Z_SYNC_FLUSH;
        }

        public bool ClientCompressPackets = false;
        public bool ServerCompressPackets = false;

        protected MemoryStream DataStr;
        protected ZOutputStream ZStream;

        public Account Acct;

        public byte[] Deflate(byte[] Input)
        {
            ZStream.Write(Input, 0, Input.Length);
            ZStream.Flush();

            byte[] DeflatedData = DataStr.ToArray();
            DataStr.SetLength(0);
            return DeflatedData;
        }

        public void Ping()
        {
            PacketStream ps = new PacketStream();
            ps.WriteUInt32((uint)Environment.TickCount);
            ps.WriteByte(0x07);
        }

        public void Send(LogonOpcodes Opcode, PacketStream ps)
        {
            byte[] data = null;

            if (ServerCompressPackets)
                data = Deflate(ps.ToLogonPacket((ushort)Opcode));
            else
                data = ps.ToLogonPacket((ushort)Opcode);

            _Socket.Send(data);
        }
    }
}
