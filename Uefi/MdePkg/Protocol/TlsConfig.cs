using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI TLS Configuration Protocol as defined in UEFI 2.5.
  The EFI TLS Configuration Protocol provides a way to set and get TLS configuration.

  Copyright (c) 2016, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.5

**/

// #ifndef __EFI_TLS_CONFIGURATION_PROTOCOL_H__
// #define __EFI_TLS_CONFIGURATION_PROTOCOL_H__

public unsafe partial class EFI
{
  ///
  /// The EFI Configuration protocol provides a way to set and get TLS configuration.
  ///
  public static EFI_GUID EFI_TLS_CONFIGURATION_PROTOCOL_GUID = new GUID(
      0x1682fe44, 0xbd7a, 0x4407, new byte[] { 0xb7, 0xc7, 0xdc, 0xa3, 0x7c, 0xa3, 0x92, 0x2d });

  // typedef struct _EFI_TLS_CONFIGURATION_PROTOCOL EFI_TLS_CONFIGURATION_PROTOCOL;
}

///
/// EFI_TLS_CONFIG_DATA_TYPE
///
public enum EFI_TLS_CONFIG_DATA_TYPE
{
  ///
  /// Local host configuration data: public certificate data.
  /// This data should be DER-encoded binary X.509 certificate
  /// or PEM-encoded X.509 certificate.
  ///
  EfiTlsConfigDataTypeHostPublicCert,
  ///
  /// Local host configuration data: private key data.
  ///
  EfiTlsConfigDataTypeHostPrivateKey,
  ///
  /// CA certificate to verify peer. This data should be PEM-encoded
  /// RSA or PKCS#8 private key.
  ///
  EfiTlsConfigDataTypeCACertificate,
  ///
  /// CA-supplied Certificate Revocation List data. This data should
  /// be DER-encoded CRL data.
  ///
  EfiTlsConfigDataTypeCertRevocationList,

  EfiTlsConfigDataTypeMaximum
}

///
/// The EFI_TLS_CONFIGURATION_PROTOCOL is designed to provide a way to set and get
/// TLS configuration, such as Certificate, private key data.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_CONFIGURATION_PROTOCOL
{
  /**
    Set TLS configuration data.

    The SetData() function sets TLS configuration to non-volatile storage or volatile
    storage.

    @param[in]  This                Pointer to the EFI_TLS_CONFIGURATION_PROTOCOL instance.
    @param[in]  DataType            Configuration data type.
    @param[in]  Data                Pointer to configuration data.
    @param[in]  DataSize            Total size of configuration data.

    @retval EFI_SUCCESS             The TLS configuration data is set successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    Data is NULL.
                                    DataSize is 0.
    @retval EFI_UNSUPPORTED         The DataType is unsupported.
    @retval EFI_OUT_OF_RESOURCES    Required system resources could not be allocated.

  **/
  public readonly delegate* unmanaged<EFI_TLS_CONFIGURATION_PROTOCOL*, EFI_TLS_CONFIG_DATA_TYPE, void*, ulong, EFI_STATUS> SetData;
  /**
    Get TLS configuration data.

    The GetData() function gets TLS configuration.

    @param[in]       This           Pointer to the EFI_TLS_CONFIGURATION_PROTOCOL instance.
    @param[in]       DataType       Configuration data type.
    @param[in, out]  Data           Pointer to configuration data.
    @param[in, out]  DataSize       Total size of configuration data. On input, it means
                                    the size of Data buffer. On output, it means the size
                                    of copied Data buffer if EFI_SUCCESS, and means the
                                    size of desired Data buffer if EFI_BUFFER_TOO_SMALL.

    @retval EFI_SUCCESS             The TLS configuration data is got successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    DataSize is NULL.
                                    Data is NULL if *DataSize is not zero.
    @retval EFI_UNSUPPORTED         The DataType is unsupported.
    @retval EFI_NOT_FOUND           The TLS configuration data is not found.
    @retval EFI_BUFFER_TOO_SMALL    The buffer is too small to hold the data.

  **/
  public readonly delegate* unmanaged<EFI_TLS_CONFIGURATION_PROTOCOL*, EFI_TLS_CONFIG_DATA_TYPE, void*, ulong*, EFI_STATUS> GetData;
}

// extern EFI_GUID  gEfiTlsConfigurationProtocolGuid;

// #endif //__EFI_TLS_CONFIGURATION_PROTOCOL_H__
