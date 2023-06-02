using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  CXL 1.1 Register definitions

  This file contains the register definitions based on the Compute Express Link
  (CXL) Specification Revision 1.1.

Copyright (c) 2020, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _CXL11_H_
// #define _CXL11_H_

// #include <IndustryStandard/Pci.h>
//
// DVSEC Vendor ID
// Compute Express Link Specification Revision: 1.1 - Chapter 7.1.1 - Table 58
// (subject to change as per CXL assigned Vendor ID)
//
public unsafe partial class EFI
{
  public const ulong INTEL_CXL_DVSEC_VENDOR_ID = 0x8086;

  //
  // CXL Flex Bus Device default device and function number
  // Compute Express Link Specification Revision: 1.1 - Chapter 7.1.1
  //
  public const ulong CXL_DEV_DEV = 0;
  public const ulong CXL_DEV_FUNC = 0;

  //
  // Ensure proper structure formats
  //
  // #pragma pack(1)

  /**
    Macro used to verify the size of a data type at compile time and trigger a
    STATIC_ASSERT() with an error message if the size of the data type does not
    match the expected size.

    @param  TypeName      Type name of data type to verify.
    @param  ExpectedSize  The expected size, in bytes, of the data type specified
                          by TypeName.
  **/
  public const ulong CXL_11_SIZE_ASSERT = (TypeName, ExpectedSize)        \;
  STATIC_ASSERT(                                         \
    sizeof (TypeName) == ExpectedSize,                    \
    "Size of " #TypeName                                  \
    " does not meet CXL 1.1 Specification requirements."  \
    )

/**
  Macro used to verify the offset of a field in a data type at compile time and
  trigger a STATIC_ASSERT() with an error message if the offset of the field in
  the data type does not match the expected offset.

  @param  TypeName        Type name of data type to verify.
  @param  FieldName       Field name in the data type specified by TypeName to
                          verify.
  @param  ExpectedOffset  The expected offset, in bytes, of the field specified
                          by TypeName and FieldName.
**/
public const ulong CXL_11_OFFSET_ASSERT = (TypeName, FieldName, ExpectedOffset)  \;
  STATIC_ASSERT(                                                  \
    OFFSET_OF (TypeName, FieldName) == ExpectedOffset,             \
    "Offset of " #TypeName "." #FieldName                          \
    " does not meet CXL 1.1 Specification requirements."           \
    )
}

