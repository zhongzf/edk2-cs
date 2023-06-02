using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Definitions of Security Protocol & Data Model Specification (SPDM)
  version 1.0.0 in Distributed Management Task Force (DMTF).

Copyright (c) 2019, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SPDM_H__
// #define __SPDM_H__

// #pragma pack(1)

///
/// SPDM response code
///
public unsafe partial class EFI
{
  public const ulong SPDM_DIGESTS = 0x01;
  public const ulong SPDM_CERTIFICATE = 0x02;
  public const ulong SPDM_CHALLENGE_AUTH = 0x03;
  public const ulong SPDM_VERSION = 0x04;
  public const ulong SPDM_MEASUREMENTS = 0x60;
  public const ulong SPDM_CAPABILITIES = 0x61;
  public const ulong SPDM_SET_CERT_RESPONSE = 0x62;
  public const ulong SPDM_ALGORITHMS = 0x63;
  public const ulong SPDM_ERROR = 0x7F;
  ///
  /// SPDM request code
  ///
  public const ulong SPDM_GET_DIGESTS = 0x81;
  public const ulong SPDM_GET_CERTIFICATE = 0x82;
  public const ulong SPDM_CHALLENGE = 0x83;
  public const ulong SPDM_GET_VERSION = 0x84;
  public const ulong SPDM_GET_MEASUREMENTS = 0xE0;
  public const ulong SPDM_GET_CAPABILITIES = 0xE1;
  public const ulong SPDM_NEGOTIATE_ALGORITHMS = 0xE3;
  public const ulong SPDM_RESPOND_IF_READY = 0xFF;
}

///
/// SPDM message header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_MESSAGE_HEADER
{
  public byte SPDMVersion;
  public byte RequestResponseCode;
  public byte Param1;
  public byte Param2;
}

public unsafe partial class EFI
{
  public const ulong SPDM_MESSAGE_VERSION = 0x10;
}

///
/// SPDM GET_VERSION request
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_GET_VERSION_REQUEST
{
  public SPDM_MESSAGE_HEADER Header;
}

///
/// SPDM GET_VERSION response
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_VERSION_RESPONSE
{
  public SPDM_MESSAGE_HEADER Header;
  public byte Reserved;
  public byte VersionNumberEntryCount;
  // SPDM_VERSION_NUMBER  VersionNumberEntry[VersionNumberEntryCount];
}

///
/// SPDM VERSION structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_VERSION_NUMBER
{
  public ushort Alpha = 4;
  public ushort UpdateVersionNumber = 4;
  public ushort MinorVersion = 4;
  public ushort MajorVersion = 4;
}

///
/// SPDM GET_CAPABILITIES request
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_GET_CAPABILITIES_REQUEST
{
  public SPDM_MESSAGE_HEADER Header;
}

///
/// SPDM GET_CAPABILITIES response
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_CAPABILITIES_RESPONSE
{
  public SPDM_MESSAGE_HEADER Header;
  public byte Reserved;
  public byte CTExponent;
  public ushort Reserved2;
  public uint Flags;
}

///
/// SPDM GET_CAPABILITIES response Flags
///
public unsafe partial class EFI
{
  public const ulong SPDM_GET_CAPABILITIES_RESPONSE_FLAGS_CACHE_CAP = BIT0;
  public const ulong SPDM_GET_CAPABILITIES_RESPONSE_FLAGS_CERT_CAP = BIT1;
  public const ulong SPDM_GET_CAPABILITIES_RESPONSE_FLAGS_CHAL_CAP = BIT2;
  public const ulong SPDM_GET_CAPABILITIES_RESPONSE_FLAGS_MEAS_CAP = (BIT3 | BIT4);
  public const ulong SPDM_GET_CAPABILITIES_RESPONSE_FLAGS_MEAS_CAP_NO_SIG = BIT3;
  public const ulong SPDM_GET_CAPABILITIES_RESPONSE_FLAGS_MEAS_CAP_SIG = BIT4;
  public const ulong SPDM_GET_CAPABILITIES_RESPONSE_FLAGS_MEAS_FRESH_CAP = BIT5;
}

///
/// SPDM NEGOTIATE_ALGORITHMS request
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_NEGOTIATE_ALGORITHMS_REQUEST
{
  public SPDM_MESSAGE_HEADER Header;
  public ushort Length;
  public byte MeasurementSpecification;
  public byte Reserved;
  public uint BaseAsymAlgo;
  public uint BaseHashAlgo;
  public fixed byte Reserved2[12];
  public byte ExtAsymCount;
  public byte ExtHashCount;
  public ushort Reserved3;
  // uint               ExtAsym[ExtAsymCount];
  // uint               ExtHash[ExtHashCount];
}

