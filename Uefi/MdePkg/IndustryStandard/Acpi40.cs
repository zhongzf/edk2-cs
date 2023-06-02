using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI 4.0 definitions from the ACPI Specification Revision 4.0a April 5, 2010

  Copyright (c) 2010 - 2022, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _ACPI_4_0_H_
// #define _ACPI_4_0_H_

// #include <IndustryStandard/Acpi30.h>

//
// Ensure proper structure formats
//
// #pragma pack(1)

///
/// ACPI 4.0 Generic Address Space definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE
{
  public byte AddressSpaceId;
  public byte RegisterBitWidth;
  public byte RegisterBitOffset;
  public byte AccessSize;
  public ulong Address;
}

//
// Generic Address Space Address IDs
//
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_SYSTEM_MEMORY = 0;
  public const ulong EFI_ACPI_4_0_SYSTEM_IO = 1;
  public const ulong EFI_ACPI_4_0_PCI_CONFIGURATION_SPACE = 2;
  public const ulong EFI_ACPI_4_0_EMBEDDED_CONTROLLER = 3;
  public const ulong EFI_ACPI_4_0_SMBUS = 4;
  public const ulong EFI_ACPI_4_0_FUNCTIONAL_FIXED_HARDWARE = 0x7F;

  //
  // Generic Address Space Access Sizes
  //
  public const ulong EFI_ACPI_4_0_UNDEFINED = 0;
  public const ulong EFI_ACPI_4_0_BYTE = 1;
  public const ulong EFI_ACPI_4_0_WORD = 2;
  public const ulong EFI_ACPI_4_0_DWORD = 3;
  public const ulong EFI_ACPI_4_0_QWORD = 4;

  //
  // ACPI 4.0 table structures
  //
}

///
/// Root System Description Pointer Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_ROOT_SYSTEM_DESCRIPTION_POINTER
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

///
/// RSD_PTR Revision (as defined in ACPI 4.0b spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_ROOT_SYSTEM_DESCRIPTION_POINTER_REVISION = 0x02 ///< ACPISpec (Revision 4.0a) says current value is 2;
}

///
/// Common table header, this prefaces all ACPI tables, including FACS, but
/// excluding the RSD PTR structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_COMMON_HEADER
{
  public uint Signature;
  public uint Length;
}

//
// Root System Description Table
// No definition needed as it is a common description table header, the same with
// EFI_ACPI_DESCRIPTION_HEADER, followed by a variable number of uint table pointers.
//

///
/// RSDT Revision (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_ROOT_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x01;

  //
  // Extended System Description Table
  // No definition needed as it is a common description table header, the same with
  // EFI_ACPI_DESCRIPTION_HEADER, followed by a variable number of ulong table pointers.
  //

  ///
  /// XSDT Revision (as defined in ACPI 4.0 spec.)
  ///
  public const ulong EFI_ACPI_4_0_EXTENDED_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x01;
}

///
/// Fixed ACPI Description Table Structure (FADT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_FIXED_ACPI_DESCRIPTION_TABLE
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
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE ResetReg;
  public byte ResetValue;
  public fixed byte Reserved2[3];
  public ulong XFirmwareCtrl;
  public ulong XDsdt;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE XPm1aEvtBlk;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE XPm1bEvtBlk;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE XPm1aCntBlk;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE XPm1bCntBlk;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE XPm2CntBlk;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE XPmTmrBlk;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE XGpe0Blk;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE XGpe1Blk;
}

///
/// FADT Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_FIXED_ACPI_DESCRIPTION_TABLE_REVISION = 0x04;

  //
  // Fixed ACPI Description Table Preferred Power Management Profile
  //
  public const ulong EFI_ACPI_4_0_PM_PROFILE_UNSPECIFIED = 0;
  public const ulong EFI_ACPI_4_0_PM_PROFILE_DESKTOP = 1;
  public const ulong EFI_ACPI_4_0_PM_PROFILE_MOBILE = 2;
  public const ulong EFI_ACPI_4_0_PM_PROFILE_WORKSTATION = 3;
  public const ulong EFI_ACPI_4_0_PM_PROFILE_ENTERPRISE_SERVER = 4;
  public const ulong EFI_ACPI_4_0_PM_PROFILE_SOHO_SERVER = 5;
  public const ulong EFI_ACPI_4_0_PM_PROFILE_APPLIANCE_PC = 6;
  public const ulong EFI_ACPI_4_0_PM_PROFILE_PERFORMANCE_SERVER = 7;

  //
  // Fixed ACPI Description Table Boot Architecture Flags
  // All other bits are reserved and must be set to 0.
  //
  public const ulong EFI_ACPI_4_0_LEGACY_DEVICES = BIT0;
  public const ulong EFI_ACPI_4_0_8042 = BIT1;
  public const ulong EFI_ACPI_4_0_VGA_NOT_PRESENT = BIT2;
  public const ulong EFI_ACPI_4_0_MSI_NOT_SUPPORTED = BIT3;
  public const ulong EFI_ACPI_4_0_PCIE_ASPM_CONTROLS = BIT4;

  //
  // Fixed ACPI Description Table Fixed Feature Flags
  // All other bits are reserved and must be set to 0.
  //
  public const ulong EFI_ACPI_4_0_WBINVD = BIT0;
  public const ulong EFI_ACPI_4_0_WBINVD_FLUSH = BIT1;
  public const ulong EFI_ACPI_4_0_PROC_C1 = BIT2;
  public const ulong EFI_ACPI_4_0_P_LVL2_UP = BIT3;
  public const ulong EFI_ACPI_4_0_PWR_BUTTON = BIT4;
  public const ulong EFI_ACPI_4_0_SLP_BUTTON = BIT5;
  public const ulong EFI_ACPI_4_0_FIX_RTC = BIT6;
  public const ulong EFI_ACPI_4_0_RTC_S4 = BIT7;
  public const ulong EFI_ACPI_4_0_TMR_VAL_EXT = BIT8;
  public const ulong EFI_ACPI_4_0_DCK_CAP = BIT9;
  public const ulong EFI_ACPI_4_0_RESET_REG_SUP = BIT10;
  public const ulong EFI_ACPI_4_0_SEALED_CASE = BIT11;
  public const ulong EFI_ACPI_4_0_HEADLESS = BIT12;
  public const ulong EFI_ACPI_4_0_CPU_SW_SLP = BIT13;
  public const ulong EFI_ACPI_4_0_PCI_EXP_WAK = BIT14;
  public const ulong EFI_ACPI_4_0_USE_PLATFORM_CLOCK = BIT15;
  public const ulong EFI_ACPI_4_0_S4_RTC_STS_VALID = BIT16;
  public const ulong EFI_ACPI_4_0_REMOTE_POWER_ON_CAPABLE = BIT17;
  public const ulong EFI_ACPI_4_0_FORCE_APIC_CLUSTER_MODEL = BIT18;
  public const ulong EFI_ACPI_4_0_FORCE_APIC_PHYSICAL_DESTINATION_MODE = BIT19;
}

