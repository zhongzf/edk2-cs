using System.Runtime.InteropServices;

namespace Uefi;
/** @file

  The definitions of DMTF Platform Level Data Model (PLDM)
  SMBIOS Transfer Specification.

  Copyright (C) 2023 Advanced Micro Devices, Inc. All rights reserved.
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  DMTF Platform Level Data Model (PLDM) SMBIOS Transfer Specification
  Version 1.0.1
  https://www.dmtf.org/sites/default/files/standards/documents/DSP0246_1.0.1.pdf

**/

// #ifndef PLDM_SMBIOS_TRANSFER_H_
// #define PLDM_SMBIOS_TRANSFER_H_

// #include <IndustryStandard/Pldm.h>

// #pragma pack(1)

public unsafe partial class EFI
{
  ///
  /// Smbios-related definitions from PLDM for SMBIOS Transfer
  /// Specification (DMTF DSP0246)
  ///
  public const ulong PLDM_GET_SMBIOS_STRUCTURE_TABLE_METADATA_COMMAND_CODE = 0x01;
  public const ulong PLDM_SET_SMBIOS_STRUCTURE_TABLE_METADATA_COMMAND_CODE = 0x02;
  public const ulong PLDM_GET_SMBIOS_STRUCTURE_TABLE_COMMAND_CODE = 0x03;
  public const ulong PLDM_SET_SMBIOS_STRUCTURE_TABLE_COMMAND_CODE = 0x04;
  public const ulong PLDM_GET_SMBIOS_STRUCTURE_BY_TYPE_COMMAND_CODE = 0x05;
  public const ulong PLDM_GET_SMBIOS_STRUCTURE_BY_HANDLE_COMMAND_CODE = 0x06;

  ///
  /// PLDM SMBIOS transfer command specific completion code.
  ///
  public const ulong PLDM_COMPLETION_CODE_INVALID_DATA_TRANSFER_HANDLE = 0x80;
  public const ulong PLDM_COMPLETION_CODE_INVALID_TRANSFER_OPERATION_FLAG = 0x81;
  public const ulong PLDM_COMPLETION_CODE_INVALID_TRANSFER_FLAG = 0x82;
  public const ulong PLDM_COMPLETION_CODE_NO_SMBIOS_STRUCTURE_TABLE_METADATA = 0x83;
  public const ulong PLDM_COMPLETION_CODE_INVALID_DATA_INTEGRITY_CHECK = 0x84;
  public const ulong PLDM_COMPLETION_CODE_SMBIOS_STRUCTURE_TABLE_UNAVAILABLE = 0x85;
}

///
/// Get SMBIOS Structure Table Metadata Response.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_SMBIOS_STRUCTURE_TABLE_METADATA
{
  public byte SmbiosMajorVersion;
  public byte SmbiosMinorVersion;
  public ushort MaximumStructureSize;
  public ushort SmbiosStructureTableLength;
  public ushort NumberOfSmbiosStructures;
  public uint SmbiosStructureTableIntegrityChecksum;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_TABLE_METADATA_RESPONSE_FORMAT
{
  public PLDM_RESPONSE_HEADER ResponseHeader;
  public PLDM_SMBIOS_STRUCTURE_TABLE_METADATA SmbiosStructureTableMetadata;
}

///
/// Set SMBIOS Structure Table Metadata Request.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_SET_SMBIOS_STRUCTURE_TABLE_METADATA_REQUEST_FORMAT
{
  public PLDM_REQUEST_HEADER RequestHeader;
  public PLDM_SMBIOS_STRUCTURE_TABLE_METADATA SmbiosStructureTableMetadata;
}

///
/// Set SMBIOS Structure Table Metadata Response.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_SET_SMBIOS_STRUCTURE_TABLE_METADATA_RESPONSE_FORMAT
{
  public PLDM_RESPONSE_HEADER ResponseHeader;
}

///
/// Get SMBIOS Structure Table Request.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_TABLE_REQUEST
{
  public uint DataTransferHandle;
  public byte TransferOperationFlag;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_TABLE_REQUEST_FORMAT
{
  public PLDM_REQUEST_HEADER RequestHeader;
  public PLDM_GET_SMBIOS_STRUCTURE_TABLE_REQUEST GetSmbiosStructureTableRequest;
}

///
/// Get SMBIOS Structure Table Response.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_TABLE_RESPONSE
{
  public uint NextDataTransferHandle;
  public byte TransferFlag;
  public byte[] Table;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_TABLE_RESPONSE_FORMAT
{
  public PLDM_RESPONSE_HEADER ResponseHeader;
  public PLDM_GET_SMBIOS_STRUCTURE_TABLE_RESPONSE GetSmbiosStructureTableResponse;
}

///
/// Set SMBIOS Structure Table Request.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_SET_SMBIOS_STRUCTURE_TABLE_REQUEST
{
  public uint DataTransferHandle;
  public byte TransferFlag;
  public byte[] Table;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_SET_SMBIOS_STRUCTURE_TABLE_REQUEST_FORMAT
{
  public PLDM_REQUEST_HEADER RequestHeader;
  public PLDM_SET_SMBIOS_STRUCTURE_TABLE_REQUEST SetSmbiosStructureTableRequest;
}

///
/// Set SMBIOS Structure Table Response.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_SET_SMBIOS_STRUCTURE_TABLE_RESPONSE_FORMAT
{
  public PLDM_RESPONSE_HEADER ResponseHeader;
  public uint NextDataTransferHandle;
}

///
/// Get SMBIOS Structure by Type Request.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_BY_TYPE_REQUEST
{
  public uint DataTransferHandle;
  public byte TransferOperationFlag;
  public byte Type;
  public ushort StructureInstanceId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_BY_TYPE_REQUEST_FORMAT
{
  public PLDM_REQUEST_HEADER RequestHeader;
  public PLDM_GET_SMBIOS_STRUCTURE_BY_TYPE_REQUEST GetSmbiosStructureByTypeRequest;
}

///
/// Get SMBIOS Structure by Type Response.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_BY_TYPE_RESPONSE
{
  public uint NextDataTransferHandle;
  public byte TransferFlag;
  public byte[] Table;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_BY_TYPE_RESPONSE_FORMAT
{
  public PLDM_RESPONSE_HEADER ResponseHeader;
  public PLDM_GET_SMBIOS_STRUCTURE_BY_TYPE_RESPONSE GetSmbiosStructureByTypeResponse;
}

///
/// Get SMBIOS Structure by Handle Request.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_BY_HANDLE_REQUEST
{
  public uint DataTransferHandle;
  public byte TransferOperationFlag;
  public ushort Handle;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_BY_HANDLE_REQUEST_FORMAT
{
  public PLDM_REQUEST_HEADER RequestHeader;
  public PLDM_GET_SMBIOS_STRUCTURE_BY_HANDLE_REQUEST GetSmbiosStructureByHandleRequest;
}

///
/// Get SMBIOS Structure by Handle Response.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_BY_HANDLE_RESPONSE
{
  public uint NextDataTransferHandle;
  public byte TransferFlag;
  public byte[] Table;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PLDM_GET_SMBIOS_STRUCTURE_BY_HANDLE_RESPONSE_FORMAT
{
  public PLDM_RESPONSE_HEADER ResponseHeader;
  public PLDM_GET_SMBIOS_STRUCTURE_BY_HANDLE_RESPONSE GetSmbiosStructureByTypeResponse;
}
// #pragma pack()

// #endif // PLDM_SMBIOS_TRANSFER_H_
