using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Header file for eMMC support.

  This header file contains some definitions defined in EMMC4.5/EMMC5.0 spec.

  Copyright (c) 2015, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __EMMC_H__
// #define __EMMC_H__

//
// EMMC command index
//
public unsafe partial class EFI
{
  public const ulong EMMC_GO_IDLE_STATE = 0;
  public const ulong EMMC_SEND_OP_COND = 1;
  public const ulong EMMC_ALL_SEND_CID = 2;
  public const ulong EMMC_SET_RELATIVE_ADDR = 3;
  public const ulong EMMC_SET_DSR = 4;
  public const ulong EMMC_SLEEP_AWAKE = 5;
  public const ulong EMMC_SWITCH = 6;
  public const ulong EMMC_SELECT_DESELECT_CARD = 7;
  public const ulong EMMC_SEND_EXT_CSD = 8;
  public const ulong EMMC_SEND_CSD = 9;
  public const ulong EMMC_SEND_CID = 10;
  public const ulong EMMC_STOP_TRANSMISSION = 12;
  public const ulong EMMC_SEND_STATUS = 13;
  public const ulong EMMC_BUSTEST_R = 14;
  public const ulong EMMC_GO_INACTIVE_STATE = 15;
  public const ulong EMMC_SET_BLOCKLEN = 16;
  public const ulong EMMC_READ_SINGLE_BLOCK = 17;
  public const ulong EMMC_READ_MULTIPLE_BLOCK = 18;
  public const ulong EMMC_BUSTEST_W = 19;
  public const ulong EMMC_SEND_TUNING_BLOCK = 21;
  public const ulong EMMC_SET_BLOCK_COUNT = 23;
  public const ulong EMMC_WRITE_BLOCK = 24;
  public const ulong EMMC_WRITE_MULTIPLE_BLOCK = 25;
  public const ulong EMMC_PROGRAM_CID = 26;
  public const ulong EMMC_PROGRAM_CSD = 27;
  public const ulong EMMC_SET_WRITE_PROT = 28;
  public const ulong EMMC_CLR_WRITE_PROT = 29;
  public const ulong EMMC_SEND_WRITE_PROT = 30;
  public const ulong EMMC_SEND_WRITE_PROT_TYPE = 31;
  public const ulong EMMC_ERASE_GROUP_START = 35;
  public const ulong EMMC_ERASE_GROUP_END = 36;
  public const ulong EMMC_ERASE = 38;
  public const ulong EMMC_FAST_IO = 39;
  public const ulong EMMC_GO_IRQ_STATE = 40;
  public const ulong EMMC_LOCK_UNLOCK = 42;
  public const ulong EMMC_SET_TIME = 49;
  public const ulong EMMC_PROTOCOL_RD = 53;
  public const ulong EMMC_PROTOCOL_WR = 54;
  public const ulong EMMC_APP_CMD = 55;
  public const ulong EMMC_GEN_CMD = 56;
}

public enum EMMC_PARTITION_TYPE
{
  EmmcPartitionUserData = 0,
  EmmcPartitionBoot1 = 1,
  EmmcPartitionBoot2 = 2,
  EmmcPartitionRPMB = 3,
  EmmcPartitionGP1 = 4,
  EmmcPartitionGP2 = 5,
  EmmcPartitionGP3 = 6,
  EmmcPartitionGP4 = 7,
  EmmcPartitionUnknown
}

