using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  IPMI SSIF Definitions

  Copyright (c) 2023, Ampere Computing LLC. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
    - IPMI Specification
      Version 2.0, Rev. 1.1

  https://www.intel.com/content/www/us/en/products/docs/servers/ipmi/ipmi-second-gen-interface-spec-v2-rev1-1.html
**/

// #ifndef IPMI_SSIF_H_
// #define IPMI_SSIF_H_

///
/// Definitions for SMBUS Commands for SSIF
/// Table 12 - Summary of SMBUS Commands for SSIF
///

public unsafe partial class EFI
{
  /// Write block
  public const ulong IPMI_SSIF_SMBUS_CMD_SINGLE_PART_WRITE = 0x02;
  public const ulong IPMI_SSIF_SMBUS_CMD_MULTI_PART_WRITE_START = 0x06;
  public const ulong IPMI_SSIF_SMBUS_CMD_MULTI_PART_WRITE_MIDDLE = 0x07;
  public const ulong IPMI_SSIF_SMBUS_CMD_MULTI_PART_WRITE_END = 0x08;

  /// Read block
  public const ulong IPMI_SSIF_SMBUS_CMD_SINGLE_PART_READ = 0x03;
  public const ulong IPMI_SSIF_SMBUS_CMD_MULTI_PART_READ_START = 0x03;
  public const ulong IPMI_SSIF_SMBUS_CMD_MULTI_PART_READ_MIDDLE = 0x09;
  public const ulong IPMI_SSIF_SMBUS_CMD_MULTI_PART_READ_END = 0x09;
  public const ulong IPMI_SSIF_SMBUS_CMD_MULTI_PART_READ_RETRY = 0x0A;

  ///
  /// Definitions for Multi-Part Read Transactions
  /// Section 12.5
  ///
  public const ulong IPMI_SSIF_MULTI_PART_READ_START_SIZE = 0x1E;
  public const ulong IPMI_SSIF_MULTI_PART_READ_START_PATTERN1 = 0x00;
  public const ulong IPMI_SSIF_MULTI_PART_READ_START_PATTERN2 = 0x01;
  public const ulong IPMI_SSIF_MULTI_PART_READ_END_PATTERN = 0xFF;

  ///
  /// IPMI SSIF maximum message size
  ///
  public const ulong IPMI_SSIF_INPUT_MESSAGE_SIZE_MAX = 0xFF;
  public const ulong IPMI_SSIF_OUTPUT_MESSAGE_SIZE_MAX = 0xFF;

  ///
  /// IPMI SMBus system interface maximum packet size in byte
  ///
  public const ulong IPMI_SSIF_MAXIMUM_PACKET_SIZE_IN_BYTES = 0x20;
}

public enum IPMI_SSIF_PACKET_ATTRIBUTE
{
  IpmiSsifPacketStart = 0,
  IpmiSsifPacketMiddle,
  IpmiSsifPacketEnd,
  IpmiSsifPacketSingle,
  IpmiSsifPacketMax
}

// #pragma pack (1)
///
/// IPMI SSIF Interface Request Format
/// Section 12.2 and 12.3
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SSIF_REQUEST_HEADER
{
  public byte NetFunc;
  public byte Command;
}

///
/// IPMI SSIF Interface Response Format
/// Section 12.4 and 12.5
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SSIF_RESPONSE_PACKET_START
{
  public fixed byte StartPattern[2];
  public byte NetFunc;
  public byte Command;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SSIF_RESPONSE_PACKET_MIDDLE
{
  public byte BlockNumber;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SSIF_RESPONSE_PACKET_END
{
  public byte EndPattern;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SSIF_RESPONSE_SINGLE_PACKET
{
  public byte NetFunc;
  public byte Command;
}

// #pragma pack ()

// #endif /* IPMI_SSIF_H_ */
