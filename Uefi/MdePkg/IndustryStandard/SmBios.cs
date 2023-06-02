using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Industry Standard Definitions of SMBIOS Table Specification v3.6.0.

Copyright (c) 2006 - 2021, Intel Corporation. All rights reserved.<BR>
(C) Copyright 2015-2017 Hewlett Packard Enterprise Development LP<BR>
(C) Copyright 2015 - 2019 Hewlett Packard Enterprise Development LP<BR>
Copyright (c) 2022, AMD Incorporated. All rights reserved.<BR>
Copyright (c) 1985 - 2022, American Megatrends International LLC.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SMBIOS_STANDARD_H__
// #define __SMBIOS_STANDARD_H__

///
/// Reference SMBIOS 2.6, chapter 3.1.2.
/// For v2.1 and later, handle values in the range 0FF00h to 0FFFFh are reserved for
/// use by this specification.
///
public unsafe partial class EFI
{
  public const ulong SMBIOS_HANDLE_RESERVED_BEGIN = 0xFF00;

  ///
  /// Reference SMBIOS 2.7, chapter 6.1.2.
  /// The UEFI Platform Initialization Specification reserves handle number FFFEh for its
  /// EFI_SMBIOS_PROTOCOL.Add() function to mean "assign an unused handle number automatically."
  /// This number is not used for any other purpose by the SMBIOS specification.
  ///
  public const ulong SMBIOS_HANDLE_PI_RESERVED = 0xFFFE;

  ///
  /// Reference SMBIOS 2.6, chapter 3.1.3.
  /// Each text string is limited to 64 significant characters due to system MIF limitations.
  /// Reference SMBIOS 2.7, chapter 6.1.3.
  /// It will have no limit on the length of each individual text string.
  ///
  public const ulong SMBIOS_STRING_MAX_LENGTH = 64;

  //
  // The length of the entire structure table (including all strings) must be reported
  // in the Structure Table Length field of the SMBIOS Structure Table Entry Point,
  // which is a WORD field limited to 65,535 bytes.
  //
  public const ulong SMBIOS_TABLE_MAX_LENGTH = 0xFFFF;

  //
  // For SMBIOS 3.0, Structure table maximum size in Entry Point structure is DWORD field limited to 0xFFFFFFFF bytes.
  //
  public const ulong SMBIOS_3_0_TABLE_MAX_LENGTH = 0xFFFFFFFF;

  ///
  /// Reference SMBIOS 3.4, chapter 5.2.1 SMBIOS 2.1 (32-bit) Entry Point
  /// Table 1 - SMBIOS 2.1 (32-bit) Entry Point structure, offset 00h
  /// _SM_, specified as four ASCII characters (5F 53 4D 5F).
  ///@{
  public const ulong SMBIOS_ANCHOR_STRING = "_SM_";
  public const ulong SMBIOS_ANCHOR_STRING_LENGTH = 4;
  ///@}

  ///
  /// Reference SMBIOS 3.4, chapter 5.2.2 SMBIOS 3.0 (64-bit) Entry Point
  /// Table 2 - SMBIOS 3.0 (64-bit) Entry Point structure, offset 00h
  /// _SM3_, specified as five ASCII characters (5F 53 4D 33 5F).
  ///@{
  public const ulong SMBIOS_3_0_ANCHOR_STRING = "_SM3_";
  public const ulong SMBIOS_3_0_ANCHOR_STRING_LENGTH = 5;
  ///@}

  //
  // SMBIOS type macros which is according to SMBIOS 3.3.0 specification.
  //
  public const ulong SMBIOS_TYPE_BIOS_INFORMATION = 0;
  public const ulong SMBIOS_TYPE_SYSTEM_INFORMATION = 1;
  public const ulong SMBIOS_TYPE_BASEBOARD_INFORMATION = 2;
  public const ulong SMBIOS_TYPE_SYSTEM_ENCLOSURE = 3;
  public const ulong SMBIOS_TYPE_PROCESSOR_INFORMATION = 4;
  public const ulong SMBIOS_TYPE_MEMORY_CONTROLLER_INFORMATION = 5;
  public const ulong SMBIOS_TYPE_MEMORY_MODULE_INFORMATON = 6;
  public const ulong SMBIOS_TYPE_CACHE_INFORMATION = 7;
  public const ulong SMBIOS_TYPE_PORT_CONNECTOR_INFORMATION = 8;
  public const ulong SMBIOS_TYPE_SYSTEM_SLOTS = 9;
  public const ulong SMBIOS_TYPE_ONBOARD_DEVICE_INFORMATION = 10;
  public const ulong SMBIOS_TYPE_OEM_STRINGS = 11;
  public const ulong SMBIOS_TYPE_SYSTEM_CONFIGURATION_OPTIONS = 12;
  public const ulong SMBIOS_TYPE_BIOS_LANGUAGE_INFORMATION = 13;
  public const ulong SMBIOS_TYPE_GROUP_ASSOCIATIONS = 14;
  public const ulong SMBIOS_TYPE_SYSTEM_EVENT_LOG = 15;
  public const ulong SMBIOS_TYPE_PHYSICAL_MEMORY_ARRAY = 16;
  public const ulong SMBIOS_TYPE_MEMORY_DEVICE = 17;
  public const ulong SMBIOS_TYPE_32BIT_MEMORY_ERROR_INFORMATION = 18;
  public const ulong SMBIOS_TYPE_MEMORY_ARRAY_MAPPED_ADDRESS = 19;
  public const ulong SMBIOS_TYPE_MEMORY_DEVICE_MAPPED_ADDRESS = 20;
  public const ulong SMBIOS_TYPE_BUILT_IN_POINTING_DEVICE = 21;
  public const ulong SMBIOS_TYPE_PORTABLE_BATTERY = 22;
  public const ulong SMBIOS_TYPE_SYSTEM_RESET = 23;
  public const ulong SMBIOS_TYPE_HARDWARE_SECURITY = 24;
  public const ulong SMBIOS_TYPE_SYSTEM_POWER_CONTROLS = 25;
  public const ulong SMBIOS_TYPE_VOLTAGE_PROBE = 26;
  public const ulong SMBIOS_TYPE_COOLING_DEVICE = 27;
  public const ulong SMBIOS_TYPE_TEMPERATURE_PROBE = 28;
  public const ulong SMBIOS_TYPE_ELECTRICAL_CURRENT_PROBE = 29;
  public const ulong SMBIOS_TYPE_OUT_OF_BAND_REMOTE_ACCESS = 30;
  public const ulong SMBIOS_TYPE_BOOT_INTEGRITY_SERVICE = 31;
  public const ulong SMBIOS_TYPE_SYSTEM_BOOT_INFORMATION = 32;
  public const ulong SMBIOS_TYPE_64BIT_MEMORY_ERROR_INFORMATION = 33;
  public const ulong SMBIOS_TYPE_MANAGEMENT_DEVICE = 34;
  public const ulong SMBIOS_TYPE_MANAGEMENT_DEVICE_COMPONENT = 35;
  public const ulong SMBIOS_TYPE_MANAGEMENT_DEVICE_THRESHOLD_DATA = 36;
  public const ulong SMBIOS_TYPE_MEMORY_CHANNEL = 37;
  public const ulong SMBIOS_TYPE_IPMI_DEVICE_INFORMATION = 38;
  public const ulong SMBIOS_TYPE_SYSTEM_POWER_SUPPLY = 39;
  public const ulong SMBIOS_TYPE_ADDITIONAL_INFORMATION = 40;
  public const ulong SMBIOS_TYPE_ONBOARD_DEVICES_EXTENDED_INFORMATION = 41;
  public const ulong SMBIOS_TYPE_MANAGEMENT_CONTROLLER_HOST_INTERFACE = 42;
  public const ulong SMBIOS_TYPE_TPM_DEVICE = 43;
  public const ulong SMBIOS_TYPE_PROCESSOR_ADDITIONAL_INFORMATION = 44;
  public const ulong SMBIOS_TYPE_FIRMWARE_INVENTORY_INFORMATION = 45;
  public const ulong SMBIOS_TYPE_STRING_PROPERTY_INFORMATION = 46;

  ///
  /// Inactive type is added from SMBIOS 2.2. Reference SMBIOS 2.6, chapter 3.3.43.
  /// Upper-level software that interprets the SMBIOS structure-table should bypass an
  /// Inactive structure just like a structure type that the software does not recognize.
  ///
  public const ulong SMBIOS_TYPE_INACTIVE = 0x007E;

  ///
  /// End-of-table type is added from SMBIOS 2.2. Reference SMBIOS 2.6, chapter 3.3.44.
  /// The end-of-table indicator is used in the last physical structure in a table
  ///
  public const ulong SMBIOS_TYPE_END_OF_TABLE = 0x007F;

  public const ulong SMBIOS_OEM_BEGIN = 128;
  public const ulong SMBIOS_OEM_END = 255;
}

///
/// Types 0 through 127 (7Fh) are reserved for and defined by this
/// specification. Types 128 through 256 (80h to FFh) are available for system- and OEM-specific information.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TYPE { byte Value; public static implicit operator SMBIOS_TYPE(byte value) => new SMBIOS_TYPE() { Value = value }; public static implicit operator byte(SMBIOS_TYPE value) => value.Value; }

///
/// Specifies the structure's handle, a unique 16-bit number in the range 0 to 0FFFEh (for version
/// 2.0) or 0 to 0FEFFh (for version 2.1 and later). The handle can be used with the Get SMBIOS
/// Structure function to retrieve a specific structure; the handle numbers are not required to be
/// contiguous. For v2.1 and later, handle values in the range 0FF00h to 0FFFFh are reserved for
/// use by this specification.
/// If the system configuration changes, a previously assigned handle might no longer exist.
/// However once a handle has been assigned by the BIOS, the BIOS cannot re-assign that handle
/// number to another structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_HANDLE { ushort Value; public static implicit operator SMBIOS_HANDLE(ushort value) => new SMBIOS_HANDLE() { Value = value }; public static implicit operator ushort(SMBIOS_HANDLE value) => value.Value; }

///
/// Smbios Table Entry Point Structure.
///
// #pragma pack(1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_ENTRY_POINT
{
  public fixed byte AnchorString[SMBIOS_ANCHOR_STRING_LENGTH];
  public byte EntryPointStructureChecksum;
  public byte EntryPointLength;
  public byte MajorVersion;
  public byte MinorVersion;
  public ushort MaxStructureSize;
  public byte EntryPointRevision;
  public fixed byte FormattedArea[5];
  public fixed byte IntermediateAnchorString[5];
  public byte IntermediateChecksum;
  public ushort TableLength;
  public uint TableAddress;
  public ushort NumberOfSmbiosStructures;
  public byte SmbiosBcdRevision;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_3_0_ENTRY_POINT
{
  public fixed byte AnchorString[SMBIOS_3_0_ANCHOR_STRING_LENGTH];
  public byte EntryPointStructureChecksum;
  public byte EntryPointLength;
  public byte MajorVersion;
  public byte MinorVersion;
  public byte DocRev;
  public byte EntryPointRevision;
  public byte Reserved;
  public uint TableMaximumSize;
  public ulong TableAddress;
}

///
/// The Smbios structure header.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_STRUCTURE
{
  public SMBIOS_TYPE Type;
  public byte Length;
  public SMBIOS_HANDLE Handle;
}

///
/// Text strings associated with a given SMBIOS structure are returned in the dmiStrucBuffer, appended directly after
/// the formatted portion of the structure. This method of returning string information eliminates the need for
/// application software to deal with pointers embedded in the SMBIOS structure. Each string is terminated with a null
/// (00h) BYTE and the set of strings is terminated with an additional null (00h) BYTE. When the formatted portion of
/// a SMBIOS structure references a string, it does so by specifying a non-zero string number within the structure's
/// string-set. For example, if a string field contains 02h, it references the second string following the formatted portion
/// of the SMBIOS structure. If a string field references no string, a null (0) is placed in that string field. If the
/// formatted portion of the structure contains string-reference fields and all the string fields are set to 0 (no string
/// references), the formatted section of the structure is followed by two null (00h) BYTES.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_STRING { byte Value; public static implicit operator SMBIOS_TABLE_STRING(byte value) => new SMBIOS_TABLE_STRING() { Value = value }; public static implicit operator byte(SMBIOS_TABLE_STRING value) => value.Value; }

///
/// BIOS Characteristics
/// Defines which functions the BIOS supports. PCI, PCMCIA, Flash, etc.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MISC_BIOS_CHARACTERISTICS
{
  public uint Reserved = 2; ///< Bits 0-1.
  public uint Unknown = 1;
  public uint BiosCharacteristicsNotSupported = 1;
  public uint IsaIsSupported = 1;
  public uint McaIsSupported = 1;
  public uint EisaIsSupported = 1;
  public uint PciIsSupported = 1;
  public uint PcmciaIsSupported = 1;
  public uint PlugAndPlayIsSupported = 1;
  public uint ApmIsSupported = 1;
  public uint BiosIsUpgradable = 1;
  public uint BiosShadowingAllowed = 1;
  public uint VlVesaIsSupported = 1;
  public uint EscdSupportIsAvailable = 1;
  public uint BootFromCdIsSupported = 1;
  public uint SelectableBootIsSupported = 1;
  public uint RomBiosIsSocketed = 1;
  public uint BootFromPcmciaIsSupported = 1;
  public uint EDDSpecificationIsSupported = 1;
  public uint JapaneseNecFloppyIsSupported = 1;
  public uint JapaneseToshibaFloppyIsSupported = 1;
  public uint Floppy525_360IsSupported = 1;
  public uint Floppy525_12IsSupported = 1;
  public uint Floppy35_720IsSupported = 1;
  public uint Floppy35_288IsSupported = 1;
  public uint PrintScreenIsSupported = 1;
  public uint Keyboard8042IsSupported = 1;
  public uint SerialIsSupported = 1;
  public uint PrinterIsSupported = 1;
  public uint CgaMonoIsSupported = 1;
  public uint NecPc98 = 1;
  public uint ReservedForVendor = 32; ///< Bits 32-63. Bits 32-47 reserved for BIOS vendor
                                      ///< and bits 48-63 reserved for System Vendor.
}

///
/// BIOS Characteristics Extension Byte 1.
/// This information, available for SMBIOS version 2.1 and later, appears at offset 12h
/// within the BIOS Information structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MBCE_BIOS_RESERVED
{
  public byte AcpiIsSupported = 1;
  public byte UsbLegacyIsSupported = 1;
  public byte AgpIsSupported = 1;
  public byte I2OBootIsSupported = 1;
  public byte Ls120BootIsSupported = 1;
  public byte AtapiZipDriveBootIsSupported = 1;
  public byte Boot1394IsSupported = 1;
  public byte SmartBatteryIsSupported = 1;
}

///
/// BIOS Characteristics Extension Byte 2.
/// This information, available for SMBIOS version 2.3 and later, appears at offset 13h
/// within the BIOS Information structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MBCE_SYSTEM_RESERVED
{
  public byte BiosBootSpecIsSupported = 1;
  public byte FunctionKeyNetworkBootIsSupported = 1;
  public byte TargetContentDistributionEnabled = 1;
  public byte UefiSpecificationSupported = 1;
  public byte VirtualMachineSupported = 1;
  public byte ManufacturingModeSupported = 1;
  public byte ManufacturingModeEnabled = 1;
  public byte ExtensionByte2Reserved = 1;
}

///
/// BIOS Characteristics Extension Bytes.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MISC_BIOS_CHARACTERISTICS_EXTENSION
{
  public MBCE_BIOS_RESERVED BiosReserved;
  public MBCE_SYSTEM_RESERVED SystemReserved;
}

///
/// Extended BIOS ROM size.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EXTENDED_BIOS_ROM_SIZE
{
  public ushort Size = 14;
  public ushort Unit = 2;
}

///
/// BIOS Information (Type 0).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE0
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Vendor;
  public SMBIOS_TABLE_STRING BiosVersion;
  public ushort BiosSegment;
  public SMBIOS_TABLE_STRING BiosReleaseDate;
  public byte BiosSize;
  public MISC_BIOS_CHARACTERISTICS BiosCharacteristics;
  public fixed byte BIOSCharacteristicsExtensionBytes[2];
  public byte SystemBiosMajorRelease;
  public byte SystemBiosMinorRelease;
  public byte EmbeddedControllerFirmwareMajorRelease;
  public byte EmbeddedControllerFirmwareMinorRelease;
  //
  // Add for smbios 3.1.0
  //
  public EXTENDED_BIOS_ROM_SIZE ExtendedBiosSize;
}

