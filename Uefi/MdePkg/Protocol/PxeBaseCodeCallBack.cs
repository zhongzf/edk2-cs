namespace Uefi;
/** @file
  It is invoked when the PXE Base Code Protocol is about to transmit, has received,
  or is waiting to receive a packet.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in EFI Specification 1.10

**/

// #ifndef _PXE_BASE_CODE_CALLBACK_H_
// #define _PXE_BASE_CODE_CALLBACK_H_

///
/// Call Back Definitions.
///
public static EFI_GUID EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL_GUID = new GUID(
    0x245dca21, 0xfb7b, 0x11d3, new byte[] { 0x8f, 0x01, 0x00, 0xa0, 0xc9, 0x69, 0x72, 0x3b });

///
/// UEFI Revision Number Definition.
///
public static ulong EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL_REVISION = 0x00010000;

///
/// EFI 1.1 Revision Number defintion.
///
#define EFI_PXE_BASE_CODE_CALLBACK_INTERFACE_REVISION  \
EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL_REVISION

///
/// UEFI Protocol name.
///
// typedef struct _EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL;

///
/// EFI1.1 Protocol name.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PXE_BASE_CODE_CALLBACK { EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL Value; public static implicit operator EFI_PXE_BASE_CODE_CALLBACK(EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL value) => new EFI_PXE_BASE_CODE_CALLBACK() { Value = value }; public static implicit operator EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL(EFI_PXE_BASE_CODE_CALLBACK value) => value.Value; }

///
/// Event type list for PXE Base Code Protocol function.
///
public enum EFI_PXE_BASE_CODE_FUNCTION
{
  EFI_PXE_BASE_CODE_FUNCTION_FIRST,
  EFI_PXE_BASE_CODE_FUNCTION_DHCP,
  EFI_PXE_BASE_CODE_FUNCTION_DISCOVER,
  EFI_PXE_BASE_CODE_FUNCTION_MTFTP,
  EFI_PXE_BASE_CODE_FUNCTION_UDP_WRITE,
  EFI_PXE_BASE_CODE_FUNCTION_UDP_READ,
  EFI_PXE_BASE_CODE_FUNCTION_ARP,
  EFI_PXE_BASE_CODE_FUNCTION_IGMP,
  EFI_PXE_BASE_CODE_PXE_FUNCTION_LAST
}

///
/// Callback status type.
///
public enum EFI_PXE_BASE_CODE_CALLBACK_STATUS
{
  EFI_PXE_BASE_CODE_CALLBACK_STATUS_FIRST,
  EFI_PXE_BASE_CODE_CALLBACK_STATUS_CONTINUE,
  EFI_PXE_BASE_CODE_CALLBACK_STATUS_ABORT,
  EFI_PXE_BASE_CODE_CALLBACK_STATUS_LAST
}






































///
/// Protocol that is invoked when the PXE Base Code Protocol is about
/// to transmit, has received, or is waiting to receive a packet.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL
{
  ///
  ///  The revision of the EFI_PXE_BASE_CODE_PROTOCOL. All future revisions must
  ///  be backwards compatible. If a future version is not backwards compatible
  ///  it is not the same GUID.
  ///
  public ulong Revision;
  /**
    Callback function that is invoked when the PXE Base Code Protocol is about to transmit, has
    received, or is waiting to receive a packet.

    This function is invoked when the PXE Base Code Protocol is about to transmit, has received,
    or is waiting to receive a packet. Parameters Function and Received specify the type of event.
    Parameters PacketLen and Packet specify the packet that generated the event. If these fields
    are zero and NULL respectively, then this is a status update callback. If the operation specified
    by Function is to continue, then CALLBACK_STATUS_CONTINUE should be returned. If the operation
    specified by Function should be aborted, then CALLBACK_STATUS_ABORT should be returned. Due to
    the polling nature of UEFI device drivers, a callback function should not execute for more than 5 ms.
    The SetParameters() function must be called after a Callback Protocol is installed to enable the
    use of callbacks.

    @param  This                  The pointer to the EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL instance.
    @param  Function              The PXE Base Code Protocol function that is waiting for an event.
    @param  Received              TRUE if the callback is being invoked due to a receive event. FALSE if
                                  the callback is being invoked due to a transmit event.
    @param  PacketLen             The length, in bytes, of Packet. This field will have a value of zero if
                                  this is a wait for receive event.
    @param  Packet                If Received is TRUE, a pointer to the packet that was just received;
                                  otherwise a pointer to the packet that is about to be transmitted.

    @retval EFI_PXE_BASE_CODE_CALLBACK_STATUS_CONTINUE if Function specifies a continue operation
    @retval EFI_PXE_BASE_CODE_CALLBACK_STATUS_ABORT    if Function specifies an abort operation

  **/
  public readonly delegate* unmanaged<EFI_PXE_BASE_CODE_CALLBACK_PROTOCOL*, EFI_PXE_BASE_CODE_FUNCTION, bool, uint, EFI_PXE_BASE_CODE_PACKET*, EFI_STATUS> Callback;
}

// extern EFI_GUID  gEfiPxeBaseCodeCallbackProtocolGuid;

// #endif
