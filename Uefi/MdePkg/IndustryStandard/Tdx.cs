using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Intel Trust Domain Extension definitions
  Detailed information is in below document:
  https://software.intel.com/content/dam/develop/external/us/en/documents
  /tdx-module-1eas-v0.85.039.pdf

  Copyright (c) 2020 - 2021, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef MDE_PKG_TDX_H_
// #define MDE_PKG_TDX_H_

public unsafe partial class EFI
{
  public const ulong EXIT_REASON_EXTERNAL_INTERRUPT = 1;
  public const ulong EXIT_REASON_TRIPLE_FAULT = 2;

  public const ulong EXIT_REASON_PENDING_INTERRUPT = 7;
  public const ulong EXIT_REASON_NMI_WINDOW = 8;
  public const ulong EXIT_REASON_TASK_SWITCH = 9;
  public const ulong EXIT_REASON_CPUID = 10;
  public const ulong EXIT_REASON_HLT = 12;
  public const ulong EXIT_REASON_INVD = 13;
  public const ulong EXIT_REASON_INVLPG = 14;
  public const ulong EXIT_REASON_RDPMC = 15;
  public const ulong EXIT_REASON_RDTSC = 16;
  public const ulong EXIT_REASON_VMCALL = 18;
  public const ulong EXIT_REASON_VMCLEAR = 19;
  public const ulong EXIT_REASON_VMLAUNCH = 20;
  public const ulong EXIT_REASON_VMPTRLD = 21;
  public const ulong EXIT_REASON_VMPTRST = 22;
  public const ulong EXIT_REASON_VMREAD = 23;
  public const ulong EXIT_REASON_VMRESUME = 24;
  public const ulong EXIT_REASON_VMWRITE = 25;
  public const ulong EXIT_REASON_VMOFF = 26;
  public const ulong EXIT_REASON_VMON = 27;
  public const ulong EXIT_REASON_CR_ACCESS = 28;
  public const ulong EXIT_REASON_DR_ACCESS = 29;
  public const ulong EXIT_REASON_IO_INSTRUCTION = 30;
  public const ulong EXIT_REASON_MSR_READ = 31;
  public const ulong EXIT_REASON_MSR_WRITE = 32;
  public const ulong EXIT_REASON_INVALID_STATE = 33;
  public const ulong EXIT_REASON_MSR_LOAD_FAIL = 34;
  public const ulong EXIT_REASON_MWAIT_INSTRUCTION = 36;
  public const ulong EXIT_REASON_MONITOR_TRAP_FLAG = 37;
  public const ulong EXIT_REASON_MONITOR_INSTRUCTION = 39;
  public const ulong EXIT_REASON_PAUSE_INSTRUCTION = 40;
  public const ulong EXIT_REASON_MCE_DURING_VMENTRY = 41;
  public const ulong EXIT_REASON_TPR_BELOW_THRESHOLD = 43;
  public const ulong EXIT_REASON_APIC_ACCESS = 44;
  public const ulong EXIT_REASON_EOI_INDUCED = 45;
  public const ulong EXIT_REASON_GDTR_IDTR = 46;
  public const ulong EXIT_REASON_LDTR_TR = 47;
  public const ulong EXIT_REASON_EPT_VIOLATION = 48;
  public const ulong EXIT_REASON_EPT_MISCONFIG = 49;
  public const ulong EXIT_REASON_INVEPT = 50;
  public const ulong EXIT_REASON_RDTSCP = 51;
  public const ulong EXIT_REASON_PREEMPTION_TIMER = 52;
  public const ulong EXIT_REASON_INVVPID = 53;
  public const ulong EXIT_REASON_WBINVD = 54;
  public const ulong EXIT_REASON_XSETBV = 55;
  public const ulong EXIT_REASON_APIC_WRITE = 56;
  public const ulong EXIT_REASON_RDRAND = 57;
  public const ulong EXIT_REASON_INVPCID = 58;
  public const ulong EXIT_REASON_VMFUNC = 59;
  public const ulong EXIT_REASON_ENCLS = 60;
  public const ulong EXIT_REASON_RDSEED = 61;
  public const ulong EXIT_REASON_PML_FULL = 62;
  public const ulong EXIT_REASON_XSAVES = 63;
  public const ulong EXIT_REASON_XRSTORS = 64;

  // TDCALL API Function Completion Status Codes
  public const ulong TDX_EXIT_REASON_SUCCESS = 0x0000000000000000;
  public const ulong TDX_EXIT_REASON_PAGE_ALREADY_ACCEPTED = 0x00000B0A00000000;
  public const ulong TDX_EXIT_REASON_PAGE_SIZE_MISMATCH = 0xC0000B0B00000000;
  public const ulong TDX_EXIT_REASON_OPERAND_INVALID = 0xC000010000000000;
  public const ulong TDX_EXIT_REASON_OPERAND_BUSY = 0x8000020000000000;

