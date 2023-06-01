using System.Runtime.InteropServices;

namespace Uefi;
/** @file

  The definitions of DMTF Management Component Transport Protocol (MCTP)
  Base Specification.

  Copyright (C) 2023 Advanced Micro Devices, Inc. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  DMTF Management Component Transport Protocol (MCTP) Base Specification
  Version 1.3.1
  https://www.dmtf.org/sites/default/files/standards/documents/DSP0236_1.3.1.pdf
**/

// #ifndef MCTP_H_
// #define MCTP_H_

///
/// Definitions of endpoint ID
///
public const ulong MCTP_NULL_DESTINATION_ENDPOINT_ID = 0;
public const ulong MCTP_NULL_SOURCE_ENDPOINT_ID = 0;
public const ulong MCTP_RESERVED_ENDPOINT_START_ID = 1;
public const ulong MCTP_RESERVED_ENDPOINT_END_ID = 7;
public const ulong MCTP_BROADCAST_ENDPOINT_ID = 0xFF;

///
/// MCTP Control Commands
///
public const ulong MCTP_CONTROL_RESERVED = 0x00;
public const ulong MCTP_CONTROL_SET_ENDPOINT_ID = 0x01;
public const ulong MCTP_CONTROL_GET_ENDPOINT_ID = 0x02;
public const ulong MCTP_CONTROL_GET_ENDPOINT_UUID = 0x03;
public const ulong MCTP_CONTROL_GET_MCTP_VERSION_SUPPORT = 0x04;
public const ulong MCTP_CONTROL_GET_MESSAGE_TYPE_SUPPORT = 0x05;
public const ulong MCTP_CONTROL_GET_VENDOR_DEFINED_MESSAGE_SUPPORT = 0x06;
public const ulong MCTP_CONTROL_RESOLVE_ENDPOINT_ID = 0x07;
public const ulong MCTP_CONTROL_ALLOCATE_ENDPOINT_IDS = 0x08;
public const ulong MCTP_CONTROL_ROUTING_INFORMATION_UPDATE = 0x09;
public const ulong MCTP_CONTROL_GET_ROUTINE_TABLE_ENTRIES = 0x0A;
public const ulong MCTP_CONTROL_PREPARE_FOR_ENDPOINT_DISCOVERY = 0x0B;
public const ulong MCTP_CONTROL_ENDPOINT_DISCOVERY = 0x0C;
public const ulong MCTP_CONTROL_DISCOVERY_NOTIFY = 0x0D;
public const ulong MCTP_CONTROL_GET_NETWORK_ID = 0x0E;
public const ulong MCTP_CONTROL_QUERY_HOP = 0x0F;
public const ulong MCTP_CONTROL_RESOLVE_UUID = 0x10;
public const ulong MCTP_CONTROL_QUERY_RATE_LIMIT = 0x11;
public const ulong MCTP_CONTROL_REQUEST_TX_RATE_LIMIT = 0x12;
public const ulong MCTP_CONTROL_UPDATE_RATE_LIMIT = 0x13;
public const ulong MCTP_CONTROL_QUERY_SUPPORTED_INTERFACES = 0x14;
public const ulong MCTP_CONTROL_TRANSPORT_SPECIFIC_START = 0xF0;
public const ulong MCTP_CONTROL_TRANSPORT_SPECIFIC_END = 0xFF;

///
/// MCTP Control Message Completion Codes
///
public const ulong MCTP_CONTROL_COMPLETION_CODES_SUCCESS = 0x00;
public const ulong MCTP_CONTROL_COMPLETION_CODES_ERROR = 0x01;
public const ulong MCTP_CONTROL_COMPLETION_CODES_ERROR_INVALID_DATA = 0x02;
public const ulong MCTP_CONTROL_COMPLETION_CODES_ERROR_INVALID_LENGTH = 0x03;
public const ulong MCTP_CONTROL_COMPLETION_CODES_ERROR_NOT_READY = 0x04;
public const ulong MCTP_CONTROL_COMPLETION_CODES_ERROR_UNSUPPORTED_CMD = 0x05;
public const ulong MCTP_CONTROL_COMPLETION_CODES_COMMAND_SPECIFIC_START = 0x80;
public const ulong MCTP_CONTROL_COMPLETION_CODES_COMMAND_SPECIFIC_END = 0xFF;

