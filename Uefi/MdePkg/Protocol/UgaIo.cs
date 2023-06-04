using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  UGA IO protocol from the EFI 1.10 specification.

  Abstraction of a very simple graphics device.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __UGA_IO_H__
// #define __UGA_IO_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_UGA_IO_PROTOCOL_GUID = new GUID(0x61a4d49e, 0x6f68, 0x4f1b, new byte[] { 0xb9, 0x22, 0xa8, 0x6e, 0xed, 0xb, 0x7, 0xa2 });

  // typedef struct _EFI_UGA_IO_PROTOCOL EFI_UGA_IO_PROTOCOL;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UGA_STATUS { uint Value; public static implicit operator UGA_STATUS(uint value) => new UGA_STATUS() { Value = value }; public static implicit operator uint(UGA_STATUS value) => value.Value; }

public enum UGA_DEVICE_TYPE
{
  UgaDtParentBus = 1,
  UgaDtGraphicsController,
  UgaDtOutputController,
  UgaDtOutputPort,
  UgaDtOther
}

typedef uint UGA_DEVICE_ID, * PUGA_DEVICE_ID;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UGA_DEVICE_DATA
{
  public UGA_DEVICE_TYPE deviceType;
  public UGA_DEVICE_ID deviceId;
  public uint ui32DeviceContextSize;
  public uint ui32SharedContextSize;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UGA_DEVICE
{
  public void* pvDeviceContext;
  public void* pvSharedContext;
  public void* pvRunTimeContext;
  struct public _UGA_DEVICE* pParentDevice;
  public void* pvBusIoServices;
  public void* pvStdIoServices;
  public UGA_DEVICE_DATA deviceData;
}

public enum UGA_IO_REQUEST_CODE
{
  UgaIoGetVersion = 1,
  UgaIoGetChildDevice,
  UgaIoStartDevice,
  UgaIoStopDevice,
  UgaIoFlushDevice,
  UgaIoResetDevice,
  UgaIoGetDeviceState,
  UgaIoSetDeviceState,
  UgaIoSetPowerState,
  UgaIoGetMemoryConfiguration,
  UgaIoSetVideoMode,
  UgaIoCopyRectangle,
  UgaIoGetEdidSegment,
  UgaIoDeviceChannelOpen,
  UgaIoDeviceChannelClose,
  UgaIoDeviceChannelRead,
  UgaIoDeviceChannelWrite,
  UgaIoGetPersistentDataSize,
  UgaIoGetPersistentData,
  UgaIoSetPersistentData,
  UgaIoGetDevicePropertySize,
  UgaIoGetDeviceProperty,
  UgaIoBtPrivateInterface
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UGA_IO_REQUEST
{
  /*IN*/
  public UGA_IO_REQUEST_CODE ioRequestCode;
  /*IN*/
  public void* pvInBuffer;
  /*IN*/
  public ulong ui64InBufferSize;
  /*OUT*/
  public void* pvOutBuffer;
  /*IN*/
  public ulong ui64OutBufferSize;
  /*OUT*/
  public ulong ui64BytesReturned;
}

// /**
//   Dynamically allocate storage for a child UGA_DEVICE.
// 
//   @param[in]     This            The EFI_UGA_IO_PROTOCOL instance.
//   @param[in]     ParentDevice    ParentDevice specifies a pointer to the parent device of Device.
//   @param[in]     DeviceData      A pointer to UGA_DEVICE_DATA returned from a call to DispatchService()
//                                  with a UGA_DEVICE of Parent and an IoRequest of type UgaIoGetChildDevice.
//   @param[in]     RunTimeContext  Context to associate with Device.
//   @param[out]    Device          The Device returns a dynamically allocated child UGA_DEVICE object
//                                  for ParentDevice. The caller is responsible for deleting Device.
// 
// 
//   @retval  EFI_SUCCESS           Device was returned.
//   @retval  EFI_INVALID_PARAMETER One of the arguments was not valid.
//   @retval  EFI_DEVICE_ERROR      The device had an error and could not complete the request.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_UGA_IO_PROTOCOL_CREATE_DEVICE)(
//   IN  EFI_UGA_IO_PROTOCOL  *This,
//   IN  UGA_DEVICE           *ParentDevice,
//   IN  UGA_DEVICE_DATA      *DeviceData,
//   IN  void                 *RunTimeContext,
//   OUT UGA_DEVICE           **Device
//   );

// /**
//   Delete a dynamically allocated child UGA_DEVICE object that was allocated via CreateDevice().
// 
//   @param[in]     This            The EFI_UGA_IO_PROTOCOL instance. Type EFI_UGA_IO_PROTOCOL is
//                                  defined in Section 10.7.
//   @param[in]     Device          The Device points to a UGA_DEVICE object that was dynamically
//                                  allocated via a CreateDevice() call.
// 
// 
//   @retval  EFI_SUCCESS           Device was returned.
//   @retval  EFI_INVALID_PARAMETER The Device was not allocated via CreateDevice().
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_UGA_IO_PROTOCOL_DELETE_DEVICE)(
//   IN EFI_UGA_IO_PROTOCOL  *This,
//   IN UGA_DEVICE           *Device
//   );

// /**
//   This is the main UGA service dispatch routine for all UGA_IO_REQUEST s.
// 
//   @param pDevice pDevice specifies a pointer to a device object associated with a
//                  device enumerated by a pIoRequest->ioRequestCode of type
//                  UgaIoGetChildDevice. The root device for the EFI_UGA_IO_PROTOCOL
//                  is represented by pDevice being set to NULL.
// 
//   @param pIoRequest
//                  pIoRequest points to a caller allocated buffer that contains data
//                  defined by pIoRequest->ioRequestCode. See Related Definitions for
//                  a definition of UGA_IO_REQUEST_CODE s and their associated data
//                  structures.
// 
//   @return UGA_STATUS
// 
// **/
// typedef UGA_STATUS
// (EFIAPI *PUGA_FW_SERVICE_DISPATCH)(
//   IN PUGA_DEVICE pDevice,
//   IN OUT PUGA_IO_REQUEST pIoRequest
//   );

///
/// Provides a basic abstraction to send I/O requests to the graphics device and any of its children.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_UGA_IO_PROTOCOL
{
  public readonly delegate* unmanaged</* IN */EFI_UGA_IO_PROTOCOL* /*This*/,/* IN */UGA_DEVICE* /*ParentDevice*/,/* IN */UGA_DEVICE_DATA* /*DeviceData*/,/* IN */void* /*RunTimeContext*/,/* OUT */UGA_DEVICE** /*Device*/, EFI_STATUS> /*EFI_UGA_IO_PROTOCOL_CREATE_DEVICE*/ CreateDevice;
  public readonly delegate* unmanaged</* IN */EFI_UGA_IO_PROTOCOL* /*This*/,/* IN */UGA_DEVICE* /*Device*/, EFI_STATUS> /*EFI_UGA_IO_PROTOCOL_DELETE_DEVICE*/ DeleteDevice;
  public readonly delegate* unmanaged</* IN OUT */PUGA_IO_REQUEST /*pIoRequest*/, EFI_STATUS> /*PUGA_FW_SERVICE_DISPATCH*/ DispatchService;
}

// extern EFI_GUID  gEfiUgaIoProtocolGuid;

//
// Data structure that is stored in the EFI Configuration Table with the
// EFI_UGA_IO_PROTOCOL_GUID.  The option ROMs listed in this table may have
// EBC UGA drivers.
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DRIVER_OS_HANDOFF_HEADER
{
  public uint Version;
  public uint HeaderSize;
  public uint SizeOfEntries;
  public uint NumberOfEntries;
}

public enum EFI_DRIVER_HANOFF_ENUM
{
  EfiUgaDriverFromPciRom,
  EfiUgaDriverFromSystem,
  EfiDriverHandoffMax
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DRIVER_OS_HANDOFF
{
  public EFI_DRIVER_HANOFF_ENUM Type;
  public EFI_DEVICE_PATH_PROTOCOL* DevicePath;
  public void* PciRomImage;
  public ulong PciRomSize;
}

// #endif
