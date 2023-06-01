namespace Uefi;
/** @file
  This file provides management service interfaces of 802.11 MAC layer. It is used by
  network applications (and drivers) to establish wireless connection with an access
  point (AP).

  Copyright (c) 2015 - 2016, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.5

**/

// #ifndef __EFI_WIFI_PROTOCOL_H__
// #define __EFI_WIFI_PROTOCOL_H__

// #include <Protocol/WiFi2.h>

public static EFI_GUID EFI_WIRELESS_MAC_CONNECTION_PROTOCOL_GUID = new GUID(
    0xda55bc9, 0x45f8, 0x4bb4, new byte[] { 0x87, 0x19, 0x52, 0x24, 0xf1, 0x8a, 0x4d, 0x45 });

// typedef struct _EFI_WIRELESS_MAC_CONNECTION_PROTOCOL EFI_WIRELESS_MAC_CONNECTION_PROTOCOL;

///
/// EFI_80211_ACC_NET_TYPE
///
public enum EFI_80211_ACC_NET_TYPE
{
  IeeePrivate = 0,
  IeeePrivatewithGuest = 1,
  IeeeChargeablePublic = 2,
  IeeeFreePublic = 3,
  IeeePersonal = 4,
  IeeeEmergencyServOnly = 5,
  IeeeTestOrExp = 14,
  IeeeWildcard = 15
}

///
/// EFI_80211_ASSOCIATE_RESULT_CODE
///
public enum EFI_80211_ASSOCIATE_RESULT_CODE
{
  AssociateSuccess,
  AssociateRefusedReasonUnspecified,
  AssociateRefusedCapsMismatch,
  AssociateRefusedExtReason,
  AssociateRefusedAPOutOfMemory,
  AssociateRefusedBasicRatesMismatch,
  AssociateRejectedEmergencyServicesNotSupported,
  AssociateRefusedTemporarily
}

///
/// EFI_80211_SCAN_RESULT_CODE
///
public enum EFI_80211_SCAN_RESULT_CODE
{
  ///
  /// The scan operation finished successfully.
  ///
  ScanSuccess,
  ///
  /// The scan operation is not supported in current implementation.
  ///
  ScanNotSupported
}

///
/// EFI_80211_REASON_CODE
///
public enum EFI_80211_REASON_CODE
{
  Ieee80211UnspecifiedReason = 1,
  Ieee80211PreviousAuthenticateInvalid = 2,
  Ieee80211DeauthenticatedSinceLeaving = 3,
  Ieee80211DisassociatedDueToInactive = 4,
  Ieee80211DisassociatedSinceApUnable = 5,
  Ieee80211Class2FrameNonauthenticated = 6,
  Ieee80211Class3FrameNonassociated = 7,
  Ieee80211DisassociatedSinceLeaving = 8,
  // ...
}

///
/// EFI_80211_DISASSOCIATE_RESULT_CODE
///
public enum EFI_80211_DISASSOCIATE_RESULT_CODE
{
  ///
  /// Disassociation process completed successfully.
  ///
  DisassociateSuccess,
  ///
  /// Disassociation failed due to any input parameter is invalid.
  ///
  DisassociateInvalidParameters
}

///
/// EFI_80211_AUTHENTICATION_TYPE
///
public enum EFI_80211_AUTHENTICATION_TYPE
{
  ///
  /// Open system authentication, admits any STA to the DS.
  ///
  OpenSystem,
  ///
  /// Shared Key authentication relies on WEP to demonstrate knowledge of a WEP
  /// encryption key.
  ///
  SharedKey,
  ///
  /// FT authentication relies on keys derived during the initial mobility domain
  /// association to authenticate the stations.
  ///
  FastBSSTransition,
  ///
  /// SAE authentication uses finite field cryptography to prove knowledge of a shared
  /// password.
  ///
  SAE
}

///
/// EFI_80211_AUTHENTICATION_RESULT_CODE
///
public enum EFI_80211_AUTHENTICATE_RESULT_CODE
{
  AuthenticateSuccess,
  AuthenticateRefused,
  AuthenticateAnticLoggingTokenRequired,
  AuthenticateFiniteCyclicGroupNotSupported,
  AuthenticationRejected,
  AuthenticateInvalidParameter
}

///
/// EFI_80211_ELEMENT_HEADER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ELEMENT_HEADER
{
  ///
  /// A unique element ID defined in IEEE 802.11 specification.
  ///
  public byte ElementID;
  ///
  /// Specifies the number of octets in the element body.
  ///
  public byte Length;
}

