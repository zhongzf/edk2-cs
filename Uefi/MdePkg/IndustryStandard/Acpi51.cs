using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI 5.1 definitions from the ACPI Specification Revision 5.1 Errata B January, 2016.

  Copyright (c) 2014 Hewlett-Packard Development Company, L.P.<BR>
  Copyright (c) 2014 - 2022, Intel Corporation. All rights reserved.<BR>
  (C) Copyright 2015 Hewlett Packard Enterprise Development LP<BR>
  Copyright (c) 2020, ARM Ltd. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _ACPI_5_1_H_
// #define _ACPI_5_1_H_

// #include <IndustryStandard/Acpi50.h>

//
// Ensure proper structure formats
//
// #pragma pack(1)

///
/// ACPI 5.1 Generic Address Space definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE
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
public const ulong EFI_ACPI_5_1_SYSTEM_MEMORY = 0;
public const ulong EFI_ACPI_5_1_SYSTEM_IO = 1;
public const ulong EFI_ACPI_5_1_PCI_CONFIGURATION_SPACE = 2;
public const ulong EFI_ACPI_5_1_EMBEDDED_CONTROLLER = 3;
public const ulong EFI_ACPI_5_1_SMBUS = 4;
public const ulong EFI_ACPI_5_1_PLATFORM_COMMUNICATION_CHANNEL = 0x0A;
public const ulong EFI_ACPI_5_1_FUNCTIONAL_FIXED_HARDWARE = 0x7F;

//
// Generic Address Space Access Sizes
//
public const ulong EFI_ACPI_5_1_UNDEFINED = 0;
public const ulong EFI_ACPI_5_1_BYTE = 1;
public const ulong EFI_ACPI_5_1_WORD = 2;
public const ulong EFI_ACPI_5_1_DWORD = 3;
public const ulong EFI_ACPI_5_1_QWORD = 4;

//
// ACPI 5.1 table structures
//

///
/// Root System Description Pointer Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_ROOT_SYSTEM_DESCRIPTION_POINTER
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
/// RSD_PTR Revision (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_ROOT_SYSTEM_DESCRIPTION_POINTER_REVISION = 0x02 ///< ACPISpec (Revision 5.1) says current value is 2;

///
/// Common table header, this prefaces all ACPI tables, including FACS, but
/// excluding the RSD PTR structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_COMMON_HEADER
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
/// RSDT Revision (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_ROOT_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x01;

//
// Extended System Description Table
// No definition needed as it is a common description table header, the same with
// EFI_ACPI_DESCRIPTION_HEADER, followed by a variable number of ulong table pointers.
//

///
/// XSDT Revision (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_EXTENDED_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x01;

///
/// Fixed ACPI Description Table Structure (FADT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FIXED_ACPI_DESCRIPTION_TABLE
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
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE ResetReg;
  public byte ResetValue;
  public ushort ArmBootArch;
  public byte MinorVersion;
  public ulong XFirmwareCtrl;
  public ulong XDsdt;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE XPm1aEvtBlk;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE XPm1bEvtBlk;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE XPm1aCntBlk;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE XPm1bCntBlk;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE XPm2CntBlk;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE XPmTmrBlk;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE XGpe0Blk;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE XGpe1Blk;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE SleepControlReg;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE SleepStatusReg;
}

///
/// FADT Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_FIXED_ACPI_DESCRIPTION_TABLE_REVISION = 0x05;
public const ulong EFI_ACPI_5_1_FIXED_ACPI_DESCRIPTION_TABLE_MINOR_REVISION = 0x01;

//
// Fixed ACPI Description Table Preferred Power Management Profile
//
public const ulong EFI_ACPI_5_1_PM_PROFILE_UNSPECIFIED = 0;
public const ulong EFI_ACPI_5_1_PM_PROFILE_DESKTOP = 1;
public const ulong EFI_ACPI_5_1_PM_PROFILE_MOBILE = 2;
public const ulong EFI_ACPI_5_1_PM_PROFILE_WORKSTATION = 3;
public const ulong EFI_ACPI_5_1_PM_PROFILE_ENTERPRISE_SERVER = 4;
public const ulong EFI_ACPI_5_1_PM_PROFILE_SOHO_SERVER = 5;
public const ulong EFI_ACPI_5_1_PM_PROFILE_APPLIANCE_PC = 6;
public const ulong EFI_ACPI_5_1_PM_PROFILE_PERFORMANCE_SERVER = 7;
public const ulong EFI_ACPI_5_1_PM_PROFILE_TABLET = 8;

//
// Fixed ACPI Description Table Boot Architecture Flags
// All other bits are reserved and must be set to 0.
//
public const ulong EFI_ACPI_5_1_LEGACY_DEVICES = BIT0;
public const ulong EFI_ACPI_5_1_8042 = BIT1;
public const ulong EFI_ACPI_5_1_VGA_NOT_PRESENT = BIT2;
public const ulong EFI_ACPI_5_1_MSI_NOT_SUPPORTED = BIT3;
public const ulong EFI_ACPI_5_1_PCIE_ASPM_CONTROLS = BIT4;
public const ulong EFI_ACPI_5_1_CMOS_RTC_NOT_PRESENT = BIT5;

//
// Fixed ACPI Description Table Arm Boot Architecture Flags
// All other bits are reserved and must be set to 0.
//
public const ulong EFI_ACPI_5_1_ARM_PSCI_COMPLIANT = BIT0;
public const ulong EFI_ACPI_5_1_ARM_PSCI_USE_HVC = BIT1;

//
// Fixed ACPI Description Table Fixed Feature Flags
// All other bits are reserved and must be set to 0.
//
public const ulong EFI_ACPI_5_1_WBINVD = BIT0;
public const ulong EFI_ACPI_5_1_WBINVD_FLUSH = BIT1;
public const ulong EFI_ACPI_5_1_PROC_C1 = BIT2;
public const ulong EFI_ACPI_5_1_P_LVL2_UP = BIT3;
public const ulong EFI_ACPI_5_1_PWR_BUTTON = BIT4;
public const ulong EFI_ACPI_5_1_SLP_BUTTON = BIT5;
public const ulong EFI_ACPI_5_1_FIX_RTC = BIT6;
public const ulong EFI_ACPI_5_1_RTC_S4 = BIT7;
public const ulong EFI_ACPI_5_1_TMR_VAL_EXT = BIT8;
public const ulong EFI_ACPI_5_1_DCK_CAP = BIT9;
public const ulong EFI_ACPI_5_1_RESET_REG_SUP = BIT10;
public const ulong EFI_ACPI_5_1_SEALED_CASE = BIT11;
public const ulong EFI_ACPI_5_1_HEADLESS = BIT12;
public const ulong EFI_ACPI_5_1_CPU_SW_SLP = BIT13;
public const ulong EFI_ACPI_5_1_PCI_EXP_WAK = BIT14;
public const ulong EFI_ACPI_5_1_USE_PLATFORM_CLOCK = BIT15;
public const ulong EFI_ACPI_5_1_S4_RTC_STS_VALID = BIT16;
public const ulong EFI_ACPI_5_1_REMOTE_POWER_ON_CAPABLE = BIT17;
public const ulong EFI_ACPI_5_1_FORCE_APIC_CLUSTER_MODEL = BIT18;
public const ulong EFI_ACPI_5_1_FORCE_APIC_PHYSICAL_DESTINATION_MODE = BIT19;
public const ulong EFI_ACPI_5_1_HW_REDUCED_ACPI = BIT20;
public const ulong EFI_ACPI_5_1_LOW_POWER_S0_IDLE_CAPABLE = BIT21;

///
/// Firmware ACPI Control Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FIRMWARE_ACPI_CONTROL_STRUCTURE
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
/// FACS Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_FIRMWARE_ACPI_CONTROL_STRUCTURE_VERSION = 0x02;

///
/// Firmware Control Structure Feature Flags
/// All other bits are reserved and must be set to 0.
///
public const ulong EFI_ACPI_5_1_S4BIOS_F = BIT0;
public const ulong EFI_ACPI_5_1_64BIT_WAKE_SUPPORTED_F = BIT1;

///
/// OSPM Enabled Firmware Control Structure Flags
/// All other bits are reserved and must be set to 0.
///
public const ulong EFI_ACPI_5_1_OSPM_64BIT_WAKE_F = BIT0;

//
// Differentiated System Description Table,
// Secondary System Description Table
// and Persistent System Description Table,
// no definition needed as they are common description table header, the same with
// EFI_ACPI_DESCRIPTION_HEADER, followed by a definition block.
//
public const ulong EFI_ACPI_5_1_DIFFERENTIATED_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x02;
public const ulong EFI_ACPI_5_1_SECONDARY_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x02;

///
/// Multiple APIC Description Table header definition.  The rest of the table
/// must be defined in a platform specific manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MULTIPLE_APIC_DESCRIPTION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint LocalApicAddress;
  public uint Flags;
}

