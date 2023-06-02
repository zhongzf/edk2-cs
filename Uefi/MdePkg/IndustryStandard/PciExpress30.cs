using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Support for the PCI Express 3.0 standard.

  This header file may not define all structures.  Please extend as required.

  Copyright (c) 2014 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _PCIEXPRESS30_H_
// #define _PCIEXPRESS30_H_

// #include <IndustryStandard/PciExpress21.h>

// #pragma pack(1)

public unsafe partial class EFI
{
  public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_SECONDARY_PCIE_ID = 0x0019;
  public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_SECONDARY_PCIE_VER1 = 0x1;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint PerformEqualization = 1;
  [FieldOffset(0)] public uint LinkEqualizationRequestInterruptEnable = 1;
  [FieldOffset(0)] public uint Reserved = 30;
}
uint Uint32;
} PCI_EXPRESS_REG_LINK_CONTROL3;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort DownstreamPortTransmitterPreset = 4;
  [FieldOffset(0)] public ushort DownstreamPortReceiverPresetHint = 3;
  [FieldOffset(0)] public ushort Reserved = 1;
  [FieldOffset(0)] public ushort UpstreamPortTransmitterPreset = 4;
  [FieldOffset(0)] public ushort UpstreamPortReceiverPresetHint = 3;
  [FieldOffset(0)] public ushort Reserved2 = 1;
}
ushort Uint16;
} PCI_EXPRESS_REG_LANE_EQUALIZATION_CONTROL;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_SECONDARY_PCIE
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public PCI_EXPRESS_REG_LINK_CONTROL3 LinkControl3;
  public uint LaneErrorStatus;
  public fixed PCI_EXPRESS_REG_LANE_EQUALIZATION_CONTROL EqualizationControl[2];
}

// #pragma pack()

// #endif
