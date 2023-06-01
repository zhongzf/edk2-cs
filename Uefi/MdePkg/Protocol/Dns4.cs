namespace Uefi;
/** @file
  This file defines the EFI Domain Name Service Binding Protocol interface. It is split
  into the following two main sections:
  DNSv4 Service Binding Protocol (DNSv4SB)
  DNSv4 Protocol (DNSv4)

  Copyright (c) 2015 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.5

**/

// #ifndef __EFI_DNS4_PROTOCOL_H__
// #define __EFI_DNS4_PROTOCOL_H__

public static EFI_GUID EFI_DNS4_SERVICE_BINDING_PROTOCOL_GUID = new GUID(
    0xb625b186, 0xe063, 0x44f7, new byte[] { 0x89, 0x5, 0x6a, 0x74, 0xdc, 0x6f, 0x52, 0xb4 });

public static EFI_GUID EFI_DNS4_PROTOCOL_GUID = new GUID(
    0xae3d28cc, 0xe05b, 0x4fa1, new byte[] { 0xa0, 0x11, 0x7e, 0xb5, 0x5a, 0x3f, 0x14, 0x1 });

// typedef struct _EFI_DNS4_PROTOCOL EFI_DNS4_PROTOCOL;

///
/// EFI_DNS4_CONFIG_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DNS4_CONFIG_DATA
{
  ///
  /// Count of the DNS servers. When used with GetModeData(),
  /// this field is the count of originally configured servers when
  /// Configure() was called for this instance. When used with
  /// Configure() this is the count of caller-supplied servers. If the
  /// DnsServerListCount is zero, the DNS server configuration
  /// will be retrieved from DHCP server automatically.
  ///
  public ulong DnsServerListCount;
  ///
  /// Pointer to DNS server list containing DnsServerListCount entries or NULL
  /// if DnsServerListCountis 0. For Configure(), this will be NULL when there are
  /// no caller supplied server addresses, and, the DNS instance will retrieve
  /// DNS server from DHCP Server. The provided DNS server list is
  /// recommended to be filled up in the sequence of preference. When
  /// used with GetModeData(), the buffer containing the list will
  /// be allocated by the driver implementing this protocol and must be
  /// freed by the caller. When used with Configure(), the buffer
  /// containing the list will be allocated and released by the caller.
  ///
  public EFI_IPv4_ADDRESS* DnsServerList;
  ///
  /// Set to TRUE to use the default IP address/subnet mask and default routing table.
  ///
  public bool UseDefaultSetting;
  ///
  /// If TRUE, enable DNS cache function for this DNS instance. If FALSE, all DNS
  /// query will not lookup local DNS cache.
  ///
  public bool EnableDnsCache;
  ///
  /// Use the protocol number defined in "Links to UEFI-Related
  /// Documents"(http://uefi.org/uefi) under the heading "IANA
  /// Protocol Numbers". Only TCP or UDP are supported, and other
  /// protocol values are invalid. An implementation can choose to
  /// support only UDP, or both TCP and UDP.
  ///
  public byte Protocol;
  ///
  /// If UseDefaultSetting is FALSE indicates the station address to use.
  ///
  public EFI_IPv4_ADDRESS StationIp;
  ///
  /// If UseDefaultSetting is FALSE indicates the subnet mask to use.
  ///
  public EFI_IPv4_ADDRESS SubnetMask;
  ///
  /// Local port number. Set to zero to use the automatically assigned port number.
  ///
  public ushort LocalPort;
  ///
  /// Retry number if no response received after RetryInterval.
  ///
  public uint RetryCount;
  ///
  /// Minimum interval of retry is 2 second. If the retry interval is less than 2
  /// seconds, then use the 2 seconds.
  ///
  public uint RetryInterval;
}

///
/// EFI_DNS4_CACHE_ENTRY
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DNS4_CACHE_ENTRY
{
  ///
  /// Host name.
  ///
  public char* HostName;
  ///
  /// IP address of this host.
  ///
  public EFI_IPv4_ADDRESS* IpAddress;
  ///
  /// Time in second unit that this entry will remain in DNS cache. A value of zero
  /// means that this entry is permanent. A nonzero value will override the existing
  /// one if this entry to be added is dynamic entry. Implementations may set its
  /// default timeout value for the dynamically created DNS cache entry after one DNS
  /// resolve succeeds.
  ///
  public uint Timeout;
}

