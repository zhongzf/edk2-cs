using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This protocol is defined to abstract TPM2 hardware access in boot phase.

Copyright (c) 2013 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __TREE_H__
// #define __TREE_H__

// #include <IndustryStandard/UefiTcgPlatform.h>
// #include <IndustryStandard/Tpm20.h>

#define EFI_TREE_PROTOCOL_GUID \
  {0x607f766c, 0x7455, 0x42be, 0x93, 0x0b, 0xe4, 0xd7, 0x6d, 0xb2, 0x72, 0x0f}

// typedef struct _EFI_TREE_PROTOCOL EFI_TREE_PROTOCOL;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TREE_VERSION
{
  public byte Major;
  public byte Minor;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TREE_EVENT_LOG_BITMAP { uint Value; public static implicit operator TREE_EVENT_LOG_BITMAP(uint value) => new TREE_EVENT_LOG_BITMAP() { Value = value }; public static implicit operator uint(TREE_EVENT_LOG_BITMAP value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TREE_EVENT_LOG_FORMAT { uint Value; public static implicit operator TREE_EVENT_LOG_FORMAT(uint value) => new TREE_EVENT_LOG_FORMAT() { Value = value }; public static implicit operator uint(TREE_EVENT_LOG_FORMAT value) => value.Value; }

public const ulong TREE_EVENT_LOG_FORMAT_TCG_1_2 = 0x00000001;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TREE_BOOT_SERVICE_CAPABILITY_1_0
{
  //
  // Allocated size of the structure passed in
  //
  public byte Size;
  //
  // Version of the TREE_BOOT_SERVICE_CAPABILITY structure itself.
  // For this version of the protocol, the Major version shall be set to 1
  // and the Minor version shall be set to 0.
  //
  TREE_VERSION StructureVersion;
  //
  // Version of the TrEE protocol.
  // For this version of the protocol, the Major version shall be set to 1
  // and the Minor version shall be set to 0.
  //
  TREE_VERSION ProtocolVersion;
  //
  // Supported hash algorithms
  //
  public uint HashAlgorithmBitmap;
  //
  // Bitmap of supported event log formats
  //
  TREE_EVENT_LOG_BITMAP SupportedEventLogs;
  //
  // False = TrEE not present
  //
  public bool TrEEPresentFlag;
  //
  // Max size (in bytes) of a command that can be sent to the TrEE
  //
  public ushort MaxCommandSize;
  //
  // Max size (in bytes) of a response that can be provided by the TrEE
  //
  public ushort MaxResponseSize;
  //
  // 4-byte Vendor ID (see Trusted Computing Group, "TCG Vendor ID Registry,"
  // Version 1.0, Revision 0.1, August 31, 2007, "TPM Capabilities Vendor ID" section)
  //
  public uint ManufacturerID;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TREE_BOOT_SERVICE_CAPABILITY { TREE_BOOT_SERVICE_CAPABILITY_1_0 Value; public static implicit operator TREE_BOOT_SERVICE_CAPABILITY(TREE_BOOT_SERVICE_CAPABILITY_1_0 value) => new TREE_BOOT_SERVICE_CAPABILITY() { Value = value }; public static implicit operator TREE_BOOT_SERVICE_CAPABILITY_1_0(TREE_BOOT_SERVICE_CAPABILITY value) => value.Value; }

public const ulong TREE_BOOT_HASH_ALG_SHA1 = 0x00000001;
public const ulong TREE_BOOT_HASH_ALG_SHA256 = 0x00000002;
public const ulong TREE_BOOT_HASH_ALG_SHA384 = 0x00000004;
public const ulong TREE_BOOT_HASH_ALG_SHA512 = 0x00000008;

//
// This bit is shall be set when an event shall be extended but not logged.
//
public const ulong TREE_EXTEND_ONLY = 0x0000000000000001;
//
// This bit shall be set when the intent is to measure a PE/COFF image.
//
public const ulong PE_COFF_IMAGE = 0x0000000000000010;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TrEE_PCRINDEX { uint Value; public static implicit operator TrEE_PCRINDEX(uint value) => new TrEE_PCRINDEX() { Value = value }; public static implicit operator uint(TrEE_PCRINDEX value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TrEE_EVENTTYPE { uint Value; public static implicit operator TrEE_EVENTTYPE(uint value) => new TrEE_EVENTTYPE() { Value = value }; public static implicit operator uint(TrEE_EVENTTYPE value) => value.Value; }

public const ulong MAX_PCR_INDEX = 23;
public const ulong TREE_EVENT_HEADER_VERSION = 1;

// #pragma pack(1)

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TrEE_EVENT_HEADER
{
  //
  // Size of the event header itself (sizeof(TrEE_EVENT_HEADER)).
  //
  public uint HeaderSize;
  //
  // Header version. For this version of this specification, the value shall be 1.
  //
  public ushort HeaderVersion;
  //
  // Index of the PCR that shall be extended (0 - 23).
  //
  TrEE_PCRINDEX PCRIndex;
  //
  // Type of the event that shall be extended (and optionally logged).
  //
  TrEE_EVENTTYPE EventType;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TrEE_EVENT
{
  //
  // Total size of the event including the Size component, the header and the Event data.
  //
  public uint Size;
  TrEE_EVENT_HEADER Header;
  public fixed byte Event[1];
}

// #pragma pack()











































































































[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TREE_PROTOCOL
{
  /**
    The EFI_TREE_PROTOCOL GetCapability function call provides protocol
    capability information and state information about the TrEE.

    @param[in]  This               Indicates the calling context
    @param[out] ProtocolCapability The caller allocates memory for a TREE_BOOT_SERVICE_CAPABILITY
                                   structure and sets the size field to the size of the structure allocated.
                                   The callee fills in the fields with the EFI protocol capability information
                                   and the current TrEE state information up to the number of fields which
                                   fit within the size of the structure passed in.

    @retval EFI_SUCCESS            Operation completed successfully.
    @retval EFI_DEVICE_ERROR       The command was unsuccessful.
                                   The ProtocolCapability variable will not be populated.
    @retval EFI_INVALID_PARAMETER  One or more of the parameters are incorrect.
                                   The ProtocolCapability variable will not be populated.
    @retval EFI_BUFFER_TOO_SMALL   The ProtocolCapability variable is too small to hold the full response.
                                   It will be partially populated (required Size field will be set).
  **/
  public readonly delegate* unmanaged<EFI_TREE_PROTOCOL*, TREE_BOOT_SERVICE_CAPABILITY*, EFI_STATUS> GetCapability;
  /**
    The EFI_TREE_PROTOCOL Get Event Log function call allows a caller to
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
  public readonly delegate* unmanaged<EFI_TREE_PROTOCOL*, TREE_EVENT_LOG_FORMAT, EFI_PHYSICAL_ADDRESS*, EFI_PHYSICAL_ADDRESS*, bool*, EFI_STATUS> GetEventLog;
  /**
    The EFI_TREE_PROTOCOL HashLogExtendEvent function call provides callers with
    an opportunity to extend and optionally log events without requiring
    knowledge of actual TPM commands.
    The extend operation will occur even if this function cannot create an event
    log entry (e.g. due to the event log being full).

    @param[in]  This               Indicates the calling context
    @param[in]  Flags              Bitmap providing additional information.
    @param[in]  DataToHash         Physical address of the start of the data buffer to be hashed.
    @param[in]  DataToHashLen      The length in bytes of the buffer referenced by DataToHash.
    @param[in]  Event              Pointer to data buffer containing information about the event.

    @retval EFI_SUCCESS            Operation completed successfully.
    @retval EFI_DEVICE_ERROR       The command was unsuccessful.
    @retval EFI_VOLUME_FULL        The extend operation occurred, but the event could not be written to one or more event logs.
    @retval EFI_INVALID_PARAMETER  One or more of the parameters are incorrect.
    @retval EFI_UNSUPPORTED        The PE/COFF image type is not supported.
  **/
  public readonly delegate* unmanaged<EFI_TREE_PROTOCOL*, ulong, EFI_PHYSICAL_ADDRESS, ulong, TrEE_EVENT*, EFI_STATUS> HashLogExtendEvent;
  /**
    This service enables the sending of commands to the TrEE.

    @param[in]  This                     Indicates the calling context
    @param[in]  InputParameterBlockSize  Size of the TrEE input parameter block.
    @param[in]  InputParameterBlock      Pointer to the TrEE input parameter block.
    @param[in]  OutputParameterBlockSize Size of the TrEE output parameter block.
    @param[in]  OutputParameterBlock     Pointer to the TrEE output parameter block.

    @retval EFI_SUCCESS            The command byte stream was successfully sent to the device and a response was successfully received.
    @retval EFI_DEVICE_ERROR       The command was not successfully sent to the device or a response was not successfully received from the device.
    @retval EFI_INVALID_PARAMETER  One or more of the parameters are incorrect.
    @retval EFI_BUFFER_TOO_SMALL   The output parameter block is too small.
  **/
  public readonly delegate* unmanaged<EFI_TREE_PROTOCOL*, uint, byte*, uint, byte*, EFI_STATUS> SubmitCommand;
}

// extern EFI_GUID  gEfiTrEEProtocolGuid;

// #endif
