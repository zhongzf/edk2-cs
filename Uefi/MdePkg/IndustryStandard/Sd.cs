using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Header file for SD memory card support.

  This header file contains some definitions defined in SD Physical Layer Simplified
  Specification Version 4.10 spec.

  Copyright (c) 2015, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SD_H__
// #define __SD_H__

public unsafe partial class EFI
{
  //
  // SD command index
  //
  public const ulong SD_GO_IDLE_STATE = 0;
  public const ulong SD_ALL_SEND_CID = 2;
  public const ulong SD_SET_RELATIVE_ADDR = 3;
  public const ulong SD_SET_DSR = 4;
  public const ulong SDIO_SEND_OP_COND = 5;
  public const ulong SD_SWITCH_FUNC = 6;
  public const ulong SD_SELECT_DESELECT_CARD = 7;
  public const ulong SD_SEND_IF_COND = 8;
  public const ulong SD_SEND_CSD = 9;
  public const ulong SD_SEND_CID = 10;
  public const ulong SD_VOLTAGE_SWITCH = 11;
  public const ulong SD_STOP_TRANSMISSION = 12;
  public const ulong SD_SEND_STATUS = 13;
  public const ulong SD_GO_INACTIVE_STATE = 15;
  public const ulong SD_SET_BLOCKLEN = 16;
  public const ulong SD_READ_SINGLE_BLOCK = 17;
  public const ulong SD_READ_MULTIPLE_BLOCK = 18;
  public const ulong SD_SEND_TUNING_BLOCK = 19;
  public const ulong SD_SPEED_CLASS_CONTROL = 20;
  public const ulong SD_SET_BLOCK_COUNT = 23;
  public const ulong SD_WRITE_SINGLE_BLOCK = 24;
  public const ulong SD_WRITE_MULTIPLE_BLOCK = 25;
  public const ulong SD_PROGRAM_CSD = 27;
  public const ulong SD_SET_WRITE_PROT = 28;
  public const ulong SD_CLR_WRITE_PROT = 29;
  public const ulong SD_SEND_WRITE_PROT = 30;
  public const ulong SD_ERASE_WR_BLK_START = 32;
  public const ulong SD_ERASE_WR_BLK_END = 33;
  public const ulong SD_ERASE = 38;
  public const ulong SD_LOCK_UNLOCK = 42;
  public const ulong SD_READ_EXTR_SINGLE = 48;
  public const ulong SD_WRITE_EXTR_SINGLE = 49;
  public const ulong SDIO_RW_DIRECT = 52;
  public const ulong SDIO_RW_EXTENDED = 53;
  public const ulong SD_APP_CMD = 55;
  public const ulong SD_GEN_CMD = 56;
  public const ulong SD_READ_EXTR_MULTI = 58;
  public const ulong SD_WRITE_EXTR_MULTI = 59;

  public const ulong SD_SET_BUS_WIDTH = 6; //  ACMD6
  public const ulong SD_STATUS = 13; //  ACMD13
  public const ulong SD_SEND_NUM_WR_BLOCKS = 22; //  ACMD22
  public const ulong SD_SET_WR_BLK_ERASE_COUNT = 23; //  ACMD23
  public const ulong SD_SEND_OP_COND = 41; //  ACMD41
  public const ulong SD_SET_CLR_CARD_DETECT = 42; //  ACMD42
  public const ulong SD_SEND_SCR = 51; //  ACMD51
}

