using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI TLS Protocols as defined in UEFI 2.5.

  The EFI TLS Service Binding Protocol is used to locate EFI TLS Protocol drivers
  to create and destroy child of the driver to communicate with other host using
  TLS protocol.
  The EFI TLS Protocol provides the ability to manage TLS session.

  Copyright (c) 2016, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.5

**/

// #ifndef __EFI_TLS_PROTOCOL_H__
// #define __EFI_TLS_PROTOCOL_H__

public unsafe partial class EFI
{
  ///
  /// The EFI TLS Service Binding Protocol is used to locate EFI TLS Protocol drivers to
  /// create and destroy child of the driver to communicate with other host using TLS
  /// protocol.
  ///
  public static EFI_GUID EFI_TLS_SERVICE_BINDING_PROTOCOL_GUID = new GUID(
      0x952cb795, 0xff36, 0x48cf, 0xa2, 0x49, 0x4d, 0xf4, 0x86, 0xd6, 0xab, 0x8d);

  ///
  /// The EFI TLS protocol provides the ability to manage TLS session.
  ///
  public static EFI_GUID EFI_TLS_PROTOCOL_GUID = new GUID(
      0xca959f, 0x6cfa, 0x4db1, 0x95, 0xbc, 0xe4, 0x6c, 0x47, 0x51, 0x43, 0x90);

  // typedef struct _EFI_TLS_PROTOCOL EFI_TLS_PROTOCOL;
}

///
/// EFI_TLS_SESSION_DATA_TYPE
///
public enum EFI_TLS_SESSION_DATA_TYPE
{
  ///
  /// TLS session Version. The corresponding Data is of type EFI_TLS_VERSION.
  ///
  EfiTlsVersion,
  ///
  /// TLS session as client or as server. The corresponding Data is of
  /// EFI_TLS_CONNECTION_END.
  ///
  EfiTlsConnectionEnd,
  ///
  /// A priority list of preferred algorithms for the TLS session.
  /// The corresponding Data is a list of EFI_TLS_CIPHER.
  ///
  EfiTlsCipherList,
  ///
  /// TLS session compression method.
  /// The corresponding Data is of type EFI_TLS_COMPRESSION.
  ///
  EfiTlsCompressionMethod,
  ///
  /// TLS session extension data.
  /// The corresponding Data is a list of type EFI_TLS_EXTENSION .
  ///
  EfiTlsExtensionData,
  ///
  /// TLS session verify method.
  /// The corresponding Data is of type EFI_TLS_VERIFY.
  ///
  EfiTlsVerifyMethod,
  ///
  /// TLS session data session ID.
  /// For SetSessionData(), it is TLS session ID used for session resumption.
  /// For GetSessionData(), it is the TLS session ID used for current session.
  /// The corresponding Data is of type EFI_TLS_SESSION_ID.
  ///
  EfiTlsSessionID,
  ///
  /// TLS session data session state.
  /// The corresponding Data is of type EFI_TLS_SESSION_STATE.
  ///
  EfiTlsSessionState,
  ///
  /// TLS session data client random.
  /// The corresponding Data is of type EFI_TLS_RANDOM.
  ///
  EfiTlsClientRandom,
  ///
  /// TLS session data server random.
  /// The corresponding Data is of type EFI_TLS_RANDOM.
  ///
  EfiTlsServerRandom,
  ///
  /// TLS session data key material.
  /// The corresponding Data is of type EFI_TLS_MASTER_SECRET.
  ///
  EfiTlsKeyMaterial,
  ///
  /// TLS session hostname for validation which is used to verify whether the name
  /// within the peer certificate matches a given host name.
  /// This parameter is invalid when EfiTlsVerifyMethod is EFI_TLS_VERIFY_NONE.
  /// The corresponding Data is of type EFI_TLS_VERIFY_HOST.
  ///
  EfiTlsVerifyHost,

  EfiTlsSessionDataTypeMaximum
}

///
/// EFI_TLS_VERSION
/// Note: The TLS version definition is from SSL3.0 to the latest TLS (e.g. 1.2).
///       SSL2.0 is obsolete and should not be used.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_VERSION
{
  public byte Major;
  public byte Minor;
}

///
/// EFI_TLS_CONNECTION_END to define TLS session as client or server.
///
public enum EFI_TLS_CONNECTION_END
{
  EfiTlsClient,
  EfiTlsServer,
}

