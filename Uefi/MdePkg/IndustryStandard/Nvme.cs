using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Definitions based on NVMe spec. version 1.1.

  (C) Copyright 2016 Hewlett Packard Enterprise Development LP<BR>
  Copyright (c) 2017 - 2023, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Specification Reference:
  NVMe Specification 1.1
  NVMe Specification 1.4
  NVMe Specification 2.0

**/

// #ifndef __NVM_E_H__
// #define __NVM_E_H__

// #pragma pack(1)

public unsafe partial class EFI
{
  //
  // controller register offsets
  //
  public const ulong NVME_CAP_OFFSET = 0x0000; //  Controller Capabilities
  public const ulong NVME_VER_OFFSET = 0x0008; //  Version
  public const ulong NVME_INTMS_OFFSET = 0x000c; //  Interrupt Mask Set
  public const ulong NVME_INTMC_OFFSET = 0x0010; //  Interrupt Mask Clear
  public const ulong NVME_CC_OFFSET = 0x0014; //  Controller Configuration
  public const ulong NVME_CSTS_OFFSET = 0x001c; //  Controller Status
  public const ulong NVME_NSSR_OFFSET = 0x0020; //  NVM Subsystem Reset
  public const ulong NVME_AQA_OFFSET = 0x0024; //  Admin Queue Attributes
  public const ulong NVME_ASQ_OFFSET = 0x0028; //  Admin Submission Queue Base Address
  public const ulong NVME_ACQ_OFFSET = 0x0030; //  Admin Completion Queue Base Address
  public const ulong NVME_BPINFO_OFFSET = 0x0040; //  Boot Partition Information
  public const ulong NVME_BPRSEL_OFFSET = 0x0044; //  Boot Partition Read Select
  public const ulong NVME_BPMBL_OFFSET = 0x0048; //  Boot Partition Memory Buffer Location
  public const ulong NVME_SQ0_OFFSET = 0x1000; //  Submission Queue 0 (admin) Tail Doorbell
  public const ulong NVME_CQ0_OFFSET = 0x1004; //  Completion Queue 0 (admin) Head Doorbell

  //
  // These register offsets are defined as 0x1000 + (N * (4 << CAP.DSTRD))
  // Get the doorbell stride bit shift value from the controller capabilities.
  //
  public const ulong NVME_SQTDBL_OFFSET = (QID, DSTRD)  0x1000 + ((2 * (QID)) * (4 << (DSTRD)))         ; //  Submission Queue y (NVM) Tail Doorbell
public const ulong NVME_CQHDBL_OFFSET = (QID, DSTRD)  0x1000 + (((2 * (QID)) + 1) * (4 << (DSTRD)))   ; //  Completion Queue y (NVM) Head Doorbell

// #pragma pack(1)
}

//
// 3.1.1 Offset 00h: CAP - Controller Capabilities
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_CAP
{
  public ushort Mqes;       // Maximum Queue Entries Supported
  public byte Cqr = 1; // Contiguous Queues Required
  public byte Ams = 2; // Arbitration Mechanism Supported
  public byte Rsvd1 = 5;
  public byte To;     // Timeout
  public ushort Dstrd = 4;
  public ushort Nssrs = 1; // NVM Subsystem Reset Supported NSSRS
  public ushort Css = 8; // Command Sets Supported - Bit 37
  public ushort Bps = 1; // Boot Partition Support - Bit 45 in NVMe1.4
  public ushort Rsvd3 = 2;
  public byte Mpsmin = 4;
  public byte Mpsmax = 4;
  public byte Pmrs = 1;
  public byte Cmbs = 1;
  public byte Rsvd4 = 6;
}

//
// 3.1.2 Offset 08h: VS - Version
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_VER
{
  public ushort Mnr;    // Minor version number
  public ushort Mjr;    // Major version number
}

//
// 3.1.5 Offset 14h: CC - Controller Configuration
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_CC
{
  public ushort En = 1; // Enable
  public ushort Rsvd1 = 3;
  public ushort Css = 3; // I/O Command Set Selected
  public ushort Mps = 4; // Memory Page Size
  public ushort Ams = 3; // Arbitration Mechanism Selected
  public ushort Shn = 2; // Shutdown Notification
  public byte Iosqes = 4; // I/O Submission Queue Entry Size
  public byte Iocqes = 4; // I/O Completion Queue Entry Size
  public byte Rsvd2;
}
public unsafe partial class EFI
{
  public const ulong NVME_CC_SHN_NORMAL_SHUTDOWN = 1;
  public const ulong NVME_CC_SHN_ABRUPT_SHUTDOWN = 2;
}

