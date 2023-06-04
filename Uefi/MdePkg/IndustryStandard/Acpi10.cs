using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI 1.0b definitions from the ACPI Specification, revision 1.0b

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
Copyright (c) 2020, Arm Limited. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _ACPI_1_0_H_
// #define _ACPI_1_0_H_

// #include <IndustryStandard/AcpiAml.h>

///
/// Common table header, this prefaces all ACPI tables, including FACS, but
/// excluding the RSD PTR structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_COMMON_HEADER
{
  public uint Signature;
  public uint Length;
}

// #pragma pack(1)
///
/// The common ACPI description table header.  This structure prefaces most ACPI tables.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_DESCRIPTION_HEADER
{
  public uint Signature;
  public uint Length;
  public byte Revision;
  public byte Checksum;
  public fixed byte OemId[6];
  public ulong OemTableId;
  public uint OemRevision;
  public uint CreatorId;
  public uint CreatorRevision;
}
// #pragma pack()

public unsafe partial class EFI
{
  //
  // Define for Descriptor
  //
  public const ulong ACPI_SMALL_ITEM_FLAG = 0x00;
  public const ulong ACPI_LARGE_ITEM_FLAG = 0x01;

  //
  // Small Item Descriptor Name
  //
  public const ulong ACPI_SMALL_IRQ_DESCRIPTOR_NAME = 0x04;
  public const ulong ACPI_SMALL_DMA_DESCRIPTOR_NAME = 0x05;
  public const ulong ACPI_SMALL_START_DEPENDENT_DESCRIPTOR_NAME = 0x06;
  public const ulong ACPI_SMALL_END_DEPENDENT_DESCRIPTOR_NAME = 0x07;
  public const ulong ACPI_SMALL_IO_PORT_DESCRIPTOR_NAME = 0x08;
  public const ulong ACPI_SMALL_FIXED_IO_PORT_DESCRIPTOR_NAME = 0x09;
  public const ulong ACPI_SMALL_VENDOR_DEFINED_DESCRIPTOR_NAME = 0x0E;
  public const ulong ACPI_SMALL_END_TAG_DESCRIPTOR_NAME = 0x0F;

  //
  // Large Item Descriptor Name
  //
  public const ulong ACPI_LARGE_24_BIT_MEMORY_RANGE_DESCRIPTOR_NAME = 0x01;
  public const ulong ACPI_LARGE_VENDOR_DEFINED_DESCRIPTOR_NAME = 0x04;
  public const ulong ACPI_LARGE_32_BIT_MEMORY_RANGE_DESCRIPTOR_NAME = 0x05;
  public const ulong ACPI_LARGE_32_BIT_FIXED_MEMORY_RANGE_DESCRIPTOR_NAME = 0x06;
  public const ulong ACPI_LARGE_DWORD_ADDRESS_SPACE_DESCRIPTOR_NAME = 0x07;
  public const ulong ACPI_LARGE_WORD_ADDRESS_SPACE_DESCRIPTOR_NAME = 0x08;
  public const ulong ACPI_LARGE_EXTENDED_IRQ_DESCRIPTOR_NAME = 0x09;
  public const ulong ACPI_LARGE_QWORD_ADDRESS_SPACE_DESCRIPTOR_NAME = 0x0A;

  //
  // Small Item Descriptor Value
  //
  public const ulong ACPI_IRQ_NOFLAG_DESCRIPTOR = 0x22;
  public const ulong ACPI_IRQ_DESCRIPTOR = 0x23;
  public const ulong ACPI_DMA_DESCRIPTOR = 0x2A;
  public const ulong ACPI_START_DEPENDENT_DESCRIPTOR = 0x30;
  public const ulong ACPI_START_DEPENDENT_EX_DESCRIPTOR = 0x31;
  public const ulong ACPI_END_DEPENDENT_DESCRIPTOR = 0x38;
  public const ulong ACPI_IO_PORT_DESCRIPTOR = 0x47;
  public const ulong ACPI_FIXED_LOCATION_IO_PORT_DESCRIPTOR = 0x4B;
  public const ulong ACPI_END_TAG_DESCRIPTOR = 0x79;