///
/// The PCIe DVSEC for Flex Bus Device
///@{
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CacheCapable = 1;                                     // bit 0
  [FieldOffset(0)] public ushort IoCapable = 1;                                     // bit 1
  [FieldOffset(0)] public ushort MemCapable = 1;                                     // bit 2
  [FieldOffset(0)] public ushort MemHwInitMode = 1;                                     // bit 3
  [FieldOffset(0)] public ushort HdmCount = 2;                                     // bit 4..5
  [FieldOffset(0)] public ushort Reserved1 = 8;                                     // bit 6..13
  [FieldOffset(0)] public ushort ViralCapable = 1;                                     // bit 14
  [FieldOffset(0)] public ushort Reserved2 = 1;                                     // bit 15
}
ushort Uint16;
} CXL_DVSEC_FLEX_BUS_DEVICE_CAPABILITY;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CacheEnable = 1;                                // bit 0
  [FieldOffset(0)] public ushort IoEnable = 1;                                // bit 1
  [FieldOffset(0)] public ushort MemEnable = 1;                                // bit 2
  [FieldOffset(0)] public ushort CacheSfCoverage = 5;                                // bit 3..7
  [FieldOffset(0)] public ushort CacheSfGranularity = 3;                                // bit 8..10
  [FieldOffset(0)] public ushort CacheCleanEviction = 1;                                // bit 11
  [FieldOffset(0)] public ushort Reserved1 = 2;                                // bit 12..13
  [FieldOffset(0)] public ushort ViralEnable = 1;                                // bit 14
  [FieldOffset(0)] public ushort Reserved2 = 1;                                // bit 15
}
ushort Uint16;
} CXL_DVSEC_FLEX_BUS_DEVICE_CONTROL;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort Reserved1 = 14;                                       // bit 0..13
  [FieldOffset(0)] public ushort ViralStatus = 1;                                        // bit 14
  [FieldOffset(0)] public ushort Reserved2 = 1;                                        // bit 15
}
ushort Uint16;
} CXL_DVSEC_FLEX_BUS_DEVICE_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort Reserved1 = 1;                                          // bit 0
  [FieldOffset(0)] public ushort Reserved2 = 1;                                          // bit 1
  [FieldOffset(0)] public ushort Reserved3 = 1;                                          // bit 2
  [FieldOffset(0)] public ushort Reserved4 = 13;                                         // bit 3..15
}
ushort Uint16;
} CXL_1_1_DVSEC_FLEX_BUS_DEVICE_CONTROL2;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort Reserved1 = 1;                                          // bit 0
  [FieldOffset(0)] public ushort Reserved2 = 1;                                          // bit 1
  [FieldOffset(0)] public ushort Reserved3 = 14;                                         // bit 2..15
}
ushort Uint16;
} CXL_1_1_DVSEC_FLEX_BUS_DEVICE_STATUS2;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort ConfigLock = 1;                                         // bit 0
  [FieldOffset(0)] public ushort Reserved1 = 15;                                        // bit 1..15
}
ushort Uint16;
} CXL_DVSEC_FLEX_BUS_DEVICE_LOCK;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint MemorySizeHigh = 32;                                    // bit 0..31
}
uint Uint32;
} CXL_DVSEC_FLEX_BUS_DEVICE_RANGE1_SIZE_HIGH;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint MemoryInfoValid = 1;                                  // bit 0
  [FieldOffset(0)] public uint MemoryActive = 1;                                  // bit 1
  [FieldOffset(0)] public uint MediaType = 3;                                  // bit 2..4
  [FieldOffset(0)] public uint MemoryClass = 3;                                  // bit 5..7
  [FieldOffset(0)] public uint DesiredInterleave = 3;                                  // bit 8..10
  [FieldOffset(0)] public uint Reserved = 17;                                 // bit 11..27
  [FieldOffset(0)] public uint MemorySizeLow = 4;                                  // bit 28..31
}
uint Uint32;
} CXL_DVSEC_FLEX_BUS_DEVICE_RANGE1_SIZE_LOW;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint MemoryBaseHigh = 32;                                    // bit 0..31
}
uint Uint32;
} CXL_DVSEC_FLEX_BUS_DEVICE_RANGE1_BASE_HIGH;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint Reserved = 28;                                     // bit 0..27
  [FieldOffset(0)] public uint MemoryBaseLow = 4;                                      // bit 28..31
}
uint Uint32;
} CXL_DVSEC_FLEX_BUS_DEVICE_RANGE1_BASE_LOW;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint MemorySizeHigh = 32;                                    // bit 0..31
}
uint Uint32;
} CXL_DVSEC_FLEX_BUS_DEVICE_RANGE2_SIZE_HIGH;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint MemoryInfoValid = 1;                                  // bit 0
  [FieldOffset(0)] public uint MemoryActive = 1;                                  // bit 1
  [FieldOffset(0)] public uint MediaType = 3;                                  // bit 2..4
  [FieldOffset(0)] public uint MemoryClass = 3;                                  // bit 5..7
  [FieldOffset(0)] public uint DesiredInterleave = 3;                                  // bit 8..10
  [FieldOffset(0)] public uint Reserved = 17;                                 // bit 11..27
  [FieldOffset(0)] public uint MemorySizeLow = 4;                                  // bit 28..31
}
uint Uint32;
} CXL_DVSEC_FLEX_BUS_DEVICE_RANGE2_SIZE_LOW;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint MemoryBaseHigh = 32;                                    // bit 0..31
}
uint Uint32;
} CXL_DVSEC_FLEX_BUS_DEVICE_RANGE2_BASE_HIGH;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint Reserved = 28;                                     // bit 0..27
  [FieldOffset(0)] public uint MemoryBaseLow = 4;                                      // bit 28..31
}
uint Uint32;
} CXL_DVSEC_FLEX_BUS_DEVICE_RANGE2_BASE_LOW;

//
// Flex Bus Device DVSEC ID
// Compute Express Link Specification Revision: 1.1 - Chapter 7.1.1, Table 58
//
public unsafe partial class EFI
{
  public const ulong FLEX_BUS_DEVICE_DVSEC_ID = 0;
}

