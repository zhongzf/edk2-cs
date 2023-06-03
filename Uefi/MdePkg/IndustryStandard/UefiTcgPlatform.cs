using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  TCG EFI Platform Definition in TCG_EFI_Platform_1_20_Final and
  TCG PC Client Platform Firmware Profile Specification, Revision 1.05

  Copyright (c) 2006 - 2019, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __UEFI_TCG_PLATFORM_H__
// #define __UEFI_TCG_PLATFORM_H__

// #include <IndustryStandard/Tpm12.h>
// #include <IndustryStandard/Tpm20.h>
// #include <Uefi.h>

public unsafe partial class EFI
{
  //
  // Standard event types
  //
  public const ulong EV_PREBOOT_CERT = ((TCG_EVENTTYPE)0x00000000);
  public const ulong EV_POST_CODE = ((TCG_EVENTTYPE)0x00000001);
  public const ulong EV_NO_ACTION = ((TCG_EVENTTYPE)0x00000003);
  public const ulong EV_SEPARATOR = ((TCG_EVENTTYPE)0x00000004);
  public const ulong EV_ACTION = ((TCG_EVENTTYPE)0x00000005);
  public const ulong EV_EVENT_TAG = ((TCG_EVENTTYPE)0x00000006);
  public const ulong EV_S_CRTM_CONTENTS = ((TCG_EVENTTYPE)0x00000007);
  public const ulong EV_S_CRTM_VERSION = ((TCG_EVENTTYPE)0x00000008);
  public const ulong EV_CPU_MICROCODE = ((TCG_EVENTTYPE)0x00000009);
  public const ulong EV_PLATFORM_CONFIG_FLAGS = ((TCG_EVENTTYPE)0x0000000A);
  public const ulong EV_TABLE_OF_DEVICES = ((TCG_EVENTTYPE)0x0000000B);
  public const ulong EV_COMPACT_HASH = ((TCG_EVENTTYPE)0x0000000C);
  public const ulong EV_NONHOST_CODE = ((TCG_EVENTTYPE)0x0000000F);
  public const ulong EV_NONHOST_CONFIG = ((TCG_EVENTTYPE)0x00000010);
  public const ulong EV_NONHOST_INFO = ((TCG_EVENTTYPE)0x00000011);
  public const ulong EV_OMIT_BOOT_DEVICE_EVENTS = ((TCG_EVENTTYPE)0x00000012);

  //
  // EFI specific event types
  //
  public const ulong EV_EFI_EVENT_BASE = ((TCG_EVENTTYPE)0x80000000);
  public const ulong EV_EFI_VARIABLE_DRIVER_CONFIG = (EV_EFI_EVENT_BASE + 1);
  public const ulong EV_EFI_VARIABLE_BOOT = (EV_EFI_EVENT_BASE + 2);
  public const ulong EV_EFI_BOOT_SERVICES_APPLICATION = (EV_EFI_EVENT_BASE + 3);
  public const ulong EV_EFI_BOOT_SERVICES_DRIVER = (EV_EFI_EVENT_BASE + 4);
  public const ulong EV_EFI_RUNTIME_SERVICES_DRIVER = (EV_EFI_EVENT_BASE + 5);
  public const ulong EV_EFI_GPT_EVENT = (EV_EFI_EVENT_BASE + 6);
  public const ulong EV_EFI_ACTION = (EV_EFI_EVENT_BASE + 7);
  public const ulong EV_EFI_PLATFORM_FIRMWARE_BLOB = (EV_EFI_EVENT_BASE + 8);
  public const ulong EV_EFI_HANDOFF_TABLES = (EV_EFI_EVENT_BASE + 9);
  public const ulong EV_EFI_PLATFORM_FIRMWARE_BLOB2 = (EV_EFI_EVENT_BASE + 0xA);
  public const ulong EV_EFI_HANDOFF_TABLES2 = (EV_EFI_EVENT_BASE + 0xB);
  public const ulong EV_EFI_HCRTM_EVENT = (EV_EFI_EVENT_BASE + 0x10);
  public const ulong EV_EFI_VARIABLE_AUTHORITY = (EV_EFI_EVENT_BASE + 0xE0);
  public const ulong EV_EFI_SPDM_FIRMWARE_BLOB = (EV_EFI_EVENT_BASE + 0xE1);
  public const ulong EV_EFI_SPDM_FIRMWARE_CONFIG = (EV_EFI_EVENT_BASE + 0xE2);