  //
  // Large Item Descriptor Value
  //
  public const ulong ACPI_24_BIT_MEMORY_RANGE_DESCRIPTOR = 0x81;
  public const ulong ACPI_32_BIT_MEMORY_RANGE_DESCRIPTOR = 0x85;
  public const ulong ACPI_32_BIT_FIXED_MEMORY_RANGE_DESCRIPTOR = 0x86;
  public const ulong ACPI_DWORD_ADDRESS_SPACE_DESCRIPTOR = 0x87;
  public const ulong ACPI_WORD_ADDRESS_SPACE_DESCRIPTOR = 0x88;
  public const ulong ACPI_EXTENDED_INTERRUPT_DESCRIPTOR = 0x89;
  public const ulong ACPI_QWORD_ADDRESS_SPACE_DESCRIPTOR = 0x8A;
  public const ulong ACPI_ADDRESS_SPACE_DESCRIPTOR = 0x8A;

  //
  // Resource Type
  //
  public const ulong ACPI_ADDRESS_SPACE_TYPE_MEM = 0x00;
  public const ulong ACPI_ADDRESS_SPACE_TYPE_IO = 0x01;
  public const ulong ACPI_ADDRESS_SPACE_TYPE_BUS = 0x02;

  ///
  /// Power Management Timer frequency is fixed at 3.579545MHz.
  ///
  public const ulong ACPI_TIMER_FREQUENCY = 3579545;

  //
  // Ensure proper structure formats
  //
  // #pragma pack(1)
}

///
/// The common definition of QWORD, DWORD, and WORD
/// Address Space Descriptors.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_ADDRESS_SPACE_DESCRIPTOR
{
  public byte Desc;
  public ushort Len;
  public byte ResType;
  public byte GenFlag;
  public byte SpecificFlag;
  public ulong AddrSpaceGranularity;
  public ulong AddrRangeMin;
  public ulong AddrRangeMax;
  public ulong AddrTranslationOffset;
  public ulong AddrLen;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct ACPI_SMALL_RESOURCE_HEADER
{
  [FieldOffset(0)] public byte Byte;
  /*   PACKED struct { */
  [FieldOffset(0)] public byte Length; // = 3;
  [FieldOffset(0)] public byte Name; // = 4;
  [FieldOffset(0)] public byte Type; // = 1;
  /*   } Bits; */
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct ACPI_LARGE_RESOURCE_HEADER
{
  //PACKED union
  //{
  [FieldOffset(0)] public byte Byte;
  //PACKED struct {
  [FieldOffset(0)] public byte Name; // = 7;
  [FieldOffset(2)] public byte Type; // = 1;
   //}
  //} Header;
  [FieldOffset(0)] ushort Length;
} 

///
/// IRQ Descriptor.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_IRQ_NOFLAG_DESCRIPTOR
{
  public ACPI_SMALL_RESOURCE_HEADER Header;
  public ushort Mask;
}

///
/// IRQ Descriptor.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_IRQ_DESCRIPTOR
{
  public ACPI_SMALL_RESOURCE_HEADER Header;
  public ushort Mask;
  public byte Information;
}

///
/// DMA Descriptor.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_DMA_DESCRIPTOR
{
  public ACPI_SMALL_RESOURCE_HEADER Header;
  public byte ChannelMask;
  public byte Information;
}

///
/// I/O Port Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_IO_PORT_DESCRIPTOR
{
  public ACPI_SMALL_RESOURCE_HEADER Header;
  public byte Information;
  public ushort BaseAddressMin;
  public ushort BaseAddressMax;
  public byte Alignment;
  public byte Length;
}

///
/// Fixed Location I/O Port Descriptor.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_FIXED_LOCATION_IO_PORT_DESCRIPTOR
{
  public ACPI_SMALL_RESOURCE_HEADER Header;
  public ushort BaseAddress;
  public byte Length;
}

///
/// 24-Bit Memory Range Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_24_BIT_MEMORY_RANGE_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte Information;
  public ushort BaseAddressMin;
  public ushort BaseAddressMax;
  public ushort Alignment;
  public ushort Length;
}

///
/// 32-Bit Memory Range Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_32_BIT_MEMORY_RANGE_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte Information;
  public uint BaseAddressMin;
  public uint BaseAddressMax;
  public uint Alignment;
  public uint Length;
}

