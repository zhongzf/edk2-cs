namespace Uefi;
/** @file
  EFI Multicast Trivial File Transfer Protocol Definition

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.0

**/

// #ifndef __EFI_MTFTP4_PROTOCOL_H__
// #define __EFI_MTFTP4_PROTOCOL_H__

public static EFI_GUID EFI_MTFTP4_SERVICE_BINDING_PROTOCOL_GUID = new GUID(
    0x2FE800BE, 0x8F01, 0x4aa6, new byte[] { 0x94, 0x6B, 0xD7, 0x13, 0x88, 0xE1, 0x83, 0x3F });

public static EFI_GUID EFI_MTFTP4_PROTOCOL_GUID = new GUID(
    0x78247c57, 0x63db, 0x4708, new byte[] { 0x99, 0xc2, 0xa8, 0xb4, 0xa9, 0xa6, 0x1f, 0x6b });

typedef struct _EFI_MTFTP4_PROTOCOL  EFI_MTFTP4_PROTOCOL;
typedef struct _EFI_MTFTP4_TOKEN     EFI_MTFTP4_TOKEN;

//
// MTFTP4 packet opcode definition
//
public static ulong EFI_MTFTP4_OPCODE_RRQ = 1;
public static ulong EFI_MTFTP4_OPCODE_WRQ = 2;
public static ulong EFI_MTFTP4_OPCODE_DATA = 3;
public static ulong EFI_MTFTP4_OPCODE_ACK = 4;
public static ulong EFI_MTFTP4_OPCODE_ERROR = 5;
public static ulong EFI_MTFTP4_OPCODE_OACK = 6;
public static ulong EFI_MTFTP4_OPCODE_DIR = 7;
public static ulong EFI_MTFTP4_OPCODE_DATA8 = 8;
public static ulong EFI_MTFTP4_OPCODE_ACK8 = 9;

//
// MTFTP4 error code definition
//
public static ulong EFI_MTFTP4_ERRORCODE_NOT_DEFINED = 0;
public static ulong EFI_MTFTP4_ERRORCODE_FILE_NOT_FOUND = 1;
public static ulong EFI_MTFTP4_ERRORCODE_ACCESS_VIOLATION = 2;
public static ulong EFI_MTFTP4_ERRORCODE_DISK_FULL = 3;
public static ulong EFI_MTFTP4_ERRORCODE_ILLEGAL_OPERATION = 4;
public static ulong EFI_MTFTP4_ERRORCODE_UNKNOWN_TRANSFER_ID = 5;
public static ulong EFI_MTFTP4_ERRORCODE_FILE_ALREADY_EXISTS = 6;
public static ulong EFI_MTFTP4_ERRORCODE_NO_SUCH_USER = 7;
public static ulong EFI_MTFTP4_ERRORCODE_REQUEST_DENIED = 8;

