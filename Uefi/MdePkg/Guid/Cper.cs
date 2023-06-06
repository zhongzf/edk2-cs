using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  GUIDs and definitions used for Common Platform Error Record.

  Copyright (c) 2011 - 2017, Intel Corporation. All rights reserved.<BR>
  (C) Copyright 2016 Hewlett Packard Enterprise Development LP<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  GUIDs defined in UEFI 2.7 Specification.

**/

// #ifndef __CPER_GUID_H__
// #define __CPER_GUID_H__

// #pragma pack(1)

public unsafe partial class EFI
{
  //public const ulong EFI_ERROR_RECORD_SIGNATURE_START = SIGNATURE_32('C', 'P', 'E', 'R');
  public const ulong EFI_ERROR_RECORD_SIGNATURE_END = 0xFFFFFFFF;

  public const ulong EFI_ERROR_RECORD_REVISION = 0x0101;

  ///
  /// Error Severity in Error Record Header and Error Section Descriptor
  ///@{
  public const ulong EFI_GENERIC_ERROR_RECOVERABLE = 0x00000000;
  public const ulong EFI_GENERIC_ERROR_FATAL = 0x00000001;
  public const ulong EFI_GENERIC_ERROR_CORRECTED = 0x00000002;
  public const ulong EFI_GENERIC_ERROR_INFO = 0x00000003;
  ///@}

  ///
  /// The validation bit mask indicates the validity of the following fields
  /// in Error Record Header.
  ///@{
  public const ulong EFI_ERROR_RECORD_HEADER_PLATFORM_ID_VALID = BIT0;
  public const ulong EFI_ERROR_RECORD_HEADER_TIME_STAMP_VALID = BIT1;
  public const ulong EFI_ERROR_RECORD_HEADER_PARTITION_ID_VALID = BIT2;
  ///@}

  ///
  /// Timestamp is precise if this bit is set and correlates to the time of the
  /// error event.
  ///
  public const ulong EFI_ERROR_TIME_STAMP_PRECISE = BIT0;
}

///
/// The timestamp correlates to the time when the error information was collected
/// by the system software and may not necessarily represent the time of the error
/// event. The timestamp contains the local time in BCD format.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ERROR_TIME_STAMP
{
  public byte Seconds;
  public byte Minutes;
  public byte Hours;
  public byte Flag;
  public byte Day;
  public byte Month;
  public byte Year;
  public byte Century;
}

public unsafe partial class EFI
{
  ///
  /// GUID value indicating the record association with an error event notification type.
  ///@{
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYEP_CMC_GUID => new GUID(
      0x2DCE8BB1, 0xBDD7, 0x450e, 0xB9, 0xAD, 0x9C, 0xF4, 0xEB, 0xD4, 0xF8, 0x90);
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYEP_CPE_GUID => new GUID(
      0x4E292F96, 0xD843, 0x4a55, 0xA8, 0xC2, 0xD4, 0x81, 0xF2, 0x7E, 0xBE, 0xEE);
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYEP_MCE_GUID => new GUID(
      0xE8F56FFE, 0x919C, 0x4cc5, 0xBA, 0x88, 0x65, 0xAB, 0xE1, 0x49, 0x13, 0xBB);
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYEP_PCIE_GUID => new GUID(
      0xCF93C01F, 0x1A16, 0x4dfc, 0xB8, 0xBC, 0x9C, 0x4D, 0xAF, 0x67, 0xC1, 0x04);
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYEP_INIT_GUID => new GUID(
      0xCC5263E8, 0x9308, 0x454a, 0x89, 0xD0, 0x34, 0x0B, 0xD3, 0x9B, 0xC9, 0x8E);
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYEP_NMI_GUID => new GUID(
      0x5BAD89FF, 0xB7E6, 0x42c9, 0x81, 0x4A, 0xCF, 0x24, 0x85, 0xD6, 0xE9, 0x8A);
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYEP_BOOT_GUID => new GUID(
      0x3D61A466, 0xAB40, 0x409a, 0xA6, 0x98, 0xF3, 0x62, 0xD4, 0x64, 0xB3, 0x8F);
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYEP_DMAR_GUID => new GUID(
      0x667DD791, 0xC6B3, 0x4c27, 0x8A, 0x6B, 0x0F, 0x8E, 0x72, 0x2D, 0xEB, 0x41);
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYPE_DMAR_SEA => new GUID(0x9A78788A, 0xBBE8, 0x11E4, 0x80, 0x9E, 0x67, 0x61, 0x1E, 0x5D, 0x46, 0xB0);
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYPE_DMAR_SEI => new GUID(0x5C284C81, 0xB0AE, 0x4E87, 0xA3, 0x22, 0xB0, 0x4C, 0x85, 0x62, 0x43, 0x23);
  public static EFI_GUID EFI_EVENT_NOTIFICATION_TYPE_DMAR_PEI => new GUID(0x09A9D5AC, 0x5204, 0x4214, 0x96, 0xE5, 0x94, 0x99, 0x2E, 0x75, 0x2B, 0xCD);
  ///@}

  ///
  /// Error Record Header Flags
  ///@{
  public const ulong EFI_HW_ERROR_FLAGS_RECOVERED = 0x00000001;
  public const ulong EFI_HW_ERROR_FLAGS_PREVERR = 0x00000002;
  public const ulong EFI_HW_ERROR_FLAGS_SIMULATED = 0x00000004;
  ///@}
}

///
/// Common error record header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_COMMON_ERROR_RECORD_HEADER
{
  public uint SignatureStart;
  public ushort Revision;
  public uint SignatureEnd;
  public ushort SectionCount;
  public uint ErrorSeverity;
  public uint ValidationBits;
  public uint RecordLength;
  public EFI_ERROR_TIME_STAMP TimeStamp;
  public EFI_GUID PlatformID;
  public EFI_GUID PartitionID;
  public EFI_GUID CreatorID;
  public EFI_GUID NotificationType;
  public ulong RecordID;
  public uint Flags;
  public ulong PersistenceInfo;
  public fixed byte Resv1[12];
  ///
  /// An array of SectionCount descriptors for the associated
  /// sections. The number of valid sections is equivalent to the
  /// SectionCount. The buffer size of the record may include
  /// more space to dynamically add additional Section
  /// Descriptors to the error record.
  ///
}

public unsafe partial class EFI
{
  public const ulong EFI_ERROR_SECTION_REVISION = 0x0100;

  ///
  /// Validity Fields in Error Section Descriptor.
  ///
  public const ulong EFI_ERROR_SECTION_FRU_ID_VALID = BIT0;
  public const ulong EFI_ERROR_SECTION_FRU_STRING_VALID = BIT1;

  ///
  /// Flag field contains information that describes the error section
  /// in Error Section Descriptor.
  ///
  public const ulong EFI_ERROR_SECTION_FLAGS_PRIMARY = BIT0;
  public const ulong EFI_ERROR_SECTION_FLAGS_CONTAINMENT_WARNING = BIT1;
  public const ulong EFI_ERROR_SECTION_FLAGS_RESET = BIT2;
  public const ulong EFI_ERROR_SECTION_FLAGS_ERROR_THRESHOLD_EXCEEDED = BIT3;
  public const ulong EFI_ERROR_SECTION_FLAGS_RESOURCE_NOT_ACCESSIBLE = BIT4;
  public const ulong EFI_ERROR_SECTION_FLAGS_LATENT_ERROR = BIT5;

