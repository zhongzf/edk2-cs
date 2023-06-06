namespace Uefi;
/** @file
  Present the dependency expression values in PI.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  PI Version 1.0

**/

// #ifndef __PI_DEPENDENCY_H__
// #define __PI_DEPENDENCY_H__

public unsafe partial class EFI
{
  ///
  /// If present, this must be the first and only opcode,
  /// EFI_DEP_BEFORE may be used by DXE and SMM drivers.
  ///
  public const ulong EFI_DEP_BEFORE = 0x00;

  ///
  /// If present, this must be the first and only opcode,
  /// EFI_DEP_AFTER may be used by DXE and SMM drivers.
  ///
  public const ulong EFI_DEP_AFTER = 0x01;

  public const ulong EFI_DEP_PUSH = 0x02;
  public const ulong EFI_DEP_AND = 0x03;
  public const ulong EFI_DEP_OR = 0x04;
  public const ulong EFI_DEP_NOT = 0x05;
  public const ulong EFI_DEP_TRUE = 0x06;
  public const ulong EFI_DEP_FALSE = 0x07;
  public const ulong EFI_DEP_END = 0x08;

  ///
  /// If present, this must be the first opcode,
  /// EFI_DEP_SOR is only used by DXE driver.
  ///
  public const ulong EFI_DEP_SOR = 0x09;
}

// #endif
