using System.Runtime.InteropServices;

namespace Uefi;
/** @file

  The definitions of DMTF Platform Level Data Model (PLDM)
  Base Specification.

  Copyright (C) 2023 Advanced Micro Devices, Inc. All rights reserved.
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  DMTF Platform Level Data Model (PLDM) Base Specification
  Version 1.1.0
  https://www.dmtf.org/sites/default/files/standards/documents/DSP0240_1.1.0.pdf

**/

// #ifndef PLDM_H_
// #define PLDM_H_

// #pragma pack(1)

public unsafe partial class EFI
{
  public const ulong PLDM_MESSAGE_HEADER_VERSION = 0;
}

///
/// General definitions from Platform Level Data Model (PLDM) Base
/// Specification (DMTF DSP0240)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_MESSAGE_HEADER
{
  public byte InstanceId = 5;          ///< Request instance ID.
  public byte Reserved = 1;          ///< Reserved bit.
  public byte DatagramBit = 1;          ///< used to indicate whether the Instance ID field is
                                        ///< being used for tracking and matching requests and
                                        ///< responses, or just being used for asynchronous
                                        ///< notifications.
  public byte RequestBit = 1;          ///< Request bit.
  public byte PldmType = 6;          ///< PLDM message type.
  public byte HeaderVersion = 2;          ///< Header version.
  public byte PldmTypeCommandCode;        ///< The command code of PLDM message type.
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_REQUEST_HEADER { PLDM_MESSAGE_HEADER Value; public static implicit operator PLDM_REQUEST_HEADER(PLDM_MESSAGE_HEADER value) => new PLDM_REQUEST_HEADER() { Value = value }; public static implicit operator PLDM_MESSAGE_HEADER(PLDM_REQUEST_HEADER value) => value.Value; }

public unsafe partial class EFI
{
  public const ulong PLDM_MESSAGE_HEADER_IS_REQUEST = 1;
  public const ulong PLDM_MESSAGE_HEADER_IS_DATAGRAM = 1;
  public const ulong PLDM_MESSAGE_HEADER_INSTANCE_ID_MASK = 0x1f;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_RESPONSE_HEADER
{
  public PLDM_MESSAGE_HEADER PldmHeader;
  public byte PldmCompletionCode;   ///< PLDM completion  of response message.
}

// #pragma pack()

public unsafe partial class EFI
{
  public const ulong PLDM_HEADER_VERSION = 0x00;

  public const ulong PLDM_COMPLETION_CODE_SUCCESS = 0x00;
  public const ulong PLDM_COMPLETION_CODE_ERROR = 0x01;
  public const ulong PLDM_COMPLETION_CODE_ERROR_INVALID_DATA = 0x02;
  public const ulong PLDM_COMPLETION_CODE_ERROR_INVALID_LENGTH = 0x03;
  public const ulong PLDM_COMPLETION_CODE_ERROR_NOT_READY = 0x04;
  public const ulong PLDM_COMPLETION_CODE_ERROR_UNSUPPORTED_PLDM_CMD = 0x05;
  public const ulong PLDM_COMPLETION_CODE_ERROR_INVALID_PLDM_TYPE = 0x20;
  public const ulong PLDM_COMPLETION_CODE_SPECIFIC_START = 0x80;
  public const ulong PLDM_COMPLETION_CODE_SPECIFIC_END = 0xff;

  ///
  /// Type Code definitions from Platform Level Data Model (PLDM) IDs
  /// and Codes Specification (DMTF DSP0245)
  /// https://www.dmtf.org/sites/default/files/standards/documents/DSP0245_1.3.0.pdf
  ///
  public const ulong PLDM_TYPE_MESSAGE_CONTROL_AND_DISCOVERY = 0x00;
  public const ulong PLDM_TYPE_SMBIOS = 0x01;
  public const ulong PLDM_TYPE_PLATFORM_MONITORING_AND_CONTROL = 0x02;
  public const ulong PLDM_TYPE_BIOS_CONTROL_AND_CONFIGURATION = 0x03;

  public const ulong PLDM_TRANSFER_FLAG_START = 0x01;
  public const ulong PLDM_TRANSFER_FLAG_MIDDLE = 0x02;
  public const ulong PLDM_TRANSFER_FLAG_END = 0x04;
  public const ulong PLDM_TRANSFER_FLAG_START_AND_END = 0x05;
}

public const ulong PLDM_TRANSFER_OPERATION_FLAG_GET_NEXT_PART = 0x00;
public const ulong PLDM_TRANSFER_OPERATION_FLAG_GET_FIRST_PART = 0x01;
// #endif // PLDM_H_
