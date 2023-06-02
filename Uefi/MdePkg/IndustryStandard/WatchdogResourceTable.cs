using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI Watchdog Resource Table (WDRT) as defined at
  Microsoft Windows Hardware Developer Central.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _WATCHDOG_RESOURCE_TABLE_H_
// #define _WATCHDOG_RESOURCE_TABLE_H_

// #include <IndustryStandard/Acpi.h>

//
// Ensure proper structure formats
//
// #pragma pack(1)

///
/// Watchdog Resource Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_WATCHDOG_RESOURCE_1_0_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public EFI_ACPI_2_0_GENERIC_ADDRESS_STRUCTURE ControlRegisterAddress;
  public EFI_ACPI_2_0_GENERIC_ADDRESS_STRUCTURE CountRegisterAddress;
  public ushort PCIDeviceID;
  public ushort PCIVendorID;
  public byte PCIBusNumber;
  public byte PCIDeviceNumber;
  public byte PCIFunctionNumber;
  public byte PCISegment;
  public ushort MaxCount;
  public byte Units;
}

// #pragma pack()

public unsafe partial class EFI
{
  //
  // WDRT Revision (defined in spec)
  //
  public const ulong EFI_ACPI_WATCHDOG_RESOURCE_1_0_TABLE_REVISION = 0x01;

  //
  // WDRT 1.0 Count Unit
  //
  public const ulong EFI_ACPI_WDRT_1_0_COUNT_UNIT_1_SEC_PER_COUNT = 1;
  public const ulong EFI_ACPI_WDRT_1_0_COUNT_UNIT_100_MILLISEC_PER_COUNT = 2;
  public const ulong EFI_ACPI_WDRT_1_0_COUNT_UNIT_10_MILLISEC_PER_COUNT = 3;
}

// #endif