///
/// SPDM NEGOTIATE_ALGORITHMS request BaseAsymAlgo
///
public unsafe partial class EFI
{
  public const ulong SPDM_ALGORITHMS_BASE_ASYM_ALGO_TPM_ALG_RSASSA_2048 = BIT0;
  public const ulong SPDM_ALGORITHMS_BASE_ASYM_ALGO_TPM_ALG_RSAPSS_2048 = BIT1;
  public const ulong SPDM_ALGORITHMS_BASE_ASYM_ALGO_TPM_ALG_RSASSA_3072 = BIT2;
  public const ulong SPDM_ALGORITHMS_BASE_ASYM_ALGO_TPM_ALG_RSAPSS_3072 = BIT3;
  public const ulong SPDM_ALGORITHMS_BASE_ASYM_ALGO_TPM_ALG_ECDSA_ECC_NIST_P256 = BIT4;
  public const ulong SPDM_ALGORITHMS_BASE_ASYM_ALGO_TPM_ALG_RSASSA_4096 = BIT5;
  public const ulong SPDM_ALGORITHMS_BASE_ASYM_ALGO_TPM_ALG_RSAPSS_4096 = BIT6;
  public const ulong SPDM_ALGORITHMS_BASE_ASYM_ALGO_TPM_ALG_ECDSA_ECC_NIST_P384 = BIT7;
  public const ulong SPDM_ALGORITHMS_BASE_ASYM_ALGO_TPM_ALG_ECDSA_ECC_NIST_P521 = BIT8;

  ///
  /// SPDM NEGOTIATE_ALGORITHMS request BaseHashAlgo
  ///
  public const ulong SPDM_ALGORITHMS_BASE_HASH_ALGO_TPM_ALG_SHA_256 = BIT0;
  public const ulong SPDM_ALGORITHMS_BASE_HASH_ALGO_TPM_ALG_SHA_384 = BIT1;
  public const ulong SPDM_ALGORITHMS_BASE_HASH_ALGO_TPM_ALG_SHA_512 = BIT2;
  public const ulong SPDM_ALGORITHMS_BASE_HASH_ALGO_TPM_ALG_SHA3_256 = BIT3;
  public const ulong SPDM_ALGORITHMS_BASE_HASH_ALGO_TPM_ALG_SHA3_384 = BIT4;
  public const ulong SPDM_ALGORITHMS_BASE_HASH_ALGO_TPM_ALG_SHA3_512 = BIT5;
}

///
/// SPDM NEGOTIATE_ALGORITHMS response
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_ALGORITHMS_RESPONSE
{
  public SPDM_MESSAGE_HEADER Header;
  public ushort Length;
  public byte MeasurementSpecificationSel;
  public byte Reserved;
  public uint MeasurementHashAlgo;
  public uint BaseAsymSel;
  public uint BaseHashSel;
  public fixed byte Reserved2[12];
  public byte ExtAsymSelCount;
  public byte ExtHashSelCount;
  public ushort Reserved3;
  // uint               ExtAsymSel[ExtAsymSelCount];
  // uint               ExtHashSel[ExtHashSelCount];
}

///
/// SPDM NEGOTIATE_ALGORITHMS response MeasurementHashAlgo
///
public unsafe partial class EFI
{
  public const ulong SPDM_ALGORITHMS_MEASUREMENT_HASH_ALGO_RAW_BIT_STREAM_ONLY = BIT0;
  public const ulong SPDM_ALGORITHMS_MEASUREMENT_HASH_ALGO_TPM_ALG_SHA_256 = BIT1;
  public const ulong SPDM_ALGORITHMS_MEASUREMENT_HASH_ALGO_TPM_ALG_SHA_384 = BIT2;
  public const ulong SPDM_ALGORITHMS_MEASUREMENT_HASH_ALGO_TPM_ALG_SHA_512 = BIT3;
  public const ulong SPDM_ALGORITHMS_MEASUREMENT_HASH_ALGO_TPM_ALG_SHA3_256 = BIT4;
  public const ulong SPDM_ALGORITHMS_MEASUREMENT_HASH_ALGO_TPM_ALG_SHA3_384 = BIT5;
  public const ulong SPDM_ALGORITHMS_MEASUREMENT_HASH_ALGO_TPM_ALG_SHA3_512 = BIT6;
}

///
/// SPDM GET_DIGESTS request
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_GET_DIGESTS_REQUEST
{
  public SPDM_MESSAGE_HEADER Header;
}

///
/// SPDM GET_DIGESTS response
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_DIGESTS_RESPONSE
{
  public SPDM_MESSAGE_HEADER Header;
  // byte                Digest[DigestSize];
}

