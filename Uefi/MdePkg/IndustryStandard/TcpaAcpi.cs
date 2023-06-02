using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  TCPA ACPI table definition.

Copyright (c) 2013, Intel Corporation. All rights reserved. <BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _TCPA_ACPI_H_
// #define _TCPA_ACPI_H_

// #include <IndustryStandard/Acpi.h>

// #pragma pack (1)

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCG_CLIENT_ACPI_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public ushort PlatformClass;
  public uint Laml;
  public ulong Lasa;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCG_SERVER_ACPI_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public ushort PlatformClass;
  public ushort Reserved0;
  public ulong Laml;
  public ulong Lasa;
  public ushort SpecRev;
  public byte DeviceFlags;
  public byte InterruptFlags;
  public byte Gpe;
  public fixed byte Reserved1[3];
  public uint GlobalSysInt;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE BaseAddress;
  public uint Reserved2;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE ConfigAddress;
  public byte PciSegNum;
  public byte PciBusNum;
  public byte PciDevNum;
  public byte PciFuncNum;
}

public unsafe partial class EFI
{
  //
  // TCG Platform Type based on TCG ACPI Specification Version 1.00
  //
  public const ulong TCG_PLATFORM_TYPE_CLIENT = 0;
  public const ulong TCG_PLATFORM_TYPE_SERVER = 1;

  // #pragma pack ()
}

// #endif
