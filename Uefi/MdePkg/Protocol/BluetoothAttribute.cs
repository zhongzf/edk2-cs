using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI Bluetooth Attribute Protocol as defined in UEFI 2.7.
  This protocol provides service for Bluetooth ATT (Attribute Protocol) and GATT (Generic
  Attribute Profile) based protocol interfaces.

  Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.7

**/

// #ifndef __EFI_BLUETOOTH_ATTRIBUTE_H__
// #define __EFI_BLUETOOTH_ATTRIBUTE_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_BLUETOOTH_ATTRIBUTE_SERVICE_BINDING_PROTOCOL_GUID = new GUID(
      0x5639867a, 0x8c8e, 0x408d, new byte[] { 0xac, 0x2f, 0x4b, 0x61, 0xbd, 0xc0, 0xbb, 0xbb });

  public static EFI_GUID EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL_GUID = new GUID(
      0x898890e9, 0x84b2, 0x4f3a, new byte[] { 0x8c, 0x58, 0xd8, 0x57, 0x78, 0x13, 0xe0, 0xac });

  // typedef struct _EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL;

  // #pragma pack(1)
}

//
// Bluetooth UUID
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_UUID
{
  public byte Length;
  //  union {
  //    public ushort Uuid16;
  //  public uint Uuid32;
  //  public fixed byte Uuid128[16];
  //}
}

public unsafe partial class EFI
{
  public const ulong UUID_16BIT_TYPE_LEN = 2;
  public const ulong UUID_32BIT_TYPE_LEN = 4;
  public const ulong UUID_128BIT_TYPE_LEN = 16;

  //public const ulong BLUETOOTH_IS_ATTRIBUTE_OF_TYPE = (a, t)((a)->Type.Length == UUID_16BIT_TYPE_LEN && (a)->Type.Data.Uuid16 == (t));
}