///
/// MADT Revision (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_MULTIPLE_APIC_DESCRIPTION_TABLE_REVISION = 0x03;

///
/// Multiple APIC Flags
/// All other bits are reserved and must be set to 0.
///
public const ulong EFI_ACPI_5_1_PCAT_COMPAT = BIT0;

//
// Multiple APIC Description Table APIC structure types
// All other values between 0x0D and 0x7F are reserved and
// will be ignored by OSPM. 0x80 ~ 0xFF are reserved for OEM.
//
public const ulong EFI_ACPI_5_1_PROCESSOR_LOCAL_APIC = 0x00;
public const ulong EFI_ACPI_5_1_IO_APIC = 0x01;
public const ulong EFI_ACPI_5_1_INTERRUPT_SOURCE_OVERRIDE = 0x02;
public const ulong EFI_ACPI_5_1_NON_MASKABLE_INTERRUPT_SOURCE = 0x03;
public const ulong EFI_ACPI_5_1_LOCAL_APIC_NMI = 0x04;
public const ulong EFI_ACPI_5_1_LOCAL_APIC_ADDRESS_OVERRIDE = 0x05;
public const ulong EFI_ACPI_5_1_IO_SAPIC = 0x06;
public const ulong EFI_ACPI_5_1_LOCAL_SAPIC = 0x07;
public const ulong EFI_ACPI_5_1_PLATFORM_INTERRUPT_SOURCES = 0x08;
public const ulong EFI_ACPI_5_1_PROCESSOR_LOCAL_X2APIC = 0x09;
public const ulong EFI_ACPI_5_1_LOCAL_X2APIC_NMI = 0x0A;
public const ulong EFI_ACPI_5_1_GIC = 0x0B;
public const ulong EFI_ACPI_5_1_GICD = 0x0C;
public const ulong EFI_ACPI_5_1_GIC_MSI_FRAME = 0x0D;
public const ulong EFI_ACPI_5_1_GICR = 0x0E;

//
// APIC Structure Definitions
//

///
/// Processor Local APIC Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PROCESSOR_LOCAL_APIC_STRUCTURE
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
public const ulong EFI_ACPI_5_1_LOCAL_APIC_ENABLED = BIT0;

///
/// IO APIC Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_IO_APIC_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_INTERRUPT_SOURCE_OVERRIDE_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_PLATFORM_INTERRUPT_APIC_STRUCTURE
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
public const ulong EFI_ACPI_5_1_POLARITY = (3 << 0);
public const ulong EFI_ACPI_5_1_TRIGGER_MODE = (3 << 2);

///
/// Non-Maskable Interrupt Source Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_NON_MASKABLE_INTERRUPT_SOURCE_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_LOCAL_APIC_NMI_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_LOCAL_APIC_ADDRESS_OVERRIDE_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_IO_SAPIC_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_PROCESSOR_LOCAL_SAPIC_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_PLATFORM_INTERRUPT_SOURCES_STRUCTURE
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
public const ulong EFI_ACPI_5_1_CPEI_PROCESSOR_OVERRIDE = BIT0;

///
/// Processor Local x2APIC Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PROCESSOR_LOCAL_X2APIC_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_LOCAL_X2APIC_NMI_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Flags;
  public uint AcpiProcessorUid;
  public byte LocalX2ApicLint;
  public fixed byte Reserved[3];
}

///
/// GIC Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Reserved;
  public uint CPUInterfaceNumber;
  public uint AcpiProcessorUid;
  public uint Flags;
  public uint ParkingProtocolVersion;
  public uint PerformanceInterruptGsiv;
  public ulong ParkedAddress;
  public ulong PhysicalBaseAddress;
  public ulong GICV;
  public ulong GICH;
  public uint VGICMaintenanceInterrupt;
  public ulong GICRBaseAddress;
  public ulong MPIDR;
}

///
/// GIC Flags.  All other bits are reserved and must be 0.
///
public const ulong EFI_ACPI_5_1_GIC_ENABLED = BIT0;
public const ulong EFI_ACPI_5_1_PERFORMANCE_INTERRUPT_MODEL = BIT1;
public const ulong EFI_ACPI_5_1_VGIC_MAINTENANCE_INTERRUPT_MODE_FLAGS = BIT2;

///
/// GIC Distributor Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GIC_DISTRIBUTOR_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Reserved1;
  public uint GicId;
  public ulong PhysicalBaseAddress;
  public uint SystemVectorBase;
  public byte GicVersion;
  public fixed byte Reserved2[3];
}

///
/// GIC Version
///
public const ulong EFI_ACPI_5_1_GIC_V1 = 0x01;
public const ulong EFI_ACPI_5_1_GIC_V2 = 0x02;
public const ulong EFI_ACPI_5_1_GIC_V3 = 0x03;
public const ulong EFI_ACPI_5_1_GIC_V4 = 0x04;

///
/// GIC MSI Frame Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GIC_MSI_FRAME_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Reserved1;
  public uint GicMsiFrameId;
  public ulong PhysicalBaseAddress;
  public uint Flags;
  public ushort SPICount;
  public ushort SPIBase;
}

///
/// GIC MSI Frame Flags.  All other bits are reserved and must be 0.
///
public const ulong EFI_ACPI_5_1_SPI_COUNT_BASE_SELECT = BIT0;

///
/// GICR Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GICR_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Reserved;
  public ulong DiscoveryRangeBaseAddress;
  public uint DiscoveryRangeLength;
}

///
/// Smart Battery Description Table (SBST)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_SMART_BATTERY_DESCRIPTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint WarningEnergyLevel;
  public uint LowEnergyLevel;
  public uint CriticalEnergyLevel;
}

///
/// SBST Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_SMART_BATTERY_DESCRIPTION_TABLE_REVISION = 0x01;

///
/// Embedded Controller Boot Resources Table (ECDT)
/// The table is followed by a null terminated ASCII string that contains
/// a fully qualified reference to the name space object.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE EcControl;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE EcData;
  public uint Uid;
  public byte GpeBit;
}

///
/// ECDT Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE_REVISION = 0x01;

///
/// System Resource Affinity Table (SRAT).  The rest of the table
/// must be defined in a platform specific manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_SYSTEM_RESOURCE_AFFINITY_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint Reserved1; ///< Must be set to 1
  public ulong Reserved2;
}

///
/// SRAT Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_SYSTEM_RESOURCE_AFFINITY_TABLE_REVISION = 0x03;

//
// SRAT structure types.
// All other values between 0x04 an 0xFF are reserved and
// will be ignored by OSPM.
//
public const ulong EFI_ACPI_5_1_PROCESSOR_LOCAL_APIC_SAPIC_AFFINITY = 0x00;
public const ulong EFI_ACPI_5_1_MEMORY_AFFINITY = 0x01;
public const ulong EFI_ACPI_5_1_PROCESSOR_LOCAL_X2APIC_AFFINITY = 0x02;
public const ulong EFI_ACPI_5_1_GICC_AFFINITY = 0x03;

///
/// Processor Local APIC/SAPIC Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PROCESSOR_LOCAL_APIC_SAPIC_AFFINITY_STRUCTURE
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
public const ulong EFI_ACPI_5_1_PROCESSOR_LOCAL_APIC_SAPIC_ENABLED = (1 << 0);

///
/// Memory Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MEMORY_AFFINITY_STRUCTURE
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
public const ulong EFI_ACPI_5_1_MEMORY_ENABLED = (1 << 0);
public const ulong EFI_ACPI_5_1_MEMORY_HOT_PLUGGABLE = (1 << 1);
public const ulong EFI_ACPI_5_1_MEMORY_NONVOLATILE = (1 << 2);

///
/// Processor Local x2APIC Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PROCESSOR_LOCAL_X2APIC_AFFINITY_STRUCTURE
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
/// GICC Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GICC_AFFINITY_STRUCTURE
{
  public byte Type;
  public byte Length;
  public uint ProximityDomain;
  public uint AcpiProcessorUid;
  public uint Flags;
  public uint ClockDomain;
}

///
/// GICC Flags.  All other bits are reserved and must be 0.
///
public const ulong EFI_ACPI_5_1_GICC_ENABLED = (1 << 0);

///
/// System Locality Distance Information Table (SLIT).
/// The rest of the table is a matrix.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_SYSTEM_LOCALITY_DISTANCE_INFORMATION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public ulong NumberOfSystemLocalities;
}

///
/// SLIT Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_SYSTEM_LOCALITY_DISTANCE_INFORMATION_TABLE_REVISION = 0x01;

///
/// Corrected Platform Error Polling Table (CPEP)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_CORRECTED_PLATFORM_ERROR_POLLING_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public fixed byte Reserved[8];
}

///
/// CPEP Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_CORRECTED_PLATFORM_ERROR_POLLING_TABLE_REVISION = 0x01;

