namespace Uefi;
/** @file
  Simple Text Input Ex protocol from the UEFI 2.0 specification.

  This protocol defines an extension to the EFI_SIMPLE_TEXT_INPUT_PROTOCOL
  which exposes much more state and modifier information from the input device,
  also allows one to register a notification for a particular keystroke.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SIMPLE_TEXT_IN_EX_H__
// #define __SIMPLE_TEXT_IN_EX_H__

// #include <Protocol/SimpleTextIn.h>

public static EFI_GUID EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL_GUID = new GUID(0xdd9e7534, 0x7762, 0x4698, new byte[] { 0x8c, 0x14, 0xf5, 0x85, 0x17, 0xa6, 0x25, 0xaa });

// typedef struct _EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL;

































///
/// EFI_KEY_TOGGLE_STATE. The toggle states are defined.
/// They are: EFI_TOGGLE_STATE_VALID, EFI_SCROLL_LOCK_ACTIVE
/// EFI_NUM_LOCK_ACTIVE, EFI_CAPS_LOCK_ACTIVE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_KEY_TOGGLE_STATE { byte Value; public static implicit operator EFI_KEY_TOGGLE_STATE(byte value) => new EFI_KEY_TOGGLE_STATE() { Value = value }; public static implicit operator byte(EFI_KEY_TOGGLE_STATE value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_KEY_STATE
{
  ///
  /// Reflects the currently pressed shift
  /// modifiers for the input device. The
  /// returned value is valid only if the high
  /// order bit has been set.
  ///
  public uint KeyShiftState;
  ///
  /// Reflects the current internal state of
  /// various toggled attributes. The returned
  /// value is valid only if the high order
  /// bit has been set.
  ///
  public EFI_KEY_TOGGLE_STATE KeyToggleState;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_KEY_DATA
{
  ///
  /// The EFI scan code and Unicode value returned from the input device.
  ///
  public EFI_INPUT_KEY Key;
  ///
  /// The current state of various toggled attributes as well as input modifier values.
  ///
  public EFI_KEY_STATE KeyState;
}

//
// Any Shift or Toggle State that is valid should have
// high order bit set.
//
// Shift state
//
public const ulong EFI_SHIFT_STATE_VALID = 0x80000000;
public const ulong EFI_RIGHT_SHIFT_PRESSED = 0x00000001;
public const ulong EFI_LEFT_SHIFT_PRESSED = 0x00000002;
public const ulong EFI_RIGHT_CONTROL_PRESSED = 0x00000004;
public const ulong EFI_LEFT_CONTROL_PRESSED = 0x00000008;
public const ulong EFI_RIGHT_ALT_PRESSED = 0x00000010;
public const ulong EFI_LEFT_ALT_PRESSED = 0x00000020;
public const ulong EFI_RIGHT_LOGO_PRESSED = 0x00000040;
public const ulong EFI_LEFT_LOGO_PRESSED = 0x00000080;
public const ulong EFI_MENU_KEY_PRESSED = 0x00000100;
public const ulong EFI_SYS_REQ_PRESSED = 0x00000200;

//
// Toggle state
//
public const ulong EFI_TOGGLE_STATE_VALID = 0x80;
public const ulong EFI_KEY_STATE_EXPOSED = 0x40;
public const ulong EFI_SCROLL_LOCK_ACTIVE = 0x01;
public const ulong EFI_NUM_LOCK_ACTIVE = 0x02;
public const ulong EFI_CAPS_LOCK_ACTIVE = 0x04;

//
// EFI Scan codes
//
public const ulong SCAN_F11 = 0x0015;
public const ulong SCAN_F12 = 0x0016;
public const ulong SCAN_PAUSE = 0x0048;
public const ulong SCAN_F13 = 0x0068;
public const ulong SCAN_F14 = 0x0069;
public const ulong SCAN_F15 = 0x006A;
public const ulong SCAN_F16 = 0x006B;
public const ulong SCAN_F17 = 0x006C;
public const ulong SCAN_F18 = 0x006D;
public const ulong SCAN_F19 = 0x006E;
public const ulong SCAN_F20 = 0x006F;
public const ulong SCAN_F21 = 0x0070;
public const ulong SCAN_F22 = 0x0071;
public const ulong SCAN_F23 = 0x0072;
public const ulong SCAN_F24 = 0x0073;
public const ulong SCAN_MUTE = 0x007F;
public const ulong SCAN_VOLUME_UP = 0x0080;
public const ulong SCAN_VOLUME_DOWN = 0x0081;
public const ulong SCAN_BRIGHTNESS_UP = 0x0100;
public const ulong SCAN_BRIGHTNESS_DOWN = 0x0101;
public const ulong SCAN_SUSPEND = 0x0102;
public const ulong SCAN_HIBERNATE = 0x0103;
public const ulong SCAN_TOGGLE_DISPLAY = 0x0104;
public const ulong SCAN_RECOVERY = 0x0105;
public const ulong SCAN_EJECT = 0x0106;

















































































///
/// The function will be called when the key sequence is typed specified by KeyData.
///
typedef
EFI_STATUS
(EFIAPI* EFI_KEY_NOTIFY_FUNCTION)(
  IN EFI_KEY_DATA * KeyData
  );


























































///
/// The EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL is used on the ConsoleIn
/// device. It is an extension to the Simple Text Input protocol
/// which allows a variety of extended shift state information to be
/// returned.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL
{
  /**
    The Reset() function resets the input device hardware. As part
    of initialization process, the firmware/device will make a quick
    but reasonable attempt to verify that the device is functioning.
    If the ExtendedVerification flag is TRUE the firmware may take
    an extended amount of time to verify the device is operating on
    reset. Otherwise the reset operation is to occur as quickly as
    possible. The hardware verification process is not defined by
    this specification and is left up to the platform firmware or
    driver to implement.

    @param This                 A pointer to the EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL instance.

    @param ExtendedVerification Indicates that the driver may
                                perform a more exhaustive
                                verification operation of the
                                device during reset.


    @retval EFI_SUCCESS       The device was reset.

    @retval EFI_DEVICE_ERROR  The device is not functioning
                              correctly and could not be reset.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL*, bool, EFI_STATUS> Reset;
  /**
    The function reads the next keystroke from the input device. If
    there is no pending keystroke the function returns
    EFI_NOT_READY. If there is a pending keystroke, then
    KeyData.Key.ScanCode is the EFI scan code defined in Error!
    Reference source not found. The KeyData.Key.UnicodeChar is the
    actual printable character or is zero if the key does not
    represent a printable character (control key, function key,
    etc.). The KeyData.KeyState is shift state for the character
    reflected in KeyData.Key.UnicodeChar or KeyData.Key.ScanCode .
    When interpreting the data from this function, it should be
    noted that if a class of printable characters that are
    normally adjusted by shift modifiers (e.g. Shift Key + "f"
    key) would be presented solely as a KeyData.Key.UnicodeChar
    without the associated shift state. So in the previous example
    of a Shift Key + "f" key being pressed, the only pertinent
    data returned would be KeyData.Key.UnicodeChar with the value
    of "F". This of course would not typically be the case for
    non-printable characters such as the pressing of the Right
    Shift Key + F10 key since the corresponding returned data
    would be reflected both in the KeyData.KeyState.KeyShiftState
    and KeyData.Key.ScanCode values. UEFI drivers which implement
    the EFI_SIMPLE_TEXT_INPUT_EX protocol are required to return
    KeyData.Key and KeyData.KeyState values. These drivers must
    always return the most current state of
    KeyData.KeyState.KeyShiftState and
    KeyData.KeyState.KeyToggleState. It should also be noted that
    certain input devices may not be able to produce shift or toggle
    state information, and in those cases the high order bit in the
    respective Toggle and Shift state fields should not be active.


    @param This     A pointer to the EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL instance.

    @param KeyData  A pointer to a buffer that is filled in with
                    the keystroke state data for the key that was
                    pressed.


    @retval EFI_SUCCESS      The keystroke information was returned.
    @retval EFI_NOT_READY    There was no keystroke data available.
    @retval EFI_DEVICE_ERROR The keystroke information was not returned due to
                             hardware errors.


  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL*, EFI_KEY_DATA*, EFI_STATUS> ReadKeyStrokeEx;
  ///
  /// Event to use with WaitForEvent() to wait for a key to be available.
  ///
  public EFI_EVENT WaitForKeyEx;
  /**
    The SetState() function allows the input device hardware to
    have state settings adjusted.

    @param This           A pointer to the EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL instance.

    @param KeyToggleState Pointer to the EFI_KEY_TOGGLE_STATE to
                          set the state for the input device.


    @retval EFI_SUCCESS       The device state was set appropriately.

    @retval EFI_DEVICE_ERROR  The device is not functioning
                              correctly and could not have the
                              setting adjusted.

    @retval EFI_UNSUPPORTED   The device does not support the
                              ability to have its state set.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL*, EFI_KEY_TOGGLE_STATE*, EFI_STATUS> SetState;
  /**
    The RegisterKeystrokeNotify() function registers a function
    which will be called when a specified keystroke will occur.

    @param This                     A pointer to the EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL instance.

    @param KeyData                  A pointer to a buffer that is filled in with
                                    the keystroke information for the key that was
                                    pressed. If KeyData.Key, KeyData.KeyState.KeyToggleState
                                    and KeyData.KeyState.KeyShiftState are 0, then any incomplete
                                    keystroke will trigger a notification of the KeyNotificationFunction.

    @param KeyNotificationFunction  Points to the function to be called when the key sequence
                                    is typed specified by KeyData. This notification function
                                    should be called at <=TPL_CALLBACK.


    @param NotifyHandle             Points to the unique handle assigned to
                                    the registered notification.

    @retval EFI_SUCCESS           Key notify was registered successfully.

    @retval EFI_OUT_OF_RESOURCES  Unable to allocate necessary
                                  data structures.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL*, EFI_KEY_DATA*, EFI_KEY_NOTIFY_FUNCTION, void**, EFI_STATUS> RegisterKeyNotify;
  /**
    The UnregisterKeystrokeNotify() function removes the
    notification which was previously registered.

    @param This               A pointer to the EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL instance.

    @param NotificationHandle The handle of the notification
                              function being unregistered.

    @retval EFI_SUCCESS           Key notify was unregistered successfully.

    @retval EFI_INVALID_PARAMETER The NotificationHandle is
                                  invalid.

  **/
  public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL*, void*, EFI_STATUS> UnregisterKeyNotify;
}

// extern EFI_GUID  gEfiSimpleTextInputExProtocolGuid;

// #endif
