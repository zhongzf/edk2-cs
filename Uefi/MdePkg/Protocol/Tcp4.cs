using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI TCPv4(Transmission Control Protocol version 4) Protocol Definition
  The EFI TCPv4 Service Binding Protocol is used to locate EFI TCPv4 Protocol drivers to create
  and destroy child of the driver to communicate with other host using TCP protocol.
  The EFI TCPv4 Protocol provides services to send and receive data stream.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.0.

**/

// #ifndef __EFI_TCP4_PROTOCOL_H__
// #define __EFI_TCP4_PROTOCOL_H__

// #include <Protocol/Ip4.h>

public static EFI_GUID EFI_TCP4_SERVICE_BINDING_PROTOCOL_GUID = new GUID(
    0x00720665, 0x67EB, 0x4a99, new byte[] { 0xBA, 0xF7, 0xD3, 0xC3, 0x3A, 0x1C, 0x7C, 0xC9 });

public static EFI_GUID EFI_TCP4_PROTOCOL_GUID = new GUID(
    0x65530BC7, 0xA359, 0x410f, new byte[] { 0xB0, 0x10, 0x5A, 0xAD, 0xC7, 0xEC, 0x2B, 0x62 });

// typedef struct _EFI_TCP4_PROTOCOL EFI_TCP4_PROTOCOL;

///
/// EFI_TCP4_SERVICE_POINT is deprecated in the UEFI 2.4B and should not be used any more.
/// The definition in here is only present to provide backwards compatability.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_SERVICE_POINT
{
  public EFI_HANDLE InstanceHandle;
  public EFI_IPv4_ADDRESS LocalAddress;
  public ushort LocalPort;
  public EFI_IPv4_ADDRESS RemoteAddress;
  public ushort RemotePort;
}

