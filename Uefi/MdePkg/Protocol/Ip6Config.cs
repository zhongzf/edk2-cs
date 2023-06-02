using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file provides a definition of the EFI IPv6 Configuration
  Protocol.

Copyright (c) 2008 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __EFI_IP6CONFIG_PROTOCOL_H__
// #define __EFI_IP6CONFIG_PROTOCOL_H__

// #include <Protocol/Ip6.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_IP6_CONFIG_PROTOCOL_GUID = new GUID(
      0x937fe521, 0x95ae, 0x4d1a, new byte[] { 0x89, 0x29, 0x48, 0xbc, 0xd9, 0x0a, 0xd3, 0x1a });

  // typedef struct _EFI_IP6_CONFIG_PROTOCOL EFI_IP6_CONFIG_PROTOCOL;
}

///
/// EFI_IP6_CONFIG_DATA_TYPE
///
public enum EFI_IP6_CONFIG_DATA_TYPE
{
  ///
  /// The interface information of the communication
  /// device this EFI IPv6 Configuration Protocol instance manages.
  /// This type of data is read only.The corresponding Data is of type
  /// EFI_IP6_CONFIG_INTERFACE_INFO.
  ///
  Ip6ConfigDataTypeInterfaceInfo,
  ///
  /// The alternative interface ID for the
  /// communication device this EFI IPv6 Configuration Protocol
  /// instance manages if the link local IPv6 address generated from
  /// the interfaced ID based on the default source the EFI IPv6
  /// Protocol uses is a duplicate address. The length of the interface
  /// ID is 64 bit. The corresponding Data is of type
  /// EFI_IP6_CONFIG_INTERFACE_ID.
  ///
  Ip6ConfigDataTypeAltInterfaceId,
  ///
  /// The general configuration policy for the EFI IPv6 network
  /// stack running on the communication device this EFI IPv6
  /// Configuration Protocol instance manages. The policy will affect
  /// other configuration settings. The corresponding Data is of type
  /// EFI_IP6_CONFIG_POLICY.
  ///
  Ip6ConfigDataTypePolicy,
  ///
  /// The number of consecutive
  /// Neighbor Solicitation messages sent while performing Duplicate
  /// Address Detection on a tentative address. A value of zero
  /// indicates that Duplicate Address Detection will not be performed
  /// on tentative addresses. The corresponding Data is of type
  /// EFI_IP6_CONFIG_DUP_ADDR_DETECT_TRANSMITS.
  ///
  Ip6ConfigDataTypeDupAddrDetectTransmits,
  ///
  /// The station addresses set manually for the EFI
  /// IPv6 network stack. It is only configurable when the policy is
  /// Ip6ConfigPolicyManual. The corresponding Data is a
  /// pointer to an array of EFI_IPv6_ADDRESS instances. When
  /// DataSize is 0 and Data is NULL, the existing configuration
  /// is cleared from the EFI IPv6 Configuration Protocol instance.
  ///
  Ip6ConfigDataTypeManualAddress,
  ///
  /// The gateway addresses set manually for the EFI IPv6
  /// network stack running on the communication device this EFI
  /// IPv6 Configuration Protocol manages. It is not configurable when
  /// the policy is Ip6ConfigPolicyAutomatic. The gateway
  /// addresses must be unicast IPv6 addresses. The corresponding
  /// Data is a pointer to an array of EFI_IPv6_ADDRESS instances.
  /// When DataSize is 0 and Data is NULL, the existing configuration
  /// is cleared from the EFI IPv6 Configuration Protocol instance.
  ///
  Ip6ConfigDataTypeGateway,
  ///
  /// The DNS server list for the EFI IPv6 network stack
  /// running on the communication device this EFI IPv6
  /// Configuration Protocol manages. It is not configurable when the
  /// policy is Ip6ConfigPolicyAutomatic.The DNS server
  /// addresses must be unicast IPv6 addresses. The corresponding
  /// Data is a pointer to an array of EFI_IPv6_ADDRESS instances.
  /// When DataSize is 0 and Data is NULL, the existing configuration
  /// is cleared from the EFI IPv6 Configuration Protocol instance.
  ///
  Ip6ConfigDataTypeDnsServer,
  ///
  /// The number of this enumeration memebers.
  ///
  Ip6ConfigDataTypeMaximum
}

///
/// EFI_IP6_CONFIG_INTERFACE_INFO
/// describes the operational state of the interface this
/// EFI IPv6 Configuration Protocol instance manages.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP6_CONFIG_INTERFACE_INFO
{
  ///
  /// The name of the interface. It is a NULL-terminated string.
  ///
  public fixed char Name[32];
  ///
  /// The interface type of the network interface.
  ///
  public byte IfType;
  ///
  /// The size, in bytes, of the network interface's hardware address.
  ///
  public uint HwAddressSize;
  ///
  /// The hardware address for the network interface.
  ///
  public EFI_MAC_ADDRESS HwAddress;
  ///
  /// Number of EFI_IP6_ADDRESS_INFO structures pointed to by AddressInfo.
  ///
  public uint AddressInfoCount;
  ///
  /// Pointer to an array of EFI_IP6_ADDRESS_INFO instances
  /// which contain the local IPv6 addresses and the corresponding
  /// prefix length information. Set to NULL if AddressInfoCount
  /// is zero.
  ///
  public EFI_IP6_ADDRESS_INFO* AddressInfo;
  ///
  /// Number of route table entries in the following RouteTable.
  ///
  public uint RouteCount;
  ///
  /// The route table of the IPv6 network stack runs on this interface.
  /// Set to NULL if RouteCount is zero.
  ///
  public EFI_IP6_ROUTE_TABLE* RouteTable;
}

