using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI 3.0 definitions from the ACPI Specification Revision 3.0b October 10, 2006

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _ACPI_3_0_H_
// #define _ACPI_3_0_H_

// #include <IndustryStandard/Acpi20.h>

public unsafe partial class EFI
{
  //
  // Define for Descriptor
  //
  public const ulong ACPI_LARGE_EXTENDED_ADDRESS_SPACE_DESCRIPTOR_NAME = 0x0B;

  public const ulong ACPI_EXTENDED_ADDRESS_SPACE_DESCRIPTOR = 0x8B;

  //
  // Ensure proper structure formats
  //
  // #pragma pack(1)
}

///
/// Extended Address Space Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_EXTENDED_ADDRESS_SPACE_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte ResType;
  public byte GenFlag;
  public byte SpecificFlag;
  public byte RevisionId;
  public byte Reserved;
  public ulong AddrSpaceGranularity;
  public ulong AddrRangeMin;
  public ulong AddrRangeMax;
  public ulong AddrTranslationOffset;
  public ulong AddrLen;
  public ulong TypeSpecificAttribute;
}

// #pragma pack()

public unsafe partial class EFI
{
  //
  // Memory Type Specific Flags
  //
  public const ulong EFI_ACPI_MEMORY_TYPE_SPECIFIC_ATTRIBUTES_UC = 0x0000000000000001;
  public const ulong EFI_ACPI_MEMORY_TYPE_SPECIFIC_ATTRIBUTES_WC = 0x0000000000000002;
  public const ulong EFI_ACPI_MEMORY_TYPE_SPECIFIC_ATTRIBUTES_WT = 0x0000000000000004;
  public const ulong EFI_ACPI_MEMORY_TYPE_SPECIFIC_ATTRIBUTES_WB = 0x0000000000000008;
  public const ulong EFI_ACPI_MEMORY_TYPE_SPECIFIC_ATTRIBUTES_UCE = 0x0000000000000010;
  public const ulong EFI_ACPI_MEMORY_TYPE_SPECIFIC_ATTRIBUTES_NV = 0x0000000000008000;

  //
  // Ensure proper structure formats
  //
  // #pragma pack(1)
}

///
/// ACPI 3.0 Generic Address Space definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE
{
  public byte AddressSpaceId;
  public byte RegisterBitWidth;
  public byte RegisterBitOffset;
  public byte AccessSize;
  public ulong Address;
}

public unsafe partial class EFI
{
  //
  // Generic Address Space Address IDs
  //
  public const ulong EFI_ACPI_3_0_SYSTEM_MEMORY = 0;
  public const ulong EFI_ACPI_3_0_SYSTEM_IO = 1;
  public const ulong EFI_ACPI_3_0_PCI_CONFIGURATION_SPACE = 2;
  public const ulong EFI_ACPI_3_0_EMBEDDED_CONTROLLER = 3;
  public const ulong EFI_ACPI_3_0_SMBUS = 4;
  public const ulong EFI_ACPI_3_0_FUNCTIONAL_FIXED_HARDWARE = 0x7F;

  //
  // Generic Address Space Access Sizes
  //
  public const ulong EFI_ACPI_3_0_UNDEFINED = 0;
  public const ulong EFI_ACPI_3_0_BYTE = 1;
  public const ulong EFI_ACPI_3_0_WORD = 2;
  public const ulong EFI_ACPI_3_0_DWORD = 3;
  public const ulong EFI_ACPI_3_0_QWORD = 4;

  //
  // ACPI 3.0 table structures
  //
}

///
/// Root System Description Pointer Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_ROOT_SYSTEM_DESCRIPTION_POINTER
{
  public ulong Signature;
  public byte Checksum;
  public fixed byte OemId[6];
  public byte Revision;
  public uint RsdtAddress;
  public uint Length;
  public ulong XsdtAddress;
  public byte ExtendedChecksum;
  public fixed byte Reserved[3];
}

public unsafe partial class EFI
{
  ///
  /// RSD_PTR Revision (as defined in ACPI 3.0b spec.)
  ///
  public const ulong EFI_ACPI_3_0_ROOT_SYSTEM_DESCRIPTION_POINTER_REVISION = 0x02; /// < ACPISpec (Revision 3.0b) says current value is 2
}

///
/// Common table header, this prefaces all ACPI tables, including FACS, but
/// excluding the RSD PTR structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_COMMON_HEADER
{
  public uint Signature;
  public uint Length;
}