//
// CPEP processor structure types.
//
public const ulong EFI_ACPI_5_1_CPEP_PROCESSOR_APIC_SAPIC = 0x00;

///
/// Corrected Platform Error Polling Processor Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_CPEP_PROCESSOR_APIC_SAPIC_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_MAXIMUM_SYSTEM_CHARACTERISTICS_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint OffsetProxDomInfo;
  public uint MaximumNumberOfProximityDomains;
  public uint MaximumNumberOfClockDomains;
  public ulong MaximumPhysicalAddress;
}

///
/// MSCT Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_MAXIMUM_SYSTEM_CHARACTERISTICS_TABLE_REVISION = 0x01;

///
/// Maximum Proximity Domain Information Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MAXIMUM_PROXIMITY_DOMAIN_INFORMATION_STRUCTURE
{
  public byte Revision;
  public byte Length;
  public uint ProximityDomainRangeLow;
  public uint ProximityDomainRangeHigh;
  public uint MaximumProcessorCapacity;
  public ulong MaximumMemoryCapacity;
}

///
/// ACPI RAS Feature Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_RAS_FEATURE_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public fixed byte PlatformCommunicationChannelIdentifier[12];
}

///
/// RASF Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_RAS_FEATURE_TABLE_REVISION = 0x01;

///
/// ACPI RASF Platform Communication Channel Shared Memory Region definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_RASF_PLATFORM_COMMUNICATION_CHANNEL_SHARED_MEMORY_REGION
{
  public uint Signature;
  public ushort Command;
  public ushort Status;
  public ushort Version;
  public fixed byte RASCapabilities[16];
  public fixed byte SetRASCapabilities[16];
  public ushort NumberOfRASFParameterBlocks;
  public uint SetRASCapabilitiesStatus;
}

///
/// ACPI RASF PCC command code
///
public const ulong EFI_ACPI_5_1_RASF_PCC_COMMAND_CODE_EXECUTE_RASF_COMMAND = 0x01;

///
/// ACPI RASF Platform RAS Capabilities
///
public const ulong EFI_ACPI_5_1_RASF_PLATFORM_RAS_CAPABILITY_HARDWARE_BASED_PATROL_SCRUB_SUPPOTED = 0x01;
public const ulong EFI_ACPI_5_1_RASF_PLATFORM_RAS_CAPABILITY_HARDWARE_BASED_PATROL_SCRUB_SUPPOTED_AND_EXPOSED_TO_SOFTWARE = 0x02;

///
/// ACPI RASF Parameter Block structure for PATROL_SCRUB
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_RASF_PATROL_SCRUB_PLATFORM_BLOCK_STRUCTURE
{
  public ushort Type;
  public ushort Version;
  public ushort Length;
  public ushort PatrolScrubCommand;
  public fixed ulong RequestedAddressRange[2];
  public fixed ulong ActualAddressRange[2];
  public ushort Flags;
  public byte RequestedSpeed;
}

///
/// ACPI RASF Patrol Scrub command
///
public const ulong EFI_ACPI_5_1_RASF_PATROL_SCRUB_COMMAND_GET_PATROL_PARAMETERS = 0x01;
public const ulong EFI_ACPI_5_1_RASF_PATROL_SCRUB_COMMAND_START_PATROL_SCRUBBER = 0x02;
public const ulong EFI_ACPI_5_1_RASF_PATROL_SCRUB_COMMAND_STOP_PATROL_SCRUBBER = 0x03;

///
/// Memory Power State Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MEMORY_POWER_STATUS_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public byte PlatformCommunicationChannelIdentifier;
  public fixed byte Reserved[3];
  // Memory Power Node Structure
  // Memory Power State Characteristics
}

///
/// MPST Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_MEMORY_POWER_STATE_TABLE_REVISION = 0x01;

///
/// MPST Platform Communication Channel Shared Memory Region definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MPST_PLATFORM_COMMUNICATION_CHANNEL_SHARED_MEMORY_REGION
{
  public uint Signature;
  public ushort Command;
  public ushort Status;
  public uint MemoryPowerCommandRegister;
  public uint MemoryPowerStatusRegister;
  public uint PowerStateId;
  public uint MemoryPowerNodeId;
  public ulong MemoryEnergyConsumed;
  public ulong ExpectedAveragePowerComsuned;
}

///
/// ACPI MPST PCC command code
///
public const ulong EFI_ACPI_5_1_MPST_PCC_COMMAND_CODE_EXECUTE_MPST_COMMAND = 0x03;

///
/// ACPI MPST Memory Power command
///
public const ulong EFI_ACPI_5_1_MPST_MEMORY_POWER_COMMAND_GET_MEMORY_POWER_STATE = 0x01;
public const ulong EFI_ACPI_5_1_MPST_MEMORY_POWER_COMMAND_SET_MEMORY_POWER_STATE = 0x02;
public const ulong EFI_ACPI_5_1_MPST_MEMORY_POWER_COMMAND_GET_AVERAGE_POWER_CONSUMED = 0x03;
public const ulong EFI_ACPI_5_1_MPST_MEMORY_POWER_COMMAND_GET_MEMORY_ENERGY_CONSUMED = 0x04;

///
/// MPST Memory Power Node Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MPST_MEMORY_POWER_STATE
{
  public byte PowerStateValue;
  public byte PowerStateInformationIndex;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MPST_MEMORY_POWER_STRUCTURE
{
  public byte Flag;
  public byte Reserved;
  public ushort MemoryPowerNodeId;
  public uint Length;
  public ulong AddressBase;
  public ulong AddressLength;
  public uint NumberOfPowerStates;
  public uint NumberOfPhysicalComponents;
  // EFI_ACPI_5_1_MPST_MEMORY_POWER_STATE              MemoryPowerState[NumberOfPowerStates];
  // ushort                                            PhysicalComponentIdentifier[NumberOfPhysicalComponents];
}

public const ulong EFI_ACPI_5_1_MPST_MEMORY_POWER_STRUCTURE_FLAG_ENABLE = 0x01;
public const ulong EFI_ACPI_5_1_MPST_MEMORY_POWER_STRUCTURE_FLAG_POWER_MANAGED = 0x02;
public const ulong EFI_ACPI_5_1_MPST_MEMORY_POWER_STRUCTURE_FLAG_HOT_PLUGGABLE = 0x04;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MPST_MEMORY_POWER_NODE_TABLE
{
  public ushort MemoryPowerNodeCount;
  public fixed byte Reserved[2];
}

///
/// MPST Memory Power State Characteristics Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MPST_MEMORY_POWER_STATE_CHARACTERISTICS_STRUCTURE
{
  public byte PowerStateStructureID;
  public byte Flag;
  public ushort Reserved;
  public uint AveragePowerConsumedInMPS0;
  public uint RelativePowerSavingToMPS0;
  public ulong ExitLatencyToMPS0;
}

public const ulong EFI_ACPI_5_1_MPST_MEMORY_POWER_STATE_CHARACTERISTICS_STRUCTURE_FLAG_MEMORY_CONTENT_PRESERVED = 0x01;
public const ulong EFI_ACPI_5_1_MPST_MEMORY_POWER_STATE_CHARACTERISTICS_STRUCTURE_FLAG_AUTONOMOUS_MEMORY_POWER_STATE_ENTRY = 0x02;
public const ulong EFI_ACPI_5_1_MPST_MEMORY_POWER_STATE_CHARACTERISTICS_STRUCTURE_FLAG_AUTONOMOUS_MEMORY_POWER_STATE_EXIT = 0x04;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MPST_MEMORY_POWER_STATE_CHARACTERISTICS_TABLE
{
  public ushort MemoryPowerStateCharacteristicsCount;
  public fixed byte Reserved[2];
}

///
/// Memory Topology Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_MEMORY_TOPOLOGY_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint Reserved;
}

///
/// PMTT Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_MEMORY_TOPOLOGY_TABLE_REVISION = 0x01;

///
/// Common Memory Aggregator Device Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PMMT_COMMON_MEMORY_AGGREGATOR_DEVICE_STRUCTURE
{
  public byte Type;
  public byte Reserved;
  public ushort Length;
  public ushort Flags;
  public ushort Reserved1;
}

///
/// Memory Aggregator Device Type
///
public const ulong EFI_ACPI_5_1_PMMT_MEMORY_AGGREGATOR_DEVICE_TYPE_SOCKET = 0x0;
public const ulong EFI_ACPI_5_1_PMMT_MEMORY_AGGREGATOR_DEVICE_TYPE_MEMORY_CONTROLLER = 0x1;
public const ulong EFI_ACPI_5_1_PMMT_MEMORY_AGGREGATOR_DEVICE_TYPE_DIMM = 0x2;

