using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file defines the EFI Wireless MAC Connection II Protocol.

  Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.6

**/

// #ifndef __EFI_WIFI2_PROTOCOL_H__
// #define __EFI_WIFI2_PROTOCOL_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL_GUID = new GUID(
      0x1b0fb9bf, 0x699d, 0x4fdd, 0xa7, 0xc3, 0x25, 0x46, 0x68, 0x1b, 0xf6, 0x3b);

  // typedef struct _EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL;
}

///
/// EFI_80211_BSS_TYPE
///
public enum EFI_80211_BSS_TYPE
{
  IeeeInfrastructureBSS,
  IeeeIndependentBSS,
  IeeeMeshBSS,
  IeeeAnyBss
}

///
/// EFI_80211_CONNECT_NETWORK_RESULT_CODE
///
public enum EFI_80211_CONNECT_NETWORK_RESULT_CODE
{
  //
  // The connection establishment operation finished successfully.
  //
  ConnectSuccess,
  //
  // The connection was refused by the Network.
  //
  ConnectRefused,
  //
  // The connection establishment operation failed (i.e, Network is not
  // detected).
  //
  ConnectFailed,
  //
  // The connection establishment operation was terminated on timeout.
  //
  ConnectFailureTimeout,
  //
  // The connection establishment operation failed on other reason.
  //
  ConnectFailedReasonUnspecified
}

///
/// EFI_80211_MAC_ADDRESS
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_MAC_ADDRESS
{
  public fixed byte Addr[6];
}

public unsafe partial class EFI
{
  public const ulong EFI_MAX_SSID_LEN = 32;
}

///
/// EFI_80211_SSID
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_SSID
{
  //
  // Length in bytes of the SSId. If zero, ignore SSId field.
  //
  public byte SSIdLen;
  //
  // Specifies the service set identifier.
  //
  public byte[/*EFI_MAX_SSID_LEN*/] SSId;
}

///
/// EFI_80211_GET_NETWORKS_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_GET_NETWORKS_DATA
{
  //
  // The number of EFI_80211_SSID in SSIDList. If zero, SSIDList should be
  // ignored.
  //
  public uint NumOfSSID;
  //
  // The SSIDList is a pointer to an array of EFI_80211_SSID instances. The
  // number of entries is specified by NumOfSSID. The array should only include
  // SSIDs of hidden networks. It is suggested that the caller inputs less than
  // 10 elements in the SSIDList. It is the caller's responsibility to free
  // this buffer.
  //
  public EFI_80211_SSID[/*1*/] SSIDList;
}

///
/// EFI_80211_SUITE_SELECTOR
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_SUITE_SELECTOR
{
  //
  // Organization Unique Identifier, as defined in IEEE 802.11 standard,
  // usually set to 00-0F-AC.
  //
  public fixed byte Oui[3];
  //
  // Suites types, as defined in IEEE 802.11 standard.
  //
  public byte SuiteType;
}

///
/// EFI_80211_AKM_SUITE_SELECTOR
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_AKM_SUITE_SELECTOR
{
  //
  // Indicates the number of AKM suite selectors that are contained in
  // AKMSuiteList. If zero, the AKMSuiteList is ignored.
  //
  public ushort AKMSuiteCount;
  //
  // A variable-length array of AKM suites, as defined in IEEE 802.11 standard,
  // Table 8-101. The number of entries is specified by AKMSuiteCount.
  //
  public EFI_80211_SUITE_SELECTOR[/*1*/] AKMSuiteList;
}

///
/// EFI_80211_CIPHER_SUITE_SELECTOR
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_CIPHER_SUITE_SELECTOR
{
  //
  // Indicates the number of cipher suites that are contained in
  // CipherSuiteList. If zero, the CipherSuiteList is ignored.
  //
  public ushort CipherSuiteCount;
  //
  // A variable-length array of cipher suites, as defined in IEEE 802.11
  // standard, Table 8-99. The number of entries is specified by
  // CipherSuiteCount.
  //
  public EFI_80211_SUITE_SELECTOR[/*1*/] CipherSuiteList;
}

///
/// EFI_80211_NETWORK
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_NETWORK
{
  //
  // Specifies the type of the BSS.
  //
  public EFI_80211_BSS_TYPE BSSType;
  //
  // Specifies the SSID of the BSS.
  //
  public EFI_80211_SSID SSId;
  //
  // Pointer to the AKM suites supported in the wireless network.
  //
  public EFI_80211_AKM_SUITE_SELECTOR* AKMSuite;
  //
  // Pointer to the cipher suites supported in the wireless network.
  //
  public EFI_80211_CIPHER_SUITE_SELECTOR* CipherSuite;
}

