using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ACPI 6.2 definitions from the ACPI Specification Revision 6.2 May, 2017.

  Copyright (c) 2017 - 2022, Intel Corporation. All rights reserved.<BR>
  Copyright (c) 2020, ARM Ltd. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _ACPI_6_2_H_
// #define _ACPI_6_2_H_

// #include <IndustryStandard/Acpi61.h>

public unsafe partial class EFI
{
  //
  // Large Item Descriptor Name
  //
  public const ulong ACPI_LARGE_PIN_FUNCTION_DESCRIPTOR_NAME = 0x0D;
  public const ulong ACPI_LARGE_PIN_CONFIGURATION_DESCRIPTOR_NAME = 0x0F;
  public const ulong ACPI_LARGE_PIN_GROUP_DESCRIPTOR_NAME = 0x10;
  public const ulong ACPI_LARGE_PIN_GROUP_FUNCTION_DESCRIPTOR_NAME = 0x11;
  public const ulong ACPI_LARGE_PIN_GROUP_CONFIGURATION_DESCRIPTOR_NAME = 0x12;

  //
  // Large Item Descriptor Value
  //
  public const ulong ACPI_PIN_FUNCTION_DESCRIPTOR = 0x8D;
  public const ulong ACPI_PIN_CONFIGURATION_DESCRIPTOR = 0x8F;
  public const ulong ACPI_PIN_GROUP_DESCRIPTOR = 0x90;
  public const ulong ACPI_PIN_GROUP_FUNCTION_DESCRIPTOR = 0x91;
  public const ulong ACPI_PIN_GROUP_CONFIGURATION_DESCRIPTOR = 0x92;

  // #pragma pack(1)
}

///
/// Pin Function Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_PIN_FUNCTION_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte RevisionId;
  public ushort Flags;
  public byte PinPullConfiguration;
  public ushort FunctionNumber;
  public ushort PinTableOffset;
  public byte ResourceSourceIndex;
  public ushort ResourceSourceNameOffset;
  public ushort VendorDataOffset;
  public ushort VendorDataLength;
}

///
/// Pin Configuration Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_PIN_CONFIGURATION_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte RevisionId;
  public ushort Flags;
  public byte PinConfigurationType;
  public uint PinConfigurationValue;
  public ushort PinTableOffset;
  public byte ResourceSourceIndex;
  public ushort ResourceSourceNameOffset;
  public ushort VendorDataOffset;
  public ushort VendorDataLength;
}

///
/// Pin Group Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_PIN_GROUP_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte RevisionId;
  public ushort Flags;
  public ushort PinTableOffset;
  public ushort ResourceLabelOffset;
  public ushort VendorDataOffset;
  public ushort VendorDataLength;
}

///
/// Pin Group Function Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_PIN_GROUP_FUNCTION_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte RevisionId;
  public ushort Flags;
  public ushort FunctionNumber;
  public byte ResourceSourceIndex;
  public ushort ResourceSourceNameOffset;
  public ushort ResourceSourceLabelOffset;
  public ushort VendorDataOffset;
  public ushort VendorDataLength;
}

///
/// Pin Group Configuration Descriptor
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_PIN_GROUP_CONFIGURATION_DESCRIPTOR
{
  public ACPI_LARGE_RESOURCE_HEADER Header;
  public byte RevisionId;
  public ushort Flags;
  public byte PinConfigurationType;
  public uint PinConfigurationValue;
  public byte ResourceSourceIndex;
  public ushort ResourceSourceNameOffset;
  public ushort ResourceSourceLabelOffset;
  public ushort VendorDataOffset;
  public ushort VendorDataLength;
}

// #pragma pack()

//
// Ensure proper structure formats
//
// #pragma pack(1)

///
/// ACPI 6.2 Generic Address Space definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE
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
  public const ulong EFI_ACPI_6_2_SYSTEM_MEMORY = 0;
  public const ulong EFI_ACPI_6_2_SYSTEM_IO = 1;
  public const ulong EFI_ACPI_6_2_PCI_CONFIGURATION_SPACE = 2;
  public const ulong EFI_ACPI_6_2_EMBEDDED_CONTROLLER = 3;
  public const ulong EFI_ACPI_6_2_SMBUS = 4;
  public const ulong EFI_ACPI_6_2_PLATFORM_COMMUNICATION_CHANNEL = 0x0A;
  public const ulong EFI_ACPI_6_2_FUNCTIONAL_FIXED_HARDWARE = 0x7F;

  //
  // Generic Address Space Access Sizes
  //
  public const ulong EFI_ACPI_6_2_UNDEFINED = 0;
  public const ulong EFI_ACPI_6_2_BYTE = 1;
  public const ulong EFI_ACPI_6_2_WORD = 2;
  public const ulong EFI_ACPI_6_2_DWORD = 3;
  public const ulong EFI_ACPI_6_2_QWORD = 4;

  //
  // ACPI 6.2 table structures
  //
}

///
/// Root System Description Pointer Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_ROOT_SYSTEM_DESCRIPTION_POINTER
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
  /// RSD_PTR Revision (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_ROOT_SYSTEM_DESCRIPTION_POINTER_REVISION = 0x02; /// < ACPISpec (Revision 6.2) says current value is 2
}

///
/// Common table header, this prefaces all ACPI tables, including FACS, but
/// excluding the RSD PTR structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_COMMON_HEADER
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
  /// RSDT Revision (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_ROOT_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x01;

  //
  // Extended System Description Table
  // No definition needed as it is a common description table header, the same with
  // EFI_ACPI_DESCRIPTION_HEADER, followed by a variable number of ulong table pointers.
  //

  ///
  /// XSDT Revision (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_EXTENDED_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x01;
}

///
/// Fixed ACPI Description Table Structure (FADT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_FIXED_ACPI_DESCRIPTION_TABLE
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
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE ResetReg;
  public byte ResetValue;
  public ushort ArmBootArch;
  public byte MinorVersion;
  public ulong XFirmwareCtrl;
  public ulong XDsdt;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE XPm1aEvtBlk;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE XPm1bEvtBlk;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE XPm1aCntBlk;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE XPm1bCntBlk;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE XPm2CntBlk;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE XPmTmrBlk;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE XGpe0Blk;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE XGpe1Blk;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE SleepControlReg;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE SleepStatusReg;
  public ulong HypervisorVendorIdentity;
}

public unsafe partial class EFI
{
  ///
  /// FADT Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_FIXED_ACPI_DESCRIPTION_TABLE_REVISION = 0x06;
  public const ulong EFI_ACPI_6_2_FIXED_ACPI_DESCRIPTION_TABLE_MINOR_REVISION = 0x02;

  //
  // Fixed ACPI Description Table Preferred Power Management Profile
  //
  public const ulong EFI_ACPI_6_2_PM_PROFILE_UNSPECIFIED = 0;
  public const ulong EFI_ACPI_6_2_PM_PROFILE_DESKTOP = 1;
  public const ulong EFI_ACPI_6_2_PM_PROFILE_MOBILE = 2;
  public const ulong EFI_ACPI_6_2_PM_PROFILE_WORKSTATION = 3;
  public const ulong EFI_ACPI_6_2_PM_PROFILE_ENTERPRISE_SERVER = 4;
  public const ulong EFI_ACPI_6_2_PM_PROFILE_SOHO_SERVER = 5;
  public const ulong EFI_ACPI_6_2_PM_PROFILE_APPLIANCE_PC = 6;
  public const ulong EFI_ACPI_6_2_PM_PROFILE_PERFORMANCE_SERVER = 7;
  public const ulong EFI_ACPI_6_2_PM_PROFILE_TABLET = 8;

  //
  // Fixed ACPI Description Table Boot Architecture Flags
  // All other bits are reserved and must be set to 0.
  //
  public const ulong EFI_ACPI_6_2_LEGACY_DEVICES = BIT0;
  public const ulong EFI_ACPI_6_2_8042 = BIT1;
  public const ulong EFI_ACPI_6_2_VGA_NOT_PRESENT = BIT2;
  public const ulong EFI_ACPI_6_2_MSI_NOT_SUPPORTED = BIT3;
  public const ulong EFI_ACPI_6_2_PCIE_ASPM_CONTROLS = BIT4;
  public const ulong EFI_ACPI_6_2_CMOS_RTC_NOT_PRESENT = BIT5;

  //
  // Fixed ACPI Description Table Arm Boot Architecture Flags
  // All other bits are reserved and must be set to 0.
  //
  public const ulong EFI_ACPI_6_2_ARM_PSCI_COMPLIANT = BIT0;
  public const ulong EFI_ACPI_6_2_ARM_PSCI_USE_HVC = BIT1;

  //
  // Fixed ACPI Description Table Fixed Feature Flags
  // All other bits are reserved and must be set to 0.
  //
  public const ulong EFI_ACPI_6_2_WBINVD = BIT0;
  public const ulong EFI_ACPI_6_2_WBINVD_FLUSH = BIT1;
  public const ulong EFI_ACPI_6_2_PROC_C1 = BIT2;
  public const ulong EFI_ACPI_6_2_P_LVL2_UP = BIT3;
  public const ulong EFI_ACPI_6_2_PWR_BUTTON = BIT4;
  public const ulong EFI_ACPI_6_2_SLP_BUTTON = BIT5;
  public const ulong EFI_ACPI_6_2_FIX_RTC = BIT6;
  public const ulong EFI_ACPI_6_2_RTC_S4 = BIT7;
  public const ulong EFI_ACPI_6_2_TMR_VAL_EXT = BIT8;
  public const ulong EFI_ACPI_6_2_DCK_CAP = BIT9;
  public const ulong EFI_ACPI_6_2_RESET_REG_SUP = BIT10;
  public const ulong EFI_ACPI_6_2_SEALED_CASE = BIT11;
  public const ulong EFI_ACPI_6_2_HEADLESS = BIT12;
  public const ulong EFI_ACPI_6_2_CPU_SW_SLP = BIT13;
  public const ulong EFI_ACPI_6_2_PCI_EXP_WAK = BIT14;
  public const ulong EFI_ACPI_6_2_USE_PLATFORM_CLOCK = BIT15;
  public const ulong EFI_ACPI_6_2_S4_RTC_STS_VALID = BIT16;
  public const ulong EFI_ACPI_6_2_REMOTE_POWER_ON_CAPABLE = BIT17;
  public const ulong EFI_ACPI_6_2_FORCE_APIC_CLUSTER_MODEL = BIT18;
  public const ulong EFI_ACPI_6_2_FORCE_APIC_PHYSICAL_DESTINATION_MODE = BIT19;
  public const ulong EFI_ACPI_6_2_HW_REDUCED_ACPI = BIT20;
  public const ulong EFI_ACPI_6_2_LOW_POWER_S0_IDLE_CAPABLE = BIT21;
}

///
/// Firmware ACPI Control Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_FIRMWARE_ACPI_CONTROL_STRUCTURE
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

public unsafe partial class EFI
{
  ///
  /// FACS Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_FIRMWARE_ACPI_CONTROL_STRUCTURE_VERSION = 0x02;

  ///
  /// Firmware Control Structure Feature Flags
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_6_2_S4BIOS_F = BIT0;
  public const ulong EFI_ACPI_6_2_64BIT_WAKE_SUPPORTED_F = BIT1;

  ///
  /// OSPM Enabled Firmware Control Structure Flags
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_6_2_OSPM_64BIT_WAKE_F = BIT0;

  //
  // Differentiated System Description Table,
  // Secondary System Description Table
  // and Persistent System Description Table,
  // no definition needed as they are common description table header, the same with
  // EFI_ACPI_DESCRIPTION_HEADER, followed by a definition block.
  //
  public const ulong EFI_ACPI_6_2_DIFFERENTIATED_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x02;
  public const ulong EFI_ACPI_6_2_SECONDARY_SYSTEM_DESCRIPTION_TABLE_REVISION = 0x02;
}

///
/// Multiple APIC Description Table header definition.  The rest of the table
/// must be defined in a platform specific manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MULTIPLE_APIC_DESCRIPTION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint LocalApicAddress;
  public uint Flags;
}

public unsafe partial class EFI
{
  ///
  /// MADT Revision (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_MULTIPLE_APIC_DESCRIPTION_TABLE_REVISION = 0x04;

  ///
  /// Multiple APIC Flags
  /// All other bits are reserved and must be set to 0.
  ///
  public const ulong EFI_ACPI_6_2_PCAT_COMPAT = BIT0;