///
/// EFI_TCP4_VARIABLE_DATA is deprecated in the UEFI 2.4B and should not be used any more.
/// The definition in here is only present to provide backwards compatability.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_VARIABLE_DATA
{
  public EFI_HANDLE DriverHandle;
  public uint ServiceCount;
  public fixed EFI_TCP4_SERVICE_POINT Services[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_ACCESS_POINT
{
  public bool UseDefaultAddress;
  public EFI_IPv4_ADDRESS StationAddress;
  public EFI_IPv4_ADDRESS SubnetMask;
  public ushort StationPort;
  public EFI_IPv4_ADDRESS RemoteAddress;
  public ushort RemotePort;
  public bool ActiveFlag;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_OPTION
{
  public uint ReceiveBufferSize;
  public uint SendBufferSize;
  public uint MaxSynBackLog;
  public uint ConnectionTimeout;
  public uint DataRetries;
  public uint FinTimeout;
  public uint TimeWaitTimeout;
  public uint KeepAliveProbes;
  public uint KeepAliveTime;
  public uint KeepAliveInterval;
  public bool EnableNagle;
  public bool EnableTimeStamp;
  public bool EnableWindowScaling;
  public bool EnableSelectiveAck;
  public bool EnablePathMtuDiscovery;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_CONFIG_DATA
{
  //
  // I/O parameters
  //
  public byte TypeOfService;
  public byte TimeToLive;

  //
  // Access Point
  //
  public EFI_TCP4_ACCESS_POINT AccessPoint;

  //
  // TCP Control Options
  //
  public EFI_TCP4_OPTION* ControlOption;
}

///
/// TCP4 connnection state
///
public enum EFI_TCP4_CONNECTION_STATE
{
  Tcp4StateClosed = 0,
  Tcp4StateListen = 1,
  Tcp4StateSynSent = 2,
  Tcp4StateSynReceived = 3,
  Tcp4StateEstablished = 4,
  Tcp4StateFinWait1 = 5,
  Tcp4StateFinWait2 = 6,
  Tcp4StateClosing = 7,
  Tcp4StateTimeWait = 8,
  Tcp4StateCloseWait = 9,
  Tcp4StateLastAck = 10
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_COMPLETION_TOKEN
{
  public EFI_EVENT Event;
  public EFI_STATUS Status;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_CONNECTION_TOKEN
{
  ///
  /// The Status in the CompletionToken will be set to one of
  /// the following values if the active open succeeds or an unexpected
  /// error happens:
  /// EFI_SUCCESS:              The active open succeeds and the instance's
  ///                           state is Tcp4StateEstablished.
  /// EFI_CONNECTION_RESET:     The connect fails because the connection is reset
  ///                           either by instance itself or the communication peer.
  /// EFI_CONNECTION_REFUSED:   The connect fails because this connection is initiated with
  ///                           an active open and the connection is refused.
  /// EFI_ABORTED:              The active open is aborted.
  /// EFI_TIMEOUT:              The connection establishment timer expires and
  ///                           no more specific information is available.
  /// EFI_NETWORK_UNREACHABLE:  The active open fails because
  ///                           an ICMP network unreachable error is received.
  /// EFI_HOST_UNREACHABLE:     The active open fails because an
  ///                           ICMP host unreachable error is received.
  /// EFI_PROTOCOL_UNREACHABLE: The active open fails
  ///                           because an ICMP protocol unreachable error is received.
  /// EFI_PORT_UNREACHABLE:     The connection establishment
  ///                           timer times out and an ICMP port unreachable error is received.
  /// EFI_ICMP_ERROR:           The connection establishment timer timeout and some other ICMP
  ///                           error is received.
  /// EFI_DEVICE_ERROR:         An unexpected system or network error occurred.
  /// EFI_NO_MEDIA:             There was a media error.
  ///
  public EFI_TCP4_COMPLETION_TOKEN CompletionToken;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_LISTEN_TOKEN
{
  public EFI_TCP4_COMPLETION_TOKEN CompletionToken;
  public EFI_HANDLE NewChildHandle;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_FRAGMENT_DATA
{
  public uint FragmentLength;
  public void* FragmentBuffer;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_RECEIVE_DATA
{
  public bool UrgentFlag;
  public uint DataLength;
  public uint FragmentCount;
  public fixed EFI_TCP4_FRAGMENT_DATA FragmentTable[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_TRANSMIT_DATA
{
  public bool Push;
  public bool Urgent;
  public uint DataLength;
  public uint FragmentCount;
  public fixed EFI_TCP4_FRAGMENT_DATA FragmentTable[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Packet
{
  ///
  /// When transmission finishes or meets any unexpected error it will
  /// be set to one of the following values:
  /// EFI_SUCCESS:              The receiving or transmission operation
  ///                           completes successfully.
  /// EFI_CONNECTION_FIN:       The receiving operation fails because the communication peer
  ///                           has closed the connection and there is no more data in the
  ///                           receive buffer of the instance.
  /// EFI_CONNECTION_RESET:     The receiving or transmission operation fails
  ///                           because this connection is reset either by instance
  ///                           itself or the communication peer.
  /// EFI_ABORTED:              The receiving or transmission is aborted.
  /// EFI_TIMEOUT:              The transmission timer expires and no more
  ///                           specific information is available.
  /// EFI_NETWORK_UNREACHABLE:  The transmission fails
  ///                           because an ICMP network unreachable error is received.
  /// EFI_HOST_UNREACHABLE:     The transmission fails because an
  ///                           ICMP host unreachable error is received.
  /// EFI_PROTOCOL_UNREACHABLE: The transmission fails
  ///                           because an ICMP protocol unreachable error is received.
  /// EFI_PORT_UNREACHABLE:     The transmission fails and an
  ///                           ICMP port unreachable error is received.
  /// EFI_ICMP_ERROR:           The transmission fails and some other
  ///                           ICMP error is received.
  /// EFI_DEVICE_ERROR:         An unexpected system or network error occurs.
  /// EFI_NO_MEDIA:             There was a media error.
  ///
  public EFI_TCP4_COMPLETION_TOKEN CompletionToken;
  union {
    ///
    /// When this token is used for receiving, RxData is a pointer to EFI_TCP4_RECEIVE_DATA.
    ///
   public EFI_TCP4_RECEIVE_DATA* RxData;
  ///
  /// When this token is used for transmitting, TxData is a pointer to EFI_TCP4_TRANSMIT_DATA.
  ///
  public EFI_TCP4_TRANSMIT_DATA* TxData;
}
} EFI_TCP4_IO_TOKEN;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_CLOSE_TOKEN
{
  public EFI_TCP4_COMPLETION_TOKEN CompletionToken;
  public bool AbortOnClose;
}

//
// Interface definition for TCP4 protocol
//






























































































































































































































































































































///
/// The EFI_TCP4_PROTOCOL defines the EFI TCPv4 Protocol child to be used by
/// any network drivers or applications to send or receive data stream.
/// It can either listen on a specified port as a service or actively connected
/// to remote peer as a client. Each instance has its own independent settings,
/// such as the routing table.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TCP4_PROTOCOL
{
  /**
    Get the current operational status.

    @param  This           The pointer to the EFI_TCP4_PROTOCOL instance.
    @param  Tcp4State      The pointer to the buffer to receive the current TCP state.
    @param  Tcp4ConfigData The pointer to the buffer to receive the current TCP configuration.
    @param  Ip4ModeData    The pointer to the buffer to receive the current IPv4 configuration
                           data used by the TCPv4 instance.
    @param  MnpConfigData  The pointer to the buffer to receive the current MNP configuration
                           data used indirectly by the TCPv4 instance.
    @param  SnpModeData    The pointer to the buffer to receive the current SNP configuration
                           data used indirectly by the TCPv4 instance.

    @retval EFI_SUCCESS           The mode data was read.
    @retval EFI_INVALID_PARAMETER This is NULL.
    @retval EFI_NOT_STARTED       No configuration data is available because this instance hasn't
                                   been started.

  **/
  public readonly delegate* unmanaged<EFI_TCP4_PROTOCOL*, EFI_TCP4_CONNECTION_STATE*, EFI_TCP4_CONFIG_DATA*, EFI_IP4_MODE_DATA*, EFI_MANAGED_NETWORK_CONFIG_DATA*, EFI_SIMPLE_NETWORK_MODE*, EFI_STATUS> GetModeData;
  /**
    Initialize or brutally reset the operational parameters for this EFI TCPv4 instance.

    @param  This           The pointer to the EFI_TCP4_PROTOCOL instance.
    @param  Tcp4ConfigData The pointer to the configure data to configure the instance.

    @retval EFI_SUCCESS           The operational settings are set, changed, or reset
                                  successfully.
    @retval EFI_INVALID_PARAMETER Some parameter is invalid.
    @retval EFI_NO_MAPPING        When using a default address, configuration (through
                                  DHCP, BOOTP, RARP, etc.) is not finished yet.
    @retval EFI_ACCESS_DENIED     Configuring TCP instance when it is configured without
                                  calling Configure() with NULL to reset it.
    @retval EFI_DEVICE_ERROR      An unexpected network or system error occurred.
    @retval EFI_UNSUPPORTED       One or more of the control options are not supported in
                                  the implementation.
    @retval EFI_OUT_OF_RESOURCES  Could not allocate enough system resources when
                                  executing Configure().

  **/
  public readonly delegate* unmanaged<EFI_TCP4_PROTOCOL*, EFI_TCP4_CONFIG_DATA*, EFI_STATUS> Configure;
  /**
    Add or delete a route entry to the route table

    @param  This           The pointer to the EFI_TCP4_PROTOCOL instance.
    @param  DeleteRoute    Set it to TRUE to delete this route from the routing table. Set it to
                           FALSE to add this route to the routing table.
                           DestinationAddress and SubnetMask are used as the
                           keywords to search route entry.
    @param  SubnetAddress  The destination network.
    @param  SubnetMask     The subnet mask of the destination network.
    @param  GatewayAddress The gateway address for this route. It must be on the same
                           subnet with the station address unless a direct route is specified.

    @retval EFI_SUCCESS           The operation completed successfully.
    @retval EFI_NOT_STARTED       The EFI TCPv4 Protocol instance has not been configured.
    @retval EFI_NO_MAPPING        When using a default address, configuration (DHCP, BOOTP,
                                  RARP, etc.) is not finished yet.
    @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                  - This is NULL.
                                  - SubnetAddress is NULL.
                                  - SubnetMask is NULL.
                                  - GatewayAddress is NULL.
                                  - *SubnetAddress is not NULL a valid subnet address.
                                  - *SubnetMask is not a valid subnet mask.
                                  - *GatewayAddress is not a valid unicast IP address or it
                                  is not in the same subnet.
    @retval EFI_OUT_OF_RESOURCES  Could not allocate enough resources to add the entry to the
                                  routing table.
    @retval EFI_NOT_FOUND         This route is not in the routing table.
    @retval EFI_ACCESS_DENIED     The route is already defined in the routing table.
    @retval EFI_UNSUPPORTED       The TCP driver does not support this operation.

  **/
  public readonly delegate* unmanaged<EFI_TCP4_PROTOCOL*, bool, EFI_IPv4_ADDRESS*, EFI_IPv4_ADDRESS*, EFI_IPv4_ADDRESS*, EFI_STATUS> Routes;
  /**
    Initiate a nonblocking TCP connection request for an active TCP instance.

    @param  This                  The pointer to the EFI_TCP4_PROTOCOL instance.
    @param  ConnectionToken       The pointer to the connection token to return when the TCP three
                                  way handshake finishes.

    @retval EFI_SUCCESS           The connection request is successfully initiated and the state
                                  of this TCPv4 instance has been changed to Tcp4StateSynSent.
    @retval EFI_NOT_STARTED       This EFI TCPv4 Protocol instance has not been configured.
    @retval EFI_ACCESS_DENIED     One or more of the following conditions are TRUE:
                                  - This instance is not configured as an active one.
                                  - This instance is not in Tcp4StateClosed state.
    @retval EFI_INVALID_PARAMETER One or more of the following are TRUE:
                                  - This is NULL.
                                  - ConnectionToken is NULL.
                                  - ConnectionToken->CompletionToken.Event is NULL.
    @retval EFI_OUT_OF_RESOURCES  The driver can't allocate enough resource to initiate the activ eopen.
    @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred.

  **/
  public readonly delegate* unmanaged<EFI_TCP4_PROTOCOL*, EFI_TCP4_CONNECTION_TOKEN*, EFI_STATUS> Connect;
  /**
    Listen on the passive instance to accept an incoming connection request. This is a nonblocking operation.

    @param  This        The pointer to the EFI_TCP4_PROTOCOL instance.
    @param  ListenToken The pointer to the listen token to return when operation finishes.

    @retval EFI_SUCCESS           The listen token has been queued successfully.
    @retval EFI_NOT_STARTED       This EFI TCPv4 Protocol instance has not been configured.
    @retval EFI_ACCESS_DENIED     One or more of the following are TRUE:
                                  - This instance is not a passive instance.
                                  - This instance is not in Tcp4StateListen state.
                                  - The same listen token has already existed in the listen
                                  token queue of this TCP instance.
    @retval EFI_INVALID_PARAMETER One or more of the following are TRUE:
                                  - This is NULL.
                                  - ListenToken is NULL.
                                  - ListentToken->CompletionToken.Event is NULL.
    @retval EFI_OUT_OF_RESOURCES  Could not allocate enough resource to finish the operation.
    @retval EFI_DEVICE_ERROR      Any unexpected and not belonged to above category error.

  **/
  public readonly delegate* unmanaged<EFI_TCP4_PROTOCOL*, EFI_TCP4_LISTEN_TOKEN*, EFI_STATUS> Accept;
  /**
    Queues outgoing data into the transmit queue.

    @param  This  The pointer to the EFI_TCP4_PROTOCOL instance.
    @param  Token The pointer to the completion token to queue to the transmit queue.

    @retval EFI_SUCCESS             The data has been queued for transmission.
    @retval EFI_NOT_STARTED         This EFI TCPv4 Protocol instance has not been configured.
    @retval EFI_NO_MAPPING          When using a default address, configuration (DHCP, BOOTP,
                                    RARP, etc.) is not finished yet.
    @retval EFI_INVALID_PARAMETER   One or more of the following are TRUE:
                                    - This is NULL.
                                    - Token is NULL.
                                    - Token->CompletionToken.Event is NULL.
                                    - Token->Packet.TxData is NULL L.
                                    - Token->Packet.FragmentCount is zero.
                                    - Token->Packet.DataLength is not equal to the sum of fragment lengths.
    @retval EFI_ACCESS_DENIED       One or more of the following conditions is TRUE:
                                    - A transmit completion token with the same Token->CompletionToken.Event
                                    was already in the transmission queue.
                                    - The current instance is in Tcp4StateClosed state.
                                    - The current instance is a passive one and it is in
                                    Tcp4StateListen state.
                                    - User has called Close() to disconnect this connection.
    @retval EFI_NOT_READY           The completion token could not be queued because the
                                    transmit queue is full.
    @retval EFI_OUT_OF_RESOURCES    Could not queue the transmit data because of resource
                                    shortage.
    @retval EFI_NETWORK_UNREACHABLE There is no route to the destination network or address.

  **/
  public readonly delegate* unmanaged<EFI_TCP4_PROTOCOL*, EFI_TCP4_IO_TOKEN*, EFI_STATUS> Transmit;
  /**
    Places an asynchronous receive request into the receiving queue.

    @param  This  The pointer to the EFI_TCP4_PROTOCOL instance.
    @param  Token The pointer to a token that is associated with the receive data
                  descriptor.

    @retval EFI_SUCCESS           The receive completion token was cached.
    @retval EFI_NOT_STARTED       This EFI TCPv4 Protocol instance has not been configured.
    @retval EFI_NO_MAPPING        When using a default address, configuration (DHCP, BOOTP, RARP,
                                  etc.) is not finished yet.
    @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                  - This is NULL.
                                  - Token is NULL.
                                  - Token->CompletionToken.Event is NULL.
                                  - Token->Packet.RxData is NULL.
                                  - Token->Packet.RxData->DataLength is 0.
                                  - The Token->Packet.RxData->DataLength is not
                                  the sum of all FragmentBuffer length in FragmentTable.
    @retval EFI_OUT_OF_RESOURCES The receive completion token could not be queued due to a lack of
                                 system resources (usually memory).
    @retval EFI_DEVICE_ERROR     An unexpected system or network error occurred.
    @retval EFI_ACCESS_DENIED    One or more of the following conditions is TRUE:
                                 - A receive completion token with the same Token-
                                 >CompletionToken.Event was already in the receive
                                 queue.
                                 - The current instance is in Tcp4StateClosed state.
                                 - The current instance is a passive one and it is in
                                 Tcp4StateListen state.
                                 - User has called Close() to disconnect this connection.
    @retval EFI_CONNECTION_FIN   The communication peer has closed the connection and there is
                                 no any buffered data in the receive buffer of this instance.
    @retval EFI_NOT_READY        The receive request could not be queued because the receive queue is full.

  **/
  public readonly delegate* unmanaged<EFI_TCP4_PROTOCOL*, EFI_TCP4_IO_TOKEN*, EFI_STATUS> Receive;
  /**
    Disconnecting a TCP connection gracefully or reset a TCP connection. This function is a
    nonblocking operation.

    @param  This       The pointer to the EFI_TCP4_PROTOCOL instance.
    @param  CloseToken The pointer to the close token to return when operation finishes.

    @retval EFI_SUCCESS           The Close() is called successfully.
    @retval EFI_NOT_STARTED       This EFI TCPv4 Protocol instance has not been configured.
    @retval EFI_ACCESS_DENIED     One or more of the following are TRUE:
                                  - Configure() has been called with
                                  TcpConfigData set to NULL and this function has
                                  not returned.
                                  - Previous Close() call on this instance has not
                                  finished.
    @retval EFI_INVALID_PARAMETER One or more of the following are TRUE:
                                  - This is NULL.
                                  - CloseToken is NULL.
                                  - CloseToken->CompletionToken.Event is NULL.
    @retval EFI_OUT_OF_RESOURCES  Could not allocate enough resource to finish the operation.
    @retval EFI_DEVICE_ERROR      Any unexpected and not belonged to above category error.

  **/
  public readonly delegate* unmanaged<EFI_TCP4_PROTOCOL*, EFI_TCP4_CLOSE_TOKEN*, EFI_STATUS> Close;
  /**
    Abort an asynchronous connection, listen, transmission or receive request.

    @param  This  The pointer to the EFI_TCP4_PROTOCOL instance.
    @param  Token The pointer to a token that has been issued by
                  EFI_TCP4_PROTOCOL.Connect(),
                  EFI_TCP4_PROTOCOL.Accept(),
                  EFI_TCP4_PROTOCOL.Transmit() or
                  EFI_TCP4_PROTOCOL.Receive(). If NULL, all pending
                  tokens issued by above four functions will be aborted. Type
                  EFI_TCP4_COMPLETION_TOKEN is defined in
                  EFI_TCP4_PROTOCOL.Connect().

    @retval  EFI_SUCCESS             The asynchronous I/O request is aborted and Token->Event
                                     is signaled.
    @retval  EFI_INVALID_PARAMETER   This is NULL.
    @retval  EFI_NOT_STARTED         This instance hasn't been configured.
    @retval  EFI_NO_MAPPING          When using the default address, configuration
                                     (DHCP, BOOTP,RARP, etc.) hasn't finished yet.
    @retval  EFI_NOT_FOUND           The asynchronous I/O request isn't found in the
                                     transmission or receive queue. It has either
                                     completed or wasn't issued by Transmit() and Receive().
    @retval  EFI_UNSUPPORTED         The implementation does not support this function.

  **/
  public readonly delegate* unmanaged<EFI_TCP4_PROTOCOL*, EFI_TCP4_COMPLETION_TOKEN*, EFI_STATUS> Cancel;
  /**
    Poll to receive incoming data and transmit outgoing segments.

    @param  This The pointer to the EFI_TCP4_PROTOCOL instance.

    @retval  EFI_SUCCESS           Incoming or outgoing data was processed.
    @retval  EFI_INVALID_PARAMETER This is NULL.
    @retval  EFI_DEVICE_ERROR      An unexpected system or network error occurred.
    @retval  EFI_NOT_READY         No incoming or outgoing data is processed.
    @retval  EFI_TIMEOUT           Data was dropped out of the transmission or receive queue.
                                   Consider increasing the polling rate.

  **/
  public readonly delegate* unmanaged<EFI_TCP4_PROTOCOL*, EFI_STATUS> Poll;
}

// extern EFI_GUID  gEfiTcp4ServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiTcp4ProtocolGuid;

// #endif
