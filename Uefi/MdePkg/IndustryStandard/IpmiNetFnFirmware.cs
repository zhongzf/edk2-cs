using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  IPMI 2.0 definitions from the IPMI Specification Version 2.0, Revision 1.1.

  Copyright (c) 1999 - 2015, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _IPMI_NET_FN_FIRMWARE_H_
// #define _IPMI_NET_FN_FIRMWARE_H_

public unsafe partial class EFI
{
  //
  // Net function definition for Firmware command
  //
  public const ulong IPMI_NETFN_FIRMWARE = 0x08;

  //
  // All Firmware commands and their structure definitions to follow here
  //

  // ----------------------------------------------------------------------------------------
  //    Definitions for Get BMC Execution Context
  // ----------------------------------------------------------------------------------------
  public const ulong IPMI_GET_BMC_EXECUTION_CONTEXT = 0x23;
}

//
//  Constants and Structure definitions for "Get Device ID" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_MSG_GET_BMC_EXEC_RSP
{
  public byte CurrentExecutionContext;
  public byte PartitionPointer;
}

public unsafe partial class EFI
{
  //
  // Current Execution Context responses
  //
  public const ulong IPMI_BMC_IN_FORCED_UPDATE_MODE = 0x11;
}

// #endif
