namespace Uefi;
/** @file
  EFI SMM Communication Protocol as defined in the PI 1.2 specification.

  This protocol provides a means of communicating between drivers outside of SMM and SMI
  handlers inside of SMM.

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _SMM_COMMUNICATION_H_
// #define _SMM_COMMUNICATION_H_

// #include <Protocol/MmCommunication.h>

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_COMMUNICATE_HEADER { EFI_MM_COMMUNICATE_HEADER Value; public static implicit operator EFI_SMM_COMMUNICATE_HEADER(EFI_MM_COMMUNICATE_HEADER value) => new EFI_SMM_COMMUNICATE_HEADER() { Value = value }; public static implicit operator EFI_MM_COMMUNICATE_HEADER(EFI_SMM_COMMUNICATE_HEADER value) => value.Value;}

public static ulong EFI_SMM_COMMUNICATION_PROTOCOL_GUID = EFI_MM_COMMUNICATION_PROTOCOL_GUID;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_COMMUNICATION_PROTOCOL { EFI_MM_COMMUNICATION_PROTOCOL Value; public static implicit operator EFI_SMM_COMMUNICATION_PROTOCOL(EFI_MM_COMMUNICATION_PROTOCOL value) => new EFI_SMM_COMMUNICATION_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_COMMUNICATION_PROTOCOL(EFI_SMM_COMMUNICATION_PROTOCOL value) => value.Value;}

// extern EFI_GUID  gEfiSmmCommunicationProtocolGuid;

// #endif
