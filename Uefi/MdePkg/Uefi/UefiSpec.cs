using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Include file that supports UEFI.

  This include file must contain things defined in the UEFI 2.7 specification.
  If a code construct is defined in the UEFI 2.7 specification it must be included
  by this include file.

Copyright (c) 2006 - 2021, Intel Corporation. All rights reserved.<BR>
Portions Copyright (c) 2020, Hewlett Packard Enterprise Development LP. All rights reserved.<BR>
Copyright (c) 2022, Loongson Technology Corporation Limited. All rights reserved.<BR>

SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __UEFI_SPEC_H__
// #define __UEFI_SPEC_H__

// #include <Uefi/UefiMultiPhase.h>

// #include <Protocol/DevicePath.h>
// #include <Protocol/SimpleTextIn.h>
// #include <Protocol/SimpleTextInEx.h>
// #include <Protocol/SimpleTextOut.h>

///
/// Enumeration of EFI memory allocation types.
///
public enum EFI_ALLOCATE_TYPE
{
  ///
  /// Allocate any available range of pages that satisfies the request.
  ///
  AllocateAnyPages,
  ///
  /// Allocate any available range of pages whose uppermost address is less than
  /// or equal to a specified maximum address.
  ///
  AllocateMaxAddress,
  ///
  /// Allocate pages at a specified address.
  ///
  AllocateAddress,
  ///
  /// Maximum enumeration value that may be used for bounds checking.
  ///
  MaxAllocateType
}

public unsafe partial class EFI
{
  //
  // Bit definitions for EFI_TIME.Daylight
  //
  public const ulong EFI_TIME_ADJUST_DAYLIGHT = 0x01;
  public const ulong EFI_TIME_IN_DAYLIGHT = 0x02;

  ///
  /// Value definition for EFI_TIME.TimeZone.
  ///
  public const ulong EFI_UNSPECIFIED_TIMEZONE = 0x07FF;

  //
  // Memory cacheability attributes
  //
  public const ulong EFI_MEMORY_UC = 0x0000000000000001;
  public const ulong EFI_MEMORY_WC = 0x0000000000000002;
  public const ulong EFI_MEMORY_WT = 0x0000000000000004;
  public const ulong EFI_MEMORY_WB = 0x0000000000000008;
  public const ulong EFI_MEMORY_UCE = 0x0000000000000010;
  //
  // Physical memory protection attributes
  //
  // Note: UEFI spec 2.5 and following: use EFI_MEMORY_RO as write-protected physical memory
  // protection attribute. Also, EFI_MEMORY_WP means cacheability attribute.
  //
  public const ulong EFI_MEMORY_WP = 0x0000000000001000;
  public const ulong EFI_MEMORY_RP = 0x0000000000002000;
  public const ulong EFI_MEMORY_XP = 0x0000000000004000;
  public const ulong EFI_MEMORY_RO = 0x0000000000020000;
  //
  // Physical memory persistence attribute.
  // The memory region supports byte-addressable non-volatility.
  //
  public const ulong EFI_MEMORY_NV = 0x0000000000008000;
  //
  // The memory region provides higher reliability relative to other memory in the system.
  // If all memory has the same reliability, then this bit is not used.
  //
  public const ulong EFI_MEMORY_MORE_RELIABLE = 0x0000000000010000;

  //
  // Note: UEFI spec 2.8 and following:
  //
  // Specific-purpose memory (SPM). The memory is earmarked for
  // specific purposes such as for specific device drivers or applications.
  // The SPM attribute serves as a hint to the OS to avoid allocating this
  // memory for core OS data or code that can not be relocated.
  //
  public const ulong EFI_MEMORY_SP = 0x0000000000040000;
  //
  // If this flag is set, the memory region is capable of being
  // protected with the CPU's memory cryptographic
  // capabilities. If this flag is clear, the memory region is not
  // capable of being protected with the CPU's memory
  // cryptographic capabilities or the CPU does not support CPU
  // memory cryptographic capabilities.
  //
  public const ulong EFI_MEMORY_CPU_CRYPTO = 0x0000000000080000;

  //
  // Runtime memory attribute
  //
  public const ulong EFI_MEMORY_RUNTIME = 0x8000000000000000;

  //
  // Attributes bitmasks, grouped by type
  //
  public const ulong EFI_CACHE_ATTRIBUTE_MASK = (EFI_MEMORY_UC | EFI_MEMORY_WC | EFI_MEMORY_WT | EFI_MEMORY_WB | EFI_MEMORY_UCE | EFI_MEMORY_WP);
  public const ulong EFI_MEMORY_ACCESS_MASK = (EFI_MEMORY_RP | EFI_MEMORY_XP | EFI_MEMORY_RO);
  public const ulong EFI_MEMORY_ATTRIBUTE_MASK = (EFI_MEMORY_ACCESS_MASK | EFI_MEMORY_SP | EFI_MEMORY_CPU_CRYPTO);

  ///
  /// Memory descriptor version number.
  ///
  public const ulong EFI_MEMORY_DESCRIPTOR_VERSION = 1;
}

///
/// Definition of an EFI memory descriptor.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MEMORY_DESCRIPTOR
{
  ///
  /// Type of the memory region.
  /// Type EFI_MEMORY_TYPE is defined in the
  /// AllocatePages() function description.
  ///
  public uint Type;
  ///
  /// Physical address of the first byte in the memory region. PhysicalStart must be
  /// aligned on a 4 KiB boundary, and must not be above 0xfffffffffffff000. Type
  /// EFI_PHYSICAL_ADDRESS is defined in the AllocatePages() function description
  ///
  public EFI_PHYSICAL_ADDRESS PhysicalStart;
  ///
  /// Virtual address of the first byte in the memory region.
  /// VirtualStart must be aligned on a 4 KiB boundary,
  /// and must not be above 0xfffffffffffff000.
  ///
  public EFI_VIRTUAL_ADDRESS VirtualStart;
  ///
  /// NumberOfPagesNumber of 4 KiB pages in the memory region.
  /// NumberOfPages must not be 0, and must not be any value
  /// that would represent a memory page with a start address,
  /// either physical or virtual, above 0xfffffffffffff000.
  ///
  public ulong NumberOfPages;
  ///
  /// Attributes of the memory region that describe the bit mask of capabilities
  /// for that memory region, and not necessarily the current settings for that
  /// memory region.
  ///
  public ulong Attribute;
}


public unsafe partial class EFI
{
  //
  // ConvertPointer DebugDisposition type.
  //
  public const ulong EFI_OPTIONAL_PTR = 0x00000001;

  //
  // These types can be ORed together as needed - for example,
  // EVT_TIMER might be Ored with EVT_NOTIFY_WAIT or
  // EVT_NOTIFY_SIGNAL.
  //
  public const ulong EVT_TIMER = 0x80000000;
  public const ulong EVT_RUNTIME = 0x40000000;
  public const ulong EVT_NOTIFY_WAIT = 0x00000100;
  public const ulong EVT_NOTIFY_SIGNAL = 0x00000200;

  public const ulong EVT_SIGNAL_EXIT_BOOT_SERVICES = 0x00000201;
  public const ulong EVT_SIGNAL_VIRTUAL_ADDRESS_CHANGE = 0x60000202;

  //
  // The event's NotifyContext pointer points to a runtime memory
  // address.
  // The event is deprecated in UEFI2.0 and later specifications.
  //
  public const ulong EVT_RUNTIME_CONTEXT = 0x20000000;
}

///
/// Timer delay types
///
public enum EFI_TIMER_DELAY
{
  ///
  /// An event's timer settings is to be cancelled and not trigger time is to be set/
  ///
  TimerCancel,
  ///
  /// An event is to be signaled periodically at a specified interval from the current time.
  ///
  TimerPeriodic,
  ///
  /// An event is to be signaled once at a specified interval from the current time.
  ///
  TimerRelative
}

public unsafe partial class EFI
{
  //
  // Task priority level
  //
  public const ulong TPL_APPLICATION = 4;
  public const ulong TPL_CALLBACK = 8;
  public const ulong TPL_NOTIFY = 16;
  public const ulong TPL_HIGH_LEVEL = 31;
}

///
/// This provides the capabilities of the
/// real time clock device as exposed through the EFI interfaces.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TIME_CAPABILITIES
{
  ///
  /// Provides the reporting resolution of the real-time clock device in
  /// counts per second. For a normal PC-AT CMOS RTC device, this
  /// value would be 1 Hz, or 1, to indicate that the device only reports
  /// the time to the resolution of 1 second.
  ///
  public uint Resolution;
  ///
  /// Provides the timekeeping accuracy of the real-time clock in an
  /// error rate of 1E-6 parts per million. For a clock with an accuracy
  /// of 50 parts per million, the value in this field would be
  /// 50,000,000.
  ///
  public uint Accuracy;
  ///
  /// A TRUE indicates that a time set operation clears the device's
  /// time below the Resolution reporting level. A FALSE
  /// indicates that the state below the Resolution level of the
  /// device is not cleared when the time is set. Normal PC-AT CMOS
  /// RTC devices set this value to FALSE.
  ///
  public bool SetsToZero;
}

///
/// Enumeration of EFI Interface Types
///
public enum EFI_INTERFACE_TYPE
{
  ///
  /// Indicates that the supplied protocol interface is supplied in native form.
  ///
  EFI_NATIVE_INTERFACE
}

public unsafe partial class EFI
{
  public const ulong EFI_OPEN_PROTOCOL_BY_HANDLE_PROTOCOL = 0x00000001;
  public const ulong EFI_OPEN_PROTOCOL_GET_PROTOCOL = 0x00000002;
  public const ulong EFI_OPEN_PROTOCOL_TEST_PROTOCOL = 0x00000004;
  public const ulong EFI_OPEN_PROTOCOL_BY_CHILD_CONTROLLER = 0x00000008;
  public const ulong EFI_OPEN_PROTOCOL_BY_DRIVER = 0x00000010;
  public const ulong EFI_OPEN_PROTOCOL_EXCLUSIVE = 0x00000020;
}

///
/// EFI Oprn Protocol Information Entry
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_OPEN_PROTOCOL_INFORMATION_ENTRY
{
  public EFI_HANDLE AgentHandle;
  public EFI_HANDLE ControllerHandle;
  public uint Attributes;
  public uint OpenCount;
}

