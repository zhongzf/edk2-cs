using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI Watchdog Action Table (WADT) as defined at
  Microsoft Hardware Watchdog Timers Design Specification.

  Copyright (c) 2008 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _WATCHDOG_ACTION_TABLE_H_
// #define _WATCHDOG_ACTION_TABLE_H_

// #include <IndustryStandard/Acpi.h>

//
// Ensure proper structure formats
//
// #pragma pack(1)
///
/// Watchdog Action Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_WATCHDOG_ACTION_1_0_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint WatchdogHeaderLength;
  public ushort PCISegment;
  public byte PCIBusNumber;
  public byte PCIDeviceNumber;
  public byte PCIFunctionNumber;
  public fixed byte Reserved_45[3];
  public uint TimerPeriod;
  public uint MaxCount;
  public uint MinCount;
  public byte WatchdogFlags;
  public fixed byte Reserved_61[3];
  public uint NumberWatchdogInstructionEntries;
}

///
/// Watchdog Instruction Entries
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_WATCHDOG_ACTION_1_0_WATCHDOG_ACTION_INSTRUCTION_ENTRY
{
  public byte WatchdogAction;
  public byte InstructionFlags;
  public fixed byte Reserved_2[2];
  public EFI_ACPI_2_0_GENERIC_ADDRESS_STRUCTURE RegisterRegion;
  public uint Value;
  public uint Mask;
}

// #pragma pack()

///
/// WDAT Revision (defined in spec)
///
public const ulong EFI_ACPI_WATCHDOG_ACTION_1_0_TABLE_REVISION = 0x01;

//
// WDAT 1.0 Flags
//
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ENABLED = 0x1;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_STOPPED_IN_SLEEP_STATE = 0x80;

//
// WDAT 1.0 Watchdog Actions
//
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_RESET = 0x1;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_QUERY_CURRENT_COUNTDOWN_PERIOD = 0x4;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_QUERY_COUNTDOWN_PERIOD = 0x5;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_SET_COUNTDOWN_PERIOD = 0x6;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_QUERY_RUNNING_STATE = 0x8;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_SET_RUNNING_STATE = 0x9;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_QUERY_STOPPED_STATE = 0xA;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_SET_STOPPED_STATE = 0xB;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_QUERY_REBOOT = 0x10;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_SET_REBOOT = 0x11;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_QUERY_SHUTDOWN = 0x12;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_SET_SHUTDOWN = 0x13;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_QUERY_WATCHDOG_STATUS = 0x20;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_ACTION_SET_WATCHDOG_STATUS = 0x21;

//
// WDAT 1.0 Watchdog Action Entry Instruction Flags
//
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_INSTRUCTION_READ_VALUE = 0x0;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_INSTRUCTION_READ_COUNTDOWN = 0x1;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_INSTRUCTION_WRITE_VALUE = 0x2;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_INSTRUCTION_WRITE_COUNTDOWN = 0x3;
public const ulong EFI_ACPI_WDAT_1_0_WATCHDOG_INSTRUCTION_PRESERVE_REGISTER = 0x80;

// #endif
