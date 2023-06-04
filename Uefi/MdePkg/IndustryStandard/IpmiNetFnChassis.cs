using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  IPMI 2.0 definitions from the IPMI Specification Version 2.0, Revision 1.1.

  This file contains all NetFn Chassis commands, including:
    Chassis Commands (Chapter 28)

  See IPMI specification, Appendix G, Command Assignments
  and Appendix H, Sub-function Assignments.

  Copyright (c) 1999 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _IPMI_NET_FN_CHASSIS_H_
// #define _IPMI_NET_FN_CHASSIS_H_

public unsafe partial class EFI
{
  // #pragma pack (1)
  //
  // Net function definition for Chassis command
  //
  public const ulong IPMI_NETFN_CHASSIS = 0x00;

  //
  //  Below is Definitions for Chassis commands (Chapter 28)
  //

  //
  //  Definitions for Get Chassis Capabilities command
  //
  public const ulong IPMI_CHASSIS_GET_CAPABILITIES = 0x00;
}

//
//  Constants and Structure definitions for "Get Chassis Capabilities" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_CHASSIS_CAPABILITIES_RESPONSE
{
  public byte CompletionCode;
  public byte CapabilitiesFlags;
  public byte ChassisFruInfoDeviceAddress;
  public byte ChassisSDRDeviceAddress;
  public byte ChassisSELDeviceAddress;
  public byte ChassisSystemManagementDeviceAddress;
  public byte ChassisBridgeDeviceAddress;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get Chassis Status command
  //
  public const ulong IPMI_CHASSIS_GET_STATUS = 0x01;
}

//
//  Constants and Structure definitions for "Get Chassis Status" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_CHASSIS_STATUS_RESPONSE
{
  public byte CompletionCode;
  public byte CurrentPowerState;
  public byte LastPowerEvent;
  public byte MiscChassisState;
  public byte FrontPanelButtonCapabilities;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Chassis Control command
  //
  public const ulong IPMI_CHASSIS_CONTROL = 0x02;
}