///
/// Socket Memory Aggregator Device Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PMMT_SOCKET_MEMORY_AGGREGATOR_DEVICE_STRUCTURE
{
  public EFI_ACPI_5_1_PMMT_COMMON_MEMORY_AGGREGATOR_DEVICE_STRUCTURE Header;
  public ushort SocketIdentifier;
  public ushort Reserved;
  // EFI_ACPI_5_1_PMMT_MEMORY_CONTROLLER_MEMORY_AGGREGATOR_DEVICE_STRUCTURE  MemoryController[];
}

///
/// MemoryController Memory Aggregator Device Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PMMT_MEMORY_CONTROLLER_MEMORY_AGGREGATOR_DEVICE_STRUCTURE
{
  public EFI_ACPI_5_1_PMMT_COMMON_MEMORY_AGGREGATOR_DEVICE_STRUCTURE Header;
  public uint ReadLatency;
  public uint WriteLatency;
  public uint ReadBandwidth;
  public uint WriteBandwidth;
  public ushort OptimalAccessUnit;
  public ushort OptimalAccessAlignment;
  public ushort Reserved;
  public ushort NumberOfProximityDomains;
  // uint                                                       ProximityDomain[NumberOfProximityDomains];
  // EFI_ACPI_5_1_PMMT_DIMM_MEMORY_AGGREGATOR_DEVICE_STRUCTURE    PhysicalComponent[];
}

///
/// DIMM Memory Aggregator Device Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PMMT_DIMM_MEMORY_AGGREGATOR_DEVICE_STRUCTURE
{
  public EFI_ACPI_5_1_PMMT_COMMON_MEMORY_AGGREGATOR_DEVICE_STRUCTURE Header;
  public ushort PhysicalComponentIdentifier;
  public ushort Reserved;
  public uint SizeOfDimm;
  public uint SmbiosHandle;
}

///
/// Boot Graphics Resource Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_BOOT_GRAPHICS_RESOURCE_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  ///
  /// 2-bytes (16 bit) version ID. This value must be 1.
  ///
  public ushort Version;
  ///
  /// 1-byte status field indicating current status about the table.
  ///     Bits[7:1] = Reserved (must be zero)
  ///     Bit [0] = Valid. A one indicates the boot image graphic is valid.
  ///
  public byte Status;
  ///
  /// 1-byte enumerated type field indicating format of the image.
  ///     0 = Bitmap
  ///     1 - 255  Reserved (for future use)
  ///
  public byte ImageType;
  ///
  /// 8-byte (64 bit) physical address pointing to the firmware's in-memory copy
  /// of the image bitmap.
  ///
  public ulong ImageAddress;
  ///
  /// A 4-byte (32-bit) unsigned long describing the display X-offset of the boot image.
  /// (X, Y) display offset of the top left corner of the boot image.
  /// The top left corner of the display is at offset (0, 0).
  ///
  public uint ImageOffsetX;
  ///
  /// A 4-byte (32-bit) unsigned long describing the display Y-offset of the boot image.
  /// (X, Y) display offset of the top left corner of the boot image.
  /// The top left corner of the display is at offset (0, 0).
  ///
  public uint ImageOffsetY;
}

///
/// BGRT Revision
///
public const ulong EFI_ACPI_5_1_BOOT_GRAPHICS_RESOURCE_TABLE_REVISION = 1;

///
/// BGRT Version
///
public const ulong EFI_ACPI_5_1_BGRT_VERSION = 0x01;

///
/// BGRT Status
///
public const ulong EFI_ACPI_5_1_BGRT_STATUS_NOT_DISPLAYED = 0x00;
public const ulong EFI_ACPI_5_1_BGRT_STATUS_DISPLAYED = 0x01;

///
/// BGRT Image Type
///
public const ulong EFI_ACPI_5_1_BGRT_IMAGE_TYPE_BMP = 0x00;

///
/// FPDT Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_FIRMWARE_PERFORMANCE_DATA_TABLE_REVISION = 0x01;

///
/// FPDT Performance Record Types
///
public const ulong EFI_ACPI_5_1_FPDT_RECORD_TYPE_FIRMWARE_BASIC_BOOT_POINTER = 0x0000;
public const ulong EFI_ACPI_5_1_FPDT_RECORD_TYPE_S3_PERFORMANCE_TABLE_POINTER = 0x0001;

///
/// FPDT Performance Record Revision
///
public const ulong EFI_ACPI_5_1_FPDT_RECORD_REVISION_FIRMWARE_BASIC_BOOT_POINTER = 0x01;
public const ulong EFI_ACPI_5_1_FPDT_RECORD_REVISION_S3_PERFORMANCE_TABLE_POINTER = 0x01;

///
/// FPDT Runtime Performance Record Types
///
public const ulong EFI_ACPI_5_1_FPDT_RUNTIME_RECORD_TYPE_S3_RESUME = 0x0000;
public const ulong EFI_ACPI_5_1_FPDT_RUNTIME_RECORD_TYPE_S3_SUSPEND = 0x0001;
public const ulong EFI_ACPI_5_1_FPDT_RUNTIME_RECORD_TYPE_FIRMWARE_BASIC_BOOT = 0x0002;

///
/// FPDT Runtime Performance Record Revision
///
public const ulong EFI_ACPI_5_1_FPDT_RUNTIME_RECORD_REVISION_S3_RESUME = 0x01;
public const ulong EFI_ACPI_5_1_FPDT_RUNTIME_RECORD_REVISION_S3_SUSPEND = 0x01;
public const ulong EFI_ACPI_5_1_FPDT_RUNTIME_RECORD_REVISION_FIRMWARE_BASIC_BOOT = 0x02;

///
/// FPDT Performance Record header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FPDT_PERFORMANCE_RECORD_HEADER
{
  public ushort Type;
  public byte Length;
  public byte Revision;
}

///
/// FPDT Performance Table header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FPDT_PERFORMANCE_TABLE_HEADER
{
  public uint Signature;
  public uint Length;
}

///
/// FPDT Firmware Basic Boot Performance Pointer Record Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FPDT_BOOT_PERFORMANCE_TABLE_POINTER_RECORD
{
  public EFI_ACPI_5_1_FPDT_PERFORMANCE_RECORD_HEADER Header;
  public uint Reserved;
  ///
  /// 64-bit processor-relative physical address of the Basic Boot Performance Table.
  ///
  public ulong BootPerformanceTablePointer;
}

///
/// FPDT S3 Performance Table Pointer Record Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FPDT_S3_PERFORMANCE_TABLE_POINTER_RECORD
{
  public EFI_ACPI_5_1_FPDT_PERFORMANCE_RECORD_HEADER Header;
  public uint Reserved;
  ///
  /// 64-bit processor-relative physical address of the S3 Performance Table.
  ///
  public ulong S3PerformanceTablePointer;
}

///
/// FPDT Firmware Basic Boot Performance Record Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FPDT_FIRMWARE_BASIC_BOOT_RECORD
{
  public EFI_ACPI_5_1_FPDT_PERFORMANCE_RECORD_HEADER Header;
  public uint Reserved;
  ///
  /// Timer value logged at the beginning of firmware image execution.
  /// This may not always be zero or near zero.
  ///
  public ulong ResetEnd;
  ///
  /// Timer value logged just prior to loading the OS boot loader into memory.
  /// For non-UEFI compatible boots, this field must be zero.
  ///
  public ulong OsLoaderLoadImageStart;
  ///
  /// Timer value logged just prior to launching the previously loaded OS boot loader image.
  /// For non-UEFI compatible boots, the timer value logged will be just prior
  /// to the INT 19h handler invocation.
  ///
  public ulong OsLoaderStartImageStart;
  ///
  /// Timer value logged at the point when the OS loader calls the
  /// ExitBootServices function for UEFI compatible firmware.
  /// For non-UEFI compatible boots, this field must be zero.
  ///
  public ulong ExitBootServicesEntry;
  ///
  /// Timer value logged at the point just prior to when the OS loader gaining
  /// control back from calls the ExitBootServices function for UEFI compatible firmware.
  /// For non-UEFI compatible boots, this field must be zero.
  ///
  public ulong ExitBootServicesExit;
}

///
/// FPDT Firmware Basic Boot Performance Table signature
///
public const ulong EFI_ACPI_5_1_FPDT_BOOT_PERFORMANCE_TABLE_SIGNATURE = SIGNATURE_32('F', 'B', 'P', 'T');

//
// FPDT Firmware Basic Boot Performance Table
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FPDT_FIRMWARE_BASIC_BOOT_TABLE
{
  public EFI_ACPI_5_1_FPDT_PERFORMANCE_TABLE_HEADER Header;
  //
  // one or more Performance Records.
  //
}

///
/// FPDT "S3PT" S3 Performance Table
///
public const ulong EFI_ACPI_5_1_FPDT_S3_PERFORMANCE_TABLE_SIGNATURE = SIGNATURE_32('S', '3', 'P', 'T');