///
/// EFI_TLS_CIPHER
/// Note: The definition of EFI_TLS_CIPHER definition is from "RFC 5246, A.4.1.
///       Hello Messages". The value of EFI_TLS_CIPHER is from TLS Cipher
///       Suite Registry of IANA.
///
// #pragma pack (1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_CIPHER
{
  public byte Data1;
  public byte Data2;
}
// #pragma pack ()

///
/// EFI_TLS_COMPRESSION
/// Note: The value of EFI_TLS_COMPRESSION definition is from "RFC 3749".
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_COMPRESSION { byte Value; public static implicit operator EFI_TLS_COMPRESSION(byte value) => new EFI_TLS_COMPRESSION() { Value = value }; public static implicit operator byte(EFI_TLS_COMPRESSION value) => value.Value; }

///
/// EFI_TLS_EXTENSION
/// Note: The definition of EFI_TLS_EXTENSION if from "RFC 5246 A.4.1.
///       Hello Messages".
///
// #pragma pack (1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_EXTENSION
{
  public ushort ExtensionType;
  public ushort Length;
  public fixed byte Data[1];
}
// #pragma pack ()

///
/// EFI_TLS_VERIFY
/// Use either EFI_TLS_VERIFY_NONE or EFI_TLS_VERIFY_PEER, the last two options
/// are 'ORed' with EFI_TLS_VERIFY_PEER if they are desired.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_VERIFY { uint Value; public static implicit operator EFI_TLS_VERIFY(uint value) => new EFI_TLS_VERIFY() { Value = value }; public static implicit operator uint(EFI_TLS_VERIFY value) => value.Value; }
public unsafe partial class EFI
{
  ///
  /// No certificates will be sent or the TLS/SSL handshake will be continued regardless
  /// of the certificate verification result.
  ///
  public const ulong EFI_TLS_VERIFY_NONE = 0x0;
  ///
  /// The TLS/SSL handshake is immediately terminated with an alert message containing
  /// the reason for the certificate verification failure.
  ///
  public const ulong EFI_TLS_VERIFY_PEER = 0x1;
  ///
  /// EFI_TLS_VERIFY_FAIL_IF_NO_PEER_CERT is only meaningful in the server mode.
  /// TLS session will fail if client certificate is absent.
  ///
  public const ulong EFI_TLS_VERIFY_FAIL_IF_NO_PEER_CERT = 0x2;
  ///
  /// TLS session only verify client once, and doesn't request certificate during
  /// re-negotiation.
  ///
  public const ulong EFI_TLS_VERIFY_CLIENT_ONCE = 0x4;
}

///
/// EFI_TLS_VERIFY_HOST_FLAG
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_VERIFY_HOST_FLAG { uint Value; public static implicit operator EFI_TLS_VERIFY_HOST_FLAG(uint value) => new EFI_TLS_VERIFY_HOST_FLAG() { Value = value }; public static implicit operator uint(EFI_TLS_VERIFY_HOST_FLAG value) => value.Value; }
public unsafe partial class EFI
{
  ///
  /// There is no additional flags set for hostname validation.
  /// Wildcards are supported and they match only in the left-most label.
  ///
  public const ulong EFI_TLS_VERIFY_FLAG_NONE = 0x00;
  ///
  /// Always check the Subject Distinguished Name (DN) in the peer certificate even if the
  /// certificate contains Subject Alternative Name (SAN).
  ///
  public const ulong EFI_TLS_VERIFY_FLAG_ALWAYS_CHECK_SUBJECT = 0x01;
  ///
  /// Disable the match of all wildcards.
  ///
  public const ulong EFI_TLS_VERIFY_FLAG_NO_WILDCARDS = 0x02;
  ///
  /// Disable the "*" as wildcard in labels that have a prefix or suffix (e.g. "www*" or "*www").
  ///
  public const ulong EFI_TLS_VERIFY_FLAG_NO_PARTIAL_WILDCARDS = 0x04;
  ///
  /// Allow the "*" to match more than one labels. Otherwise, only matches a single label.
  ///
  public const ulong EFI_TLS_VERIFY_FLAG_MULTI_LABEL_WILDCARDS = 0x08;
  ///
  /// Restrict to only match direct child sub-domains which start with ".".
  /// For example, a name of ".example.com" would match "www.example.com" with this flag,
  /// but would not match "www.sub.example.com".
  ///
  public const ulong EFI_TLS_VERIFY_FLAG_SINGLE_LABEL_SUBDOMAINS = 0x10;
  ///
  /// Never check the Subject Distinguished Name (DN) even there is no
  /// Subject Alternative Name (SAN) in the certificate.
  ///
  public const ulong EFI_TLS_VERIFY_FLAG_NEVER_CHECK_SUBJECT = 0x20;
}