//
// PCIe DVSEC for Flex Bus Device
// Compute Express Link Specification Revision: 1.1 - Chapter 7.1.1, Figure 95
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CXL_1_1_DVSEC_FLEX_BUS_DEVICE
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;                                      // offset 0
  public PCI_EXPRESS_DESIGNATED_VENDOR_SPECIFIC_HEADER_1 DesignatedVendorSpecificHeader1;             // offset 4
  public PCI_EXPRESS_DESIGNATED_VENDOR_SPECIFIC_HEADER_2 DesignatedVendorSpecificHeader2;             // offset 8
  public CXL_DVSEC_FLEX_BUS_DEVICE_CAPABILITY DeviceCapability;                            // offset 10
  public CXL_DVSEC_FLEX_BUS_DEVICE_CONTROL DeviceControl;                               // offset 12
  public CXL_DVSEC_FLEX_BUS_DEVICE_STATUS DeviceStatus;                                // offset 14
  public CXL_1_1_DVSEC_FLEX_BUS_DEVICE_CONTROL2 DeviceControl2;                              // offset 16
  public CXL_1_1_DVSEC_FLEX_BUS_DEVICE_STATUS2 DeviceStatus2;                               // offset 18
  public CXL_DVSEC_FLEX_BUS_DEVICE_LOCK DeviceLock;                                  // offset 20
  public ushort Reserved;                                    // offset 22
  public CXL_DVSEC_FLEX_BUS_DEVICE_RANGE1_SIZE_HIGH DeviceRange1SizeHigh;                        // offset 24
  public CXL_DVSEC_FLEX_BUS_DEVICE_RANGE1_SIZE_LOW DeviceRange1SizeLow;                         // offset 28
  public CXL_DVSEC_FLEX_BUS_DEVICE_RANGE1_BASE_HIGH DeviceRange1BaseHigh;                        // offset 32
  public CXL_DVSEC_FLEX_BUS_DEVICE_RANGE1_BASE_LOW DeviceRange1BaseLow;                         // offset 36
  public CXL_DVSEC_FLEX_BUS_DEVICE_RANGE2_SIZE_HIGH DeviceRange2SizeHigh;                        // offset 40
  public CXL_DVSEC_FLEX_BUS_DEVICE_RANGE2_SIZE_LOW DeviceRange2SizeLow;                         // offset 44
  public CXL_DVSEC_FLEX_BUS_DEVICE_RANGE2_BASE_HIGH DeviceRange2BaseHigh;                        // offset 48
  public CXL_DVSEC_FLEX_BUS_DEVICE_RANGE2_BASE_LOW DeviceRange2BaseLow;                         // offset 52
}

CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, Header, 0x00);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DesignatedVendorSpecificHeader1, 0x04);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DesignatedVendorSpecificHeader2, 0x08);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceCapability, 0x0A);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceControl, 0x0C);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceStatus, 0x0E);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceControl2, 0x10);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceStatus2, 0x12);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceLock, 0x14);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceRange1SizeHigh, 0x18);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceRange1SizeLow, 0x1C);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceRange1BaseHigh, 0x20);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceRange1BaseLow, 0x24);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceRange2SizeHigh, 0x28);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceRange2SizeLow, 0x2C);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceRange2BaseHigh, 0x30);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, DeviceRange2BaseLow, 0x34);
CXL_11_SIZE_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_DEVICE, 0x38);
///@}

///
/// PCIe DVSEC for FLex Bus Port
///@{
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CacheCapable = 1;                                       // bit 0
  [FieldOffset(0)] public ushort IoCapable = 1;                                       // bit 1
  [FieldOffset(0)] public ushort MemCapable = 1;                                       // bit 2
  [FieldOffset(0)] public ushort Reserved = 13;                                      // bit 3..15
}
ushort Uint16;
} CXL_1_1_DVSEC_FLEX_BUS_PORT_CAPABILITY;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CacheEnable = 1;                               // bit 0
  [FieldOffset(0)] public ushort IoEnable = 1;                               // bit 1
  [FieldOffset(0)] public ushort MemEnable = 1;                               // bit 2
  [FieldOffset(0)] public ushort CxlSyncBypassEnable = 1;                               // bit 3
  [FieldOffset(0)] public ushort DriftBufferEnable = 1;                               // bit 4
  [FieldOffset(0)] public ushort Reserved = 3;                               // bit 5..7
  [FieldOffset(0)] public ushort Retimer1Present = 1;                               // bit 8
  [FieldOffset(0)] public ushort Retimer2Present = 1;                               // bit 9
  [FieldOffset(0)] public ushort Reserved2 = 6;                               // bit 10..15
}
ushort Uint16;
} CXL_1_1_DVSEC_FLEX_BUS_PORT_CONTROL;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CacheEnable = 1;            // bit 0
  [FieldOffset(0)] public ushort IoEnable = 1;            // bit 1
  [FieldOffset(0)] public ushort MemEnable = 1;            // bit 2
  [FieldOffset(0)] public ushort CxlSyncBypassEnable = 1;            // bit 3
  [FieldOffset(0)] public ushort DriftBufferEnable = 1;            // bit 4
  [FieldOffset(0)] public ushort Reserved = 3;            // bit 5..7
  [FieldOffset(0)] public ushort CxlCorrectableProtocolIdFramingError = 1;            // bit 8
  [FieldOffset(0)] public ushort CxlUncorrectableProtocolIdFramingError = 1;            // bit 9
  [FieldOffset(0)] public ushort CxlUnexpectedProtocolIdDropped = 1;            // bit 10
  [FieldOffset(0)] public ushort Reserved2 = 5;            // bit 11..15
}
ushort Uint16;
} CXL_1_1_DVSEC_FLEX_BUS_PORT_STATUS;

