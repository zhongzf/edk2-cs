namespace Uefi;
/** @file
  This file defines the EFI IPv4 (Internet Protocol version 4)
  Protocol interface. It is split into the following three main
  sections:
  - EFI IPv4 Service Binding Protocol
  - EFI IPv4 Variable (deprecated in UEFI 2.4B)
  - EFI IPv4 Protocol.
  The EFI IPv4 Protocol provides basic network IPv4 packet I/O services,
  which includes support foR a subset of the Internet Control Message
  Protocol (ICMP) and may include support for the Internet Group Management
  Protocol (IGMP).

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.0.

**/

// #ifndef __EFI_IP4_PROTOCOL_H__
// #define __EFI_IP4_PROTOCOL_H__

// #include <Protocol/ManagedNetwork.h>

public static EFI_GUID EFI_IP4_SERVICE_BINDING_PROTOCOL_GUID = new GUID(
    0xc51711e7, 0xb4bf, 0x404a, new byte[] { 0xbf, 0xb8, 0x0a, 0x04, 0x8e, 0xf1, 0xff, 0xe4 });

public static EFI_GUID EFI_IP4_PROTOCOL_GUID = new GUID(
    0x41d94cd2, 0x35b6, 0x455a, new byte[] { 0x82, 0x58, 0xd4, 0xe5, 0x13, 0x34, 0xaa, 0xdd });

// typedef struct _EFI_IP4_PROTOCOL EFI_IP4_PROTOCOL;

///
/// EFI_IP4_ADDRESS_PAIR is deprecated in the UEFI 2.4B and should not be used any more.
/// The definition in here is only present to provide backwards compatability.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_ADDRESS_PAIR
{
  public EFI_HANDLE InstanceHandle;
  public EFI_IPv4_ADDRESS Ip4Address;
  public EFI_IPv4_ADDRESS SubnetMask;
}

