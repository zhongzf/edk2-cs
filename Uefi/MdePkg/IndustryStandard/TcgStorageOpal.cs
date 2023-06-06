using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Opal Specification defined values and structures.

  (TCG Storage Architecture Core Specification, Version 2.01, Revision 1.00,
  https://trustedcomputinggroup.org/tcg-storage-architecture-core-specification/

  Storage Work Group Storage Security Subsystem Class: Pyrite, Version 1.00 Final, Revision 1.00,
  https://trustedcomputinggroup.org/tcg-storage-security-subsystem-class-pyrite/

  Storage Work Group Storage Security Subsystem Class: Opal, Version 2.01 Final, Revision 1.00,
  https://trustedcomputinggroup.org/storage-work-group-storage-security-subsystem-class-opal/

  TCG Storage Security Subsystem Class: Opalite Version 1.00 Revision 1.00,
  https://trustedcomputinggroup.org/tcg-storage-security-subsystem-class-opalite/)

  Check http://trustedcomputinggroup.org for latest specification updates.

Copyright (c) 2016 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _TCG_STORAGE_OPAL_H_
// #define _TCG_STORAGE_OPAL_H_

// #include <IndustryStandard/TcgStorageCore.h>

public unsafe partial class EFI
{
  //public const ulong OPAL_UID_ADMIN_SP = TCG_TO_UID(0x00, 0x00, 0x02, 0x05, 0x00, 0x00, 0x00, 0x01);
  //public const ulong OPAL_UID_ADMIN_SP_C_PIN_MSID = TCG_TO_UID(0x00, 0x00, 0x00, 0x0B, 0x00, 0x00, 0x84, 0x02);
  //public const ulong OPAL_UID_ADMIN_SP_C_PIN_SID = TCG_TO_UID(0x00, 0x00, 0x00, 0x0B, 0x00, 0x00, 0x00, 0x01);
  //public const ulong OPAL_UID_LOCKING_SP = TCG_TO_UID(0x00, 0x00, 0x02, 0x05, 0x00, 0x00, 0x00, 0x02);

  //// ADMIN_SP
  //// Authorities
  //public const ulong OPAL_ADMIN_SP_ANYBODY_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x01);
  //public const ulong OPAL_ADMIN_SP_ADMINS_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x02);
  //public const ulong OPAL_ADMIN_SP_MAKERS_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x03);
  //public const ulong OPAL_ADMIN_SP_SID_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x06);
  //public const ulong OPAL_ADMIN_SP_ADMIN1_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x02, 0x01);
  //public const ulong OPAL_ADMIN_SP_PSID_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x01, 0xFF, 0x01);

  //public const ulong OPAL_ADMIN_SP_ACTIVATE_METHOD = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x02, 0x03);
  //public const ulong OPAL_ADMIN_SP_REVERT_METHOD = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x02, 0x02);

  //// ADMIN_SP
  //// Data Removal mechanism
  //public const ulong OPAL_UID_ADMIN_SP_DATA_REMOVAL_MECHANISM = TCG_TO_UID(0x00, 0x00, 0x11, 0x01, 0x00, 0x00, 0x00, 0x01);

  //// LOCKING SP
  //// Authorities
  //public const ulong OPAL_LOCKING_SP_ANYBODY_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x01);
  //public const ulong OPAL_LOCKING_SP_ADMINS_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x02);
  //public const ulong OPAL_LOCKING_SP_ADMIN1_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x01, 0x00, 0x01);
  //public const ulong OPAL_LOCKING_SP_USERS_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x03, 0x00, 0x00);
  //public const ulong OPAL_LOCKING_SP_USER1_AUTHORITY = TCG_TO_UID(0x00, 0x00, 0x00, 0x09, 0x00, 0x03, 0x00, 0x01);

  //public const ulong OPAL_LOCKING_SP_REVERTSP_METHOD = TCG_TO_UID(0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x11);

  //// C_PIN Table Rows
  //public const ulong OPAL_LOCKING_SP_C_PIN_ADMIN1 = TCG_TO_UID(0x00, 0x00, 0x00, 0x0B, 0x00, 0x01, 0x00, 0x01);
  //public const ulong OPAL_LOCKING_SP_C_PIN_USER1 = TCG_TO_UID(0x00, 0x00, 0x00, 0x0B, 0x00, 0x03, 0x00, 0x01);

  //// Locking Table
  //public const ulong OPAL_LOCKING_SP_LOCKING_GLOBALRANGE = TCG_TO_UID(0x00, 0x00, 0x08, 0x02, 0x00, 0x00, 0x00, 0x01);
  //public const ulong OPAL_LOCKING_SP_LOCKING_RANGE1 = TCG_TO_UID(0x00, 0x00, 0x08, 0x02, 0x00, 0x03, 0x00, 0x01);

  //// LOCKING SP ACE Table Preconfiguration
  //public const ulong OPAL_LOCKING_SP_ACE_LOCKING_GLOBALRANGE_GET_ALL = TCG_TO_UID(0x00, 0x00, 0x00, 0x08, 0x00, 0x03, 0xD0, 0x00);
  //public const ulong OPAL_LOCKING_SP_ACE_LOCKING_GLOBALRANGE_SET_RDLOCKED = TCG_TO_UID(0x00, 0x00, 0x00, 0x08, 0x00, 0x03, 0xE0, 0x00);
  //public const ulong OPAL_LOCKING_SP_ACE_LOCKING_GLOBALRANGE_SET_WRLOCKED = TCG_TO_UID(0x00, 0x00, 0x00, 0x08, 0x00, 0x03, 0xE8, 0x00);

  //public const ulong OPAL_LOCKING_SP_ACE_K_AES_256_GLOBALRANGE_GENKEY = TCG_TO_UID(0x00, 0x00, 0x00, 0x08, 0x00, 0x03, 0xB8, 0x00);
  //public const ulong OPAL_LOCKING_SP_ACE_K_AES_128_GLOBALRANGE_GENKEY = TCG_TO_UID(0x00, 0x00, 0x00, 0x08, 0x00, 0x03, 0xB0, 0x00);

  //// LOCKING SP LockingInfo Table Preconfiguration
  //public const ulong OPAL_LOCKING_SP_LOCKING_INFO = TCG_TO_UID(0x00, 0x00, 0x08, 0x01, 0x00, 0x00, 0x00, 0x01);

  public const ulong OPAL_LOCKING_SP_LOCKINGINFO_ALIGNMENTREQUIRED_COL = 0x7;
  public const ulong OPAL_LOCKING_SP_LOCKINGINFO_LOGICALBLOCKSIZE_COL = 0x8;
  public const ulong OPAL_LOCKING_SP_LOCKINGINFO_ALIGNMENTGRANULARITY_COL = 0x9;
  public const ulong OPAL_LOCKING_SP_LOCKINGINFO_LOWESTALIGNEDLBA_COL = 0xA;

  //// K_AES_256 Table Preconfiguration
  //public const ulong OPAL_LOCKING_SP_K_AES_256_GLOBALRANGE_KEY = TCG_TO_UID(0x00, 0x00, 0x08, 0x06, 0x00, 0x00, 0x00, 0x01);

  //// K_AES_128 Table Preconfiguration
  //public const ulong OPAL_LOCKING_SP_K_AES_128_GLOBALRANGE_KEY = TCG_TO_UID(0x00, 0x00, 0x08, 0x05, 0x00, 0x00, 0x00, 0x01);

  // Minimum Properties that an Opal Compliant SD Shall support
  public const ulong OPAL_MIN_MAX_COM_PACKET_SIZE = 2048;
  public const ulong OPAL_MIN_MAX_REPONSE_COM_PACKET_SIZE = 2048;
  public const ulong OPAL_MIN_MAX_PACKET_SIZE = 2028;
  public const ulong OPAL_MIN_MAX_IND_TOKEN_SIZE = 1992;
  public const ulong OPAL_MIN_MAX_PACKETS = 1;
  public const ulong OPAL_MIN_MAX_SUBPACKETS = 1;
  public const ulong OPAL_MIN_MAX_METHODS = 1;
  public const ulong OPAL_MIN_MAX_SESSIONS = 1;
  public const ulong OPAL_MIN_MAX_AUTHENTICATIONS = 2;
  public const ulong OPAL_MIN_MAX_TRANSACTION_LIMIT = 1;

  public const ulong OPAL_ADMIN_SP_PIN_COL = 3;
  public const ulong OPAL_LOCKING_SP_C_PIN_TRYLIMIT_COL = 5;
  public const ulong OPAL_RANDOM_METHOD_MAX_COUNT_SIZE = 32;

  // Data Removal Mechanism column.
  public const ulong OPAL_ADMIN_SP_ACTIVE_DATA_REMOVAL_MECHANISM_COL = 1;
}

//
// Supported Data Removal Mechanism.
// Detail see Pyrite SSC v2 spec.
//
public enum SUPPORTED_DATA_REMOVAL_MECHANISM
{
  OverwriteDataErase = 0,
  BlockErase,
  CryptoErase,
  Unmap,
  ResetWritePointers,
  VendorSpecificErase,
  ResearvedMechanism
}

// #pragma pack(1)

[StructLayout(LayoutKind.Sequential)]
public unsafe struct OPAL_GEOMETRY_REPORTING_FEATURE
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public fixed byte Reserved[8];
  public uint LogicalBlockSizeBE;
  public ulong AlignmentGranularityBE;
  public ulong LowestAlignedLBABE;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct OPAL_SINGLE_USER_MODE_FEATURE
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public uint NumLockingObjectsSupportedBE;
  public byte Any; // = 1;
  public byte All; // = 1;
  public byte Policy; // = 1;
  public byte Reserved; // = 5;
  public fixed byte Reserved2[7];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct OPAL_DATASTORE_TABLE_FEATURE
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public ushort Reserved;
  public ushort MaxNumTablesBE;
  public uint MaxTotalSizeBE;
  public uint SizeAlignmentBE;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct OPAL_SSCV1_FEATURE_DESCRIPTOR
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public ushort BaseComdIdBE;
  public ushort NumComIdsBE;
  public byte RangeCrossing; // = 1;
  public byte Reserved; // = 7;
  public fixed byte Future[11];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct OPAL_SSCV2_FEATURE_DESCRIPTOR
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public ushort BaseComdIdBE;
  public ushort NumComIdsBE;
  public byte Reserved;
  public ushort NumLockingSpAdminAuthoritiesSupportedBE;
  public ushort NumLockingSpUserAuthoritiesSupportedBE;
  public byte InitialCPINSIDPIN;
  public byte CPINSIDPINRevertBehavior;
  public fixed byte Future[5];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct OPAL_SSCLITE_FEATURE_DESCRIPTOR
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public ushort BaseComdIdBE;
  public ushort NumComIdsBE;
  public fixed byte Reserved[5];
  public byte InitialCPINSIDPIN;
  public byte CPINSIDPINRevertBehavior;
  public fixed byte Future[5];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PYRITE_SSC_FEATURE_DESCRIPTOR
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public ushort BaseComdIdBE;
  public ushort NumComIdsBE;
  public fixed byte Reserved[5];
  public byte InitialCPINSIDPIN;
  public byte CPINSIDPINRevertBehavior;
  public fixed byte Future[5];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PYRITE_SSCV2_FEATURE_DESCRIPTOR
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public ushort BaseComdIdBE;
  public ushort NumComIdsBE;
  public fixed byte Reserved[5];
  public byte InitialCPINSIDPIN;
  public byte CPINSIDPINRevertBehavior;
  public fixed byte Future[5];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct DATA_REMOVAL_FEATURE_DESCRIPTOR
{
  public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER Header;
  public byte Reserved;
  public byte OperationProcessing; // = 1;
  public byte Reserved2; // = 7;
  public byte RemovalMechanism;
  public byte FormatBit0; // = 1; // Data Removal Time Format for Bit 0
  public byte FormatBit1; // = 1; // Data Removal Time Format for Bit 1
  public byte FormatBit2; // = 1; // Data Removal Time Format for Bit 2
  public byte FormatBit3; // = 1; // Data Removal Time Format for Bit 3
  public byte FormatBit4; // = 1; // Data Removal Time Format for Bit 4
  public byte FormatBit5; // = 1; // Data Removal Time Format for Bit 5
  public byte Reserved3; // = 2;
  public ushort TimeBit0;      // Data Removal Time for Supported Data Removal Mechanism Bit 0
  public ushort TimeBit1;      // Data Removal Time for Supported Data Removal Mechanism Bit 1
  public ushort TimeBit2;      // Data Removal Time for Supported Data Removal Mechanism Bit 2
  public ushort TimeBit3;      // Data Removal Time for Supported Data Removal Mechanism Bit 3
  public ushort TimeBit4;      // Data Removal Time for Supported Data Removal Mechanism Bit 4
  public ushort TimeBit5;      // Data Removal Time for Supported Data Removal Mechanism Bit 5
  public fixed byte Future[16];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct OPAL_LEVEL0_FEATURE_DESCRIPTOR
{
  [FieldOffset(0)] public TCG_LEVEL0_FEATURE_DESCRIPTOR_HEADER CommonHeader;
  [FieldOffset(0)] public TCG_TPER_FEATURE_DESCRIPTOR Tper;
  [FieldOffset(0)] public TCG_LOCKING_FEATURE_DESCRIPTOR Locking;
  [FieldOffset(0)] public OPAL_GEOMETRY_REPORTING_FEATURE Geometry;
  [FieldOffset(0)] public OPAL_SINGLE_USER_MODE_FEATURE SingleUser;
  [FieldOffset(0)] public OPAL_DATASTORE_TABLE_FEATURE DataStore;
  [FieldOffset(0)] public OPAL_SSCV1_FEATURE_DESCRIPTOR OpalSscV1;
  [FieldOffset(0)] public OPAL_SSCV2_FEATURE_DESCRIPTOR OpalSscV2;
  [FieldOffset(0)] public OPAL_SSCLITE_FEATURE_DESCRIPTOR OpalSscLite;
  [FieldOffset(0)] public PYRITE_SSC_FEATURE_DESCRIPTOR PyriteSsc;
  [FieldOffset(0)] public PYRITE_SSCV2_FEATURE_DESCRIPTOR PyriteSscV2;
  [FieldOffset(0)] public TCG_BLOCK_SID_FEATURE_DESCRIPTOR BlockSid;
  [FieldOffset(0)] public DATA_REMOVAL_FEATURE_DESCRIPTOR DataRemoval;
}

// #pragma pack()

// #endif // _OPAL_H_