///
///  System Wake-up Type.
///
public enum MISC_SYSTEM_WAKEUP_TYPE
{
  SystemWakeupTypeReserved = 0x00,
  SystemWakeupTypeOther = 0x01,
  SystemWakeupTypeUnknown = 0x02,
  SystemWakeupTypeApmTimer = 0x03,
  SystemWakeupTypeModemRing = 0x04,
  SystemWakeupTypeLanRemote = 0x05,
  SystemWakeupTypePowerSwitch = 0x06,
  SystemWakeupTypePciPme = 0x07,
  SystemWakeupTypeAcPowerRestored = 0x08
}

///
/// System Information (Type 1).
///
/// The information in this structure defines attributes of the overall system and is
/// intended to be associated with the Component ID group of the system's MIF.
/// An SMBIOS implementation is associated with a single system instance and contains
/// one and only one System Information (Type 1) structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE1
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Manufacturer;
  public SMBIOS_TABLE_STRING ProductName;
  public SMBIOS_TABLE_STRING Version;
  public SMBIOS_TABLE_STRING SerialNumber;
  public GUID Uuid;
  public byte WakeUpType;            ///< The enumeration value from MISC_SYSTEM_WAKEUP_TYPE.
  public SMBIOS_TABLE_STRING SKUNumber;
  public SMBIOS_TABLE_STRING Family;
}

///
///  Base Board - Feature Flags.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BASE_BOARD_FEATURE_FLAGS
{
  public byte Motherboard = 1;
  public byte RequiresDaughterCard = 1;
  public byte Removable = 1;
  public byte Replaceable = 1;
  public byte HotSwappable = 1;
  public byte Reserved = 3;
}

///
///  Base Board - Board Type.
///
public enum BASE_BOARD_TYPE
{
  BaseBoardTypeUnknown = 0x1,
  BaseBoardTypeOther = 0x2,
  BaseBoardTypeServerBlade = 0x3,
  BaseBoardTypeConnectivitySwitch = 0x4,
  BaseBoardTypeSystemManagementModule = 0x5,
  BaseBoardTypeProcessorModule = 0x6,
  BaseBoardTypeIOModule = 0x7,
  BaseBoardTypeMemoryModule = 0x8,
  BaseBoardTypeDaughterBoard = 0x9,
  BaseBoardTypeMotherBoard = 0xA,
  BaseBoardTypeProcessorMemoryModule = 0xB,
  BaseBoardTypeProcessorIOModule = 0xC,
  BaseBoardTypeInterconnectBoard = 0xD
}

///
/// Base Board (or Module) Information (Type 2).
///
/// The information in this structure defines attributes of a system baseboard -
/// for example a motherboard, planar, or server blade or other standard system module.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE2
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Manufacturer;
  public SMBIOS_TABLE_STRING ProductName;
  public SMBIOS_TABLE_STRING Version;
  public SMBIOS_TABLE_STRING SerialNumber;
  public SMBIOS_TABLE_STRING AssetTag;
  public BASE_BOARD_FEATURE_FLAGS FeatureFlag;
  public SMBIOS_TABLE_STRING LocationInChassis;
  public ushort ChassisHandle;
  public byte BoardType;            ///< The enumeration value from BASE_BOARD_TYPE.
  public byte NumberOfContainedObjectHandles;
  public fixed ushort ContainedObjectHandles[1];
}

///
/// System Enclosure or Chassis Types
///
public enum MISC_CHASSIS_TYPE
{
  MiscChassisTypeOther = 0x01,
  MiscChassisTypeUnknown = 0x02,
  MiscChassisTypeDeskTop = 0x03,
  MiscChassisTypeLowProfileDesktop = 0x04,
  MiscChassisTypePizzaBox = 0x05,
  MiscChassisTypeMiniTower = 0x06,
  MiscChassisTypeTower = 0x07,
  MiscChassisTypePortable = 0x08,
  MiscChassisTypeLapTop = 0x09,
  MiscChassisTypeNotebook = 0x0A,
  MiscChassisTypeHandHeld = 0x0B,
  MiscChassisTypeDockingStation = 0x0C,
  MiscChassisTypeAllInOne = 0x0D,
  MiscChassisTypeSubNotebook = 0x0E,
  MiscChassisTypeSpaceSaving = 0x0F,
  MiscChassisTypeLunchBox = 0x10,
  MiscChassisTypeMainServerChassis = 0x11,
  MiscChassisTypeExpansionChassis = 0x12,
  MiscChassisTypeSubChassis = 0x13,
  MiscChassisTypeBusExpansionChassis = 0x14,
  MiscChassisTypePeripheralChassis = 0x15,
  MiscChassisTypeRaidChassis = 0x16,
  MiscChassisTypeRackMountChassis = 0x17,
  MiscChassisTypeSealedCasePc = 0x18,
  MiscChassisMultiSystemChassis = 0x19,
  MiscChassisCompactPCI = 0x1A,
  MiscChassisAdvancedTCA = 0x1B,
  MiscChassisBlade = 0x1C,
  MiscChassisBladeEnclosure = 0x1D,
  MiscChassisTablet = 0x1E,
  MiscChassisConvertible = 0x1F,
  MiscChassisDetachable = 0x20,
  MiscChassisIoTGateway = 0x21,
  MiscChassisEmbeddedPc = 0x22,
  MiscChassisMiniPc = 0x23,
  MiscChassisStickPc = 0x24
}

///
/// System Enclosure or Chassis States .
///
public enum MISC_CHASSIS_STATE
{
  ChassisStateOther = 0x01,
  ChassisStateUnknown = 0x02,
  ChassisStateSafe = 0x03,
  ChassisStateWarning = 0x04,
  ChassisStateCritical = 0x05,
  ChassisStateNonRecoverable = 0x06
}

///
/// System Enclosure or Chassis Security Status.
///
public enum MISC_CHASSIS_SECURITY_STATE
{
  ChassisSecurityStatusOther = 0x01,
  ChassisSecurityStatusUnknown = 0x02,
  ChassisSecurityStatusNone = 0x03,
  ChassisSecurityStatusExternalInterfaceLockedOut = 0x04,
  ChassisSecurityStatusExternalInterfaceLockedEnabled = 0x05
}

///
/// Contained Element record
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CONTAINED_ELEMENT
{
  public byte ContainedElementType;
  public byte ContainedElementMinimum;
  public byte ContainedElementMaximum;
}

///
/// System Enclosure or Chassis (Type 3).
///
/// The information in this structure defines attributes of the system's mechanical enclosure(s).
/// For example, if a system included a separate enclosure for its peripheral devices,
/// two structures would be returned: one for the main, system enclosure and the second for
/// the peripheral device enclosure.  The additions to this structure in v2.1 of this specification
/// support the population of the CIM_Chassis class.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE3
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Manufacturer;
  public byte Type;
  public SMBIOS_TABLE_STRING Version;
  public SMBIOS_TABLE_STRING SerialNumber;
  public SMBIOS_TABLE_STRING AssetTag;
  public byte BootupState;                 ///< The enumeration value from MISC_CHASSIS_STATE.
  public byte PowerSupplyState;            ///< The enumeration value from MISC_CHASSIS_STATE.
  public byte ThermalState;                ///< The enumeration value from MISC_CHASSIS_STATE.
  public byte SecurityStatus;              ///< The enumeration value from MISC_CHASSIS_SECURITY_STATE.
  public fixed byte OemDefined[4];
  public byte Height;
  public byte NumberofPowerCords;
  public byte ContainedElementCount;
  public byte ContainedElementRecordLength;
  //
  // Can have 0 to (ContainedElementCount * ContainedElementRecordLength) contained elements
  //
  public fixed CONTAINED_ELEMENT ContainedElements[1];
  //
  // Add for smbios 2.7
  //
  // Since ContainedElements has a variable number of entries, must not define SKUNumber in
  // the structure.  Need to reference it by starting at offset 0x15 and adding
  // (ContainedElementCount * ContainedElementRecordLength) bytes.
  //
  // SMBIOS_TABLE_STRING         SKUNumber;
}

///
/// Processor Information - Processor Type.
///
public enum PROCESSOR_TYPE_DATA
{
  ProcessorOther = 0x01,
  ProcessorUnknown = 0x02,
  CentralProcessor = 0x03,
  MathProcessor = 0x04,
  DspProcessor = 0x05,
  VideoProcessor = 0x06
}

