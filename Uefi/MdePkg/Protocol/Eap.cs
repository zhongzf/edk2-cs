using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI EAP(Extended Authenticaton Protocol) Protocol Definition
  The EFI EAP Protocol is used to abstract the ability to configure and extend the
  EAP framework.
  The definitions in this file are defined in UEFI Specification 2.3.1B, which have
  not been verified by one implementation yet.

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.2

**/

// #ifndef __EFI_EAP_PROTOCOL_H__
// #define __EFI_EAP_PROTOCOL_H__

public static EFI_GUID EFI_EAP_PROTOCOL_GUID = new GUID(
    0x5d9f96db, 0xe731, 0x4caa, new byte[] { 0xa0, 0xd, 0x72, 0xe1, 0x87, 0xcd, 0x77, 0x62 });

// typedef struct _EFI_EAP_PROTOCOL EFI_EAP_PROTOCOL;

///
/// Type for the identification number assigned to the Port by the
/// System in which the Port resides.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PORT_HANDLE { void* Value; public static implicit operator EFI_PORT_HANDLE(void* value) => new EFI_PORT_HANDLE() { Value = value }; public static implicit operator void*(EFI_PORT_HANDLE value) => value.Value; }

///
/// EAP Authentication Method Type (RFC 3748)
///@{
public const ulong EFI_EAP_TYPE_TLS = 13///< REQUIRED - RFC 5216;
///@}

//
// EAP_TYPE MD5, OTP and TOEKN_CARD has been removed from UEFI2.3.1B.
// Definitions are kept for backward compatibility.
//
public const ulong EFI_EAP_TYPE_MD5 = 4;
public const ulong EFI_EAP_TYPE_OTP = 5;
public const ulong EFI_EAP_TYPE_TOKEN_CARD = 6;































































































///
/// EFI_EAP_PROTOCOL
/// is used to configure the desired EAP authentication method for the EAP
/// framework and extend the EAP framework by registering new EAP authentication
/// method on a Port. The EAP framework is built on a per-Port basis. Herein, a
/// Port means a NIC. For the details of EAP protocol, please refer to RFC 2284.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_EAP_PROTOCOL
{
  /**
    Set the desired EAP authentication method for the Port.

    The SetDesiredAuthMethod() function sets the desired EAP authentication method indicated
    by EapAuthType for the Port.

    If EapAuthType is an invalid EAP authentication type, then EFI_INVALID_PARAMETER is
    returned.
    If the EAP authentication method of EapAuthType is unsupported by the Ports, then it will
    return EFI_UNSUPPORTED.
    The cryptographic strength of EFI_EAP_TYPE_TLS shall be at least of hash strength
    SHA-256 and RSA key length of at least 2048 bits.

    @param[in] This                A pointer to the EFI_EAP_PROTOCOL instance that indicates
                                   the calling context.
    @param[in] EapAuthType         The type of the EAP authentication method to register. It should
                                   be the type value defined by RFC. See RFC 2284 for details.
    @param[in] Handler             The handler of the EAP authentication method to register.

    @retval EFI_SUCCESS            The EAP authentication method of EapAuthType is
                                   registered successfully.
    @retval EFI_INVALID_PARAMETER  EapAuthType is an invalid EAP authentication type.
    @retval EFI_UNSUPPORTED        The EAP authentication method of EapAuthType is
                                   unsupported by the Port.

  **/
  public readonly delegate* unmanaged<EFI_EAP_PROTOCOL*, byte, EFI_STATUS> SetDesiredAuthMethod;
  /**
    Register an EAP authentication method.

    The RegisterAuthMethod() function registers the user provided EAP authentication method,
    the type of which is EapAuthType and the handler of which is Handler.

    If EapAuthType is an invalid EAP authentication type, then EFI_INVALID_PARAMETER is
    returned.
    If there is not enough system memory to perform the registration, then
    EFI_OUT_OF_RESOURCES is returned.

    @param[in] This                A pointer to the EFI_EAP_PROTOCOL instance that indicates
                                   the calling context.
    @param[in] EapAuthType         The type of the EAP authentication method to register. It should
                                   be the type value defined by RFC. See RFC 2284 for details.
    @param[in] Handler             The handler of the EAP authentication method to register.

    @retval EFI_SUCCESS            The EAP authentication method of EapAuthType is
                                   registered successfully.
    @retval EFI_INVALID_PARAMETER  EapAuthType is an invalid EAP authentication type.
    @retval EFI_OUT_OF_RESOURCES   There is not enough system memory to perform the registration.

  **/
  public readonly delegate* unmanaged<EFI_EAP_PROTOCOL*, byte, EFI_EAP_BUILD_RESPONSE_PACKET, EFI_STATUS> RegisterAuthMethod;
}

// extern EFI_GUID  gEfiEapProtocolGuid;

// #endif