///
/// Fixed 32-Bit Fixed Memory Range Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_32_BIT_FIXED_MEMORY_RANGE_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte Information;
  public uint BaseAddress;
  public uint Length;
}

///
/// QWORD Address Space Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_QWORD_ADDRESS_SPACE_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte ResType;
  public byte GenFlag;
  public byte SpecificFlag;
  public ulong AddrSpaceGranularity;
  public ulong AddrRangeMin;
  public ulong AddrRangeMax;
  public ulong AddrTranslationOffset;
  public ulong AddrLen;
}

///
/// DWORD Address Space Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_DWORD_ADDRESS_SPACE_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte ResType;
  public byte GenFlag;
  public byte SpecificFlag;
  public uint AddrSpaceGranularity;
  public uint AddrRangeMin;
  public uint AddrRangeMax;
  public uint AddrTranslationOffset;
  public uint AddrLen;
}

///
/// WORD Address Space Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_WORD_ADDRESS_SPACE_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte ResType;
  public byte GenFlag;
  public byte SpecificFlag;
  public ushort AddrSpaceGranularity;
  public ushort AddrRangeMin;
  public ushort AddrRangeMax;
  public ushort AddrTranslationOffset;
  public ushort AddrLen;
}

///
/// Extended Interrupt Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_EXTENDED_INTERRUPT_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte InterruptVectorFlags;
  public byte InterruptTableLength;
  public fixed uint InterruptNumber[1];
}

// #pragma pack()

///
/// The End tag identifies an end of resource data.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_END_TAG_DESCRIPTOR
{
  public byte Desc;
  public byte Checksum;
}

public unsafe partial class EFI
{
  //
  // General use definitions
  //
  public const ulong EFI_ACPI_RESERVED_BYTE = 0x00;
  public const ulong EFI_ACPI_RESERVED_WORD = 0x0000;
  public const ulong EFI_ACPI_RESERVED_DWORD = 0x00000000;
  public const ulong EFI_ACPI_RESERVED_QWORD = 0x0000000000000000;

  //
  // Resource Type Specific Flags
  // Ref ACPI specification 6.4.3.5.5
  //
  // Bit [0]    : Write Status, _RW
  //
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_READ_WRITE = (1 << 0);
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_READ_ONLY = (0 << 0);
  //
  // Bit [2:1]  : Memory Attributes, _MEM
  //
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_NON_CACHEABLE = (0 << 1);
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_CACHEABLE = (1 << 1);
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_CACHEABLE_WRITE_COMBINING = (2 << 1);
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_CACHEABLE_PREFETCHABLE = (3 << 1);
  //
  // Bit [4:3]  : Memory Attributes, _MTP
  //
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_ADDRESS_RANGE_MEMORY = (0 << 3);
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_ADDRESS_RANGE_RESERVED = (1 << 3);
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_ADDRESS_RANGE_ACPI = (2 << 3);
  public const ulong EFI_APCI_MEMORY_RESOURCE_SPECIFIC_FLAG_ADDRESS_RANGE_NVS = (3 << 3);
  //
  // Bit [5]    : Memory to I/O Translation, _TTP
  //
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_TYPE_TRANSLATION = (1 << 5);
  public const ulong EFI_ACPI_MEMORY_RESOURCE_SPECIFIC_FLAG_TYPE_STATIC = (0 << 5);

  //
  // IRQ Information
  // Ref ACPI specification 6.4.2.1
  //
  public const ulong EFI_ACPI_IRQ_SHARABLE_MASK = 0x10;
  public const ulong EFI_ACPI_IRQ_SHARABLE = 0x10;

