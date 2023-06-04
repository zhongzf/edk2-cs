using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  IPMI 2.0 definitions from the IPMI Specification Version 2.0, Revision 1.1.

  This file contains all NetFn Transport commands, including:
    IPM LAN Commands (Chapter 23)
    IPMI Serial/Modem Commands (Chapter 25)
    SOL Commands (Chapter 26)
    Command Forwarding Commands (Chapter 35b)

  See IPMI specification, Appendix G, Command Assignments
  and Appendix H, Sub-function Assignments.

  Copyright (c) 1999 - 2018, Intel Corporation. All rights reserved.<BR>
  Copyright (C) 2023 Advanced Micro Devices, Inc. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _IPMI_NET_FN_TRANSPORT_H_
// #define _IPMI_NET_FN_TRANSPORT_H_

public unsafe partial class EFI
{
  // #pragma pack(1)
  //
  // Net function definition for Transport command
  //
  public const ulong IPMI_NETFN_TRANSPORT = 0x0C;

  //
  //  Below is Definitions for IPM LAN Commands (Chapter 23)
  //

  //
  //  Definitions for Set Lan Configuration Parameters command
  //
  public const ulong IPMI_TRANSPORT_SET_LAN_CONFIG_PARAMETERS = 0x01;

  //
  //  Constants and Structure definitions for "Set Lan Configuration Parameters" command to follow here
  //
}

//
// LAN Management Structure
//
public enum IPMI_LAN_OPTION_TYPE
{
  IpmiLanReserved1,
  IpmiLanReserved2,
  IpmiLanAuthType,
  IpmiLanIpAddress,
  IpmiLanIpAddressSource,
  IpmiLanMacAddress,
  IpmiLanSubnetMask,
  IpmiLanIpv4HeaderParam,
  IpmiLanPrimaryRcmpPort,
  IpmiLanSecondaryRcmpPort,
  IpmiLanBmcGeneratedArpCtrl,
  IpmiLanArpInterval,
  IpmiLanDefaultGateway,
  IpmiLanDefaultGatewayMac,
  IpmiLanBackupGateway,
  IpmiLanBackupGatewayMac,
  IpmiLanCommunityString,
  IpmiLanReserved3,
  IpmiLanDestinationType,
  IpmiLanDestinationAddress,
  IpmiLanVlanId = 0x14,
  IpmiIpv4OrIpv6Support = 0x32,
  IpmiIpv4OrIpv6AddressEnable,
  IpmiIpv6HdrStatTrafficClass,
  IpmiIpv6HdrStatHopLimit,
  IpmiIpv6HdrFlowLabel,
  IpmiIpv6Status,
  IpmiIpv6StaticAddress,
  IpmiIpv6DhcpStaticDuidLen,
  IpmiIpv6DhcpStaticDuid,
  IpmiIpv6DhcpAddress,
  IpmiIpv6DhcpDynamicDuidLen,
  IpmiIpv6DhcpDynamicDuid,
  IpmiIpv6RouterConfig = 0x40,
  IpmiIpv6StaticRouter1IpAddr,
  IpmiIpv6DynamicRouterIpAddr = 0x4a
}

//
// IP Address Source
//
public enum IPMI_IP_ADDRESS_SRC
{
  IpmiUnspecified,
  IpmiStaticAddrsss,
  IpmiDynamicAddressBmcDhcp,
  IpmiDynamicAddressBiosDhcp,
  IpmiDynamicAddressBmcNonDhcp
}

//
// Destination Type
//
public enum IPMI_LAN_DEST_TYPE_DEST_TYPE
{
  IpmiPetTrapDestination,
  IpmiDirectedEventDestination,
  IpmiReserved1,
  IpmiReserved2,
  IpmiReserved3,
  IpmiReserved4,
  IpmiReserved5,
  IpmiOem1,
  IpmiOem2
}

