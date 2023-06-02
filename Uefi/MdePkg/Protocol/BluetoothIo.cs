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
      0x388278d3, 0x7b85, 0x42f0, new byte[] { 0xab, 0xa9, 0xfb, 0x4b, 0xfd, 0x69, 0xf5, 0xab });

  public static EFI_GUID EFI_BLUETOOTH_IO_PROTOCOL_GUID = new GUID(
      0x467313de, 0x4e30, 0x43f1, new byte[] { 0x94, 0x3e, 0x32, 0x3f, 0x89, 0x84, 0x5d, 0xb5 });

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

///
/// This protocol provides service for Bluetooth L2CAP (Logical Link Control and Adaptation Protocol)
/// and SDP (Service Discovery Protocol).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_IO_PROTOCOL
{
  /**
    Get Bluetooth device information.

    @param[in]   This               Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[out]  DeviceInfoSize     A pointer to the size, in bytes, of the DeviceInfo buffer.
    @param[out]  DeviceInfo         A pointer to a callee allocated buffer that returns Bluetooth device information.

    @retval EFI_SUCCESS             The Bluetooth device information is returned successfully.
    @retval EFI_DEVICE_ERROR        A hardware error occurred trying to retrieve the Bluetooth device information.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, ulong*, void**, EFI_STATUS> GetDeviceInfo;
  /**
    Get Bluetooth SDP information.

    @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[out] SdpInfoSize         A pointer to the size, in bytes, of the SdpInfo buffer.
    @param[out] SdpInfo             A pointer to a callee allocated buffer that returns Bluetooth SDP information.

    @retval EFI_SUCCESS             The Bluetooth device information is returned successfully.
    @retval EFI_DEVICE_ERROR        A hardware error occurred trying to retrieve the Bluetooth SDP information.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, ulong*, void**, EFI_STATUS> GetSdpInfo;
  /**
    Send L2CAP message (including L2CAP header).

    @param[in]      This            Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[in, out] BufferSize      On input, indicates the size, in bytes, of the data buffer specified by Buffer.
                                    On output, indicates the amount of data actually transferred.
    @param[in]      Buffer          A pointer to the buffer of data that will be transmitted to Bluetooth L2CAP layer.
    @param[in]      Timeout         Indicating the transfer should be completed within this time frame. The units are in
                                    milliseconds. If Timeout is 0, then the caller must wait for the function to be completed
                                    until EFI_SUCCESS or EFI_DEVICE_ERROR is returned.

    @retval EFI_SUCCESS             The L2CAP message is sent successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    - BufferSize is NULL.
                                    - *BufferSize is 0.
                                    - Buffer is NULL.
    @retval EFI_TIMEOUT             Sending L2CAP message fail due to timeout.
    @retval EFI_DEVICE_ERROR        Sending L2CAP message fail due to host controller or device error.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, ulong*, void*, ulong, EFI_STATUS> L2CapRawSend;
  /**
    Receive L2CAP message (including L2CAP header).

    @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[in]  BufferSize          On input, indicates the size, in bytes, of the data buffer specified by Buffer.
                                    On output, indicates the amount of data actually transferred.
    @param[out] Buffer              A pointer to the buffer of data that will be received from Bluetooth L2CAP layer.
    @param[in]  Timeout             Indicating the transfer should be completed within this time frame. The units are in
                                    milliseconds. If Timeout is 0, then the caller must wait for the function to be completed
                                    until EFI_SUCCESS or EFI_DEVICE_ERROR is returned.

    @retval EFI_SUCCESS             The L2CAP message is received successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    - BufferSize is NULL.
                                    - *BufferSize is 0.
                                    - Buffer is NULL.
    @retval EFI_TIMEOUT             Receiving L2CAP message fail due to timeout.
    @retval EFI_DEVICE_ERROR        Receiving L2CAP message fail due to host controller or device error.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, ulong*, void*, ulong, EFI_STATUS> L2CapRawReceive;
  /**
    Receive L2CAP message (including L2CAP header) in non-blocking way.

    @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[in]  IsNewTransfer       If TRUE, a new transfer will be submitted. If FALSE, the request is deleted.
    @param[in]  PollingInterval     Indicates the periodic rate, in milliseconds, that the transfer is to be executed.
    @param[in]  DataLength          Specifies the length, in bytes, of the data to be received.
    @param[in]  Callback            The callback function. This function is called if the asynchronous transfer is
                                    completed.
    @param[in]  Context             Data passed into Callback function. This is optional parameter and may be NULL.

    @retval EFI_SUCCESS             The L2CAP asynchronous receive request is submitted successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    - DataLength is 0.
                                    - If IsNewTransfer is TRUE, and an asynchronous receive request already exists.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, bool, ulong, ulong, EFI_BLUETOOTH_IO_ASYNC_FUNC_CALLBACK, void*, EFI_STATUS> L2CapRawAsyncReceive;
  /**
    Send L2CAP message (excluding L2CAP header) to a specific channel.

    @param[in]      This            Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[in]      Handle          A handle created by EFI_BLUETOOTH_IO_PROTOCOL.L2CapConnect indicates which channel to send.
    @param[in, out] BufferSize      On input, indicates the size, in bytes, of the data buffer specified by Buffer.
                                    On output, indicates the amount of data actually transferred.
    @param[in]      Buffer          A pointer to the buffer of data that will be transmitted to Bluetooth L2CAP layer.
    @param[in]      Timeout         Indicating the transfer should be completed within this time frame. The units are in
                                    milliseconds. If Timeout is 0, then the caller must wait for the function to be completed
                                    until EFI_SUCCESS or EFI_DEVICE_ERROR is returned.

    @retval EFI_SUCCESS             The L2CAP message is sent successfully.
    @retval EFI_NOT_FOUND           Handle is invalid or not found.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    - BufferSize is NULL.
                                    - *BufferSize is 0.
                                    - Buffer is NULL.
    @retval EFI_TIMEOUT             Sending L2CAP message fail due to timeout.
    @retval EFI_DEVICE_ERROR        Sending L2CAP message fail due to host controller or device error.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, EFI_HANDLE, ulong*, void*, ulong, EFI_STATUS> L2CapSend;
  /**
    Receive L2CAP message (excluding L2CAP header) from a specific channel.

    @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[in]  Handle              A handle created by EFI_BLUETOOTH_IO_PROTOCOL.L2CapConnect indicates which channel to receive.
    @param[out] BufferSize          Indicates the size, in bytes, of the data buffer specified by Buffer.
    @param[out] Buffer              A pointer to the buffer of data that will be received from Bluetooth L2CAP layer.
    @param[in]  Timeout             Indicating the transfer should be completed within this time frame. The units are in
                                    milliseconds. If Timeout is 0, then the caller must wait for the function to be completed
                                    until EFI_SUCCESS or EFI_DEVICE_ERROR is returned.

    @retval EFI_SUCCESS             The L2CAP message is received successfully.
    @retval EFI_NOT_FOUND           Handle is invalid or not found.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    - BufferSize is NULL.
                                    - *BufferSize is 0.
                                    - Buffer is NULL.
    @retval EFI_TIMEOUT             Receiving L2CAP message fail due to timeout.
    @retval EFI_DEVICE_ERROR        Receiving L2CAP message fail due to host controller or device error.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, EFI_HANDLE, ulong*, void**, ulong, EFI_STATUS> L2CapReceive;
  /**
    Receive L2CAP message (excluding L2CAP header) in non-blocking way from a specific channel.

    @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[in]  Handel              A handle created by EFI_BLUETOOTH_IO_PROTOCOL.L2CapConnect indicates which channel
                                    to receive.
    @param[in]  Callback            The callback function. This function is called if the asynchronous transfer is
                                    completed.
    @param[in]  Context             Data passed into Callback function. This is optional parameter and may be NULL.

    @retval EFI_SUCCESS             The L2CAP asynchronous receive request is submitted successfully.
    @retval EFI_NOT_FOUND           Handle is invalid or not found.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    - DataLength is 0.
                                    - If an asynchronous receive request already exists on same Handle.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, EFI_HANDLE, EFI_BLUETOOTH_IO_CHANNEL_SERVICE_CALLBACK, void*, EFI_STATUS> L2CapAsyncReceive;
  /**
    Do L2CAP connection.

    @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[out] Handel              A handle to indicate this L2CAP connection.
    @param[in]  Psm                 Bluetooth PSM. See Bluetooth specification for detail.
    @param[in]  Mtu                 Bluetooth MTU. See Bluetooth specification for detail.
    @param[in]  Callback            The callback function. This function is called whenever there is message received
                                    in this channel.
    @param[in]  Context             Data passed into Callback function. This is optional parameter and may be NULL.

    @retval EFI_SUCCESS             The Bluetooth L2CAP layer connection is created successfully.
    @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
                                    - Handle is NULL.
    @retval EFI_DEVICE_ERROR        A hardware error occurred trying to do Bluetooth L2CAP connection.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, EFI_HANDLE*, ushort, ushort, EFI_BLUETOOTH_IO_CHANNEL_SERVICE_CALLBACK, void*, EFI_STATUS> L2CapConnect;
  /**
    Do L2CAP disconnection.

    @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[in]  Handel              A handle to indicate this L2CAP connection.

    @retval EFI_SUCCESS             The Bluetooth L2CAP layer is disconnected successfully.
    @retval EFI_NOT_FOUND           Handle is invalid or not found.
    @retval EFI_DEVICE_ERROR        A hardware error occurred trying to do Bluetooth L2CAP disconnection.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, EFI_HANDLE, EFI_STATUS> L2CapDisconnect;
  /**
    Register L2CAP callback function for special channel.

    @param[in]  This                Pointer to the EFI_BLUETOOTH_IO_PROTOCOL instance.
    @param[out] Handel              A handle to indicate this L2CAP connection.
    @param[in]  Psm                 Bluetooth PSM. See Bluetooth specification for detail.
    @param[in]  Mtu                 Bluetooth MTU. See Bluetooth specification for detail.
    @param[in]  Callback            The callback function. This function is called whenever there is message received
                                    in this channel. NULL means unregister.
    @param[in]  Context             Data passed into Callback function. This is optional parameter and may be NULL.

    @retval EFI_SUCCESS             The Bluetooth L2CAP callback function is registered successfully.
    @retval EFI_ALREADY_STARTED     The callback function already exists when register.
    @retval EFI_NOT_FOUND           The callback function does not exist when unregister.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_IO_PROTOCOL*, EFI_HANDLE*, ushort, ushort, EFI_BLUETOOTH_IO_CHANNEL_SERVICE_CALLBACK, void*, EFI_STATUS> L2CapRegisterService;
}

// extern EFI_GUID  gEfiBluetoothIoServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiBluetoothIoProtocolGuid;

// #endif
