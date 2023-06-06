using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  GUID for UEFI WIN_CERTIFICATE structure.

  Copyright (c) 2006 - 2012, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  GUID defined in UEFI 2.0 spec.
**/

// #ifndef __EFI_WIN_CERTIFICATE_H__
// #define __EFI_WIN_CERTIFICATE_H__

public unsafe partial class EFI
{
  //
  // _WIN_CERTIFICATE.wCertificateType
  //
  public const ulong WIN_CERT_TYPE_PKCS_SIGNED_DATA = 0x0002;
  public const ulong WIN_CERT_TYPE_EFI_PKCS115 = 0x0EF0;
  public const ulong WIN_CERT_TYPE_EFI_GUID = 0x0EF1;
}

///
/// The WIN_CERTIFICATE structure is part of the PE/COFF specification.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct WIN_CERTIFICATE
{
  ///
  /// The length of the entire certificate,
  /// including the length of the header, in bytes.
  ///
  public uint dwLength;
  ///
  /// The revision level of the WIN_CERTIFICATE
  /// structure. The current revision level is 0x0200.
  ///
  public ushort wRevision;
  ///
  /// The certificate type. See WIN_CERT_TYPE_xxx for the UEFI
  /// certificate types. The UEFI specification reserves the range of
  /// certificate type values from 0x0EF0 to 0x0EFF.
  ///
  public ushort wCertificateType;
  ///
  /// The following is the actual certificate. The format of
  /// the certificate depends on wCertificateType.
  ///
  /// byte bCertificate[ANYSIZE_ARRAY];
  ///
}

public unsafe partial class EFI
{
  ///
  /// WIN_CERTIFICATE_UEFI_GUID.CertType
  ///
  public static EFI_GUID EFI_CERT_TYPE_RSA2048_SHA256_GUID => new GUID(0xa7717414, 0xc616, 0x4977, 0x94, 0x20, 0x84, 0x47, 0x12, 0xa7, 0x35, 0xbf);
}

///
/// WIN_CERTIFICATE_UEFI_GUID.CertData
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CERT_BLOCK_RSA_2048_SHA256
{
  public EFI_GUID HashType;
  public fixed byte PublicKey[256];
  public fixed byte Signature[256];
}

///
/// Certificate which encapsulates a GUID-specific digital signature
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct WIN_CERTIFICATE_UEFI_GUID
{
  ///
  /// This is the standard WIN_CERTIFICATE header, where
  /// wCertificateType is set to WIN_CERT_TYPE_EFI_GUID.
  ///
  public WIN_CERTIFICATE Hdr;
  ///
  /// This is the unique id which determines the
  /// format of the CertData. .
  ///
  public EFI_GUID CertType;
  ///
  /// The following is the certificate data. The format of
  /// the data is determined by the CertType.
  /// If CertType is EFI_CERT_TYPE_RSA2048_SHA256_GUID,
  /// the CertData will be EFI_CERT_BLOCK_RSA_2048_SHA256 structure.
  ///
  public fixed byte CertData[1];
}

///
/// Certificate which encapsulates the RSASSA_PKCS1-v1_5 digital signature.
///
/// The WIN_CERTIFICATE_UEFI_PKCS1_15 structure is derived from
/// WIN_CERTIFICATE and encapsulate the information needed to
/// implement the RSASSA-PKCS1-v1_5 digital signature algorithm as
/// specified in RFC2437.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct WIN_CERTIFICATE_EFI_PKCS1_15
{
  ///
  /// This is the standard WIN_CERTIFICATE header, where
  /// wCertificateType is set to WIN_CERT_TYPE_UEFI_PKCS1_15.
  ///
  public WIN_CERTIFICATE Hdr;
  ///
  /// This is the hashing algorithm which was performed on the
  /// UEFI executable when creating the digital signature.
  ///
  public EFI_GUID HashAlgorithm;
  ///
  /// The following is the actual digital signature. The
  /// size of the signature is the same size as the key
  /// (1024-bit key is 128 bytes) and can be determined by
  /// subtracting the length of the other parts of this header
  /// from the total length of the certificate as found in
  /// Hdr.dwLength.
  ///
  /// byte Signature[];
  ///
}

// extern EFI_GUID  gEfiCertTypeRsa2048Sha256Guid;

// #endif
