using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This protocol provides registering and unregistering services to status code consumers while in DXE SMM.

  Copyright (c) 2007 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in PI Specification 1.1.

**/

// #ifndef __SMM_REPORT_STATUS_CODE_HANDLER_PROTOCOL_H__
// #define __SMM_REPORT_STATUS_CODE_HANDLER_PROTOCOL_H__

// #include <Protocol/MmReportStatusCodeHandler.h>

public const ulong EFI_SMM_RSC_HANDLER_PROTOCOL_GUID = EFI_MM_RSC_HANDLER_PROTOCOL_GUID;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_RSC_HANDLER_CALLBACK { EFI_MM_RSC_HANDLER_CALLBACK Value; public static implicit operator EFI_SMM_RSC_HANDLER_CALLBACK(EFI_MM_RSC_HANDLER_CALLBACK value) => new EFI_SMM_RSC_HANDLER_CALLBACK() { Value = value }; public static implicit operator EFI_MM_RSC_HANDLER_CALLBACK(EFI_SMM_RSC_HANDLER_CALLBACK value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_RSC_HANDLER_REGISTER { EFI_MM_RSC_HANDLER_REGISTER Value; public static implicit operator EFI_SMM_RSC_HANDLER_REGISTER(EFI_MM_RSC_HANDLER_REGISTER value) => new EFI_SMM_RSC_HANDLER_REGISTER() { Value = value }; public static implicit operator EFI_MM_RSC_HANDLER_REGISTER(EFI_SMM_RSC_HANDLER_REGISTER value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_RSC_HANDLER_UNREGISTER { EFI_MM_RSC_HANDLER_UNREGISTER Value; public static implicit operator EFI_SMM_RSC_HANDLER_UNREGISTER(EFI_MM_RSC_HANDLER_UNREGISTER value) => new EFI_SMM_RSC_HANDLER_UNREGISTER() { Value = value }; public static implicit operator EFI_MM_RSC_HANDLER_UNREGISTER(EFI_SMM_RSC_HANDLER_UNREGISTER value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_RSC_HANDLER_PROTOCOL { EFI_MM_RSC_HANDLER_PROTOCOL Value; public static implicit operator EFI_SMM_RSC_HANDLER_PROTOCOL(EFI_MM_RSC_HANDLER_PROTOCOL value) => new EFI_SMM_RSC_HANDLER_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_RSC_HANDLER_PROTOCOL(EFI_SMM_RSC_HANDLER_PROTOCOL value) => value.Value; }

// extern EFI_GUID  gEfiSmmRscHandlerProtocolGuid;

// #endif // __SMM_REPORT_STATUS_CODE_HANDLER_PROTOCOL_H__