///
/// EFI_DNS4_MODE_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DNS4_MODE_DATA
{
  ///
  /// The configuration data of this instance.
  ///
  public EFI_DNS4_CONFIG_DATA DnsConfigData;
  ///
  /// Number of configured DNS server. Each DNS instance has its own DNS server
  /// configuration.
  ///
  public uint DnsServerCount;
  ///
  /// Pointer to common list of addresses of all configured DNS server
  /// used by EFI_DNS4_PROTOCOL instances. List will include
  /// DNS servers configured by this or any other EFI_DNS4_PROTOCOL instance.
  /// The storage for this list is allocated by the driver publishing this
  /// protocol, and must be freed by the caller.
  ///
  public EFI_IPv4_ADDRESS* DnsServerList;
  ///
  /// Number of DNS Cache entries. The DNS Cache is shared among all DNS instances.
  ///
  public uint DnsCacheCount;
  ///
  /// Pointer to a buffer containing DnsCacheCount DNS Cache
  /// entry structures. The storage for this list is allocated by the driver
  /// publishing this protocol and must be freed by caller.
  ///
  public EFI_DNS4_CACHE_ENTRY* DnsCacheList;
}

///
/// DNS_HOST_TO_ADDR_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct DNS_HOST_TO_ADDR_DATA
{
  ///
  /// Number of the returned IP addresses.
  ///
  public uint IpCount;
  ///
  /// Pointer to the all the returned IP addresses.
  ///
  public EFI_IPv4_ADDRESS* IpList;
}

///
/// DNS_ADDR_TO_HOST_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct DNS_ADDR_TO_HOST_DATA
{
  ///
  /// Pointer to the primary name for this host address. It's the caller's
  /// responsibility to free the response memory.
  ///
  public char* HostName;
}

///
/// DNS_RESOURCE_RECORD
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct DNS_RESOURCE_RECORD
{
  ///
  /// The Owner name.
  ///
  public byte* QName;
  ///
  /// The Type Code of this RR.
  ///
  public ushort QType;
  ///
  /// The CLASS code of this RR.
  ///
  public ushort QClass;
  ///
  /// 32 bit integer which specify the time interval that the resource record may be
  /// cached before the source of the information should again be consulted. Zero means
  /// this RR can not be cached.
  ///
  public uint TTL;
  ///
  /// 16 big integer which specify the length of RData.
  ///
  public ushort DataLength;
  ///
  /// A string of octets that describe the resource, the format of this information
  /// varies according to QType and QClass difference.
  ///
  public byte* RData;
}

///
/// DNS_GENERAL_LOOKUP_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct DNS_GENERAL_LOOKUP_DATA
{
  ///
  /// Number of returned matching RRs.
  ///
  public ulong RRCount;
  ///
  /// Pointer to the all the returned matching RRs. It's caller responsibility to free
  /// the allocated memory to hold the returned RRs.
  ///
  public DNS_RESOURCE_RECORD* RRList;
}

///
/// EFI_DNS4_COMPLETION_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct RspData
{
  ///
  /// This Event will be signaled after the Status field is updated by the EFI DNS
  /// protocol driver. The type of Event must be EFI_NOTIFY_SIGNAL.
  ///
  public EFI_EVENT Event;
  ///
  /// Will be set to one of the following values:
  ///   EFI_SUCCESS:      The host name to address translation completed successfully.
  ///   EFI_NOT_FOUND:    No matching Resource Record (RR) is found.
  ///   EFI_TIMEOUT:      No DNS server reachable, or RetryCount was exhausted without
  ///                     response from all specified DNS servers.
  ///   EFI_DEVICE_ERROR: An unexpected system or network error occurred.
  ///   EFI_NO_MEDIA:     There was a media error.
  ///
  public EFI_STATUS Status;
  ///
  /// Retry number if no response received after RetryInterval. If zero, use the
  /// parameter configured through Dns.Configure() interface.
  ///
  public uint RetryCount;
  ///
  /// Minimum interval of retry is 2 second. If the retry interval is less than 2
  /// seconds, then use the 2 seconds. If zero, use the parameter configured through
  /// Dns.Configure() interface.
  public uint RetryInterval;
  ///
  /// DNSv4 completion token data
  ///
  union {
    ///
    /// When the Token is used for host name to address translation, H2AData is a pointer
    /// to the DNS_HOST_TO_ADDR_DATA.
    ///
   public DNS_HOST_TO_ADDR_DATA* H2AData;
  ///
  /// When the Token is used for host address to host name translation, A2HData is a
  /// pointer to the DNS_ADDR_TO_HOST_DATA.
  ///
  public DNS_ADDR_TO_HOST_DATA* A2HData;
  ///
  /// When the Token is used for a general lookup function, GLookupDATA is a pointer to
  /// the DNS_GENERAL_LOOKUP_DATA.
  ///
  public DNS_GENERAL_LOOKUP_DATA* GLookupData;
}
} EFI_DNS4_COMPLETION_TOKEN;




















































































































































































































































