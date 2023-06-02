using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  The file provides services that allow information about an
  absolute pointer device to be retrieved.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in UEFI Specification 2.3.

**/

// #ifndef __ABSOLUTE_POINTER_H__
// #define __ABSOLUTE_POINTER_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_ABSOLUTE_POINTER_PROTOCOL_GUID = new GUID(0x8D59D32B, 0xC655, 0x4AE9, new byte[] { 0x9B, 0x15, 0xF2, 0x59, 0x04, 0x99, 0x2A, 0x43 });

  // typedef struct _EFI_ABSOLUTE_POINTER_PROTOCOL EFI_ABSOLUTE_POINTER_PROTOCOL;

  // *******************************************************
  // EFI_ABSOLUTE_POINTER_MODE
  // *******************************************************
}

/**
  The following data values in the EFI_ABSOLUTE_POINTER_MODE
  interface are read-only and are changed by using the appropriate
  interface functions.
**/
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ABSOLUTE_POINTER_MODE
{
  public ulong AbsoluteMinX; ///< The Absolute Minimum of the device on the x-axis
  public ulong AbsoluteMinY; ///< The Absolute Minimum of the device on the y axis.
  public ulong AbsoluteMinZ; ///< The Absolute Minimum of the device on the z-axis
  public ulong AbsoluteMaxX; ///< The Absolute Maximum of the device on the x-axis. If 0, and the
                             ///< AbsoluteMinX is 0, then the pointer device does not support a xaxis
  public ulong AbsoluteMaxY; ///< The Absolute Maximum of the device on the y -axis. If 0, and the
                             ///< AbsoluteMinX is 0, then the pointer device does not support a yaxis.
  public ulong AbsoluteMaxZ; ///< The Absolute Maximum of the device on the z-axis. If 0 , and the
                             ///< AbsoluteMinX is 0, then the pointer device does not support a zaxis
  public uint Attributes;   ///< The following bits are set as needed (or'd together) to indicate the
                            ///< capabilities of the device supported. The remaining bits are undefined
                            ///< and should be 0
}

///
/// If set, indicates this device supports an alternate button input.
///
public unsafe partial class EFI
{
  public const ulong EFI_ABSP_SupportsAltActive = 0x00000001;

  ///
  /// If set, indicates this device returns pressure data in parameter CurrentZ.
  ///
  public const ulong EFI_ABSP_SupportsPressureAsZ = 0x00000002;

  ///
  /// This bit is set if the touch sensor is active.
  ///
  public const ulong EFI_ABSP_TouchActive = 0x00000001;

  ///
  /// This bit is set if the alt sensor, such as pen-side button, is active
  ///
  public const ulong EFI_ABS_AltActive = 0x00000002;
}

/**
  Definition of EFI_ABSOLUTE_POINTER_STATE.
**/
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ABSOLUTE_POINTER_STATE
{
  ///
  /// The unsigned position of the activation on the x axis. If the AboluteMinX
  /// and the AboluteMaxX fields of the EFI_ABSOLUTE_POINTER_MODE structure are
  /// both 0, then this pointer device does not support an x-axis, and this field
  /// must be ignored.
  ///
  public ulong CurrentX;

  ///
  /// The unsigned position of the activation on the y axis. If the AboluteMinY
  /// and the AboluteMaxY fields of the EFI_ABSOLUTE_POINTER_MODE structure are
  /// both 0, then this pointer device does not support an y-axis, and this field
  /// must be ignored.
  ///
  public ulong CurrentY;

  ///
  /// The unsigned position of the activation on the z axis, or the pressure
  /// measurement. If the AboluteMinZ and the AboluteMaxZ fields of the
  /// EFI_ABSOLUTE_POINTER_MODE structure are both 0, then this pointer device
  /// does not support an z-axis, and this field must be ignored.
  ///
  public ulong CurrentZ;

  ///
  /// Bits are set to 1 in this structure item to indicate that device buttons are
  /// active.
  ///
  public uint ActiveButtons;
}

///
/// The EFI_ABSOLUTE_POINTER_PROTOCOL provides a set of services
/// for a pointer device that can be used as an input device from an
/// application written to this specification. The services include
/// the ability to: reset the pointer device, retrieve the state of
/// the pointer device, and retrieve the capabilities of the pointer
/// device. The service also provides certain data items describing the device.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ABSOLUTE_POINTER_PROTOCOL
{
  /**
    This function resets the pointer device hardware. As part of
    initialization process, the firmware/device will make a quick
    but reasonable attempt to verify that the device is
    functioning. If the ExtendedVerification flag is TRUE the
    firmware may take an extended amount of time to verify the
    device is operating on reset. Otherwise the reset operation is
    to occur as quickly as possible. The hardware verification
    process is not defined by this specification and is left up to
    the platform firmware or driver to implement.

    @param This                 A pointer to the EFI_ABSOLUTE_POINTER_PROTOCOL
                                instance.

    @param ExtendedVerification Indicates that the driver may
                                perform a more exhaustive
                                verification operation of the
                                device during reset.

    @retval EFI_SUCCESS       The device was reset.

    @retval EFI_DEVICE_ERROR  The device is not functioning
                              correctly and could not be reset.

  **/
  public readonly delegate* unmanaged<EFI_ABSOLUTE_POINTER_PROTOCOL*, bool, EFI_STATUS> Reset;
  /**
    The GetState() function retrieves the current state of a pointer
    device. This includes information on the active state associated
    with the pointer device and the current position of the axes
    associated with the pointer device. If the state of the pointer
    device has not changed since the last call to GetState(), then
    EFI_NOT_READY is returned. If the state of the pointer device
    has changed since the last call to GetState(), then the state
    information is placed in State, and EFI_SUCCESS is returned. If
    a device error occurs while attempting to retrieve the state
    information, then EFI_DEVICE_ERROR is returned.

    @param This   A pointer to the EFI_ABSOLUTE_POINTER_PROTOCOL
                  instance.

    @param State  A pointer to the state information on the
                  pointer device.

    @retval EFI_SUCCESS       The state of the pointer device was
                              returned in State.

    @retval EFI_NOT_READY     The state of the pointer device has not
                              changed since the last call to GetState().

    @retval EFI_DEVICE_ERROR  A device error occurred while
                              attempting to retrieve the pointer
                              device's current state.

  **/
  public readonly delegate* unmanaged<EFI_ABSOLUTE_POINTER_PROTOCOL*, EFI_ABSOLUTE_POINTER_STATE*, EFI_STATUS> GetState;
  ///
  /// Event to use with WaitForEvent() to wait for input from the pointer device.
  ///
  public EFI_EVENT WaitForInput;
  ///
  /// Pointer to EFI_ABSOLUTE_POINTER_MODE data.
  ///
  public EFI_ABSOLUTE_POINTER_MODE* Mode;
}

// extern EFI_GUID  gEfiAbsolutePointerProtocolGuid;

// #endif
