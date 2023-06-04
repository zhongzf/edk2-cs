using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI high precision event timer table definition, at www.intel.com
  Specification name is IA-PC HPET (High Precision Event Timers) Specification.

  Copyright (c) 2007 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _HIGH_PRECISION_EVENT_TIMER_TABLE_H_
// #define _HIGH_PRECISION_EVENT_TIMER_TABLE_H_

// #include <IndustryStandard/Acpi.h>

//
// Ensure proper structure formats
//
// #pragma pack(1)

///
/// HPET Event Timer Block ID described in IA-PC HPET Specification, 3.2.4.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_ACPI_HIGH_PRECISION_EVENT_TIMER_BLOCK_ID
{
  /*   struct { */
  [FieldOffset(0)] public uint Revision; // = 8;
  [FieldOffset(0)] public uint NumberOfTimers; // = 5;
  [FieldOffset(0)] public uint CounterSize; // = 1;
  [FieldOffset(0)] public uint Reserved; // = 1;
  [FieldOffset(0)] public uint LegacyRoute; // = 1;
  [FieldOffset(0)] public uint VendorId; // = 16;
  /*   }      Bits; */
  [FieldOffset(0)] public uint Uint32;
}

///
/// High Precision Event Timer Table header definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_HIGH_PRECISION_EVENT_TIMER_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint EventTimerBlockId;
  public EFI_ACPI_2_0_GENERIC_ADDRESS_STRUCTURE BaseAddressLower32Bit;
  public byte HpetNumber;
  public ushort MainCounterMinimumClockTickInPeriodicMode;
  public byte PageProtectionAndOemAttribute;
}

public unsafe partial class EFI
{
  ///
  /// HPET Revision (defined in spec)
  ///
  public const ulong EFI_ACPI_HIGH_PRECISION_EVENT_TIMER_TABLE_REVISION = 0x01;

  //
  // Page protection setting
  // Values 3 through 15 are reserved for use by the specification
  //
  public const ulong EFI_ACPI_NO_PAGE_PROTECTION = 0;
  public const ulong EFI_ACPI_4KB_PAGE_PROTECTION = 1;
  public const ulong EFI_ACPI_64KB_PAGE_PROTECTION = 2;

  // #pragma pack()
}

// #endif