//
// Bluetooth Attribute Permission
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_BLUETOOTH_ATTRIBUTE_PERMISSION
{
  /*   struct { */
  [FieldOffset(0)] public ushort Readable; // = 1;
  [FieldOffset(0)] public ushort ReadEncryption; // = 1;
  [FieldOffset(0)] public ushort ReadAuthentication; // = 1;
  [FieldOffset(0)] public ushort ReadAuthorization; // = 1;
  [FieldOffset(0)] public ushort ReadKeySize; // = 5;
  [FieldOffset(0)] public ushort Reserved1; // = 7;
  [FieldOffset(0)] public ushort Writeable; // = 1;
  [FieldOffset(0)] public ushort WriteEncryption; // = 1;
  [FieldOffset(0)] public ushort WriteAuthentication; // = 1;
  [FieldOffset(0)] public ushort WriteAuthorization; // = 1;
  [FieldOffset(0)] public ushort WriteKeySize; // = 5;
  [FieldOffset(0)] public ushort Reserved2; // = 7;
  /*   } Permission; */
  [FieldOffset(0)] public uint Data32;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_ATTRIBUTE_HEADER
{
  public EFI_BLUETOOTH_UUID Type;
  public ushort Length;
  public ushort AttributeHandle;
  public EFI_BLUETOOTH_ATTRIBUTE_PERMISSION AttributePermission;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_GATT_PRIMARY_SERVICE_INFO
{
  public EFI_BLUETOOTH_ATTRIBUTE_HEADER Header;
  public ushort EndGroupHandle;
  public EFI_BLUETOOTH_UUID ServiceUuid;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_GATT_INCLUDE_SERVICE_INFO
{
  public EFI_BLUETOOTH_ATTRIBUTE_HEADER Header;
  public ushort StartGroupHandle;
  public ushort EndGroupHandle;
  public EFI_BLUETOOTH_UUID ServiceUuid;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_GATT_CHARACTERISTIC_INFO
{
  public EFI_BLUETOOTH_ATTRIBUTE_HEADER Header;
  public byte CharacteristicProperties;
  public ushort CharacteristicValueHandle;
  public EFI_BLUETOOTH_UUID CharacteristicUuid;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_GATT_CHARACTERISTIC_DESCRIPTOR_INFO
{
  public EFI_BLUETOOTH_ATTRIBUTE_HEADER Header;
  public EFI_BLUETOOTH_UUID CharacteristicDescriptorUuid;
}

// #pragma pack()

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_PARAMETER_NOTIFICATION
{
  public ushort AttributeHandle;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_PARAMETER_INDICATION
{
  public ushort AttributeHandle;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_PARAMETER
{
  public uint Version;
  public byte AttributeOpCode;
//  union {
//    public EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_PARAMETER_NOTIFICATION Notification;
//  public EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_PARAMETER_INDICATION Indication;
//}
} 

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_LE_DEVICE_INFO
{
  public uint Version;
  public BLUETOOTH_LE_ADDRESS BD_ADDR;
  public BLUETOOTH_LE_ADDRESS DirectAddress;
  public byte RSSI;
  public ulong AdvertisementDataSize;
  public void* AdvertisementData;
}

// /**
//   The callback function to send request.
// 
//   @param[in]  This                Pointer to the EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL instance.
//   @param[in]  Data                Data received. The first byte is the attribute opcode, followed by opcode specific
//                                   fields. See Bluetooth specification, Vol 3, Part F, Attribute Protocol. It might be a
//                                   normal RESPONSE message, or ERROR RESPONSE messag
//   @param[in]  DataLength          The length of Data in bytes.
//   @param[in]  Context             The context passed from the callback registration request.
// 
//   @retval EFI_SUCCESS   The callback function complete successfully.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_FUNCTION)(
//   IN EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL *This,
//   IN void                             *Data,
//   IN ulong                            DataLength,
//   IN void                             *Context
//   );

// /**
//   Send a "REQUEST" or "COMMAND" message to remote server and receive a "RESPONSE" message
//   for "REQUEST" from remote server according to Bluetooth attribute protocol data unit(PDU).
// 
//   @param[in]  This              Pointer to the EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL instance.
//   @param[in]  Data              Data of a REQUEST or COMMAND message. The first byte is the attribute PDU
//                                 related opcode, followed by opcode specific fields. See Bluetooth specification,
//                                 Vol 3, Part F, Attribute Protocol.
//   @param[in]  DataLength        The length of Data in bytes.
//   @param[in]  Callback          Callback function to notify the RESPONSE is received to the caller, with the
//                                 response buffer. Caller must check the response buffer content to know if the
//                                 request action is success or fail. It may be NULL if the data is a COMMAND.
//   @param[in]  Context           Data passed into Callback function. It is optional parameter and may be NULL.
// 
//   @retval EFI_SUCCESS           The request is sent successfully.
//   @retval EFI_INVALID_PARAMETER One or more parameters are invalid due to following conditions:
//                                 - The Buffer is NULL.
//                                 - The BufferLength is 0.
//                                 - The opcode in Buffer is not a valid OPCODE according to Bluetooth specification.
//                                 - The Callback is NULL.
//   @retval EFI_DEVICE_ERROR      Sending the request failed due to the host controller or the device error.
//   @retval EFI_NOT_READY         A GATT operation is already underway for this device.
//   @retval EFI_UNSUPPORTED       The attribute does not support the corresponding operation.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_ATTRIBUTE_SEND_REQUEST)(
//   IN EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL            *This,
//   IN void                                        *Data,
//   IN ulong                                       DataLength,
//   IN EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_FUNCTION   Callback,
//   IN void                                        *Context
//   );

// /**
//   Register or unregister a server initiated message, such as NOTIFICATION or INDICATION, on a
//   characteristic value on remote server.
// 
//   @param[in]  This              Pointer to the EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL instance.
//   @param[in]  CallbackParameter The parameter of the callback.
//   @param[in]  Callback          Callback function for server initiated attribute protocol. NULL callback
//                                 function means unregister the server initiated callback.
//   @param[in]  Context           Data passed into Callback function. It is optional parameter and may be NULL.
// 
//   @retval EFI_SUCCESS           The callback function is registered or unregistered successfully
//   @retval EFI_INVALID_PARAMETER The attribute opcode is not server initiated message opcode. See
//                                 Bluetooth specification, Vol 3, Part F, Attribute Protocol.
//   @retval EFI_ALREADY_STARTED   A callback function is already registered on the same attribute
//                                 opcode and attribute handle, when the Callback is not NULL.
//   @retval EFI_NOT_STARTED       A callback function is not registered on the same attribute opcode
//                                 and attribute handle, when the Callback is NULL.
//   @retval EFI_NOT_READY         A GATT operation is already underway for this device.
//   @retval EFI_UNSUPPORTED       The attribute does not support notification.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_ATTRIBUTE_REGISTER_FOR_SERVER_NOTIFICATION)(
//   IN  EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL           *This,
//   IN  EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_PARAMETER *CallbackParameter,
//   IN  EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_FUNCTION  Callback,
//   IN  void                                       *Context
//   );

// /**
//   Get Bluetooth discovered service information.
// 
//   @param[in]  This              Pointer to the EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL instance.
//   @param[out] ServiceInfoSize   A pointer to the size, in bytes, of the ServiceInfo buffer.
//   @param[out] ServiceInfo       A pointer to a callee allocated buffer that returns Bluetooth
//                                 discovered service information. Callee allocates this buffer by
//                                 using EFI Boot Service AllocatePool().
// 
//   @retval EFI_SUCCESS           The Bluetooth discovered service information is returned successfully.
//   @retval EFI_DEVICE_ERROR      A hardware error occurred trying to retrieve the Bluetooth discovered
//                                 service information.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_ATTRIBUTE_GET_SERVICE_INFO)(
//   IN EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL      *This,
//   OUT ulong                                *ServiceInfoSize,
//   OUT void                                 **ServiceInfo
//   );

// /**
//   Get Bluetooth device information.
// 
//   @param[in]  This              Pointer to the EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL instance.
//   @param[out] DeviceInfoSize    A pointer to the size, in bytes, of the DeviceInfo buffer.
//   @param[out] DeviceInfo        A pointer to a callee allocated buffer that returns Bluetooth
//                                 device information. Callee allocates this buffer by using EFI Boot
//                                 Service AllocatePool(). If this device is Bluetooth classic
//                                 device, EFI_BLUETOOTH_DEVICE_INFO should be used. If
//                                 this device is Bluetooth LE device, EFI_BLUETOOTH_LE_DEVICE_INFO
//                                 should be used.
// 
//   @retval EFI_SUCCESS           The Bluetooth device information is returned successfully.
//   @retval EFI_DEVICE_ERROR      A hardware error occurred trying to retrieve the Bluetooth device
//                                 information
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_ATTRIBUTE_GET_DEVICE_INFO)(
//   IN  EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL  *This,
//   OUT ulong                             *DeviceInfoSize,
//   OUT void                              **DeviceInfo
//   );

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL
{
  //public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL* /*This*/,/* IN */void* /*Data*/,/* IN */ulong /*DataLength*/,/* IN */EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_FUNCTION /*Callback*/,/* IN */void* /*Context*/, EFI_STATUS> /*EFI_BLUETOOTH_ATTRIBUTE_SEND_REQUEST*/ SendRequest;
  public void* SendRequest;

  //public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL* /*This*/,/* IN */EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_PARAMETER* /*CallbackParameter*/,/* IN */EFI_BLUETOOTH_ATTRIBUTE_CALLBACK_FUNCTION /*Callback*/,/* IN */void* /*Context*/, EFI_STATUS> /*EFI_BLUETOOTH_ATTRIBUTE_REGISTER_FOR_SERVER_NOTIFICATION*/ RegisterForServerNotification;
  public void* RegisterForServerNotification;

  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL* /*This*/,/* OUT */ulong* /*ServiceInfoSize*/,/* OUT */void** /*ServiceInfo*/, EFI_STATUS> /*EFI_BLUETOOTH_ATTRIBUTE_GET_SERVICE_INFO*/ GetServiceInfo;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL* /*This*/,/* OUT */ulong* /*DeviceInfoSize*/,/* OUT */void** /*DeviceInfo*/, EFI_STATUS> /*EFI_BLUETOOTH_ATTRIBUTE_GET_DEVICE_INFO*/ GetDeviceInfo;
}

// extern EFI_GUID  gEfiBluetoothAttributeProtocolGuid;
// extern EFI_GUID  gEfiBluetoothAttributeServiceBindingProtocolGuid;

// #endif