///
/// Firmware ACPI Control Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_FIRMWARE_ACPI_CONTROL_STRUCTURE
{
  public uint Signature;
  public uint Length;
  public uint HardwareSignature;
  public uint FirmwareWakingVector;
  public uint GlobalLock;
  public uint Flags;
  public ulong XFirmwareWakingVector;
  public byte Version;
  public fixed byte Reserved0[3];
  public uint OspmFlags;
  public fixed byte Reserved1[24];
}

///
/// FACS Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_FIRMWARE_ACPI_CONTROL_STRUCTURE_VERSION = 0x02;

  ///
  /// Firmware Control Structure Feature Flags
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_4_0_S4BIOS_F = BIT0;
  public const ulong EFI_ACPI_4_0_64BIT_WAKE_SUPPORTED_F = BIT1;

  ///
  /// OSPM Enabled Firmware Control Structure Flags
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_4_0_OSPM_64BIT_WAKE__F = BIT0;

  //
  // Differentiated System Description Table,
  // Secondary System Description Table
  // and Persistent System Description Table,
  // no definition needed as they are common description table header, the same with
  // EFI_ACPI_DESCRIPTION_HEADER, followed by a definition block.
  //
  public const ulong EFI_ACPI_4_0_DIFFERENTIATED_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x02;
  public const ulong EFI_ACPI_4_0_SECONDARY_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x02;
}

///
/// Multiple APIC Description Table header definition.  The rest of the table
/// must be defined in a platform specific manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_MULTIPLE_APIC_DESCRIPTION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint LocalApicAddress;
  public uint Flags;
}

///
/// MADT Revision (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_MULTIPLE_APIC_DESCRIPTION_TABLE_REVISION = 0x03;

  ///
  /// Multiple APIC Flags
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_4_0_PCAT_COMPAT = BIT0;

  //
  // Multiple APIC Description Table APIC structure types
  // All other values between 0x0B an 0xFF are reserved and
  // will be ignored by OSPM.
  //
  public const ulong EFI_ACPI_4_0_PROCESSOR_LOCAL_APIC = 0x00;
  public const ulong EFI_ACPI_4_0_IO_APIC = 0x01;
  public const ulong EFI_ACPI_4_0_INTERRUPT_SOURCE_OVERRIDE = 0x02;
  public const ulong EFI_ACPI_4_0_NON_MASKABLE_INTERRUPT_SOURCE = 0x03;
  public const ulong EFI_ACPI_4_0_LOCAL_APIC_NMI = 0x04;
  public const ulong EFI_ACPI_4_0_LOCAL_APIC_ADDRESS_OVERRIDE = 0x05;
  public const ulong EFI_ACPI_4_0_IO_SAPIC = 0x06;
  public const ulong EFI_ACPI_4_0_LOCAL_SAPIC = 0x07;
  public const ulong EFI_ACPI_4_0_PLATFORM_INTERRUPT_SOURCES = 0x08;
  public const ulong EFI_ACPI_4_0_PROCESSOR_LOCAL_X2APIC = 0x09;
  public const ulong EFI_ACPI_4_0_LOCAL_X2APIC_NMI = 0x0A;

  //
  // APIC Structure Definitions
  //
}

///
/// Processor Local APIC Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_PROCESSOR_LOCAL_APIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte AcpiProcessorId;
  public byte ApicId;
  public uint Flags;
}

///
/// Local APIC Flags.  All other bits are reserved and must be 0.
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_LOCAL_APIC_ENABLED = BIT0;
}

///
/// IO APIC Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_IO_APIC_STRUCTURE
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
public unsafe struct EFI_ACPI_4_0_INTERRUPT_SOURCE_OVERRIDE_STRUCTURE
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
public unsafe struct EFI_ACPI_4_0_PLATFORM_INTERRUPT_APIC_STRUCTURE
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

//
// MPS INTI flags.
// All other bits are reserved and must be set to 0.
//
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_POLARITY = (3 << 0);
  public const ulong EFI_ACPI_4_0_TRIGGER_MODE = (3 << 2);
}