  public const ulong EFI_ACPI_IRQ_POLARITY_MASK = 0x08;
  public const ulong EFI_ACPI_IRQ_HIGH_TRUE = 0x00;
  public const ulong EFI_ACPI_IRQ_LOW_FALSE = 0x08;

  public const ulong EFI_ACPI_IRQ_MODE = 0x01;
  public const ulong EFI_ACPI_IRQ_LEVEL_TRIGGERED = 0x00;
  public const ulong EFI_ACPI_IRQ_EDGE_TRIGGERED = 0x01;

  //
  // DMA Information
  // Ref ACPI specification 6.4.2.2
  //
  public const ulong EFI_ACPI_DMA_SPEED_TYPE_MASK = 0x60;
  public const ulong EFI_ACPI_DMA_SPEED_TYPE_COMPATIBILITY = 0x00;
  public const ulong EFI_ACPI_DMA_SPEED_TYPE_A = 0x20;
  public const ulong EFI_ACPI_DMA_SPEED_TYPE_B = 0x40;
  public const ulong EFI_ACPI_DMA_SPEED_TYPE_F = 0x60;

  public const ulong EFI_ACPI_DMA_BUS_MASTER_MASK = 0x04;
  public const ulong EFI_ACPI_DMA_BUS_MASTER = 0x04;

  public const ulong EFI_ACPI_DMA_TRANSFER_TYPE_MASK = 0x03;
  public const ulong EFI_ACPI_DMA_TRANSFER_TYPE_8_BIT = 0x00;
  public const ulong EFI_ACPI_DMA_TRANSFER_TYPE_8_BIT_AND_16_BIT = 0x01;
  public const ulong EFI_ACPI_DMA_TRANSFER_TYPE_16_BIT = 0x02;

  //
  // IO Information
  // Ref ACPI specification 6.4.2.5
  //
  public const ulong EFI_ACPI_IO_DECODE_MASK = 0x01;
  public const ulong EFI_ACPI_IO_DECODE_16_BIT = 0x01;
  public const ulong EFI_ACPI_IO_DECODE_10_BIT = 0x00;

  //
  // Memory Information
  // Ref ACPI specification 6.4.3.4
  //
  public const ulong EFI_ACPI_MEMORY_WRITE_STATUS_MASK = 0x01;
  public const ulong EFI_ACPI_MEMORY_WRITABLE = 0x01;
  public const ulong EFI_ACPI_MEMORY_NON_WRITABLE = 0x00;

  //
  // Interrupt Vector Flags definitions for Extended Interrupt Descriptor
  // Ref ACPI specification 6.4.3.6
  //
  public const ulong EFI_ACPI_EXTENDED_INTERRUPT_FLAG_PRODUCER_CONSUMER_MASK = BIT0;
  public const ulong EFI_ACPI_EXTENDED_INTERRUPT_FLAG_MODE_MASK = BIT1;
  public const ulong EFI_ACPI_EXTENDED_INTERRUPT_FLAG_POLARITY_MASK = BIT2;
  public const ulong EFI_ACPI_EXTENDED_INTERRUPT_FLAG_SHARABLE_MASK = BIT3;
  public const ulong EFI_ACPI_EXTENDED_INTERRUPT_FLAG_WAKE_CAPABLITY_MASK = BIT4;

  //
  // Ensure proper structure formats
  //
  // #pragma pack(1)
  //
  // ACPI 1.0b table structures
  //
}

///
/// Root System Description Pointer Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_1_0_ROOT_SYSTEM_DESCRIPTION_POINTER
{
  public ulong Signature;
  public byte Checksum;
  public fixed byte OemId[6];
  public byte Reserved;
  public uint RsdtAddress;
}

//
// Root System Description Table
// No definition needed as it is a common description table header, the same with
// EFI_ACPI_DESCRIPTION_HEADER, followed by a variable number of uint table pointers.
//

public unsafe partial class EFI
{
  ///
  /// RSDT Revision (as defined in ACPI 1.0b specification).
  ///
  public const ulong EFI_ACPI_1_0_ROOT_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x01;
}

