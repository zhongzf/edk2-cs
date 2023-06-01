using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI_MANAGED_NETWORK_SERVICE_BINDING_PROTOCOL as defined in UEFI 2.0.
  EFI_MANAGED_NETWORK_PROTOCOL as defined in UEFI 2.0.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.0

**/

// #ifndef __EFI_MANAGED_NETWORK_PROTOCOL_H__
// #define __EFI_MANAGED_NETWORK_PROTOCOL_H__

// #include <Protocol/SimpleNetwork.h>

public static EFI_GUID EFI_MANAGED_NETWORK_SERVICE_BINDING_PROTOCOL_GUID = new GUID(
    0xf36ff770, 0xa7e1, 0x42cf, new byte[] { 0x9e, 0xd2, 0x56, 0xf0, 0xf2, 0x71, 0xf4, 0x4c });

public static EFI_GUID EFI_MANAGED_NETWORK_PROTOCOL_GUID = new GUID(
    0x7ab33a91, 0xace5, 0x4326, new byte[] { 0xb5, 0x72, 0xe7, 0xee, 0x33, 0xd3, 0x9f, 0x16 });

// typedef struct _EFI_MANAGED_NETWORK_PROTOCOL EFI_MANAGED_NETWORK_PROTOCOL;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MANAGED_NETWORK_CONFIG_DATA
{
  ///
  /// Timeout value for a UEFI one-shot timer event. A packet that has not been removed
  /// from the MNP receive queue will be dropped if its receive timeout expires.
  ///
  public uint ReceivedQueueTimeoutValue;
  ///
  /// Timeout value for a UEFI one-shot timer event. A packet that has not been removed
  /// from the MNP transmit queue will be dropped if its receive timeout expires.
  ///
  public uint TransmitQueueTimeoutValue;
  ///
  /// Ethernet type II 16-bit protocol type in host byte order. Valid
  /// values are zero and 1,500 to 65,535.
  ///
  public ushort ProtocolTypeFilter;
  ///
  /// Set to TRUE to receive packets that are sent to the network
  /// device MAC address. The startup default value is FALSE.
  ///
  public bool EnableUnicastReceive;
  ///
  /// Set to TRUE to receive packets that are sent to any of the
  /// active multicast groups. The startup default value is FALSE.
  ///
  public bool EnableMulticastReceive;
  ///
  /// Set to TRUE to receive packets that are sent to the network
  /// device broadcast address. The startup default value is FALSE.
  ///
  public bool EnableBroadcastReceive;
  ///
  /// Set to TRUE to receive packets that are sent to any MAC address.
  /// The startup default value is FALSE.
  ///
  public bool EnablePromiscuousReceive;
  ///
  /// Set to TRUE to drop queued packets when the configuration
  /// is changed. The startup default value is FALSE.
  ///
  public bool FlushQueuesOnReset;
  ///
  /// Set to TRUE to timestamp all packets when they are received
  /// by the MNP. Note that timestamps may be unsupported in some
  /// MNP implementations. The startup default value is FALSE.
  ///
  public bool EnableReceiveTimestamps;
  ///
  /// Set to TRUE to disable background polling in this MNP
  /// instance. Note that background polling may not be supported in
  /// all MNP implementations. The startup default value is FALSE,
  /// unless background polling is not supported.
  ///
  public bool DisableBackgroundPolling;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MANAGED_NETWORK_RECEIVE_DATA
{
  public EFI_TIME Timestamp;
  public EFI_EVENT RecycleEvent;
  public uint PacketLength;
  public uint HeaderLength;
  public uint AddressLength;
  public uint DataLength;
  public bool BroadcastFlag;
  public bool MulticastFlag;
  public bool PromiscuousFlag;
  public ushort ProtocolType;
  public void* DestinationAddress;
  public void* SourceAddress;
  public void* MediaHeader;
  public void* PacketData;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MANAGED_NETWORK_FRAGMENT_DATA
{
  public uint FragmentLength;
  public void* FragmentBuffer;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MANAGED_NETWORK_TRANSMIT_DATA
{
  public EFI_MAC_ADDRESS* DestinationAddress; // OPTIONAL
  public EFI_MAC_ADDRESS* SourceAddress;      // OPTIONAL
  public ushort ProtocolType;        // OPTIONAL
  public uint DataLength;
  public ushort HeaderLength;     // OPTIONAL
  public ushort FragmentCount;
  public fixed EFI_MANAGED_NETWORK_FRAGMENT_DATA FragmentTable[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Packet
{
  ///
  /// This Event will be signaled after the Status field is updated
  /// by the MNP. The type of Event must be
  /// EFI_NOTIFY_SIGNAL. The Task Priority Level (TPL) of
  /// Event must be lower than or equal to TPL_CALLBACK.
  ///
  public EFI_EVENT Event;
  ///
  /// The status that is returned to the caller at the end of the operation
  /// to indicate whether this operation completed successfully.
  ///
  public EFI_STATUS Status;
  union {
    ///
    /// When this token is used for receiving, RxData is a pointer to the EFI_MANAGED_NETWORK_RECEIVE_DATA.
    ///
   public EFI_MANAGED_NETWORK_RECEIVE_DATA* RxData;
  ///
  /// When this token is used for transmitting, TxData is a pointer to the EFI_MANAGED_NETWORK_TRANSMIT_DATA.
  ///
  public EFI_MANAGED_NETWORK_TRANSMIT_DATA* TxData;
}
} EFI_MANAGED_NETWORK_COMPLETION_TOKEN;












































































































































































































///
/// The MNP is used by network applications (and drivers) to
/// perform raw (unformatted) asynchronous network packet I/O.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MANAGED_NETWORK_PROTOCOL
{
  /**
    Returns the operational parameters for the current MNP child driver.

    @param  This          The pointer to the EFI_MANAGED_NETWORK_PROTOCOL instance.
    @param  MnpConfigData The pointer to storage for MNP operational parameters.
    @param  SnpModeData   The pointer to storage for SNP operational parameters.

    @retval EFI_SUCCESS           The operation completed successfully.
    @retval EFI_INVALID_PARAMETER This is NULL.
    @retval EFI_UNSUPPORTED       The requested feature is unsupported in this MNP implementation.
    @retval EFI_NOT_STARTED       This MNP child driver instance has not been configured. The default
                                  values are returned in MnpConfigData if it is not NULL.
    @retval Other                 The mode data could not be read.

  **/
  public readonly delegate* unmanaged<EFI_MANAGED_NETWORK_PROTOCOL*, EFI_MANAGED_NETWORK_CONFIG_DATA*, EFI_SIMPLE_NETWORK_MODE*, EFI_STATUS> GetModeData;
  /**
    Sets or clears the operational parameters for the MNP child driver.

    @param  This          The pointer to the EFI_MANAGED_NETWORK_PROTOCOL instance.
    @param  MnpConfigData The pointer to configuration data that will be assigned to the MNP
                          child driver instance. If NULL, the MNP child driver instance is
                          reset to startup defaults and all pending transmit and receive
                          requests are flushed.

    @retval EFI_SUCCESS           The operation completed successfully.
    @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
    @retval EFI_OUT_OF_RESOURCES  Required system resources (usually memory) could not be
                                  allocated.
    @retval EFI_UNSUPPORTED       The requested feature is unsupported in this [MNP]
                                  implementation.
    @retval EFI_DEVICE_ERROR      An unexpected network or system error occurred.
    @retval Other                 The MNP child driver instance has been reset to startup defaults.

  **/
  public readonly delegate* unmanaged<EFI_MANAGED_NETWORK_PROTOCOL*, EFI_MANAGED_NETWORK_CONFIG_DATA*, EFI_STATUS> Configure;
  /**
    Translates an IP multicast address to a hardware (MAC) multicast address.

    @param  This       The pointer to the EFI_MANAGED_NETWORK_PROTOCOL instance.
    @param  Ipv6Flag   Set to TRUE to if IpAddress is an IPv6 multicast address.
                       Set to FALSE if IpAddress is an IPv4 multicast address.
    @param  IpAddress  The pointer to the multicast IP address (in network byte order) to convert.
    @param  MacAddress The pointer to the resulting multicast MAC address.

    @retval EFI_SUCCESS           The operation completed successfully.
    @retval EFI_INVALID_PARAMETER One of the following conditions is TRUE:
                                  - This is NULL.
                                  - IpAddress is NULL.
                                  - *IpAddress is not a valid multicast IP address.
                                  - MacAddress is NULL.
    @retval EFI_NOT_STARTED       This MNP child driver instance has not been configured.
    @retval EFI_UNSUPPORTED       The requested feature is unsupported in this MNP implementation.
    @retval EFI_DEVICE_ERROR      An unexpected network or system error occurred.
    @retval Other                 The address could not be converted.

  **/
  public readonly delegate* unmanaged<EFI_MANAGED_NETWORK_PROTOCOL*, bool, EFI_IP_ADDRESS*, EFI_MAC_ADDRESS*, EFI_STATUS> McastIpToMac;
  /**
    Enables and disables receive filters for multicast address.

    @param  This       The pointer to the EFI_MANAGED_NETWORK_PROTOCOL instance.
    @param  JoinFlag   Set to TRUE to join this multicast group.
                       Set to FALSE to leave this multicast group.
    @param  MacAddress The pointer to the multicast MAC group (address) to join or leave.

    @retval EFI_SUCCESS           The requested operation completed successfully.
    @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                  - This is NULL.
                                  - JoinFlag is TRUE and MacAddress is NULL.
                                  - *MacAddress is not a valid multicast MAC address.
    @retval EFI_NOT_STARTED       This MNP child driver instance has not been configured.
    @retval EFI_ALREADY_STARTED   The supplied multicast group is already joined.
    @retval EFI_NOT_FOUND         The supplied multicast group is not joined.
    @retval EFI_DEVICE_ERROR      An unexpected network or system error occurred.
    @retval EFI_UNSUPPORTED       The requested feature is unsupported in this MNP implementation.
    @retval Other                 The requested operation could not be completed.

  **/
  public readonly delegate* unmanaged<EFI_MANAGED_NETWORK_PROTOCOL*, bool, EFI_MAC_ADDRESS*, EFI_STATUS> Groups;
  /**
    Places asynchronous outgoing data packets into the transmit queue.

    @param  This  The pointer to the EFI_MANAGED_NETWORK_PROTOCOL instance.
    @param  Token The pointer to a token associated with the transmit data descriptor.

    @retval EFI_SUCCESS           The transmit completion token was cached.
    @retval EFI_NOT_STARTED       This MNP child driver instance has not been configured.
    @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
    @retval EFI_ACCESS_DENIED     The transmit completion token is already in the transmit queue.
    @retval EFI_OUT_OF_RESOURCES  The transmit data could not be queued due to a lack of system resources
                                  (usually memory).
    @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred.
    @retval EFI_NOT_READY         The transmit request could not be queued because the transmit queue is full.

  **/
  public readonly delegate* unmanaged<EFI_MANAGED_NETWORK_PROTOCOL*, EFI_MANAGED_NETWORK_COMPLETION_TOKEN*, EFI_STATUS> Transmit;
  /**
    Places an asynchronous receiving request into the receiving queue.

    @param  This  The pointer to the EFI_MANAGED_NETWORK_PROTOCOL instance.
    @param  Token The pointer to a token associated with the receive data descriptor.

    @retval EFI_SUCCESS           The receive completion token was cached.
    @retval EFI_NOT_STARTED       This MNP child driver instance has not been configured.
    @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                  - This is NULL.
                                  - Token is NULL.
                                  - Token.Event is NULL.
    @retval EFI_OUT_OF_RESOURCES  The transmit data could not be queued due to a lack of system resources
                                  (usually memory).
    @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred.
    @retval EFI_ACCESS_DENIED     The receive completion token was already in the receive queue.
    @retval EFI_NOT_READY         The receive request could not be queued because the receive queue is full.

  **/
  public readonly delegate* unmanaged<EFI_MANAGED_NETWORK_PROTOCOL*, EFI_MANAGED_NETWORK_COMPLETION_TOKEN*, EFI_STATUS> Receive;
  /**
    Aborts an asynchronous transmit or receive request.

    @param  This  The pointer to the EFI_MANAGED_NETWORK_PROTOCOL instance.
    @param  Token The pointer to a token that has been issued by
                  EFI_MANAGED_NETWORK_PROTOCOL.Transmit() or
                  EFI_MANAGED_NETWORK_PROTOCOL.Receive(). If
                  NULL, all pending tokens are aborted.

    @retval  EFI_SUCCESS           The asynchronous I/O request was aborted and Token.Event
                                   was signaled. When Token is NULL, all pending requests were
                                   aborted and their events were signaled.
    @retval  EFI_NOT_STARTED       This MNP child driver instance has not been configured.
    @retval  EFI_INVALID_PARAMETER This is NULL.
    @retval  EFI_NOT_FOUND         When Token is not NULL, the asynchronous I/O request was
                                   not found in the transmit or receive queue. It has either completed
                                   or was not issued by Transmit() and Receive().

  **/
  public readonly delegate* unmanaged<EFI_MANAGED_NETWORK_PROTOCOL*, EFI_MANAGED_NETWORK_COMPLETION_TOKEN*, EFI_STATUS> Cancel;
  /**
    Polls for incoming data packets and processes outgoing data packets.

    @param  This The pointer to the EFI_MANAGED_NETWORK_PROTOCOL instance.

    @retval EFI_SUCCESS      Incoming or outgoing data was processed.
    @retval EFI_NOT_STARTED  This MNP child driver instance has not been configured.
    @retval EFI_DEVICE_ERROR An unexpected system or network error occurred.
    @retval EFI_NOT_READY    No incoming or outgoing data was processed. Consider increasing
                             the polling rate.
    @retval EFI_TIMEOUT      Data was dropped out of the transmit and/or receive queue.
                              Consider increasing the polling rate.

  **/
  public readonly delegate* unmanaged<EFI_MANAGED_NETWORK_PROTOCOL*, EFI_STATUS> Poll;
}

// extern EFI_GUID  gEfiManagedNetworkServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiManagedNetworkProtocolGuid;

// #endif