//
// 3.1.6 Offset 1Ch: CSTS - Controller Status
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_CSTS
{
  public uint Rdy = 1; // Ready
  public uint Cfs = 1; // Controller Fatal Status
  public uint Shst = 2; // Shutdown Status
  public uint Nssro = 1; // NVM Subsystem Reset Occurred
  public uint Rsvd1 = 27;
}
public unsafe partial class EFI
{
  public const ulong NVME_CSTS_SHST_SHUTDOWN_OCCURRING = 1;
  public const ulong NVME_CSTS_SHST_SHUTDOWN_COMPLETED = 2;
  //
  // 3.1.8 Offset 24h: AQA - Admin Queue Attributes
  //
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_AQA
{
  public ushort Asqs = 12; // Submission Queue Size
  public ushort Rsvd1 = 4;
  public ushort Acqs = 12; // Completion Queue Size
  public ushort Rsvd2 = 4;
}

public unsafe partial class EFI
{
  //
  // 3.1.9 Offset 28h: ASQ - Admin Submission Queue Base Address
  //
  public const ulong NVME_ASQ = UINT64;
  //
  // 3.1.10 Offset 30h: ACQ - Admin Completion Queue Base Address
  //
  public const ulong NVME_ACQ = UINT64;
}

//
// 3.1.13 Offset 40h: BPINFO - Boot Partition Information
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_BPINFO
{
  public uint Bpsz = 15; // Boot Partition Size
  public uint Rsvd1 = 9;
  public uint Brs = 2;  // Boot Read Status
  public uint Rsvd2 = 5;
  public uint Abpid = 1;  // Active Boot Partition ID
}

//
// 3.1.14 Offset 44h: BPRSEL - Boot Partition Read Select
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_BPRSEL
{
  public uint Bprsz = 10; // Boot Partition Read Size
  public uint Bprof = 20; // Boot Partition Read Offset
  public uint Rsvd1 = 1;
  public uint Bpid = 1;  // Boot Partition Identifier
}

//
// 3.1.15 Offset 48h: BPMBL - Boot Partition Memory Buffer Location (Optional)
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_BPMBL
{
  public ulong Rsvd1 = 12;
  public ulong Bmbba = 52; // Boot Partition Memory Buffer Base Address
}

//
// 3.1.25 Offset (1000h + ((2y) * (4 << CAP.DSTRD))): SQyTDBL - Submission Queue y Tail Doorbell
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_SQTDBL
{
  public ushort Sqt;
  public ushort Rsvd1;
}

//
// 3.1.12 Offset (1000h + ((2y + 1) * (4 << CAP.DSTRD))): CQyHDBL - Completion Queue y Head Doorbell
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_CQHDBL
{
  public ushort Cqh;
  public ushort Rsvd1;
}

//
// NVM command set structures
//
// Read Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_READ
{
  //
  // CDW 10, 11
  //
  public ulong Slba;             /* Starting Sector Address */
  //
  // CDW 12
  //
  public ushort Nlb;              /* Number of Sectors */
  public ushort Rsvd1 = 10;
  public ushort Prinfo = 4;       /* Protection Info Check */
  public ushort Fua = 1;       /* Force Unit Access */
  public ushort Lr = 1;       /* Limited Retry */
  //
  // CDW 13
  //
  public uint Af = 4;       /* Access Frequency */
  public uint Al = 2;       /* Access Latency */
  public uint Sr = 1;       /* Sequential Request */
  public uint In = 1;       /* Incompressible */
  public uint Rsvd2 = 24;
  //
  // CDW 14
  //
  public uint Eilbrt;           /* Expected Initial Logical Block Reference Tag */
  //
  // CDW 15
  //
  public ushort Elbat;            /* Expected Logical Block Application Tag */
  public ushort Elbatm;           /* Expected Logical Block Application Tag Mask */
}

//
// Write Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_WRITE
{
  //
  // CDW 10, 11
  //
  public ulong Slba;             /* Starting Sector Address */
  //
  // CDW 12
  //
  public ushort Nlb;              /* Number of Sectors */
  public ushort Rsvd1 = 10;
  public ushort Prinfo = 4;       /* Protection Info Check */
  public ushort Fua = 1;       /* Force Unit Access */
  public ushort Lr = 1;       /* Limited Retry */
  //
  // CDW 13
  //
  public uint Af = 4;       /* Access Frequency */
  public uint Al = 2;       /* Access Latency */
  public uint Sr = 1;       /* Sequential Request */
  public uint In = 1;       /* Incompressible */
  public uint Rsvd2 = 24;
  //
  // CDW 14
  //
  public uint Ilbrt;            /* Initial Logical Block Reference Tag */
  //
  // CDW 15
  //
  public ushort Lbat;             /* Logical Block Application Tag */
  public ushort Lbatm;            /* Logical Block Application Tag Mask */
}

//
// Flush
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_FLUSH
{
  //
  // CDW 10
  //
  public uint Flush;            /* Flush */
}

//
// Write Uncorrectable command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_WRITE_UNCORRECTABLE
{
  //
  // CDW 10, 11
  //
  public ulong Slba;             /* Starting LBA */
  //
  // CDW 12
  //
  public uint Nlb = 16;       /* Number of  Logical Blocks */
  public uint Rsvd1 = 16;
}

//
// Write Zeroes command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_WRITE_ZEROES
{
  //
  // CDW 10, 11
  //
  public ulong Slba;             /* Starting LBA */
  //
  // CDW 12
  //
  public ushort Nlb;              /* Number of Logical Blocks */
  public ushort Rsvd1 = 10;
  public ushort Prinfo = 4;       /* Protection Info Check */
  public ushort Fua = 1;       /* Force Unit Access */
  public ushort Lr = 1;       /* Limited Retry */
  //
  // CDW 13
  //
  public uint Rsvd2;
  //
  // CDW 14
  //
  public uint Ilbrt;            /* Initial Logical Block Reference Tag */
  //
  // CDW 15
  //
  public ushort Lbat;             /* Logical Block Application Tag */
  public ushort Lbatm;            /* Logical Block Application Tag Mask */
}

//
// Compare command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_COMPARE
{
  //
  // CDW 10, 11
  //
  public ulong Slba;             /* Starting LBA */
  //
  // CDW 12
  //
  public ushort Nlb;              /* Number of Logical Blocks */
  public ushort Rsvd1 = 10;
  public ushort Prinfo = 4;       /* Protection Info Check */
  public ushort Fua = 1;       /* Force Unit Access */
  public ushort Lr = 1;       /* Limited Retry */
  //
  // CDW 13
  //
  public uint Rsvd2;
  //
  // CDW 14
  //
  public uint Eilbrt;           /* Expected Initial Logical Block Reference Tag */
  //
  // CDW 15
  //
  public ushort Elbat;            /* Expected Logical Block Application Tag */
  public ushort Elbatm;           /* Expected Logical Block Application Tag Mask */
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct NVME_CMD
{
  NVME_READ Read;
  NVME_WRITE Write;
  NVME_FLUSH Flush;
  NVME_WRITE_UNCORRECTABLE WriteUncorrectable;
  NVME_WRITE_ZEROES WriteZeros;
  NVME_COMPARE Compare;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_PSDESCRIPTOR
{
  public ushort Mp;             /* Maximum Power */
  public byte Rsvd1;          /* Reserved as of Nvm Express 1.1 Spec */
  public byte Mps = 1;      /* Max Power Scale */
  public byte Nops = 1;      /* Non-Operational State */
  public byte Rsvd2 = 6;      /* Reserved as of Nvm Express 1.1 Spec */
  public uint Enlat;          /* Entry Latency */
  public uint Exlat;          /* Exit Latency */
  public byte Rrt = 5;      /* Relative Read Throughput */
  public byte Rsvd3 = 3;      /* Reserved as of Nvm Express 1.1 Spec */
  public byte Rrl = 5;      /* Relative Read Latency */
  public byte Rsvd4 = 3;      /* Reserved as of Nvm Express 1.1 Spec */
  public byte Rwt = 5;      /* Relative Write Throughput */
  public byte Rsvd5 = 3;      /* Reserved as of Nvm Express 1.1 Spec */
  public byte Rwl = 5;      /* Relative Write Latency */
  public byte Rsvd6 = 3;      /* Reserved as of Nvm Express 1.1 Spec */
  public fixed byte Rsvd7[16];      /* Reserved as of Nvm Express 1.1 Spec */
}

//
//  Identify Controller Data
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_CONTROLLER_DATA
{
  //
  // Controller Capabilities and Features 0-255
  //
  public ushort Vid;    /* PCI Vendor ID */
  public ushort Ssvid;  /* PCI sub-system vendor ID */
  public fixed byte Sn[20]; /* Product serial number */

  public fixed byte Mn[40];      /* Product model number */
  public fixed byte Fr[8];       /* Firmware Revision */
  public byte Rab;         /* Recommended Arbitration Burst */
  public fixed byte Ieee_oui[3]; /* Organization Unique Identifier */
  public byte Cmic;        /* Multi-interface Capabilities */
  public byte Mdts;        /* Maximum Data Transfer Size */
  public fixed byte Cntlid[2];   /* Controller ID */
  public fixed byte Rsvd1[176];  /* Reserved as of Nvm Express 1.1 Spec */
  //
  // Admin Command Set Attributes
  //
  public ushort Oacs;  /* Optional Admin Command Support */
  public unsafe partial class EFI
  {
    public const ulong NAMESPACE_MANAGEMENT_SUPPORTED = BIT3;
    public const ulong FW_DOWNLOAD_ACTIVATE_SUPPORTED = BIT2;
    public const ulong FORMAT_NVM_SUPPORTED = BIT1;
    public const ulong SECURITY_SEND_RECEIVE_SUPPORTED = BIT0;
    public byte Acl;   /* Abort Command Limit */
    public byte Aerl;  /* Async Event Request Limit */
    public byte Frmw;  /* Firmware updates */
    public byte Lpa;   /* Log Page Attributes */
    public byte Elpe;  /* Error Log Page Entries */
    public byte Npss;  /* Number of Power States Support */
    public byte Avscc; /* Admin Vendor Specific Command Configuration */
    public byte Apsta; /* Autonomous Power State Transition Attributes */
    //
    // Below fields before Rsvd2 are defined in NVM Express 1.4 Spec
    //
    public ushort Wctemp;      /* Warning Composite Temperature Threshold */
    public ushort Cctemp;      /* Critical Composite Temperature Threshold */
    public ushort Mtfa;        /* Maximum Time for Firmware Activation */
    public uint Hmpre;       /* Host Memory Buffer Preferred Size */
    public uint Hmmin;       /* Host Memory Buffer Minimum Size */
    public fixed byte Tnvmcap[16]; /* Total NVM Capacity */
    public fixed byte Unvmcap[16]; /* Unallocated NVM Capacity */
    public uint Rpmbs;       /* Replay Protected Memory Block Support */
    public ushort Edstt;       /* Extended Device Self-test Time */
    public byte Dsto;        /* Device Self-test Options  */
    public byte Fwug;        /* Firmware Update Granularity */
    public fixed byte Rsvd2[192];  /* Reserved as of Nvm Express 1.4 Spec */
    //
    // NVM Command Set Attributes
    //
    public byte Sqes;       /* Submission Queue Entry Size */
    public byte Cqes;       /* Completion Queue Entry Size */
    public ushort Rsvd3;      /* Reserved as of Nvm Express 1.1 Spec */
    public uint Nn;         /* Number of Namespaces */
    public ushort Oncs;       /* Optional NVM Command Support */
    public ushort Fuses;      /* Fused Operation Support */
    public byte Fna;        /* Format NVM Attributes */
    public byte Vwc;        /* Volatile Write Cache */
    public ushort Awun;       /* Atomic Write Unit Normal */
    public ushort Awupf;      /* Atomic Write Unit Power Fail */
    public byte Nvscc;      /* NVM Vendor Specific Command Configuration */
    public byte Rsvd4;      /* Reserved as of Nvm Express 1.1 Spec */
    public ushort Acwu;       /* Atomic Compare & Write Unit */
    public ushort Rsvd5;      /* Reserved as of Nvm Express 1.1 Spec */
    public uint Sgls;       /* SGL Support  */
    public fixed byte Rsvd6[164]; /* Reserved as of Nvm Express 1.1 Spec */
    //
    // I/O Command set Attributes
    //
    public fixed byte Rsvd7[1344]; /* Reserved as of Nvm Express 1.1 Spec */
    //
    // Power State Descriptors
    //
    NVME_PSDESCRIPTOR PsDescriptor[32];

    public fixed byte VendorData[1024]; /* Vendor specific data */
  }
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_LBAFORMAT
{
  public ushort Ms;             /* Metadata Size */
  public byte Lbads;          /* LBA Data Size */
  public byte Rp = 2;      /* Relative Performance */
  public unsafe partial class EFI
  {
    public const ulong LBAF_RP_BEST = 00b;
public const ulong LBAF_RP_BETTER = 01b;
public const ulong LBAF_RP_GOOD = 10b;
public const ulong LBAF_RP_DEGRADED = 11b;
 public byte Rsvd1 = 6;      /* Reserved as of Nvm Express 1.1 Spec */
  }
}

//
// Identify Namespace Data
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_NAMESPACE_DATA
{
  //
  // NVM Command Set Specific
  //
  public ulong Nsze;      /* Namespace Size (total number of blocks in formatted namespace) */
  public ulong Ncap;      /* Namespace Capacity (max number of logical blocks) */
  public ulong Nuse;      /* Namespace Utilization */
  public byte Nsfeat;    /* Namespace Features */
  public byte Nlbaf;     /* Number of LBA Formats */
  public byte Flbas;     /* Formatted LBA size */
  public byte Mc;        /* Metadata Capabilities */
  public byte Dpc;       /* End-to-end Data Protection capabilities */
  public byte Dps;       /* End-to-end Data Protection Type Settings */
  public byte Nmic;      /* Namespace Multi-path I/O and Namespace Sharing Capabilities */
  public byte Rescap;    /* Reservation Capabilities */
  public fixed byte Rsvd1[88]; /* Reserved as of Nvm Express 1.1 Spec */
  public ulong Eui64;     /* IEEE Extended Unique Identifier */
  //
  // LBA Format
  //
  NVME_LBAFORMAT LbaFormat[16];

  public fixed byte Rsvd2[192];       /* Reserved as of Nvm Express 1.1 Spec */
  public fixed byte VendorData[3712]; /* Vendor specific data */
}

//
// RPMB Device Configuration Block Data Structure as of Nvm Express 1.4 Spec
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_RPMB_CONFIGURATION_DATA
{
  public byte Bppe;       /* Boot Partition Protection Enable */
  public byte Bpl;        /* Boot Partition Lock */
  public byte Nwpac;      /* Namespace Write Protection Authentication Control */
  public fixed byte Rsvd1[509]; /* Reserved as of Nvm Express 1.4 Spec */
}

public unsafe partial class EFI
{
  public const ulong RPMB_FRAME_STUFF_BYTES = 223;
}

//
// RPMB Data Frame as of Nvm Express 1.4 Spec
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_RPMB_DATA_FRAME
{
  public fixed byte Sbakamc[RPMB_FRAME_STUFF_BYTES]; /* [222-N:00] Stuff Bytes */
  /* [222:222-(N-1)] Authentication Key or Message Authentication Code (MAC) */
  public byte Rpmbt;                           /* RPMB Target */
  public fixed ulong Nonce[2];
  public uint Wcounter;                        /* Write Counter */
  public uint Address;                         /* Starting address of data to be programmed to or read from the RPMB. */
  public uint Scount;                          /* Sector Count */
  public ushort Result;
  public ushort Rpmessage;                       /* Request/Response Message */
  // byte    *Data;                         /* Data to be written or read by signed access where M = 512 * Sector Count. */
}

//
// RPMB Device Configuration Block Data Structure.
// (ref. NVMe Base spec. v2.0 Figure 460).
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_RPMB_DCB
{
  public byte BPPEnable;     /* Boot Partition Protection Enabled */
  public byte BPLock;        /* Boot Partition Lock */
  public byte NameSpaceWrP;  /* Namespace Write Protection */
  public fixed byte Rsvd1[509];    /* Reserved as of Nvm Express 2.0 Spec */
}

public unsafe partial class EFI
{
  //
  // RPMB Request and Response Message Types.
  // (ref. NVMe Base spec. v2.0 Figure 461).
  //
  public const ulong NVME_RPMB_AUTHKEY_PROGRAM = 0x0001;
  public const ulong NVME_RPMB_COUNTER_READ = 0x0002;
  public const ulong NVME_RPMB_AUTHDATA_WRITE = 0x0003;
  public const ulong NVME_RPMB_AUTHDATA_READ = 0x0004;
  public const ulong NVME_RPMB_RESULT_READ = 0x0005;
  public const ulong NVME_RPMB_DCB_WRITE = 0x0006;
  public const ulong NVME_RPMB_DCB_READ = 0x0007;
  public const ulong NVME_RPMB_AUTHKEY_PROGRAM_RESPONSE = 0x0100;
  public const ulong NVME_RPMB_COUNTER_READ_RESPONSE = 0x0200;
  public const ulong NVME_RPMB_AUTHDATA_WRITE_RESPONSE = 0x0300;
  public const ulong NVME_RPMB_AUTHDATA_READ_RESPONSE = 0x0400;
  public const ulong NVME_RPMB_DCB_WRITE_RESPONSE = 0x0600;
  public const ulong NVME_RPMB_DCB_READ_RESPONSE = 0x0700;

  //
  // RPMB Operation Result.
  // (ref. NVMe Base spec. v2.0 Figure 462).
  //
  public const ulong NVME_RPMB_RESULT_SUCCESS = 0x00;
  public const ulong NVME_RPMB_RESULT_GENERAL_FAILURE = 0x01;
  public const ulong NVME_RPMB_RESULT_AHTHENTICATION_FAILURE = 0x02;
  public const ulong NVME_RPMB_RESULT_COUNTER_FAILURE = 0x03;
  public const ulong NVME_RPMB_RESULT_ADDRESS_FAILURE = 0x04;
  public const ulong NVME_RPMB_RESULT_WRITE_FAILURE = 0x05;
  public const ulong NVME_RPMB_RESULT_READ_FAILURE = 0x06;
  public const ulong NVME_RPMB_RESULT_AUTHKEY_NOT_PROGRAMMED = 0x07;
  public const ulong NVME_RPMB_RESULT_INVALID_DCB = 0x08;
}

//
// Get Log Page - Boot Partition Log Header.
// (ref. NVMe Base spec. v2.0 Figure 262).
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_BOOT_PARTITION_HEADER
{
  public byte LogIdentifier;   /* Log Identifier, shall be set to 15h */
  public fixed byte Rsvd1[3];
  public uint Bpsz = 15;      /* Boot Partition Size */
  public uint Rsvd2 = 16;
  public uint Abpid = 1;       /* Active Boot Partition ID */
  public fixed byte Rsvd3[8];
}

//
// NvmExpress Admin Identify Cmd
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_IDENTIFY
{
  //
  // CDW 10
  //
  public uint Cns = 2;
  public uint Rsvd1 = 30;
}

//
// NvmExpress Admin Create I/O Completion Queue
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_CRIOCQ
{
  //
  // CDW 10
  //
  public uint Qid = 16;       /* Queue Identifier */
  public uint Qsize = 16;       /* Queue Size */

  //
  // CDW 11
  //
  public uint Pc = 1;        /* Physically Contiguous */
  public uint Ien = 1;        /* Interrupts Enabled */
  public uint Rsvd1 = 14;       /* reserved as of Nvm Express 1.1 Spec */
  public uint Iv = 16;       /* Interrupt Vector for MSI-X or MSI*/
}

//
// NvmExpress Admin Create I/O Submission Queue
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_CRIOSQ
{
  //
  // CDW 10
  //
  public uint Qid = 16;       /* Queue Identifier */
  public uint Qsize = 16;       /* Queue Size */

  //
  // CDW 11
  //
  public uint Pc = 1;        /* Physically Contiguous */
  public uint Qprio = 2;        /* Queue Priority */
  public uint Rsvd1 = 13;       /* Reserved as of Nvm Express 1.1 Spec */
  public uint Cqid = 16;       /* Completion Queue ID */
}

//
// NvmExpress Admin Delete I/O Completion Queue
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_DEIOCQ
{
  //
  // CDW 10
  //
  public ushort Qid;
  public ushort Rsvd1;
}

//
// NvmExpress Admin Delete I/O Submission Queue
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_DEIOSQ
{
  //
  // CDW 10
  //
  public ushort Qid;
  public ushort Rsvd1;
}

//
// NvmExpress Admin Abort Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_ABORT
{
  //
  // CDW 10
  //
  public uint Sqid = 16;        /* Submission Queue identifier */
  public uint Cid = 16;        /* Command Identifier */
}

//
// NvmExpress Admin Firmware Activate Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_FIRMWARE_ACTIVATE
{
  //
  // CDW 10
  //
  public uint Fs = 3;        /* Submission Queue identifier */
  public uint Aa = 2;        /* Command Identifier */
  public uint Rsvd1 = 27;
}

//
// NvmExpress Admin Firmware Image Download Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_FIRMWARE_IMAGE_DOWNLOAD
{
  //
  // CDW 10
  //
  public uint Numd;             /* Number of Dwords */
  //
  // CDW 11
  //
  public uint Ofst;             /* Offset */
}

//
// NvmExpress Admin Get Features Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_GET_FEATURES
{
  //
  // CDW 10
  //
  public uint Fid = 8;         /* Feature Identifier */
  public uint Sel = 3;         /* Select */
  public uint Rsvd1 = 21;
}

//
// NvmExpress Admin Get Log Page Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_GET_LOG_PAGE
{
  //
  // CDW 10
  //
  public uint Lid = 8;        /* Log Page Identifier */
  public unsafe partial class EFI
  {
    public const ulong LID_ERROR_INFO = 0x1;
    public const ulong LID_SMART_INFO = 0x2;
    public const ulong LID_FW_SLOT_INFO = 0x3;
    public const ulong LID_BP_INFO = 0x15;
    public uint Rsvd1 = 8;
    public uint Numd = 12;       /* Number of Dwords */
    public uint Rsvd2 = 4;        /* Reserved as of Nvm Express 1.1 Spec */
  }
}

//
// NvmExpress Admin Set Features Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_SET_FEATURES
{
  //
  // CDW 10
  //
  public uint Fid = 8;        /* Feature Identifier */
  public uint Rsvd1 = 23;
  public uint Sv = 1;        /* Save */
}

//
// NvmExpress Admin Format NVM Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_FORMAT_NVM
{
  //
  // CDW 10
  //
  public uint Lbaf = 4;        /* LBA Format */
  public uint Ms = 1;        /* Metadata Settings */
  public uint Pi = 3;        /* Protection Information */
  public uint Pil = 1;        /* Protection Information Location */
  public uint Ses = 3;        /* Secure Erase Settings */
  public uint Rsvd1 = 20;
}

//
// NvmExpress Admin Security Receive Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_SECURITY_RECEIVE
{
  //
  // CDW 10
  //
  public uint Rsvd1 = 8;
  public uint Spsp = 16;       /* SP Specific */
  public uint Secp = 8;        /* Security Protocol */
  //
  // CDW 11
  //
  public uint Al;               /* Allocation Length */
}

//
// NvmExpress Admin Security Send Command
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ADMIN_SECURITY_SEND
{
  //
  // CDW 10
  //
  public uint Rsvd1 = 8;
  public uint Spsp = 16;       /* SP Specific */
  public uint Secp = 8;        /* Security Protocol */
  //
  // CDW 11
  //
  public uint Tl;               /* Transfer Length */
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct NVME_ADMIN_CMD
{
  NVME_ADMIN_IDENTIFY Identify;
  NVME_ADMIN_CRIOCQ CrIoCq;
  NVME_ADMIN_CRIOSQ CrIoSq;
  NVME_ADMIN_DEIOCQ DeIoCq;
  NVME_ADMIN_DEIOSQ DeIoSq;
  NVME_ADMIN_ABORT Abort;
  NVME_ADMIN_FIRMWARE_ACTIVATE Activate;
  NVME_ADMIN_FIRMWARE_IMAGE_DOWNLOAD FirmwareImageDownload;
  NVME_ADMIN_GET_FEATURES GetFeatures;
  NVME_ADMIN_GET_LOG_PAGE GetLogPage;
  NVME_ADMIN_SET_FEATURES SetFeatures;
  NVME_ADMIN_FORMAT_NVM FormatNvm;
  NVME_ADMIN_SECURITY_RECEIVE SecurityReceive;
  NVME_ADMIN_SECURITY_SEND SecuritySend;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_RAW
{
  public uint Cdw10;
  public uint Cdw11;
  public uint Cdw12;
  public uint Cdw13;
  public uint Cdw14;
  public uint Cdw15;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct NVME_PAYLOAD
{
  NVME_ADMIN_CMD Admin; // Union of Admin commands
  NVME_CMD Nvm;   // Union of Nvm commands
  NVME_RAW Raw;
}

//
// Submission Queue
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_SQ
{
  //
  // CDW 0, Common to all commands
  //
  public byte Opc;       // Opcode
  public byte Fuse = 2; // Fused Operation
  public byte Rsvd1 = 5;
  public byte Psdt = 1; // PRP or SGL for Data Transfer
  public ushort Cid;       // Command Identifier

  //
  // CDW 1
  //
  public uint Nsid;     // Namespace Identifier

  //
  // CDW 2,3
  //
  public ulong Rsvd2;

  //
  // CDW 4,5
  //
  public ulong Mptr;     // Metadata Pointer

  //
  // CDW 6-9
  //
  public fixed ulong Prp[2];   // First and second PRP entries

  NVME_PAYLOAD Payload;
}

//
// Completion Queue
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_CQ
{
  //
  // CDW 0
  //
  public uint Dword0;
  //
  // CDW 1
  //
  public uint Rsvd1;
  //
  // CDW 2
  //
  public ushort Sqhd;           // Submission Queue Head Pointer
  public ushort Sqid;           // Submission Queue Identifier
                                //
                                // CDW 3
                                //
  public ushort Cid;            // Command Identifier
  public ushort Pt = 1;      // Phase Tag
  public ushort Sc = 8;      // Status Code
  public ushort Sct = 3;      // Status Code Type
  public ushort Rsvd2 = 2;
  public ushort Mo = 1;      // More
  public ushort Dnr = 1;      // Do Not Retry
}

public unsafe partial class EFI
{
  //
  // Nvm Express Admin cmd opcodes
  //
  public const ulong NVME_ADMIN_DEIOSQ_CMD = 0x00;
  public const ulong NVME_ADMIN_CRIOSQ_CMD = 0x01;
  public const ulong NVME_ADMIN_GET_LOG_PAGE_CMD = 0x02;
  public const ulong NVME_ADMIN_DEIOCQ_CMD = 0x04;
  public const ulong NVME_ADMIN_CRIOCQ_CMD = 0x05;
  public const ulong NVME_ADMIN_IDENTIFY_CMD = 0x06;
  public const ulong NVME_ADMIN_ABORT_CMD = 0x08;
  public const ulong NVME_ADMIN_SET_FEATURES_CMD = 0x09;
  public const ulong NVME_ADMIN_GET_FEATURES_CMD = 0x0A;
  public const ulong NVME_ADMIN_ASYNC_EVENT_REQUEST_CMD = 0x0C;
  public const ulong NVME_ADMIN_NAMESACE_MANAGEMENT_CMD = 0x0D;
  public const ulong NVME_ADMIN_FW_COMMIT_CMD = 0x10;
  public const ulong NVME_ADMIN_FW_IAMGE_DOWNLOAD_CMD = 0x11;
  public const ulong NVME_ADMIN_NAMESACE_ATTACHMENT_CMD = 0x15;
  public const ulong NVME_ADMIN_FORMAT_NVM_CMD = 0x80;
  public const ulong NVME_ADMIN_SECURITY_SEND_CMD = 0x81;
  public const ulong NVME_ADMIN_SECURITY_RECEIVE_CMD = 0x82;

  public const ulong NVME_IO_FLUSH_OPC = 0;
  public const ulong NVME_IO_WRITE_OPC = 1;
  public const ulong NVME_IO_READ_OPC = 2;
}

public enum NVME_ADMIN_COMMAND_OPCODE
{
  DeleteIOSubmissionQueueOpcode = NVME_ADMIN_DEIOSQ_CMD,
  CreateIOSubmissionQueueOpcode = NVME_ADMIN_CRIOSQ_CMD,
  GetLogPageOpcode = NVME_ADMIN_GET_LOG_PAGE_CMD,
  DeleteIOCompletionQueueOpcode = NVME_ADMIN_DEIOCQ_CMD,
  CreateIOCompletionQueueOpcode = NVME_ADMIN_CRIOCQ_CMD,
  IdentifyOpcode = NVME_ADMIN_IDENTIFY_CMD,
  AbortOpcode = NVME_ADMIN_ABORT_CMD,
  SetFeaturesOpcode = NVME_ADMIN_SET_FEATURES_CMD,
  GetFeaturesOpcode = NVME_ADMIN_GET_FEATURES_CMD,
  AsyncEventRequestOpcode = NVME_ADMIN_ASYNC_EVENT_REQUEST_CMD,
  NamespaceManagementOpcode = NVME_ADMIN_NAMESACE_MANAGEMENT_CMD,
  FirmwareCommitOpcode = NVME_ADMIN_FW_COMMIT_CMD,
  FirmwareImageDownloadOpcode = NVME_ADMIN_FW_IAMGE_DOWNLOAD_CMD,
  NamespaceAttachmentOpcode = NVME_ADMIN_NAMESACE_ATTACHMENT_CMD,
  FormatNvmOpcode = NVME_ADMIN_FORMAT_NVM_CMD,
  SecuritySendOpcode = NVME_ADMIN_SECURITY_SEND_CMD,
  SecurityReceiveOpcode = NVME_ADMIN_SECURITY_RECEIVE_CMD
}

//
// Controller or Namespace Structure (CNS) field
// (ref. spec. v1.1 figure 82).
//
public enum NVME_ADMIN_IDENTIFY_CNS
{
  IdentifyNamespaceCns = 0x0,
  IdentifyControllerCns = 0x1,
  IdentifyActiveNsListCns = 0x2
}

//
// Commit Action
// (ref. spec. 1.1 figure 60).
//
public enum NVME_FW_ACTIVATE_ACTION
{
  ActivateActionReplace = 0x0,
  ActivateActionReplaceActivate = 0x1,
  ActivateActionActivate = 0x2
}

//
// Firmware Slot
// (ref. spec. 1.1 Figure 60).
//
public enum NVME_FW_ACTIVATE_SLOT
{
  FirmwareSlotCtrlChooses = 0x0,
  FirmwareSlot1 = 0x1,
  FirmwareSlot2 = 0x2,
  FirmwareSlot3 = 0x3,
  FirmwareSlot4 = 0x4,
  FirmwareSlot5 = 0x5,
  FirmwareSlot6 = 0x6,
  FirmwareSlot7 = 0x7
}

//
// Get Log Page ? Log Page Identifiers
// (ref. spec. v1.1 Figure 73).
//
public enum NVME_LOG_ID
{
  ErrorInfoLogID = LID_ERROR_INFO,
  SmartHealthInfoLogID = LID_SMART_INFO,
  FirmwareSlotInfoLogID = LID_FW_SLOT_INFO
}

//
// Get Log Page ? Firmware Slot Information Log
// (ref. spec. v1.1 Figure 77).
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_ACTIVE_FW_INFO
{
  //
  // Indicates the firmware slot from which the actively running firmware revision was loaded.
  //
  public byte ActivelyRunningFwSlot = 3;
  public byte                          = 1;
  //
  // Indicates the firmware slot that is going to be activated at the next controller reset. If this field is 0h, then the controller does not indicate the firmware slot that is going to be activated at the next controller reset.
  //
 public byte NextActiveFwSlot = 3;
  public byte                          = 1;
}

//
// Get Log Page ? Firmware Slot Information Log
// (ref. spec. v1.1 Figure 77).
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_FW_SLOT_INFO_LOG
{
  //
  // Specifies information about the active firmware revision.
  // s
  NVME_ACTIVE_FW_INFO ActiveFwInfo;
  public fixed byte Reserved1[7];
  //
  // Contains the revision of the firmware downloaded to firmware slot 1/7. If no valid firmware revision is present or if this slot is unsupported, all zeros shall be returned.
  //
  public fixed byte FwRevisionSlot[7][8];
 public fixed byte Reserved2[448];
}

//
// SMART / Health Information (Log Identifier 02h)
// (ref. spec. v1.1 5.10.1.2)
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_SMART_HEALTH_INFO_LOG
{
  //
  // This field indicates critical warnings for the state of the controller.
  //
  public byte CriticalWarningAvailableSpare = 1;
  public byte CriticalWarningTemperature = 1;
  public byte CriticalWarningReliability = 1;
  public byte CriticalWarningMediaReadOnly = 1;
  public byte CriticalWarningVolatileBackup = 1;
  public byte CriticalWarningReserved = 3;
  //
  // Contains a value corresponding to a temperature in degrees Kelvin that represents the current composite temperature of the controller and namespace(s) associated with that controller. The manner in which this value is computed is implementation specific and may not represent the actual temperature of any physical point in the NVM subsystem.
  //
  public ushort CompositeTemp;
  //
  // Contains a normalized percentage (0 to 100%) of the remaining spare capacity available.
  //
  public byte AvailableSpare;
  //
  // When the Available Spare falls below the threshold indicated in this field, an asynchronous event completion may occur. The value is indicated as a normalized percentage (0 to 100%).
  //
  public byte AvailableSpareThreshold;
  //
  // Contains a vendor specific estimate of the percentage of NVM subsystem life used based on the actual usage and the manufacturer's prediction of NVM life. A value of 100 indicates that the estimated endurance of the NVM in the NVM subsystem has been consumed, but may not indicate an NVM subsystem failure. The value is allowed to exceed 100. Percentages greater than 254 shall be represented as 255. This value shall be updated once per power-on hour (when the controller is not in a sleep state).
  //
  public byte PercentageUsed;
  public fixed byte Reserved1[26];
  //
  // Contains the number of 512 byte data units the host has read from the controller; this value does not include metadata.
  //
  public fixed byte DataUnitsRead[16];
  //
  // Contains the number of 512 byte data units the host has written to the controller; this value does not include metadata.
  //
  public fixed byte DataUnitsWritten[16];
  //
  // Contains the number of read commands completed by the controller.
  //
  public fixed byte HostReadCommands[16];
  //
  // Contains the number of write commands completed by the controller.
  //
  public fixed byte HostWriteCommands[16];
  //
  // Contains the amount of time the controller is busy with I/O commands. This value is reported in minutes.
  //
  public fixed byte ControllerBusyTime[16];
  //
  // Contains the number of power cycles.
  //
  public fixed byte PowerCycles[16];
  //
  // Contains the number of power-on hours.
  //
  public fixed byte PowerOnHours[16];
  //
  // Contains the number of unsafe shutdowns.
  //
  public fixed byte UnsafeShutdowns[16];
  //
  // Contains the number of occurrences where the controller detected an unrecovered data integrity error.
  //
  public fixed byte MediaAndDataIntegrityErrors[16];
  //
  // Contains the number of Error Information log entries over the life of the controller.
  //
  public fixed byte NumberErrorInformationLogEntries[16];
  //
  // Contains the amount of time in minutes that the controller is operational and the Composite Temperature is greater than or equal to the Warning Composite Temperature Threshold (WCTEMP) field and less than the Critical Composite Temperature Threshold (CCTEMP) field in the Identify Controller data structure in Figure 90.
  //
  public uint WarningCompositeTemperatureTime;
  //
  // Contains the amount of time in minutes that the controller is operational and the Composite Temperature is greater the Critical Composite Temperature Threshold (CCTEMP) field in the Identify Controller data structure in Figure 90.
  //
  public uint CriticalCompositeTemperatureTime;
  //
  // Contains the current temperature in degrees Kelvin reported by the temperature sensor.  An implementation that does not implement the temperature sensor reports a temperature of zero degrees Kelvin.
  //
  public fixed ushort TemperatureSensor[8];
  public fixed byte Reserved2[296];
}

// #pragma pack()

// #endif