///
/// EFI_IP6_CONFIG_INTERFACE_ID
/// describes the 64-bit interface ID.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP6_CONFIG_INTERFACE_ID
{
  public fixed byte Id[8];
}

///
/// EFI_IP6_CONFIG_POLICY
/// defines the general configuration policy the EFI IPv6
/// Configuration Protocol supports.
///
public enum EFI_IP6_CONFIG_POLICY
{
  ///
  /// Under this policy, the IpI6ConfigDataTypeManualAddress,
  /// Ip6ConfigDataTypeGateway and Ip6ConfigDataTypeDnsServer
  /// configuration data are required to be set manually.
  /// The EFI IPv6 Protocol will get all required configuration
  /// such as address, prefix and gateway settings from the EFI
  /// IPv6 Configuration protocol.
  ///
  Ip6ConfigPolicyManual,
  ///
  /// Under this policy, the IpI6ConfigDataTypeManualAddress,
  /// Ip6ConfigDataTypeGateway and Ip6ConfigDataTypeDnsServer
  /// configuration data are not allowed to set via SetData().
  /// All of these configurations are retrieved from some auto
  /// configuration mechanism.
  /// The EFI IPv6 Protocol will use the IPv6 stateless address
  /// autoconfiguration mechanism and/or the IPv6 stateful address
  /// autoconfiguration mechanism described in the related RFCs to
  /// get address and other configuration information
  ///
  Ip6ConfigPolicyAutomatic
}

///
/// EFI_IP6_CONFIG_DUP_ADDR_DETECT_TRANSMITS
/// describes the number of consecutive Neighbor Solicitation messages sent
/// while performing Duplicate Address Detection on a tentative address.
/// The default value for a newly detected communication device is 1.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP6_CONFIG_DUP_ADDR_DETECT_TRANSMITS
{
  public uint DupAddrDetectTransmits;  ///< The number of consecutive Neighbor Solicitation messages sent.
}

///
/// EFI_IP6_CONFIG_MANUAL_ADDRESS
/// is used to set the station address information for the EFI IPv6 network
/// stack manually when the policy is Ip6ConfigPolicyManual.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP6_CONFIG_MANUAL_ADDRESS
{
  public EFI_IPv6_ADDRESS Address;         ///< The IPv6 unicast address.
  public bool IsAnycast;       ///< Set to TRUE if Address is anycast.
  public byte PrefixLength;    ///< The length, in bits, of the prefix associated with this Address.
}

