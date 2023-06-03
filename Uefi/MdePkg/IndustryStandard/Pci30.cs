using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Support for PCI 3.0 standard.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __PCI30_H__
// #define __PCI30_H__

// #include <IndustryStandard/Pci23.h>

public unsafe partial class EFI
{
  ///
  /// PCI_CLASS_MASS_STORAGE, Base Class 01h.
  ///
  ///@{
  public const ulong PCI_CLASS_MASS_STORAGE_SATADPA = 0x06;
  public const ulong PCI_IF_MASS_STORAGE_SATA = 0x00;
  public const ulong PCI_IF_MASS_STORAGE_AHCI = 0x01;
  ///@}

  ///
  /// PCI_CLASS_WIRELESS, Base Class 0Dh.
  ///
  ///@{
  public const ulong PCI_SUBCLASS_ETHERNET_80211A = 0x20;
  public const ulong PCI_SUBCLASS_ETHERNET_80211B = 0x21;
  ///@}

  /**
    Macro that checks whether device is a SATA controller.

    @param  _p      Specified device.

    @retval TRUE    Device is a SATA controller.
    @retval FALSE   Device is not a SATA controller.

  **/
  //public const ulong IS_PCI_SATADPA = (_p)IS_CLASS2(_p, PCI_CLASS_MASS_STORAGE, PCI_CLASS_MASS_STORAGE_SATADPA);

  ///
  /// PCI Capability List IDs and records
  ///
  public const ulong EFI_PCI_CAPABILITY_ID_PCIEXP = 0x10;

  // #pragma pack(1)
}

///
/// PCI Data Structure Format
/// Section 5.1.2, PCI Firmware Specification, Revision 3.0
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_3_0_DATA_STRUCTURE
{
  public uint Signature;  ///< "PCIR"
  public ushort VendorId;
  public ushort DeviceId;
  public ushort DeviceListOffset;
  public ushort Length;
  public byte Revision;
  public fixed byte ClassCode[3];
  public ushort ImageLength;
  public ushort CodeRevision;
  public byte CodeType;
  public byte Indicator;
  public ushort MaxRuntimeImageLength;
  public ushort ConfigUtilityCodeHeaderOffset;
  public ushort DMTFCLPEntryPointOffset;
}

// #pragma pack()

// #endif
