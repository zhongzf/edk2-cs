using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI Serial Port Console Redirection Table as defined by Microsoft in
  http://www.microsoft.com/whdc/system/platform/server/spcr.mspx

  Copyright (c) 2007 - 2018, Intel Corporation. All rights reserved.<BR>
  (C) Copyright 2015 Hewlett Packard Enterprise Development LP<BR>
  Copyright (c) 2014 - 2016, ARM Limited. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_H_
// #define _SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_H_

// #include <IndustryStandard/Acpi.h>

//
// Ensure proper structure formats
//
// #pragma pack(1)

///
/// SPCR Revision (defined in spec)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_REVISION = 0x02;
}

///
/// Serial Port Console Redirection Table Format
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public byte InterfaceType;
  public fixed byte Reserved1[3];
  public EFI_ACPI_5_0_GENERIC_ADDRESS_STRUCTURE BaseAddress;
  public byte InterruptType;
  public byte Irq;
  public uint GlobalSystemInterrupt;
  public byte BaudRate;
  public byte Parity;
  public byte StopBits;
  public byte FlowControl;
  public byte TerminalType;
  public byte Reserved2;
  public ushort PciDeviceId;
  public ushort PciVendorId;
  public byte PciBusNumber;
  public byte PciDeviceNumber;
  public byte PciFunctionNumber;
  public uint PciFlags;
  public byte PciSegment;
  public uint Reserved3;
}

// #pragma pack()

//
// SPCR Definitions
//

//
// Interface Type
//

///
/// Full 16550 interface
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERFACE_TYPE_16550 = 0;
  ///
  /// Full 16450 interface
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERFACE_TYPE_16450 = 1;

  //
  // The Serial Port Subtypes for ARM are documented in Table 3 of the DBG2 Specification
  //

  ///
  /// ARM PL011 UART
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERFACE_TYPE_ARM_PL011_UART = 0x03;

  ///
  /// NVIDIA 16550 UART
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERFACE_TYPE_NVIDIA_16550_UART = 0x05;

  ///
  /// ARM SBSA Generic UART (2.x) supporting 32-bit only accesses [deprecated]
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERFACE_TYPE_ARM_SBSA_GENERIC_UART_2X = 0x0d;

  ///
  /// ARM SBSA Generic UART
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERFACE_TYPE_ARM_SBSA_GENERIC_UART = 0x0e;

  ///
  /// ARM DCC
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERFACE_TYPE_DCC = 0x0f;

  ///
  /// BCM2835 UART
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERFACE_TYPE_BCM2835_UART = 0x10;

  ///
  /// 16550-compatible with parameters defined in Generic Address Structure
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERFACE_TYPE_16550_WITH_GAS = 0x12;

  //
  // Interrupt Type
  //

  ///
  /// PC-AT-compatible dual-8259 IRQ interrupt
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERRUPT_TYPE_8259 = 0x1;
  ///
  /// I/O APIC interrupt (Global System Interrupt)
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERRUPT_TYPE_APIC = 0x2;
  ///
  /// I/O SAPIC interrupt (Global System Interrupt)
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERRUPT_TYPE_SAPIC = 0x4;
  ///
  /// ARMH GIC interrupt (Global System Interrupt)
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_INTERRUPT_TYPE_GIC = 0x8;

  //
  // Baud Rate
  //
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_BAUD_RATE_9600 = 3;
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_BAUD_RATE_19200 = 4;
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_BAUD_RATE_57600 = 6;
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_BAUD_RATE_115200 = 7;

  //
  // Parity
  //
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_PARITY_NO_PARITY = 0;

  //
  // Stop Bits
  //
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_STOP_BITS_1 = 1;

  //
  // Flow Control
  //

  ///
  /// DCD required for transmit
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_FLOW_CONTROL_DCD = 0x1;
  ///
  /// RTS/CTS hardware flow control
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_FLOW_CONTROL_RTS_CTS = 0x2;
  ///
  ///  XON/XOFF software control
  ///
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_FLOW_CONTROL_XON_XOFF = 0x4;

  //
  // Terminal Type
  //
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_TERMINAL_TYPE_VT100 = 0;
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_TERMINAL_TYPE_VT100_PLUS = 1;
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_TERMINAL_TYPE_VT_UTF8 = 2;
  public const ulong EFI_ACPI_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_TERMINAL_TYPE_ANSI = 3;
}

// #endif