///
/// EFI_TLS_VERIFY_HOST
///
// #pragma pack (1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_VERIFY_HOST
{
  public EFI_TLS_VERIFY_HOST_FLAG Flags;
  public byte* HostName;
}
// #pragma pack ()

///
/// EFI_TLS_RANDOM
/// Note: The definition of EFI_TLS_RANDOM is from "RFC 5246 A.4.1.
///       Hello Messages".
///
// #pragma pack (1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_RANDOM
{
  public uint GmtUnixTime;
  public fixed byte RandomBytes[28];
}
// #pragma pack ()

///
/// EFI_TLS_MASTER_SECRET
/// Note: The definition of EFI_TLS_MASTER_SECRET is from "RFC 5246 8.1.
///       Computing the Master Secret".
///
// #pragma pack (1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_MASTER_SECRET
{
  public fixed byte Data[48];
}
// #pragma pack ()

public unsafe partial class EFI
{
  ///
  /// EFI_TLS_SESSION_ID
  /// Note: The definition of EFI_TLS_SESSION_ID is from "RFC 5246 A.4.1. Hello Messages".
  ///
  public const ulong MAX_TLS_SESSION_ID_LENGTH = 32;
  // #pragma pack (1)
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_SESSION_ID
{
  public ushort Length;
  public byte[/*MAX_TLS_SESSION_ID_LENGTH*/] Data;
}
// #pragma pack ()

///
/// EFI_TLS_SESSION_STATE
///
public enum EFI_TLS_SESSION_STATE
{
  ///
  /// When a new child of TLS protocol is created, the initial state of TLS session
  /// is EfiTlsSessionNotStarted.
  ///
  EfiTlsSessionNotStarted,
  ///
  /// The consumer can call BuildResponsePacket() with NULL to get ClientHello to
  /// start the TLS session. Then the status is EfiTlsSessionHandShaking.
  ///
  EfiTlsSessionHandShaking,
  ///
  /// During handshake, the consumer need call BuildResponsePacket() with input
  /// data from peer, then get response packet and send to peer. After handshake
  /// finish, the TLS session status becomes EfiTlsSessionDataTransferring, and
  /// consumer can use ProcessPacket() for data transferring.
  ///
  EfiTlsSessionDataTransferring,
  ///
  /// Finally, if consumer wants to active close TLS session, consumer need
  /// call SetSessionData to set TLS session state to EfiTlsSessionClosing, and
  /// call BuildResponsePacket() with NULL to get CloseNotify alert message,
  /// and sent it out.
  ///
  EfiTlsSessionClosing,
  ///
  /// If any error happen during parsing ApplicationData content type, EFI_ABORT
  /// will be returned by ProcessPacket(), and TLS session state will become
  /// EfiTlsSessionError. Then consumer need call BuildResponsePacket() with
  /// NULL to get alert message and sent it out.
  ///
  EfiTlsSessionError,