//
// Flex Bus Port DVSEC ID
// Compute Express Link Specification Revision: 1.1 - Chapter 7.2.1.3, Table 62
//
public unsafe partial class EFI
{
  public const ulong FLEX_BUS_PORT_DVSEC_ID = 7;
}

//
// PCIe DVSEC for Flex Bus Port
// Compute Express Link Specification Revision: 1.1 - Chapter 7.2.1.3, Figure 99
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CXL_1_1_DVSEC_FLEX_BUS_PORT
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;                                      // offset 0
  public PCI_EXPRESS_DESIGNATED_VENDOR_SPECIFIC_HEADER_1 DesignatedVendorSpecificHeader1;             // offset 4
  public PCI_EXPRESS_DESIGNATED_VENDOR_SPECIFIC_HEADER_2 DesignatedVendorSpecificHeader2;             // offset 8
  public CXL_1_1_DVSEC_FLEX_BUS_PORT_CAPABILITY PortCapability;                              // offset 10
  public CXL_1_1_DVSEC_FLEX_BUS_PORT_CONTROL PortControl;                                 // offset 12
  public CXL_1_1_DVSEC_FLEX_BUS_PORT_STATUS PortStatus;                                  // offset 14
}

CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_PORT, Header, 0x00);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_PORT, DesignatedVendorSpecificHeader1, 0x04);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_PORT, DesignatedVendorSpecificHeader2, 0x08);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_PORT, PortCapability, 0x0A);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_PORT, PortControl, 0x0C);
CXL_11_OFFSET_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_PORT, PortStatus, 0x0E);
CXL_11_SIZE_ASSERT(CXL_1_1_DVSEC_FLEX_BUS_PORT, 0x10);
///@}

///
/// CXL 1.1 Upstream and Downstream Port Subsystem Component registers
///

/// The CXL.Cache and CXL.Memory Architectural register definitions
/// Based on chapter 7.2.2 of Compute Express Link Specification Revision: 1.1
///@{

public unsafe partial class EFI
{
  public const ulong CXL_CAPABILITY_HEADER_OFFSET = 0;
}
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint CxlCapabilityId = 16;                              // bit 0..15
  [FieldOffset(0)] public uint CxlCapabilityVersion = 4;                              // bit 16..19
  [FieldOffset(0)] public uint CxlCacheMemVersion = 4;                              // bit 20..23
  [FieldOffset(0)] public uint ArraySize = 8;                              // bit 24..31
}
uint Uint32;
} CXL_CAPABILITY_HEADER;

public unsafe partial class EFI
{
  public const ulong CXL_RAS_CAPABILITY_HEADER_OFFSET = 4;
}
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint CxlCapabilityId = 16;                           // bit 0..15
  [FieldOffset(0)] public uint CxlCapabilityVersion = 4;                           // bit 16..19
  [FieldOffset(0)] public uint CxlRasCapabilityPointer = 12;                           // bit 20..31
}
uint Uint32;
} CXL_RAS_CAPABILITY_HEADER;

public unsafe partial class EFI
{
  public const ulong CXL_SECURITY_CAPABILITY_HEADER_OFFSET = 8;
}
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint CxlCapabilityId = 16;                      // bit 0..15
  [FieldOffset(0)] public uint CxlCapabilityVersion = 4;                      // bit 16..19
  [FieldOffset(0)] public uint CxlSecurityCapabilityPointer = 12;                      // bit 20..31
}
uint Uint32;
} CXL_SECURITY_CAPABILITY_HEADER;

