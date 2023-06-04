using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Support for SCSI-2 standard

  Copyright (c) 2006 - 2020, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SCSI_H__
// #define __SCSI_H__

public unsafe partial class EFI
{
  //
  // SCSI command OP Code
  //
  //
  // Commands for all device types
  //
  public const ulong EFI_SCSI_OP_CHANGE_DEFINITION = 0x40;
  public const ulong EFI_SCSI_OP_COMPARE = 0x39;
  public const ulong EFI_SCSI_OP_COPY = 0x18;
  public const ulong EFI_SCSI_OP_COPY_VERIFY = 0x3a;
  public const ulong EFI_SCSI_OP_INQUIRY = 0x12;
  public const ulong EFI_SCSI_OP_LOG_SELECT = 0x4c;
  public const ulong EFI_SCSI_OP_LOG_SENSE = 0x4d;
  public const ulong EFI_SCSI_OP_MODE_SEL6 = 0x15;
  public const ulong EFI_SCSI_OP_MODE_SEL10 = 0x55;
  public const ulong EFI_SCSI_OP_MODE_SEN6 = 0x1a;
  public const ulong EFI_SCSI_OP_MODE_SEN10 = 0x5a;
  public const ulong EFI_SCSI_OP_READ_BUFFER = 0x3c;
  public const ulong EFI_SCSI_OP_RECEIVE_DIAG = 0x1c;
  public const ulong EFI_SCSI_OP_REQUEST_SENSE = 0x03;
  public const ulong EFI_SCSI_OP_SEND_DIAG = 0x1d;
  public const ulong EFI_SCSI_OP_TEST_UNIT_READY = 0x00;
  public const ulong EFI_SCSI_OP_WRITE_BUFF = 0x3b;

  //
  // Additional commands for Direct Access Devices
  //
  public const ulong EFI_SCSI_OP_FORMAT = 0x04;
  public const ulong EFI_SCSI_OP_LOCK_UN_CACHE = 0x36;
  public const ulong EFI_SCSI_OP_PREFETCH = 0x34;
  public const ulong EFI_SCSI_OP_MEDIA_REMOVAL = 0x1e;
  public const ulong EFI_SCSI_OP_READ6 = 0x08;
  public const ulong EFI_SCSI_OP_READ10 = 0x28;
  public const ulong EFI_SCSI_OP_READ16 = 0x88;
  public const ulong EFI_SCSI_OP_READ_CAPACITY = 0x25;
  public const ulong EFI_SCSI_OP_READ_CAPACITY16 = 0x9e;
  public const ulong EFI_SCSI_OP_READ_DEFECT = 0x37;
  public const ulong EFI_SCSI_OP_READ_LONG = 0x3e;
  public const ulong EFI_SCSI_OP_REASSIGN_BLK = 0x07;
  public const ulong EFI_SCSI_OP_RELEASE = 0x17;
  public const ulong EFI_SCSI_OP_REZERO = 0x01;
  public const ulong EFI_SCSI_OP_SEARCH_DATA_E = 0x31;
  public const ulong EFI_SCSI_OP_SEARCH_DATA_H = 0x30;
  public const ulong EFI_SCSI_OP_SEARCH_DATA_L = 0x32;
  public const ulong EFI_SCSI_OP_SEEK6 = 0x0b;
  public const ulong EFI_SCSI_OP_SEEK10 = 0x2b;
  public const ulong EFI_SCSI_OP_SEND_DIAG = 0x1d;
  public const ulong EFI_SCSI_OP_SET_LIMIT = 0x33;
  public const ulong EFI_SCSI_OP_START_STOP_UNIT = 0x1b;
  public const ulong EFI_SCSI_OP_SYNC_CACHE = 0x35;
  public const ulong EFI_SCSI_OP_VERIFY = 0x2f;
  public const ulong EFI_SCSI_OP_WRITE6 = 0x0a;
  public const ulong EFI_SCSI_OP_WRITE10 = 0x2a;
  public const ulong EFI_SCSI_OP_WRITE16 = 0x8a;
  public const ulong EFI_SCSI_OP_WRITE_VERIFY = 0x2e;
  public const ulong EFI_SCSI_OP_WRITE_LONG = 0x3f;
  public const ulong EFI_SCSI_OP_WRITE_SAME = 0x41;
  public const ulong EFI_SCSI_OP_UNMAP = 0x42;