  //#define EFI_CALLING_EFI_APPLICATION         \
  //  "Calling EFI Application from Boot Option"
  //#define EFI_RETURNING_FROM_EFI_APPLICATION  \
  //  "Returning from EFI Application from Boot Option"
  //#define EFI_EXIT_BOOT_SERVICES_INVOCATION   \
  //  "Exit Boot Services Invocation"
  //#define EFI_EXIT_BOOT_SERVICES_FAILED       \
  //  "Exit Boot Services Returned with Failure"
  //#define EFI_EXIT_BOOT_SERVICES_SUCCEEDED    \
  //  "Exit Boot Services Returned with Success"

  public const ulong EV_POSTCODE_INFO_POST_CODE = "POST CODE";
  public const ulong POST_CODE_STR_LEN = (sizeof(EV_POSTCODE_INFO_POST_CODE) - 1);

  public const ulong EV_POSTCODE_INFO_SMM_CODE = "SMM CODE";
  public const ulong SMM_CODE_STR_LEN = (sizeof(EV_POSTCODE_INFO_SMM_CODE) - 1);

  public const ulong EV_POSTCODE_INFO_ACPI_DATA = "ACPI DATA";
  public const ulong ACPI_DATA_LEN = (sizeof(EV_POSTCODE_INFO_ACPI_DATA) - 1);

  public const ulong EV_POSTCODE_INFO_BIS_CODE = "BIS CODE";
  public const ulong BIS_CODE_LEN = (sizeof(EV_POSTCODE_INFO_BIS_CODE) - 1);

  public const ulong EV_POSTCODE_INFO_UEFI_PI = "UEFI PI";
  public const ulong UEFI_PI_LEN = (sizeof(EV_POSTCODE_INFO_UEFI_PI) - 1);

  public const ulong EV_POSTCODE_INFO_OPROM = "Embedded Option ROM";
  public const ulong OPROM_LEN = (sizeof(EV_POSTCODE_INFO_OPROM) - 1);

  public const ulong EV_POSTCODE_INFO_EMBEDDED_UEFI_DRIVER = "Embedded UEFI Driver";
  public const ulong EMBEDDED_UEFI_DRIVER_LEN = (sizeof(EV_POSTCODE_INFO_EMBEDDED_UEFI_DRIVER) - 1);

  public const ulong FIRMWARE_DEBUGGER_EVENT_STRING = "UEFI Debug Mode";
  public const ulong FIRMWARE_DEBUGGER_EVENT_STRING_LEN = (sizeof(FIRMWARE_DEBUGGER_EVENT_STRING) - 1);