///
/// EFI_80211_ELEMENT_REQ
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ELEMENT_REQ
{
  ///
  /// Common header of an element.
  ///
  public EFI_80211_ELEMENT_HEADER Hdr;
  ///
  /// Start of elements that are requested to be included in the Probe Response frame.
  /// The elements are listed in order of increasing element ID.
  ///
  public fixed byte RequestIDs[1];
}

///
/// EFI_80211_ELEMENT_SSID
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ELEMENT_SSID
{
  ///
  /// Common header of an element.
  ///
  public EFI_80211_ELEMENT_HEADER Hdr;
  ///
  /// Service set identifier. If Hdr.Length is zero, this field is ignored.
  ///
  public fixed byte SSId[32];
}

///
/// EFI_80211_SCAN_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_SCAN_DATA
{
  ///
  /// Determines whether infrastructure BSS, IBSS, MBSS, or all, are included in the
  /// scan.
  ///
  public EFI_80211_BSS_TYPE BSSType;
  ///
  /// Indicates a specific or wildcard BSSID. Use all binary 1s to represent all SSIDs.
  ///
  public EFI_80211_MAC_ADDRESS BSSId;
  ///
  /// Length in bytes of the SSId. If zero, ignore SSId field.
  ///
  public byte SSIdLen;
  ///
  /// Specifies the desired SSID or the wildcard SSID. Use NULL to represent all SSIDs.
  ///
  public byte* SSId;
  ///
  /// Indicates passive scanning if TRUE.
  ///
  public bool PassiveMode;
  ///
  /// The delay in microseconds to be used prior to transmitting a Probe frame during
  /// active scanning. If zero, the value can be overridden by an
  /// implementation-dependent default value.
  ///
  public uint ProbeDelay;
  ///
  /// Specifies a list of channels that are examined when scanning for a BSS. If set to
  /// NULL, all valid channels will be scanned.
  ///
  public uint* ChannelList;
  ///
  /// Indicates the minimum time in TU to spend on each channel when scanning. If zero,
  /// the value can be overridden by an implementation-dependent default value.
  ///
  public uint MinChannelTime;
  ///
  /// Indicates the maximum time in TU to spend on each channel when scanning. If zero,
  /// the value can be overridden by an implementation-dependent default value.
  ///
  public uint MaxChannelTime;
  ///
  /// Points to an optionally present element. This is an optional parameter and may be
  /// NULL.
  ///
  public EFI_80211_ELEMENT_REQ* RequestInformation;
  ///
  /// Indicates one or more SSID elements that are optionally present. This is an
  /// optional parameter and may be NULL.
  ///
  public EFI_80211_ELEMENT_SSID* SSIDList;
  ///
  /// Specifies a desired specific access network type or the wildcard access network
  /// type. Use 15 as wildcard access network type.
  ///
  public EFI_80211_ACC_NET_TYPE AccessNetworkType;
  ///
  ///  Specifies zero or more elements. This is an optional parameter and may be NULL.
  ///
  public byte* VendorSpecificInfo;
}

///
/// EFI_80211_COUNTRY_TRIPLET_SUBBAND
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_COUNTRY_TRIPLET_SUBBAND
{
  ///
  /// Indicates the lowest channel number in the subband. It has a positive integer
  /// value less than 201.
  ///
  public byte FirstChannelNum;
  ///
  /// Indicates the number of channels in the subband.
  ///
  public byte NumOfChannels;
  ///
  /// Indicates the maximum power in dBm allowed to be transmitted.
  ///
  public byte MaxTxPowerLevel;
}

///
/// EFI_80211_COUNTRY_TRIPLET_OPERATE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_COUNTRY_TRIPLET_OPERATE
{
  ///
  /// Indicates the operating extension identifier. It has a positive integer value of
  /// 201 or greater.
  ///
  public byte OperatingExtId;
  ///
  /// Index into a set of values for radio equipment set of rules.
  ///
  public byte OperatingClass;
  ///
  /// Specifies aAirPropagationTime characteristics used in BSS operation. Refer the
  /// definition of aAirPropagationTime in IEEE 802.11 specification.
  ///
  public byte CoverageClass;
}

///
/// EFI_80211_COUNTRY_TRIPLET
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_80211_COUNTRY_TRIPLET
{
  ///
  /// The subband triplet.
  ///
  [FieldOffset(0)] public EFI_80211_COUNTRY_TRIPLET_SUBBAND Subband;
  ///
  /// The operating triplet.
  ///
  [FieldOffset(0)] public EFI_80211_COUNTRY_TRIPLET_OPERATE Operating;
}

