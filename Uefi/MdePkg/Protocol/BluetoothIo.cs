using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI Bluetooth IO Service Binding Protocol as defined in UEFI 2.5.
  EFI Bluetooth IO Protocol as defined in UEFI 2.5.
  The EFI Bluetooth IO Service Binding Protocol is used to locate EFI Bluetooth IO Protocol drivers to
  create and destroy child of the driver to communicate with other Bluetooth device by using Bluetooth IO protocol.

  Copyright (c) 2015 - 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.5

**/

// #ifndef __EFI_BLUETOOTH_IO_PROTOCOL_H__
// #define __EFI_BLUETOOTH_IO_PROTOCOL_H__

// #include <IndustryStandard/Bluetooth.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_BLUETOOTH_IO_SERVICE_BINDING_PROTOCOL_GUID = new GUID(
      0x388278d3, 0x7b85, 0x42f0, 0xab, 0xa9, 0xfb, 0x4b, 0xfd, 0x69, 0xf5, 0xab);

  public static EFI_GUID EFI_BLUETOOTH_IO_PROTOCOL_GUID = new GUID(
      0x467313de, 0x4e30, 0x43f1, 0x94, 0x3e, 0x32, 0x3f, 0x89, 0x84, 0x5d, 0xb5);

  // typedef struct _EFI_BLUETOOTH_IO_PROTOCOL EFI_BLUETOOTH_IO_PROTOCOL;
}

///
/// EFI_BLUETOOTH_DEVICE_INFO
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_DEVICE_INFO
{
  ///
  /// The version of the structure
  ///
  public uint Version;
  ///
  /// 48bit Bluetooth device address.
  ///
  public BLUETOOTH_ADDRESS BD_ADDR;
  ///
  /// Bluetooth PageScanRepetitionMode. See Bluetooth specification for detail.
  ///
  public byte PageScanRepetitionMode;
  ///
  /// Bluetooth ClassOfDevice. See Bluetooth specification for detail.
  ///
  public BLUETOOTH_CLASS_OF_DEVICE ClassOfDevice;
  ///
  /// Bluetooth CloseOffset. See Bluetooth specification for detail.
  ///
  public ushort ClockOffset;
  ///
  /// Bluetooth RSSI. See Bluetooth specification for detail.
  ///
  public byte RSSI;
  ///
  /// Bluetooth ExtendedInquiryResponse. See Bluetooth specification for detail.
  ///
  public fixed byte ExtendedInquiryResponse[240];
}

// /**
//   Get Bluetooth device information.
// 
//   @param[in]   This               Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[out]  DeviceInfoSize     A pointer to the size, in bytes, of the DeviceInfo buffer.
//   @param[out]  DeviceInfo         A pointer to a callee allocated buffer that returns Bluetooth device information.
// 
//   @retval EFI_SUCCESS             The Bluetooth device information is returned successfully.
//   @retval EFI_DEVICE_ERROR        A hardware error occurred trying to retrieve the Bluetooth device information.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_GET_DEVICE_INFO)(
//   IN EFI_BLUETOOTH_IO_PROTOCOL    *This,
//   OUT ulong                       *DeviceInfoSize,
//   OUT void                        **DeviceInfo
//   );

// /**
//   Get Bluetooth SDP information.
// 
//   @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[out] SdpInfoSize         A pointer to the size, in bytes, of the SdpInfo buffer.
//   @param[out] SdpInfo             A pointer to a callee allocated buffer that returns Bluetooth SDP information.
// 
//   @retval EFI_SUCCESS             The Bluetooth device information is returned successfully.
//   @retval EFI_DEVICE_ERROR        A hardware error occurred trying to retrieve the Bluetooth SDP information.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_GET_SDP_INFO)(
//   IN EFI_BLUETOOTH_IO_PROTOCOL    *This,
//   OUT ulong                       *SdpInfoSize,
//   OUT void                        **SdpInfo
//   );