  ///
  /// Error Sectition Type GUIDs in Error Section Descriptor
  ///@{
  public static EFI_GUID EFI_ERROR_SECTION_PROCESSOR_GENERIC_GUID => new GUID(
      0x9876ccad, 0x47b4, 0x4bdb, 0xb6, 0x5e, 0x16, 0xf1, 0x93, 0xc4, 0xf3, 0xdb);
  public static EFI_GUID EFI_ERROR_SECTION_PROCESSOR_SPECIFIC_GUID => new GUID(
      0xdc3ea0b0, 0xa144, 0x4797, 0xb9, 0x5b, 0x53, 0xfa, 0x24, 0x2b, 0x6e, 0x1d);
  public static EFI_GUID EFI_ERROR_SECTION_PROCESSOR_SPECIFIC_IA32X64_GUID => new GUID(
      0xdc3ea0b0, 0xa144, 0x4797, 0xb9, 0x5b, 0x53, 0xfa, 0x24, 0x2b, 0x6e, 0x1d);
  public static EFI_GUID EFI_ERROR_SECTION_PROCESSOR_SPECIFIC_ARM_GUID => new GUID(
      0xe19e3d16, 0xbc11, 0x11e4, 0x9c, 0xaa, 0xc2, 0x05, 0x1d, 0x5d, 0x46, 0xb0);
  public static EFI_GUID EFI_ERROR_SECTION_PLATFORM_MEMORY_GUID => new GUID(
      0xa5bc1114, 0x6f64, 0x4ede, 0xb8, 0x63, 0x3e, 0x83, 0xed, 0x7c, 0x83, 0xb1);
  public static EFI_GUID EFI_ERROR_SECTION_PLATFORM_MEMORY2_GUID => new GUID(
      0x61EC04FC, 0x48E6, 0xD813, 0x25, 0xC9, 0x8D, 0xAA, 0x44, 0x75, 0x0B, 0x12);
  public static EFI_GUID EFI_ERROR_SECTION_PCIE_GUID => new GUID(
      0xd995e954, 0xbbc1, 0x430f, 0xad, 0x91, 0xb4, 0x4d, 0xcb, 0x3c, 0x6f, 0x35);
  public static EFI_GUID EFI_ERROR_SECTION_FW_ERROR_RECORD_GUID => new GUID(
      0x81212a96, 0x09ed, 0x4996, 0x94, 0x71, 0x8d, 0x72, 0x9c, 0x8e, 0x69, 0xed);
  public static EFI_GUID EFI_ERROR_SECTION_PCI_PCIX_BUS_GUID => new GUID(
      0xc5753963, 0x3b84, 0x4095, 0xbf, 0x78, 0xed, 0xda, 0xd3, 0xf9, 0xc9, 0xdd);
  public static EFI_GUID EFI_ERROR_SECTION_PCI_DEVICE_GUID => new GUID(
      0xeb5e4685, 0xca66, 0x4769, 0xb6, 0xa2, 0x26, 0x06, 0x8b, 0x00, 0x13, 0x26);
  public static EFI_GUID EFI_ERROR_SECTION_DMAR_GENERIC_GUID => new GUID(
      0x5b51fef7, 0xc79d, 0x4434, 0x8f, 0x1b, 0xaa, 0x62, 0xde, 0x3e, 0x2c, 0x64);
  public static EFI_GUID EFI_ERROR_SECTION_DIRECTED_IO_DMAR_GUID => new GUID(
      0x71761d37, 0x32b2, 0x45cd, 0xa7, 0xd0, 0xb0, 0xfe, 0xdd, 0x93, 0xe8, 0xcf);
  public static EFI_GUID EFI_ERROR_SECTION_IOMMU_DMAR_GUID => new GUID(
      0x036f84e1, 0x7f37, 0x428c, 0xa7, 0x9e, 0x57, 0x5f, 0xdf, 0xaa, 0x84, 0xec);
  ///@}
}

///
/// Error Section Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ERROR_SECTION_DESCRIPTOR
{
  public uint SectionOffset;
  public uint SectionLength;
  public ushort Revision;
  public byte SecValidMask;
  public byte Resv1;
  public uint SectionFlags;
  public EFI_GUID SectionType;
  public EFI_GUID FruId;
  public uint Severity;
  public fixed byte FruString[20];
}

public unsafe partial class EFI
{
  ///
  /// The validation bit mask indicates whether or not each of the following fields are
  /// valid in Proessor Generic Error section.
  ///@{
  public const ulong EFI_GENERIC_ERROR_PROC_TYPE_VALID = BIT0;
  public const ulong EFI_GENERIC_ERROR_PROC_ISA_VALID = BIT1;
  public const ulong EFI_GENERIC_ERROR_PROC_ERROR_TYPE_VALID = BIT2;
  public const ulong EFI_GENERIC_ERROR_PROC_OPERATION_VALID = BIT3;
  public const ulong EFI_GENERIC_ERROR_PROC_FLAGS_VALID = BIT4;
  public const ulong EFI_GENERIC_ERROR_PROC_LEVEL_VALID = BIT5;
  public const ulong EFI_GENERIC_ERROR_PROC_VERSION_VALID = BIT6;
  public const ulong EFI_GENERIC_ERROR_PROC_BRAND_VALID = BIT7;
  public const ulong EFI_GENERIC_ERROR_PROC_ID_VALID = BIT8;
  public const ulong EFI_GENERIC_ERROR_PROC_TARGET_ADDR_VALID = BIT9;
  public const ulong EFI_GENERIC_ERROR_PROC_REQUESTER_ID_VALID = BIT10;
  public const ulong EFI_GENERIC_ERROR_PROC_RESPONDER_ID_VALID = BIT11;
  public const ulong EFI_GENERIC_ERROR_PROC_INST_IP_VALID = BIT12;
  ///@}

  ///
  /// The type of the processor architecture in Proessor Generic Error section.
  ///@{
  public const ulong EFI_GENERIC_ERROR_PROC_TYPE_IA32_X64 = 0x00;
  public const ulong EFI_GENERIC_ERROR_PROC_TYPE_IA64 = 0x01;
  public const ulong EFI_GENERIC_ERROR_PROC_TYPE_ARM = 0x02;
  ///@}

  ///
  /// The type of the instruction set executing when the error occurred in Proessor
  /// Generic Error section.
  ///@{
  public const ulong EFI_GENERIC_ERROR_PROC_ISA_IA32 = 0x00;
  public const ulong EFI_GENERIC_ERROR_PROC_ISA_IA64 = 0x01;
  public const ulong EFI_GENERIC_ERROR_PROC_ISA_X64 = 0x02;
  public const ulong EFI_GENERIC_ERROR_PROC_ISA_ARM_A32_T32 = 0x03;
  public const ulong EFI_GENERIC_ERROR_PROC_ISA_ARM_A64 = 0x04;
  ///@}

  ///
  /// The type of error that occurred in Proessor Generic Error section.
  ///@{
  public const ulong EFI_GENERIC_ERROR_PROC_ERROR_TYPE_UNKNOWN = 0x00;
  public const ulong EFI_GENERIC_ERROR_PROC_ERROR_TYPE_CACHE = 0x01;
  public const ulong EFI_GENERIC_ERROR_PROC_ERROR_TYPE_TLB = 0x02;
  public const ulong EFI_GENERIC_ERROR_PROC_ERROR_TYPE_BUS = 0x04;
  public const ulong EFI_GENERIC_ERROR_PROC_ERROR_TYPE_MICRO_ARCH = 0x08;
  ///@}