public unsafe partial class EFI
{
  public const ulong CXL_LINK_CAPABILITY_HEADER_OFFSET = 0xC;
}
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint CxlCapabilityId = 16;                          // bit 0..15
  [FieldOffset(0)] public uint CxlCapabilityVersion = 4;                          // bit 16..19
  [FieldOffset(0)] public uint CxlLinkCapabilityPointer = 12;                          // bit 20..31
}
uint Uint32;
} CXL_LINK_CAPABILITY_HEADER;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint CacheDataParity = 1;                             // bit 0..0
  [FieldOffset(0)] public uint CacheAddressParity = 1;                             // bit 1..1
  [FieldOffset(0)] public uint CacheByteEnableParity = 1;                             // bit 2..2
  [FieldOffset(0)] public uint CacheDataEcc = 1;                             // bit 3..3
  [FieldOffset(0)] public uint MemDataParity = 1;                             // bit 4..4
  [FieldOffset(0)] public uint MemAddressParity = 1;                             // bit 5..5
  [FieldOffset(0)] public uint MemByteEnableParity = 1;                             // bit 6..6
  [FieldOffset(0)] public uint MemDataEcc = 1;                             // bit 7..7
  [FieldOffset(0)] public uint ReInitThreshold = 1;                             // bit 8..8
  [FieldOffset(0)] public uint RsvdEncodingViolation = 1;                             // bit 9..9
  [FieldOffset(0)] public uint PoisonReceived = 1;                             // bit 10..10
  [FieldOffset(0)] public uint ReceiverOverflow = 1;                             // bit 11..11
  [FieldOffset(0)] public uint Reserved = 20;                             // bit 12..31
}
uint Uint32;
} CXL_1_1_UNCORRECTABLE_ERROR_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint CacheDataParityMask = 1;                         // bit 0..0
  [FieldOffset(0)] public uint CacheAddressParityMask = 1;                         // bit 1..1
  [FieldOffset(0)] public uint CacheByteEnableParityMask = 1;                         // bit 2..2
  [FieldOffset(0)] public uint CacheDataEccMask = 1;                         // bit 3..3
  [FieldOffset(0)] public uint MemDataParityMask = 1;                         // bit 4..4
  [FieldOffset(0)] public uint MemAddressParityMask = 1;                         // bit 5..5
  [FieldOffset(0)] public uint MemByteEnableParityMask = 1;                         // bit 6..6
  [FieldOffset(0)] public uint MemDataEccMask = 1;                         // bit 7..7
  [FieldOffset(0)] public uint ReInitThresholdMask = 1;                         // bit 8..8
  [FieldOffset(0)] public uint RsvdEncodingViolationMask = 1;                         // bit 9..9
  [FieldOffset(0)] public uint PoisonReceivedMask = 1;                         // bit 10..10
  [FieldOffset(0)] public uint ReceiverOverflowMask = 1;                         // bit 11..11
  [FieldOffset(0)] public uint Reserved = 20;                         // bit 12..31
}
uint Uint32;
} CXL_1_1_UNCORRECTABLE_ERROR_MASK;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint CacheDataParitySeverity = 1;                     // bit 0..0
  [FieldOffset(0)] public uint CacheAddressParitySeverity = 1;                     // bit 1..1
  [FieldOffset(0)] public uint CacheByteEnableParitySeverity = 1;                     // bit 2..2
  [FieldOffset(0)] public uint CacheDataEccSeverity = 1;                     // bit 3..3
  [FieldOffset(0)] public uint MemDataParitySeverity = 1;                     // bit 4..4
  [FieldOffset(0)] public uint MemAddressParitySeverity = 1;                     // bit 5..5
  [FieldOffset(0)] public uint MemByteEnableParitySeverity = 1;                     // bit 6..6
  [FieldOffset(0)] public uint MemDataEccSeverity = 1;                     // bit 7..7
  [FieldOffset(0)] public uint ReInitThresholdSeverity = 1;                     // bit 8..8
  [FieldOffset(0)] public uint RsvdEncodingViolationSeverity = 1;                     // bit 9..9
  [FieldOffset(0)] public uint PoisonReceivedSeverity = 1;                     // bit 10..10
  [FieldOffset(0)] public uint ReceiverOverflowSeverity = 1;                     // bit 11..11
  [FieldOffset(0)] public uint Reserved = 20;                     // bit 12..31
}
uint Uint32;
} CXL_1_1_UNCORRECTABLE_ERROR_SEVERITY;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint CacheDataEcc = 1;                              // bit 0..0
  [FieldOffset(0)] public uint MemoryDataEcc = 1;                              // bit 1..1
  [FieldOffset(0)] public uint CrcThreshold = 1;                              // bit 2..2
  [FieldOffset(0)] public uint RetryThreshold = 1;                              // bit 3..3
  [FieldOffset(0)] public uint CachePoisonReceived = 1;                              // bit 4..4
  [FieldOffset(0)] public uint MemoryPoisonReceived = 1;                              // bit 5..5
  [FieldOffset(0)] public uint PhysicalLayerError = 1;                              // bit 6..6
  [FieldOffset(0)] public uint Reserved = 25;                              // bit 7..31
}
uint Uint32;
} CXL_CORRECTABLE_ERROR_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint CacheDataEccMask = 1;                          // bit 0..0
  [FieldOffset(0)] public uint MemoryDataEccMask = 1;                          // bit 1..1
  [FieldOffset(0)] public uint CrcThresholdMask = 1;                          // bit 2..2
  [FieldOffset(0)] public uint RetryThresholdMask = 1;                          // bit 3..3
  [FieldOffset(0)] public uint CachePoisonReceivedMask = 1;                          // bit 4..4
  [FieldOffset(0)] public uint MemoryPoisonReceivedMask = 1;                          // bit 5..5
  [FieldOffset(0)] public uint PhysicalLayerErrorMask = 1;                          // bit 6..6
  [FieldOffset(0)] public uint Reserved = 25;                          // bit 7..31
}
uint Uint32;
} CXL_CORRECTABLE_ERROR_MASK;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint FirstErrorPointer = 4;                 // bit 0..3
  [FieldOffset(0)] public uint Reserved1 = 5;                 // bit 4..8
  [FieldOffset(0)] public uint MultipleHeaderRecordingCapability = 1;                 // bit 9..9
  [FieldOffset(0)] public uint Reserved2 = 3;                 // bit 10..12
  [FieldOffset(0)] public uint PoisonEnabled = 1;                 // bit 13..13
  [FieldOffset(0)] public uint Reserved3 = 18;                 // bit 14..31
}
uint Uint32;
} CXL_ERROR_CAPABILITIES_AND_CONTROL;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CXL_1_1_RAS_CAPABILITY_STRUCTURE
{
  public CXL_1_1_UNCORRECTABLE_ERROR_STATUS UncorrectableErrorStatus;
  public CXL_1_1_UNCORRECTABLE_ERROR_MASK UncorrectableErrorMask;
  public CXL_1_1_UNCORRECTABLE_ERROR_SEVERITY UncorrectableErrorSeverity;
  public CXL_CORRECTABLE_ERROR_STATUS CorrectableErrorStatus;
  public CXL_CORRECTABLE_ERROR_MASK CorrectableErrorMask;
  public CXL_ERROR_CAPABILITIES_AND_CONTROL ErrorCapabilitiesAndControl;
  public fixed uint HeaderLog[16];
}