///
/// Processor Information - Processor Family.
///
public enum PROCESSOR_FAMILY_DATA
{
  ProcessorFamilyOther = 0x01,
  ProcessorFamilyUnknown = 0x02,
  ProcessorFamily8086 = 0x03,
  ProcessorFamily80286 = 0x04,
  ProcessorFamilyIntel386 = 0x05,
  ProcessorFamilyIntel486 = 0x06,
  ProcessorFamily8087 = 0x07,
  ProcessorFamily80287 = 0x08,
  ProcessorFamily80387 = 0x09,
  ProcessorFamily80487 = 0x0A,
  ProcessorFamilyPentium = 0x0B,
  ProcessorFamilyPentiumPro = 0x0C,
  ProcessorFamilyPentiumII = 0x0D,
  ProcessorFamilyPentiumMMX = 0x0E,
  ProcessorFamilyCeleron = 0x0F,
  ProcessorFamilyPentiumIIXeon = 0x10,
  ProcessorFamilyPentiumIII = 0x11,
  ProcessorFamilyM1 = 0x12,
  ProcessorFamilyM2 = 0x13,
  ProcessorFamilyIntelCeleronM = 0x14,
  ProcessorFamilyIntelPentium4Ht = 0x15,
  ProcessorFamilyAmdDuron = 0x18,
  ProcessorFamilyK5 = 0x19,
  ProcessorFamilyK6 = 0x1A,
  ProcessorFamilyK6_2 = 0x1B,
  ProcessorFamilyK6_3 = 0x1C,
  ProcessorFamilyAmdAthlon = 0x1D,
  ProcessorFamilyAmd29000 = 0x1E,
  ProcessorFamilyK6_2Plus = 0x1F,
  ProcessorFamilyPowerPC = 0x20,
  ProcessorFamilyPowerPC601 = 0x21,
  ProcessorFamilyPowerPC603 = 0x22,
  ProcessorFamilyPowerPC603Plus = 0x23,
  ProcessorFamilyPowerPC604 = 0x24,
  ProcessorFamilyPowerPC620 = 0x25,
  ProcessorFamilyPowerPCx704 = 0x26,
  ProcessorFamilyPowerPC750 = 0x27,
  ProcessorFamilyIntelCoreDuo = 0x28,
  ProcessorFamilyIntelCoreDuoMobile = 0x29,
  ProcessorFamilyIntelCoreSoloMobile = 0x2A,
  ProcessorFamilyIntelAtom = 0x2B,
  ProcessorFamilyIntelCoreM = 0x2C,
  ProcessorFamilyIntelCorem3 = 0x2D,
  ProcessorFamilyIntelCorem5 = 0x2E,
  ProcessorFamilyIntelCorem7 = 0x2F,
  ProcessorFamilyAlpha = 0x30,
  ProcessorFamilyAlpha21064 = 0x31,
  ProcessorFamilyAlpha21066 = 0x32,
  ProcessorFamilyAlpha21164 = 0x33,
  ProcessorFamilyAlpha21164PC = 0x34,
  ProcessorFamilyAlpha21164a = 0x35,
  ProcessorFamilyAlpha21264 = 0x36,
  ProcessorFamilyAlpha21364 = 0x37,
  ProcessorFamilyAmdTurionIIUltraDualCoreMobileM = 0x38,
  ProcessorFamilyAmdTurionIIDualCoreMobileM = 0x39,
  ProcessorFamilyAmdAthlonIIDualCoreM = 0x3A,
  ProcessorFamilyAmdOpteron6100Series = 0x3B,
  ProcessorFamilyAmdOpteron4100Series = 0x3C,
  ProcessorFamilyAmdOpteron6200Series = 0x3D,
  ProcessorFamilyAmdOpteron4200Series = 0x3E,
  ProcessorFamilyAmdFxSeries = 0x3F,
  ProcessorFamilyMips = 0x40,
  ProcessorFamilyMIPSR4000 = 0x41,
  ProcessorFamilyMIPSR4200 = 0x42,
  ProcessorFamilyMIPSR4400 = 0x43,
  ProcessorFamilyMIPSR4600 = 0x44,
  ProcessorFamilyMIPSR10000 = 0x45,
  ProcessorFamilyAmdCSeries = 0x46,
  ProcessorFamilyAmdESeries = 0x47,
  ProcessorFamilyAmdASeries = 0x48, ///< SMBIOS spec 2.8.0 updated the name
  ProcessorFamilyAmdGSeries = 0x49,
  ProcessorFamilyAmdZSeries = 0x4A,
  ProcessorFamilyAmdRSeries = 0x4B,
  ProcessorFamilyAmdOpteron4300 = 0x4C,
  ProcessorFamilyAmdOpteron6300 = 0x4D,
  ProcessorFamilyAmdOpteron3300 = 0x4E,
  ProcessorFamilyAmdFireProSeries = 0x4F,
  ProcessorFamilySparc = 0x50,
  ProcessorFamilySuperSparc = 0x51,
  ProcessorFamilymicroSparcII = 0x52,
  ProcessorFamilymicroSparcIIep = 0x53,
  ProcessorFamilyUltraSparc = 0x54,
  ProcessorFamilyUltraSparcII = 0x55,
  ProcessorFamilyUltraSparcIii = 0x56,
  ProcessorFamilyUltraSparcIII = 0x57,
  ProcessorFamilyUltraSparcIIIi = 0x58,
  ProcessorFamily68040 = 0x60,
  ProcessorFamily68xxx = 0x61,
  ProcessorFamily68000 = 0x62,
  ProcessorFamily68010 = 0x63,
  ProcessorFamily68020 = 0x64,
  ProcessorFamily68030 = 0x65,
  ProcessorFamilyAmdAthlonX4QuadCore = 0x66,
  ProcessorFamilyAmdOpteronX1000Series = 0x67,
  ProcessorFamilyAmdOpteronX2000Series = 0x68,
  ProcessorFamilyAmdOpteronASeries = 0x69,
  ProcessorFamilyAmdOpteronX3000Series = 0x6A,
  ProcessorFamilyAmdZen = 0x6B,
  ProcessorFamilyHobbit = 0x70,
  ProcessorFamilyCrusoeTM5000 = 0x78,
  ProcessorFamilyCrusoeTM3000 = 0x79,
  ProcessorFamilyEfficeonTM8000 = 0x7A,
  ProcessorFamilyWeitek = 0x80,
  ProcessorFamilyItanium = 0x82,
  ProcessorFamilyAmdAthlon64 = 0x83,
  ProcessorFamilyAmdOpteron = 0x84,
  ProcessorFamilyAmdSempron = 0x85,
  ProcessorFamilyAmdTurion64Mobile = 0x86,
  ProcessorFamilyDualCoreAmdOpteron = 0x87,
  ProcessorFamilyAmdAthlon64X2DualCore = 0x88,
  ProcessorFamilyAmdTurion64X2Mobile = 0x89,
  ProcessorFamilyQuadCoreAmdOpteron = 0x8A,
  ProcessorFamilyThirdGenerationAmdOpteron = 0x8B,
  ProcessorFamilyAmdPhenomFxQuadCore = 0x8C,
  ProcessorFamilyAmdPhenomX4QuadCore = 0x8D,
  ProcessorFamilyAmdPhenomX2DualCore = 0x8E,
  ProcessorFamilyAmdAthlonX2DualCore = 0x8F,
  ProcessorFamilyPARISC = 0x90,
  ProcessorFamilyPaRisc8500 = 0x91,
  ProcessorFamilyPaRisc8000 = 0x92,
  ProcessorFamilyPaRisc7300LC = 0x93,
  ProcessorFamilyPaRisc7200 = 0x94,
  ProcessorFamilyPaRisc7100LC = 0x95,
  ProcessorFamilyPaRisc7100 = 0x96,
  ProcessorFamilyV30 = 0xA0,
  ProcessorFamilyQuadCoreIntelXeon3200Series = 0xA1,
  ProcessorFamilyDualCoreIntelXeon3000Series = 0xA2,
  ProcessorFamilyQuadCoreIntelXeon5300Series = 0xA3,
  ProcessorFamilyDualCoreIntelXeon5100Series = 0xA4,
  ProcessorFamilyDualCoreIntelXeon5000Series = 0xA5,
  ProcessorFamilyDualCoreIntelXeonLV = 0xA6,
  ProcessorFamilyDualCoreIntelXeonULV = 0xA7,
  ProcessorFamilyDualCoreIntelXeon7100Series = 0xA8,
  ProcessorFamilyQuadCoreIntelXeon5400Series = 0xA9,
  ProcessorFamilyQuadCoreIntelXeon = 0xAA,
  ProcessorFamilyDualCoreIntelXeon5200Series = 0xAB,
  ProcessorFamilyDualCoreIntelXeon7200Series = 0xAC,
  ProcessorFamilyQuadCoreIntelXeon7300Series = 0xAD,
  ProcessorFamilyQuadCoreIntelXeon7400Series = 0xAE,
  ProcessorFamilyMultiCoreIntelXeon7400Series = 0xAF,
  ProcessorFamilyPentiumIIIXeon = 0xB0,
  ProcessorFamilyPentiumIIISpeedStep = 0xB1,
  ProcessorFamilyPentium4 = 0xB2,
  ProcessorFamilyIntelXeon = 0xB3,
  ProcessorFamilyAS400 = 0xB4,
  ProcessorFamilyIntelXeonMP = 0xB5,
  ProcessorFamilyAMDAthlonXP = 0xB6,
  ProcessorFamilyAMDAthlonMP = 0xB7,
  ProcessorFamilyIntelItanium2 = 0xB8,
  ProcessorFamilyIntelPentiumM = 0xB9,
  ProcessorFamilyIntelCeleronD = 0xBA,
  ProcessorFamilyIntelPentiumD = 0xBB,
  ProcessorFamilyIntelPentiumEx = 0xBC,
  ProcessorFamilyIntelCoreSolo = 0xBD, ///< SMBIOS spec 2.6 updated this value
  ProcessorFamilyReserved = 0xBE,
  ProcessorFamilyIntelCore2 = 0xBF,
  ProcessorFamilyIntelCore2Solo = 0xC0,
  ProcessorFamilyIntelCore2Extreme = 0xC1,
  ProcessorFamilyIntelCore2Quad = 0xC2,
  ProcessorFamilyIntelCore2ExtremeMobile = 0xC3,
  ProcessorFamilyIntelCore2DuoMobile = 0xC4,
  ProcessorFamilyIntelCore2SoloMobile = 0xC5,
  ProcessorFamilyIntelCoreI7 = 0xC6,
  ProcessorFamilyDualCoreIntelCeleron = 0xC7,
  ProcessorFamilyIBM390 = 0xC8,
  ProcessorFamilyG4 = 0xC9,
  ProcessorFamilyG5 = 0xCA,
  ProcessorFamilyG6 = 0xCB,
  ProcessorFamilyzArchitecture = 0xCC,
  ProcessorFamilyIntelCoreI5 = 0xCD,
  ProcessorFamilyIntelCoreI3 = 0xCE,
  ProcessorFamilyIntelCoreI9 = 0xCF,
  ProcessorFamilyViaC7M = 0xD2,
  ProcessorFamilyViaC7D = 0xD3,
  ProcessorFamilyViaC7 = 0xD4,
  ProcessorFamilyViaEden = 0xD5,
  ProcessorFamilyMultiCoreIntelXeon = 0xD6,
  ProcessorFamilyDualCoreIntelXeon3Series = 0xD7,
  ProcessorFamilyQuadCoreIntelXeon3Series = 0xD8,
  ProcessorFamilyViaNano = 0xD9,
  ProcessorFamilyDualCoreIntelXeon5Series = 0xDA,
  ProcessorFamilyQuadCoreIntelXeon5Series = 0xDB,
  ProcessorFamilyDualCoreIntelXeon7Series = 0xDD,
  ProcessorFamilyQuadCoreIntelXeon7Series = 0xDE,
  ProcessorFamilyMultiCoreIntelXeon7Series = 0xDF,
  ProcessorFamilyMultiCoreIntelXeon3400Series = 0xE0,
  ProcessorFamilyAmdOpteron3000Series = 0xE4,
  ProcessorFamilyAmdSempronII = 0xE5,
  ProcessorFamilyEmbeddedAmdOpteronQuadCore = 0xE6,
  ProcessorFamilyAmdPhenomTripleCore = 0xE7,
  ProcessorFamilyAmdTurionUltraDualCoreMobile = 0xE8,
  ProcessorFamilyAmdTurionDualCoreMobile = 0xE9,
  ProcessorFamilyAmdAthlonDualCore = 0xEA,
  ProcessorFamilyAmdSempronSI = 0xEB,
  ProcessorFamilyAmdPhenomII = 0xEC,
  ProcessorFamilyAmdAthlonII = 0xED,
  ProcessorFamilySixCoreAmdOpteron = 0xEE,
  ProcessorFamilyAmdSempronM = 0xEF,
  ProcessorFamilyi860 = 0xFA,
  ProcessorFamilyi960 = 0xFB,
  ProcessorFamilyIndicatorFamily2 = 0xFE,
  ProcessorFamilyReserved1 = 0xFF
}

///
/// Processor Information2 - Processor Family2.
///
public enum PROCESSOR_FAMILY2_DATA
{
  ProcessorFamilyARMv7 = 0x0100,
  ProcessorFamilyARMv8 = 0x0101,
  ProcessorFamilyARMv9 = 0x0102,
  ProcessorFamilySH3 = 0x0104,
  ProcessorFamilySH4 = 0x0105,
  ProcessorFamilyARM = 0x0118,
  ProcessorFamilyStrongARM = 0x0119,
  ProcessorFamily6x86 = 0x012C,
  ProcessorFamilyMediaGX = 0x012D,
  ProcessorFamilyMII = 0x012E,
  ProcessorFamilyWinChip = 0x0140,
  ProcessorFamilyDSP = 0x015E,
  ProcessorFamilyVideoProcessor = 0x01F4,
  ProcessorFamilyRiscvRV32 = 0x0200,
  ProcessorFamilyRiscVRV64 = 0x0201,
  ProcessorFamilyRiscVRV128 = 0x0202,
  ProcessorFamilyLoongArch = 0x0258,
  ProcessorFamilyLoongson1 = 0x0259,
  ProcessorFamilyLoongson2 = 0x025A,
  ProcessorFamilyLoongson3 = 0x025B,
  ProcessorFamilyLoongson2K = 0x025C,
  ProcessorFamilyLoongson3A = 0x025D,
  ProcessorFamilyLoongson3B = 0x025E,
  ProcessorFamilyLoongson3C = 0x025F,
  ProcessorFamilyLoongson3D = 0x0260,
  ProcessorFamilyLoongson3E = 0x0261,
  ProcessorFamilyDualCoreLoongson2K = 0x0262,
  ProcessorFamilyQuadCoreLoongson3A = 0x026C,
  ProcessorFamilyMultiCoreLoongson3A = 0x026D,
  ProcessorFamilyQuadCoreLoongson3B = 0x026E,
  ProcessorFamilyMultiCoreLoongson3B = 0x026F,
  ProcessorFamilyMultiCoreLoongson3C = 0x0270,
  ProcessorFamilyMultiCoreLoongson3D = 0x0271
}

///
/// Processor Information - Voltage.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PROCESSOR_VOLTAGE
{
  public byte ProcessorVoltageCapability5V = 1;
  public byte ProcessorVoltageCapability3_3V = 1;
  public byte ProcessorVoltageCapability2_9V = 1;
  public byte ProcessorVoltageCapabilityReserved = 1; ///< Bit 3, must be zero.
  public byte ProcessorVoltageReserved = 3; ///< Bits 4-6, must be zero.
  public byte ProcessorVoltageIndicateLegacy = 1;
}

///
/// Processor Information - Processor Upgrade.
///
public enum PROCESSOR_UPGRADE
{
  ProcessorUpgradeOther = 0x01,
  ProcessorUpgradeUnknown = 0x02,
  ProcessorUpgradeDaughterBoard = 0x03,
  ProcessorUpgradeZIFSocket = 0x04,
  ProcessorUpgradePiggyBack = 0x05, ///< Replaceable.
  ProcessorUpgradeNone = 0x06,
  ProcessorUpgradeLIFSocket = 0x07,
  ProcessorUpgradeSlot1 = 0x08,
  ProcessorUpgradeSlot2 = 0x09,
  ProcessorUpgrade370PinSocket = 0x0A,
  ProcessorUpgradeSlotA = 0x0B,
  ProcessorUpgradeSlotM = 0x0C,
  ProcessorUpgradeSocket423 = 0x0D,
  ProcessorUpgradeSocketA = 0x0E, ///< Socket 462.
  ProcessorUpgradeSocket478 = 0x0F,
  ProcessorUpgradeSocket754 = 0x10,
  ProcessorUpgradeSocket940 = 0x11,
  ProcessorUpgradeSocket939 = 0x12,
  ProcessorUpgradeSocketmPGA604 = 0x13,
  ProcessorUpgradeSocketLGA771 = 0x14,
  ProcessorUpgradeSocketLGA775 = 0x15,
  ProcessorUpgradeSocketS1 = 0x16,
  ProcessorUpgradeAM2 = 0x17,
  ProcessorUpgradeF1207 = 0x18,
  ProcessorSocketLGA1366 = 0x19,
  ProcessorUpgradeSocketG34 = 0x1A,
  ProcessorUpgradeSocketAM3 = 0x1B,
  ProcessorUpgradeSocketC32 = 0x1C,
  ProcessorUpgradeSocketLGA1156 = 0x1D,
  ProcessorUpgradeSocketLGA1567 = 0x1E,
  ProcessorUpgradeSocketPGA988A = 0x1F,
  ProcessorUpgradeSocketBGA1288 = 0x20,
  ProcessorUpgradeSocketrPGA988B = 0x21,
  ProcessorUpgradeSocketBGA1023 = 0x22,
  ProcessorUpgradeSocketBGA1224 = 0x23,
  ProcessorUpgradeSocketLGA1155 = 0x24, ///< SMBIOS spec 2.8.0 updated the name
  ProcessorUpgradeSocketLGA1356 = 0x25,
  ProcessorUpgradeSocketLGA2011 = 0x26,
  ProcessorUpgradeSocketFS1 = 0x27,
  ProcessorUpgradeSocketFS2 = 0x28,
  ProcessorUpgradeSocketFM1 = 0x29,
  ProcessorUpgradeSocketFM2 = 0x2A,
  ProcessorUpgradeSocketLGA2011_3 = 0x2B,
  ProcessorUpgradeSocketLGA1356_3 = 0x2C,
  ProcessorUpgradeSocketLGA1150 = 0x2D,
  ProcessorUpgradeSocketBGA1168 = 0x2E,
  ProcessorUpgradeSocketBGA1234 = 0x2F,
  ProcessorUpgradeSocketBGA1364 = 0x30,
  ProcessorUpgradeSocketAM4 = 0x31,
  ProcessorUpgradeSocketLGA1151 = 0x32,
  ProcessorUpgradeSocketBGA1356 = 0x33,
  ProcessorUpgradeSocketBGA1440 = 0x34,
  ProcessorUpgradeSocketBGA1515 = 0x35,
  ProcessorUpgradeSocketLGA3647_1 = 0x36,
  ProcessorUpgradeSocketSP3 = 0x37,
  ProcessorUpgradeSocketSP3r2 = 0x38,
  ProcessorUpgradeSocketLGA2066 = 0x39,
  ProcessorUpgradeSocketBGA1392 = 0x3A,
  ProcessorUpgradeSocketBGA1510 = 0x3B,
  ProcessorUpgradeSocketBGA1528 = 0x3C,
  ProcessorUpgradeSocketLGA4189 = 0x3D,
  ProcessorUpgradeSocketLGA1200 = 0x3E,
  ProcessorUpgradeSocketLGA4677 = 0x3F,
  ProcessorUpgradeSocketLGA1700 = 0x40,
  ProcessorUpgradeSocketBGA1744 = 0x41,
  ProcessorUpgradeSocketBGA1781 = 0x42,
  ProcessorUpgradeSocketBGA1211 = 0x43,
  ProcessorUpgradeSocketBGA2422 = 0x44,
  ProcessorUpgradeSocketLGA1211 = 0x45,
  ProcessorUpgradeSocketLGA2422 = 0x46,
  ProcessorUpgradeSocketLGA5773 = 0x47,
  ProcessorUpgradeSocketBGA5773 = 0x48
}

