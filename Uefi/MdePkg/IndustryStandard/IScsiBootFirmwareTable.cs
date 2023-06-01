using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  The definition for iSCSI Boot Firmware Table, it's defined in Microsoft's
  iSCSI Boot Firmware Table(iBFT) as Defined in ACPI 3.0b Specification.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _ISCSI_BOOT_FIRMWARE_TABLE_H_
// #define _ISCSI_BOOT_FIRMWARE_TABLE_H_

public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_REVISION = 0x01;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_STRUCTURE_ALIGNMENT = 8;

///
/// Structure Type/ID
///
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_RESERVED_STRUCTURE_ID = 0;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_CONTROL_STRUCTURE_ID = 1;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_INITIATOR_STRUCTURE_ID = 2;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_NIC_STRUCTURE_ID = 3;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_TARGET_STRUCTURE_ID = 4;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_EXTERNSIONS_STRUCTURE_ID = 5;

///
/// from the definition of IP_PREFIX_ORIGIN Enumeration in MSDN,
/// not defined in Microsoft iBFT document.
///
public enum IP_PREFIX_VALUE
{
  IpPrefixOriginOther = 0,
  IpPrefixOriginManual,
  IpPrefixOriginWellKnown,
  IpPrefixOriginDhcp,
  IpPrefixOriginRouterAdvertisement,
  IpPrefixOriginUnchanged = 16
}

// #pragma pack(1)

///
/// iBF Table Header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_HEADER
{
  public uint Signature;
  public uint Length;
  public byte Revision;
  public byte Checksum;
  public fixed byte OemId[6];
  public ulong OemTableId;
  public fixed byte Reserved[24];
}

///
/// Common Header of Boot Firmware Table Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_STRUCTURE_HEADER
{
  public byte StructureId;
  public byte Version;
  public ushort Length;
  public byte Index;
  public byte Flags;
}

///
/// Control Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_CONTROL_STRUCTURE
{
  public EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_STRUCTURE_HEADER Header;
  public ushort Extensions;
  public ushort InitiatorOffset;
  public ushort NIC0Offset;
  public ushort Target0Offset;
  public ushort NIC1Offset;
  public ushort Target1Offset;
}

public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_CONTROL_STRUCTURE_VERSION = 0x1;

public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_CONTROL_STRUCTURE_FLAG_BOOT_FAILOVER = BIT0;

///
/// Initiator Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_INITIATOR_STRUCTURE
{
  public EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_STRUCTURE_HEADER Header;
  public EFI_IPv6_ADDRESS ISnsServer;
  public EFI_IPv6_ADDRESS SlpServer;
  public EFI_IPv6_ADDRESS PrimaryRadiusServer;
  public EFI_IPv6_ADDRESS SecondaryRadiusServer;
  public ushort IScsiNameLength;
  public ushort IScsiNameOffset;
}

public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_INITIATOR_STRUCTURE_VERSION = 0x1;

public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_INITIATOR_STRUCTURE_FLAG_BLOCK_VALID = BIT0;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_INITIATOR_STRUCTURE_FLAG_BOOT_SELECTED = BIT1;

///
/// NIC Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_NIC_STRUCTURE
{
  public EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_STRUCTURE_HEADER Header;
  public EFI_IPv6_ADDRESS Ip;
  public byte SubnetMaskPrefixLength;
  public byte Origin;
  public EFI_IPv6_ADDRESS Gateway;
  public EFI_IPv6_ADDRESS PrimaryDns;
  public EFI_IPv6_ADDRESS SecondaryDns;
  public EFI_IPv6_ADDRESS DhcpServer;
  public ushort VLanTag;
  public fixed byte Mac[6];
  public ushort PciLocation;
  public ushort HostNameLength;
  public ushort HostNameOffset;
}

public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_NIC_STRUCTURE_VERSION = 0x1;

public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_NIC_STRUCTURE_FLAG_BLOCK_VALID = BIT0;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_NIC_STRUCTURE_FLAG_BOOT_SELECTED = BIT1;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_NIC_STRUCTURE_FLAG_GLOBAL = BIT2;

///
/// Target Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_TARGET_STRUCTURE
{
  public EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_STRUCTURE_HEADER Header;
  public EFI_IPv6_ADDRESS Ip;
  public ushort Port;
  public fixed byte BootLun[8];
  public byte CHAPType;
  public byte NicIndex;
  public ushort IScsiNameLength;
  public ushort IScsiNameOffset;
  public ushort CHAPNameLength;
  public ushort CHAPNameOffset;
  public ushort CHAPSecretLength;
  public ushort CHAPSecretOffset;
  public ushort ReverseCHAPNameLength;
  public ushort ReverseCHAPNameOffset;
  public ushort ReverseCHAPSecretLength;
  public ushort ReverseCHAPSecretOffset;
}

public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_TARGET_STRUCTURE_VERSION = 0x1;

public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_TARGET_STRUCTURE_FLAG_BLOCK_VALID = BIT0;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_TARGET_STRUCTURE_FLAG_BOOT_SELECTED = BIT1;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_TARGET_STRUCTURE_FLAG_RADIUS_CHAP = BIT2;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_TARGET_STRUCTURE_FLAG_RADIUS_RCHAP = BIT3;

public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_TARGET_STRUCTURE_CHAP_TYPE_NO_CHAP = 0;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_TARGET_STRUCTURE_CHAP_TYPE_CHAP = 1;
public const ulong EFI_ACPI_ISCSI_BOOT_FIRMWARE_TABLE_TARGET_STRUCTURE_CHAP_TYPE_MUTUAL_CHAP = 2;

// #pragma pack()

// #endif
