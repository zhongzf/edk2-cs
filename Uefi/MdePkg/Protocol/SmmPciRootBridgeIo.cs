using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  SMM PCI Root Bridge IO protocol as defined in the PI 1.2 specification.

  This protocol provides PCI I/O and memory access within SMM.

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _SMM_PCI_ROOT_BRIDGE_IO_H_
// #define _SMM_PCI_ROOT_BRIDGE_IO_H_

// #include <Protocol/MmPciRootBridgeIo.h>

public const ulong EFI_SMM_PCI_ROOT_BRIDGE_IO_PROTOCOL_GUID = EFI_MM_PCI_ROOT_BRIDGE_IO_PROTOCOL_GUID;

///
/// This protocol provides the same functionality as the PCI Root Bridge I/O Protocol defined in the
/// UEFI 2.1 Specifcation, section 13.2, except that the functions for Map() and Unmap() may return
/// EFI_UNSUPPORTED.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_PCI_ROOT_BRIDGE_IO_PROTOCOL { EFI_MM_PCI_ROOT_BRIDGE_IO_PROTOCOL Value; public static implicit operator EFI_SMM_PCI_ROOT_BRIDGE_IO_PROTOCOL(EFI_MM_PCI_ROOT_BRIDGE_IO_PROTOCOL value) => new EFI_SMM_PCI_ROOT_BRIDGE_IO_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_PCI_ROOT_BRIDGE_IO_PROTOCOL(EFI_SMM_PCI_ROOT_BRIDGE_IO_PROTOCOL value) => value.Value; }

// extern EFI_GUID  gEfiSmmPciRootBridgeIoProtocolGuid;

// #endif