///
/// Enumeration of EFI Locate Search Types
///
public enum EFI_LOCATE_SEARCH_TYPE
{
  ///
  /// Retrieve all the handles in the handle database.
  ///
  AllHandles,
  ///
  /// Retrieve the next handle fron a RegisterProtocolNotify() event.
  ///
  ByRegisterNotify,
  ///
  /// Retrieve the set of handles from the handle database that support a
  /// specified protocol.
  ///
  ByProtocol
}

///
/// EFI Capsule Block Descriptor
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_CAPSULE_BLOCK_DESCRIPTOR
{
  ///
  /// Length in bytes of the data pointed to by DataBlock/ContinuationPointer.
  ///
  [FieldOffset(0)]
  public ulong Length;
  ///
  /// Physical address of the data block. This member of the union is
  /// used if Length is not equal to zero.
  ///
  [FieldOffset(8)]
  public EFI_PHYSICAL_ADDRESS DataBlock;
  ///
  /// Physical address of another block of
  /// EFI_CAPSULE_BLOCK_DESCRIPTOR structures. This
  /// member of the union is used if Length is equal to zero. If
  /// ContinuationPointer is zero this entry represents the end of the list.
  ///
  [FieldOffset(8)]
  public EFI_PHYSICAL_ADDRESS ContinuationPointer;
}

///
/// EFI Capsule Header.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CAPSULE_HEADER
{
  ///
  /// A GUID that defines the contents of a capsule.
  ///
  public EFI_GUID CapsuleGuid;
  ///
  /// The size of the capsule header. This may be larger than the size of
  /// the EFI_CAPSULE_HEADER since CapsuleGuid may imply
  /// extended header entries
  ///
  public uint HeaderSize;
  ///
  /// Bit-mapped list describing the capsule attributes. The Flag values
  /// of 0x0000 - 0xFFFF are defined by CapsuleGuid. Flag values
  /// of 0x10000 - 0xFFFFFFFF are defined by this specification
  ///
  public uint Flags;
  ///
  /// Size in bytes of the capsule.
  ///
  public uint CapsuleImageSize;
}

///
/// The EFI System Table entry must point to an array of capsules
/// that contain the same CapsuleGuid value. The array must be
/// prefixed by a uint that represents the size of the array of capsules.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CAPSULE_TABLE
{
  ///
  /// the size of the array of capsules.
  ///
  public uint CapsuleArrayNumber;
  ///
  /// Point to an array of capsules that contain the same CapsuleGuid value.
  ///
  public void* CapsulePtr;
}

public unsafe partial class EFI
{
  public const ulong CAPSULE_FLAGS_PERSIST_ACROSS_RESET = 0x00010000;
  public const ulong CAPSULE_FLAGS_POPULATE_SYSTEM_TABLE = 0x00020000;
  public const ulong CAPSULE_FLAGS_INITIATE_RESET = 0x00040000;

  //
  // Firmware should stop at a firmware user interface on next boot
  //
  public const ulong EFI_OS_INDICATIONS_BOOT_TO_FW_UI = 0x0000000000000001;
  public const ulong EFI_OS_INDICATIONS_TIMESTAMP_REVOCATION = 0x0000000000000002;
  public const ulong EFI_OS_INDICATIONS_FILE_CAPSULE_DELIVERY_SUPPORTED = 0x0000000000000004;
  public const ulong EFI_OS_INDICATIONS_FMP_CAPSULE_SUPPORTED = 0x0000000000000008;
  public const ulong EFI_OS_INDICATIONS_CAPSULE_RESULT_VAR_SUPPORTED = 0x0000000000000010;
  public const ulong EFI_OS_INDICATIONS_START_PLATFORM_RECOVERY = 0x0000000000000040;
  public const ulong EFI_OS_INDICATIONS_JSON_CONFIG_DATA_REFRESH = 0x0000000000000080;

  //
  // EFI Runtime Services Table
  //
  //public const ulong EFI_SYSTEM_TABLE_SIGNATURE = SIGNATURE_64('I', 'B', 'I', ' ', 'S', 'Y', 'S', 'T');
  public const ulong EFI_2_80_SYSTEM_TABLE_REVISION = ((2 << 16) | (80));
  public const ulong EFI_2_70_SYSTEM_TABLE_REVISION = ((2 << 16) | (70));
  public const ulong EFI_2_60_SYSTEM_TABLE_REVISION = ((2 << 16) | (60));
  public const ulong EFI_2_50_SYSTEM_TABLE_REVISION = ((2 << 16) | (50));
  public const ulong EFI_2_40_SYSTEM_TABLE_REVISION = ((2 << 16) | (40));
  public const ulong EFI_2_31_SYSTEM_TABLE_REVISION = ((2 << 16) | (31));
  public const ulong EFI_2_30_SYSTEM_TABLE_REVISION = ((2 << 16) | (30));
  public const ulong EFI_2_20_SYSTEM_TABLE_REVISION = ((2 << 16) | (20));
  public const ulong EFI_2_10_SYSTEM_TABLE_REVISION = ((2 << 16) | (10));
  public const ulong EFI_2_00_SYSTEM_TABLE_REVISION = ((2 << 16) | (00));
  public const ulong EFI_1_10_SYSTEM_TABLE_REVISION = ((1 << 16) | (10));
  public const ulong EFI_1_02_SYSTEM_TABLE_REVISION = ((1 << 16) | (02));
  public const ulong EFI_SYSTEM_TABLE_REVISION = EFI_2_70_SYSTEM_TABLE_REVISION;
  public const ulong EFI_SPECIFICATION_VERSION = EFI_SYSTEM_TABLE_REVISION;

  //public const ulong EFI_RUNTIME_SERVICES_SIGNATURE = SIGNATURE_64('R', 'U', 'N', 'T', 'S', 'E', 'R', 'V');
  public const ulong EFI_RUNTIME_SERVICES_REVISION = EFI_SPECIFICATION_VERSION;
}

