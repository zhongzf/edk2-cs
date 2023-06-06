using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file declares Sec Platform Information2 PPI.

  This service is the primary handoff state into the PEI Foundation.
  This service abstracts platform-specific information for many CPU's.

Copyright (c) 2015 - 2016, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This PPI is introduced from PI Version 1.4.

**/

// #ifndef __SEC_PLATFORM_INFORMATION2_PPI_H__
// #define __SEC_PLATFORM_INFORMATION2_PPI_H__

// #include <Ppi/SecPlatformInformation.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_SEC_PLATFORM_INFORMATION2_GUID => new GUID(
      0x9e9f374b, 0x8f16, 0x4230, 0x98, 0x24, 0x58, 0x46, 0xee, 0x76, 0x6a, 0x97);

  // typedef struct _EFI_SEC_PLATFORM_INFORMATION2_PPI EFI_SEC_PLATFORM_INFORMATION2_PPI;
}

///
/// EFI_SEC_PLATFORM_INFORMATION_CPU.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SEC_PLATFORM_INFORMATION_CPU
{
  public uint CpuLocation;
  public EFI_SEC_PLATFORM_INFORMATION_RECORD InfoRecord;
}

///
/// EFI_SEC_PLATFORM_INFORMATION_RECORD2.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SEC_PLATFORM_INFORMATION_RECORD2
{
  ///
  /// The CPU location would be the local APIC ID
  ///
  public uint NumberOfCpus;
  public EFI_SEC_PLATFORM_INFORMATION_CPU[/*1*/] CpuInstance;
}

// /**
//   This interface conveys state information out of the Security (SEC) phase into PEI.
// 
//   This service is published by the SEC phase.
// 
//   @param  PeiServices                The pointer to the PEI Services Table.
//   @param  StructureSize              The pointer to the variable describing size of the input buffer.
//   @param  PlatformInformationRecord2 The pointer to the EFI_SEC_PLATFORM_INFORMATION_RECORD2.
// 
//   @retval EFI_SUCCESS                The data was successfully returned.
//   @retval EFI_BUFFER_TOO_SMALL       The buffer was too small. The current buffer size needed to
//                                      hold the record is returned in StructureSize.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_SEC_PLATFORM_INFORMATION2)(
//   IN CONST  EFI_PEI_SERVICES                     **PeiServices,
//   IN OUT    ulong                               *StructureSize,
//   OUT       EFI_SEC_PLATFORM_INFORMATION_RECORD2 *PlatformInformationRecord2
//   );

///
/// This service abstracts platform-specific information for many CPU's.
/// It is the multi-processor equivalent of PlatformInformation for
/// implementations that synchronize some, if not all CPU's in the SEC phase.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SEC_PLATFORM_INFORMATION2_PPI
{
  public readonly delegate* unmanaged</* IN CONST */EFI_PEI_SERVICES** /*PeiServices*/,/* IN OUT */ulong* /*StructureSize*/,/* OUT */EFI_SEC_PLATFORM_INFORMATION_RECORD2* /*PlatformInformationRecord2*/, EFI_STATUS> /*EFI_SEC_PLATFORM_INFORMATION2*/ PlatformInformation2;
}

// extern EFI_GUID  gEfiSecPlatformInformation2PpiGuid;

// #endif