  //
  // Multiple APIC Description Table APIC structure types
  // All other values between 0x0D and 0x7F are reserved and
  // will be ignored by OSPM. 0x80 ~ 0xFF are reserved for OEM.
  //
  public const ulong EFI_ACPI_6_2_PROCESSOR_LOCAL_APIC = 0x00;
  public const ulong EFI_ACPI_6_2_IO_APIC = 0x01;
  public const ulong EFI_ACPI_6_2_INTERRUPT_SOURCE_OVERRIDE = 0x02;
  public const ulong EFI_ACPI_6_2_NON_MASKABLE_INTERRUPT_SOURCE = 0x03;
  public const ulong EFI_ACPI_6_2_LOCAL_APIC_NMI = 0x04;
  public const ulong EFI_ACPI_6_2_LOCAL_APIC_ADDRESS_OVERRIDE = 0x05;
  public const ulong EFI_ACPI_6_2_IO_SAPIC = 0x06;
  public const ulong EFI_ACPI_6_2_LOCAL_SAPIC = 0x07;
  public const ulong EFI_ACPI_6_2_PLATFORM_INTERRUPT_SOURCES = 0x08;
  public const ulong EFI_ACPI_6_2_PROCESSOR_LOCAL_X2APIC = 0x09;
  public const ulong EFI_ACPI_6_2_LOCAL_X2APIC_NMI = 0x0A;
  public const ulong EFI_ACPI_6_2_GIC = 0x0B;
  public const ulong EFI_ACPI_6_2_GICD = 0x0C;
  public const ulong EFI_ACPI_6_2_GIC_MSI_FRAME = 0x0D;
  public const ulong EFI_ACPI_6_2_GICR = 0x0E;
  public const ulong EFI_ACPI_6_2_GIC_ITS = 0x0F;

  //
  // APIC Structure Definitions
  //
}

///
/// Processor Local APIC Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PROCESSOR_LOCAL_APIC_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte AcpiProcessorUid;
  public byte ApicId;
  public uint Flags;
}

public unsafe partial class EFI
{
  ///
  /// Local APIC Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_6_2_LOCAL_APIC_ENABLED = BIT0;
}

///
/// IO APIC Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_IO_APIC_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_INTERRUPT_SOURCE_OVERRIDE_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_PLATFORM_INTERRUPT_APIC_STRUCTURE
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
  public const ulong EFI_ACPI_6_2_POLARITY = (3 << 0);
  public const ulong EFI_ACPI_6_2_TRIGGER_MODE = (3 << 2);
}

///
/// Non-Maskable Interrupt Source Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NON_MASKABLE_INTERRUPT_SOURCE_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_LOCAL_APIC_NMI_STRUCTURE
{
  public byte Type;
  public byte Length;
  public byte AcpiProcessorUid;
  public ushort Flags;
  public byte LocalApicLint;
}

///
/// Local APIC Address Override Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_LOCAL_APIC_ADDRESS_OVERRIDE_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_IO_SAPIC_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_PROCESSOR_LOCAL_SAPIC_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_PLATFORM_INTERRUPT_SOURCES_STRUCTURE
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
  public const ulong EFI_ACPI_6_2_CPEI_PROCESSOR_OVERRIDE = BIT0;
}

///
/// Processor Local x2APIC Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PROCESSOR_LOCAL_X2APIC_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_LOCAL_X2APIC_NMI_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_GIC_STRUCTURE
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
  public byte ProcessorPowerEfficiencyClass;
  public fixed byte Reserved2[3];
}

public unsafe partial class EFI
{
  ///
  /// GIC Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_6_2_GIC_ENABLED = BIT0;
  public const ulong EFI_ACPI_6_2_PERFORMANCE_INTERRUPT_MODEL = BIT1;
  public const ulong EFI_ACPI_6_2_VGIC_MAINTENANCE_INTERRUPT_MODE_FLAGS = BIT2;
}

///
/// GIC Distributor Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GIC_DISTRIBUTOR_STRUCTURE
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

public unsafe partial class EFI
{
  ///
  /// GIC Version
  ///
  public const ulong EFI_ACPI_6_2_GIC_V1 = 0x01;
  public const ulong EFI_ACPI_6_2_GIC_V2 = 0x02;
  public const ulong EFI_ACPI_6_2_GIC_V3 = 0x03;
  public const ulong EFI_ACPI_6_2_GIC_V4 = 0x04;
}

///
/// GIC MSI Frame Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GIC_MSI_FRAME_STRUCTURE
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

public unsafe partial class EFI
{
  ///
  /// GIC MSI Frame Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_6_2_SPI_COUNT_BASE_SELECT = BIT0;
}

///
/// GICR Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GICR_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Reserved;
  public ulong DiscoveryRangeBaseAddress;
  public uint DiscoveryRangeLength;
}

///
/// GIC Interrupt Translation Service Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GIC_ITS_STRUCTURE
{
  public byte Type;
  public byte Length;
  public ushort Reserved;
  public uint GicItsId;
  public ulong PhysicalBaseAddress;
  public uint Reserved2;
}

///
/// Smart Battery Description Table (SBST)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_SMART_BATTERY_DESCRIPTION_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint WarningEnergyLevel;
  public uint LowEnergyLevel;
  public uint CriticalEnergyLevel;
}

public unsafe partial class EFI
{
  ///
  /// SBST Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_SMART_BATTERY_DESCRIPTION_TABLE_REVISION = 0x01;
}

///
/// Embedded Controller Boot Resources Table (ECDT)
/// The table is followed by a null terminated ASCII string that contains
/// a fully qualified reference to the name space object.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE EcControl;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE EcData;
  public uint Uid;
  public byte GpeBit;
}

public unsafe partial class EFI
{
  ///
  /// ECDT Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE_REVISION = 0x01;
}

///
/// System Resource Affinity Table (SRAT).  The rest of the table
/// must be defined in a platform specific manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_SYSTEM_RESOURCE_AFFINITY_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint Reserved1; ///< Must be set to 1
  public ulong Reserved2;
}

public unsafe partial class EFI
{
  ///
  /// SRAT Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_SYSTEM_RESOURCE_AFFINITY_TABLE_REVISION = 0x03;

  //
  // SRAT structure types.
  // All other values between 0x05 an 0xFF are reserved and
  // will be ignored by OSPM.
  //
  public const ulong EFI_ACPI_6_2_PROCESSOR_LOCAL_APIC_SAPIC_AFFINITY = 0x00;
  public const ulong EFI_ACPI_6_2_MEMORY_AFFINITY = 0x01;
  public const ulong EFI_ACPI_6_2_PROCESSOR_LOCAL_X2APIC_AFFINITY = 0x02;
  public const ulong EFI_ACPI_6_2_GICC_AFFINITY = 0x03;
  public const ulong EFI_ACPI_6_2_GIC_ITS_AFFINITY = 0x04;
}

///
/// Processor Local APIC/SAPIC Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PROCESSOR_LOCAL_APIC_SAPIC_AFFINITY_STRUCTURE
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

public unsafe partial class EFI
{
  ///
  /// Local APIC/SAPIC Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_6_2_PROCESSOR_LOCAL_APIC_SAPIC_ENABLED = (1 << 0);
}

///
/// Memory Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MEMORY_AFFINITY_STRUCTURE
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
  public const ulong EFI_ACPI_6_2_MEMORY_ENABLED = (1 << 0);
  public const ulong EFI_ACPI_6_2_MEMORY_HOT_PLUGGABLE = (1 << 1);
  public const ulong EFI_ACPI_6_2_MEMORY_NONVOLATILE = (1 << 2);
}

///
/// Processor Local x2APIC Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PROCESSOR_LOCAL_X2APIC_AFFINITY_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_GICC_AFFINITY_STRUCTURE
{
  public byte Type;
  public byte Length;
  public uint ProximityDomain;
  public uint AcpiProcessorUid;
  public uint Flags;
  public uint ClockDomain;
}

public unsafe partial class EFI
{
  ///
  /// GICC Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_6_2_GICC_ENABLED = (1 << 0);
}

///
/// GIC Interrupt Translation Service (ITS) Affinity Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GIC_ITS_AFFINITY_STRUCTURE
{
  public byte Type;
  public byte Length;
  public uint ProximityDomain;
  public fixed byte Reserved[2];
  public uint ItsId;
}

///
/// System Locality Distance Information Table (SLIT).
/// The rest of the table is a matrix.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_SYSTEM_LOCALITY_DISTANCE_INFORMATION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public ulong NumberOfSystemLocalities;
}

public unsafe partial class EFI
{
  ///
  /// SLIT Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_SYSTEM_LOCALITY_DISTANCE_INFORMATION_TABLE_REVISION = 0x01;
}

///
/// Corrected Platform Error Polling Table (CPEP)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_CORRECTED_PLATFORM_ERROR_POLLING_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public fixed byte Reserved[8];
}

public unsafe partial class EFI
{
  ///
  /// CPEP Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_CORRECTED_PLATFORM_ERROR_POLLING_TABLE_REVISION = 0x01;

  //
  // CPEP processor structure types.
  //
  public const ulong EFI_ACPI_6_2_CPEP_PROCESSOR_APIC_SAPIC = 0x00;
}

///
/// Corrected Platform Error Polling Processor Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_CPEP_PROCESSOR_APIC_SAPIC_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_MAXIMUM_SYSTEM_CHARACTERISTICS_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint OffsetProxDomInfo;
  public uint MaximumNumberOfProximityDomains;
  public uint MaximumNumberOfClockDomains;
  public ulong MaximumPhysicalAddress;
}

public unsafe partial class EFI
{
  ///
  /// MSCT Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_MAXIMUM_SYSTEM_CHARACTERISTICS_TABLE_REVISION = 0x01;
}

///
/// Maximum Proximity Domain Information Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MAXIMUM_PROXIMITY_DOMAIN_INFORMATION_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_RAS_FEATURE_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public fixed byte PlatformCommunicationChannelIdentifier[12];
}

public unsafe partial class EFI
{
  ///
  /// RASF Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_RAS_FEATURE_TABLE_REVISION = 0x01;
}

///
/// ACPI RASF Platform Communication Channel Shared Memory Region definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_RASF_PLATFORM_COMMUNICATION_CHANNEL_SHARED_MEMORY_REGION
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

public unsafe partial class EFI
{
  ///
  /// ACPI RASF PCC command code
  ///
  public const ulong EFI_ACPI_6_2_RASF_PCC_COMMAND_CODE_EXECUTE_RASF_COMMAND = 0x01;

  ///
  /// ACPI RASF Platform RAS Capabilities
  ///
  public const ulong EFI_ACPI_6_2_RASF_PLATFORM_RAS_CAPABILITY_HARDWARE_BASED_PATROL_SCRUB_SUPPORTED = BIT0;
  public const ulong EFI_ACPI_6_2_RASF_PLATFORM_RAS_CAPABILITY_HARDWARE_BASED_PATROL_SCRUB_SUPPORTED_AND_EXPOSED_TO_SOFTWARE = BIT1;
  public const ulong EFI_ACPI_6_2_RASF_PLATFORM_RAS_CAPABILITY_CPU_CACHE_FLUSH_TO_NVDIMM_DURABILITY_ON_POWER_LOSS = BIT2;
  public const ulong EFI_ACPI_6_2_RASF_PLATFORM_RAS_CAPABILITY_MEMORY_CONTROLLER_FLUSH_TO_NVDIMM_DURABILITY_ON_POWER_LOSS = BIT3;
  public const ulong EFI_ACPI_6_2_RASF_PLATFORM_RAS_CAPABILITY_BYTE_ADDRESSABLE_PERSISTENT_MEMORY_HARDWARE_MIRRORING = BIT4;
}

///
/// ACPI RASF Parameter Block structure for PATROL_SCRUB
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_RASF_PATROL_SCRUB_PLATFORM_BLOCK_STRUCTURE
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

public unsafe partial class EFI
{
  ///
  /// ACPI RASF Patrol Scrub command
  ///
  public const ulong EFI_ACPI_6_2_RASF_PATROL_SCRUB_COMMAND_GET_PATROL_PARAMETERS = 0x01;
  public const ulong EFI_ACPI_6_2_RASF_PATROL_SCRUB_COMMAND_START_PATROL_SCRUBBER = 0x02;
  public const ulong EFI_ACPI_6_2_RASF_PATROL_SCRUB_COMMAND_STOP_PATROL_SCRUBBER = 0x03;
}

///
/// Memory Power State Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MEMORY_POWER_STATUS_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public byte PlatformCommunicationChannelIdentifier;
  public fixed byte Reserved[3];
  // Memory Power Node Structure
  // Memory Power State Characteristics
}

public unsafe partial class EFI
{
  ///
  /// MPST Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_MEMORY_POWER_STATE_TABLE_REVISION = 0x01;
}

///
/// MPST Platform Communication Channel Shared Memory Region definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MPST_PLATFORM_COMMUNICATION_CHANNEL_SHARED_MEMORY_REGION
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

public unsafe partial class EFI
{
  ///
  /// ACPI MPST PCC command code
  ///
  public const ulong EFI_ACPI_6_2_MPST_PCC_COMMAND_CODE_EXECUTE_MPST_COMMAND = 0x03;

  ///
  /// ACPI MPST Memory Power command
  ///
  public const ulong EFI_ACPI_6_2_MPST_MEMORY_POWER_COMMAND_GET_MEMORY_POWER_STATE = 0x01;
  public const ulong EFI_ACPI_6_2_MPST_MEMORY_POWER_COMMAND_SET_MEMORY_POWER_STATE = 0x02;
  public const ulong EFI_ACPI_6_2_MPST_MEMORY_POWER_COMMAND_GET_AVERAGE_POWER_CONSUMED = 0x03;
  public const ulong EFI_ACPI_6_2_MPST_MEMORY_POWER_COMMAND_GET_MEMORY_ENERGY_CONSUMED = 0x04;
}