  ///
  /// The type of operation in Proessor Generic Error section.
  ///@{
  public const ulong EFI_GENERIC_ERROR_PROC_OPERATION_GENERIC = 0x00;
  public const ulong EFI_GENERIC_ERROR_PROC_OPERATION_DATA_READ = 0x01;
  public const ulong EFI_GENERIC_ERROR_PROC_OPERATION_DATA_WRITE = 0x02;
  public const ulong EFI_GENERIC_ERROR_PROC_OPERATION_INSTRUCTION_EXEC = 0x03;
  ///@}

  ///
  /// Flags bit mask indicates additional information about the error in Proessor Generic
  /// Error section
  ///@{
  public const ulong EFI_GENERIC_ERROR_PROC_FLAGS_RESTARTABLE = BIT0;
  public const ulong EFI_GENERIC_ERROR_PROC_FLAGS_PRECISE_IP = BIT1;
  public const ulong EFI_GENERIC_ERROR_PROC_FLAGS_OVERFLOW = BIT2;
  public const ulong EFI_GENERIC_ERROR_PROC_FLAGS_CORRECTED = BIT3;
  ///@}
}

///
/// Processor Generic Error Section
/// describes processor reported hardware errors for logical processors in the system.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PROCESSOR_GENERIC_ERROR_DATA
{
  public ulong ValidFields;
  public byte Type;
  public byte Isa;
  public byte ErrorType;
  public byte Operation;
  public byte Flags;
  public byte Level;
  public ushort Resv1;
  public ulong VersionInfo;
  public fixed byte BrandString[128];
  public ulong ApicId;
  public ulong TargetAddr;
  public ulong RequestorId;
  public ulong ResponderId;
  public ulong InstructionIP;
}

//#if defined (MDE_CPU_IA32) || defined (MDE_CPU_X64)
///
/// IA32 and x64 Specific definitions.
///

public unsafe partial class EFI
{
  ///
  /// GUID value indicating the type of Processor Error Information structure
  /// in IA32/X64 Processor Error Information Structure.
  ///@{
  public static EFI_GUID EFI_IA32_X64_ERROR_TYPE_CACHE_CHECK_GUID => new GUID(
      0xA55701F5, 0xE3EF, 0x43de, 0xAC, 0x72, 0x24, 0x9B, 0x57, 0x3F, 0xAD, 0x2C);
  public static EFI_GUID EFI_IA32_X64_ERROR_TYPE_TLB_CHECK_GUID => new GUID(
      0xFC06B535, 0x5E1F, 0x4562, 0x9F, 0x25, 0x0A, 0x3B, 0x9A, 0xDB, 0x63, 0xC3);
  public static EFI_GUID EFI_IA32_X64_ERROR_TYPE_BUS_CHECK_GUID => new GUID(
      0x1CF3F8B3, 0xC5B1, 0x49a2, 0xAA, 0x59, 0x5E, 0xEF, 0x92, 0xFF, 0xA6, 0x3C);
  public static EFI_GUID EFI_IA32_X64_ERROR_TYPE_MS_CHECK_GUID => new GUID(
      0x48AB7F57, 0xDC34, 0x4f6c, 0xA7, 0xD3, 0xB0, 0xB5, 0xB0, 0xA7, 0x43, 0x14);
  ///@}

  ///
  /// The validation bit mask indicates which fields in the IA32/X64 Processor
  /// Error Record structure are valid.
  ///@{
  public const ulong EFI_IA32_X64_PROCESSOR_ERROR_APIC_ID_VALID = BIT0;
  public const ulong EFI_IA32_X64_PROCESSOR_ERROR_CPU_ID_INFO_VALID = BIT1;
  ///@}
}

///
/// IA32/X64 Processor Error Record
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IA32_X64_PROCESSOR_ERROR_RECORD
{
  public ulong ValidFields;
  public ulong ApicId;
  public fixed byte CpuIdInfo[48];
}

public unsafe partial class EFI
{
  ///
  /// The validation bit mask indicates which fields in the Cache Check structure
  /// are valid.
  ///@{
  public const ulong EFI_CACHE_CHECK_TRANSACTION_TYPE_VALID = BIT0;
  public const ulong EFI_CACHE_CHECK_OPERATION_VALID = BIT1;
  public const ulong EFI_CACHE_CHECK_LEVEL_VALID = BIT2;
  public const ulong EFI_CACHE_CHECK_CONTEXT_CORRUPT_VALID = BIT3;
  public const ulong EFI_CACHE_CHECK_UNCORRECTED_VALID = BIT4;
  public const ulong EFI_CACHE_CHECK_PRECISE_IP_VALID = BIT5;
  public const ulong EFI_CACHE_CHECK_RESTARTABLE_VALID = BIT6;
  public const ulong EFI_CACHE_CHECK_OVERFLOW_VALID = BIT7;
  ///@}

  ///
  /// Type of cache error in the Cache Check structure
  ///@{
  public const ulong EFI_CACHE_CHECK_ERROR_TYPE_INSTRUCTION = 0;
  public const ulong EFI_CACHE_CHECK_ERROR_TYPE_DATA_ACCESS = 1;
  public const ulong EFI_CACHE_CHECK_ERROR_TYPE_GENERIC = 2;
  ///@}

  ///
  /// Type of cache operation that caused the error in the Cache
  /// Check structure
  ///@{
  public const ulong EFI_CACHE_CHECK_OPERATION_TYPE_GENERIC = 0;
  public const ulong EFI_CACHE_CHECK_OPERATION_TYPE_GENERIC_READ = 1;
  public const ulong EFI_CACHE_CHECK_OPERATION_TYPE_GENERIC_WRITE = 2;
  public const ulong EFI_CACHE_CHECK_OPERATION_TYPE_DATA_READ = 3;
  public const ulong EFI_CACHE_CHECK_OPERATION_TYPE_DATA_WRITE = 4;
  public const ulong EFI_CACHE_CHECK_OPERATION_TYPE_INSTRUCTION_FETCH = 5;
  public const ulong EFI_CACHE_CHECK_OPERATION_TYPE_PREFETCH = 6;
  public const ulong EFI_CACHE_CHECK_OPERATION_TYPE_EVICTION = 7;
  public const ulong EFI_CACHE_CHECK_OPERATION_TYPE_SNOOP = 8;
  ///@}
}

///
/// IA32/X64 Cache Check Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IA32_X64_CACHE_CHECK_INFO
{
  public ulong ValidFields; // = 16;
  public ulong TransactionType; // = 2;
  public ulong Operation; // = 4;
  public ulong Level; // = 3;
  public ulong ContextCorrupt; // = 1;
  public ulong ErrorUncorrected; // = 1;
  public ulong PreciseIp; // = 1;
  public ulong RestartableIp; // = 1;
  public ulong Overflow; // = 1;
  public ulong Resv1; // = 34;
}

