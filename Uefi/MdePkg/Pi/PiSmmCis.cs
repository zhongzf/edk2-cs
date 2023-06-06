using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Common definitions in the Platform Initialization Specification version 1.4a
  VOLUME 4 System Management Mode Core Interface version.

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _PI_SMMCIS_H_
// #define _PI_SMMCIS_H_

// #include <Pi/PiMmCis.h>
// #include <Protocol/SmmCpuIo2.h>

public unsafe partial class EFI
{
  // typedef struct _EFI_SMM_SYSTEM_TABLE2 EFI_SMM_SYSTEM_TABLE2;
  //
  // Define new MM related definition introduced by PI 1.5.
  //
  //public const ulong SMM_SMST_SIGNATURE = MM_MMST_SIGNATURE;
  public const ulong SMM_SPECIFICATION_MAJOR_REVISION = MM_SPECIFICATION_MAJOR_REVISION;
  public const ulong SMM_SPECIFICATION_MINOR_REVISION = MM_SPECIFICATION_MINOR_REVISION;
  public const ulong EFI_SMM_SYSTEM_TABLE2_REVISION = EFI_MM_SYSTEM_TABLE_REVISION;

  // /**
  //   Adds, updates, or removes a configuration table entry from the System Management System Table.
  // 
  //   The SmmInstallConfigurationTable() function is used to maintain the list
  //   of configuration tables that are stored in the System Management System
  //   Table.  The list is stored as an array of (GUID, Pointer) pairs.  The list
  //   must be allocated from pool memory with PoolType set to EfiRuntimeServicesData.
  // 
  //   @param[in] SystemTable         A pointer to the SMM System Table (SMST).
  //   @param[in] Guid                A pointer to the GUID for the entry to add, update, or remove.
  //   @param[in] Table               A pointer to the buffer of the table to add.
  //   @param[in] TableSize           The size of the table to install.
  // 
  //   @retval EFI_SUCCESS            The (Guid, Table) pair was added, updated, or removed.
  //   @retval EFI_INVALID_PARAMETER  Guid is not valid.
  //   @retval EFI_NOT_FOUND          An attempt was made to delete a non-existent entry.
  //   @retval EFI_OUT_OF_RESOURCES   There is not enough memory available to complete the operation.
  // **/
  // typedef
  // EFI_STATUS
  // (EFIAPI *EFI_SMM_INSTALL_CONFIGURATION_TABLE2)(
  //   IN CONST EFI_SMM_SYSTEM_TABLE2    *SystemTable,
  //   IN CONST EFI_GUID                 *Guid,
  //   IN void                           *Table,
  //   IN ulong                          TableSize
  //   );

  //typedef  EFI_MM_STARTUP_THIS_AP          EFI_SMM_STARTUP_THIS_AP;
  //typedef  EFI_MM_NOTIFY_FN                EFI_SMM_NOTIFY_FN;
  //typedef  EFI_MM_REGISTER_PROTOCOL_NOTIFY EFI_SMM_REGISTER_PROTOCOL_NOTIFY;
  //typedef  EFI_MM_INTERRUPT_MANAGE         EFI_SMM_INTERRUPT_MANAGE;
  //typedef  EFI_MM_HANDLER_ENTRY_POINT      EFI_SMM_HANDLER_ENTRY_POINT2;
  //typedef  EFI_MM_INTERRUPT_REGISTER       EFI_SMM_INTERRUPT_REGISTER;
  //typedef  EFI_MM_INTERRUPT_UNREGISTER     EFI_SMM_INTERRUPT_UNREGISTER;
}

///
/// Processor information and functionality needed by SMM Foundation.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_ENTRY_CONTEXT
{
  public EFI_SMM_STARTUP_THIS_AP SmmStartupThisAp;
  ///
  /// A number between zero and the NumberOfCpus field. This field designates which
  /// processor is executing the SMM Foundation.
  ///
  public ulong CurrentlyExecutingCpu;
  ///
  /// The number of possible processors in the platform.  This is a 1 based
  /// counter.  This does not indicate the number of processors that entered SMM.
  ///
  public ulong NumberOfCpus;
  ///
  /// Points to an array, where each element describes the number of bytes in the
  /// corresponding save state specified by CpuSaveState. There are always
  /// NumberOfCpus entries in the array.
  ///
  public ulong* CpuSaveStateSize;
  ///
  /// Points to an array, where each element is a pointer to a CPU save state. The
  /// corresponding element in CpuSaveStateSize specifies the number of bytes in the
  /// save state area. There are always NumberOfCpus entries in the array.
  ///
  public void** CpuSaveState;
}