///
/// Processor ID Field Description
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PROCESSOR_SIGNATURE
{
  public uint ProcessorSteppingId = 4;
  public uint ProcessorModel = 4;
  public uint ProcessorFamily = 4;
  public uint ProcessorType = 2;
  public uint ProcessorReserved1 = 2;
  public uint ProcessorXModel = 4;
  public uint ProcessorXFamily = 8;
  public uint ProcessorReserved2 = 4;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PROCESSOR_FEATURE_FLAGS
{
  public uint ProcessorFpu = 1;
  public uint ProcessorVme = 1;
  public uint ProcessorDe = 1;
  public uint ProcessorPse = 1;
  public uint ProcessorTsc = 1;
  public uint ProcessorMsr = 1;
  public uint ProcessorPae = 1;
  public uint ProcessorMce = 1;
  public uint ProcessorCx8 = 1;
  public uint ProcessorApic = 1;
  public uint ProcessorReserved1 = 1;
  public uint ProcessorSep = 1;
  public uint ProcessorMtrr = 1;
  public uint ProcessorPge = 1;
  public uint ProcessorMca = 1;
  public uint ProcessorCmov = 1;
  public uint ProcessorPat = 1;
  public uint ProcessorPse36 = 1;
  public uint ProcessorPsn = 1;
  public uint ProcessorClfsh = 1;
  public uint ProcessorReserved2 = 1;
  public uint ProcessorDs = 1;
  public uint ProcessorAcpi = 1;
  public uint ProcessorMmx = 1;
  public uint ProcessorFxsr = 1;
  public uint ProcessorSse = 1;
  public uint ProcessorSse2 = 1;
  public uint ProcessorSs = 1;
  public uint ProcessorReserved3 = 1;
  public uint ProcessorTm = 1;
  public uint ProcessorReserved4 = 2;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PROCESSOR_CHARACTERISTIC_FLAGS
{
  public ushort ProcessorReserved1 = 1;
  public ushort ProcessorUnknown = 1;
  public ushort Processor64BitCapable = 1;
  public ushort ProcessorMultiCore = 1;
  public ushort ProcessorHardwareThread = 1;
  public ushort ProcessorExecuteProtection = 1;
  public ushort ProcessorEnhancedVirtualization = 1;
  public ushort ProcessorPowerPerformanceCtrl = 1;
  public ushort Processor128BitCapable = 1;
  public ushort ProcessorArm64SocId = 1;
  public ushort ProcessorReserved2 = 6;
}

///
/// Processor Information - Status
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte CpuStatus = 3; ///< Indicates the status of the processor.
  [FieldOffset(0)] public byte Reserved1 = 3; ///< Reserved for future use. Must be set to zero.
  [FieldOffset(0)] public byte SocketPopulated = 1; ///< Indicates if the processor socket is populated or not.
  [FieldOffset(0)] public byte Reserved2 = 1; ///< Reserved for future use. Must be set to zero.
}
byte Data;
} PROCESSOR_STATUS_DATA;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PROCESSOR_ID_DATA
{
  public PROCESSOR_SIGNATURE Signature;
  public PROCESSOR_FEATURE_FLAGS FeatureFlags;
}

///
/// Processor Information (Type 4).
///
/// The information in this structure defines the attributes of a single processor;
/// a separate structure instance is provided for each system processor socket/slot.
/// For example, a system with an IntelDX2 processor would have a single
/// structure instance, while a system with an IntelSX2 processor would have a structure
/// to describe the main CPU, and a second structure to describe the 80487 co-processor.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE4
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Socket;
  public byte ProcessorType;         ///< The enumeration value from PROCESSOR_TYPE_DATA.
  public byte ProcessorFamily;       ///< The enumeration value from PROCESSOR_FAMILY_DATA.
  public SMBIOS_TABLE_STRING ProcessorManufacturer;
  public PROCESSOR_ID_DATA ProcessorId;
  public SMBIOS_TABLE_STRING ProcessorVersion;
  public PROCESSOR_VOLTAGE Voltage;
  public ushort ExternalClock;
  public ushort MaxSpeed;
  public ushort CurrentSpeed;
  public byte Status;
  public byte ProcessorUpgrade;     ///< The enumeration value from PROCESSOR_UPGRADE.
  public ushort L1CacheHandle;
  public ushort L2CacheHandle;
  public ushort L3CacheHandle;
  public SMBIOS_TABLE_STRING SerialNumber;
  public SMBIOS_TABLE_STRING AssetTag;
  public SMBIOS_TABLE_STRING PartNumber;
  //
  // Add for smbios 2.5
  //
  public byte CoreCount;
  public byte EnabledCoreCount;
  public byte ThreadCount;
  public ushort ProcessorCharacteristics;
  //
  // Add for smbios 2.6
  //
  public ushort ProcessorFamily2;
  //
  // Add for smbios 3.0
  //
  public ushort CoreCount2;
  public ushort EnabledCoreCount2;
  public ushort ThreadCount2;
  //
  // Add for smbios 3.6
  //
  public ushort ThreadEnabled;
}

///
/// Memory Controller Error Detecting Method.
///
public enum MEMORY_ERROR_DETECT_METHOD
{
  ErrorDetectingMethodOther = 0x01,
  ErrorDetectingMethodUnknown = 0x02,
  ErrorDetectingMethodNone = 0x03,
  ErrorDetectingMethodParity = 0x04,
  ErrorDetectingMethod32Ecc = 0x05,
  ErrorDetectingMethod64Ecc = 0x06,
  ErrorDetectingMethod128Ecc = 0x07,
  ErrorDetectingMethodCrc = 0x08
}

///
/// Memory Controller Error Correcting Capability.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEMORY_ERROR_CORRECT_CAPABILITY
{
  public byte Other = 1;
  public byte Unknown = 1;
  public byte None = 1;
  public byte SingleBitErrorCorrect = 1;
  public byte DoubleBitErrorCorrect = 1;
  public byte ErrorScrubbing = 1;
  public byte Reserved = 2;
}

///
/// Memory Controller Information - Interleave Support.
///
public enum MEMORY_SUPPORT_INTERLEAVE_TYPE
{
  MemoryInterleaveOther = 0x01,
  MemoryInterleaveUnknown = 0x02,
  MemoryInterleaveOneWay = 0x03,
  MemoryInterleaveTwoWay = 0x04,
  MemoryInterleaveFourWay = 0x05,
  MemoryInterleaveEightWay = 0x06,
  MemoryInterleaveSixteenWay = 0x07
}

///
/// Memory Controller Information - Memory Speeds.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEMORY_SPEED_TYPE
{
  public ushort Other = 1;
  public ushort Unknown = 1;
  public ushort SeventyNs = 1;
  public ushort SixtyNs = 1;
  public ushort FiftyNs = 1;
  public ushort Reserved = 11;
}

///
/// Memory Controller Information (Type 5, Obsolete).
///
/// The information in this structure defines the attributes of the system's memory controller(s)
/// and the supported attributes of any memory-modules present in the sockets controlled by
/// this controller.
/// Note: This structure, and its companion Memory Module Information (Type 6, Obsolete),
/// are obsolete starting with version 2.1 of this specification. The Physical Memory Array (Type 16)
/// and Memory Device (Type 17) structures should be used instead.  BIOS providers might
/// choose to implement both memory description types to allow existing DMI browsers
/// to properly display the system's memory attributes.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE5
{
  public SMBIOS_STRUCTURE Hdr;
  public byte ErrDetectMethod;         ///< The enumeration value from MEMORY_ERROR_DETECT_METHOD.
  public MEMORY_ERROR_CORRECT_CAPABILITY ErrCorrectCapability;
  public byte SupportInterleave;       ///< The enumeration value from MEMORY_SUPPORT_INTERLEAVE_TYPE.
  public byte CurrentInterleave;       ///< The enumeration value from MEMORY_SUPPORT_INTERLEAVE_TYPE .
  public byte MaxMemoryModuleSize;
  public MEMORY_SPEED_TYPE SupportSpeed;
  public ushort SupportMemoryType;
  public byte MemoryModuleVoltage;
  public byte AssociatedMemorySlotNum;
  public fixed ushort MemoryModuleConfigHandles[1];
}

///
/// Memory Module Information - Memory Types
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEMORY_CURRENT_TYPE
{
  public ushort Other = 1;
  public ushort Unknown = 1;
  public ushort Standard = 1;
  public ushort FastPageMode = 1;
  public ushort Edo = 1;
  public ushort Parity = 1;
  public ushort Ecc = 1;
  public ushort Simm = 1;
  public ushort Dimm = 1;
  public ushort BurstEdo = 1;
  public ushort Sdram = 1;
  public ushort Reserved = 5;
}

///
/// Memory Module Information - Memory Size.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEMORY_INSTALLED_ENABLED_SIZE
{
  public byte InstalledOrEnabledSize = 7; ///< Size (n), where 2**n is the size in MB.
  public byte SingleOrDoubleBank = 1;
}

///
/// Memory Module Information (Type 6, Obsolete)
///
/// One Memory Module Information structure is included for each memory-module socket
/// in the system.  The structure describes the speed, type, size, and error status
/// of each system memory module.  The supported attributes of each module are described
/// by the "owning" Memory Controller Information structure.
/// Note:  This structure, and its companion Memory Controller Information (Type 5, Obsolete),
/// are obsolete starting with version 2.1 of this specification. The Physical Memory Array (Type 16)
/// and Memory Device (Type 17) structures should be used instead.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE6
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING SocketDesignation;
  public byte BankConnections;
  public byte CurrentSpeed;
  public MEMORY_CURRENT_TYPE CurrentMemoryType;
  public MEMORY_INSTALLED_ENABLED_SIZE InstalledSize;
  public MEMORY_INSTALLED_ENABLED_SIZE EnabledSize;
  public byte ErrorStatus;
}

///
/// Cache Information - SRAM Type.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CACHE_SRAM_TYPE_DATA
{
  public ushort Other = 1;
  public ushort Unknown = 1;
  public ushort NonBurst = 1;
  public ushort Burst = 1;
  public ushort PipelineBurst = 1;
  public ushort Synchronous = 1;
  public ushort Asynchronous = 1;
  public ushort Reserved = 9;
}

///
/// Cache Information - Error Correction Type.
///
public enum CACHE_ERROR_TYPE_DATA
{
  CacheErrorOther = 0x01,
  CacheErrorUnknown = 0x02,
  CacheErrorNone = 0x03,
  CacheErrorParity = 0x04,
  CacheErrorSingleBit = 0x05, ///< ECC
  CacheErrorMultiBit = 0x06  ///< ECC
}

///
/// Cache Information - System Cache Type.
///
public enum CACHE_TYPE_DATA
{
  CacheTypeOther = 0x01,
  CacheTypeUnknown = 0x02,
  CacheTypeInstruction = 0x03,
  CacheTypeData = 0x04,
  CacheTypeUnified = 0x05
}

///
/// Cache Information - Associativity.
///
public enum CACHE_ASSOCIATIVITY_DATA
{
  CacheAssociativityOther = 0x01,
  CacheAssociativityUnknown = 0x02,
  CacheAssociativityDirectMapped = 0x03,
  CacheAssociativity2Way = 0x04,
  CacheAssociativity4Way = 0x05,
  CacheAssociativityFully = 0x06,
  CacheAssociativity8Way = 0x07,
  CacheAssociativity16Way = 0x08,
  CacheAssociativity12Way = 0x09,
  CacheAssociativity24Way = 0x0A,
  CacheAssociativity32Way = 0x0B,
  CacheAssociativity48Way = 0x0C,
  CacheAssociativity64Way = 0x0D,
  CacheAssociativity20Way = 0x0E
}

///
/// Cache Information (Type 7).
///
/// The information in this structure defines the attributes of CPU cache device in the system.
/// One structure is specified for each such device, whether the device is internal to
/// or external to the CPU module.  Cache modules can be associated with a processor structure
/// in one or two ways, depending on the SMBIOS version.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE7
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING SocketDesignation;
  public ushort CacheConfiguration;
  public ushort MaximumCacheSize;
  public ushort InstalledSize;
  public CACHE_SRAM_TYPE_DATA SupportedSRAMType;
  public CACHE_SRAM_TYPE_DATA CurrentSRAMType;
  public byte CacheSpeed;
  public byte ErrorCorrectionType;              ///< The enumeration value from CACHE_ERROR_TYPE_DATA.
  public byte SystemCacheType;                  ///< The enumeration value from CACHE_TYPE_DATA.
  public byte Associativity;                    ///< The enumeration value from CACHE_ASSOCIATIVITY_DATA.
  //
  // Add for smbios 3.1.0
  //
  public uint MaximumCacheSize2;
  public uint InstalledSize2;
}

///
/// Port Connector Information - Connector Types.
///
public enum MISC_PORT_CONNECTOR_TYPE
{
  PortConnectorTypeNone = 0x00,
  PortConnectorTypeCentronics = 0x01,
  PortConnectorTypeMiniCentronics = 0x02,
  PortConnectorTypeProprietary = 0x03,
  PortConnectorTypeDB25Male = 0x04,
  PortConnectorTypeDB25Female = 0x05,
  PortConnectorTypeDB15Male = 0x06,
  PortConnectorTypeDB15Female = 0x07,
  PortConnectorTypeDB9Male = 0x08,
  PortConnectorTypeDB9Female = 0x09,
  PortConnectorTypeRJ11 = 0x0A,
  PortConnectorTypeRJ45 = 0x0B,
  PortConnectorType50PinMiniScsi = 0x0C,
  PortConnectorTypeMiniDin = 0x0D,
  PortConnectorTypeMicroDin = 0x0E,
  PortConnectorTypePS2 = 0x0F,
  PortConnectorTypeInfrared = 0x10,
  PortConnectorTypeHpHil = 0x11,
  PortConnectorTypeUsb = 0x12,
  PortConnectorTypeSsaScsi = 0x13,
  PortConnectorTypeCircularDin8Male = 0x14,
  PortConnectorTypeCircularDin8Female = 0x15,
  PortConnectorTypeOnboardIde = 0x16,
  PortConnectorTypeOnboardFloppy = 0x17,
  PortConnectorType9PinDualInline = 0x18,
  PortConnectorType25PinDualInline = 0x19,
  PortConnectorType50PinDualInline = 0x1A,
  PortConnectorType68PinDualInline = 0x1B,
  PortConnectorTypeOnboardSoundInput = 0x1C,
  PortConnectorTypeMiniCentronicsType14 = 0x1D,
  PortConnectorTypeMiniCentronicsType26 = 0x1E,
  PortConnectorTypeHeadPhoneMiniJack = 0x1F,
  PortConnectorTypeBNC = 0x20,
  PortConnectorType1394 = 0x21,
  PortConnectorTypeSasSata = 0x22,
  PortConnectorTypeUsbTypeC = 0x23,
  PortConnectorTypePC98 = 0xA0,
  PortConnectorTypePC98Hireso = 0xA1,
  PortConnectorTypePCH98 = 0xA2,
  PortConnectorTypePC98Note = 0xA3,
  PortConnectorTypePC98Full = 0xA4,
  PortConnectorTypeOther = 0xFF
}

///
/// Port Connector Information - Port Types
///
public enum MISC_PORT_TYPE
{
  PortTypeNone = 0x00,
  PortTypeParallelXtAtCompatible = 0x01,
  PortTypeParallelPortPs2 = 0x02,
  PortTypeParallelPortEcp = 0x03,
  PortTypeParallelPortEpp = 0x04,
  PortTypeParallelPortEcpEpp = 0x05,
  PortTypeSerialXtAtCompatible = 0x06,
  PortTypeSerial16450Compatible = 0x07,
  PortTypeSerial16550Compatible = 0x08,
  PortTypeSerial16550ACompatible = 0x09,
  PortTypeScsi = 0x0A,
  PortTypeMidi = 0x0B,
  PortTypeJoyStick = 0x0C,
  PortTypeKeyboard = 0x0D,
  PortTypeMouse = 0x0E,
  PortTypeSsaScsi = 0x0F,
  PortTypeUsb = 0x10,
  PortTypeFireWire = 0x11,
  PortTypePcmciaTypeI = 0x12,
  PortTypePcmciaTypeII = 0x13,
  PortTypePcmciaTypeIII = 0x14,
  PortTypeCardBus = 0x15,
  PortTypeAccessBusPort = 0x16,
  PortTypeScsiII = 0x17,
  PortTypeScsiWide = 0x18,
  PortTypePC98 = 0x19,
  PortTypePC98Hireso = 0x1A,
  PortTypePCH98 = 0x1B,
  PortTypeVideoPort = 0x1C,
  PortTypeAudioPort = 0x1D,
  PortTypeModemPort = 0x1E,
  PortTypeNetworkPort = 0x1F,
  PortTypeSata = 0x20,
  PortTypeSas = 0x21,
  PortTypeMfdp = 0x22,    ///< Multi-Function Display Port
  PortTypeThunderbolt = 0x23,
  PortType8251Compatible = 0xA0,
  PortType8251FifoCompatible = 0xA1,
  PortTypeOther = 0xFF
}