public unsafe partial class EFI
{
  ///
  /// The validation bit mask indicates which fields in the TLB Check structure
  /// are valid.
  ///@{
  public const ulong EFI_TLB_CHECK_TRANSACTION_TYPE_VALID = BIT0;
  public const ulong EFI_TLB_CHECK_OPERATION_VALID = BIT1;
  public const ulong EFI_TLB_CHECK_LEVEL_VALID = BIT2;
  public const ulong EFI_TLB_CHECK_CONTEXT_CORRUPT_VALID = BIT3;
  public const ulong EFI_TLB_CHECK_UNCORRECTED_VALID = BIT4;
  public const ulong EFI_TLB_CHECK_PRECISE_IP_VALID = BIT5;
  public const ulong EFI_TLB_CHECK_RESTARTABLE_VALID = BIT6;
  public const ulong EFI_TLB_CHECK_OVERFLOW_VALID = BIT7;
  ///@}

  ///
  /// Type of cache error in the TLB Check structure
  ///@{
  public const ulong EFI_TLB_CHECK_ERROR_TYPE_INSTRUCTION = 0;
  public const ulong EFI_TLB_CHECK_ERROR_TYPE_DATA_ACCESS = 1;
  public const ulong EFI_TLB_CHECK_ERROR_TYPE_GENERIC = 2;
  ///@}

  ///
  /// Type of cache operation that caused the error in the TLB
  /// Check structure
  ///@{
  public const ulong EFI_TLB_CHECK_OPERATION_TYPE_GENERIC = 0;
  public const ulong EFI_TLB_CHECK_OPERATION_TYPE_GENERIC_READ = 1;
  public const ulong EFI_TLB_CHECK_OPERATION_TYPE_GENERIC_WRITE = 2;
  public const ulong EFI_TLB_CHECK_OPERATION_TYPE_DATA_READ = 3;
  public const ulong EFI_TLB_CHECK_OPERATION_TYPE_DATA_WRITE = 4;
  public const ulong EFI_TLB_CHECK_OPERATION_TYPE_INST_FETCH = 5;
  public const ulong EFI_TLB_CHECK_OPERATION_TYPE_PREFETCH = 6;
  ///@}
}

///
/// IA32/X64 TLB Check Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IA32_X64_TLB_CHECK_INFO
{
  public ulong ValidFields; // = 16;
  public ulong TransactionType; // = 2;
  public ulong Operation; // = 4;
  public ulong Level; // = 3;
  public ulong ContextCorrupt; // = 1;
  public ulong ErrorUncorrected; // = 1;
  public ulong PreciseIp; // = 1;
  public ulong RestartableIp; // = 1;
  public ulong Overflow; // = 1;
  public ulong Resv1; // = 34;
}

public unsafe partial class EFI
{
  ///
  /// The validation bit mask indicates which fields in the MS Check structure
  /// are valid.
  ///@{
  public const ulong EFI_BUS_CHECK_TRANSACTION_TYPE_VALID = BIT0;
  public const ulong EFI_BUS_CHECK_OPERATION_VALID = BIT1;
  public const ulong EFI_BUS_CHECK_LEVEL_VALID = BIT2;
  public const ulong EFI_BUS_CHECK_CONTEXT_CORRUPT_VALID = BIT3;
  public const ulong EFI_BUS_CHECK_UNCORRECTED_VALID = BIT4;
  public const ulong EFI_BUS_CHECK_PRECISE_IP_VALID = BIT5;
  public const ulong EFI_BUS_CHECK_RESTARTABLE_VALID = BIT6;
  public const ulong EFI_BUS_CHECK_OVERFLOW_VALID = BIT7;
  public const ulong EFI_BUS_CHECK_PARTICIPATION_TYPE_VALID = BIT8;
  public const ulong EFI_BUS_CHECK_TIME_OUT_VALID = BIT9;
  public const ulong EFI_BUS_CHECK_ADDRESS_SPACE_VALID = BIT10;
  ///@}

  ///
  /// Type of cache error in the Bus Check structure
  ///@{
  public const ulong EFI_BUS_CHECK_ERROR_TYPE_INSTRUCTION = 0;
  public const ulong EFI_BUS_CHECK_ERROR_TYPE_DATA_ACCESS = 1;
  public const ulong EFI_BUS_CHECK_ERROR_TYPE_GENERIC = 2;
  ///@}

  ///
  /// Type of cache operation that caused the error in the Bus
  /// Check structure
  ///@{
  public const ulong EFI_BUS_CHECK_OPERATION_TYPE_GENERIC = 0;
  public const ulong EFI_BUS_CHECK_OPERATION_TYPE_GENERIC_READ = 1;
  public const ulong EFI_BUS_CHECK_OPERATION_TYPE_GENERIC_WRITE = 2;
  public const ulong EFI_BUS_CHECK_OPERATION_TYPE_DATA_READ = 3;
  public const ulong EFI_BUS_CHECK_OPERATION_TYPE_DATA_WRITE = 4;
  public const ulong EFI_BUS_CHECK_OPERATION_TYPE_INST_FETCH = 5;
  public const ulong EFI_BUS_CHECK_OPERATION_TYPE_PREFETCH = 6;
  ///@}

  ///
  /// Type of Participation
  ///@{
  public const ulong EFI_BUS_CHECK_PARTICIPATION_TYPE_REQUEST = 0;
  public const ulong EFI_BUS_CHECK_PARTICIPATION_TYPE_RESPONDED = 1;
  public const ulong EFI_BUS_CHECK_PARTICIPATION_TYPE_OBSERVED = 2;
  public const ulong EFI_BUS_CHECK_PARTICIPATION_TYPE_GENERIC = 3;
  ///@}

  ///
  /// Type of Address Space
  ///@{
  public const ulong EFI_BUS_CHECK_ADDRESS_SPACE_TYPE_MEMORY = 0;
  public const ulong EFI_BUS_CHECK_ADDRESS_SPACE_TYPE_RESERVED = 1;
  public const ulong EFI_BUS_CHECK_ADDRESS_SPACE_TYPE_IO = 2;
  public const ulong EFI_BUS_CHECK_ADDRESS_SPACE_TYPE_OTHER = 3;
  ///@}
}

///
/// IA32/X64 Bus Check Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IA32_X64_BUS_CHECK_INFO
{
  public ulong ValidFields; // = 16;
  public ulong TransactionType; // = 2;
  public ulong Operation; // = 4;
  public ulong Level; // = 3;
  public ulong ContextCorrupt; // = 1;
  public ulong ErrorUncorrected; // = 1;
  public ulong PreciseIp; // = 1;
  public ulong RestartableIp; // = 1;
  public ulong Overflow; // = 1;
  public ulong ParticipationType; // = 2;
  public ulong TimeOut; // = 1;
  public ulong AddressSpace; // = 2;
  public ulong Resv1; // = 29;
}

public unsafe partial class EFI
{
  ///
  /// The validation bit mask indicates which fields in the MS Check structure
  /// are valid.
  ///@{
  public const ulong EFI_MS_CHECK_ERROR_TYPE_VALID = BIT0;
  public const ulong EFI_MS_CHECK_CONTEXT_CORRUPT_VALID = BIT1;
  public const ulong EFI_MS_CHECK_UNCORRECTED_VALID = BIT2;
  public const ulong EFI_MS_CHECK_PRECISE_IP_VALID = BIT3;
  public const ulong EFI_MS_CHECK_RESTARTABLE_VALID = BIT4;
  public const ulong EFI_MS_CHECK_OVERFLOW_VALID = BIT5;
  ///@}

