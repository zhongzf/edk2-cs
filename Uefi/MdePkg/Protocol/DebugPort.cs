using System.Runtime.InteropServices;

namespace Uefi;
/** @file

  The file defines the EFI Debugport protocol.
  This protocol is used by debug agent to communicate with the
  remote debug host.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __DEBUG_PORT_H__
// #define __DEBUG_PORT_H__

///
/// DebugPortIo protocol {EBA4E8D2-3858-41EC-A281-2647BA9660D0}
///
public unsafe partial class EFI
{
  public static EFI_GUID EFI_DEBUGPORT_PROTOCOL_GUID = new GUID(
      0xEBA4E8D2, 0x3858, 0x41EC, new byte[] { 0xA2, 0x81, 0x26, 0x47, 0xBA, 0x96, 0x60, 0xD0 });

  // extern EFI_GUID  gEfiDebugPortProtocolGuid;

  // typedef struct _EFI_DEBUGPORT_PROTOCOL EFI_DEBUGPORT_PROTOCOL;

  //
  // DebugPort member functions
  //

}

///
/// This protocol provides the communication link between the debug agent and the remote host.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEBUGPORT_PROTOCOL
{
  /**
    Resets the debugport.

    @param  This                  A pointer to the EFI_DEBUGPORT_PROTOCOL instance.

    @retval EFI_SUCCESS           The debugport device was reset and is in usable state.
    @retval EFI_DEVICE_ERROR      The debugport device could not be reset and is unusable.

  **/
  public readonly delegate* unmanaged<EFI_DEBUGPORT_PROTOCOL*, EFI_STATUS> Reset;
  /**
    Writes data to the debugport.

    @param  This                  A pointer to the EFI_DEBUGPORT_PROTOCOL instance.
    @param  Timeout               The number of microseconds to wait before timing out a write operation.
    @param  BufferSize            On input, the requested number of bytes of data to write. On output, the
                                  number of bytes of data actually written.
    @param  Buffer                A pointer to a buffer containing the data to write.

    @retval EFI_SUCCESS           The data was written.
    @retval EFI_DEVICE_ERROR      The device reported an error.
    @retval EFI_TIMEOUT           The data write was stopped due to a timeout.

  **/
  public readonly delegate* unmanaged<EFI_DEBUGPORT_PROTOCOL*, uint, ulong*, void*, EFI_STATUS> Write;
  /**
    Reads data from the debugport.

    @param  This                  A pointer to the EFI_DEBUGPORT_PROTOCOL instance.
    @param  Timeout               The number of microseconds to wait before timing out a read operation.
    @param  BufferSize            On input, the requested number of bytes of data to read. On output, the
                                  number of bytes of data actually number of bytes
                                  of data read and returned in Buffer.
    @param  Buffer                A pointer to a buffer into which the data read will be saved.

    @retval EFI_SUCCESS           The data was read.
    @retval EFI_DEVICE_ERROR      The device reported an error.
    @retval EFI_TIMEOUT           The operation was stopped due to a timeout or overrun.

  **/
  public readonly delegate* unmanaged<EFI_DEBUGPORT_PROTOCOL*, uint, ulong*, void*, EFI_STATUS> Read;
  /**
    Checks to see if any data is available to be read from the debugport device.

    @param  This                  A pointer to the EFI_DEBUGPORT_PROTOCOL instance.

    @retval EFI_SUCCESS           At least one byte of data is available to be read.
    @retval EFI_DEVICE_ERROR      The debugport device is not functioning correctly.
    @retval EFI_NOT_READY         No data is available to be read.

  **/
  public readonly delegate* unmanaged<EFI_DEBUGPORT_PROTOCOL*, EFI_STATUS> Poll;
}

//
// DEBUGPORT variable definitions...
//
public unsafe partial class EFI
{
  public const string EFI_DEBUGPORT_VARIABLE_NAME = "DEBUGPORT";
  public const ulong EFI_DEBUGPORT_VARIABLE_GUID = EFI_DEBUGPORT_PROTOCOL_GUID;

  // extern EFI_GUID  gEfiDebugPortVariableGuid;

  //
  // DebugPort device path definitions...
  //
  public const ulong DEVICE_PATH_MESSAGING_DEBUGPORT = EFI_DEBUGPORT_PROTOCOL_GUID;

  // extern EFI_GUID  gEfiDebugPortDevicePathGuid;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct DEBUGPORT_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  public EFI_GUID Guid;
}

// #endif
