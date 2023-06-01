using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Simple Text Out protocol from the UEFI 2.0 specification.

  Abstraction of a very simple text based output device like VGA text mode or
  a serial terminal. The Simple Text Out protocol instance can represent
  a single hardware device or a virtual device that is an aggregation
  of multiple physical devices.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SIMPLE_TEXT_OUT_H__
// #define __SIMPLE_TEXT_OUT_H__

public static EFI_GUID EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL_GUID = new GUID(
    0x387477c2, 0x69c7, 0x11d2, new byte[] { 0x8e, 0x39, 0x0, 0xa0, 0xc9, 0x69, 0x72, 0x3b });

///
/// Protocol GUID defined in EFI1.1.
///
public const ulong SIMPLE_TEXT_OUTPUT_PROTOCOL = EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL_GUID;

// typedef struct _EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL;

///
/// Backward-compatible with EFI1.1.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SIMPLE_TEXT_OUTPUT_INTERFACE { EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL Value; public static implicit operator SIMPLE_TEXT_OUTPUT_INTERFACE(EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL value) => new SIMPLE_TEXT_OUTPUT_INTERFACE() { Value = value }; public static implicit operator EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL(SIMPLE_TEXT_OUTPUT_INTERFACE value) => value.Value; }

//
// Defines for required EFI Unicode Box Draw characters
//
public const ulong BOXDRAW_HORIZONTAL = 0x2500;
public const ulong BOXDRAW_VERTICAL = 0x2502;
public const ulong BOXDRAW_DOWN_RIGHT = 0x250c;
public const ulong BOXDRAW_DOWN_LEFT = 0x2510;
public const ulong BOXDRAW_UP_RIGHT = 0x2514;
public const ulong BOXDRAW_UP_LEFT = 0x2518;
public const ulong BOXDRAW_VERTICAL_RIGHT = 0x251c;
public const ulong BOXDRAW_VERTICAL_LEFT = 0x2524;
public const ulong BOXDRAW_DOWN_HORIZONTAL = 0x252c;
public const ulong BOXDRAW_UP_HORIZONTAL = 0x2534;
public const ulong BOXDRAW_VERTICAL_HORIZONTAL = 0x253c;
public const ulong BOXDRAW_DOUBLE_HORIZONTAL = 0x2550;
public const ulong BOXDRAW_DOUBLE_VERTICAL = 0x2551;
public const ulong BOXDRAW_DOWN_RIGHT_DOUBLE = 0x2552;
public const ulong BOXDRAW_DOWN_DOUBLE_RIGHT = 0x2553;
public const ulong BOXDRAW_DOUBLE_DOWN_RIGHT = 0x2554;
public const ulong BOXDRAW_DOWN_LEFT_DOUBLE = 0x2555;
public const ulong BOXDRAW_DOWN_DOUBLE_LEFT = 0x2556;
public const ulong BOXDRAW_DOUBLE_DOWN_LEFT = 0x2557;
public const ulong BOXDRAW_UP_RIGHT_DOUBLE = 0x2558;
public const ulong BOXDRAW_UP_DOUBLE_RIGHT = 0x2559;
public const ulong BOXDRAW_DOUBLE_UP_RIGHT = 0x255a;
public const ulong BOXDRAW_UP_LEFT_DOUBLE = 0x255b;
public const ulong BOXDRAW_UP_DOUBLE_LEFT = 0x255c;
public const ulong BOXDRAW_DOUBLE_UP_LEFT = 0x255d;
public const ulong BOXDRAW_VERTICAL_RIGHT_DOUBLE = 0x255e;
public const ulong BOXDRAW_VERTICAL_DOUBLE_RIGHT = 0x255f;
public const ulong BOXDRAW_DOUBLE_VERTICAL_RIGHT = 0x2560;
public const ulong BOXDRAW_VERTICAL_LEFT_DOUBLE = 0x2561;
public const ulong BOXDRAW_VERTICAL_DOUBLE_LEFT = 0x2562;
public const ulong BOXDRAW_DOUBLE_VERTICAL_LEFT = 0x2563;
public const ulong BOXDRAW_DOWN_HORIZONTAL_DOUBLE = 0x2564;
public const ulong BOXDRAW_DOWN_DOUBLE_HORIZONTAL = 0x2565;
public const ulong BOXDRAW_DOUBLE_DOWN_HORIZONTAL = 0x2566;
public const ulong BOXDRAW_UP_HORIZONTAL_DOUBLE = 0x2567;
public const ulong BOXDRAW_UP_DOUBLE_HORIZONTAL = 0x2568;
public const ulong BOXDRAW_DOUBLE_UP_HORIZONTAL = 0x2569;
public const ulong BOXDRAW_VERTICAL_HORIZONTAL_DOUBLE = 0x256a;
public const ulong BOXDRAW_VERTICAL_DOUBLE_HORIZONTAL = 0x256b;
public const ulong BOXDRAW_DOUBLE_VERTICAL_HORIZONTAL = 0x256c;

