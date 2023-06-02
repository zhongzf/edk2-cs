using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI IO Remapping Table (IORT) definitions.

  Copyright (c) 2017, Linaro Limited. All rights reserved.<BR>
  Copyright (c) 2018 - 2022, Arm Limited. All rights reserved.<BR>

  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Reference(s):
  - IO Remapping Table, Platform Design Document, Revision E.d, Feb 2022
    (https://developer.arm.com/documentation/den0049/)
  - IO Remapping Table, Platform Design Document, Revision E.e, Sept 2022
      (https://developer.arm.com/documentation/den0049/)

  @par Glossary:
  - Ref  : Reference
  - Mem  : Memory
  - Desc : Descriptor
**/

// #ifndef __IO_REMAPPING_TABLE_H__
// #define __IO_REMAPPING_TABLE_H__

// #include <IndustryStandard/Acpi.h>

public unsafe partial class EFI
{
  public const ulong EFI_ACPI_IO_REMAPPING_TABLE_REVISION_00 = 0x0;
  public const ulong EFI_ACPI_IO_REMAPPING_TABLE_REVISION_04 = 0x4; //  Deprecated
  public const ulong EFI_ACPI_IO_REMAPPING_TABLE_REVISION_05 = 0x5;
  public const ulong EFI_ACPI_IO_REMAPPING_TABLE_REVISION_06 = 0x6;

  public const ulong EFI_ACPI_IORT_TYPE_ITS_GROUP = 0x0;
  public const ulong EFI_ACPI_IORT_TYPE_NAMED_COMP = 0x1;
  public const ulong EFI_ACPI_IORT_TYPE_ROOT_COMPLEX = 0x2;
  public const ulong EFI_ACPI_IORT_TYPE_SMMUv1v2 = 0x3;
  public const ulong EFI_ACPI_IORT_TYPE_SMMUv3 = 0x4;
  public const ulong EFI_ACPI_IORT_TYPE_PMCG = 0x5;
  public const ulong EFI_ACPI_IORT_TYPE_RMR = 0x6;

  public const ulong EFI_ACPI_IORT_MEM_ACCESS_PROP_CCA = BIT0;

  public const ulong EFI_ACPI_IORT_MEM_ACCESS_PROP_AH_TR = BIT0;
  public const ulong EFI_ACPI_IORT_MEM_ACCESS_PROP_AH_WA = BIT1;
  public const ulong EFI_ACPI_IORT_MEM_ACCESS_PROP_AH_RA = BIT2;
  public const ulong EFI_ACPI_IORT_MEM_ACCESS_PROP_AH_AHO = BIT3;

  public const ulong EFI_ACPI_IORT_MEM_ACCESS_FLAGS_CPM = BIT0;
  public const ulong EFI_ACPI_IORT_MEM_ACCESS_FLAGS_DACS = BIT1;

  public const ulong EFI_ACPI_IORT_SMMUv1v2_MODEL_v1 = 0x0;
  public const ulong EFI_ACPI_IORT_SMMUv1v2_MODEL_v2 = 0x1;
  public const ulong EFI_ACPI_IORT_SMMUv1v2_MODEL_MMU400 = 0x2;
  public const ulong EFI_ACPI_IORT_SMMUv1v2_MODEL_MMU500 = 0x3;
  public const ulong EFI_ACPI_IORT_SMMUv1v2_MODEL_MMU401 = 0x4;
  public const ulong EFI_ACPI_IORT_SMMUv1v2_MODEL_CAVIUM_THX_v2 = 0x5;

  public const ulong EFI_ACPI_IORT_SMMUv1v2_FLAG_DVM = BIT0;
  public const ulong EFI_ACPI_IORT_SMMUv1v2_FLAG_COH_WALK = BIT1;

  public const ulong EFI_ACPI_IORT_SMMUv1v2_INT_FLAG_LEVEL = 0x0;
  public const ulong EFI_ACPI_IORT_SMMUv1v2_INT_FLAG_EDGE = 0x1;

  public const ulong EFI_ACPI_IORT_SMMUv3_FLAG_COHAC_OVERRIDE = BIT0;
  public const ulong EFI_ACPI_IORT_SMMUv3_FLAG_HTTU_OVERRIDE = BIT1;
  public const ulong EFI_ACPI_IORT_SMMUv3_FLAG_PROXIMITY_DOMAIN = BIT3;
  public const ulong EFI_ACPI_IORT_SMMUv3_FLAG_DEVICEID_VALID = BIT4;

  public const ulong EFI_ACPI_IORT_SMMUv3_MODEL_GENERIC = 0x0;
  public const ulong EFI_ACPI_IORT_SMMUv3_MODEL_HISILICON_HI161X = 0x1;
  public const ulong EFI_ACPI_IORT_SMMUv3_MODEL_CAVIUM_CN99XX = 0x2;

  public const ulong EFI_ACPI_IORT_ROOT_COMPLEX_ATS_UNSUPPORTED = 0x0;
  public const ulong EFI_ACPI_IORT_ROOT_COMPLEX_ATS_SUPPORTED = BIT0;

  public const ulong EFI_ACPI_IORT_ROOT_COMPLEX_PRI_UNSUPPORTED = 0x0;
  public const ulong EFI_ACPI_IORT_ROOT_COMPLEX_PRI_SUPPORTED = BIT1;

  public const ulong EFI_ACPI_IORT_ROOT_COMPLEX_PASID_FWD_UNSUPPORTED = 0x0;
  public const ulong EFI_ACPI_IORT_ROOT_COMPLEX_PASID_FWD_SUPPORTED = BIT2;

  public const ulong EFI_ACPI_IORT_ROOT_COMPLEX_PASID_UNSUPPORTED = 0x0;
  public const ulong EFI_ACPI_IORT_ROOT_COMPLEX_PASID_SUPPORTED = BIT1;

  public const ulong EFI_ACPI_IORT_RMR_REMAP_NOT_PERMITTED = 0x0;
  public const ulong EFI_ACPI_IORT_RMR_REMAP_PERMITTED = BIT0;

  public const ulong EFI_ACPI_IORT_RMR_ACCESS_REQ_NOT_PRIVILEGED = 0x0;
  public const ulong EFI_ACPI_IORT_RMR_ACCESS_REQ_PRIVILEGED = BIT1;

  public const ulong EFI_ACPI_IORT_RMR_ACCESS_ATTRIB_DEV_NGNRNE = 0x0;
  public const ulong EFI_ACPI_IORT_RMR_ACCESS_ATTRIB_DEV_NGNRE = 0x1;
  public const ulong EFI_ACPI_IORT_RMR_ACCESS_ATTRIB_DEV_NGRE = 0x2;
  public const ulong EFI_ACPI_IORT_RMR_ACCESS_ATTRIB_DEV_GRE = 0x3;
  public const ulong EFI_ACPI_IORT_RMR_ACCESS_ATTRIB_NORM_IN_NC_OUT_NC = 0x4;
  public const ulong EFI_ACPI_IORT_RMR_ACCESS_ATTRIB_NORM_IN_WB_OUT_WB_ISH = 0x5;

  public const ulong EFI_ACPI_IORT_ID_MAPPING_FLAGS_SINGLE = BIT0;

  public const ulong EFI_ACPI_IORT_RMR_NODE_REVISION_02 = 0x2; //  Deprecated

  // #pragma pack(1)
}

///
/// Table header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint NumNodes;
  public uint NodeOffset;
  public uint Reserved;
}

///
/// Definition for ID mapping table shared by all node types
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_ID_TABLE
{
  public uint InputBase;
  public uint NumIds;
  public uint OutputBase;
  public uint OutputReference;
  public uint Flags;
}

///
/// Node header definition shared by all node types
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_NODE
{
  public byte Type;
  public ushort Length;
  public byte Revision;
  public uint Identifier;
  public uint NumIdMappings;
  public uint IdReference;
}

///
/// Node type 0: ITS node
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_ITS_NODE
{
  public EFI_ACPI_6_0_IO_REMAPPING_NODE Node;

  public uint NumItsIdentifiers;
  // uint                                  ItsIdentifiers[NumItsIdentifiers];
}

///
/// Node type 1: root complex node
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_RC_NODE
{
  public EFI_ACPI_6_0_IO_REMAPPING_NODE Node;

  public uint CacheCoherent;
  public byte AllocationHints;
  public ushort Reserved;
  public byte MemoryAccessFlags;

  public uint AtsAttribute;
  public uint PciSegmentNumber;
  public byte MemoryAddressSize;
  public ushort PasidCapabilities;
  public fixed byte Reserved1[1];
  public uint Flags;
}

///
/// Node type 2: named component node
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_NAMED_COMP_NODE
{
  public EFI_ACPI_6_0_IO_REMAPPING_NODE Node;

  public uint Flags;
  public uint CacheCoherent;
  public byte AllocationHints;
  public ushort Reserved;
  public byte MemoryAccessFlags;
  public byte AddressSizeLimit;
  // byte                                   ObjectName[];
}

///
/// Node type 3: SMMUv1 or SMMUv2 node
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_SMMU_INT
{
  public uint Interrupt;
  public uint InterruptFlags;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_SMMU_NODE
{
  public EFI_ACPI_6_0_IO_REMAPPING_NODE Node;

  public ulong Base;
  public ulong Span;
  public uint Model;
  public uint Flags;
  public uint GlobalInterruptArrayRef;
  public uint NumContextInterrupts;
  public uint ContextInterruptArrayRef;
  public uint NumPmuInterrupts;
  public uint PmuInterruptArrayRef;

  public uint SMMU_NSgIrpt;
  public uint SMMU_NSgIrptFlags;
  public uint SMMU_NSgCfgIrpt;
  public uint SMMU_NSgCfgIrptFlags;

  // EFI_ACPI_6_0_IO_REMAPPING_SMMU_CTX_INT  ContextInterrupt[NumContextInterrupts];
  // EFI_ACPI_6_0_IO_REMAPPING_SMMU_CTX_INT  PmuInterrupt[NumPmuInterrupts];
}

///
/// Node type 4: SMMUv3 node
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_SMMU3_NODE
{
  public EFI_ACPI_6_0_IO_REMAPPING_NODE Node;

  public ulong Base;
  public uint Flags;
  public uint Reserved;
  public ulong VatosAddress;
  public uint Model;
  public uint Event;
  public uint Pri;
  public uint Gerr;
  public uint Sync;
  public uint ProximityDomain;
  public uint DeviceIdMappingIndex;
}

///
/// Node type 5: PMCG node
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_PMCG_NODE
{
  public EFI_ACPI_6_0_IO_REMAPPING_NODE Node;

  public ulong Base;
  public uint OverflowInterruptGsiv;
  public uint NodeReference;
  public ulong Page1Base;
  // EFI_ACPI_6_0_IO_REMAPPING_ID_TABLE      OverflowInterruptMsiMapping[1];
}

///
/// Memory Range Descriptor.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_MEM_RANGE_DESC
{
  /// Base address of Reserved Memory Range,
  /// aligned to a page size of 64K.
  public ulong Base;

  /// Length of the Reserved Memory range.
  /// Must be a multiple of the page size of 64K.
  public ulong Length;

  /// Reserved, must be zero.
  public uint Reserved;
}

///
/// Node type 6: Reserved Memory Range (RMR) node
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_0_IO_REMAPPING_RMR_NODE
{
  public EFI_ACPI_6_0_IO_REMAPPING_NODE Node;

  /// RMR flags
  public uint Flags;

  /// Memory range descriptor count.
  public uint NumMemRangeDesc;

  /// Offset of the memory range descriptor array.
  public uint MemRangeDescRef;
  // EFI_ACPI_6_0_IO_REMAPPING_ID_TABLE         IdMapping[1];
  // EFI_ACPI_6_0_IO_REMAPPING_MEM_RANGE_DESC   MemRangeDesc[1];
}

// #pragma pack()

// #endif