  //
  // Additional commands for Sequential Access Devices
  //
  public const ulong EFI_SCSI_OP_ERASE = 0x19;
  public const ulong EFI_SCSI_OP_LOAD_UNLOAD = 0x1b;
  public const ulong EFI_SCSI_OP_LOCATE = 0x2b;
  public const ulong EFI_SCSI_OP_READ_BLOCK_LIMIT = 0x05;
  public const ulong EFI_SCSI_OP_READ_POS = 0x34;
  public const ulong EFI_SCSI_OP_READ_REVERSE = 0x0f;
  public const ulong EFI_SCSI_OP_RECOVER_BUF_DATA = 0x14;
  public const ulong EFI_SCSI_OP_RESERVE_UNIT = 0x16;
  public const ulong EFI_SCSI_OP_REWIND = 0x01;
  public const ulong EFI_SCSI_OP_SPACE = 0x11;
  public const ulong EFI_SCSI_OP_VERIFY_TAPE = 0x13;
  public const ulong EFI_SCSI_OP_WRITE_FILEMARK = 0x10;

  //
  // Additional commands for Printer Devices
  //
  public const ulong EFI_SCSI_OP_PRINT = 0x0a;
  public const ulong EFI_SCSI_OP_SLEW_PRINT = 0x0b;
  public const ulong EFI_SCSI_OP_STOP_PRINT = 0x1b;
  public const ulong EFI_SCSI_OP_SYNC_BUFF = 0x10;

  //
  // Additional commands for Processor Devices
  //
  public const ulong EFI_SCSI_OP_RECEIVE = 0x08;
  public const ulong EFI_SCSI_OP_SEND = 0x0a;

  //
  // Additional commands for Write-Once Devices
  //
  public const ulong EFI_SCSI_OP_MEDIUM_SCAN = 0x38;
  public const ulong EFI_SCSI_OP_SEARCH_DAT_E10 = 0x31;
  public const ulong EFI_SCSI_OP_SEARCH_DAT_E12 = 0xb1;
  public const ulong EFI_SCSI_OP_SEARCH_DAT_H10 = 0x30;
  public const ulong EFI_SCSI_OP_SEARCH_DAT_H12 = 0xb0;
  public const ulong EFI_SCSI_OP_SEARCH_DAT_L10 = 0x32;
  public const ulong EFI_SCSI_OP_SEARCH_DAT_L12 = 0xb2;
  public const ulong EFI_SCSI_OP_SET_LIMIT10 = 0x33;
  public const ulong EFI_SCSI_OP_SET_LIMIT12 = 0xb3;
  public const ulong EFI_SCSI_OP_VERIFY10 = 0x2f;
  public const ulong EFI_SCSI_OP_VERIFY12 = 0xaf;
  public const ulong EFI_SCSI_OP_WRITE12 = 0xaa;
  public const ulong EFI_SCSI_OP_WRITE_VERIFY10 = 0x2e;
  public const ulong EFI_SCSI_OP_WRITE_VERIFY12 = 0xae;

  //
  // Additional commands for CD-ROM Devices
  //
  public const ulong EFI_SCSI_OP_PLAY_AUD_10 = 0x45;
  public const ulong EFI_SCSI_OP_PLAY_AUD_12 = 0xa5;
  public const ulong EFI_SCSI_OP_PLAY_AUD_MSF = 0x47;
  public const ulong EFI_SCSI_OP_PLAY_AUD_TKIN = 0x48;
  public const ulong EFI_SCSI_OP_PLAY_TK_REL10 = 0x49;
  public const ulong EFI_SCSI_OP_PLAY_TK_REL12 = 0xa9;
  public const ulong EFI_SCSI_OP_READ_CD_CAPACITY = 0x25;
  public const ulong EFI_SCSI_OP_READ_HEADER = 0x44;
  public const ulong EFI_SCSI_OP_READ_SUB_CHANNEL = 0x42;
  public const ulong EFI_SCSI_OP_READ_TOC = 0x43;