///
/// EFI_80211_ELEMENT_COUNTRY
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ELEMENT_COUNTRY
{
  ///
  /// Common header of an element.
  ///
  public EFI_80211_ELEMENT_HEADER Hdr;
  ///
  /// Specifies country strings in 3 octets.
  ///
  public fixed byte CountryStr[3];
  ///
  /// Indicates a triplet that repeated in country element. The number of triplets is
  /// determined by the Hdr.Length field.
  ///
  public fixed EFI_80211_COUNTRY_TRIPLET CountryTriplet[1];
}

///
/// EFI_80211_ELEMENT_DATA_RSN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ELEMENT_DATA_RSN
{
  ///
  /// Indicates the version number of the RSNA protocol. Value 1 is defined in current
  /// IEEE 802.11 specification.
  ///
  public ushort Version;
  ///
  /// Specifies the cipher suite selector used by the BSS to protect group address frames.
  ///
  public uint GroupDataCipherSuite;
  ///
  /// Indicates the number of pairwise cipher suite selectors that are contained in
  /// PairwiseCipherSuiteList.
  ///
  // ushort                             PairwiseCipherSuiteCount;
  ///
  /// Contains a series of cipher suite selectors that indicate the pairwise cipher
  /// suites contained in this element.
  ///
  // uint                             PairwiseCipherSuiteList[PairwiseCipherSuiteCount];
  ///
  /// Indicates the number of AKM suite selectors that are contained in AKMSuiteList.
  ///
  // ushort                             AKMSuiteCount;
  ///
  /// Contains a series of AKM suite selectors that indicate the AKM suites contained in
  /// this element.
  ///
  // uint                             AKMSuiteList[AKMSuiteCount];
  ///
  /// Indicates requested or advertised capabilities.
  ///
  // ushort                             RSNCapabilities;
  ///
  /// Indicates the number of PKMIDs in the PMKIDList.
  ///
  // ushort                             PMKIDCount;
  ///
  /// Contains zero or more PKMIDs that the STA believes to be valid for the destination
  /// AP.
  // byte                              PMKIDList[PMKIDCount][16];
  ///
  /// Specifies the cipher suite selector used by the BSS to protect group addressed
  /// robust management frames.
  ///
  // uint                             GroupManagementCipherSuite;
}

///
/// EFI_80211_ELEMENT_RSN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ELEMENT_RSN
{
  ///
  /// Common header of an element.
  ///
  public EFI_80211_ELEMENT_HEADER Hdr;
  ///
  /// Points to RSN element. The size of a RSN element is limited to 255 octets.
  ///
  public EFI_80211_ELEMENT_DATA_RSN* Data;
}

///
/// EFI_80211_ELEMENT_EXT_CAP
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ELEMENT_EXT_CAP
{
  ///
  /// Common header of an element.
  ///
  public EFI_80211_ELEMENT_HEADER Hdr;
  ///
  /// Indicates the capabilities being advertised by the STA transmitting the element.
  /// This is a bit field with variable length. Refer to IEEE 802.11 specification for
  /// bit value.
  ///
  public fixed byte Capabilities[1];
}

///
/// EFI_80211_BSS_DESCRIPTION
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_BSS_DESCRIPTION
{
  ///
  /// Indicates a specific BSSID of the found BSS.
  ///
  public EFI_80211_MAC_ADDRESS BSSId;
  ///
  /// Specifies the SSID of the found BSS. If NULL, ignore SSIdLen field.
  ///
  public byte* SSId;
  ///
  /// Specifies the SSID of the found BSS. If NULL, ignore SSIdLen field.
  ///
  public byte SSIdLen;
  ///
  /// Specifies the type of the found BSS.
  ///
  public EFI_80211_BSS_TYPE BSSType;
  ///
  /// The beacon period in TU of the found BSS.
  ///
  public ushort BeaconPeriod;
  ///
  /// The timestamp of the received frame from the found BSS.
  ///
  public ulong Timestamp;
  ///
  /// The advertised capabilities of the BSS.
  ///
  public ushort CapabilityInfo;
  ///
  /// The set of data rates that shall be supported by all STAs that desire to join this
  /// BSS.
  ///
  public byte* BSSBasicRateSet;
  ///
  /// The set of data rates that the peer STA desires to use for communication within
  /// the BSS.
  ///
  public byte* OperationalRateSet;
  ///
  /// The information required to identify the regulatory domain in which the peer STA
  /// is located.
  ///
  public EFI_80211_ELEMENT_COUNTRY* Country;
  ///
  /// The cipher suites and AKM suites supported in the BSS.
  ///
  public EFI_80211_ELEMENT_RSN RSN;
  ///
  /// Specifies the RSSI of the received frame.
  ///
  public byte RSSI;
  ///
  /// Specifies the RCPI of the received frame.
  ///
  public byte RCPIMeasurement;
  ///
  /// Specifies the RSNI of the received frame.
  ///
  public byte RSNIMeasurement;
  ///
  /// Specifies the elements requested by the request element of the Probe Request frame.
  /// This is an optional parameter and may be NULL.
  ///
  public byte* RequestedElements;
  ///
  /// Specifies the BSS membership selectors that represent the set of features that
  /// shall be supported by all STAs to join this BSS.
  ///
  public byte* BSSMembershipSelectorSet;
  ///
  /// Specifies the parameters within the Extended Capabilities element that are
  /// supported by the MAC entity. This is an optional parameter and may be NULL.
  ///
  public EFI_80211_ELEMENT_EXT_CAP* ExtCapElement;
}

