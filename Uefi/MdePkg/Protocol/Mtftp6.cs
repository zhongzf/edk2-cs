namespace Uefi;
/** @file
  UEFI Multicast Trivial File Transfer Protocol v6 Definition, which is built upon
  the EFI UDPv6 Protocol and provides basic services for client-side unicast and/or
  multicast TFTP operations.

  Copyright (c) 2008 - 2011, Intel Corporation. All rights reserved.<BR>
  (C) Copyright 2016 Hewlett Packard Enterprise Development LP<BR>

  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.2

**/

// #ifndef __EFI_MTFTP6_PROTOCOL_H__
// #define __EFI_MTFTP6_PROTOCOL_H__

public static EFI_GUID EFI_MTFTP6_SERVICE_BINDING_PROTOCOL_GUID = new GUID(
    0xd9760ff3, 0x3cca, 0x4267, new byte[] { 0x80, 0xf9, 0x75, 0x27, 0xfa, 0xfa, 0x42, 0x23 });

public static EFI_GUID EFI_MTFTP6_PROTOCOL_GUID = new GUID(
    0xbf0a78ba, 0xec29, 0x49cf, new byte[] { 0xa1, 0xc9, 0x7a, 0xe5, 0x4e, 0xab, 0x6a, 0x51 });

typedef struct _EFI_MTFTP6_PROTOCOL  EFI_MTFTP6_PROTOCOL;
typedef struct _EFI_MTFTP6_TOKEN     EFI_MTFTP6_TOKEN;

///
/// MTFTP Packet OpCodes
///@{
public static ulong EFI_MTFTP6_OPCODE_RRQ = 1   ///< The MTFTPv6 packet is a read request.;
public static ulong EFI_MTFTP6_OPCODE_WRQ = 2   ///< The MTFTPv6 packet is a write request.;
public static ulong EFI_MTFTP6_OPCODE_DATA = 3   ///< The MTFTPv6 packet is a data packet.;
public static ulong EFI_MTFTP6_OPCODE_ACK = 4   ///< The MTFTPv6 packet is an acknowledgement packet.;
public static ulong EFI_MTFTP6_OPCODE_ERROR = 5   ///< The MTFTPv6 packet is an error packet.;
public static ulong EFI_MTFTP6_OPCODE_OACK = 6   ///< The MTFTPv6 packet is an option acknowledgement packet.;
public static ulong EFI_MTFTP6_OPCODE_DIR = 7   ///< The MTFTPv6 packet is a directory query packet.;
public static ulong EFI_MTFTP6_OPCODE_DATA8 = 8   ///< The MTFTPv6 packet is a data packet with a big block number.;
public static ulong EFI_MTFTP6_OPCODE_ACK8 = 9   ///< The MTFTPv6 packet is an acknowledgement packet with a big block number.;
///@}

///
/// MTFTP ERROR Packet ErrorCodes
///@{
///
/// The error code is not defined. See the error message in the packet (if any) for details.
///
public static ulong EFI_MTFTP6_ERRORCODE_NOT_DEFINED = 0;
///
/// The file was not found.
///
public static ulong EFI_MTFTP6_ERRORCODE_FILE_NOT_FOUND = 1;
///
/// There was an access violation.
///
public static ulong EFI_MTFTP6_ERRORCODE_ACCESS_VIOLATION = 2;
///
/// The disk was full or its allocation was exceeded.
///
public static ulong EFI_MTFTP6_ERRORCODE_DISK_FULL = 3;
///
/// The MTFTPv6 operation was illegal.
///
public static ulong EFI_MTFTP6_ERRORCODE_ILLEGAL_OPERATION = 4;
///
/// The transfer ID is unknown.
///
public static ulong EFI_MTFTP6_ERRORCODE_UNKNOWN_TRANSFER_ID = 5;
///
/// The file already exists.
///
public static ulong EFI_MTFTP6_ERRORCODE_FILE_ALREADY_EXISTS = 6;
///
/// There is no such user.
///
public static ulong EFI_MTFTP6_ERRORCODE_NO_SUCH_USER = 7;
///
/// The request has been denied due to option negotiation.
///
public static ulong EFI_MTFTP6_ERRORCODE_REQUEST_DENIED = 8;
///@}