//
// Root System Description Table
// No definition needed as it is a common description table header, the same with
// EFI_ACPI_DESCRIPTION_HEADER, followed by a variable number of uint table pointers.
//

public unsafe partial class EFI
{
  ///
  /// RSDT Revision (as defined in ACPI 3.0 spec.)
  ///
  public const ulong EFI_ACPI_3_0_ROOT_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x01;

  //
  // Extended System Description Table
  // No definition needed as it is a common description table header, the same with
  // EFI_ACPI_DESCRIPTION_HEADER, followed by a variable number of ulong table pointers.
  //

  ///
  /// XSDT Revision (as defined in ACPI 3.0 spec.)
  ///
  public const ulong EFI_ACPI_3_0_EXTENDED_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x01;
}

///
/// Fixed ACPI Description Table Structure (FADT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_FIXED_ACPI_DESCRIPTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint FirmwareCtrl;
  public uint Dsdt;
  public byte Reserved0;
  public byte PreferredPmProfile;
  public ushort SciInt;
  public uint SmiCmd;
  public byte AcpiEnable;
  public byte AcpiDisable;
  public byte S4BiosReq;
  public byte PstateCnt;
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
  public byte PmTmrLen;
  public byte Gpe0BlkLen;
  public byte Gpe1BlkLen;
  public byte Gpe1Base;
  public byte CstCnt;
  public ushort PLvl2Lat;
  public ushort PLvl3Lat;
  public ushort FlushSize;
  public ushort FlushStride;
  public byte DutyOffset;
  public byte DutyWidth;
  public byte DayAlrm;
  public byte MonAlrm;
  public byte Century;
  public ushort IaPcBootArch;
  public byte Reserved1;
  public uint Flags;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE ResetReg;
  public byte ResetValue;
  public fixed byte Reserved2[3];
  public ulong XFirmwareCtrl;
  public ulong XDsdt;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE XPm1aEvtBlk;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE XPm1bEvtBlk;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE XPm1aCntBlk;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE XPm1bCntBlk;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE XPm2CntBlk;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE XPmTmrBlk;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE XGpe0Blk;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE XGpe1Blk;
}

public unsafe partial class EFI
{
  ///
  /// FADT Version (as defined in ACPI 3.0 spec.)
  ///
  public const ulong EFI_ACPI_3_0_FIXED_ACPI_DESCRIPTION_TABLE_REVISION = 0x04;

  //
  // Fixed ACPI Description Table Preferred Power Management Profile
  //
  public const ulong EFI_ACPI_3_0_PM_PROFILE_UNSPECIFIED = 0;
  public const ulong EFI_ACPI_3_0_PM_PROFILE_DESKTOP = 1;
  public const ulong EFI_ACPI_3_0_PM_PROFILE_MOBILE = 2;
  public const ulong EFI_ACPI_3_0_PM_PROFILE_WORKSTATION = 3;
  public const ulong EFI_ACPI_3_0_PM_PROFILE_ENTERPRISE_SERVER = 4;
  public const ulong EFI_ACPI_3_0_PM_PROFILE_SOHO_SERVER = 5;
  public const ulong EFI_ACPI_3_0_PM_PROFILE_APPLIANCE_PC = 6;
  public const ulong EFI_ACPI_3_0_PM_PROFILE_PERFORMANCE_SERVER = 7;

  //
  // Fixed ACPI Description Table Boot Architecture Flags
  // All other bits are reserved and must be set to 0.
  //
  public const ulong EFI_ACPI_3_0_LEGACY_DEVICES = BIT0;
  public const ulong EFI_ACPI_3_0_8042 = BIT1;
  public const ulong EFI_ACPI_3_0_VGA_NOT_PRESENT = BIT2;
  public const ulong EFI_ACPI_3_0_MSI_NOT_SUPPORTED = BIT3;
  public const ulong EFI_ACPI_3_0_PCIE_ASPM_CONTROLS = BIT4;