///
/// EFI_80211_SUBELEMENT_INFO
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_SUBELEMENT_INFO
{
  ///
  /// Indicates the unique identifier within the containing element or sub-element.
  ///
  public byte SubElementID;
  ///
  /// Specifies the number of octets in the Data field.
  ///
  public byte Length;
  ///
  /// A variable length data buffer.
  ///
  public fixed byte Data[1];
}

///
/// EFI_80211_MULTIPLE_BSSID
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_MULTIPLE_BSSID
{
  ///
  /// Common header of an element.
  ///
  public EFI_80211_ELEMENT_HEADER Hdr;
  ///
  /// Indicates the maximum number of BSSIDs in the multiple BSSID set. When Indicator
  /// is set to n, 2n is the maximum number.
  ///
  public byte Indicator;
  ///
  /// Contains zero or more sub-elements.
  ///
  public fixed EFI_80211_SUBELEMENT_INFO SubElement[1];
}

///
/// EFI_80211_BSS_DESP_PILOT
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_BSS_DESP_PILOT
{
  ///
  /// Indicates a specific BSSID of the found BSS.
  ///
  public EFI_80211_MAC_ADDRESS BSSId;
  ///
  /// Specifies the type of the found BSS.
  ///
  public EFI_80211_BSS_TYPE BSSType;
  ///
  /// One octet field to report condensed capability information.
  ///
  public byte ConCapInfo;
  ///
  /// Two octet's field to report condensed country string.
  ///
  public fixed byte ConCountryStr[2];
  ///
  /// Indicates the operating class value for the operating channel.
  ///
  public byte OperatingClass;
  ///
  /// Indicates the operating channel.
  ///
  public byte Channel;
  ///
  /// Indicates the measurement pilot interval in TU.
  ///
  public byte Interval;
  ///
  /// Indicates that the BSS is within a multiple BSSID set.
  ///
  public EFI_80211_MULTIPLE_BSSID* MultipleBSSID;
  ///
  /// Specifies the RCPI of the received frame.
  ///
  public byte RCPIMeasurement;
  ///
  /// Specifies the RSNI of the received frame.
  ///
  public byte RSNIMeasurement;
}

///
/// EFI_80211_SCAN_RESULT
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_SCAN_RESULT
{
  ///
  /// The number of EFI_80211_BSS_DESCRIPTION in BSSDespSet. If zero, BSSDespSet should
  /// be ignored.
  ///
  public ulong NumOfBSSDesp;
  ///
  /// Points to zero or more instances of EFI_80211_BSS_DESCRIPTION.
  ///
  public EFI_80211_BSS_DESCRIPTION** BSSDespSet;
  ///
  /// The number of EFI_80211_BSS_DESP_PILOT in BSSDespFromPilotSet. If zero,
  /// BSSDespFromPilotSet should be ignored.
  ///
  public ulong NumofBSSDespFromPilot;
  ///
  /// Points to zero or more instances of EFI_80211_BSS_DESP_PILOT.
  ///
  public EFI_80211_BSS_DESP_PILOT** BSSDespFromPilotSet;
  ///
  /// Specifies zero or more elements. This is an optional parameter and may be NULL.
  ///
  public byte* VendorSpecificInfo;
}

