using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Serial IO protocol as defined in the UEFI 2.0 specification.

  Abstraction of a basic serial device. Targeted at 16550 UART, but
  could be much more generic.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SERIAL_IO_PROTOCOL_H__
// #define __SERIAL_IO_PROTOCOL_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_SERIAL_IO_PROTOCOL_GUID => new GUID(
      0xBB25CF6F, 0xF1D4, 0x11D2, 0x9A, 0x0C, 0x00, 0x90, 0x27, 0x3F, 0xC1, 0xFD);

  public static EFI_GUID EFI_SERIAL_TERMINAL_DEVICE_TYPE_GUID => new GUID(
      0X6AD9A60F, 0X5815, 0X4C7C, 0X8A, 0X10, 0X50, 0X53, 0XD2, 0XBF, 0X7A, 0X1B);

  ///
  /// Protocol GUID defined in EFI1.1.
  ///
  public static EFI_GUID SERIAL_IO_PROTOCOL = EFI_SERIAL_IO_PROTOCOL_GUID;

  // typedef struct _EFI_SERIAL_IO_PROTOCOL EFI_SERIAL_IO_PROTOCOL;
}

///
/// Backward-compatible with EFI1.1.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SERIAL_IO_INTERFACE { EFI_SERIAL_IO_PROTOCOL Value; public static implicit operator SERIAL_IO_INTERFACE(EFI_SERIAL_IO_PROTOCOL value) => new SERIAL_IO_INTERFACE() { Value = value }; public static implicit operator EFI_SERIAL_IO_PROTOCOL(SERIAL_IO_INTERFACE value) => value.Value; }

///
/// Parity type that is computed or checked as each character is transmitted or received. If the
/// device does not support parity, the value is the default parity value.
///
public enum EFI_PARITY_TYPE
{
  DefaultParity,
  NoParity,
  EvenParity,
  OddParity,
  MarkParity,
  SpaceParity
}

///
/// Stop bits type
///
public enum EFI_STOP_BITS_TYPE
{
  DefaultStopBits,
  OneStopBit,
  OneFiveStopBits,
  TwoStopBits
}

public unsafe partial class EFI
{
  //
  // define for Control bits, grouped by read only, write only, and read write
  //
  //
  // Read Only
  //
  public const ulong EFI_SERIAL_CLEAR_TO_SEND = 0x00000010;
  public const ulong EFI_SERIAL_DATA_SET_READY = 0x00000020;
  public const ulong EFI_SERIAL_RING_INDICATE = 0x00000040;
  public const ulong EFI_SERIAL_CARRIER_DETECT = 0x00000080;
  public const ulong EFI_SERIAL_INPUT_BUFFER_EMPTY = 0x00000100;
  public const ulong EFI_SERIAL_OUTPUT_BUFFER_EMPTY = 0x00000200;

  //
  // Write Only
  //
  public const ulong EFI_SERIAL_REQUEST_TO_SEND = 0x00000002;
  public const ulong EFI_SERIAL_DATA_TERMINAL_READY = 0x00000001;

