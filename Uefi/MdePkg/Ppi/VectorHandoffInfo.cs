using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file declares Vector Handoff Info PPI that describes an array of
  interrupt and/or exception vectors that are in use and need to persist.

  This is an optional PPI that may be produced by SEC. If present, it provides
  a description of the interrupt and/or exception vectors that were established
  in the SEC Phase and need to persist into PEI and DXE.

  Copyright (c) 2013 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This PPI is introduced in PI Version 1.2.1.

**/

// #ifndef __VECTOR_HANDOFF_INFO_H__
// #define __VECTOR_HANDOFF_INFO_H__

public unsafe partial class EFI
{
  ///
  /// NOTE: EFI_PEI_VECTOR_HANDOFF_INFO_PPI_GUID can also be used in the PEI Phase
  /// to build a GUIDed HOB that contains an array of EFI_VECTOR_HANDOFF_INFO.
  ///
  public static EFI_GUID EFI_PEI_VECTOR_HANDOFF_INFO_PPI_GUID => new GUID(0x3cd652b4, 0x6d33, 0x4dce, 0x89, 0xdb, 0x83, 0xdf, 0x97, 0x66, 0xfc, 0xca);

  ///
  /// Vector Handoff Info Attributes
  ///@{
  public const ulong EFI_VECTOR_HANDOFF_DO_NOT_HOOK = 0x00000000;
  public const ulong EFI_VECTOR_HANDOFF_HOOK_BEFORE = 0x00000001;
  public const ulong EFI_VECTOR_HANDOFF_HOOK_AFTER = 0x00000002;
  public const ulong EFI_VECTOR_HANDOFF_LAST_ENTRY = 0x80000000;
  ///@}
}

///
/// EFI_VECTOR_HANDOFF_INFO entries that describes the interrupt and/or
/// exception vectors in use in the PEI Phase.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_VECTOR_HANDOFF_INFO
{
  //
  // The interrupt or exception vector that is in use and must be preserved.
  //
  public uint VectorNumber;
  //
  // A bitmask that describes the attributes of the interrupt or exception vector.
  //
  public uint Attribute;
  //
  // The GUID identifies the party who created the entry. For the
  // EFI_VECTOR_HANDOFF_DO_NOT_HOOK case, this establishes the single owner.
  //
  public EFI_GUID Owner;
}

///
/// Provides a description of the interrupt and/or exception vectors that
/// were established in the SEC Phase and need to persist into PEI and DXE.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PEI_VECTOR_HANDOFF_INFO_PPI
{
  //
  // Pointer to an array of interrupt and /or exception vectors.
  //
  public EFI_VECTOR_HANDOFF_INFO* Info;
}

// extern EFI_GUID  gEfiVectorHandoffInfoPpiGuid;

// #endif