///
/// Port Connector Information (Type 8).
///
/// The information in this structure defines the attributes of a system port connector,
/// e.g. parallel, serial, keyboard, or mouse ports.  The port's type and connector information
/// are provided. One structure is present for each port provided by the system.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE8
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING InternalReferenceDesignator;
  public byte InternalConnectorType;             ///< The enumeration value from MISC_PORT_CONNECTOR_TYPE.
  public SMBIOS_TABLE_STRING ExternalReferenceDesignator;
  public byte ExternalConnectorType;             ///< The enumeration value from MISC_PORT_CONNECTOR_TYPE.
  public byte PortType;                          ///< The enumeration value from MISC_PORT_TYPE.
}

///
/// System Slots - Slot Type
///
public enum MISC_SLOT_TYPE
{
  SlotTypeOther = 0x01,
  SlotTypeUnknown = 0x02,
  SlotTypeIsa = 0x03,
  SlotTypeMca = 0x04,
  SlotTypeEisa = 0x05,
  SlotTypePci = 0x06,
  SlotTypePcmcia = 0x07,
  SlotTypeVlVesa = 0x08,
  SlotTypeProprietary = 0x09,
  SlotTypeProcessorCardSlot = 0x0A,
  SlotTypeProprietaryMemoryCardSlot = 0x0B,
  SlotTypeIORiserCardSlot = 0x0C,
  SlotTypeNuBus = 0x0D,
  SlotTypePci66MhzCapable = 0x0E,
  SlotTypeAgp = 0x0F,
  SlotTypeApg2X = 0x10,
  SlotTypeAgp4X = 0x11,
  SlotTypePciX = 0x12,
  SlotTypeAgp8X = 0x13,
  SlotTypeM2Socket1_DP = 0x14,
  SlotTypeM2Socket1_SD = 0x15,
  SlotTypeM2Socket2 = 0x16,
  SlotTypeM2Socket3 = 0x17,
  SlotTypeMxmTypeI = 0x18,
  SlotTypeMxmTypeII = 0x19,
  SlotTypeMxmTypeIIIStandard = 0x1A,
  SlotTypeMxmTypeIIIHe = 0x1B,
  SlotTypeMxmTypeIV = 0x1C,
  SlotTypeMxm30TypeA = 0x1D,
  SlotTypeMxm30TypeB = 0x1E,
  SlotTypePciExpressGen2Sff_8639 = 0x1F,
  SlotTypePciExpressGen3Sff_8639 = 0x20,
  SlotTypePciExpressMini52pinWithBSKO = 0x21,    ///< PCI Express Mini 52-pin (CEM spec. 2.0) with bottom-side keep-outs.
  SlotTypePciExpressMini52pinWithoutBSKO = 0x22,    ///< PCI Express Mini 52-pin (CEM spec. 2.0) without bottom-side keep-outs.
  SlotTypePciExpressMini76pin = 0x23,    ///< PCI Express Mini 76-pin (CEM spec. 2.0) Corresponds to Display-Mini card.
  SlotTypePCIExpressGen4SFF_8639 = 0x24,    ///< U.2
  SlotTypePCIExpressGen5SFF_8639 = 0x25,    ///< U.2
  SlotTypeOCPNIC30SmallFormFactor = 0x26,    ///< SFF
  SlotTypeOCPNIC30LargeFormFactor = 0x27,    ///< LFF
  SlotTypeOCPNICPriorto30 = 0x28,
  SlotTypeCXLFlexbus10 = 0x30,
  SlotTypePC98C20 = 0xA0,
  SlotTypePC98C24 = 0xA1,
  SlotTypePC98E = 0xA2,
  SlotTypePC98LocalBus = 0xA3,
  SlotTypePC98Card = 0xA4,
  SlotTypePciExpress = 0xA5,
  SlotTypePciExpressX1 = 0xA6,
  SlotTypePciExpressX2 = 0xA7,
  SlotTypePciExpressX4 = 0xA8,
  SlotTypePciExpressX8 = 0xA9,
  SlotTypePciExpressX16 = 0xAA,
  SlotTypePciExpressGen2 = 0xAB,
  SlotTypePciExpressGen2X1 = 0xAC,
  SlotTypePciExpressGen2X2 = 0xAD,
  SlotTypePciExpressGen2X4 = 0xAE,
  SlotTypePciExpressGen2X8 = 0xAF,
  SlotTypePciExpressGen2X16 = 0xB0,
  SlotTypePciExpressGen3 = 0xB1,
  SlotTypePciExpressGen3X1 = 0xB2,
  SlotTypePciExpressGen3X2 = 0xB3,
  SlotTypePciExpressGen3X4 = 0xB4,
  SlotTypePciExpressGen3X8 = 0xB5,
  SlotTypePciExpressGen3X16 = 0xB6,
  SlotTypePciExpressGen4 = 0xB8,
  SlotTypePciExpressGen4X1 = 0xB9,
  SlotTypePciExpressGen4X2 = 0xBA,
  SlotTypePciExpressGen4X4 = 0xBB,
  SlotTypePciExpressGen4X8 = 0xBC,
  SlotTypePciExpressGen4X16 = 0xBD,
  SlotTypePCIExpressGen5 = 0xBE,
  SlotTypePCIExpressGen5X1 = 0xBF,
  SlotTypePCIExpressGen5X2 = 0xC0,
  SlotTypePCIExpressGen5X4 = 0xC1,
  SlotTypePCIExpressGen5X8 = 0xC2,
  SlotTypePCIExpressGen5X16 = 0xC3,
  SlotTypePCIExpressGen6andBeyond = 0xC4,
  SlotTypeEnterpriseandDatacenter1UE1FormFactorSlot = 0xC5,
  SlotTypeEnterpriseandDatacenter3E3FormFactorSlot = 0xC6
}

///
/// System Slots - Slot Data Bus Width.
///
public enum MISC_SLOT_DATA_BUS_WIDTH
{
  SlotDataBusWidthOther = 0x01,
  SlotDataBusWidthUnknown = 0x02,
  SlotDataBusWidth8Bit = 0x03,
  SlotDataBusWidth16Bit = 0x04,
  SlotDataBusWidth32Bit = 0x05,
  SlotDataBusWidth64Bit = 0x06,
  SlotDataBusWidth128Bit = 0x07,
  SlotDataBusWidth1X = 0x08,    ///< Or X1
  SlotDataBusWidth2X = 0x09,    ///< Or X2
  SlotDataBusWidth4X = 0x0A,    ///< Or X4
  SlotDataBusWidth8X = 0x0B,    ///< Or X8
  SlotDataBusWidth12X = 0x0C,    ///< Or X12
  SlotDataBusWidth16X = 0x0D,    ///< Or X16
  SlotDataBusWidth32X = 0x0E     ///< Or X32
}

///
/// System Slots - Slot Physical Width.
///
public enum MISC_SLOT_PHYSICAL_WIDTH
{
  SlotPhysicalWidthOther = 0x01,
  SlotPhysicalWidthUnknown = 0x02,
  SlotPhysicalWidth8Bit = 0x03,
  SlotPhysicalWidth16Bit = 0x04,
  SlotPhysicalWidth32Bit = 0x05,
  SlotPhysicalWidth64Bit = 0x06,
  SlotPhysicalWidth128Bit = 0x07,
  SlotPhysicalWidth1X = 0x08,    ///< Or X1
  SlotPhysicalWidth2X = 0x09,    ///< Or X2
  SlotPhysicalWidth4X = 0x0A,    ///< Or X4
  SlotPhysicalWidth8X = 0x0B,    ///< Or X8
  SlotPhysicalWidth12X = 0x0C,    ///< Or X12
  SlotPhysicalWidth16X = 0x0D,    ///< Or X16
  SlotPhysicalWidth32X = 0x0E     ///< Or X32
}

///
/// System Slots - Slot Information.
///
public enum MISC_SLOT_INFORMATION
{
  Others = 0x00,
  Gen1 = 0x01,
  Gen2 = 0x01,
  Gen3 = 0x03,
  Gen4 = 0x04,
  Gen5 = 0x05,
  Gen6 = 0x06
}

///
/// System Slots - Current Usage.
///
public enum MISC_SLOT_USAGE
{
  SlotUsageOther = 0x01,
  SlotUsageUnknown = 0x02,
  SlotUsageAvailable = 0x03,
  SlotUsageInUse = 0x04,
  SlotUsageUnavailable = 0x05
}

///
/// System Slots - Slot Length.
///
public enum MISC_SLOT_LENGTH
{
  SlotLengthOther = 0x01,
  SlotLengthUnknown = 0x02,
  SlotLengthShort = 0x03,
  SlotLengthLong = 0x04
}

///
/// System Slots - Slot Characteristics 1.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MISC_SLOT_CHARACTERISTICS1
{
  public byte CharacteristicsUnknown = 1;
  public byte Provides50Volts = 1;
  public byte Provides33Volts = 1;
  public byte SharedSlot = 1;
  public byte PcCard16Supported = 1;
  public byte CardBusSupported = 1;
  public byte ZoomVideoSupported = 1;
  public byte ModemRingResumeSupported = 1;
}
///
/// System Slots - Slot Characteristics 2.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MISC_SLOT_CHARACTERISTICS2
{
  public byte PmeSignalSupported = 1;
  public byte HotPlugDevicesSupported = 1;
  public byte SmbusSignalSupported = 1;
  public byte BifurcationSupported = 1;
  public byte AsyncSurpriseRemoval = 1;
  public byte FlexbusSlotCxl10Capable = 1;
  public byte FlexbusSlotCxl20Capable = 1;
  public byte Reserved = 1; ///< Set to 0.
}

///
/// System Slots - Slot Height
///
public enum MISC_SLOT_HEIGHT
{
  SlotHeightNone = 0x00,
  SlotHeightOther = 0x01,
  SlotHeightUnknown = 0x02,
  SlotHeightFullHeight = 0x03,
  SlotHeightLowProfile = 0x04
}

///
/// System Slots - Peer Segment/Bus/Device/Function/Width Groups
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MISC_SLOT_PEER_GROUP
{
  public ushort SegmentGroupNum;
  public byte BusNum;
  public byte DevFuncNum;
  public byte DataBusWidth;
}

///
/// System Slots (Type 9)
///
/// The information in this structure defines the attributes of a system slot.
/// One structure is provided for each slot in the system.
///
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE9
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING SlotDesignation;
  public byte SlotType;               ///< The enumeration value from MISC_SLOT_TYPE.
  public byte SlotDataBusWidth;       ///< The enumeration value from MISC_SLOT_DATA_BUS_WIDTH.
  public byte CurrentUsage;           ///< The enumeration value from MISC_SLOT_USAGE.
  public byte SlotLength;             ///< The enumeration value from MISC_SLOT_LENGTH.
  public ushort SlotID;
  public MISC_SLOT_CHARACTERISTICS1 SlotCharacteristics1;
  public MISC_SLOT_CHARACTERISTICS2 SlotCharacteristics2;
  //
  // Add for smbios 2.6
  //
  public ushort SegmentGroupNum;
  public byte BusNum;
  public byte DevFuncNum;
  //
  // Add for smbios 3.2
  //
  public byte DataBusWidth;
  public byte PeerGroupingCount;
  public fixed MISC_SLOT_PEER_GROUP PeerGroups[1];
  //
  // Since PeerGroups has a variable number of entries, must not define new
  // fields in the structure. Remaining fields can be referenced using
  // SMBIOS_TABLE_TYPE9_EXTENDED structure
  //
}

///
/// Extended structure for System Slots (Type 9)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE9_EXTENDED
{
  //
  // Add for smbios 3.4
  //
  public byte SlotInformation;
  public byte SlotPhysicalWidth;
  public ushort SlotPitch;
  //
  // Add for smbios 3.5
  //
  public byte SlotHeight;             ///< The enumeration value from MISC_SLOT_HEIGHT.
}

///
/// On Board Devices Information - Device Types.
///
public enum MISC_ONBOARD_DEVICE_TYPE
{
  OnBoardDeviceTypeOther = 0x01,
  OnBoardDeviceTypeUnknown = 0x02,
  OnBoardDeviceTypeVideo = 0x03,
  OnBoardDeviceTypeScsiController = 0x04,
  OnBoardDeviceTypeEthernet = 0x05,
  OnBoardDeviceTypeTokenRing = 0x06,
  OnBoardDeviceTypeSound = 0x07,
  OnBoardDeviceTypePATAController = 0x08,
  OnBoardDeviceTypeSATAController = 0x09,
  OnBoardDeviceTypeSASController = 0x0A
}

///
/// Device Item Entry
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct DEVICE_STRUCT
{
  public byte DeviceType;                ///< Bit [6:0] - enumeration type of device from MISC_ONBOARD_DEVICE_TYPE.
                                         ///< Bit 7     - 1 : device enabled, 0 : device disabled.
  public SMBIOS_TABLE_STRING DescriptionString;
}

///
/// On Board Devices Information (Type 10, obsolete).
///
/// Note: This structure is obsolete starting with version 2.6 specification; the Onboard Devices Extended
/// Information (Type 41) structure should be used instead . BIOS providers can choose to implement both
/// types to allow existing SMBIOS browsers to properly display the system's onboard devices information.
/// The information in this structure defines the attributes of devices that are onboard (soldered onto)
/// a system element, usually the baseboard.  In general, an entry in this table implies that the BIOS
/// has some level of control over the enabling of the associated device for use by the system.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE10
{
  public SMBIOS_STRUCTURE Hdr;
  public fixed DEVICE_STRUCT Device[1];
}

///
/// OEM Strings (Type 11).
/// This structure contains free form strings defined by the OEM. Examples of this are:
/// Part Numbers for Reference Documents for the system, contact information for the manufacturer, etc.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE11
{
  public SMBIOS_STRUCTURE Hdr;
  public byte StringCount;
}

///
/// System Configuration Options (Type 12).
///
/// This structure contains information required to configure the base board's Jumpers and Switches.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE12
{
  public SMBIOS_STRUCTURE Hdr;
  public byte StringCount;
}

///
/// BIOS Language Information (Type 13).
///
/// The information in this structure defines the installable language attributes of the BIOS.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE13
{
  public SMBIOS_STRUCTURE Hdr;
  public byte InstallableLanguages;
  public byte Flags;
  public fixed byte Reserved[15];
  public SMBIOS_TABLE_STRING CurrentLanguages;
}

///
/// Group Item Entry
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct GROUP_STRUCT
{
  public byte ItemType;
  public ushort ItemHandle;
}

///
/// Group Associations (Type 14).
///
/// The Group Associations structure is provided for OEMs who want to specify
/// the arrangement or hierarchy of certain components (including other Group Associations)
/// within the system.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE14
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING GroupName;
  public fixed GROUP_STRUCT Group[1];
}