///
/// EFI Runtime Services Table.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_RUNTIME_SERVICES
{
  ///
  /// The table header for the EFI Runtime Services Table.
  ///
  public EFI_TABLE_HEADER Hdr;

  //
  // Time Services
  //
  /**
    Returns the current time and date information, and the time-keeping capabilities
    of the hardware platform.

    @param[out]  Time             A pointer to storage to receive a snapshot of the current time.
    @param[out]  Capabilities     An optional pointer to a buffer to receive the real time clock
                                  device's capabilities.

    @retval EFI_SUCCESS           The operation completed successfully.
    @retval EFI_INVALID_PARAMETER Time is NULL.
    @retval EFI_DEVICE_ERROR      The time could not be retrieved due to hardware error.

  **/
  public readonly delegate* unmanaged<EFI_TIME*, EFI_TIME_CAPABILITIES*, EFI_STATUS> GetTime;
  /**
    Sets the current local time and date information.

    @param[in]  Time              A pointer to the current time.

    @retval EFI_SUCCESS           The operation completed successfully.
    @retval EFI_INVALID_PARAMETER A time field is out of range.
    @retval EFI_DEVICE_ERROR      The time could not be set due due to hardware error.

  **/
  public readonly delegate* unmanaged<EFI_TIME*, EFI_STATUS> SetTime;
  /**
    Returns the current wakeup alarm clock setting.

    @param[out]  Enabled          Indicates if the alarm is currently enabled or disabled.
    @param[out]  Pending          Indicates if the alarm signal is pending and requires acknowledgement.
    @param[out]  Time             The current alarm setting.

    @retval EFI_SUCCESS           The alarm settings were returned.
    @retval EFI_INVALID_PARAMETER Enabled is NULL.
    @retval EFI_INVALID_PARAMETER Pending is NULL.
    @retval EFI_INVALID_PARAMETER Time is NULL.
    @retval EFI_DEVICE_ERROR      The wakeup time could not be retrieved due to a hardware error.
    @retval EFI_UNSUPPORTED       A wakeup timer is not supported on this platform.

  **/
  public readonly delegate* unmanaged<bool*, bool*, EFI_TIME*, EFI_STATUS> GetWakeupTime;
  /**
    Sets the system wakeup alarm clock time.

    @param[in]  Enable            Enable or disable the wakeup alarm.
    @param[in]  Time              If Enable is TRUE, the time to set the wakeup alarm for.
                                  If Enable is FALSE, then this parameter is optional, and may be NULL.

    @retval EFI_SUCCESS           If Enable is TRUE, then the wakeup alarm was enabled. If
                                  Enable is FALSE, then the wakeup alarm was disabled.
    @retval EFI_INVALID_PARAMETER A time field is out of range.
    @retval EFI_DEVICE_ERROR      The wakeup time could not be set due to a hardware error.
    @retval EFI_UNSUPPORTED       A wakeup timer is not supported on this platform.

  **/
  public readonly delegate* unmanaged<bool, EFI_TIME*, EFI_STATUS> SetWakeupTime;

  //
  // Virtual Memory Services
  //
  /**
    Changes the runtime addressing mode of EFI firmware from physical to virtual.

    @param[in]  MemoryMapSize     The size in bytes of VirtualMap.
    @param[in]  DescriptorSize    The size in bytes of an entry in the VirtualMap.
    @param[in]  DescriptorVersion The version of the structure entries in VirtualMap.
    @param[in]  VirtualMap        An array of memory descriptors which contain new virtual
                                  address mapping information for all runtime ranges.

    @retval EFI_SUCCESS           The virtual address map has been applied.
    @retval EFI_UNSUPPORTED       EFI firmware is not at runtime, or the EFI firmware is already in
                                  virtual address mapped mode.
    @retval EFI_INVALID_PARAMETER DescriptorSize or DescriptorVersion is invalid.
    @retval EFI_NO_MAPPING        A virtual address was not supplied for a range in the memory
                                  map that requires a mapping.
    @retval EFI_NOT_FOUND         A virtual address was supplied for an address that is not found
                                  in the memory map.

  **/
  public readonly delegate* unmanaged<ulong, ulong, uint, EFI_MEMORY_DESCRIPTOR*, EFI_STATUS> SetVirtualAddressMap;
  /**
    Determines the new virtual address that is to be used on subsequent memory accesses.

    @param[in]       DebugDisposition  Supplies type information for the pointer being converted.
    @param[in, out]  Address           A pointer to a pointer that is to be fixed to be the value needed
                                       for the new virtual address mappings being applied.

    @retval EFI_SUCCESS           The pointer pointed to by Address was modified.
    @retval EFI_INVALID_PARAMETER 1) Address is NULL.
                                  2) *Address is NULL and DebugDisposition does
                                  not have the EFI_OPTIONAL_PTR bit set.
    @retval EFI_NOT_FOUND         The pointer pointed to by Address was not found to be part
                                  of the current memory map. This is normally fatal.

  **/
  public readonly delegate* unmanaged<ulong, void**, EFI_STATUS> ConvertPointer;

  //
  // Variable Services
  //
  /**
    Returns the value of a variable.

    @param[in]       VariableName  A Null-terminated string that is the name of the vendor's
                                   variable.
    @param[in]       VendorGuid    A unique identifier for the vendor.
    @param[out]      Attributes    If not NULL, a pointer to the memory location to return the
                                   attributes bitmask for the variable.
    @param[in, out]  DataSize      On input, the size in bytes of the return Data buffer.
                                   On output the size of data returned in Data.
    @param[out]      Data          The buffer to return the contents of the variable. May be NULL
                                   with a zero DataSize in order to determine the size buffer needed.

    @retval EFI_SUCCESS            The function completed successfully.
    @retval EFI_NOT_FOUND          The variable was not found.
    @retval EFI_BUFFER_TOO_SMALL   The DataSize is too small for the result.
    @retval EFI_INVALID_PARAMETER  VariableName is NULL.
    @retval EFI_INVALID_PARAMETER  VendorGuid is NULL.
    @retval EFI_INVALID_PARAMETER  DataSize is NULL.
    @retval EFI_INVALID_PARAMETER  The DataSize is not too small and Data is NULL.
    @retval EFI_DEVICE_ERROR       The variable could not be retrieved due to a hardware error.
    @retval EFI_SECURITY_VIOLATION The variable could not be retrieved due to an authentication failure.

  **/
  public readonly delegate* unmanaged<char*, EFI_GUID*, uint*, ulong*, void*, EFI_STATUS> GetVariable;
  /**
    Enumerates the current variable names.

    @param[in, out]  VariableNameSize The size of the VariableName buffer. The size must be large
                                      enough to fit input string supplied in VariableName buffer.
    @param[in, out]  VariableName     On input, supplies the last VariableName that was returned
                                      by GetNextVariableName(). On output, returns the Nullterminated
                                      string of the current variable.
    @param[in, out]  VendorGuid       On input, supplies the last VendorGuid that was returned by
                                      GetNextVariableName(). On output, returns the
                                      VendorGuid of the current variable.

    @retval EFI_SUCCESS           The function completed successfully.
    @retval EFI_NOT_FOUND         The next variable was not found.
    @retval EFI_BUFFER_TOO_SMALL  The VariableNameSize is too small for the result.
                                  VariableNameSize has been updated with the size needed to complete the request.
    @retval EFI_INVALID_PARAMETER VariableNameSize is NULL.
    @retval EFI_INVALID_PARAMETER VariableName is NULL.
    @retval EFI_INVALID_PARAMETER VendorGuid is NULL.
    @retval EFI_INVALID_PARAMETER The input values of VariableName and VendorGuid are not a name and
                                  GUID of an existing variable.
    @retval EFI_INVALID_PARAMETER Null-terminator is not found in the first VariableNameSize bytes of
                                  the input VariableName buffer.
    @retval EFI_DEVICE_ERROR      The variable could not be retrieved due to a hardware error.

  **/
  public readonly delegate* unmanaged<ulong*, char*, EFI_GUID*, EFI_STATUS> GetNextVariableName;
  /**
    Sets the value of a variable.

    @param[in]  VariableName       A Null-terminated string that is the name of the vendor's variable.
                                   Each VariableName is unique for each VendorGuid. VariableName must
                                   contain 1 or more characters. If VariableName is an empty string,
                                   then EFI_INVALID_PARAMETER is returned.
    @param[in]  VendorGuid         A unique identifier for the vendor.
    @param[in]  Attributes         Attributes bitmask to set for the variable.
    @param[in]  DataSize           The size in bytes of the Data buffer. Unless the EFI_VARIABLE_APPEND_WRITE or
                                   EFI_VARIABLE_TIME_BASED_AUTHENTICATED_WRITE_ACCESS attribute is set, a size of zero
                                   causes the variable to be deleted. When the EFI_VARIABLE_APPEND_WRITE attribute is
                                   set, then a SetVariable() call with a DataSize of zero will not cause any change to
                                   the variable value (the timestamp associated with the variable may be updated however
                                   even if no new data value is provided,see the description of the
                                   EFI_VARIABLE_AUTHENTICATION_2 descriptor below. In this case the DataSize will not
                                   be zero since the EFI_VARIABLE_AUTHENTICATION_2 descriptor will be populated).
    @param[in]  Data               The contents for the variable.

    @retval EFI_SUCCESS            The firmware has successfully stored the variable and its data as
                                   defined by the Attributes.
    @retval EFI_INVALID_PARAMETER  An invalid combination of attribute bits, name, and GUID was supplied, or the
                                   DataSize exceeds the maximum allowed.
    @retval EFI_INVALID_PARAMETER  VariableName is an empty string.
    @retval EFI_OUT_OF_RESOURCES   Not enough storage is available to hold the variable and its data.
    @retval EFI_DEVICE_ERROR       The variable could not be retrieved due to a hardware error.
    @retval EFI_WRITE_PROTECTED    The variable in question is read-only.
    @retval EFI_WRITE_PROTECTED    The variable in question cannot be deleted.
    @retval EFI_SECURITY_VIOLATION The variable could not be written due to EFI_VARIABLE_TIME_BASED_AUTHENTICATED_WRITE_ACESS being set,
                                   but the AuthInfo does NOT pass the validation check carried out by the firmware.

    @retval EFI_NOT_FOUND          The variable trying to be updated or deleted was not found.

  **/
  public readonly delegate* unmanaged<char*, EFI_GUID*, uint, ulong, void*, EFI_STATUS> SetVariable;

  //
  // Miscellaneous Services
  //
  /**
    Returns the next high 32 bits of the platform's monotonic counter.

    @param[out]  HighCount        The pointer to returned value.

    @retval EFI_SUCCESS           The next high monotonic count was returned.
    @retval EFI_INVALID_PARAMETER HighCount is NULL.
    @retval EFI_DEVICE_ERROR      The device is not functioning properly.

  **/
  public readonly delegate* unmanaged<uint*, EFI_STATUS> GetNextHighMonotonicCount;
  /**
    Resets the entire platform.

    @param[in]  ResetType         The type of reset to perform.
    @param[in]  ResetStatus       The status code for the reset.
    @param[in]  DataSize          The size, in bytes, of ResetData.
    @param[in]  ResetData         For a ResetType of EfiResetCold, EfiResetWarm, or
                                  EfiResetShutdown the data buffer starts with a Null-terminated
                                  string, optionally followed by additional binary data.
                                  The string is a description that the caller may use to further
                                  indicate the reason for the system reset.
                                  For a ResetType of EfiResetPlatformSpecific the data buffer
                                  also starts with a Null-terminated string that is followed
                                  by an EFI_GUID that describes the specific type of reset to perform.
  **/
  public readonly delegate* unmanaged<EFI_RESET_TYPE, EFI_STATUS, ulong, void*, EFI_STATUS> ResetSystem;

  //
  // UEFI 2.0 Capsule Services
  //
  /**
    Passes capsules to the firmware with both virtual and physical mapping. Depending on the intended
    consumption, the firmware may process the capsule immediately. If the payload should persist
    across a system reset, the reset value returned from EFI_QueryCapsuleCapabilities must
    be passed into ResetSystem() and will cause the capsule to be processed by the firmware as
    part of the reset process.

    @param[in]  CapsuleHeaderArray Virtual pointer to an array of virtual pointers to the capsules
                                   being passed into update capsule.
    @param[in]  CapsuleCount       Number of pointers to EFI_CAPSULE_HEADER in
                                   CaspuleHeaderArray.
    @param[in]  ScatterGatherList  Physical pointer to a set of
                                   EFI_CAPSULE_BLOCK_DESCRIPTOR that describes the
                                   location in physical memory of a set of capsules.

    @retval EFI_SUCCESS           Valid capsule was passed. If
                                  CAPSULE_FLAGS_PERSIT_ACROSS_RESET is not set, the
                                  capsule has been successfully processed by the firmware.
    @retval EFI_INVALID_PARAMETER CapsuleSize is NULL, or an incompatible set of flags were
                                  set in the capsule header.
    @retval EFI_INVALID_PARAMETER CapsuleCount is 0.
    @retval EFI_DEVICE_ERROR      The capsule update was started, but failed due to a device error.
    @retval EFI_UNSUPPORTED       The capsule type is not supported on this platform.
    @retval EFI_OUT_OF_RESOURCES  When ExitBootServices() has been previously called this error indicates the capsule
                                  is compatible with this platform but is not capable of being submitted or processed
                                  in runtime. The caller may resubmit the capsule prior to ExitBootServices().
    @retval EFI_OUT_OF_RESOURCES  When ExitBootServices() has not been previously called then this error indicates
                                  the capsule is compatible with this platform but there are insufficient resources to process.

  **/
  public readonly delegate* unmanaged<EFI_CAPSULE_HEADER**, ulong, EFI_PHYSICAL_ADDRESS, EFI_STATUS> UpdateCapsule;
  /**
    Returns if the capsule can be supported via UpdateCapsule().

    @param[in]   CapsuleHeaderArray  Virtual pointer to an array of virtual pointers to the capsules
                                     being passed into update capsule.
    @param[in]   CapsuleCount        Number of pointers to EFI_CAPSULE_HEADER in
                                     CaspuleHeaderArray.
    @param[out]  MaxiumCapsuleSize   On output the maximum size that UpdateCapsule() can
                                     support as an argument to UpdateCapsule() via
                                     CapsuleHeaderArray and ScatterGatherList.
    @param[out]  ResetType           Returns the type of reset required for the capsule update.

    @retval EFI_SUCCESS           Valid answer returned.
    @retval EFI_UNSUPPORTED       The capsule type is not supported on this platform, and
                                  MaximumCapsuleSize and ResetType are undefined.
    @retval EFI_INVALID_PARAMETER MaximumCapsuleSize is NULL.
    @retval EFI_OUT_OF_RESOURCES  When ExitBootServices() has been previously called this error indicates the capsule
                                  is compatible with this platform but is not capable of being submitted or processed
                                  in runtime. The caller may resubmit the capsule prior to ExitBootServices().
    @retval EFI_OUT_OF_RESOURCES  When ExitBootServices() has not been previously called then this error indicates
                                  the capsule is compatible with this platform but there are insufficient resources to process.

  **/
  public readonly delegate* unmanaged<EFI_CAPSULE_HEADER**, ulong, ulong*, EFI_RESET_TYPE*, EFI_STATUS> QueryCapsuleCapabilities;

  //
  // Miscellaneous UEFI 2.0 Service
  //
  /**
    Returns information about the EFI variables.

    @param[in]   Attributes                   Attributes bitmask to specify the type of variables on
                                              which to return information.
    @param[out]  MaximumVariableStorageSize   On output the maximum size of the storage space
                                              available for the EFI variables associated with the
                                              attributes specified.
    @param[out]  RemainingVariableStorageSize Returns the remaining size of the storage space
                                              available for the EFI variables associated with the
                                              attributes specified.
    @param[out]  MaximumVariableSize          Returns the maximum size of the individual EFI
                                              variables associated with the attributes specified.

    @retval EFI_SUCCESS                  Valid answer returned.
    @retval EFI_INVALID_PARAMETER        An invalid combination of attribute bits was supplied
    @retval EFI_UNSUPPORTED              The attribute is not supported on this platform, and the
                                         MaximumVariableStorageSize,
                                         RemainingVariableStorageSize, MaximumVariableSize
                                         are undefined.

  **/
  public readonly delegate* unmanaged<uint, ulong*, ulong*, ulong*, EFI_STATUS> QueryVariableInfo;
}

