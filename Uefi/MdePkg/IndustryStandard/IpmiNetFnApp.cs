using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  IPMI 2.0 definitions from the IPMI Specification Version 2.0, Revision 1.1.

  This file contains all NetFn App commands, including:
    IPM Device "Global" Commands (Chapter 20)
    Firmware Firewall & Command Discovery Commands (Chapter 21)
    BMC Watchdog Timer Commands (Chapter 27)
    IPMI Messaging Support Commands (Chapter 22)
    RMCP+ Support and Payload Commands (Chapter 24)

  See IPMI specification, Appendix G, Command Assignments
  and Appendix H, Sub-function Assignments.

  Copyright (c) 1999 - 2018, Intel Corporation. All rights reserved.<BR>
  Copyright (C) 2023 Advanced Micro Devices, Inc. All rights reserved.<BR>
  Copyright (c) 2023, Ampere Computing LLC. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _IPMI_NET_FN_APP_H_
// #define _IPMI_NET_FN_APP_H_

public unsafe partial class EFI
{
  // #pragma pack(1)
  //
  // Net function definition for App command
  //
  public const ulong IPMI_NETFN_APP = 0x06;

  //
  //  Below is Definitions for IPM Device "Global" Commands  (Chapter 20)
  //

  //
  //  Definitions for Get Device ID command
  //
  public const ulong IPMI_APP_GET_DEVICE_ID = 0x1;
}

