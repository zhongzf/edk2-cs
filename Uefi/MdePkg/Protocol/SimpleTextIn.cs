using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Simple Text Input protocol from the UEFI 2.0 specification.

  Abstraction of a very simple input device like a keyboard or serial
  terminal.

  Copyright (c) 2006 - 2011, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SIMPLE_TEXT_IN_PROTOCOL_H__
// #define __SIMPLE_TEXT_IN_PROTOCOL_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_SIMPLE_TEXT_INPUT_PROTOCOL_GUID = new GUID(
      0x387477c1, 0x69c7, 0x11d2, new byte[] { 0x8e, 0x39, 0x0, 0xa0, 0xc9, 0x69, 0x72, 0x3b });

  // typedef struct _EFI_SIMPLE_TEXT_INPUT_PROTOCOL EFI_SIMPLE_TEXT_INPUT_PROTOCOL;

  ///
  /// Protocol GUID name defined in EFI1.1.
  ///
  public const ulong SIMPLE_INPUT_PROTOCOL = EFI_SIMPLE_TEXT_INPUT_PROTOCOL_GUID;

  ///
  /// Protocol name in EFI1.1 for backward-compatible.
  ///
  // typedef struct _EFI_SIMPLE_TEXT_INPUT_PROTOCOL SIMPLE_INPUT_INTERFACE;
}

///
/// The keystroke information for the key that was pressed.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_INPUT_KEY
{
  public ushort ScanCode;
  public char UnicodeChar;
}

//
// Required unicode control chars
//
public unsafe partial class EFI
{
  public const ulong CHAR_BACKSPACE = 0x0008;
  public const ulong CHAR_TAB = 0x0009;
  public const ulong CHAR_LINEFEED = 0x000A;
  public const ulong CHAR_CARRIAGE_RETURN = 0x000D;

  //
  // EFI Scan codes
  //
  public const ulong SCAN_NULL = 0x0000;
  public const ulong SCAN_UP = 0x0001;
  public const ulong SCAN_DOWN = 0x0002;
  public const ulong SCAN_RIGHT = 0x0003;
  public const ulong SCAN_LEFT = 0x0004;
  public const ulong SCAN_HOME = 0x0005;
  public const ulong SCAN_END = 0x0006;
  public const ulong SCAN_INSERT = 0x0007;
  public const ulong SCAN_DELETE = 0x0008;
  public const ulong SCAN_PAGE_UP = 0x0009;
  public const ulong SCAN_PAGE_DOWN = 0x000A;
  public const ulong SCAN_F1 = 0x000B;
  public const ulong SCAN_F2 = 0x000C;
  public const ulong SCAN_F3 = 0x000D;
  public const ulong SCAN_F4 = 0x000E;
  public const ulong SCAN_F5 = 0x000F;
  public const ulong SCAN_F6 = 0x0010;
  public const ulong SCAN_F7 = 0x0011;
  public const ulong SCAN_F8 = 0x0012;
  public const ulong SCAN_F9 = 0x0013;
  public const ulong SCAN_F10 = 0x0014;
  public const ulong SCAN_ESC = 0x0017;

}

///
/// The EFI_SIMPLE_TEXT_INPUT_PROTOCOL is used on the ConsoleIn device.
/// It is the minimum required protocol for ConsoleIn.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SIMPLE_TEXT_INPUT_PROTOCOL
{
  /**
    Reset the input device and optionally run diagnostics

    @param  This                 Protocol instance pointer.
    @param  ExtendedVerification Driver may perform diagnostics on reset.

    @retval EFI_SUCCESS          The device was reset.
    @retval EFI_DEVICE_ERROR     The device is not functioning properly and could not be reset.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_INPUT_PROTOCOL*, bool, EFI_STATUS> Reset;
  /**
    Reads the next keystroke from the input device. The WaitForKey Event can
    be used to test for existence of a keystroke via WaitForEvent () call.

    @param  This  Protocol instance pointer.
    @param  Key   A pointer to a buffer that is filled in with the keystroke
                  information for the key that was pressed.

    @retval EFI_SUCCESS      The keystroke information was returned.
    @retval EFI_NOT_READY    There was no keystroke data available.
    @retval EFI_DEVICE_ERROR The keystroke information was not returned due to
                             hardware errors.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_INPUT_PROTOCOL*, EFI_INPUT_KEY*, EFI_STATUS> ReadKeyStroke;
  ///
  /// Event to use with WaitForEvent() to wait for a key to be available
  ///
  public EFI_EVENT WaitForKey;
}

// extern EFI_GUID  gEfiSimpleTextInProtocolGuid;

// #endif