public unsafe partial class EFI
{
  //public const ulong EFI_BOOT_SERVICES_SIGNATURE = SIGNATURE_64('B', 'O', 'O', 'T', 'S', 'E', 'R', 'V');
  public const ulong EFI_BOOT_SERVICES_REVISION = EFI_SPECIFICATION_VERSION;
}

///
/// EFI Boot Services Table.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BOOT_SERVICES
{
  ///
  /// The table header for the EFI Boot Services Table.
  ///
  public EFI_TABLE_HEADER Hdr;

  //
  // Task Priority Services
  //
  /**
    Raises a task's priority level and returns its previous level.

    @param[in]  NewTpl          The new task priority level.

    @return Previous task priority level

  **/
  public readonly delegate* unmanaged<EFI_TPL, EFI_STATUS> RaiseTPL;
  /**
    Restores a task's priority level to its previous value.

    @param[in]  OldTpl          The previous task priority level to restore.

  **/
  public readonly delegate* unmanaged<EFI_TPL, EFI_STATUS> RestoreTPL;

  //
  // Memory Services
  //
  /**
    Allocates memory pages from the system.

    @param[in]       Type         The type of allocation to perform.
    @param[in]       MemoryType   The type of memory to allocate.
                                  MemoryType values in the range 0x70000000..0x7FFFFFFF
                                  are reserved for OEM use. MemoryType values in the range
                                  0x80000000..0xFFFFFFFF are reserved for use by UEFI OS loaders
                                  that are provided by operating system vendors.
    @param[in]       Pages        The number of contiguous 4 KB pages to allocate.
    @param[in, out]  Memory       The pointer to a physical address. On input, the way in which the address is
                                  used depends on the value of Type.

    @retval EFI_SUCCESS           The requested pages were allocated.
    @retval EFI_INVALID_PARAMETER 1) Type is not AllocateAnyPages or
                                  AllocateMaxAddress or AllocateAddress.
                                  2) MemoryType is in the range
                                  EfiMaxMemoryType..0x6FFFFFFF.
                                  3) Memory is NULL.
                                  4) MemoryType is EfiPersistentMemory.
    @retval EFI_OUT_OF_RESOURCES  The pages could not be allocated.
    @retval EFI_NOT_FOUND         The requested pages could not be found.

  **/
  public readonly delegate* unmanaged<EFI_ALLOCATE_TYPE, EFI_MEMORY_TYPE, ulong, EFI_PHYSICAL_ADDRESS*, EFI_STATUS> AllocatePages;
  /**
    Frees memory pages.

    @param[in]  Memory      The base physical address of the pages to be freed.
    @param[in]  Pages       The number of contiguous 4 KB pages to free.

    @retval EFI_SUCCESS           The requested pages were freed.
    @retval EFI_INVALID_PARAMETER Memory is not a page-aligned address or Pages is invalid.
    @retval EFI_NOT_FOUND         The requested memory pages were not allocated with
                                  AllocatePages().

  **/
  public readonly delegate* unmanaged<EFI_PHYSICAL_ADDRESS, ulong, EFI_STATUS> FreePages;
  /**
    Returns the current memory map.

    @param[in, out]  MemoryMapSize         A pointer to the size, in bytes, of the MemoryMap buffer.
                                           On input, this is the size of the buffer allocated by the caller.
                                           On output, it is the size of the buffer returned by the firmware if
                                           the buffer was large enough, or the size of the buffer needed to contain
                                           the map if the buffer was too small.
    @param[out]      MemoryMap             A pointer to the buffer in which firmware places the current memory
                                           map.
    @param[out]      MapKey                A pointer to the location in which firmware returns the key for the
                                           current memory map.
    @param[out]      DescriptorSize        A pointer to the location in which firmware returns the size, in bytes, of
                                           an individual EFI_MEMORY_DESCRIPTOR.
    @param[out]      DescriptorVersion     A pointer to the location in which firmware returns the version number
                                           associated with the EFI_MEMORY_DESCRIPTOR.

    @retval EFI_SUCCESS           The memory map was returned in the MemoryMap buffer.
    @retval EFI_BUFFER_TOO_SMALL  The MemoryMap buffer was too small. The current buffer size
                                  needed to hold the memory map is returned in MemoryMapSize.
    @retval EFI_INVALID_PARAMETER 1) MemoryMapSize is NULL.
                                  2) The MemoryMap buffer is not too small and MemoryMap is
                                     NULL.

  **/
  public readonly delegate* unmanaged<ulong*, EFI_MEMORY_DESCRIPTOR*, ulong*, ulong*, uint*, EFI_STATUS> GetMemoryMap;
  /**
    Allocates pool memory.

    @param[in]   PoolType         The type of pool to allocate.
                                  MemoryType values in the range 0x70000000..0x7FFFFFFF
                                  are reserved for OEM use. MemoryType values in the range
                                  0x80000000..0xFFFFFFFF are reserved for use by UEFI OS loaders
                                  that are provided by operating system vendors.
    @param[in]   Size             The number of bytes to allocate from the pool.
    @param[out]  Buffer           A pointer to a pointer to the allocated buffer if the call succeeds;
                                  undefined otherwise.

    @retval EFI_SUCCESS           The requested number of bytes was allocated.
    @retval EFI_OUT_OF_RESOURCES  The pool requested could not be allocated.
    @retval EFI_INVALID_PARAMETER Buffer is NULL.
                                  PoolType is in the range EfiMaxMemoryType..0x6FFFFFFF.
                                  PoolType is EfiPersistentMemory.

  **/
  public readonly delegate* unmanaged<EFI_MEMORY_TYPE, ulong, void**, EFI_STATUS> AllocatePool;
  /**
    Returns pool memory to the system.

    @param[in]  Buffer            The pointer to the buffer to free.

    @retval EFI_SUCCESS           The memory was returned to the system.
    @retval EFI_INVALID_PARAMETER Buffer was invalid.

  **/
  public readonly delegate* unmanaged<void*, EFI_STATUS> FreePool;

  //
  // Event & Timer Services
  //
  /**
    Creates an event.

    @param[in]   Type             The type of event to create and its mode and attributes.
    @param[in]   NotifyTpl        The task priority level of event notifications, if needed.
    @param[in]   NotifyFunction   The pointer to the event's notification function, if any.
    @param[in]   NotifyContext    The pointer to the notification function's context; corresponds to parameter
                                  Context in the notification function.
    @param[out]  Event            The pointer to the newly created event if the call succeeds; undefined
                                  otherwise.

    @retval EFI_SUCCESS           The event structure was created.
    @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
    @retval EFI_OUT_OF_RESOURCES  The event could not be allocated.

  **/
  //public readonly delegate* unmanaged<uint, EFI_TPL, EFI_EVENT_NOTIFY, void*, EFI_EVENT*, EFI_STATUS> CreateEvent;
  /**
    Sets the type of timer and the trigger time for a timer event.

    @param[in]  Event             The timer event that is to be signaled at the specified time.
    @param[in]  Type              The type of time that is specified in TriggerTime.
    @param[in]  TriggerTime       The number of 100ns units until the timer expires.
                                  A TriggerTime of 0 is legal.
                                  If Type is TimerRelative and TriggerTime is 0, then the timer
                                  event will be signaled on the next timer tick.
                                  If Type is TimerPeriodic and TriggerTime is 0, then the timer
                                  event will be signaled on every timer tick.

    @retval EFI_SUCCESS           The event has been set to be signaled at the requested time.
    @retval EFI_INVALID_PARAMETER Event or Type is not valid.

  **/
  public readonly delegate* unmanaged<EFI_EVENT, EFI_TIMER_DELAY, ulong, EFI_STATUS> SetTimer;
  /**
    Stops execution until an event is signaled.

    @param[in]   NumberOfEvents   The number of events in the Event array.
    @param[in]   Event            An array of EFI_EVENT.
    @param[out]  Index            The pointer to the index of the event which satisfied the wait condition.

    @retval EFI_SUCCESS           The event indicated by Index was signaled.
    @retval EFI_INVALID_PARAMETER 1) NumberOfEvents is 0.
                                  2) The event indicated by Index is of type
                                     EVT_NOTIFY_SIGNAL.
    @retval EFI_UNSUPPORTED       The current TPL is not TPL_APPLICATION.

  **/
  public readonly delegate* unmanaged<ulong, EFI_EVENT*, ulong*, EFI_STATUS> WaitForEvent;
  /**
    Signals an event.

    @param[in]  Event             The event to signal.

    @retval EFI_SUCCESS           The event has been signaled.

  **/
  public readonly delegate* unmanaged<EFI_EVENT, EFI_STATUS> SignalEvent;
  /**
    Closes an event.

    @param[in]  Event             The event to close.

    @retval EFI_SUCCESS           The event has been closed.

  **/
  public readonly delegate* unmanaged<EFI_EVENT, EFI_STATUS> CloseEvent;
  /**
    Checks whether an event is in the signaled state.

    @param[in]  Event             The event to check.

    @retval EFI_SUCCESS           The event is in the signaled state.
    @retval EFI_NOT_READY         The event is not in the signaled state.
    @retval EFI_INVALID_PARAMETER Event is of type EVT_NOTIFY_SIGNAL.

  **/
  public readonly delegate* unmanaged<EFI_EVENT, EFI_STATUS> CheckEvent;

  //
  // Protocol Handler Services
  //
  /**
    Installs a protocol interface on a device handle. If the handle does not exist, it is created and added
    to the list of handles in the system. InstallMultipleProtocolInterfaces() performs
    more error checking than InstallProtocolInterface(), so it is recommended that
    InstallMultipleProtocolInterfaces() be used in place of
    InstallProtocolInterface()

    @param[in, out]  Handle         A pointer to the EFI_HANDLE on which the interface is to be installed.
    @param[in]       Protocol       The numeric ID of the protocol interface.
    @param[in]       InterfaceType  Indicates whether Interface is supplied in native form.
    @param[in]       Interface      A pointer to the protocol interface.

    @retval EFI_SUCCESS           The protocol interface was installed.
    @retval EFI_OUT_OF_RESOURCES  Space for a new handle could not be allocated.
    @retval EFI_INVALID_PARAMETER Handle is NULL.
    @retval EFI_INVALID_PARAMETER Protocol is NULL.
    @retval EFI_INVALID_PARAMETER InterfaceType is not EFI_NATIVE_INTERFACE.
    @retval EFI_INVALID_PARAMETER Protocol is already installed on the handle specified by Handle.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE*, EFI_GUID*, EFI_INTERFACE_TYPE, void*, EFI_STATUS> InstallProtocolInterface;
  /**
    Reinstalls a protocol interface on a device handle.

    @param[in]  Handle            Handle on which the interface is to be reinstalled.
    @param[in]  Protocol          The numeric ID of the interface.
    @param[in]  OldInterface      A pointer to the old interface. NULL can be used if a structure is not
                                  associated with Protocol.
    @param[in]  NewInterface      A pointer to the new interface.

    @retval EFI_SUCCESS           The protocol interface was reinstalled.
    @retval EFI_NOT_FOUND         The OldInterface on the handle was not found.
    @retval EFI_ACCESS_DENIED     The protocol interface could not be reinstalled,
                                  because OldInterface is still being used by a
                                  driver that will not release it.
    @retval EFI_INVALID_PARAMETER Handle is NULL.
    @retval EFI_INVALID_PARAMETER Protocol is NULL.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_GUID*, void*, void*, EFI_STATUS> ReinstallProtocolInterface;
  /**
    Removes a protocol interface from a device handle. It is recommended that
    UninstallMultipleProtocolInterfaces() be used in place of
    UninstallProtocolInterface().

    @param[in]  Handle            The handle on which the interface was installed.
    @param[in]  Protocol          The numeric ID of the interface.
    @param[in]  Interface         A pointer to the interface.

    @retval EFI_SUCCESS           The interface was removed.
    @retval EFI_NOT_FOUND         The interface was not found.
    @retval EFI_ACCESS_DENIED     The interface was not removed because the interface
                                  is still being used by a driver.
    @retval EFI_INVALID_PARAMETER Handle is NULL.
    @retval EFI_INVALID_PARAMETER Protocol is NULL.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_GUID*, void*, EFI_STATUS> UninstallProtocolInterface;
  /**
    Queries a handle to determine if it supports a specified protocol.

    @param[in]   Handle           The handle being queried.
    @param[in]   Protocol         The published unique identifier of the protocol.
    @param[out]  Interface        Supplies the address where a pointer to the corresponding Protocol
                                  Interface is returned.

    @retval EFI_SUCCESS           The interface information for the specified protocol was returned.
    @retval EFI_UNSUPPORTED       The device does not support the specified protocol.
    @retval EFI_INVALID_PARAMETER Handle is NULL.
    @retval EFI_INVALID_PARAMETER Protocol is NULL.
    @retval EFI_INVALID_PARAMETER Interface is NULL.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_GUID*, void**, EFI_STATUS> HandleProtocol;
  public void* Reserved;
  /**
    Creates an event that is to be signaled whenever an interface is installed for a specified protocol.

    @param[in]   Protocol         The numeric ID of the protocol for which the event is to be registered.
    @param[in]   Event            Event that is to be signaled whenever a protocol interface is registered
                                  for Protocol.
    @param[out]  Registration     A pointer to a memory location to receive the registration value.

    @retval EFI_SUCCESS           The notification event has been registered.
    @retval EFI_OUT_OF_RESOURCES  Space for the notification event could not be allocated.
    @retval EFI_INVALID_PARAMETER Protocol is NULL.
    @retval EFI_INVALID_PARAMETER Event is NULL.
    @retval EFI_INVALID_PARAMETER Registration is NULL.

  **/
  public readonly delegate* unmanaged<EFI_GUID*, EFI_EVENT, void**, EFI_STATUS> RegisterProtocolNotify;
  /**
    Returns an array of handles that support a specified protocol.

    @param[in]       SearchType   Specifies which handle(s) are to be returned.
    @param[in]       Protocol     Specifies the protocol to search by.
    @param[in]       SearchKey    Specifies the search key.
    @param[in, out]  BufferSize   On input, the size in bytes of Buffer. On output, the size in bytes of
                                  the array returned in Buffer (if the buffer was large enough) or the
                                  size, in bytes, of the buffer needed to obtain the array (if the buffer was
                                  not large enough).
    @param[out]      Buffer       The buffer in which the array is returned.

    @retval EFI_SUCCESS           The array of handles was returned.
    @retval EFI_NOT_FOUND         No handles match the search.
    @retval EFI_BUFFER_TOO_SMALL  The BufferSize is too small for the result.
    @retval EFI_INVALID_PARAMETER SearchType is not a member of EFI_LOCATE_SEARCH_TYPE.
    @retval EFI_INVALID_PARAMETER SearchType is ByRegisterNotify and SearchKey is NULL.
    @retval EFI_INVALID_PARAMETER SearchType is ByProtocol and Protocol is NULL.
    @retval EFI_INVALID_PARAMETER One or more matches are found and BufferSize is NULL.
    @retval EFI_INVALID_PARAMETER BufferSize is large enough for the result and Buffer is NULL.

  **/
  public readonly delegate* unmanaged<EFI_LOCATE_SEARCH_TYPE, EFI_GUID*, void*, ulong*, EFI_HANDLE*, EFI_STATUS> LocateHandle;
  /**
    Locates the handle to a device on the device path that supports the specified protocol.

    @param[in]       Protocol     Specifies the protocol to search for.
    @param[in, out]  DevicePath   On input, a pointer to a pointer to the device path. On output, the device
                                  path pointer is modified to point to the remaining part of the device
                                  path.
    @param[out]      Device       A pointer to the returned device handle.

    @retval EFI_SUCCESS           The resulting handle was returned.
    @retval EFI_NOT_FOUND         No handles match the search.
    @retval EFI_INVALID_PARAMETER Protocol is NULL.
    @retval EFI_INVALID_PARAMETER DevicePath is NULL.
    @retval EFI_INVALID_PARAMETER A handle matched the search and Device is NULL.

  **/
  public readonly delegate* unmanaged<EFI_GUID*, EFI_DEVICE_PATH_PROTOCOL**, EFI_HANDLE*, EFI_STATUS> LocateDevicePath;
  /**
    Adds, updates, or removes a configuration table entry from the EFI System Table.

    @param[in]  Guid              A pointer to the GUID for the entry to add, update, or remove.
    @param[in]  Table             A pointer to the configuration table for the entry to add, update, or
                                  remove. May be NULL.

    @retval EFI_SUCCESS           The (Guid, Table) pair was added, updated, or removed.
    @retval EFI_NOT_FOUND         An attempt was made to delete a nonexistent entry.
    @retval EFI_INVALID_PARAMETER Guid is NULL.
    @retval EFI_OUT_OF_RESOURCES  There is not enough memory available to complete the operation.

  **/
  public readonly delegate* unmanaged<EFI_GUID*, void*, EFI_STATUS> InstallConfigurationTable;

  //
  // Image Services
  //
  /**
    Loads an EFI image into memory.

    @param[in]   BootPolicy        If TRUE, indicates that the request originates from the boot
                                   manager, and that the boot manager is attempting to load
                                   FilePath as a boot selection. Ignored if SourceBuffer is
                                   not NULL.
    @param[in]   ParentImageHandle The caller's image handle.
    @param[in]   DevicePath        The DeviceHandle specific file path from which the image is
                                   loaded.
    @param[in]   SourceBuffer      If not NULL, a pointer to the memory location containing a copy
                                   of the image to be loaded.
    @param[in]   SourceSize        The size in bytes of SourceBuffer. Ignored if SourceBuffer is NULL.
    @param[out]  ImageHandle       The pointer to the returned image handle that is created when the
                                   image is successfully loaded.

    @retval EFI_SUCCESS            Image was loaded into memory correctly.
    @retval EFI_NOT_FOUND          Both SourceBuffer and DevicePath are NULL.
    @retval EFI_INVALID_PARAMETER  One or more parametes are invalid.
    @retval EFI_UNSUPPORTED        The image type is not supported.
    @retval EFI_OUT_OF_RESOURCES   Image was not loaded due to insufficient resources.
    @retval EFI_LOAD_ERROR         Image was not loaded because the image format was corrupt or not
                                   understood.
    @retval EFI_DEVICE_ERROR       Image was not loaded because the device returned a read error.
    @retval EFI_ACCESS_DENIED      Image was not loaded because the platform policy prohibits the
                                   image from being loaded. NULL is returned in *ImageHandle.
    @retval EFI_SECURITY_VIOLATION Image was loaded and an ImageHandle was created with a
                                   valid EFI_LOADED_IMAGE_PROTOCOL. However, the current
                                   platform policy specifies that the image should not be started.
  **/
  public readonly delegate* unmanaged<bool, EFI_HANDLE, EFI_DEVICE_PATH_PROTOCOL*, void*, ulong, EFI_HANDLE*, EFI_STATUS> LoadImage;
  /**
    Transfers control to a loaded image's entry point.

    @param[in]   ImageHandle       Handle of image to be started.
    @param[out]  ExitDataSize      The pointer to the size, in bytes, of ExitData.
    @param[out]  ExitData          The pointer to a pointer to a data buffer that includes a Null-terminated
                                   string, optionally followed by additional binary data.

    @retval EFI_INVALID_PARAMETER  ImageHandle is either an invalid image handle or the image
                                   has already been initialized with StartImage.
    @retval EFI_SECURITY_VIOLATION The current platform policy specifies that the image should not be started.
    @return Exit code from image

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, ulong*, char**, EFI_STATUS> StartImage;
  /**
    Terminates a loaded EFI image and returns control to boot services.

    @param[in]  ImageHandle       Handle that identifies the image. This parameter is passed to the
                                  image on entry.
    @param[in]  ExitStatus        The image's exit code.
    @param[in]  ExitDataSize      The size, in bytes, of ExitData. Ignored if ExitStatus is EFI_SUCCESS.
    @param[in]  ExitData          The pointer to a data buffer that includes a Null-terminated string,
                                  optionally followed by additional binary data. The string is a
                                  description that the caller may use to further indicate the reason
                                  for the image's exit. ExitData is only valid if ExitStatus
                                  is something other than EFI_SUCCESS. The ExitData buffer
                                  must be allocated by calling AllocatePool().

    @retval EFI_SUCCESS           The image specified by ImageHandle was unloaded.
    @retval EFI_INVALID_PARAMETER The image specified by ImageHandle has been loaded and
                                  started with LoadImage() and StartImage(), but the
                                  image is not the currently executing image.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_STATUS, ulong, char*, EFI_STATUS> Exit;
  /**
    Unloads an image.

    @param[in]  ImageHandle       Handle that identifies the image to be unloaded.

    @retval EFI_SUCCESS           The image has been unloaded.
    @retval EFI_INVALID_PARAMETER ImageHandle is not a valid image handle.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_STATUS> UnloadImage;
  /**
    Terminates all boot services.

    @param[in]  ImageHandle       Handle that identifies the exiting image.
    @param[in]  MapKey            Key to the latest memory map.

    @retval EFI_SUCCESS           Boot services have been terminated.
    @retval EFI_INVALID_PARAMETER MapKey is incorrect.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, ulong, EFI_STATUS> ExitBootServices;

  //
  // Miscellaneous Services
  //
  /**
    Returns a monotonically increasing count for the platform.

    @param[out]  Count            The pointer to returned value.

    @retval EFI_SUCCESS           The next monotonic count was returned.
    @retval EFI_INVALID_PARAMETER Count is NULL.
    @retval EFI_DEVICE_ERROR      The device is not functioning properly.

  **/
  public readonly delegate* unmanaged<ulong*, EFI_STATUS> GetNextMonotonicCount;
  /**
    Induces a fine-grained stall.

    @param[in]  Microseconds      The number of microseconds to stall execution.

    @retval EFI_SUCCESS           Execution was stalled at least the requested number of
                                  Microseconds.

  **/
  public readonly delegate* unmanaged<ulong, EFI_STATUS> Stall;
  /**
    Sets the system's watchdog timer.

    @param[in]  Timeout           The number of seconds to set the watchdog timer to.
    @param[in]  WatchdogCode      The numeric code to log on a watchdog timer timeout event.
    @param[in]  DataSize          The size, in bytes, of WatchdogData.
    @param[in]  WatchdogData      A data buffer that includes a Null-terminated string, optionally
                                  followed by additional binary data.

    @retval EFI_SUCCESS           The timeout has been set.
    @retval EFI_INVALID_PARAMETER The supplied WatchdogCode is invalid.
    @retval EFI_UNSUPPORTED       The system does not have a watchdog timer.
    @retval EFI_DEVICE_ERROR      The watchdog timer could not be programmed due to a hardware
                                  error.

  **/
  public readonly delegate* unmanaged<ulong, ulong, ulong, char*, EFI_STATUS> SetWatchdogTimer;

  //
  // DriverSupport Services
  //
  /**
    Connects one or more drivers to a controller.

    @param[in]  ControllerHandle      The handle of the controller to which driver(s) are to be connected.
    @param[in]  DriverImageHandle     A pointer to an ordered list handles that support the
                                      EFI_DRIVER_BINDING_PROTOCOL.
    @param[in]  RemainingDevicePath   A pointer to the device path that specifies a child of the
                                      controller specified by ControllerHandle.
    @param[in]  Recursive             If TRUE, then ConnectController() is called recursively
                                      until the entire tree of controllers below the controller specified
                                      by ControllerHandle have been created. If FALSE, then
                                      the tree of controllers is only expanded one level.

    @retval EFI_SUCCESS           1) One or more drivers were connected to ControllerHandle.
                                  2) No drivers were connected to ControllerHandle, but
                                  RemainingDevicePath is not NULL, and it is an End Device
                                  Path Node.
    @retval EFI_INVALID_PARAMETER ControllerHandle is NULL.
    @retval EFI_NOT_FOUND         1) There are no EFI_DRIVER_BINDING_PROTOCOL instances
                                  present in the system.
                                  2) No drivers were connected to ControllerHandle.
    @retval EFI_SECURITY_VIOLATION
                                  The user has no permission to start UEFI device drivers on the device path
                                  associated with the ControllerHandle or specified by the RemainingDevicePath.
  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_HANDLE*, EFI_DEVICE_PATH_PROTOCOL*, bool, EFI_STATUS> ConnectController;
  /**
    Disconnects one or more drivers from a controller.

    @param[in]  ControllerHandle      The handle of the controller from which driver(s) are to be disconnected.
    @param[in]  DriverImageHandle     The driver to disconnect from ControllerHandle.
                                      If DriverImageHandle is NULL, then all the drivers currently managing
                                      ControllerHandle are disconnected from ControllerHandle.
    @param[in]  ChildHandle           The handle of the child to destroy.
                                      If ChildHandle is NULL, then all the children of ControllerHandle are
                                      destroyed before the drivers are disconnected from ControllerHandle.

    @retval EFI_SUCCESS           1) One or more drivers were disconnected from the controller.
                                  2) On entry, no drivers are managing ControllerHandle.
                                  3) DriverImageHandle is not NULL, and on entry
                                     DriverImageHandle is not managing ControllerHandle.
    @retval EFI_INVALID_PARAMETER 1) ControllerHandle is NULL.
                                  2) DriverImageHandle is not NULL, and it is not a valid EFI_HANDLE.
                                  3) ChildHandle is not NULL, and it is not a valid EFI_HANDLE.
                                  4) DriverImageHandle does not support the EFI_DRIVER_BINDING_PROTOCOL.
    @retval EFI_OUT_OF_RESOURCES  There are not enough resources available to disconnect any drivers from
                                  ControllerHandle.
    @retval EFI_DEVICE_ERROR      The controller could not be disconnected because of a device error.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_HANDLE, EFI_HANDLE, EFI_STATUS> DisconnectController;

  //
  // Open and Close Protocol Services
  //
  /**
    Queries a handle to determine if it supports a specified protocol. If the protocol is supported by the
    handle, it opens the protocol on behalf of the calling agent.

    @param[in]   Handle           The handle for the protocol interface that is being opened.
    @param[in]   Protocol         The published unique identifier of the protocol.
    @param[out]  Interface        Supplies the address where a pointer to the corresponding Protocol
                                  Interface is returned.
    @param[in]   AgentHandle      The handle of the agent that is opening the protocol interface
                                  specified by Protocol and Interface.
    @param[in]   ControllerHandle If the agent that is opening a protocol is a driver that follows the
                                  UEFI Driver Model, then this parameter is the controller handle
                                  that requires the protocol interface. If the agent does not follow
                                  the UEFI Driver Model, then this parameter is optional and may
                                  be NULL.
    @param[in]   Attributes       The open mode of the protocol interface specified by Handle
                                  and Protocol.

    @retval EFI_SUCCESS           An item was added to the open list for the protocol interface, and the
                                  protocol interface was returned in Interface.
    @retval EFI_UNSUPPORTED       Handle does not support Protocol.
    @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
    @retval EFI_ACCESS_DENIED     Required attributes can't be supported in current environment.
    @retval EFI_ALREADY_STARTED   Item on the open list already has requierd attributes whose agent
                                  handle is the same as AgentHandle.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_GUID*, void**, EFI_HANDLE, EFI_HANDLE, uint, EFI_STATUS> OpenProtocol;
  /**
    Closes a protocol on a handle that was opened using OpenProtocol().

    @param[in]  Handle            The handle for the protocol interface that was previously opened
                                  with OpenProtocol(), and is now being closed.
    @param[in]  Protocol          The published unique identifier of the protocol.
    @param[in]  AgentHandle       The handle of the agent that is closing the protocol interface.
    @param[in]  ControllerHandle  If the agent that opened a protocol is a driver that follows the
                                  UEFI Driver Model, then this parameter is the controller handle
                                  that required the protocol interface.

    @retval EFI_SUCCESS           The protocol instance was closed.
    @retval EFI_INVALID_PARAMETER 1) Handle is NULL.
                                  2) AgentHandle is NULL.
                                  3) ControllerHandle is not NULL and ControllerHandle is not a valid EFI_HANDLE.
                                  4) Protocol is NULL.
    @retval EFI_NOT_FOUND         1) Handle does not support the protocol specified by Protocol.
                                  2) The protocol interface specified by Handle and Protocol is not
                                     currently open by AgentHandle and ControllerHandle.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_GUID*, EFI_HANDLE, EFI_HANDLE, EFI_STATUS> CloseProtocol;
  /**
    Retrieves the list of agents that currently have a protocol interface opened.

    @param[in]   Handle           The handle for the protocol interface that is being queried.
    @param[in]   Protocol         The published unique identifier of the protocol.
    @param[out]  EntryBuffer      A pointer to a buffer of open protocol information in the form of
                                  EFI_OPEN_PROTOCOL_INFORMATION_ENTRY structures.
    @param[out]  EntryCount       A pointer to the number of entries in EntryBuffer.

    @retval EFI_SUCCESS           The open protocol information was returned in EntryBuffer, and the
                                  number of entries was returned EntryCount.
    @retval EFI_OUT_OF_RESOURCES  There are not enough resources available to allocate EntryBuffer.
    @retval EFI_NOT_FOUND         Handle does not support the protocol specified by Protocol.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_GUID*, EFI_OPEN_PROTOCOL_INFORMATION_ENTRY**, ulong*, EFI_STATUS> OpenProtocolInformation;

  //
  // Library Services
  //
  /**
    Retrieves the list of protocol interface GUIDs that are installed on a handle in a buffer allocated
    from pool.

    @param[in]   Handle              The handle from which to retrieve the list of protocol interface
                                     GUIDs.
    @param[out]  ProtocolBuffer      A pointer to the list of protocol interface GUID pointers that are
                                     installed on Handle.
    @param[out]  ProtocolBufferCount A pointer to the number of GUID pointers present in
                                     ProtocolBuffer.

    @retval EFI_SUCCESS           The list of protocol interface GUIDs installed on Handle was returned in
                                  ProtocolBuffer. The number of protocol interface GUIDs was
                                  returned in ProtocolBufferCount.
    @retval EFI_OUT_OF_RESOURCES  There is not enough pool memory to store the results.
    @retval EFI_INVALID_PARAMETER Handle is NULL.
    @retval EFI_INVALID_PARAMETER Handle is not a valid EFI_HANDLE.
    @retval EFI_INVALID_PARAMETER ProtocolBuffer is NULL.
    @retval EFI_INVALID_PARAMETER ProtocolBufferCount is NULL.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_GUID***, ulong*, EFI_STATUS> ProtocolsPerHandle;
  /**
    Returns an array of handles that support the requested protocol in a buffer allocated from pool.

    @param[in]       SearchType   Specifies which handle(s) are to be returned.
    @param[in]       Protocol     Provides the protocol to search by.
                                  This parameter is only valid for a SearchType of ByProtocol.
    @param[in]       SearchKey    Supplies the search key depending on the SearchType.
    @param[out]      NoHandles    The number of handles returned in Buffer.
    @param[out]      Buffer       A pointer to the buffer to return the requested array of handles that
                                  support Protocol.

    @retval EFI_SUCCESS           The array of handles was returned in Buffer, and the number of
                                  handles in Buffer was returned in NoHandles.
    @retval EFI_NOT_FOUND         No handles match the search.
    @retval EFI_OUT_OF_RESOURCES  There is not enough pool memory to store the matching results.
    @retval EFI_INVALID_PARAMETER NoHandles is NULL.
    @retval EFI_INVALID_PARAMETER Buffer is NULL.

  **/
  public readonly delegate* unmanaged<EFI_LOCATE_SEARCH_TYPE, EFI_GUID*, void*, ulong*, EFI_HANDLE**, EFI_STATUS> LocateHandleBuffer;
  /**
    Returns the first protocol instance that matches the given protocol.

    @param[in]  Protocol          Provides the protocol to search for.
    @param[in]  Registration      Optional registration key returned from
                                  RegisterProtocolNotify().
    @param[out]  Interface        On return, a pointer to the first interface that matches Protocol and
                                  Registration.

    @retval EFI_SUCCESS           A protocol instance matching Protocol was found and returned in
                                  Interface.
    @retval EFI_NOT_FOUND         No protocol instances were found that match Protocol and
                                  Registration.
    @retval EFI_INVALID_PARAMETER Interface is NULL.
                                  Protocol is NULL.

  **/
  public readonly delegate* unmanaged<EFI_GUID*, void*, void**, EFI_STATUS> LocateProtocol;
  /**
    Installs one or more protocol interfaces into the boot services environment.

    @param[in, out]  Handle       The pointer to a handle to install the new protocol interfaces on,
                                  or a pointer to NULL if a new handle is to be allocated.
    @param  ...                   A variable argument list containing pairs of protocol GUIDs and protocol
                                  interfaces.

    @retval EFI_SUCCESS           All the protocol interface was installed.
    @retval EFI_OUT_OF_RESOURCES  There was not enough memory in pool to install all the protocols.
    @retval EFI_ALREADY_STARTED   A Device Path Protocol instance was passed in that is already present in
                                  the handle database.
    @retval EFI_INVALID_PARAMETER Handle is NULL.
    @retval EFI_INVALID_PARAMETER Protocol is already installed on the handle specified by Handle.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE*, EFI_STATUS> InstallMultipleProtocolInterfaces;
  /**
    Removes one or more protocol interfaces into the boot services environment.

    @param[in]  Handle            The handle to remove the protocol interfaces from.
    @param  ...                   A variable argument list containing pairs of protocol GUIDs and
                                  protocol interfaces.

    @retval EFI_SUCCESS           All the protocol interfaces were removed.
    @retval EFI_INVALID_PARAMETER One of the protocol interfaces was not previously installed on Handle.

  **/
  public readonly delegate* unmanaged<EFI_HANDLE, EFI_STATUS> UninstallMultipleProtocolInterfaces;

  //
  // 32-bit CRC Services
  //
  /**
    Computes and returns a 32-bit CRC for a data buffer.

    @param[in]   Data             A pointer to the buffer on which the 32-bit CRC is to be computed.
    @param[in]   DataSize         The number of bytes in the buffer Data.
    @param[out]  Crc32            The 32-bit CRC that was computed for the data buffer specified by Data
                                  and DataSize.

    @retval EFI_SUCCESS           The 32-bit CRC was computed for the data buffer and returned in
                                  Crc32.
    @retval EFI_INVALID_PARAMETER Data is NULL.
    @retval EFI_INVALID_PARAMETER Crc32 is NULL.
    @retval EFI_INVALID_PARAMETER DataSize is 0.

  **/
  public readonly delegate* unmanaged<void*, ulong, uint*, EFI_STATUS> CalculateCrc32;

  //
  // Miscellaneous Services
  //
  /**
    Copies the contents of one buffer to another buffer.

    @param[in]  Destination       The pointer to the destination buffer of the memory copy.
    @param[in]  Source            The pointer to the source buffer of the memory copy.
    @param[in]  Length            Number of bytes to copy from Source to Destination.

  **/
  public readonly delegate* unmanaged<void*, void*, ulong, EFI_STATUS> CopyMem;
  /**
    The SetMem() function fills a buffer with a specified value.

    @param[in]  Buffer            The pointer to the buffer to fill.
    @param[in]  Size              Number of bytes in Buffer to fill.
    @param[in]  Value             Value to fill Buffer with.

  **/
  public readonly delegate* unmanaged<void*, ulong, byte, EFI_STATUS> SetMem;
  /**
    Creates an event in a group.

    @param[in]   Type             The type of event to create and its mode and attributes.
    @param[in]   NotifyTpl        The task priority level of event notifications,if needed.
    @param[in]   NotifyFunction   The pointer to the event's notification function, if any.
    @param[in]   NotifyContext    The pointer to the notification function's context; corresponds to parameter
                                  Context in the notification function.
    @param[in]   EventGroup       The pointer to the unique identifier of the group to which this event belongs.
                                  If this is NULL, then the function behaves as if the parameters were passed
                                  to CreateEvent.
    @param[out]  Event            The pointer to the newly created event if the call succeeds; undefined
                                  otherwise.

    @retval EFI_SUCCESS           The event structure was created.
    @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
    @retval EFI_OUT_OF_RESOURCES  The event could not be allocated.

  **/
  //public readonly delegate* unmanaged<uint, EFI_TPL, EFI_EVENT_NOTIFY, CONST, CONST, EFI_EVENT*, EFI_STATUS> CreateEventEx;
}