// /**
//   Send L2CAP message (including L2CAP header).
// 
//   @param[in]      This            Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[in, out] BufferSize      On input, indicates the size, in bytes, of the data buffer specified by Buffer.
//                                   On output, indicates the amount of data actually transferred.
//   @param[in]      Buffer          A pointer to the buffer of data that will be transmitted to Bluetooth L2CAP layer.
//   @param[in]      Timeout         Indicating the transfer should be completed within this time frame. The units are in
//                                   milliseconds. If Timeout is 0, then the caller must wait for the function to be completed
//                                   until EFI_SUCCESS or EFI_DEVICE_ERROR is returned.
// 
//   @retval EFI_SUCCESS             The L2CAP message is sent successfully.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   - BufferSize is NULL.
//                                   - *BufferSize is 0.
//                                   - Buffer is NULL.
//   @retval EFI_TIMEOUT             Sending L2CAP message fail due to timeout.
//   @retval EFI_DEVICE_ERROR        Sending L2CAP message fail due to host controller or device error.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_L2CAP_RAW_SEND)(
//   IN EFI_BLUETOOTH_IO_PROTOCOL      *This,
//   IN OUT ulong                      *BufferSize,
//   IN void                           *Buffer,
//   IN ulong                          Timeout
//   );

// /**
//   Receive L2CAP message (including L2CAP header).
// 
//   @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[in]  BufferSize          On input, indicates the size, in bytes, of the data buffer specified by Buffer.
//                                   On output, indicates the amount of data actually transferred.
//   @param[out] Buffer              A pointer to the buffer of data that will be received from Bluetooth L2CAP layer.
//   @param[in]  Timeout             Indicating the transfer should be completed within this time frame. The units are in
//                                   milliseconds. If Timeout is 0, then the caller must wait for the function to be completed
//                                   until EFI_SUCCESS or EFI_DEVICE_ERROR is returned.
// 
//   @retval EFI_SUCCESS             The L2CAP message is received successfully.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   - BufferSize is NULL.
//                                   - *BufferSize is 0.
//                                   - Buffer is NULL.
//   @retval EFI_TIMEOUT             Receiving L2CAP message fail due to timeout.
//   @retval EFI_DEVICE_ERROR        Receiving L2CAP message fail due to host controller or device error.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_L2CAP_RAW_RECEIVE)(
//   IN EFI_BLUETOOTH_IO_PROTOCOL  *This,
//   IN OUT ulong                  *BufferSize,
//   OUT void                      *Buffer,
//   IN ulong                      Timeout
//   );

// /**
//   Callback function, it is called when asynchronous transfer is completed.
// 
//   @param[in]  ChannelID         Bluetooth L2CAP message channel ID.
//   @param[in]  Data              Data received via asynchronous transfer.
//   @param[in]  DataLength        The length of Data in bytes, received via asynchronous transfer.
//   @param[in]  Context           Context passed from asynchronous transfer request.
// 
//   @retval EFI_SUCCESS           The callback function complete successfully.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_ASYNC_FUNC_CALLBACK)(
//   IN ushort                     ChannelID,
//   IN void                       *Data,
//   IN ulong                      DataLength,
//   IN void                       *Context
//   );

// /**
//   Receive L2CAP message (including L2CAP header) in non-blocking way.
// 
//   @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[in]  IsNewTransfer       If TRUE, a new transfer will be submitted. If FALSE, the request is deleted.
//   @param[in]  PollingInterval     Indicates the periodic rate, in milliseconds, that the transfer is to be executed.
//   @param[in]  DataLength          Specifies the length, in bytes, of the data to be received.
//   @param[in]  Callback            The callback function. This function is called if the asynchronous transfer is
//                                   completed.
//   @param[in]  Context             Data passed into Callback function. This is optional parameter and may be NULL.
// 
//   @retval EFI_SUCCESS             The L2CAP asynchronous receive request is submitted successfully.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   - DataLength is 0.
//                                   - If IsNewTransfer is TRUE, and an asynchronous receive request already exists.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_L2CAP_RAW_ASYNC_RECEIVE)(
//   IN EFI_BLUETOOTH_IO_PROTOCOL              *This,
//   IN bool                                IsNewTransfer,
//   IN ulong                                  PollingInterval,
//   IN ulong                                  DataLength,
//   IN EFI_BLUETOOTH_IO_ASYNC_FUNC_CALLBACK   Callback,
//   IN void                                   *Context
//   );

