using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Defines Windows SMM Security Mitigation Table
  @ https://msdn.microsoft.com/windows/hardware/drivers/bringup/acpi-system-description-tables#wsmt

  Copyright (c) 2016 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _WINDOWS_SMM_SECURITY_MITIGATION_TABLE_H_
// #define _WINDOWS_SMM_SECURITY_MITIGATION_TABLE_H_

// #include <IndustryStandard/Acpi.h>

public unsafe partial class EFI
{
  //public const ulong EFI_ACPI_WINDOWS_SMM_SECURITY_MITIGATION_TABLE_SIGNATURE = SIGNATURE_32('W', 'S', 'M', 'T');

  // #pragma pack(1)

  public const ulong EFI_WSMT_TABLE_REVISION = 1;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_WSMT_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint ProtectionFlags;
}

public unsafe partial class EFI
{
  public const ulong EFI_WSMT_PROTECTION_FLAGS_FIXED_COMM_BUFFERS = 0x1;
  public const ulong EFI_WSMT_PROTECTION_FLAGS_COMM_BUFFER_NESTED_PTR_PROTECTION = 0x2;
  public const ulong EFI_WSMT_PROTECTION_FLAGS_SYSTEM_RESOURCE_PROTECTION = 0x4;

  // #pragma pack()
}

// #endif