///
/// Non-Maskable Interrupt Source Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_NON_MASKABLE_INTERRUPT_SOURCE_STRUCTURE
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
public unsafe struct EFI_ACPI_4_0_LOCAL_APIC_NMI_STRUCTURE
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
public unsafe struct EFI_ACPI_4_0_LOCAL_APIC_ADDRESS_OVERRIDE_STRUCTURE
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
public unsafe struct EFI_ACPI_4_0_IO_SAPIC_STRUCTURE
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
public unsafe struct EFI_ACPI_4_0_PROCESSOR_LOCAL_SAPIC_STRUCTURE
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
public unsafe struct EFI_ACPI_4_0_PLATFORM_INTERRUPT_SOURCES_STRUCTURE
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

///
/// Platform Interrupt Source Flags.
/// All other bits are reserved and must be set to 0.
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_CPEI_PROCESSOR_OVERRIDE = BIT0;
}

///
/// Processor Local x2APIC Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_PROCESSOR_LOCAL_X2APIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public fixed byte Reserved[2];
  public uint X2ApicId;
  public uint Flags;
  public uint AcpiProcessorUid;
}

///
/// Local x2APIC NMI Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_LOCAL_X2APIC_NMI_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Flags;
  public uint AcpiProcessorUid;
  public byte LocalX2ApicLint;
  public fixed byte Reserved[3];
}

///
/// Smart Battery Description Table (SBST)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_SMART_BATTERY_DESCRIPTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint WarningEnergyLevel;
  public uint LowEnergyLevel;
  public uint CriticalEnergyLevel;
}

///
/// SBST Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_SMART_BATTERY_DESCRIPTION_TABLE_REVISION = 0x01;
}

///
/// Embedded Controller Boot Resources Table (ECDT)
/// The table is followed by a null terminated ASCII string that contains
/// a fully qualified reference to the name space object.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE EcControl;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE EcData;
  public uint Uid;
  public byte GpeBit;
}

///
/// ECDT Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE_REVISION = 0x01;
}

///
/// System Resource Affinity Table (SRAT.  The rest of the table
/// must be defined in a platform specific manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_SYSTEM_RESOURCE_AFFINITY_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint Reserved1; ///< Must be set to 1
  public ulong Reserved2;
}

///
/// SRAT Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_SYSTEM_RESOURCE_AFFINITY_TABLE_REVISION = 0x03;

  //
  // SRAT structure types.
  // All other values between 0x03 an 0xFF are reserved and
  // will be ignored by OSPM.
  //
  public const ulong EFI_ACPI_4_0_PROCESSOR_LOCAL_APIC_SAPIC_AFFINITY = 0x00;
  public const ulong EFI_ACPI_4_0_MEMORY_AFFINITY = 0x01;
  public const ulong EFI_ACPI_4_0_PROCESSOR_LOCAL_X2APIC_AFFINITY = 0x02;
}

///
/// Processor Local APIC/SAPIC Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_PROCESSOR_LOCAL_APIC_SAPIC_AFFINITY_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte ProximityDomain7To0;
  public byte ApicId;
  public uint Flags;
  public byte LocalSapicEid;
  public fixed byte ProximityDomain31To8[3];
  public uint ClockDomain;
}

///
/// Local APIC/SAPIC Flags.  All other bits are reserved and must be 0.
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_PROCESSOR_LOCAL_APIC_SAPIC_ENABLED = (1 << 0);
}

///
/// Memory Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_MEMORY_AFFINITY_STRUCTURE
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

//
// Memory Flags.  All other bits are reserved and must be 0.
//
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_MEMORY_ENABLED = (1 << 0);
  public const ulong EFI_ACPI_4_0_MEMORY_HOT_PLUGGABLE = (1 << 1);
  public const ulong EFI_ACPI_4_0_MEMORY_NONVOLATILE = (1 << 2);
}

///
/// Processor Local x2APIC Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_PROCESSOR_LOCAL_X2APIC_AFFINITY_STRUCTURE
{
  public byte Type;
  public byte Length;
  public fixed byte Reserved1[2];
  public uint ProximityDomain;
  public uint X2ApicId;
  public uint Flags;
  public uint ClockDomain;
  public fixed byte Reserved2[4];
}

///
/// System Locality Distance Information Table (SLIT).
/// The rest of the table is a matrix.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_SYSTEM_LOCALITY_DISTANCE_INFORMATION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public ulong NumberOfSystemLocalities;
}

///
/// SLIT Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_SYSTEM_LOCALITY_DISTANCE_INFORMATION_TABLE_REVISION = 0x01;
}

///
/// Corrected Platform Error Polling Table (CPEP)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_CORRECTED_PLATFORM_ERROR_POLLING_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public fixed byte Reserved[8];
}

///
/// CPEP Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_CORRECTED_PLATFORM_ERROR_POLLING_TABLE_REVISION = 0x01;

  //
  // CPEP processor structure types.
  //
  public const ulong EFI_ACPI_4_0_CPEP_PROCESSOR_APIC_SAPIC = 0x00;
}

///
/// Corrected Platform Error Polling Processor Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_CPEP_PROCESSOR_APIC_SAPIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte ProcessorId;
  public byte ProcessorEid;
  public uint PollingInterval;
}

///
/// Maximum System Characteristics Table (MSCT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_MAXIMUM_SYSTEM_CHARACTERISTICS_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint OffsetProxDomInfo;
  public uint MaximumNumberOfProximityDomains;
  public uint MaximumNumberOfClockDomains;
  public ulong MaximumPhysicalAddress;
}

///
/// MSCT Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_MAXIMUM_SYSTEM_CHARACTERISTICS_TABLE_REVISION = 0x01;
}