// /**
//   Send L2CAP message (excluding L2CAP header) to a specific channel.
// 
//   @param[in]      This            Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[in]      Handle          A handle created by EFI_BLUETOOTH_IO_PROTOCOL.L2CapConnect indicates which channel to send.
//   @param[in, out] BufferSize      On input, indicates the size, in bytes, of the data buffer specified by Buffer.
//                                   On output, indicates the amount of data actually transferred.
//   @param[in]      Buffer          A pointer to the buffer of data that will be transmitted to Bluetooth L2CAP layer.
//   @param[in]      Timeout         Indicating the transfer should be completed within this time frame. The units are in
//                                   milliseconds. If Timeout is 0, then the caller must wait for the function to be completed
//                                   until EFI_SUCCESS or EFI_DEVICE_ERROR is returned.
// 
//   @retval EFI_SUCCESS             The L2CAP message is sent successfully.
//   @retval EFI_NOT_FOUND           Handle is invalid or not found.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   - BufferSize is NULL.
//                                   - *BufferSize is 0.
//                                   - Buffer is NULL.
//   @retval EFI_TIMEOUT             Sending L2CAP message fail due to timeout.
//   @retval EFI_DEVICE_ERROR        Sending L2CAP message fail due to host controller or device error.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_L2CAP_SEND)(
//   IN EFI_BLUETOOTH_IO_PROTOCOL      *This,
//   IN EFI_HANDLE                     Handle,
//   IN OUT ulong                      *BufferSize,
//   IN void                           *Buffer,
//   IN ulong                          Timeout
//   );

// /**
//   Receive L2CAP message (excluding L2CAP header) from a specific channel.
// 
//   @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[in]  Handle              A handle created by EFI_BLUETOOTH_IO_PROTOCOL.L2CapConnect indicates which channel to receive.
//   @param[out] BufferSize          Indicates the size, in bytes, of the data buffer specified by Buffer.
//   @param[out] Buffer              A pointer to the buffer of data that will be received from Bluetooth L2CAP layer.
//   @param[in]  Timeout             Indicating the transfer should be completed within this time frame. The units are in
//                                   milliseconds. If Timeout is 0, then the caller must wait for the function to be completed
//                                   until EFI_SUCCESS or EFI_DEVICE_ERROR is returned.
// 
//   @retval EFI_SUCCESS             The L2CAP message is received successfully.
//   @retval EFI_NOT_FOUND           Handle is invalid or not found.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   - BufferSize is NULL.
//                                   - *BufferSize is 0.
//                                   - Buffer is NULL.
//   @retval EFI_TIMEOUT             Receiving L2CAP message fail due to timeout.
//   @retval EFI_DEVICE_ERROR        Receiving L2CAP message fail due to host controller or device error.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_L2CAP_RECEIVE)(
//   IN EFI_BLUETOOTH_IO_PROTOCOL    *This,
//   IN EFI_HANDLE                   Handle,
//   OUT ulong                       *BufferSize,
//   OUT void                        **Buffer,
//   IN ulong                        Timeout
//   );

// /**
//   Callback function, it is called when asynchronous transfer is completed.
// 
//   @param[in]  Data                Data received via asynchronous transfer.
//   @param[in]  DataLength          The length of Data in bytes, received via asynchronous transfer.
//   @param[in]  Context             Context passed from asynchronous transfer request.
// 
//   @retval EFI_SUCCESS       The callback function complete successfully.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_CHANNEL_SERVICE_CALLBACK)(
//   IN void                         *Data,
//   IN ulong                        DataLength,
//   IN void                         *Context
//   );