CXL_11_OFFSET_ASSERT(CXL_1_1_RAS_CAPABILITY_STRUCTURE, UncorrectableErrorStatus, 0x00);
CXL_11_OFFSET_ASSERT(CXL_1_1_RAS_CAPABILITY_STRUCTURE, UncorrectableErrorMask, 0x04);
CXL_11_OFFSET_ASSERT(CXL_1_1_RAS_CAPABILITY_STRUCTURE, UncorrectableErrorSeverity, 0x08);
CXL_11_OFFSET_ASSERT(CXL_1_1_RAS_CAPABILITY_STRUCTURE, CorrectableErrorStatus, 0x0C);
CXL_11_OFFSET_ASSERT(CXL_1_1_RAS_CAPABILITY_STRUCTURE, CorrectableErrorMask, 0x10);
CXL_11_OFFSET_ASSERT(CXL_1_1_RAS_CAPABILITY_STRUCTURE, ErrorCapabilitiesAndControl, 0x14);
CXL_11_OFFSET_ASSERT(CXL_1_1_RAS_CAPABILITY_STRUCTURE, HeaderLog, 0x18);
CXL_11_SIZE_ASSERT(CXL_1_1_RAS_CAPABILITY_STRUCTURE, 0x58);

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint DeviceTrustLevel = 2;                                  // bit 0..1
  [FieldOffset(0)] public uint Reserved = 30;                                  // bit 2..31
}
uint Uint32;
} CXL_1_1_SECURITY_POLICY;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CXL_1_1_SECURITY_CAPABILITY_STRUCTURE
{
  public CXL_1_1_SECURITY_POLICY SecurityPolicy;
}

