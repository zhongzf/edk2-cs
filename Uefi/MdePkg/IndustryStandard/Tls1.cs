using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Transport Layer Security  -- TLS 1.0/1.1/1.2 Standard definitions, from RFC 2246/4346/5246

  This file contains common TLS 1.0/1.1/1.2 definitions from RFC 2246/4346/5246

  Copyright (c) 2016 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef __TLS_1_H__
// #define __TLS_1_H__

// #pragma pack(1)

public unsafe partial class EFI
{
  ///
  /// TLS Cipher Suite, refers to A.5 of rfc-2246, rfc-4346, rfc-5246, rfc-5288 and rfc-5289.
  ///
  //public const ulong TLS_RSA_WITH_NULL_MD5 = { 0x00, 0x01 };
  //public const ulong TLS_RSA_WITH_NULL_SHA = { 0x00, 0x02 };
  //public const ulong TLS_RSA_WITH_RC4_128_MD5 = { 0x00, 0x04 };
  //public const ulong TLS_RSA_WITH_RC4_128_SHA = { 0x00, 0x05 };
  //public const ulong TLS_RSA_WITH_IDEA_CBC_SHA = { 0x00, 0x07 };
  //public const ulong TLS_RSA_WITH_DES_CBC_SHA = { 0x00, 0x09 };
  //public const ulong TLS_RSA_WITH_3DES_EDE_CBC_SHA = { 0x00, 0x0A };
  //public const ulong TLS_DH_DSS_WITH_DES_CBC_SHA = { 0x00, 0x0C };
  //public const ulong TLS_DH_DSS_WITH_3DES_EDE_CBC_SHA = { 0x00, 0x0D };
  //public const ulong TLS_DH_RSA_WITH_DES_CBC_SHA = { 0x00, 0x0F };
  //public const ulong TLS_DH_RSA_WITH_3DES_EDE_CBC_SHA = { 0x00, 0x10 };
  //public const ulong TLS_DHE_DSS_WITH_DES_CBC_SHA = { 0x00, 0x12 };
  //public const ulong TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA = { 0x00, 0x13 };
  //public const ulong TLS_DHE_RSA_WITH_DES_CBC_SHA = { 0x00, 0x15 };
  //public const ulong TLS_DHE_RSA_WITH_3DES_EDE_CBC_SHA = { 0x00, 0x16 };
  //public const ulong TLS_RSA_WITH_AES_128_CBC_SHA = { 0x00, 0x2F };
  //public const ulong TLS_DH_DSS_WITH_AES_128_CBC_SHA = { 0x00, 0x30 };
  //public const ulong TLS_DH_RSA_WITH_AES_128_CBC_SHA = { 0x00, 0x31 };
  //public const ulong TLS_DHE_DSS_WITH_AES_128_CBC_SHA = { 0x00, 0x32 };
  //public const ulong TLS_DHE_RSA_WITH_AES_128_CBC_SHA = { 0x00, 0x33 };
  //public const ulong TLS_RSA_WITH_AES_256_CBC_SHA = { 0x00, 0x35 };
  //public const ulong TLS_DH_DSS_WITH_AES_256_CBC_SHA = { 0x00, 0x36 };
  //public const ulong TLS_DH_RSA_WITH_AES_256_CBC_SHA = { 0x00, 0x37 };
  //public const ulong TLS_DHE_DSS_WITH_AES_256_CBC_SHA = { 0x00, 0x38 };
  //public const ulong TLS_DHE_RSA_WITH_AES_256_CBC_SHA = { 0x00, 0x39 };
  //public const ulong TLS_RSA_WITH_NULL_SHA256 = { 0x00, 0x3B };
  //public const ulong TLS_RSA_WITH_AES_128_CBC_SHA256 = { 0x00, 0x3C };
  //public const ulong TLS_RSA_WITH_AES_256_CBC_SHA256 = { 0x00, 0x3D };
  //public const ulong TLS_DH_DSS_WITH_AES_128_CBC_SHA256 = { 0x00, 0x3E };
  //public const ulong TLS_DH_RSA_WITH_AES_128_CBC_SHA256 = { 0x00, 0x3F };
  //public const ulong TLS_DHE_DSS_WITH_AES_128_CBC_SHA256 = { 0x00, 0x40 };
  //public const ulong TLS_DHE_RSA_WITH_AES_128_CBC_SHA256 = { 0x00, 0x67 };
  //public const ulong TLS_DH_DSS_WITH_AES_256_CBC_SHA256 = { 0x00, 0x68 };
  //public const ulong TLS_DH_RSA_WITH_AES_256_CBC_SHA256 = { 0x00, 0x69 };
  //public const ulong TLS_DHE_DSS_WITH_AES_256_CBC_SHA256 = { 0x00, 0x6A };
  //public const ulong TLS_DHE_RSA_WITH_AES_256_CBC_SHA256 = { 0x00, 0x6B };
  //public const ulong TLS_DHE_RSA_WITH_AES_256_GCM_SHA384 = { 0x00, 0x9F };
  //public const ulong TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256 = { 0xC0, 0x2B };
  //public const ulong TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384 = { 0xC0, 0x2C };
  //public const ulong TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384 = { 0xC0, 0x30 };