  //
  // Fixed ACPI Description Table Fixed Feature Flags
  // All other bits are reserved and must be set to 0.
  //
  public const ulong EFI_ACPI_3_0_WBINVD = BIT0;
  public const ulong EFI_ACPI_3_0_WBINVD_FLUSH = BIT1;
  public const ulong EFI_ACPI_3_0_PROC_C1 = BIT2;
  public const ulong EFI_ACPI_3_0_P_LVL2_UP = BIT3;
  public const ulong EFI_ACPI_3_0_PWR_BUTTON = BIT4;
  public const ulong EFI_ACPI_3_0_SLP_BUTTON = BIT5;
  public const ulong EFI_ACPI_3_0_FIX_RTC = BIT6;
  public const ulong EFI_ACPI_3_0_RTC_S4 = BIT7;
  public const ulong EFI_ACPI_3_0_TMR_VAL_EXT = BIT8;
  public const ulong EFI_ACPI_3_0_DCK_CAP = BIT9;
  public const ulong EFI_ACPI_3_0_RESET_REG_SUP = BIT10;
  public const ulong EFI_ACPI_3_0_SEALED_CASE = BIT11;
  public const ulong EFI_ACPI_3_0_HEADLESS = BIT12;
  public const ulong EFI_ACPI_3_0_CPU_SW_SLP = BIT13;
  public const ulong EFI_ACPI_3_0_PCI_EXP_WAK = BIT14;
  public const ulong EFI_ACPI_3_0_USE_PLATFORM_CLOCK = BIT15;
  public const ulong EFI_ACPI_3_0_S4_RTC_STS_VALID = BIT16;
  public const ulong EFI_ACPI_3_0_REMOTE_POWER_ON_CAPABLE = BIT17;
  public const ulong EFI_ACPI_3_0_FORCE_APIC_CLUSTER_MODEL = BIT18;
  public const ulong EFI_ACPI_3_0_FORCE_APIC_PHYSICAL_DESTINATION_MODE = BIT19;
}

///
/// Firmware ACPI Control Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_FIRMWARE_ACPI_CONTROL_STRUCTURE
{
  public uint Signature;
  public uint Length;
  public uint HardwareSignature;
  public uint FirmwareWakingVector;
  public uint GlobalLock;
  public uint Flags;
  public ulong XFirmwareWakingVector;
  public byte Version;
  public fixed byte Reserved[31];
}

public unsafe partial class EFI
{
  ///
  /// FACS Version (as defined in ACPI 3.0 spec.)
  ///
  public const ulong EFI_ACPI_3_0_FIRMWARE_ACPI_CONTROL_STRUCTURE_VERSION = 0x01;

  ///
  /// Firmware Control Structure Feature Flags
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_3_0_S4BIOS_F = BIT0;

  //
  // Differentiated System Description Table,
  // Secondary System Description Table
  // and Persistent System Description Table,
  // no definition needed as they are common description table header, the same with
  // EFI_ACPI_DESCRIPTION_HEADER, followed by a definition block.
  //
  public const ulong EFI_ACPI_3_0_DIFFERENTIATED_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x02;
  public const ulong EFI_ACPI_3_0_SECONDARY_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x02;
}

///
/// Multiple APIC Description Table header definition.  The rest of the table
/// must be defined in a platform specific manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_MULTIPLE_APIC_DESCRIPTION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint LocalApicAddress;
  public uint Flags;
}

public unsafe partial class EFI
{
  ///
  /// MADT Revision (as defined in ACPI 3.0 spec.)
  ///
  public const ulong EFI_ACPI_3_0_MULTIPLE_APIC_DESCRIPTION_TABLE_REVISION = 0x02;

  ///
  /// Multiple APIC Flags
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_3_0_PCAT_COMPAT = BIT0;

  //
  // Multiple APIC Description Table APIC structure types
  // All other values between 0x09 an 0xFF are reserved and
  // will be ignored by OSPM.
  //
  public const ulong EFI_ACPI_3_0_PROCESSOR_LOCAL_APIC = 0x00;
  public const ulong EFI_ACPI_3_0_IO_APIC = 0x01;
  public const ulong EFI_ACPI_3_0_INTERRUPT_SOURCE_OVERRIDE = 0x02;
  public const ulong EFI_ACPI_3_0_NON_MASKABLE_INTERRUPT_SOURCE = 0x03;
  public const ulong EFI_ACPI_3_0_LOCAL_APIC_NMI = 0x04;
  public const ulong EFI_ACPI_3_0_LOCAL_APIC_ADDRESS_OVERRIDE = 0x05;
  public const ulong EFI_ACPI_3_0_IO_SAPIC = 0x06;
  public const ulong EFI_ACPI_3_0_LOCAL_SAPIC = 0x07;
  public const ulong EFI_ACPI_3_0_PLATFORM_INTERRUPT_SOURCES = 0x08;