///
/// MCTP Control Message Types
///
public const ulong MCTP_MESSAGE_TYPE_CONTROL = 0x00;
public const ulong MCTP_MESSAGE_TYPE_PLDM = 0x01;
public const ulong MCTP_MESSAGE_TYPE_NCSI = 0x02;
public const ulong MCTP_MESSAGE_TYPE_ETHERNET = 0x03;
public const ulong MCTP_MESSAGE_TYPE_NVME = 0x04;
public const ulong MCTP_MESSAGE_TYPE_SPDM = 0x05;
public const ulong MCTP_MESSAGE_TYPE_SECURE_MESSAGE = 0x06;
public const ulong MCTP_MESSAGE_TYPE_CXL_FM_API = 0x07;
public const ulong MCTP_MESSAGE_TYPE_CXL_CCI = 0x08;
public const ulong MCTP_MESSAGE_TYPE_VENDOR_DEFINED_PCI = 0x7E;
public const ulong MCTP_MESSAGE_TYPE_VENDOR_DEFINED_IANA = 0x7F;

public const ulong MCTP_ENDPOINT_ID_NULL = 0;
public const ulong MCTP_ENDPOINT_ID_RESERVED_START = 1;
public const ulong MCTP_ENDPOINT_ID_RESERVED_END = 7;
public const ulong MCTP_ENDPOINT_ID_BROADCAST = 0xff;
///
/// MCTP Control Message Format
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint MessageType = 7; ///< Message type.
  [FieldOffset(0)] public uint IntegrityCheck = 1; ///< Message integrity check.
  [FieldOffset(0)] public uint InstanceId = 5; ///< Instance ID.
  [FieldOffset(0)] public uint Reserved = 1; ///< Reserved bit.
  [FieldOffset(0)] public uint DatagramBit = 1; ///< Datagram bit.
  [FieldOffset(0)] public uint RequestBit = 1; ///< Request bit.
  [FieldOffset(0)] public uint CommandCode = 8; ///< Command code of request message.
  [FieldOffset(0)] public uint CompletionCode = 8; ///< Completion code in response message.
}
uint BodyHeader;
} MCTP_CONTROL_MESSAGE;

/// Minimum transmission size is 64 bytes.
/// The value of 64 is defined in MCTP Base Specification.
public const ulong MCTP_BASELINE_MINIMUM_UNIT_TRANSMISSION_SIZE = 0x40;

///
/// The 32-bit Header of MCTP packet.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint HeaderVersion = 4; ///< The version of header.
  [FieldOffset(0)] public uint Reserved = 4; ///< Reserved for future definitions.
  [FieldOffset(0)] public uint DestinationEndpointId = 8; ///< Destination endpoint Id (EID).
  [FieldOffset(0)] public uint SourceEndpointIdId = 8; ///< Source endpoint Id (EID)
  [FieldOffset(0)] public uint MessageTag = 3; ///< Check the MCTP Base specification for the
                                               ///< usages.
  [FieldOffset(0)] public uint TagOwner = 1; ///< Tag owner identifies the message was
                                             ///< originated by the source EID or
                                             ///< destination EID.
  [FieldOffset(0)] public uint PacketSequence = 2; ///< Sequence number increments Modulo 4 on
                                                   ///< each packet.
  [FieldOffset(0)] public uint EndOfMessage = 1; ///< Indicates the last packet of message.
  [FieldOffset(0)] public uint StartOfMessage = 1; ///< Indicates the first packet of message.
}
uint Header;
} MCTP_TRANSPORT_HEADER;

///
/// The 8-bit Message Header of MCTP packet.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte MessageType = 7;
  [FieldOffset(0)] public byte IntegrityCheck = 1;
}
byte MessageHeader;
} MCTP_MESSAGE_HEADER;

// #endif