///
/// MPST Memory Power Node Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MPST_MEMORY_POWER_STATE
{
  public byte PowerStateValue;
  public byte PowerStateInformationIndex;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MPST_MEMORY_POWER_STRUCTURE
{
  public byte Flag;
  public byte Reserved;
  public ushort MemoryPowerNodeId;
  public uint Length;
  public ulong AddressBase;
  public ulong AddressLength;
  public uint NumberOfPowerStates;
  public uint NumberOfPhysicalComponents;
  // EFI_ACPI_6_2_MPST_MEMORY_POWER_STATE              MemoryPowerState[NumberOfPowerStates];
  // ushort                                            PhysicalComponentIdentifier[NumberOfPhysicalComponents];
}

public unsafe partial class EFI
{
  public const ulong EFI_ACPI_6_2_MPST_MEMORY_POWER_STRUCTURE_FLAG_ENABLE = 0x01;
  public const ulong EFI_ACPI_6_2_MPST_MEMORY_POWER_STRUCTURE_FLAG_POWER_MANAGED = 0x02;
  public const ulong EFI_ACPI_6_2_MPST_MEMORY_POWER_STRUCTURE_FLAG_HOT_PLUGGABLE = 0x04;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MPST_MEMORY_POWER_NODE_TABLE
{
  public ushort MemoryPowerNodeCount;
  public fixed byte Reserved[2];
}

///
/// MPST Memory Power State Characteristics Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MPST_MEMORY_POWER_STATE_CHARACTERISTICS_STRUCTURE
{
  public byte PowerStateStructureID;
  public byte Flag;
  public ushort Reserved;
  public uint AveragePowerConsumedInMPS0;
  public uint RelativePowerSavingToMPS0;
  public ulong ExitLatencyToMPS0;
}

public unsafe partial class EFI
{
  public const ulong EFI_ACPI_6_2_MPST_MEMORY_POWER_STATE_CHARACTERISTICS_STRUCTURE_FLAG_MEMORY_CONTENT_PRESERVED = 0x01;
  public const ulong EFI_ACPI_6_2_MPST_MEMORY_POWER_STATE_CHARACTERISTICS_STRUCTURE_FLAG_AUTONOMOUS_MEMORY_POWER_STATE_ENTRY = 0x02;
  public const ulong EFI_ACPI_6_2_MPST_MEMORY_POWER_STATE_CHARACTERISTICS_STRUCTURE_FLAG_AUTONOMOUS_MEMORY_POWER_STATE_EXIT = 0x04;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MPST_MEMORY_POWER_STATE_CHARACTERISTICS_TABLE
{
  public ushort MemoryPowerStateCharacteristicsCount;
  public fixed byte Reserved[2];
}

///
/// Memory Topology Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_MEMORY_TOPOLOGY_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint Reserved;
}

public unsafe partial class EFI
{
  ///
  /// PMTT Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_MEMORY_TOPOLOGY_TABLE_REVISION = 0x01;
}

///
/// Common Memory Aggregator Device Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PMMT_COMMON_MEMORY_AGGREGATOR_DEVICE_STRUCTURE
{
  public byte Type;
  public byte Reserved;
  public ushort Length;
  public ushort Flags;
  public ushort Reserved1;
}

public unsafe partial class EFI
{
  ///
  /// Memory Aggregator Device Type
  ///
  public const ulong EFI_ACPI_6_2_PMMT_MEMORY_AGGREGATOR_DEVICE_TYPE_SOCKET = 0x0;
  public const ulong EFI_ACPI_6_2_PMMT_MEMORY_AGGREGATOR_DEVICE_TYPE_MEMORY_CONTROLLER = 0x1;
  public const ulong EFI_ACPI_6_2_PMMT_MEMORY_AGGREGATOR_DEVICE_TYPE_DIMM = 0x2;
}

///
/// Socket Memory Aggregator Device Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PMMT_SOCKET_MEMORY_AGGREGATOR_DEVICE_STRUCTURE
{
  public EFI_ACPI_6_2_PMMT_COMMON_MEMORY_AGGREGATOR_DEVICE_STRUCTURE Header;
  public ushort SocketIdentifier;
  public ushort Reserved;
  // EFI_ACPI_6_2_PMMT_MEMORY_CONTROLLER_MEMORY_AGGREGATOR_DEVICE_STRUCTURE  MemoryController[];
}

///
/// MemoryController Memory Aggregator Device Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PMMT_MEMORY_CONTROLLER_MEMORY_AGGREGATOR_DEVICE_STRUCTURE
{
  public EFI_ACPI_6_2_PMMT_COMMON_MEMORY_AGGREGATOR_DEVICE_STRUCTURE Header;
  public uint ReadLatency;
  public uint WriteLatency;
  public uint ReadBandwidth;
  public uint WriteBandwidth;
  public ushort OptimalAccessUnit;
  public ushort OptimalAccessAlignment;
  public ushort Reserved;
  public ushort NumberOfProximityDomains;
  // uint                                                       ProximityDomain[NumberOfProximityDomains];
  // EFI_ACPI_6_2_PMMT_DIMM_MEMORY_AGGREGATOR_DEVICE_STRUCTURE    PhysicalComponent[];
}

///
/// DIMM Memory Aggregator Device Structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PMMT_DIMM_MEMORY_AGGREGATOR_DEVICE_STRUCTURE
{
  public EFI_ACPI_6_2_PMMT_COMMON_MEMORY_AGGREGATOR_DEVICE_STRUCTURE Header;
  public ushort PhysicalComponentIdentifier;
  public ushort Reserved;
  public uint SizeOfDimm;
  public uint SmbiosHandle;
}

///
/// Boot Graphics Resource Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_BOOT_GRAPHICS_RESOURCE_TABLE
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

public unsafe partial class EFI
{
  ///
  /// BGRT Revision
  ///
  public const ulong EFI_ACPI_6_2_BOOT_GRAPHICS_RESOURCE_TABLE_REVISION = 1;

  ///
  /// BGRT Version
  ///
  public const ulong EFI_ACPI_6_2_BGRT_VERSION = 0x01;

  ///
  /// BGRT Status
  ///
  public const ulong EFI_ACPI_6_2_BGRT_STATUS_NOT_DISPLAYED = 0x00;
  public const ulong EFI_ACPI_6_2_BGRT_STATUS_DISPLAYED = 0x01;

  ///
  /// BGRT Image Type
  ///
  public const ulong EFI_ACPI_6_2_BGRT_IMAGE_TYPE_BMP = 0x00;

  ///
  /// FPDT Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_FIRMWARE_PERFORMANCE_DATA_TABLE_REVISION = 0x01;

  ///
  /// FPDT Performance Record Types
  ///
  public const ulong EFI_ACPI_6_2_FPDT_RECORD_TYPE_FIRMWARE_BASIC_BOOT_POINTER = 0x0000;
  public const ulong EFI_ACPI_6_2_FPDT_RECORD_TYPE_S3_PERFORMANCE_TABLE_POINTER = 0x0001;

  ///
  /// FPDT Performance Record Revision
  ///
  public const ulong EFI_ACPI_6_2_FPDT_RECORD_REVISION_FIRMWARE_BASIC_BOOT_POINTER = 0x01;
  public const ulong EFI_ACPI_6_2_FPDT_RECORD_REVISION_S3_PERFORMANCE_TABLE_POINTER = 0x01;

  ///
  /// FPDT Runtime Performance Record Types
  ///
  public const ulong EFI_ACPI_6_2_FPDT_RUNTIME_RECORD_TYPE_S3_RESUME = 0x0000;
  public const ulong EFI_ACPI_6_2_FPDT_RUNTIME_RECORD_TYPE_S3_SUSPEND = 0x0001;
  public const ulong EFI_ACPI_6_2_FPDT_RUNTIME_RECORD_TYPE_FIRMWARE_BASIC_BOOT = 0x0002;

  ///
  /// FPDT Runtime Performance Record Revision
  ///
  public const ulong EFI_ACPI_6_2_FPDT_RUNTIME_RECORD_REVISION_S3_RESUME = 0x01;
  public const ulong EFI_ACPI_6_2_FPDT_RUNTIME_RECORD_REVISION_S3_SUSPEND = 0x01;
  public const ulong EFI_ACPI_6_2_FPDT_RUNTIME_RECORD_REVISION_FIRMWARE_BASIC_BOOT = 0x02;
}

///
/// FPDT Performance Record header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_FPDT_PERFORMANCE_RECORD_HEADER
{
  public ushort Type;
  public byte Length;
  public byte Revision;
}

///
/// FPDT Performance Table header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_FPDT_PERFORMANCE_TABLE_HEADER
{
  public uint Signature;
  public uint Length;
}

///
/// FPDT Firmware Basic Boot Performance Pointer Record Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_FPDT_BOOT_PERFORMANCE_TABLE_POINTER_RECORD
{
  public EFI_ACPI_6_2_FPDT_PERFORMANCE_RECORD_HEADER Header;
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
public unsafe struct EFI_ACPI_6_2_FPDT_S3_PERFORMANCE_TABLE_POINTER_RECORD
{
  public EFI_ACPI_6_2_FPDT_PERFORMANCE_RECORD_HEADER Header;
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
public unsafe struct EFI_ACPI_6_2_FPDT_FIRMWARE_BASIC_BOOT_RECORD
{
  public EFI_ACPI_6_2_FPDT_PERFORMANCE_RECORD_HEADER Header;
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

public unsafe partial class EFI
{
  ///
  /// FPDT Firmware Basic Boot Performance Table signature
  ///
  public const ulong EFI_ACPI_6_2_FPDT_BOOT_PERFORMANCE_TABLE_SIGNATURE = SIGNATURE_32('F', 'B', 'P', 'T');
}

//
// FPDT Firmware Basic Boot Performance Table
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_FPDT_FIRMWARE_BASIC_BOOT_TABLE
{
  public EFI_ACPI_6_2_FPDT_PERFORMANCE_TABLE_HEADER Header;
  //
  // one or more Performance Records.
  //
}

public unsafe partial class EFI
{
  ///
  /// FPDT "S3PT" S3 Performance Table
  ///
  public const ulong EFI_ACPI_6_2_FPDT_S3_PERFORMANCE_TABLE_SIGNATURE = SIGNATURE_32('S', '3', 'P', 'T');
}

//
// FPDT Firmware S3 Boot Performance Table
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_FPDT_FIRMWARE_S3_BOOT_TABLE
{
  public EFI_ACPI_6_2_FPDT_PERFORMANCE_TABLE_HEADER Header;
  //
  // one or more Performance Records.
  //
}

///
/// FPDT Basic S3 Resume Performance Record
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_FPDT_S3_RESUME_RECORD
{
  public EFI_ACPI_6_2_FPDT_PERFORMANCE_RECORD_HEADER Header;
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
public unsafe struct EFI_ACPI_6_2_FPDT_S3_SUSPEND_RECORD
{
  public EFI_ACPI_6_2_FPDT_PERFORMANCE_RECORD_HEADER Header;
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
public unsafe struct EFI_ACPI_6_2_FIRMWARE_PERFORMANCE_RECORD_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
}

///
/// Generic Timer Description Table definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GENERIC_TIMER_DESCRIPTION_TABLE
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

public unsafe partial class EFI
{
  ///
  /// GTDT Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_GENERIC_TIMER_DESCRIPTION_TABLE_REVISION = 0x02;

  ///
  /// Timer Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_6_2_GTDT_TIMER_FLAG_TIMER_INTERRUPT_MODE = BIT0;
  public const ulong EFI_ACPI_6_2_GTDT_TIMER_FLAG_TIMER_INTERRUPT_POLARITY = BIT1;
  public const ulong EFI_ACPI_6_2_GTDT_TIMER_FLAG_ALWAYS_ON_CAPABILITY = BIT2;

  ///
  /// Platform Timer Type
  ///
  public const ulong EFI_ACPI_6_2_GTDT_GT_BLOCK = 0;
  public const ulong EFI_ACPI_6_2_GTDT_SBSA_GENERIC_WATCHDOG = 1;
}

///
/// GT Block Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GTDT_GT_BLOCK_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_GTDT_GT_BLOCK_TIMER_STRUCTURE
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

public unsafe partial class EFI
{
  ///
  /// GT Block Physical Timers and Virtual Timers Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_6_2_GTDT_GT_BLOCK_TIMER_FLAG_TIMER_INTERRUPT_MODE = BIT0;
  public const ulong EFI_ACPI_6_2_GTDT_GT_BLOCK_TIMER_FLAG_TIMER_INTERRUPT_POLARITY = BIT1;

  ///
  /// Common Flags Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_6_2_GTDT_GT_BLOCK_COMMON_FLAG_SECURE_TIMER = BIT0;
  public const ulong EFI_ACPI_6_2_GTDT_GT_BLOCK_COMMON_FLAG_ALWAYS_ON_CAPABILITY = BIT1;
}

///
/// SBSA Generic Watchdog Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GTDT_SBSA_GENERIC_WATCHDOG_STRUCTURE
{
  public byte Type;
  public ushort Length;
  public byte Reserved;
  public ulong RefreshFramePhysicalAddress;
  public ulong WatchdogControlFramePhysicalAddress;
  public uint WatchdogTimerGSIV;
  public uint WatchdogTimerFlags;
}

public unsafe partial class EFI
{
  ///
  /// SBSA Generic Watchdog Timer Flags.  All other bits are reserved and must be 0.
  ///
  public const ulong EFI_ACPI_6_2_GTDT_SBSA_GENERIC_WATCHDOG_FLAG_TIMER_INTERRUPT_MODE = BIT0;
  public const ulong EFI_ACPI_6_2_GTDT_SBSA_GENERIC_WATCHDOG_FLAG_TIMER_INTERRUPT_POLARITY = BIT1;
  public const ulong EFI_ACPI_6_2_GTDT_SBSA_GENERIC_WATCHDOG_FLAG_SECURE_TIMER = BIT2;
}

//
// NVDIMM Firmware Interface Table definition.
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NVDIMM_FIRMWARE_INTERFACE_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint Reserved;
}

public unsafe partial class EFI
{
  //
  // NFIT Version (as defined in ACPI 6.2 spec.)
  //
  public const ulong EFI_ACPI_6_2_NVDIMM_FIRMWARE_INTERFACE_TABLE_REVISION = 0x1;

  //
  // Definition for NFIT Table Structure Types
  //
  public const ulong EFI_ACPI_6_2_NFIT_SYSTEM_PHYSICAL_ADDRESS_RANGE_STRUCTURE_TYPE = 0;
  public const ulong EFI_ACPI_6_2_NFIT_NVDIMM_REGION_MAPPING_STRUCTURE_TYPE = 1;
  public const ulong EFI_ACPI_6_2_NFIT_INTERLEAVE_STRUCTURE_TYPE = 2;
  public const ulong EFI_ACPI_6_2_NFIT_SMBIOS_MANAGEMENT_INFORMATION_STRUCTURE_TYPE = 3;
  public const ulong EFI_ACPI_6_2_NFIT_NVDIMM_CONTROL_REGION_STRUCTURE_TYPE = 4;
  public const ulong EFI_ACPI_6_2_NFIT_NVDIMM_BLOCK_DATA_WINDOW_REGION_STRUCTURE_TYPE = 5;
  public const ulong EFI_ACPI_6_2_NFIT_FLUSH_HINT_ADDRESS_STRUCTURE_TYPE = 6;
  public const ulong EFI_ACPI_6_2_NFIT_PLATFORM_CAPABILITIES_STRUCTURE_TYPE = 7;
}

//
// Definition for NFIT Structure Header
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NFIT_STRUCTURE_HEADER
{
  public ushort Type;
  public ushort Length;
}

public unsafe partial class EFI
{
  //
  // Definition for System Physical Address Range Structure
  //
  public const ulong EFI_ACPI_6_2_NFIT_SYSTEM_PHYSICAL_ADDRESS_RANGE_FLAGS_CONTROL_REGION_FOR_MANAGEMENT = BIT0;
  public const ulong EFI_ACPI_6_2_NFIT_SYSTEM_PHYSICAL_ADDRESS_RANGE_FLAGS_PROXIMITY_DOMAIN_VALID = BIT1;
  public const ulong EFI_ACPI_6_2_NFIT_GUID_VOLATILE_MEMORY_REGION = { 0x7305944F, 0xFDDA, 0x44E3, { 0xB1, 0x6C, 0x3F, 0x22, 0xD2, 0x52, 0xE5, 0xD0 } };
  public const ulong EFI_ACPI_6_2_NFIT_GUID_BYTE_ADDRESSABLE_PERSISTENT_MEMORY_REGION = { 0x66F0D379, 0xB4F3, 0x4074, { 0xAC, 0x43, 0x0D, 0x33, 0x18, 0xB7, 0x8C, 0xDB } };
  public const ulong EFI_ACPI_6_2_NFIT_GUID_NVDIMM_CONTROL_REGION = { 0x92F701F6, 0x13B4, 0x405D, { 0x91, 0x0B, 0x29, 0x93, 0x67, 0xE8, 0x23, 0x4C } };
  public const ulong EFI_ACPI_6_2_NFIT_GUID_NVDIMM_BLOCK_DATA_WINDOW_REGION = { 0x91AF0530, 0x5D86, 0x470E, { 0xA6, 0xB0, 0x0A, 0x2D, 0xB9, 0x40, 0x82, 0x49 } };
  public const ulong EFI_ACPI_6_2_NFIT_GUID_RAM_DISK_SUPPORTING_VIRTUAL_DISK_REGION_VOLATILE = { 0x77AB535A, 0x45FC, 0x624B, { 0x55, 0x60, 0xF7, 0xB2, 0x81, 0xD1, 0xF9, 0x6E } };
  public const ulong EFI_ACPI_6_2_NFIT_GUID_RAM_DISK_SUPPORTING_VIRTUAL_CD_REGION_VOLATILE = { 0x3D5ABD30, 0x4175, 0x87CE, { 0x6D, 0x64, 0xD2, 0xAD, 0xE5, 0x23, 0xC4, 0xBB } };
  public const ulong EFI_ACPI_6_2_NFIT_GUID_RAM_DISK_SUPPORTING_VIRTUAL_DISK_REGION_PERSISTENT = { 0x5CEA02C9, 0x4D07, 0x69D3, { 0x26, 0x9F, 0x44, 0x96, 0xFB, 0xE0, 0x96, 0xF9 } };
  public const ulong EFI_ACPI_6_2_NFIT_GUID_RAM_DISK_SUPPORTING_VIRTUAL_CD_REGION_PERSISTENT = { 0x08018188, 0x42CD, 0xBB48, { 0x10, 0x0F, 0x53, 0x87, 0xD5, 0x3D, 0xED, 0x3D } };
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NFIT_SYSTEM_PHYSICAL_ADDRESS_RANGE_STRUCTURE
{
  public ushort Type;
  public ushort Length;
  public ushort SPARangeStructureIndex;
  public ushort Flags;
  public uint Reserved_8;
  public uint ProximityDomain;
  public GUID AddressRangeTypeGUID;
  public ulong SystemPhysicalAddressRangeBase;
  public ulong SystemPhysicalAddressRangeLength;
  public ulong AddressRangeMemoryMappingAttribute;
}

//
// Definition for Memory Device to System Physical Address Range Mapping Structure
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NFIT_DEVICE_HANDLE
{
  public uint DIMMNumber; // = 4;
  public uint MemoryChannelNumber; // = 4;
  public uint MemoryControllerID; // = 4;
  public uint SocketID; // = 4;
  public uint NodeControllerID; // = 12;
  public uint Reserved_28; // = 4;
}

public unsafe partial class EFI
{
  public const ulong EFI_ACPI_6_2_NFIT_MEMORY_DEVICE_STATE_FLAGS_PREVIOUS_SAVE_FAIL = BIT0;
  public const ulong EFI_ACPI_6_2_NFIT_MEMORY_DEVICE_STATE_FLAGS_LAST_RESTORE_FAIL = BIT1;
  public const ulong EFI_ACPI_6_2_NFIT_MEMORY_DEVICE_STATE_FLAGS_PLATFORM_FLUSH_FAIL = BIT2;
  public const ulong EFI_ACPI_6_2_NFIT_MEMORY_DEVICE_STATE_FLAGS_NOT_ARMED_PRIOR_TO_OSPM_HAND_OFF = BIT3;
  public const ulong EFI_ACPI_6_2_NFIT_MEMORY_DEVICE_STATE_FLAGS_SMART_HEALTH_EVENTS_PRIOR_OSPM_HAND_OFF = BIT4;
  public const ulong EFI_ACPI_6_2_NFIT_MEMORY_DEVICE_STATE_FLAGS_FIRMWARE_ENABLED_TO_NOTIFY_OSPM_ON_SMART_HEALTH_EVENTS = BIT5;
  public const ulong EFI_ACPI_6_2_NFIT_MEMORY_DEVICE_STATE_FLAGS_FIRMWARE_NOT_MAP_NVDIMM_TO_SPA = BIT6;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NFIT_NVDIMM_REGION_MAPPING_STRUCTURE
{
  public ushort Type;
  public ushort Length;
  public EFI_ACPI_6_2_NFIT_DEVICE_HANDLE NFITDeviceHandle;
  public ushort NVDIMMPhysicalID;
  public ushort NVDIMMRegionID;
  public ushort SPARangeStructureIndex;
  public ushort NVDIMMControlRegionStructureIndex;
  public ulong NVDIMMRegionSize;
  public ulong RegionOffset;
  public ulong NVDIMMPhysicalAddressRegionBase;
  public ushort InterleaveStructureIndex;
  public ushort InterleaveWays;
  public ushort NVDIMMStateFlags;
  public ushort Reserved_46;
}

//
// Definition for Interleave Structure
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NFIT_INTERLEAVE_STRUCTURE
{
  public ushort Type;
  public ushort Length;
  public ushort InterleaveStructureIndex;
  public ushort Reserved_6;
  public uint NumberOfLines;
  public uint LineSize;
  // uint                                      LineOffset[NumberOfLines];
}

//
// Definition for SMBIOS Management Information Structure
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NFIT_SMBIOS_MANAGEMENT_INFORMATION_STRUCTURE
{
  public ushort Type;
  public ushort Length;
  public uint Reserved_4;
  // byte                                       Data[];
}

public unsafe partial class EFI
{
  //
  // Definition for NVDIMM Control Region Structure
  //
  public const ulong EFI_ACPI_6_2_NFIT_NVDIMM_CONTROL_REGION_VALID_FIELDS_MANUFACTURING = BIT0;
}

public const ulong EFI_ACPI_6_2_NFIT_NVDIMM_CONTROL_REGION_FLAGS_BLOCK_DATA_WINDOWS_BUFFERED = BIT0;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NFIT_NVDIMM_CONTROL_REGION_STRUCTURE
{
  public ushort Type;
  public ushort Length;
  public ushort NVDIMMControlRegionStructureIndex;
  public ushort VendorID;
  public ushort DeviceID;
  public ushort RevisionID;
  public ushort SubsystemVendorID;
  public ushort SubsystemDeviceID;
  public ushort SubsystemRevisionID;
  public byte ValidFields;
  public byte ManufacturingLocation;
  public ushort ManufacturingDate;
  public fixed byte Reserved_22[2];
  public uint SerialNumber;
  public ushort RegionFormatInterfaceCode;
  public ushort NumberOfBlockControlWindows;
  public ulong SizeOfBlockControlWindow;
  public ulong CommandRegisterOffsetInBlockControlWindow;
  public ulong SizeOfCommandRegisterInBlockControlWindows;
  public ulong StatusRegisterOffsetInBlockControlWindow;
  public ulong SizeOfStatusRegisterInBlockControlWindows;
  public ushort NVDIMMControlRegionFlag;
  public fixed byte Reserved_74[6];
}

//
// Definition for NVDIMM Block Data Window Region Structure
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NFIT_NVDIMM_BLOCK_DATA_WINDOW_REGION_STRUCTURE
{
  public ushort Type;
  public ushort Length;
  public ushort NVDIMMControlRegionStructureIndex;
  public ushort NumberOfBlockDataWindows;
  public ulong BlockDataWindowStartOffset;
  public ulong SizeOfBlockDataWindow;
  public ulong BlockAccessibleMemoryCapacity;
  public ulong BeginningAddressOfFirstBlockInBlockAccessibleMemory;
}

//
// Definition for Flush Hint Address Structure
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NFIT_FLUSH_HINT_ADDRESS_STRUCTURE
{
  public ushort Type;
  public ushort Length;
  public EFI_ACPI_6_2_NFIT_DEVICE_HANDLE NFITDeviceHandle;
  public ushort NumberOfFlushHintAddresses;
  public fixed byte Reserved_10[6];
  // ulong                                      FlushHintAddress[NumberOfFlushHintAddresses];
}

//
// Definition for Platform Capabilities Structure
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_NFIT_PLATFORM_CAPABILITIES_STRUCTURE
{
  public ushort Type;
  public ushort Length;
  public byte HighestValidCapability;
  public fixed byte Reserved_5[3];
  public uint Capabilities;
  public fixed byte Reserved_12[4];
}

public unsafe partial class EFI
{
  public const ulong EFI_ACPI_6_2_NFIT_PLATFORM_CAPABILITY_CPU_CACHE_FLUSH_TO_NVDIMM_DURABILITY_ON_POWER_LOSS = BIT0;
  public const ulong EFI_ACPI_6_2_NFIT_PLATFORM_CAPABILITY_MEMORY_CONTROLLER_FLUSH_TO_NVDIMM_DURABILITY_ON_POWER_LOSS = BIT1;
  public const ulong EFI_ACPI_6_2_NFIT_PLATFORM_CAPABILITY_BYTE_ADDRESSABLE_PERSISTENT_MEMORY_HARDWARE_MIRRORING = BIT2;
}

///
/// Secure DEVices Table (SDEV)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_SECURE_DEVICES_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
}

public unsafe partial class EFI
{
  ///
  /// SDEV Revision (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_SECURE_DEVICES_TABLE_REVISION = 0x01;

  ///
  /// Secure Device types
  ///
  public const ulong EFI_ACPI_6_2_SDEV_TYPE_PCIE_ENDPOINT_DEVICE = 0x01;
  public const ulong EFI_ACPI_6_2_SDEV_TYPE_ACPI_NAMESPACE_DEVICE = 0x00;

  ///
  /// Secure Device flags
  ///
  public const ulong EFI_ACPI_6_2_SDEV_FLAG_ALLOW_HANDOFF = BIT0;
}

///
/// SDEV Structure Header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_SDEV_STRUCTURE_HEADER
{
  public byte Type;
  public byte Flags;
  public ushort Length;
}

///
/// PCIe Endpoint Device based Secure Device Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_SDEV_STRUCTURE_PCIE_ENDPOINT_DEVICE
{
  public byte Type;
  public byte Flags;
  public ushort Length;
  public ushort PciSegmentNumber;
  public ushort StartBusNumber;
  public ushort PciPathOffset;
  public ushort PciPathLength;
  public ushort VendorSpecificDataOffset;
  public ushort VendorSpecificDataLength;
}

///
/// ACPI_NAMESPACE_DEVICE based Secure Device Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_SDEV_STRUCTURE_ACPI_NAMESPACE_DEVICE
{
  public byte Type;
  public byte Flags;
  public ushort Length;
  public ushort DeviceIdentifierOffset;
  public ushort DeviceIdentifierLength;
  public ushort VendorSpecificDataOffset;
  public ushort VendorSpecificDataLength;
}

///
/// Boot Error Record Table (BERT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_BOOT_ERROR_RECORD_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint BootErrorRegionLength;
  public ulong BootErrorRegion;
}

public unsafe partial class EFI
{
  ///
  /// BERT Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_BOOT_ERROR_RECORD_TABLE_REVISION = 0x01;
}

///
/// Boot Error Region Block Status Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_ERROR_BLOCK_STATUS
{
  public uint UncorrectableErrorValid; // = 1;
  public uint CorrectableErrorValid; // = 1;
  public uint MultipleUncorrectableErrors; // = 1;
  public uint MultipleCorrectableErrors; // = 1;
  public uint ErrorDataEntryCount; // = 10;
  public uint Reserved; // = 18;
}

///
/// Boot Error Region Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_BOOT_ERROR_REGION_STRUCTURE
{
  public EFI_ACPI_6_2_ERROR_BLOCK_STATUS BlockStatus;
  public uint RawDataOffset;
  public uint RawDataLength;
  public uint DataLength;
  public uint ErrorSeverity;
}

public unsafe partial class EFI
{
  //
  // Boot Error Severity types
  //
  public const ulong EFI_ACPI_6_2_ERROR_SEVERITY_RECOVERABLE = 0x00;
  public const ulong EFI_ACPI_6_2_ERROR_SEVERITY_FATAL = 0x01;
  public const ulong EFI_ACPI_6_2_ERROR_SEVERITY_CORRECTED = 0x02;
  public const ulong EFI_ACPI_6_2_ERROR_SEVERITY_NONE = 0x03;
  //
  // The term 'Correctable' is no longer being used as an error severity of the
  // reported error since ACPI Specification Version 5.1 Errata B.
  // The below macro is considered as deprecated and should no longer be used.
  //
  public const ulong EFI_ACPI_6_2_ERROR_SEVERITY_CORRECTABLE = 0x00;
}

///
/// Generic Error Data Entry Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GENERIC_ERROR_DATA_ENTRY_STRUCTURE
{
  public fixed byte SectionType[16];
  public uint ErrorSeverity;
  public ushort Revision;
  public byte ValidationBits;
  public byte Flags;
  public uint ErrorDataLength;
  public fixed byte FruId[16];
  public fixed byte FruText[20];
  public fixed byte Timestamp[8];
}

public unsafe partial class EFI
{
  ///
  /// Generic Error Data Entry Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_GENERIC_ERROR_DATA_ENTRY_REVISION = 0x0300;
}

///
/// HEST - Hardware Error Source Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HARDWARE_ERROR_SOURCE_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint ErrorSourceCount;
}

public unsafe partial class EFI
{
  ///
  /// HEST Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_SOURCE_TABLE_REVISION = 0x01;

  //
  // Error Source structure types.
  //
  public const ulong EFI_ACPI_6_2_IA32_ARCHITECTURE_MACHINE_CHECK_EXCEPTION = 0x00;
  public const ulong EFI_ACPI_6_2_IA32_ARCHITECTURE_CORRECTED_MACHINE_CHECK = 0x01;
  public const ulong EFI_ACPI_6_2_IA32_ARCHITECTURE_NMI_ERROR = 0x02;
  public const ulong EFI_ACPI_6_2_PCI_EXPRESS_ROOT_PORT_AER = 0x06;
  public const ulong EFI_ACPI_6_2_PCI_EXPRESS_DEVICE_AER = 0x07;
  public const ulong EFI_ACPI_6_2_PCI_EXPRESS_BRIDGE_AER = 0x08;
  public const ulong EFI_ACPI_6_2_GENERIC_HARDWARE_ERROR = 0x09;
  public const ulong EFI_ACPI_6_2_GENERIC_HARDWARE_ERROR_VERSION_2 = 0x0A;
  public const ulong EFI_ACPI_6_2_IA32_ARCHITECTURE_DEFERRED_MACHINE_CHECK = 0x0B;

  //
  // Error Source structure flags.
  //
  public const ulong EFI_ACPI_6_2_ERROR_SOURCE_FLAG_FIRMWARE_FIRST = (1 << 0);
  public const ulong EFI_ACPI_6_2_ERROR_SOURCE_FLAG_GLOBAL = (1 << 1);
  public const ulong EFI_ACPI_6_2_ERROR_SOURCE_FLAG_GHES_ASSIST = (1 << 2);
}

///
/// IA-32 Architecture Machine Check Exception Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_IA32_ARCHITECTURE_MACHINE_CHECK_EXCEPTION_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_BANK_STRUCTURE
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

public unsafe partial class EFI
{
  ///
  /// IA-32 Architecture Machine Check Bank Structure MCA data format
  ///
  public const ulong EFI_ACPI_6_2_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_DATA_FORMAT_IA32 = 0x00;
  public const ulong EFI_ACPI_6_2_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_DATA_FORMAT_INTEL64 = 0x01;
  public const ulong EFI_ACPI_6_2_IA32_ARCHITECTURE_MACHINE_CHECK_ERROR_DATA_FORMAT_AMD64 = 0x02;

  //
  // Hardware Error Notification types. All other values are reserved
  //
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_POLLED = 0x00;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_EXTERNAL_INTERRUPT = 0x01;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_LOCAL_INTERRUPT = 0x02;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_SCI = 0x03;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_NMI = 0x04;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_CMCI = 0x05;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_MCE = 0x06;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_GPIO_SIGNAL = 0x07;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_ARMV8_SEA = 0x08;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_ARMV8_SEI = 0x09;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_GSIV = 0x0A;
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_SOFTWARE_DELEGATED_EXCEPTION = 0x0B;
}

///
/// Hardware Error Notification Configuration Write Enable Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_CONFIGURATION_WRITE_ENABLE_STRUCTURE
{
  public ushort Type; // = 1;
  public ushort PollInterval; // = 1;
  public ushort SwitchToPollingThresholdValue; // = 1;
  public ushort SwitchToPollingThresholdWindow; // = 1;
  public ushort ErrorThresholdValue; // = 1;
  public ushort ErrorThresholdWindow; // = 1;
  public ushort Reserved; // = 10;
}

///
/// Hardware Error Notification Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_STRUCTURE
{
  public byte Type;
  public byte Length;
  public EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_CONFIGURATION_WRITE_ENABLE_STRUCTURE ConfigurationWriteEnable;
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
public unsafe struct EFI_ACPI_6_2_IA32_ARCHITECTURE_CORRECTED_MACHINE_CHECK_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public fixed byte Reserved0[2];
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_STRUCTURE NotificationStructure;
  public byte NumberOfHardwareBanks;
  public fixed byte Reserved1[3];
}

///
/// IA-32 Architecture NMI Error Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_IA32_ARCHITECTURE_NMI_ERROR_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_PCI_EXPRESS_ROOT_PORT_AER_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_PCI_EXPRESS_DEVICE_AER_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_PCI_EXPRESS_BRIDGE_AER_STRUCTURE
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
public unsafe struct EFI_ACPI_6_2_GENERIC_HARDWARE_ERROR_SOURCE_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public ushort RelatedSourceId;
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public uint MaxRawDataLength;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE ErrorStatusAddress;
  public EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_STRUCTURE NotificationStructure;
  public uint ErrorStatusBlockLength;
}

///
/// Generic Hardware Error Source Version 2 Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GENERIC_HARDWARE_ERROR_SOURCE_VERSION_2_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public ushort RelatedSourceId;
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public uint MaxRawDataLength;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE ErrorStatusAddress;
  public EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_STRUCTURE NotificationStructure;
  public uint ErrorStatusBlockLength;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE ReadAckRegister;
  public ulong ReadAckPreserve;
  public ulong ReadAckWrite;
}

///
/// Generic Error Status Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_GENERIC_ERROR_STATUS_STRUCTURE
{
  public EFI_ACPI_6_2_ERROR_BLOCK_STATUS BlockStatus;
  public uint RawDataOffset;
  public uint RawDataLength;
  public uint DataLength;
  public uint ErrorSeverity;
}

///
/// IA-32 Architecture Deferred Machine Check Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_IA32_ARCHITECTURE_DEFERRED_MACHINE_CHECK_STRUCTURE
{
  public ushort Type;
  public ushort SourceId;
  public fixed byte Reserved0[2];
  public byte Flags;
  public byte Enabled;
  public uint NumberOfRecordsToPreAllocate;
  public uint MaxSectionsPerRecord;
  public EFI_ACPI_6_2_HARDWARE_ERROR_NOTIFICATION_STRUCTURE NotificationStructure;
  public byte NumberOfHardwareBanks;
  public fixed byte Reserved1[3];
}

///
/// HMAT - Heterogeneous Memory Attribute Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HETEROGENEOUS_MEMORY_ATTRIBUTE_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public fixed byte Reserved[4];
}

public unsafe partial class EFI
{
  ///
  /// HMAT Revision (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_HETEROGENEOUS_MEMORY_ATTRIBUTE_TABLE_REVISION = 0x01;

  ///
  /// HMAT types
  ///
  public const ulong EFI_ACPI_6_2_HMAT_TYPE_MEMORY_SUBSYSTEM_ADDRESS_RANGE = 0x00;
  public const ulong EFI_ACPI_6_2_HMAT_TYPE_SYSTEM_LOCALITY_LATENCY_AND_BANDWIDTH_INFO = 0x01;
  public const ulong EFI_ACPI_6_2_HMAT_TYPE_MEMORY_SIDE_CACHE_INFO = 0x02;
}

///
/// HMAT Structure Header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HMAT_STRUCTURE_HEADER
{
  public ushort Type;
  public fixed byte Reserved[2];
  public uint Length;
}

///
/// Memory Subsystem Address Range Structure flags
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HMAT_STRUCTURE_MEMORY_SUBSYSTEM_ADDRESS_RANGE_FLAGS
{
  public ushort ProcessorProximityDomainValid; // = 1;
  public ushort MemoryProximityDomainValid; // = 1;
  public ushort ReservationHint; // = 1;
  public ushort Reserved; // = 13;
}

///
/// Memory Subsystem Address Range Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HMAT_STRUCTURE_MEMORY_SUBSYSTEM_ADDRESS_RANGE
{
  public ushort Type;
  public fixed byte Reserved[2];
  public uint Length;
  public EFI_ACPI_6_2_HMAT_STRUCTURE_MEMORY_SUBSYSTEM_ADDRESS_RANGE_FLAGS Flags;
  public fixed byte Reserved1[2];
  public uint ProcessorProximityDomain;
  public uint MemoryProximityDomain;
  public fixed byte Reserved2[4];
  public ulong SystemPhysicalAddressRangeBase;
  public ulong SystemPhysicalAddressRangeLength;
}

///
/// System Locality Latency and Bandwidth Information Structure flags
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HMAT_STRUCTURE_SYSTEM_LOCALITY_LATENCY_AND_BANDWIDTH_INFO_FLAGS
{
  public byte MemoryHierarchy; // = 5;
  public byte Reserved; // = 3;
}

///
/// System Locality Latency and Bandwidth Information Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HMAT_STRUCTURE_SYSTEM_LOCALITY_LATENCY_AND_BANDWIDTH_INFO
{
  public ushort Type;
  public fixed byte Reserved[2];
  public uint Length;
  public EFI_ACPI_6_2_HMAT_STRUCTURE_SYSTEM_LOCALITY_LATENCY_AND_BANDWIDTH_INFO_FLAGS Flags;
  public byte DataType;
  public fixed byte Reserved1[2];
  public uint NumberOfInitiatorProximityDomains;
  public uint NumberOfTargetProximityDomains;
  public fixed byte Reserved2[4];
  public ulong EntryBaseUnit;
}

///
/// Memory Side Cache Information Structure cache attributes
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HMAT_STRUCTURE_MEMORY_SIDE_CACHE_INFO_CACHE_ATTRIBUTES
{
  public uint TotalCacheLevels; // = 4;
  public uint CacheLevel; // = 4;
  public uint CacheAssociativity; // = 4;
  public uint WritePolicy; // = 4;
  public uint CacheLineSize; // = 16;
}

///
/// Memory Side Cache Information Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_HMAT_STRUCTURE_MEMORY_SIDE_CACHE_INFO
{
  public ushort Type;
  public fixed byte Reserved[2];
  public uint Length;
  public uint MemoryProximityDomain;
  public fixed byte Reserved1[4];
  public ulong MemorySideCacheSize;
  public EFI_ACPI_6_2_HMAT_STRUCTURE_MEMORY_SIDE_CACHE_INFO_CACHE_ATTRIBUTES CacheAttributes;
  public fixed byte Reserved2[2];
  public ushort NumberOfSmbiosHandles;
}

///
/// ERST - Error Record Serialization Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_ERROR_RECORD_SERIALIZATION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint SerializationHeaderSize;
  public fixed byte Reserved0[4];
  public uint InstructionEntryCount;
}