//
//  Constants and Structure definitions for "Chassis Control" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_CHASSIS_CONTROL_CHASSIS_CONTROL
{
  /*   struct { */
  [FieldOffset(0)] public byte ChassisControl; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_CHASSIS_CONTROL_REQUEST
{
  public IPMI_CHASSIS_CONTROL_CHASSIS_CONTROL ChassisControl;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Chassis Reset command
  //
  public const ulong IPMI_CHASSIS_RESET = 0x03;

  //
  //  Constants and Structure definitions for "Chassis Reset" command to follow here
  //

  //
  //  Definitions for Chassis Identify command
  //
  public const ulong IPMI_CHASSIS_IDENTIFY = 0x04;

  //
  //  Constants and Structure definitions for "Chassis Identify" command to follow here
  //

  //
  //  Definitions for Set Chassis Capabilities command
  //
  public const ulong IPMI_CHASSIS_SET_CAPABILITIES = 0x05;

  //
  //  Constants and Structure definitions for "Set Chassis Capabilities" command to follow here
  //

  //
  //  Definitions for Set Power Restore Policy command
  //
  public const ulong IPMI_CHASSIS_SET_POWER_RESTORE_POLICY = 0x06;
}

//
//  Constants and Structure definitions for "Set Power Restore Policy" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_POWER_RESTORE_POLICY
{
  /*   struct { */
  [FieldOffset(0)] public byte PowerRestorePolicy; // = 3;
  [FieldOffset(0)] public byte Reserved; // = 5;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_POWER_RESTORE_POLICY_REQUEST
{
  public IPMI_POWER_RESTORE_POLICY PowerRestorePolicy;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_POWER_RESTORE_POLICY_RESPONSE
{
  public byte CompletionCode;
  public byte PowerRestorePolicySupport;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get System Restart Cause command
  //
  public const ulong IPMI_CHASSIS_GET_SYSTEM_RESTART_CAUSE = 0x07;

  //
  //  Constants and Structure definitions for "Get System Restart Cause" command to follow here
  //
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_UNKNOWN = 0x0;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_CHASSIS_CONTROL_COMMAND = 0x1;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_PUSHBUTTON_RESET = 0x2;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_PUSHBUTTON_POWERUP = 0x3;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_WATCHDOG_EXPIRE = 0x4;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_OEM = 0x5;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_AUTO_POWER_ALWAYS_RESTORE = 0x6;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_AUTO_POWER_RESTORE_PREV = 0x7;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_PEF_RESET = 0x8;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_PEF_POWERCYCLE = 0x9;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_SOFT_RESET = 0xA;
  public const ulong IPMI_SYSTEM_RESTART_CAUSE_RTC_POWERUP = 0xB;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SYSTEM_RESTART_CAUSE
{
  /*   struct { */
  [FieldOffset(0)] public byte Cause; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SYSTEM_RESTART_CAUSE_RESPONSE
{
  public byte CompletionCode;
  public IPMI_SYSTEM_RESTART_CAUSE RestartCause;
  public byte ChannelNumber;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Set System BOOT options command
  //
  public const ulong IPMI_CHASSIS_SET_SYSTEM_BOOT_OPTIONS = 0x08;
}

//
//  Constants and Structure definitions for "Set System boot options" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SET_BOOT_OPTIONS_PARAMETER_VALID
{
  /*   struct { */
  [FieldOffset(0)] public byte ParameterSelector; // = 7;
  [FieldOffset(0)] public byte MarkParameterInvalid; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_BOOT_OPTIONS_REQUEST
{
  public IPMI_SET_BOOT_OPTIONS_PARAMETER_VALID ParameterValid;
  public byte[] ParameterData;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_BOOT_OPTIONS_RESPONSE
{
  public byte CompletionCode; // = 8;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get System Boot options command
  //
  public const ulong IPMI_CHASSIS_GET_SYSTEM_BOOT_OPTIONS = 0x09;
}

//
//  Constants and Structure definitions for "Get System boot options" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_BOOT_OPTIONS_PARAMETER_SELECTOR
{
  /*   struct { */
  [FieldOffset(0)] public byte ParameterSelector; // = 7;
  [FieldOffset(0)] public byte Reserved; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_BOOT_OPTIONS_REQUEST
{
  public IPMI_GET_BOOT_OPTIONS_PARAMETER_SELECTOR ParameterSelector;
  public byte SetSelector;
  public byte BlockSelector;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_THE_SYSTEM_BOOT_OPTIONS
{
  public byte Parameter;
  public byte Valid;
  public byte Data1;
  public byte Data2;
  public byte Data3;
  public byte Data4;
  public byte Data5;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_BOOT_INITIATOR
{
  public byte ParameterVersion;
  public byte ParameterValid;
  public byte ChannelNumber;
  public uint SessionId;
  public uint TimeStamp;
  public fixed byte Reserved[3];
}

public unsafe partial class EFI
{
  //
  // Definitions for boot option parameter selector
  //
  public const ulong IPMI_BOOT_OPTIONS_PARAMETER_SELECTOR_SET_IN_PROGRESS = 0x0;
  public const ulong IPMI_BOOT_OPTIONS_PARAMETER_SELECTOR_SERVICE_PARTITION_SELECTOR = 0x1;
  public const ulong IPMI_BOOT_OPTIONS_PARAMETER_SELECTOR_SERVICE_PARTITION_SCAN = 0x2;
  public const ulong IPMI_BOOT_OPTIONS_PARAMETER_SELECTOR_BMC_BOOT_FLAG = 0x3;
  public const ulong IPMI_BOOT_OPTIONS_PARAMETER_BOOT_INFO_ACK = 0x4;
  public const ulong IPMI_BOOT_OPTIONS_PARAMETER_BOOT_FLAGS = 0x5;
  public const ulong IPMI_BOOT_OPTIONS_PARAMETER_BOOT_INITIATOR_INFO = 0x6;
  public const ulong IPMI_BOOT_OPTIONS_PARAMETER_BOOT_INITIATOR_MAILBOX = 0x7;
  public const ulong IPMI_BOOT_OPTIONS_PARAMETER_OEM_BEGIN = 0x60;
  public const ulong IPMI_BOOT_OPTIONS_PARAMETER_OEM_END = 0x7F;
}

//
// Response Parameters for IPMI Get Boot Options
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_0
{
  /*   struct { */
  [FieldOffset(0)] public byte SetInProgress; // = 2;
  [FieldOffset(0)] public byte Reserved; // = 6;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_1
{
  public byte ServicePartitionSelector;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_2
{
  /*   struct { */
  [FieldOffset(0)] public byte ServicePartitionDiscovered; // = 1;
  [FieldOffset(0)] public byte ServicePartitionScanRequest; // = 1;
  [FieldOffset(0)] public byte Reserved; // = 6;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_3
{
  /*   struct { */
  [FieldOffset(0)] public byte BmcBootFlagValid; // = 5;
  [FieldOffset(0)] public byte Reserved; // = 3;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_4
{
  public byte WriteMask;
  public byte BootInitiatorAcknowledgeData;
}

public unsafe partial class EFI
{
  //
  //  Definitions for the 'Boot device selector' field of Boot Option Parameters #5
  //
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_NO_OVERRIDE = 0x0;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_PXE = 0x1;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_HARDDRIVE = 0x2;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_HARDDRIVE_SAFE_MODE = 0x3;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_DIAGNOSTIC_PARTITION = 0x4;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_CD_DVD = 0x5;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_BIOS_SETUP = 0x6;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_REMOTE_FLOPPY = 0x7;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_REMOTE_CD_DVD = 0x8;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_PRIMARY_REMOTE_MEDIA = 0x9;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_REMOTE_HARDDRIVE = 0xB;
  public const ulong IPMI_BOOT_DEVICE_SELECTOR_FLOPPY = 0xF;

  public const ulong BOOT_OPTION_HANDLED_BY_BIOS = 0x01;

  //
  //  Constant definitions for the 'BIOS Mux Control Override' field of Boot Option Parameters #5
  //
  public const ulong BIOS_MUX_CONTROL_OVERRIDE_RECOMMEND_SETTING = 0x00;
  public const ulong BIOS_MUX_CONTROL_OVERRIDE_FORCE_TO_BMC = 0x01;
  public const ulong BIOS_MUX_CONTROL_OVERRIDE_FORCE_TO_SYSTEM = 0x02;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5_DATA_1
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved; // = 5;
  [FieldOffset(0)] public byte BiosBootType; // = 1;
  [FieldOffset(0)] public byte PersistentOptions; // = 1;
  [FieldOffset(0)] public byte BootFlagValid; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5_DATA_2
{
  /*   struct { */
  [FieldOffset(0)] public byte LockReset; // = 1;
  [FieldOffset(0)] public byte ScreenBlank; // = 1;
  [FieldOffset(0)] public byte BootDeviceSelector; // = 4;
  [FieldOffset(0)] public byte LockKeyboard; // = 1;
  [FieldOffset(0)] public byte CmosClear; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5_DATA_3
{
  /*   struct { */
  [FieldOffset(0)] public byte ConsoleRedirection; // = 2;
  [FieldOffset(0)] public byte LockSleep; // = 1;
  [FieldOffset(0)] public byte UserPasswordBypass; // = 1;
  [FieldOffset(0)] public byte ForceProgressEventTrap; // = 1;
  [FieldOffset(0)] public byte BiosVerbosity; // = 2;
  [FieldOffset(0)] public byte LockPower; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5_DATA_4
{
  /*   struct { */
  [FieldOffset(0)] public byte BiosMuxControlOverride; // = 3;
  [FieldOffset(0)] public byte BiosSharedModeOverride; // = 1;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5_DATA_5
{
  /*   struct { */
  [FieldOffset(0)] public byte DeviceInstanceSelector; // = 5;
  [FieldOffset(0)] public byte Reserved; // = 3;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5
{
  public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5_DATA_1 Data1;
  public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5_DATA_2 Data2;
  public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5_DATA_3 Data3;
  public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5_DATA_4 Data4;
  public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5_DATA_5 Data5;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BOOT_OPTIONS_CHANNEL_NUMBER
{
  /*   struct { */
  [FieldOffset(0)] public byte ChannelNumber; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_6
{
  public IPMI_BOOT_OPTIONS_CHANNEL_NUMBER ChannelNumber;
  public fixed byte SessionId[4];
  public fixed byte BootInfoTimeStamp[4];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_7
{
  public byte SetSelector;
  public fixed byte BlockData[16];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_BOOT_OPTIONS_PARAMETERS
{
  [FieldOffset(0)] public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_0 Parm0;
  [FieldOffset(0)] public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_1 Parm1;
  [FieldOffset(0)] public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_2 Parm2;
  [FieldOffset(0)] public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_3 Parm3;
  [FieldOffset(0)] public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_4 Parm4;
  [FieldOffset(0)] public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_5 Parm5;
  [FieldOffset(0)] public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_6 Parm6;
  [FieldOffset(0)] public IPMI_BOOT_OPTIONS_RESPONSE_PARAMETER_7 Parm7;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_BOOT_OPTIONS_PARAMETER_VERSION
{
  /*   struct { */
  [FieldOffset(0)] public byte ParameterVersion; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_GET_BOOT_OPTIONS_PARAMETER_VALID
{
  /*   struct { */
  [FieldOffset(0)] public byte ParameterSelector; // = 7;
  [FieldOffset(0)] public byte ParameterValid; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_BOOT_OPTIONS_RESPONSE
{
  public byte CompletionCode;
  public IPMI_GET_BOOT_OPTIONS_PARAMETER_VERSION ParameterVersion;
  public IPMI_GET_BOOT_OPTIONS_PARAMETER_VALID ParameterValid;
  public byte[] ParameterData;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Set front panel button enables command
  //
  public const ulong IPMI_CHASSIS_SET_FRONT_PANEL_BUTTON_ENABLES = 0x0A;
}

//
//  Constants and Structure definitions for "Set front panel button enables" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_FRONT_PANEL_BUTTON_ENABLES
{
  /*   struct { */
  [FieldOffset(0)] public byte DisablePoweroffButton; // = 1;
  [FieldOffset(0)] public byte DisableResetButton; // = 1;
  [FieldOffset(0)] public byte DisableDiagnosticInterruptButton; // = 1;
  [FieldOffset(0)] public byte DisableStandbyButton; // = 1;
  [FieldOffset(0)] public byte Reserved; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_CHASSIS_SET_FRONT_PANEL_BUTTON_ENABLES_REQUEST
{
  public IPMI_FRONT_PANEL_BUTTON_ENABLES FrontPanelButtonEnables;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Set Power Cycle Interval command
  //
  public const ulong IPMI_CHASSIS_SET_POWER_CYCLE_INTERVALS = 0x0B;

  //
  //  Constants and Structure definitions for "Set Power Cycle Interval" command to follow here
  //

  //
  //  Definitions for Get POH Counter command
  //
  public const ulong IPMI_CHASSIS_GET_POH_COUNTER = 0x0F;
}

//
//  Constants and Structure definitions for "Get POH Counter" command to follow here
//
// #pragma pack()
// #endif