  //
  // Additional commands for Scanner Devices
  //
  public const ulong EFI_SCSI_OP_GET_DATABUFF_STAT = 0x34;
  public const ulong EFI_SCSI_OP_GET_WINDOW = 0x25;
  public const ulong EFI_SCSI_OP_OBJECT_POS = 0x31;
  public const ulong EFI_SCSI_OP_SCAN = 0x1b;
  public const ulong EFI_SCSI_OP_SET_WINDOW = 0x24;

  //
  // Additional commands for Optical Memory Devices
  //
  public const ulong EFI_SCSI_OP_UPDATE_BLOCK = 0x3d;

  //
  // Additional commands for Medium Changer Devices
  //
  public const ulong EFI_SCSI_OP_EXCHANGE_MEDIUM = 0xa6;
  public const ulong EFI_SCSI_OP_INIT_ELEMENT_STAT = 0x07;
  public const ulong EFI_SCSI_OP_POS_TO_ELEMENT = 0x2b;
  public const ulong EFI_SCSI_OP_REQUEST_VE_ADDR = 0xb5;
  public const ulong EFI_SCSI_OP_SEND_VOL_TAG = 0xb6;

  //
  // Additional commands for Communication Devices
  //
  public const ulong EFI_SCSI_OP_GET_MESSAGE6 = 0x08;
  public const ulong EFI_SCSI_OP_GET_MESSAGE10 = 0x28;
  public const ulong EFI_SCSI_OP_GET_MESSAGE12 = 0xa8;
  public const ulong EFI_SCSI_OP_SEND_MESSAGE6 = 0x0a;
  public const ulong EFI_SCSI_OP_SEND_MESSAGE10 = 0x2a;
  public const ulong EFI_SCSI_OP_SEND_MESSAGE12 = 0xaa;

  //
  // Additional commands for Secure Transactions
  //
  public const ulong EFI_SCSI_OP_SECURITY_PROTOCOL_IN = 0xa2;
  public const ulong EFI_SCSI_OP_SECURITY_PROTOCOL_OUT = 0xb5;

  //
  // SCSI Data Transfer Direction
  //
  public const ulong EFI_SCSI_DATA_IN = 0;
  public const ulong EFI_SCSI_DATA_OUT = 1;

  //
  // SCSI Block Command Cache Control Parameters
  //
  public const ulong EFI_SCSI_BLOCK_FUA = BIT3; /// < Force Unit Access
  public const ulong EFI_SCSI_BLOCK_DPO = BIT4; /// < Disable Page Out