//
// EFI Required Block Elements Code Chart
//
public const ulong BLOCKELEMENT_FULL_BLOCK = 0x2588;
public const ulong BLOCKELEMENT_LIGHT_SHADE = 0x2591;

//
// EFI Required Geometric Shapes Code Chart
//
public const ulong GEOMETRICSHAPE_UP_TRIANGLE = 0x25b2;
public const ulong GEOMETRICSHAPE_RIGHT_TRIANGLE = 0x25ba;
public const ulong GEOMETRICSHAPE_DOWN_TRIANGLE = 0x25bc;
public const ulong GEOMETRICSHAPE_LEFT_TRIANGLE = 0x25c4;

//
// EFI Required Arrow shapes
//
public const ulong ARROW_LEFT = 0x2190;
public const ulong ARROW_UP = 0x2191;
public const ulong ARROW_RIGHT = 0x2192;
public const ulong ARROW_DOWN = 0x2193;

//
// EFI Console Colours
//
public const ulong EFI_BLACK = 0x00;
public const ulong EFI_BLUE = 0x01;
public const ulong EFI_GREEN = 0x02;
public const ulong EFI_CYAN = (EFI_BLUE | EFI_GREEN);
public const ulong EFI_RED = 0x04;
public const ulong EFI_MAGENTA = (EFI_BLUE | EFI_RED);
public const ulong EFI_BROWN = (EFI_GREEN | EFI_RED);
public const ulong EFI_LIGHTGRAY = (EFI_BLUE | EFI_GREEN | EFI_RED);
public const ulong EFI_BRIGHT = 0x08;
public const ulong EFI_DARKGRAY = (EFI_BLACK | EFI_BRIGHT);
public const ulong EFI_LIGHTBLUE = (EFI_BLUE | EFI_BRIGHT);
public const ulong EFI_LIGHTGREEN = (EFI_GREEN | EFI_BRIGHT);
public const ulong EFI_LIGHTCYAN = (EFI_CYAN | EFI_BRIGHT);
public const ulong EFI_LIGHTRED = (EFI_RED | EFI_BRIGHT);
public const ulong EFI_LIGHTMAGENTA = (EFI_MAGENTA | EFI_BRIGHT);
public const ulong EFI_YELLOW = (EFI_BROWN | EFI_BRIGHT);
public const ulong EFI_WHITE = (EFI_BLUE | EFI_GREEN | EFI_RED | EFI_BRIGHT);

//
// Macro to accept color values in their raw form to create
// a value that represents both a foreground and background
// color in a single byte.
// For Foreground, and EFI_* value is valid from EFI_BLACK(0x00) to
// EFI_WHITE (0x0F).
// For Background, only EFI_BLACK, EFI_BLUE, EFI_GREEN, EFI_CYAN,
// EFI_RED, EFI_MAGENTA, EFI_BROWN, and EFI_LIGHTGRAY are acceptable
//
// Do not use EFI_BACKGROUND_xxx values with this macro.
//
public const ulong EFI_TEXT_ATTR = (Foreground, Background)((Foreground) | ((Background) << 4));