  ///
  /// Error type identifies the operation that caused the error.
  ///@{
  public const ulong EFI_MS_CHECK_ERROR_TYPE_NO = 0;
  public const ulong EFI_MS_CHECK_ERROR_TYPE_UNCLASSIFIED = 1;
  public const ulong EFI_MS_CHECK_ERROR_TYPE_MICROCODE_PARITY = 2;
  public const ulong EFI_MS_CHECK_ERROR_TYPE_EXTERNAL = 3;
  public const ulong EFI_MS_CHECK_ERROR_TYPE_FRC = 4;
  public const ulong EFI_MS_CHECK_ERROR_TYPE_INTERNAL_UNCLASSIFIED = 5;
  ///@}
}

///
/// IA32/X64 MS Check Field Description
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IA32_X64_MS_CHECK_INFO
{
  public ulong ValidFields; // = 16;
  public ulong ErrorType; // = 3;
  public ulong ContextCorrupt; // = 1;
  public ulong ErrorUncorrected; // = 1;
  public ulong PreciseIp; // = 1;
  public ulong RestartableIp; // = 1;
  public ulong Overflow; // = 1;
  public ulong Resv1; // = 40;
}

///
/// IA32/X64 Check Information Item
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_IA32_X64_CHECK_INFO_ITEM
{
  [FieldOffset(0)] public EFI_IA32_X64_CACHE_CHECK_INFO CacheCheck;
  [FieldOffset(0)] public EFI_IA32_X64_TLB_CHECK_INFO TlbCheck;
  [FieldOffset(0)] public EFI_IA32_X64_BUS_CHECK_INFO BusCheck;
  [FieldOffset(0)] public EFI_IA32_X64_MS_CHECK_INFO MsCheck;
  [FieldOffset(0)] public ulong Data64;
}

public unsafe partial class EFI
{
  ///
  /// The validation bit mask indicates which fields in the IA32/X64 Processor Error
  /// Information Structure are valid.
  ///@{
  public const ulong EFI_IA32_X64_ERROR_PROC_CHECK_INFO_VALID = BIT0;
  public const ulong EFI_IA32_X64_ERROR_PROC_TARGET_ADDR_VALID = BIT1;
  public const ulong EFI_IA32_X64_ERROR_PROC_REQUESTER_ID_VALID = BIT2;
  public const ulong EFI_IA32_X64_ERROR_PROC_RESPONDER_ID_VALID = BIT3;
  public const ulong EFI_IA32_X64_ERROR_PROC_INST_IP_VALID = BIT4;
  ///@}
}

///
/// IA32/X64 Processor Error Information Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IA32_X64_PROCESS_ERROR_INFO
{
  public EFI_GUID ErrorType;
  public ulong ValidFields;
  public EFI_IA32_X64_CHECK_INFO_ITEM CheckInfo;
  public ulong TargetId;
  public ulong RequestorId;
  public ulong ResponderId;
  public ulong InstructionIP;
}

///
/// IA32/X64 Processor Context Information Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IA32_X64_PROCESSOR_CONTEXT_INFO
{
  public ushort RegisterType;
  public ushort ArraySize;
  public uint MsrAddress;
  public ulong MmRegisterAddress;
  //
  // This field will provide the contents of the actual registers or raw data.
  // The number of Registers or size of the raw data reported is determined
  // by (Array Size / 8) or otherwise specified by the context structure type
  // definition.
  //
}

public unsafe partial class EFI
{
  ///
  /// Register Context Type
  ///@{
  public const ulong EFI_REG_CONTEXT_TYPE_UNCLASSIFIED = 0x0000;
  public const ulong EFI_REG_CONTEXT_TYPE_MSR = 0x0001;
  public const ulong EFI_REG_CONTEXT_TYPE_IA32 = 0x0002;
  public const ulong EFI_REG_CONTEXT_TYPE_X64 = 0x0003;
  public const ulong EFI_REG_CONTEXT_TYPE_FXSAVE = 0x0004;
  public const ulong EFI_REG_CONTEXT_TYPE_DR_IA32 = 0x0005;
  public const ulong EFI_REG_CONTEXT_TYPE_DR_X64 = 0x0006;
  public const ulong EFI_REG_CONTEXT_TYPE_MEM_MAP = 0x0007;
  ///@}
}

///
/// IA32 Register State
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CONTEXT_IA32_REGISTER_STATE
{
  public uint Eax;
  public uint Ebx;
  public uint Ecx;
  public uint Edx;
  public uint Esi;
  public uint Edi;
  public uint Ebp;
  public uint Esp;
  public ushort Cs;
  public ushort Ds;
  public ushort Ss;
  public ushort Es;
  public ushort Fs;
  public ushort Gs;
  public uint Eflags;
  public uint Eip;
  public uint Cr0;
  public uint Cr1;
  public uint Cr2;
  public uint Cr3;
  public uint Cr4;
  public fixed uint Gdtr[2];
  public fixed uint Idtr[2];
  public ushort Ldtr;
  public ushort Tr;
}

///
/// X64 Register State
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CONTEXT_X64_REGISTER_STATE
{
  public ulong Rax;
  public ulong Rbx;
  public ulong Rcx;
  public ulong Rdx;
  public ulong Rsi;
  public ulong Rdi;
  public ulong Rbp;
  public ulong Rsp;
  public ulong R8;
  public ulong R9;
  public ulong R10;
  public ulong R11;
  public ulong R12;
  public ulong R13;
  public ulong R14;
  public ulong R15;
  public ushort Cs;
  public ushort Ds;
  public ushort Ss;
  public ushort Es;
  public ushort Fs;
  public ushort Gs;
  public uint Resv1;
  public ulong Rflags;
  public ulong Rip;
  public ulong Cr0;
  public ulong Cr1;
  public ulong Cr2;
  public ulong Cr3;
  public ulong Cr4;
  public fixed ulong Gdtr[2];
  public fixed ulong Idtr[2];
  public ushort Ldtr;
  public ushort Tr;
}

///
/// The validation bit mask indicates each of the following field is in IA32/X64
/// Processor Error Section.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IA32_X64_VALID_BITS
{
  public ulong ApicIdValid; // = 1;
  public ulong CpuIdInforValid; // = 1;
  public ulong ErrorInfoNum; // = 6;
  public ulong ContextNum; // = 6;
  public ulong Resv1; // = 50;
}

// #endif

///
/// Error Status Fields
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_GENERIC_ERROR_STATUS
{
  public ulong Resv1; // = 8;
  public ulong Type; // = 8;
  public ulong AddressSignal; // = 1;      ///< Error in Address signals or in Address portion of transaction
  public ulong ControlSignal; // = 1;      ///< Error in Control signals or in Control portion of transaction
  public ulong DataSignal; // = 1;      ///< Error in Data signals or in Data portion of transaction
  public ulong DetectedByResponder; // = 1;      ///< Error detected by responder
  public ulong DetectedByRequester; // = 1;      ///< Error detected by requestor
  public ulong FirstError; // = 1;      ///< First Error in the sequence - option field
  public ulong OverflowNotLogged; // = 1;      ///< Additional errors were not logged due to lack of resources
  public ulong Resv2; // = 41;
}