//
//  Constants and Structure definitions for "Get Device ID" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_DEVICE_ID_DEVICE_REV
{
  /*   struct { */
  [FieldOffset(0)] public byte DeviceRevision = 4;
  [FieldOffset(0)] public byte Reserved = 3;
  [FieldOffset(0)] public byte DeviceSdr = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_DEVICE_ID_FIRMWARE_REV_1
{
  /*   struct { */
  [FieldOffset(0)] public byte MajorFirmwareRev = 7;
  [FieldOffset(0)] public byte UpdateMode = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_DEVICE_ID_DEVICE_SUPPORT
{
  /*   struct { */
  [FieldOffset(0)] public byte SensorDeviceSupport = 1;
  [FieldOffset(0)] public byte SdrRepositorySupport = 1;
  [FieldOffset(0)] public byte SelDeviceSupport = 1;
  [FieldOffset(0)] public byte FruInventorySupport = 1;
  [FieldOffset(0)] public byte IpmbMessageReceiver = 1;
  [FieldOffset(0)] public byte IpmbMessageGenerator = 1;
  [FieldOffset(0)] public byte BridgeSupport = 1;
  [FieldOffset(0)] public byte ChassisSupport = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_DEVICE_ID_RESPONSE
{
  public byte CompletionCode;
  public byte DeviceId;
  public IPMI_GET_DEVICE_ID_DEVICE_REV DeviceRevision;
  public IPMI_GET_DEVICE_ID_FIRMWARE_REV_1 FirmwareRev1;
  public byte MinorFirmwareRev;
  public byte SpecificationVersion;
  public IPMI_GET_DEVICE_ID_DEVICE_SUPPORT DeviceSupport;
  public fixed byte ManufacturerId[3];
  public ushort ProductId;
  public uint AuxFirmwareRevInfo;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Cold Reset command
  //
  public const ulong IPMI_APP_COLD_RESET = 0x2;

  //
  //  Constants and Structure definitions for "Cold Reset" command to follow here
  //

  //
  //  Definitions for Warm Reset command
  //
  public const ulong IPMI_APP_WARM_RESET = 0x3;

  //
  //  Constants and Structure definitions for "Warm Reset" command to follow here
  //

  //
  //  Definitions for Get Self Results command
  //
  public const ulong IPMI_APP_GET_SELFTEST_RESULTS = 0x4;
}

//
//  Constants and Structure definitions for "Get Self Test Results" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SELF_TEST_RESULT_RESPONSE
{
  public byte CompletionCode;
  public byte Result;
  public byte Param;
}

public unsafe partial class EFI
{
  public const ulong IPMI_APP_SELFTEST_NO_ERROR = 0x55;
  public const ulong IPMI_APP_SELFTEST_NOT_IMPLEMENTED = 0x56;
  public const ulong IPMI_APP_SELFTEST_ERROR = 0x57;
  public const ulong IPMI_APP_SELFTEST_FATAL_HW_ERROR = 0x58;
  public const ulong IPMI_APP_SELFTEST_INACCESSIBLE_SEL = 0x80;
  public const ulong IPMI_APP_SELFTEST_INACCESSIBLE_SDR = 0x40;
  public const ulong IPMI_APP_SELFTEST_INACCESSIBLE_FRU = 0x20;
  public const ulong IPMI_APP_SELFTEST_IPMB_SIGNAL_FAIL = 0x10;
  public const ulong IPMI_APP_SELFTEST_SDR_REPOSITORY_EMPTY = 0x08;
  public const ulong IPMI_APP_SELFTEST_FRU_CORRUPT = 0x04;
  public const ulong IPMI_APP_SELFTEST_FW_BOOTBLOCK_CORRUPT = 0x02;
  public const ulong IPMI_APP_SELFTEST_FW_CORRUPT = 0x01;

  //
  //  Definitions for Manufacturing Test ON command
  //
  public const ulong IPMI_APP_MANUFACTURING_TEST_ON = 0x5;

  //
  //  Constants and Structure definitions for "Manufacturing Test ON" command to follow here
  //

  //
  //  Definitions for Set ACPI Power State command
  //
  public const ulong IPMI_APP_SET_ACPI_POWERSTATE = 0x6;

  //
  //  Constants and Structure definitions for "Set ACPI Power State" command to follow here
  //

  //
  //  Definitions for System Power State
  //
  // Working
  public const ulong IPMI_SYSTEM_POWER_STATE_S0_G0 = 0x0;
  public const ulong IPMI_SYSTEM_POWER_STATE_S1 = 0x1;
  public const ulong IPMI_SYSTEM_POWER_STATE_S2 = 0x2;
  public const ulong IPMI_SYSTEM_POWER_STATE_S3 = 0x3;
  public const ulong IPMI_SYSTEM_POWER_STATE_S4 = 0x4;
  // Soft off
  public const ulong IPMI_SYSTEM_POWER_STATE_S5_G2 = 0x5;
  // Sent when message source cannot differentiate between S4 and S5
  public const ulong IPMI_SYSTEM_POWER_STATE_S4_S5 = 0x6;
  // Mechanical off
  public const ulong IPMI_SYSTEM_POWER_STATE_G3 = 0x7;
  // Sleeping - cannot differentiate between S1-S3
  public const ulong IPMI_SYSTEM_POWER_STATE_SLEEPING = 0x8;
  // Sleeping - cannot differentiate between S1-S4
  public const ulong IPMI_SYSTEM_POWER_STATE_G1_SLEEPING = 0x9;
  // S5 entered by override
  public const ulong IPMI_SYSTEM_POWER_STATE_OVERRIDE = 0xA;
  public const ulong IPMI_SYSTEM_POWER_STATE_LEGACY_ON = 0x20;
  public const ulong IPMI_SYSTEM_POWER_STATE_LEGACY_OFF = 0x21;
  public const ulong IPMI_SYSTEM_POWER_STATE_UNKNOWN = 0x2A;
  public const ulong IPMI_SYSTEM_POWER_STATE_NO_CHANGE = 0x7F;

  //
  //  Definitions for Device Power State
  //
  public const ulong IPMI_DEVICE_POWER_STATE_D0 = 0x0;
  public const ulong IPMI_DEVICE_POWER_STATE_D1 = 0x1;
  public const ulong IPMI_DEVICE_POWER_STATE_D2 = 0x2;
  public const ulong IPMI_DEVICE_POWER_STATE_D3 = 0x3;
  public const ulong IPMI_DEVICE_POWER_STATE_UNKNOWN = 0x2A;
  public const ulong IPMI_DEVICE_POWER_STATE_NO_CHANGE = 0x7F;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_ACPI_POWER_STATE
{
  /*   struct { */
  [FieldOffset(0)] public byte PowerState = 7;
  [FieldOffset(0)] public byte StateChange = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_ACPI_POWER_STATE_REQUEST
{
  public IPMI_ACPI_POWER_STATE SystemPowerState;
  public IPMI_ACPI_POWER_STATE DevicePowerState;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get ACPI Power State command
  //
  public const ulong IPMI_APP_GET_ACPI_POWERSTATE = 0x7;

  //
  //  Constants and Structure definitions for "Get ACPI Power State" command to follow here
  //

  //
  //  Definitions for Get Device GUID command
  //
  public const ulong IPMI_APP_GET_DEVICE_GUID = 0x8;
}

//
//  Constants and Structure definitions for "Get Device GUID" command to follow here
//
//
//  Message structure definition for "Get Device Guid" IPMI command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_DEVICE_GUID_RESPONSE
{
  public byte CompletionCode;
  public fixed byte Guid[16];
}

//
//  Below is Definitions for BMC Watchdog Timer Commands (Chapter 27)
//

public unsafe partial class EFI
{
  //
  //  Definitions for Reset WatchDog Timer command
  //
  public const ulong IPMI_APP_RESET_WATCHDOG_TIMER = 0x22;

  //
  //  Definitions for Set WatchDog Timer command
  //
  public const ulong IPMI_APP_SET_WATCHDOG_TIMER = 0x24;

  //
  //  Constants and Structure definitions for "Set WatchDog Timer" command to follow here
  //

  //
  // Definitions for watchdog timer use
  //
  public const ulong IPMI_WATCHDOG_TIMER_BIOS_FRB2 = 0x1;
  public const ulong IPMI_WATCHDOG_TIMER_BIOS_POST = 0x2;
  public const ulong IPMI_WATCHDOG_TIMER_OS_LOADER = 0x3;
  public const ulong IPMI_WATCHDOG_TIMER_SMS = 0x4;
  public const ulong IPMI_WATCHDOG_TIMER_OEM = 0x5;
}

//
//  Structure definition for timer Use
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_WATCHDOG_TIMER_USE
{
  /*   struct { */
  [FieldOffset(0)] public byte TimerUse = 3;
  [FieldOffset(0)] public byte Reserved = 3;
  [FieldOffset(0)] public byte TimerRunning = 1;
  [FieldOffset(0)] public byte TimerUseExpirationFlagLog = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

public unsafe partial class EFI
{
  //
  //  Definitions for watchdog timeout action
  //
  public const ulong IPMI_WATCHDOG_TIMER_ACTION_NO_ACTION = 0x0;
  public const ulong IPMI_WATCHDOG_TIMER_ACTION_HARD_RESET = 0x1;
  public const ulong IPMI_WATCHDOG_TIMER_ACTION_POWER_DONW = 0x2;
  public const ulong IPMI_WATCHDOG_TIMER_ACTION_POWER_CYCLE = 0x3;

  //
  //  Definitions for watchdog pre-timeout interrupt
  //
  public const ulong IPMI_WATCHDOG_PRE_TIMEOUT_INTERRUPT_NONE = 0x0;
  public const ulong IPMI_WATCHDOG_PRE_TIMEOUT_INTERRUPT_SMI = 0x1;
  public const ulong IPMI_WATCHDOG_PRE_TIMEOUT_INTERRUPT_NMI = 0x2;
  public const ulong IPMI_WATCHDOG_PRE_TIMEOUT_INTERRUPT_MESSAGING = 0x3;
}

//
//  Structure definitions for Timer Actions
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_WATCHDOG_TIMER_ACTIONS
{
  /*   struct { */
  [FieldOffset(0)] public byte TimeoutAction = 3;
  [FieldOffset(0)] public byte Reserved1 = 1;
  [FieldOffset(0)] public byte PreTimeoutInterrupt = 3;
  [FieldOffset(0)] public byte Reserved2 = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

public unsafe partial class EFI
{
  //
  //  Bit definitions for Timer use expiration flags
  //
  public const ulong IPMI_WATCHDOG_TIMER_EXPIRATION_FLAG_BIOS_FRB2 = BIT1;
  public const ulong IPMI_WATCHDOG_TIMER_EXPIRATION_FLAG_BIOS_POST = BIT2;
  public const ulong IPMI_WATCHDOG_TIMER_EXPIRATION_FLAG_OS_LOAD = BIT3;
  public const ulong IPMI_WATCHDOG_TIMER_EXPIRATION_FLAG_SMS_OS = BIT4;
  public const ulong IPMI_WATCHDOG_TIMER_EXPIRATION_FLAG_OEM = BIT5;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_WATCHDOG_TIMER_REQUEST
{
  public IPMI_WATCHDOG_TIMER_USE TimerUse;
  public IPMI_WATCHDOG_TIMER_ACTIONS TimerActions;
  public byte PretimeoutInterval;
  public byte TimerUseExpirationFlagsClear;
  public ushort InitialCountdownValue;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get WatchDog Timer command
  //
  public const ulong IPMI_APP_GET_WATCHDOG_TIMER = 0x25;
}

//
//  Constants and Structure definitions for "Get WatchDog Timer" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_WATCHDOG_TIMER_RESPONSE
{
  public byte CompletionCode;
  public IPMI_WATCHDOG_TIMER_USE TimerUse;
  public IPMI_WATCHDOG_TIMER_ACTIONS TimerActions;
  public byte PretimeoutInterval;
  public byte TimerUseExpirationFlagsClear;
  public ushort InitialCountdownValue;
  public ushort PresentCountdownValue;
}

//
//  Below is Definitions for IPMI Messaging Support Commands (Chapter 22)
//

public unsafe partial class EFI
{
  //
  //  Definitions for Set BMC Global Enables command
  //
  public const ulong IPMI_APP_SET_BMC_GLOBAL_ENABLES = 0x2E;
}

//
//  Constants and Structure definitions for "Set BMC Global Enables " command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BMC_GLOBAL_ENABLES
{
  /*   struct { */
  [FieldOffset(0)] public byte ReceiveMessageQueueInterrupt = 1;
  [FieldOffset(0)] public byte EventMessageBufferFullInterrupt = 1;
  [FieldOffset(0)] public byte EventMessageBuffer = 1;
  [FieldOffset(0)] public byte SystemEventLogging = 1;
  [FieldOffset(0)] public byte Reserved = 1;
  [FieldOffset(0)] public byte Oem0Enable = 1;
  [FieldOffset(0)] public byte Oem1Enable = 1;
  [FieldOffset(0)] public byte Oem2Enable = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_BMC_GLOBAL_ENABLES_REQUEST
{
  public IPMI_BMC_GLOBAL_ENABLES SetEnables;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get BMC Global Enables command
  //
  public const ulong IPMI_APP_GET_BMC_GLOBAL_ENABLES = 0x2F;
}

//
//  Constants and Structure definitions for "Get BMC Global Enables " command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_BMC_GLOBAL_ENABLES_RESPONSE
{
  public byte CompletionCode;
  public IPMI_BMC_GLOBAL_ENABLES GetEnables;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Clear Message Flags command
  //
  public const ulong IPMI_APP_CLEAR_MESSAGE_FLAGS = 0x30;
}

//
//  Constants and Structure definitions for "Clear Message Flags" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_MESSAGE_FLAGS
{
  /*   struct { */
  [FieldOffset(0)] public byte ReceiveMessageQueue = 1;
  [FieldOffset(0)] public byte EventMessageBuffer = 1;
  [FieldOffset(0)] public byte Reserved1 = 1;
  [FieldOffset(0)] public byte WatchdogPerTimeoutInterrupt = 1;
  [FieldOffset(0)] public byte Reserved2 = 1;
  [FieldOffset(0)] public byte Oem0 = 1;
  [FieldOffset(0)] public byte Oem1 = 1;
  [FieldOffset(0)] public byte Oem2 = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_CLEAR_MESSAGE_FLAGS_REQUEST
{
  public IPMI_MESSAGE_FLAGS ClearFlags;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get Message Flags command
  //
  public const ulong IPMI_APP_GET_MESSAGE_FLAGS = 0x31;
}

//
//  Constants and Structure definitions for "Get Message Flags" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_MESSAGE_FLAGS_RESPONSE
{
  public byte CompletionCode;
  public IPMI_MESSAGE_FLAGS GetFlags;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Enable Message Channel Receive command
  //
  public const ulong IPMI_APP_ENABLE_MESSAGE_CHANNEL_RECEIVE = 0x32;

  //
  //  Constants and Structure definitions for "Enable Message Channel Receive" command to follow here
  //

  //
  //  Definitions for Get Message command
  //
  public const ulong IPMI_APP_GET_MESSAGE = 0x33;
}

//
//  Constants and Structure definitions for "Get Message" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_MESSAGE_CHANNEL_NUMBER
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNumber = 4;
  [FieldOffset(0)] public byte InferredPrivilegeLevel = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_MESSAGE_RESPONSE
{
  public byte CompletionCode;
  public IPMI_GET_MESSAGE_CHANNEL_NUMBER ChannelNumber;
  public fixed byte MessageData[0];
}

public unsafe partial class EFI
{
  //
  //  Definitions for Send Message command
  //
  public const ulong IPMI_APP_SEND_MESSAGE = 0x34;
}

//
//  Constants and Structure definitions for "Send Message" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SEND_MESSAGE_CHANNEL_NUMBER
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNumber = 4;
  [FieldOffset(0)] public byte Authentication = 1;
  [FieldOffset(0)] public byte Encryption = 1;
  [FieldOffset(0)] public byte Tracking = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SEND_MESSAGE_REQUEST
{
  public byte CompletionCode;
  public IPMI_SEND_MESSAGE_CHANNEL_NUMBER ChannelNumber;
  public fixed byte MessageData[0];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SEND_MESSAGE_RESPONSE
{
  public byte CompletionCode;
  public fixed byte ResponseData[0];
}

public unsafe partial class EFI
{
  //
  //  Definitions for Read Event Message Buffer command
  //
  public const ulong IPMI_APP_READ_EVENT_MSG_BUFFER = 0x35;

  //
  //  Constants and Structure definitions for "Read Event Message Buffer" command to follow here
  //

  //
  //  Definitions for Get BT Interface Capabilities command
  //
  public const ulong IPMI_APP_GET_BT_INTERFACE_CAPABILITY = 0x36;

  //
  //  Constants and Structure definitions for "Get BT Interface Capabilities" command to follow here
  //

  //
  //  Definitions for Get System GUID command
  //
  public const ulong IPMI_APP_GET_SYSTEM_GUID = 0x37;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SYSTEM_UUID_RESPONSE
{
  public byte CompletionCode;
  public EFI_GUID SystemUuid;
}

//
//  Constants and Structure definitions for "Get System GUID" command to follow here
//

public unsafe partial class EFI
{
  //
  //  Definitions for Get Channel Authentication Capabilities command
  //
  public const ulong IPMI_APP_GET_CHANNEL_AUTHENTICATION_CAPABILITIES = 0x38;

  //
  //  Constants and Structure definitions for "Get Channel Authentication Capabilities" command to follow here
  //

  //
  //  Definitions for Get Session Challenge command
  //
  public const ulong IPMI_APP_GET_SESSION_CHALLENGE = 0x39;

  //
  //  Constants and Structure definitions for "Get Session Challenge" command to follow here
  //

  //
  //  Definitions for Activate Session command
  //
  public const ulong IPMI_APP_ACTIVATE_SESSION = 0x3A;

  //
  //  Constants and Structure definitions for "Activate Session" command to follow here
  //

  //
  //  Definitions for Set Session Privelege Level command
  //
  public const ulong IPMI_APP_SET_SESSION_PRIVELEGE_LEVEL = 0x3B;

  //
  //  Constants and Structure definitions for "Set Session Privelege Level" command to follow here
  //

  //
  //  Definitions for Close Session command
  //
  public const ulong IPMI_APP_CLOSE_SESSION = 0x3C;

  //
  //  Constants and Structure definitions for "Close Session" command to follow here
  //

  //
  //  Definitions for Get Session Info command
  //
  public const ulong IPMI_APP_GET_SESSION_INFO = 0x3D;

  //
  //  Constants and Structure definitions for "Get Session Info" command to follow here
  //

  //
  //  Definitions for Get Auth Code command
  //
  public const ulong IPMI_APP_GET_AUTHCODE = 0x3F;

  //
  //  Constants and Structure definitions for "Get AuthCode" command to follow here
  //

  //
  //  Definitions for Set Channel Access command
  //
  public const ulong IPMI_APP_SET_CHANNEL_ACCESS = 0x40;

  //
  //  Constants and Structure definitions for "Set Channel Access" command to follow here
  //

  //
  //  Definitions for Get Channel Access command
  //
  public const ulong IPMI_APP_GET_CHANNEL_ACCESS = 0x41;

  //
  //  Constants and Structure definitions for "Get Channel Access" command to follow here
  //

  //
  //  Definitions for channel access memory type in Get Channel Access command request
  //
  public const ulong IPMI_CHANNEL_ACCESS_MEMORY_TYPE_NON_VOLATILE = 0x1;
  public const ulong IPMI_CHANNEL_ACCESS_MEMORY_TYPE_PRESENT_VOLATILE_SETTING = 0x2;

  //
  //  Definitions for channel access modes in Get Channel Access command response
  //
  public const ulong IPMI_CHANNEL_ACCESS_MODES_DISABLED = 0x0;
  public const ulong IPMI_CHANNEL_ACCESS_MODES_PRE_BOOT_ONLY = 0x1;
  public const ulong IPMI_CHANNEL_ACCESS_MODES_ALWAYS_AVAILABLE = 0x2;
  public const ulong IPMI_CHANNEL_ACCESS_MODES_SHARED = 0x3;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_CHANNEL_ACCESS_CHANNEL_NUMBER
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNo = 4;
  [FieldOffset(0)] public byte Reserved = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_CHANNEL_ACCESS_TYPE
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved = 6;
  [FieldOffset(0)] public byte MemoryType = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_CHANNEL_ACCESS_REQUEST
{
  public IPMI_GET_CHANNEL_ACCESS_CHANNEL_NUMBER ChannelNumber;
  public IPMI_GET_CHANNEL_ACCESS_TYPE AccessType;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_CHANNEL_ACCESS_CHANNEL_ACCESS
{
  /*   struct { */
  [FieldOffset(0)] public byte AccessMode = 3;
  [FieldOffset(0)] public byte UserLevelAuthEnabled = 1;
  [FieldOffset(0)] public byte MessageAuthEnable = 1;
  [FieldOffset(0)] public byte Alert = 1;
  [FieldOffset(0)] public byte Reserved = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_CHANNEL_ACCESS_PRIVILEGE_LIMIT
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelPriviledgeLimit = 4;
  [FieldOffset(0)] public byte Reserved = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_CHANNEL_ACCESS_RESPONSE
{
  public byte CompletionCode;
  public IPMI_GET_CHANNEL_ACCESS_CHANNEL_ACCESS ChannelAccess;
  public IPMI_GET_CHANNEL_ACCESS_PRIVILEGE_LIMIT PrivilegeLimit;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get Channel Info command
  //
  public const ulong IPMI_APP_GET_CHANNEL_INFO = 0x42;

  //
  //  Constants and Structure definitions for "Get Channel Info" command to follow here
  //

  //
  //  Definitions for channel media type
  //
  // IPMB (I2C)
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_IPMB = 0x1;
  // ICMB v1.0
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_ICMB_1_0 = 0x2;
  // ICMB v0.9
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_ICMB_0_9 = 0x3;
  // 802.3 LAN
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_802_3_LAN = 0x4;
  // Asynch. Serial/Modem (RS-232)
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_RS_232 = 0x5;
  // Other LAN
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_OTHER_LAN = 0x6;
  // PCI SMBus
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_PCI_SM_BUS = 0x7;
  // SMBus v1.0/1.1
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_SM_BUS_V1 = 0x8;
  // SMBus v2.0
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_SM_BUS_V2 = 0x9;
  // USB 1.x
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_USB1 = 0xA;
  // USB 2.x
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_USB2 = 0xB;
  // System Interface (KCS, SMIC, or BT)
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_SYSTEM_INTERFACE = 0xC;
  // OEM
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_OEM_START = 0x60;
  public const ulong IPMI_CHANNEL_MEDIA_TYPE_OEM_END = 0x7F;

  //
  //  Definitions for channel protocol type
  //
  // Not available
  public const ulong IPMI_CHANNEL_PROTOCOL_TYPE_NA = 0x00;
  // IPMB-1.0
  public const ulong IPMI_CHANNEL_PROTOCOL_TYPE_IPMB_1_0 = 0x01;
  // ICMB-1.0
  public const ulong IPMI_CHANNEL_PROTOCOL_TYPE_ICMB_1_0 = 0x02;
  // Reserved
  public const ulong IPMI_CHANNEL_PROTOCOL_TYPE_RESERVED = 0x03;
  // IPMI SMBUS
  public const ulong IPMI_CHANNEL_PROTOCOL_TYPE_IPMI_SMBUS = 0x04;
  // KCS
  public const ulong IPMI_CHANNEL_PROTOCOL_TYPE_KCS = 0x05;
  // SMIC
  public const ulong IPMI_CHANNEL_PROTOCOL_TYPE_SMIC = 0x06;
  // BT-10
  public const ulong IPMI_CHANNEL_PROTOCOL_TYPE_BT_10 = 0x07;
  // BT-15
  public const ulong IPMI_CHANNEL_PROTOCOL_TYPE_BT_15 = 0x08;
  // TMode
  public const ulong IPMI_CHANNEL_PROTOCOL_TYPE_TMODE = 0x09;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_CHANNEL_INFO_CHANNEL_NUMBER
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNo = 4;
  [FieldOffset(0)] public byte Reserved = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_CHANNEL_INFO_MEDIUM_TYPE
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelMediumType = 7;
  [FieldOffset(0)] public byte Reserved = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_CHANNEL_INFO_PROTOCOL_TYPE
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelProtocolType = 5;
  [FieldOffset(0)] public byte Reserved = 3;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_CHANNEL_INFO_SESSION_SUPPORT
{
  /*   struct { */
  [FieldOffset(0)] public byte ActiveSessionCount = 6;
  [FieldOffset(0)] public byte SessionSupport = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_CHANNEL_INFO_RESPONSE
{
  public byte CompletionCode;
  public IPMI_CHANNEL_INFO_CHANNEL_NUMBER ChannelNumber;
  public IPMI_CHANNEL_INFO_MEDIUM_TYPE MediumType;
  public IPMI_CHANNEL_INFO_PROTOCOL_TYPE ProtocolType;
  public IPMI_CHANNEL_INFO_SESSION_SUPPORT SessionSupport;
  public fixed byte VendorId[3];
  public ushort AuxChannelInfo;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_CHANNEL_INFO_REQUEST
{
  public IPMI_CHANNEL_INFO_CHANNEL_NUMBER ChannelNumber;
}

//
//  Constants and Structure definitions for "Get Channel Info" command to follow here
//

public unsafe partial class EFI
{
  //
  //  Definitions for Set User Access command
  //
  public const ulong IPMI_APP_SET_USER_ACCESS = 0x43;

  //
  //  Constants and Structure definitions for "Set User Access" command to follow here
  //

  //
  //  Definitions for Get User Access command
  //
  public const ulong IPMI_APP_GET_USER_ACCESS = 0x44;
}

//
//  Constants and Structure definitions for "Get User Access" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_USER_ACCESS_CHANNEL_NUMBER
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNo = 4;
  [FieldOffset(0)] public byte Reserved = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_USER_ID
{
  /*   struct { */
  [FieldOffset(0)] public byte UserId = 6;
  [FieldOffset(0)] public byte Reserved = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_USER_ACCESS_REQUEST
{
  public IPMI_GET_USER_ACCESS_CHANNEL_NUMBER ChannelNumber;
  public IPMI_USER_ID UserId;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_USER_ACCESS_MAX_USER_ID
{
  /*   struct { */
  [FieldOffset(0)] public byte MaxUserId = 6;
  [FieldOffset(0)] public byte Reserved = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_USER_ACCESS_CURRENT_USER
{
  /*   struct { */
  [FieldOffset(0)] public byte CurrentUserId = 6;
  [FieldOffset(0)] public byte UserIdEnableStatus = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_USER_ACCESS_FIXED_NAME_USER
{
  /*   struct { */
  [FieldOffset(0)] public byte FixedUserId = 6;
  [FieldOffset(0)] public byte Reserved = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_USER_ACCESS_CHANNEL_ACCESS
{
  /*   struct { */
  [FieldOffset(0)] public byte UserPrivilegeLimit = 4;
  [FieldOffset(0)] public byte EnableIpmiMessaging = 1;
  [FieldOffset(0)] public byte EnableUserLinkAuthetication = 1;
  [FieldOffset(0)] public byte UserAccessAvailable = 1;
  [FieldOffset(0)] public byte Reserved = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_USER_ACCESS_RESPONSE
{
  public byte CompletionCode;
  public IPMI_GET_USER_ACCESS_MAX_USER_ID MaxUserId;
  public IPMI_GET_USER_ACCESS_CURRENT_USER CurrentUser;
  public IPMI_GET_USER_ACCESS_FIXED_NAME_USER FixedNameUser;
  public IPMI_GET_USER_ACCESS_CHANNEL_ACCESS ChannelAccess;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Set User Name command
  //
  public const ulong IPMI_APP_SET_USER_NAME = 0x45;
}

//
//  Constants and Structure definitions for "Set User Name" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_USER_NAME_REQUEST
{
  public IPMI_USER_ID UserId;
  public fixed byte UserName[16];
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get User Name command
  //
  public const ulong IPMI_APP_GET_USER_NAME = 0x46;
}

//
//  Constants and Structure definitions for "Get User Name" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_USER_NAME_REQUEST
{
  public IPMI_USER_ID UserId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_USER_NAME_RESPONSE
{
  public byte CompletionCode;
  public fixed byte UserName[16];
}

public unsafe partial class EFI
{
  //
  //  Definitions for Set User Password command
  //
  public const ulong IPMI_APP_SET_USER_PASSWORD = 0x47;

  //
  //  Constants and Structure definitions for "Set User Password" command to follow here
  //

  //
  //  Definitions for Set User password command operation type
  //
  public const ulong IPMI_SET_USER_PASSWORD_OPERATION_TYPE_DISABLE_USER = 0x0;
  public const ulong IPMI_SET_USER_PASSWORD_OPERATION_TYPE_ENABLE_USER = 0x1;
  public const ulong IPMI_SET_USER_PASSWORD_OPERATION_TYPE_SET_PASSWORD = 0x2;
  public const ulong IPMI_SET_USER_PASSWORD_OPERATION_TYPE_TEST_PASSWORD = 0x3;

  //
  //  Definitions for Set user password command password size
  //
  public const ulong IPMI_SET_USER_PASSWORD_PASSWORD_SIZE_16 = 0x0;
  public const ulong IPMI_SET_USER_PASSWORD_PASSWORD_SIZE_20 = 0x1;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SET_USER_PASSWORD_USER_ID
{
  /*   struct { */
  [FieldOffset(0)] public byte UserId = 6;
  [FieldOffset(0)] public byte Reserved = 1;
  [FieldOffset(0)] public byte PasswordSize = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SET_USER_PASSWORD_OPERATION
{
  /*   struct { */
  [FieldOffset(0)] public byte Operation = 2;
  [FieldOffset(0)] public byte Reserved = 6;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_USER_PASSWORD_REQUEST
{
  public IPMI_SET_USER_PASSWORD_USER_ID UserId;
  public IPMI_SET_USER_PASSWORD_OPERATION Operation;
  public fixed byte PasswordData[0]; // 16 or 20 bytes, depending on the 'PasswordSize' field
}

//
//  Below is Definitions for RMCP+ Support and Payload Commands (Chapter 24)
//

public unsafe partial class EFI
{
  //
  //  Definitions for Activate Payload command
  //
  public const ulong IPMI_APP_ACTIVATE_PAYLOAD = 0x48;

  //
  //  Constants and Structure definitions for "Activate Payload" command to follow here
  //

  //
  //  Definitions for De-Activate Payload command
  //
  public const ulong IPMI_APP_DEACTIVATE_PAYLOAD = 0x49;

  //
  //  Constants and Structure definitions for "DeActivate Payload" command to follow here
  //

  //
  //  Definitions for Get Payload activation Status command
  //
  public const ulong IPMI_APP_GET_PAYLOAD_ACTIVATION_STATUS = 0x4a;

  //
  //  Constants and Structure definitions for "Get Payload activation Status" command to follow here
  //

  //
  //  Definitions for Get Payload Instance Info command
  //
  public const ulong IPMI_APP_GET_PAYLOAD_INSTANCE_INFO = 0x4b;

  //
  //  Constants and Structure definitions for "Get Payload Instance Info" command to follow here
  //

  //
  //  Definitions for Set User Payload Access command
  //
  public const ulong IPMI_APP_SET_USER_PAYLOAD_ACCESS = 0x4C;

  //
  //  Constants and Structure definitions for "Set User Payload Access" command to follow here
  //

  //
  //  Definitions for Get User Payload Access command
  //
  public const ulong IPMI_APP_GET_USER_PAYLOAD_ACCESS = 0x4D;

  //
  //  Constants and Structure definitions for "Get User Payload Access" command to follow here
  //

  //
  //  Definitions for Get Channel Payload Support command
  //
  public const ulong IPMI_APP_GET_CHANNEL_PAYLOAD_SUPPORT = 0x4E;

  //
  //  Constants and Structure definitions for "Get Channel Payload Support" command to follow here
  //

  //
  //  Definitions for Get Channel Payload Version command
  //
  public const ulong IPMI_APP_GET_CHANNEL_PAYLOAD_VERSION = 0x4F;

  //
  //  Constants and Structure definitions for "Get Channel Payload Version" command to follow here
  //

  //
  //  Definitions for Get Channel OEM Payload Info command
  //
  public const ulong IPMI_APP_GET_CHANNEL_OEM_PAYLOAD_INFO = 0x50;

  //
  //  Constants and Structure definitions for "Get Channel OEM Payload Info" command to follow here
  //

  //
  //  Definitions for  Master Write-Read command
  //
  public const ulong IPMI_APP_MASTER_WRITE_READ = 0x52;

  //
  //  Constants and Structure definitions for "Master Write Read" command to follow here
  //

  //
  //  Definitions for  Get Channel Cipher Suites command
  //
  public const ulong IPMI_APP_GET_CHANNEL_CIPHER_SUITES = 0x54;

  //
  //  Constants and Structure definitions for "Get Channel Cipher Suites" command to follow here
  //

  //
  //  Below is Definitions for RMCP+ Support and Payload Commands (Chapter 24, Section 3)
  //

  //
  //  Definitions for  Suspend-Resume Payload Encryption command
  //
  public const ulong IPMI_APP_SUSPEND_RESUME_PAYLOAD_ENCRYPTION = 0x55;

  //
  //  Constants and Structure definitions for "Suspend-Resume Payload Encryption" command to follow here
  //

  //
  //  Below is Definitions for IPMI Messaging Support Commands (Chapter 22, Section 25 and 9)
  //

  //
  //  Definitions for  Set Channel Security Keys command
  //
  public const ulong IPMI_APP_SET_CHANNEL_SECURITY_KEYS = 0x56;

  //
  //  Constants and Structure definitions for "Set Channel Security Keys" command to follow here
  //

  //
  //  Definitions for  Get System Interface Capabilities command
  //
  public const ulong IPMI_APP_GET_SYSTEM_INTERFACE_CAPABILITIES = 0x57;

  //
  //  Constants and Structure definitions for "Get System Interface Capabilities" command to follow here
  //

  public const ulong IPMI_GET_SYSTEM_INTERFACE_CAPABILITIES_INTERFACE_TYPE_SSIF = 0x0;
  public const ulong IPMI_GET_SYSTEM_INTERFACE_CAPABILITIES_INTERFACE_TYPE_KCS = 0x1;
  public const ulong IPMI_GET_SYSTEM_INTERFACE_CAPABILITIES_INTERFACE_TYPE_SMIC = 0x2;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_SYSTEM_INTERFACE_CAPABILITIES_REQUEST
{
  /*   struct { */
  [FieldOffset(0)] public byte InterfaceType = 4;
  [FieldOffset(0)] public byte Reserved = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SYSTEM_INTERFACE_SSIF_CAPABILITIES
{
  /*   struct { */
  [FieldOffset(0)] public byte Version = 3;
  [FieldOffset(0)] public byte PecSupport = 1;
  [FieldOffset(0)] public byte Reserved = 2;
  [FieldOffset(0)] public byte TransactionSupport = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SYSTEM_INTERFACE_KCS_SMIC_CAPABILITIES
{
  /*   struct { */
  [FieldOffset(0)] public byte SystemInterfaceVersion = 3;
  [FieldOffset(0)] public byte Reserved = 5;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SYSTEM_INTERFACE_SSIF_CAPABILITIES_RESPONSE
{
  public byte CompletionCode;
  public byte Reserved;
  public IPMI_SYSTEM_INTERFACE_SSIF_CAPABILITIES InterfaceCap;
  public byte InputMsgSize;
  public byte OutputMsgSize;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SYSTEM_INTERFACE_KCS_SMIC_CAPABILITIES_RESPONSE
{
  public byte CompletionCode;
  public byte Reserved;
  public IPMI_SYSTEM_INTERFACE_KCS_SMIC_CAPABILITIES InterfaceCap;
  public byte InputMaxMsgSize;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get System Interface Capabilities command SSIF transaction support
  //
  public const ulong IPMI_GET_SYSTEM_INTERFACE_CAPABILITIES_SSIF_TRANSACTION_SUPPORT_SINGLE_PARTITION_RW = 0x0;
  public const ulong IPMI_GET_SYSTEM_INTERFACE_CAPABILITIES_SSIF_TRANSACTION_SUPPORT_MULTI_PARTITION_RW = 0x1;
  public const ulong IPMI_GET_SYSTEM_INTERFACE_CAPABILITIES_SSIF_TRANSACTION_SUPPORT_MULTI_PARTITION_RW_WITH_MIDDLE = 0x2;
}

// #pragma pack()
// #endif
