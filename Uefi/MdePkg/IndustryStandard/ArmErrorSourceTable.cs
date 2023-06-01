using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Arm Error Source Table as described in the
  'ACPI for the Armv8 RAS Extensions 1.1' Specification.

  Copyright (c) 2020 Arm Limited.
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Reference(s):
    - ACPI for the Armv8 RAS Extensions 1.1 Platform Design Document,
      dated 28 September 2020.
      (https://developer.arm.com/documentation/den0085/0101/)

  @par Glossary
    - Ref : Reference
    - Id  : Identifier
**/

// #ifndef ARM_ERROR_SOURCE_TABLE_H_
// #define ARM_ERROR_SOURCE_TABLE_H_

///
/// "AEST" Arm Error Source Table
///
public const ulong EFI_ACPI_6_3_ARM_ERROR_SOURCE_TABLE_SIGNATURE = SIGNATURE_32('A', 'E', 'S', 'T');

public const ulong EFI_ACPI_ARM_ERROR_SOURCE_TABLE_REVISION = 1;

// #pragma pack(1)

///
/// Arm Error Source Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ARM_ERROR_SOURCE_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
}

///
/// AEST Node structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_NODE_STRUCT
{
  /// Node type:
  ///   0x00 - Processor error node
  ///   0x01 - Memory error node
  ///   0x02 - SMMU error node
  ///   0x03 - Vendor-defined error node
  ///   0x04 - GIC error node
  public byte Type;

  /// Length of structure in bytes.
  public ushort Length;

  /// Reserved - Must be zero.
  public byte Reserved;

  /// Offset from the start of the node to node-specific data.
  public uint DataOffset;

  /// Offset from the start of the node to the node interface structure.
  public uint InterfaceOffset;

  /// Offset from the start of the node to node interrupt array.
  public uint InterruptArrayOffset;

  /// Number of entries in the interrupt array.
  public uint InterruptArrayCount;

  // Generic node data

  /// The timestamp frequency of the counter in Hz.
  public ulong TimestampRate;

  /// Reserved - Must be zero.
  public ulong Reserved1;

  /// The rate in Hz at which the Error Generation Counter decrements.
  public ulong ErrorInjectionCountdownRate;
}

// AEST Node type definitions
public const ulong EFI_ACPI_AEST_NODE_TYPE_PROCESSOR = 0x0;
public const ulong EFI_ACPI_AEST_NODE_TYPE_MEMORY = 0x1;
public const ulong EFI_ACPI_AEST_NODE_TYPE_SMMU = 0x2;
public const ulong EFI_ACPI_AEST_NODE_TYPE_VENDOR_DEFINED = 0x3;
public const ulong EFI_ACPI_AEST_NODE_TYPE_GIC = 0x4;

///
/// AEST Node Interface structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_INTERFACE_STRUCT
{
  /// Interface type:
  ///   0x0 - System register (SR)
  ///   0x1 - Memory mapped (MMIO)
  public byte Type;

  /// Reserved - Must be zero.
  public fixed byte Reserved[3];

  /// AEST node interface flags.
  public uint Flags;

  /// Base address of error group that contains the error node.
  public ulong BaseAddress;

  /// Zero-based index of the first standard error record that
  /// belongs to this node.
  public uint StartErrorRecordIndex;

  /// Number of error records in this node including both
  /// implemented and unimplemented records.
  public uint NumberErrorRecords;

  /// A bitmap indicating the error records within this
  /// node that are implemented in the current system.
  public ulong ErrorRecordImplemented;

  /// A bitmap indicating the error records within this node that
  /// support error status reporting through the ERRGSR register.
  public ulong ErrorRecordStatusReportingSupported;

  /// A bitmap indicating the addressing mode used by each error
  /// record within this node to populate the ERR<n>_ADDR register.
  public ulong AddressingMode;
}

// AEST Interface node type definitions.
public const ulong EFI_ACPI_AEST_INTERFACE_TYPE_SR = 0x0;
public const ulong EFI_ACPI_AEST_INTERFACE_TYPE_MMIO = 0x1;