///
/// Error Type
///
public enum EFI_GENERIC_ERROR_STATUS_ERROR_TYPE
{
  ///
  /// General Internal errors
  ///
  ErrorInternal = 1,
  ErrorBus = 16,
  ///
  /// Component Internal errors
  ///
  ErrorMemStorage = 4,        // Error in memory device
  ErrorTlbStorage = 5,        // TLB error in cache
  ErrorCacheStorage = 6,
  ErrorFunctionalUnit = 7,
  ErrorSelftest = 8,
  ErrorOverflow = 9,
  ///
  /// Bus internal errors
  ///
  ErrorVirtualMap = 17,
  ErrorAccessInvalid = 18,      // Improper access
  ErrorUnimplAccess = 19,      // Unimplemented memory access
  ErrorLossOfLockstep = 20,
  ErrorResponseInvalid = 21,       // Response not associated with request
  ErrorParity = 22,
  ErrorProtocol = 23,
  ErrorPath = 24,      // Detected path error
  ErrorTimeout = 25,      // Bus timeout
  ErrorPoisoned = 26       // Read data poisoned
}

public unsafe partial class EFI
{
  ///
  /// Validation bit mask indicates which fields in the memory error record are valid
  /// in Memory Error section
  ///@{
  public const ulong EFI_PLATFORM_MEMORY_ERROR_STATUS_VALID = BIT0;
  public const ulong EFI_PLATFORM_MEMORY_PHY_ADDRESS_VALID = BIT1;
  public const ulong EFI_PLATFORM_MEMORY_PHY_ADDRESS_MASK_VALID = BIT2;
  public const ulong EFI_PLATFORM_MEMORY_NODE_VALID = BIT3;
  public const ulong EFI_PLATFORM_MEMORY_CARD_VALID = BIT4;
  public const ulong EFI_PLATFORM_MEMORY_MODULE_VALID = BIT5;
  public const ulong EFI_PLATFORM_MEMORY_BANK_VALID = BIT6;
  public const ulong EFI_PLATFORM_MEMORY_DEVICE_VALID = BIT7;
  public const ulong EFI_PLATFORM_MEMORY_ROW_VALID = BIT8;
  public const ulong EFI_PLATFORM_MEMORY_COLUMN_VALID = BIT9;
  public const ulong EFI_PLATFORM_MEMORY_BIT_POS_VALID = BIT10;
  public const ulong EFI_PLATFORM_MEMORY_REQUESTOR_ID_VALID = BIT11;
  public const ulong EFI_PLATFORM_MEMORY_RESPONDER_ID_VALID = BIT12;
  public const ulong EFI_PLATFORM_MEMORY_TARGET_ID_VALID = BIT13;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_TYPE_VALID = BIT14;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_RANK_NUM_VALID = BIT15;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_CARD_HANDLE_VALID = BIT16;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_MODULE_HANDLE_VALID = BIT17;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_EXTENDED_ROW_BIT_16_17_VALID = BIT18;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_BANK_GROUP_VALID = BIT19;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_BANK_ADDRESS_VALID = BIT20;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_CHIP_IDENTIFICATION_VALID = BIT21;
  ///@}

  ///
  /// Memory Error Type identifies the type of error that occurred in Memory
  /// Error section
  ///@{
  public const ulong EFI_PLATFORM_MEMORY_ERROR_UNKNOWN = 0x00;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_NONE = 0x01;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_SINGLEBIT_ECC = 0x02;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_MLTIBIT_ECC = 0x03;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_SINGLESYMBOLS_CHIPKILL = 0x04;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_MULTISYMBOL_CHIPKILL = 0x05;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_MATER_ABORT = 0x06;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_TARGET_ABORT = 0x07;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_PARITY = 0x08;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_WDT = 0x09;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_INVALID_ADDRESS = 0x0A;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_MIRROR_FAILED = 0x0B;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_SPARING = 0x0C;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_SCRUB_CORRECTED = 0x0D;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_SCRUB_UNCORRECTED = 0x0E;
  public const ulong EFI_PLATFORM_MEMORY_ERROR_MEMORY_MAP_EVENT = 0x0F;
  ///@}
}

///
/// Memory Error Section
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PLATFORM_MEMORY_ERROR_DATA
{
  public ulong ValidFields;
  public EFI_GENERIC_ERROR_STATUS ErrorStatus;
  public ulong PhysicalAddress;     // Error physical address
  public ulong PhysicalAddressMask; // Grnaularity
  public ushort Node;                // Node #
  public ushort Card;
  public ushort ModuleRank;        // Module or Rank#
  public ushort Bank;
  public ushort Device;
  public ushort Row;
  public ushort Column;
  public ushort BitPosition;
  public ulong RequestorId;
  public ulong ResponderId;
  public ulong TargetId;
  public byte ErrorType;
  public byte Extended;
  public ushort RankNum;
  public ushort CardHandle;
  public ushort ModuleHandle;
}

public unsafe partial class EFI
{
  ///
  /// Validation bit mask indicates which fields in the memory error record 2 are valid
  /// in Memory Error section 2
  ///@{
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_STATUS_VALID = BIT0;
  public const ulong EFI_PLATFORM_MEMORY2_PHY_ADDRESS_VALID = BIT1;
  public const ulong EFI_PLATFORM_MEMORY2_PHY_ADDRESS_MASK_VALID = BIT2;
  public const ulong EFI_PLATFORM_MEMORY2_NODE_VALID = BIT3;
  public const ulong EFI_PLATFORM_MEMORY2_CARD_VALID = BIT4;
  public const ulong EFI_PLATFORM_MEMORY2_MODULE_VALID = BIT5;
  public const ulong EFI_PLATFORM_MEMORY2_BANK_VALID = BIT6;
  public const ulong EFI_PLATFORM_MEMORY2_DEVICE_VALID = BIT7;
  public const ulong EFI_PLATFORM_MEMORY2_ROW_VALID = BIT8;
  public const ulong EFI_PLATFORM_MEMORY2_COLUMN_VALID = BIT9;
  public const ulong EFI_PLATFORM_MEMORY2_RANK_VALID = BIT10;
  public const ulong EFI_PLATFORM_MEMORY2_BIT_POS_VALID = BIT11;
  public const ulong EFI_PLATFORM_MEMORY2_CHIP_ID_VALID = BIT12;
  public const ulong EFI_PLATFORM_MEMORY2_MEMORY_ERROR_TYPE_VALID = BIT13;
  public const ulong EFI_PLATFORM_MEMORY2_STATUS_VALID = BIT14;
  public const ulong EFI_PLATFORM_MEMORY2_REQUESTOR_ID_VALID = BIT15;
  public const ulong EFI_PLATFORM_MEMORY2_RESPONDER_ID_VALID = BIT16;
  public const ulong EFI_PLATFORM_MEMORY2_TARGET_ID_VALID = BIT17;
  public const ulong EFI_PLATFORM_MEMORY2_CARD_HANDLE_VALID = BIT18;
  public const ulong EFI_PLATFORM_MEMORY2_MODULE_HANDLE_VALID = BIT19;
  public const ulong EFI_PLATFORM_MEMORY2_BANK_GROUP_VALID = BIT20;
  public const ulong EFI_PLATFORM_MEMORY2_BANK_ADDRESS_VALID = BIT21;
  ///@}

  ///
  /// Memory Error Type identifies the type of error that occurred in Memory
  /// Error section 2
  ///@{
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_UNKNOWN = 0x00;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_NONE = 0x01;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_SINGLEBIT_ECC = 0x02;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_MLTIBIT_ECC = 0x03;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_SINGLESYMBOL_CHIPKILL = 0x04;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_MULTISYMBOL_CHIPKILL = 0x05;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_MASTER_ABORT = 0x06;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_TARGET_ABORT = 0x07;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_PARITY = 0x08;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_WDT = 0x09;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_INVALID_ADDRESS = 0x0A;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_MIRROR_BROKEN = 0x0B;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_MEMORY_SPARING = 0x0C;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_SCRUB_CORRECTED = 0x0D;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_SCRUB_UNCORRECTED = 0x0E;
  public const ulong EFI_PLATFORM_MEMORY2_ERROR_MEMORY_MAP_EVENT = 0x0F;
  ///@}
}