///
/// The EFI_IP6_CONFIG_PROTOCOL provides the mechanism to set and get various
/// types of configurations for the EFI IPv6 network stack.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP6_CONFIG_PROTOCOL
{
  /**
    Set the configuration for the EFI IPv6 network stack running on the communication
    device this EFI IPv6 Configuration Protocol instance manages.

    This function is used to set the configuration data of type DataType for the EFI
    IPv6 network stack running on the communication device this EFI IPv6 Configuration
    Protocol instance manages.

    The DataSize is used to calculate the count of structure instances in the Data for
    some DataType that multiple structure instances are allowed.

    This function is always non-blocking. When setting some type of configuration data,
    an asynchronous process is invoked to check the correctness of the data, such as
    doing Duplicate Address Detection on the manually set local IPv6 addresses.
    EFI_NOT_READY is returned immediately to indicate that such an asynchronous process
    is invoked and the process is not finished yet. The caller willing to get the result
    of the asynchronous process is required to call RegisterDataNotify() to register an
    event on the specified configuration data. Once the event is signaled, the caller
    can call GetData() to get back the configuration data in order to know the result.
    For other types of configuration data that do not require an asynchronous configuration
    process, the result of the operation is immediately returned.

    @param[in]     This           Pointer to the EFI_IP6_CONFIG_PROTOCOL instance.
    @param[in]     DataType       The type of data to set.
    @param[in]     DataSize       Size of the buffer pointed to by Data in bytes.
    @param[in]     Data           The data buffer to set. The type of the data buffer is
                                  associated with the DataType.

    @retval EFI_SUCCESS           The specified configuration data for the EFI IPv6
                                  network stack is set successfully.
    @retval EFI_INVALID_PARAMETER One or more of the following are TRUE:
                                  - This is NULL.
                                  - One or more fields in Data and DataSize do not match the
                                    requirement of the data type indicated by DataType.
    @retval EFI_WRITE_PROTECTED   The specified configuration data is read-only or the specified
                                  configuration data can not be set under the current policy
    @retval EFI_ACCESS_DENIED     Another set operation on the specified configuration
                                  data is already in process.
    @retval EFI_NOT_READY         An asynchronous process is invoked to set the specified
                                  configuration data and the process is not finished yet.
    @retval EFI_BAD_BUFFER_SIZE   The DataSize does not match the size of the type
                                  indicated by DataType.
    @retval EFI_UNSUPPORTED       This DataType is not supported.
    @retval EFI_OUT_OF_RESOURCES  Required system resources could not be allocated.
    @retval EFI_DEVICE_ERROR      An unexpected system error or network error occurred.

  **/
  public readonly delegate* unmanaged<EFI_IP6_CONFIG_PROTOCOL*, EFI_IP6_CONFIG_DATA_TYPE, ulong, void*, EFI_STATUS> SetData;
  /**
    Get the configuration data for the EFI IPv6 network stack running on the communication
    device this EFI IPv6 Configuration Protocol instance manages.

    This function returns the configuration data of type DataType for the EFI IPv6 network
    stack running on the communication device this EFI IPv6 Configuration Protocol instance
    manages.

    The caller is responsible for allocating the buffer used to return the specified
    configuration data and the required size will be returned to the caller if the size of
    the buffer is too small.

    EFI_NOT_READY is returned if the specified configuration data is not ready due to an
    already in progress asynchronous configuration process. The caller can call RegisterDataNotify()
    to register an event on the specified configuration data. Once the asynchronous configuration
    process is finished, the event will be signaled and a subsequent GetData() call will return
    the specified configuration data.

    @param[in]     This           Pointer to the EFI_IP6_CONFIG_PROTOCOL instance.
    @param[in]     DataType       The type of data to get.
    @param[in,out] DataSize       On input, in bytes, the size of Data. On output, in bytes, the
                                  size of buffer required to store the specified configuration data.
    @param[in]     Data           The data buffer in which the configuration data is returned. The
                                  type of the data buffer is associated with the DataType.

    @retval EFI_SUCCESS           The specified configuration data is got successfully.
    @retval EFI_INVALID_PARAMETER One or more of the followings are TRUE:
                                  - This is NULL.
                                  - DataSize is NULL.
                                  - Data is NULL if *DataSize is not zero.
    @retval EFI_BUFFER_TOO_SMALL  The size of Data is too small for the specified configuration data
                                  and the required size is returned in DataSize.
    @retval EFI_NOT_READY         The specified configuration data is not ready due to an already in
                                  progress asynchronous configuration process.
    @retval EFI_NOT_FOUND         The specified configuration data is not found.

  **/
  public readonly delegate* unmanaged<EFI_IP6_CONFIG_PROTOCOL*, EFI_IP6_CONFIG_DATA_TYPE, ulong*, void*, EFI_STATUS> GetData;
  /**
    Register an event that is to be signaled whenever a configuration process on the specified
    configuration data is done.

    This function registers an event that is to be signaled whenever a configuration process
    on the specified configuration data is done. An event can be registered for different DataType
    simultaneously and the caller is responsible for determining which type of configuration data
    causes the signaling of the event in such case.

    @param[in]     This           Pointer to the EFI_IP6_CONFIG_PROTOCOL instance.
    @param[in]     DataType       The type of data to unregister the event for.
    @param[in]     Event          The event to register.

    @retval EFI_SUCCESS           The notification event for the specified configuration data is
                                  registered.
    @retval EFI_INVALID_PARAMETER This is NULL or Event is NULL.
    @retval EFI_UNSUPPORTED       The configuration data type specified by DataType is not
                                  supported.
    @retval EFI_OUT_OF_RESOURCES  Required system resources could not be allocated.
    @retval EFI_ACCESS_DENIED     The Event is already registered for the DataType.

  **/
  public readonly delegate* unmanaged<EFI_IP6_CONFIG_PROTOCOL*, EFI_IP6_CONFIG_DATA_TYPE, EFI_EVENT, EFI_STATUS> RegisterDataNotify;
  /**
    Remove a previously registered event for the specified configuration data.

    This function removes a previously registered event for the specified configuration data.

    @param[in]     This           Pointer to the EFI_IP6_CONFIG_PROTOCOL instance.
    @param[in]     DataType       The type of data to remove the previously registered event for.
    @param[in]     Event          The event to unregister.

    @retval EFI_SUCCESS           The event registered for the specified configuration data is removed.
    @retval EFI_INVALID_PARAMETER This is NULL or Event is NULL.
    @retval EFI_NOT_FOUND         The Event has not been registered for the specified
                                  DataType.

  **/
  public readonly delegate* unmanaged<EFI_IP6_CONFIG_PROTOCOL*, EFI_IP6_CONFIG_DATA_TYPE, EFI_EVENT, EFI_STATUS> UnregisterDataNotify;
}

// extern EFI_GUID  gEfiIp6ConfigProtocolGuid;

// #endif