///
/// System Event Log - Event Log Types.
///
public enum EVENT_LOG_TYPE_DATA
{
  EventLogTypeReserved = 0x00,
  EventLogTypeSingleBitECC = 0x01,
  EventLogTypeMultiBitECC = 0x02,
  EventLogTypeParityMemErr = 0x03,
  EventLogTypeBusTimeOut = 0x04,
  EventLogTypeIOChannelCheck = 0x05,
  EventLogTypeSoftwareNMI = 0x06,
  EventLogTypePOSTMemResize = 0x07,
  EventLogTypePOSTErr = 0x08,
  EventLogTypePCIParityErr = 0x09,
  EventLogTypePCISystemErr = 0x0A,
  EventLogTypeCPUFailure = 0x0B,
  EventLogTypeEISATimeOut = 0x0C,
  EventLogTypeMemLogDisabled = 0x0D,
  EventLogTypeLoggingDisabled = 0x0E,
  EventLogTypeSysLimitExce = 0x10,
  EventLogTypeAsyncHWTimer = 0x11,
  EventLogTypeSysConfigInfo = 0x12,
  EventLogTypeHDInfo = 0x13,
  EventLogTypeSysReconfig = 0x14,
  EventLogTypeUncorrectCPUErr = 0x15,
  EventLogTypeAreaResetAndClr = 0x16,
  EventLogTypeSystemBoot = 0x17,
  EventLogTypeUnused = 0x18,  ///< 0x18 - 0x7F
  EventLogTypeAvailForSys = 0x80,  ///< 0x80 - 0xFE
  EventLogTypeEndOfLog = 0xFF
}

///
/// System Event Log - Variable Data Format Types.
///
public enum EVENT_LOG_VARIABLE_DATA
{
  EventLogVariableNone = 0x00,
  EventLogVariableHandle = 0x01,
  EventLogVariableMutilEvent = 0x02,
  EventLogVariableMutilEventHandle = 0x03,
  EventLogVariablePOSTResultBitmap = 0x04,
  EventLogVariableSysManagementType = 0x05,
  EventLogVariableMutliEventSysManagmentType = 0x06,
  EventLogVariableUnused = 0x07,
  EventLogVariableOEMAssigned = 0x80
}

///
/// Event Log Type Descriptors
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EVENT_LOG_TYPE
{
  public byte LogType;                                 ///< The enumeration value from EVENT_LOG_TYPE_DATA.
  public byte DataFormatType;
}

///
/// System Event Log (Type 15).
///
/// The presence of this structure within the SMBIOS data returned for a system indicates
/// that the system supports an event log.  An event log is a fixed-length area within a
/// non-volatile storage element, starting with a fixed-length (and vendor-specific) header
/// record, followed by one or more variable-length log records.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE15
{
  public SMBIOS_STRUCTURE Hdr;
  public ushort LogAreaLength;
  public ushort LogHeaderStartOffset;
  public ushort LogDataStartOffset;
  public byte AccessMethod;
  public byte LogStatus;
  public uint LogChangeToken;
  public uint AccessMethodAddress;
  public byte LogHeaderFormat;
  public byte NumberOfSupportedLogTypeDescriptors;
  public byte LengthOfLogTypeDescriptor;
  public fixed EVENT_LOG_TYPE EventLogTypeDescriptors[1];
}

///
/// Physical Memory Array - Location.
///
public enum MEMORY_ARRAY_LOCATION
{
  MemoryArrayLocationOther = 0x01,
  MemoryArrayLocationUnknown = 0x02,
  MemoryArrayLocationSystemBoard = 0x03,
  MemoryArrayLocationIsaAddonCard = 0x04,
  MemoryArrayLocationEisaAddonCard = 0x05,
  MemoryArrayLocationPciAddonCard = 0x06,
  MemoryArrayLocationMcaAddonCard = 0x07,
  MemoryArrayLocationPcmciaAddonCard = 0x08,
  MemoryArrayLocationProprietaryAddonCard = 0x09,
  MemoryArrayLocationNuBus = 0x0A,
  MemoryArrayLocationPc98C20AddonCard = 0xA0,
  MemoryArrayLocationPc98C24AddonCard = 0xA1,
  MemoryArrayLocationPc98EAddonCard = 0xA2,
  MemoryArrayLocationPc98LocalBusAddonCard = 0xA3,
  MemoryArrayLocationCXLAddonCard = 0xA4
}

///
/// Physical Memory Array - Use.
///
public enum MEMORY_ARRAY_USE
{
  MemoryArrayUseOther = 0x01,
  MemoryArrayUseUnknown = 0x02,
  MemoryArrayUseSystemMemory = 0x03,
  MemoryArrayUseVideoMemory = 0x04,
  MemoryArrayUseFlashMemory = 0x05,
  MemoryArrayUseNonVolatileRam = 0x06,
  MemoryArrayUseCacheMemory = 0x07
}

///
/// Physical Memory Array - Error Correction Types.
///
public enum MEMORY_ERROR_CORRECTION
{
  MemoryErrorCorrectionOther = 0x01,
  MemoryErrorCorrectionUnknown = 0x02,
  MemoryErrorCorrectionNone = 0x03,
  MemoryErrorCorrectionParity = 0x04,
  MemoryErrorCorrectionSingleBitEcc = 0x05,
  MemoryErrorCorrectionMultiBitEcc = 0x06,
  MemoryErrorCorrectionCrc = 0x07
}

///
/// Physical Memory Array (Type 16).
///
/// This structure describes a collection of memory devices that operate
/// together to form a memory address space.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE16
{
  public SMBIOS_STRUCTURE Hdr;
  public byte Location;                             ///< The enumeration value from MEMORY_ARRAY_LOCATION.
  public byte Use;                                  ///< The enumeration value from MEMORY_ARRAY_USE.
  public byte MemoryErrorCorrection;                ///< The enumeration value from MEMORY_ERROR_CORRECTION.
  public uint MaximumCapacity;
  public ushort MemoryErrorInformationHandle;
  public ushort NumberOfMemoryDevices;
  //
  // Add for smbios 2.7
  //
  public ulong ExtendedMaximumCapacity;
}

///
/// Memory Device - Form Factor.
///
public enum MEMORY_FORM_FACTOR
{
  MemoryFormFactorOther = 0x01,
  MemoryFormFactorUnknown = 0x02,
  MemoryFormFactorSimm = 0x03,
  MemoryFormFactorSip = 0x04,
  MemoryFormFactorChip = 0x05,
  MemoryFormFactorDip = 0x06,
  MemoryFormFactorZip = 0x07,
  MemoryFormFactorProprietaryCard = 0x08,
  MemoryFormFactorDimm = 0x09,
  MemoryFormFactorTsop = 0x0A,
  MemoryFormFactorRowOfChips = 0x0B,
  MemoryFormFactorRimm = 0x0C,
  MemoryFormFactorSodimm = 0x0D,
  MemoryFormFactorSrimm = 0x0E,
  MemoryFormFactorFbDimm = 0x0F,
  MemoryFormFactorDie = 0x10
}

///
/// Memory Device - Type
///
public enum MEMORY_DEVICE_TYPE
{
  MemoryTypeOther = 0x01,
  MemoryTypeUnknown = 0x02,
  MemoryTypeDram = 0x03,
  MemoryTypeEdram = 0x04,
  MemoryTypeVram = 0x05,
  MemoryTypeSram = 0x06,
  MemoryTypeRam = 0x07,
  MemoryTypeRom = 0x08,
  MemoryTypeFlash = 0x09,
  MemoryTypeEeprom = 0x0A,
  MemoryTypeFeprom = 0x0B,
  MemoryTypeEprom = 0x0C,
  MemoryTypeCdram = 0x0D,
  MemoryType3Dram = 0x0E,
  MemoryTypeSdram = 0x0F,
  MemoryTypeSgram = 0x10,
  MemoryTypeRdram = 0x11,
  MemoryTypeDdr = 0x12,
  MemoryTypeDdr2 = 0x13,
  MemoryTypeDdr2FbDimm = 0x14,
  MemoryTypeDdr3 = 0x18,
  MemoryTypeFbd2 = 0x19,
  MemoryTypeDdr4 = 0x1A,
  MemoryTypeLpddr = 0x1B,
  MemoryTypeLpddr2 = 0x1C,
  MemoryTypeLpddr3 = 0x1D,
  MemoryTypeLpddr4 = 0x1E,
  MemoryTypeLogicalNonVolatileDevice = 0x1F,
  MemoryTypeHBM = 0x20,
  MemoryTypeHBM2 = 0x21,
  MemoryTypeDdr5 = 0x22,
  MemoryTypeLpddr5 = 0x23,
  MemoryTypeHBM3 = 0x24
}

///
/// Memory Device - Type Detail
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEMORY_DEVICE_TYPE_DETAIL
{
  public ushort Reserved = 1;
  public ushort Other = 1;
  public ushort Unknown = 1;
  public ushort FastPaged = 1;
  public ushort StaticColumn = 1;
  public ushort PseudoStatic = 1;
  public ushort Rambus = 1;
  public ushort Synchronous = 1;
  public ushort Cmos = 1;
  public ushort Edo = 1;
  public ushort WindowDram = 1;
  public ushort CacheDram = 1;
  public ushort Nonvolatile = 1;
  public ushort Registered = 1;
  public ushort Unbuffered = 1;
  public ushort LrDimm = 1;
}

///
/// Memory Device - Memory Technology
///
public enum MEMORY_DEVICE_TECHNOLOGY
{
  MemoryTechnologyOther = 0x01,
  MemoryTechnologyUnknown = 0x02,
  MemoryTechnologyDram = 0x03,
  MemoryTechnologyNvdimmN = 0x04,
  MemoryTechnologyNvdimmF = 0x05,
  MemoryTechnologyNvdimmP = 0x06,
  //
  // This definition is updated to represent Intel
  // Optane DC Persistent Memory in SMBIOS spec 3.4.0
  //
  MemoryTechnologyIntelOptanePersistentMemory = 0x07
}

///
/// Memory Device - Memory Operating Mode Capability
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  ///
  /// Individual bit fields
  ///
  struct {
   [FieldOffset(0)] public ushort Reserved = 1; ///< Set to 0.
  [FieldOffset(0)] public ushort Other = 1;
  [FieldOffset(0)] public ushort Unknown = 1;
  [FieldOffset(0)] public ushort VolatileMemory = 1;
  [FieldOffset(0)] public ushort ByteAccessiblePersistentMemory = 1;
  [FieldOffset(0)] public ushort BlockAccessiblePersistentMemory = 1;
  [FieldOffset(0)] public ushort Reserved2 = 10; ///< Set to 0.
}
///
/// All bit fields as a 16-bit value
///
ushort Uint16;
} MEMORY_DEVICE_OPERATING_MODE_CAPABILITY;

///
/// Memory Device (Type 17).
///
/// This structure describes a single memory device that is part of
/// a larger Physical Memory Array (Type 16).
/// Note:  If a system includes memory-device sockets, the SMBIOS implementation
/// includes a Memory Device structure instance for each slot, whether or not the
/// socket is currently populated.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE17
{
  public SMBIOS_STRUCTURE Hdr;
  public ushort MemoryArrayHandle;
  public ushort MemoryErrorInformationHandle;
  public ushort TotalWidth;
  public ushort DataWidth;
  public ushort Size;
  public byte FormFactor;        ///< The enumeration value from MEMORY_FORM_FACTOR.
  public byte DeviceSet;
  public SMBIOS_TABLE_STRING DeviceLocator;
  public SMBIOS_TABLE_STRING BankLocator;
  public byte MemoryType;        ///< The enumeration value from MEMORY_DEVICE_TYPE.
  public MEMORY_DEVICE_TYPE_DETAIL TypeDetail;
  public ushort Speed;
  public SMBIOS_TABLE_STRING Manufacturer;
  public SMBIOS_TABLE_STRING SerialNumber;
  public SMBIOS_TABLE_STRING AssetTag;
  public SMBIOS_TABLE_STRING PartNumber;
  //
  // Add for smbios 2.6
  //
  public byte Attributes;
  //
  // Add for smbios 2.7
  //
  public uint ExtendedSize;
  //
  // Keep using name "ConfiguredMemoryClockSpeed" for compatibility
  // although this field is renamed from "Configured Memory Clock Speed"
  // to "Configured Memory Speed" in smbios 3.2.0.
  //
  public ushort ConfiguredMemoryClockSpeed;
  //
  // Add for smbios 2.8.0
  //
  public ushort MinimumVoltage;
  public ushort MaximumVoltage;
  public ushort ConfiguredVoltage;
  //
  // Add for smbios 3.2.0
  //
  public byte MemoryTechnology;  ///< The enumeration value from MEMORY_DEVICE_TECHNOLOGY
  public MEMORY_DEVICE_OPERATING_MODE_CAPABILITY MemoryOperatingModeCapability;
  public SMBIOS_TABLE_STRING FirmwareVersion;
  public ushort ModuleManufacturerID;
  public ushort ModuleProductID;
  public ushort MemorySubsystemControllerManufacturerID;
  public ushort MemorySubsystemControllerProductID;
  public ulong NonVolatileSize;
  public ulong VolatileSize;
  public ulong CacheSize;
  public ulong LogicalSize;
  //
  // Add for smbios 3.3.0
  //
  public uint ExtendedSpeed;
  public uint ExtendedConfiguredMemorySpeed;
}

///
/// 32-bit Memory Error Information - Error Type.
///
public enum MEMORY_ERROR_TYPE
{
  MemoryErrorOther = 0x01,
  MemoryErrorUnknown = 0x02,
  MemoryErrorOk = 0x03,
  MemoryErrorBadRead = 0x04,
  MemoryErrorParity = 0x05,
  MemoryErrorSigleBit = 0x06,
  MemoryErrorDoubleBit = 0x07,
  MemoryErrorMultiBit = 0x08,
  MemoryErrorNibble = 0x09,
  MemoryErrorChecksum = 0x0A,
  MemoryErrorCrc = 0x0B,
  MemoryErrorCorrectSingleBit = 0x0C,
  MemoryErrorCorrected = 0x0D,
  MemoryErrorUnCorrectable = 0x0E
}

///
/// 32-bit Memory Error Information - Error Granularity.
///
public enum MEMORY_ERROR_GRANULARITY
{
  MemoryGranularityOther = 0x01,
  MemoryGranularityOtherUnknown = 0x02,
  MemoryGranularityDeviceLevel = 0x03,
  MemoryGranularityMemPartitionLevel = 0x04
}

///
/// 32-bit Memory Error Information - Error Operation.
///
public enum MEMORY_ERROR_OPERATION
{
  MemoryErrorOperationOther = 0x01,
  MemoryErrorOperationUnknown = 0x02,
  MemoryErrorOperationRead = 0x03,
  MemoryErrorOperationWrite = 0x04,
  MemoryErrorOperationPartialWrite = 0x05
}

///
/// 32-bit Memory Error Information (Type 18).
///
/// This structure identifies the specifics of an error that might be detected
/// within a Physical Memory Array.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE18
{
  public SMBIOS_STRUCTURE Hdr;
  public byte ErrorType;                        ///< The enumeration value from MEMORY_ERROR_TYPE.
  public byte ErrorGranularity;                 ///< The enumeration value from MEMORY_ERROR_GRANULARITY.
  public byte ErrorOperation;                   ///< The enumeration value from MEMORY_ERROR_OPERATION.
  public uint VendorSyndrome;
  public uint MemoryArrayErrorAddress;
  public uint DeviceErrorAddress;
  public uint ErrorResolution;
}

///
/// Memory Array Mapped Address (Type 19).
///
/// This structure provides the address mapping for a Physical Memory Array.
/// One structure is present for each contiguous address range described.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE19
{
  public SMBIOS_STRUCTURE Hdr;
  public uint StartingAddress;
  public uint EndingAddress;
  public ushort MemoryArrayHandle;
  public byte PartitionWidth;
  //
  // Add for smbios 2.7
  //
  public ulong ExtendedStartingAddress;
  public ulong ExtendedEndingAddress;
}

///
/// Memory Device Mapped Address (Type 20).
///
/// This structure maps memory address space usually to a device-level granularity.
/// One structure is present for each contiguous address range described.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE20
{
  public SMBIOS_STRUCTURE Hdr;
  public uint StartingAddress;
  public uint EndingAddress;
  public ushort MemoryDeviceHandle;
  public ushort MemoryArrayMappedAddressHandle;
  public byte PartitionRowPosition;
  public byte InterleavePosition;
  public byte InterleavedDataDepth;
  //
  // Add for smbios 2.7
  //
  public ulong ExtendedStartingAddress;
  public ulong ExtendedEndingAddress;
}