//
// Destination address format
//
public enum IPMI_LAN_DEST_ADDRESS_VERSION
{
  IpmiDestinationAddressVersion4,
  IpmiDestinationAddressVersion6
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_AUTH_TYPE
{
  /*   struct { */
  [FieldOffset(0)] public byte NoAuth; // = 1;
  [FieldOffset(0)] public byte MD2Auth; // = 1;
  [FieldOffset(0)] public byte MD5Auth; // = 1;
  [FieldOffset(0)] public byte Reserved1; // = 1;
  [FieldOffset(0)] public byte StraightPswd; // = 1;
  [FieldOffset(0)] public byte OemType; // = 1;
  [FieldOffset(0)] public byte Reserved2; // = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_IP_ADDRESS
{
  public fixed byte IpAddress[4];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_IP_ADDRESS_SRC
{
  /*   struct { */
  [FieldOffset(0)] public byte AddressSrc; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_MAC_ADDRESS
{
  public fixed byte MacAddress[6];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_SUBNET_MASK
{
  public fixed byte IpAddress[4];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_IPV4_HDR_PARAM_DATA_2
{
  /*   struct { */
  [FieldOffset(0)] public byte IpFlag; // = 3;
  [FieldOffset(0)] public byte Reserved; // = 5;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_IPV4_HDR_PARAM_DATA_3
{
  /*   struct { */
  [FieldOffset(0)] public byte Precedence; // = 3;
  [FieldOffset(0)] public byte Reserved; // = 1;
  [FieldOffset(0)] public byte ServiceType; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_IPV4_HDR_PARAM
{
  public byte TimeToLive;
  public IPMI_LAN_IPV4_HDR_PARAM_DATA_2 Data2;
  public IPMI_LAN_IPV4_HDR_PARAM_DATA_3 Data3;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_RCMP_PORT
{
  public byte RcmpPortMsb;
  public byte RcmpPortLsb;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_BMC_GENERATED_ARP_CONTROL
{
  /*   struct { */
  [FieldOffset(0)] public byte EnableBmcArpResponse; // = 1;
  [FieldOffset(0)] public byte EnableBmcGratuitousArp; // = 1;
  [FieldOffset(0)] public byte Reserved; // = 6;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_ARP_INTERVAL
{
  public byte ArpInterval;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_DEFAULT_GATEWAY
{
  public fixed byte IpAddress[4];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_COMMUNITY_STRING
{
  public fixed byte Data[18];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_SET_SELECTOR
{
  /*   struct { */
  [FieldOffset(0)] public byte DestinationSelector; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_DEST_TYPE_DESTINATION_TYPE
{
  /*   struct { */
  [FieldOffset(0)] public byte DestinationType; // = 3;
  [FieldOffset(0)] public byte Reserved; // = 4;
  [FieldOffset(0)] public byte AlertAcknowledged; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_DEST_TYPE
{
  public IPMI_LAN_SET_SELECTOR SetSelector;
  public IPMI_LAN_DEST_TYPE_DESTINATION_TYPE DestinationType;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_ADDRESS_FORMAT
{
  /*   struct { */
  [FieldOffset(0)] public byte AlertingIpAddressSelector; // = 4;
  [FieldOffset(0)] public byte AddressFormat; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_GATEWAY_SELECTOR
{
  /*   struct { */
  [FieldOffset(0)] public byte UseDefaultGateway; // = 1;
  [FieldOffset(0)] public byte Reserved2; // = 7;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_DEST_ADDRESS
{
  public IPMI_LAN_SET_SELECTOR SetSelector;
  public IPMI_LAN_ADDRESS_FORMAT AddressFormat;
  public IPMI_LAN_GATEWAY_SELECTOR GatewaySelector;
  public IPMI_LAN_IP_ADDRESS AlertingIpAddress;
  public IPMI_LAN_MAC_ADDRESS AlertingMacAddress;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_VLAN_ID_DATA1
{
  public byte VanIdLowByte;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_VLAN_ID_DATA2
{
  /*   struct { */
  [FieldOffset(0)] public byte VanIdHighByte; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 3;
  [FieldOffset(0)] public byte Enabled; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_VLAN_ID
{
  public IPMI_LAN_VLAN_ID_DATA1 Data1;
  public IPMI_LAN_VLAN_ID_DATA2 Data2;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_OPTIONS
{
  [FieldOffset(0)] public IPMI_LAN_AUTH_TYPE IpmiLanAuthType;
  [FieldOffset(0)] public IPMI_LAN_IP_ADDRESS IpmiLanIpAddress;
  [FieldOffset(0)] public IPMI_LAN_IP_ADDRESS_SRC IpmiLanIpAddressSrc;
  [FieldOffset(0)] public IPMI_LAN_MAC_ADDRESS IpmiLanMacAddress;
  [FieldOffset(0)] public IPMI_LAN_SUBNET_MASK IpmiLanSubnetMask;
  [FieldOffset(0)] public IPMI_LAN_IPV4_HDR_PARAM IpmiLanIpv4HdrParam;
  [FieldOffset(0)] public IPMI_LAN_RCMP_PORT IpmiLanPrimaryRcmpPort;
  [FieldOffset(0)] public IPMI_LAN_BMC_GENERATED_ARP_CONTROL IpmiLanArpControl;
  [FieldOffset(0)] public IPMI_LAN_ARP_INTERVAL IpmiLanArpInterval;
  [FieldOffset(0)] public IPMI_LAN_COMMUNITY_STRING IpmiLanCommunityString;
  [FieldOffset(0)] public IPMI_LAN_DEST_TYPE IpmiLanDestType;
  [FieldOffset(0)] public IPMI_LAN_DEST_ADDRESS IpmiLanDestAddress;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_IPV6_ADDRESS_SOURCE_TYPE
{
  /*   struct { */
  [FieldOffset(0)] public byte AddressSourceType; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 3;
  [FieldOffset(0)] public byte EnableStatus; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_LAN_IPV6_STATIC_ADDRESS
{
  public byte SetSelector;
  public IPMI_LAN_IPV6_ADDRESS_SOURCE_TYPE AddressSourceType;
  public fixed byte Ipv6Address[16];
  public byte AddressPrefixLen;
  public byte AddressStatus;
}

//
//  Set in progress parameter
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_LAN_SET_IN_PROGRESS
{
  /*   struct { */
  [FieldOffset(0)] public byte SetInProgress; // = 2;
  [FieldOffset(0)] public byte Reserved; // = 6;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SET_LAN_CONFIG_CHANNEL_NUM
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNo; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_LAN_CONFIGURATION_PARAMETERS_COMMAND_REQUEST
{
  public IPMI_SET_LAN_CONFIG_CHANNEL_NUM ChannelNumber;
  public byte ParameterSelector;
  public byte[] ParameterData;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get Lan Configuration Parameters command
  //
  public const ulong IPMI_TRANSPORT_GET_LAN_CONFIG_PARAMETERS = 0x02;
}

//
//  Constants and Structure definitions for "Get Lan Configuration Parameters" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_LAN_CONFIG_CHANNEL_NUM
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNo; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 3;
  [FieldOffset(0)] public byte GetParameter; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_LAN_CONFIGURATION_PARAMETERS_REQUEST
{
  public IPMI_GET_LAN_CONFIG_CHANNEL_NUM ChannelNumber;
  public byte ParameterSelector;
  public byte SetSelector;
  public byte BlockSelector;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_LAN_CONFIGURATION_PARAMETERS_RESPONSE
{
  public byte CompletionCode;
  public byte ParameterRevision;
  public byte[] ParameterData;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Suspend BMC ARPs command
  //
  public const ulong IPMI_TRANSPORT_SUSPEND_BMC_ARPS = 0x03;

  //
  //  Constants and Structure definitions for "Suspend BMC ARPs" command to follow here
  //

  //
  //  Definitions for Get IP-UDP-RMCP Statistics command
  //
  public const ulong IPMI_TRANSPORT_GET_PACKET_STATISTICS = 0x04;

  //
  //  Constants and Structure definitions for "Get IP-UDP-RMCP Statistics" command to follow here
  //

  //
  //  Below is Definitions for IPMI Serial/Modem Commands (Chapter 25)
  //

  //
  //  Definitions for Set Serial/Modem Configuration command
  //
  public const ulong IPMI_TRANSPORT_SET_SERIAL_CONFIGURATION = 0x10;

  //
  //  Constants and Structure definitions for "Set Serial/Modem Configuration" command to follow here
  //
}

//
// EMP OPTION DATA
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_AUTH_TYPE
{
  /*   struct { */
  [FieldOffset(0)] public byte NoAuthentication; // = 1;
  [FieldOffset(0)] public byte MD2Authentication; // = 1;
  [FieldOffset(0)] public byte MD5Authentication; // = 1;
  [FieldOffset(0)] public byte Reserved1; // = 1;
  [FieldOffset(0)] public byte StraightPassword; // = 1;
  [FieldOffset(0)] public byte OemProprietary; // = 1;
  [FieldOffset(0)] public byte Reservd2; // = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_CONNECTION_TYPE
{
  /*   struct { */
  [FieldOffset(0)] public byte EnableBasicMode; // = 1;
  [FieldOffset(0)] public byte EnablePPPMode; // = 1;
  [FieldOffset(0)] public byte EnableTerminalMode; // = 1;
  [FieldOffset(0)] public byte Reserved1; // = 2;
  [FieldOffset(0)] public byte SnoopOsPPPNegotiation; // = 1;
  [FieldOffset(0)] public byte Reserved2; // = 1;
  [FieldOffset(0)] public byte DirectConnect; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_INACTIVITY_TIMEOUT
{
  /*   struct { */
  [FieldOffset(0)] public byte InactivityTimeout; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_CHANNEL_CALLBACK_CONTROL_ENABLE
{
  /*   struct { */
  [FieldOffset(0)] public byte IpmiCallback; // = 1;
  [FieldOffset(0)] public byte CBCPCallback; // = 1;
  [FieldOffset(0)] public byte Reserved; // = 6;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_CHANNEL_CALLBACK_CONTROL_CBCP
{
  /*   struct { */
  [FieldOffset(0)] public byte CbcpEnableNoCallback; // = 1;
  [FieldOffset(0)] public byte CbcpEnablePreSpecifiedNumber; // = 1;
  [FieldOffset(0)] public byte CbcpEnableUserSpecifiedNumber; // = 1;
  [FieldOffset(0)] public byte CbcpEnableCallbackFromList; // = 1;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_EMP_CHANNEL_CALLBACK_CONTROL
{
  public IPMI_CHANNEL_CALLBACK_CONTROL_ENABLE CallbackEnable;
  public IPMI_CHANNEL_CALLBACK_CONTROL_CBCP CBCPNegotiation;
  public byte CallbackDestination1;
  public byte CallbackDestination2;
  public byte CallbackDestination3;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_SESSION_TERMINATION
{
  /*   struct { */
  [FieldOffset(0)] public byte CloseSessionOnDCDLoss; // = 1;
  [FieldOffset(0)] public byte EnableSessionInactivityTimeout; // = 1;
  [FieldOffset(0)] public byte Reserved; // = 6;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_MESSAGING_COM_SETTING
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved1; // = 5;
  [FieldOffset(0)] public byte EnableDtrHangup; // = 1;
  [FieldOffset(0)] public byte FlowControl; // = 2;
  [FieldOffset(0)] public byte BitRate; // = 4;
  [FieldOffset(0)] public byte Reserved2; // = 4;
  [FieldOffset(0)] public byte SaveSetting; // = 1;
  [FieldOffset(0)] public byte SetComPort; // = 1;
  [FieldOffset(0)] public byte Reserved3; // = 6;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
  [FieldOffset(0)] public ushort Uint16;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_MODEM_RING_TIME
{
  /*   struct { */
  [FieldOffset(0)] public byte RingDurationInterval; // = 6;
  [FieldOffset(0)] public byte Reserved1; // = 2;
  [FieldOffset(0)] public byte RingDeadTime; // = 4;
  [FieldOffset(0)] public byte Reserved2; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_EMP_MODEM_INIT_STRING
{
  public byte Reserved;
  public fixed byte InitString[48];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_EMP_MODEM_ESC_SEQUENCE
{
  public fixed byte EscapeSequence[5];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_EMP_MODEM_HANGUP_SEQUENCE
{
  public fixed byte HangupSequence[8];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_MODEM_DIALUP_COMMAND
{
  public fixed byte ModelDialCommend[8];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_PAGE_BLACKOUT_INTERVAL
{
  public byte PageBlackoutInterval;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_EMP_COMMUNITY_STRING
{
  public fixed byte CommunityString[18];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_DIAL_PAGE_DESTINATION
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved; // = 4;
  [FieldOffset(0)] public byte DialStringSelector; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_TAP_PAGE_DESTINATION
{
  /*   struct { */
  [FieldOffset(0)] public byte TapAccountSelector; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_PPP_ALERT_DESTINATION
{
  public byte PPPAccountSetSelector;
  public byte DialStringSelector;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_DEST_TYPE_SPECIFIC
{
  [FieldOffset(0)] public IPMI_DIAL_PAGE_DESTINATION DialPageDestination;
  [FieldOffset(0)] public IPMI_TAP_PAGE_DESTINATION TapPageDestination;
  [FieldOffset(0)] public IPMI_PPP_ALERT_DESTINATION PppAlertDestination;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_DESTINATION_SELECTOR
{
  /*   struct { */
  [FieldOffset(0)] public byte DestinationSelector; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_DESTINATION_TYPE
{
  /*   struct { */
  [FieldOffset(0)] public byte DestinationType; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 3;
  [FieldOffset(0)] public byte AlertAckRequired; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_RETRIES
{
  /*   struct { */
  [FieldOffset(0)] public byte NumRetriesCall; // = 3;
  [FieldOffset(0)] public byte Reserved1; // = 1;
  [FieldOffset(0)] public byte NumRetryAlert; // = 3;
  [FieldOffset(0)] public byte Reserved2; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_EMP_DESTINATION_INFO
{
  public IPMI_EMP_DESTINATION_SELECTOR DestinationSelector;
  public IPMI_EMP_DESTINATION_TYPE DestinationType;
  public byte AlertAckTimeoutSeconds;
  public IPMI_EMP_RETRIES Retries;
  public IPMI_DEST_TYPE_SPECIFIC DestinationTypeSpecific;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_DESTINATION_COM_SETTING_DATA_2
{
  /*   struct { */
  [FieldOffset(0)] public byte Parity; // = 3;
  [FieldOffset(0)] public byte CharacterSize; // = 1;
  [FieldOffset(0)] public byte StopBit; // = 1;
  [FieldOffset(0)] public byte DtrHangup; // = 1;
  [FieldOffset(0)] public byte FlowControl; // = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_BIT_RATE
{
  /*   struct { */
  [FieldOffset(0)] public byte BitRate; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_EMP_DESTINATION_COM_SETTING
{
  public IPMI_EMP_DESTINATION_SELECTOR DestinationSelector;
  public IPMI_EMP_DESTINATION_COM_SETTING_DATA_2 Data2;
  public IPMI_EMP_BIT_RATE BitRate;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_DIAL_STRING_SELECTOR
{
  /*   struct { */
  [FieldOffset(0)] public byte DialStringSelector; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_DESTINATION_DIAL_STRING
{
  public IPMI_DIAL_STRING_SELECTOR DestinationSelector;
  public byte Reserved;
  public fixed byte DialString[48];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_PPP_IP_ADDRESS
{
  [FieldOffset(0)] public uint IpAddressLong;
  [FieldOffset(0)] public fixed byte IpAddress[4];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_DESTINATION_IP_ADDRESS_SELECTOR
{
  /*   struct { */
  [FieldOffset(0)] public byte IpAddressSelector; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_DESTINATION_IP_ADDRESS
{
  public IPMI_DESTINATION_IP_ADDRESS_SELECTOR DestinationSelector;
  public IPMI_PPP_IP_ADDRESS PppIpAddress;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_TAP_DIAL_STRING_SERVICE_SELECTOR
{
  /*   struct { */
  [FieldOffset(0)] public byte TapServiceSelector; // = 4;
  [FieldOffset(0)] public byte TapDialStringSelector; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_DESTINATION_TAP_ACCOUNT
{
  public byte TapSelector;
  public IPMI_TAP_DIAL_STRING_SERVICE_SELECTOR TapDialStringServiceSelector;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_TAP_PAGER_ID_STRING
{
  public byte TapSelector;
  public fixed byte PagerIdString[16];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_EMP_OPTIONS
{
  [FieldOffset(0)] public byte OptionData;
  [FieldOffset(0)] public IPMI_EMP_AUTH_TYPE EmpAuthType;
  [FieldOffset(0)] public IPMI_EMP_CONNECTION_TYPE EmpConnectionType;
  [FieldOffset(0)] public IPMI_EMP_INACTIVITY_TIMEOUT EmpInactivityTimeout;
  [FieldOffset(0)] public IPMI_EMP_CHANNEL_CALLBACK_CONTROL EmpCallbackControl;
  [FieldOffset(0)] public IPMI_EMP_SESSION_TERMINATION EmpSessionTermination;
  [FieldOffset(0)] public IPMI_EMP_MESSAGING_COM_SETTING EmpMessagingComSetting;
  [FieldOffset(0)] public IPMI_EMP_MODEM_RING_TIME EmpModemRingTime;
  [FieldOffset(0)] public IPMI_EMP_MODEM_INIT_STRING EmpModemInitString;
  [FieldOffset(0)] public IPMI_EMP_MODEM_ESC_SEQUENCE EmpModemEscSequence;
  [FieldOffset(0)] public IPMI_EMP_MODEM_HANGUP_SEQUENCE EmpModemHangupSequence;
  [FieldOffset(0)] public IPMI_MODEM_DIALUP_COMMAND EmpModemDialupCommand;
  [FieldOffset(0)] public IPMI_PAGE_BLACKOUT_INTERVAL EmpPageBlackoutInterval;
  [FieldOffset(0)] public IPMI_EMP_COMMUNITY_STRING EmpCommunityString;
  [FieldOffset(0)] public IPMI_EMP_DESTINATION_INFO EmpDestinationInfo;
  [FieldOffset(0)] public IPMI_EMP_DESTINATION_COM_SETTING EmpDestinationComSetting;
  [FieldOffset(0)] public byte CallRetryBusySignalInterval;
  [FieldOffset(0)] public IPMI_DESTINATION_DIAL_STRING DestinationDialString;
  [FieldOffset(0)] public IPMI_DESTINATION_IP_ADDRESS DestinationIpAddress;
  [FieldOffset(0)] public IPMI_DESTINATION_TAP_ACCOUNT DestinationTapAccount;
  [FieldOffset(0)] public IPMI_TAP_PAGER_ID_STRING TapPagerIdString;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get Serial/Modem Configuration command
  //
  public const ulong IPMI_TRANSPORT_GET_SERIAL_CONFIGURATION = 0x11;

  //
  //  Constants and Structure definitions for "Get Serial/Modem Configuration" command to follow here
  //

  //
  //  Definitions for Set Serial/Modem Mux command
  //
  public const ulong IPMI_TRANSPORT_SET_SERIAL_MUX = 0x12;

  //
  //  Constants and Structure definitions for "Set Serial/Modem Mux" command to follow here
  //

  //
  // Set Serial/Modem Mux command request return status
  //
  public const ulong IPMI_MUX_SETTING_REQUEST_REJECTED = 0x00;
  public const ulong IPMI_MUX_SETTING_REQUEST_ACCEPTED = 0x01;

  //
  //  Definitions for serial multiplex settings
  //
  public const ulong IPMI_MUX_SETTING_GET_MUX_SETTING = 0x0;
  public const ulong IPMI_MUX_SETTING_REQUEST_MUX_TO_SYSTEM = 0x1;
  public const ulong IPMI_MUX_SETTING_REQUEST_MUX_TO_BMC = 0x2;
  public const ulong IPMI_MUX_SETTING_FORCE_MUX_TO_SYSTEM = 0x3;
  public const ulong IPMI_MUX_SETTING_FORCE_MUX_TO_BMC = 0x4;
  public const ulong IPMI_MUX_SETTING_BLOCK_REQUEST_MUX_TO_SYSTEM = 0x5;
  public const ulong IPMI_MUX_SETTING_ALLOW_REQUEST_MUX_TO_SYSTEM = 0x6;
  public const ulong IPMI_MUX_SETTING_BLOCK_REQUEST_MUX_TO_BMC = 0x7;
  public const ulong IPMI_MUX_SETTING_ALLOW_REQUEST_MUX_TO_BMC = 0x8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_MUX_CHANNEL_NUM
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNo; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_MUX_SETTING_REQUEST
{
  /*   struct { */
  [FieldOffset(0)] public byte MuxSetting; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_SERIAL_MODEM_MUX_COMMAND_REQUEST
{
  public IPMI_MUX_CHANNEL_NUM ChannelNumber;
  public IPMI_MUX_SETTING_REQUEST MuxSetting;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_MUX_SETTING_PRESENT_STATE
{
  /*   struct { */
  [FieldOffset(0)] public byte MuxSetToBmc; // = 1;
  [FieldOffset(0)] public byte CommandStatus; // = 1;
  [FieldOffset(0)] public byte MessagingSessionActive; // = 1;
  [FieldOffset(0)] public byte AlertInProgress; // = 1;
  [FieldOffset(0)] public byte Reserved; // = 2;
  [FieldOffset(0)] public byte MuxToBmcAllowed; // = 1;
  [FieldOffset(0)] public byte MuxToSystemBlocked; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_SERIAL_MODEM_MUX_COMMAND_RESPONSE
{
  public byte CompletionCode;
  public IPMI_MUX_SETTING_PRESENT_STATE MuxSetting;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get TAP Response Code command
  //
  public const ulong IPMI_TRANSPORT_GET_TAP_RESPONSE_CODE = 0x13;

  //
  //  Constants and Structure definitions for "Get TAP Response Code" command to follow here
  //

  //
  //  Definitions for Set PPP UDP Proxy Transmit Data command
  //
  public const ulong IPMI_TRANSPORT_SET_PPP_UDP_PROXY_TXDATA = 0x14;

  //
  //  Constants and Structure definitions for "Set PPP UDP Proxy Transmit Data" command to follow here
  //

  //
  //  Definitions for Get PPP UDP Proxy Transmit Data command
  //
  public const ulong IPMI_TRANSPORT_GET_PPP_UDP_PROXY_TXDATA = 0x15;

  //
  //  Constants and Structure definitions for "Get PPP UDP Proxy Transmit Data" command to follow here
  //

  //
  //  Definitions for Send PPP UDP Proxy Packet command
  //
  public const ulong IPMI_TRANSPORT_SEND_PPP_UDP_PROXY_PACKET = 0x16;

  //
  //  Constants and Structure definitions for "Send PPP UDP Proxy Packet" command to follow here
  //

  //
  //  Definitions for Get PPP UDP Proxy Receive Data command
  //
  public const ulong IPMI_TRANSPORT_GET_PPP_UDP_PROXY_RX = 0x17;

  //
  //  Constants and Structure definitions for "Get PPP UDP Proxy Receive Data" command to follow here
  //

  //
  //  Definitions for Serial/Modem connection active command
  //
  public const ulong IPMI_TRANSPORT_SERIAL_CONNECTION_ACTIVE = 0x18;

  //
  //  Constants and Structure definitions for "Serial/Modem connection active" command to follow here
  //

  //
  //  Definitions for Callback command
  //
  public const ulong IPMI_TRANSPORT_CALLBACK = 0x19;

  //
  //  Constants and Structure definitions for "Callback" command to follow here
  //

  //
  //  Definitions for Set user Callback Options command
  //
  public const ulong IPMI_TRANSPORT_SET_USER_CALLBACK_OPTIONS = 0x1A;

  //
  //  Constants and Structure definitions for "Set user Callback Options" command to follow here
  //

  //
  //  Definitions for Get user Callback Options command
  //
  public const ulong IPMI_TRANSPORT_GET_USER_CALLBACK_OPTIONS = 0x1B;

  //
  //  Constants and Structure definitions for "Get user Callback Options" command to follow here
  //

  //
  //  Below is Definitions for SOL Commands (Chapter 26)
  //

  //
  //  Definitions for SOL activating command
  //
  public const ulong IPMI_TRANSPORT_SOL_ACTIVATING = 0x20;
}

//
//  Constants and Structure definitions for "SOL activating" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SOL_SESSION_STATE
{
  /*   struct { */
  [FieldOffset(0)] public byte SessionState; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SOL_ACTIVATING_REQUEST
{
  public IPMI_SOL_SESSION_STATE SessionState;
  public byte PayloadInstance;
  public byte FormatVersionMajor; // 1
  public byte FormatVersionMinor; // 0
}

public unsafe partial class EFI
{
  //
  //  Definitions for Set SOL Configuration Parameters command
  //
  public const ulong IPMI_TRANSPORT_SET_SOL_CONFIG_PARAM = 0x21;

  //
  //  Constants and Structure definitions for "Set SOL Configuration Parameters" command to follow here
  //

  //
  // SOL Configuration Parameters selector
  //
  public const ulong IPMI_SOL_CONFIGURATION_PARAMETER_SET_IN_PROGRESS = 0;
  public const ulong IPMI_SOL_CONFIGURATION_PARAMETER_SOL_ENABLE = 1;
  public const ulong IPMI_SOL_CONFIGURATION_PARAMETER_SOL_AUTHENTICATION = 2;
  public const ulong IPMI_SOL_CONFIGURATION_PARAMETER_SOL_CHARACTER_PARAM = 3;
  public const ulong IPMI_SOL_CONFIGURATION_PARAMETER_SOL_RETRY = 4;
  public const ulong IPMI_SOL_CONFIGURATION_PARAMETER_SOL_NV_BIT_RATE = 5;
  public const ulong IPMI_SOL_CONFIGURATION_PARAMETER_SOL_VOLATILE_BIT_RATE = 6;
  public const ulong IPMI_SOL_CONFIGURATION_PARAMETER_SOL_PAYLOAD_CHANNEL = 7;
  public const ulong IPMI_SOL_CONFIGURATION_PARAMETER_SOL_PAYLOAD_PORT = 8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SET_SOL_CONFIG_PARAM_CHANNEL_NUM
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNumber; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_SOL_CONFIGURATION_PARAMETERS_REQUEST
{
  public IPMI_SET_SOL_CONFIG_PARAM_CHANNEL_NUM ChannelNumber;
  public byte ParameterSelector;
  public byte[] ParameterData;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get SOL Configuration Parameters command
  //
  public const ulong IPMI_TRANSPORT_GET_SOL_CONFIG_PARAM = 0x22;
}

//
//  Constants and Structure definitions for "Get SOL Configuration Parameters" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_SOL_CONFIG_PARAM_CHANNEL_NUM
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNumber; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 3;
  [FieldOffset(0)] public byte GetParameter; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SOL_CONFIGURATION_PARAMETERS_REQUEST
{
  public IPMI_GET_SOL_CONFIG_PARAM_CHANNEL_NUM ChannelNumber;
  public byte ParameterSelector;
  public byte SetSelector;
  public byte BlockSelector;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SOL_CONFIGURATION_PARAMETERS_RESPONSE
{
  public byte CompletionCode;
  public byte ParameterRevision;
  public byte[] ParameterData;
}

// #pragma pack()
// #endif