public unsafe partial class EFI
{
  ///
  /// ERST Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_ERROR_RECORD_SERIALIZATION_TABLE_REVISION = 0x01;

  ///
  /// ERST Serialization Actions
  ///
  public const ulong EFI_ACPI_6_2_ERST_BEGIN_WRITE_OPERATION = 0x00;
  public const ulong EFI_ACPI_6_2_ERST_BEGIN_READ_OPERATION = 0x01;
  public const ulong EFI_ACPI_6_2_ERST_BEGIN_CLEAR_OPERATION = 0x02;
  public const ulong EFI_ACPI_6_2_ERST_END_OPERATION = 0x03;
  public const ulong EFI_ACPI_6_2_ERST_SET_RECORD_OFFSET = 0x04;
  public const ulong EFI_ACPI_6_2_ERST_EXECUTE_OPERATION = 0x05;
  public const ulong EFI_ACPI_6_2_ERST_CHECK_BUSY_STATUS = 0x06;
  public const ulong EFI_ACPI_6_2_ERST_GET_COMMAND_STATUS = 0x07;
  public const ulong EFI_ACPI_6_2_ERST_GET_RECORD_IDENTIFIER = 0x08;
  public const ulong EFI_ACPI_6_2_ERST_SET_RECORD_IDENTIFIER = 0x09;
  public const ulong EFI_ACPI_6_2_ERST_GET_RECORD_COUNT = 0x0A;
  public const ulong EFI_ACPI_6_2_ERST_BEGIN_DUMMY_WRITE_OPERATION = 0x0B;
  public const ulong EFI_ACPI_6_2_ERST_GET_ERROR_LOG_ADDRESS_RANGE = 0x0D;
  public const ulong EFI_ACPI_6_2_ERST_GET_ERROR_LOG_ADDRESS_RANGE_LENGTH = 0x0E;
  public const ulong EFI_ACPI_6_2_ERST_GET_ERROR_LOG_ADDRESS_RANGE_ATTRIBUTES = 0x0F;
  public const ulong EFI_ACPI_6_2_ERST_GET_EXECUTE_OPERATION_TIMINGS = 0x10;