///
/// Fixed ACPI Description Table Structure (FADT).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_1_0_FIXED_ACPI_DESCRIPTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint FirmwareCtrl;
  public uint Dsdt;
  public byte IntModel;
  public byte Reserved1;
  public ushort SciInt;
  public uint SmiCmd;
  public byte AcpiEnable;
  public byte AcpiDisable;
  public byte S4BiosReq;
  public byte Reserved2;
  public uint Pm1aEvtBlk;
  public uint Pm1bEvtBlk;
  public uint Pm1aCntBlk;
  public uint Pm1bCntBlk;
  public uint Pm2CntBlk;
  public uint PmTmrBlk;
  public uint Gpe0Blk;
  public uint Gpe1Blk;
  public byte Pm1EvtLen;
  public byte Pm1CntLen;
  public byte Pm2CntLen;
  public byte PmTmLen;
  public byte Gpe0BlkLen;
  public byte Gpe1BlkLen;
  public byte Gpe1Base;
  public byte Reserved3;
  public ushort PLvl2Lat;
  public ushort PLvl3Lat;
  public ushort FlushSize;
  public ushort FlushStride;
  public byte DutyOffset;
  public byte DutyWidth;
  public byte DayAlrm;
  public byte MonAlrm;
  public byte Century;
  public byte Reserved4;
  public byte Reserved5;
  public byte Reserved6;
  public uint Flags;
}

public unsafe partial class EFI
{
  ///
  /// FADT Version (as defined in ACPI 1.0b specification).
  ///
  public const ulong EFI_ACPI_1_0_FIXED_ACPI_DESCRIPTION_TABLE_REVISION = 0x01;

  public const ulong EFI_ACPI_1_0_INT_MODE_DUAL_PIC = 0;
  public const ulong EFI_ACPI_1_0_INT_MODE_MULTIPLE_APIC = 1;

  //
  // Fixed ACPI Description Table Fixed Feature Flags
  // All other bits are reserved and must be set to 0.
  //
  public const ulong EFI_ACPI_1_0_WBINVD = BIT0;
  public const ulong EFI_ACPI_1_0_WBINVD_FLUSH = BIT1;
  public const ulong EFI_ACPI_1_0_PROC_C1 = BIT2;
  public const ulong EFI_ACPI_1_0_P_LVL2_UP = BIT3;
  public const ulong EFI_ACPI_1_0_PWR_BUTTON = BIT4;
  public const ulong EFI_ACPI_1_0_SLP_BUTTON = BIT5;
  public const ulong EFI_ACPI_1_0_FIX_RTC = BIT6;
  public const ulong EFI_ACPI_1_0_RTC_S4 = BIT7;
  public const ulong EFI_ACPI_1_0_TMR_VAL_EXT = BIT8;
  public const ulong EFI_ACPI_1_0_DCK_CAP = BIT9;
}

///
/// Firmware ACPI Control Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_1_0_FIRMWARE_ACPI_CONTROL_STRUCTURE
{
  public uint Signature;
  public uint Length;
  public uint HardwareSignature;
  public uint FirmwareWakingVector;
  public uint GlobalLock;
  public uint Flags;
  public fixed byte Reserved[40];
}

public unsafe partial class EFI
{
  ///
  /// Firmware Control Structure Feature Flags.
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_1_0_S4BIOS_F = BIT0;
}

///
/// Multiple APIC Description Table header definition.  The rest of the table
/// must be defined in a platform-specific manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_1_0_MULTIPLE_APIC_DESCRIPTION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint LocalApicAddress;
  public uint Flags;
}

public unsafe partial class EFI
{
  ///
  /// MADT Revision (as defined in ACPI 1.0b specification).
  ///
  public const ulong EFI_ACPI_1_0_MULTIPLE_APIC_DESCRIPTION_TABLE_REVISION = 0x01;

  ///
  /// Multiple APIC Flags
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_1_0_PCAT_COMPAT = BIT0;

