namespace Uefi;
/** @file
  This file defines the EFI HTTP Boot Callback Protocol interface.

  Copyright (c) 2017 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.7

**/

// #ifndef __EFI_HTTP_BOOT_CALLBACK_H__
// #define __EFI_HTTP_BOOT_CALLBACK_H__

public static EFI_GUID EFI_HTTP_BOOT_CALLBACK_PROTOCOL_GUID = new GUID( 
    0xba23b311, 0x343d, 0x11e6, new byte[] {0x91, 0x85, 0x58, 0x20, 0xb1, 0xd6, 0x52, 0x99});

// typedef struct _EFI_HTTP_BOOT_CALLBACK_PROTOCOL EFI_HTTP_BOOT_CALLBACK_PROTOCOL;

///
/// EFI_HTTP_BOOT_CALLBACK_DATA_TYPE
///
public enum EFI_HTTP_BOOT_CALLBACK_DATA_TYPE {
  ///
  /// Data points to a DHCP4 packet which is about to transmit or has received.
  ///
  HttpBootDhcp4,
  ///
  /// Data points to a DHCP6 packet which is about to be transmit or has received.
  ///
  HttpBootDhcp6,
  ///
  /// Data points to an EFI_HTTP_MESSAGE structure, which contains a HTTP request message
  /// to be transmitted.
  ///
  HttpBootHttpRequest,
  ///
  /// Data points to an EFI_HTTP_MESSAGE structure, which contians a received HTTP
  /// response message.
  ///
  HttpBootHttpResponse,
  ///
  /// Part of the entity body has been received from the HTTP server. Data points to the
  /// buffer of the entity body data.
  ///
  HttpBootHttpEntityBody,
  ///
  /// Data points to the authentication information to provide to the HTTP server.
  ///
  HttpBootHttpAuthInfo,
  HttpBootTypeMax
}
































///
/// EFI HTTP Boot Callback Protocol is invoked when the HTTP Boot driver is about to transmit or
/// has received a packet. The EFI HTTP Boot Callback Protocol must be installed on the same handle
/// as the Load File Protocol for the HTTP Boot.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HTTP_BOOT_CALLBACK_PROTOCOL {
/**
  Callback function that is invoked when the HTTP Boot driver is about to transmit or has received a
  packet.

  This function is invoked when the HTTP Boot driver is about to transmit or has received packet.
  Parameters DataType and Received specify the type of event and the format of the buffer pointed
  to by Data. Due to the polling nature of UEFI device drivers, this callback function should not
  execute for more than 5 ms.
  The returned status code determines the behavior of the HTTP Boot driver.

  @param[in]  This                Pointer to the EFI_HTTP_BOOT_CALLBACK_PROTOCOL instance.
  @param[in]  DataType            The event that occurs in the current state.
  @param[in]  Received            TRUE if the callback is being invoked due to a receive event.
                                  FALSE if the callback is being invoked due to a transmit event.
  @param[in]  DataLength          The length in bytes of the buffer pointed to by Data.
  @param[in]  Data                A pointer to the buffer of data, the data type is specified by
                                  DataType.

  @retval EFI_SUCCESS             Tells the HTTP Boot driver to continue the HTTP Boot process.
  @retval EFI_ABORTED             Tells the HTTP Boot driver to abort the current HTTP Boot process.
**/
public readonly delegate* unmanaged<EFI_HTTP_BOOT_CALLBACK_PROTOCOL*,EFI_HTTP_BOOT_CALLBACK_DATA_TYPE,bool,uint,void*, EFI_STATUS> Callback;
}

// extern EFI_GUID  gEfiHttpBootCallbackProtocolGuid;

// #endif
