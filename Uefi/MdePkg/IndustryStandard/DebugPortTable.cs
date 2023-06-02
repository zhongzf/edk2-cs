using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI debug port table definition, defined at
  Microsoft DebugPortSpecification.

  Copyright (c) 2012 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _DEBUG_PORT_TABLE_H_
// #define _DEBUG_PORT_TABLE_H_

// #include <IndustryStandard/Acpi.h>

//
// Ensure proper structure formats
//
// #pragma pack(1)

//
// Debug Port Table definition.
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_DEBUG_PORT_DESCRIPTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public byte InterfaceType;
  public fixed byte Reserved_37[3];
  public EFI_ACPI_2_0_GENERIC_ADDRESS_STRUCTURE BaseAddress;
}

// #pragma pack()

//
// DBGP Revision (defined in spec)
//
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_DEBUG_PORT_TABLE_REVISION = 0x01;

  //
  // Interface Type
  //
  public const ulong EFI_ACPI_DBGP_INTERFACE_TYPE_FULL_16550 = 0;
  public const ulong EFI_ACPI_DBGP_INTERFACE_TYPE_16550_SUBSET_COMPATIBLE_WITH_MS_DBGP_SPEC = 1;
}

// #endif
