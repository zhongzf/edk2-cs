using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI Adapter Information Protocol definition.
  The EFI Adapter Information Protocol is used to dynamically and quickly discover
  or set device information for an adapter.

  Copyright (c) 2014 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.4

**/

// #ifndef __EFI_ADAPTER_INFORMATION_PROTOCOL_H__
// #define __EFI_ADAPTER_INFORMATION_PROTOCOL_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_ADAPTER_INFORMATION_PROTOCOL_GUID = new GUID(
      0xE5DD1403, 0xD622, 0xC24E, new byte[] { 0x84, 0x88, 0xC7, 0x1B, 0x17, 0xF5, 0xE8, 0x02 });

  public static EFI_GUID EFI_ADAPTER_INFO_MEDIA_STATE_GUID = new GUID(
      0xD7C74207, 0xA831, 0x4A26, new byte[] { 0xB1, 0xF5, 0xD1, 0x93, 0x06, 0x5C, 0xE8, 0xB6 });

  public static EFI_GUID EFI_ADAPTER_INFO_NETWORK_BOOT_GUID = new GUID(
      0x1FBD2960, 0x4130, 0x41E5, new byte[] { 0x94, 0xAC, 0xD2, 0xCF, 0x03, 0x7F, 0xB3, 0x7C });

  public static EFI_GUID EFI_ADAPTER_INFO_SAN_MAC_ADDRESS_GUID = new GUID(
      0x114da5ef, 0x2cf1, 0x4e12, new byte[] { 0x9b, 0xbb, 0xc4, 0x70, 0xb5, 0x52, 0x5, 0xd9 });

  public static EFI_GUID EFI_ADAPTER_INFO_UNDI_IPV6_SUPPORT_GUID = new GUID(
      0x4bd56be3, 0x4975, 0x4d8a, new byte[] { 0xa0, 0xad, 0xc4, 0x91, 0x20, 0x4b, 0x5d, 0x4d });

  public static EFI_GUID EFI_ADAPTER_INFO_MEDIA_TYPE_GUID = new GUID(
      0x8484472f, 0x71ec, 0x411a, new byte[] { 0xb3, 0x9c, 0x62, 0xcd, 0x94, 0xd9, 0x91, 0x6e });

  // typedef struct _EFI_ADAPTER_INFORMATION_PROTOCOL EFI_ADAPTER_INFORMATION_PROTOCOL;
}

///
/// EFI_ADAPTER_INFO_MEDIA_STATE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ADAPTER_INFO_MEDIA_STATE
{
  ///
  /// Returns the current media state status. MediaState can have any of the following values:
  /// EFI_SUCCESS: There is media attached to the network adapter. EFI_NOT_READY: This detects a bounced state.
  /// There was media attached to the network adapter, but it was removed and reattached. EFI_NO_MEDIA: There is
  /// not any media attached to the network.
  ///
  public EFI_STATUS MediaState;
}

///
/// EFI_ADAPTER_INFO_MEDIA_TYPE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ADAPTER_INFO_MEDIA_TYPE
{
  ///
  /// Indicates the current media type. MediaType can have any of the following values:
  /// 1: Ethernet Network Adapter
  /// 2: Ethernet Wireless Network Adapter
  /// 3~255: Reserved
  ///
  public byte MediaType;
}

///
/// EFI_ADAPTER_INFO_NETWORK_BOOT
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ADAPTER_INFO_NETWORK_BOOT
{
  ///
  /// TRUE if the adapter supports booting from iSCSI IPv4 targets.
  ///
  public bool iScsiIpv4BootCapablity;
  ///
  /// TRUE if the adapter supports booting from iSCSI IPv6 targets.
  ///
  public bool iScsiIpv6BootCapablity;
  ///
  /// TRUE if the adapter supports booting from FCoE targets.
  ///
  public bool FCoeBootCapablity;
  ///
  /// TRUE if the adapter supports an offload engine (such as TCP
  /// Offload Engine (TOE)) for its iSCSI or FCoE boot operations.
  ///
  public bool OffloadCapability;
  ///
  /// TRUE if the adapter supports multipath I/O (MPIO) for its iSCSI
  /// boot operations.
  ///
  public bool iScsiMpioCapability;
  ///
  /// TRUE if the adapter is currently configured to boot from iSCSI
  /// IPv4 targets.
  ///
  public bool iScsiIpv4Boot;
  ///
  /// TRUE if the adapter is currently configured to boot from iSCSI
  /// IPv6 targets.
  ///
  public bool iScsiIpv6Boot;
  ///
  /// TRUE if the adapter is currently configured to boot from FCoE targets.
  ///
  public bool FCoeBoot;
}

///
/// EFI_ADAPTER_INFO_SAN_MAC_ADDRESS
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ADAPTER_INFO_SAN_MAC_ADDRESS
{
  ///
  /// Returns the SAN MAC address for the adapter.For adapters that support today's 802.3 ethernet
  /// networking and Fibre-Channel Over Ethernet (FCOE), this conveys the FCOE SAN MAC address from the adapter.
  ///
  public EFI_MAC_ADDRESS SanMacAddress;
}

