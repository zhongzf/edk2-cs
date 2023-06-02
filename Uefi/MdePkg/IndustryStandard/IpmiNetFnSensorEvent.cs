using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  IPMI 2.0 definitions from the IPMI Specification Version 2.0, Revision 1.1.

  This file contains all NetFn Sensor/Event commands, including:
    Event Commands (Chapter 29)
    PEF and Alerting Commands (Chapter 30)
    Sensor Device Commands (Chapter 35)

  See IPMI specification, Appendix G, Command Assignments
  and Appendix H, Sub-function Assignments.

  Copyright (c) 1999 - 2015, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _IPMI_NET_FN_SENSOR_EVENT_H_
// #define _IPMI_NET_FN_SENSOR_EVENT_H_

public unsafe partial class EFI
{
  // #pragma pack(1)
  //
  // Net function definition for Sensor command
  //
  public const ulong IPMI_NETFN_SENSOR_EVENT = 0x04;

  //
  // All Sensor commands and their structure definitions to follow here
  //

  //
  //  Definitions for Send Platform Event Message command
  //
  public const ulong IPMI_SENSOR_PLATFORM_EVENT_MESSAGE = 0x02;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_PLATFORM_EVENT_MESSAGE_DATA_REQUEST
{
  public byte GeneratorId;
  public byte EvMRevision;
  public byte SensorType;
  public byte SensorNumber;
  public byte EventDirType;
  public byte OEMEvData1;
  public byte OEMEvData2;
  public byte OEMEvData3;
}

// #pragma pack()
// #endif
