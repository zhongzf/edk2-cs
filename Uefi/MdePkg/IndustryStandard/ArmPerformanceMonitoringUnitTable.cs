using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI Arm Performance Monitoring Unit (APMT) table
  as specified in ARM spec DEN0117

  Copyright (c) 2022, NVIDIA CORPORATION. All rights reserved.
  Copyright (c) 2022, ARM Limited. All rights reserved.
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef ARM_PERFORMANCE_MONITORING_UNIT_TABLE_H_
// #define ARM_PERFORMANCE_MONITORING_UNIT_TABLE_H_

// #include <IndustryStandard/Acpi.h>

// #pragma pack(1)

///
/// Arm Performance Monitoring Unit (APMT) tabl
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ARM_PERFORMANCE_MONITORING_UNIT_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
}

public unsafe partial class EFI
{
  ///
  /// APMT Revision (as defined in DEN0117.)
  ///
  public const ulong EFI_ACPI_ARM_PERFORMANCE_MONITORING_UNIT_TABLE_REVISION = 0x00;

  ///
  /// Arm PMU Node Structure
  ///

  // Node Flags
  public const ulong EFI_ACPI_APMT_DUAL_PAGE_EXTENSION_SUPPORTED = BIT0;
  public const ulong EFI_ACPI_APMT_PROCESSOR_AFFINITY_TYPE_CONTAINER = BIT1;
  public const ulong EFI_ACPI_APMT_PROCESSOR_AFFINITY_TYPE_PROCESSOR = 0; //  BIT 1
  public const ulong EFI_ACPI_APMT_64BIT_SINGLE_COPY_ATOMICITY_SUPPORTED = BIT2;

  // Interrupt Flags
  public const ulong EFI_ACPI_APMT_INTERRUPT_MODE_EDGE_TRIGGERED = BIT0;
  public const ulong EFI_ACPI_APMT_INTERRUPT_MODE_LEVEL_TRIGGERED = 0; //  BIT 0
  public const ulong EFI_ACPI_APMT_INTERRUPT_TYPE_WIRED = 0; //  BIT 1

  // Node Type
  public const ulong EFI_ACPI_APMT_NODE_TYPE_MEMORY_CONTROLLER = 0x00;
  public const ulong EFI_ACPI_APMT_NODE_TYPE_SMMU = 0x01;
  public const ulong EFI_ACPI_APMT_NODE_TYPE_PCIE_ROOT_COMPLEX = 0x02;
  public const ulong EFI_ACPI_APMT_NODE_TYPE_ACPI_DEVICE = 0x03;
  public const ulong EFI_ACPI_APMT_NODE_TYPE_CPU_CACHE = 0x04;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ARM_PERFORMANCE_MONITORING_UNIT_NODE
{
  public ushort Length;
  public byte NodeFlags;
  public byte NodeType;
  public uint Identifier;
  public ulong NodeInstancePrimary;
  public uint NodeInstanceSecondary;
  public ulong BaseAddress0;
  public ulong BaseAddress1;
  public uint OverflowInterrupt;
  public uint Reserved1;
  public uint OverflowInterruptFlags;
  public uint ProcessorAffinity;
  public uint ImplementationId;
}

// #pragma pack()

// #endif