// #pragma pack(1)

///
/// EFI_MTFTP6_REQ_HEADER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_REQ_HEADER
{
  ///
  /// For this packet type, OpCode = EFI_MTFTP6_OPCODE_RRQ for a read request
  /// or OpCode = EFI_MTFTP6_OPCODE_WRQ for a write request.
  ///
  public ushort OpCode;
  ///
  /// The file name to be downloaded or uploaded.
  ///
  public fixed byte Filename[1];
}

///
/// EFI_MTFTP6_OACK_HEADER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_OACK_HEADER
{
  ///
  /// For this packet type, OpCode = EFI_MTFTP6_OPCODE_OACK.
  ///
  public ushort OpCode;
  ///
  /// The option strings in the option acknowledgement packet.
  ///
  public fixed byte Data[1];
}

///
/// EFI_MTFTP6_DATA_HEADER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_DATA_HEADER
{
  ///
  /// For this packet type, OpCode = EFI_MTFTP6_OPCODE_DATA.
  ///
  public ushort OpCode;
  ///
  /// Block number of this data packet.
  ///
  public ushort Block;
  ///
  /// The content of this data packet.
  ///
  public fixed byte Data[1];
}

///
/// EFI_MTFTP6_ACK_HEADER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_ACK_HEADER
{
  ///
  /// For this packet type, OpCode = EFI_MTFTP6_OPCODE_ACK.
  ///
  public ushort OpCode;
  ///
  /// The block number of the data packet that is being acknowledged.
  ///
  public fixed ushort Block[1];
}

///
/// EFI_MTFTP6_DATA8_HEADER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_DATA8_HEADER
{
  ///
  /// For this packet type, OpCode = EFI_MTFTP6_OPCODE_DATA8.
  ///
  public ushort OpCode;
  ///
  /// The block number of data packet.
  ///
  public ulong Block;
  ///
  /// The content of this data packet.
  ///
  public fixed byte Data[1];
}

///
/// EFI_MTFTP6_ACK8_HEADER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_ACK8_HEADER
{
  ///
  /// For this packet type, OpCode = EFI_MTFTP6_OPCODE_ACK8.
  ///
  public ushort OpCode;
  ///
  /// The block number of the data packet that is being acknowledged.
  ///
  public fixed ulong Block[1];
}

///
/// EFI_MTFTP6_ERROR_HEADER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_ERROR_HEADER
{
  ///
  /// For this packet type, OpCode = EFI_MTFTP6_OPCODE_ERROR.
  ///
  public ushort OpCode;
  ///
  /// The error number as defined by the MTFTPv6 packet error codes.
  ///
  public ushort ErrorCode;
  ///
  /// Error message string.
  ///
  public fixed byte ErrorMessage[1];
}

///
/// EFI_MTFTP6_PACKET
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_MTFTP6_PACKET
{
  [FieldOffset(0)] public ushort OpCode; ///< Type of packets as defined by the MTFTPv6 packet opcodes.
  [FieldOffset(0)] public EFI_MTFTP6_REQ_HEADER Rrq;    ///< Read request packet header.
  [FieldOffset(0)] public EFI_MTFTP6_REQ_HEADER Wrq;    ///< write request packet header.
  [FieldOffset(0)] public EFI_MTFTP6_OACK_HEADER Oack;   ///< Option acknowledge packet header.
  [FieldOffset(0)] public EFI_MTFTP6_DATA_HEADER Data;   ///< Data packet header.
  [FieldOffset(0)] public EFI_MTFTP6_ACK_HEADER Ack;    ///< Acknowledgement packet header.
  [FieldOffset(0)] public EFI_MTFTP6_DATA8_HEADER Data8;  ///< Data packet header with big block number.
  [FieldOffset(0)] public EFI_MTFTP6_ACK8_HEADER Ack8;   ///< Acknowledgement header with big block number.
  [FieldOffset(0)] public EFI_MTFTP6_ERROR_HEADER Error;  ///< Error packet header.
}

// #pragma pack()