  //
  // Read Write
  //
  public const ulong EFI_SERIAL_HARDWARE_LOOPBACK_ENABLE = 0x00001000;
  public const ulong EFI_SERIAL_SOFTWARE_LOOPBACK_ENABLE = 0x00002000;
  public const ulong EFI_SERIAL_HARDWARE_FLOW_CONTROL_ENABLE = 0x00004000;
}

  //
  // Serial IO Member Functions
  //

  // /**
  //   Reset the serial device.
  // 
  //   @param  This              Protocol instance pointer.
  // 
  //   @retval EFI_SUCCESS       The device was reset.
  //   @retval EFI_DEVICE_ERROR  The serial device could not be reset.
  // 
  // **/
  // typedef
  // EFI_STATUS
  // (EFIAPI *EFI_SERIAL_RESET)(
  //   IN EFI_SERIAL_IO_PROTOCOL *This
  //   );

  // /**
  //   Sets the baud rate, receive FIFO depth, transmit/receice time out, parity,
  //   data bits, and stop bits on a serial device.
  // 
  //   @param  This             Protocol instance pointer.
  //   @param  BaudRate         The requested baud rate. A BaudRate value of 0 will use the
  //                            device's default interface speed.
  //   @param  ReveiveFifoDepth The requested depth of the FIFO on the receive side of the
  //                            serial interface. A ReceiveFifoDepth value of 0 will use
  //                            the device's default FIFO depth.
  //   @param  Timeout          The requested time out for a single character in microseconds.
  //                            This timeout applies to both the transmit and receive side of the
  //                            interface. A Timeout value of 0 will use the device's default time
  //                            out value.
  //   @param  Parity           The type of parity to use on this serial device. A Parity value of
  //                            DefaultParity will use the device's default parity value.
  //   @param  DataBits         The number of data bits to use on the serial device. A DataBits
  //                            vaule of 0 will use the device's default data bit setting.
  //   @param  StopBits         The number of stop bits to use on this serial device. A StopBits
  //                            value of DefaultStopBits will use the device's default number of
  //                            stop bits.
  // 
  //   @retval EFI_SUCCESS           The device was reset.
  //   @retval EFI_INVALID_PARAMETER One or more attributes has an unsupported value.
  //   @retval EFI_DEVICE_ERROR      The serial device is not functioning correctly.
  // 
  // **/
  // typedef
  // EFI_STATUS
  // (EFIAPI *EFI_SERIAL_SET_ATTRIBUTES)(
  //   IN EFI_SERIAL_IO_PROTOCOL         *This,
  //   IN ulong                         BaudRate,
  //   IN uint                         ReceiveFifoDepth,
  //   IN uint                         Timeout,
  //   IN EFI_PARITY_TYPE                Parity,
  //   IN byte                          DataBits,
  //   IN EFI_STOP_BITS_TYPE             StopBits
  //   );

  // /**
  //   Set the control bits on a serial device
  // 
  //   @param  This             Protocol instance pointer.
  //   @param  Control          Set the bits of Control that are settable.
  // 
  //   @retval EFI_SUCCESS      The new control bits were set on the serial device.
  //   @retval EFI_UNSUPPORTED  The serial device does not support this operation.
  //   @retval EFI_DEVICE_ERROR The serial device is not functioning correctly.
  // 
  // **/
  // typedef
  // EFI_STATUS
  // (EFIAPI *EFI_SERIAL_SET_CONTROL_BITS)(
  //   IN EFI_SERIAL_IO_PROTOCOL         *This,
  //   IN uint                         Control
  //   );

  // /**
  //   Retrieves the status of thecontrol bits on a serial device
  // 
  //   @param  This              Protocol instance pointer.
  //   @param  Control           A pointer to return the current Control signals from the serial device.
  // 
  //   @retval EFI_SUCCESS       The control bits were read from the serial device.
  //   @retval EFI_DEVICE_ERROR  The serial device is not functioning correctly.
  // 
  // **/
  // typedef
  // EFI_STATUS
  // (EFIAPI *EFI_SERIAL_GET_CONTROL_BITS)(
  //   IN EFI_SERIAL_IO_PROTOCOL         *This,
  //   OUT uint                        *Control
  //   );

  // /**
  //   Writes data to a serial device.
  // 
  //   @param  This              Protocol instance pointer.
  //   @param  BufferSize        On input, the size of the Buffer. On output, the amount of
  //                             data actually written.
  //   @param  Buffer            The buffer of data to write
  // 
  //   @retval EFI_SUCCESS       The data was written.
  //   @retval EFI_DEVICE_ERROR  The device reported an error.
  //   @retval EFI_TIMEOUT       The data write was stopped due to a timeout.
  // 
  // **/
  // typedef
  // EFI_STATUS
  // (EFIAPI *EFI_SERIAL_WRITE)(
  //   IN EFI_SERIAL_IO_PROTOCOL         *This,
  //   IN OUT ulong                      *BufferSize,
  //   IN void                           *Buffer
  //   );

  // /**
  //   Writes data to a serial device.
  // 
  //   @param  This              Protocol instance pointer.
  //   @param  BufferSize        On input, the size of the Buffer. On output, the amount of
  //                             data returned in Buffer.
  //   @param  Buffer            The buffer to return the data into.
  // 
  //   @retval EFI_SUCCESS       The data was read.
  //   @retval EFI_DEVICE_ERROR  The device reported an error.
  //   @retval EFI_TIMEOUT       The data write was stopped due to a timeout.
  // 
  // **/
  // typedef
  // EFI_STATUS
  // (EFIAPI *EFI_SERIAL_READ)(
  //   IN EFI_SERIAL_IO_PROTOCOL         *This,
  //   IN OUT ulong                      *BufferSize,
  //   OUT void                          *Buffer
  //   );

  /**
    @par Data Structure Description:
    The data values in SERIAL_IO_MODE are read-only and are updated by the code
    that produces the SERIAL_IO_PROTOCOL member functions.

    @param ControlMask
    A mask for the Control bits that the device supports. The device
    must always support the Input Buffer Empty control bit.

    @param TimeOut
    If applicable, the number of microseconds to wait before timing out
    a Read or Write operation.

    @param BaudRate
    If applicable, the current baud rate setting of the device; otherwise,
    baud rate has the value of zero to indicate that device runs at the
    device's designed speed.

    @param ReceiveFifoDepth
    The number of characters the device will buffer on input

    @param DataBits
    The number of characters the device will buffer on input

    @param Parity
    If applicable, this is the EFI_PARITY_TYPE that is computed or
    checked as each character is transmitted or reveived. If the device
    does not support parity the value is the default parity value.

    @param StopBits
    If applicable, the EFI_STOP_BITS_TYPE number of stop bits per
    character. If the device does not support stop bits the value is
    the default stop bit values.

  **/
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct EFI_SERIAL_IO_MODE
  {
    public uint ControlMask;

    //
    // current Attributes
    //
    public uint Timeout;
    public ulong BaudRate;
    public uint ReceiveFifoDepth;
    public uint DataBits;
    public uint Parity;
    public uint StopBits;
  }

  public unsafe partial class EFI
  {
    public const ulong EFI_SERIAL_IO_PROTOCOL_REVISION = 0x00010000;
    public const ulong EFI_SERIAL_IO_PROTOCOL_REVISION1p1 = 0x00010001;
    public const ulong SERIAL_IO_INTERFACE_REVISION = EFI_SERIAL_IO_PROTOCOL_REVISION;
  }

  ///
  /// The Serial I/O protocol is used to communicate with UART-style serial devices.
  /// These can be standard UART serial ports in PC-AT systems, serial ports attached
  /// to a USB interface, or potentially any character-based I/O device.
  ///
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct EFI_SERIAL_IO_PROTOCOL
  {
    ///
    /// The revision to which the EFI_SERIAL_IO_PROTOCOL adheres. All future revisions
    /// must be backwards compatible. If a future version is not backwards compatible,
    /// it is not the same GUID.
    ///
    public uint Revision;
    public readonly delegate* unmanaged</* IN */EFI_SERIAL_IO_PROTOCOL* /*This*/, EFI_STATUS> /*EFI_SERIAL_RESET*/ Reset;
    public readonly delegate* unmanaged</* IN */EFI_SERIAL_IO_PROTOCOL* /*This*/,/* IN */ulong /*BaudRate*/,/* IN */uint /*ReceiveFifoDepth*/,/* IN */uint /*Timeout*/,/* IN */EFI_PARITY_TYPE /*Parity*/,/* IN */byte /*DataBits*/,/* IN */EFI_STOP_BITS_TYPE /*StopBits*/, EFI_STATUS> /*EFI_SERIAL_SET_ATTRIBUTES*/ SetAttributes;
    public readonly delegate* unmanaged</* IN */EFI_SERIAL_IO_PROTOCOL* /*This*/,/* IN */uint /*Control*/, EFI_STATUS> /*EFI_SERIAL_SET_CONTROL_BITS*/ SetControl;
    public readonly delegate* unmanaged</* IN */EFI_SERIAL_IO_PROTOCOL* /*This*/,/* OUT */uint* /*Control*/, EFI_STATUS> /*EFI_SERIAL_GET_CONTROL_BITS*/ GetControl;
    public readonly delegate* unmanaged</* IN */EFI_SERIAL_IO_PROTOCOL* /*This*/,/* IN OUT */ulong* /*BufferSize*/,/* IN */void* /*Buffer*/, EFI_STATUS> /*EFI_SERIAL_WRITE*/ Write;
    public readonly delegate* unmanaged</* IN */EFI_SERIAL_IO_PROTOCOL* /*This*/,/* IN OUT */ulong* /*BufferSize*/,/* OUT */void* /*Buffer*/, EFI_STATUS> /*EFI_SERIAL_READ*/ Read;
    ///
    /// Pointer to SERIAL_IO_MODE data.
    ///
    public EFI_SERIAL_IO_MODE* Mode;
    ///
    /// Pointer to a GUID identifying the device connected to the serial port.
    /// This field is NULL when the protocol is installed by the serial port
    /// driver and may be populated by a platform driver for a serial port
    /// with a known device attached. The field will remain NULL if there is
    /// no platform serial device identification information available.
    ///
    /*CONST*/
    public EFI_GUID* DeviceTypeGuid; // Revision 1.1
  }

// extern EFI_GUID  gEfiSerialIoProtocolGuid;
// extern EFI_GUID  gEfiSerialTerminalDeviceTypeGuid;

// #endif