public const ulong EFI_BACKGROUND_BLACK = 0x00;
public const ulong EFI_BACKGROUND_BLUE = 0x10;
public const ulong EFI_BACKGROUND_GREEN = 0x20;
public const ulong EFI_BACKGROUND_CYAN = (EFI_BACKGROUND_BLUE | EFI_BACKGROUND_GREEN);
public const ulong EFI_BACKGROUND_RED = 0x40;
public const ulong EFI_BACKGROUND_MAGENTA = (EFI_BACKGROUND_BLUE | EFI_BACKGROUND_RED);
public const ulong EFI_BACKGROUND_BROWN = (EFI_BACKGROUND_GREEN | EFI_BACKGROUND_RED);
public const ulong EFI_BACKGROUND_LIGHTGRAY = (EFI_BACKGROUND_BLUE | EFI_BACKGROUND_GREEN | EFI_BACKGROUND_RED);

//
// We currently define attributes from 0 - 7F for color manipulations
// To internally handle the local display characteristics for a particular character,
// Bit 7 signifies the local glyph representation for a character.  If turned on, glyphs will be
// pulled from the wide glyph database and will display locally as a wide character (16 X 19 versus 8 X 19)
// If bit 7 is off, the narrow glyph database will be used.  This does NOT affect information that is sent to
// non-local displays, such as serial or LAN consoles.
//
public const ulong EFI_WIDE_ATTRIBUTE = 0x80;

































































































































































































/**
  @par Data Structure Description:
  Mode Structure pointed to by Simple Text Out protocol.
**/
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SIMPLE_TEXT_OUTPUT_MODE
{
  ///
  /// The number of modes supported by QueryMode () and SetMode ().
  ///
  public int MaxMode;

  //
  // current settings
  //

  ///
  /// The text mode of the output device(s).
  ///
  public int Mode;
  ///
  /// The current character output attribute.
  ///
  public int Attribute;
  ///
  /// The cursor's column.
  ///
  public int CursorColumn;
  ///
  /// The cursor's row.
  ///
  public int CursorRow;
  ///
  /// The cursor is currently visible or not.
  ///
  public bool CursorVisible;
}

