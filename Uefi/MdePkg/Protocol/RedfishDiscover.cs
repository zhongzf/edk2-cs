namespace Uefi;
/** @file
  This file defines the EFI Redfish Discover Protocol interface.

  (C) Copyright 2021 Hewlett Packard Enterprise Development LP<BR>

  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  - Some corrections and revises are added to UEFI Specification 2.9.
  - This Protocol is introduced in UEFI Specification 2.8.

**/

// #ifndef EFI_REDFISH_DISCOVER_PROTOCOL_H_
// #define EFI_REDFISH_DISCOVER_PROTOCOL_H_

//
// GUID definitions
//
public static EFI_GUID EFI_REDFISH_DISCOVER_PROTOCOL_GUID = new GUID( 
    0x5db12509, 0x4550, 0x4347, new byte[] { 0x96, 0xb3, 0x73, 0xc0, 0xff, 0x6e, 0x86, 0x9f });

public static ulong REDFISH_DISCOVER_TOKEN_SIGNATURE = SIGNATURE_32 ('R', 'F', 'T', 'S');

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REDFISH_DISCOVER_FLAG { uint Value; public static implicit operator EFI_REDFISH_DISCOVER_FLAG(uint value) => new EFI_REDFISH_DISCOVER_FLAG() { Value = value }; public static implicit operator uint(EFI_REDFISH_DISCOVER_FLAG value) => value.Value;}
public static ulong EFI_REDFISH_DISCOVER_HOST_INTERFACE = 0x00000001 ///< Discover Redfish server reported in SMBIOS 42h.;
public static ulong EFI_REDFISH_DISCOVER_SSDP = 0x00000002 ///< Discover Redfish server using UPnP Http search method.;
public static ulong EFI_REDFISH_DISCOVER_SSDP_UDP6 = 0x00000004 ///< Use UDP version 6.;
public static ulong EFI_REDFISH_DISCOVER_KEEP_ALIVE = 0x00000008 ///< Keep to send UPnP Search in the duration indicated in;
                                                        ///< EFI_REDFISH_DISCOVER_DURATION_MASK.
public static ulong EFI_REDFISH_DISCOVER_RENEW = 0x00000010         ///< Set this bit to indicate this function to notify the caller;
                                                       ///< a list of all Redfish servers it found. Otherwise, this fucntion
                                                       ///< just notify the caller new found Redfish servers.
                                                       ///<
public static ulong EFI_REDFISH_DISCOVER_VALIDATION = 0x80000000 ///< Validate Redfish service for host interface instance.;
public static ulong EFI_REDFISH_DISCOVER_DURATION_MASK = 0x0f000000 ///< 2 to the Power of Duration. The valid value of duration is between;
                                                       ///< 3 to 15. The corresponding duration is 8 to 2^15 seconds.
                                                       ///< Duration is only valid when EFI_REDFISH_DISCOVER_KEEP_ALIVE
                                                       ///< is set to 1.
