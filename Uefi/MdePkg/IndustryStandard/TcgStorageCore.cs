using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  TCG defined values and structures.

  (TCG Storage Architecture Core Specification, Version 2.01, Revision 1.00,
  https://trustedcomputinggroup.org/tcg-storage-architecture-core-specification/)

  Check http://trustedcomputinggroup.org for latest specification updates.

Copyright (c) 2016 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _TCG_STORAGE_CORE_H_
// #define _TCG_STORAGE_CORE_H_

// #include <Base.h>

// #pragma pack(1)

/// UID in host native byte order
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_UID { ulong Value; public static implicit operator TCG_UID(ulong value) => new TCG_UID() { Value = value }; public static implicit operator ulong(TCG_UID value) => value.Value; }

//public unsafe partial class EFI
//{
//  public const ulong TCG_TO_UID = (b0, b1, b2, b3, b4, b5, b6, b7)(TCG_UID)(\;
//  (ulong) (b0)         | \
//  ((ulong)(b1) << 8)  | \
//  ((ulong)(b2) << 16) | \
//  ((ulong)(b3) << 24) | \
//  ((ulong)(b4) << 32) | \
//  ((ulong)(b5) << 40) | \
//  ((ulong)(b6) << 48) | \
//  ((ulong)(b7) << 56))
//}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_COM_PACKET
{
  public uint ReservedBE;
  public ushort ComIDBE;
  public ushort ComIDExtensionBE;
  public uint OutstandingDataBE;
  public uint MinTransferBE;
  public uint LengthBE;
  //public fixed byte Payload[0];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_PACKET
{
  public uint TperSessionNumberBE;
  public uint HostSessionNumberBE;
  public uint SequenceNumberBE;
  public ushort ReservedBE;
  public ushort AckTypeBE;
  public uint AcknowledgementBE;
  public uint LengthBE;
  //public fixed byte Payload[0];
}

public unsafe partial class EFI
{
  public const ulong TCG_SUBPACKET_ALIGNMENT = 4; //  4-byte alignment per spec
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_SUB_PACKET
{
  public fixed byte ReservedBE[6];
  public ushort KindBE;
  public uint LengthBE;
  //public fixed byte Payload[0];
}

public unsafe partial class EFI
{
  public const ulong SUBPACKET_KIND_DATA = 0x0000;
  public const ulong SUBPACKET_KIND_CREDIT_CONTROL = 0x8001;
}

public unsafe partial class EFI
{
  public const ulong TCG_ATOM_TYPE_INTEGER = 0x0;
  public const ulong TCG_ATOM_TYPE_BYTE = 0x1;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_TINY_ATOM_BITS
{
  public byte Data = 6;
  public byte Sign = 1;
  public byte IsZero = 1;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct TCG_SIMPLE_TOKEN_TINY_ATOM
{
  [FieldOffset(0)] public byte Raw;
  [FieldOffset(0)] public TCG_TINY_ATOM_BITS TinyAtomBits;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_SHORT_ATOM_BITS
{
  public byte Length = 4;
  public byte SignOrCont = 1;
  public byte ByteOrInt = 1;
  public byte IsZero = 1;
  public byte IsOne = 1;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct TCG_SIMPLE_TOKEN_SHORT_ATOM
{
  [FieldOffset(0)] public byte RawHeader;
  [FieldOffset(0)] public TCG_SHORT_ATOM_BITS ShortAtomBits;
}

public unsafe partial class EFI
{
  public const ulong TCG_MEDIUM_ATOM_LENGTH_HIGH_SHIFT = 0x8;
  public const ulong TCG_MEDIUM_ATOM_LENGTH_HIGH_MASK = 0x7;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_MEDIUM_ATOM_BITS
{
  public byte LengthHigh = 3;
  public byte SignOrCont = 1;
  public byte ByteOrInt = 1;
  public byte IsZero = 1;
  public byte IsOne1 = 1;
  public byte IsOne2 = 1;
  public byte LengthLow;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct TCG_SIMPLE_TOKEN_MEDIUM_ATOM
{
  [FieldOffset(0)] public ushort RawHeader;
  [FieldOffset(0)] public TCG_MEDIUM_ATOM_BITS MediumAtomBits;
}

public unsafe partial class EFI
{
  public const ulong TCG_LONG_ATOM_LENGTH_HIGH_SHIFT = 16;
  public const ulong TCG_LONG_ATOM_LENGTH_MID_SHIFT = 8;
}

//  typedef struct {
//  byte SignOrCont : 1;
//  byte ByteOrInt  : 1;
//  byte Reserved   : 2;
//  byte IsZero     : 1;
//  byte IsOne1     : 1;
//  byte IsOne2     : 1;
//  byte IsOne3     : 1;
//  byte LengthHigh;
//  byte LengthMid;
//  byte LengthLow;
//}
//TCG_LONG_ATOM_BITS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct TCG_SIMPLE_TOKEN_LONG_ATOM
{
  [FieldOffset(0)] public uint RawHeader;
  [FieldOffset(0)] public TCG_LONG_ATOM_BITS LongAtomBits;
}

// TCG Core Spec v2 - Table 04 - Token Types
public enum TCG_TOKEN_TYPE
{
  TcgTokenTypeReserved,
  TcgTokenTypeTinyAtom,
  TcgTokenTypeShortAtom,
  TcgTokenTypeMediumAtom,
  TcgTokenTypeLongAtom,
  TcgTokenTypeStartList,
  TcgTokenTypeEndList,
  TcgTokenTypeStartName,
  TcgTokenTypeEndName,
  TcgTokenTypeCall,
  TcgTokenTypeEndOfData,
  TcgTokenTypeEndOfSession,
  TcgTokenTypeStartTransaction,
  TcgTokenTypeEndTransaction,
  TcgTokenTypeEmptyAtom,
}

// #pragma pack()

public unsafe partial class EFI
{
  public const ulong TCG_TOKEN_SHORTATOM_MAX_BYTE_SIZE = 0x0F;
  public const ulong TCG_TOKEN_MEDIUMATOM_MAX_BYTE_SIZE = 0x7FF;
  public const ulong TCG_TOKEN_LONGATOM_MAX_BYTE_SIZE = 0xFFFFFF;

  public const ulong TCG_TOKEN_TINYATOM_UNSIGNED_MAX_VALUE = 0x3F;
  public const long TCG_TOKEN_TINYATOM_SIGNED_MAX_VALUE = 0x1F;
  public const long TCG_TOKEN_TINYATOM_SIGNED_MIN_VALUE = -32;

  // TOKEN TYPES
  public const ulong TCG_TOKEN_TINYATOM = 0x00;
  public const ulong TCG_TOKEN_TINYSIGNEDATOM = 0x40;
  public const ulong TCG_TOKEN_SHORTATOM = 0x80;
  public const ulong TCG_TOKEN_SHORTSIGNEDATOM = 0x90;
  public const ulong TCG_TOKEN_SHORTBYTESATOM = 0xA0;
  public const ulong TCG_TOKEN_MEDIUMATOM = 0xC0;
  public const ulong TCG_TOKEN_MEDIUMSIGNEDATOM = 0xC8;
  public const ulong TCG_TOKEN_MEDIUMBYTESATOM = 0xD0;
  public const ulong TCG_TOKEN_LONGATOM = 0xE0;
  public const ulong TCG_TOKEN_LONGSIGNEDATOM = 0xE1;
  public const ulong TCG_TOKEN_LONGBYTESATOM = 0xE2;
  public const ulong TCG_TOKEN_STARTLIST = 0xF0;
  public const ulong TCG_TOKEN_ENDLIST = 0xF1;
  public const ulong TCG_TOKEN_STARTNAME = 0xF2;
  public const ulong TCG_TOKEN_ENDNAME = 0xF3;
  // 0xF4 - 0xF7 TCG Reserved
  public const ulong TCG_TOKEN_CALL = 0xF8;
  public const ulong TCG_TOKEN_ENDDATA = 0xF9;
  public const ulong TCG_TOKEN_ENDSESSION = 0xFA;
  public const ulong TCG_TOKEN_STARTTRANSACTION = 0xFB;
  public const ulong TCG_TOKEN_ENDTRANSACTION = 0xFC;
  // 0xFD - 0xFE TCG Reserved
  public const ulong TCG_TOKEN_EMPTY = 0xFF;

  // CELLBLOCK reserved Names
  public const ulong TCG_CELL_BLOCK_TABLE_NAME = (byte)0x00;
  public const ulong TCG_CELL_BLOCK_START_ROW_NAME = (byte)0x01;
  public const ulong TCG_CELL_BLOCK_END_ROW_NAME = (byte)0x02;
  public const ulong TCG_CELL_BLOCK_START_COLUMN_NAME = (byte)0x03;
  public const ulong TCG_CELL_BLOCK_END_COLUMN_NAME = (byte)0x04;

  // METHOD STATUS CODES
  public const ulong TCG_METHOD_STATUS_CODE_SUCCESS = 0x00;
  public const ulong TCG_METHOD_STATUS_CODE_NOT_AUTHORIZED = 0x01;
  public const ulong TCG_METHOD_STATUS_CODE_OBSOLETE = 0x02;
  public const ulong TCG_METHOD_STATUS_CODE_SP_BUSY = 0x03;
  public const ulong TCG_METHOD_STATUS_CODE_SP_FAILED = 0x04;
  public const ulong TCG_METHOD_STATUS_CODE_SP_DISABLED = 0x05;
  public const ulong TCG_METHOD_STATUS_CODE_SP_FROZEN = 0x06;
  public const ulong TCG_METHOD_STATUS_CODE_NO_SESSIONS_AVAILABLE = 0x07;
  public const ulong TCG_METHOD_STATUS_CODE_UNIQUENESS_CONFLICT = 0x08;
  public const ulong TCG_METHOD_STATUS_CODE_INSUFFICIENT_SPACE = 0x09;
  public const ulong TCG_METHOD_STATUS_CODE_INSUFFICIENT_ROWS = 0x0A;
  public const ulong TCG_METHOD_STATUS_CODE_INVALID_PARAMETER = 0x0C;
  public const ulong TCG_METHOD_STATUS_CODE_OBSOLETE2 = 0x0D;
  public const ulong TCG_METHOD_STATUS_CODE_OBSOLETE3 = 0x0E;
  public const ulong TCG_METHOD_STATUS_CODE_TPER_MALFUNCTION = 0x0F;
  public const ulong TCG_METHOD_STATUS_CODE_TRANSACTION_FAILURE = 0x10;
  public const ulong TCG_METHOD_STATUS_CODE_RESPONSE_OVERFLOW = 0x11;
  public const ulong TCG_METHOD_STATUS_CODE_AUTHORITY_LOCKED_OUT = 0x12;
  public const ulong TCG_METHOD_STATUS_CODE_FAIL = 0x3F;

  // Feature Codes
  public const ulong TCG_FEATURE_INVALID = (ushort)0x0000;
  public const ulong TCG_FEATURE_TPER = (ushort)0x0001;
  public const ulong TCG_FEATURE_LOCKING = (ushort)0x0002;
  public const ulong TCG_FEATURE_GEOMETRY_REPORTING = (ushort)0x0003;
  public const ulong TCG_FEATURE_SINGLE_USER_MODE = (ushort)0x0201;
  public const ulong TCG_FEATURE_DATASTORE_TABLE = (ushort)0x0202;
  public const ulong TCG_FEATURE_OPAL_SSC_V1_0_0 = (ushort)0x0200;
  public const ulong TCG_FEATURE_OPAL_SSC_V2_0_0 = (ushort)0x0203;
  public const ulong TCG_FEATURE_OPAL_SSC_LITE = (ushort)0x0301;
  public const ulong TCG_FEATURE_PYRITE_SSC = (ushort)0x0302;
  public const ulong TCG_FEATURE_PYRITE_SSC_V2_0_0 = (ushort)0x0303;
  public const ulong TCG_FEATURE_BLOCK_SID = (ushort)0x0402;
  public const ulong TCG_FEATURE_DATA_REMOVAL = (ushort)0x0404;

  // ACE Expression values
  public const ulong TCG_ACE_EXPRESSION_AND = 0x0;
  public const ulong TCG_ACE_EXPRESSION_OR = 0x1;

  /****************************************************************************
  TRUSTED RECEIVE - supported security protocols list (SP_Specific = 0000h)
  ATA 8 Rev6a Table 68 7.57.6.2
  ****************************************************************************/
  // Security Protocol IDs
  public const ulong TCG_SECURITY_PROTOCOL_INFO = 0x00;
  public const ulong TCG_OPAL_SECURITY_PROTOCOL_1 = 0x01;
  public const ulong TCG_OPAL_SECURITY_PROTOCOL_2 = 0x02;
  public const ulong TCG_SECURITY_PROTOCOL_TCG3 = 0x03;
  public const ulong TCG_SECURITY_PROTOCOL_TCG4 = 0x04;
  public const ulong TCG_SECURITY_PROTOCOL_TCG5 = 0x05;
  public const ulong TCG_SECURITY_PROTOCOL_TCG6 = 0x06;
  public const ulong TCG_SECURITY_PROTOCOL_CBCS = 0x07;
  public const ulong TCG_SECURITY_PROTOCOL_TAPE_DATA = 0x20;
  public const ulong TCG_SECURITY_PROTOCOL_DATA_ENCRYPT_CONFIG = 0x21;
  public const ulong TCG_SECURITY_PROTOCOL_SA_CREATION_CAPS = 0x40;
  public const ulong TCG_SECURITY_PROTOCOL_IKEV2_SCSI = 0x41;
  public const ulong TCG_SECURITY_PROTOCOL_JEDEC_UFS = 0xEC;
  public const ulong TCG_SECURITY_PROTOCOL_SDCARD_SECURITY = 0xED;
  public const ulong TCG_SECURITY_PROTOCOL_IEEE_1667 = 0xEE;
  public const ulong TCG_SECURITY_PROTOCOL_ATA_DEVICE_SERVER_PASS = 0xEF;

  // Security Protocol Specific IDs
  public const ulong TCG_SP_SPECIFIC_PROTOCOL_LIST = 0x0000;
  public const ulong TCG_SP_SPECIFIC_PROTOCOL_LEVEL0_DISCOVERY = 0x0001;

  public const ulong TCG_RESERVED_COMID = 0x0000;

  // Defined in TCG Storage Feature Set:Block SID Authentication spec,
  // ComId used for BlockSid command is hardcode 0x0005.
  public const ulong TCG_BLOCKSID_COMID = 0x0005;
}

// #pragma pack(1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_SUPPORTED_SECURITY_PROTOCOLS
{
  public fixed byte Reserved[6];
  public ushort ListLength_BE; // 6 - 7
  public fixed byte List[504];     // 8...
}

// Level 0 Discovery
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_LEVEL0_DISCOVERY_HEADER
{
  public uint LengthBE; // number of valid bytes in discovery response, not including length field
  public ushort VerMajorBE;
  public ushort VerMinorBE;
  public fixed byte Reserved[8];
  public fixed byte VendorUnique[32];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER
{
  public ushort FeatureCode_BE;
  public byte Reserved = 4;
  public byte Version = 4;
  public byte Length;  // length of feature dependent data in bytes
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_LOCKING_FEATURE_DESCRIPTOR
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public byte LockingSupported = 1;
  public byte LockingEnabled = 1; // means the locking security provider (SP) is enabled
  public byte Locked = 1; // means at least 1 locking range is enabled
  public byte MediaEncryption = 1;
  public byte MbrEnabled = 1;
  public byte MbrDone = 1;
  public byte Reserved = 2;
  public fixed byte Reserved515[11];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_BLOCK_SID_FEATURE_DESCRIPTOR
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public byte SIDValueState = 1;
  public byte SIDBlockedState = 1;
  public byte Reserved4 = 6;
  public byte HardwareReset = 1;
  public byte Reserved5 = 7;
  public fixed byte Reserved615[10];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TCG_TPER_FEATURE_DESCRIPTOR
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public byte SyncSupported = 1;
  public byte AsyncSupported = 1;
  public byte AckNakSupported = 1;
  public byte BufferMgmtSupported = 1;
  public byte StreamingSupported = 1;
  public byte Reserved4b5 = 1;
  public byte ComIdMgmtSupported = 1;
  public byte Reserved4b7 = 1;
  public fixed byte Reserved515[11];
}

// #pragma pack()

public unsafe partial class EFI
{
  //// Special Purpose UIDs
  //public const ulong TCG_UID_NULL = TCG_TO_UID(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
  //public const ulong TCG_UID_THIS_SP = TCG_TO_UID(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01);
  //public const ulong TCG_UID_SMUID = TCG_TO_UID(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF);

  //// Session Manager Method UIDS
  //public const ulong TCG_UID_SM_PROPERTIES = TCG_TO_UID(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x01);
  //public const ulong TCG_UID_SM_START_SESSION = TCG_TO_UID(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x02);
  //public const ulong TCG_UID_SM_SYNC_SESSION = TCG_TO_UID(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x03);
  //public const ulong TCG_UID_SM_START_TRUSTED_SESSION = TCG_TO_UID(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x04);
  //public const ulong TCG_UID_SM_SYNC_TRUSTED_SESSION = TCG_TO_UID(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x05);
  //public const ulong TCG_UID_SM_CLOSE_SESSION = TCG_TO_UID(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x06);

  //// MethodID UIDs
  //public const ulong TCG_UID_METHOD_DELETE_SP = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x01);
  //public const ulong TCG_UID_METHOD_CREATE_TABLE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x02);
  //public const ulong TCG_UID_METHOD_DELETE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x03);
  //public const ulong TCG_UID_METHOD_CREATE_ROW = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x04);
  //public const ulong TCG_UID_METHOD_DELETE_ROW = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x05);
  //public const ulong TCG_UID_METHOD_NEXT = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x08);
  //public const ulong TCG_UID_METHOD_GET_FREE_SPACE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x09);
  //public const ulong TCG_UID_METHOD_GET_FREE_ROWS = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x0A);
  //public const ulong TCG_UID_METHOD_DELETE_METHOD = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x0B);
  //public const ulong TCG_UID_METHOD_GET_ACL = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x0D);
  //public const ulong TCG_UID_METHOD_ADD_ACE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x0E);
  //public const ulong TCG_UID_METHOD_REMOVE_ACE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x0F);
  //public const ulong TCG_UID_METHOD_GEN_KEY = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x10);
  //public const ulong TCG_UID_METHOD_GET_PACKAGE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x12);
  //public const ulong TCG_UID_METHOD_SET_PACKAGE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x13);
  //public const ulong TCG_UID_METHOD_GET = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x16);
  //public const ulong TCG_UID_METHOD_SET = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x17);
  //public const ulong TCG_UID_METHOD_AUTHENTICATE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x1C);
  //public const ulong TCG_UID_METHOD_ISSUE_SP = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x02, 0x01);
  //public const ulong TCG_UID_METHOD_GET_CLOCK = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x04, 0x01);
  //public const ulong TCG_UID_METHOD_RESET_CLOCK = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x04, 0x02);
  //public const ulong TCG_UID_METHOD_SET_CLOCK_HIGH = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x04, 0x03);
  //public const ulong TCG_UID_METHOD_SET_LAG_HIGH = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x04, 0x04);
  //public const ulong TCG_UID_METHOD_SET_CLOCK_LOW = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x04, 0x05);
  //public const ulong TCG_UID_METHOD_SET_LAG_LOW = TCG_TO_UID(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x06);
  //public const ulong TCG_UID_METHOD_INCREMENT_COUNTER = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x04, 0x07);
  //public const ulong TCG_UID_METHOD_RANDOM = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x01);
  //public const ulong TCG_UID_METHOD_SALT = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x02);
  //public const ulong TCG_UID_METHOD_DECRYPT_INIT = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x03);
  //public const ulong TCG_UID_METHOD_DECRYPT = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x04);
  //public const ulong TCG_UID_METHOD_DECRYPT_FINALIZE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x05);
  //public const ulong TCG_UID_METHOD_ENCRYPT_INIT = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x06);
  //public const ulong TCG_UID_METHOD_ENCRYPT = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x07);
  //public const ulong TCG_UID_METHOD_ENCRYPT_FINALIZE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x08);
  //public const ulong TCG_UID_METHOD_HMAC_INIT = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x09);
  //public const ulong TCG_UID_METHOD_HMAC = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x0A);
  //public const ulong TCG_UID_METHOD_HMAC_FINALIZE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x0B);
  //public const ulong TCG_UID_METHOD_HASH_INIT = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x0C);
  //public const ulong TCG_UID_METHOD_HASH = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x0D);
  //public const ulong TCG_UID_METHOD_HASH_FINALIZE = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x0E);
  //public const ulong TCG_UID_METHOD_SIGN = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x0F);
  //public const ulong TCG_UID_METHOD_VERIFY = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x10);
  //public const ulong TCG_UID_METHOD_XOR = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x06, 0x11);
  //public const ulong TCG_UID_METHOD_ADD_LOG = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x0A, 0x01);
  //public const ulong TCG_UID_METHOD_CREATE_LOG = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x0A, 0x02);
  //public const ulong TCG_UID_METHOD_CLEAR_LOG = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x0A, 0x03);
  //public const ulong TCG_UID_METHOD_FLUSH_LOG = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x0A, 0x04);
}

// #endif // TCG_H_
