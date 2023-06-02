using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI Bluetooth LE Config Protocol as defined in UEFI 2.7.
  This protocol abstracts user interface configuration for BluetoothLe device.

  Copyright (c) 2017 - 2019, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.7

**/

// #ifndef __EFI_BLUETOOTH_LE_CONFIG_H__
// #define __EFI_BLUETOOTH_LE_CONFIG_H__

// #include <Protocol/BluetoothConfig.h>
// #include <Protocol/BluetoothAttribute.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_BLUETOOTH_LE_CONFIG_PROTOCOL_GUID = new GUID(
      0x8f76da58, 0x1f99, 0x4275, new byte[] { 0xa4, 0xec, 0x47, 0x56, 0x51, 0x5b, 0x1c, 0xe8 });

  // typedef struct _EFI_BLUETOOTH_LE_CONFIG_PROTOCOL EFI_BLUETOOTH_LE_CONFIG_PROTOCOL;

}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_LE_CONFIG_SCAN_PARAMETER
{
  ///
  /// The version of the structure. A value of zero represents the EFI_BLUETOOTH_LE_CONFIG_SCAN_PARAMETER
  /// structure as defined here. Future version of this specification may extend this data structure in a
  /// backward compatible way and increase the value of Version.
  ///
  public uint Version;
  ///
  /// Passive scanning or active scanning. See Bluetooth specification.
  ///
  public byte ScanType;
  ///
  /// Recommended scan interval to be used while performing scan.
  ///
  public ushort ScanInterval;
  ///
  /// Recommended scan window to be used while performing a scan.
  ///
  public ushort ScanWindow;
  ///
  /// Recommended scanning filter policy to be used while performing a scan.
  ///
  public byte ScanningFilterPolicy;
  ///
  /// This is one byte flag to serve as a filter to remove unneeded scan
  /// result. For example, set BIT0 means scan in LE Limited Discoverable
  /// Mode. Set BIT1 means scan in LE General Discoverable Mode.
  ///
  public byte AdvertisementFlagFilter;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_LE_SCAN_CALLBACK_INFORMATION
{
  public BLUETOOTH_LE_ADDRESS BDAddr;
  public BLUETOOTH_LE_ADDRESS DirectAddress;
  public byte RemoteDeviceState;
  public sbyte RSSI;
  public ulong AdvertisementDataSize;
  public void* AdvertisementData;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_LE_CONFIG_CONNECT_PARAMETER
{
  ///
  /// The version of the structure. A value of zero represents the
  /// EFI_BLUETOOTH_LE_CONFIG_CONNECT_PARAMETER
  /// structure as defined here. Future version of this specification may
  /// extend this data structure in a backward compatible way and
  /// increase the value of Version.
  ///
  public uint Version;
  ///
  /// Recommended scan interval to be used while performing scan before connect.
  ///
  public ushort ScanInterval;
  ///
  /// Recommended scan window to be used while performing a connection
  ///
  public ushort ScanWindow;
  ///
  /// Minimum allowed connection interval. Shall be less than or equal to ConnIntervalMax.
  ///
  public ushort ConnIntervalMin;
  ///
  /// Maximum allowed connection interval. Shall be greater than or equal to ConnIntervalMin.
  ///
  public ushort ConnIntervalMax;
  ///
  /// Slave latency for the connection in number of connection events.
  ///
  public ushort ConnLatency;
  ///
  /// Link supervision timeout for the connection.
  ///
  public ushort SupervisionTimeout;
}

public enum EFI_BLUETOOTH_LE_SMP_EVENT_DATA_TYPE
{
  ///
  /// It indicates an authorization request. No data is associated with the callback
  /// input. In the output data, the application should return the authorization value.
  /// The data structure is BOOLEAN. TRUE means YES. FALSE means NO.
  ///
  EfiBluetoothSmpAuthorizationRequestEvent,
  ///
  /// It indicates that a passkey has been generated locally by the driver, and the same
  /// passkey should be entered at the remote device. The callback input data is the
  /// passkey of type UINT32, to be displayed by the application. No output data
  /// should be returned.
  ///
  EfiBluetoothSmpPasskeyReadyEvent,
  ///
  /// It indicates that the driver is requesting for the passkey has been generated at
  /// the remote device. No data is associated with the callback input. The output data
  /// is the passkey of type UINT32, to be entered by the user.
  ///
  EfiBluetoothSmpPasskeyRequestEvent,
  ///
  /// It indicates that the driver is requesting for the passkey that has been pre-shared
  /// out-of-band with the remote device. No data is associated with the callback
  /// input. The output data is the stored OOB data of type UINT8[16].
  ///
  EfiBluetoothSmpOOBDataRequestEvent,
  ///
  /// In indicates that a number have been generated locally by the bus driver, and
  /// also at the remote device, and the bus driver wants to know if the two numbers
  /// match. The callback input data is the number of type UINT32. The output data
  /// is confirmation value of type BOOLEAN. TRUE means comparison pass. FALSE
  /// means comparison fail.
  ///
  EfiBluetoothSmpNumericComparisonEvent,
}

public enum EFI_BLUETOOTH_LE_SMP_DATA_TYPE
{
  // For local device only
  EfiBluetoothSmpLocalIR,  /* If Key hierarchy is supported */
  EfiBluetoothSmpLocalER,  /* If Key hierarchy is supported */
  EfiBluetoothSmpLocalDHK, /* If Key hierarchy is supported. OPTIONAL */
  // For peer specific
  EfiBluetoothSmpKeysDistributed = 0x1000,
  EfiBluetoothSmpKeySize,
  EfiBluetoothSmpKeyType,
  EfiBluetoothSmpPeerLTK,
  EfiBluetoothSmpPeerIRK,
  EfiBluetoothSmpPeerCSRK,
  EfiBluetoothSmpPeerRand,
  EfiBluetoothSmpPeerEDIV,
  EfiBluetoothSmpPeerSignCounter,
  EfiBluetoothSmpLocalLTK,  /* If Key hierarchy not supported */
  EfiBluetoothSmpLocalIRK,  /* If Key hierarchy not supported */
  EfiBluetoothSmpLocalCSRK, /* If Key hierarchy not supported */
  EfiBluetoothSmpLocalSignCounter,
  EfiBluetoothSmpLocalDIV,
  EfiBluetoothSmpPeerAddressList,
  EfiBluetoothSmpMax,
}

///
/// This protocol abstracts user interface configuration for BluetoothLe device.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLUETOOTH_LE_CONFIG_PROTOCOL
{
  /**
    Initialize BluetoothLE host controller and local device.

    The Init() function initializes BluetoothLE host controller and local device.

    @param[in]  This              Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.

    @retval EFI_SUCCESS           The BluetoothLE host controller and local device is initialized successfully.
    @retval EFI_DEVICE_ERROR      A hardware error occurred trying to initialize the BluetoothLE host controller
                                  and local device.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, EFI_STATUS> Init;
  /**
    Scan BluetoothLE device.

    The Scan() function scans BluetoothLE device. When this function is returned, it just means scan
    request is submitted. It does not mean scan process is started or finished. Whenever there is a
    BluetoothLE device is found, the Callback function will be called. Callback function might be
    called before this function returns or after this function returns

    @param[in]  This              Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]  ReScan            If TRUE, a new scan request is submitted no matter there is scan result before.
                                  If FALSE and there is scan result, the previous scan result is returned and no scan request
                                  is submitted.
    @param[in]  Timeout           Duration in milliseconds for which to scan.
    @param[in]  ScanParameter     If it is not NULL, the ScanParameter is used to perform a scan by the BluetoothLE bus driver.
                                  If it is NULL, the default parameter is used.
    @param[in]  Callback          The callback function. This function is called if a BluetoothLE device is found during
                                  scan process.
    @param[in]  Context           Data passed into Callback function. This is optional parameter and may be NULL.

    @retval EFI_SUCCESS           The Bluetooth scan request is submitted.
    @retval EFI_DEVICE_ERROR      A hardware error occurred trying to scan the BluetoothLE device.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, bool, uint, EFI_BLUETOOTH_LE_CONFIG_SCAN_PARAMETER*, EFI_BLUETOOTH_LE_CONFIG_SCAN_CALLBACK_FUNCTION, void*, EFI_STATUS> Scan;
  /**
    Connect a BluetoothLE device.

    The Connect() function connects a Bluetooth device. When this function is returned successfully,
    a new EFI_BLUETOOTH_IO_PROTOCOL is created.

    @param[in]  This              Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]  AutoReconnect     If TRUE, the BluetoothLE host controller needs to do an auto
                                  reconnect. If FALSE, the BluetoothLE host controller does not do
                                  an auto reconnect.
    @param[in]  DoBonding         If TRUE, the BluetoothLE host controller needs to do a bonding.
                                  If FALSE, the BluetoothLE host controller does not do a bonding.
    @param[in]  ConnectParameter  If it is not NULL, the ConnectParameter is used to perform a
                                  scan by the BluetoothLE bus driver. If it is NULL, the default
                                  parameter is used.
    @param[in]  BD_ADDR           The address of the BluetoothLE device to be connected.

    @retval EFI_SUCCESS           The BluetoothLE device is connected successfully.
    @retval EFI_ALREADY_STARTED   The BluetoothLE device is already connected.
    @retval EFI_NOT_FOUND         The BluetoothLE device is not found.
    @retval EFI_DEVICE_ERROR      A hardware error occurred trying to connect the BluetoothLE device.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, bool, bool, EFI_BLUETOOTH_LE_CONFIG_CONNECT_PARAMETER*, BLUETOOTH_LE_ADDRESS*, EFI_STATUS> Connect;
  /**
    Disconnect a BluetoothLE device.

    The Disconnect() function disconnects a BluetoothLE device. When this function is returned
    successfully, the EFI_BLUETOOTH_ATTRIBUTE_PROTOCOL associated with this device is
    destroyed and all services associated are stopped.

    @param[in]  This          Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]  BD_ADDR       The address of BluetoothLE device to be connected.
    @param[in]  Reason        Bluetooth disconnect reason. See Bluetooth specification for detail.

    @retval EFI_SUCCESS           The BluetoothLE device is disconnected successfully.
    @retval EFI_NOT_STARTED       The BluetoothLE device is not connected.
    @retval EFI_NOT_FOUND         The BluetoothLE device is not found.
    @retval EFI_DEVICE_ERROR      A hardware error occurred trying to disconnect the BluetoothLE device.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, BLUETOOTH_LE_ADDRESS*, byte, EFI_STATUS> Disconnect;
  /**
    Get BluetoothLE configuration data.

    The GetData() function returns BluetoothLE configuration data. For remote BluetoothLE device
    configuration data, please use GetRemoteData() function with valid BD_ADDR.

    @param[in]       This         Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]       DataType     Configuration data type.
    @param[in, out]  DataSize     On input, indicates the size, in bytes, of the data buffer specified by Data.
                                  On output, indicates the amount of data actually returned.
    @param[in, out]  Data         A pointer to the buffer of data that will be returned.

    @retval EFI_SUCCESS           The BluetoothLE configuration data is returned successfully.
    @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                  - DataSize is NULL.
                                  - *DataSize is 0.
                                  - Data is NULL.
    @retval EFI_UNSUPPORTED       The DataType is unsupported.
    @retval EFI_NOT_FOUND         The DataType is not found.
    @retval EFI_BUFFER_TOO_SMALL  The buffer is too small to hold the buffer.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, EFI_BLUETOOTH_CONFIG_DATA_TYPE, ulong*, void*, EFI_STATUS> GetData;
  /**
    Set BluetoothLE configuration data.

    The SetData() function sets local BluetoothLE device configuration data. Not all DataType can be
    set.

    @param[in]  This              Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]  DataType          Configuration data type.
    @param[in]  DataSize          Indicates the size, in bytes, of the data buffer specified by Data.
    @param[in]  Data              A pointer to the buffer of data that will be set.

    @retval EFI_SUCCESS           The BluetoothLE configuration data is set successfully.
    @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                  - DataSize is 0.
                                  - Data is NULL.
    @retval EFI_UNSUPPORTED       The DataType is unsupported.
    @retval EFI_WRITE_PROTECTED   Cannot set configuration data.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, EFI_BLUETOOTH_CONFIG_DATA_TYPE, ulong, void*, EFI_STATUS> SetData;
  /**
    Get remove BluetoothLE device configuration data.

    The GetRemoteData() function returns remote BluetoothLE device configuration data.

    @param[in]  This              Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]  DataType          Configuration data type.
    @param[in]  BDAddr            Remote BluetoothLE device address.
    @param[in, out] DataSize      On input, indicates the size, in bytes, of the data buffer specified by Data.
                                  On output, indicates the amount of data actually returned.
    @param[in, out] Data          A pointer to the buffer of data that will be returned.

    @retval EFI_SUCCESS           The remote BluetoothLE device configuration data is returned successfully.
    @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                  - DataSize is NULL.
                                  - *DataSize is 0.
                                  - Data is NULL.
    @retval EFI_UNSUPPORTED       The DataType is unsupported.
    @retval EFI_NOT_FOUND         The DataType is not found.
    @retval EFI_BUFFER_TOO_SMALL  The buffer is too small to hold the buffer.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, EFI_BLUETOOTH_CONFIG_DATA_TYPE, BLUETOOTH_LE_ADDRESS*, ulong*, void*, EFI_STATUS> GetRemoteData;
  /**
    Register Security Manager Protocol callback function for user authentication/authorization.

    The RegisterSmpAuthCallback() function register Security Manager Protocol callback
    function for user authentication/authorization.

    @param[in]  This            Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]  Callback        Callback function for user authentication/authorization.
    @param[in]  Context         Data passed into Callback function. This is optional parameter and may be NULL.

    @retval EFI_SUCCESS         The SMP callback function is registered successfully.
    @retval EFI_ALREADY_STARTED A callback function is already registered on the same attribute
                                opcode and attribute handle, when the Callback is not NULL.
    @retval EFI_NOT_STARTED     A callback function is not registered on the same attribute opcode
                                and attribute handle, when the Callback is NULL.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, EFI_BLUETOOTH_LE_SMP_CALLBACK, void*, EFI_STATUS> RegisterSmpAuthCallback;
  /**
    Send user authentication/authorization to remote device.

    The SendSmpAuthData() function sends user authentication/authorization to remote device. It
    should be used to send these information after the caller gets the request data from the callback
    function by RegisterSmpAuthCallback().

    @param[in]  This            Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]  BDAddr          Remote BluetoothLE device address.
    @param[in]  EventDataType   Event data type in EFI_BLUETOOTH_LE_SMP_EVENT_DATA_TYPE.
    @param[in]  DataSize        The size of Data in bytes, of the data buffer specified by Data.
    @param[in]  Data            A pointer to the buffer of data that will be sent. The data format
                                depends on the type of SMP event data being responded to.

    @retval EFI_SUCCESS         The SMP authorization data is sent successfully.
    @retval EFI_NOT_READY       SMP is not in the correct state to receive the auth data.

  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, BLUETOOTH_LE_ADDRESS*, EFI_BLUETOOTH_LE_SMP_EVENT_DATA_TYPE, ulong, void*, EFI_STATUS> SendSmpAuthData;
  /**
    Register a callback function to get SMP related data.

    The RegisterSmpGetDataCallback() function registers a callback function to get SMP related data.

    @param[in]  This            Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]  Callback        Callback function for SMP get data.
    @param[in]  Context         Data passed into Callback function. This is optional parameter and may be NULL.

    @retval EFI_SUCCESS         The SMP get data callback function is registered successfully.
    @retval EFI_ALREADY_STARTED A callback function is already registered on the same attribute
                                opcode and attribute handle, when the Callback is not NULL.
    @retval EFI_NOT_STARTED     A callback function is not registered on the same attribute opcode
                                and attribute handle, when the Callback is NULL
  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, EFI_BLUETOOTH_LE_CONFIG_SMP_GET_DATA_CALLBACK, void*, EFI_STATUS> RegisterSmpGetDataCallback;
  /**
    Register a callback function to set SMP related data.

    The RegisterSmpSetDataCallback() function registers a callback function to set SMP related data.

    @param[in]  This            Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]  Callback        Callback function for SMP set data.
    @param[in]  Context         Data passed into Callback function. This is optional parameter and may be NULL.

    @retval EFI_SUCCESS         The SMP set data callback function is registered successfully.
    @retval EFI_ALREADY_STARTED A callback function is already registered on the same attribute
                                opcode and attribute handle, when the Callback is not NULL.
    @retval EFI_NOT_STARTED     A callback function is not registered on the same attribute opcode
                                and attribute handle, when the Callback is NULL
  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, EFI_BLUETOOTH_LE_CONFIG_SMP_SET_DATA_CALLBACK, void*, EFI_STATUS> RegisterSmpSetDataCallback;
  /**
    Register link connect complete callback function.

    The RegisterLinkConnectCompleteCallback() function registers Bluetooth link connect
    complete callback function. The Bluetooth Configuration driver may call
    RegisterLinkConnectCompleteCallback() to register a callback function. During pairing,
    Bluetooth bus driver must trigger this callback function to report device state, if it is registered.
    Then Bluetooth Configuration driver will get information on device connection, according to
    CallbackType defined by EFI_BLUETOOTH_CONNECT_COMPLETE_CALLBACK_TYPE

    @param[in]  This            Pointer to the EFI_BLUETOOTH_LE_CONFIG_PROTOCOL instance.
    @param[in]  Callback        The callback function. NULL means unregister.
    @param[in]  Context         Data passed into Callback function. This is optional parameter and may be NULL.

    @retval EFI_SUCCESS         The link connect complete callback function is registered successfully.
    @retval EFI_ALREADY_STARTED A callback function is already registered on the same attribute
                                opcode and attribute handle, when the Callback is not NULL.
    @retval EFI_NOT_STARTED     A callback function is not registered on the same attribute opcode
                                and attribute handle, when the Callback is NULL
  **/
  public readonly delegate* unmanaged<EFI_BLUETOOTH_LE_CONFIG_PROTOCOL*, EFI_BLUETOOTH_LE_CONFIG_CONNECT_COMPLETE_CALLBACK, void*, EFI_STATUS> RegisterLinkConnectCompleteCallback;
}

// extern EFI_GUID  gEfiBluetoothLeConfigProtocolGuid;

// #endif