  //
  // Peripheral Device Type Definitions
  //
  public const ulong EFI_SCSI_TYPE_DISK = 0x00; /// < Direct-access device (e.g. magnetic disk)
  public const ulong EFI_SCSI_TYPE_TAPE = 0x01; /// < Sequential-access device (e.g. magnetic tape)
  public const ulong EFI_SCSI_TYPE_PRINTER = 0x02; /// < Printer device
  public const ulong EFI_SCSI_TYPE_PROCESSOR = 0x03; /// < Processor device
  public const ulong EFI_SCSI_TYPE_WORM = 0x04; /// < Write-once device (e.g. some optical disks)
  public const ulong EFI_SCSI_TYPE_CDROM = 0x05; /// < CD/DVD device
  public const ulong EFI_SCSI_TYPE_SCANNER = 0x06; /// < Scanner device (obsolete)
  public const ulong EFI_SCSI_TYPE_OPTICAL = 0x07; /// < Optical memory device (e.g. some optical disks)
  public const ulong EFI_SCSI_TYPE_MEDIUMCHANGER = 0x08; /// < Medium changer device (e.g. jukeboxes)
  public const ulong EFI_SCSI_TYPE_COMMUNICATION = 0x09; /// < Communications device (obsolete)
  public const ulong EFI_SCSI_TYPE_ASCIT8_1 = 0x0A; /// < Defined by ASC IT8 (Graphic arts pre-press devices)
  public const ulong EFI_SCSI_TYPE_ASCIT8_2 = 0x0B; /// < Defined by ASC IT8 (Graphic arts pre-press devices)
  public const ulong EFI_SCSI_TYPE_RAID = 0x0C; /// < Storage array controller device (e.g., RAID)
  public const ulong EFI_SCSI_TYPE_SES = 0x0D; /// < Enclosure services device
  public const ulong EFI_SCSI_TYPE_RBC = 0x0E; /// < Simplified direct-access device (e.g., magnetic disk)
  public const ulong EFI_SCSI_TYPE_OCRW = 0x0F; /// < Optical card reader/writer device
  public const ulong EFI_SCSI_TYPE_BRIDGE = 0x10; /// < Bridge Controller Commands
  public const ulong EFI_SCSI_TYPE_OSD = 0x11; /// < Object-based Storage Device
  public const ulong EFI_SCSI_TYPE_AUTOMATION = 0x12; /// < Automation/Drive Interface
  public const ulong EFI_SCSI_TYPE_SECURITYMANAGER = 0x13; /// < Security manager device
  public const ulong EFI_SCSI_TYPE_RESERVED_LOW = 0x14; /// < Reserved (low)
  public const ulong EFI_SCSI_TYPE_RESERVED_HIGH = 0x1D; /// < Reserved (high)
  public const ulong EFI_SCSI_TYPE_WLUN = 0x1E; /// < Well known logical unit
  public const ulong EFI_SCSI_TYPE_UNKNOWN = 0x1F; /// < Unknown or no device type

  //
  // Page Codes for INQUIRY command
  //
  public const ulong EFI_SCSI_PAGE_CODE_SUPPORTED_VPD = 0x00;
  public const ulong EFI_SCSI_PAGE_CODE_BLOCK_LIMITS_VPD = 0xB0;
}

// #pragma pack(1)
///
/// Standard INQUIRY data format
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_INQUIRY_DATA
{
  public byte Peripheral_Type; // = 5;
  public byte Peripheral_Qualifier; // = 3;
  public byte DeviceType_Modifier; // = 7;
  public byte Rmb; // = 1;
  public byte Version;
  public byte Response_Data_Format;
  public byte Addnl_Length;
  public fixed byte Reserved_5_95[95 - 5 + 1];
}

///
/// Supported VPD Pages VPD page
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_SUPPORTED_VPD_PAGES_VPD_PAGE
{
  public byte Peripheral_Type; // = 5;
  public byte Peripheral_Qualifier; // = 3;
  public byte PageCode;
  public byte PageLength2;
  public byte PageLength1;
  public fixed byte SupportedVpdPageList[0x100];
}