// #pragma pack(1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SD_CID
{
  public byte NotUsed; // = 1;              // Not used [0:0]
  public byte Crc; // = 7;              // CRC [7:1]
  public ushort ManufacturingDate; // = 12;             // Manufacturing date [19:8]
  public ushort Reserved; // = 4;              // Reserved [23:20]
  public fixed byte ProductSerialNumber[4];             // Product serial number [55:24]
  public byte ProductRevision;                    // Product revision [63:56]
  public fixed byte ProductName[5];                     // Product name [103:64]
  public fixed byte OemId[2];                           // OEM/Application ID [119:104]
  public byte ManufacturerId;                     // Manufacturer ID [127:120]
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SD_CSD
{
  public uint NotUsed; // = 1;               // Not used [0:0]
  public uint Crc; // = 7;               // CRC [7:1]
  public uint Reserved; // = 2;               // Reserved [9:8]
  public uint FileFormat; // = 2;               // File format [11:10]
  public uint TmpWriteProtect; // = 1;               // Temporary write protection [12:12]
  public uint PermWriteProtect; // = 1;               // Permanent write protection [13:13]
  public uint Copy; // = 1;               // Copy flag (OTP) [14:14]
  public uint FileFormatGrp; // = 1;               // File format group [15:15]
  public uint Reserved1; // = 5;               // Reserved [20:16]
  public uint WriteBlPartial; // = 1;               // Partial blocks for write allowed [21:21]
  public uint WriteBlLen; // = 4;               // Max. write data block length [25:22]
  public uint R2WFactor; // = 3;               // Write speed factor [28:26]
  public uint Reserved2; // = 2;               // Manufacturer default ECC [30:29]
  public uint WpGrpEnable; // = 1;               // Write protect group enable [31:31]

  public uint WpGrpSize; // = 7;               // Write protect group size [38:32]
  public uint SectorSize; // = 7;               // Erase sector size [45:39]
  public uint EraseBlkEn; // = 1;               // Erase single block enable [46:46]
  public uint CSizeMul; // = 3;               // device size multiplier [49:47]
  public uint VddWCurrMax; // = 3;               // max. write current @VDD max [52:50]
  public uint VddWCurrMin; // = 3;               // max. write current @VDD min [55:53]
  public uint VddRCurrMax; // = 3;               // max. read current @VDD max [58:56]
  public uint VddRCurrMin; // = 3;               // max. read current @VDD min [61:59]
  public uint CSizeLow; // = 2;               // Device size low 2 bits [63:62]

  public uint CSizeHigh; // = 10;              // Device size high 10 bits [73:64]
  public uint Reserved4; // = 2;               // Reserved [75:74]
  public uint DsrImp; // = 1;               // DSR implemented [76:76]
  public uint ReadBlkMisalign; // = 1;               // Read block misalignment [77:77]
  public uint WriteBlkMisalign; // = 1;               // Write block misalignment [78:78]
  public uint ReadBlPartial; // = 1;               // Partial blocks for read allowed [79:79]
  public uint ReadBlLen; // = 4;               // Max. read data block length [83:80]
  public uint Ccc; // = 12;              // Card command classes [95:84]

  public uint TranSpeed; // = 8;               // Max. data transfer rate [103:96]
  public uint Nsac; // = 8;               // Data read access-time in CLK cycles (NSAC*100) [111:104]
  public uint Taac; // = 8;               // Data read access-time [119:112]
  public uint Reserved5; // = 6;               // Reserved [125:120]
  public uint CsdStructure; // = 2;               // CSD structure [127:126]
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SD_CSD2
{
  public uint NotUsed; // = 1;               // Not used [0:0]
  public uint Crc; // = 7;               // CRC [7:1]
  public uint Reserved; // = 2;               // Reserved [9:8]
  public uint FileFormat; // = 2;               // File format [11:10]
  public uint TmpWriteProtect; // = 1;               // Temporary write protection [12:12]
  public uint PermWriteProtect; // = 1;               // Permanent write protection [13:13]
  public uint Copy; // = 1;               // Copy flag (OTP) [14:14]
  public uint FileFormatGrp; // = 1;               // File format group [15:15]
  public uint Reserved1; // = 5;               // Reserved [20:16]
  public uint WriteBlPartial; // = 1;               // Partial blocks for write allowed [21:21]
  public uint WriteBlLen; // = 4;               // Max. write data block length [25:22]
  public uint R2WFactor; // = 3;               // Write speed factor [28:26]
  public uint Reserved2; // = 2;               // Manufacturer default ECC [30:29]
  public uint WpGrpEnable; // = 1;               // Write protect group enable [31:31]

  public uint WpGrpSize; // = 7;               // Write protect group size [38:32]
  public uint SectorSize; // = 7;               // Erase sector size [45:39]
  public uint EraseBlkEn; // = 1;               // Erase single block enable [46:46]
  public uint Reserved3; // = 1;               // Reserved [47:47]
  public uint CSizeLow; // = 16;              // Device size low 16 bits [63:48]

  public uint CSizeHigh; // = 6;               // Device size high 6 bits [69:64]
  public uint Reserved4; // = 6;               // Reserved [75:70]
  public uint DsrImp; // = 1;               // DSR implemented [76:76]
  public uint ReadBlkMisalign; // = 1;               // Read block misalignment [77:77]
  public uint WriteBlkMisalign; // = 1;               // Write block misalignment [78:78]
  public uint ReadBlPartial; // = 1;               // Partial blocks for read allowed [79:79]
  public uint ReadBlLen; // = 4;               // Max. read data block length [83:80]
  public uint Ccc; // = 12;              // Card command classes [95:84]

  public uint TranSpeed; // = 8;               // Max. data transfer rate [103:96]
  public uint Nsac; // = 8;               // Data read access-time in CLK cycles (NSAC*100) [111:104]
  public uint Taac; // = 8;               // Data read access-time [119:112]
  public uint Reserved5; // = 6;               // Reserved [125:120]
  public uint CsdStructure; // = 2;               // CSD structure [127:126]
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SD_SCR
{
  public uint Reserved;                           // Reserved [31:0]

  public uint CmdSupport; // = 4;             // Command Support bits [35:32]
  public uint Reserved1; // = 6;             // Reserved [41:36]
  public uint SdSpec4; // = 1;             // Spec. Version 4.00 or higher [42:42]
  public uint ExSecurity; // = 4;             // Extended Security Support [46:43]
  public uint SdSpec3; // = 1;             // Spec. Version 3.00 or higher [47:47]
  public uint SdBusWidths; // = 4;             // DAT Bus widths supported [51:48]
  public uint SdSecurity; // = 3;             // CPRM security support [54:52]
  public uint DataStatAfterErase; // = 1;             // Data status after erases [55]
  public uint SdSpec; // = 4;             // SD Memory Card Spec. Version [59:56]
  public uint ScrStructure; // = 4;             // SCR Structure [63:60]
}

// #pragma pack()

// #endif
