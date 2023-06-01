using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI memory mapped configuration space access table definition, defined at
  in the PCI Firmware Specification, version 3.0.
  Specification is available at http://www.pcisig.com.

  Copyright (c) 2007 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _MEMORY_MAPPED_CONFIGURATION_SPACE_ACCESS_TABLE_H_
// #define _MEMORY_MAPPED_CONFIGURATION_SPACE_ACCESS_TABLE_H_

// #include <IndustryStandard/Acpi.h>

//
// Ensure proper structure formats
//
// #pragma pack(1)

///
/// Memory Mapped Configuration Space Access Table (MCFG)
/// This table is a basic description table header followed by
/// a number of base address allocation structures.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_MEMORY_MAPPED_ENHANCED_CONFIGURATION_SPACE_BASE_ADDRESS_ALLOCATION_STRUCTURE
{
  public ulong BaseAddress;
  public ushort PciSegmentGroupNumber;
  public byte StartBusNumber;
  public byte EndBusNumber;
  public uint Reserved;
}

///
/// MCFG Table header definition.  The rest of the table
/// must be defined in a platform specific manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_MEMORY_MAPPED_CONFIGURATION_BASE_ADDRESS_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public ulong Reserved;
}

///
/// MCFG Revision (defined in spec)
///
public const ulong EFI_ACPI_MEMORY_MAPPED_CONFIGURATION_SPACE_ACCESS_TABLE_REVISION = 0x01;

// #pragma pack()

// #endif