///
/// Built-in Pointing Device - Type
///
public enum BUILTIN_POINTING_DEVICE_TYPE
{
  PointingDeviceTypeOther = 0x01,
  PointingDeviceTypeUnknown = 0x02,
  PointingDeviceTypeMouse = 0x03,
  PointingDeviceTypeTrackBall = 0x04,
  PointingDeviceTypeTrackPoint = 0x05,
  PointingDeviceTypeGlidePoint = 0x06,
  PointingDeviceTouchPad = 0x07,
  PointingDeviceTouchScreen = 0x08,
  PointingDeviceOpticalSensor = 0x09
}

///
/// Built-in Pointing Device - Interface.
///
public enum BUILTIN_POINTING_DEVICE_INTERFACE
{
  PointingDeviceInterfaceOther = 0x01,
  PointingDeviceInterfaceUnknown = 0x02,
  PointingDeviceInterfaceSerial = 0x03,
  PointingDeviceInterfacePs2 = 0x04,
  PointingDeviceInterfaceInfrared = 0x05,
  PointingDeviceInterfaceHpHil = 0x06,
  PointingDeviceInterfaceBusMouse = 0x07,
  PointingDeviceInterfaceADB = 0x08,
  PointingDeviceInterfaceBusMouseDB9 = 0xA0,
  PointingDeviceInterfaceBusMouseMicroDin = 0xA1,
  PointingDeviceInterfaceUsb = 0xA2,
  PointingDeviceInterfaceI2c = 0xA3,
  PointingDeviceInterfaceSpi = 0xA4
}

///
/// Built-in Pointing Device (Type 21).
///
/// This structure describes the attributes of the built-in pointing device for the
/// system. The presence of this structure does not imply that the built-in
/// pointing device is active for the system's use!
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE21
{
  public SMBIOS_STRUCTURE Hdr;
  public byte Type;                                 ///< The enumeration value from BUILTIN_POINTING_DEVICE_TYPE.
  public byte Interface;                            ///< The enumeration value from BUILTIN_POINTING_DEVICE_INTERFACE.
  public byte NumberOfButtons;
}

///
/// Portable Battery - Device Chemistry
///
public enum PORTABLE_BATTERY_DEVICE_CHEMISTRY
{
  PortableBatteryDeviceChemistryOther = 0x01,
  PortableBatteryDeviceChemistryUnknown = 0x02,
  PortableBatteryDeviceChemistryLeadAcid = 0x03,
  PortableBatteryDeviceChemistryNickelCadmium = 0x04,
  PortableBatteryDeviceChemistryNickelMetalHydride = 0x05,
  PortableBatteryDeviceChemistryLithiumIon = 0x06,
  PortableBatteryDeviceChemistryZincAir = 0x07,
  PortableBatteryDeviceChemistryLithiumPolymer = 0x08
}

///
/// Portable Battery (Type 22).
///
/// This structure describes the attributes of the portable battery(s) for the system.
/// The structure contains the static attributes for the group.  Each structure describes
/// a single battery pack's attributes.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE22
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Location;
  public SMBIOS_TABLE_STRING Manufacturer;
  public SMBIOS_TABLE_STRING ManufactureDate;
  public SMBIOS_TABLE_STRING SerialNumber;
  public SMBIOS_TABLE_STRING DeviceName;
  public byte DeviceChemistry;                         ///< The enumeration value from PORTABLE_BATTERY_DEVICE_CHEMISTRY.
  public ushort DeviceCapacity;
  public ushort DesignVoltage;
  public SMBIOS_TABLE_STRING SBDSVersionNumber;
  public byte MaximumErrorInBatteryData;
  public ushort SBDSSerialNumber;
  public ushort SBDSManufactureDate;
  public SMBIOS_TABLE_STRING SBDSDeviceChemistry;
  public byte DesignCapacityMultiplier;
  public uint OEMSpecific;
}

///
/// System Reset (Type 23)
///
/// This structure describes whether Automatic System Reset functions enabled (Status).
/// If the system has a watchdog Timer and the timer is not reset (Timer Reset)
/// before the Interval elapses, an automatic system reset will occur. The system will re-boot
/// according to the Boot Option. This function may repeat until the Limit is reached, at which time
/// the system will re-boot according to the Boot Option at Limit.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE23
{
  public SMBIOS_STRUCTURE Hdr;
  public byte Capabilities;
  public ushort ResetCount;
  public ushort ResetLimit;
  public ushort TimerInterval;
  public ushort Timeout;
}

///
/// Hardware Security (Type 24).
///
/// This structure describes the system-wide hardware security settings.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE24
{
  public SMBIOS_STRUCTURE Hdr;
  public byte HardwareSecuritySettings;
}

///
/// System Power Controls (Type 25).
///
/// This structure describes the attributes for controlling the main power supply to the system.
/// Software that interprets this structure uses the month, day, hour, minute, and second values
/// to determine the number of seconds until the next power-on of the system.  The presence of
/// this structure implies that a timed power-on facility is available for the system.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE25
{
  public SMBIOS_STRUCTURE Hdr;
  public byte NextScheduledPowerOnMonth;
  public byte NextScheduledPowerOnDayOfMonth;
  public byte NextScheduledPowerOnHour;
  public byte NextScheduledPowerOnMinute;
  public byte NextScheduledPowerOnSecond;
}

///
/// Voltage Probe - Location and Status.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MISC_VOLTAGE_PROBE_LOCATION
{
  public byte VoltageProbeSite = 5;
  public byte VoltageProbeStatus = 3;
}

///
/// Voltage Probe (Type 26)
///
/// This describes the attributes for a voltage probe in the system.
/// Each structure describes a single voltage probe.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE26
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Description;
  public MISC_VOLTAGE_PROBE_LOCATION LocationAndStatus;
  public ushort MaximumValue;
  public ushort MinimumValue;
  public ushort Resolution;
  public ushort Tolerance;
  public ushort Accuracy;
  public uint OEMDefined;
  public ushort NominalValue;
}

///
/// Cooling Device - Device Type and Status.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MISC_COOLING_DEVICE_TYPE
{
  public byte CoolingDevice = 5;
  public byte CoolingDeviceStatus = 3;
}

///
/// Cooling Device (Type 27)
///
/// This structure describes the attributes for a cooling device in the system.
/// Each structure describes a single cooling device.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE27
{
  public SMBIOS_STRUCTURE Hdr;
  public ushort TemperatureProbeHandle;
  public MISC_COOLING_DEVICE_TYPE DeviceTypeAndStatus;
  public byte CoolingUnitGroup;
  public uint OEMDefined;
  public ushort NominalSpeed;
  //
  // Add for smbios 2.7
  //
  public SMBIOS_TABLE_STRING Description;
}

///
/// Temperature Probe - Location and Status.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MISC_TEMPERATURE_PROBE_LOCATION
{
  public byte TemperatureProbeSite = 5;
  public byte TemperatureProbeStatus = 3;
}

///
/// Temperature Probe (Type 28).
///
/// This structure describes the attributes for a temperature probe in the system.
/// Each structure describes a single temperature probe.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE28
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Description;
  public MISC_TEMPERATURE_PROBE_LOCATION LocationAndStatus;
  public ushort MaximumValue;
  public ushort MinimumValue;
  public ushort Resolution;
  public ushort Tolerance;
  public ushort Accuracy;
  public uint OEMDefined;
  public ushort NominalValue;
}

///
/// Electrical Current Probe - Location and Status.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MISC_ELECTRICAL_CURRENT_PROBE_LOCATION
{
  public byte ElectricalCurrentProbeSite = 5;
  public byte ElectricalCurrentProbeStatus = 3;
}

///
/// Electrical Current Probe (Type 29).
///
/// This structure describes the attributes for an electrical current probe in the system.
/// Each structure describes a single electrical current probe.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE29
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Description;
  public MISC_ELECTRICAL_CURRENT_PROBE_LOCATION LocationAndStatus;
  public ushort MaximumValue;
  public ushort MinimumValue;
  public ushort Resolution;
  public ushort Tolerance;
  public ushort Accuracy;
  public uint OEMDefined;
  public ushort NominalValue;
}

///
/// Out-of-Band Remote Access (Type 30).
///
/// This structure describes the attributes and policy settings of a hardware facility
/// that may be used to gain remote access to a hardware system when the operating system
/// is not available due to power-down status, hardware failures, or boot failures.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE30
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING ManufacturerName;
  public byte Connections;
}

///
/// Boot Integrity Services (BIS) Entry Point (Type 31).
///
/// Structure type 31 (decimal) is reserved for use by the Boot Integrity Services (BIS).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE31
{
  public SMBIOS_STRUCTURE Hdr;
  public byte Checksum;
  public byte Reserved1;
  public ushort Reserved2;
  public uint BisEntry16;
  public uint BisEntry32;
  public ulong Reserved3;
  public uint Reserved4;
}

///
/// System Boot Information - System Boot Status.
///
public enum MISC_BOOT_INFORMATION_STATUS_DATA_TYPE
{
  BootInformationStatusNoError = 0x00,
  BootInformationStatusNoBootableMedia = 0x01,
  BootInformationStatusNormalOSFailedLoading = 0x02,
  BootInformationStatusFirmwareDetectedFailure = 0x03,
  BootInformationStatusOSDetectedFailure = 0x04,
  BootInformationStatusUserRequestedBoot = 0x05,
  BootInformationStatusSystemSecurityViolation = 0x06,
  BootInformationStatusPreviousRequestedImage = 0x07,
  BootInformationStatusWatchdogTimerExpired = 0x08,
  BootInformationStatusStartReserved = 0x09,
  BootInformationStatusStartOemSpecific = 0x80,
  BootInformationStatusStartProductSpecific = 0xC0
}

///
/// System Boot Information (Type 32).
///
/// The client system firmware, e.g. BIOS, communicates the System Boot Status to the
/// client's Pre-boot Execution Environment (PXE) boot image or OS-present management
/// application via this structure. When used in the PXE environment, for example,
/// this code identifies the reason the PXE was initiated and can be used by boot-image
/// software to further automate an enterprise's PXE sessions.  For example, an enterprise
/// could choose to automatically download a hardware-diagnostic image to a client whose
/// reason code indicated either a firmware- or operating system-detected hardware failure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE32
{
  public SMBIOS_STRUCTURE Hdr;
  public fixed byte Reserved[6];
  public byte BootStatus;                         ///< The enumeration value from MISC_BOOT_INFORMATION_STATUS_DATA_TYPE.
}

///
/// 64-bit Memory Error Information (Type 33).
///
/// This structure describes an error within a Physical Memory Array,
/// when the error address is above 4G (0xFFFFFFFF).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE33
{
  public SMBIOS_STRUCTURE Hdr;
  public byte ErrorType;                          ///< The enumeration value from MEMORY_ERROR_TYPE.
  public byte ErrorGranularity;                   ///< The enumeration value from MEMORY_ERROR_GRANULARITY.
  public byte ErrorOperation;                     ///< The enumeration value from MEMORY_ERROR_OPERATION.
  public uint VendorSyndrome;
  public ulong MemoryArrayErrorAddress;
  public ulong DeviceErrorAddress;
  public uint ErrorResolution;
}

///
/// Management Device -  Type.
///
public enum MISC_MANAGEMENT_DEVICE_TYPE
{
  ManagementDeviceTypeOther = 0x01,
  ManagementDeviceTypeUnknown = 0x02,
  ManagementDeviceTypeLm75 = 0x03,
  ManagementDeviceTypeLm78 = 0x04,
  ManagementDeviceTypeLm79 = 0x05,
  ManagementDeviceTypeLm80 = 0x06,
  ManagementDeviceTypeLm81 = 0x07,
  ManagementDeviceTypeAdm9240 = 0x08,
  ManagementDeviceTypeDs1780 = 0x09,
  ManagementDeviceTypeMaxim1617 = 0x0A,
  ManagementDeviceTypeGl518Sm = 0x0B,
  ManagementDeviceTypeW83781D = 0x0C,
  ManagementDeviceTypeHt82H791 = 0x0D
}

///
/// Management Device -  Address Type.
///
public enum MISC_MANAGEMENT_DEVICE_ADDRESS_TYPE
{
  ManagementDeviceAddressTypeOther = 0x01,
  ManagementDeviceAddressTypeUnknown = 0x02,
  ManagementDeviceAddressTypeIOPort = 0x03,
  ManagementDeviceAddressTypeMemory = 0x04,
  ManagementDeviceAddressTypeSmbus = 0x05
}

///
/// Management Device (Type 34).
///
/// The information in this structure defines the attributes of a Management Device.
/// A Management Device might control one or more fans or voltage, current, or temperature
/// probes as defined by one or more Management Device Component structures.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE34
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Description;
  public byte Type;                                    ///< The enumeration value from MISC_MANAGEMENT_DEVICE_TYPE.
  public uint Address;
  public byte AddressType;                             ///< The enumeration value from MISC_MANAGEMENT_DEVICE_ADDRESS_TYPE.
}

///
/// Management Device Component (Type 35)
///
/// This structure associates a cooling device or environmental probe with structures
/// that define the controlling hardware device and (optionally) the component's thresholds.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE35
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING Description;
  public ushort ManagementDeviceHandle;
  public ushort ComponentHandle;
  public ushort ThresholdHandle;
}

///
/// Management Device Threshold Data (Type 36).
///
/// The information in this structure defines threshold information for
/// a component (probe or cooling-unit) contained within a Management Device.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE36
{
  public SMBIOS_STRUCTURE Hdr;
  public ushort LowerThresholdNonCritical;
  public ushort UpperThresholdNonCritical;
  public ushort LowerThresholdCritical;
  public ushort UpperThresholdCritical;
  public ushort LowerThresholdNonRecoverable;
  public ushort UpperThresholdNonRecoverable;
}

///
/// Memory Channel Entry.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEMORY_DEVICE
{
  public byte DeviceLoad;
  public ushort DeviceHandle;
}

///
/// Memory Channel - Channel Type.
///
public enum MEMORY_CHANNEL_TYPE
{
  MemoryChannelTypeOther = 0x01,
  MemoryChannelTypeUnknown = 0x02,
  MemoryChannelTypeRambus = 0x03,
  MemoryChannelTypeSyncLink = 0x04
}

///
/// Memory Channel (Type 37)
///
/// The information in this structure provides the correlation between a Memory Channel
/// and its associated Memory Devices.  Each device presents one or more loads to the channel.
/// The sum of all device loads cannot exceed the channel's defined maximum.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE37
{
  public SMBIOS_STRUCTURE Hdr;
  public byte ChannelType;
  public byte MaximumChannelLoad;
  public byte MemoryDeviceCount;
  public fixed MEMORY_DEVICE MemoryDevice[1];
}

///
/// IPMI Device Information - BMC Interface Type
///
public enum BMC_INTERFACE_TYPE
{
  IPMIDeviceInfoInterfaceTypeUnknown = 0x00,
  IPMIDeviceInfoInterfaceTypeKCS = 0x01,       ///< The Keyboard Controller Style.
  IPMIDeviceInfoInterfaceTypeSMIC = 0x02,       ///< The Server Management Interface Chip.
  IPMIDeviceInfoInterfaceTypeBT = 0x03,       ///< The Block Transfer
  IPMIDeviceInfoInterfaceTypeSSIF = 0x04        ///< SMBus System Interface
}

