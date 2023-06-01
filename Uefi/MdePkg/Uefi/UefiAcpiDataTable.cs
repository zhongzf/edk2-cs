using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  UEFI ACPI Data Table Definition.

Copyright (c) 2011 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __UEFI_ACPI_DATA_TABLE_H__
// #define __UEFI_ACPI_DATA_TABLE_H__

// #include <IndustryStandard/Acpi.h>

// #pragma pack(1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_DATA_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public GUID Identifier;
  public ushort DataOffset;
}
// #pragma pack()

// #endif
