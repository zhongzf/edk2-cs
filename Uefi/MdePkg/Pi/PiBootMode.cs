using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Present the boot mode values in PI.

  Copyright (c) 2006 - 2012, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  PI Version 1.2.1A

**/

// #ifndef __PI_BOOT_MODE_H__
// #define __PI_BOOT_MODE_H__

///
/// EFI boot mode
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BOOT_MODE { uint Value; public static implicit operator EFI_BOOT_MODE(uint value) => new EFI_BOOT_MODE() { Value = value }; public static implicit operator uint(EFI_BOOT_MODE value) => value.Value; }

public unsafe partial class EFI
{
  //
  // 0x21 - 0xf..f are reserved.
  //
  public const ulong BOOT_WITH_FULL_CONFIGURATION = 0x00;
  public const ulong BOOT_WITH_MINIMAL_CONFIGURATION = 0x01;
  public const ulong BOOT_ASSUMING_NO_CONFIGURATION_CHANGES = 0x02;
  public const ulong BOOT_WITH_FULL_CONFIGURATION_PLUS_DIAGNOSTICS = 0x03;
  public const ulong BOOT_WITH_DEFAULT_SETTINGS = 0x04;
  public const ulong BOOT_ON_S4_RESUME = 0x05;
  public const ulong BOOT_ON_S5_RESUME = 0x06;
  public const ulong BOOT_WITH_MFG_MODE_SETTINGS = 0x07;
  public const ulong BOOT_ON_S2_RESUME = 0x10;
  public const ulong BOOT_ON_S3_RESUME = 0x11;
  public const ulong BOOT_ON_FLASH_UPDATE = 0x12;
  public const ulong BOOT_IN_RECOVERY_MODE = 0x20;
}

// #endif