// AEST node interface flag definitions.
public const ulong EFI_ACPI_AEST_INTERFACE_FLAG_PRIVATE = 0;
public const ulong EFI_ACPI_AEST_INTERFACE_FLAG_SHARED = BIT0;
public const ulong EFI_ACPI_AEST_INTERFACE_FLAG_CLEAR_MISCX = BIT1;

///
/// AEST Node Interrupt structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_INTERRUPT_STRUCT
{
  /// Interrupt type:
  ///   0x0 - Fault Handling Interrupt
  ///   0x1 - Error Recovery Interrupt
  public byte InterruptType;

  /// Reserved - Must be zero.
  public fixed byte Reserved[2];

  /// Interrupt flags
  /// Bits [31:1]: Must be zero.
  /// Bit 0:
  ///   0b - Interrupt is edge-triggered
  ///   1b - Interrupt is level-triggered
  public byte InterruptFlags;

  /// GSIV of interrupt, if interrupt is an SPI or a PPI.
  public uint InterruptGsiv;

  /// If MSI is supported, then this field must be set to the
  /// Identifier field of the IORT ITS Group node.
  public byte ItsGroupRefId;

  /// Reserved - must be zero.
  public fixed byte Reserved1[3];
}

// AEST Interrupt node - interrupt type defintions.
public const ulong EFI_ACPI_AEST_INTERRUPT_TYPE_FAULT_HANDLING = 0x0;
public const ulong EFI_ACPI_AEST_INTERRUPT_TYPE_ERROR_RECOVERY = 0x1;

// AEST Interrupt node - interrupt flag defintions.
public const ulong EFI_ACPI_AEST_INTERRUPT_FLAG_TRIGGER_TYPE_EDGE = 0;
public const ulong EFI_ACPI_AEST_INTERRUPT_FLAG_TRIGGER_TYPE_LEVEL = BIT0;

///
/// Cache Processor Resource structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_PROCESSOR_CACHE_RESOURCE_STRUCT
{
  /// Reference to the cache structure in the PPTT table.
  public uint CacheRefId;

  /// Reserved
  public uint Reserved;
}

///
/// TLB Processor Resource structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_PROCESSOR_TLB_RESOURCE_STRUCT
{
  /// TLB level from perspective of current processor.
  public uint TlbRefId;

  /// Reserved
  public uint Reserved;
}

///
/// Processor Generic Resource structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_PROCESSOR_GENERIC_RESOURCE_STRUCT
{
  /// Vendor-defined supplementary data.
  public uint Data;
}

///
/// AEST Processor Resource union.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_ACPI_AEST_PROCESSOR_RESOURCE
{
  /// Processor Cache resource.
  [FieldOffset(0)] public EFI_ACPI_AEST_PROCESSOR_CACHE_RESOURCE_STRUCT Cache;

  /// Processor TLB resource.
  [FieldOffset(0)] public EFI_ACPI_AEST_PROCESSOR_TLB_RESOURCE_STRUCT Tlb;

  /// Processor Generic resource.
  [FieldOffset(0)] public EFI_ACPI_AEST_PROCESSOR_GENERIC_RESOURCE_STRUCT Generic;
}

///
/// AEST Processor structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_PROCESSOR_STRUCT
{
  /// AEST Node header
  public EFI_ACPI_AEST_NODE_STRUCT NodeHeader;

  /// Processor ID of node.
  public uint AcpiProcessorId;

  /// Resource type of the processor node.
  ///   0x0 - Cache
  ///   0x1 - TLB
  ///   0x2 - Generic
  public byte ResourceType;

  /// Reserved - must be zero.
  public byte Reserved;

  /// Processor structure flags.
  public byte Flags;

  /// Processor structure revision.
  public byte Revision;

  /// Processor affinity descriptor for the resource that this
  /// error node pertains to.
  public ulong ProcessorAffinityLevelIndicator;

  /// Processor resource
  public EFI_ACPI_AEST_PROCESSOR_RESOURCE Resource;

  // Node Interface
  // EFI_ACPI_AEST_INTERFACE_STRUCT   NodeInterface;

  // Node Interrupt Array
  // EFI_ACPI_AEST_INTERRUPT_STRUCT   NodeInterruptArray[n];
}

