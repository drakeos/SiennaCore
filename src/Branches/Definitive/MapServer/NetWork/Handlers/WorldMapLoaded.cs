﻿/*
 * Copyright (C) 2011 APS
 *	http://AllPrivateServer.com
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FrameWork;
using Common;

namespace MapServer
{

    [ISerializableAttribute((long)Opcodes.WorldMapLoaded)]
    public class WorldMapLoaded : ISerializablePacket
    {
        public override void OnRead(RiftClient From)
        {
            Log.Info("WorldMapLoaded", "Map loaded for : " + From.Character.CharacterName);
            long CharacterId = From.Character.CharacterId;

            {
                WorldTemplateUpdate Update = new WorldTemplateUpdate();
                Update.GUID = CharacterId;
                Update.Field1 = new byte[]
                { 
                    0xEB,0x04,0x4F,0x1F,0x02,0x5F,0x17,0x07,0x90,0x01,0x07,0xAE,0x05,0x9E,0x02,0x00,0x9F,
                    0x12,0x1C,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xDF,0x12,0x24,
                    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xD0,
                    0x05,0xD8,0x05,0x07,0xC1,0x1E,0x57,0xF5,0x05,0x07,0x07
                };
                From.SendSerialized(Update);
            }

            {
                ISerializablePacket Packet = new ISerializablePacket();
                Packet.Opcode = 0x1973;
                From.SendSerialized(Packet);
            }

            {
                ISerializablePacket Packet = new ISerializablePacket();
                Packet.Opcode = 0x1E7F;
                Packet.AddField(0, EPacketFieldType.False, false);
                Packet.AddField(1, EPacketFieldType.False, false);
                Packet.AddField(2, EPacketFieldType.False, false);

                Packet.AddField(3, EPacketFieldType.List, new List<ISerializablePacket>());

                Packet.AddField(4, EPacketFieldType.Unsigned7BitEncoded, (long)3);
                Packet.AddField(5, EPacketFieldType.Unsigned7BitEncoded, (long)30);

                Packet.AddField(6, EPacketFieldType.False, false);

                Packet.AddField(7, EPacketFieldType.List, new List<long>());
                Packet.AddField(8, EPacketFieldType.List, new List<long>());
                From.SendSerialized(Packet);
            }

            {
                WorldChannelJoinned Channel = new WorldChannelJoinned();
                Channel.ChannelName = "Niveau 1-9";
                Channel.CharacterName = From.Character.CharacterName;
                Channel.Field2 = 5;
                From.SendSerialized(Channel);
            }

            {
                WorldChannelJoinned Channel = new WorldChannelJoinned();
                Channel.ChannelName = "Mathosia";
                Channel.CharacterName = From.Character.CharacterName;
                Channel.Field2 = 2;
                From.SendSerialized(Channel);
            }

            {
                WorldTemplateUpdate Update = new WorldTemplateUpdate();
                Update.GUID = CharacterId;
                Update.Field1 = new byte[]
                { 
                    0xEB,0x04,0x4F,0x1F,0x02,0x5F,0x17,0x07,0xE7,0x02,0xBB,0x99,0x01,0x4E,0xA0,0x1F,0x1A,0x02,0x07,0x56,0xA0,0x1F,0x1A,0x02,0x07,0x58,0xA0,0x1F,0x1A,0x02,0x07,0x5E,0xA0,0x1F,0x19,0x07,0x60,0xA0,0x1F,0x19,0x07,0x66,0xA0,0x1F,0x19,0x07,0x70,0xA0,0x1F,0x1A,0x02,0x07,0xEA,0xBA,0xC9,0x65,0xA0,0x1F,0x19,0x07,0xAC,0xBA,0xEE,0x78,0xA0,0x1F,0x1A,0x02,0x07,0xA0,0x8C,0x88,0x9C,0x01,0xA0,0x1F,0x19,0x07,0x90,0xD6,0xBA,0x88,0x02,0xA0,0x1F,0x1A,0x02,0x07,0xD8,0xD2,0x84,0xAA,0x02,0xA0,0x1F,0x1A,0x02,0x07,0x9E,0x83,0x90,0x87,0x03,0xA0,0x1F,0x1A,0x02,0x07,0x8C,0xE7,0xF5,0x8E,0x03,0xA0,0x1F,0x1A,0x02,0x07,0x86,0xDE,0x9D,0xE9,0x03,0xA0,0x1F,0x19,0x07,0xF6,0xD4,0xCE,0xF4,0x03,0xA0,0x1F,0x1A,0x02,0x07,0xE2,0xA8,0xF2,0x8A,0x04,0xA0,0x1F,0x1A,0x02,0x07,0xD2,0x92,0xCB,0xB3,0x05,0xA0,0x1F,0x19,0x07,0xE0,0xFD,0xF3,0x92,0x06,0xA0,0x1F,0x1A,0x02,0x07,0xE6,0xB7,0xF4,0x94,0x06,0xA0,0x1F,0x1A,0x02,0x07,0xAE,0xBA,0xFD,0xC6,0x06,0xA0,0x1F,0x1A,0x02,0x07,0xB6,0xA5,0xF2,0x8C,0x07,0xA0,0x1F,0x19,0x07,0xC2,0xE4,0xA7,0x9A,0x07,0xA0,0x1F,0x1A,0x02,0x07,0xDE,0x9A,0xE4,0xCA,0x07,0xA0,0x1F,0x19,0x07,0xEC,0xF9,0xF1,0xDF,0x07,0xA0,0x1F,0x1A,0x02,0x07,0xA4,0xDE,0xC0,0xB1,0x08,0xA0,0x1F,0x1A,0x02,0x07,0xE8,0xCE,0xFA,0x81,0x09,0xA0,0x1F,0x1A,0x02,0x07,0x94,0xB1,0xA8,0xBB,0x09,0xA0,0x1F,0x1A,0x02,0x07,0x8A,0x95,0x8E,0xC8,0x09,0xA0,0x1F,0x1A,0x02,0x07,0xD8,0xF7,0xF3,0xFD,0x09,0xA0,0x1F,0x1A,0x02,0x07,0xFA,0xF1,0xE0,0xBA,0x0A,0xA0,0x1F,0x1A,0x02,0x07,0xCE,0xDA,0xE7,0xEE,0x0B,0xA0,0x1F,0x19,0x07,0xF6,0xA2,0x94,0xC1,0x0C,0xA0,0x1F,0x1A,0x02,0x07,0xE2,0xD0,0xE6,0xD0,0x0C,0xA0,0x1F,0x1A,0x02,0x07,0x88,0xFD,0xC2,0xD6,0x0D,0xA0,0x1F,0x1A,0x02,0x07,0x8C,0xA8,0xAA,0xF8,0x0D,0xA0,0x1F,0x19,0x07,0x88,0xBF,0x82,0xFE,0x0E,0xA0,0x1F,0x1A,0x02,0x07,0xBA,0xC4,0xB6,0x90,0x0F,0xA0,0x1F,0x1A,0x02,0x07,0xE7,0x03,0xBB,0x05,0x0A,0xAF,0x02,0x01,0x07,0x90,0x01,0x07,0x94,0x05,0xE7,0x05,0xBB,0x21,0x02,0xBF,0x1B,0x24,0xDF,0x92,0xC3,0x45,0x2C,0xC8,0x23,0xCF,0x7D,0x3C,0x82,0x9B,0xBB,0x22,0x97,0x04,0x90,0x1C,0x04,0x9B,0xEC,0x3E,0x73,0x07,0x07,0x04,0xBF,0x1B,0x24,0xEB,0x36,0xDE,0x44,0x2C,0x33,0x45,0x7A,0x77,0x32,0x15,0x3C,0x82,0x9B,0xBB,0x22,0x97,0x04,0x90,0x1C,0x04,0x5F,0x2D,0x02,0x4F,0x07,0x07,0x0A,0xBF,0x1B,0x24,0x87,0xD4,0x3F,0x5B,0x3A,0x02,0x97,0x04,0x90,0x1C,0x04,0x1E,0x3B,0xD5,0x2D,0x07,0x07,0x0E,0xBF,0x1B,0x24,0x62,0x00,0xDB,0x11,0x3C,0x6F,0x69,0x28,0x59,0x97,0x04,0x90,0x1C,0x04,0x7F,0xC2,0xC0,0x7C,0x07,0x07,0x10,0xBF,0x1B,0x24,0x9A,0x41,0xDC,0x01,0x3C,0x6F,0x69,0x28,0x59,0x97,0x04,0x90,0x1C,0x04,0x5E,0x8B,0x6F,0x26,0x07,0x07,0x12,0xBF,0x1B,0x24,0x9E,0xFC,0x62,0x77,0x3C,0x82,0x9B,0xBB,0x22,0x97,0x04,0x90,0x1C,0x04,0xB7,0x94,0xB3,0x29,0x07,0x07,0x16,0xBF,0x1B,0x24,0x48,0xF1,0xD4,0x0D,0x32,0x14,0x3C,0x6F,0x69,0x28,0x59,0x97,0x04,0x90,0x1C,0x04,0x8A,0x09,0x42,0x17,0x07,0x07,0x2E,0xBF,0x1B,0x24,0xE6,0x82,0x84,0x33,0x3C,0xB3,0xCD,0x6F,0x6A,0x97,0x04,0x90,0x1C,0x04,0x53,0x58,0x26,0x30,0x07,0x07,0x9F,0x06,0x57,0xA9,0x0E,0x02,0x03,0x2A,0xE8,0x07,0x41,0x07,0xDF,0x06,0x57,0x94,0x0E,0x07,0xD7,0x07,0xC2,0x05,0x12,0x05,0xDF,0x05,0x93,0x07,0x06,0xC6,0x01,0x14,0x14,0x1A,0x14,0x12,0x00,0x14,0x14,0x14,0x14,0x14,0x02,0x16,0x1A,0x00,0x00,0x00,0x00,0x8C,0x02,0x00,0x00,0x00,0x00,0x00,0x14,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0xCC,0x0B,0xD0,0x0F,0xC8,0x01,0x14,0x04,0x00,0x00,0x14,0x00,0x00,0x00,0xC8,0x01,0xC8,0x01,0x00,0x00,0x06,0x00,0xC8,0x01,0x00,0x00,0x00,0x00,0x00,0xC8,0x01,0x00,0x00,0x00,0x14,0x00,0x14,0x00,0x00,0xD0,0x0F,0x00,0x00,0x00,0x06,0x06,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xB4,0x01,0x00,0x00,0x00,0xC8,0x01,0xC8,0x01,0xC8,0x01,0xC8,0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC8,0x01,0x00,0x00,0x00,0xDF,0x06,0x93,0x07,0x06,0xC6,0x01,0x14,0x14,0x1A,0x14,0x12,0x00,0x14,0x14,0x14,0x14,0x14,0x02,0x16,0x1A,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x14,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0xCC,0x0B,0xD0,0x0F,0xC8,0x01,0x14,0x04,0x00,0x00,0x14,0x00,0x00,0x00,0xC8,0x01,0xC8,0x01,0x00,0x00,0x06,0x00,0xC8,0x01,0x00,0x00,0x00,0x00,0x00,0xC8,0x01,0x00,0x00,0x00,0x14,0x00,0x14,0x00,0x00,0xD0,0x0F,0x00,0x00,0x00,0x06,0x06,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xB4,0x01,0x00,0x00,0x00,0xC8,0x01,0xC8,0x01,0xC8,0x01,0xC8,0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC8,0x01,0x00,0x00,0x00,0x07,0xDA,0x01,0x0F,0xE4,0x01,0x82,0x86,0x19,0x66,0x07,0xAE,0x05,0x97,0x04,0xF4,0x05,0x0C,0x00,0x00,0x00,0x00,0x1C,0x00,0x00,0x00,0x00,0x07,0x9F,0x1E,0x97,0x02,0xB6,0x0E,0x01,0xDF,0x01,0xD7,0x01,0x90,0x1C,0x07,0x90,0x1C,0x07,0x90,0x1C,0x07,0x07,0xB6,0x0E,0xDF,0x01,0xD7,0x01,0x90,0x1C,0x07,0x90,0x1C,0x07,0x90,0x1C,0x07,0x07,0xB6,0x0E,0xDF,0x01,0xD7,0x01,0x90,0x1C,0x07,0x90,0x1C,0x07,0x90,0x1C,0x07,0x07,0xB6,0x0E,0xDF,0x01,0xD7,0x01,0x90,0x1C,0x07,0x90,0x1C,0x07,0x90,0x1C,0x07,0x07,0x07,0xC1,0x1E,0x57,0xF5,0x05,0x0F,0x1F,0x0A,0x01,0x5F,0x0B,0x84,0x9A,0xCC,0xE1,0x0C,0x07,0x4F,0x1F,0x0A,0x01,0x5F,0x0B,0x1E,0x07,0x07,0x9F,0x07,0x2B,0x06,0x08,0x18,0x04,0x02,0x07
                };
                From.SendSerialized(Update);
            }

            // Character Information
            {
                PacketInStream Entity = new PacketInStream(Program.BuildPlayer, Program.BuildPlayer.Length);
                WorldEntityUpdate Update = PacketProcessor.ReadPacket(ref Entity) as WorldEntityUpdate;
                if(Update.Build(From.Character))
                    From.SendSerialized(Update);
            }

            WorldServerMOTD Motd = new WorldServerMOTD();
            Motd.Text = "Welcome to APS-Rift";
            From.SendSerialized(Motd);
        }
    }
}