///
/// Maximum Proximity Domain Information Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_MAXIMUM_PROXIMITY_DOMAIN_INFORMATION_STRUCTURE
{
  public byte Revision;
  public byte Length;
  public uint ProximityDomainRangeLow;
  public uint ProximityDomainRangeHigh;
  public uint MaximumProcessorCapacity;
  public ulong MaximumMemoryCapacity;
}

///
/// Boot Error Record Table (BERT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_BOOT_ERROR_RECORD_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint BootErrorRegionLength;
  public ulong BootErrorRegion;
}

///
/// BERT Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_BOOT_ERROR_RECORD_TABLE_REVISION = 0x01;
}

///
/// Boot Error Region Block Status Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_ERROR_BLOCK_STATUS
{
  public uint UncorrectableErrorValid = 1;
  public uint CorrectableErrorValid = 1;
  public uint MultipleUncorrectableErrors = 1;
  public uint MultipleCorrectableErrors = 1;
  public uint ErrorDataEntryCount = 10;
  public uint Reserved = 18;
}

///
/// Boot Error Region Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_BOOT_ERROR_REGION_STRUCTURE
{
  public EFI_ACPI_4_0_ERROR_BLOCK_STATUS BlockStatus;
  public uint RawDataOffset;
  public uint RawDataLength;
  public uint DataLength;
  public uint ErrorSeverity;
}

//
// Boot Error Severity types
//
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_ERROR_SEVERITY_CORRECTABLE = 0x00;
  public const ulong EFI_ACPI_4_0_ERROR_SEVERITY_RECOVERABLE = 0x00;
  public const ulong EFI_ACPI_4_0_ERROR_SEVERITY_FATAL = 0x01;
  public const ulong EFI_ACPI_4_0_ERROR_SEVERITY_CORRECTED = 0x02;
  public const ulong EFI_ACPI_4_0_ERROR_SEVERITY_NONE = 0x03;
}

///
/// Generic Error Data Entry Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_GENERIC_ERROR_DATA_ENTRY_STRUCTURE
{
  public fixed byte SectionType[16];
  public uint ErrorSeverity;
  public ushort Revision;
  public byte ValidationBits;
  public byte Flags;
  public uint ErrorDataLength;
  public fixed byte FruId[16];
  public fixed byte FruText[20];
}

///
/// Generic Error Data Entry Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_GENERIC_ERROR_DATA_ENTRY_REVISION = 0x0201;
}

///
/// HEST - Hardware Error Source Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_HARDWARE_ERROR_SOURCE_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint ErrorSourceCount;
}

///
/// HEST Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_HARDWARE_ERROR_SOURCE_TABLE_REVISION = 0x01;

  //
  // Error Source structure types.
  //
  public const ulong EFI_ACPI_4_0_IA32_ARCHITECTURE_MACHINE_CHECK_EXCEPTION = 0x00;
  public const ulong EFI_ACPI_4_0_IA32_ARCHITECTURE_CORRECTED_MACHINE_CHECK = 0x01;
  public const ulong EFI_ACPI_4_0_IA32_ARCHITECTURE_NMI_ERROR = 0x02;
  public const ulong EFI_ACPI_4_0_PCI_EXPRESS_ROOT_PORT_AER = 0x06;
  public const ulong EFI_ACPI_4_0_PCI_EXPRESS_DEVICE_AER = 0x07;
  public const ulong EFI_ACPI_4_0_PCI_EXPRESS_BRIDGE_AER = 0x08;
  public const ulong EFI_ACPI_4_0_GENERIC_HARDWARE_ERROR = 0x09;

  //
  // Error Source structure flags.
  //
  public const ulong EFI_ACPI_4_0_ERROR_SOURCE_FLAG_FIRMWARE_FIRST = (1 << 0);
  public const ulong EFI_ACPI_4_0_ERROR_SOURCE_FLAG_GLOBAL = (1 << 1);
}

///
/// IA-32 Architecture Machine Check Exception Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_IA32_ARCHITECTURE_MACHINE_CHECK_EXCEPTION_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public fixed byte Reserved0[2];
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public ulong GlobalCapabilityInitData;
  public ulong GlobalControlInitData;
  public byte NumberOfHardwareBanks;
  public fixed byte Reserved1[7];
}

///
/// IA-32 Architecture Machine Check Bank Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_BANK_STRUCTURE
{
  public byte BankNumber;
  public byte ClearStatusOnInitialization;
  public byte StatusDataFormat;
  public byte Reserved0;
  public uint ControlRegisterMsrAddress;
  public ulong ControlInitData;
  public uint StatusRegisterMsrAddress;
  public uint AddressRegisterMsrAddress;
  public uint MiscRegisterMsrAddress;
}

///
/// IA-32 Architecture Machine Check Bank Structure MCA data format
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_DATA_FORMAT_IA32 = 0x00;
  public const ulong EFI_ACPI_4_0_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_DATA_FORMAT_INTEL64 = 0x01;
  public const ulong EFI_ACPI_4_0_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_DATA_FORMAT_AMD64 = 0x02;

  //
  // Hardware Error Notification types. All other values are reserved
  //
  public const ulong EFI_ACPI_4_0_HARDWARE_ERROR_NOTIFICATION_POLLED = 0x00;
  public const ulong EFI_ACPI_4_0_HARDWARE_ERROR_NOTIFICATION_EXTERNAL_INTERRUPT = 0x01;
  public const ulong EFI_ACPI_4_0_HARDWARE_ERROR_NOTIFICATION_LOCAL_INTERRUPT = 0x02;
  public const ulong EFI_ACPI_4_0_HARDWARE_ERROR_NOTIFICATION_SCI = 0x03;
  public const ulong EFI_ACPI_4_0_HARDWARE_ERROR_NOTIFICATION_NMI = 0x04;
}