CXL_11_OFFSET_ASSERT(CXL_1_1_SECURITY_CAPABILITY_STRUCTURE, SecurityPolicy, 0x0);
CXL_11_SIZE_ASSERT(CXL_1_1_SECURITY_CAPABILITY_STRUCTURE, 0x4);

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ulong CxlLinkVersionSupported = 4;                           // bit 0..3
  [FieldOffset(0)] public ulong CxlLinkVersionReceived = 4;                           // bit 4..7
  [FieldOffset(0)] public ulong LlrWrapValueSupported = 8;                           // bit 8..15
  [FieldOffset(0)] public ulong LlrWrapValueReceived = 8;                           // bit 16..23
  [FieldOffset(0)] public ulong NumRetryReceived = 5;                           // bit 24..28
  [FieldOffset(0)] public ulong NumPhyReinitReceived = 5;                           // bit 29..33
  [FieldOffset(0)] public ulong WrPtrReceived = 8;                           // bit 34..41
  [FieldOffset(0)] public ulong EchoEseqReceived = 8;                           // bit 42..49
  [FieldOffset(0)] public ulong NumFreeBufReceived = 8;                           // bit 50..57
  [FieldOffset(0)] public ulong Reserved = 6;                           // bit 58..63
}
ulong Uint64;
} CXL_LINK_LAYER_CAPABILITY;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort LlReset = 1;                             // bit 0..0
  [FieldOffset(0)] public ushort LlInitStall = 1;                             // bit 1..1
  [FieldOffset(0)] public ushort LlCrdStall = 1;                             // bit 2..2
  [FieldOffset(0)] public ushort InitState = 2;                             // bit 3..4
  [FieldOffset(0)] public ushort LlRetryBufferConsumed = 8;                             // bit 5..12
  [FieldOffset(0)] public ushort Reserved = 3;                             // bit 13..15
}
ulong Uint64;
} CXL_LINK_LAYER_CONTROL_AND_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ulong CacheReqCredits = 10;                                  // bit 0..9
  [FieldOffset(0)] public ulong CacheRspCredits = 10;                                  // bit 10..19
  [FieldOffset(0)] public ulong CacheDataCredits = 10;                                  // bit 20..29
  [FieldOffset(0)] public ulong MemReqRspCredits = 10;                                  // bit 30..39
  [FieldOffset(0)] public ulong MemDataCredits = 10;                                  // bit 40..49
}
ulong Uint64;
} CXL_LINK_LAYER_RX_CREDIT_CONTROL;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ulong CacheReqCredits = 10;                                  // bit 0..9
  [FieldOffset(0)] public ulong CacheRspCredits = 10;                                  // bit 10..19
  [FieldOffset(0)] public ulong CacheDataCredits = 10;                                  // bit 20..29
  [FieldOffset(0)] public ulong MemReqRspCredits = 10;                                  // bit 30..39
  [FieldOffset(0)] public ulong MemDataCredits = 10;                                  // bit 40..49
}
ulong Uint64;
} CXL_LINK_LAYER_RX_CREDIT_RETURN_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ulong CacheReqCredits = 10;                                  // bit 0..9
  [FieldOffset(0)] public ulong CacheRspCredits = 10;                                  // bit 10..19
  [FieldOffset(0)] public ulong CacheDataCredits = 10;                                  // bit 20..29
  [FieldOffset(0)] public ulong MemReqRspCredits = 10;                                  // bit 30..39
  [FieldOffset(0)] public ulong MemDataCredits = 10;                                  // bit 40..49
}
ulong Uint64;
} CXL_LINK_LAYER_TX_CREDIT_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint AckForceThreshold = 8;                                 // bit 0..7
  [FieldOffset(0)] public uint AckFLushRetimer = 10;                                 // bit 8..17
}
ulong Uint64;
} CXL_LINK_LAYER_ACK_TIMER_CONTROL;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint MdhDisable = 1;                                        // bit 0..0
  [FieldOffset(0)] public uint Reserved = 31;                                        // bit 1..31
}
ulong Uint64;
} CXL_LINK_LAYER_DEFEATURE;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CXL_1_1_LINK_CAPABILITY_STRUCTURE
{
  public CXL_LINK_LAYER_CAPABILITY LinkLayerCapability;
  public CXL_LINK_LAYER_CONTROL_AND_STATUS LinkLayerControlStatus;
  public CXL_LINK_LAYER_RX_CREDIT_CONTROL LinkLayerRxCreditControl;
  public CXL_LINK_LAYER_RX_CREDIT_RETURN_STATUS LinkLayerRxCreditReturnStatus;
  public CXL_LINK_LAYER_TX_CREDIT_STATUS LinkLayerTxCreditStatus;
  public CXL_LINK_LAYER_ACK_TIMER_CONTROL LinkLayerAckTimerControl;
  public CXL_LINK_LAYER_DEFEATURE LinkLayerDefeature;
}