///
/// EFI_80211_SCAN_DATA_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_SCAN_DATA_TOKEN
{
  ///
  /// This Event will be signaled after the Status field is updated by the EFI Wireless
  /// MAC Connection Protocol driver. The type of Event must be EFI_NOTIFY_SIGNAL.
  ///
  public EFI_EVENT Event;
  ///
  /// Will be set to one of the following values:
  ///   EFI_SUCCESS:       Scan operation completed successfully.
  ///   EFI_NOT_FOUND:     Failed to find available BSS.
  ///   EFI_DEVICE_ERROR:  An unexpected network or system error occurred.
  ///   EFI_ACCESS_DENIED: The scan operation is not completed due to some underlying
  ///                      hardware or software state.
  ///   EFI_NOT_READY:     The scan operation is started but not yet completed.
  public EFI_STATUS Status;
  ///
  /// Pointer to the scan data.
  ///
  public EFI_80211_SCAN_DATA* Data;
  ///
  /// Indicates the scan state.
  ///
  public EFI_80211_SCAN_RESULT_CODE ResultCode;
  ///
  /// Indicates the scan result. It is caller's responsibility to free this buffer.
  ///
  public EFI_80211_SCAN_RESULT* Result;
}

///
/// EFI_80211_ELEMENT_SUPP_CHANNEL_TUPLE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ELEMENT_SUPP_CHANNEL_TUPLE
{
  ///
  /// The first channel number in a subband of supported channels.
  ///
  public byte FirstChannelNumber;
  ///
  /// The number of channels in a subband of supported channels.
  ///
  public byte NumberOfChannels;
}

///
/// EFI_80211_ELEMENT_SUPP_CHANNEL
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ELEMENT_SUPP_CHANNEL
{
  ///
  /// Common header of an element.
  ///
  public EFI_80211_ELEMENT_HEADER Hdr;
  ///
  /// Indicates one or more tuples of (first channel, number of channels).
  ///
  public fixed EFI_80211_ELEMENT_SUPP_CHANNEL_TUPLE Subband[1];
}

///
/// EFI_80211_ASSOCIATE_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ASSOCIATE_DATA
{
  ///
  /// Specifies the address of the peer MAC entity to associate with.
  ///
  public EFI_80211_MAC_ADDRESS BSSId;
  ///
  /// Specifies the requested operational capabilities to the AP in 2 octets.
  ///
  public ushort CapabilityInfo;
  ///
  /// Specifies a time limit in TU, after which the associate procedure is terminated.
  ///
  public uint FailureTimeout;
  ///
  /// Specifies if in power save mode, how often the STA awakes and listens for the next
  /// beacon frame in TU.
  ///
  public uint ListenInterval;
  ///
  /// Indicates a list of channels in which the STA is capable of operating.
  ///
  public EFI_80211_ELEMENT_SUPP_CHANNEL* Channels;
  ///
  /// The cipher suites and AKM suites selected by the STA.
  ///
  public EFI_80211_ELEMENT_RSN RSN;
  ///
  /// Specifies the parameters within the Extended Capabilities element that are
  /// supported by the MAC entity.  This is an optional parameter and may be NULL.
  ///
  public EFI_80211_ELEMENT_EXT_CAP* ExtCapElement;
  ///
  /// Specifies zero or more elements. This is an optional parameter and may be NULL.
  ///
  public byte* VendorSpecificInfo;
}

///
/// EFI_80211_ELEMENT_TIMEOUT_VAL
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ELEMENT_TIMEOUT_VAL
{
  ///
  /// Common header of an element.
  ///
  public EFI_80211_ELEMENT_HEADER Hdr;
  ///
  /// Specifies the timeout interval type.
  ///
  public byte Type;
  ///
  /// Specifies the timeout interval value.
  ///
  public uint Value;
}

///
/// EFI_80211_ASSOCIATE_RESULT
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ASSOCIATE_RESULT
{
  ///
  /// Specifies the address of the peer MAC entity from which the association request
  /// was received.
  ///
  public EFI_80211_MAC_ADDRESS BSSId;
  ///
  /// Specifies the operational capabilities advertised by the AP.
  ///
  public ushort CapabilityInfo;
  ///
  /// Specifies the association ID value assigned by the AP.
  ///
  public ushort AssociationID;
  ///
  /// Indicates the measured RCPI of the corresponding association request frame. It is
  /// an optional parameter and is set to zero if unavailable.
  ///
  public byte RCPIValue;
  ///
  /// Indicates the measured RSNI at the time the corresponding association request
  /// frame was received. It is an optional parameter and is set to zero if unavailable.
  ///
  public byte RSNIValue;
  ///
  /// Specifies the parameters within the Extended Capabilities element that are
  /// supported by the MAC entity.  This is an optional parameter and may be NULL.
  ///
  public EFI_80211_ELEMENT_EXT_CAP* ExtCapElement;
  ///
  /// Specifies the timeout interval when the result code is AssociateRefusedTemporarily.
  ///
  public EFI_80211_ELEMENT_TIMEOUT_VAL TimeoutInterval;
  ///
  /// Specifies zero or more elements. This is an optional parameter and may be NULL.
  ///
  public byte* VendorSpecificInfo;
}