// /**
//   Receive L2CAP message (excluding L2CAP header) in non-blocking way from a specific channel.
// 
//   @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[in]  Handel              A handle created by EFI_BLUETOOTH_IO_PROTOCOL.L2CapConnect indicates which channel
//                                   to receive.
//   @param[in]  Callback            The callback function. This function is called if the asynchronous transfer is
//                                   completed.
//   @param[in]  Context             Data passed into Callback function. This is optional parameter and may be NULL.
// 
//   @retval EFI_SUCCESS             The L2CAP asynchronous receive request is submitted successfully.
//   @retval EFI_NOT_FOUND           Handle is invalid or not found.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   - DataLength is 0.
//                                   - If an asynchronous receive request already exists on same Handle.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_L2CAP_ASYNC_RECEIVE)(
//   IN  EFI_BLUETOOTH_IO_PROTOCOL                   *This,
//   IN  EFI_HANDLE                                  Handle,
//   IN  EFI_BLUETOOTH_IO_CHANNEL_SERVICE_CALLBACK   Callback,
//   IN  void *Context
//   );

// /**
//   Do L2CAP connection.
// 
//   @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[out] Handel              A handle to indicate this L2CAP connection.
//   @param[in]  Psm                 Bluetooth PSM. See Bluetooth specification for detail.
//   @param[in]  Mtu                 Bluetooth MTU. See Bluetooth specification for detail.
//   @param[in]  Callback            The callback function. This function is called whenever there is message received
//                                   in this channel.
//   @param[in]  Context             Data passed into Callback function. This is optional parameter and may be NULL.
// 
//   @retval EFI_SUCCESS             The Bluetooth L2CAP layer connection is created successfully.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   - Handle is NULL.
//   @retval EFI_DEVICE_ERROR        A hardware error occurred trying to do Bluetooth L2CAP connection.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_L2CAP_CONNECT)(
//   IN EFI_BLUETOOTH_IO_PROTOCOL                    *This,
//   OUT EFI_HANDLE                                  *Handle,
//   IN ushort                                       Psm,
//   IN ushort                                       Mtu,
//   IN EFI_BLUETOOTH_IO_CHANNEL_SERVICE_CALLBACK    Callback,
//   IN void                                         *Context
//   );

// /**
//   Do L2CAP disconnection.
// 
//   @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[in]  Handel              A handle to indicate this L2CAP connection.
// 
//   @retval EFI_SUCCESS             The Bluetooth L2CAP layer is disconnected successfully.
//   @retval EFI_NOT_FOUND           Handle is invalid or not found.
//   @retval EFI_DEVICE_ERROR        A hardware error occurred trying to do Bluetooth L2CAP disconnection.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_L2CAP_DISCONNECT)(
//   IN EFI_BLUETOOTH_IO_PROTOCOL                    *This,
//   IN EFI_HANDLE                                   Handle
//   );

// /**
//   Register L2CAP callback function for special channel.
// 
//   @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
//   @param[out] Handel              A handle to indicate this L2CAP connection.
//   @param[in]  Psm                 Bluetooth PSM. See Bluetooth specification for detail.
//   @param[in]  Mtu                 Bluetooth MTU. See Bluetooth specification for detail.
//   @param[in]  Callback            The callback function. This function is called whenever there is message received
//                                   in this channel. NULL means unregister.
//   @param[in]  Context             Data passed into Callback function. This is optional parameter and may be NULL.
// 
//   @retval EFI_SUCCESS             The Bluetooth L2CAP callback function is registered successfully.
//   @retval EFI_ALREADY_STARTED     The callback function already exists when register.
//   @retval EFI_NOT_FOUND           The callback function does not exist when unregister.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLUETOOTH_IO_L2CAP_REGISTER_SERVICE)(
//   IN EFI_BLUETOOTH_IO_PROTOCOL                    *This,
//   OUT EFI_HANDLE                                  *Handle,
//   IN ushort                                       Psm,
//   IN ushort                                       Mtu,
//   IN EFI_BLUETOOTH_IO_CHANNEL_SERVICE_CALLBACK    Callback,
//   IN void                                         *Context
//   );