  ///
  /// ERST Action Command Status
  ///
  public const ulong EFI_ACPI_6_2_ERST_STATUS_SUCCESS = 0x00;
  public const ulong EFI_ACPI_6_2_ERST_STATUS_NOT_ENOUGH_SPACE = 0x01;
  public const ulong EFI_ACPI_6_2_ERST_STATUS_HARDWARE_NOT_AVAILABLE = 0x02;
  public const ulong EFI_ACPI_6_2_ERST_STATUS_FAILED = 0x03;
  public const ulong EFI_ACPI_6_2_ERST_STATUS_RECORD_STORE_EMPTY = 0x04;
  public const ulong EFI_ACPI_6_2_ERST_STATUS_RECORD_NOT_FOUND = 0x05;

  ///
  /// ERST Serialization Instructions
  ///
  public const ulong EFI_ACPI_6_2_ERST_READ_REGISTER = 0x00;
  public const ulong EFI_ACPI_6_2_ERST_READ_REGISTER_VALUE = 0x01;
  public const ulong EFI_ACPI_6_2_ERST_WRITE_REGISTER = 0x02;
  public const ulong EFI_ACPI_6_2_ERST_WRITE_REGISTER_VALUE = 0x03;
  public const ulong EFI_ACPI_6_2_ERST_NOOP = 0x04;
  public const ulong EFI_ACPI_6_2_ERST_LOAD_VAR1 = 0x05;
  public const ulong EFI_ACPI_6_2_ERST_LOAD_VAR2 = 0x06;
  public const ulong EFI_ACPI_6_2_ERST_STORE_VAR1 = 0x07;
  public const ulong EFI_ACPI_6_2_ERST_ADD = 0x08;
  public const ulong EFI_ACPI_6_2_ERST_SUBTRACT = 0x09;
  public const ulong EFI_ACPI_6_2_ERST_ADD_VALUE = 0x0A;
  public const ulong EFI_ACPI_6_2_ERST_SUBTRACT_VALUE = 0x0B;
  public const ulong EFI_ACPI_6_2_ERST_STALL = 0x0C;
  public const ulong EFI_ACPI_6_2_ERST_STALL_WHILE_TRUE = 0x0D;
  public const ulong EFI_ACPI_6_2_ERST_SKIP_NEXT_INSTRUCTION_IF_TRUE = 0x0E;
  public const ulong EFI_ACPI_6_2_ERST_GOTO = 0x0F;
  public const ulong EFI_ACPI_6_2_ERST_SET_SRC_ADDRESS_BASE = 0x10;
  public const ulong EFI_ACPI_6_2_ERST_SET_DST_ADDRESS_BASE = 0x11;
  public const ulong EFI_ACPI_6_2_ERST_MOVE_DATA = 0x12;