  //
  // Multiple APIC Description Table APIC structure types
  // All other values between 0x05 an 0xFF are reserved and
  // will be ignored by OSPM.
  //
  public const ulong EFI_ACPI_1_0_PROCESSOR_LOCAL_APIC = 0x00;
  public const ulong EFI_ACPI_1_0_IO_APIC = 0x01;
  public const ulong EFI_ACPI_1_0_INTERRUPT_SOURCE_OVERRIDE = 0x02;
  public const ulong EFI_ACPI_1_0_NON_MASKABLE_INTERRUPT_SOURCE = 0x03;
  public const ulong EFI_ACPI_1_0_LOCAL_APIC_NMI = 0x04;

  //
  // APIC Structure Definitions
  //
}

///
/// Processor Local APIC Structure Definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_1_0_PROCESSOR_LOCAL_APIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte AcpiProcessorId;
  public byte ApicId;
  public uint Flags;
}

public unsafe partial class EFI
{
  ///
  /// Local APIC Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_1_0_LOCAL_APIC_ENABLED = BIT0;
}

///
/// IO APIC Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_1_0_IO_APIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte IoApicId;
  public byte Reserved;
  public uint IoApicAddress;
  public uint SystemVectorBase;
}

///
/// Interrupt Source Override Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_1_0_INTERRUPT_SOURCE_OVERRIDE_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte Bus;
  public byte Source;
  public uint GlobalSystemInterruptVector;
  public ushort Flags;
}

///
/// Non-Maskable Interrupt Source Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_1_0_NON_MASKABLE_INTERRUPT_SOURCE_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Flags;
  public uint GlobalSystemInterruptVector;
}

///
/// Local APIC NMI Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_1_0_LOCAL_APIC_NMI_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte AcpiProcessorId;
  public ushort Flags;
  public byte LocalApicInti;
}

///
/// Smart Battery Description Table (SBST)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_1_0_SMART_BATTERY_DESCRIPTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint WarningEnergyLevel;
  public uint LowEnergyLevel;
  public uint CriticalEnergyLevel;
}

//
// Known table signatures
//

public unsafe partial class EFI
{
  /////
  ///// "RSD PTR " Root System Description Pointer.
  /////
  //public const ulong EFI_ACPI_1_0_ROOT_SYSTEM_DESCRIPTION_POINTER_SIGNATURE = SIGNATURE_64('R', 'S', 'D', ' ', 'P', 'T', 'R', ' ');

  /////
  ///// "APIC" Multiple APIC Description Table.
  /////
  //public const ulong EFI_ACPI_1_0_APIC_SIGNATURE = SIGNATURE_32('A', 'P', 'I', 'C');

  /////
  ///// "DSDT" Differentiated System Description Table.
  /////
  //public const ulong EFI_ACPI_1_0_DIFFERENTIATED_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('D', 'S', 'D', 'T');

  /////
  ///// "FACS" Firmware ACPI Control Structure.
  /////
  //public const ulong EFI_ACPI_1_0_FIRMWARE_ACPI_CONTROL_STRUCTURE_SIGNATURE = SIGNATURE_32('F', 'A', 'C', 'S');

  /////
  ///// "FACP" Fixed ACPI Description Table.
  /////
  //public const ulong EFI_ACPI_1_0_FIXED_ACPI_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('F', 'A', 'C', 'P');

  /////
  ///// "PSDT" Persistent System Description Table.
  /////
  //public const ulong EFI_ACPI_1_0_PERSISTENT_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('P', 'S', 'D', 'T');

  /////
  ///// "RSDT" Root System Description Table.
  /////
  //public const ulong EFI_ACPI_1_0_ROOT_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('R', 'S', 'D', 'T');

  /////
  ///// "SBST" Smart Battery Specification Table.
  /////
  //public const ulong EFI_ACPI_1_0_SMART_BATTERY_SPECIFICATION_TABLE_SIGNATURE = SIGNATURE_32('S', 'B', 'S', 'T');

  /////
  ///// "SSDT" Secondary System Description Table.
  /////
  //public const ulong EFI_ACPI_1_0_SECONDARY_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('S', 'S', 'D', 'T');

  // #pragma pack()
}

// #endif