///
/// EFI_80211_NETWORK_DESCRIPTION
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_NETWORK_DESCRIPTION
{
  //
  // Specifies the found wireless network.
  //
  public EFI_80211_NETWORK Network;
  //
  // Indicates the network quality as a value between 0 to 100, where 100
  // indicates the highest network quality.
  //
  public byte NetworkQuality;
}

///
/// EFI_80211_GET_NETWORKS_RESULT
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_GET_NETWORKS_RESULT
{
  //
  // The number of EFI_80211_NETWORK_DESCRIPTION in NetworkDesc. If zero,
  // NetworkDesc should be ignored.
  //
  public byte NumOfNetworkDesc;
  //
  // The NetworkDesc is a pointer to an array of EFI_80211_NETWORK_DESCRIPTION
  // instances. It is caller's responsibility to free this buffer.
  //
  public EFI_80211_NETWORK_DESCRIPTION[/*1*/] NetworkDesc;
}

///
/// EFI_80211_GET_NETWORKS_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_GET_NETWORKS_TOKEN
{
  //
  // If the status code returned by GetNetworks() is EFI_SUCCESS, then this
  // Event will be signaled after the Status field is updated by the EFI
  // Wireless MAC Connection Protocol II driver. The type of Event must be
  // EFI_NOTIFY_SIGNAL.
  //
  public EFI_EVENT Event;
  //
  // Will be set to one of the following values:
  // EFI_SUCCESS: The operation completed successfully.
  // EFI_NOT_FOUND: Failed to find available wireless networks.
  // EFI_DEVICE_ERROR: An unexpected network or system error occurred.
  // EFI_ACCESS_DENIED: The operation is not completed due to some underlying
  // hardware or software state.
  // EFI_NOT_READY: The operation is started but not yet completed.
  //
  public EFI_STATUS Status;
  //
  // Pointer to the input data for getting networks.
  //
  public EFI_80211_GET_NETWORKS_DATA* Data;
  //
  // Indicates the scan result. It is caller's responsibility to free this
  // buffer.
  //
  public EFI_80211_GET_NETWORKS_RESULT* Result;
}

///
/// EFI_80211_CONNECT_NETWORK_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_CONNECT_NETWORK_DATA
{
  //
  // Specifies the wireless network to connect to.
  //
  public EFI_80211_NETWORK* Network;
  //
  // Specifies a time limit in seconds that is optionally present, after which
  // the connection establishment procedure is terminated by the UNDI driver.
  // This is an optional parameter and may be 0. Values of 5 seconds or higher
  // are recommended.
  //
  public uint FailureTimeout;
}

///
/// EFI_80211_CONNECT_NETWORK_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_CONNECT_NETWORK_TOKEN
{
  //
  // If the status code returned by ConnectNetwork() is EFI_SUCCESS, then this
  // Event will be signaled after the Status field is updated by the EFI
  // Wireless MAC Connection Protocol II driver. The type of Event must be
  // EFI_NOTIFY_SIGNAL.
  //
  public EFI_EVENT Event;
  //
  // Will be set to one of the following values:
  // EFI_SUCCESS: The operation completed successfully.
  // EFI_DEVICE_ERROR: An unexpected network or system error occurred.
  // EFI_ACCESS_DENIED: The operation is not completed due to some underlying
  // hardware or software state.
  // EFI_NOT_READY: The operation is started but not yet completed.
  //
  public EFI_STATUS Status;
  //
  // Pointer to the connection data.
  //
  public EFI_80211_CONNECT_NETWORK_DATA* Data;
  //
  // Indicates the connection state.
  //
  public EFI_80211_CONNECT_NETWORK_RESULT_CODE ResultCode;
}

///
/// EFI_80211_DISCONNECT_NETWORK_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_DISCONNECT_NETWORK_TOKEN
{
  //
  // If the status code returned by DisconnectNetwork() is EFI_SUCCESS, then
  // this Event will be signaled after the Status field is updated by the EFI
  // Wireless MAC Connection Protocol II driver. The type of Event must be
  // EFI_NOTIFY_SIGNAL.
  //
  public EFI_EVENT Event;
  //
  // Will be set to one of the following values:
  // EFI_SUCCESS: The operation completed successfully
  // EFI_DEVICE_ERROR: An unexpected network or system error occurred.
  // EFI_ACCESS_DENIED: The operation is not completed due to some underlying
  // hardware or software state.
  //
  public EFI_STATUS Status;
}

