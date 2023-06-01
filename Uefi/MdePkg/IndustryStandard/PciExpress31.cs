using System.Runtime.InteropServices;

namespace Uefi;
/** @file
Support for the PCI Express 3.1 standard.

This header file may not define all structures.  Please extend as required.

Copyright (c) 2016, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _PCIEXPRESS31_H_
// #define _PCIEXPRESS31_H_

// #include <IndustryStandard/PciExpress30.h>

// #pragma pack(1)

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_L1_PM_SUBSTATES_ID = 0x001E;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_L1_PM_SUBSTATES_VER1 = 0x1;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint PciPmL12 = 1;
  [FieldOffset(0)] public uint PciPmL11 = 1;
  [FieldOffset(0)] public uint AspmL12 = 1;
  [FieldOffset(0)] public uint AspmL11 = 1;
  [FieldOffset(0)] public uint L1PmSubstates = 1;
  [FieldOffset(0)] public uint Reserved = 3;
  [FieldOffset(0)] public uint CommonModeRestoreTime = 8;
  [FieldOffset(0)] public uint TPowerOnScale = 2;
  [FieldOffset(0)] public uint Reserved2 = 1;
  [FieldOffset(0)] public uint TPowerOnValue = 5;
  [FieldOffset(0)] public uint Reserved3 = 8;
}
uint Uint32;
} PCI_EXPRESS_REG_L1_PM_SUBSTATES_CAPABILITY;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint PciPmL12 = 1;
  [FieldOffset(0)] public uint PciPmL11 = 1;
  [FieldOffset(0)] public uint AspmL12 = 1;
  [FieldOffset(0)] public uint AspmL11 = 1;
  [FieldOffset(0)] public uint Reserved = 4;
  [FieldOffset(0)] public uint CommonModeRestoreTime = 8;
  [FieldOffset(0)] public uint LtrL12ThresholdValue = 10;
  [FieldOffset(0)] public uint Reserved2 = 3;
  [FieldOffset(0)] public uint LtrL12ThresholdScale = 3;
}
uint Uint32;
} PCI_EXPRESS_REG_L1_PM_SUBSTATES_CONTROL1;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint TPowerOnScale = 2;
  [FieldOffset(0)] public uint Reserved = 1;
  [FieldOffset(0)] public uint TPowerOnValue = 5;
  [FieldOffset(0)] public uint Reserved2 = 24;
}
uint Uint32;
} PCI_EXPRESS_REG_L1_PM_SUBSTATES_CONTROL2;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_L1_PM_SUBSTATES
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public PCI_EXPRESS_REG_L1_PM_SUBSTATES_CAPABILITY Capability;
  public PCI_EXPRESS_REG_L1_PM_SUBSTATES_CONTROL1 Control1;
  public PCI_EXPRESS_REG_L1_PM_SUBSTATES_CONTROL2 Control2;
}

// #pragma pack()

// #endif