  //
  // APIC Structure Definitions
  //
}

///
/// Processor Local APIC Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_PROCESSOR_LOCAL_APIC_STRUCTURE
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
  public const ulong EFI_ACPI_3_0_LOCAL_APIC_ENABLED = BIT0;
}

///
/// IO APIC Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_IO_APIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte IoApicId;
  public byte Reserved;
  public uint IoApicAddress;
  public uint GlobalSystemInterruptBase;
}

///
/// Interrupt Source Override Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_INTERRUPT_SOURCE_OVERRIDE_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte Bus;
  public byte Source;
  public uint GlobalSystemInterrupt;
  public ushort Flags;
}

///
/// Platform Interrupt Sources Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_PLATFORM_INTERRUPT_APIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Flags;
  public byte InterruptType;
  public byte ProcessorId;
  public byte ProcessorEid;
  public byte IoSapicVector;
  public uint GlobalSystemInterrupt;
  public uint PlatformInterruptSourceFlags;
  public byte CpeiProcessorOverride;
  public fixed byte Reserved[31];
}

public unsafe partial class EFI
{
  //
  // MPS INTI flags.
  // All other bits are reserved and must be set to 0.
  //
  public const ulong EFI_ACPI_3_0_POLARITY = (3 << 0);
  public const ulong EFI_ACPI_3_0_TRIGGER_MODE = (3 << 2);
}

///
/// Non-Maskable Interrupt Source Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_NON_MASKABLE_INTERRUPT_SOURCE_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Flags;
  public uint GlobalSystemInterrupt;
}

///
/// Local APIC NMI Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_LOCAL_APIC_NMI_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte AcpiProcessorId;
  public ushort Flags;
  public byte LocalApicLint;
}

///
/// Local APIC Address Override Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_LOCAL_APIC_ADDRESS_OVERRIDE_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Reserved;
  public ulong LocalApicAddress;
}

///
/// IO SAPIC Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_IO_SAPIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte IoApicId;
  public byte Reserved;
  public uint GlobalSystemInterruptBase;
  public ulong IoSapicAddress;
}

///
/// Local SAPIC Structure
/// This struct followed by a null-terminated ASCII string - ACPI Processor UID String
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_PROCESSOR_LOCAL_SAPIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte AcpiProcessorId;
  public byte LocalSapicId;
  public byte LocalSapicEid;
  public fixed byte Reserved[3];
  public uint Flags;
  public uint ACPIProcessorUIDValue;
}

///
/// Platform Interrupt Sources Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_PLATFORM_INTERRUPT_SOURCES_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Flags;
  public byte InterruptType;
  public byte ProcessorId;
  public byte ProcessorEid;
  public byte IoSapicVector;
  public uint GlobalSystemInterrupt;
  public uint PlatformInterruptSourceFlags;
}

public unsafe partial class EFI
{
  ///
  /// Platform Interrupt Source Flags.
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_3_0_CPEI_PROCESSOR_OVERRIDE = BIT0;
}

///
/// Smart Battery Description Table (SBST)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_SMART_BATTERY_DESCRIPTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint WarningEnergyLevel;
  public uint LowEnergyLevel;
  public uint CriticalEnergyLevel;
}

public unsafe partial class EFI
{
  ///
  /// SBST Version (as defined in ACPI 3.0 spec.)
  ///
  public const ulong EFI_ACPI_3_0_SMART_BATTERY_DESCRIPTION_TABLE_REVISION = 0x01;
}

///
/// Embedded Controller Boot Resources Table (ECDT)
/// The table is followed by a null terminated ASCII string that contains
/// a fully qualified reference to the name space object.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE EcControl;
  public EFI_ACPI_3_0_GENERIC_ADDRESS_STRUCTURE EcData;
  public uint Uid;
  public byte GpeBit;
}

public unsafe partial class EFI
{
  ///
  /// ECDT Version (as defined in ACPI 3.0 spec.)
  ///
  public const ulong EFI_ACPI_3_0_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE_REVISION = 0x01;
}

///
/// System Resource Affinity Table (SRAT.  The rest of the table
/// must be defined in a platform specific manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_SYSTEM_RESOURCE_AFFINITY_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint Reserved1; ///< Must be set to 1
  public ulong Reserved2;
}

public unsafe partial class EFI
{
  ///
  /// SRAT Version (as defined in ACPI 3.0 spec.)
  ///
  public const ulong EFI_ACPI_3_0_SYSTEM_RESOURCE_AFFINITY_TABLE_REVISION = 0x02;