///
/// The EFI_DNS4_Protocol provides the function to get the host name and address
/// mapping, also provides pass through interface to retrieve arbitrary information
/// from DNS.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DNS4_PROTOCOL
{
  /**
    Retrieve mode data of this DNS instance.

    This function is used to retrieve DNS mode data for this DNS instance.

    @param[in]   This               Pointer to EFI_DNS4_PROTOCOL instance.
    @param[out]  DnsModeData        Point to the mode data.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_NOT_STARTED         When DnsConfigData is queried, no configuration data
                                    is available because this instance has not been
                                    configured.
    @retval EFI_INVALID_PARAMETER   This is NULL or DnsModeData is NULL.
    @retval EFI_OUT_OF_RESOURCES    Failed to allocate needed resources.
  **/
  public readonly delegate* unmanaged<EFI_DNS4_PROTOCOL*, EFI_DNS4_MODE_DATA*, EFI_STATUS> GetModeData;
  /**
    Configure this DNS instance.

    This function is used to configure DNS mode data for this DNS instance.

    @param[in]  This                Pointer to EFI_DNS4_PROTOCOL instance.
    @param[in]  DnsConfigData       Point to the Configuration data.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_UNSUPPORTED         The designated protocol is not supported.
    @retval EFI_INVALID_PARAMETER   This is NULL.
                                    The StationIp address provided in DnsConfigData is not a
                                    valid unicast.
                                    DnsServerList is NULL while DnsServerListCount
                                    is not ZERO.
                                    DnsServerListCount is ZERO while DnsServerList
                                    is not NULL
    @retval EFI_OUT_OF_RESOURCES    The DNS instance data or required space could not be
                                    allocated.
    @retval EFI_DEVICE_ERROR        An unexpected system or network error occurred. The
                                    EFI DNSv4 Protocol instance is not configured.
    @retval EFI_ALREADY_STARTED     Second call to Configure() with DnsConfigData. To
                                    reconfigure the instance the caller must call Configure()
                                    with NULL first to return driver to unconfigured state.
  **/
  public readonly delegate* unmanaged<EFI_DNS4_PROTOCOL*, EFI_DNS4_CONFIG_DATA*, EFI_STATUS> Configure;
  /**
    Host name to host address translation.

    The HostNameToIp () function is used to translate the host name to host IP address. A
    type A query is used to get the one or more IP addresses for this host.

    @param[in]  This                Pointer to EFI_DNS4_PROTOCOL instance.
    @param[in]  HostName            Host name.
    @param[in]  Token               Point to the completion token to translate host name
                                    to host address.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    Token is NULL.
                                    Token.Event is NULL.
                                    HostName is NULL. HostName string is unsupported format.
    @retval EFI_NO_MAPPING          There's no source address is available for use.
    @retval EFI_NOT_STARTED         This instance has not been started.
  **/
  public readonly delegate* unmanaged<EFI_DNS4_PROTOCOL*, char*, EFI_DNS4_COMPLETION_TOKEN*, EFI_STATUS> HostNameToIp;
  /**
    IPv4 address to host name translation also known as Reverse DNS lookup.

    The IpToHostName() function is used to translate the host address to host name. A type PTR
    query is used to get the primary name of the host. Support of this function is optional.

    @param[in]  This                Pointer to EFI_DNS4_PROTOCOL instance.
    @param[in]  IpAddress           Ip Address.
    @param[in]  Token               Point to the completion token to translate host
                                    address to host name.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_UNSUPPORTED         This function is not supported.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    Token is NULL.
                                    Token.Event is NULL.
                                    IpAddress is not valid IP address .
    @retval EFI_NO_MAPPING          There's no source address is available for use.
    @retval EFI_ALREADY_STARTED     This Token is being used in another DNS session.
    @retval EFI_OUT_OF_RESOURCES    Failed to allocate needed resources.
  **/
  public readonly delegate* unmanaged<EFI_DNS4_PROTOCOL*, EFI_IPv4_ADDRESS, EFI_DNS4_COMPLETION_TOKEN*, EFI_STATUS> IpToHostName;
  /**
    Retrieve arbitrary information from the DNS server.

    This GeneralLookup() function retrieves arbitrary information from the DNS. The caller
    supplies a QNAME, QTYPE, and QCLASS, and all of the matching RRs are returned. All
    RR content (e.g., TTL) was returned. The caller need parse the returned RR to get
    required information. The function is optional.

    @param[in]  This                Pointer to EFI_DNS4_PROTOCOL instance.
    @param[in]  QName               Pointer to Query Name.
    @param[in]  QType               Query Type.
    @param[in]  QClass              Query Name.
    @param[in]  Token               Point to the completion token to retrieve arbitrary
                                    information.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_UNSUPPORTED         This function is not supported. Or the requested
                                    QType is not supported
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    Token is NULL.
                                    Token.Event is NULL.
                                    QName is NULL.
    @retval EFI_NO_MAPPING          There's no source address is available for use.
    @retval EFI_ALREADY_STARTED     This Token is being used in another DNS session.
    @retval EFI_OUT_OF_RESOURCES    Failed to allocate needed resources.
  **/
  public readonly delegate* unmanaged<EFI_DNS4_PROTOCOL*, byte*, ushort, ushort, EFI_DNS4_COMPLETION_TOKEN*, EFI_STATUS> GeneralLookUp;
  /**
    This function is to update the DNS Cache.

    The UpdateDnsCache() function is used to add/delete/modify DNS cache entry. DNS cache
    can be normally dynamically updated after the DNS resolve succeeds. This function
    provided capability to manually add/delete/modify the DNS cache.

    @param[in]  This                Pointer to EFI_DNS4_PROTOCOL instance.
    @param[in]  DeleteFlag          If FALSE, this function is to add one entry to the
                                    DNS Cahce. If TRUE, this function will delete
                                    matching DNS Cache entry.
    @param[in]  Override            If TRUE, the maching DNS cache entry will be
                                    overwritten with the supplied parameter. If FALSE,
                                    EFI_ACCESS_DENIED will be returned if the entry to
                                    be added is already existed.
    @param[in]  DnsCacheEntry       Pointer to DNS Cache entry.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    DnsCacheEntry.HostName is NULL.
                                    DnsCacheEntry.IpAddress is NULL.
                                    DnsCacheEntry.Timeout is zero.
    @retval EFI_ACCESS_DENIED       The DNS cache entry already exists and Override is
                                    not TRUE.
  **/
  public readonly delegate* unmanaged<EFI_DNS4_PROTOCOL*, bool, bool, EFI_DNS4_CACHE_ENTRY, EFI_STATUS> UpdateDnsCache;
  /**
    Polls for incoming data packets and processes outgoing data packets.

    The Poll() function can be used by network drivers and applications to increase the
    rate that data packets are moved between the communications device and the transmit
    and receive queues.
    In some systems, the periodic timer event in the managed network driver may not poll
    the underlying communications device fast enough to transmit and/or receive all data
    packets without missing incoming packets or dropping outgoing packets. Drivers and
    applications that are experiencing packet loss should try calling the Poll()
    function more often.

    @param[in]  This                Pointer to EFI_DNS4_PROTOCOL instance.

    @retval EFI_SUCCESS             Incoming or outgoing data was processed.
    @retval EFI_NOT_STARTED         This EFI DNS Protocol instance has not been started.
    @retval EFI_INVALID_PARAMETER   This is NULL.
    @retval EFI_DEVICE_ERROR        An unexpected system or network error occurred.
    @retval EFI_TIMEOUT             Data was dropped out of the transmit and/or receive
                                    queue. Consider increasing the polling rate.
  **/
  public readonly delegate* unmanaged<EFI_DNS4_PROTOCOL*, EFI_STATUS> Poll;
  /**
    Abort an asynchronous DNS operation, including translation between IP and Host, and
    general look up behavior.

    The Cancel() function is used to abort a pending resolution request. After calling
    this function, Token.Status will be set to EFI_ABORTED and then Token.Event will be
    signaled. If the token is not in one of the queues, which usually means that the
    asynchronous operation has completed, this function will not signal the token and
    EFI_NOT_FOUND is returned.

    @param[in]  This                Pointer to EFI_DNS4_PROTOCOL instance.
    @param[in]  Token               Pointer to a token that has been issued by
                                    EFI_DNS4_PROTOCOL.HostNameToIp (),
                                    EFI_DNS4_PROTOCOL.IpToHostName() or
                                    EFI_DNS4_PROTOCOL.GeneralLookup().
                                    If NULL, all pending tokens are aborted.

    @retval EFI_SUCCESS             Incoming or outgoing data was processed.
    @retval EFI_NOT_STARTED         This EFI DNS4 Protocol instance has not been started.
    @retval EFI_INVALID_PARAMETER   This is NULL.
    @retval EFI_NOT_FOUND           When Token is not NULL, and the asynchronous DNS
                                    operation was not found in the transmit queue. It
                                    was either completed or was not issued by
                                    HostNameToIp(), IpToHostName() or GeneralLookup().
  **/
  public readonly delegate* unmanaged<EFI_DNS4_PROTOCOL*, EFI_DNS4_COMPLETION_TOKEN*, EFI_STATUS> Cancel;
}

// extern EFI_GUID  gEfiDns4ServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiDns4ProtocolGuid;

// #endif