///
/// Memory Error Section 2
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PLATFORM_MEMORY2_ERROR_DATA
{
  public ulong ValidFields;
  public EFI_GENERIC_ERROR_STATUS ErrorStatus;
  public ulong PhysicalAddress;     // Error physical address
  public ulong PhysicalAddressMask; // Grnaularity
  public ushort Node;                // Node #
  public ushort Card;
  public ushort Module;             // Module or Rank#
  public ushort Bank;
  public uint Device;
  public uint Row;
  public uint Column;
  public uint Rank;
  public uint BitPosition;
  public byte ChipId;
  public byte MemErrorType;
  public byte Status;
  public byte Reserved;
  public ulong RequestorId;
  public ulong ResponderId;
  public ulong TargetId;
  public uint CardHandle;
  public uint ModuleHandle;
}

public unsafe partial class EFI
{
  ///
  /// Validation bits mask indicates which of the following fields is valid
  /// in PCI Express Error Record.
  ///@{
  public const ulong EFI_PCIE_ERROR_PORT_TYPE_VALID = BIT0;
  public const ulong EFI_PCIE_ERROR_VERSION_VALID = BIT1;
  public const ulong EFI_PCIE_ERROR_COMMAND_STATUS_VALID = BIT2;
  public const ulong EFI_PCIE_ERROR_DEVICE_ID_VALID = BIT3;
  public const ulong EFI_PCIE_ERROR_SERIAL_NO_VALID = BIT4;
  public const ulong EFI_PCIE_ERROR_BRIDGE_CRL_STS_VALID = BIT5;
  public const ulong EFI_PCIE_ERROR_CAPABILITY_INFO_VALID = BIT6;
  public const ulong EFI_PCIE_ERROR_AER_INFO_VALID = BIT7;
  ///@}

  ///
  /// PCIe Device/Port Type as defined in the PCI Express capabilities register
  ///@{
  public const ulong EFI_PCIE_ERROR_PORT_PCIE_ENDPOINT = 0x00000000;
  public const ulong EFI_PCIE_ERROR_PORT_PCI_ENDPOINT = 0x00000001;
  public const ulong EFI_PCIE_ERROR_PORT_ROOT_PORT = 0x00000004;
  public const ulong EFI_PCIE_ERROR_PORT_UPSWITCH_PORT = 0x00000005;
  public const ulong EFI_PCIE_ERROR_PORT_DOWNSWITCH_PORT = 0x00000006;
  public const ulong EFI_PCIE_ERROR_PORT_PCIE_TO_PCI_BRIDGE = 0x00000007;
  public const ulong EFI_PCIE_ERROR_PORT_PCI_TO_PCIE_BRIDGE = 0x00000008;
  public const ulong EFI_PCIE_ERROR_PORT_ROOT_INT_ENDPOINT = 0x00000009;
  public const ulong EFI_PCIE_ERROR_PORT_ROOT_EVENT_COLLECTOR = 0x0000000A;
  ///@}
}

///
/// PCI Slot number
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_GENERIC_ERROR_PCI_SLOT
{
  public ushort Resv1; // = 3;
  public ushort Number; // = 13;
}

///
/// PCIe Root Port PCI/bridge PCI compatible device number and
/// bus number information to uniquely identify the root port or
/// bridge. Default values for both the bus numbers is zero.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_GENERIC_ERROR_PCIE_DEV_BRIDGE_ID
{
  public ushort VendorId;
  public ushort DeviceId;
  public fixed byte ClassCode[3];
  public byte Function;
  public byte Device;
  public ushort Segment;
  public byte PrimaryOrDeviceBus;
  public byte SecondaryBus;
  public EFI_GENERIC_ERROR_PCI_SLOT Slot;
  public byte Resv1;
}

///
/// PCIe Capability Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCIE_ERROR_DATA_CAPABILITY
{
  public fixed byte PcieCap[60];
}

///
/// PCIe Advanced Error Reporting Extended Capability Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCIE_ERROR_DATA_AER
{
  public fixed byte PcieAer[96];
}

///
/// PCI Express Error Record
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCIE_ERROR_DATA
{
  public ulong ValidFields;
  public uint PortType;
  public uint Version;
  public uint CommandStatus;
  public uint Resv2;
  public EFI_GENERIC_ERROR_PCIE_DEV_BRIDGE_ID DevBridge;
  public ulong SerialNo;
  public uint BridgeControlStatus;
  public EFI_PCIE_ERROR_DATA_CAPABILITY Capability;
  public EFI_PCIE_ERROR_DATA_AER AerInfo;
}

public unsafe partial class EFI
{
  ///
  /// Validation bits Indicates which of the following fields is valid
  /// in PCI/PCI-X Bus Error Section.
  ///@{
  public const ulong EFI_PCI_PCIX_BUS_ERROR_STATUS_VALID = BIT0;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_TYPE_VALID = BIT1;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_BUS_ID_VALID = BIT2;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_BUS_ADDRESS_VALID = BIT3;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_BUS_DATA_VALID = BIT4;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_COMMAND_VALID = BIT5;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_REQUESTOR_ID_VALID = BIT6;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_COMPLETER_ID_VALID = BIT7;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_TARGET_ID_VALID = BIT8;
  ///@}

  ///
  /// PCI Bus Error Type in PCI/PCI-X Bus Error Section
  ///@{
  public const ulong EFI_PCI_PCIX_BUS_ERROR_UNKNOWN = 0x0000;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_DATA_PARITY = 0x0001;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_SYSTEM = 0x0002;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_MASTER_ABORT = 0x0003;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_BUS_TIMEOUT = 0x0004;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_MASTER_DATA_PARITY = 0x0005;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_ADDRESS_PARITY = 0x0006;
  public const ulong EFI_PCI_PCIX_BUS_ERROR_COMMAND_PARITY = 0x0007;
  ///@}
}

///
/// PCI/PCI-X Bus Error Section
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_PCIX_BUS_ERROR_DATA
{
  public ulong ValidFields;
  public EFI_GENERIC_ERROR_STATUS ErrorStatus;
  public ushort Type;
  public ushort BusId;
  public uint Resv2;
  public ulong BusAddress;
  public ulong BusData;
  public ulong BusCommand;
  public ulong RequestorId;
  public ulong ResponderId;
  public ulong TargetId;
}

public unsafe partial class EFI
{
  ///
  /// Validation bits Indicates which of the following fields is valid
  /// in PCI/PCI-X Component Error Section.
  ///@{
  public const ulong EFI_PCI_PCIX_DEVICE_ERROR_STATUS_VALID = BIT0;
  public const ulong EFI_PCI_PCIX_DEVICE_ERROR_ID_INFO_VALID = BIT1;
  public const ulong EFI_PCI_PCIX_DEVICE_ERROR_MEM_NUM_VALID = BIT2;
  public const ulong EFI_PCI_PCIX_DEVICE_ERROR_IO_NUM_VALID = BIT3;
  public const ulong EFI_PCI_PCIX_DEVICE_ERROR_REG_DATA_PAIR_VALID = BIT4;
  ///@}
}