///
/// IPMI Device Information (Type 38).
///
/// The information in this structure defines the attributes of an
/// Intelligent Platform Management Interface (IPMI) Baseboard Management Controller (BMC).
///
/// The Type 42 structure can also be used to describe a physical management controller
/// host interface and one or more protocols that share that interface. If IPMI is not
/// shared with other protocols, either the Type 38 or Type 42 structures can be used.
/// Providing Type 38 is recommended for backward compatibility.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE38
{
  public SMBIOS_STRUCTURE Hdr;
  public byte InterfaceType;                ///< The enumeration value from BMC_INTERFACE_TYPE.
  public byte IPMISpecificationRevision;
  public byte I2CSlaveAddress;
  public byte NVStorageDeviceAddress;
  public ulong BaseAddress;
  public byte BaseAddressModifier_InterruptInfo;
  public byte InterruptNumber;
}

///
/// System Power Supply - Power Supply Characteristics.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SYS_POWER_SUPPLY_CHARACTERISTICS
{
  public ushort PowerSupplyHotReplaceable = 1;
  public ushort PowerSupplyPresent = 1;
  public ushort PowerSupplyUnplugged = 1;
  public ushort InputVoltageRangeSwitch = 4;
  public ushort PowerSupplyStatus = 3;
  public ushort PowerSupplyType = 4;
  public ushort Reserved = 2;
}

///
/// System Power Supply (Type 39).
///
/// This structure identifies attributes of a system power supply. One instance
/// of this record is present for each possible power supply in a system.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE39
{
  public SMBIOS_STRUCTURE Hdr;
  public byte PowerUnitGroup;
  public SMBIOS_TABLE_STRING Location;
  public SMBIOS_TABLE_STRING DeviceName;
  public SMBIOS_TABLE_STRING Manufacturer;
  public SMBIOS_TABLE_STRING SerialNumber;
  public SMBIOS_TABLE_STRING AssetTagNumber;
  public SMBIOS_TABLE_STRING ModelPartNumber;
  public SMBIOS_TABLE_STRING RevisionLevel;
  public ushort MaxPowerCapacity;
  public SYS_POWER_SUPPLY_CHARACTERISTICS PowerSupplyCharacteristics;
  public ushort InputVoltageProbeHandle;
  public ushort CoolingDeviceHandle;
  public ushort InputCurrentProbeHandle;
}

///
/// Additional Information Entry Format.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ADDITIONAL_INFORMATION_ENTRY
{
  public byte EntryLength;
  public ushort ReferencedHandle;
  public byte ReferencedOffset;
  public SMBIOS_TABLE_STRING EntryString;
  public fixed byte Value[1];
}

///
/// Additional Information (Type 40).
///
/// This structure is intended to provide additional information for handling unspecified
/// enumerated values and interim field updates in another structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE40
{
  public SMBIOS_STRUCTURE Hdr;
  public byte NumberOfAdditionalInformationEntries;
  public fixed ADDITIONAL_INFORMATION_ENTRY AdditionalInfoEntries[1];
}

///
/// Onboard Devices Extended Information - Onboard Device Types.
///
public enum ONBOARD_DEVICE_EXTENDED_INFO_TYPE
{
  OnBoardDeviceExtendedTypeOther = 0x01,
  OnBoardDeviceExtendedTypeUnknown = 0x02,
  OnBoardDeviceExtendedTypeVideo = 0x03,
  OnBoardDeviceExtendedTypeScsiController = 0x04,
  OnBoardDeviceExtendedTypeEthernet = 0x05,
  OnBoardDeviceExtendedTypeTokenRing = 0x06,
  OnBoardDeviceExtendedTypeSound = 0x07,
  OnBoardDeviceExtendedTypePATAController = 0x08,
  OnBoardDeviceExtendedTypeSATAController = 0x09,
  OnBoardDeviceExtendedTypeSASController = 0x0A,
  OnBoardDeviceExtendedTypeWirelessLAN = 0x0B,
  OnBoardDeviceExtendedTypeBluetooth = 0x0C,
  OnBoardDeviceExtendedTypeWWAN = 0x0D,
  OnBoardDeviceExtendedTypeeMMC = 0x0E,
  OnBoardDeviceExtendedTypeNvme = 0x0F,
  OnBoardDeviceExtendedTypeUfc = 0x10
}

///
/// Onboard Devices Extended Information (Type 41).
///
/// The information in this structure defines the attributes of devices that
/// are onboard (soldered onto) a system element, usually the baseboard.
/// In general, an entry in this table implies that the BIOS has some level of
/// control over the enabling of the associated device for use by the system.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE41
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING ReferenceDesignation;
  public byte DeviceType;                        ///< The enumeration value from ONBOARD_DEVICE_EXTENDED_INFO_TYPE
  public byte DeviceTypeInstance;
  public ushort SegmentGroupNum;
  public byte BusNum;
  public byte DevFuncNum;
}

///
///  Management Controller Host Interface - Protocol Record Data Format.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MC_HOST_INTERFACE_PROTOCOL_RECORD
{
  public byte ProtocolType;
  public byte ProtocolTypeDataLen;
  public fixed byte ProtocolTypeData[1];
}

///
/// Management Controller Host Interface - Interface Types.
/// 00h - 3Fh: MCTP Host Interfaces
///
public enum MC_HOST_INTERFACE_TYPE
{
  MCHostInterfaceTypeNetworkHostInterface = 0x40,
  MCHostInterfaceTypeOemDefined = 0xF0
}

///
/// Management Controller Host Interface - Protocol Types.
///
public enum MC_HOST_INTERFACE_PROTOCOL_TYPE
{
  MCHostInterfaceProtocolTypeIPMI = 0x02,
  MCHostInterfaceProtocolTypeMCTP = 0x03,
  MCHostInterfaceProtocolTypeRedfishOverIP = 0x04,
  MCHostInterfaceProtocolTypeOemDefined = 0xF0
}

///
/// Management Controller Host Interface (Type 42).
///
/// The information in this structure defines the attributes of a Management
/// Controller Host Interface that is not discoverable by "Plug and Play" mechanisms.
///
/// Type 42 should be used for management controller host interfaces that use protocols
/// other than IPMI or that use multiple protocols on a single host interface type.
///
/// This structure should also be provided if IPMI is shared with other protocols
/// over the same interface hardware. If IPMI is not shared with other protocols,
/// either the Type 38 or Type 42 structures can be used. Providing Type 38 is
/// recommended for backward compatibility. The structures are not required to
/// be mutually exclusive. Type 38 and Type 42 structures may be implemented
/// simultaneously to provide backward compatibility with IPMI applications or drivers
/// that do not yet recognize the Type 42 structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE42
{
  public SMBIOS_STRUCTURE Hdr;
  public byte InterfaceType;                                ///< The enumeration value from MC_HOST_INTERFACE_TYPE
  public byte InterfaceTypeSpecificDataLength;
  public fixed byte InterfaceTypeSpecificData[4];                 ///< This field has a minimum of four bytes
}

///
/// Processor Specific Block - Processor Architecture Type
///
public enum PROCESSOR_SPECIFIC_BLOCK_ARCH_TYPE
{
  ProcessorSpecificBlockArchTypeReserved = 0x00,
  ProcessorSpecificBlockArchTypeIa32 = 0x01,
  ProcessorSpecificBlockArchTypeX64 = 0x02,
  ProcessorSpecificBlockArchTypeItanium = 0x03,
  ProcessorSpecificBlockArchTypeAarch32 = 0x04,
  ProcessorSpecificBlockArchTypeAarch64 = 0x05,
  ProcessorSpecificBlockArchTypeRiscVRV32 = 0x06,
  ProcessorSpecificBlockArchTypeRiscVRV64 = 0x07,
  ProcessorSpecificBlockArchTypeRiscVRV128 = 0x08,
  ProcessorSpecificBlockArchTypeLoongArch32 = 0x09,
  ProcessorSpecificBlockArchTypeLoongArch64 = 0x0A
}

///
/// Processor Specific Block is the standard container of processor-specific data.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PROCESSOR_SPECIFIC_BLOCK
{
  public byte Length;
  public byte ProcessorArchType;
  ///
  /// Below followed by Processor-specific data
  ///
  ///
}

///
/// Processor Additional Information(Type 44).
///
/// The information in this structure defines the processor additional information in case
/// SMBIOS type 4 is not sufficient to describe processor characteristics.
/// The SMBIOS type 44 structure has a reference handle field to link back to the related
/// SMBIOS type 4 structure. There may be multiple SMBIOS type 44 structures linked to the
/// same SMBIOS type 4 structure. For example, when cores are not identical in a processor,
/// SMBIOS type 44 structures describe different core-specific information.
///
/// SMBIOS type 44 defines the standard header for the processor-specific block, while the
/// contents of processor-specific data are maintained by processor
/// architecture workgroups or vendors in separate documents.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE44
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_HANDLE RefHandle;                       ///< This field refer to associated SMBIOS type 4
                                                        ///
                                                        /// Below followed by Processor-specific block
                                                        ///
  public PROCESSOR_SPECIFIC_BLOCK ProcessorSpecificBlock;
}

///
/// TPM Device (Type 43).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE43
{
  public SMBIOS_STRUCTURE Hdr;
  public fixed byte VendorID[4];
  public byte MajorSpecVersion;
  public byte MinorSpecVersion;
  public uint FirmwareVersion1;
  public uint FirmwareVersion2;
  public SMBIOS_TABLE_STRING Description;
  public ulong Characteristics;
  public uint OemDefined;
}

///
/// Firmware Inventory Version Format Type (Type 45).
///
public enum FIRMWARE_INVENTORY_VERSION_FORMAT_TYPE
{
  VersionFormatTypeFreeForm = 0x00,
  VersionFormatTypeMajorMinor = 0x01,
  VersionFormatType32BitHex = 0x02,
  VersionFormatType64BitHex = 0x03,
  VersionFormatTypeReserved = 0x04,  /// 0x04 - 0x7F are reserved
  VersionFormatTypeOem = 0x80   /// 0x80 - 0xFF are BIOS Vendor/OEM-specific
}

///
/// Firmware Inventory Firmware Id Format Type (Type 45).
///
public enum FIRMWARE_INVENTORY_FIRMWARE_ID_FORMAT_TYPE
{
  FirmwareIdFormatTypeFreeForm = 0x00,
  FirmwareIdFormatTypeUuid = 0x01,
  FirmwareIdFormatTypeReserved = 0x04,  /// 0x04 - 0x7F are reserved
  InventoryFirmwareIdFormatTypeOem = 0x80   /// 0x80 - 0xFF are BIOS Vendor/OEM-specific
}

///
/// Firmware Inventory Firmware Characteristics (Type 45).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct FIRMWARE_CHARACTERISTICS
{
  public ushort Updatable = 1;
  public ushort WriteProtected = 1;
  public ushort Reserved = 14;
}

///
/// Firmware Inventory State Information (Type 45).
///
public enum FIRMWARE_INVENTORY_STATE
{
  FirmwareInventoryStateOther = 0x01,
  FirmwareInventoryStateUnknown = 0x02,
  FirmwareInventoryStateDisabled = 0x03,
  FirmwareInventoryStateEnabled = 0x04,
  FirmwareInventoryStateAbsent = 0x05,
  FirmwareInventoryStateStandbyOffline = 0x06,
  FirmwareInventoryStateStandbySpare = 0x07,
  FirmwareInventoryStateUnavailableOffline = 0x08
}

///
/// Firmware Inventory Information (Type 45)
///
/// The information in this structure defines an inventory of firmware
/// components in the system. This can include firmware components such as
/// BIOS, BMC, as well as firmware for other devices in the system.
/// The information can be used by software to display the firmware inventory
/// in a uniform manner. It can also be used by a management controller,
/// such as a BMC, for remote system management.
/// This structure is not intended to replace other standard programmatic
/// interfaces for firmware updates.
/// One Type 45 structure is provided for each firmware component.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE45
{
  public SMBIOS_STRUCTURE Hdr;
  public SMBIOS_TABLE_STRING FirmwareComponentName;
  public SMBIOS_TABLE_STRING FirmwareVersion;
  public byte FirmwareVersionFormat;    ///< The enumeration value from FIRMWARE_INVENTORY_VERSION_FORMAT_TYPE
  public SMBIOS_TABLE_STRING FirmwareId;
  public byte FirmwareIdFormat;         ///< The enumeration value from FIRMWARE_INVENTORY_FIRMWARE_ID_FORMAT_TYPE.
  public SMBIOS_TABLE_STRING ReleaseDate;
  public SMBIOS_TABLE_STRING Manufacturer;
  public SMBIOS_TABLE_STRING LowestSupportedVersion;
  public ulong ImageSize;
  public FIRMWARE_CHARACTERISTICS Characteristics;
  public byte State;                    ///< The enumeration value from FIRMWARE_INVENTORY_STATE.
  public byte AssociatedComponentCount;
  ///
  /// zero or n-number of handles depends on AssociatedComponentCount
  /// handles are of type SMBIOS_HANDLE
  ///
}

///
/// String Property IDs (Type 46).
///
public enum STRING_PROPERTY_ID
{
  StringPropertyIdNone = 0x0000,
  StringPropertyIdDevicePath = 0x0001,
  StringPropertyIdReserved = 0x0002,  /// Reserved    0x0002 - 0x7FFF
  StringPropertyIdBiosVendor = 0x8000,  /// BIOS vendor 0x8000 - 0xBFFF
  StringPropertyIdOem = 0xC000   /// OEM range   0xC000 - 0xFFFF
}

///
/// This structure defines a string property for another structure.
/// This allows adding string properties that are common to several structures
/// without having to modify the definitions of these structures.
/// Multiple type 46 structures can add string properties to the same
/// parent structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE46
{
  public SMBIOS_STRUCTURE Hdr;
  public ushort StringPropertyId;          ///< The enumeration value from STRING_PROPERTY_ID.
  public SMBIOS_TABLE_STRING StringPropertyValue;
  public SMBIOS_HANDLE ParentHandle;
}

///
/// Inactive (Type 126)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE126
{
  public SMBIOS_STRUCTURE Hdr;
}

///
/// End-of-Table (Type 127)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SMBIOS_TABLE_TYPE127
{
  public SMBIOS_STRUCTURE Hdr;
}

///
/// Union of all the possible SMBIOS record types.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct SMBIOS_STRUCTURE_POINTER
{
  [FieldOffset(0)] public SMBIOS_STRUCTURE* Hdr;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE0* Type0;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE1* Type1;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE2* Type2;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE3* Type3;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE4* Type4;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE5* Type5;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE6* Type6;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE7* Type7;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE8* Type8;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE9* Type9;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE10* Type10;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE11* Type11;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE12* Type12;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE13* Type13;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE14* Type14;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE15* Type15;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE16* Type16;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE17* Type17;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE18* Type18;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE19* Type19;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE20* Type20;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE21* Type21;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE22* Type22;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE23* Type23;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE24* Type24;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE25* Type25;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE26* Type26;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE27* Type27;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE28* Type28;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE29* Type29;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE30* Type30;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE31* Type31;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE32* Type32;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE33* Type33;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE34* Type34;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE35* Type35;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE36* Type36;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE37* Type37;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE38* Type38;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE39* Type39;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE40* Type40;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE41* Type41;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE42* Type42;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE43* Type43;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE44* Type44;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE45* Type45;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE46* Type46;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE126* Type126;
  [FieldOffset(0)] public SMBIOS_TABLE_TYPE127* Type127;
  [FieldOffset(0)] public byte* Raw;
}

// #pragma pack()

// #endif
