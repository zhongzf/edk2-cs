namespace Uefi;
/** @file
  EFI FTPv4 (File Transfer Protocol version 4) Protocol Definition
  The EFI FTPv4 Protocol is used to locate communication devices that are
  supported by an EFI FTPv4 Protocol driver and to create and destroy instances
  of the EFI FTPv4 Protocol child protocol driver that can use the underlying
  communication device.
  The definitions in this file are defined in UEFI Specification 2.3, which have
  not been verified by one implementation yet.

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.2

**/

// #ifndef __EFI_FTP4_PROTOCOL_H__
// #define __EFI_FTP4_PROTOCOL_H__

public static EFI_GUID EFI_FTP4_SERVICE_BINDING_PROTOCOL_GUID = new GUID( 
    0xfaaecb1, 0x226e, 0x4782, new byte[] {0xaa, 0xce, 0x7d, 0xb9, 0xbc, 0xbf, 0x4d, 0xaf });

public static EFI_GUID EFI_FTP4_PROTOCOL_GUID = new GUID( 
    0xeb338826, 0x681b, 0x4295, new byte[] {0xb3, 0x56, 0x2b, 0x36, 0x4c, 0x75, 0x7b, 0x9 });

// typedef struct _EFI_FTP4_PROTOCOL EFI_FTP4_PROTOCOL;

///
/// EFI_FTP4_CONNECTION_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FTP4_CONNECTION_TOKEN {
  ///
  /// The Event to signal after the connection is established and Status field is updated
  /// by the EFI FTP v4 Protocol driver. The type of Event must be
  /// EVENT_NOTIFY_SIGNAL, and its Task Priority Level (TPL) must be lower than or
  /// equal to TPL_CALLBACK. If it is set to NULL, this function will not return  until the
  /// function completes.
  ///
 public EFI_EVENT    Event;
  ///
  /// The variable to receive the result of the completed operation.
  /// EFI_SUCCESS:              The FTP connection is established successfully
  /// EFI_ACCESS_DENIED:        The FTP server denied the access the user's request to access it.
  /// EFI_CONNECTION_RESET:     The connect fails because the connection is reset either by instance
  ///                           itself or communication peer.
  /// EFI_TIMEOUT:              The connection establishment timer expired and no more specific
  ///                           information is available.
  /// EFI_NETWORK_UNREACHABLE:  The active open fails because an ICMP network unreachable error is
  ///                           received.
  /// EFI_HOST_UNREACHABLE:     The active open fails because an ICMP host unreachable error is
  ///                           received.
  /// EFI_PROTOCOL_UNREACHABLE: The active open fails because an ICMP protocol unreachable error is
  ///                           received.
  /// EFI_PORT_UNREACHABLE:     The connection establishment timer times out and an ICMP port
  ///                           unreachable error is received.
  /// EFI_ICMP_ERROR:           The connection establishment timer timeout and some other ICMP
  ///                           error is received.
  /// EFI_DEVICE_ERROR:         An unexpected system or network error occurred.
  ///
 public EFI_STATUS    Status;
}

///
/// EFI_FTP4_CONFIG_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FTP4_CONFIG_DATA {
  ///
  /// Pointer to a ASCII string that contains user name. The caller is
  /// responsible for freeing Username after GetModeData() is called.
  ///
 public byte               *Username;
  ///
  /// Pointer to a ASCII string that contains password. The caller is
  /// responsible for freeing Password after GetModeData() is called.
  ///
 public byte               *Password;
  ///
  /// Set it to TRUE to initiate an active data connection. Set it to
  /// FALSE to initiate a passive data connection.
  ///
 public bool             Active;
  ///
  /// Boolean value indicating if default network settting used.
  ///
 public bool             UseDefaultSetting;
  ///
  /// IP address of station if UseDefaultSetting is FALSE.
  ///
 public EFI_IPv4_ADDRESS    StationIp;
  ///
  /// Subnet mask of station if UseDefaultSetting is FALSE.
  ///
 public EFI_IPv4_ADDRESS    SubnetMask;
  ///
  /// IP address of gateway if UseDefaultSetting is FALSE.
  ///
 public EFI_IPv4_ADDRESS    GatewayIp;
  ///
  /// IP address of FTPv4 server.
  ///
 public EFI_IPv4_ADDRESS    ServerIp;
  ///
  /// FTPv4 server port number of control connection, and the default
  /// value is 21 as convention.
  ///
 public ushort              ServerPort;
  ///
  /// FTPv4 server port number of data connection. If it is zero, use
  /// (ServerPort - 1) by convention.
  ///
 public ushort              AltDataPort;
  ///
  /// A byte indicate the representation type. The right 4 bit is used for
  /// first parameter, the left 4 bit is use for second parameter
  /// - For the first parameter, 0x0 = image, 0x1 = EBCDIC, 0x2 = ASCII, 0x3 = local
  /// - For the second parameter, 0x0 = Non-print, 0x1 = Telnet format effectors, 0x2 =
  ///   Carriage Control.
  /// - If it is a local type, the second parameter is the local byte byte size.
  /// - If it is a image type, the second parameter is undefined.
  ///
 public byte    RepType;
  ///
  /// Defines the file structure in FTP used. 0x00 = file, 0x01 = record, 0x02 = page.
  ///
 public byte    FileStruct;
  ///
  /// Defines the transifer mode used in FTP. 0x00 = stream, 0x01 = Block, 0x02 = Compressed.
  ///
 public byte    TransMode;
}