// /**
//   Request a survey of potential wireless networks that administrator can later
//   elect to try to join.
// 
//   @param[in]  This                Pointer to the
//                                   EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL
//                                   instance.
//   @param[in]  Token               Pointer to the token for getting wireless
//                                   network.
// 
//   @retval EFI_SUCCESS             The operation started, and an event will
//                                   eventually be raised for the caller.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is
//                                   TRUE:
//                                   This is NULL.
//                                   Token is NULL.
//   @retval EFI_UNSUPPORTED         One or more of the input parameters is not
//                                   supported by this implementation.
//   @retval EFI_ALREADY_STARTED     The operation of getting wireless network is
//                                   already started.
//   @retval EFI_OUT_OF_RESOURCES    Required system resources could not be
//                                   allocated.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_WIRELESS_MAC_CONNECTION_II_GET_NETWORKS)(
//   IN EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL          *This,
//   IN EFI_80211_GET_NETWORKS_TOKEN                     *Token
//   );

// /**
//   Connect a wireless network specified by a particular SSID, BSS type and
//   Security type.
// 
//   @param[in]  This                Pointer to the
//                                   EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL
//                                   instance.
//   @param[in]  Token               Pointer to the token for connecting wireless
//                                   network.
// 
//   @retval EFI_SUCCESS             The operation started successfully. Results
//                                   will be notified eventually.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is
//                                   TRUE:
//                                   This is NULL.
//                                   Token is NULL.
//   @retval EFI_UNSUPPORTED         One or more of the input parameters are not
//                                   supported by this implementation.
//   @retval EFI_ALREADY_STARTED     The connection process is already started.
//   @retval EFI_NOT_FOUND           The specified wireless network is not found.
//   @retval EFI_OUT_OF_RESOURCES    Required system resources could not be
//                                   allocated.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_WIRELESS_MAC_CONNECTION_II_CONNECT_NETWORK)(
//   IN EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL          *This,
//   IN EFI_80211_CONNECT_NETWORK_TOKEN                  *Token
//   );

// /**
//   Request a disconnection with current connected wireless network.
// 
//   @param[in]  This                Pointer to the
//                                   EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL
//                                   instance.
//   @param[in]  Token               Pointer to the token for disconnecting
//                                   wireless network.
// 
//   @retval EFI_SUCCESS             The operation started successfully. Results
//                                   will be notified eventually.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is
//                                   TRUE:
//                                   This is NULL.
//                                   Token is NULL.
//   @retval EFI_UNSUPPORTED         One or more of the input parameters are not
//                                   supported by this implementation.
//   @retval EFI_NOT_FOUND           Not connected to a wireless network.
//   @retval EFI_OUT_OF_RESOURCES    Required system resources could not be
//                                   allocated.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_WIRELESS_MAC_CONNECTION_II_DISCONNECT_NETWORK)(
//   IN EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL          *This,
//   IN EFI_80211_DISCONNECT_NETWORK_TOKEN               *Token
//   );

///
/// The EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL provides network management
/// service interfaces for 802.11 network stack. It is used by network
/// applications (and drivers) to establish wireless connection with a wireless
/// network.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL
{
  public readonly delegate* unmanaged</* IN */EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL* /*This*/,/* IN */EFI_80211_GET_NETWORKS_TOKEN* /*Token*/, EFI_STATUS> /*EFI_WIRELESS_MAC_CONNECTION_II_GET_NETWORKS*/ GetNetworks;
  public readonly delegate* unmanaged</* IN */EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL* /*This*/,/* IN */EFI_80211_CONNECT_NETWORK_TOKEN* /*Token*/, EFI_STATUS> /*EFI_WIRELESS_MAC_CONNECTION_II_CONNECT_NETWORK*/ ConnectNetwork;
  public readonly delegate* unmanaged</* IN */EFI_WIRELESS_MAC_CONNECTION_II_PROTOCOL* /*This*/,/* IN */EFI_80211_DISCONNECT_NETWORK_TOKEN* /*Token*/, EFI_STATUS> /*EFI_WIRELESS_MAC_CONNECTION_II_DISCONNECT_NETWORK*/ DisconnectNetwork;
}

// extern EFI_GUID  gEfiWiFi2ProtocolGuid;

// #endif
