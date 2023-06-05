using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This protocol provides services for creating ACPI system description tables.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in PI Specification 1.2.

**/

// #ifndef __ACPI_SYSTEM_DESCRIPTION_TABLE_H___
// #define __ACPI_SYSTEM_DESCRIPTION_TABLE_H___

public unsafe partial class EFI
{
  public static EFI_GUID EFI_ACPI_SDT_PROTOCOL_GUID = new GUID(0xeb97088e, 0xcfdf, 0x49c6, new byte[] { 0xbe, 0x4b, 0xd9, 0x6, 0xa5, 0xb2, 0xe, 0x86 });
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_TABLE_VERSION { uint Value; public static implicit operator EFI_ACPI_TABLE_VERSION(uint value) => new EFI_ACPI_TABLE_VERSION() { Value = value }; public static implicit operator uint(EFI_ACPI_TABLE_VERSION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_HANDLE { void* Value; public static implicit operator EFI_ACPI_HANDLE(void* value) => new EFI_ACPI_HANDLE() { Value = value }; public static implicit operator void*(EFI_ACPI_HANDLE value) => value.Value; }

public unsafe partial class EFI
{
  public const ulong EFI_ACPI_TABLE_VERSION_NONE = (1 << 0);
  public const ulong EFI_ACPI_TABLE_VERSION_1_0B = (1 << 1);
  public const ulong EFI_ACPI_TABLE_VERSION_2_0 = (1 << 2);
  public const ulong EFI_ACPI_TABLE_VERSION_3_0 = (1 << 3);
  public const ulong EFI_ACPI_TABLE_VERSION_4_0 = (1 << 4);
  public const ulong EFI_ACPI_TABLE_VERSION_5_0 = (1 << 5);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_DATA_TYPE { uint Value; public static implicit operator EFI_ACPI_DATA_TYPE(uint value) => new EFI_ACPI_DATA_TYPE() { Value = value }; public static implicit operator uint(EFI_ACPI_DATA_TYPE value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong EFI_ACPI_DATA_TYPE_NONE = 0;
  public const ulong EFI_ACPI_DATA_TYPE_OPCODE = 1;
  public const ulong EFI_ACPI_DATA_TYPE_NAME_STRING = 2;
  public const ulong EFI_ACPI_DATA_TYPE_OP = 3;
  public const ulong EFI_ACPI_DATA_TYPE_UINT = 4;
  public const ulong EFI_ACPI_DATA_TYPE_STRING = 5;
  public const ulong EFI_ACPI_DATA_TYPE_CHILD = 6;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_SDT_HEADER
{
  public uint Signature;
  public uint Length;
  public byte Revision;
  public byte Checksum;
  public fixed byte OemId[6];
  public fixed byte OemTableId[8];
  public uint OemRevision;
  public uint CreatorId;
  public uint CreatorRevision;
}

//typedef
//EFI_STATUS
//(EFIAPI* EFI_ACPI_NOTIFICATION_FN)(
//  IN EFI_ACPI_SDT_HEADER    * Table,     ///< A pointer to the ACPI table header.
//  IN EFI_ACPI_TABLE_VERSION Version,    ///< The ACPI table's version.
//  IN ulong TableKey    ///< The table key for this ACPI table.
//  );

// /**
//   Returns a requested ACPI table.
// 
//   The GetAcpiTable() function returns a pointer to a buffer containing the ACPI table associated
//   with the Index that was input. The following structures are not considered elements in the list of
//   ACPI tables:
//   - Root System Description Pointer (RSD_PTR)
//   - Root System Description Table (RSDT)
//   - Extended System Description Table (XSDT)
//   Version is updated with a bit map containing all the versions of ACPI of which the table is a
//   member. For tables installed via the EFI_ACPI_TABLE_PROTOCOL.InstallAcpiTable() interface,
//   the function returns the value of EFI_ACPI_STD_PROTOCOL.AcpiVersion.
// 
//   @param[in]    Index       The zero-based index of the table to retrieve.
//   @param[out]   Table       Pointer for returning the table buffer.
//   @param[out]   Version     On return, updated with the ACPI versions to which this table belongs. Type
//                             EFI_ACPI_TABLE_VERSION is defined in "Related Definitions" in the
//                             EFI_ACPI_SDT_PROTOCOL.
//   @param[out]   TableKey    On return, points to the table key for the specified ACPI system definition table.
//                             This is identical to the table key used in the EFI_ACPI_TABLE_PROTOCOL.
//                             The TableKey can be passed to EFI_ACPI_TABLE_PROTOCOL.UninstallAcpiTable()
//                             to uninstall the table.
// 
//   @retval EFI_SUCCESS       The function completed successfully.
//   @retval EFI_NOT_FOUND     The requested index is too large and a table was not found.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_ACPI_GET_ACPI_TABLE2)(
//   IN    ulong                   Index,
//   OUT   EFI_ACPI_SDT_HEADER     **Table,
//   OUT   EFI_ACPI_TABLE_VERSION  *Version,
//   OUT   ulong                   *TableKey
//   );

// /**
//   Register or unregister a callback when an ACPI table is installed.
// 
//   This function registers or unregisters a function which will be called whenever a new ACPI table is
//   installed.
// 
//   @param[in]    Register        If TRUE, then the specified function will be registered. If FALSE, then the specified
//                                 function will be unregistered.
//   @param[in]    Notification    Points to the callback function to be registered or unregistered.
// 
//   @retval EFI_SUCCESS           Callback successfully registered or unregistered.
//   @retval EFI_INVALID_PARAMETER Notification is NULL
//   @retval EFI_INVALID_PARAMETER Register is FALSE and Notification does not match a known registration function.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_ACPI_REGISTER_NOTIFY)(
//   IN bool                    Register,
//   IN EFI_ACPI_NOTIFICATION_FN   Notification
//   );

// /**
//   Create a handle from an ACPI opcode
// 
//   @param[in]  Buffer                 Points to the ACPI opcode.
//   @param[out] Handle                 Upon return, holds the handle.
// 
//   @retval   EFI_SUCCESS             Success
//   @retval   EFI_INVALID_PARAMETER   Buffer is NULL or Handle is NULL or Buffer points to an
//                                     invalid opcode.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_ACPI_OPEN)(
//   IN    void            *Buffer,
//   OUT   EFI_ACPI_HANDLE *Handle
//   );

// /**
//   Create a handle for the first ACPI opcode in an ACPI system description table.
// 
//   @param[in]    TableKey    The table key for the ACPI table, as returned by GetTable().
//   @param[out]   Handle      On return, points to the newly created ACPI handle.
// 
//   @retval EFI_SUCCESS       Handle created successfully.
//   @retval EFI_NOT_FOUND     TableKey does not refer to a valid ACPI table.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_ACPI_OPEN_SDT)(
//   IN    ulong           TableKey,
//   OUT   EFI_ACPI_HANDLE *Handle
//   );

// /**
//   Close an ACPI handle.
// 
//   @param[in] Handle Returns the handle.
// 
//   @retval EFI_SUCCESS           Success
//   @retval EFI_INVALID_PARAMETER Handle is NULL or does not refer to a valid ACPI object.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_ACPI_CLOSE)(
//   IN EFI_ACPI_HANDLE Handle
//   );

// /**
//   Return the child ACPI objects.
// 
//   @param[in]        ParentHandle    Parent handle.
//   @param[in, out]   Handle          On entry, points to the previously returned handle or NULL to start with the first
//                                     handle. On return, points to the next returned ACPI handle or NULL if there are no
//                                     child objects.
// 
//   @retval EFI_SUCCESS               Success
//   @retval EFI_INVALID_PARAMETER     ParentHandle is NULL or does not refer to a valid ACPI object.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_ACPI_GET_CHILD)(
//   IN EFI_ACPI_HANDLE        ParentHandle,
//   IN OUT EFI_ACPI_HANDLE    *Handle
//   );

// /**
//   Retrieve information about an ACPI object.
// 
//   @param[in]    Handle      ACPI object handle.
//   @param[in]    Index       Index of the data to retrieve from the object. In general, indexes read from left-to-right
//                             in the ACPI encoding, with index 0 always being the ACPI opcode.
//   @param[out]   DataType    Points to the returned data type or EFI_ACPI_DATA_TYPE_NONE if no data exists
//                             for the specified index.
//   @param[out]   Data        Upon return, points to the pointer to the data.
//   @param[out]   DataSize    Upon return, points to the size of Data.
// 
//   @retval
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_ACPI_GET_OPTION)(
//   IN        EFI_ACPI_HANDLE     Handle,
//   IN        ulong               Index,
//   OUT       EFI_ACPI_DATA_TYPE  *DataType,
//   OUT CONST void                **Data,
//   OUT       ulong               *DataSize
//   );

// /**
//   Change information about an ACPI object.
// 
//   @param[in]  Handle    ACPI object handle.
//   @param[in]  Index     Index of the data to retrieve from the object. In general, indexes read from left-to-right
//                         in the ACPI encoding, with index 0 always being the ACPI opcode.
//   @param[in]  Data      Points to the data.
//   @param[in]  DataSize  The size of the Data.
// 
//   @retval EFI_SUCCESS           Success
//   @retval EFI_INVALID_PARAMETER Handle is NULL or does not refer to a valid ACPI object.
//   @retval EFI_BAD_BUFFER_SIZE   Data cannot be accommodated in the space occupied by
//                                 the option.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_ACPI_SET_OPTION)(
//   IN        EFI_ACPI_HANDLE Handle,
//   IN        ulong           Index,
//   IN CONST  void            *Data,
//   IN        ulong           DataSize
//   );

// /**
//   Returns the handle of the ACPI object representing the specified ACPI path
// 
//   @param[in]    HandleIn    Points to the handle of the object representing the starting point for the path search.
//   @param[in]    AcpiPath    Points to the ACPI path, which conforms to the ACPI encoded path format.
//   @param[out]   HandleOut   On return, points to the ACPI object which represents AcpiPath, relative to
//                             HandleIn.
// 
//   @retval EFI_SUCCESS           Success
//   @retval EFI_INVALID_PARAMETER HandleIn is NULL or does not refer to a valid ACPI object.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_ACPI_FIND_PATH)(
//   IN    EFI_ACPI_HANDLE HandleIn,
//   IN    void            *AcpiPath,
//   OUT   EFI_ACPI_HANDLE *HandleOut
//   );

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_SDT_PROTOCOL
{
  ///
  /// A bit map containing all the ACPI versions supported by this protocol.
  ///
  public EFI_ACPI_TABLE_VERSION AcpiVersion;
  public readonly delegate* unmanaged</* IN */ulong /*Index*/,/* OUT */EFI_ACPI_SDT_HEADER** /*Table*/,/* OUT */EFI_ACPI_TABLE_VERSION* /*Version*/,/* OUT */ulong* /*TableKey*/, EFI_STATUS> /*EFI_ACPI_GET_ACPI_TABLE2*/ GetAcpiTable;
  
  //public readonly delegate* unmanaged</* IN */bool /*Register*/,/* IN */EFI_ACPI_NOTIFICATION_FN /*Notification*/, EFI_STATUS> /*EFI_ACPI_REGISTER_NOTIFY*/ RegisterNotify;
  public void* RegisterNotify;

  public readonly delegate* unmanaged</* IN */void* /*Buffer*/,/* OUT */EFI_ACPI_HANDLE* /*Handle*/, EFI_STATUS> /*EFI_ACPI_OPEN*/ Open;
  public readonly delegate* unmanaged</* IN */ulong /*TableKey*/,/* OUT */EFI_ACPI_HANDLE* /*Handle*/, EFI_STATUS> /*EFI_ACPI_OPEN_SDT*/ OpenSdt;
  public readonly delegate* unmanaged</* IN */EFI_ACPI_HANDLE /*Handle*/, EFI_STATUS> /*EFI_ACPI_CLOSE*/ Close;
  public readonly delegate* unmanaged</* IN */EFI_ACPI_HANDLE /*ParentHandle*/,/* IN OUT */EFI_ACPI_HANDLE* /*Handle*/, EFI_STATUS> /*EFI_ACPI_GET_CHILD*/ GetChild;
  public readonly delegate* unmanaged</* IN */EFI_ACPI_HANDLE /*Handle*/,/* IN */ulong /*Index*/,/* OUT */EFI_ACPI_DATA_TYPE* /*DataType*/,/* OUTCONST */ void*,/* OUT */ulong* /*DataSize*/, EFI_STATUS> /*EFI_ACPI_GET_OPTION*/ GetOption;
  public readonly delegate* unmanaged</* IN */EFI_ACPI_HANDLE /*Handle*/,/* IN */ulong /*Index*/,/* IN CONST */void* /*Data*/,/* IN */ulong /*DataSize*/, EFI_STATUS> /*EFI_ACPI_SET_OPTION*/ SetOption;
  public readonly delegate* unmanaged</* IN */EFI_ACPI_HANDLE /*HandleIn*/,/* IN */void* /*AcpiPath*/,/* OUT */EFI_ACPI_HANDLE* /*HandleOut*/, EFI_STATUS> /*EFI_ACPI_FIND_PATH*/ FindPath;
}

// extern EFI_GUID  gEfiAcpiSdtProtocolGuid;

// #endif // __ACPI_SYSTEM_DESCRIPTION_TABLE_H___