  //
  // SRAT structure types.
  // All other values between 0x02 an 0xFF are reserved and
  // will be ignored by OSPM.
  //
  public const ulong EFI_ACPI_3_0_PROCESSOR_LOCAL_APIC_SAPIC_AFFINITY = 0x00;
  public const ulong EFI_ACPI_3_0_MEMORY_AFFINITY = 0x01;
}

///
/// Processor Local APIC/SAPIC Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_PROCESSOR_LOCAL_APIC_SAPIC_AFFINITY_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte ProximityDomain7To0;
  public byte ApicId;
  public uint Flags;
  public byte LocalSapicEid;
  public fixed byte ProximityDomain31To8[3];
  public fixed byte Reserved[4];
}

public unsafe partial class EFI
{
  ///
  /// Local APIC/SAPIC Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_3_0_PROCESSOR_LOCAL_APIC_SAPIC_ENABLED = (1 << 0);
}

///
/// Memory Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_MEMORY_AFFINITY_STRUCTURE
{
  public byte Type;
  public byte Length;
  public uint ProximityDomain;
  public ushort Reserved1;
  public uint AddressBaseLow;
  public uint AddressBaseHigh;
  public uint LengthLow;
  public uint LengthHigh;
  public uint Reserved2;
  public uint Flags;
  public ulong Reserved3;
}

public unsafe partial class EFI
{
  //
  // Memory Flags.  All other bits are reserved and must be 0.
  //
  public const ulong EFI_ACPI_3_0_MEMORY_ENABLED = (1 << 0);
  public const ulong EFI_ACPI_3_0_MEMORY_HOT_PLUGGABLE = (1 << 1);
  public const ulong EFI_ACPI_3_0_MEMORY_NONVOLATILE = (1 << 2);
}

///
/// System Locality Distance Information Table (SLIT).
/// The rest of the table is a matrix.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_3_0_SYSTEM_LOCALITY_DISTANCE_INFORMATION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public ulong NumberOfSystemLocalities;
}

public unsafe partial class EFI
{
  /////
  ///// SLIT Version (as defined in ACPI 3.0 spec.)
  /////
  //public const ulong EFI_ACPI_3_0_SYSTEM_LOCALITY_DISTANCE_INFORMATION_TABLE_REVISION = 0x01;

  ////
  //// Known table signatures
  ////

  /////
  ///// "RSD PTR " Root System Description Pointer
  /////
  //public const ulong EFI_ACPI_3_0_ROOT_SYSTEM_DESCRIPTION_POINTER_SIGNATURE = SIGNATURE_64('R', 'S', 'D', ' ', 'P', 'T', 'R', ' ');

  /////
  ///// "APIC" Multiple APIC Description Table
  /////
  //public const ulong EFI_ACPI_3_0_MULTIPLE_APIC_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('A', 'P', 'I', 'C');

  /////
  ///// "DSDT" Differentiated System Description Table
  /////
  //public const ulong EFI_ACPI_3_0_DIFFERENTIATED_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('D', 'S', 'D', 'T');

  /////
  ///// "ECDT" Embedded Controller Boot Resources Table
  /////
  //public const ulong EFI_ACPI_3_0_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE_SIGNATURE = SIGNATURE_32('E', 'C', 'D', 'T');

  /////
  ///// "FACP" Fixed ACPI Description Table
  /////
  //public const ulong EFI_ACPI_3_0_FIXED_ACPI_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('F', 'A', 'C', 'P');

  /////
  ///// "FACS" Firmware ACPI Control Structure
  /////
  //public const ulong EFI_ACPI_3_0_FIRMWARE_ACPI_CONTROL_STRUCTURE_SIGNATURE = SIGNATURE_32('F', 'A', 'C', 'S');

  /////
  ///// "PSDT" Persistent System Description Table
  /////
  //public const ulong EFI_ACPI_3_0_PERSISTENT_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('P', 'S', 'D', 'T');

  /////
  ///// "RSDT" Root System Description Table
  /////
  //public const ulong EFI_ACPI_3_0_ROOT_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('R', 'S', 'D', 'T');

  /////
  ///// "SBST" Smart Battery Specification Table
  /////
  //public const ulong EFI_ACPI_3_0_SMART_BATTERY_SPECIFICATION_TABLE_SIGNATURE = SIGNATURE_32('S', 'B', 'S', 'T');

