using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file declares EFI PCI Override protocol which provides the interface between
  the PCI bus driver/PCI Host Bridge Resource Allocation driver and an implementation's
  driver to describe the unique features of a platform.
  This protocol is optional.

  Copyright (c) 2009, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is defined in UEFI Platform Initialization Specification 1.2
  Volume 5: Standards

**/

// #ifndef _PCI_OVERRIDE_H_
// #define _PCI_OVERRIDE_H_

///
/// EFI_PCI_OVERRIDE_PROTOCOL has the same structure with EFI_PCI_PLATFORM_PROTOCOL
///
// #include <Protocol/PciPlatform.h>

///
/// Global ID for the EFI_PCI_OVERRIDE_PROTOCOL
///
public unsafe partial class EFI
{
  public static EFI_GUID EFI_PCI_OVERRIDE_GUID = new GUID(
      0xb5b35764, 0x460c, 0x4a06, new byte[] { 0x99, 0xfc, 0x77, 0xa1, 0x7c, 0x1b, 0x5c, 0xeb });
}

///
/// Declaration for EFI_PCI_OVERRIDE_PROTOCOL
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_OVERRIDE_PROTOCOL { EFI_PCI_PLATFORM_PROTOCOL Value; public static implicit operator EFI_PCI_OVERRIDE_PROTOCOL(EFI_PCI_PLATFORM_PROTOCOL value) => new EFI_PCI_OVERRIDE_PROTOCOL() { Value = value }; public static implicit operator EFI_PCI_PLATFORM_PROTOCOL(EFI_PCI_OVERRIDE_PROTOCOL value) => value.Value; }

// extern EFI_GUID  gEfiPciOverrideProtocolGuid;

// #endif