///
/// SPDM GET_DIGESTS request
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_GET_CERTIFICATE_REQUEST
{
  public SPDM_MESSAGE_HEADER Header;
  public ushort Offset;
  public ushort Length;
}

///
/// SPDM GET_DIGESTS response
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_CERTIFICATE_RESPONSE
{
  public SPDM_MESSAGE_HEADER Header;
  public ushort PortionLength;
  public ushort RemainderLength;
  // byte                CertChain[CertChainSize];
}

///
/// SPDM CHALLENGE request
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_CHALLENGE_REQUEST
{
  public SPDM_MESSAGE_HEADER Header;
  public fixed byte Nonce[32];
}

///
/// SPDM CHALLENGE response
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_CHALLENGE_AUTH_RESPONSE
{
  public SPDM_MESSAGE_HEADER Header;
  // byte                CertChainHash[DigestSize];
  // byte                Nonce[32];
  // byte                MeasurementSummaryHash[DigestSize];
  // ushort               OpaqueLength;
  // byte                OpaqueData[OpaqueLength];
  // byte                Signature[KeySize];
}

///
/// SPDM GET_MEASUREMENTS request
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_GET_MEASUREMENTS_REQUEST
{
  public SPDM_MESSAGE_HEADER Header;
  public fixed byte Nonce[32];
}

///
/// SPDM MEASUREMENTS block common header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_MEASUREMENT_BLOCK_COMMON_HEADER
{
  public byte Index;
  public byte MeasurementSpecification;
  public ushort MeasurementSize;
  // byte                Measurement[MeasurementSize];
}

public unsafe partial class EFI
{
  public const ulong SPDM_MEASUREMENT_BLOCK_HEADER_SPECIFICATION_DMTF = BIT0;
}

///
/// SPDM MEASUREMENTS block DMTF header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_MEASUREMENT_BLOCK_DMTF_HEADER
{
  public byte DMTFSpecMeasurementValueType;
  public ushort DMTFSpecMeasurementValueSize;
  // byte                DMTFSpecMeasurementValue[DMTFSpecMeasurementValueSize];
}

///
/// SPDM MEASUREMENTS block MeasurementValueType
///
public unsafe partial class EFI
{
  public const ulong SPDM_MEASUREMENT_BLOCK_MEASUREMENT_TYPE_IMMUTABLE_ROM = 0;
  public const ulong SPDM_MEASUREMENT_BLOCK_MEASUREMENT_TYPE_MUTABLE_FIRMWARE = 1;
  public const ulong SPDM_MEASUREMENT_BLOCK_MEASUREMENT_TYPE_HARDWARE_CONFIGURATION = 2;
  public const ulong SPDM_MEASUREMENT_BLOCK_MEASUREMENT_TYPE_FIRMWARE_CONFIGURATION = 3;
  public const ulong SPDM_MEASUREMENT_BLOCK_MEASUREMENT_TYPE_RAW_BIT_STREAM = BIT7;
}

///
/// SPDM GET_MEASUREMENTS response
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_MEASUREMENTS_RESPONSE
{
  public SPDM_MESSAGE_HEADER Header;
  public byte NumberOfBlocks;
  public fixed byte MeasurementRecordLength[3];
  // byte                MeasurementRecord[MeasurementRecordLength];
  // byte                Nonce[32];
  // ushort               OpaqueLength;
  // byte                OpaqueData[OpaqueLength];
  // byte                Signature[KeySize];
}

///
/// SPDM ERROR response
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_ERROR_RESPONSE
{
  public SPDM_MESSAGE_HEADER Header;
  // Param1 == Error Code
  // Param2 == Error Data
  // byte                ExtendedErrorData[];
}

///
/// SPDM error code
///
public unsafe partial class EFI
{
  public const ulong SPDM_ERROR_CODE_INVALID_REQUEST = 0x01;
  public const ulong SPDM_ERROR_CODE_BUSY = 0x03;
  public const ulong SPDM_ERROR_CODE_UNEXPECTED_REQUEST = 0x04;
  public const ulong SPDM_ERROR_CODE_UNSPECIFIED = 0x05;
  public const ulong SPDM_ERROR_CODE_UNSUPPORTED_REQUEST = 0x07;
  public const ulong SPDM_ERROR_CODE_MAJOR_VERSION_MISMATCH = 0x41;
  public const ulong SPDM_ERROR_CODE_RESPONSE_NOT_READY = 0x42;
  public const ulong SPDM_ERROR_CODE_REQUEST_RESYNCH = 0x43;
}

///
/// SPDM RESPONSE_IF_READY request
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPDM_RESPONSE_IF_READY_REQUEST
{
  public SPDM_MESSAGE_HEADER Header;
  // Param1 == RequestCode
  // Param2 == Token
}

// #pragma pack()

// #endif