///
/// Contains a set of GUID/pointer pairs comprised of the ConfigurationTable field in the
/// EFI System Table.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_CONFIGURATION_TABLE
{
  ///
  /// The 128-bit GUID value that uniquely identifies the system configuration table.
  ///
  public EFI_GUID VendorGuid;
  ///
  /// A pointer to the table associated with VendorGuid.
  ///
  public void* VendorTable;
}

///
/// EFI System Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SYSTEM_TABLE
{
  ///
  /// The table header for the EFI System Table.
  ///
  public EFI_TABLE_HEADER Hdr;
  ///
  /// A pointer to a null terminated string that identifies the vendor
  /// that produces the system firmware for the platform.
  ///
  public char* FirmwareVendor;
  ///
  /// A firmware vendor specific value that identifies the revision
  /// of the system firmware for the platform.
  ///
  public uint FirmwareRevision;
  ///
  /// The handle for the active console input device. This handle must support
  /// EFI_SIMPLE_TEXT_INPUT_PROTOCOL and EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL.
  ///
  public EFI_HANDLE ConsoleInHandle;
  ///
  /// A pointer to the EFI_SIMPLE_TEXT_INPUT_PROTOCOL interface that is
  /// associated with ConsoleInHandle.
  ///
  public EFI_SIMPLE_TEXT_INPUT_PROTOCOL* ConIn;
  ///
  /// The handle for the active console output device.
  ///
  public EFI_HANDLE ConsoleOutHandle;
  ///
  /// A pointer to the EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL interface
  /// that is associated with ConsoleOutHandle.
  ///
  public EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* ConOut;
  ///
  /// The handle for the active standard error console device.
  /// This handle must support the EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL.
  ///
  public EFI_HANDLE StandardErrorHandle;
  ///
  /// A pointer to the EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL interface
  /// that is associated with StandardErrorHandle.
  ///
  public EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* StdErr;
  ///
  /// A pointer to the EFI Runtime Services Table.
  ///
  public EFI_RUNTIME_SERVICES* RuntimeServices;
  ///
  /// A pointer to the EFI Boot Services Table.
  ///
  public EFI_BOOT_SERVICES* BootServices;
  ///
  /// The number of system configuration tables in the buffer ConfigurationTable.
  ///
  public ulong NumberOfTableEntries;
  ///
  /// A pointer to the system configuration tables.
  /// The number of entries in the table is NumberOfTableEntries.
  ///
  public EFI_CONFIGURATION_TABLE* ConfigurationTable;
}

