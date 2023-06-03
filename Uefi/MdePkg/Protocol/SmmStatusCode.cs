using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI SMM Status Code Protocol as defined in the PI 1.2 specification.

  This protocol provides the basic status code services while in SMM.

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _SMM_STATUS_CODE_H__
// #define _SMM_STATUS_CODE_H__

// #include <Protocol/MmStatusCode.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_SMM_STATUS_CODE_PROTOCOL_GUID = EFI_MM_STATUS_CODE_PROTOCOL_GUID;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_STATUS_CODE_PROTOCOL { EFI_MM_STATUS_CODE_PROTOCOL Value; public static implicit operator EFI_SMM_STATUS_CODE_PROTOCOL(EFI_MM_STATUS_CODE_PROTOCOL value) => new EFI_SMM_STATUS_CODE_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_STATUS_CODE_PROTOCOL(EFI_SMM_STATUS_CODE_PROTOCOL value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_REPORT_STATUS_CODE { EFI_MM_REPORT_STATUS_CODE Value; public static implicit operator EFI_SMM_REPORT_STATUS_CODE(EFI_MM_REPORT_STATUS_CODE value) => new EFI_SMM_REPORT_STATUS_CODE() { Value = value }; public static implicit operator EFI_MM_REPORT_STATUS_CODE(EFI_SMM_REPORT_STATUS_CODE value) => value.Value; }

// extern EFI_GUID  gEfiSmmStatusCodeProtocolGuid;

// #endif