// typedef struct _EFI_FTP4_COMMAND_TOKEN EFI_FTP4_COMMAND_TOKEN;
























///
/// EFI_FTP4_COMMAND_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FTP4_COMMAND_TOKEN {
  ///
  /// The Event to signal after request is finished and Status field
  /// is updated by the EFI FTP v4 Protocol driver. The type of Event
  /// must be EVT_NOTIFY_SIGNAL, and its Task Priority Level
  /// (TPL) must be lower than or equal to TPL_CALLBACK. If it is
  /// set to NULL, related function must wait until the function
  /// completes.
  ///
 public EFI_EVENT    Event;
  ///
  /// Pointer to a null-terminated ASCII name string.
  ///
 public byte        *Pathname;
  ///
  /// The size of data buffer in bytes.
  ///
 public ulong       DataBufferSize;
  ///
  /// Pointer to the data buffer. Data downloaded from FTP server
  /// through connection is downloaded here.
  ///
 public void         *DataBuffer;
  ///
  /// Pointer to a callback function. If it is receiving function that leads
  /// to inbound data, the callback function is called when databuffer is
  /// full. Then, old data in the data buffer should be flushed and new
  /// data is stored from the beginning of data buffer. If it is a transmit
  /// function that lead to outbound data and DataBufferSize of
  /// Data in DataBuffer has been transmitted, this callback
  /// function is called to supply additional data to be transmitted. The
  /// size of additional data to be transmitted is indicated in
  /// DataBufferSize, again. If there is no data remained,
  /// DataBufferSize should be set to 0.
  ///
/**
  Callback function when process inbound or outbound data.

  If it is receiving function that leads to inbound data, the callback function
  is called when data buffer is full. Then, old data in the data buffer should be
  flushed and new data is stored from the beginning of data buffer.
  If it is a transmit function that lead to outbound data and the size of
  Data in daata buffer has been transmitted, this callback function is called to
  supply additional data to be transmitted.

  @param[in] This                Pointer to the EFI_FTP4_PROTOCOL instance.
  @param[in] Token               Pointer to the token structure to provide the parameters that
                                 are used in this operation.
  @return  User defined Status.

**/
public readonly delegate* unmanaged<EFI_FTP4_PROTOCOL*,EFI_FTP4_COMMAND_TOKEN*, EFI_STATUS> DataCallback;
  ///
  /// Pointer to the parameter for DataCallback.
  ///
 public void                      *Context;
  ///
  /// The variable to receive the result of the completed operation.
  /// EFI_SUCCESS:              The FTP command is completed successfully.
  /// EFI_ACCESS_DENIED:        The FTP server denied the access to the requested file.
  /// EFI_CONNECTION_RESET:     The connect fails because the connection is reset either
  ///                           by instance itself or communication peer.
  /// EFI_TIMEOUT:              The connection establishment timer expired and no more




























































                                 - This is NULL.




























                                 - This is NULL.




































  @retval EFI_NO_MAPPING         When using a default address, configuration (DHCP, BOOTP,




































                                 - Token.Pathname is NULL.







































                                 - Token.Pathname is NULL.




































                                 - Token is NULL.



























  @param[in] This                Pointer to the EFI_FTP4_PROTOCOL instance.

  @retval EFI_SUCCESS            Incoming or outgoing data was processed.
  @retval EFI_NOT_STARTED        This EFI FTPv4 Protocol instance has not been started.
  @retval EFI_INVALID_PARAMETER  This is NULL.
  @retval EFI_DEVICE_ERROR       EapAuthType An unexpected system or network error occurred.
  @retval EFI_TIMEOUT            Data was dropped out of the transmit and/or receive queue.
                                 Consider increasing the polling rate.

**/
typedef
EFI_STATUS
(EFIAPI *EFI_FTP4_POLL)(
  IN EFI_FTP4_PROTOCOL        *This
  );

///
/// EFI_FTP4_PROTOCOL
/// provides basic services for client-side FTP (File Transfer Protocol)
/// operations.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FTP4_PROTOCOL {
 public EFI_FTP4_GET_MODE_DATA     GetModeData;
 public EFI_FTP4_CONNECT           Connect;
 public EFI_FTP4_CLOSE             Close;
 public EFI_FTP4_CONFIGURE         Configure;
 public EFI_FTP4_READ_FILE         ReadFile;
 public EFI_FTP4_WRITE_FILE        WriteFile;
 public EFI_FTP4_READ_DIRECTORY    ReadDirectory;
 public EFI_FTP4_POLL              Poll;
}

// extern EFI_GUID  gEfiFtp4ServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiFtp4ProtocolGuid;

// #endif