/**
  This is the declaration of an EFI image entry point. This entry point is
  the same for UEFI Applications, UEFI OS Loaders, and UEFI Drivers including
  both device drivers and bus drivers.

  @param[in]  ImageHandle       The firmware allocated handle for the UEFI image.
  @param[in]  SystemTable       A pointer to the EFI System Table.

  @retval EFI_SUCCESS           The operation completed successfully.
  @retval Others                An unexpected error occurred.
**/
//typedef
//EFI_STATUS
//(EFIAPI * EFI_IMAGE_ENTRY_POINT)(
//  IN  EFI_HANDLE                   ImageHandle,
//  IN  EFI_SYSTEM_TABLE * SystemTable
//  );

//
// EFI Load Option. This data structure describes format of UEFI boot option variables.
//
// NOTE: EFI Load Option is a byte packed buffer of variable length fields.
// The first two fields have fixed length. They are declared as members of the
// EFI_LOAD_OPTION structure. All the other fields are variable length fields.
// They are listed in the comment block below for reference purposes.
//
// #pragma pack(1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LOAD_OPTION
{
  ///
  /// The attributes for this load option entry. All unused bits must be zero
  /// and are reserved by the UEFI specification for future growth.
  ///
  public uint Attributes;
  ///
  /// Length in bytes of the FilePathList. OptionalData starts at offset
  /// sizeof(UINT32) + sizeof(UINT16) + StrSize(Description) + FilePathListLength
  /// of the EFI_LOAD_OPTION descriptor.
  ///
  public ushort FilePathListLength;
  ///
  /// The user readable description for the load option.
  /// This field ends with a Null character.
  ///
  // char                        Description[];
  ///
  /// A packed array of UEFI device paths. The first element of the array is a
  /// device path that describes the device and location of the Image for this
  /// load option. The FilePathList[0] is specific to the device type. Other
  /// device paths may optionally exist in the FilePathList, but their usage is
  /// OSV specific. Each element in the array is variable length, and ends at
  /// the device path end structure. Because the size of Description is
  /// arbitrary, this data structure is not guaranteed to be aligned on a
  /// natural boundary. This data structure may have to be copied to an aligned
  /// natural boundary before it is used.
  ///
  // EFI_DEVICE_PATH_PROTOCOL      FilePathList[];
  ///
  /// The remaining bytes in the load option descriptor are a binary data buffer
  /// that is passed to the loaded image. If the field is zero bytes long, a
  /// NULL pointer is passed to the loaded image. The number of bytes in
  /// OptionalData can be computed by subtracting the starting offset of
  /// OptionalData from total size in bytes of the EFI_LOAD_OPTION.
  ///
  // byte                         OptionalData[];
}
// #pragma pack()

