using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI Alert Standard Format Description Table ASF! as described in the ASF2.0 Specification

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _ALERT_STANDARD_FORMAT_TABLE_H_
// #define _ALERT_STANDARD_FORMAT_TABLE_H_

// #include <IndustryStandard/Acpi.h>

//
// Ensure proper structure formats
//
// #pragma pack (1)

///
/// Information Record header that appears at the beginning of each record
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ASF_RECORD_HEADER
{
  public byte Type;
  public byte Reserved;
  public ushort RecordLength;
}

///
/// This structure contains information that identifies the system's type
/// and configuration
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ASF_INFO
{
  public EFI_ACPI_ASF_RECORD_HEADER RecordHeader;
  public byte MinWatchDogResetValue;
  public byte MinPollingInterval;
  public ushort SystemID;
  public uint IANAManufactureID;
  public byte FeatureFlags;
  public fixed byte Reserved[3];
}

///
/// ASF Alert Data
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ASF_ALERTDATA
{
  public byte DeviceAddress;
  public byte Command;
  public byte DataMask;
  public byte CompareValue;
  public byte EventSenseType;
  public byte EventType;
  public byte EventOffset;
  public byte EventSourceType;
  public byte EventSeverity;
  public byte SensorNumber;
  public byte Entity;
  public byte EntityInstance;
}

///
/// Alert sensors definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ASF_ALRT
{
  public EFI_ACPI_ASF_RECORD_HEADER RecordHeader;
  public byte AssertionEventBitMask;
  public byte DeassertionEventBitMask;
  public byte NumberOfAlerts;
  public byte ArrayElementLength;        ///< For ASF version 1.0 and later, this filed is set to 0x0C
                                         ///
                                         /// EFI_ACPI_ASF_ALERTDATA           DeviceArray[ANYSIZE_ARRAY];
                                         ///
}

///
/// Alert Control Data
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ASF_CONTROLDATA
{
  public byte Function;
  public byte DeviceAddress;
  public byte Command;
  public byte DataValue;
}

///
/// Alert Remote Control System Actions
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ASF_RCTL
{
  public EFI_ACPI_ASF_RECORD_HEADER RecordHeader;
  public byte NumberOfControls;
  public byte ArrayElementLength;        ///< For ASF version 1.0 and later, this filed is set to 0x4
  public ushort RctlReserved;
  ///
  /// EFI_ACPI_ASF_CONTROLDATA;        DeviceArray[ANYSIZE_ARRAY];
  ///
}

///
/// Remote Control Capabilities
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ASF_RMCP
{
  public EFI_ACPI_ASF_RECORD_HEADER RecordHeader;
  public fixed byte RemoteControlCapabilities[7];
  public byte RMCPCompletionCode;
  public uint RMCPIANA;
  public byte RMCPSpecialCommand;
  public fixed byte RMCPSpecialCommandParameter[2];
  public fixed byte RMCPBootOptions[2];
  public fixed byte RMCPOEMParameters[2];
}

///
/// SMBus Devices with fixed addresses
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ASF_ADDR
{
  public EFI_ACPI_ASF_RECORD_HEADER RecordHeader;
  public byte SEEPROMAddress;
  public byte NumberOfDevices;
  ///
  /// byte                            FixedSmbusAddresses[ANYSIZE_ARRAY];
  ///
}

///
/// ASF! Description Table Header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ASF_DESCRIPTION_HEADER { EFI_ACPI_DESCRIPTION_HEADER Value; public static implicit operator EFI_ACPI_ASF_DESCRIPTION_HEADER(EFI_ACPI_DESCRIPTION_HEADER value) => new EFI_ACPI_ASF_DESCRIPTION_HEADER() { Value = value }; public static implicit operator EFI_ACPI_DESCRIPTION_HEADER(EFI_ACPI_ASF_DESCRIPTION_HEADER value) => value.Value; }

public unsafe partial class EFI
{
  ///
  /// The revision stored in ASF! DESCRIPTION TABLE as BCD value
  ///
  public const ulong EFI_ACPI_2_0_ASF_DESCRIPTION_TABLE_REVISION = 0x20;

  ///
  /// "ASF!" ASF Description Table Signature
  ///
  //public const ulong EFI_ACPI_ASF_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('A', 'S', 'F', '!');

  // #pragma pack ()
}

// #endif // _ALERT_STANDARD_FORMAT_TABLE_H
