using System.Runtime.InteropServices;

namespace Uefi;
/** @file
Support for the PCI Express 5.0 standard.

This header file may not define all structures.  Please extend as required.

Copyright (c) 2020, American Megatrends International LLC. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _PCIEXPRESS50_H_
// #define _PCIEXPRESS50_H_

// #include <IndustryStandard/PciExpress40.h>

// #pragma pack(1)

public unsafe partial class EFI
{
  /// The Physical Layer PCI Express Extended Capability definitions.
  ///
  /// Based on section 7.7.6 of PCI Express Base Specification 5.0.
  ///@{
  public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_PHYSICAL_LAYER_32_0_ID = 0x002A;
  public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_PHYSICAL_LAYER_32_0_VER1 = 0x1;

  // Register offsets from Physical Layer PCI-E Ext Cap Header
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_CAPABILITIES_OFFSET = 0x04;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_CONTROL_OFFSET = 0x08;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_STATUS_OFFSET = 0x0C;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_RCVD_MODIFIED_TS_DATA1_OFFSET = 0x10;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_RCVD_MODIFIED_TS_DATA2_OFFSET = 0x14;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_TRANS_MODIFIED_TS_DATA1_OFFSET = 0x18;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_TRANS_MODIFIED_TS_DATA2_OFFSET = 0x1C;
  public const ulong PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_LANE_EQUALIZATION_CONTROL_OFFSET = 0x20;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_CAPABILITIES
{
  /*   struct { */
  [FieldOffset(0)] public uint EqualizationByPassToHighestRateSupport; // = 1;               // bit 0
  [FieldOffset(0)] public uint NoEqualizationNeededSupport; // = 1;               // bit 1
  [FieldOffset(0)] public uint Reserved1; // = 6;               // Reserved bit 2:7
  [FieldOffset(0)] public uint ModifiedTSUsageMode0Support; // = 1;               // bit 8
  [FieldOffset(0)] public uint ModifiedTSUsageMode1Support; // = 1;               // bit 9
  [FieldOffset(0)] public uint ModifiedTSUsageMode2Support; // = 1;               // bit 10
  [FieldOffset(0)] public uint ModifiedTSReservedUsageModes; // = 5;               // bit 11:15
  [FieldOffset(0)] public uint Reserved2; // = 16;              // Reserved bit 16:31
  /*   } Bits; */
  [FieldOffset(0)] public uint Uint32;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_CONTROL
{
  /*   struct { */
  [FieldOffset(0)] public uint EqualizationByPassToHighestRateDisable; // = 1;               // bit 0
  [FieldOffset(0)] public uint NoEqualizationNeededDisable; // = 1;               // bit 1
  [FieldOffset(0)] public uint Reserved1; // = 6;               // Reserved bit 2:7
  [FieldOffset(0)] public uint ModifiedTSUsageModeSelected; // = 3;               // bit 8:10
  [FieldOffset(0)] public uint Reserved2; // = 21;              // Reserved bit 11:31
  /*   } Bits; */
  [FieldOffset(0)] public uint Uint32;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_STATUS
{
  /*   struct { */
  [FieldOffset(0)] public uint EqualizationComplete; // = 1;  // bit 0
  [FieldOffset(0)] public uint EqualizationPhase1Success; // = 1;  // bit 1
  [FieldOffset(0)] public uint EqualizationPhase2Success; // = 1;  // bit 2
  [FieldOffset(0)] public uint EqualizationPhase3Success; // = 1;  // bit 3
  [FieldOffset(0)] public uint LinkEqualizationRequest; // = 1;  // bit 4
  [FieldOffset(0)] public uint ModifiedTSRcvd; // = 1;  // bit 5
  [FieldOffset(0)] public uint RcvdEnhancedLinkControl; // = 2;  // bit 6:7
  [FieldOffset(0)] public uint TransmitterPrecodingOn; // = 1;  // bit 8
  [FieldOffset(0)] public uint TransmitterPrecodeRequest; // = 1;  // bit 9
  [FieldOffset(0)] public uint NoEqualizationNeededRcvd; // = 1;  // bit 10
  [FieldOffset(0)] public uint Reserved; // = 21; // Reserved bit 11:31
  /*   } Bits; */
  [FieldOffset(0)] public uint Uint32;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_RCVD_MODIFIED_TS_DATA1
{
  /*   struct { */
  [FieldOffset(0)] public uint RcvdModifiedTSUsageMode; // = 3;  // bit 0:2
  [FieldOffset(0)] public uint RcvdModifiedTSUsageInfo1; // = 13; // bit 3:15
  [FieldOffset(0)] public uint RcvdModifiedTSVendorId; // = 16; // bit 16:31
  /*   } Bits; */
  [FieldOffset(0)] public uint Uint32;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_RCVD_MODIFIED_TS_DATA2
{
  /*   struct { */
  [FieldOffset(0)] public uint RcvdModifiedTSUsageInfo2; // = 24; // bit 0:23
  [FieldOffset(0)] public uint AltProtocolNegotiationStatus; // = 2;  // bit 24:25
  [FieldOffset(0)] public uint Reserved; // = 6;  // Reserved bit 26:31
  /*   } Bits; */
  [FieldOffset(0)] public uint Uint32;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_TRANS_MODIFIED_TS_DATA1
{
  /*   struct { */
  [FieldOffset(0)] public uint TransModifiedTSUsageMode; // = 3;  // bit 0:2
  [FieldOffset(0)] public uint TransModifiedTSUsageInfo1; // = 13; // bit 3:15
  [FieldOffset(0)] public uint TransModifiedTSVendorId; // = 16; // bit 16:31
  /*   } Bits; */
  [FieldOffset(0)] public uint Uint32;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_TRANS_MODIFIED_TS_DATA2
{
  /*   struct { */
  [FieldOffset(0)] public uint TransModifiedTSUsageInfo2; // = 24; // bit 0:23
  [FieldOffset(0)] public uint AltProtocolNegotiationStatus; // = 2;  // bit 24:25
  [FieldOffset(0)] public uint Reserved; // = 6;  // Reserved bit 26:31
  /*   } Bits; */
  [FieldOffset(0)] public uint Uint32;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_LANE_EQUALIZATION_CONTROL
{
  /*   struct { */
  [FieldOffset(0)] public byte DownstreamPortTransmitterPreset; // = 4; // bit 0..3
  [FieldOffset(0)] public byte UpstreamPortTransmitterPreset; // = 4; // bit 4..7
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_PHYSICAL_LAYER_32_0
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_CAPABILITIES Capablities;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_CONTROL Control;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_STATUS Status;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_RCVD_MODIFIED_TS_DATA1 RcvdModifiedTs1Data;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_RCVD_MODIFIED_TS_DATA2 RcvdModifiedTs2Data;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_TRANS_MODIFIED_TS_DATA1 TransModifiedTs1Data;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_TRANS_MODIFIED_TS_DATA2 TransModifiedTs2Data;
  public PCI_EXPRESS_REG_PHYSICAL_LAYER_32_0_LANE_EQUALIZATION_CONTROL[/*1*/] LaneEqualizationControl;
}
///@}

// #pragma pack()

// #endif