///
/// Hardware Error Notification Configuration Write Enable Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_HARDWARE_ERROR_NOTIFICATION_CONFIGURATION_WRITE_ENABLE_STRUCTURE
{
  public ushort Type = 1;
  public ushort PollInterval = 1;
  public ushort SwitchToPollingThresholdValue = 1;
  public ushort SwitchToPollingThresholdWindow = 1;
  public ushort ErrorThresholdValue = 1;
  public ushort ErrorThresholdWindow = 1;
  public ushort Reserved = 10;
}

///
/// Hardware Error Notification Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_HARDWARE_ERROR_NOTIFICATION_STRUCTURE
{
  public byte Type;
  public byte Length;
  public EFI_ACPI_4_0_HARDWARE_ERROR_NOTIFICATION_CONFIGURATION_WRITE_ENABLE_STRUCTURE ConfigurationWriteEnable;
  public uint PollInterval;
  public uint Vector;
  public uint SwitchToPollingThresholdValue;
  public uint SwitchToPollingThresholdWindow;
  public uint ErrorThresholdValue;
  public uint ErrorThresholdWindow;
}

///
/// IA-32 Architecture Corrected Machine Check Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_IA32_ARCHITECTURE_CORRECTED_MACHINE_CHECK_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public fixed byte Reserved0[2];
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public EFI_ACPI_4_0_HARDWARE_ERROR_NOTIFICATION_STRUCTURE NotificationStructure;
  public byte NumberOfHardwareBanks;
  public fixed byte Reserved1[3];
}

///
/// IA-32 Architecture NMI Error Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_IA32_ARCHITECTURE_NMI_ERROR_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public fixed byte Reserved0[2];
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public uint MaxRawDataLength;
}

///
/// PCI Express Root Port AER Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_PCI_EXPRESS_ROOT_PORT_AER_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public fixed byte Reserved0[2];
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public uint Bus;
  public ushort Device;
  public ushort Function;
  public ushort DeviceControl;
  public fixed byte Reserved1[2];
  public uint UncorrectableErrorMask;
  public uint UncorrectableErrorSeverity;
  public uint CorrectableErrorMask;
  public uint AdvancedErrorCapabilitiesAndControl;
  public uint RootErrorCommand;
}

///
/// PCI Express Device AER Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_PCI_EXPRESS_DEVICE_AER_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public fixed byte Reserved0[2];
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public uint Bus;
  public ushort Device;
  public ushort Function;
  public ushort DeviceControl;
  public fixed byte Reserved1[2];
  public uint UncorrectableErrorMask;
  public uint UncorrectableErrorSeverity;
  public uint CorrectableErrorMask;
  public uint AdvancedErrorCapabilitiesAndControl;
}

///
/// PCI Express Bridge AER Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_PCI_EXPRESS_BRIDGE_AER_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public fixed byte Reserved0[2];
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public uint Bus;
  public ushort Device;
  public ushort Function;
  public ushort DeviceControl;
  public fixed byte Reserved1[2];
  public uint UncorrectableErrorMask;
  public uint UncorrectableErrorSeverity;
  public uint CorrectableErrorMask;
  public uint AdvancedErrorCapabilitiesAndControl;
  public uint SecondaryUncorrectableErrorMask;
  public uint SecondaryUncorrectableErrorSeverity;
  public uint SecondaryAdvancedErrorCapabilitiesAndControl;
}

///
/// Generic Hardware Error Source Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_GENERIC_HARDWARE_ERROR_SOURCE_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public ushort RelatedSourceId;
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public uint MaxRawDataLength;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE ErrorStatusAddress;
  public EFI_ACPI_4_0_HARDWARE_ERROR_NOTIFICATION_STRUCTURE NotificationStructure;
  public uint ErrorStatusBlockLength;
}

///
/// Generic Error Status Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_GENERIC_ERROR_STATUS_STRUCTURE
{
  public EFI_ACPI_4_0_ERROR_BLOCK_STATUS BlockStatus;
  public uint RawDataOffset;
  public uint RawDataLength;
  public uint DataLength;
  public uint ErrorSeverity;
}

///
/// ERST - Error Record Serialization Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_ERROR_RECORD_SERIALIZATION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint SerializationHeaderSize;
  public fixed byte Reserved0[4];
  public uint InstructionEntryCount;
}