  // TDCALL [TDG.MEM.PAGE.ACCEPT] page size
  public const ulong TDCALL_ACCEPT_PAGE_SIZE_4K = 0;
  public const ulong TDCALL_ACCEPT_PAGE_SIZE_2M = 1;
  public const ulong TDCALL_ACCEPT_PAGE_SIZE_1G = 2;

  public const ulong TDCALL_TDVMCALL = 0;
  public const ulong TDCALL_TDINFO = 1;
  public const ulong TDCALL_TDEXTENDRTMR = 2;
  public const ulong TDCALL_TDGETVEINFO = 3;
  public const ulong TDCALL_TDREPORT = 4;
  public const ulong TDCALL_TDSETCPUIDVE = 5;
  public const ulong TDCALL_TDACCEPTPAGE = 6;

  public const ulong TDVMCALL_CPUID = 0x0000a;
  public const ulong TDVMCALL_HALT = 0x0000c;
  public const ulong TDVMCALL_IO = 0x0001e;
  public const ulong TDVMCALL_RDMSR = 0x0001f;
  public const ulong TDVMCALL_WRMSR = 0x00020;
  public const ulong TDVMCALL_MMIO = 0x00030;
  public const ulong TDVMCALL_PCONFIG = 0x00041;

  public const ulong TDVMCALL_GET_TDVMCALL_INFO = 0x10000;
  public const ulong TDVMCALL_MAPGPA = 0x10001;
  public const ulong TDVMCALL_GET_QUOTE = 0x10002;
  public const ulong TDVMCALL_REPORT_FATAL_ERR = 0x10003;
  public const ulong TDVMCALL_SETUP_EVENT_NOTIFY = 0x10004;
}

// #pragma pack(1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TDCALL_GENERIC_RETURN_DATA
{
  public fixed ulong Data[6];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TDCALL_INFO_RETURN_DATA
{
  public ulong Gpaw;
  public ulong Attributes;
  public uint MaxVcpus;
  public uint NumVcpus;
  public fixed ulong Resv[3];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct VMX_EXIT_QUALIFICATION
{
  [FieldOffset(0)] public ulong Val;
  /*   struct { */
  [FieldOffset(0)] public uint Size; // = 3;
  [FieldOffset(0)] public uint Direction; // = 1;
  [FieldOffset(0)] public uint String; // = 1;
  [FieldOffset(0)] public uint Rep; // = 1;
  [FieldOffset(0)] public uint Encoding; // = 1;
  [FieldOffset(0)] public uint Resv; // = 9;
  [FieldOffset(0)] public uint Port; // = 16;
  [FieldOffset(0)] public uint Resv2;
  /*   } Io; */
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TDCALL_VEINFO_RETURN_DATA
{
  public uint ExitReason;
  public uint Resv;
  public VMX_EXIT_QUALIFICATION ExitQualification;
  public ulong GuestLA;
  public ulong GuestPA;
  public uint ExitInstructionLength;
  public uint ExitInstructionInfo;
  public uint Resv1;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct TD_RETURN_DATA
{
  [FieldOffset(0)] public TDCALL_GENERIC_RETURN_DATA Generic;
  [FieldOffset(0)] public TDCALL_INFO_RETURN_DATA TdInfo;
  [FieldOffset(0)] public TDCALL_VEINFO_RETURN_DATA VeInfo;
}

/* data structure used in TDREPORT_STRUCT */
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TD_REPORT_TYPE
{
  public byte Type;
  public byte Subtype;
  public byte Version;
  public byte Rsvd;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct REPORTMACSTRUCT
{
  public TD_REPORT_TYPE ReportType;
  public fixed byte Rsvd1[12];
  public fixed byte CpuSvn[16];
  public fixed byte TeeTcbInfoHash[48];
  public fixed byte TeeInfoHash[48];
  public fixed byte ReportData[64];
  public fixed byte Rsvd2[32];
  public fixed byte Mac[32];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TEE_TCB_SVN
{
  public fixed byte Seam[2];
  public fixed byte Rsvd[14];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TEE_TCB_INFO
{
  public fixed byte Valid[8];
  public TEE_TCB_SVN TeeTcbSvn;
  public fixed byte Mrseam[48];
  public fixed byte Mrsignerseam[48];
  public fixed byte Attributes[8];
  public fixed byte Rsvd[111];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TDINFO
{
  public fixed byte Attributes[8];
  public fixed byte Xfam[8];
  public fixed byte Mrtd[48];
  public fixed byte Mrconfigid[48];
  public fixed byte Mrowner[48];
  public fixed byte Mrownerconfig[48];
  byte Rtmrs[4][48];
  public fixed byte Rsvd[112];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TDREPORT_STRUCT
{
  public REPORTMACSTRUCT ReportMacStruct;
  public TEE_TCB_INFO TeeTcbInfo;
  public fixed byte Rsvd[17];
  public TDINFO Tdinfo;
}

// #pragma pack()

// #endif