// /**
//   This function is the main entry point to the SMM Foundation.
// 
//   @param[in] SmmEntryContext  Processor information and functionality needed by SMM Foundation.
// **/
// typedef
// VOID
// (EFIAPI *EFI_SMM_ENTRY_POINT)(
//   IN CONST EFI_SMM_ENTRY_CONTEXT  *SmmEntryContext
//   );

///
/// System Management System Table (SMST)
///
/// The System Management System Table (SMST) is a table that contains a collection of common
/// services for managing SMRAM allocation and providing basic I/O services. These services are
/// intended for both preboot and runtime usage.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_SYSTEM_TABLE2
{
  ///
  /// The table header for the SMST.
  ///
  public EFI_TABLE_HEADER Hdr;
  ///
  /// A pointer to a NULL-terminated Unicode string containing the vendor name.
  /// It is permissible for this pointer to be NULL.
  ///
  public char* SmmFirmwareVendor;
  ///
  /// The particular revision of the firmware.
  ///
  public uint SmmFirmwareRevision;

  public readonly delegate* unmanaged</* IN CONST */EFI_SMM_SYSTEM_TABLE2* /*SystemTable*/,/* IN CONST */EFI_GUID* /*Guid*/,/* IN */void* /*Table*/,/* IN */ulong /*TableSize*/, EFI_STATUS> /*EFI_SMM_INSTALL_CONFIGURATION_TABLE2*/ SmmInstallConfigurationTable;

  ///
  /// I/O Service
  ///
  public EFI_SMM_CPU_IO2_PROTOCOL SmmIo;

  ///
  /// Runtime memory services
  ///
  public EFI_ALLOCATE_POOL SmmAllocatePool;
  public EFI_FREE_POOL SmmFreePool;
  public EFI_ALLOCATE_PAGES SmmAllocatePages;
  public EFI_FREE_PAGES SmmFreePages;

  ///
  /// MP service
  ///
  public EFI_SMM_STARTUP_THIS_AP SmmStartupThisAp;

  ///
  /// CPU information records
  ///

  ///
  /// A number between zero and and the NumberOfCpus field. This field designates
  /// which processor is executing the SMM infrastructure.
  ///
  public ulong CurrentlyExecutingCpu;
  ///
  /// The number of possible processors in the platform.  This is a 1 based counter.
  ///
  public ulong NumberOfCpus;
  ///
  /// Points to an array, where each element describes the number of bytes in the
  /// corresponding save state specified by CpuSaveState. There are always
  /// NumberOfCpus entries in the array.
  ///
  public ulong* CpuSaveStateSize;
  ///
  /// Points to an array, where each element is a pointer to a CPU save state. The
  /// corresponding element in CpuSaveStateSize specifies the number of bytes in the
  /// save state area. There are always NumberOfCpus entries in the array.
  ///
  public void** CpuSaveState;

  ///
  /// Extensibility table
  ///

  ///
  /// The number of UEFI Configuration Tables in the buffer SmmConfigurationTable.
  ///
  public ulong NumberOfTableEntries;
  ///
  /// A pointer to the UEFI Configuration Tables. The number of entries in the table is
  /// NumberOfTableEntries.
  ///
  public EFI_CONFIGURATION_TABLE* SmmConfigurationTable;

  ///
  /// Protocol services
  ///
  public EFI_INSTALL_PROTOCOL_INTERFACE SmmInstallProtocolInterface;
  public EFI_UNINSTALL_PROTOCOL_INTERFACE SmmUninstallProtocolInterface;
  public EFI_HANDLE_PROTOCOL SmmHandleProtocol;
  public EFI_SMM_REGISTER_PROTOCOL_NOTIFY SmmRegisterProtocolNotify;
  public EFI_LOCATE_HANDLE SmmLocateHandle;
  public EFI_LOCATE_PROTOCOL SmmLocateProtocol;

  ///
  /// SMI Management functions
  ///
  public EFI_SMM_INTERRUPT_MANAGE SmiManage;
  public EFI_SMM_INTERRUPT_REGISTER SmiHandlerRegister;
  public EFI_SMM_INTERRUPT_UNREGISTER SmiHandlerUnRegister;
}

// #endif