///
/// ERST Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_ERROR_RECORD_SERIALIZATION_TABLE_REVISION = 0x01;

  ///
  /// ERST Serialization Actions
  ///
  public const ulong EFI_ACPI_4_0_ERST_BEGIN_WRITE_OPERATION = 0x00;
  public const ulong EFI_ACPI_4_0_ERST_BEGIN_READ_OPERATION = 0x01;
  public const ulong EFI_ACPI_4_0_ERST_BEGIN_CLEAR_OPERATION = 0x02;
  public const ulong EFI_ACPI_4_0_ERST_END_OPERATION = 0x03;
  public const ulong EFI_ACPI_4_0_ERST_SET_RECORD_OFFSET = 0x04;
  public const ulong EFI_ACPI_4_0_ERST_EXECUTE_OPERATION = 0x05;
  public const ulong EFI_ACPI_4_0_ERST_CHECK_BUSY_STATUS = 0x06;
  public const ulong EFI_ACPI_4_0_ERST_GET_COMMAND_STATUS = 0x07;
  public const ulong EFI_ACPI_4_0_ERST_GET_RECORD_IDENTIFIER = 0x08;
  public const ulong EFI_ACPI_4_0_ERST_SET_RECORD_IDENTIFIER = 0x09;
  public const ulong EFI_ACPI_4_0_ERST_GET_RECORD_COUNT = 0x0A;
  public const ulong EFI_ACPI_4_0_ERST_BEGIN_DUMMY_WRITE_OPERATION = 0x0B;
  public const ulong EFI_ACPI_4_0_ERST_GET_ERROR_LOG_ADDRESS_RANGE = 0x0D;
  public const ulong EFI_ACPI_4_0_ERST_GET_ERROR_LOG_ADDRESS_RANGE_LENGTH = 0x0E;
  public const ulong EFI_ACPI_4_0_ERST_GET_ERROR_LOG_ADDRESS_RANGE_ATTRIBUTES = 0x0F;

  ///
  /// ERST Action Command Status
  ///
  public const ulong EFI_ACPI_4_0_EINJ_STATUS_SUCCESS = 0x00;
  public const ulong EFI_ACPI_4_0_EINJ_STATUS_NOT_ENOUGH_SPACE = 0x01;
  public const ulong EFI_ACPI_4_0_EINJ_STATUS_HARDWARE_NOT_AVAILABLE = 0x02;
  public const ulong EFI_ACPI_4_0_EINJ_STATUS_FAILED = 0x03;
  public const ulong EFI_ACPI_4_0_EINJ_STATUS_RECORD_STORE_EMPTY = 0x04;
  public const ulong EFI_ACPI_4_0_EINJ_STATUS_RECORD_NOT_FOUND = 0x05;

  ///
  /// ERST Serialization Instructions
  ///
  public const ulong EFI_ACPI_4_0_ERST_READ_REGISTER = 0x00;
  public const ulong EFI_ACPI_4_0_ERST_READ_REGISTER_VALUE = 0x01;
  public const ulong EFI_ACPI_4_0_ERST_WRITE_REGISTER = 0x02;
  public const ulong EFI_ACPI_4_0_ERST_WRITE_REGISTER_VALUE = 0x03;
  public const ulong EFI_ACPI_4_0_ERST_NOOP = 0x04;
  public const ulong EFI_ACPI_4_0_ERST_LOAD_VAR1 = 0x05;
  public const ulong EFI_ACPI_4_0_ERST_LOAD_VAR2 = 0x06;
  public const ulong EFI_ACPI_4_0_ERST_STORE_VAR1 = 0x07;
  public const ulong EFI_ACPI_4_0_ERST_ADD = 0x08;
  public const ulong EFI_ACPI_4_0_ERST_SUBTRACT = 0x09;
  public const ulong EFI_ACPI_4_0_ERST_ADD_VALUE = 0x0A;
  public const ulong EFI_ACPI_4_0_ERST_SUBTRACT_VALUE = 0x0B;
  public const ulong EFI_ACPI_4_0_ERST_STALL = 0x0C;
  public const ulong EFI_ACPI_4_0_ERST_STALL_WHILE_TRUE = 0x0D;
  public const ulong EFI_ACPI_4_0_ERST_SKIP_NEXT_INSTRUCTION_IF_TRUE = 0x0E;
  public const ulong EFI_ACPI_4_0_ERST_GOTO = 0x0F;
  public const ulong EFI_ACPI_4_0_ERST_SET_SRC_ADDRESS_BASE = 0x10;
  public const ulong EFI_ACPI_4_0_ERST_SET_DST_ADDRESS_BASE = 0x11;
  public const ulong EFI_ACPI_4_0_ERST_MOVE_DATA = 0x12;

  ///
  /// ERST Instruction Flags
  ///
  public const ulong EFI_ACPI_4_0_ERST_PRESERVE_REGISTER = 0x01;
}

///
/// ERST Serialization Instruction Entry
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_ERST_SERIALIZATION_INSTRUCTION_ENTRY
{
  public byte SerializationAction;
  public byte Instruction;
  public byte Flags;
  public byte Reserved0;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE RegisterRegion;
  public ulong Value;
  public ulong Mask;
}

///
/// EINJ - Error Injection Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_ERROR_INJECTION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint InjectionHeaderSize;
  public byte InjectionFlags;
  public fixed byte Reserved0[3];
  public uint InjectionEntryCount;
}

