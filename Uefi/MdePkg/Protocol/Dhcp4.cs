namespace Uefi;
/** @file
  EFI_DHCP4_PROTOCOL as defined in UEFI 2.0.
  EFI_DHCP4_SERVICE_BINDING_PROTOCOL as defined in UEFI 2.0.
  These protocols are used to collect configuration information for the EFI IPv4 Protocol
  drivers and to provide DHCPv4 server and PXE boot server discovery services.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in UEFI Specification 2.0.

**/

// #ifndef __EFI_DHCP4_PROTOCOL_H__
// #define __EFI_DHCP4_PROTOCOL_H__

public static EFI_GUID EFI_DHCP4_PROTOCOL_GUID = new GUID( 
    0x8a219718, 0x4ef5, 0x4761, new byte[] {0x91, 0xc8, 0xc0, 0xf0, 0x4b, 0xda, 0x9e, 0x56 });

public static EFI_GUID EFI_DHCP4_SERVICE_BINDING_PROTOCOL_GUID = new GUID( 
    0x9d9a39d8, 0xbd42, 0x4a73, new byte[] {0xa4, 0xd5, 0x8e, 0xe9, 0x4b, 0xe1, 0x13, 0x80 });

// typedef struct _EFI_DHCP4_PROTOCOL EFI_DHCP4_PROTOCOL;

// #pragma pack(1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DHCP4_PACKET_OPTION {
  ///
  /// DHCP option code.
  ///
 public byte    OpCode;
  ///
  /// Length of the DHCP option data. Not present if OpCode is 0 or 255.
  ///
 public byte    Length;
  ///
  /// Start of the DHCP option data. Not present if OpCode is 0 or 255 or if Length is zero.
  ///
 public fixed byte    Data[1];
}
// #pragma pack()

// #pragma pack(1)
///
/// EFI_DHCP4_PACKET defines the format of DHCPv4 packets. See RFC 2131 for more information.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DHCP4_HEADER {
 public byte               OpCode;
 public byte               HwType;
 public byte               HwAddrLen;
 public byte               Hops;
 public uint              Xid;
 public ushort              Seconds;
 public ushort              Reserved;
 public EFI_IPv4_ADDRESS    ClientAddr;       ///< Client IP address from client.
 public EFI_IPv4_ADDRESS    YourAddr;         ///< Client IP address from server.
 public EFI_IPv4_ADDRESS    ServerAddr;       ///< IP address of next server in bootstrap.
 public EFI_IPv4_ADDRESS    GatewayAddr;      ///< Relay agent IP address.
 public fixed byte               ClientHwAddr[16]; ///< Client hardware address.
 public fixed byte               ServerName[64];
 public fixed byte               BootFileName[128];
}
// #pragma pack()

// #pragma pack(1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Dhcp4 {
  ///
  /// Size of the EFI_DHCP4_PACKET buffer.
  ///
 public uint    Size;
  ///
  /// Length of the EFI_DHCP4_PACKET from the first byte of the Header field
  /// to the last byte of the Option[] field.
  ///
 public uint    Length;

  struct {
    ///
    /// DHCP packet header.
    ///
   public EFI_DHCP4_HEADER    Header;
    ///
    /// DHCP magik cookie in network byte order.
    ///
   public uint              Magik;
    ///
    /// Start of the DHCP packed option data.
    ///
   public fixed byte               Option[1];
}
} EFI_DHCP4_PACKET;
// #pragma pack()

