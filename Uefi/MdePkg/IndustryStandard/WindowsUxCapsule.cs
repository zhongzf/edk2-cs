using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Defines Windows UX Capsule GUID and layout defined at Microsoft
  Windows UEFI Firmware Update Platform specification

  Copyright (c) 2015 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _WINDOWS_UX_CAPSULE_GUID_H_
// #define _WINDOWS_UX_CAPSULE_GUID_H_

// #pragma pack(1)

[StructLayout(LayoutKind.Sequential)]
public unsafe struct DISPLAY_DISPLAY_PAYLOAD
{
  public byte Version;
  public byte Checksum;
  public byte ImageType;
  public byte Reserved;
  public uint Mode;
  public uint OffsetX;
  public uint OffsetY;
  // byte  Image[];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DISPLAY_CAPSULE
{
  public EFI_CAPSULE_HEADER CapsuleHeader;
  public DISPLAY_DISPLAY_PAYLOAD ImagePayload;
}

// #pragma pack()

public unsafe partial class EFI
{
  public static EFI_GUID WINDOWS_UX_CAPSULE_GUID => new GUID(
      0x3b8c8162, 0x188c, 0x46a4, 0xae, 0xc9, 0xbe, 0x43, 0xf1, 0xd6, 0x56, 0x97);

  // extern EFI_GUID  gWindowsUxCapsuleGuid;
}

// #endif
