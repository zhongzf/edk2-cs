using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  TPM2 ACPI table definition.

Copyright (c) 2013 - 2019, Intel Corporation. All rights reserved. <BR>
Copyright (c) 2021, Ampere Computing LLC. All rights reserved. <BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _TPM2_ACPI_H_
// #define _TPM2_ACPI_H_

// #include <IndustryStandard/Acpi.h>

// #pragma pack (1)

public const ulong EFI_TPM2_ACPI_TABLE_REVISION_3 = 3;
public const ulong EFI_TPM2_ACPI_TABLE_REVISION_4 = 4;
public const ulong EFI_TPM2_ACPI_TABLE_REVISION = EFI_TPM2_ACPI_TABLE_REVISION_4;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TPM2_ACPI_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  // Flags field is replaced in version 4 and above
  //    BIT0~15:  PlatformClass      This field is only valid for version 4 and above
  //    BIT16~31: Reserved
  public uint Flags;
  public ulong AddressOfControlArea;
  public uint StartMethod;
  // byte                       PlatformSpecificParameters[];  // size up to 12
  // uint                      Laml;                          // Optional
  // ulong                      Lasa;                          // Optional
}

public const ulong EFI_TPM2_ACPI_TABLE_START_METHOD_ACPI = 2;
public const ulong EFI_TPM2_ACPI_TABLE_START_METHOD_TIS = 6;
public const ulong EFI_TPM2_ACPI_TABLE_START_METHOD_COMMAND_RESPONSE_BUFFER_INTERFACE = 7;
public const ulong EFI_TPM2_ACPI_TABLE_START_METHOD_COMMAND_RESPONSE_BUFFER_INTERFACE_WITH_ACPI = 8;
public const ulong EFI_TPM2_ACPI_TABLE_START_METHOD_COMMAND_RESPONSE_BUFFER_INTERFACE_WITH_SMC = 11;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TPM2_ACPI_CONTROL_AREA
{
  public uint Reserved;
  public uint Error;
  public uint Cancel;
  public uint Start;
  public ulong InterruptControl;
  public uint CommandSize;
  public ulong Command;
  public uint ResponseSize;
  public ulong Response;
}

//
// Start Method Specific Parameters for ARM SMC Start Method (11)
// Refer to Table 9: Start Method Specific Parameters for ARM SMC
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TPM2_ACPI_START_METHOD_SPECIFIC_PARAMETERS_ARM_SMC
{
  public uint Interrupt;
  public byte Flags;
  public byte OperationFlags;
  public fixed byte Reserved[2];
  public uint SmcFunctionId;
}

// #pragma pack ()

// #endif
