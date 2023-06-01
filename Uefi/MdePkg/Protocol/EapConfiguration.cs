namespace Uefi;
/** @file
  This file defines the EFI EAP Configuration protocol.

  Copyright (c) 2015 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.5

**/

// #ifndef __EFI_EAP_CONFIGURATION_PROTOCOL_H__
// #define __EFI_EAP_CONFIGURATION_PROTOCOL_H__

///
/// EFI EAP Configuration protocol provides a way to set and get EAP configuration.
///
public static EFI_GUID EFI_EAP_CONFIGURATION_PROTOCOL_GUID = new GUID(
    0xe5b58dbb, 0x7688, 0x44b4, new byte[] { 0x97, 0xbf, 0x5f, 0x1d, 0x4b, 0x7c, 0xc8, 0xdb });

// typedef struct _EFI_EAP_CONFIGURATION_PROTOCOL EFI_EAP_CONFIGURATION_PROTOCOL;

///
/// Make sure it not conflict with any real EapTypeXXX
///
public const ulong EFI_EAP_TYPE_ATTRIBUTE = 0;

public enum EFI_EAP_CONFIG_DATA_TYPE
{
  ///
  /// EFI_EAP_TYPE_ATTRIBUTE
  ///
  EfiEapConfigEapAuthMethod,
  EfiEapConfigEapSupportedAuthMethod,
  ///
  /// EapTypeIdentity
  ///
  EfiEapConfigIdentityString,
  ///
  /// EapTypeEAPTLS/EapTypePEAP
  ///
  EfiEapConfigEapTlsCACert,
  EfiEapConfigEapTlsClientCert,
  EfiEapConfigEapTlsClientPrivateKeyFile,
  EfiEapConfigEapTlsClientPrivateKeyFilePassword, // ASCII format, Volatile
  EfiEapConfigEapTlsCipherSuite,
  EfiEapConfigEapTlsSupportedCipherSuite,
  ///
  /// EapTypeMSChapV2
  ///
  EfiEapConfigEapMSChapV2Password, // UNICODE format, Volatile
  ///
  /// EapTypePEAP
  ///
  EfiEapConfigEap2ndAuthMethod,
  ///
  /// More...
  ///
}

///
/// EFI_EAP_TYPE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_EAP_TYPE { byte Value; public static implicit operator EFI_EAP_TYPE(byte value) => new EFI_EAP_TYPE() { Value = value }; public static implicit operator byte(EFI_EAP_TYPE value) => value.Value; }
public const ulong EFI_EAP_TYPE_ATTRIBUTE = 0;
public const ulong EFI_EAP_TYPE_IDENTITY = 1;
public const ulong EFI_EAP_TYPE_NOTIFICATION = 2;
public const ulong EFI_EAP_TYPE_NAK = 3;
public const ulong EFI_EAP_TYPE_MD5CHALLENGE = 4;
public const ulong EFI_EAP_TYPE_OTP = 5;
public const ulong EFI_EAP_TYPE_GTC = 6;
public const ulong EFI_EAP_TYPE_EAPTLS = 13;
public const ulong EFI_EAP_TYPE_EAPSIM = 18;
public const ulong EFI_EAP_TYPE_TTLS = 21;
public const ulong EFI_EAP_TYPE_PEAP = 25;
public const ulong EFI_EAP_TYPE_MSCHAPV2 = 26;
public const ulong EFI_EAP_TYPE_EAP_EXTENSION = 33;






























































///
/// The EFI_EAP_CONFIGURATION_PROTOCOL
/// is designed to provide a way to set and get EAP configuration, such as Certificate,
/// private key file.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_EAP_CONFIGURATION_PROTOCOL
{
  /**
    Set EAP configuration data.

    The SetData() function sets EAP configuration to non-volatile storage or volatile
    storage.

    @param[in]  This                Pointer to the EFI_EAP_CONFIGURATION_PROTOCOL instance.
    @param[in]  EapType             EAP type.
    @param[in]  DataType            Configuration data type.
    @param[in]  Data                Pointer to configuration data.
    @param[in]  DataSize            Total size of configuration data.

    @retval EFI_SUCCESS             The EAP configuration data is set successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    Data is NULL.
                                    DataSize is 0.
    @retval EFI_UNSUPPORTED         The EapType or DataType is unsupported.
    @retval EFI_OUT_OF_RESOURCES    Required system resources could not be allocated.
  **/
  public readonly delegate* unmanaged<EFI_EAP_CONFIGURATION_PROTOCOL*, EFI_EAP_TYPE, EFI_EAP_CONFIG_DATA_TYPE, void*, ulong, EFI_STATUS> SetData;
  /**
    Get EAP configuration data.

    The GetData() function gets EAP configuration.

    @param[in]       This           Pointer to the EFI_EAP_CONFIGURATION_PROTOCOL instance.
    @param[in]       EapType        EAP type.
    @param[in]       DataType       Configuration data type.
    @param[in, out]  Data           Pointer to configuration data.
    @param[in, out]  DataSize       Total size of configuration data. On input, it means
                                    the size of Data buffer. On output, it means the size
                                    of copied Data buffer if EFI_SUCCESS, and means the
                                    size of desired Data buffer if EFI_BUFFER_TOO_SMALL.

    @retval EFI_SUCCESS             The EAP configuration data is got successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    Data is NULL.
                                    DataSize is NULL.
    @retval EFI_UNSUPPORTED         The EapType or DataType is unsupported.
    @retval EFI_NOT_FOUND           The EAP configuration data is not found.
    @retval EFI_BUFFER_TOO_SMALL    The buffer is too small to hold the buffer.
  **/
  public readonly delegate* unmanaged<EFI_EAP_CONFIGURATION_PROTOCOL*, EFI_EAP_TYPE, EFI_EAP_CONFIG_DATA_TYPE, void*, ulong*, EFI_STATUS> GetData;
}

// extern EFI_GUID  gEfiEapConfigurationProtocolGuid;

// #endif
