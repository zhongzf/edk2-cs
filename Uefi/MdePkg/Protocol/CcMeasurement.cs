using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  If CC Guest firmware supports measurement and an event is created,
  CC Guest firmware is designed to report the event log with the same
  data structure in TCG-Platform-Firmware-Profile specification with
  EFI_TCG2_EVENT_LOG_FORMAT_TCG_2 format.

  The CC Guest firmware supports measurement, the CC Guest Firmware is
  designed to produce EFI_CC_MEASUREMENT_PROTOCOL with new GUID
  EFI_CC_MEASUREMENT_PROTOCOL_GUID to report event log and provides hash
  capability.

Copyright (c) 2020 - 2021, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef CC_MEASUREMENT_PROTOCOL_H_
// #define CC_MEASUREMENT_PROTOCOL_H_

// #include <IndustryStandard/UefiTcgPlatform.h>

public static EFI_GUID EFI_CC_MEASUREMENT_PROTOCOL_GUID = new GUID(0x96751a3d, 0x72f4, 0x41a6, new byte[] { 0xa7, 0x94, 0xed, 0x5d, 0x0e, 0x67, 0xae, 0x6b });
// extern EFI_GUID  gEfiCcMeasurementProtocolGuid;

// typedef struct _EFI_CC_MEASUREMENT_PROTOCOL EFI_CC_MEASUREMENT_PROTOCOL;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_VERSION
{
  public byte Major;
  public byte Minor;
}