//
// FPDT Firmware S3 Boot Performance Table
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FPDT_FIRMWARE_S3_BOOT_TABLE
{
  public EFI_ACPI_5_1_FPDT_PERFORMANCE_TABLE_HEADER Header;
  //
  // one or more Performance Records.
  //
}

///
/// FPDT Basic S3 Resume Performance Record
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FPDT_S3_RESUME_RECORD
{
  public EFI_ACPI_5_1_FPDT_PERFORMANCE_RECORD_HEADER Header;
  ///
  /// A count of the number of S3 resume cycles since the last full boot sequence.
  ///
  public uint ResumeCount;
  ///
  /// Timer recorded at the end of BIOS S3 resume, just prior to handoff to the
  /// OS waking vector. Only the most recent resume cycle's time is retained.
  ///
  public ulong FullResume;
  ///
  /// Average timer value of all resume cycles logged since the last full boot
  /// sequence, including the most recent resume.  Note that the entire log of
  /// timer values does not need to be retained in order to calculate this average.
  ///
  public ulong AverageResume;
}

///
/// FPDT Basic S3 Suspend Performance Record
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FPDT_S3_SUSPEND_RECORD
{
  public EFI_ACPI_5_1_FPDT_PERFORMANCE_RECORD_HEADER Header;
  ///
  /// Timer value recorded at the OS write to SLP_TYP upon entry to S3.
  /// Only the most recent suspend cycle's timer value is retained.
  ///
  public ulong SuspendStart;
  ///
  /// Timer value recorded at the final firmware write to SLP_TYP (or other
  /// mechanism) used to trigger hardware entry to S3.
  /// Only the most recent suspend cycle's timer value is retained.
  ///
  public ulong SuspendEnd;
}

///
/// Firmware Performance Record Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_FIRMWARE_PERFORMANCE_RECORD_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
}

///
/// Generic Timer Description Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GENERIC_TIMER_DESCRIPTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public ulong CntControlBasePhysicalAddress;
  public uint Reserved;
  public uint SecurePL1TimerGSIV;
  public uint SecurePL1TimerFlags;
  public uint NonSecurePL1TimerGSIV;
  public uint NonSecurePL1TimerFlags;
  public uint VirtualTimerGSIV;
  public uint VirtualTimerFlags;
  public uint NonSecurePL2TimerGSIV;
  public uint NonSecurePL2TimerFlags;
  public ulong CntReadBasePhysicalAddress;
  public uint PlatformTimerCount;
  public uint PlatformTimerOffset;
}

///
/// GTDT Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_GENERIC_TIMER_DESCRIPTION_TABLE_REVISION = 0x02;

///
/// Timer Flags.  All other bits are reserved and must be 0.
///
public const ulong EFI_ACPI_5_1_GTDT_TIMER_FLAG_TIMER_INTERRUPT_MODE = BIT0;
public const ulong EFI_ACPI_5_1_GTDT_TIMER_FLAG_TIMER_INTERRUPT_POLARITY = BIT1;
public const ulong EFI_ACPI_5_1_GTDT_TIMER_FLAG_ALWAYS_ON_CAPABILITY = BIT2;

///
/// Platform Timer Type
///
public const ulong EFI_ACPI_5_1_GTDT_GT_BLOCK = 0;
public const ulong EFI_ACPI_5_1_GTDT_SBSA_GENERIC_WATCHDOG = 1;

///
/// GT Block Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GTDT_GT_BLOCK_STRUCTURE
{
  public byte Type;
  public ushort Length;
  public byte Reserved;
  public ulong CntCtlBase;
  public uint GTBlockTimerCount;
  public uint GTBlockTimerOffset;
}

///
/// GT Block Timer Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GTDT_GT_BLOCK_TIMER_STRUCTURE
{
  public byte GTFrameNumber;
  public fixed byte Reserved[3];
  public ulong CntBaseX;
  public ulong CntEL0BaseX;
  public uint GTxPhysicalTimerGSIV;
  public uint GTxPhysicalTimerFlags;
  public uint GTxVirtualTimerGSIV;
  public uint GTxVirtualTimerFlags;
  public uint GTxCommonFlags;
}

///
/// GT Block Physical Timers and Virtual Timers Flags.  All other bits are reserved and must be 0.
///
public const ulong EFI_ACPI_5_1_GTDT_GT_BLOCK_TIMER_FLAG_TIMER_INTERRUPT_MODE = BIT0;
public const ulong EFI_ACPI_5_1_GTDT_GT_BLOCK_TIMER_FLAG_TIMER_INTERRUPT_POLARITY = BIT1;

///
/// Common Flags Flags.  All other bits are reserved and must be 0.
///
public const ulong EFI_ACPI_5_1_GTDT_GT_BLOCK_COMMON_FLAG_SECURE_TIMER = BIT0;
public const ulong EFI_ACPI_5_1_GTDT_GT_BLOCK_COMMON_FLAG_ALWAYS_ON_CAPABILITY = BIT1;

///
/// SBSA Generic Watchdog Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GTDT_SBSA_GENERIC_WATCHDOG_STRUCTURE
{
  public byte Type;
  public ushort Length;
  public byte Reserved;
  public ulong RefreshFramePhysicalAddress;
  public ulong WatchdogControlFramePhysicalAddress;
  public uint WatchdogTimerGSIV;
  public uint WatchdogTimerFlags;
}

///
/// SBSA Generic Watchdog Timer Flags.  All other bits are reserved and must be 0.
///
public const ulong EFI_ACPI_5_1_GTDT_SBSA_GENERIC_WATCHDOG_FLAG_TIMER_INTERRUPT_MODE = BIT0;
public const ulong EFI_ACPI_5_1_GTDT_SBSA_GENERIC_WATCHDOG_FLAG_TIMER_INTERRUPT_POLARITY = BIT1;
public const ulong EFI_ACPI_5_1_GTDT_SBSA_GENERIC_WATCHDOG_FLAG_SECURE_TIMER = BIT2;

///
/// Boot Error Record Table (BERT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_BOOT_ERROR_RECORD_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint BootErrorRegionLength;
  public ulong BootErrorRegion;
}

///
/// BERT Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_BOOT_ERROR_RECORD_TABLE_REVISION = 0x01;

///
/// Boot Error Region Block Status Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_ERROR_BLOCK_STATUS
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
public unsafe struct EFI_ACPI_5_1_BOOT_ERROR_REGION_STRUCTURE
{
  public EFI_ACPI_5_1_ERROR_BLOCK_STATUS BlockStatus;
  public uint RawDataOffset;
  public uint RawDataLength;
  public uint DataLength;
  public uint ErrorSeverity;
}

//
// Boot Error Severity types
//
public const ulong EFI_ACPI_5_1_ERROR_SEVERITY_RECOVERABLE = 0x00;
public const ulong EFI_ACPI_5_1_ERROR_SEVERITY_FATAL = 0x01;
public const ulong EFI_ACPI_5_1_ERROR_SEVERITY_CORRECTED = 0x02;
public const ulong EFI_ACPI_5_1_ERROR_SEVERITY_NONE = 0x03;
//
// The term 'Correctable' is no longer being used as an error severity of the
// reported error since ACPI Specification Version 5.1 Errata B.
// The below macro is considered as deprecated and should no longer be used.
//
public const ulong EFI_ACPI_5_1_ERROR_SEVERITY_CORRECTABLE = 0x00;

///
/// Generic Error Data Entry Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GENERIC_ERROR_DATA_ENTRY_STRUCTURE
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
/// Generic Error Data Entry Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_GENERIC_ERROR_DATA_ENTRY_REVISION = 0x0201;

///
/// HEST - Hardware Error Source Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_HARDWARE_ERROR_SOURCE_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint ErrorSourceCount;
}

///
/// HEST Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_HARDWARE_ERROR_SOURCE_TABLE_REVISION = 0x01;

//
// Error Source structure types.
//
public const ulong EFI_ACPI_5_1_IA32_ARCHITECTURE_MACHINE_CHECK_EXCEPTION = 0x00;
public const ulong EFI_ACPI_5_1_IA32_ARCHITECTURE_CORRECTED_MACHINE_CHECK = 0x01;
public const ulong EFI_ACPI_5_1_IA32_ARCHITECTURE_NMI_ERROR = 0x02;
public const ulong EFI_ACPI_5_1_PCI_EXPRESS_ROOT_PORT_AER = 0x06;
public const ulong EFI_ACPI_5_1_PCI_EXPRESS_DEVICE_AER = 0x07;
public const ulong EFI_ACPI_5_1_PCI_EXPRESS_BRIDGE_AER = 0x08;
public const ulong EFI_ACPI_5_1_GENERIC_HARDWARE_ERROR = 0x09;