  EfiTlsSessionStateMaximum
}

///
/// EFI_TLS_FRAGMENT_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_FRAGMENT_DATA
{
  ///
  /// Length of data buffer in the fragment.
  ///
  public uint FragmentLength;
  ///
  /// Pointer to the data buffer in the fragment.
  ///
  public void* FragmentBuffer;
}

///
/// EFI_TLS_CRYPT_MODE
///
public enum EFI_TLS_CRYPT_MODE
{
  ///
  /// Encrypt data provided in the fragment buffers.
  ///
  EfiTlsEncrypt,
  ///
  /// Decrypt data provided in the fragment buffers.
  ///
  EfiTlsDecrypt,
}

// /**
//   Set TLS session data.
// 
//   The SetSessionData() function set data for a new TLS session. All session data should
//   be set before BuildResponsePacket() invoked.
// 
//   @param[in]  This                Pointer to the EFI_TLS_PROTOCOL instance.
//   @param[in]  DataType            TLS session data type.
//   @param[in]  Data                Pointer to session data.
//   @param[in]  DataSize            Total size of session data.
// 
//   @retval EFI_SUCCESS             The TLS session data is set successfully.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   This is NULL.
//                                   Data is NULL.
//                                   DataSize is 0.
//   @retval EFI_UNSUPPORTED         The DataType is unsupported.
//   @retval EFI_ACCESS_DENIED       If the DataType is one of below:
//                                   EfiTlsClientRandom
//                                   EfiTlsServerRandom
//                                   EfiTlsKeyMaterial
//   @retval EFI_NOT_READY           Current TLS session state is NOT
//                                   EfiTlsSessionStateNotStarted.
//   @retval EFI_OUT_OF_RESOURCES    Required system resources could not be allocated.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_TLS_SET_SESSION_DATA)(
//   IN EFI_TLS_PROTOCOL                *This,
//   IN EFI_TLS_SESSION_DATA_TYPE       DataType,
//   IN void                            *Data,
//   IN ulong                           DataSize
//   );

// /**
//   Get TLS session data.
// 
//   The GetSessionData() function return the TLS session information.
// 
//   @param[in]       This           Pointer to the EFI_TLS_PROTOCOL instance.
//   @param[in]       DataType       TLS session data type.
//   @param[in, out]  Data           Pointer to session data.
//   @param[in, out]  DataSize       Total size of session data. On input, it means
//                                   the size of Data buffer. On output, it means the size
//                                   of copied Data buffer if EFI_SUCCESS, and means the
//                                   size of desired Data buffer if EFI_BUFFER_TOO_SMALL.
// 
//   @retval EFI_SUCCESS             The TLS session data is got successfully.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   This is NULL.
//                                   DataSize is NULL.
//                                   Data is NULL if *DataSize is not zero.
//   @retval EFI_UNSUPPORTED         The DataType is unsupported.
//   @retval EFI_NOT_FOUND           The TLS session data is not found.
//   @retval EFI_NOT_READY           The DataType is not ready in current session state.
//   @retval EFI_BUFFER_TOO_SMALL    The buffer is too small to hold the data.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_TLS_GET_SESSION_DATA)(
//   IN EFI_TLS_PROTOCOL                *This,
//   IN EFI_TLS_SESSION_DATA_TYPE       DataType,
//   IN OUT void                        *Data   OPTIONAL,
//   IN OUT ulong                       *DataSize
//   );

// /**
//   Build response packet according to TLS state machine. This function is only valid for
//   alert, handshake and change_cipher_spec content type.
// 
//   The BuildResponsePacket() function builds TLS response packet in response to the TLS
//   request packet specified by RequestBuffer and RequestSize. If RequestBuffer is NULL and
//   RequestSize is 0, and TLS session status is EfiTlsSessionNotStarted, the TLS session
//   will be initiated and the response packet needs to be ClientHello. If RequestBuffer is
//   NULL and RequestSize is 0, and TLS session status is EfiTlsSessionClosing, the TLS
//   session will be closed and response packet needs to be CloseNotify. If RequestBuffer is
//   NULL and RequestSize is 0, and TLS session status is EfiTlsSessionError, the TLS
//   session has errors and the response packet needs to be Alert message based on error
//   type.
// 
//   @param[in]       This           Pointer to the EFI_TLS_PROTOCOL instance.
//   @param[in]       RequestBuffer  Pointer to the most recently received TLS packet. NULL
//                                   means TLS need initiate the TLS session and response
//                                   packet need to be ClientHello.
//   @param[in]       RequestSize    Packet size in bytes for the most recently received TLS
//                                   packet. 0 is only valid when RequestBuffer is NULL.
//   @param[out]      Buffer         Pointer to the buffer to hold the built packet.
//   @param[in, out]  BufferSize     Pointer to the buffer size in bytes. On input, it is
//                                   the buffer size provided by the caller. On output, it
//                                   is the buffer size in fact needed to contain the
//                                   packet.
// 
//   @retval EFI_SUCCESS             The required TLS packet is built successfully.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   This is NULL.
//                                   RequestBuffer is NULL but RequestSize is NOT 0.
//                                   RequestSize is 0 but RequestBuffer is NOT NULL.
//                                   BufferSize is NULL.
//                                   Buffer is NULL if *BufferSize is not zero.
//   @retval EFI_BUFFER_TOO_SMALL    BufferSize is too small to hold the response packet.
//   @retval EFI_NOT_READY           Current TLS session state is NOT ready to build
//                                   ResponsePacket.
//   @retval EFI_ABORTED             Something wrong build response packet.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_TLS_BUILD_RESPONSE_PACKET)(
//   IN EFI_TLS_PROTOCOL                *This,
//   IN byte                           *RequestBuffer  OPTIONAL,
//   IN ulong                           RequestSize  OPTIONAL,
//   OUT byte                          *Buffer  OPTIONAL,
//   IN OUT ulong                       *BufferSize
//   );

// /**
//   Decrypt or encrypt TLS packet during session. This function is only valid after
//   session connected and for application_data content type.
// 
//   The ProcessPacket () function process each inbound or outbound TLS APP packet.
// 
//   @param[in]       This           Pointer to the EFI_TLS_PROTOCOL instance.
//   @param[in, out]  FragmentTable  Pointer to a list of fragment. The caller will take
//                                   responsible to handle the original FragmentTable while
//                                   it may be reallocated in TLS driver. If CryptMode is
//                                   EfiTlsEncrypt, on input these fragments contain the TLS
//                                   header and plain text TLS APP payload; on output these
//                                   fragments contain the TLS header and cipher text TLS
//                                   APP payload. If CryptMode is EfiTlsDecrypt, on input
//                                   these fragments contain the TLS header and cipher text
//                                   TLS APP payload; on output these fragments contain the
//                                   TLS header and plain text TLS APP payload.
//   @param[in]       FragmentCount  Number of fragment.
//   @param[in]       CryptMode      Crypt mode.
// 
//   @retval EFI_SUCCESS             The operation completed successfully.
//   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
//                                   This is NULL.
//                                   FragmentTable is NULL.
//                                   FragmentCount is NULL.
//                                   CryptoMode is invalid.
//   @retval EFI_NOT_READY           Current TLS session state is NOT
//                                   EfiTlsSessionDataTransferring.
//   @retval EFI_ABORTED             Something wrong decryption the message. TLS session
//                                   status will become EfiTlsSessionError. The caller need
//                                   call BuildResponsePacket() to generate Error Alert
//                                   message and send it out.
//   @retval EFI_OUT_OF_RESOURCES    No enough resource to finish the operation.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_TLS_PROCESS_PACKET)(
//   IN EFI_TLS_PROTOCOL                *This,
//   IN OUT EFI_TLS_FRAGMENT_DATA       **FragmentTable,
//   IN uint                          *FragmentCount,
//   IN EFI_TLS_CRYPT_MODE              CryptMode
//   );

///
/// The EFI_TLS_PROTOCOL is used to create, destroy and manage TLS session.
/// For detail of TLS, please refer to TLS related RFC.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TLS_PROTOCOL
{
  public readonly delegate* unmanaged</* IN */EFI_TLS_PROTOCOL* /*This*/,/* IN */EFI_TLS_SESSION_DATA_TYPE /*DataType*/,/* IN */void* /*Data*/,/* IN */ulong /*DataSize*/, EFI_STATUS> /*EFI_TLS_SET_SESSION_DATA*/ SetSessionData;
  public readonly delegate* unmanaged</* IN */EFI_TLS_PROTOCOL* /*This*/,/* IN */EFI_TLS_SESSION_DATA_TYPE /*DataType*/,/* IN OUT */void* /*Data*/,/* IN OUT */ulong* /*DataSize*/, EFI_STATUS> /*EFI_TLS_GET_SESSION_DATA*/ GetSessionData;
  public readonly delegate* unmanaged</* IN */EFI_TLS_PROTOCOL* /*This*/,/* IN */byte* /*RequestBuffer*/,/* IN */ulong /*RequestSize*/,/* OUT */byte* /*Buffer*/,/* IN OUT */ulong* /*BufferSize*/, EFI_STATUS> /*EFI_TLS_BUILD_RESPONSE_PACKET*/ BuildResponsePacket;
  public readonly delegate* unmanaged</* IN */EFI_TLS_PROTOCOL* /*This*/,/* IN OUT */EFI_TLS_FRAGMENT_DATA** /*FragmentTable*/,/* IN */uint* /*FragmentCount*/,/* IN */EFI_TLS_CRYPT_MODE /*CryptMode*/, EFI_STATUS> /*EFI_TLS_PROCESS_PACKET*/ ProcessPacket;
}

// extern EFI_GUID  gEfiTlsServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiTlsProtocolGuid;

// #endif // __EFI_TLS_PROTOCOL_H__