///
/// EFI_80211_ASSOCIATE_DATA_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_ASSOCIATE_DATA_TOKEN
{
  ///
  /// This Event will be signaled after the Status field is updated by the EFI Wireless
  /// MAC Connection Protocol driver. The type of Event must be EFI_NOTIFY_SIGNAL.
  ///
  public EFI_EVENT Event;
  ///
  /// Will be set to one of the following values:
  ///   EFI_SUCCESS:      Association operation completed successfully.
  ///   EFI_DEVICE_ERROR: An unexpected network or system error occurred.
  ///
  public EFI_STATUS Status;
  ///
  /// Pointer to the association data.
  ///
  public EFI_80211_ASSOCIATE_DATA* Data;
  ///
  /// Indicates the association state.
  ///
  public EFI_80211_ASSOCIATE_RESULT_CODE ResultCode;
  ///
  /// Indicates the association result. It is caller's responsibility to free this
  /// buffer.
  ///
  public EFI_80211_ASSOCIATE_RESULT* Result;
}

///
/// EFI_80211_DISASSOCIATE_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_DISASSOCIATE_DATA
{
  ///
  /// Specifies the address of the peer MAC entity with which to perform the
  /// disassociation process.
  ///
  public EFI_80211_MAC_ADDRESS BSSId;
  ///
  /// Specifies the reason for initiating the disassociation process.
  ///
  public EFI_80211_REASON_CODE ReasonCode;
  ///
  /// Zero or more elements, may be NULL.
  ///
  public byte* VendorSpecificInfo;
}

///
/// EFI_80211_DISASSOCIATE_DATA_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_DISASSOCIATE_DATA_TOKEN
{
  ///
  /// This Event will be signaled after the Status field is updated by the EFI Wireless
  /// MAC Connection Protocol driver. The type of Event must be EFI_NOTIFY_SIGNAL.
  ///
  public EFI_EVENT Event;
  ///
  /// Will be set to one of the following values:
  ///   EFI_SUCCESS:       Disassociation operation completed successfully.
  ///   EFI_DEVICE_ERROR:  An unexpected network or system error occurred.
  ///   EFI_ACCESS_DENIED: The disassociation operation is not completed due to some
  ///                      underlying hardware or software state.
  ///   EFI_NOT_READY:     The disassociation operation is started but not yet completed.
  ///
  public EFI_STATUS Status;
  ///
  /// Pointer to the disassociation data.
  ///
  public EFI_80211_DISASSOCIATE_DATA* Data;
  ///
  /// Indicates the disassociation state.
  ///
  public EFI_80211_DISASSOCIATE_RESULT_CODE ResultCode;
}

///
/// EFI_80211_AUTHENTICATION_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_AUTHENTICATE_DATA
{
  ///
  /// Specifies the address of the peer MAC entity with which to perform the
  /// authentication process.
  ///
  public EFI_80211_MAC_ADDRESS BSSId;
  ///
  /// Specifies the type of authentication algorithm to use during the authentication
  /// process.
  ///
  public EFI_80211_AUTHENTICATION_TYPE AuthType;
  ///
  /// Specifies a time limit in TU after which the authentication procedure is
  /// terminated.
  ///
  public uint FailureTimeout;
  ///
  /// Specifies the set of elements to be included in the first message of the FT
  /// authentication sequence, may be NULL.
  ///
  public byte* FTContent;
  ///
  /// Specifies the set of elements to be included in the SAE Commit Message or SAE
  /// Confirm Message, may be NULL.
  ///
  public byte* SAEContent;
  ///
  /// Zero or more elements, may be NULL.
  ///
  public byte* VendorSpecificInfo;
}