//
// EFI_CC Type/SubType definition
//
public const ulong EFI_CC_TYPE_NONE = 0;
public const ulong EFI_CC_TYPE_SEV = 1;
public const ulong EFI_CC_TYPE_TDX = 2;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_TYPE
{
  public byte Type;
  public byte SubType;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_EVENT_LOG_BITMAP { uint Value; public static implicit operator EFI_CC_EVENT_LOG_BITMAP(uint value) => new EFI_CC_EVENT_LOG_BITMAP() { Value = value }; public static implicit operator uint(EFI_CC_EVENT_LOG_BITMAP value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_EVENT_LOG_FORMAT { uint Value; public static implicit operator EFI_CC_EVENT_LOG_FORMAT(uint value) => new EFI_CC_EVENT_LOG_FORMAT() { Value = value }; public static implicit operator uint(EFI_CC_EVENT_LOG_FORMAT value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_EVENT_ALGORITHM_BITMAP { uint Value; public static implicit operator EFI_CC_EVENT_ALGORITHM_BITMAP(uint value) => new EFI_CC_EVENT_ALGORITHM_BITMAP() { Value = value }; public static implicit operator uint(EFI_CC_EVENT_ALGORITHM_BITMAP value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_MR_INDEX { uint Value; public static implicit operator EFI_CC_MR_INDEX(uint value) => new EFI_CC_MR_INDEX() { Value = value }; public static implicit operator uint(EFI_CC_MR_INDEX value) => value.Value; }

//
// Intel TDX measure register index
//
public const ulong TDX_MR_INDEX_MRTD = 0;
public const ulong TDX_MR_INDEX_RTMR0 = 1;
public const ulong TDX_MR_INDEX_RTMR1 = 2;
public const ulong TDX_MR_INDEX_RTMR2 = 3;
public const ulong TDX_MR_INDEX_RTMR3 = 4;

public const ulong EFI_CC_EVENT_LOG_FORMAT_TCG_2 = 0x00000002;
public const ulong EFI_CC_BOOT_HASH_ALG_SHA384 = 0x00000004;

//
// This bit is shall be set when an event shall be extended but not logged.
//
public const ulong EFI_CC_FLAG_EXTEND_ONLY = 0x0000000000000001;
//
// This bit shall be set when the intent is to measure a PE/COFF image.
//
public const ulong EFI_CC_FLAG_PE_COFF_IMAGE = 0x0000000000000010;

// #pragma pack (1)

public const ulong EFI_CC_EVENT_HEADER_VERSION = 1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_EVENT_HEADER
{
  //
  // Size of the event header itself (sizeof(EFI_CC_EVENT_HEADER)).
  //
  public uint HeaderSize;
  //
  // Header version. For this version of this specification, the value shall be 1.
  //
  public ushort HeaderVersion;
  //
  // Index of the MR (measurement register) that shall be extended.
  //
  public EFI_CC_MR_INDEX MrIndex;
  //
  // Type of the event that shall be extended (and optionally logged).
  //
  public uint EventType;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_EVENT
{
  //
  // Total size of the event including the Size component, the header and the Event data.
  //
  public uint Size;
  public EFI_CC_EVENT_HEADER Header;
  public fixed byte Event[1];
}

// #pragma pack()

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_BOOT_SERVICE_CAPABILITY
{
  //
  // Allocated size of the structure
  //
  public byte Size;
  //
  // Version of the EFI_CC_BOOT_SERVICE_CAPABILITY structure itself.
  // For this version of the protocol, the Major version shall be set to 1
  // and the Minor version shall be set to 0.
  //
  public EFI_CC_VERSION StructureVersion;
  //
  // Version of the EFI CC Measurement protocol.
  // For this version of the protocol, the Major version shall be set to 1
  // and the Minor version shall be set to 0.
  //
  public EFI_CC_VERSION ProtocolVersion;
  //
  // Supported hash algorithms
  //
  public EFI_CC_EVENT_ALGORITHM_BITMAP HashAlgorithmBitmap;
  //
  // Bitmap of supported event log formats
  //
  public EFI_CC_EVENT_LOG_BITMAP SupportedEventLogs;

  //
  // Indicates the CC type
  //
  public EFI_CC_TYPE CcType;
}






































































































[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_MEASUREMENT_PROTOCOL
{
  /**
    The EFI_CC_MEASUREMENT_PROTOCOL GetCapability function call provides protocol
    capability information and state information.

    @param[in]      This               Indicates the calling context
    @param[in, out] ProtocolCapability The caller allocates memory for a EFI_CC_BOOT_SERVICE_CAPABILITY
                                       structure and sets the size field to the size of the structure allocated.
                                       The callee fills in the fields with the EFI CC BOOT Service capability
                                       information and the current CC information.

    @retval EFI_SUCCESS            Operation completed successfully.
    @retval EFI_DEVICE_ERROR       The command was unsuccessful.
                                   The ProtocolCapability variable will not be populated.
    @retval EFI_INVALID_PARAMETER  One or more of the parameters are incorrect.
                                   The ProtocolCapability variable will not be populated.
    @retval EFI_BUFFER_TOO_SMALL   The ProtocolCapability variable is too small to hold the full response.
                                   It will be partially populated (required Size field will be set).
  **/
  public readonly delegate* unmanaged<EFI_CC_MEASUREMENT_PROTOCOL*, EFI_CC_BOOT_SERVICE_CAPABILITY*, EFI_STATUS> GetCapability;
  /**
    The EFI_CC_MEASUREMENT_PROTOCOL Get Event Log function call allows a caller to
    retrieve the address of a given event log and its last entry.

    @param[in]  This               Indicates the calling context
    @param[in]  EventLogFormat     The type of the event log for which the information is requested.
    @param[out] EventLogLocation   A pointer to the memory address of the event log.
    @param[out] EventLogLastEntry  If the Event Log contains more than one entry, this is a pointer to the
                                   address of the start of the last entry in the event log in memory.
    @param[out] EventLogTruncated  If the Event Log is missing at least one entry because an event would
                                   have exceeded the area allocated for events, this value is set to TRUE.
                                   Otherwise, the value will be FALSE and the Event Log will be complete.

    @retval EFI_SUCCESS            Operation completed successfully.
    @retval EFI_INVALID_PARAMETER  One or more of the parameters are incorrect
                                   (e.g. asking for an event log whose format is not supported).
  **/
  public readonly delegate* unmanaged<EFI_CC_MEASUREMENT_PROTOCOL*, EFI_CC_EVENT_LOG_FORMAT, EFI_PHYSICAL_ADDRESS*, EFI_PHYSICAL_ADDRESS*, bool*, EFI_STATUS> GetEventLog;
  /**
    The EFI_CC_MEASUREMENT_PROTOCOL HashLogExtendEvent function call provides
    callers with an opportunity to extend and optionally log events without requiring
    knowledge of actual CC commands.
    The extend operation will occur even if this function cannot create an event
    log entry (e.g. due to the event log being full).

    @param[in]  This               Indicates the calling context
    @param[in]  Flags              Bitmap providing additional information.
    @param[in]  DataToHash         Physical address of the start of the data buffer to be hashed.
    @param[in]  DataToHashLen      The length in bytes of the buffer referenced by DataToHash.
    @param[in]  EfiCcEvent        Pointer to data buffer containing information about the event.

    @retval EFI_SUCCESS            Operation completed successfully.
    @retval EFI_DEVICE_ERROR       The command was unsuccessful.
    @retval EFI_VOLUME_FULL        The extend operation occurred, but the event could not be written to one or more event logs.
    @retval EFI_INVALID_PARAMETER  One or more of the parameters are incorrect.
    @retval EFI_UNSUPPORTED        The PE/COFF image type is not supported.
  **/
  public readonly delegate* unmanaged<EFI_CC_MEASUREMENT_PROTOCOL*, ulong, EFI_PHYSICAL_ADDRESS, ulong, EFI_CC_EVENT*, EFI_STATUS> HashLogExtendEvent;
  /**
    The EFI_CC_MEASUREMENT_PROTOCOL MapPcrToMrIndex function call provides callers
    the info on TPM PCR <-> CC MR mapping information.

    @param[in]  This               Indicates the calling context
    @param[in]  PcrIndex           TPM PCR index.
    @param[out] MrIndex            CC MR index.

    @retval EFI_SUCCESS            The MrIndex is returned.
    @retval EFI_INVALID_PARAMETER  The MrIndex is NULL.
    @retval EFI_UNSUPPORTED        The PcrIndex is invalid.
  **/
  public readonly delegate* unmanaged<EFI_CC_MEASUREMENT_PROTOCOL*, TCG_PCRINDEX, EFI_CC_MR_INDEX*, EFI_STATUS> MapPcrToMrIndex;
}

//
// CC event log
//

// #pragma pack(1)

//
// Crypto Agile Log Entry Format.
// It is similar with TCG_PCR_EVENT2 except the field of MrIndex and PCRIndex.
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CC_EVENT
{
  public EFI_CC_MR_INDEX MrIndex;
  public uint EventType;
  TPML_DIGEST_VALUES Digests;
  public uint EventSize;
  public fixed byte Event[1];
}

//
// EFI CC Event Header
// It is similar with TCG_PCR_EVENT2_HDR except the field of MrIndex and PCRIndex
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CC_EVENT_HDR
{
  public EFI_CC_MR_INDEX MrIndex;
  public uint EventType;
  TPML_DIGEST_VALUES Digests;
  public uint EventSize;
}

// #pragma pack()

//
// Log entries after Get Event Log service
//

public const ulong EFI_CC_FINAL_EVENTS_TABLE_VERSION = 1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_FINAL_EVENTS_TABLE
{
  //
  // The version of this structure. It shall be set to 1.
  //
  public ulong Version;
  //
  // Number of events recorded after invocation of GetEventLog API
  //
  public ulong NumberOfEvents;
  //
  // List of events of type CC_EVENT.
  //
  // CC_EVENT              Event[1];
}

public static EFI_GUID EFI_CC_FINAL_EVENTS_TABLE_GUID = new GUID(0xdd4a4648, 0x2de7, 0x4665, new byte[] { 0x96, 0x4d, 0x21, 0xd9, 0xef, 0x5f, 0xb4, 0x46 });

// extern EFI_GUID  gEfiCcFinalEventsTableGuid;

//
// Define the CC Measure EventLog ACPI Table
//
// #pragma pack(1)

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CC_EVENTLOG_ACPI_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  public EFI_CC_TYPE CcType;
  public ushort Rsvd;
  public ulong Laml;
  public ulong Lasa;
}

// #pragma pack()

//
// Define the signature and revision of CC Measurement EventLog ACPI Table
//
public const ulong EFI_CC_EVENTLOG_ACPI_TABLE_SIGNATURE = SIGNATURE_32('C', 'C', 'E', 'L');
public const ulong EFI_CC_EVENTLOG_ACPI_TABLE_REVISION = 1;

// #endif