public enum EFI_DHCP4_STATE {
  ///
  /// The EFI DHCPv4 Protocol driver is stopped.
  ///
  Dhcp4Stopped = 0x0,
  ///
  /// The EFI DHCPv4 Protocol driver is inactive.
  ///
  Dhcp4Init = 0x1,
  ///
  /// The EFI DHCPv4 Protocol driver is collecting DHCP offer packets from DHCP servers.
  ///
  Dhcp4Selecting = 0x2,
  ///
  /// The EFI DHCPv4 Protocol driver has sent the request to the DHCP server and is waiting for a response.
  ///
  Dhcp4Requesting = 0x3,
  ///
  /// The DHCP configuration has completed.
  ///
  Dhcp4Bound = 0x4,
  ///
  /// The DHCP configuration is being renewed and another request has
  /// been sent out, but it has not received a response from the server yet.
  ///
  Dhcp4Renewing = 0x5,
  ///
  /// The DHCP configuration has timed out and the EFI DHCPv4
  /// Protocol driver is trying to extend the lease time.
  ///
  Dhcp4Rebinding = 0x6,
  ///
  /// The EFI DHCPv4 Protocol driver was initialized with a previously
  /// allocated or known IP address.
  ///
  Dhcp4InitReboot = 0x7,
  ///
  /// The EFI DHCPv4 Protocol driver is seeking to reuse the previously
  /// allocated IP address by sending a request to the DHCP server.
  ///
  Dhcp4Rebooting = 0x8
}

public enum EFI_DHCP4_EVENT {
  ///
  /// The packet to start the configuration sequence is about to be sent.
  ///
  Dhcp4SendDiscover = 0x01,
  ///
  /// A reply packet was just received.
  ///
  Dhcp4RcvdOffer = 0x02,
  ///
  /// It is time for Dhcp4Callback to select an offer.
  ///
  Dhcp4SelectOffer = 0x03,
  ///
  /// A request packet is about to be sent.
  ///
  Dhcp4SendRequest = 0x04,
  ///
  /// A DHCPACK packet was received and will be passed to Dhcp4Callback.
  ///
  Dhcp4RcvdAck = 0x05,
  ///
  /// A DHCPNAK packet was received and will be passed to Dhcp4Callback.
  ///
  Dhcp4RcvdNak = 0x06,
  ///
  /// A decline packet is about to be sent.
  ///
  Dhcp4SendDecline = 0x07,
  ///
  /// The DHCP configuration process has completed. No packet is associated with this event.
  ///
  Dhcp4BoundCompleted = 0x08,
  ///
  /// It is time to enter the Dhcp4Renewing state and to contact the server
  /// that originally issued the network address. No packet is associated with this event.
  ///
  Dhcp4EnterRenewing = 0x09,
  ///
  /// It is time to enter the Dhcp4Rebinding state and to contact any server.
  /// No packet is associated with this event.
  ///
  Dhcp4EnterRebinding = 0x0a,
  ///
  /// The configured IP address was lost either because the lease has expired,
  /// the user released the configuration, or a DHCPNAK packet was received in
  /// the Dhcp4Renewing or Dhcp4Rebinding state. No packet is associated with this event.
  ///
  Dhcp4AddressLost = 0x0b,
  ///
  /// The DHCP process failed because a DHCPNAK packet was received or the user
  /// aborted the DHCP process at a time when the configuration was not available yet.
  /// No packet is associated with this event.
  ///
  Dhcp4Fail = 0x0c
}












