///
/// EFI_ADAPTER_INFO_UNDI_IPV6_SUPPORT
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ADAPTER_INFO_UNDI_IPV6_SUPPORT
{
  ///
  /// Returns capability of UNDI to support IPv6 traffic.
  ///
  public bool Ipv6Support;
}

///
/// EFI_ADAPTER_INFORMATION_PROTOCOL
/// The protocol for adapter provides the following services.
/// - Gets device state information from adapter.
/// - Sets device information for adapter.
/// - Gets a list of supported information types for this instance of the protocol.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ADAPTER_INFORMATION_PROTOCOL
{
  /**
    Returns the current state information for the adapter.

    This function returns information of type InformationType from the adapter.
    If an adapter does not support the requested informational type, then
    EFI_UNSUPPORTED is returned.

    @param[in]  This                   A pointer to the EFI_ADAPTER_INFORMATION_PROTOCOL instance.
    @param[in]  InformationType        A pointer to an EFI_GUID that defines the contents of InformationBlock.
    @param[out] InforamtionBlock       The service returns a pointer to the buffer with the InformationBlock
                                       structure which contains details about the data specific to InformationType.
    @param[out] InforamtionBlockSize   The driver returns the size of the InformationBlock in bytes.

    @retval EFI_SUCCESS                The InformationType information was retrieved.
    @retval EFI_UNSUPPORTED            The InformationType is not known.
    @retval EFI_DEVICE_ERROR           The device reported an error.
    @retval EFI_OUT_OF_RESOURCES       The request could not be completed due to a lack of resources.
    @retval EFI_INVALID_PARAMETER      This is NULL.
    @retval EFI_INVALID_PARAMETER      InformationBlock is NULL.
    @retval EFI_INVALID_PARAMETER      InformationBlockSize is NULL.

  **/
  public readonly delegate* unmanaged<EFI_ADAPTER_INFORMATION_PROTOCOL*, EFI_GUID*, void**, ulong*, EFI_STATUS> GetInformation;
  /**
    Sets state information for an adapter.

    This function sends information of type InformationType for an adapter.
    If an adapter does not support the requested information type, then EFI_UNSUPPORTED
    is returned.

    @param[in]  This                   A pointer to the EFI_ADAPTER_INFORMATION_PROTOCOL instance.
    @param[in]  InformationType        A pointer to an EFI_GUID that defines the contents of InformationBlock.
    @param[in]  InforamtionBlock       A pointer to the InformationBlock structure which contains details
                                       about the data specific to InformationType.
    @param[in]  InforamtionBlockSize   The size of the InformationBlock in bytes.

    @retval EFI_SUCCESS                The information was received and interpreted successfully.
    @retval EFI_UNSUPPORTED            The InformationType is not known.
    @retval EFI_DEVICE_ERROR           The device reported an error.
    @retval EFI_INVALID_PARAMETER      This is NULL.
    @retval EFI_INVALID_PARAMETER      InformationBlock is NULL.
    @retval EFI_WRITE_PROTECTED        The InformationType cannot be modified using EFI_ADAPTER_INFO_SET_INFO().

  **/
  public readonly delegate* unmanaged<EFI_ADAPTER_INFORMATION_PROTOCOL*, EFI_GUID*, void*, ulong, EFI_STATUS> SetInformation;
  /**
    Get a list of supported information types for this instance of the protocol.

    This function returns a list of InformationType GUIDs that are supported on an
    adapter with this instance of EFI_ADAPTER_INFORMATION_PROTOCOL. The list is returned
    in InfoTypesBuffer, and the number of GUID pointers in InfoTypesBuffer is returned in
    InfoTypesBufferCount.

    @param[in]  This                  A pointer to the EFI_ADAPTER_INFORMATION_PROTOCOL instance.
    @param[out] InfoTypesBuffer       A pointer to the array of InformationType GUIDs that are supported
                                      by This.
    @param[out] InfoTypesBufferCount  A pointer to the number of GUIDs present in InfoTypesBuffer.

    @retval EFI_SUCCESS               The list of information type GUIDs that are supported on this adapter was
                                      returned in InfoTypesBuffer. The number of information type GUIDs was
                                      returned in InfoTypesBufferCount.
    @retval EFI_INVALID_PARAMETER     This is NULL.
    @retval EFI_INVALID_PARAMETER     InfoTypesBuffer is NULL.
    @retval EFI_INVALID_PARAMETER     InfoTypesBufferCount is NULL.
    @retval EFI_OUT_OF_RESOURCES      There is not enough pool memory to store the results.

  **/
  public readonly delegate* unmanaged<EFI_ADAPTER_INFORMATION_PROTOCOL*, EFI_GUID**, ulong*, EFI_STATUS> GetSupportedTypes;
}

// extern EFI_GUID  gEfiAdapterInformationProtocolGuid;

// extern EFI_GUID  gEfiAdapterInfoMediaStateGuid;

// extern EFI_GUID  gEfiAdapterInfoNetworkBootGuid;

// extern EFI_GUID  gEfiAdapterInfoSanMacAddressGuid;

// extern EFI_GUID  gEfiAdapterInfoUndiIpv6SupportGuid;

// #endif