///
/// EFI_80211_AUTHENTICATION_RESULT
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_AUTHENTICATE_RESULT
{
  ///
  /// Specifies the address of the peer MAC entity from which the authentication request
  /// was received.
  ///
  public EFI_80211_MAC_ADDRESS BSSId;
  ///
  /// Specifies the set of elements to be included in the second message of the FT
  /// authentication sequence, may be NULL.
  ///
  public byte* FTContent;
  ///
  /// Specifies the set of elements to be included in the SAE Commit Message or SAE
  /// Confirm Message, may be NULL.
  ///
  public byte* SAEContent;
  ///
  /// Zero or more elements, may be NULL.
  ///
  public byte* VendorSpecificInfo;
}

///
/// EFI_80211_AUTHENTICATE_DATA_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_AUTHENTICATE_DATA_TOKEN
{
  ///
  /// This Event will be signaled after the Status field is updated by the EFI Wireless
  /// MAC Connection Protocol driver. The type of Event must be EFI_NOTIFY_SIGNAL.
  ///
  public EFI_EVENT Event;
  ///
  /// Will be set to one of the following values:
  ///   EFI_SUCCESS: Authentication operation completed successfully.
  ///   EFI_PROTOCOL_ERROR: Peer MAC entity rejects the authentication.
  ///   EFI_NO_RESPONSE:    Peer MAC entity does not response the authentication request.
  ///   EFI_DEVICE_ERROR:   An unexpected network or system error occurred.
  ///   EFI_ACCESS_DENIED:  The authentication operation is not completed due to some
  ///                       underlying hardware or software state.
  ///   EFI_NOT_READY:      The authentication operation is started but not yet completed.
  ///
  public EFI_STATUS Status;
  ///
  /// Pointer to the authentication data.
  ///
  public EFI_80211_AUTHENTICATE_DATA* Data;
  ///
  /// Indicates the association state.
  ///
  public EFI_80211_AUTHENTICATE_RESULT_CODE ResultCode;
  ///
  /// Indicates the association result. It is caller's responsibility to free this
  /// buffer.
  ///
  public EFI_80211_AUTHENTICATE_RESULT* Result;
}

///
/// EFI_80211_DEAUTHENTICATE_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_DEAUTHENTICATE_DATA
{
  ///
  /// Specifies the address of the peer MAC entity with which to perform the
  /// deauthentication process.
  ///
  public EFI_80211_MAC_ADDRESS BSSId;
  ///
  /// Specifies the reason for initiating the deauthentication process.
  ///
  public EFI_80211_REASON_CODE ReasonCode;
  ///
  /// Zero or more elements, may be NULL.
  ///
  public byte* VendorSpecificInfo;
}

///
/// EFI_80211_DEAUTHENTICATE_DATA_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_80211_DEAUTHENTICATE_DATA_TOKEN
{
  ///
  /// This Event will be signaled after the Status field is updated by the EFI Wireless
  /// MAC Connection Protocol driver. The type of Event must be EFI_NOTIFY_SIGNAL.
  ///
  public EFI_EVENT Event;
  ///
  /// Will be set to one of the following values:
  ///   EFI_SUCCESS:       Deauthentication operation completed successfully.
  ///   EFI_DEVICE_ERROR:  An unexpected network or system error occurred.
  ///   EFI_ACCESS_DENIED: The deauthentication operation is not completed due to some
  ///                      underlying hardware or software state.
  ///   EFI_NOT_READY:     The deauthentication operation is started but not yet
  ///                      completed.
  ///
  public EFI_STATUS Status;
  ///
  /// Pointer to the deauthentication data.
  ///
  public EFI_80211_DEAUTHENTICATE_DATA* Data;
}
















































































































