  /////
  ///// "SLIT" System Locality Information Table
  /////
  //public const ulong EFI_ACPI_3_0_SYSTEM_LOCALITY_INFORMATION_TABLE_SIGNATURE = SIGNATURE_32('S', 'L', 'I', 'T');

  /////
  ///// "SRAT" System Resource Affinity Table
  /////
  //public const ulong EFI_ACPI_3_0_SYSTEM_RESOURCE_AFFINITY_TABLE_SIGNATURE = SIGNATURE_32('S', 'R', 'A', 'T');

  /////
  ///// "SSDT" Secondary System Description Table
  /////
  //public const ulong EFI_ACPI_3_0_SECONDARY_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('S', 'S', 'D', 'T');

  /////
  ///// "XSDT" Extended System Description Table
  /////
  //public const ulong EFI_ACPI_3_0_EXTENDED_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('X', 'S', 'D', 'T');

  /////
  ///// "BOOT" MS Simple Boot Spec
  /////
  //public const ulong EFI_ACPI_3_0_SIMPLE_BOOT_FLAG_TABLE_SIGNATURE = SIGNATURE_32('B', 'O', 'O', 'T');

  /////
  ///// "CPEP" Corrected Platform Error Polling Table
  /////
  //public const ulong EFI_ACPI_3_0_CORRECTED_PLATFORM_ERROR_POLLING_TABLE_SIGNATURE = SIGNATURE_32('C', 'P', 'E', 'P');

  /////
  ///// "DBGP" MS Debug Port Spec
  /////
  //public const ulong EFI_ACPI_3_0_DEBUG_PORT_TABLE_SIGNATURE = SIGNATURE_32('D', 'B', 'G', 'P');

  /////
  ///// "ETDT" Event Timer Description Table
  /////
  //public const ulong EFI_ACPI_3_0_EVENT_TIMER_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('E', 'T', 'D', 'T');

  /////
  ///// "HPET" IA-PC High Precision Event Timer Table
  /////
  //public const ulong EFI_ACPI_3_0_HIGH_PRECISION_EVENT_TIMER_TABLE_SIGNATURE = SIGNATURE_32('H', 'P', 'E', 'T');

  /////
  ///// "MCFG" PCI Express Memory Mapped Configuration Space Base Address Description Table
  /////
  //public const ulong EFI_ACPI_3_0_PCI_EXPRESS_MEMORY_MAPPED_CONFIGURATION_SPACE_BASE_ADDRESS_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('M', 'C', 'F', 'G');

  /////
  ///// "SPCR" Serial Port Console Redirection Table
  /////
  //public const ulong EFI_ACPI_3_0_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_SIGNATURE = SIGNATURE_32('S', 'P', 'C', 'R');

  /////
  ///// "SPMI" Server Platform Management Interface Table
  /////
  //public const ulong EFI_ACPI_3_0_SERVER_PLATFORM_MANAGEMENT_INTERFACE_TABLE_SIGNATURE = SIGNATURE_32('S', 'P', 'M', 'I');

  /////
  ///// "TCPA" Trusted Computing Platform Alliance Capabilities Table
  /////
  //public const ulong EFI_ACPI_3_0_TRUSTED_COMPUTING_PLATFORM_ALLIANCE_CAPABILITIES_TABLE_SIGNATURE = SIGNATURE_32('T', 'C', 'P', 'A');

  /////
  ///// "WDRT" Watchdog Resource Table
  /////
  //public const ulong EFI_ACPI_3_0_WATCHDOG_RESOURCE_TABLE_SIGNATURE = SIGNATURE_32('W', 'D', 'R', 'T');

  /////
  ///// "WDAT" Watchdog Action Table
  /////
  //public const ulong EFI_ACPI_3_0_WATCHDOG_ACTION_TABLE_SIGNATURE = SIGNATURE_32('W', 'D', 'A', 'T');

  /////
  ///// "WSPT" Windows Specific Properties Table
  /////
  //public const ulong EFI_ACPI_3_0_WINDOWS_SPECIFIC_PROPERTIES_TABLE_SIGNATURE = SIGNATURE_32('W', 'S', 'P', 'T');

  /////
  ///// "iBFT" iSCSI Boot Firmware Table
  /////
  //public const ulong EFI_ACPI_3_0_ISCSI_BOOT_FIRMWARE_TABLE_SIGNATURE = SIGNATURE_32('i', 'B', 'F', 'T');

  // #pragma pack()
}

// #endif