public unsafe partial class EFI
{
  //
  // EFI Load Options Attributes
  //
  public const ulong LOAD_OPTION_ACTIVE = 0x00000001;
  public const ulong LOAD_OPTION_FORCE_RECONNECT = 0x00000002;
  public const ulong LOAD_OPTION_HIDDEN = 0x00000008;
  public const ulong LOAD_OPTION_CATEGORY = 0x00001F00;

  public const ulong LOAD_OPTION_CATEGORY_BOOT = 0x00000000;
  public const ulong LOAD_OPTION_CATEGORY_APP = 0x00000100;

  public const ulong EFI_BOOT_OPTION_SUPPORT_KEY = 0x00000001;
  public const ulong EFI_BOOT_OPTION_SUPPORT_APP = 0x00000002;
  public const ulong EFI_BOOT_OPTION_SUPPORT_SYSPREP = 0x00000010;
  public const ulong EFI_BOOT_OPTION_SUPPORT_COUNT = 0x00000300;
}

///
/// EFI Boot Key Data
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_BOOT_KEY_DATA
{
  /////
  ///// Indicates the revision of the EFI_KEY_OPTION structure. This revision level should be 0.
  /////
  //[FieldOffset(0)]
  //public uint Revision = 8;
  /////
  ///// Either the left or right Shift keys must be pressed (1) or must not be pressed (0).
  /////
  //[FieldOffset(0)]
  //public uint ShiftPressed = 1;
  /////
  ///// Either the left or right Control keys must be pressed (1) or must not be pressed (0).
  /////
  //[FieldOffset(0)]
  //public uint ControlPressed = 1;
  /////
  ///// Either the left or right Alt keys must be pressed (1) or must not be pressed (0).
  /////
  //[FieldOffset(0)]
  //public uint AltPressed = 1;
  /////
  ///// Either the left or right Logo keys must be pressed (1) or must not be pressed (0).
  /////
  //[FieldOffset(0)]
  //public uint LogoPressed = 1;
  /////
  ///// The Menu key must be pressed (1) or must not be pressed (0).
  /////
  //[FieldOffset(0)]
  //public uint MenuPressed = 1;
  /////
  ///// The SysReq key must be pressed (1) or must not be pressed (0).
  /////
  //[FieldOffset(0)]
  //public uint SysReqPressed = 1;
  //[FieldOffset(0)]
  //public uint Reserved = 16;
  /////
  ///// Specifies the actual number of entries in EFI_KEY_OPTION.Keys, from 0-3. If
  ///// zero, then only the shift state is considered. If more than one, then the boot option will
  ///// only be launched if all of the specified keys are pressed with the same shift state.
  /////
  //[FieldOffset(0)]
  //public uint InputKeyCount = 2;

  [FieldOffset(4)]
  public uint PackedValue;
}