// typedef struct _EFI_REDFISH_DISCOVER_PROTOCOL EFI_REDFISH_DISCOVER_PROTOCOL;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REDFISH_DISCOVERED_INFORMATION {
 public EFI_HANDLE        RedfishRestExHandle;    ///< REST EX EFI handle associated with this Redfish service.
 public bool           IsUdp6;                 ///< Indicates it's IP versino 6.
 public EFI_IP_ADDRESS    RedfishHostIpAddress;   ///< IP address of Redfish service.
 public ulong             RedfishVersion;         ///< Redfish service version.
 public char            *Location;              ///< Redfish service location.
 public char            *Uuid;                  ///< Redfish service UUID.
 public char            *Os;                    ///< Redfish service OS.
 public char            *OsVersion;             ///< Redfish service OS version.
 public char            *Product;               ///< Redfish service product name.
 public char            *ProductVer;            ///< Redfish service product version.
 public bool           UseHttps;               ///< Using HTTPS.
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REDFISH_DISCOVERED_INSTANCE {
 public EFI_STATUS                            Status;      ///< Status of Redfish service discovery.
 public EFI_REDFISH_DISCOVERED_INFORMATION    Information; ///< Redfish service discovered.
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REDFISH_DISCOVERED_LIST {
 public ulong                              NumberOfServiceFound; ///< Must be 0 when pass to Acquire ().
 public EFI_REDFISH_DISCOVERED_INSTANCE    *RedfishInstances;    ///< Must be NULL when pass to Acquire ().
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REDFISH_DISCOVER_NETWORK_INTERFACE {
 public EFI_MAC_ADDRESS    MacAddress;                  ///< MAC address of network interfase to discover Redfish service.
 public bool            IsIpv6;                      ///< Indicates it's IP versino 6.
 public EFI_IP_ADDRESS     SubnetId;                    ///< Subnet ID.
 public byte              SubnetPrefixLength;          ///< Subnet prefix-length for IPv4 and IPv6.
 public ushort             VlanId;                      ///< VLAN ID.
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REDFISH_DISCOVERED_TOKEN {
 public uint                         Signature;    ///< Token signature.
 public EFI_REDFISH_DISCOVERED_LIST    DiscoverList; ///< The memory ofpublic EFI_REDFISH_DISCOVERED_LIST is
                                               ///< allocated by Acquire() and freed when caller invoke Release().
 public EFI_EVENT                      Event;        ///< The TPL_CALLBACK event to be notified when Redfish services
                                               ///< are discovered or any errors occurred during discovery.
 public ulong                          Timeout;      ///< The timeout value declared in EFI_REDFISH_DISCOVERED_TOKEN
                                               ///< determines the seconds to drop discover process.
                                               ///< Basically, the nearby Redfish services must response in >=1
                                               ///< and <= 5 seconds. The valid timeout value used to have
                                               ///< asynchronous discovery is >= 1 and <= 5 seconds. Set the
                                               ///< timeout to zero means to discover Redfish service synchronously.
                                               ///< Event in token is created by caller to listen the Reefish services
                                               ///< found by Acquire().
}






























































































[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REDFISH_DISCOVER_PROTOCOL {
/**
  This function gets the NIC list which Redfish discover protocol
  can discover Redfish service on it.

  @param[in]    This         EFI_REDFISH_DISCOVER_PROTOCOL instance.
  @param[in]    ImageHandle  EFI Image handle request the NIC list,
  @param[out]   NumberOfNetworkInterfaces Number of NICs can do Redfish service discovery.
  @param[out]   NetworkInterfaces NIC instances. It's an array of instance. The number of entries
                             in array is indicated by NumberOfNetworkInterfaces.
                             Caller has to release the memory
                             allocated by Redfish discover protocol.

  @retval EFI_SUCCESS        REST EX instances of discovered Redfish are released.
  @retval Others             Fail to remove the entry

**/
public readonly delegate* unmanaged<EFI_REDFISH_DISCOVER_PROTOCOL*,EFI_HANDLE,ulong*,EFI_REDFISH_DISCOVER_NETWORK_INTERFACE**, EFI_STATUS> GetNetworkInterfaceList;
/**
  This function acquires Redfish services by discovering static Redfish setting
  according to Redfish Host Interface or through SSDP. Returns a list of EFI
  handles in EFI_REDFISH_DISCOVERED_LIST. Each of EFI handle has cooresponding
  EFI REST EX instance installed on it. Each REST EX isntance is a child instance which
  created through EFI REST EX serivce protoocl for communicating with specific
  Redfish service.

  @param[in]    This          EFI_REDFISH_DISCOVER_PROTOCOL instance.
  @param[in]    ImageHandle   EFI image owns these Redfish service instances.
  @param[in]    TargetNetworkInterface Target NIC to do the discovery.
                              NULL means discover Redfish service on all NICs on platform.
  @param[in]    Flags         Redfish service discover flags.
  @param[in]    Token         EFI_REDFISH_DISCOVERED_TOKEN instance.
                              The memory of EFI_REDFISH_DISCOVERED_LIST and the strings in
                              EFI_REDFISH_DISCOVERED_INFORMATION are all allocated by Acquire()
                              and must be freed when caller invoke Release().

  @retval EFI_SUCCESS             REST EX instance of discovered Redfish services are returned.
  @retval EFI_INVALID_PARAMETERS  ImageHandle == NULL, Flags == 0, Token == NULL, Token->Timeout > 5,
                                  or Token->Event == NULL.
  @retval Others                  Fail acquire Redfish services.

**/
public readonly delegate* unmanaged<EFI_REDFISH_DISCOVER_PROTOCOL*,EFI_HANDLE,EFI_REDFISH_DISCOVER_NETWORK_INTERFACE*,EFI_REDFISH_DISCOVER_FLAG,EFI_REDFISH_DISCOVERED_TOKEN*, EFI_STATUS> AcquireRedfishService;
/**
  This function aborts Redfish service discovery on the given network interface.

  @param[in]    This                    EFI_REDFISH_DISCOVER_PROTOCOL instance.
  @param[in]    TargetNetworkInterface  Target NIC to do the discovery.

  @retval EFI_SUCCESS             REST EX instance of discovered Redfish services are returned.
  @retval Others                  Fail to abort Redfish service discovery.

**/
public readonly delegate* unmanaged<EFI_REDFISH_DISCOVER_PROTOCOL*,EFI_REDFISH_DISCOVER_NETWORK_INTERFACE*, EFI_STATUS> AbortAcquireRedfishService;
/**
  This function releases Redfish services found by RedfishServiceAcquire().

  @param[in]    This         EFI_REDFISH_DISCOVER_PROTOCOL instance.
  @param[in]    List         The Redfish service to release.

  @retval EFI_SUCCESS        REST EX instances of discovered Redfish are released.
  @retval Others             Fail to remove the entry

**/
public readonly delegate* unmanaged<EFI_REDFISH_DISCOVER_PROTOCOL*,EFI_REDFISH_DISCOVERED_LIST*, EFI_STATUS> ReleaseRedfishService;
}

// extern EFI_GUID  gEfiRedfishDiscoverProtocolGuid;
// #endif