  //
  // Set structure alignment to 1-byte
  //
  // #pragma pack (1)
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_EVENTTYPE { uint Value; public static implicit operator TCG_EVENTTYPE(uint value) => new TCG_EVENTTYPE() { Value = value }; public static implicit operator uint(TCG_EVENTTYPE value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_PCRINDEX { TPM_PCRINDEX Value; public static implicit operator TCG_PCRINDEX(TPM_PCRINDEX value) => new TCG_PCRINDEX() { Value = value }; public static implicit operator TPM_PCRINDEX(TCG_PCRINDEX value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_DIGEST { TPM_DIGEST Value; public static implicit operator TCG_DIGEST(TPM_DIGEST value) => new TCG_DIGEST() { Value = value }; public static implicit operator TPM_DIGEST(TCG_DIGEST value) => value.Value; }
///
/// Event Log Entry Structure Definition
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_PCR_EVENT
{
  public TCG_PCRINDEX PCRIndex;                   ///< PCRIndex event extended to
  public TCG_EVENTTYPE EventType;                  ///< TCG EFI event type
  public TCG_DIGEST Digest;                     ///< Value extended into PCRIndex
  public uint EventSize;                  ///< Size of the event data
  public fixed byte Event[1];                   ///< The event data
}

public unsafe partial class EFI
{
  public const ulong TSS_EVENT_DATA_MAX_SIZE = 256;
}

///
/// TCG_PCR_EVENT_HDR
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_PCR_EVENT_HDR
{
  public TCG_PCRINDEX PCRIndex;
  public TCG_EVENTTYPE EventType;
  public TCG_DIGEST Digest;
  public uint EventSize;
}

///
/// EFI_PLATFORM_FIRMWARE_BLOB
///
/// BlobLength should be of type ulong but we use ulong here
/// because PEI is 32-bit while DXE is 64-bit on x64 platforms
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PLATFORM_FIRMWARE_BLOB
{
  public EFI_PHYSICAL_ADDRESS BlobBase;
  public ulong BlobLength;
}

///
/// UEFI_PLATFORM_FIRMWARE_BLOB
///
/// This structure is used in EV_EFI_PLATFORM_FIRMWARE_BLOB
/// event to facilitate the measurement of firmware volume.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct UEFI_PLATFORM_FIRMWARE_BLOB
{
  public EFI_PHYSICAL_ADDRESS BlobBase;
  public ulong BlobLength;
}

///
/// UEFI_PLATFORM_FIRMWARE_BLOB2
///
/// This structure is used in EV_EFI_PLATFORM_FIRMWARE_BLOB2
/// event to facilitate the measurement of firmware volume.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct UEFI_PLATFORM_FIRMWARE_BLOB2
{
  public byte BlobDescriptionSize;
  // byte                             BlobDescription[BlobDescriptionSize];
  // EFI_PHYSICAL_ADDRESS              BlobBase;
  // ulong                            BlobLength;
}

///
/// EFI_IMAGE_LOAD_EVENT
///
/// This structure is used in EV_EFI_BOOT_SERVICES_APPLICATION,
/// EV_EFI_BOOT_SERVICES_DRIVER and EV_EFI_RUNTIME_SERVICES_DRIVER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_LOAD_EVENT
{
  public EFI_PHYSICAL_ADDRESS ImageLocationInMemory;
  public ulong ImageLengthInMemory;
  public ulong ImageLinkTimeAddress;
  public ulong LengthOfDevicePath;
  public fixed EFI_DEVICE_PATH_PROTOCOL DevicePath[1];
}

///
/// UEFI_IMAGE_LOAD_EVENT
///
/// This structure is used in EV_EFI_BOOT_SERVICES_APPLICATION,
/// EV_EFI_BOOT_SERVICES_DRIVER and EV_EFI_RUNTIME_SERVICES_DRIVER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct UEFI_IMAGE_LOAD_EVENT
{
  public EFI_PHYSICAL_ADDRESS ImageLocationInMemory;
  public ulong ImageLengthInMemory;
  public ulong ImageLinkTimeAddress;
  public ulong LengthOfDevicePath;
  public fixed EFI_DEVICE_PATH_PROTOCOL DevicePath[1];
}

///
/// EFI_HANDOFF_TABLE_POINTERS
///
/// This structure is used in EV_EFI_HANDOFF_TABLES event to facilitate
/// the measurement of given configuration tables.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HANDOFF_TABLE_POINTERS
{
  public ulong NumberOfTables;
  public fixed EFI_CONFIGURATION_TABLE TableEntry[1];
}

///
/// UEFI_HANDOFF_TABLE_POINTERS
///
/// This structure is used in EV_EFI_HANDOFF_TABLES event to facilitate
/// the measurement of given configuration tables.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct UEFI_HANDOFF_TABLE_POINTERS
{
  public ulong NumberOfTables;
  public fixed EFI_CONFIGURATION_TABLE TableEntry[1];
}

///
/// UEFI_HANDOFF_TABLE_POINTERS2
///
/// This structure is used in EV_EFI_HANDOFF_TABLES2 event to facilitate
/// the measurement of given configuration tables.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct UEFI_HANDOFF_TABLE_POINTERS2
{
  public byte TableDescriptionSize;
  // byte                             TableDescription[TableDescriptionSize];
  // ulong                            NumberOfTables;
  // EFI_CONFIGURATION_TABLE           TableEntry[1];
}

///
/// EFI_VARIABLE_DATA
///
/// This structure serves as the header for measuring variables. The name of the
/// variable (in Unicode format) should immediately follow, then the variable
/// data.
/// This is defined in TCG EFI Platform Spec for TPM1.1 or 1.2 V1.22
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_VARIABLE_DATA
{
  public EFI_GUID VariableName;
  public ulong UnicodeNameLength;
  public ulong VariableDataLength;
  public fixed char UnicodeName[1];
  public fixed sbyte VariableData[1];                        ///< Driver or platform-specific data
}

///
/// UEFI_VARIABLE_DATA
///
/// This structure serves as the header for measuring variables. The name of the
/// variable (in Unicode format) should immediately follow, then the variable
/// data.
/// This is defined in TCG PC Client Firmware Profile Spec 00.21
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct UEFI_VARIABLE_DATA
{
  public EFI_GUID VariableName;
  public ulong UnicodeNameLength;
  public ulong VariableDataLength;
  public fixed char UnicodeName[1];
  public fixed sbyte VariableData[1];                        ///< Driver or platform-specific data
}

//
// For TrEE1.0 compatibility
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_VARIABLE_DATA_TREE
{
  public EFI_GUID VariableName;
  public ulong UnicodeNameLength;                         // The TCG Definition used UINTN
  public ulong VariableDataLength;                        // The TCG Definition used UINTN
  public fixed char UnicodeName[1];
  public fixed sbyte VariableData[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_GPT_DATA
{
  public EFI_PARTITION_TABLE_HEADER EfiPartitionHeader;
  public ulong NumberOfPartitions;
  public fixed EFI_PARTITION_ENTRY Partitions[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UEFI_GPT_DATA
{
  public EFI_PARTITION_TABLE_HEADER EfiPartitionHeader;
  public ulong NumberOfPartitions;
  public fixed EFI_PARTITION_ENTRY Partitions[1];
}

public unsafe partial class EFI
{
  public const ulong TCG_DEVICE_SECURITY_EVENT_DATA_SIGNATURE = "SPDM Device Sec";
  public const ulong TCG_DEVICE_SECURITY_EVENT_DATA_VERSION = 1;

  public const ulong TCG_DEVICE_SECURITY_EVENT_DATA_DEVICE_TYPE_NULL = 0;
  public const ulong TCG_DEVICE_SECURITY_EVENT_DATA_DEVICE_TYPE_PCI = 1;
  public const ulong TCG_DEVICE_SECURITY_EVENT_DATA_DEVICE_TYPE_USB = 2;
}

///
/// TCG_DEVICE_SECURITY_EVENT_DATA_HEADER
/// This is the header of TCG_DEVICE_SECURITY_EVENT_DATA, which is
/// used in EV_EFI_SPDM_FIRMWARE_BLOB and EV_EFI_SPDM_FIRMWARE_CONFIG.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_DEVICE_SECURITY_EVENT_DATA_HEADER
{
  public fixed byte Signature[16];
  public ushort Version;
  public ushort Length;
  public uint SpdmHashAlgo;
  public uint DeviceType;
  // SPDM_MEASUREMENT_BLOCK         SpdmMeasurementBlock;
}

public unsafe partial class EFI
{
  public const ulong TCG_DEVICE_SECURITY_EVENT_DATA_PCI_CONTEXT_VERSION = 0;
}

///
/// TCG_DEVICE_SECURITY_EVENT_DATA_PCI_CONTEXT
/// This is the PCI context data of TCG_DEVICE_SECURITY_EVENT_DATA, which is
/// used in EV_EFI_SPDM_FIRMWARE_BLOB and EV_EFI_SPDM_FIRMWARE_CONFIG.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_DEVICE_SECURITY_EVENT_DATA_PCI_CONTEXT
{
  public ushort Version;
  public ushort Length;
  public ushort VendorId;
  public ushort DeviceId;
  public byte RevisionID;
  public fixed byte ClassCode[3];
  public ushort SubsystemVendorID;
  public ushort SubsystemID;
}

public unsafe partial class EFI
{
  public const ulong TCG_DEVICE_SECURITY_EVENT_DATA_USB_CONTEXT_VERSION = 0;
}

///
/// TCG_DEVICE_SECURITY_EVENT_DATA_USB_CONTEXT
/// This is the USB context data of TCG_DEVICE_SECURITY_EVENT_DATA, which is
/// used in EV_EFI_SPDM_FIRMWARE_BLOB and EV_EFI_SPDM_FIRMWARE_CONFIG.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_DEVICE_SECURITY_EVENT_DATA_USB_CONTEXT
{
  public ushort Version;
  public ushort Length;
  // byte   DeviceDescriptor[DescLen];
  // byte   BodDescriptor[DescLen];
  // byte   ConfigurationDescriptor[DescLen][NumOfConfiguration];
}

//
// Crypto Agile Log Entry Format
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_PCR_EVENT2
{
  public TCG_PCRINDEX PCRIndex;
  public TCG_EVENTTYPE EventType;
  public TPML_DIGEST_VALUES Digest;
  public uint EventSize;
  public fixed byte Event[1];
}

//
// TCG PCR Event2 Header
// Follow TCG EFI Protocol Spec 5.2 Crypto Agile Log Entry Format
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_PCR_EVENT2_HDR
{
  public TCG_PCRINDEX PCRIndex;
  public TCG_EVENTTYPE EventType;
  public TPML_DIGEST_VALUES Digests;
  public uint EventSize;
}

//
// Log Header Entry Data
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_EfiSpecIdEventAlgorithmSize
{
  //
  // TCG defined hashing algorithm ID.
  //
  public ushort algorithmId;
  //
  // The size of the digest for the respective hashing algorithm.
  //
  public ushort digestSize;
}

public unsafe partial class EFI
{
  public const ulong TCG_EfiSpecIDEventStruct_SIGNATURE_02 = "Spec ID Event02";
  public const ulong TCG_EfiSpecIDEventStruct_SIGNATURE_03 = "Spec ID Event03";

  public const ulong TCG_EfiSpecIDEventStruct_SPEC_VERSION_MAJOR_TPM12 = 1;
  public const ulong TCG_EfiSpecIDEventStruct_SPEC_VERSION_MINOR_TPM12 = 2;
  public const ulong TCG_EfiSpecIDEventStruct_SPEC_ERRATA_TPM12 = 2;

  public const ulong TCG_EfiSpecIDEventStruct_SPEC_VERSION_MAJOR_TPM2 = 2;
  public const ulong TCG_EfiSpecIDEventStruct_SPEC_VERSION_MINOR_TPM2 = 0;
  public const ulong TCG_EfiSpecIDEventStruct_SPEC_ERRATA_TPM2 = 0;
  public const ulong TCG_EfiSpecIDEventStruct_SPEC_ERRATA_TPM2_REV_105 = 105;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_EfiSpecIDEventStruct
{
  public fixed byte signature[16];
  //
  // The value for the Platform Class.
  // The enumeration is defined in the TCG ACPI Specification Client Common Header.
  //
  public uint platformClass;
  //
  // The TCG EFI Platform Specification minor version number this BIOS supports.
  // Any BIOS supporting version (1.22) MUST set this value to 02h.
  // Any BIOS supporting version (2.0) SHALL set this value to 0x00.
  //
  public byte specVersionMinor;
  //
  // The TCG EFI Platform Specification major version number this BIOS supports.
  // Any BIOS supporting version (1.22) MUST set this value to 01h.
  // Any BIOS supporting version (2.0) SHALL set this value to 0x02.
  //
  public byte specVersionMajor;
  //
  // The TCG EFI Platform Specification errata for this specification this BIOS supports.
  // Any BIOS supporting version and errata (1.22) MUST set this value to 02h.
  // Any BIOS supporting version and errata (2.0) SHALL set this value to 0x00.
  //
  public byte specErrata;
  //
  // Specifies the size of the ulong fields used in various data structures used in this specification.
  // 0x01 indicates uint and 0x02 indicates UINT64.
  //
  public byte uintnSize;
  //
  // This field is added in "Spec ID Event03".
  // The number of hashing algorithms used in this event log (except the first event).
  // All events in this event log use all hashing algorithms defined here.
  //
  // uint              numberOfAlgorithms;
  //
  // This field is added in "Spec ID Event03".
  // An array of size numberOfAlgorithms of value pairs.
  //
  // TCG_EfiSpecIdEventAlgorithmSize digestSize[numberOfAlgorithms];
  //
  // Size in bytes of the VendorInfo field.
  // Maximum value SHALL be FFh bytes.
  //
  // byte               vendorInfoSize;
  //
  // Provided for use by the BIOS implementer.
  // The value might be used, for example, to provide more detailed information about the specific BIOS such as BIOS revision numbers, etc.
  // The values within this field are not standardized and are implementer-specific.
  // Platform-specific or -unique information SHALL NOT be provided in this field.
  //
  // byte               vendorInfo[vendorInfoSize];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_PCClientTaggedEvent
{
  public uint taggedEventID;
  public uint taggedEventDataSize;
  // byte               taggedEventData[taggedEventDataSize];
}

public unsafe partial class EFI
{
  public const ulong TCG_Sp800_155_PlatformId_Event_SIGNATURE = "SP800-155 Event";
  public const ulong TCG_Sp800_155_PlatformId_Event2_SIGNATURE = "SP800-155 Event2";
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_Sp800_155_PlatformId_Event2
{
  public fixed byte Signature[16];
  //
  // Where Vendor ID is an integer defined
  // at http://www.iana.org/assignments/enterprisenumbers
  //
  public uint VendorId;
  //
  // 16-byte identifier of a given platform's static configuration of code
  //
  public EFI_GUID ReferenceManifestGuid;
  //
  // Below structure is newly added in TCG_Sp800_155_PlatformId_Event2.
  //
  // byte               PlatformManufacturerStrSize;
  // byte               PlatformManufacturerStr[PlatformManufacturerStrSize];
  // byte               PlatformModelSize;
  // byte               PlatformModel[PlatformModelSize];
  // byte               PlatformVersionSize;
  // byte               PlatformVersion[PlatformVersionSize];
  // byte               PlatformModelSize;
  // byte               PlatformModel[PlatformModelSize];
  // byte               FirmwareManufacturerStrSize;
  // byte               FirmwareManufacturerStr[FirmwareManufacturerStrSize];
  // uint              FirmwareManufacturerId;
  // byte               FirmwareVersion;
  // byte               FirmwareVersion[FirmwareVersionSize]];
}

public unsafe partial class EFI
{
  public const ulong TCG_EfiStartupLocalityEvent_SIGNATURE = "StartupLocality";

  //
  // The Locality Indicator which sent the TPM2_Startup command
  //
  public const ulong LOCALITY_0_INDICATOR = 0x00;
  public const ulong LOCALITY_3_INDICATOR = 0x03;
}

//
// Startup Locality Event
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_EfiStartupLocalityEvent
{
  public fixed byte Signature[16];
  //
  // The Locality Indicator which sent the TPM2_Startup command
  //
  public byte StartupLocality;
}

//
// Restore original structure alignment
//
// #pragma pack ()

// #endif