///
/// EFI Key Option.
///
// #pragma pack(1)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_KEY_OPTION
{
  ///
  /// Specifies options about how the key will be processed.
  ///
  public EFI_BOOT_KEY_DATA KeyData;
  ///
  /// The CRC-32 which should match the CRC-32 of the entire EFI_LOAD_OPTION to
  /// which BootOption refers. If the CRC-32s do not match this value, then this key
  /// option is ignored.
  ///
  public uint BootOptionCrc;
  ///
  /// The Boot#### option which will be invoked if this key is pressed and the boot option
  /// is active (LOAD_OPTION_ACTIVE is set).
  ///
  public ushort BootOption;
  ///
  /// The key codes to compare against those returned by the
  /// EFI_SIMPLE_TEXT_INPUT and EFI_SIMPLE_TEXT_INPUT_EX protocols.
  /// The number of key codes (0-3) is specified by the EFI_KEY_CODE_COUNT field in KeyOptions.
  ///
  // EFI_INPUT_KEY      Keys[];
}
// #pragma pack()

public unsafe partial class EFI
{
  //
  // EFI File location to boot from on removable media devices
  //
  public const string EFI_REMOVABLE_MEDIA_FILE_NAME_IA32 = "\\EFI\\BOOT\\BOOTIA32.EFI";
  public const string EFI_REMOVABLE_MEDIA_FILE_NAME_IA64 = "\\EFI\\BOOT\\BOOTIA64.EFI";
  public const string EFI_REMOVABLE_MEDIA_FILE_NAME_X64 = "\\EFI\\BOOT\\BOOTX64.EFI";
  public const string EFI_REMOVABLE_MEDIA_FILE_NAME_ARM = "\\EFI\\BOOT\\BOOTARM.EFI";
  public const string EFI_REMOVABLE_MEDIA_FILE_NAME_AARCH64 = "\\EFI\\BOOT\\BOOTAA64.EFI";
  public const string EFI_REMOVABLE_MEDIA_FILE_NAME_RISCV64 = "\\EFI\\BOOT\\BOOTRISCV64.EFI";
  public const string EFI_REMOVABLE_MEDIA_FILE_NAME_LOONGARCH64 = "\\EFI\\BOOT\\BOOTLOONGARCH64.EFI";
}

//#if !defined (EFI_REMOVABLE_MEDIA_FILE_NAME)
//#if defined (MDE_CPU_IA32)
//public const ulong EFI_REMOVABLE_MEDIA_FILE_NAME = EFI_REMOVABLE_MEDIA_FILE_NAME_IA32;
//#elif defined (MDE_CPU_X64)
//public const ulong EFI_REMOVABLE_MEDIA_FILE_NAME = EFI_REMOVABLE_MEDIA_FILE_NAME_X64;
//#elif defined (MDE_CPU_EBC)
//#elif defined (MDE_CPU_ARM)
//public const ulong EFI_REMOVABLE_MEDIA_FILE_NAME = EFI_REMOVABLE_MEDIA_FILE_NAME_ARM;
//#elif defined (MDE_CPU_AARCH64)
//public const ulong EFI_REMOVABLE_MEDIA_FILE_NAME = EFI_REMOVABLE_MEDIA_FILE_NAME_AARCH64;
//#elif defined (MDE_CPU_RISCV64)
//public const ulong EFI_REMOVABLE_MEDIA_FILE_NAME = EFI_REMOVABLE_MEDIA_FILE_NAME_RISCV64;
//#elif defined (MDE_CPU_LOONGARCH64)
//public const ulong EFI_REMOVABLE_MEDIA_FILE_NAME = EFI_REMOVABLE_MEDIA_FILE_NAME_LOONGARCH64;
//#else
//#error Unknown Processor Type
//#endif
// #endif

public unsafe partial class EFI
{
  //
  // The directory within the active EFI System Partition defined for delivery of capsule to firmware
  //
  public const string EFI_CAPSULE_FILE_DIRECTORY = "\\EFI\\UpdateCapsule\\";
}

// #include <Uefi/UefiPxe.h>
// #include <Uefi/UefiGpt.h>
// #include <Uefi/UefiInternalFormRepresentation.h>

// #endif