[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DHCP4_CONFIG_DATA {
  ///
  /// The number of times to try sending a packet during the Dhcp4SendDiscover
  /// event and waiting for a response during the Dhcp4RcvdOffer event.
  /// Set to zero to use the default try counts and timeout values.
  ///
 public uint                     DiscoverTryCount;
  ///
  /// The maximum amount of time (in seconds) to wait for returned packets in each
  /// of the retries. Timeout values of zero will default to a timeout value
  /// of one second. Set to NULL to use default timeout values.
  ///
 public uint                     *DiscoverTimeout;
  ///
  /// The number of times to try sending a packet during the Dhcp4SendRequest event
  /// and waiting for a response during the Dhcp4RcvdAck event before accepting
  /// failure. Set to zero to use the default try counts and timeout values.
  ///
 public uint                     RequestTryCount;
  ///
  /// The maximum amount of time (in seconds) to wait for return packets in each of the retries.
  /// Timeout values of zero will default to a timeout value of one second.
  /// Set to NULL to use default timeout values.
  ///
 public uint                     *RequestTimeout;
  ///
  /// For a DHCPDISCOVER, setting this parameter to the previously allocated IP
  /// address will cause the EFI DHCPv4 Protocol driver to enter the Dhcp4InitReboot state.
  /// And set this field to 0.0.0.0 to enter the Dhcp4Init state.
  /// For a DHCPINFORM this parameter should be set to the client network address
  /// which was assigned to the client during a DHCPDISCOVER.
  ///
 public EFI_IPv4_ADDRESS           ClientAddress;
  ///
  /// The callback function to intercept various events that occurred in
  /// the DHCP configuration process. Set to NULL to ignore all those events.
  ///
 public EFI_DHCP4_CALLBACK         Dhcp4Callback;
  ///
  /// The pointer to the context that will be passed to Dhcp4Callback when it is called.
  ///
 public void                       *CallbackContext;
  ///
  /// Number of DHCP options in the OptionList.
  ///
 public uint                     OptionCount;
  ///
  /// List of DHCP options to be included in every packet that is sent during the
  /// Dhcp4SendDiscover event. Pad options are appended automatically by DHCP driver
  /// in outgoing DHCP packets. If OptionList itself contains pad option, they are
  /// ignored by the driver. OptionList can be freed after EFI_DHCP4_PROTOCOL.Configure()
  /// returns. Ignored if OptionCount is zero.
  ///
 public EFI_DHCP4_PACKET_OPTION    **OptionList;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DHCP4_MODE_DATA {
  ///
  /// The EFI DHCPv4 Protocol driver operating state.
  ///
 public EFI_DHCP4_STATE          State;
  ///
  /// The configuration data of the current EFI DHCPv4 Protocol driver instance.
  ///
 public EFI_DHCP4_CONFIG_DATA    ConfigData;
  ///
  /// The client IP address that was acquired from the DHCP server. If it is zero,
  /// the DHCP acquisition has not completed yet and the following fields in this structure are undefined.
  ///
 public EFI_IPv4_ADDRESS         ClientAddress;
  ///
  /// The local hardware address.
  ///
 public EFI_MAC_ADDRESS          ClientMacAddress;
  ///
  /// The server IP address that is providing the DHCP service to this client.
  ///
 public EFI_IPv4_ADDRESS         ServerAddress;
  ///
  /// The router IP address that was acquired from the DHCP server.
  /// May be zero if the server does not offer this address.
  ///
 public EFI_IPv4_ADDRESS         RouterAddress;
  ///
  /// The subnet mask of the connected network that was acquired from the DHCP server.
  ///
 public EFI_IPv4_ADDRESS         SubnetMask;
  ///
  /// The lease time (in 1-second units) of the configured IP address.
  /// The value 0xFFFFFFFF means that the lease time is infinite.
  /// A default lease of 7 days is used if the DHCP server does not provide a value.
  ///
 public uint                   LeaseTime;
  ///
  /// The cached latest DHCPACK or DHCPNAK or BOOTP REPLY packet. May be NULL if no packet is cached.
  ///
 public EFI_DHCP4_PACKET         *ReplyPacket;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DHCP4_LISTEN_POINT {
  ///
  /// Alternate listening address. It can be a unicast, multicast, or broadcast address.
  ///
 public EFI_IPv4_ADDRESS    ListenAddress;
  ///
  /// The subnet mask of above listening unicast/broadcast IP address.
  /// Ignored if ListenAddress is a multicast address.
  ///
 public EFI_IPv4_ADDRESS    SubnetMask;
  ///
  /// Alternate station source (or listening) port number.
  /// If zero, then the default station port number (68) will be used.
  ///
 public ushort              ListenPort;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DHCP4_TRANSMIT_RECEIVE_TOKEN {
  ///
  /// The completion status of transmitting and receiving.
  ///
 public EFI_STATUS                Status;
  ///
  /// If not NULL, the event that will be signaled when the collection process
  /// completes. If NULL, this function will busy-wait until the collection process competes.
  ///
 public EFI_EVENT                 CompletionEvent;
  ///
  /// The pointer to the server IP address. This address may be a unicast, multicast, or broadcast address.
  ///
 public EFI_IPv4_ADDRESS          RemoteAddress;
  ///
  /// The server listening port number. If zero, the default server listening port number (67) will be used.
  ///
 public ushort                    RemotePort;
  ///
  /// The pointer to the gateway address to override the existing setting.
  ///
 public EFI_IPv4_ADDRESS          GatewayAddress;
  ///
  /// The number of entries in ListenPoints. If zero, the default station address and port number 68 are used.
  ///
 public uint                    ListenPointCount;
  ///
  /// An array of station address and port number pairs that are used as receiving filters.
  /// The first entry is also used as the source address and source port of the outgoing packet.
  ///
 public EFI_DHCP4_LISTEN_POINT    *ListenPoints;
  ///
  /// The number of seconds to collect responses. Zero is invalid.
  ///
 public uint                    TimeoutValue;
  ///
  /// The pointer to the packet to be transmitted.
  ///
 public EFI_DHCP4_PACKET          *Packet;
  ///
  /// Number of received packets.
  ///
 public uint                    ResponseCount;
  ///
  /// The pointer to the allocated list of received packets.
  ///
 public EFI_DHCP4_PACKET          *ResponseList;
}


















































































































































































































































































































































///
/// This protocol is used to collect configuration information for the EFI IPv4 Protocol drivers
/// and to provide DHCPv4 server and PXE boot server discovery services.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DHCP4_PROTOCOL {
/**
  Returns the current operating mode and cached data packet for the EFI DHCPv4 Protocol driver.

  The GetModeData() function returns the current operating mode and cached data
  packet for the EFI DHCPv4 Protocol driver.

  @param  This          The pointer to the EFI_DHCP4_PROTOCOL instance.
  @param  Dhcp4ModeData The pointer to storage for the EFI_DHCP4_MODE_DATA structure.

  @retval EFI_SUCCESS           The mode data was returned.
  @retval EFI_INVALID_PARAMETER This is NULL.

**/
public readonly delegate* unmanaged<EFI_DHCP4_PROTOCOL*,EFI_DHCP4_MODE_DATA*, EFI_STATUS> GetModeData;
/**
  Initializes, changes, or resets the operational settings for the EFI DHCPv4 Protocol driver.

  The Configure() function is used to initialize, change, or reset the operational
  settings of the EFI DHCPv4 Protocol driver for the communication device on which
  the EFI DHCPv4 Service Binding Protocol is installed. This function can be
  successfully called only if both of the following are true:
  * This instance of the EFI DHCPv4 Protocol driver is in the Dhcp4Stopped, Dhcp4Init,
    Dhcp4InitReboot, or Dhcp4Bound states.
  * No other EFI DHCPv4 Protocol driver instance that is controlled by this EFI
    DHCPv4 Service Binding Protocol driver instance has configured this EFI DHCPv4
    Protocol driver.
  When this driver is in the Dhcp4Stopped state, it can transfer into one of the
  following two possible initial states:
  * Dhcp4Init
  * Dhcp4InitReboot.
  The driver can transfer into these states by calling Configure() with a non-NULL
  Dhcp4CfgData. The driver will transfer into the appropriate state based on the
  supplied client network address in the ClientAddress parameter and DHCP options
  in the OptionList parameter as described in RFC 2131.
  When Configure() is called successfully while Dhcp4CfgData is set to NULL, the
  default configuring data will be reset in the EFI DHCPv4 Protocol driver and
  the state of the EFI DHCPv4 Protocol driver will not be changed. If one instance
  wants to make it possible for another instance to configure the EFI DHCPv4 Protocol
  driver, it must call this function with Dhcp4CfgData set to NULL.

  @param  This                   The pointer to the EFI_DHCP4_PROTOCOL instance.
  @param  Dhcp4CfgData           The pointer to the EFI_DHCP4_CONFIG_DATA.

  @retval EFI_SUCCESS           The EFI DHCPv4 Protocol driver is now in the Dhcp4Init or
                                Dhcp4InitReboot state, if the original state of this driver
                                was Dhcp4Stopped, Dhcp4Init,Dhcp4InitReboot, or Dhcp4Bound
                                and the value of Dhcp4CfgData was not NULL.
                                Otherwise, the state was left unchanged.
  @retval EFI_ACCESS_DENIED     This instance of the EFI DHCPv4 Protocol driver was not in the
                                Dhcp4Stopped, Dhcp4Init, Dhcp4InitReboot, or Dhcp4Bound state;
                                Or onother instance of this EFI DHCPv4 Protocol driver is already
                                in a valid configured state.
  @retval EFI_INVALID_PARAMETER One or more following conditions are TRUE:
                                This is NULL.
                                DiscoverTryCount > 0 and DiscoverTimeout is NULL
                                RequestTryCount > 0 and RequestTimeout is NULL.
                                OptionCount >0 and OptionList is NULL.
                                ClientAddress is not a valid unicast address.
  @retval EFI_OUT_OF_RESOURCES  Required system resources could not be allocated.
  @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred.

**/
public readonly delegate* unmanaged<EFI_DHCP4_PROTOCOL*,EFI_DHCP4_CONFIG_DATA*, EFI_STATUS> Configure;
/**
  Starts the DHCP configuration process.

  The Start() function starts the DHCP configuration process. This function can
  be called only when the EFI DHCPv4 Protocol driver is in the Dhcp4Init or
  Dhcp4InitReboot state.
  If the DHCP process completes successfully, the state of the EFI DHCPv4 Protocol
  driver will be transferred through Dhcp4Selecting and Dhcp4Requesting to the
  Dhcp4Bound state. The CompletionEvent will then be signaled if it is not NULL.
  If the process aborts, either by the user or by some unexpected network error,
  the state is restored to the Dhcp4Init state. The Start() function can be called
  again to restart the process.
  Refer to RFC 2131 for precise state transitions during this process. At the
  time when each event occurs in this process, the callback function that was set
  by EFI_DHCP4_PROTOCOL.Configure() will be called and the user can take this
  opportunity to control the process.

  @param  This            The pointer to the EFI_DHCP4_PROTOCOL instance.
  @param  CompletionEvent If not NULL, it indicates the event that will be signaled when the
                          EFI DHCPv4 Protocol driver is transferred into the
                          Dhcp4Bound state or when the DHCP process is aborted.
                          EFI_DHCP4_PROTOCOL.GetModeData() can be called to
                          check the completion status. If NULL,
                          EFI_DHCP4_PROTOCOL.Start() will wait until the driver
                          is transferred into the Dhcp4Bound state or the process fails.

  @retval EFI_SUCCESS           The DHCP configuration process has started, or it has completed
                                when CompletionEvent is NULL.
  @retval EFI_NOT_STARTED       The EFI DHCPv4 Protocol driver is in the Dhcp4Stopped
                                state. EFI_DHCP4_PROTOCOL. Configure() needs to be called.
  @retval EFI_INVALID_PARAMETER This is NULL.
  @retval EFI_OUT_OF_RESOURCES  Required system resources could not be allocated.
  @retval EFI_TIMEOUT           The DHCP configuration process failed because no response was
                                received from the server within the specified timeout value.
  @retval EFI_ABORTED           The user aborted the DHCP process.
  @retval EFI_ALREADY_STARTED   Some other EFI DHCPv4 Protocol instance already started the
                                DHCP process.
  @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred.
  @retval EFI_NO_MEDIA          There was a media error.

**/
public readonly delegate* unmanaged<EFI_DHCP4_PROTOCOL*,EFI_EVENT, EFI_STATUS> Start;
/**
  Extends the lease time by sending a request packet.

  The RenewRebind() function is used to manually extend the lease time when the
  EFI DHCPv4 Protocol driver is in the Dhcp4Bound state, and the lease time has
  not expired yet. This function will send a request packet to the previously
  found server (or to any server when RebindRequest is TRUE) and transfer the
  state into the Dhcp4Renewing state (or Dhcp4Rebinding when RebindingRequest is
  TRUE). When a response is received, the state is returned to Dhcp4Bound.
  If no response is received before the try count is exceeded (the RequestTryCount
  field that is specified in EFI_DHCP4_CONFIG_DATA) but before the lease time that
  was issued by the previous server expires, the driver will return to the Dhcp4Bound
  state, and the previous configuration is restored. The outgoing and incoming packets
  can be captured by the EFI_DHCP4_CALLBACK function.

  @param  This            The pointer to the EFI_DHCP4_PROTOCOL instance.
  @param  RebindRequest   If TRUE, this function broadcasts the request packets and enters
                          the Dhcp4Rebinding state. Otherwise, it sends a unicast
                          request packet and enters the Dhcp4Renewing state.
  @param  CompletionEvent If not NULL, this event is signaled when the renew/rebind phase
                          completes or some error occurs.
                          EFI_DHCP4_PROTOCOL.GetModeData() can be called to
                          check the completion status. If NULL,
                          EFI_DHCP4_PROTOCOL.RenewRebind() will busy-wait
                          until the DHCP process finishes.

  @retval EFI_SUCCESS           The EFI DHCPv4 Protocol driver is now in the
                                Dhcp4Renewing state or is back to the Dhcp4Bound state.
  @retval EFI_NOT_STARTED       The EFI DHCPv4 Protocol driver is in the Dhcp4Stopped
                                state. EFI_DHCP4_PROTOCOL.Configure() needs to
                                be called.
  @retval EFI_INVALID_PARAMETER This is NULL.
  @retval EFI_TIMEOUT           There was no response from the server when the try count was
                                exceeded.
  @retval EFI_ACCESS_DENIED     The driver is not in the Dhcp4Bound state.
  @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred.

**/
public readonly delegate* unmanaged<EFI_DHCP4_PROTOCOL*,bool,EFI_EVENT, EFI_STATUS> RenewRebind;
/**
  Releases the current address configuration.

  The Release() function releases the current configured IP address by doing either
  of the following:
  * Sending a DHCPRELEASE packet when the EFI DHCPv4 Protocol driver is in the
    Dhcp4Bound state
  * Setting the previously assigned IP address that was provided with the
    EFI_DHCP4_PROTOCOL.Configure() function to 0.0.0.0 when the driver is in
    Dhcp4InitReboot state
  After a successful call to this function, the EFI DHCPv4 Protocol driver returns
  to the Dhcp4Init state, and any subsequent incoming packets will be discarded silently.

  @param  This                  The pointer to the EFI_DHCP4_PROTOCOL instance.

  @retval EFI_SUCCESS           The EFI DHCPv4 Protocol driver is now in the Dhcp4Init phase.
  @retval EFI_INVALID_PARAMETER This is NULL.
  @retval EFI_ACCESS_DENIED     The EFI DHCPv4 Protocol driver is not Dhcp4InitReboot state.
  @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred.

**/
public readonly delegate* unmanaged<EFI_DHCP4_PROTOCOL*, EFI_STATUS> Release;
/**
  Stops the current address configuration.

  The Stop() function is used to stop the DHCP configuration process. After this
  function is called successfully, the EFI DHCPv4 Protocol driver is transferred
  into the Dhcp4Stopped state. EFI_DHCP4_PROTOCOL.Configure() needs to be called
  before DHCP configuration process can be started again. This function can be
  called when the EFI DHCPv4 Protocol driver is in any state.

  @param  This                  The pointer to the EFI_DHCP4_PROTOCOL instance.

  @retval EFI_SUCCESS           The EFI DHCPv4 Protocol driver is now in the Dhcp4Stopped phase.
  @retval EFI_INVALID_PARAMETER This is NULL.

**/
public readonly delegate* unmanaged<EFI_DHCP4_PROTOCOL*, EFI_STATUS> Stop;
/**
  Builds a DHCP packet, given the options to be appended or deleted or replaced.

  The Build() function is used to assemble a new packet from the original packet
  by replacing or deleting existing options or appending new options. This function
  does not change any state of the EFI DHCPv4 Protocol driver and can be used at
  any time.

  @param  This        The pointer to the EFI_DHCP4_PROTOCOL instance.
  @param  SeedPacket  Initial packet to be used as a base for building new packet.
  @param  DeleteCount Number of opcodes in the DeleteList.
  @param  DeleteList  List of opcodes to be deleted from the seed packet.
                      Ignored if DeleteCount is zero.
  @param  AppendCount Number of entries in the OptionList.
  @param  AppendList  The pointer to a DHCP option list to be appended to SeedPacket.
                      If SeedPacket also contains options in this list, they are
                      replaced by new options (except pad option). Ignored if
                      AppendCount is zero. Type EFI_DHCP4_PACKET_OPTION
  @param  NewPacket   The pointer to storage for the pointer to the new allocated packet.
                      Use the EFI Boot Service FreePool() on the resulting pointer
                      when done with the packet.

  @retval EFI_SUCCESS           The new packet was built.
  @retval EFI_OUT_OF_RESOURCES  Storage for the new packet could not be allocated.
  @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                This is NULL.
                                SeedPacket is NULL.
                                SeedPacket is not a well-formed DHCP packet.
                                AppendCount is not zero and AppendList is NULL.
                                DeleteCount is not zero and DeleteList is NULL.
                                NewPacket is NULL
                                Both DeleteCount and AppendCount are zero and
                                NewPacket is not NULL.

**/
public readonly delegate* unmanaged<EFI_DHCP4_PROTOCOL*,EFI_DHCP4_PACKET*,uint,byte*,uint,EFI_DHCP4_PACKET_OPTION*,EFI_DHCP4_PACKET**, EFI_STATUS> Build;
/**
  Transmits a DHCP formatted packet and optionally waits for responses.

  The TransmitReceive() function is used to transmit a DHCP packet and optionally
  wait for the response from servers. This function does not change the state of
  the EFI DHCPv4 Protocol driver. It can be used at any time because of this.

  @param  This    The pointer to the EFI_DHCP4_PROTOCOL instance.
  @param  Token   The pointer to the EFI_DHCP4_TRANSMIT_RECEIVE_TOKEN structure.

  @retval EFI_SUCCESS           The packet was successfully queued for transmission.
  @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                This is NULL.
                                Token.RemoteAddress is zero.
                                Token.Packet is NULL.
                                Token.Packet is not a well-formed DHCP packet.
                                The transaction ID in Token.Packet is in use by another DHCP process.
  @retval EFI_NOT_READY         The previous call to this function has not finished yet. Try to call
                                this function after collection process completes.
  @retval EFI_NO_MAPPING        The default station address is not available yet.
  @retval EFI_OUT_OF_RESOURCES  Required system resources could not be allocated.
  @retval EFI_UNSUPPORTED       The implementation doesn't support this function
  @retval Others                Some other unexpected error occurred.

**/
public readonly delegate* unmanaged<EFI_DHCP4_PROTOCOL*,EFI_DHCP4_TRANSMIT_RECEIVE_TOKEN*, EFI_STATUS> TransmitReceive;
/**
  Parses the packed DHCP option data.

  The Parse() function is used to retrieve the option list from a DHCP packet.
  If *OptionCount isn't zero, and there is enough space for all the DHCP options
  in the Packet, each element of PacketOptionList is set to point to somewhere in
  the Packet->Dhcp4.Option where a new DHCP option begins. If RFC3396 is supported,
  the caller should reassemble the parsed DHCP options to get the final result.
  If *OptionCount is zero or there isn't enough space for all of them, the number
  of DHCP options in the Packet is returned in OptionCount.

  @param  This             The pointer to the EFI_DHCP4_PROTOCOL instance.
  @param  Packet           The pointer to packet to be parsed.
  @param  OptionCount      On input, the number of entries in the PacketOptionList.
                           On output, the number of entries that were written into the
                           PacketOptionList.
  @param  PacketOptionList A list of packet option entries to be filled in. End option or pad
                           options are not included.

  @retval EFI_SUCCESS           The packet was successfully parsed.
  @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                This is NULL.
                                The packet is NULL.
                                The packet is not a well-formed DHCP packet.
                                OptionCount is NULL.
  @retval EFI_BUFFER_TOO_SMALL  One or more of the following conditions is TRUE:
                                1) *OptionCount is smaller than the number of options that
                                were found in the Packet.
                                2) PacketOptionList is NULL.
  @retval EFI_OUT_OF_RESOURCE   The packet failed to parse because of a resource shortage.

**/
public readonly delegate* unmanaged<EFI_DHCP4_PROTOCOL*,EFI_DHCP4_PACKET*,uint*,EFI_DHCP4_PACKET_OPTION*, EFI_STATUS> Parse;
}

// extern EFI_GUID  gEfiDhcp4ProtocolGuid;
// extern EFI_GUID  gEfiDhcp4ServiceBindingProtocolGuid;

// #endif