  ///
  /// TLS Version, refers to A.1 of rfc-2246, rfc-4346 and rfc-5246.
  ///
  public const ulong TLS10_PROTOCOL_VERSION_MAJOR = 0x03;
  public const ulong TLS10_PROTOCOL_VERSION_MINOR = 0x01;
  public const ulong TLS11_PROTOCOL_VERSION_MAJOR = 0x03;
  public const ulong TLS11_PROTOCOL_VERSION_MINOR = 0x02;
  public const ulong TLS12_PROTOCOL_VERSION_MAJOR = 0x03;
  public const ulong TLS12_PROTOCOL_VERSION_MINOR = 0x03;
}

///
/// TLS Content Type, refers to A.1 of rfc-2246, rfc-4346 and rfc-5246.
///
public enum TLS_CONTENT_TYPE
{
  TlsContentTypeChangeCipherSpec = 20,
  TlsContentTypeAlert = 21,
  TlsContentTypeHandshake = 22,
  TlsContentTypeApplicationData = 23,
}

///
/// TLS Record Header, refers to A.1 of rfc-2246, rfc-4346 and rfc-5246.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TLS_RECORD_HEADER
{
  public byte ContentType;
  public EFI_TLS_VERSION Version;
  public ushort Length;
}

public unsafe partial class EFI
{
  public const ulong TLS_RECORD_HEADER_LENGTH = 5;

  //
  // The length (in bytes) of the TLSPlaintext records payload MUST NOT exceed 2^14.
  // Refers to section 6.2 of RFC5246.
  //
  public const ulong TLS_PLAINTEXT_RECORD_MAX_PAYLOAD_LENGTH = 16384;

  //
  // The length (in bytes) of the TLSCiphertext records payload MUST NOT exceed 2^14 + 2048.
  // Refers to section 6.2 of RFC5246.
  //
  public const ulong TLS_CIPHERTEXT_RECORD_MAX_PAYLOAD_LENGTH = 18432;
}

///
/// TLS Hash algorithm, refers to section 7.4.1.4.1. of rfc-5246.
///
public enum TLS_HASH_ALGO
{
  TlsHashAlgoNone = 0,
  TlsHashAlgoMd5 = 1,
  TlsHashAlgoSha1 = 2,
  TlsHashAlgoSha224 = 3,
  TlsHashAlgoSha256 = 4,
  TlsHashAlgoSha384 = 5,
  TlsHashAlgoSha512 = 6,
}

///
/// TLS Signature algorithm, refers to section 7.4.1.4.1. of rfc-5246.
///
public enum TLS_SIGNATURE_ALGO
{
  TlsSignatureAlgoAnonymous = 0,
  TlsSignatureAlgoRsa = 1,
  TlsSignatureAlgoDsa = 2,
  TlsSignatureAlgoEcdsa = 3,
}

///
/// TLS Supported Elliptic Curves Extensions, refers to section 5.1.1 of rfc-8422.
///
public enum TLS_EC_NAMED_CURVE
{
  TlsEcNamedCurveSecp256r1 = 23,
  TlsEcNamedCurveSecp384r1 = 24,
  TlsEcNamedCurveSecp521r1 = 25,
  TlsEcNamedCurveX25519 = 29,
  TlsEcNamedCurveX448 = 30,
}

// #pragma pack()

// #endif
