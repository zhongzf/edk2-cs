using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file provides a definition of the EFI IPv4 Configuration
  Protocol.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.0.

**/

// #ifndef __EFI_IP4CONFIG_PROTOCOL_H__
// #define __EFI_IP4CONFIG_PROTOCOL_H__

// #include <Protocol/Ip4.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_IP4_CONFIG_PROTOCOL_GUID = new GUID(
      0x3b95aa31, 0x3793, 0x434b, new byte[] { 0x86, 0x67, 0xc8, 0x07, 0x08, 0x92, 0xe0, 0x5e });

  // typedef struct _EFI_IP4_CONFIG_PROTOCOL EFI_IP4_CONFIG_PROTOCOL;

#define IP4_CONFIG_VARIABLE_ATTRIBUTES \
  (EFI_VARIABLE_NON_VOLATILE | EFI_VARIABLE_BOOTSERVICE_ACCESS)
}

///
/// EFI_IP4_IPCONFIG_DATA contains the minimum IPv4 configuration data
/// that is needed to start basic network communication. The StationAddress
/// and SubnetMask must be a valid unicast IP address and subnet mask.
/// If RouteTableSize is not zero, then RouteTable contains a properly
/// formatted routing table for the StationAddress/SubnetMask, with the
/// last entry in the table being the default route.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_IPCONFIG_DATA
{
  ///
  /// Default station IP address, stored in network byte order.
  ///
  public EFI_IPv4_ADDRESS StationAddress;
  ///
  /// Default subnet mask, stored in network byte order.
  ///
  public EFI_IPv4_ADDRESS SubnetMask;
  ///
  /// Number of entries in the following RouteTable. May be zero.
  ///
  public uint RouteTableSize;
  ///
  /// Default routing table data (stored in network byte order).
  /// Ignored if RouteTableSize is zero.
  ///
  public EFI_IP4_ROUTE_TABLE* RouteTable;
}

///
/// The EFI_IP4_CONFIG_PROTOCOL driver performs platform-dependent and policy-dependent
/// configurations for the EFI IPv4 Protocol driver.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP4_CONFIG_PROTOCOL
{
  /**
    Starts running the configuration policy for the EFI IPv4 Protocol driver.

    The Start() function is called to determine and to begin the platform
    configuration policy by the EFI IPv4 Protocol driver. This determination may
    be as simple as returning EFI_UNSUPPORTED if there is no EFI IPv4 Protocol
    driver configuration policy. It may be as involved as loading some defaults
    from nonvolatile storage, downloading dynamic data from a DHCP server, and
    checking permissions with a site policy server.
    Starting the configuration policy is just the beginning. It may finish almost
    instantly or it may take several minutes before it fails to retrieve configuration
    information from one or more servers. Once the policy is started, drivers
    should use the DoneEvent parameter to determine when the configuration policy
    has completed. EFI_IP4_CONFIG_PROTOCOL.GetData() must then be called to
    determine if the configuration succeeded or failed.
    Until the configuration completes successfully, EFI IPv4 Protocol driver instances
    that are attempting to use default configurations must return EFI_NO_MAPPING.
    Once the configuration is complete, the EFI IPv4 Configuration Protocol driver
    signals DoneEvent. The configuration may need to be updated in the future.
    Note that in this case the EFI IPv4 Configuration Protocol driver must signal
    ReconfigEvent, and all EFI IPv4 Protocol driver instances that are using default
    configurations must return EFI_NO_MAPPING until the configuration policy has
    been rerun.

    @param  This                   The pointer to the EFI_IP4_CONFIG_PROTOCOL instance.
    @param  DoneEvent              Event that will be signaled when the EFI IPv4
                                   Protocol driver configuration policy completes
                                   execution. This event must be of type EVT_NOTIFY_SIGNAL.
    @param  ReconfigEvent          Event that will be signaled when the EFI IPv4
                                   Protocol driver configuration needs to be updated.
                                   This event must be of type EVT_NOTIFY_SIGNAL.

    @retval EFI_SUCCESS            The configuration policy for the EFI IPv4 Protocol
                                   driver is now running.
    @retval EFI_INVALID_PARAMETER  One or more of the following parameters is NULL:
                                    This
                                    DoneEvent
                                    ReconfigEvent
    @retval EFI_OUT_OF_RESOURCES   Required system resources could not be allocated.
    @retval EFI_ALREADY_STARTED    The configuration policy for the EFI IPv4 Protocol
                                   driver was already started.
    @retval EFI_DEVICE_ERROR       An unexpected system error or network error occurred.
    @retval EFI_UNSUPPORTED        This interface does not support the EFI IPv4 Protocol
                                   driver configuration.

  **/
  public readonly delegate* unmanaged<EFI_IP4_CONFIG_PROTOCOL*, EFI_EVENT, EFI_EVENT, EFI_STATUS> Start;
  /**
    Stops running the configuration policy for the EFI IPv4 Protocol driver.

    The Stop() function stops the configuration policy for the EFI IPv4 Protocol driver.
    All configuration data will be lost after calling Stop().

    @param  This                   The pointer to the EFI_IP4_CONFIG_PROTOCOL instance.

    @retval EFI_SUCCESS            The configuration policy for the EFI IPv4 Protocol
                                   driver has been stopped.
    @retval EFI_INVALID_PARAMETER  This is NULL.
    @retval EFI_NOT_STARTED        The configuration policy for the EFI IPv4 Protocol
                                   driver was not started.

  **/
  public readonly delegate* unmanaged<EFI_IP4_CONFIG_PROTOCOL*, EFI_STATUS> Stop;
  /**
    Returns the default configuration data (if any) for the EFI IPv4 Protocol driver.

    The GetData() function returns the current configuration data for the EFI IPv4
    Protocol driver after the configuration policy has completed.

    @param  This                   The pointer to the EFI_IP4_CONFIG_PROTOCOL instance.
    @param  IpConfigDataSize       On input, the size of the IpConfigData buffer.
                                   On output, the count of bytes that were written
                                   into the IpConfigData buffer.
    @param  IpConfigData           The pointer to the EFI IPv4 Configuration Protocol
                                   driver configuration data structure.
                                   Type EFI_IP4_IPCONFIG_DATA is defined in
                                   "Related Definitions" below.

    @retval EFI_SUCCESS            The EFI IPv4 Protocol driver configuration has been returned.
    @retval EFI_INVALID_PARAMETER  This is NULL.
    @retval EFI_NOT_STARTED        The configuration policy for the EFI IPv4 Protocol
                                   driver is not running.
    @retval EFI_NOT_READY EFI      IPv4 Protocol driver configuration is still running.
    @retval EFI_ABORTED EFI        IPv4 Protocol driver configuration could not complete.
    @retval EFI_BUFFER_TOO_SMALL   *IpConfigDataSize is smaller than the configuration
                                   data buffer or IpConfigData is NULL.

  **/
  public readonly delegate* unmanaged<EFI_IP4_CONFIG_PROTOCOL*, ulong*, EFI_IP4_IPCONFIG_DATA*, EFI_STATUS> GetData;
}

// extern EFI_GUID  gEfiIp4ConfigProtocolGuid;

// #endif
