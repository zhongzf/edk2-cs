using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Support for PCI 2.3 standard.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _PCI23_H_
// #define _PCI23_H_

// #include <IndustryStandard/Pci22.h>

public unsafe partial class EFI
{
  ///
  /// PCI_CLASS_MASS_STORAGE, Base Class 01h.
  ///
  ///@{
  public const ulong PCI_CLASS_MASS_STORAGE_ATA = 0x05;
  public const ulong PCI_IF_MASS_STORAGE_SINGLE_DMA = 0x20;
  public const ulong PCI_IF_MASS_STORAGE_CHAINED_DMA = 0x30;
  ///@}

  ///
  /// PCI_CLASS_NETWORK, Base Class 02h.
  ///
  ///@{
  public const ulong PCI_CLASS_NETWORK_WORLDFIP = 0x05;
  public const ulong PCI_CLASS_NETWORK_PICMG_MULTI_COMPUTING = 0x06;
  ///@}

  ///
  /// PCI_CLASS_BRIDGE, Base Class 06h.
  ///
  ///@{
  public const ulong PCI_CLASS_BRIDGE_SEMI_TRANSPARENT_P2P = 0x09;
  public const ulong PCI_IF_BRIDGE_SEMI_TRANSPARENT_P2P_PRIMARY = 0x40;
  public const ulong PCI_IF_BRIDGE_SEMI_TRANSPARENT_P2P_SECONDARY = 0x80;
  public const ulong PCI_CLASS_BRIDGE_INFINIBAND_TO_PCI = 0x0A;
  ///@}

  ///
  /// PCI_CLASS_SCC, Base Class 07h.
  ///
  ///@{
  public const ulong PCI_SUBCLASS_GPIB = 0x04;
  public const ulong PCI_SUBCLASS_SMART_CARD = 0x05;
  ///@}

  ///
  /// PCI_CLASS_SERIAL, Base Class 0Ch.
  ///
  ///@{
  public const ulong PCI_IF_EHCI = 0x20;
  public const ulong PCI_CLASS_SERIAL_IB = 0x06;
  public const ulong PCI_CLASS_SERIAL_IPMI = 0x07;
  public const ulong PCI_IF_IPMI_SMIC = 0x00;
  public const ulong PCI_IF_IPMI_KCS = 0x01; /// < Keyboard Controller Style
  public const ulong PCI_IF_IPMI_BT = 0x02; /// < Block Transfer
  public const ulong PCI_CLASS_SERIAL_SERCOS = 0x08;
  public const ulong PCI_CLASS_SERIAL_CANBUS = 0x09;
  ///@}

  ///
  /// PCI_CLASS_WIRELESS, Base Class 0Dh.
  ///
  ///@{
  public const ulong PCI_SUBCLASS_BLUETOOTH = 0x11;
  public const ulong PCI_SUBCLASS_BROADBAND = 0x12;
  ///@}

  ///
  /// PCI_CLASS_DPIO, Base Class 11h.
  ///
  ///@{
  public const ulong PCI_SUBCLASS_PERFORMANCE_COUNTERS = 0x01;
  public const ulong PCI_SUBCLASS_COMMUNICATION_SYNCHRONIZATION = 0x10;
  public const ulong PCI_SUBCLASS_MANAGEMENT_CARD = 0x20;
  ///@}

  ///
  /// defined in PCI Express Spec.
  ///
  public const ulong PCI_EXP_MAX_CONFIG_OFFSET = 0x1000;

  ///
  /// PCI Capability List IDs and records.
  ///
  public const ulong EFI_PCI_CAPABILITY_ID_PCIX = 0x07;
  public const ulong EFI_PCI_CAPABILITY_ID_VENDOR = 0x09;
}

// #pragma pack(1)
///
/// PCI-X Capabilities List,
/// Section 7.2, PCI-X Addendum to the PCI Local Bus Specification, Revision 1.0b.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_CAPABILITY_PCIX
{
  public EFI_PCI_CAPABILITY_HDR Hdr;
  public ushort CommandReg;
  public uint StatusReg;
}

///
/// PCI-X Bridge Capabilities List,
/// Section 8.6.2, PCI-X Addendum to the PCI Local Bus Specification, Revision 1.0b.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_CAPABILITY_PCIX_BRDG
{
  public EFI_PCI_CAPABILITY_HDR Hdr;
  public ushort SecStatusReg;
  public uint StatusReg;
  public uint SplitTransCtrlRegUp;
  public uint SplitTransCtrlRegDn;
}

///
/// Vendor Specific Capability Header
/// Table H-1: Capability IDs, PCI Local Bus Specification, 2.3
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_CAPABILITY_VENDOR_HDR
{
  public EFI_PCI_CAPABILITY_HDR Hdr;
  public byte Length;
}

// #pragma pack()

public unsafe partial class EFI
{
  public const ulong PCI_CODE_TYPE_EFI_IMAGE = 0x03;
}

// #endif
