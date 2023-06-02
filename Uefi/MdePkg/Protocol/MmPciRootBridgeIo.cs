using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  MM PCI Root Bridge IO protocol as defined in the PI 1.5 specification.

  This protocol provides PCI I/O and memory access within MM.

  Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _MM_PCI_ROOT_BRIDGE_IO_H_
// #define _MM_PCI_ROOT_BRIDGE_IO_H_

// #include <Protocol/PciRootBridgeIo.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_MM_PCI_ROOT_BRIDGE_IO_PROTOCOL_GUID = new GUID(
      0x8bc1714d, 0xffcb, 0x41c3, new byte[] { 0x89, 0xdc, 0x6c, 0x74, 0xd0, 0x6d, 0x98, 0xea });
}

///
/// This protocol provides the same functionality as the PCI Root Bridge I/O Protocol defined in the
/// UEFI 2.1 Specifcation, section 13.2, except that the functions for Map() and Unmap() may return
/// EFI_UNSUPPORTED.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MM_PCI_ROOT_BRIDGE_IO_PROTOCOL { EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL Value; public static implicit operator EFI_MM_PCI_ROOT_BRIDGE_IO_PROTOCOL(EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL value) => new EFI_MM_PCI_ROOT_BRIDGE_IO_PROTOCOL() { Value = value }; public static implicit operator EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL(EFI_MM_PCI_ROOT_BRIDGE_IO_PROTOCOL value) => value.Value; }

// extern EFI_GUID  gEfiMmPciRootBridgeIoProtocolGuid;

// #endif