//
// Error Source structure flags.
//
public const ulong EFI_ACPI_5_1_ERROR_SOURCE_FLAG_FIRMWARE_FIRST = (1 << 0);
public const ulong EFI_ACPI_5_1_ERROR_SOURCE_FLAG_GLOBAL = (1 << 1);

///
/// IA-32 Architecture Machine Check Exception Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_IA32_ARCHITECTURE_MACHINE_CHECK_EXCEPTION_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_BANK_STRUCTURE
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
public const ulong EFI_ACPI_5_1_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_DATA_FORMAT_IA32 = 0x00;
public const ulong EFI_ACPI_5_1_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_DATA_FORMAT_INTEL64 = 0x01;
public const ulong EFI_ACPI_5_1_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_DATA_FORMAT_AMD64 = 0x02;

//
// Hardware Error Notification types. All other values are reserved
//
public const ulong EFI_ACPI_5_1_HARDWARE_ERROR_NOTIFICATION_POLLED = 0x00;
public const ulong EFI_ACPI_5_1_HARDWARE_ERROR_NOTIFICATION_EXTERNAL_INTERRUPT = 0x01;
public const ulong EFI_ACPI_5_1_HARDWARE_ERROR_NOTIFICATION_LOCAL_INTERRUPT = 0x02;
public const ulong EFI_ACPI_5_1_HARDWARE_ERROR_NOTIFICATION_SCI = 0x03;
public const ulong EFI_ACPI_5_1_HARDWARE_ERROR_NOTIFICATION_NMI = 0x04;

///
/// Hardware Error Notification Configuration Write Enable Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_HARDWARE_ERROR_NOTIFICATION_CONFIGURATION_WRITE_ENABLE_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_HARDWARE_ERROR_NOTIFICATION_STRUCTURE
{
  public byte Type;
  public byte Length;
  public EFI_ACPI_5_1_HARDWARE_ERROR_NOTIFICATION_CONFIGURATION_WRITE_ENABLE_STRUCTURE ConfigurationWriteEnable;
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
public unsafe struct EFI_ACPI_5_1_IA32_ARCHITECTURE_CORRECTED_MACHINE_CHECK_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public fixed byte Reserved0[2];
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public EFI_ACPI_5_1_HARDWARE_ERROR_NOTIFICATION_STRUCTURE NotificationStructure;
  public byte NumberOfHardwareBanks;
  public fixed byte Reserved1[3];
}

///
/// IA-32 Architecture NMI Error Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_IA32_ARCHITECTURE_NMI_ERROR_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_PCI_EXPRESS_ROOT_PORT_AER_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_PCI_EXPRESS_DEVICE_AER_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_PCI_EXPRESS_BRIDGE_AER_STRUCTURE
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
public unsafe struct EFI_ACPI_5_1_GENERIC_HARDWARE_ERROR_SOURCE_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public ushort RelatedSourceId;
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public uint MaxRawDataLength;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE ErrorStatusAddress;
  public EFI_ACPI_5_1_HARDWARE_ERROR_NOTIFICATION_STRUCTURE NotificationStructure;
  public uint ErrorStatusBlockLength;
}

///
/// Generic Error Status Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_GENERIC_ERROR_STATUS_STRUCTURE
{
  public EFI_ACPI_5_1_ERROR_BLOCK_STATUS BlockStatus;
  public uint RawDataOffset;
  public uint RawDataLength;
  public uint DataLength;
  public uint ErrorSeverity;
}

///
/// ERST - Error Record Serialization Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_ERROR_RECORD_SERIALIZATION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint SerializationHeaderSize;
  public fixed byte Reserved0[4];
  public uint InstructionEntryCount;
}

///
/// ERST Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_ERROR_RECORD_SERIALIZATION_TABLE_REVISION = 0x01;

///
/// ERST Serialization Actions
///
public const ulong EFI_ACPI_5_1_ERST_BEGIN_WRITE_OPERATION = 0x00;
public const ulong EFI_ACPI_5_1_ERST_BEGIN_READ_OPERATION = 0x01;
public const ulong EFI_ACPI_5_1_ERST_BEGIN_CLEAR_OPERATION = 0x02;
public const ulong EFI_ACPI_5_1_ERST_END_OPERATION = 0x03;
public const ulong EFI_ACPI_5_1_ERST_SET_RECORD_OFFSET = 0x04;
public const ulong EFI_ACPI_5_1_ERST_EXECUTE_OPERATION = 0x05;
public const ulong EFI_ACPI_5_1_ERST_CHECK_BUSY_STATUS = 0x06;
public const ulong EFI_ACPI_5_1_ERST_GET_COMMAND_STATUS = 0x07;
public const ulong EFI_ACPI_5_1_ERST_GET_RECORD_IDENTIFIER = 0x08;
public const ulong EFI_ACPI_5_1_ERST_SET_RECORD_IDENTIFIER = 0x09;
public const ulong EFI_ACPI_5_1_ERST_GET_RECORD_COUNT = 0x0A;
public const ulong EFI_ACPI_5_1_ERST_BEGIN_DUMMY_WRITE_OPERATION = 0x0B;
public const ulong EFI_ACPI_5_1_ERST_GET_ERROR_LOG_ADDRESS_RANGE = 0x0D;
public const ulong EFI_ACPI_5_1_ERST_GET_ERROR_LOG_ADDRESS_RANGE_LENGTH = 0x0E;
public const ulong EFI_ACPI_5_1_ERST_GET_ERROR_LOG_ADDRESS_RANGE_ATTRIBUTES = 0x0F;

///
/// ERST Action Command Status
///
public const ulong EFI_ACPI_5_1_ERST_STATUS_SUCCESS = 0x00;
public const ulong EFI_ACPI_5_1_ERST_STATUS_NOT_ENOUGH_SPACE = 0x01;
public const ulong EFI_ACPI_5_1_ERST_STATUS_HARDWARE_NOT_AVAILABLE = 0x02;
public const ulong EFI_ACPI_5_1_ERST_STATUS_FAILED = 0x03;
public const ulong EFI_ACPI_5_1_ERST_STATUS_RECORD_STORE_EMPTY = 0x04;
public const ulong EFI_ACPI_5_1_ERST_STATUS_RECORD_NOT_FOUND = 0x05;

///
/// ERST Serialization Instructions
///
public const ulong EFI_ACPI_5_1_ERST_READ_REGISTER = 0x00;
public const ulong EFI_ACPI_5_1_ERST_READ_REGISTER_VALUE = 0x01;
public const ulong EFI_ACPI_5_1_ERST_WRITE_REGISTER = 0x02;
public const ulong EFI_ACPI_5_1_ERST_WRITE_REGISTER_VALUE = 0x03;
public const ulong EFI_ACPI_5_1_ERST_NOOP = 0x04;
public const ulong EFI_ACPI_5_1_ERST_LOAD_VAR1 = 0x05;
public const ulong EFI_ACPI_5_1_ERST_LOAD_VAR2 = 0x06;
public const ulong EFI_ACPI_5_1_ERST_STORE_VAR1 = 0x07;
public const ulong EFI_ACPI_5_1_ERST_ADD = 0x08;
public const ulong EFI_ACPI_5_1_ERST_SUBTRACT = 0x09;
public const ulong EFI_ACPI_5_1_ERST_ADD_VALUE = 0x0A;
public const ulong EFI_ACPI_5_1_ERST_SUBTRACT_VALUE = 0x0B;
public const ulong EFI_ACPI_5_1_ERST_STALL = 0x0C;
public const ulong EFI_ACPI_5_1_ERST_STALL_WHILE_TRUE = 0x0D;
public const ulong EFI_ACPI_5_1_ERST_SKIP_NEXT_INSTRUCTION_IF_TRUE = 0x0E;
public const ulong EFI_ACPI_5_1_ERST_GOTO = 0x0F;
public const ulong EFI_ACPI_5_1_ERST_SET_SRC_ADDRESS_BASE = 0x10;
public const ulong EFI_ACPI_5_1_ERST_SET_DST_ADDRESS_BASE = 0x11;
public const ulong EFI_ACPI_5_1_ERST_MOVE_DATA = 0x12;

///
/// ERST Instruction Flags
///
public const ulong EFI_ACPI_5_1_ERST_PRESERVE_REGISTER = 0x01;

///
/// ERST Serialization Instruction Entry
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_ERST_SERIALIZATION_INSTRUCTION_ENTRY
{
  public byte SerializationAction;
  public byte Instruction;
  public byte Flags;
  public byte Reserved0;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE RegisterRegion;
  public ulong Value;
  public ulong Mask;
}

///
/// EINJ - Error Injection Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_ERROR_INJECTION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint InjectionHeaderSize;
  public byte InjectionFlags;
  public fixed byte Reserved0[3];
  public uint InjectionEntryCount;
}

///
/// EINJ Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_ERROR_INJECTION_TABLE_REVISION = 0x01;

