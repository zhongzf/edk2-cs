namespace Uefi;
/** @file
  EFI_DEVICE_PATH_TO_TEXT_PROTOCOL as defined in UEFI 2.0.
  This protocol provides service to convert device nodes and paths to text.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __DEVICE_PATH_TO_TEXT_PROTOCOL_H__
// #define __DEVICE_PATH_TO_TEXT_PROTOCOL_H__

///
/// Device Path To Text protocol
///
public static EFI_GUID EFI_DEVICE_PATH_TO_TEXT_PROTOCOL_GUID = new GUID(
    0x8b843e20, 0x8132, 0x4852, new byte[] { 0x90, 0xcc, 0x55, 0x1a, 0x4e, 0x4a, 0x7f, 0x1c });















































///
/// This protocol converts device paths and device nodes to text.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEVICE_PATH_TO_TEXT_PROTOCOL
{
  /**
    Convert a device node to its text representation.

    @param  DeviceNode     Points to the device node to be converted.
    @param  DisplayOnly    If DisplayOnly is TRUE, then the shorter text representation
                           of the display node is used, where applicable. If DisplayOnly
                           is FALSE, then the longer text representation of the display node
                           is used.
    @param  AllowShortcuts If AllowShortcuts is TRUE, then the shortcut forms of text
                           representation for a device node can be used, where applicable.

    @retval a_pointer      a pointer to the allocated text representation of the device node data
    @retval NULL           if DeviceNode is NULL or there was insufficient memory.

  **/
  public readonly delegate* unmanaged<CONST, bool, bool, EFI_STATUS> ConvertDeviceNodeToText;
  /**
    Convert a device path to its text representation.

    @param  DevicePath     Points to the device path to be converted.
    @param  DisplayOnly    If DisplayOnly is TRUE, then the shorter text representation
                           of the display node is used, where applicable. If DisplayOnly
                           is FALSE, then the longer text representation of the display node
                           is used.
    @param  AllowShortcuts The AllowShortcuts is FALSE, then the shortcut forms of
                           text representation for a device node cannot be used.

    @retval a_pointer      a pointer to the allocated text representation of the device node.
    @retval NULL           if DevicePath is NULL or there was insufficient memory.

  **/
  public readonly delegate* unmanaged<CONST, bool, bool, EFI_STATUS> ConvertDevicePathToText;
}

// extern EFI_GUID  gEfiDevicePathToTextProtocolGuid;

// #endif