///
/// EINJ Version (as defined in ACPI 4.0 spec.)
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_ERROR_INJECTION_TABLE_REVISION = 0x01;

  ///
  /// EINJ Error Injection Actions
  ///
  public const ulong EFI_ACPI_4_0_EINJ_BEGIN_INJECTION_OPERATION = 0x00;
  public const ulong EFI_ACPI_4_0_EINJ_GET_TRIGGER_ERROR_ACTION_TABLE = 0x01;
  public const ulong EFI_ACPI_4_0_EINJ_SET_ERROR_TYPE = 0x02;
  public const ulong EFI_ACPI_4_0_EINJ_GET_ERROR_TYPE = 0x03;
  public const ulong EFI_ACPI_4_0_EINJ_END_OPERATION = 0x04;
  public const ulong EFI_ACPI_4_0_EINJ_EXECUTE_OPERATION = 0x05;
  public const ulong EFI_ACPI_4_0_EINJ_CHECK_BUSY_STATUS = 0x06;
  public const ulong EFI_ACPI_4_0_EINJ_GET_COMMAND_STATUS = 0x07;
  public const ulong EFI_ACPI_4_0_EINJ_TRIGGER_ERROR = 0xFF;

  ///
  /// EINJ Action Command Status
  ///
  public const ulong EFI_ACPI_4_0_EINJ_STATUS_SUCCESS = 0x00;
  public const ulong EFI_ACPI_4_0_EINJ_STATUS_UNKNOWN_FAILURE = 0x01;
  public const ulong EFI_ACPI_4_0_EINJ_STATUS_INVALID_ACCESS = 0x02;

  ///
  /// EINJ Error Type Definition
  ///
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_PROCESSOR_CORRECTABLE = (1 << 0);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_PROCESSOR_UNCORRECTABLE_NONFATAL = (1 << 1);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_PROCESSOR_UNCORRECTABLE_FATAL = (1 << 2);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_MEMORY_CORRECTABLE = (1 << 3);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_MEMORY_UNCORRECTABLE_NONFATAL = (1 << 4);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_MEMORY_UNCORRECTABLE_FATAL = (1 << 5);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_PCI_EXPRESS_CORRECTABLE = (1 << 6);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_PCI_EXPRESS_UNCORRECTABLE_NONFATAL = (1 << 7);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_PCI_EXPRESS_UNCORRECTABLE_FATAL = (1 << 8);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_PLATFORM_CORRECTABLE = (1 << 9);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_PLATFORM_UNCORRECTABLE_NONFATAL = (1 << 10);
  public const ulong EFI_ACPI_4_0_EINJ_ERROR_PLATFORM_UNCORRECTABLE_FATAL = (1 << 11);

  ///
  /// EINJ Injection Instructions
  ///
  public const ulong EFI_ACPI_4_0_EINJ_READ_REGISTER = 0x00;
  public const ulong EFI_ACPI_4_0_EINJ_READ_REGISTER_VALUE = 0x01;
  public const ulong EFI_ACPI_4_0_EINJ_WRITE_REGISTER = 0x02;
  public const ulong EFI_ACPI_4_0_EINJ_WRITE_REGISTER_VALUE = 0x03;
  public const ulong EFI_ACPI_4_0_EINJ_NOOP = 0x04;

  ///
  /// EINJ Instruction Flags
  ///
  public const ulong EFI_ACPI_4_0_EINJ_PRESERVE_REGISTER = 0x01;
}

///
/// EINJ Injection Instruction Entry
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_EINJ_INJECTION_INSTRUCTION_ENTRY
{
  public byte InjectionAction;
  public byte Instruction;
  public byte Flags;
  public byte Reserved0;
  public EFI_ACPI_4_0_GENERIC_ADDRESS_STRUCTURE RegisterRegion;
  public ulong Value;
  public ulong Mask;
}

///
/// EINJ Trigger Action Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_4_0_EINJ_TRIGGER_ACTION_TABLE
{
  public uint HeaderSize;
  public uint Revision;
  public uint TableSize;
  public uint EntryCount;
}

//
// Known table signatures
//