///
/// EFI_MTFTP6_CONFIG_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_CONFIG_DATA
{
  ///
  /// The local IP address to use. Set to zero to let the underlying IPv6
  /// driver choose a source address. If not zero it must be one of the
  /// configured IP addresses in the underlying IPv6 driver.
  ///
  public EFI_IPv6_ADDRESS StationIp;
  ///
  /// Local port number. Set to zero to use the automatically assigned port number.
  ///
  public ushort LocalPort;
  ///
  /// The IP address of the MTFTPv6 server.
  ///
  public EFI_IPv6_ADDRESS ServerIp;
  ///
  /// The initial MTFTPv6 server port number. Request packets are
  /// sent to this port. This number is almost always 69 and using zero
  /// defaults to 69.
  public ushort InitialServerPort;
  ///
  /// The number of times to transmit MTFTPv6 request packets and wait for a response.
  ///
  public ushort TryCount;
  ///
  /// The number of seconds to wait for a response after sending the MTFTPv6 request packet.
  ///
  public ushort TimeoutValue;
}

///
/// EFI_MTFTP6_MODE_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_MODE_DATA
{
  ///
  /// The configuration data of this instance.
  ///
  public EFI_MTFTP6_CONFIG_DATA ConfigData;
  ///
  /// The number of option strings in the following SupportedOptions array.
  ///
  public byte SupportedOptionCount;
  ///
  /// An array of null-terminated ASCII option strings that are recognized and supported by
  /// this EFI MTFTPv6 Protocol driver implementation. The buffer is
  /// read only to the caller and the caller should NOT free the buffer.
  ///
  public byte** SupportedOptions;
}

///
/// EFI_MTFTP_OVERRIDE_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_OVERRIDE_DATA
{
  ///
  /// IP address of the MTFTPv6 server. If set to all zero, the value that
  /// was set by the EFI_MTFTP6_PROTOCOL.Configure() function will be used.
  ///
  public EFI_IPv6_ADDRESS ServerIp;
  ///
  /// MTFTPv6 server port number. If set to zero, it will use the value
  /// that was set by the EFI_MTFTP6_PROTOCOL.Configure() function.
  ///
  public ushort ServerPort;
  ///
  /// Number of times to transmit MTFTPv6 request packets and wait
  /// for a response. If set to zero, the value that was set by
  /// theEFI_MTFTP6_PROTOCOL.Configure() function will be used.
  ///
  public ushort TryCount;
  ///
  /// Number of seconds to wait for a response after sending the
  /// MTFTPv6 request packet. If set to zero, the value that was set by
  /// the EFI_MTFTP6_PROTOCOL.Configure() function will be used.
  ///
  public ushort TimeoutValue;
}

///
/// EFI_MTFTP6_OPTION
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_OPTION
{
  public byte* OptionStr;               ///< Pointer to the null-terminated ASCII MTFTPv6 option string.
  public byte* ValueStr;                ///< Pointer to the null-terminated ASCII MTFTPv6 value string.
}



















































































