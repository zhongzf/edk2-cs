using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI debug port 2 table definition, defined at
  Microsoft DebugPort2Specification.

  Copyright (c) 2012 - 2018, Intel Corporation. All rights reserved.<BR>
  Copyright (c) 2012 - 2016, ARM Limited. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _DEBUG_PORT_2_TABLE_H_
// #define _DEBUG_PORT_2_TABLE_H_

// #include <IndustryStandard/Acpi.h>

//
// Ensure proper structure formats
//
// #pragma pack(1)

//
// Debug Device Information structure.
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_DBG2_DEBUG_DEVICE_INFORMATION_STRUCT
{
  public byte Revision;
  public ushort Length;
  public byte NumberofGenericAddressRegisters;
  public ushort NameSpaceStringLength;
  public ushort NameSpaceStringOffset;
  public ushort OemDataLength;
  public ushort OemDataOffset;
  public ushort PortType;
  public ushort PortSubtype;
  public fixed byte Reserved[2];
  public ushort BaseAddressRegisterOffset;
  public ushort AddressSizeOffset;
}

public unsafe partial class EFI
{
  public const ulong EFI_ACPI_DBG2_DEBUG_DEVICE_INFORMATION_STRUCT_REVISION = 0x00;

  public const ulong EFI_ACPI_DBG2_PORT_TYPE_SERIAL = 0x8000;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_SERIAL_FULL_16550 = 0x0000;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_SERIAL_16550_SUBSET_COMPATIBLE_WITH_MS_DBGP_SPEC = 0x0001;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_SERIAL_ARM_PL011_UART = 0x0003;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_SERIAL_NVIDIA_16550_UART = 0x0005;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_SERIAL_ARM_SBSA_GENERIC_UART_2X = 0x000d;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_SERIAL_ARM_SBSA_GENERIC_UART = 0x000e;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_SERIAL_DCC = 0x000f;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_SERIAL_BCM2835_UART = 0x0010;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_SERIAL_16550_WITH_GAS = 0x0012;
  public const ulong EFI_ACPI_DBG2_PORT_TYPE_1394 = 0x8001;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_1394_STANDARD = 0x0000;
  public const ulong EFI_ACPI_DBG2_PORT_TYPE_USB = 0x8002;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_USB_XHCI = 0x0000;
  public const ulong EFI_ACPI_DBG2_PORT_SUBTYPE_USB_EHCI = 0x0001;
  public const ulong EFI_ACPI_DBG2_PORT_TYPE_NET = 0x8003;
}

//
// Debug Port 2 Table definition.
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_DEBUG_PORT_2_DESCRIPTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint OffsetDbgDeviceInfo;
  public uint NumberDbgDeviceInfo;
}

// #pragma pack()

//
// DBG2 Revision (defined in spec)
//
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_DEBUG_PORT_2_TABLE_REVISION = 0x00;
}

// #endif