///
/// The SIMPLE_TEXT_OUTPUT protocol is used to control text-based output devices.
/// It is the minimum required protocol for any handle supplied as the ConsoleOut
/// or StandardError device. In addition, the minimum supported text mode of such
/// devices is at least 80 x 25 characters.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL
{
  /**
    Reset the text output device hardware and optionally run diagnostics

    @param  This                 The protocol instance pointer.
    @param  ExtendedVerification Driver may perform more exhaustive verification
                                 operation of the device during reset.

    @retval EFI_SUCCESS          The text output device was reset.
    @retval EFI_DEVICE_ERROR     The text output device is not functioning correctly and
                                 could not be reset.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, bool, EFI_STATUS> Reset;

  /**
    Write a string to the output device.

    @param  This   The protocol instance pointer.
    @param  String The NULL-terminated string to be displayed on the output
                   device(s). All output devices must also support the Unicode
                   drawing character codes defined in this file.

    @retval EFI_SUCCESS             The string was output to the device.
    @retval EFI_DEVICE_ERROR        The device reported an error while attempting to output
                                    the text.
    @retval EFI_UNSUPPORTED         The output device's mode is not currently in a
                                    defined text mode.
    @retval EFI_WARN_UNKNOWN_GLYPH  This warning code indicates that some of the
                                    characters in the string could not be
                                    rendered and were skipped.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, char*, EFI_STATUS> OutputString;
  /**
    Verifies that all characters in a string can be output to the
    target device.

    @param  This   The protocol instance pointer.
    @param  String The NULL-terminated string to be examined for the output
                   device(s).

    @retval EFI_SUCCESS      The device(s) are capable of rendering the output string.
    @retval EFI_UNSUPPORTED  Some of the characters in the string cannot be
                             rendered by one or more of the output devices mapped
                             by the EFI handle.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, char*, EFI_STATUS> TestString;

  /**
    Returns information for an available text mode that the output device(s)
    supports.

    @param  This       The protocol instance pointer.
    @param  ModeNumber The mode number to return information on.
    @param  Columns    Returns the geometry of the text output device for the
                       requested ModeNumber.
    @param  Rows       Returns the geometry of the text output device for the
                       requested ModeNumber.

    @retval EFI_SUCCESS      The requested mode information was returned.
    @retval EFI_DEVICE_ERROR The device had an error and could not complete the request.
    @retval EFI_UNSUPPORTED  The mode number was not valid.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, ulong, ulong*, ulong*, EFI_STATUS> QueryMode;
  /**
    Sets the output device(s) to a specified mode.

    @param  This       The protocol instance pointer.
    @param  ModeNumber The mode number to set.

    @retval EFI_SUCCESS      The requested text mode was set.
    @retval EFI_DEVICE_ERROR The device had an error and could not complete the request.
    @retval EFI_UNSUPPORTED  The mode number was not valid.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, ulong, EFI_STATUS> SetMode;
  /**
    Sets the background and foreground colors for the OutputString () and
    ClearScreen () functions.

    @param  This      The protocol instance pointer.
    @param  Attribute The attribute to set. Bits 0..3 are the foreground color, and
                      bits 4..6 are the background color. All other bits are undefined
                      and must be zero. The valid Attributes are defined in this file.

    @retval EFI_SUCCESS       The attribute was set.
    @retval EFI_DEVICE_ERROR  The device had an error and could not complete the request.
    @retval EFI_UNSUPPORTED   The attribute requested is not defined.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, ulong, EFI_STATUS> SetAttribute;

  /**
    Clears the output device(s) display to the currently selected background
    color.

    @param  This              The protocol instance pointer.

    @retval  EFI_SUCCESS      The operation completed successfully.
    @retval  EFI_DEVICE_ERROR The device had an error and could not complete the request.
    @retval  EFI_UNSUPPORTED  The output device is not in a valid text mode.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, EFI_STATUS> ClearScreen;
  /**
    Sets the current coordinates of the cursor position

    @param  This        The protocol instance pointer.
    @param  Column      The position to set the cursor to. Must be greater than or
                        equal to zero and less than the number of columns and rows
                        by QueryMode ().
    @param  Row         The position to set the cursor to. Must be greater than or
                        equal to zero and less than the number of columns and rows
                        by QueryMode ().

    @retval EFI_SUCCESS      The operation completed successfully.
    @retval EFI_DEVICE_ERROR The device had an error and could not complete the request.
    @retval EFI_UNSUPPORTED  The output device is not in a valid text mode, or the
                             cursor position is invalid for the current mode.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, ulong, ulong, EFI_STATUS> SetCursorPosition;
  /**
    Makes the cursor visible or invisible

    @param  This    The protocol instance pointer.
    @param  Visible If TRUE, the cursor is set to be visible. If FALSE, the cursor is
                    set to be invisible.

    @retval EFI_SUCCESS      The operation completed successfully.
    @retval EFI_DEVICE_ERROR The device had an error and could not complete the
                             request, or the device does not support changing
                             the cursor mode.
    @retval EFI_UNSUPPORTED  The output device is not in a valid text mode.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, bool, EFI_STATUS> EnableCursor;

  ///
  /// Pointer to SIMPLE_TEXT_OUTPUT_MODE data.
  ///
  public EFI_SIMPLE_TEXT_OUTPUT_MODE* Mode;
}

// extern EFI_GUID  gEfiSimpleTextOutProtocolGuid;

// #endif