[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MTFTP6_TOKEN
{
  ///
  /// The status that is returned to the caller at the end of the operation
  /// to indicate whether this operation completed successfully.
  /// Defined Status values are listed below.
  ///
  public EFI_STATUS Status;
  ///
  /// The event that will be signaled when the operation completes. If
  /// set to NULL, the corresponding function will wait until the read or
  /// write operation finishes. The type of Event must be EVT_NOTIFY_SIGNAL.
  ///
  public EFI_EVENT Event;
  ///
  /// If not NULL, the data that will be used to override the existing
  /// configure data.
  ///
  public EFI_MTFTP6_OVERRIDE_DATA* OverrideData;
  ///
  /// Pointer to the null-terminated ASCII file name string.
  ///
  public byte* Filename;
  ///
  /// Pointer to the null-terminated ASCII mode string. If NULL, octet is used.
  ///
  public byte* ModeStr;
  ///
  /// Number of option/value string pairs.
  ///
  public uint OptionCount;
  ///
  /// Pointer to an array of option/value string pairs. Ignored if
  /// OptionCount is zero. Both a remote server and this driver
  /// implementation should support these options. If one or more
  /// options are unrecognized by this implementation, it is sent to the
  /// remote server without being changed.
  ///
  public EFI_MTFTP6_OPTION* OptionList;
  ///
  /// On input, the size, in bytes, of Buffer. On output, the number
  /// of bytes transferred.
  ///
  public ulong BufferSize;
  ///
  /// Pointer to the data buffer. Data that is downloaded from the
  /// MTFTPv6 server is stored here. Data that is uploaded to the
  /// MTFTPv6 server is read from here. Ignored if BufferSize is zero.
  ///
  public void* Buffer;
  ///
  /// Pointer to the context that will be used by CheckPacket,
  /// TimeoutCallback and PacketNeeded.
  ///
  public void* Context;
  ///
  /// Pointer to the callback function to check the contents of the
  /// received packet.
  ///
  /**
    EFI_MTFTP6_TIMEOUT_CALLBACK is a callback function that the caller provides to capture the
    timeout event in the EFI_MTFTP6_PROTOCOL.ReadFile(), EFI_MTFTP6_PROTOCOL.WriteFile() or
    EFI_MTFTP6_PROTOCOL.ReadDirectory() functions.

    Whenever a timeout occurs, the EFI MTFTPv6 Protocol driver will call the EFI_MTFTP6_TIMEOUT_CALLBACK
    function to notify the caller of the timeout event. Any status code other than EFI_SUCCESS
    that is returned from this function will abort the current download process.

    @param[in] This          Pointer to the EFI_MTFTP6_PROTOCOL instance.
    @param[in] Token         The token that the caller provided in the EFI_MTFTP6_PROTOCOl.ReadFile(),
                             WriteFile() or ReadDirectory() function.





























































                                   - MtftpCofigData.ServerIp is not a valid IPv6 unicast address.




























































    @retval  EFI_ICMP_ERROR           Some other ICMP ERROR packet was received and the Packet is set to NULL.







































                                   OptionList parameters have been updated.









































                                      downloaded data in downloading process.



















































                                   - Token.Buffer and Token.PacketNeeded are both NULL.

























































                                   - Token.Buffer and Token.CheckPacket are both NULL.

























    underlying communications device fast enough to transmit and/or receive all data packets without
    missing incoming packets or dropping outgoing packets. Drivers and applications that are
    experiencing packet loss should try calling the Poll() function more often.

    @param[in]  This               Pointer to the EFI_MTFTP6_PROTOCOL instance.

    @retval  EFI_SUCCESS           Incoming or outgoing data was processed.
    @retval  EFI_NOT_STARTED       This EFI MTFTPv6 Protocol instance has not been started.
    @retval  EFI_INVALID_PARAMETER This is NULL.
    @retval  EFI_DEVICE_ERROR      An unexpected system or network error occurred.
    @retval  EFI_TIMEOUT           Data was dropped out of the transmit and/or receive queue.
                                   Consider increasing the polling rate.

  **/
  typedef
  EFI_STATUS
  (EFIAPI* EFI_MTFTP6_POLL)(
    IN EFI_MTFTP6_PROTOCOL      * This
  );

  ///
  /// The EFI_MTFTP6_PROTOCOL is designed to be used by UEFI drivers and applications to transmit
  /// and receive data files. The EFI MTFTPv6 Protocol driver uses the underlying EFI UDPv6 Protocol
  /// driver and EFI IPv6 Protocol driver.
  ///
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct EFI_MTFTP6_PROTOCOL
  {
    public EFI_MTFTP6_GET_MODE_DATA GetModeData;
    public EFI_MTFTP6_CONFIGURE Configure;
    public EFI_MTFTP6_GET_INFO GetInfo;
    public EFI_MTFTP6_PARSE_OPTIONS ParseOptions;
    public EFI_MTFTP6_READ_FILE ReadFile;
    public EFI_MTFTP6_WRITE_FILE WriteFile;
    public EFI_MTFTP6_READ_DIRECTORY ReadDirectory;
    public EFI_MTFTP6_POLL Poll;
  }

// extern EFI_GUID  gEfiMtftp6ServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiMtftp6ProtocolGuid;

// #endif