///
/// The EFI_WIRELESS_MAC_CONNECTION_PROTOCOL is designed to provide management service
/// interfaces for the EFI wireless network stack to establish wireless connection with
/// AP. An EFI Wireless MAC Connection Protocol instance will be installed on each
/// communication device that the EFI wireless network stack runs on.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_WIRELESS_MAC_CONNECTION_PROTOCOL
{
  /**
    Request a survey of potential BSSs that administrator can later elect to try to join.

    The Scan() function returns the description of the set of BSSs detected by the scan
    process. Passive scan operation is performed by default.

    @param[in]  This                Pointer to the EFI_WIRELESS_MAC_CONNECTION_PROTOCOL
                                    instance.
    @param[in]  Data                Pointer to the scan token.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    Data is NULL.
                                    Data->Data is NULL.
    @retval EFI_UNSUPPORTED         One or more of the input parameters are not supported
                                    by this implementation.
    @retval EFI_ALREADY_STARTED     The scan operation is already started.
  **/
  public readonly delegate* unmanaged<EFI_WIRELESS_MAC_CONNECTION_PROTOCOL*, EFI_80211_SCAN_DATA_TOKEN*, EFI_STATUS> Scan;
  /**
    Request an association with a specified peer MAC entity that is within an AP.

    The Associate() function provides the capability for MAC layer to become associated
    with an AP.

    @param[in]  This                Pointer to the EFI_WIRELESS_MAC_CONNECTION_PROTOCOL
                                    instance.
    @param[in]  Data                Pointer to the association token.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    Data is NULL.
                                    Data->Data is NULL.
    @retval EFI_UNSUPPORTED         One or more of the input parameters are not supported
                                    by this implementation.
    @retval EFI_ALREADY_STARTED     The association process is already started.
    @retval EFI_NOT_READY           Authentication is not performed before this association
                                    process.
    @retval EFI_NOT_FOUND           The specified peer MAC entity is not found.
    @retval EFI_OUT_OF_RESOURCES    Required system resources could not be allocated.
  **/
  public readonly delegate* unmanaged<EFI_WIRELESS_MAC_CONNECTION_PROTOCOL*, EFI_80211_ASSOCIATE_DATA_TOKEN*, EFI_STATUS> Associate;
  /**
    Request a disassociation with a specified peer MAC entity.

    The Disassociate() function is invoked to terminate an existing association.
    Disassociation is a notification and cannot be refused by the receiving peer except
    when management frame protection is negotiated and the message integrity check fails.

    @param[in]  This                Pointer to the EFI_WIRELESS_MAC_CONNECTION_PROTOCOL
                                    instance.
    @param[in]  Data                Pointer to the disassociation token.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    Data is NULL.
    @retval EFI_ALREADY_STARTED     The disassociation process is already started.
    @retval EFI_NOT_READY           The disassociation service is invoked to a
                                    nonexistent association relationship.
    @retval EFI_NOT_FOUND           The specified peer MAC entity is not found.
    @retval EFI_OUT_OF_RESOURCES    Required system resources could not be allocated.
  **/
  public readonly delegate* unmanaged<EFI_WIRELESS_MAC_CONNECTION_PROTOCOL*, EFI_80211_DISASSOCIATE_DATA_TOKEN*, EFI_STATUS> Disassociate;
  /**
    Request the process of establishing an authentication relationship with a peer MAC
    entity.

    The Authenticate() function requests authentication with a specified peer MAC entity.
    This service might be time-consuming thus is designed to be invoked independently of
    the association service.

    @param[in]  This                Pointer to the EFI_WIRELESS_MAC_CONNECTION_PROTOCOL
                                    instance.
    @param[in]  Data                Pointer to the authentication token.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    Data is NULL.
                                    Data.Data is NULL.
    @retval EFI_UNSUPPORTED         One or more of the input parameters are not supported
                                    by this implementation.
    @retval EFI_ALREADY_STARTED     The authentication process is already started.
    @retval EFI_NOT_FOUND           The specified peer MAC entity is not found.
    @retval EFI_OUT_OF_RESOURCES    Required system resources could not be allocated.
  **/
  public readonly delegate* unmanaged<EFI_WIRELESS_MAC_CONNECTION_PROTOCOL*, EFI_80211_AUTHENTICATE_DATA_TOKEN*, EFI_STATUS> Authenticate;
  /**
    Invalidate the authentication relationship with a peer MAC entity.

    The Deauthenticate() function requests that the authentication relationship with a
    specified peer MAC entity be invalidated. Deauthentication is a notification and when
    it is sent out the association at the transmitting station is terminated.

    @param[in]  This                Pointer to the EFI_WIRELESS_MAC_CONNECTION_PROTOCOL
                                    instance.
    @param[in]  Data                Pointer to the deauthentication token.

    @retval EFI_SUCCESS             The operation completed successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    This is NULL.
                                    Data is NULL.
                                    Data.Data is NULL.
    @retval EFI_ALREADY_STARTED     The deauthentication process is already started.
    @retval EFI_NOT_READY           The deauthentication service is invoked to a
                                    nonexistent association or authentication relationship.
    @retval EFI_NOT_FOUND           The specified peer MAC entity is not found.
    @retval EFI_OUT_OF_RESOURCES    Required system resources could not be allocated.
  **/
  public readonly delegate* unmanaged<EFI_WIRELESS_MAC_CONNECTION_PROTOCOL*, EFI_80211_DEAUTHENTICATE_DATA_TOKEN*, EFI_STATUS> Deauthenticate;
}

// extern EFI_GUID  gEfiWiFiProtocolGuid;

// #endif