///
/// Block Limits VPD page
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_BLOCK_LIMITS_VPD_PAGE
{
  public byte Peripheral_Type; // = 5;
  public byte Peripheral_Qualifier; // = 3;
  public byte PageCode;
  public byte PageLength2;
  public byte PageLength1;
  public byte WriteSameNonZero; // = 1;
  public byte Reserved_4; // = 7;
  public byte MaximumCompareAndWriteLength;
  public byte OptimalTransferLengthGranularity2;
  public byte OptimalTransferLengthGranularity1;
  public byte MaximumTransferLength4;
  public byte MaximumTransferLength3;
  public byte MaximumTransferLength2;
  public byte MaximumTransferLength1;
  public byte OptimalTransferLength4;
  public byte OptimalTransferLength3;
  public byte OptimalTransferLength2;
  public byte OptimalTransferLength1;
  public byte MaximumPrefetchXdreadXdwriteTransferLength4;
  public byte MaximumPrefetchXdreadXdwriteTransferLength3;
  public byte MaximumPrefetchXdreadXdwriteTransferLength2;
  public byte MaximumPrefetchXdreadXdwriteTransferLength1;
  public byte MaximumUnmapLbaCount4;
  public byte MaximumUnmapLbaCount3;
  public byte MaximumUnmapLbaCount2;
  public byte MaximumUnmapLbaCount1;
  public byte MaximumUnmapBlockDescriptorCount4;
  public byte MaximumUnmapBlockDescriptorCount3;
  public byte MaximumUnmapBlockDescriptorCount2;
  public byte MaximumUnmapBlockDescriptorCount1;
  public byte OptimalUnmapGranularity4;
  public byte OptimalUnmapGranularity3;
  public byte OptimalUnmapGranularity2;
  public byte OptimalUnmapGranularity1;
  public byte UnmapGranularityAlignment4; // = 7;
  public byte UnmapGranularityAlignmentValid; // = 1;
  public byte UnmapGranularityAlignment3;
  public byte UnmapGranularityAlignment2;
  public byte UnmapGranularityAlignment1;
  public byte MaximumWriteSameLength4;
  public byte MaximumWriteSameLength3;
  public byte MaximumWriteSameLength2;
  public byte MaximumWriteSameLength1;
  public byte MaximumAtomicTransferLength4;
  public byte MaximumAtomicTransferLength3;
  public byte MaximumAtomicTransferLength2;
  public byte MaximumAtomicTransferLength1;
  public byte AtomicAlignment4;
  public byte AtomicAlignment3;
  public byte AtomicAlignment2;
  public byte AtomicAlignment1;
  public byte AtomicTransferLengthGranularity4;
  public byte AtomicTransferLengthGranularity3;
  public byte AtomicTransferLengthGranularity2;
  public byte AtomicTransferLengthGranularity1;
  public byte MaximumAtomicTransferLengthWithAtomicBoundary4;
  public byte MaximumAtomicTransferLengthWithAtomicBoundary3;
  public byte MaximumAtomicTransferLengthWithAtomicBoundary2;
  public byte MaximumAtomicTransferLengthWithAtomicBoundary1;
  public byte MaximumAtomicBoundarySize4;
  public byte MaximumAtomicBoundarySize3;
  public byte MaximumAtomicBoundarySize2;
  public byte MaximumAtomicBoundarySize1;
}

///
/// Error codes 70h and 71h sense data format
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_SENSE_DATA
{
  public byte Error_Code; // = 7;
  public byte Valid; // = 1;
  public byte Segment_Number;
  public byte Sense_Key; // = 4;
  public byte Reserved_21; // = 1;
  public byte Ili; // = 1;
  public byte Reserved_22; // = 2;
  public fixed byte Information_3_6[4];
  public byte Addnl_Sense_Length;        ///< Additional sense length (n-7)
  public fixed byte Vendor_Specific_8_11[4];
  public byte Addnl_Sense_Code;            ///< Additional sense code
  public byte Addnl_Sense_Code_Qualifier;  ///< Additional sense code qualifier
  public byte Field_Replaceable_Unit_Code; ///< Field replaceable unit code
  public fixed byte Reserved_15_17[3];
}

