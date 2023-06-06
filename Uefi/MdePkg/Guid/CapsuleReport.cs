using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Guid & data structure used for Capsule process result variables

  Copyright (c) 2015 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  GUIDs defined in UEFI 2.4 spec.

**/

// #ifndef _CAPSULE_REPORT_GUID_H__
// #define _CAPSULE_REPORT_GUID_H__

public unsafe partial class EFI
{
  //
  // This is the GUID for capsule result variable.
  //
  public static EFI_GUID EFI_CAPSULE_REPORT_GUID => new GUID(
      0x39b68c46, 0xf7fb, 0x441b, 0xb6, 0xec, 0x16, 0xb0, 0xf6, 0x98, 0x21, 0xf3);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CAPSULE_RESULT_VARIABLE_HEADER
{
  ///
  /// Size in bytes of the variable including any data beyond header as specified by CapsuleGuid
  ///
  public uint VariableTotalSize;

  ///
  /// For alignment
  ///
  public uint Reserved;

  ///
  /// Guid from EFI_CAPSULE_HEADER
  ///
  public EFI_GUID CapsuleGuid;

  ///
  /// Timestamp using system time when processing completed
  ///
  public EFI_TIME CapsuleProcessed;

  ///
  /// Result of the capsule processing. Exact interpretation of any error code may depend
  /// upon type of capsule processed
  ///
  public EFI_STATUS CapsuleStatus;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CAPSULE_RESULT_VARIABLE_FMP
{
  ///
  /// Version of this structure, currently 0x00000001
  ///
  public ushort Version;

  ///
  /// The index of the payload within the FMP capsule which was processed to generate this report
  /// Starting from zero
  ///
  public byte PayloadIndex;

  ///
  /// The UpdateImageIndex from EFI_FIRMWARE_MANAGEMENT_CAPSULE_IMAGE_HEADER
  /// (after unsigned conversion from byte to UINT16).
  ///
  public byte UpdateImageIndex;

  ///
  /// The UpdateImageTypeId Guid from EFI_FIRMWARE_MANAGEMENT_CAPSULE_IMAGE_HEADER.
  ///
  public EFI_GUID UpdateImageTypeId;

  ///
  /// In case of capsule loaded from disk, the zero-terminated array containing file name of capsule that was processed.
  /// In case of capsule submitted directly to UpdateCapsule() there is no file name, and this field is required to contain a single 16-bit zero character
  ///  which is included in VariableTotalSize.
  ///
  /// char CapsuleFileName[];
  ///

  ///
  /// This field will contain a zero-terminated char string containing the text representation of the device path of device publishing Firmware Management Protocol
  /// (if present). In case where device path is not present and the target is not otherwise known to firmware, or when payload was blocked by policy, or skipped,
  /// this field is required to contain a single 16-bit zero character which is included in VariableTotalSize.
  ///
  /// char CapsuleTarget[];
  ///
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CAPSULE_RESULT_VARIABLE_JSON
{
  ///
  /// Version of this structure, currently 0x00000001
  ///
  public uint Version;

  ///
  /// The unique identifier of the capsule whose processing result is recorded in this variable.
  /// 0x00000000 - 0xEFFFFFFF - Implementation Reserved
  /// 0xF0000000 - 0xFFFFFFFF - Specification Reserved
  public unsafe partial class EFI
  {
    public const ulong REDFISH_DEFINED_JSON_SCHEMA = 0xF000000;
    /// The JSON payload shall conform to a Redfish-defined JSON schema, see DMTF-Redfish
    /// Specification.
    ///
    public uint CapsuleId;

    ///
    /// The length of Resp in bytes.
    ///
    public uint RespLength;

    ///
    /// Variable length buffer containing the replied JSON payload to the caller who delivered JSON
    /// capsule to system. The definition of the JSON schema used in the replied payload is beyond
    /// the scope of this specification.
    ///
    public byte[] Resp;
  }

  // extern EFI_GUID  gEfiCapsuleReportGuid;
}

// #endif
