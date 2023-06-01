namespace Uefi;
/** @file
  EFI SMM Access2 Protocol as defined in the PI 1.2 specification.

  This protocol is used to control the visibility of the SMRAM on the platform.
  It abstracts the location and characteristics of SMRAM.  The expectation is
  that the north bridge or memory controller would publish this protocol.

  The principal functionality found in the memory controller includes the following:
  - Exposing the SMRAM to all non-SMM agents, or the "open" state
  - Shrouding the SMRAM to all but the SMM agents, or the "closed" state
  - Preserving the system integrity, or "locking" the SMRAM, such that the settings cannot be
    perturbed by either boot service or runtime agents

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _SMM_ACCESS2_H_
// #define _SMM_ACCESS2_H_

// #include <Protocol/MmAccess.h>

public static ulong EFI_SMM_ACCESS2_PROTOCOL_GUID = EFI_MM_ACCESS_PROTOCOL_GUID;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_ACCESS2_PROTOCOL { EFI_MM_ACCESS_PROTOCOL Value; public static implicit operator EFI_SMM_ACCESS2_PROTOCOL(EFI_MM_ACCESS_PROTOCOL value) => new EFI_SMM_ACCESS2_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_ACCESS_PROTOCOL(EFI_SMM_ACCESS2_PROTOCOL value) => value.Value;}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_OPEN2 { EFI_MM_OPEN Value; public static implicit operator EFI_SMM_OPEN2(EFI_MM_OPEN value) => new EFI_SMM_OPEN2() { Value = value }; public static implicit operator EFI_MM_OPEN(EFI_SMM_OPEN2 value) => value.Value;}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_CLOSE2 { EFI_MM_CLOSE Value; public static implicit operator EFI_SMM_CLOSE2(EFI_MM_CLOSE value) => new EFI_SMM_CLOSE2() { Value = value }; public static implicit operator EFI_MM_CLOSE(EFI_SMM_CLOSE2 value) => value.Value;}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_LOCK2 { EFI_MM_LOCK Value; public static implicit operator EFI_SMM_LOCK2(EFI_MM_LOCK value) => new EFI_SMM_LOCK2() { Value = value }; public static implicit operator EFI_MM_LOCK(EFI_SMM_LOCK2 value) => value.Value;}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_CAPABILITIES2 { EFI_MM_CAPABILITIES Value; public static implicit operator EFI_SMM_CAPABILITIES2(EFI_MM_CAPABILITIES value) => new EFI_SMM_CAPABILITIES2() { Value = value }; public static implicit operator EFI_MM_CAPABILITIES(EFI_SMM_CAPABILITIES2 value) => value.Value;}
// extern EFI_GUID  gEfiSmmAccess2ProtocolGuid;

// #endif