///
/// SCSI Disk READ CAPACITY Data
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_DISK_CAPACITY_DATA
{
  public byte LastLba3;
  public byte LastLba2;
  public byte LastLba1;
  public byte LastLba0;
  public byte BlockSize3;
  public byte BlockSize2;
  public byte BlockSize1;
  public byte BlockSize0;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_DISK_CAPACITY_DATA16
{
  public byte LastLba7;
  public byte LastLba6;
  public byte LastLba5;
  public byte LastLba4;
  public byte LastLba3;
  public byte LastLba2;
  public byte LastLba1;
  public byte LastLba0;
  public byte BlockSize3;
  public byte BlockSize2;
  public byte BlockSize1;
  public byte BlockSize0;
  public byte Protection;
  public byte LogicPerPhysical;
  public byte LowestAlignLogic2;
  public byte LowestAlignLogic1;
  public fixed byte Reserved[16];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_DISK_UNMAP_PARAM_LIST_HEADER
{
  public ushort DataLen;
  public ushort BlkDespDataLen;
  public fixed byte Reserved[4];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_DISK_UNMAP_BLOCK_DESP
{
  public ulong Lba;
  public uint BlockNum;
  public fixed byte Reserved[4];
}

// #pragma pack()

public unsafe partial class EFI
{
  //
  // Sense Key
  //
  public const ulong EFI_SCSI_SK_NO_SENSE = (0x0);
  public const ulong EFI_SCSI_SK_RECOVERY_ERROR = (0x1);
  public const ulong EFI_SCSI_SK_NOT_READY = (0x2);
  public const ulong EFI_SCSI_SK_MEDIUM_ERROR = (0x3);
  public const ulong EFI_SCSI_SK_HARDWARE_ERROR = (0x4);
  public const ulong EFI_SCSI_SK_ILLEGAL_REQUEST = (0x5);
  public const ulong EFI_SCSI_SK_UNIT_ATTENTION = (0x6);
  public const ulong EFI_SCSI_SK_DATA_PROTECT = (0x7);
  public const ulong EFI_SCSI_SK_BLANK_CHECK = (0x8);
  public const ulong EFI_SCSI_SK_VENDOR_SPECIFIC = (0x9);
  public const ulong EFI_SCSI_SK_RESERVED_A = (0xA);
  public const ulong EFI_SCSI_SK_ABORT = (0xB);
  public const ulong EFI_SCSI_SK_RESERVED_C = (0xC);
  public const ulong EFI_SCSI_SK_OVERFLOW = (0xD);
  public const ulong EFI_SCSI_SK_MISCOMPARE = (0xE);
  public const ulong EFI_SCSI_SK_RESERVED_F = (0xF);

  //
  // Additional Sense Codes and Sense Code Qualifiers.
  // Only some frequently used additional sense codes and qualifiers are
  // defined here. Please refer to SCSI standard for full value definition.
  //
  public const ulong EFI_SCSI_ASC_NOT_READY = (0x04);
  public const ulong EFI_SCSI_ASCQ_IN_PROGRESS = (0x01);

  public const ulong EFI_SCSI_ASC_MEDIA_ERR1 = (0x10);
  public const ulong EFI_SCSI_ASC_MEDIA_ERR2 = (0x11);
  public const ulong EFI_SCSI_ASC_MEDIA_ERR3 = (0x14);
  public const ulong EFI_SCSI_ASC_MEDIA_ERR4 = (0x30);
  public const ulong EFI_SCSI_ASC_MEDIA_UPSIDE_DOWN = (0x06);
  public const ulong EFI_SCSI_ASC_INVALID_CMD = (0x20);
  public const ulong EFI_SCSI_ASC_LBA_OUT_OF_RANGE = (0x21);
  public const ulong EFI_SCSI_ASC_INVALID_FIELD = (0x24);
  public const ulong EFI_SCSI_ASC_WRITE_PROTECTED = (0x27);
  public const ulong EFI_SCSI_ASC_MEDIA_CHANGE = (0x28);
  public const ulong EFI_SCSI_ASC_RESET = (0x29); /// < Power On Reset or Bus Reset occurred
  public const ulong EFI_SCSI_ASC_ILLEGAL_FIELD = (0x26);
  public const ulong EFI_SCSI_ASC_NO_MEDIA = (0x3A);
  public const ulong EFI_SCSI_ASC_ILLEGAL_MODE_FOR_THIS_TRACK = (0x64);
}

// #endif
