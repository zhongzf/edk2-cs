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

public unsafe partial class EFI
{
  //
  // EMMC command index
  //
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
  public byte NotUsed;// = 1;                        // Not used [0:0]
  public byte Crc;// = 7;                        // CRC [7:1]
  public byte ManufacturingDate;                     // Manufacturing date [15:8]
  public fixed byte ProductSerialNumber[4];                // Product serial number [47:16]
  public byte ProductRevision;                       // Product revision [55:48]
  public fixed byte ProductName[6];                        // Product name [103:56]
  public byte OemId;                                 // OEM/Application ID [111:104]
  public byte DeviceType;// = 2;                        // Device/BGA [113:112]
  public byte Reserved;// = 6;                        // Reserved [119:114]
  public byte ManufacturerId;                        // Manufacturer ID [127:120]
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EMMC_CSD
{
  public uint NotUsed;// = 1;                 // Not used [0:0]
  public uint Crc;// = 7;                 // CRC [7:1]
  public uint Ecc;// = 2;                 // ECC code [9:8]
  public uint FileFormat;// = 2;                 // File format [11:10]
  public uint TmpWriteProtect;// = 1;                 // Temporary write protection [12:12]
  public uint PermWriteProtect;// = 1;                 // Permanent write protection [13:13]
  public uint Copy;// = 1;                 // Copy flag (OTP) [14:14]
  public uint FileFormatGrp;// = 1;                 // File format group [15:15]
  public uint ContentProtApp;// = 1;                 // Content protection application [16:16]
  public uint Reserved;// = 4;                 // Reserved [20:17]
  public uint WriteBlPartial;// = 1;                 // Partial blocks for write allowed [21:21]
  public uint WriteBlLen;// = 4;                 // Max. write data block length [25:22]
  public uint R2WFactor;// = 3;                 // Write speed factor [28:26]
  public uint DefaultEcc;// = 2;                 // Manufacturer default ECC [30:29]
  public uint WpGrpEnable;// = 1;                 // Write protect group enable [31:31]

  public uint WpGrpSize;// = 5;                 // Write protect group size [36:32]
  public uint EraseGrpMult;// = 5;                 // Erase group size multiplier [41:37]
  public uint EraseGrpSize;// = 5;                 // Erase group size [46:42]
  public uint CSizeMult;// = 3;                 // Device size multiplier [49:47]
  public uint VddWCurrMax;// = 3;                 // Max. write current @ VDD max [52:50]
  public uint VddWCurrMin;// = 3;                 // Max. write current @ VDD min [55:53]
  public uint VddRCurrMax;// = 3;                 // Max. read current @ VDD max [58:56]
  public uint VddRCurrMin;// = 3;                 // Max. read current @ VDD min [61:59]
  public uint CSizeLow;// = 2;                 // Device size low two bits [63:62]

  public uint CSizeHigh;// = 10;                // Device size high eight bits [73:64]
  public uint Reserved1;// = 2;                 // Reserved [75:74]
  public uint DsrImp;// = 1;                 // DSR implemented [76:76]
  public uint ReadBlkMisalign;// = 1;                 // Read block misalignment [77:77]
  public uint WriteBlkMisalign;// = 1;                 // Write block misalignment [78:78]
  public uint ReadBlPartial;// = 1;                 // Partial blocks for read allowed [79:79]
  public uint ReadBlLen;// = 4;                 // Max. read data block length [83:80]
  public uint Ccc;// = 12;                // Device command classes [95:84]

  public uint TranSpeed;// = 8;                 // Max. bus clock frequency [103:96]
  public uint Nsac;// = 8;                 // Data read access-time 2 in CLK cycles (NSAC*100) [111:104]
  public uint Taac;// = 8;                 // Data read access-time 1 [119:112]
  public uint Reserved2;// = 2;                 // Reserved [121:120]
  public uint SpecVers;// = 4;                 // System specification version [125:122]
  public uint CsdStructure;// = 2;                 // CSD structure [127:126]
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EMMC_EXT_CSD
{
  //
  // Modes Segment
  //
  public fixed byte Reserved[16];                          // Reserved [15:0]
  public byte SecureRemovalType;                     // Secure Removal Type R/W & R [16]
  public byte ProductStateAwarenessEnablement;       // Product state awareness enablement R/W/E & R [17]
  public fixed byte MaxPreLoadingDataSize[4];              // Max pre loading data size R [21:18]
  public fixed byte PreLoadingDataSize[4];                 // Pre loading data size R/W/EP [25:22]
  public byte FfuStatus;                             // FFU status R [26]
  public fixed byte Reserved1[2];                          // Reserved [28:27]
  public byte ModeOperationCodes;                    // Mode operation codes W/EP [29]
  public byte ModeConfig;                            // Mode config R/W/EP [30]
  public byte Reserved2;                             // Reserved [31]
  public byte FlushCache;                            // Flushing of the cache W/EP [32]
  public byte CacheCtrl;                             // Control to turn the Cache ON/OFF R/W/EP [33]
  public byte PowerOffNotification;                  // Power Off Notification R/W/EP [34]
  public byte PackedFailureIndex;                    // Packed command failure index R [35]
  public byte PackedCommandStatus;                   // Packed command status R [36]
  public fixed byte ContextConf[15];                       // Context configuration R/W/EP [51:37]
  public fixed byte ExtPartitionsAttribute[2];             // Extended Partitions Attribute R/W [53:52]
  public fixed byte ExceptionEventsStatus[2];              // Exception events status R [55:54]
  public fixed byte ExceptionEventsCtrl[2];                // Exception events control R/W/EP [57:56]
  public byte DyncapNeeded;                          // Number of addressed group to be Released R [58]
  public byte Class6Ctrl;                            // Class 6 commands control R/W/EP [59]
  public byte IniTimeoutEmu;                         // 1st initialization after disabling sector size emulation R [60]
  public byte DataSectorSize;                        // Sector size R [61]
  public byte UseNativeSector;                       // Sector size emulation R/W [62]
  public byte NativeSectorSize;                      // Native sector size R [63]
  public fixed byte VendorSpecificField[64];               // Vendor Specific Fields <vendor specific> [127:64]
  public fixed byte Reserved3[2];                          // Reserved [129:128]
  public byte ProgramCidCsdDdrSupport;               // Program CID/CSD in DDR mode support R [130]
  public byte PeriodicWakeup;                        // Periodic Wake-up R/W/E [131]
  public byte TcaseSupport;                          // Package Case Temperature is controlled W/EP [132]
  public byte ProductionStateAwareness;              // Production state awareness R/W/E [133]
  public byte SecBadBlkMgmnt;                        // Bad Block Management mode R/W [134]
  public byte Reserved4;                             // Reserved [135]
  public fixed byte EnhStartAddr[4];                       // Enhanced User Data Start Address R/W [139:136]
  public fixed byte EnhSizeMult[3];                        // Enhanced User Data Area Size R/W [142:140]
  public fixed byte GpSizeMult[12];                        // General Purpose Partition Size R/W [154:143]
  public byte PartitionSettingCompleted;             // Partitioning Setting R/W [155]
  public byte PartitionsAttribute;                   // Partitions attribute R/W [156]
  public fixed byte MaxEnhSizeMult[3];                     // Max Enhanced Area Size R [159:157]
  public byte PartitioningSupport;                   // Partitioning Support R [160]
  public byte HpiMgmt;                               // HPI management R/W/EP [161]
  public byte RstFunction;                           // H/W reset function R/W [162]
  public byte BkopsEn;                               // Enable background operations handshake R/W [163]
  public byte BkopsStart;                            // Manually start background operations W/EP [164]
  public byte SanitizeStart;                         // Start Sanitize operation W/EP [165]
  public byte WrRelParam;                            // Write reliability parameter register R [166]
  public byte WrRelSet;                              // Write reliability setting register R/W [167]
  public byte RpmbSizeMult;                          // RPMB Size R [168]
  public byte FwConfig;                              // FW configuration R/W [169]
  public byte Reserved5;                             // Reserved [170]
  public byte UserWp;                                // User area write protection register R/W,R/W/CP&R/W/EP [171]
  public byte Reserved6;                             // Reserved [172]
  public byte BootWp;                                // Boot area write protection register R/W&R/W/CP[173]
  public byte BootWpStatus;                          // Boot write protection status registers R [174]
  public byte EraseGroupDef;                         // High-density erase group definition R/W/EP [175]
  public byte Reserved7;                             // Reserved [176]
  public byte BootBusConditions;                     // Boot bus Conditions R/W/E [177]
  public byte BootConfigProt;                        // Boot config protection R/W&R/W/CP[178]
  public byte PartitionConfig;                       // Partition configuration R/W/E&R/W/EP[179]
  public byte Reserved8;                             // Reserved [180]
  public byte ErasedMemCont;                         // Erased memory content R [181]
  public byte Reserved9;                             // Reserved [182]
  public byte BusWidth;                              // Bus width mode W/EP [183]
  public byte Reserved10;                            // Reserved [184]
  public byte HsTiming;                              // High-speed interface timing R/W/EP [185]
  public byte Reserved11;                            // Reserved [186]
  public byte PowerClass;                            // Power class R/W/EP [187]
  public byte Reserved12;                            // Reserved [188]
  public byte CmdSetRev;                             // Command set revision R [189]
  public byte Reserved13;                            // Reserved [190]
  public byte CmdSet;                                // Command set R/W/EP [191]
  //
  // Properties Segment
  //
  public byte ExtCsdRev;                             // Extended CSD revision [192]
  public byte Reserved14;                            // Reserved [193]
  public byte CsdStructure;                          // CSD STRUCTURE [194]
  public byte Reserved15;                            // Reserved [195]
  public byte DeviceType;                            // Device type [196]
  public byte DriverStrength;                        // I/O Driver Strength [197]
  public byte OutOfInterruptTime;                    // Out-of-interrupt busy timing[198]
  public byte PartitionSwitchTime;                   // Partition switching timing [199]
  public byte PwrCl52M195V;                          // Power class for 52MHz at 1.95V [200]
  public byte PwrCl26M195V;                          // Power class for 26MHz at 1.95V [201]
  public byte PwrCl52M360V;                          // Power class for 52MHz at 3.6V [202]
  public byte PwrCl26M360V;                          // Power class for 26MHz at 3.6V [203]
  public byte Reserved16;                            // Reserved [204]
  public byte MinPerfR4B26M;                         // Minimum Read Performance for 4bit at 26MHz [205]
  public byte MinPerfW4B26M;                         // Minimum Write Performance for 4bit at 26MHz [206]
  public byte MinPerfR8B26M4B52M;                    // Minimum Read Performance for 8bit at 26MHz, for 4bit at 52MHz [207]
  public byte MinPerfW8B26M4B52M;                    // Minimum Write Performance for 8bit at 26MHz, for 4bit at 52MHz [208]
  public byte MinPerfR8B52M;                         // Minimum Read Performance for 8bit at 52MHz [209]
  public byte MinPerfW8B52M;                         // Minimum Write Performance for 8bit at 52MHz [210]
  public byte Reserved17;                            // Reserved [211]
  public fixed byte SecCount[4];                           // Sector Count [215:212]
  public byte SleepNotificationTime;                 // Sleep Notification Timeout [216]
  public byte SATimeout;                             // Sleep/awake timeout [217]
  public byte ProductionStateAwarenessTimeout;       // Production state awareness timeout [218]
  public byte SCVccq;                                // Sleep current (VCCQ) [219]
  public byte SCVcc;                                 // Sleep current (VCC) [220]
  public byte HcWpGrpSize;                           // High-capacity write protect group size [221]
  public byte RelWrSecC;                             // Reliable write sector count [222]
  public byte EraseTimeoutMult;                      // High-capacity erase timeout [223]
  public byte HcEraseGrpSize;                        // High-capacity erase unit size [224]
  public byte AccSize;                               // Access size [225]
  public byte BootSizeMult;                          // Boot partition size [226]
  public byte Reserved18;                            // Reserved [227]
  public byte BootInfo;                              // Boot information [228]
  public byte SecTrimMult;                           // Secure TRIM Multiplier [229]
  public byte SecEraseMult;                          // Secure Erase Multiplier [230]
  public byte SecFeatureSupport;                     // Secure Feature support [231]
  public byte TrimMult;                              // TRIM Multiplier [232]
  public byte Reserved19;                            // Reserved [233]
  public byte MinPerfDdrR8b52M;                      // Minimum Read Performance for 8bit at 52MHz in DDR mode [234]
  public byte MinPerfDdrW8b52M;                      // Minimum Write Performance for 8bit at 52MHz in DDR mode [235]
  public byte PwrCl200M130V;                         // Power class for 200MHz, at VCCQ=1.3V, VCC = 3.6V [236]
  public byte PwrCl200M195V;                         // Power class for 200MHz at VCCQ=1.95V, VCC = 3.6V [237]
  public byte PwrClDdr52M195V;                       // Power class for 52MHz, DDR at VCC= 1.95V [238]
  public byte PwrClDdr52M360V;                       // Power class for 52MHz, DDR at VCC= 3.6V [239]
  public byte Reserved20;                            // Reserved [240]
  public byte IniTimeoutAp;                          // 1st initialization time after partitioning [241]
  public fixed byte CorrectlyPrgSectorsNum[4];             // Number of correctly programmed sectors [245:242]
  public byte BkopsStatus;                           // Background operations status [246]
  public byte PowerOffLongTime;                      // Power off notification(long) timeout [247]
  public byte GenericCmd6Time;                       // Generic CMD6 timeout [248]
  public fixed byte CacheSize[4];                          // Cache size [252:249]
  public byte PwrClDdr200M360V;                      // Power class for 200MHz, DDR at VCC= 3.6V [253]
  public fixed byte FirmwareVersion[8];                    // Firmware version [261:254]
  public fixed byte DeviceVersion[2];                      // Device version [263:262]
  public byte OptimalTrimUnitSize;                   // Optimal trim unit size[264]
  public byte OptimalWriteSize;                      // Optimal write size [265]
  public byte OptimalReadSize;                       // Optimal read size [266]
  public byte PreEolInfo;                            // Pre EOL information [267]
  public byte DeviceLifeTimeEstTypA;                 // Device life time estimation type A [268]
  public byte DeviceLifeTimeEstTypB;                 // Device life time estimation type B [269]
  public fixed byte VendorProprietaryHealthReport[32];     // Vendor proprietary health report [301:270]
  public fixed byte NumOfFwSectorsProgrammed[4];           // Number of FW sectors correctly programmed [305:302]
  public fixed byte Reserved21[181];                       // Reserved [486:306]
  public fixed byte FfuArg[4];                             // FFU Argument [490:487]
  public byte OperationCodeTimeout;                  // Operation codes timeout [491]
  public byte FfuFeatures;                           // FFU features [492]
  public byte SupportedModes;                        // Supported modes [493]
  public byte ExtSupport;                            // Extended partitions attribute support [494]
  public byte LargeUnitSizeM1;                       // Large Unit size [495]
  public byte ContextCapabilities;                   // Context management capabilities [496]
  public byte TagResSize;                            // Tag Resources Size [497]
  public byte TagUnitSize;                           // Tag Unit Size [498]
  public byte DataTagSupport;                        // Data Tag Support [499]
  public byte MaxPackedWrites;                       // Max packed write commands [500]
  public byte MaxPackedReads;                        // Max packed read commands[501]
  public byte BkOpsSupport;                          // Background operations support [502]
  public byte HpiFeatures;                           // HPI features [503]
  public byte SupportedCmdSet;                       // Supported Command Sets [504]
  public byte ExtSecurityErr;                        // Extended Security Commands Error [505]
  public fixed byte Reserved22[6];                         // Reserved [511:506]
}

// #pragma pack()

// #endif