///
/// EINJ Error Injection Actions
///
public const ulong EFI_ACPI_5_1_EINJ_BEGIN_INJECTION_OPERATION = 0x00;
public const ulong EFI_ACPI_5_1_EINJ_GET_TRIGGER_ERROR_ACTION_TABLE = 0x01;
public const ulong EFI_ACPI_5_1_EINJ_SET_ERROR_TYPE = 0x02;
public const ulong EFI_ACPI_5_1_EINJ_GET_ERROR_TYPE = 0x03;
public const ulong EFI_ACPI_5_1_EINJ_END_OPERATION = 0x04;
public const ulong EFI_ACPI_5_1_EINJ_EXECUTE_OPERATION = 0x05;
public const ulong EFI_ACPI_5_1_EINJ_CHECK_BUSY_STATUS = 0x06;
public const ulong EFI_ACPI_5_1_EINJ_GET_COMMAND_STATUS = 0x07;
public const ulong EFI_ACPI_5_1_EINJ_TRIGGER_ERROR = 0xFF;

///
/// EINJ Action Command Status
///
public const ulong EFI_ACPI_5_1_EINJ_STATUS_SUCCESS = 0x00;
public const ulong EFI_ACPI_5_1_EINJ_STATUS_UNKNOWN_FAILURE = 0x01;
public const ulong EFI_ACPI_5_1_EINJ_STATUS_INVALID_ACCESS = 0x02;

///
/// EINJ Error Type Definition
///
public const ulong EFI_ACPI_5_1_EINJ_ERROR_PROCESSOR_CORRECTABLE = (1 << 0);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_PROCESSOR_UNCORRECTABLE_NONFATAL = (1 << 1);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_PROCESSOR_UNCORRECTABLE_FATAL = (1 << 2);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_MEMORY_CORRECTABLE = (1 << 3);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_MEMORY_UNCORRECTABLE_NONFATAL = (1 << 4);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_MEMORY_UNCORRECTABLE_FATAL = (1 << 5);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_PCI_EXPRESS_CORRECTABLE = (1 << 6);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_PCI_EXPRESS_UNCORRECTABLE_NONFATAL = (1 << 7);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_PCI_EXPRESS_UNCORRECTABLE_FATAL = (1 << 8);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_PLATFORM_CORRECTABLE = (1 << 9);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_PLATFORM_UNCORRECTABLE_NONFATAL = (1 << 10);
public const ulong EFI_ACPI_5_1_EINJ_ERROR_PLATFORM_UNCORRECTABLE_FATAL = (1 << 11);

///
/// EINJ Injection Instructions
///
public const ulong EFI_ACPI_5_1_EINJ_READ_REGISTER = 0x00;
public const ulong EFI_ACPI_5_1_EINJ_READ_REGISTER_VALUE = 0x01;
public const ulong EFI_ACPI_5_1_EINJ_WRITE_REGISTER = 0x02;
public const ulong EFI_ACPI_5_1_EINJ_WRITE_REGISTER_VALUE = 0x03;
public const ulong EFI_ACPI_5_1_EINJ_NOOP = 0x04;

///
/// EINJ Instruction Flags
///
public const ulong EFI_ACPI_5_1_EINJ_PRESERVE_REGISTER = 0x01;

///
/// EINJ Injection Instruction Entry
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_EINJ_INJECTION_INSTRUCTION_ENTRY
{
  public byte InjectionAction;
  public byte Instruction;
  public byte Flags;
  public byte Reserved0;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE RegisterRegion;
  public ulong Value;
  public ulong Mask;
}

///
/// EINJ Trigger Action Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_EINJ_TRIGGER_ACTION_TABLE
{
  public uint HeaderSize;
  public uint Revision;
  public uint TableSize;
  public uint EntryCount;
}

///
/// Platform Communications Channel Table (PCCT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PLATFORM_COMMUNICATION_CHANNEL_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint Flags;
  public ulong Reserved;
}

///
/// PCCT Version (as defined in ACPI 5.1 spec.)
///
public const ulong EFI_ACPI_5_1_PLATFORM_COMMUNICATION_CHANNEL_TABLE_REVISION = 0x01;

///
/// PCCT Global Flags
///
public const ulong EFI_ACPI_5_1_PCCT_FLAGS_SCI_DOORBELL = BIT0;

//
// PCCT Subspace type
//
public const ulong EFI_ACPI_5_1_PCCT_SUBSPACE_TYPE_GENERIC = 0x00;

///
/// PCC Subspace Structure Header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PCCT_SUBSPACE_HEADER
{
  public byte Type;
  public byte Length;
}

///
/// Generic Communications Subspace Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PCCT_SUBSPACE_GENERIC
{
  public byte Type;
  public byte Length;
  public fixed byte Reserved[6];
  public ulong BaseAddress;
  public ulong AddressLength;
  public EFI_ACPI_5_1_GENERIC_ADDRESS_STRUCTURE DoorbellRegister;
  public ulong DoorbellPreserve;
  public ulong DoorbellWrite;
  public uint NominalLatency;
  public uint MaximumPeriodicAccessRate;
  public ushort MinimumRequestTurnaroundTime;
}