  ///
  /// ERST Instruction Flags
  ///
  public const ulong EFI_ACPI_6_2_ERST_PRESERVE_REGISTER = 0x01;
}

///
/// ERST Serialization Instruction Entry
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_ERST_SERIALIZATION_INSTRUCTION_ENTRY
{
  public byte SerializationAction;
  public byte Instruction;
  public byte Flags;
  public byte Reserved0;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE RegisterRegion;
  public ulong Value;
  public ulong Mask;
}

///
/// EINJ - Error Injection Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_ERROR_INJECTION_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint InjectionHeaderSize;
  public byte InjectionFlags;
  public fixed byte Reserved0[3];
  public uint InjectionEntryCount;
}

public unsafe partial class EFI
{
  ///
  /// EINJ Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_ERROR_INJECTION_TABLE_REVISION = 0x01;

  ///
  /// EINJ Error Injection Actions
  ///
  public const ulong EFI_ACPI_6_2_EINJ_BEGIN_INJECTION_OPERATION = 0x00;
  public const ulong EFI_ACPI_6_2_EINJ_GET_TRIGGER_ERROR_ACTION_TABLE = 0x01;
  public const ulong EFI_ACPI_6_2_EINJ_SET_ERROR_TYPE = 0x02;
  public const ulong EFI_ACPI_6_2_EINJ_GET_ERROR_TYPE = 0x03;
  public const ulong EFI_ACPI_6_2_EINJ_END_OPERATION = 0x04;
  public const ulong EFI_ACPI_6_2_EINJ_EXECUTE_OPERATION = 0x05;
  public const ulong EFI_ACPI_6_2_EINJ_CHECK_BUSY_STATUS = 0x06;
  public const ulong EFI_ACPI_6_2_EINJ_GET_COMMAND_STATUS = 0x07;
  public const ulong EFI_ACPI_6_2_EINJ_TRIGGER_ERROR = 0xFF;

  ///
  /// EINJ Action Command Status
  ///
  public const ulong EFI_ACPI_6_2_EINJ_STATUS_SUCCESS = 0x00;
  public const ulong EFI_ACPI_6_2_EINJ_STATUS_UNKNOWN_FAILURE = 0x01;
  public const ulong EFI_ACPI_6_2_EINJ_STATUS_INVALID_ACCESS = 0x02;

  ///
  /// EINJ Error Type Definition
  ///
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_PROCESSOR_CORRECTABLE = (1 << 0);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_PROCESSOR_UNCORRECTABLE_NONFATAL = (1 << 1);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_PROCESSOR_UNCORRECTABLE_FATAL = (1 << 2);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_MEMORY_CORRECTABLE = (1 << 3);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_MEMORY_UNCORRECTABLE_NONFATAL = (1 << 4);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_MEMORY_UNCORRECTABLE_FATAL = (1 << 5);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_PCI_EXPRESS_CORRECTABLE = (1 << 6);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_PCI_EXPRESS_UNCORRECTABLE_NONFATAL = (1 << 7);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_PCI_EXPRESS_UNCORRECTABLE_FATAL = (1 << 8);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_PLATFORM_CORRECTABLE = (1 << 9);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_PLATFORM_UNCORRECTABLE_NONFATAL = (1 << 10);
  public const ulong EFI_ACPI_6_2_EINJ_ERROR_PLATFORM_UNCORRECTABLE_FATAL = (1 << 11);

  ///
  /// EINJ Injection Instructions
  ///
  public const ulong EFI_ACPI_6_2_EINJ_READ_REGISTER = 0x00;
  public const ulong EFI_ACPI_6_2_EINJ_READ_REGISTER_VALUE = 0x01;
  public const ulong EFI_ACPI_6_2_EINJ_WRITE_REGISTER = 0x02;
  public const ulong EFI_ACPI_6_2_EINJ_WRITE_REGISTER_VALUE = 0x03;
  public const ulong EFI_ACPI_6_2_EINJ_NOOP = 0x04;

  ///
  /// EINJ Instruction Flags
  ///
  public const ulong EFI_ACPI_6_2_EINJ_PRESERVE_REGISTER = 0x01;
}

///
/// EINJ Injection Instruction Entry
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_EINJ_INJECTION_INSTRUCTION_ENTRY
{
  public byte InjectionAction;
  public byte Instruction;
  public byte Flags;
  public byte Reserved0;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE RegisterRegion;
  public ulong Value;
  public ulong Mask;
}

///
/// EINJ Trigger Action Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_EINJ_TRIGGER_ACTION_TABLE
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
public unsafe struct EFI_ACPI_6_2_PLATFORM_COMMUNICATION_CHANNEL_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public uint Flags;
  public ulong Reserved;
}

public unsafe partial class EFI
{
  ///
  /// PCCT Version (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_PLATFORM_COMMUNICATION_CHANNEL_TABLE_REVISION = 0x02;

  ///
  /// PCCT Global Flags
  ///
  public const ulong EFI_ACPI_6_2_PCCT_FLAGS_PLATFORM_INTERRUPT = BIT0;

  //
  // PCCT Subspace type
  //
  public const ulong EFI_ACPI_6_2_PCCT_SUBSPACE_TYPE_GENERIC = 0x00;
  public const ulong EFI_ACPI_6_2_PCCT_SUBSPACE_TYPE_1_HW_REDUCED_COMMUNICATIONS = 0x01;
  public const ulong EFI_ACPI_6_2_PCCT_SUBSPACE_TYPE_2_HW_REDUCED_COMMUNICATIONS = 0x02;
  public const ulong EFI_ACPI_6_2_PCCT_SUBSPACE_TYPE_3_EXTENDED_PCC = 0x03;
  public const ulong EFI_ACPI_6_2_PCCT_SUBSPACE_TYPE_4_EXTENDED_PCC = 0x04;
}

///
/// PCC Subspace Structure Header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PCCT_SUBSPACE_HEADER
{
  public byte Type;
  public byte Length;
}