///
/// EFI_IP4_VARIABLE_DATA is deprecated in the UEFI 2.4B and should not be used any more.
/// The definition in here is only present to provide backwards compatability.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_VARIABLE_DATA
{
  public EFI_HANDLE DriverHandle;
  public uint AddressCount;
  public fixed EFI_IP4_ADDRESS_PAIR AddressPairs[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_CONFIG_DATA
{
  ///
  /// The default IPv4 protocol packets to send and receive. Ignored
  /// when AcceptPromiscuous is TRUE.
  ///
  public byte DefaultProtocol;
  ///
  /// Set to TRUE to receive all IPv4 packets that get through the receive filters.
  /// Set to FALSE to receive only the DefaultProtocol IPv4
  /// packets that get through the receive filters.
  ///
  public bool AcceptAnyProtocol;
  ///
  /// Set to TRUE to receive ICMP error report packets. Ignored when
  /// AcceptPromiscuous or AcceptAnyProtocol is TRUE.
  ///
  public bool AcceptIcmpErrors;
  ///
  /// Set to TRUE to receive broadcast IPv4 packets. Ignored when
  /// AcceptPromiscuous is TRUE.
  /// Set to FALSE to stop receiving broadcast IPv4 packets.
  ///
  public bool AcceptBroadcast;
  ///
  /// Set to TRUE to receive all IPv4 packets that are sent to any
  /// hardware address or any protocol address.
  /// Set to FALSE to stop receiving all promiscuous IPv4 packets
  ///
  public bool AcceptPromiscuous;
  ///
  /// Set to TRUE to use the default IPv4 address and default routing table.
  ///
  public bool UseDefaultAddress;
  ///
  /// The station IPv4 address that will be assigned to this EFI IPv4Protocol instance.
  ///
  public EFI_IPv4_ADDRESS StationAddress;
  ///
  /// The subnet address mask that is associated with the station address.
  ///
  public EFI_IPv4_ADDRESS SubnetMask;
  ///
  /// TypeOfService field in transmitted IPv4 packets.
  ///
  public byte TypeOfService;
  ///
  /// TimeToLive field in transmitted IPv4 packets.
  ///
  public byte TimeToLive;
  ///
  /// State of the DoNotFragment bit in transmitted IPv4 packets.
  ///
  public bool DoNotFragment;
  ///
  /// Set to TRUE to send and receive unformatted packets. The other
  /// IPv4 receive filters are still applied. Fragmentation is disabled for RawData mode.
  ///
  public bool RawData;
  ///
  /// The timer timeout value (number of microseconds) for the
  /// receive timeout event to be associated with each assembled
  /// packet. Zero means do not drop assembled packets.
  ///
  public uint ReceiveTimeout;
  ///
  /// The timer timeout value (number of microseconds) for the
  /// transmit timeout event to be associated with each outgoing
  /// packet. Zero means do not drop outgoing packets.
  ///
  public uint TransmitTimeout;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_ROUTE_TABLE
{
  public EFI_IPv4_ADDRESS SubnetAddress;
  public EFI_IPv4_ADDRESS SubnetMask;
  public EFI_IPv4_ADDRESS GatewayAddress;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_ICMP_TYPE
{
  public byte Type;
  public byte Code;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_MODE_DATA
{
  ///
  /// Set to TRUE after this EFI IPv4 Protocol instance has been successfully configured.
  ///
  public bool IsStarted;
  ///
  /// The maximum packet size, in bytes, of the packet which the upper layer driver could feed.
  ///
  public uint MaxPacketSize;
  ///
  /// Current configuration settings.
  ///
  public EFI_IP4_CONFIG_DATA ConfigData;
  ///
  /// Set to TRUE when the EFI IPv4 Protocol instance has a station address and subnet mask.
  ///
  public bool IsConfigured;
  ///
  /// Number of joined multicast groups.
  ///
  public uint GroupCount;
  ///
  /// List of joined multicast group addresses.
  ///
  public EFI_IPv4_ADDRESS* GroupTable;
  ///
  /// Number of entries in the routing table.
  ///
  public uint RouteCount;
  ///
  /// Routing table entries.
  ///
  public EFI_IP4_ROUTE_TABLE* RouteTable;
  ///
  /// Number of entries in the supported ICMP types list.
  ///
  public uint IcmpTypeCount;
  ///
  /// Array of ICMP types and codes that are supported by this EFI IPv4 Protocol driver
  ///
  public EFI_IP4_ICMP_TYPE* IcmpTypeList;
}

// #pragma pack(1)

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_HEADER
{
  public byte HeaderLength = 4;
  public byte Version = 4;
  public byte TypeOfService;
  public ushort TotalLength;
  public ushort Identification;
  public ushort Fragmentation;
  public byte TimeToLive;
  public byte Protocol;
  public ushort Checksum;
  public EFI_IPv4_ADDRESS SourceAddress;
  public EFI_IPv4_ADDRESS DestinationAddress;
}
// #pragma pack()

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_FRAGMENT_DATA
{
  public uint FragmentLength;
  public void* FragmentBuffer;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_RECEIVE_DATA
{
  public EFI_TIME TimeStamp;
  public EFI_EVENT RecycleSignal;
  public uint HeaderLength;
  public EFI_IP4_HEADER* Header;
  public uint OptionsLength;
  public void* Options;
  public uint DataLength;
  public uint FragmentCount;
  public fixed EFI_IP4_FRAGMENT_DATA FragmentTable[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_OVERRIDE_DATA
{
  public EFI_IPv4_ADDRESS SourceAddress;
  public EFI_IPv4_ADDRESS GatewayAddress;
  public byte Protocol;
  public byte TypeOfService;
  public byte TimeToLive;
  public bool DoNotFragment;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_TRANSMIT_DATA
{
  public EFI_IPv4_ADDRESS DestinationAddress;
  public EFI_IP4_OVERRIDE_DATA* OverrideData;    // OPTIONAL
  public uint OptionsLength;    // OPTIONAL
  public void* OptionsBuffer;   // OPTIONAL
  public uint TotalDataLength;
  public uint FragmentCount;
  public fixed EFI_IP4_FRAGMENT_DATA FragmentTable[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Packet
{
  ///
  /// This Event will be signaled after the Status field is updated
  /// by the EFI IPv4 Protocol driver. The type of Event must be
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
    /// When this token is used for receiving, RxData is a pointer to the EFI_IP4_RECEIVE_DATA.
    ///
   public EFI_IP4_RECEIVE_DATA* RxData;
  ///
  /// When this token is used for transmitting, TxData is a pointer to the EFI_IP4_TRANSMIT_DATA.
  ///
  public EFI_IP4_TRANSMIT_DATA* TxData;
}
} EFI_IP4_COMPLETION_TOKEN;



































































































































































































































































































































///
/// The EFI IPv4 Protocol implements a simple packet-oriented interface that can be
/// used by drivers, daemons, and applications to transmit and receive network packets.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_PROTOCOL
{
  /**
    Gets the current operational settings for this instance of the EFI IPv4 Protocol driver.

    The GetModeData() function returns the current operational mode data for this
    driver instance. The data fields in EFI_IP4_MODE_DATA are read only. This
    function is used optionally to retrieve the operational mode data of underlying
    networks or drivers.

    @param  This          The pointer to the EFI_IP4_PROTOCOL instance.
    @param  Ip4ModeData   The pointer to the EFI IPv4 Protocol mode data structure.
    @param  MnpConfigData The pointer to the managed network configuration data structure.
    @param  SnpModeData   The pointer to the simple network mode data structure.

    @retval EFI_SUCCESS           The operation completed successfully.
    @retval EFI_INVALID_PARAMETER This is NULL.
    @retval EFI_OUT_OF_RESOURCES  The required mode data could not be allocated.

  **/
  public readonly delegate* unmanaged<CONST, EFI_IP4_MODE_DATA*, EFI_MANAGED_NETWORK_CONFIG_DATA*, EFI_SIMPLE_NETWORK_MODE*, EFI_STATUS> GetModeData;
  /**
    Assigns an IPv4 address and subnet mask to this EFI IPv4 Protocol driver instance.

    The Configure() function is used to set, change, or reset the operational
    parameters and filter settings for this EFI IPv4 Protocol instance. Until these
    parameters have been set, no network traffic can be sent or received by this
    instance. Once the parameters have been reset (by calling this function with
    IpConfigData set to NULL), no more traffic can be sent or received until these
    parameters have been set again. Each EFI IPv4 Protocol instance can be started
    and stopped independently of each other by enabling or disabling their receive
    filter settings with the Configure() function.

    When IpConfigData.UseDefaultAddress is set to FALSE, the new station address will
    be appended as an alias address into the addresses list in the EFI IPv4 Protocol
    driver. While set to TRUE, Configure() will trigger the EFI_IP4_CONFIG_PROTOCOL
    to retrieve the default IPv4 address if it is not available yet. Clients could
    frequently call GetModeData() to check the status to ensure that the default IPv4
    address is ready.

    If operational parameters are reset or changed, any pending transmit and receive
    requests will be cancelled. Their completion token status will be set to EFI_ABORTED
    and their events will be signaled.

    @param  This         The pointer to the EFI_IP4_PROTOCOL instance.
    @param  IpConfigData The pointer to the EFI IPv4 Protocol configuration data structure.

    @retval EFI_SUCCESS           The driver instance was successfully opened.
    @retval EFI_NO_MAPPING        When using the default address, configuration (DHCP, BOOTP,
                                  RARP, etc.) is not finished yet.
    @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                  This is NULL.
                                  IpConfigData.StationAddress is not a unicast IPv4 address.
                                  IpConfigData.SubnetMask is not a valid IPv4 subnet
    @retval EFI_UNSUPPORTED       One or more of the following conditions is TRUE:
                                  A configuration protocol (DHCP, BOOTP, RARP, etc.) could
                                  not be located when clients choose to use the default IPv4
                                  address. This EFI IPv4 Protocol implementation does not
                                  support this requested filter or timeout setting.
    @retval EFI_OUT_OF_RESOURCES  The EFI IPv4 Protocol driver instance data could not be allocated.
    @retval EFI_ALREADY_STARTED   The interface is already open and must be stopped before the
                                  IPv4 address or subnet mask can be changed. The interface must
                                  also be stopped when switching to/from raw packet mode.
    @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred. The EFI IPv4
                                  Protocol driver instance is not opened.

  **/
  public readonly delegate* unmanaged<EFI_IP4_PROTOCOL*, EFI_IP4_CONFIG_DATA*, EFI_STATUS> Configure;
  /**
    Joins and leaves multicast groups.

    The Groups() function is used to join and leave multicast group sessions. Joining
    a group will enable reception of matching multicast packets. Leaving a group will
    disable the multicast packet reception.

    If JoinFlag is FALSE and GroupAddress is NULL, all joined groups will be left.

    @param  This                  The pointer to the EFI_IP4_PROTOCOL instance.
    @param  JoinFlag              Set to TRUE to join the multicast group session and FALSE to leave.
    @param  GroupAddress          The pointer to the IPv4 multicast address.

    @retval EFI_SUCCESS           The operation completed successfully.
    @retval EFI_INVALID_PARAMETER One or more of the following is TRUE:
                                  - This is NULL.
                                  - JoinFlag is TRUE and GroupAddress is NULL.
                                  - GroupAddress is not NULL and *GroupAddress is
                                    not a multicast IPv4 address.
    @retval EFI_NOT_STARTED       This instance has not been started.
    @retval EFI_NO_MAPPING        When using the default address, configuration (DHCP, BOOTP,
                                  RARP, etc.) is not finished yet.
    @retval EFI_OUT_OF_RESOURCES  System resources could not be allocated.
    @retval EFI_UNSUPPORTED       This EFI IPv4 Protocol implementation does not support multicast groups.
    @retval EFI_ALREADY_STARTED   The group address is already in the group table (when
                                  JoinFlag is TRUE).
    @retval EFI_NOT_FOUND         The group address is not in the group table (when JoinFlag is FALSE).
    @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred.

  **/
  public readonly delegate* unmanaged<EFI_IP4_PROTOCOL*, bool, EFI_IPv4_ADDRESS*, EFI_STATUS> Groups;
  /**
    Adds and deletes routing table entries.

    The Routes() function adds a route to or deletes a route from the routing table.

    Routes are determined by comparing the SubnetAddress with the destination IPv4
    address arithmetically AND-ed with the SubnetMask. The gateway address must be
    on the same subnet as the configured station address.

    The default route is added with SubnetAddress and SubnetMask both set to 0.0.0.0.
    The default route matches all destination IPv4 addresses that do not match any
    other routes.

    A GatewayAddress that is zero is a nonroute. Packets are sent to the destination
    IP address if it can be found in the ARP cache or on the local subnet. One automatic
    nonroute entry will be inserted into the routing table for outgoing packets that
    are addressed to a local subnet (gateway address of 0.0.0.0).

    Each EFI IPv4 Protocol instance has its own independent routing table. Those EFI
    IPv4 Protocol instances that use the default IPv4 address will also have copies
    of the routing table that was provided by the EFI_IP4_CONFIG_PROTOCOL, and these
    copies will be updated whenever the EIF IPv4 Protocol driver reconfigures its
    instances. As a result, client modification to the routing table will be lost.

    @param  This                   The pointer to the EFI_IP4_PROTOCOL instance.
    @param  DeleteRoute            Set to TRUE to delete this route from the routing table. Set to
                                   FALSE to add this route to the routing table. SubnetAddress
                                   and SubnetMask are used as the key to each route entry.
    @param  SubnetAddress          The address of the subnet that needs to be routed.
    @param  SubnetMask             The subnet mask of SubnetAddress.
    @param  GatewayAddress         The unicast gateway IPv4 address for this route.

    @retval EFI_SUCCESS            The operation completed successfully.
    @retval EFI_NOT_STARTED        The driver instance has not been started.
    @retval EFI_NO_MAPPING         When using the default address, configuration (DHCP, BOOTP,
                                   RARP, etc.) is not finished yet.
    @retval EFI_INVALID_PARAMETER  One or more of the following conditions is TRUE:
                                   - This is NULL.
                                   - SubnetAddress is NULL.
                                   - SubnetMask is NULL.
                                   - GatewayAddress is NULL.
                                   - *SubnetAddress is not a valid subnet address.
                                   - *SubnetMask is not a valid subnet mask.
                                   - *GatewayAddress is not a valid unicast IPv4 address.
    @retval EFI_OUT_OF_RESOURCES   Could not add the entry to the routing table.
    @retval EFI_NOT_FOUND          This route is not in the routing table (when DeleteRoute is TRUE).
    @retval EFI_ACCESS_DENIED      The route is already defined in the routing table (when
                                   DeleteRoute is FALSE).

  **/
  public readonly delegate* unmanaged<EFI_IP4_PROTOCOL*, bool, EFI_IPv4_ADDRESS*, EFI_IPv4_ADDRESS*, EFI_IPv4_ADDRESS*, EFI_STATUS> Routes;
  /**
    Places outgoing data packets into the transmit queue.

    The Transmit() function places a sending request in the transmit queue of this
    EFI IPv4 Protocol instance. Whenever the packet in the token is sent out or some
    errors occur, the event in the token will be signaled and the status is updated.

    @param  This  The pointer to the EFI_IP4_PROTOCOL instance.
    @param  Token The pointer to the transmit token.

    @retval  EFI_SUCCESS           The data has been queued for transmission.
    @retval  EFI_NOT_STARTED       This instance has not been started.
    @retval  EFI_NO_MAPPING        When using the default address, configuration (DHCP, BOOTP,
                                   RARP, etc.) is not finished yet.
    @retval  EFI_INVALID_PARAMETER One or more pameters are invalid.
    @retval  EFI_ACCESS_DENIED     The transmit completion token with the same Token.Event
                                   was already in the transmit queue.
    @retval  EFI_NOT_READY         The completion token could not be queued because the transmit
                                   queue is full.
    @retval  EFI_NOT_FOUND         Not route is found to destination address.
    @retval  EFI_OUT_OF_RESOURCES  Could not queue the transmit data.
    @retval  EFI_BUFFER_TOO_SMALL  Token.Packet.TxData.TotalDataLength is too
                                   short to transmit.
    @retval  EFI_BAD_BUFFER_SIZE   The length of the IPv4 header + option length + total data length is
                                   greater than MTU (or greater than the maximum packet size if
                                   Token.Packet.TxData.OverrideData.
                                   DoNotFragment is TRUE.)

  **/
  public readonly delegate* unmanaged<EFI_IP4_PROTOCOL*, EFI_IP4_COMPLETION_TOKEN*, EFI_STATUS> Transmit;
  /**
    Places a receiving request into the receiving queue.

    The Receive() function places a completion token into the receive packet queue.
    This function is always asynchronous.

    The Token.Event field in the completion token must be filled in by the caller
    and cannot be NULL. When the receive operation completes, the EFI IPv4 Protocol
    driver updates the Token.Status and Token.Packet.RxData fields and the Token.Event
    is signaled.

    @param  This  The pointer to the EFI_IP4_PROTOCOL instance.
    @param  Token The pointer to a token that is associated with the receive data descriptor.

    @retval EFI_SUCCESS           The receive completion token was cached.
    @retval EFI_NOT_STARTED       This EFI IPv4 Protocol instance has not been started.
    @retval EFI_NO_MAPPING        When using the default address, configuration (DHCP, BOOTP, RARP, etc.)
                                  is not finished yet.
    @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                  - This is NULL.
                                  - Token is NULL.
                                  - Token.Event is NULL.
    @retval EFI_OUT_OF_RESOURCES  The receive completion token could not be queued due to a lack of system
                                  resources (usually memory).
    @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred.
                                  The EFI IPv4 Protocol instance has been reset to startup defaults.
    @retval EFI_ACCESS_DENIED     The receive completion token with the same Token.Event was already
                                  in the receive queue.
    @retval EFI_NOT_READY         The receive request could not be queued because the receive queue is full.
    @retval EFI_ICMP_ERROR        An ICMP error packet was received.

  **/
  public readonly delegate* unmanaged<EFI_IP4_PROTOCOL*, EFI_IP4_COMPLETION_TOKEN*, EFI_STATUS> Receive;
  /**
    Abort an asynchronous transmit or receive request.

    The Cancel() function is used to abort a pending transmit or receive request.
    If the token is in the transmit or receive request queues, after calling this
    function, Token->Status will be set to EFI_ABORTED and then Token->Event will
    be signaled. If the token is not in one of the queues, which usually means the
    asynchronous operation has completed, this function will not signal the token
    and EFI_NOT_FOUND is returned.

    @param  This  The pointer to the EFI_IP4_PROTOCOL instance.
    @param  Token The pointer to a token that has been issued by
                  EFI_IP4_PROTOCOL.Transmit() or
                  EFI_IP4_PROTOCOL.Receive(). If NULL, all pending
                  tokens are aborted. Type EFI_IP4_COMPLETION_TOKEN is
                  defined in EFI_IP4_PROTOCOL.Transmit().

    @retval EFI_SUCCESS           The asynchronous I/O request was aborted and
                                  Token->Event was signaled. When Token is NULL, all
                                  pending requests were aborted and their events were signaled.
    @retval EFI_INVALID_PARAMETER This is NULL.
    @retval EFI_NOT_STARTED       This instance has not been started.
    @retval EFI_NO_MAPPING        When using the default address, configuration (DHCP, BOOTP,
                                  RARP, etc.) is not finished yet.
    @retval EFI_NOT_FOUND         When Token is not NULL, the asynchronous I/O request was
                                  not found in the transmit or receive queue. It has either completed
                                  or was not issued by Transmit() and Receive().

  **/
  public readonly delegate* unmanaged<EFI_IP4_PROTOCOL*, EFI_IP4_COMPLETION_TOKEN*, EFI_STATUS> Cancel;
  /**
    Polls for incoming data packets and processes outgoing data packets.

    The Poll() function polls for incoming data packets and processes outgoing data
    packets. Network drivers and applications can call the EFI_IP4_PROTOCOL.Poll()
    function to increase the rate that data packets are moved between the communications
    device and the transmit and receive queues.

    In some systems the periodic timer event may not poll the underlying communications
    device fast enough to transmit and/or receive all data packets without missing
    incoming packets or dropping outgoing packets. Drivers and applications that are
    experiencing packet loss should try calling the EFI_IP4_PROTOCOL.Poll() function
    more often.

    @param  This The pointer to the EFI_IP4_PROTOCOL instance.

    @retval  EFI_SUCCESS           Incoming or outgoing data was processed.
    @retval  EFI_NOT_STARTED       This EFI IPv4 Protocol instance has not been started.
    @retval  EFI_NO_MAPPING        When using the default address, configuration (DHCP, BOOTP,
                                   RARP, etc.) is not finished yet.
    @retval  EFI_INVALID_PARAMETER This is NULL.
    @retval  EFI_DEVICE_ERROR      An unexpected system or network error occurred.
    @retval  EFI_NOT_READY         No incoming or outgoing data is processed.
    @retval  EFI_TIMEOUT           Data was dropped out of the transmit and/or receive queue.
                                   Consider increasing the polling rate.

  **/
  public readonly delegate* unmanaged<EFI_IP4_PROTOCOL*, EFI_STATUS> Poll;
}

// extern EFI_GUID  gEfiIp4ServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiIp4ProtocolGuid;

// #endif