///
/// "RSD PTR " Root System Description Pointer
///
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_4_0_ROOT_SYSTEM_DESCRIPTION_POINTER_SIGNATURE = SIGNATURE_64('R', 'S', 'D', ' ', 'P', 'T', 'R', ' ');

  ///
  /// "APIC" Multiple APIC Description Table
  ///
  public const ulong EFI_ACPI_4_0_MULTIPLE_APIC_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('A', 'P', 'I', 'C');

  ///
  /// "BERT" Boot Error Record Table
  ///
  public const ulong EFI_ACPI_4_0_BOOT_ERROR_RECORD_TABLE_SIGNATURE = SIGNATURE_32('B', 'E', 'R', 'T');

  ///
  /// "CPEP" Corrected Platform Error Polling Table
  ///
  public const ulong EFI_ACPI_4_0_CORRECTED_PLATFORM_ERROR_POLLING_TABLE_SIGNATURE = SIGNATURE_32('C', 'P', 'E', 'P');

  ///
  /// "DSDT" Differentiated System Description Table
  ///
  public const ulong EFI_ACPI_4_0_DIFFERENTIATED_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('D', 'S', 'D', 'T');

  ///
  /// "ECDT" Embedded Controller Boot Resources Table
  ///
  public const ulong EFI_ACPI_4_0_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE_SIGNATURE = SIGNATURE_32('E', 'C', 'D', 'T');

  ///
  /// "EINJ" Error Injection Table
  ///
  public const ulong EFI_ACPI_4_0_ERROR_INJECTION_TABLE_SIGNATURE = SIGNATURE_32('E', 'I', 'N', 'J');

  ///
  /// "ERST" Error Record Serialization Table
  ///
  public const ulong EFI_ACPI_4_0_ERROR_RECORD_SERIALIZATION_TABLE_SIGNATURE = SIGNATURE_32('E', 'R', 'S', 'T');

  ///
  /// "FACP" Fixed ACPI Description Table
  ///
  public const ulong EFI_ACPI_4_0_FIXED_ACPI_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('F', 'A', 'C', 'P');

  ///
  /// "FACS" Firmware ACPI Control Structure
  ///
  public const ulong EFI_ACPI_4_0_FIRMWARE_ACPI_CONTROL_STRUCTURE_SIGNATURE = SIGNATURE_32('F', 'A', 'C', 'S');

  ///
  /// "HEST" Hardware Error Source Table
  ///
  public const ulong EFI_ACPI_4_0_HARDWARE_ERROR_SOURCE_TABLE_SIGNATURE = SIGNATURE_32('H', 'E', 'S', 'T');

  ///
  /// "MSCT" Maximum System Characteristics Table
  ///
  public const ulong EFI_ACPI_4_0_MAXIMUM_SYSTEM_CHARACTERISTICS_TABLE_SIGNATURE = SIGNATURE_32('M', 'S', 'C', 'T');

  ///
  /// "PSDT" Persistent System Description Table
  ///
  public const ulong EFI_ACPI_4_0_PERSISTENT_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('P', 'S', 'D', 'T');

  ///
  /// "RSDT" Root System Description Table
  ///
  public const ulong EFI_ACPI_4_0_ROOT_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('R', 'S', 'D', 'T');

  ///
  /// "SBST" Smart Battery Specification Table
  ///
  public const ulong EFI_ACPI_4_0_SMART_BATTERY_SPECIFICATION_TABLE_SIGNATURE = SIGNATURE_32('S', 'B', 'S', 'T');

  ///
  /// "SLIT" System Locality Information Table
  ///
  public const ulong EFI_ACPI_4_0_SYSTEM_LOCALITY_INFORMATION_TABLE_SIGNATURE = SIGNATURE_32('S', 'L', 'I', 'T');

  ///
  /// "SRAT" System Resource Affinity Table
  ///
  public const ulong EFI_ACPI_4_0_SYSTEM_RESOURCE_AFFINITY_TABLE_SIGNATURE = SIGNATURE_32('S', 'R', 'A', 'T');

  ///
  /// "SSDT" Secondary System Description Table
  ///
  public const ulong EFI_ACPI_4_0_SECONDARY_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('S', 'S', 'D', 'T');

  ///
  /// "XSDT" Extended System Description Table
  ///
  public const ulong EFI_ACPI_4_0_EXTENDED_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('X', 'S', 'D', 'T');

  ///
  /// "BOOT" MS Simple Boot Spec
  ///
  public const ulong EFI_ACPI_4_0_SIMPLE_BOOT_FLAG_TABLE_SIGNATURE = SIGNATURE_32('B', 'O', 'O', 'T');

  ///
  /// "DBGP" MS Debug Port Spec
  ///
  public const ulong EFI_ACPI_4_0_DEBUG_PORT_TABLE_SIGNATURE = SIGNATURE_32('D', 'B', 'G', 'P');

  ///
  /// "DMAR" DMA Remapping Table
  ///
  public const ulong EFI_ACPI_4_0_DMA_REMAPPING_TABLE_SIGNATURE = SIGNATURE_32('D', 'M', 'A', 'R');

  ///
  /// "ETDT" Event Timer Description Table
  ///
  public const ulong EFI_ACPI_4_0_EVENT_TIMER_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('E', 'T', 'D', 'T');

  ///
  /// "HPET" IA-PC High Precision Event Timer Table
  ///
  public const ulong EFI_ACPI_4_0_HIGH_PRECISION_EVENT_TIMER_TABLE_SIGNATURE = SIGNATURE_32('H', 'P', 'E', 'T');

  ///
  /// "iBFT" iSCSI Boot Firmware Table
  ///
  public const ulong EFI_ACPI_4_0_ISCSI_BOOT_FIRMWARE_TABLE_SIGNATURE = SIGNATURE_32('i', 'B', 'F', 'T');

  ///
  /// "IVRS" I/O Virtualization Reporting Structure
  ///
  public const ulong EFI_ACPI_4_0_IO_VIRTUALIZATION_REPORTING_STRUCTURE_SIGNATURE = SIGNATURE_32('I', 'V', 'R', 'S');

  ///
  /// "MCFG" PCI Express Memory Mapped Configuration Space Base Address Description Table
  ///
  public const ulong EFI_ACPI_4_0_PCI_EXPRESS_MEMORY_MAPPED_CONFIGURATION_SPACE_BASE_ADDRESS_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('M', 'C', 'F', 'G');

  ///
  /// "MCHI" Management Controller Host Interface Table
  ///
  public const ulong EFI_ACPI_4_0_MANAGEMENT_CONTROLLER_HOST_INTERFACE_TABLE_SIGNATURE = SIGNATURE_32('M', 'C', 'H', 'I');

  ///
  /// "SPCR" Serial Port Console Redirection Table
  ///
  public const ulong EFI_ACPI_4_0_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_SIGNATURE = SIGNATURE_32('S', 'P', 'C', 'R');

  ///
  /// "SPMI" Server Platform Management Interface Table
  ///
  public const ulong EFI_ACPI_4_0_SERVER_PLATFORM_MANAGEMENT_INTERFACE_TABLE_SIGNATURE = SIGNATURE_32('S', 'P', 'M', 'I');

  ///
  /// "TCPA" Trusted Computing Platform Alliance Capabilities Table
  ///
  public const ulong EFI_ACPI_4_0_TRUSTED_COMPUTING_PLATFORM_ALLIANCE_CAPABILITIES_TABLE_SIGNATURE = SIGNATURE_32('T', 'C', 'P', 'A');

  ///
  /// "UEFI" UEFI ACPI Data Table
  ///
  public const ulong EFI_ACPI_4_0_UEFI_ACPI_DATA_TABLE_SIGNATURE = SIGNATURE_32('U', 'E', 'F', 'I');

  ///
  /// "WAET" Windows ACPI Enlightenment Table
  ///
  public const ulong EFI_ACPI_4_0_WINDOWS_ACPI_ENLIGHTENMENT_TABLE_SIGNATURE = SIGNATURE_32('W', 'A', 'E', 'T');

  ///
  /// "WDAT" Watchdog Action Table
  ///
  public const ulong EFI_ACPI_4_0_WATCHDOG_ACTION_TABLE_SIGNATURE = SIGNATURE_32('W', 'D', 'A', 'T');

  ///
  /// "WDRT" Watchdog Resource Table
  ///
  public const ulong EFI_ACPI_4_0_WATCHDOG_RESOURCE_TABLE_SIGNATURE = SIGNATURE_32('W', 'D', 'R', 'T');

  // #pragma pack()
}

// #endif