///
/// Generic Communications Subspace Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PCCT_SUBSPACE_GENERIC
{
  public byte Type;
  public byte Length;
  public fixed byte Reserved[6];
  public ulong BaseAddress;
  public ulong AddressLength;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE DoorbellRegister;
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
public unsafe struct EFI_ACPI_6_2_PCCT_GENERIC_SHARED_MEMORY_REGION_COMMAND
{
  public byte Command;
  public byte Reserved; // = 7;
  public byte NotifyOnCompletion; // = 1;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PCCT_GENERIC_SHARED_MEMORY_REGION_STATUS
{
  public byte CommandComplete; // = 1;
  public byte PlatformInterrupt; // = 1;
  public byte Error; // = 1;
  public byte PlatformNotification; // = 1;
  public byte Reserved; // = 4;
  public byte Reserved1;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PCCT_GENERIC_SHARED_MEMORY_REGION_HEADER
{
  public uint Signature;
  public EFI_ACPI_6_2_PCCT_GENERIC_SHARED_MEMORY_REGION_COMMAND Command;
  public EFI_ACPI_6_2_PCCT_GENERIC_SHARED_MEMORY_REGION_STATUS Status;
}

public unsafe partial class EFI
{
  public const ulong EFI_ACPI_6_2_PCCT_SUBSPACE_PLATFORM_INTERRUPT_FLAGS_POLARITY = BIT0;
  public const ulong EFI_ACPI_6_2_PCCT_SUBSPACE_PLATFORM_INTERRUPT_FLAGS_MODE = BIT1;
}

///
/// Type 1 HW-Reduced Communications Subspace Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PCCT_SUBSPACE_1_HW_REDUCED_COMMUNICATIONS
{
  public byte Type;
  public byte Length;
  public uint PlatformInterrupt;
  public byte PlatformInterruptFlags;
  public byte Reserved;
  public ulong BaseAddress;
  public ulong AddressLength;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE DoorbellRegister;
  public ulong DoorbellPreserve;
  public ulong DoorbellWrite;
  public uint NominalLatency;
  public uint MaximumPeriodicAccessRate;
  public ushort MinimumRequestTurnaroundTime;
}

///
/// Type 2 HW-Reduced Communications Subspace Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PCCT_SUBSPACE_2_HW_REDUCED_COMMUNICATIONS
{
  public byte Type;
  public byte Length;
  public uint PlatformInterrupt;
  public byte PlatformInterruptFlags;
  public byte Reserved;
  public ulong BaseAddress;
  public ulong AddressLength;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE DoorbellRegister;
  public ulong DoorbellPreserve;
  public ulong DoorbellWrite;
  public uint NominalLatency;
  public uint MaximumPeriodicAccessRate;
  public ushort MinimumRequestTurnaroundTime;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE PlatformInterruptAckRegister;
  public ulong PlatformInterruptAckPreserve;
  public ulong PlatformInterruptAckWrite;
}

///
/// Type 3 Extended PCC Subspace Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PCCT_SUBSPACE_3_EXTENDED_PCC
{
  public byte Type;
  public byte Length;
  public uint PlatformInterrupt;
  public byte PlatformInterruptFlags;
  public byte Reserved;
  public ulong BaseAddress;
  public uint AddressLength;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE DoorbellRegister;
  public ulong DoorbellPreserve;
  public ulong DoorbellWrite;
  public uint NominalLatency;
  public uint MaximumPeriodicAccessRate;
  public uint MinimumRequestTurnaroundTime;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE PlatformInterruptAckRegister;
  public ulong PlatformInterruptAckPreserve;
  public ulong PlatformInterruptAckSet;
  public fixed byte Reserved1[8];
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE CommandCompleteCheckRegister;
  public ulong CommandCompleteCheckMask;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE CommandCompleteUpdateRegister;
  public ulong CommandCompleteUpdatePreserve;
  public ulong CommandCompleteUpdateSet;
  public EFI_ACPI_6_2_GENERIC_ADDRESS_STRUCTURE ErrorStatusRegister;
  public ulong ErrorStatusMask;
}

///
/// Type 4 Extended PCC Subspace Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PCCT_SUBSPACE_4_EXTENDED_PCC { EFI_ACPI_6_2_PCCT_SUBSPACE_3_EXTENDED_PCC Value; public static implicit operator EFI_ACPI_6_2_PCCT_SUBSPACE_4_EXTENDED_PCC(EFI_ACPI_6_2_PCCT_SUBSPACE_3_EXTENDED_PCC value) => new EFI_ACPI_6_2_PCCT_SUBSPACE_4_EXTENDED_PCC() { Value = value }; public static implicit operator EFI_ACPI_6_2_PCCT_SUBSPACE_3_EXTENDED_PCC(EFI_ACPI_6_2_PCCT_SUBSPACE_4_EXTENDED_PCC value) => value.Value; }

public unsafe partial class EFI
{
  public const ulong EFI_ACPI_6_2_PCCT_MASTER_SLAVE_COMMUNICATIONS_CHANNEL_FLAGS_NOTIFY_ON_COMPLETION = BIT0;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PCCT_EXTENDED_PCC_SHARED_MEMORY_REGION_HEADER
{
  public uint Signature;
  public uint Flags;
  public uint Length;
  public uint Command;
}

///
/// Platform Debug Trigger Table (PDTT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PLATFORM_DEBUG_TRIGGER_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public byte TriggerCount;
  public fixed byte Reserved[3];
  public uint TriggerIdentifierArrayOffset;
}

public unsafe partial class EFI
{
  ///
  /// PDTT Revision (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_PLATFORM_DEBUG_TRIGGER_TABLE_REVISION = 0x00;
}

///
/// PDTT Platform Communication Channel Identifier Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PDTT_PCC_IDENTIFIER
{
  public ushort SubChannelIdentifer; // = 8;
  public ushort Runtime; // = 1;
  public ushort WaitForCompletion; // = 1;
  public ushort Reserved; // = 6;
}

public unsafe partial class EFI
{
  ///
  /// PCC Commands Codes used by Platform Debug Trigger Table
  ///
  public const ulong EFI_ACPI_6_2_PDTT_PCC_COMMAND_DOORBELL_ONLY = 0x00;
  public const ulong EFI_ACPI_6_2_PDTT_PCC_COMMAND_VENDOR_SPECIFIC = 0x01;
}

///
/// PPTT Platform Communication Channel
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PDTT_PCC { EFI_ACPI_6_2_PCCT_GENERIC_SHARED_MEMORY_REGION_HEADER Value; public static implicit operator EFI_ACPI_6_2_PDTT_PCC(EFI_ACPI_6_2_PCCT_GENERIC_SHARED_MEMORY_REGION_HEADER value) => new EFI_ACPI_6_2_PDTT_PCC() { Value = value }; public static implicit operator EFI_ACPI_6_2_PCCT_GENERIC_SHARED_MEMORY_REGION_HEADER(EFI_ACPI_6_2_PDTT_PCC value) => value.Value; }

///
/// Processor Properties Topology Table (PPTT)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PROCESSOR_PROPERTIES_TOPOLOGY_TABLE_HEADER
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
}

public unsafe partial class EFI
{
  ///
  /// PPTT Revision (as defined in ACPI 6.2 spec.)
  ///
  public const ulong EFI_ACPI_6_2_PROCESSOR_PROPERTIES_TOPOLOGY_TABLE_REVISION = 0x01;

  ///
  /// PPTT types
  ///
  public const ulong EFI_ACPI_6_2_PPTT_TYPE_PROCESSOR = 0x00;
  public const ulong EFI_ACPI_6_2_PPTT_TYPE_CACHE = 0x01;
  public const ulong EFI_ACPI_6_2_PPTT_TYPE_ID = 0x02;
}

///
/// PPTT Structure Header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PPTT_STRUCTURE_HEADER
{
  public byte Type;
  public byte Length;
  public fixed byte Reserved[2];
}

public unsafe partial class EFI
{
  ///
  /// For PPTT struct processor flags
  ///
  public const ulong EFI_ACPI_6_2_PPTT_PROCESSOR_ID_INVALID = 0x0;
  public const ulong EFI_ACPI_6_2_PPTT_PROCESSOR_ID_VALID = 0x1;
}

///
/// Processor hierarchy node structure flags
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PPTT_STRUCTURE_PROCESSOR_FLAGS
{
  public uint PhysicalPackage; // = 1;
  public uint AcpiProcessorIdValid; // = 1;
  public uint Reserved; // = 30;
}

///
/// Processor hierarchy node structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PPTT_STRUCTURE_PROCESSOR
{
  public byte Type;
  public byte Length;
  public fixed byte Reserved[2];
  public EFI_ACPI_6_2_PPTT_STRUCTURE_PROCESSOR_FLAGS Flags;
  public uint Parent;
  public uint AcpiProcessorId;
  public uint NumberOfPrivateResources;
}

///
/// Cache Type Structure flags
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PPTT_STRUCTURE_CACHE_FLAGS
{
  public uint SizePropertyValid; // = 1;
  public uint NumberOfSetsValid; // = 1;
  public uint AssociativityValid; // = 1;
  public uint AllocationTypeValid; // = 1;
  public uint CacheTypeValid; // = 1;
  public uint WritePolicyValid; // = 1;
  public uint LineSizeValid; // = 1;
  public uint Reserved; // = 25;
}

public unsafe partial class EFI
{
  ///
  /// For cache attributes
  ///
  public const ulong EFI_ACPI_6_2_CACHE_ATTRIBUTES_ALLOCATION_READ = 0x0;
  public const ulong EFI_ACPI_6_2_CACHE_ATTRIBUTES_ALLOCATION_WRITE = 0x1;
  public const ulong EFI_ACPI_6_2_CACHE_ATTRIBUTES_ALLOCATION_READ_WRITE = 0x2;
  public const ulong EFI_ACPI_6_2_CACHE_ATTRIBUTES_CACHE_TYPE_DATA = 0x0;
  public const ulong EFI_ACPI_6_2_CACHE_ATTRIBUTES_CACHE_TYPE_INSTRUCTION = 0x1;
  public const ulong EFI_ACPI_6_2_CACHE_ATTRIBUTES_CACHE_TYPE_UNIFIED = 0x2;
  public const ulong EFI_ACPI_6_2_CACHE_ATTRIBUTES_WRITE_POLICY_WRITE_BACK = 0x0;
  public const ulong EFI_ACPI_6_2_CACHE_ATTRIBUTES_WRITE_POLICY_WRITE_THROUGH = 0x1;
}

///
/// Cache Type Structure cache attributes
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PPTT_STRUCTURE_CACHE_ATTRIBUTES
{
  public byte AllocationType; // = 2;
  public byte CacheType; // = 2;
  public byte WritePolicy; // = 1;
  public byte Reserved; // = 3;
}

///
/// Cache Type Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PPTT_STRUCTURE_CACHE
{
  public byte Type;
  public byte Length;
  public fixed byte Reserved[2];
  public EFI_ACPI_6_2_PPTT_STRUCTURE_CACHE_FLAGS Flags;
  public uint NextLevelOfCache;
  public uint Size;
  public uint NumberOfSets;
  public byte Associativity;
  public EFI_ACPI_6_2_PPTT_STRUCTURE_CACHE_ATTRIBUTES Attributes;
  public ushort LineSize;
}

///
/// ID structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_6_2_PPTT_STRUCTURE_ID
{
  public byte Type;
  public byte Length;
  public fixed byte Reserved[2];
  public uint VendorId;
  public ulong Level1Id;
  public ulong Level2Id;
  public ushort MajorRev;
  public ushort MinorRev;
  public ushort SpinRev;
}

//
// Known table signatures
//

public unsafe partial class EFI
{
  ///
  /// "RSD PTR " Root System Description Pointer
  ///
  public const ulong EFI_ACPI_6_2_ROOT_SYSTEM_DESCRIPTION_POINTER_SIGNATURE = SIGNATURE_64('R', 'S', 'D', ' ', 'P', 'T', 'R', ' ');

  ///
  /// "APIC" Multiple APIC Description Table
  ///
  public const ulong EFI_ACPI_6_2_MULTIPLE_APIC_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('A', 'P', 'I', 'C');

  ///
  /// "BERT" Boot Error Record Table
  ///
  public const ulong EFI_ACPI_6_2_BOOT_ERROR_RECORD_TABLE_SIGNATURE = SIGNATURE_32('B', 'E', 'R', 'T');

  ///
  /// "BGRT" Boot Graphics Resource Table
  ///
  public const ulong EFI_ACPI_6_2_BOOT_GRAPHICS_RESOURCE_TABLE_SIGNATURE = SIGNATURE_32('B', 'G', 'R', 'T');

  ///
  /// "CPEP" Corrected Platform Error Polling Table
  ///
  public const ulong EFI_ACPI_6_2_CORRECTED_PLATFORM_ERROR_POLLING_TABLE_SIGNATURE = SIGNATURE_32('C', 'P', 'E', 'P');

  ///
  /// "DSDT" Differentiated System Description Table
  ///
  public const ulong EFI_ACPI_6_2_DIFFERENTIATED_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('D', 'S', 'D', 'T');

  ///
  /// "ECDT" Embedded Controller Boot Resources Table
  ///
  public const ulong EFI_ACPI_6_2_EMBEDDED_CONTROLLER_BOOT_RESOURCES_TABLE_SIGNATURE = SIGNATURE_32('E', 'C', 'D', 'T');

  ///
  /// "EINJ" Error Injection Table
  ///
  public const ulong EFI_ACPI_6_2_ERROR_INJECTION_TABLE_SIGNATURE = SIGNATURE_32('E', 'I', 'N', 'J');

  ///
  /// "ERST" Error Record Serialization Table
  ///
  public const ulong EFI_ACPI_6_2_ERROR_RECORD_SERIALIZATION_TABLE_SIGNATURE = SIGNATURE_32('E', 'R', 'S', 'T');

  ///
  /// "FACP" Fixed ACPI Description Table
  ///
  public const ulong EFI_ACPI_6_2_FIXED_ACPI_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('F', 'A', 'C', 'P');

  ///
  /// "FACS" Firmware ACPI Control Structure
  ///
  public const ulong EFI_ACPI_6_2_FIRMWARE_ACPI_CONTROL_STRUCTURE_SIGNATURE = SIGNATURE_32('F', 'A', 'C', 'S');

  ///
  /// "FPDT" Firmware Performance Data Table
  ///
  public const ulong EFI_ACPI_6_2_FIRMWARE_PERFORMANCE_DATA_TABLE_SIGNATURE = SIGNATURE_32('F', 'P', 'D', 'T');

  ///
  /// "GTDT" Generic Timer Description Table
  ///
  public const ulong EFI_ACPI_6_2_GENERIC_TIMER_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('G', 'T', 'D', 'T');

  ///
  /// "HEST" Hardware Error Source Table
  ///
  public const ulong EFI_ACPI_6_2_HARDWARE_ERROR_SOURCE_TABLE_SIGNATURE = SIGNATURE_32('H', 'E', 'S', 'T');

  ///
  /// "HMAT" Heterogeneous Memory Attribute Table
  ///
  public const ulong EFI_ACPI_6_2_HETEROGENEOUS_MEMORY_ATTRIBUTE_TABLE_SIGNATURE = SIGNATURE_32('H', 'M', 'A', 'T');

  ///
  /// "MPST" Memory Power State Table
  ///
  public const ulong EFI_ACPI_6_2_MEMORY_POWER_STATE_TABLE_SIGNATURE = SIGNATURE_32('M', 'P', 'S', 'T');

  ///
  /// "MSCT" Maximum System Characteristics Table
  ///
  public const ulong EFI_ACPI_6_2_MAXIMUM_SYSTEM_CHARACTERISTICS_TABLE_SIGNATURE = SIGNATURE_32('M', 'S', 'C', 'T');

  ///
  /// "NFIT" NVDIMM Firmware Interface Table
  ///
  public const ulong EFI_ACPI_6_2_NVDIMM_FIRMWARE_INTERFACE_TABLE_STRUCTURE_SIGNATURE = SIGNATURE_32('N', 'F', 'I', 'T');

  ///
  /// "PDTT" Platform Debug Trigger Table
  ///
  public const ulong EFI_ACPI_6_2_PLATFORM_DEBUG_TRIGGER_TABLE_STRUCTURE_SIGNATURE = SIGNATURE_32('P', 'D', 'T', 'T');

  ///
  /// "PMTT" Platform Memory Topology Table
  ///
  public const ulong EFI_ACPI_6_2_PLATFORM_MEMORY_TOPOLOGY_TABLE_SIGNATURE = SIGNATURE_32('P', 'M', 'T', 'T');

  ///
  /// "PPTT" Processor Properties Topology Table
  ///
  public const ulong EFI_ACPI_6_2_PROCESSOR_PROPERTIES_TOPOLOGY_TABLE_STRUCTURE_SIGNATURE = SIGNATURE_32('P', 'P', 'T', 'T');

  ///
  /// "PSDT" Persistent System Description Table
  ///
  public const ulong EFI_ACPI_6_2_PERSISTENT_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('P', 'S', 'D', 'T');

  ///
  /// "RASF" ACPI RAS Feature Table
  ///
  public const ulong EFI_ACPI_6_2_ACPI_RAS_FEATURE_TABLE_SIGNATURE = SIGNATURE_32('R', 'A', 'S', 'F');

  ///
  /// "RSDT" Root System Description Table
  ///
  public const ulong EFI_ACPI_6_2_ROOT_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('R', 'S', 'D', 'T');

  ///
  /// "SBST" Smart Battery Specification Table
  ///
  public const ulong EFI_ACPI_6_2_SMART_BATTERY_SPECIFICATION_TABLE_SIGNATURE = SIGNATURE_32('S', 'B', 'S', 'T');

  ///
  /// "SDEV" Secure DEVices Table
  ///
  public const ulong EFI_ACPI_6_2_SECURE_DEVICES_TABLE_SIGNATURE = SIGNATURE_32('S', 'D', 'E', 'V');

  ///
  /// "SLIT" System Locality Information Table
  ///
  public const ulong EFI_ACPI_6_2_SYSTEM_LOCALITY_INFORMATION_TABLE_SIGNATURE = SIGNATURE_32('S', 'L', 'I', 'T');

  ///
  /// "SRAT" System Resource Affinity Table
  ///
  public const ulong EFI_ACPI_6_2_SYSTEM_RESOURCE_AFFINITY_TABLE_SIGNATURE = SIGNATURE_32('S', 'R', 'A', 'T');

  ///
  /// "SSDT" Secondary System Description Table
  ///
  public const ulong EFI_ACPI_6_2_SECONDARY_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('S', 'S', 'D', 'T');

  ///
  /// "XSDT" Extended System Description Table
  ///
  public const ulong EFI_ACPI_6_2_EXTENDED_SYSTEM_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('X', 'S', 'D', 'T');

  ///
  /// "BOOT" MS Simple Boot Spec
  ///
  public const ulong EFI_ACPI_6_2_SIMPLE_BOOT_FLAG_TABLE_SIGNATURE = SIGNATURE_32('B', 'O', 'O', 'T');

  ///
  /// "CSRT" MS Core System Resource Table
  ///
  public const ulong EFI_ACPI_6_2_CORE_SYSTEM_RESOURCE_TABLE_SIGNATURE = SIGNATURE_32('C', 'S', 'R', 'T');

  ///
  /// "DBG2" MS Debug Port 2 Spec
  ///
  public const ulong EFI_ACPI_6_2_DEBUG_PORT_2_TABLE_SIGNATURE = SIGNATURE_32('D', 'B', 'G', '2');

  ///
  /// "DBGP" MS Debug Port Spec
  ///
  public const ulong EFI_ACPI_6_2_DEBUG_PORT_TABLE_SIGNATURE = SIGNATURE_32('D', 'B', 'G', 'P');

  ///
  /// "DMAR" DMA Remapping Table
  ///
  public const ulong EFI_ACPI_6_2_DMA_REMAPPING_TABLE_SIGNATURE = SIGNATURE_32('D', 'M', 'A', 'R');

  ///
  /// "DPPT" DMA Protection Policy Table
  ///
  public const ulong EFI_ACPI_6_2_DMA_PROTECTION_POLICY_TABLE_SIGNATURE = SIGNATURE_32('D', 'P', 'P', 'T');

  ///
  /// "DRTM" Dynamic Root of Trust for Measurement Table
  ///
  public const ulong EFI_ACPI_6_2_DYNAMIC_ROOT_OF_TRUST_FOR_MEASUREMENT_TABLE_SIGNATURE = SIGNATURE_32('D', 'R', 'T', 'M');

  ///
  /// "ETDT" Event Timer Description Table
  ///
  public const ulong EFI_ACPI_6_2_EVENT_TIMER_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('E', 'T', 'D', 'T');

  ///
  /// "HPET" IA-PC High Precision Event Timer Table
  ///
  public const ulong EFI_ACPI_6_2_HIGH_PRECISION_EVENT_TIMER_TABLE_SIGNATURE = SIGNATURE_32('H', 'P', 'E', 'T');

  ///
  /// "iBFT" iSCSI Boot Firmware Table
  ///
  public const ulong EFI_ACPI_6_2_ISCSI_BOOT_FIRMWARE_TABLE_SIGNATURE = SIGNATURE_32('i', 'B', 'F', 'T');

  ///
  /// "IORT" I/O Remapping Table
  ///
  public const ulong EFI_ACPI_6_2_IO_REMAPPING_TABLE_SIGNATURE = SIGNATURE_32('I', 'O', 'R', 'T');

  ///
  /// "IVRS" I/O Virtualization Reporting Structure
  ///
  public const ulong EFI_ACPI_6_2_IO_VIRTUALIZATION_REPORTING_STRUCTURE_SIGNATURE = SIGNATURE_32('I', 'V', 'R', 'S');

  ///
  /// "LPIT" Low Power Idle Table
  ///
  public const ulong EFI_ACPI_6_2_LOW_POWER_IDLE_TABLE_STRUCTURE_SIGNATURE = SIGNATURE_32('L', 'P', 'I', 'T');

  ///
  /// "MCFG" PCI Express Memory Mapped Configuration Space Base Address Description Table
  ///
  public const ulong EFI_ACPI_6_2_PCI_EXPRESS_MEMORY_MAPPED_CONFIGURATION_SPACE_BASE_ADDRESS_DESCRIPTION_TABLE_SIGNATURE = SIGNATURE_32('M', 'C', 'F', 'G');

  ///
  /// "MCHI" Management Controller Host Interface Table
  ///
  public const ulong EFI_ACPI_6_2_MANAGEMENT_CONTROLLER_HOST_INTERFACE_TABLE_SIGNATURE = SIGNATURE_32('M', 'C', 'H', 'I');

  ///
  /// "MSDM" MS Data Management Table
  ///
  public const ulong EFI_ACPI_6_2_DATA_MANAGEMENT_TABLE_SIGNATURE = SIGNATURE_32('M', 'S', 'D', 'M');

  ///
  /// "PCCT" Platform Communications Channel Table
  ///
  public const ulong EFI_ACPI_6_2_PLATFORM_COMMUNICATIONS_CHANNEL_TABLE_SIGNATURE = SIGNATURE_32('P', 'C', 'C', 'T');

  ///
  /// "SDEI" Software Delegated Exceptions Interface Table
  ///
  public const ulong EFI_ACPI_6_2_SOFTWARE_DELEGATED_EXCEPTIONS_INTERFACE_TABLE_SIGNATURE = SIGNATURE_32('S', 'D', 'E', 'I');

  ///
  /// "SLIC" MS Software Licensing Table Specification
  ///
  public const ulong EFI_ACPI_6_2_SOFTWARE_LICENSING_TABLE_SIGNATURE = SIGNATURE_32('S', 'L', 'I', 'C');

  ///
  /// "SPCR" Serial Port Console Redirection Table
  ///
  public const ulong EFI_ACPI_6_2_SERIAL_PORT_CONSOLE_REDIRECTION_TABLE_SIGNATURE = SIGNATURE_32('S', 'P', 'C', 'R');

  ///
  /// "SPMI" Server Platform Management Interface Table
  ///
  public const ulong EFI_ACPI_6_2_SERVER_PLATFORM_MANAGEMENT_INTERFACE_TABLE_SIGNATURE = SIGNATURE_32('S', 'P', 'M', 'I');

  ///
  /// "STAO" _STA Override Table
  ///
  public const ulong EFI_ACPI_6_2_STA_OVERRIDE_TABLE_SIGNATURE = SIGNATURE_32('S', 'T', 'A', 'O');

  ///
  /// "TCPA" Trusted Computing Platform Alliance Capabilities Table
  ///
  public const ulong EFI_ACPI_6_2_TRUSTED_COMPUTING_PLATFORM_ALLIANCE_CAPABILITIES_TABLE_SIGNATURE = SIGNATURE_32('T', 'C', 'P', 'A');

  ///
  /// "TPM2" Trusted Computing Platform 1 Table
  ///
  public const ulong EFI_ACPI_6_2_TRUSTED_COMPUTING_PLATFORM_2_TABLE_SIGNATURE = SIGNATURE_32('T', 'P', 'M', '2');

  ///
  /// "UEFI" UEFI ACPI Data Table
  ///
  public const ulong EFI_ACPI_6_2_UEFI_ACPI_DATA_TABLE_SIGNATURE = SIGNATURE_32('U', 'E', 'F', 'I');

  ///
  /// "WAET" Windows ACPI Emulated Devices Table
  ///
  public const ulong EFI_ACPI_6_2_WINDOWS_ACPI_EMULATED_DEVICES_TABLE_SIGNATURE = SIGNATURE_32('W', 'A', 'E', 'T');

  ///
  /// "WDAT" Watchdog Action Table
  ///
  public const ulong EFI_ACPI_6_2_WATCHDOG_ACTION_TABLE_SIGNATURE = SIGNATURE_32('W', 'D', 'A', 'T');

  ///
  /// "WDRT" Watchdog Resource Table
  ///
  public const ulong EFI_ACPI_6_2_WATCHDOG_RESOURCE_TABLE_SIGNATURE = SIGNATURE_32('W', 'D', 'R', 'T');

  ///
  /// "WPBT" MS Platform Binary Table
  ///
  public const ulong EFI_ACPI_6_2_PLATFORM_BINARY_TABLE_SIGNATURE = SIGNATURE_32('W', 'P', 'B', 'T');

  ///
  /// "WSMT" Windows SMM Security Mitigation Table
  ///
  public const ulong EFI_ACPI_6_2_WINDOWS_SMM_SECURITY_MITIGATION_TABLE_SIGNATURE = SIGNATURE_32('W', 'S', 'M', 'T');

  ///
  /// "XENV" Xen Project Table
  ///
  public const ulong EFI_ACPI_6_2_XEN_PROJECT_TABLE_SIGNATURE = SIGNATURE_32('X', 'E', 'N', 'V');

  // #pragma pack()
}

// #endif
