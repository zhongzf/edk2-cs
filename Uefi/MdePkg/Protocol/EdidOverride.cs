using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EDID Override Protocol from the UEFI 2.0 specification.

  Allow platform to provide EDID information to the producer of the Graphics Output
  protocol.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __EDID_OVERRIDE_H__
// #define __EDID_OVERRIDE_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_EDID_OVERRIDE_PROTOCOL_GUID = new GUID(
      0x48ecb431, 0xfb72, 0x45c0, new byte[] { 0xa9, 0x22, 0xf4, 0x58, 0xfe, 0x4, 0xb, 0xd5 });

  // typedef struct _EFI_EDID_OVERRIDE_PROTOCOL EFI_EDID_OVERRIDE_PROTOCOL;

  public const ulong EFI_EDID_OVERRIDE_DONT_OVERRIDE = 0x01;
  public const ulong EFI_EDID_OVERRIDE_ENABLE_HOT_PLUG = 0x02;

}

///
/// This protocol is produced by the platform to allow the platform to provide
/// EDID information to the producer of the Graphics Output protocol.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_EDID_OVERRIDE_PROTOCOL
{
  /**
    Returns policy information and potentially a replacement EDID for the specified video output device.

    @param  This              The EFI_EDID_OVERRIDE_PROTOCOL instance.
    @param  ChildHandle       A child handle produced by the Graphics Output EFI
                              driver that represents a video output device.
    @param  Attributes        The attributes associated with ChildHandle video output device.
    @param  EdidSize          A pointer to the size, in bytes, of the Edid buffer.
    @param  Edid              A pointer to callee allocated buffer that contains the EDID that
                              should be used for ChildHandle. A value of NULL
                              represents no EDID override for ChildHandle.

    @retval EFI_SUCCESS       Valid overrides returned for ChildHandle.
    @retval EFI_UNSUPPORTED   ChildHandle has no overrides.

  **/
  public readonly delegate* unmanaged<EFI_EDID_OVERRIDE_PROTOCOL*, EFI_HANDLE*, uint*, ulong*, byte**, EFI_STATUS> GetEdid;
}

// extern EFI_GUID  gEfiEdidOverrideProtocolGuid;

// #endif