///
/// This protocol provides service for Bluetooth L2CAP (Logical Link Control and Adaptation Protocol)
/// and SDP (Service Discovery Protocol).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_IO_PROTOCOL
{
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* OUT */ulong* /*DeviceInfoSize*/,/* OUT */void** /*DeviceInfo*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_GET_DEVICE_INFO*/ GetDeviceInfo;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* OUT */ulong* /*SdpInfoSize*/,/* OUT */void** /*SdpInfo*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_GET_SDP_INFO*/ GetSdpInfo;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* IN OUT */ulong* /*BufferSize*/,/* IN */void* /*Buffer*/,/* IN */ulong /*Timeout*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_L2CAP_RAW_SEND*/ L2CapRawSend;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* IN OUT */ulong* /*BufferSize*/,/* OUT */void* /*Buffer*/,/* IN */ulong /*Timeout*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_L2CAP_RAW_RECEIVE*/ L2CapRawReceive;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* IN */bool /*IsNewTransfer*/,/* IN */ulong /*PollingInterval*/,/* IN */ulong /*DataLength*/,/* IN */delegate* unmanaged</* IN */ushort /*ChannelID*/,/* IN */void* /*Data*/,/* IN */ulong /*DataLength*/,/* IN */void* /*Context*/, EFI_STATUS> /*Callback*/,/* IN */void* /*Context*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_L2CAP_RAW_ASYNC_RECEIVE*/ L2CapRawAsyncReceive;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* IN */EFI_HANDLE /*Handle*/,/* IN OUT */ulong* /*BufferSize*/,/* IN */void* /*Buffer*/,/* IN */ulong /*Timeout*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_L2CAP_SEND*/ L2CapSend;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* IN */EFI_HANDLE /*Handle*/,/* OUT */ulong* /*BufferSize*/,/* OUT */void** /*Buffer*/,/* IN */ulong /*Timeout*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_L2CAP_RECEIVE*/ L2CapReceive;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* IN */EFI_HANDLE /*Handle*/,/* IN */delegate* unmanaged</* IN */void* /*Data*/,/* IN */ulong /*DataLength*/,/* IN */void* /*Context*/, EFI_STATUS> /*Callback*/,/* IN */void* /*Context*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_L2CAP_ASYNC_RECEIVE*/ L2CapAsyncReceive;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* OUT */EFI_HANDLE* /*Handle*/,/* IN */ushort /*Psm*/,/* IN */ushort /*Mtu*/,/* IN */delegate* unmanaged</* IN */void* /*Data*/,/* IN */ulong /*DataLength*/,/* IN */void* /*Context*/, EFI_STATUS> /*Callback*/,/* IN */void* /*Context*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_L2CAP_CONNECT*/ L2CapConnect;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* IN */EFI_HANDLE /*Handle*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_L2CAP_DISCONNECT*/ L2CapDisconnect;
  public readonly delegate* unmanaged</* IN */EFI_BLUETOOTH_IO_PROTOCOL* /*This*/,/* OUT */EFI_HANDLE* /*Handle*/,/* IN */ushort /*Psm*/,/* IN */ushort /*Mtu*/,/* IN */delegate* unmanaged</* IN */void* /*Data*/,/* IN */ulong /*DataLength*/,/* IN */void* /*Context*/, EFI_STATUS> /*Callback*/,/* IN */void* /*Context*/, EFI_STATUS> /*EFI_BLUETOOTH_IO_L2CAP_REGISTER_SERVICE*/ L2CapRegisterService;
}

// extern EFI_GUID  gEfiBluetoothIoServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiBluetoothIoProtocolGuid;

// #endif