CXL_11_OFFSET_ASSERT(CXL_1_1_LINK_CAPABILITY_STRUCTURE, LinkLayerCapability, 0x00);
CXL_11_OFFSET_ASSERT(CXL_1_1_LINK_CAPABILITY_STRUCTURE, LinkLayerControlStatus, 0x08);
CXL_11_OFFSET_ASSERT(CXL_1_1_LINK_CAPABILITY_STRUCTURE, LinkLayerRxCreditControl, 0x10);
CXL_11_OFFSET_ASSERT(CXL_1_1_LINK_CAPABILITY_STRUCTURE, LinkLayerRxCreditReturnStatus, 0x18);
CXL_11_OFFSET_ASSERT(CXL_1_1_LINK_CAPABILITY_STRUCTURE, LinkLayerTxCreditStatus, 0x20);
CXL_11_OFFSET_ASSERT(CXL_1_1_LINK_CAPABILITY_STRUCTURE, LinkLayerAckTimerControl, 0x28);
CXL_11_OFFSET_ASSERT(CXL_1_1_LINK_CAPABILITY_STRUCTURE, LinkLayerDefeature, 0x30);
CXL_11_SIZE_ASSERT(CXL_1_1_LINK_CAPABILITY_STRUCTURE, 0x38);

public unsafe partial class EFI
{
  public const ulong CXL_IO_ARBITRATION_CONTROL_OFFSET = 0x180;
}
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint Reserved1 = 4;               // bit 0..3
  [FieldOffset(0)] public uint WeightedRoundRobinArbitrationWeight = 4;               // bit 4..7
  [FieldOffset(0)] public uint Reserved2 = 24;               // bit 8..31
}
uint Uint32;
} CXL_IO_ARBITRATION_CONTROL;

CXL_11_SIZE_ASSERT(CXL_IO_ARBITRATION_CONTROL, 0x4);

public unsafe partial class EFI
{
  public const ulong CXL_CACHE_MEMORY_ARBITRATION_CONTROL_OFFSET = 0x1C0;
}
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint Reserved1 = 4;               // bit 0..3
  [FieldOffset(0)] public uint WeightedRoundRobinArbitrationWeight = 4;               // bit 4..7
  [FieldOffset(0)] public uint Reserved2 = 24;               // bit 8..31
}
uint Uint32;
} CXL_CACHE_MEMORY_ARBITRATION_CONTROL;

CXL_11_SIZE_ASSERT(CXL_CACHE_MEMORY_ARBITRATION_CONTROL, 0x4);

///@}

/// The CXL.RCRB base register definition
/// Based on chapter 7.3 of Compute Express Link Specification Revision: 1.1
///@{
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ulong RcrbEnable = 1;                                   // bit 0..0
  [FieldOffset(0)] public ulong Reserved = 12;                                   // bit 1..12
  [FieldOffset(0)] public ulong RcrbBaseAddress = 51;                                   // bit 13..63
}
ulong Uint64;
} CXL_RCRB_BASE;

CXL_11_SIZE_ASSERT(CXL_RCRB_BASE, 0x8);

///@}

// #pragma pack()

//
// CXL Downstream / Upstream Port RCRB space register offsets
// Compute Express Link Specification Revision: 1.1 - Chapter 7.2.1.1 - Figure 97
//
public unsafe partial class EFI
{
  public const ulong CXL_PORT_RCRB_MEMBAR0_LOW_OFFSET = 0x010;
  public const ulong CXL_PORT_RCRB_MEMBAR0_HIGH_OFFSET = 0x014;
  public const ulong CXL_PORT_RCRB_EXTENDED_CAPABILITY_BASE_OFFSET = 0x100;
}

// #endif