// #pragma pack(1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EMMC_CID
{
  public byte NotUsed = 1;                        // Not used [0:0]
  public byte Crc = 7;                        // CRC [7:1]
  public byte ManufacturingDate;                     // Manufacturing date [15:8]
  public fixed byte ProductSerialNumber[4];                // Product serial number [47:16]
  public byte ProductRevision;                       // Product revision [55:48]
  public fixed byte ProductName[6];                        // Product name [103:56]
  public byte OemId;                                 // OEM/Application ID [111:104]
  public byte DeviceType = 2;                        // Device/BGA [113:112]
  public byte Reserved = 6;                        // Reserved [119:114]
  public byte ManufacturerId;                        // Manufacturer ID [127:120]
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EMMC_CSD
{
  public uint NotUsed = 1;                 // Not used [0:0]
  public uint Crc = 7;                 // CRC [7:1]
  public uint Ecc = 2;                 // ECC code [9:8]
  public uint FileFormat = 2;                 // File format [11:10]
  public uint TmpWriteProtect = 1;                 // Temporary write protection [12:12]
  public uint PermWriteProtect = 1;                 // Permanent write protection [13:13]
  public uint Copy = 1;                 // Copy flag (OTP) [14:14]
  public uint FileFormatGrp = 1;                 // File format group [15:15]
  public uint ContentProtApp = 1;                 // Content protection application [16:16]
  public uint Reserved = 4;                 // Reserved [20:17]
  public uint WriteBlPartial = 1;                 // Partial blocks for write allowed [21:21]
  public uint WriteBlLen = 4;                 // Max. write data block length [25:22]
  public uint R2WFactor = 3;                 // Write speed factor [28:26]
  public uint DefaultEcc = 2;                 // Manufacturer default ECC [30:29]
  public uint WpGrpEnable = 1;                 // Write protect group enable [31:31]

  public uint WpGrpSize = 5;                 // Write protect group size [36:32]
  public uint EraseGrpMult = 5;                 // Erase group size multiplier [41:37]
  public uint EraseGrpSize = 5;                 // Erase group size [46:42]
  public uint CSizeMult = 3;                 // Device size multiplier [49:47]
  public uint VddWCurrMax = 3;                 // Max. write current @ VDD max [52:50]
  public uint VddWCurrMin = 3;                 // Max. write current @ VDD min [55:53]
  public uint VddRCurrMax = 3;                 // Max. read current @ VDD max [58:56]
  public uint VddRCurrMin = 3;                 // Max. read current @ VDD min [61:59]
  public uint CSizeLow = 2;                 // Device size low two bits [63:62]

  public uint CSizeHigh = 10;                // Device size high eight bits [73:64]
  public uint Reserved1 = 2;                 // Reserved [75:74]
  public uint DsrImp = 1;                 // DSR implemented [76:76]
  public uint ReadBlkMisalign = 1;                 // Read block misalignment [77:77]
  public uint WriteBlkMisalign = 1;                 // Write block misalignment [78:78]
  public uint ReadBlPartial = 1;                 // Partial blocks for read allowed [79:79]
  public uint ReadBlLen = 4;                 // Max. read data block length [83:80]
  public uint Ccc = 12;                // Device command classes [95:84]

  public uint TranSpeed = 8;                 // Max. bus clock frequency [103:96]
  public uint Nsac = 8;                 // Data read access-time 2 in CLK cycles (NSAC*100) [111:104]
  public uint Taac = 8;                 // Data read access-time 1 [119:112]
  public uint Reserved2 = 2;                 // Reserved [121:120]
  public uint SpecVers = 4;                 // System specification version [125:122]
  public uint CsdStructure = 2;                 // CSD structure [127:126]
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EMMC_EXT_CSD
{
  //
  // Modes Segment
  //
  public fixed byte Reserved[16];                          // Reserved [15:0]
  byte SecureRemovalType;                     // Secure Removal Type R/W &public fixed R [16]
  byte ProductStateAwarenessEnablement;       // Product state awareness enablement R/W/E &public fixed R [17]
  public fixed byte MaxPreLoadingDataSize[4];              // Max pre loading data size R [21:18]
  public fixed byte PreLoadingDataSize[4];                 // Pre loading data size R/W/EP [25:22]
  byte FfuStatus;                             // FFU statuspublic fixed R [26]
  public fixed byte Reserved1[2];                          // Reserved [28:27]
  byte ModeOperationCodes;                    // Mode operation codes W/EP [29]
  byte ModeConfig;                            // Mode config R/W/EP [30]
  byte Reserved2;                             //public fixed Reserved [31]
  byte FlushCache;                            // Flushing of the cache W/EP [32]
  byte CacheCtrl;                             // Control to turn the Cache ON/OFF R/W/EP [33]
  byte PowerOffNotification;                  // Power Off Notification R/W/EP [34]
  byte PackedFailureIndex;                    // Packed command failure indexpublic fixed R [35]
  byte PackedCommandStatus;                   // Packed command statuspublic fixed R [36]
  public fixed byte ContextConf[15];                       // Context configuration R/W/EP [51:37]
  public fixed byte ExtPartitionsAttribute[2];             // Extended Partitions Attribute R/W [53:52]
  public fixed byte ExceptionEventsStatus[2];              // Exception events status R [55:54]
  public fixed byte ExceptionEventsCtrl[2];                // Exception events control R/W/EP [57:56]
  byte DyncapNeeded;                          // Number of addressed group to be Releasedpublic fixed R [58]
  byte Class6Ctrl;                            // Class 6 commands control R/W/EP [59]
  byte IniTimeoutEmu;                         // 1st initialization after disabling sector size emulationpublic fixed R [60]
  byte DataSectorSize;                        // Sector sizepublic fixed R [61]
  byte UseNativeSector;                       // Sector size emulation R/W [62]
  byte NativeSectorSize;                      // Native sector sizepublic fixed R [63]
  public fixed byte VendorSpecificField[64];               // Vendor Specific Fields <vendor specific> [127:64]
  public fixed byte Reserved3[2];                          // Reserved [129:128]
  byte ProgramCidCsdDdrSupport;               // Program CID/CSD in DDR mode supportpublic fixed R [130]
  byte PeriodicWakeup;                        // Periodic Wake-up R/W/E [131]
  byte TcaseSupport;                          // Package Case Temperature is controlled W/EP [132]
  byte ProductionStateAwareness;              // Production state awareness R/W/E [133]
  byte SecBadBlkMgmnt;                        // Bad Block Management mode R/W [134]
  byte Reserved4;                             //public fixed Reserved [135]
  public fixed byte EnhStartAddr[4];                       // Enhanced User Data Start Address R/W [139:136]
  public fixed byte EnhSizeMult[3];                        // Enhanced User Data Area Size R/W [142:140]
  public fixed byte GpSizeMult[12];                        // General Purpose Partition Size R/W [154:143]
  byte PartitionSettingCompleted;             // Partitioning Setting R/W [155]
  byte PartitionsAttribute;                   // Partitions attribute R/W [156]
  public fixed byte MaxEnhSizeMult[3];                     // Max Enhanced Area Size R [159:157]
  byte PartitioningSupport;                   // Partitioning Supportpublic fixed R [160]
  byte HpiMgmt;                               // HPI management R/W/EP [161]
  byte RstFunction;                           // H/W reset function R/W [162]
  byte BkopsEn;                               // Enable background operations handshake R/W [163]
  byte BkopsStart;                            // Manually start background operations W/EP [164]
  byte SanitizeStart;                         // Start Sanitize operation W/EP [165]
  byte WrRelParam;                            // Write reliability parameter registerpublic fixed R [166]
  byte WrRelSet;                              // Write reliability setting register R/W [167]
  byte RpmbSizeMult;                          // RPMB Sizepublic fixed R [168]
  byte FwConfig;                              // FW configuration R/W [169]
  byte Reserved5;                             //public fixed Reserved [170]
  byte UserWp;                                // User area write protection register R/W,R/W/CP&R/W/EP [171]
  byte Reserved6;                             //public fixed Reserved [172]
  byte BootWp;                                // Boot area write protection register R/W&R/W/CP[173]
  byte BootWpStatus;                          // Boot write protection status registerspublic fixed R [174]
  byte EraseGroupDef;                         // High-density erase group definition R/W/EP [175]
  byte Reserved7;                             //public fixed Reserved [176]
  byte BootBusConditions;                     // Boot bus Conditions R/W/E [177]
  byte BootConfigProt;                        // Boot config protection R/W&R/W/CP[178]
  byte PartitionConfig;                       // Partition configuration R/W/E&R/W/EP[179]
  byte Reserved8;                             //public fixed Reserved [180]
  byte ErasedMemCont;                         // Erased memory contentpublic fixed R [181]
  byte Reserved9;                             //public fixed Reserved [182]
  byte BusWidth;                              // Bus width mode W/EP [183]
  byte Reserved10;                            //public fixed Reserved [184]
  byte HsTiming;                              // High-speed interface timing R/W/EP [185]
  byte Reserved11;                            //public fixed Reserved [186]
  byte PowerClass;                            // Power class R/W/EP [187]
  byte Reserved12;                            //public fixed Reserved [188]
  byte CmdSetRev;                             // Command set revisionpublic fixed R [189]
  byte Reserved13;                            //public fixed Reserved [190]
  byte CmdSet;                                // Command set R/W/EP [191]
  //
  // Properties Segment
  //
  byte ExtCsdRev;                             // Extended CSDpublic fixed revision [192]
  byte Reserved14;                            //public fixed Reserved [193]
  byte CsdStructure;                          // CSDpublic fixed STRUCTURE [194]
  byte Reserved15;                            //public fixed Reserved [195]
  byte DeviceType;                            // Devicepublic fixed type [196]
  byte DriverStrength;                        // I/O Driverpublic fixed Strength [197]
  byte OutOfInterruptTime;                    // Out-of-interruptpublic fixed busy timing[198]
  byte PartitionSwitchTime;                   // Partition switchingpublic fixed timing [199]
  byte PwrCl52M195V;                          // Power class for 52MHz at 1.95V [200]
  byte PwrCl26M195V;                          // Power class for 26MHz at 1.95V [201]
  byte PwrCl52M360V;                          // Power class for 52MHz at 3.6V [202]
  byte PwrCl26M360V;                          // Power class for 26MHz at 3.6V [203]
  byte Reserved16;                            //public fixed Reserved [204]
  byte MinPerfR4B26M;                         // Minimum Read Performance for 4bit atpublic fixed 26MHz [205]
  byte MinPerfW4B26M;                         // Minimum Write Performance for 4bit atpublic fixed 26MHz [206]
  byte MinPerfR8B26M4B52M;                    // Minimum Read Performance for 8bit at 26MHz, for 4bit atpublic fixed 52MHz [207]
  byte MinPerfW8B26M4B52M;                    // Minimum Write Performance for 8bit at 26MHz, for 4bit atpublic fixed 52MHz [208]
  byte MinPerfR8B52M;                         // Minimum Read Performance for 8bit atpublic fixed 52MHz [209]
  byte MinPerfW8B52M;                         // Minimum Write Performance for 8bit atpublic fixed 52MHz [210]
  byte Reserved17;                            //public fixed Reserved [211]
  public fixed byte SecCount[4];                           // Sector Count [215:212]
  byte SleepNotificationTime;                 // Sleep Notification Timeout [216]
  byte SATimeout;                             // Sleep/awakepublic fixed timeout [217]
  byte ProductionStateAwarenessTimeout;       // Production state awarenesspublic fixed timeout [218]
  public fixed bytepublic fixed  public fixed SCVccq; public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  // Sleep current (VCCQ) [219]
public fixed bytepublic fixed  public fixed SCVcc; public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed  public fixed   // Sleep current (VCC) [220]
  byte HcWpGrpSize;                           // High-capacity write protect grouppublic fixed size [221]
  byte RelWrSecC;                             // Reliable write sectorpublic fixed count [222]
  byte EraseTimeoutMult;                      // High-capacity erasepublic fixed timeout [223]
  byte HcEraseGrpSize;                        // High-capacity erase unitpublic fixed size [224]
  byte AccSize;                               // Accesspublic fixed size [225]
  byte BootSizeMult;                          // Boot partitionpublic fixed size [226]
  byte Reserved18;                            //public fixed Reserved [227]
  byte BootInfo;                              // Bootpublic fixed information [228]
  byte SecTrimMult;                           // Secure TRIMpublic fixed Multiplier [229]
  byte SecEraseMult;                          // Secure Erasepublic fixed Multiplier [230]
  byte SecFeatureSupport;                     // Secure Featurepublic fixed support [231]
  byte TrimMult;                              // TRIMpublic fixed Multiplier [232]
  byte Reserved19;                            //public fixed Reserved [233]
  byte MinPerfDdrR8b52M;                      // Minimum Read Performance for 8bit at 52MHz in DDRpublic fixed mode [234]
  byte MinPerfDdrW8b52M;                      // Minimum Write Performance for 8bit at 52MHz in DDRpublic fixed mode [235]
  byte PwrCl200M130V;                         // Power class for 200MHz, at VCCQ=1.3V, VCC = 3.6V [236]
  byte PwrCl200M195V;                         // Power class for 200MHz at VCCQ=1.95V, VCC = 3.6V [237]
  byte PwrClDdr52M195V;                       // Power class for 52MHz, DDR at VCC= 1.95V [238]
  byte PwrClDdr52M360V;                       // Power class for 52MHz, DDR at VCC= 3.6V [239]
  byte Reserved20;                            //public fixed Reserved [240]
  byte IniTimeoutAp;                          // 1st initialization time afterpublic fixed partitioning [241]
  public fixed byte CorrectlyPrgSectorsNum[4];             // Number of correctly programmed sectors [245:242]
  byte BkopsStatus;                           // Background operationspublic fixed status [246]
  byte PowerOffLongTime;                      // Power off notification(long)public fixed timeout [247]
  byte GenericCmd6Time;                       // Generic CMD6public fixed timeout [248]
  public fixed byte CacheSize[4];                          // Cache size [252:249]
  byte PwrClDdr200M360V;                      // Power class for 200MHz, DDR at VCC= 3.6V [253]
  public fixed byte FirmwareVersion[8];                    // Firmware version [261:254]
  public fixed byte DeviceVersion[2];                      // Device version [263:262]
  byte OptimalTrimUnitSize;                   // Optimal trimpublic fixed unit size[264]
  byte OptimalWriteSize;                      // Optimal writepublic fixed size [265]
  byte OptimalReadSize;                       // Optimal readpublic fixed size [266]
  byte PreEolInfo;                            // Pre EOLpublic fixed information [267]
  byte DeviceLifeTimeEstTypA;                 // Device life time estimation typepublic fixed A [268]
  byte DeviceLifeTimeEstTypB;                 // Device life time estimation typepublic fixed B [269]
  public fixed byte VendorProprietaryHealthReport[32];     // Vendor proprietary health report [301:270]
  public fixed byte NumOfFwSectorsProgrammed[4];           // Number of FW sectors correctly programmed [305:302]
  public fixed byte Reserved21[181];                       // Reserved [486:306]
  public fixed byte FfuArg[4];                             // FFU Argument [490:487]
  byte OperationCodeTimeout;                  // Operation codespublic fixed timeout [491]
  byte FfuFeatures;                           // FFUpublic fixed features [492]
  byte SupportedModes;                        // Supportedpublic fixed modes [493]
  byte ExtSupport;                            // Extended partitions attributepublic fixed support [494]
  byte LargeUnitSizeM1;                       // Large Unitpublic fixed size [495]
  byte ContextCapabilities;                   // Context managementpublic fixed capabilities [496]
  byte TagResSize;                            // Tag Resourcespublic fixed Size [497]
  byte TagUnitSize;                           // Tag Unitpublic fixed Size [498]
  byte DataTagSupport;                        // Data Tagpublic fixed Support [499]
  byte MaxPackedWrites;                       // Max packed writepublic fixed commands [500]
  byte MaxPackedReads;                        // Max packedpublic fixed read commands[501]
  byte BkOpsSupport;                          // Background operationspublic fixed support [502]
  byte HpiFeatures;                           // HPIpublic fixed features [503]
  byte SupportedCmdSet;                       // Supported Commandpublic fixed Sets [504]
  byte ExtSecurityErr;                        // Extended Security Commandspublic fixed Error [505]
  public fixed byte Reserved22[6];                         // Reserved [511:506]
}

// #pragma pack()

// #endif