///
/// PCI/PCI-X Device Identification Information
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_GENERIC_ERROR_PCI_DEVICE_ID
{
  public ushort VendorId;
  public ushort DeviceId;
  public fixed byte ClassCode[3];
  public byte Function;
  public byte Device;
  public byte Bus;
  public byte Segment;
  public byte Resv1;
  public uint Resv2;
}

public unsafe partial class EFI
{
  ///
  /// Identifies the type of firmware error record
  ///@{
  public const ulong EFI_FIRMWARE_ERROR_TYPE_IPF_SAL = 0x00;
  public const ulong EFI_FIRMWARE_ERROR_TYPE_SOC_TYPE1 = 0x01;
  public const ulong EFI_FIRMWARE_ERROR_TYPE_SOC_TYPE2 = 0x02;
  ///@}
}

///
/// Firmware Error Record Section
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_ERROR_DATA
{
  public byte ErrorType;
  public byte Revision;
  public fixed byte Resv1[6];
  public ulong RecordId;
  public EFI_GUID RecordIdGuid;
}

public unsafe partial class EFI
{
  ///
  /// Fault Reason in DMAr Generic Error Section
  ///@{
  public const ulong EFI_DMA_FAULT_REASON_TABLE_ENTRY_NOT_PRESENT = 0x01;
  public const ulong EFI_DMA_FAULT_REASON_TABLE_ENTRY_INVALID = 0x02;
  public const ulong EFI_DMA_FAULT_REASON_ACCESS_MAPPING_TABLE_ERROR = 0x03;
  public const ulong EFI_DMA_FAULT_REASON_RESV_BIT_ERROR_IN_MAPPING_TABLE = 0x04;
  public const ulong EFI_DMA_FAULT_REASON_ACCESS_ADDR_OUT_OF_SPACE = 0x05;
  public const ulong EFI_DMA_FAULT_REASON_INVALID_ACCESS = 0x06;
  public const ulong EFI_DMA_FAULT_REASON_INVALID_REQUEST = 0x07;
  public const ulong EFI_DMA_FAULT_REASON_ACCESS_TRANSLATE_TABLE_ERROR = 0x08;
  public const ulong EFI_DMA_FAULT_REASON_RESV_BIT_ERROR_IN_TRANSLATE_TABLE = 0x09;
  public const ulong EFI_DMA_FAULT_REASON_INVALID_COMMAOND = 0x0A;
  public const ulong EFI_DMA_FAULT_REASON_ACCESS_COMMAND_BUFFER_ERROR = 0x0B;
  ///@}

  ///
  /// DMA access type in DMAr Generic Error Section
  ///@{
  public const ulong EFI_DMA_ACCESS_TYPE_READ = 0x00;
  public const ulong EFI_DMA_ACCESS_TYPE_WRITE = 0x01;
  ///@}

  ///
  /// DMA address type in DMAr Generic Error Section
  ///@{
  public const ulong EFI_DMA_ADDRESS_UNTRANSLATED = 0x00;
  public const ulong EFI_DMA_ADDRESS_TRANSLATION = 0x01;
  ///@}

  ///
  /// Architecture type in DMAr Generic Error Section
  ///@{
  public const ulong EFI_DMA_ARCH_TYPE_VT = 0x01;
  public const ulong EFI_DMA_ARCH_TYPE_IOMMU = 0x02;
  ///@}
}

///
/// DMAr Generic Error Section
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DMAR_GENERIC_ERROR_DATA
{
  public ushort RequesterId;
  public ushort SegmentNumber;
  public byte FaultReason;
  public byte AccessType;
  public byte AddressType;
  public byte ArchType;
  public ulong DeviceAddr;
  public fixed byte Resv1[16];
}

///
/// Intel VT for Directed I/O specific DMAr Errors
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DIRECTED_IO_DMAR_ERROR_DATA
{
  public byte Version;
  public byte Revision;
  public fixed byte OemId[6];
  public ulong Capability;
  public ulong CapabilityEx;
  public uint GlobalCommand;
  public uint GlobalStatus;
  public uint FaultStatus;
  public fixed byte Resv1[12];
  public fixed ulong FaultRecord[2];
  public fixed ulong RootEntry[2];
  public fixed ulong ContextEntry[2];
  public ulong PteL6;
  public ulong PteL5;
  public ulong PteL4;
  public ulong PteL3;
  public ulong PteL2;
  public ulong PteL1;
}

///
/// IOMMU specific DMAr Errors
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IOMMU_DMAR_ERROR_DATA
{
  public byte Revision;
  public fixed byte Resv1[7];
  public ulong Control;
  public ulong Status;
  public fixed byte Resv2[8];
  public fixed ulong EventLogEntry[2];
  public fixed byte Resv3[16];
  public fixed ulong DeviceTableEntry[4];
  public ulong PteL6;
  public ulong PteL5;
  public ulong PteL4;
  public ulong PteL3;
  public ulong PteL2;
  public ulong PteL1;
}

// #pragma pack()

// extern EFI_GUID  gEfiEventNotificationTypeCmcGuid;
// extern EFI_GUID  gEfiEventNotificationTypeCpeGuid;
// extern EFI_GUID  gEfiEventNotificationTypeMceGuid;
// extern EFI_GUID  gEfiEventNotificationTypePcieGuid;
// extern EFI_GUID  gEfiEventNotificationTypeInitGuid;
// extern EFI_GUID  gEfiEventNotificationTypeNmiGuid;
// extern EFI_GUID  gEfiEventNotificationTypeBootGuid;
// extern EFI_GUID  gEfiEventNotificationTypeDmarGuid;
// extern EFI_GUID  gEfiEventNotificationTypeSeaGuid;
// extern EFI_GUID  gEfiEventNotificationTypeSeiGuid;
// extern EFI_GUID  gEfiEventNotificationTypePeiGuid;

// extern EFI_GUID  gEfiProcessorGenericErrorSectionGuid;
// extern EFI_GUID  gEfiProcessorSpecificErrorSectionGuid;
// extern EFI_GUID  gEfiIa32X64ProcessorErrorSectionGuid;
// extern EFI_GUID  gEfiArmProcessorErrorSectionGuid;
// extern EFI_GUID  gEfiPlatformMemoryErrorSectionGuid;
// extern EFI_GUID  gEfiPlatformMemory2ErrorSectionGuid;
// extern EFI_GUID  gEfiPcieErrorSectionGuid;
// extern EFI_GUID  gEfiFirmwareErrorSectionGuid;
// extern EFI_GUID  gEfiPciBusErrorSectionGuid;
// extern EFI_GUID  gEfiPciDevErrorSectionGuid;
// extern EFI_GUID  gEfiDMArGenericErrorSectionGuid;
// extern EFI_GUID  gEfiDirectedIoDMArErrorSectionGuid;
// extern EFI_GUID  gEfiIommuDMArErrorSectionGuid;

//#if defined (MDE_CPU_IA32) || defined (MDE_CPU_X64)
///
/// IA32 and x64 Specific definitions.
///

// extern EFI_GUID  gEfiIa32X64ErrorTypeCacheCheckGuid;
// extern EFI_GUID  gEfiIa32X64ErrorTypeTlbCheckGuid;
// extern EFI_GUID  gEfiIa32X64ErrorTypeBusCheckGuid;
// extern EFI_GUID  gEfiIa32X64ErrorTypeMsCheckGuid;

// #endif

// #endif