// AEST Processor resource type definitions.
public const ulong EFI_ACPI_AEST_PROCESSOR_RESOURCE_TYPE_CACHE = 0x0;
public const ulong EFI_ACPI_AEST_PROCESSOR_RESOURCE_TYPE_TLB = 0x1;
public const ulong EFI_ACPI_AEST_PROCESSOR_RESOURCE_TYPE_GENERIC = 0x2;

// AEST Processor flag definitions.
public const ulong EFI_ACPI_AEST_PROCESSOR_FLAG_GLOBAL = BIT0;
public const ulong EFI_ACPI_AEST_PROCESSOR_FLAG_SHARED = BIT1;

///
/// Memory Controller structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_MEMORY_CONTROLLER_STRUCT
{
  /// AEST Node header
  public EFI_ACPI_AEST_NODE_STRUCT NodeHeader;

  /// SRAT proximity domain.
  public uint ProximityDomain;

  // Node Interface
  // EFI_ACPI_AEST_INTERFACE_STRUCT   NodeInterface;

  // Node Interrupt Array
  // EFI_ACPI_AEST_INTERRUPT_STRUCT   NodeInterruptArray[n];
}

///
/// SMMU structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_SMMU_STRUCT
{
  /// AEST Node header
  public EFI_ACPI_AEST_NODE_STRUCT NodeHeader;

  /// Reference to the IORT table node that describes this SMMU.
  public uint SmmuRefId;

  /// Reference to the IORT table node that is associated with the
  /// sub-component within this SMMU.
  public uint SubComponentRefId;

  // Node Interface
  // EFI_ACPI_AEST_INTERFACE_STRUCT   NodeInterface;

  // Node Interrupt Array
  // EFI_ACPI_AEST_INTERRUPT_STRUCT   NodeInterruptArray[n];
}

///
/// Vendor-Defined structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_VENDOR_DEFINED_STRUCT
{
  /// AEST Node header
  public EFI_ACPI_AEST_NODE_STRUCT NodeHeader;

  /// ACPI HID of the component.
  public uint HardwareId;

  /// The ACPI Unique identifier of the component.
  public uint UniqueId;

  /// Vendor-specific data, for example to identify this error source.
  public fixed byte VendorData[16];

  // Node Interface
  // EFI_ACPI_AEST_INTERFACE_STRUCT   NodeInterface;

  // Node Interrupt Array
  // EFI_ACPI_AEST_INTERRUPT_STRUCT   NodeInterruptArray[n];
}

///
/// GIC structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_AEST_GIC_STRUCT
{
  /// AEST Node header
  public EFI_ACPI_AEST_NODE_STRUCT NodeHeader;

  /// Type of GIC interface that is associated with this error node.
  ///   0x0 - GIC CPU (GICC)
  ///   0x1 - GIC Distributor (GICD)
  ///   0x2 - GIC Resistributor (GICR)
  ///   0x3 - GIC ITS (GITS)
  public uint InterfaceType;

  /// Identifier for the interface instance.
  public uint GicInterfaceRefId;

  // Node Interface
  // EFI_ACPI_AEST_INTERFACE_STRUCT   NodeInterface;

  // Node Interrupt Array
  // EFI_ACPI_AEST_INTERRUPT_STRUCT   NodeInterruptArray[n];
}

// AEST GIC interface type definitions.
public const ulong EFI_ACPI_AEST_GIC_INTERFACE_TYPE_GICC = 0x0;
public const ulong EFI_ACPI_AEST_GIC_INTERFACE_TYPE_GICD = 0x1;
public const ulong EFI_ACPI_AEST_GIC_INTERFACE_TYPE_GICR = 0x2;
public const ulong EFI_ACPI_AEST_GIC_INTERFACE_TYPE_GITS = 0x3;

// #pragma pack()

// #endif // ARM_ERROR_SOURCE_TABLE_H_
