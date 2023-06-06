using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Defives data structures per MultiProcessor Specification Ver 1.4.

  The MultiProcessor Specification defines an enhancement to the standard
  to which PC manufacturers design DOS-compatible systems.

Copyright (c) 2007 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _LEGACY_BIOS_MPTABLE_H_
// #define _LEGACY_BIOS_MPTABLE_H_

public unsafe partial class EFI
{
  public const ulong EFI_LEGACY_MP_TABLE_REV_1_4 = 0x04;

  //
  // Define MP table structures. All are packed.
  //
  // #pragma pack(1)
}

//public const ulong EFI_LEGACY_MP_TABLE_FLOATING_POINTER_SIGNATURE = SIGNATURE_32('_', 'M', 'P', '_');
[StructLayout(LayoutKind.Sequential)]
public unsafe struct FEATUREBYTE2_5
{
  public uint Reserved1; // = 6;
  public uint MutipleClk; // = 1;
  public uint Imcr; // = 1;
  public uint Reserved2; // = 24;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_FLOATING_POINTER
{
  public uint Signature;
  public uint PhysicalAddress;
  public byte Length;
  public byte SpecRev;
  public byte Checksum;
  public byte FeatureByte1;
  public FEATUREBYTE2_5 FeatureByte2_5;
}

public unsafe partial class EFI
{
  //public const ulong EFI_LEGACY_MP_TABLE_HEADER_SIGNATURE = SIGNATURE_32('P', 'C', 'M', 'P');
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_HEADER
{
  public uint Signature;
  public ushort BaseTableLength;
  public byte SpecRev;
  public byte Checksum;
  public fixed byte OemId[8];
  public fixed byte OemProductId[12];
  public uint OemTablePointer;
  public ushort OemTableSize;
  public ushort EntryCount;
  public uint LocalApicAddress;
  public ushort ExtendedTableLength;
  public byte ExtendedChecksum;
  public byte Reserved;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_TYPE
{
  public byte EntryType;
}

public unsafe partial class EFI
{
  //
  // Entry Type 0: Processor.
  //
  public const ulong EFI_LEGACY_MP_TABLE_ENTRY_TYPE_PROCESSOR = 0x00;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_PROCESSOR_FLAGS
{
  public byte Enabled; // = 1;
  public byte Bsp; // = 1;
  public byte Reserved; // = 6;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_PROCESSOR_SIGNATURE
{
  public uint Stepping; // = 4;
  public uint Model; // = 4;
  public uint Family; // = 4;
  public uint Reserved; // = 20;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_PROCESSOR_FEATURES
{
  public uint Fpu; // = 1;
  public uint Reserved1; // = 6;
  public uint Mce; // = 1;
  public uint Cx8; // = 1;
  public uint Apic; // = 1;
  public uint Reserved2; // = 22;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_PROCESSOR
{
  public byte EntryType;
  public byte Id;
  public byte Ver;
  public EFI_LEGACY_MP_TABLE_ENTRY_PROCESSOR_FLAGS Flags;
  public EFI_LEGACY_MP_TABLE_ENTRY_PROCESSOR_SIGNATURE Signature;
  public EFI_LEGACY_MP_TABLE_ENTRY_PROCESSOR_FEATURES Features;
  public uint Reserved1;
  public uint Reserved2;
}

public unsafe partial class EFI
{
  //
  // Entry Type 1: Bus.
  //
  public const ulong EFI_LEGACY_MP_TABLE_ENTRY_TYPE_BUS = 0x01;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_BUS
{
  public byte EntryType;
  public byte Id;
  public fixed byte TypeString[6];
}

public unsafe partial class EFI
{
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_CBUS = "CBUS  "; //  Corollary CBus
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_CBUSII = "CBUSII"; //  Corollary CBUS II
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_EISA = "EISA  "; //  Extended ISA
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_FUTURE = "FUTURE"; //  IEEE FutureBus
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_INTERN = "INTERN"; //  Internal bus
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_ISA = "ISA   "; //  Industry Standard Architecture
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_MBI = "MBI   "; //  Multibus I
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_MBII = "MBII  "; //  Multibus II
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_MCA = "MCA   "; //  Micro Channel Architecture
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_MPI = "MPI   "; //  MPI
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_MPSA = "MPSA  "; //  MPSA
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_NUBUS = "NUBUS "; //  Apple Macintosh NuBus
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_PCI = "PCI   "; //  Peripheral Component Interconnect
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_PCMCIA = "PCMCIA"; //  PC Memory Card International Assoc.
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_TC = "TC    "; //  DEC TurboChannel
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_VL = "VL    "; //  VESA Local Bus
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_VME = "VME   "; //  VMEbus
  public const string EFI_LEGACY_MP_TABLE_ENTRY_BUS_STRING_XPRESS = "XPRESS"; //  Express System Bus
                                                                              //
                                                                              // Entry Type 2: I/O APIC.
                                                                              //
  public const ulong EFI_LEGACY_MP_TABLE_ENTRY_TYPE_IOAPIC = 0x02;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_IOAPIC_FLAGS
{
  public byte Enabled; // = 1;
  public byte Reserved; // = 7;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_IOAPIC
{
  public byte EntryType;
  public byte Id;
  public byte Ver;
  public EFI_LEGACY_MP_TABLE_ENTRY_IOAPIC_FLAGS Flags;
  public uint Address;
}

public unsafe partial class EFI
{
  //
  // Entry Type 3: I/O Interrupt Assignment.
  //
  public const ulong EFI_LEGACY_MP_TABLE_ENTRY_TYPE_IO_INT = 0x03;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_INT_FLAGS
{
  public ushort Polarity; // = 2;
  public ushort Trigger; // = 2;
  public ushort Reserved; // = 12;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_INT_FIELDS
{
  public byte IntNo; // = 2;
  public byte Dev; // = 5;
  public byte Reserved; // = 1;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_INT_SOURCE_BUS_IRQ
{
  [FieldOffset(0)] public EFI_LEGACY_MP_TABLE_ENTRY_INT_FIELDS fields;
  [FieldOffset(0)] public byte @byte;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_IO_INT
{
  public byte EntryType;
  public byte IntType;
  public EFI_LEGACY_MP_TABLE_ENTRY_INT_FLAGS Flags;
  public byte SourceBusId;
  public EFI_LEGACY_MP_TABLE_ENTRY_INT_SOURCE_BUS_IRQ SourceBusIrq;
  public byte DestApicId;
  public byte DestApicIntIn;
}

public enum EFI_LEGACY_MP_TABLE_ENTRY_IO_INT_TYPE
{
  EfiLegacyMpTableEntryIoIntTypeInt = 0,
  EfiLegacyMpTableEntryIoIntTypeNmi = 1,
  EfiLegacyMpTableEntryIoIntTypeSmi = 2,
  EfiLegacyMpTableEntryIoIntTypeExtInt = 3,
}

public enum EFI_LEGACY_MP_TABLE_ENTRY_IO_INT_FLAGS_POLARITY
{
  EfiLegacyMpTableEntryIoIntFlagsPolaritySpec = 0x0,
  EfiLegacyMpTableEntryIoIntFlagsPolarityActiveHigh = 0x1,
  EfiLegacyMpTableEntryIoIntFlagsPolarityReserved = 0x2,
  EfiLegacyMpTableEntryIoIntFlagsPolarityActiveLow = 0x3,
}

public enum EFI_LEGACY_MP_TABLE_ENTRY_IO_INT_FLAGS_TRIGGER
{
  EfiLegacyMpTableEntryIoIntFlagsTriggerSpec = 0x0,
  EfiLegacyMpTableEntryIoIntFlagsTriggerEdge = 0x1,
  EfiLegacyMpTableEntryIoIntFlagsTriggerReserved = 0x2,
  EfiLegacyMpTableEntryIoIntFlagsTriggerLevel = 0x3,
}

public unsafe partial class EFI
{
  //
  // Entry Type 4: Local Interrupt Assignment.
  //
  public const ulong EFI_LEGACY_MP_TABLE_ENTRY_TYPE_LOCAL_INT = 0x04;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_LOCAL_INT
{
  public byte EntryType;
  public byte IntType;
  public EFI_LEGACY_MP_TABLE_ENTRY_INT_FLAGS Flags;
  public byte SourceBusId;
  public EFI_LEGACY_MP_TABLE_ENTRY_INT_SOURCE_BUS_IRQ SourceBusIrq;
  public byte DestApicId;
  public byte DestApicIntIn;
}

public enum EFI_LEGACY_MP_TABLE_ENTRY_LOCAL_INT_TYPE
{
  EfiLegacyMpTableEntryLocalIntTypeInt = 0,
  EfiLegacyMpTableEntryLocalIntTypeNmi = 1,
  EfiLegacyMpTableEntryLocalIntTypeSmi = 2,
  EfiLegacyMpTableEntryLocalIntTypeExtInt = 3,
}

public enum EFI_LEGACY_MP_TABLE_ENTRY_LOCAL_INT_FLAGS_POLARITY
{
  EfiLegacyMpTableEntryLocalIntFlagsPolaritySpec = 0x0,
  EfiLegacyMpTableEntryLocalIntFlagsPolarityActiveHigh = 0x1,
  EfiLegacyMpTableEntryLocalIntFlagsPolarityReserved = 0x2,
  EfiLegacyMpTableEntryLocalIntFlagsPolarityActiveLow = 0x3,
}

public enum EFI_LEGACY_MP_TABLE_ENTRY_LOCAL_INT_FLAGS_TRIGGER
{
  EfiLegacyMpTableEntryLocalIntFlagsTriggerSpec = 0x0,
  EfiLegacyMpTableEntryLocalIntFlagsTriggerEdge = 0x1,
  EfiLegacyMpTableEntryLocalIntFlagsTriggerReserved = 0x2,
  EfiLegacyMpTableEntryLocalIntFlagsTriggerLevel = 0x3,
}

public unsafe partial class EFI
{
  //
  // Entry Type 128: System Address Space Mapping.
  //
  public const ulong EFI_LEGACY_MP_TABLE_ENTRY_EXT_TYPE_SYS_ADDR_SPACE_MAPPING = 0x80;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_EXT_SYS_ADDR_SPACE_MAPPING
{
  public byte EntryType;
  public byte Length;
  public byte BusId;
  public byte AddressType;
  public ulong AddressBase;
  public ulong AddressLength;
}

public enum EFI_LEGACY_MP_TABLE_ENTRY_EXT_SYS_ADDR_SPACE_MAPPING_TYPE
{
  EfiLegacyMpTableEntryExtSysAddrSpaceMappingIo = 0,
  EfiLegacyMpTableEntryExtSysAddrSpaceMappingMemory = 1,
  EfiLegacyMpTableEntryExtSysAddrSpaceMappingPrefetch = 2,
}

public unsafe partial class EFI
{
  //
  // Entry Type 129: Bus Hierarchy.
  //
  public const ulong EFI_LEGACY_MP_TABLE_ENTRY_EXT_TYPE_BUS_HIERARCHY = 0x81;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_EXT_BUS_HIERARCHY_BUSINFO
{
  public byte SubtractiveDecode; // = 1;
  public byte Reserved; // = 7;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_EXT_BUS_HIERARCHY
{
  public byte EntryType;
  public byte Length;
  public byte BusId;
  public EFI_LEGACY_MP_TABLE_ENTRY_EXT_BUS_HIERARCHY_BUSINFO BusInfo;
  public byte ParentBus;
  public byte Reserved1;
  public byte Reserved2;
  public byte Reserved3;
}

public unsafe partial class EFI
{
  //
  // Entry Type 130: Compatibility Bus Address Space Modifier.
  //
  public const ulong EFI_LEGACY_MP_TABLE_ENTRY_EXT_TYPE_COMPAT_BUS_ADDR_SPACE_MODIFIER = 0x82;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_EXT_COMPAT_BUS_ADDR_SPACE_MODIFIER_ADDR_MODE
{
  public byte RangeMode; // = 1;
  public byte Reserved; // = 7;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_MP_TABLE_ENTRY_EXT_COMPAT_BUS_ADDR_SPACE_MODIFIER
{
  public byte EntryType;
  public byte Length;
  public byte BusId;
  public EFI_LEGACY_MP_TABLE_ENTRY_EXT_COMPAT_BUS_ADDR_SPACE_MODIFIER_ADDR_MODE AddrMode;
  public uint PredefinedRangeList;
}

// #pragma pack()

// #endif