///
/// Generic Communications Channel Shared Memory Region
///

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PCCT_GENERIC_SHARED_MEMORY_REGION_COMMAND
{
  public byte Command;
  public byte Reserved = 7;
  public byte GenerateSci = 1;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PCCT_GENERIC_SHARED_MEMORY_REGION_STATUS
{
  public byte CommandComplete = 1;
  public byte SciDoorbell = 1;
  public byte Error = 1;
  public byte PlatformNotification = 1;
  public byte Reserved = 4;
  public byte Reserved1;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_5_1_PCCT_GENERIC_SHARED_MEMORY_REGION_HEADER
{
  public uint Signature;
  public EFI_ACPI_5_1_PCCT_GENERIC_SHARED_MEMORY_REGION_COMMAND Command;
  public EFI_ACPI_5_1_PCCT_GENERIC_SHARED_MEMORY_REGION_STATUS Status;
}

//
// Known table signatures
//

///
/// "RSD PTR " Root System Description Pointer
///
public const ulong EFI_ACPI_5_1_ROOT_SYSTEM_DESCRIPTION_POINTER_SIGNATURE = SIGNATURE_64('R', 'S', 'D', ' ', 'P', 'T', 'R', ' ');

///
/// "APIC" Multiple APIC Description Table
///
public const ulong EFI_ACPI_5_1_MULTIPLE_APIC_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('A', 'P', 'I', 'C');

///
/// "BERT" Boot Error Record Table
///
public const ulong EFI_ACPI_5_1_BOOT_ERROR_RECORD_TABLE_SIGNATURE = SIGNATURE_32('B', 'E', 'R', 'T');

///
/// "BGRT" Boot Graphics Resource Table
///
public const ulong EFI_ACPI_5_1_BOOT_GRAPHICS_RESOURCE_TABLE_SIGNATURE = SIGNATURE_32('B', 'G', 'R', 'T');

///
/// "CPEP" Corrected Platform Error Polling Table
///
public const ulong EFI_ACPI_5_1_CORRECTED_PLATFORM_ERROR_POLLING_TABLE_SIGNATURE = SIGNATURE_32('C', 'P', 'E', 'P');

///
/// "DSDT" Differentiated System Description Table
///
public const ulong EFI_ACPI_5_1_DIFFERENTIATED_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('D', 'S', 'D', 'T');

///
/// "ECDT" Embedded Controller Boot Resources Table
///
public const ulong EFI_ACPI_5_1_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE_SIGNATURE = SIGNATURE_32('E', 'C', 'D', 'T');

///
/// "EINJ" Error Injection Table
///
public const ulong EFI_ACPI_5_1_ERROR_INJECTION_TABLE_SIGNATURE = SIGNATURE_32('E', 'I', 'N', 'J');

///
/// "ERST" Error Record Serialization Table
///
public const ulong EFI_ACPI_5_1_ERROR_RECORD_SERIALIZATION_TABLE_SIGNATURE = SIGNATURE_32('E', 'R', 'S', 'T');

///
/// "FACP" Fixed ACPI Description Table
///
public const ulong EFI_ACPI_5_1_FIXED_ACPI_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('F', 'A', 'C', 'P');

///
/// "FACS" Firmware ACPI Control Structure
///
public const ulong EFI_ACPI_5_1_FIRMWARE_ACPI_CONTROL_STRUCTURE_SIGNATURE = SIGNATURE_32('F', 'A', 'C', 'S');

///
/// "FPDT" Firmware Performance Data Table
///
public const ulong EFI_ACPI_5_1_FIRMWARE_PERFORMANCE_DATA_TABLE_SIGNATURE = SIGNATURE_32('F', 'P', 'D', 'T');

///
/// "GTDT" Generic Timer Description Table
///
public const ulong EFI_ACPI_5_1_GENERIC_TIMER_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('G', 'T', 'D', 'T');

///
/// "HEST" Hardware Error Source Table
///
public const ulong EFI_ACPI_5_1_HARDWARE_ERROR_SOURCE_TABLE_SIGNATURE = SIGNATURE_32('H', 'E', 'S', 'T');

///
/// "MPST" Memory Power State Table
///
public const ulong EFI_ACPI_5_1_MEMORY_POWER_STATE_TABLE_SIGNATURE = SIGNATURE_32('M', 'P', 'S', 'T');

///
/// "MSCT" Maximum System Characteristics Table
///
public const ulong EFI_ACPI_5_1_MAXIMUM_SYSTEM_CHARACTERISTICS_TABLE_SIGNATURE = SIGNATURE_32('M', 'S', 'C', 'T');

///
/// "PMTT" Platform Memory Topology Table
///
public const ulong EFI_ACPI_5_1_PLATFORM_MEMORY_TOPOLOGY_TABLE_SIGNATURE = SIGNATURE_32('P', 'M', 'T', 'T');

///
/// "PSDT" Persistent System Description Table
///
public const ulong EFI_ACPI_5_1_PERSISTENT_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('P', 'S', 'D', 'T');

///
/// "RASF" ACPI RAS Feature Table
///
public const ulong EFI_ACPI_5_1_ACPI_RAS_FEATURE_TABLE_SIGNATURE = SIGNATURE_32('R', 'A', 'S', 'F');

///
/// "RSDT" Root System Description Table
///
public const ulong EFI_ACPI_5_1_ROOT_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('R', 'S', 'D', 'T');

///
/// "SBST" Smart Battery Specification Table
///
public const ulong EFI_ACPI_5_1_SMART_BATTERY_SPECIFICATION_TABLE_SIGNATURE = SIGNATURE_32('S', 'B', 'S', 'T');

///
/// "SLIT" System Locality Information Table
///
public const ulong EFI_ACPI_5_1_SYSTEM_LOCALITY_INFORMATION_TABLE_SIGNATURE = SIGNATURE_32('S', 'L', 'I', 'T');

///
/// "SRAT" System Resource Affinity Table
///
public const ulong EFI_ACPI_5_1_SYSTEM_RESOURCE_AFFINITY_TABLE_SIGNATURE = SIGNATURE_32('S', 'R', 'A', 'T');

///
/// "SSDT" Secondary System Description Table
///
public const ulong EFI_ACPI_5_1_SECONDARY_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('S', 'S', 'D', 'T');

///
/// "XSDT" Extended System Description Table
///
public const ulong EFI_ACPI_5_1_EXTENDED_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('X', 'S', 'D', 'T');

///
/// "BOOT" MS Simple Boot Spec
///
public const ulong EFI_ACPI_5_1_SIMPLE_BOOT_FLAG_TABLE_SIGNATURE = SIGNATURE_32('B', 'O', 'O', 'T');

///
/// "CSRT" MS Core System Resource Table
///
public const ulong EFI_ACPI_5_1_CORE_SYSTEM_RESOURCE_TABLE_SIGNATURE = SIGNATURE_32('C', 'S', 'R', 'T');

///
/// "DBG2" MS Debug Port 2 Spec
///
public const ulong EFI_ACPI_5_1_DEBUG_PORT_2_TABLE_SIGNATURE = SIGNATURE_32('D', 'B', 'G', '2');

///
/// "DBGP" MS Debug Port Spec
///
public const ulong EFI_ACPI_5_1_DEBUG_PORT_TABLE_SIGNATURE = SIGNATURE_32('D', 'B', 'G', 'P');

///
/// "DMAR" DMA Remapping Table
///
public const ulong EFI_ACPI_5_1_DMA_REMAPPING_TABLE_SIGNATURE = SIGNATURE_32('D', 'M', 'A', 'R');

///
/// "DRTM" Dynamic Root of Trust for Measurement Table
///
public const ulong EFI_ACPI_5_1_DYNAMIC_ROOT_OF_TRUST_FOR_MEASUREMENT_TABLE_SIGNATURE = SIGNATURE_32('D', 'R', 'T', 'M');

///
/// "ETDT" Event Timer Description Table
///
public const ulong EFI_ACPI_5_1_EVENT_TIMER_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('E', 'T', 'D', 'T');

///
/// "HPET" IA-PC High Precision Event Timer Table
///
public const ulong EFI_ACPI_5_1_HIGH_PRECISION_EVENT_TIMER_TABLE_SIGNATURE = SIGNATURE_32('H', 'P', 'E', 'T');

///
/// "iBFT" iSCSI Boot Firmware Table
///
public const ulong EFI_ACPI_5_1_ISCSI_BOOT_FIRMWARE_TABLE_SIGNATURE = SIGNATURE_32('i', 'B', 'F', 'T');

///
/// "IVRS" I/O Virtualization Reporting Structure
///
public const ulong EFI_ACPI_5_1_IO_VIRTUALIZATION_REPORTING_STRUCTURE_SIGNATURE = SIGNATURE_32('I', 'V', 'R', 'S');

///
/// "LPIT" Low Power Idle Table
///
public const ulong EFI_ACPI_5_1_IO_LOW_POWER_IDLE_TABLE_STRUCTURE_SIGNATURE = SIGNATURE_32('L', 'P', 'I', 'T');

///
/// "MCFG" PCI Express Memory Mapped Configuration Space Base Address Description Table
///
public const ulong EFI_ACPI_5_1_PCI_EXPRESS_MEMORY_MAPPED_CONFIGURATION_SPACE_BASE_ADDRESS_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('M', 'C', 'F', 'G');

///
/// "MCHI" Management Controller Host Interface Table
///
public const ulong EFI_ACPI_5_1_MANAGEMENT_CONTROLLER_HOST_INTERFACE_TABLE_SIGNATURE = SIGNATURE_32('M', 'C', 'H', 'I');

///
/// "MSDM" MS Data Management Table
///
public const ulong EFI_ACPI_5_1_DATA_MANAGEMENT_TABLE_SIGNATURE = SIGNATURE_32('M', 'S', 'D', 'M');

///
/// "PCCT" Platform Communications Channel Table
///
public const ulong EFI_ACPI_5_1_PLATFORM_COMMUNICATIONS_CHANNEL_TABLE_SIGNATURE = SIGNATURE_32('P', 'C', 'C', 'T');

///
/// "SLIC" MS Software Licensing Table Specification
///
public const ulong EFI_ACPI_5_1_SOFTWARE_LICENSING_TABLE_SIGNATURE = SIGNATURE_32('S', 'L', 'I', 'C');

///
/// "SPCR" Serial Port Console Redirection Table
///
public const ulong EFI_ACPI_5_1_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_SIGNATURE = SIGNATURE_32('S', 'P', 'C', 'R');

///
/// "SPMI" Server Platform Management Interface Table
///
public const ulong EFI_ACPI_5_1_SERVER_PLATFORM_MANAGEMENT_INTERFACE_TABLE_SIGNATURE = SIGNATURE_32('S', 'P', 'M', 'I');

///
/// "TCPA" Trusted Computing Platform Alliance Capabilities Table
///
public const ulong EFI_ACPI_5_1_TRUSTED_COMPUTING_PLATFORM_ALLIANCE_CAPABILITIES_TABLE_SIGNATURE = SIGNATURE_32('T', 'C', 'P', 'A');

///
/// "TPM2" Trusted Computing Platform 1 Table
///
public const ulong EFI_ACPI_5_1_TRUSTED_COMPUTING_PLATFORM_2_TABLE_SIGNATURE = SIGNATURE_32('T', 'P', 'M', '2');

///
/// "UEFI" UEFI ACPI Data Table
///
public const ulong EFI_ACPI_5_1_UEFI_ACPI_DATA_TABLE_SIGNATURE = SIGNATURE_32('U', 'E', 'F', 'I');

///
/// "WAET" Windows ACPI Emulated Devices Table
///
public const ulong EFI_ACPI_5_1_WINDOWS_ACPI_EMULATED_DEVICES_TABLE_SIGNATURE = SIGNATURE_32('W', 'A', 'E', 'T');

///
/// "WDAT" Watchdog Action Table
///
public const ulong EFI_ACPI_5_1_WATCHDOG_ACTION_TABLE_SIGNATURE = SIGNATURE_32('W', 'D', 'A', 'T');

///
/// "WDRT" Watchdog Resource Table
///
public const ulong EFI_ACPI_5_1_WATCHDOG_RESOURCE_TABLE_SIGNATURE = SIGNATURE_32('W', 'D', 'R', 'T');

///
/// "WPBT" MS Platform Binary Table
///
public const ulong EFI_ACPI_5_1_PLATFORM_BINARY_TABLE_SIGNATURE = SIGNATURE_32('W', 'P', 'B', 'T');

// #pragma pack()

// #endif
