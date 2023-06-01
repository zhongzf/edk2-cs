namespace Uefi;
/** @file
  EDID Active Protocol from the UEFI 2.0 specification.

  Placed on the video output device child handle that is actively displaying output.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __EDID_ACTIVE_H__
// #define __EDID_ACTIVE_H__

public static EFI_GUID EFI_EDID_ACTIVE_PROTOCOL_GUID = new GUID(
    0xbd8c1056, 0x9f36, 0x44ec, new byte[] { 0x92, 0xa8, 0xa6, 0x33, 0x7f, 0x81, 0x79, 0x86 });

///
/// This protocol contains the EDID information for an active video output device. This is either the
/// EDID information retrieved from the EFI_EDID_OVERRIDE_PROTOCOL if an override is
/// available, or an identical copy of the EDID information from the
/// EFI_EDID_DISCOVERED_PROTOCOL if no overrides are available.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_EDID_ACTIVE_PROTOCOL
{
  ///
  /// The size, in bytes, of the Edid buffer. 0 if no EDID information
  /// is available from the video output device. Otherwise, it must be a
  /// minimum of 128 bytes.
  ///
  public uint SizeOfEdid;

  ///
  /// A pointer to a read-only array of bytes that contains the EDID
  /// information for an active video output device. This pointer is
  /// NULL if no EDID information is available for the video output
  /// device. The minimum size of a valid Edid buffer is 128 bytes.
  /// EDID information is defined in the E-EDID EEPROM
  /// specification published by VESA (www.vesa.org).
  ///
  public byte* Edid;
}

// extern EFI_GUID  gEfiEdidActiveProtocolGuid;

// #endif