//
// MTFTP4 pacekt definitions
//
// #pragma pack(1)

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_REQ_HEADER
{
  public ushort OpCode;
  public fixed byte Filename[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_OACK_HEADER
{
  public ushort OpCode;
  public fixed byte Data[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_DATA_HEADER
{
  public ushort OpCode;
  public ushort Block;
  public fixed byte Data[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_ACK_HEADER
{
  public ushort OpCode;
  public fixed ushort Block[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_DATA8_HEADER
{
  public ushort OpCode;
  public ulong Block;
  public fixed byte Data[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_ACK8_HEADER
{
  public ushort OpCode;
  public fixed ulong Block[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_ERROR_HEADER
{
  public ushort OpCode;
  public ushort ErrorCode;
  public fixed byte ErrorMessage[1];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_MTFTP4_PACKET
{
  ///
  /// Type of packets as defined by the MTFTPv4 packet opcodes.
  ///
  [FieldOffset(0)] public ushort OpCode;
  ///
  /// Read request packet header.
  ///
  [FieldOffset(0)] public EFI_MTFTP4_REQ_HEADER Rrq;
  ///
  /// Write request packet header.
  ///
  [FieldOffset(0)] public EFI_MTFTP4_REQ_HEADER Wrq;
  ///
  /// Option acknowledge packet header.
  ///
  [FieldOffset(0)] public EFI_MTFTP4_OACK_HEADER Oack;
  ///
  /// Data packet header.
  ///
  [FieldOffset(0)] public EFI_MTFTP4_DATA_HEADER Data;
  ///
  /// Acknowledgement packet header.
  ///
  [FieldOffset(0)] public EFI_MTFTP4_ACK_HEADER Ack;
  ///
  /// Data packet header with big block number.
  ///
  [FieldOffset(0)] public EFI_MTFTP4_DATA8_HEADER Data8;
  ///
  /// Acknowledgement header with big block num.
  ///
  [FieldOffset(0)] public EFI_MTFTP4_ACK8_HEADER Ack8;
  ///
  /// Error packet header.
  ///
  [FieldOffset(0)] public EFI_MTFTP4_ERROR_HEADER Error;
}

// #pragma pack()

///
/// MTFTP4 option definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_OPTION
{
  public byte* OptionStr;
  public byte* ValueStr;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_CONFIG_DATA
{
  public bool UseDefaultSetting;
  public EFI_IPv4_ADDRESS StationIp;
  public EFI_IPv4_ADDRESS SubnetMask;
  public ushort LocalPort;
  public EFI_IPv4_ADDRESS GatewayIp;
  public EFI_IPv4_ADDRESS ServerIp;
  public ushort InitialServerPort;
  public ushort TryCount;
  public ushort TimeoutValue;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_MODE_DATA
{
  public EFI_MTFTP4_CONFIG_DATA ConfigData;
  public byte SupportedOptionCount;
  public byte** SupportedOptoins;
  public byte UnsupportedOptionCount;
  public byte** UnsupportedOptoins;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_OVERRIDE_DATA
{
  public EFI_IPv4_ADDRESS GatewayIp;
  public EFI_IPv4_ADDRESS ServerIp;
  public ushort ServerPort;
  public ushort TryCount;
  public ushort TimeoutValue;
}

//
// Protocol interfaces definition
//





























































































































































































































































































































///
/// The EFI_MTFTP4_PROTOCOL is designed to be used by UEFI drivers and applications
/// to transmit and receive data files. The EFI MTFTPv4 Protocol driver uses
/// the underlying EFI UDPv4 Protocol driver and EFI IPv4 Protocol driver.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_PROTOCOL
{
  /**
    Submits an asynchronous interrupt transfer to an interrupt endpoint of a USB device.

    @param  This     The pointer to the EFI_MTFTP4_PROTOCOL instance.
    @param  ModeData The pointer to storage for the EFI MTFTPv4 Protocol driver mode data.

    @retval EFI_SUCCESS           The configuration data was successfully returned.
    @retval EFI_OUT_OF_RESOURCES  The required mode data could not be allocated.
    @retval EFI_INVALID_PARAMETER This is NULL or ModeData is NULL.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, EFI_MTFTP4_MODE_DATA*, EFI_STATUS> GetModeData;
  /**
    Initializes, changes, or resets the default operational setting for this
    EFI MTFTPv4 Protocol driver instance.

    @param  This            The pointer to the EFI_MTFTP4_PROTOCOL instance.
    @param  MtftpConfigData The pointer to the configuration data structure.

    @retval EFI_SUCCESS           The EFI MTFTPv4 Protocol driver was configured successfully.
    @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
    @retval EFI_ACCESS_DENIED     The EFI configuration could not be changed at this time because
                                  there is one MTFTP background operation in progress.
    @retval EFI_NO_MAPPING        When using a default address, configuration (DHCP, BOOTP,
                                  RARP, etc.) has not finished yet.
    @retval EFI_UNSUPPORTED       A configuration protocol (DHCP, BOOTP, RARP, etc.) could not
                                  be located when clients choose to use the default address
                                  settings.
    @retval EFI_OUT_OF_RESOURCES  The EFI MTFTPv4 Protocol driver instance data could not be
                                  allocated.
    @retval EFI_DEVICE_ERROR      An unexpected system or network error occurred. The EFI
                                   MTFTPv4 Protocol driver instance is not configured.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, EFI_MTFTP4_CONFIG_DATA*, EFI_STATUS> Configure;
  /**
    Gets information about a file from an MTFTPv4 server.

    @param  This         The pointer to the EFI_MTFTP4_PROTOCOL instance.
    @param  OverrideData Data that is used to override the existing parameters. If NULL,
                         the default parameters that were set in the
                         EFI_MTFTP4_PROTOCOL.Configure() function are used.
    @param  Filename     The pointer to null-terminated ASCII file name string.
    @param  ModeStr      The pointer to null-terminated ASCII mode string. If NULL, "octet" will be used.
    @param  OptionCount  Number of option/value string pairs in OptionList.
    @param  OptionList   The pointer to array of option/value string pairs. Ignored if
                         OptionCount is zero.
    @param  PacketLength The number of bytes in the returned packet.
    @param  Packet       The pointer to the received packet. This buffer must be freed by
                         the caller.

    @retval EFI_SUCCESS              An MTFTPv4 OACK packet was received and is in the Packet.
    @retval EFI_INVALID_PARAMETER    One or more of the following conditions is TRUE:
                                     - This is NULL.
                                     - Filename is NULL.
                                     - OptionCount is not zero and OptionList is NULL.
                                     - One or more options in OptionList have wrong format.
                                     - PacketLength is NULL.
                                     - One or more IPv4 addresses in OverrideData are not valid
                                       unicast IPv4 addresses if OverrideData is not NULL.
    @retval EFI_UNSUPPORTED          One or more options in the OptionList are in the
                                     unsupported list of structure EFI_MTFTP4_MODE_DATA.
    @retval EFI_NOT_STARTED          The EFI MTFTPv4 Protocol driver has not been started.
    @retval EFI_NO_MAPPING           When using a default address, configuration (DHCP, BOOTP,
                                     RARP, etc.) has not finished yet.
    @retval EFI_ACCESS_DENIED        The previous operation has not completed yet.
    @retval EFI_OUT_OF_RESOURCES     Required system resources could not be allocated.
    @retval EFI_TFTP_ERROR           An MTFTPv4 ERROR packet was received and is in the Packet.
    @retval EFI_NETWORK_UNREACHABLE  An ICMP network unreachable error packet was received and the Packet is set to NULL.
    @retval EFI_HOST_UNREACHABLE     An ICMP host unreachable error packet was received and the Packet is set to NULL.
    @retval EFI_PROTOCOL_UNREACHABLE An ICMP protocol unreachable error packet was received and the Packet is set to NULL.
    @retval EFI_PORT_UNREACHABLE     An ICMP port unreachable error packet was received and the Packet is set to NULL.
    @retval EFI_ICMP_ERROR           Some other ICMP ERROR packet was received and is in the Buffer.
    @retval EFI_PROTOCOL_ERROR       An unexpected MTFTPv4 packet was received and is in the Packet.
    @retval EFI_TIMEOUT              No responses were received from the MTFTPv4 server.
    @retval EFI_DEVICE_ERROR         An unexpected network error or system error occurred.
    @retval EFI_NO_MEDIA             There was a media error.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, EFI_MTFTP4_OVERRIDE_DATA*, byte*, byte*, byte, EFI_MTFTP4_OPTION*, uint*, EFI_MTFTP4_PACKET**, EFI_STATUS> GetInfo;
  /**
    Parses the options in an MTFTPv4 OACK packet.

    @param  This         The pointer to the EFI_MTFTP4_PROTOCOL instance.
    @param  PacketLen    Length of the OACK packet to be parsed.
    @param  Packet       The pointer to the OACK packet to be parsed.
    @param  OptionCount  The pointer to the number of options in following OptionList.
    @param  OptionList   The pointer to EFI_MTFTP4_OPTION storage. Call the EFI Boot
                         Service FreePool() to release the OptionList if the options
                         in this OptionList are not needed any more.

    @retval EFI_SUCCESS           The OACK packet was valid and the OptionCount and
                                  OptionList parameters have been updated.
    @retval EFI_INVALID_PARAMETER One or more of the following conditions is TRUE:
                                  - PacketLen is 0.
                                  - Packet is NULL or Packet is not a valid MTFTPv4 packet.
                                  - OptionCount is NULL.
    @retval EFI_NOT_FOUND         No options were found in the OACK packet.
    @retval EFI_OUT_OF_RESOURCES  Storage for the OptionList array cannot be allocated.
    @retval EFI_PROTOCOL_ERROR    One or more of the option fields is invalid.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, uint, EFI_MTFTP4_PACKET*, uint*, EFI_MTFTP4_OPTION**, EFI_STATUS> ParseOptions;
  /**
    Downloads a file from an MTFTPv4 server.

    @param  This  The pointer to the EFI_MTFTP4_PROTOCOL instance.
    @param  Token The pointer to the token structure to provide the parameters that are
                  used in this operation.

    @retval EFI_SUCCESS              The data file has been transferred successfully.
    @retval EFI_OUT_OF_RESOURCES     Required system resources could not be allocated.
    @retval EFI_BUFFER_TOO_SMALL     BufferSize is not zero but not large enough to hold the
                                     downloaded data in downloading process.
    @retval EFI_ABORTED              Current operation is aborted by user.
    @retval EFI_NETWORK_UNREACHABLE  An ICMP network unreachable error packet was received.
    @retval EFI_HOST_UNREACHABLE     An ICMP host unreachable error packet was received.
    @retval EFI_PROTOCOL_UNREACHABLE An ICMP protocol unreachable error packet was received.
    @retval EFI_PORT_UNREACHABLE     An ICMP port unreachable error packet was received.
    @retval EFI_ICMP_ERROR           Some other  ICMP ERROR packet was received.
    @retval EFI_TIMEOUT              No responses were received from the MTFTPv4 server.
    @retval EFI_TFTP_ERROR           An MTFTPv4 ERROR packet was received.
    @retval EFI_DEVICE_ERROR         An unexpected network error or system error occurred.
    @retval EFI_NO_MEDIA             There was a media error.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, EFI_MTFTP4_TOKEN*, EFI_STATUS> ReadFile;
  /**
    Sends a file to an MTFTPv4 server.

    @param  This  The pointer to the EFI_MTFTP4_PROTOCOL instance.
    @param  Token The pointer to the token structure to provide the parameters that are
                  used in this operation.

    @retval EFI_SUCCESS           The upload session has started.
    @retval EFI_UNSUPPORTED       The operation is not supported by this implementation.
    @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
    @retval EFI_UNSUPPORTED       One or more options in the Token.OptionList are in
                                  the unsupported list of structure EFI_MTFTP4_MODE_DATA.
    @retval EFI_NOT_STARTED       The EFI MTFTPv4 Protocol driver has not been started.
    @retval EFI_NO_MAPPING        When using a default address, configuration (DHCP, BOOTP,
                                  RARP, etc.) is not finished yet.
    @retval EFI_ALREADY_STARTED   This Token is already being used in another MTFTPv4 session.
    @retval EFI_OUT_OF_RESOURCES  Required system resources could not be allocated.
    @retval EFI_ACCESS_DENIED     The previous operation has not completed yet.
    @retval EFI_DEVICE_ERROR      An unexpected network error or system error occurred.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, EFI_MTFTP4_TOKEN*, EFI_STATUS> WriteFile;
  /**
    Downloads a data file "directory" from an MTFTPv4 server. May be unsupported in some EFI
    implementations.

    @param  This  The pointer to the EFI_MTFTP4_PROTOCOL instance.
    @param  Token The pointer to the token structure to provide the parameters that are
                  used in this operation.

    @retval EFI_SUCCESS           The MTFTPv4 related file "directory" has been downloaded.
    @retval EFI_UNSUPPORTED       The operation is not supported by this implementation.
    @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
    @retval EFI_UNSUPPORTED       One or more options in the Token.OptionList are in
                                  the unsupported list of structure EFI_MTFTP4_MODE_DATA.
    @retval EFI_NOT_STARTED       The EFI MTFTPv4 Protocol driver has not been started.
    @retval EFI_NO_MAPPING        When using a default address, configuration (DHCP, BOOTP,
                                  RARP, etc.) is not finished yet.
    @retval EFI_ALREADY_STARTED   This Token is already being used in another MTFTPv4 session.
    @retval EFI_OUT_OF_RESOURCES  Required system resources could not be allocated.
    @retval EFI_ACCESS_DENIED     The previous operation has not completed yet.
    @retval EFI_DEVICE_ERROR      An unexpected network error or system error occurred.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, EFI_MTFTP4_TOKEN*, EFI_STATUS> ReadDirectory;
  /**
    Polls for incoming data packets and processes outgoing data packets.

    @param  This The pointer to the EFI_MTFTP4_PROTOCOL instance.

    @retval  EFI_SUCCESS           Incoming or outgoing data was processed.
    @retval  EFI_NOT_STARTED       This EFI MTFTPv4 Protocol instance has not been started.
    @retval  EFI_NO_MAPPING        When using a default address, configuration (DHCP, BOOTP,
                                   RARP, etc.) is not finished yet.
    @retval  EFI_INVALID_PARAMETER This is NULL.
    @retval  EFI_DEVICE_ERROR      An unexpected system or network error occurred.
    @retval  EFI_TIMEOUT           Data was dropped out of the transmit and/or receive queue.
                                   Consider increasing the polling rate.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, EFI_STATUS> Poll;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP4_TOKEN
{
  ///
  /// The status that is returned to the caller at the end of the operation
  /// to indicate whether this operation completed successfully.
  ///
  public EFI_STATUS Status;
  ///
  /// The event that will be signaled when the operation completes. If
  /// set to NULL, the corresponding function will wait until the read or
  /// write operation finishes. The type of Event must be
  /// EVT_NOTIFY_SIGNAL. The Task Priority Level (TPL) of
  /// Event must be lower than or equal to TPL_CALLBACK.
  ///
  public EFI_EVENT Event;
  ///
  /// If not NULL, the data that will be used to override the existing configure data.
  ///
  public EFI_MTFTP4_OVERRIDE_DATA* OverrideData;
  ///
  /// The pointer to the null-terminated ASCII file name string.
  ///
  public byte* Filename;
  ///
  /// The pointer to the null-terminated ASCII mode string. If NULL, "octet" is used.
  ///
  public byte* ModeStr;
  ///
  /// Number of option/value string pairs.
  ///
  public uint OptionCount;
  ///
  /// The pointer to an array of option/value string pairs. Ignored if OptionCount is zero.
  ///
  public EFI_MTFTP4_OPTION* OptionList;
  ///
  /// The size of the data buffer.
  ///
  public ulong BufferSize;
  ///
  /// The pointer to the data buffer. Data that is downloaded from the
  /// MTFTPv4 server is stored here. Data that is uploaded to the
  /// MTFTPv4 server is read from here. Ignored if BufferSize is zero.
  ///
  public void* Buffer;
  ///
  /// The pointer to the context that will be used by CheckPacket,
  /// TimeoutCallback and PacketNeeded.
  ///
  public void* Context;
  ///
  /// The pointer to the callback function to check the contents of the received packet.
  ///
  /**
    A callback function that is provided by the caller to intercept
    the EFI_MTFTP4_OPCODE_DATA or EFI_MTFTP4_OPCODE_DATA8 packets processed in the
    EFI_MTFTP4_PROTOCOL.ReadFile() function, and alternatively to intercept
    EFI_MTFTP4_OPCODE_OACK or EFI_MTFTP4_OPCODE_ERROR packets during a call to
    EFI_MTFTP4_PROTOCOL.ReadFile(), WriteFile() or ReadDirectory().

    @param  This        The pointer to the EFI_MTFTP4_PROTOCOL instance.
    @param  Token       The token that the caller provided in the
                        EFI_MTFTP4_PROTOCOL.ReadFile(), WriteFile()
                        or ReadDirectory() function.
    @param  PacketLen   Indicates the length of the packet.
    @param  Packet      The pointer to an MTFTPv4 packet.

    @retval EFI_SUCCESS The operation was successful.
    @retval Others      Aborts the transfer process.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, EFI_MTFTP4_TOKEN*, ushort, EFI_MTFTP4_PACKET*, EFI_STATUS> CheckPacket;
  ///
  /// The pointer to the function to be called when a timeout occurs.
  ///
  /**
    Timeout callback function.

    @param  This           The pointer to the EFI_MTFTP4_PROTOCOL instance.
    @param  Token          The token that is provided in the
                           EFI_MTFTP4_PROTOCOL.ReadFile() or
                           EFI_MTFTP4_PROTOCOL.WriteFile() or
                           EFI_MTFTP4_PROTOCOL.ReadDirectory() functions
                           by the caller.

    @retval EFI_SUCCESS   The operation was successful.
    @retval Others        Aborts download process.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, EFI_MTFTP4_TOKEN*, EFI_STATUS> TimeoutCallback;
  ///
  /// The pointer to the function to provide the needed packet contents.
  ///
  /**
    A callback function that the caller provides to feed data to the
    EFI_MTFTP4_PROTOCOL.WriteFile() function.

    @param  This   The pointer to the EFI_MTFTP4_PROTOCOL instance.
    @param  Token  The token provided in the
                   EFI_MTFTP4_PROTOCOL.WriteFile() by the caller.
    @param  Length Indicates the length of the raw data wanted on input, and the
                   length the data available on output.
    @param  Buffer The pointer to the buffer where the data is stored.

    @retval EFI_SUCCESS The operation was successful.
    @retval Others      Aborts session.

  **/
  public readonly delegate* unmanaged<EFI_MTFTP4_PROTOCOL*, EFI_MTFTP4_TOKEN*, OUT, void**, EFI_STATUS> PacketNeeded;
}

// extern EFI_GUID  gEfiMtftp4ServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiMtftp4ProtocolGuid;

// #endif
