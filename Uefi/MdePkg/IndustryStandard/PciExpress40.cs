using System.Runtime.InteropServices;

namespace Uefi;
/** @file
Support for the PCI Express 4.0 standard.

This header file may not define all structures.  Please extend as required.

Copyright (c) 2018, American Megatrends, Inc. All rights reserved.<BR>
Copyright (c) 2020, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _PCIEXPRESS40_H_
// #define _PCIEXPRESS40_H_

// #include <IndustryStandard/PciExpress31.h>

// #pragma pack(1)

/// The Physical Layer PCI Express Extended Capability definitions.
///
/// Based on section 7.7.5 of PCI Express Base Specification 4.0.
///@{
public unsafe partial class EFI
{
  public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_PHYSICAL_LAYER_16_0_ID = 0x0026;
  public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_PHYSICAL_LAYER_16_0_VER1 = 0x1;

  // Register offsets from Physical Layer PCI-E Ext Cap Header
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_CAPABILITIES_OFFSET = 0x04;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_CONTROL_OFFSET = 0x08;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_STATUS_OFFSET = 0x0C;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_LOCAL_DATA_PARITY_STATUS_OFFSET = 0x10;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_FIRST_RETIMER_DATA_PARITY_STATUS_OFFSET = 0x14;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_SECOND_RETIMER_DATA_PARITY_STATUS_OFFSET = 0x18;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_LANE_EQUALIZATION_CONTROL_OFFSET = 0x20;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint Reserved = 32;               // Reserved bit 0:31
}
uint Uint32;
} PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_CAPABILITIES;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint Reserved = 32;               // Reserved bit 0:31
}
uint Uint32;
} PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_CONTROL;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint EqualizationComplete = 1;  // bit 0
  [FieldOffset(0)] public uint EqualizationPhase1Success = 1;  // bit 1
  [FieldOffset(0)] public uint EqualizationPhase2Success = 1;  // bit 2
  [FieldOffset(0)] public uint EqualizationPhase3Success = 1;  // bit 3
  [FieldOffset(0)] public uint LinkEqualizationRequest = 1;  // bit 4
  [FieldOffset(0)] public uint Reserved = 27; // Reserved bit 5:31
}
uint Uint32;
} PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte DownstreamPortTransmitterPreset = 4; // bit 0..3
  [FieldOffset(0)] public byte UpstreamPortTransmitterPreset = 4; // bit 4..7
}
byte Uint8;
} PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_LANE_EQUALIZATION_CONTROL;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_PHYSICAL_LAYER_16_0
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_CAPABILITIES Capablities;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_CONTROL Control;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_STATUS Status;
  public uint LocalDataParityMismatchStatus;
  public uint FirstRetimerDataParityMismatchStatus;
  public uint SecondRetimerDataParityMismatchStatus;
  public uint Reserved;
  public fixed PCI_EXPRESS_REG_PHYSICAL_LAYER_16_0_LANE_EQUALIZATION_CONTROL LaneEqualizationControl[1];
}
///@}

/// The Designated Vendor Specific Capability definitions
/// Based on section 7.9.6 of PCI Express Base Specification 4.0.
///@{
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint DvsecVendorId = 16;                                     // bit 0..15
  [FieldOffset(0)] public uint DvsecRevision = 4;                                      // bit 16..19
  [FieldOffset(0)] public uint DvsecLength = 12;                                     // bit 20..31
}
uint Uint32;
} PCI_EXPRESS_DESIGNATED_VENDOR_SPECIFIC_HEADER_1;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort DvsecId = 16;                                           // bit 0..15
}
ushort Uint16;
} PCI_EXPRESS_DESIGNATED_VENDOR_SPECIFIC_HEADER_2;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_DESIGNATED_VENDOR_SPECIFIC
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public PCI_EXPRESS_DESIGNATED_VENDOR_SPECIFIC_HEADER_1 DesignatedVendorSpecificHeader1;
  public PCI_EXPRESS_DESIGNATED_VENDOR_SPECIFIC_HEADER_2 DesignatedVendorSpecificHeader2;
  public fixed byte DesignatedVendorSpecific[1];
}
///@}

// #pragma pack()

// #endif
