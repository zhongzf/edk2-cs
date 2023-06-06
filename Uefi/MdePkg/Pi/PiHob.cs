using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  HOB related definitions in PI.

Copyright (c) 2006 - 2017, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  PI Version 1.6

**/

// #ifndef __PI_HOB_H__
// #define __PI_HOB_H__

public unsafe partial class EFI
{
  //
  // HobType of EFI_HOB_GENERIC_HEADER.
  //
  public const ulong EFI_HOB_TYPE_HANDOFF = 0x0001;
  public const ulong EFI_HOB_TYPE_MEMORY_ALLOCATION = 0x0002;
  public const ulong EFI_HOB_TYPE_RESOURCE_DESCRIPTOR = 0x0003;
  public const ulong EFI_HOB_TYPE_GUID_EXTENSION = 0x0004;
  public const ulong EFI_HOB_TYPE_FV = 0x0005;
  public const ulong EFI_HOB_TYPE_CPU = 0x0006;
  public const ulong EFI_HOB_TYPE_MEMORY_POOL = 0x0007;
  public const ulong EFI_HOB_TYPE_FV2 = 0x0009;
  public const ulong EFI_HOB_TYPE_LOAD_PEIM_UNUSED = 0x000A;
  public const ulong EFI_HOB_TYPE_UEFI_CAPSULE = 0x000B;
  public const ulong EFI_HOB_TYPE_FV3 = 0x000C;
  public const ulong EFI_HOB_TYPE_UNUSED = 0xFFFE;
  public const ulong EFI_HOB_TYPE_END_OF_HOB_LIST = 0xFFFF;
}

///
/// Describes the format and size of the data inside the HOB.
/// All HOBs must contain this generic HOB header.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_GENERIC_HEADER
{
  ///
  /// Identifies the HOB data structure type.
  ///
  public ushort HobType;
  ///
  /// The length in bytes of the HOB.
  ///
  public ushort HobLength;
  ///
  /// This field must always be set to zero.
  ///
  public uint Reserved;
}

public unsafe partial class EFI
{
  ///
  /// Value of version  in EFI_HOB_HANDOFF_INFO_TABLE.
  ///
  public const ulong EFI_HOB_HANDOFF_TABLE_VERSION = 0x0009;
}

///
/// Contains general state information used by the HOB producer phase.
/// This HOB must be the first one in the HOB list.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_HANDOFF_INFO_TABLE
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_HANDOFF.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// The version number pertaining to the PHIT HOB definition.
  /// This value is four bytes in length to provide an 8-byte aligned entry
  /// when it is combined with the 4-byte BootMode.
  ///
  public uint Version;
  ///
  /// The system boot mode as determined during the HOB producer phase.
  ///
  public EFI_BOOT_MODE BootMode;
  ///
  /// The highest address location of memory that is allocated for use by the HOB producer
  /// phase. This address must be 4-KB aligned to meet page restrictions of UEFI.
  ///
  public EFI_PHYSICAL_ADDRESS EfiMemoryTop;
  ///
  /// The lowest address location of memory that is allocated for use by the HOB producer phase.
  ///
  public EFI_PHYSICAL_ADDRESS EfiMemoryBottom;
  ///
  /// The highest address location of free memory that is currently available
  /// for use by the HOB producer phase.
  ///
  public EFI_PHYSICAL_ADDRESS EfiFreeMemoryTop;
  ///
  /// The lowest address location of free memory that is available for use by the HOB producer phase.
  ///
  public EFI_PHYSICAL_ADDRESS EfiFreeMemoryBottom;
  ///
  /// The end of the HOB list.
  ///
  public EFI_PHYSICAL_ADDRESS EfiEndOfHobList;
}

///
/// EFI_HOB_MEMORY_ALLOCATION_HEADER describes the
/// various attributes of the logical memory allocation. The type field will be used for
/// subsequent inclusion in the UEFI memory map.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_MEMORY_ALLOCATION_HEADER
{
  ///
  /// A GUID that defines the memory allocation region's type and purpose, as well as
  /// other fields within the memory allocation HOB. This GUID is used to define the
  /// additional data within the HOB that may be present for the memory allocation HOB.
  /// Type EFI_GUID is defined in InstallProtocolInterface() in the UEFI 2.0
  /// specification.
  ///
  public EFI_GUID Name;

  ///
  /// The base address of memory allocated by this HOB. Type
  /// EFI_PHYSICAL_ADDRESS is defined in AllocatePages() in the UEFI 2.0
  /// specification.
  ///
  public EFI_PHYSICAL_ADDRESS MemoryBaseAddress;

  ///
  /// The length in bytes of memory allocated by this HOB.
  ///
  public ulong MemoryLength;

  ///
  /// Defines the type of memory allocated by this HOB. The memory type definition
  /// follows the EFI_MEMORY_TYPE definition. Type EFI_MEMORY_TYPE is defined
  /// in AllocatePages() in the UEFI 2.0 specification.
  ///
  public EFI_MEMORY_TYPE MemoryType;

  ///
  /// Padding for Itanium processor family
  ///
  public fixed byte Reserved[4];
}

///
/// Describes all memory ranges used during the HOB producer
/// phase that exist outside the HOB list. This HOB type
/// describes how memory is used, not the physical attributes of memory.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_MEMORY_ALLOCATION
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_MEMORY_ALLOCATION.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// An instance of the EFI_HOB_MEMORY_ALLOCATION_HEADER that describes the
  /// various attributes of the logical memory allocation.
  ///
  public EFI_HOB_MEMORY_ALLOCATION_HEADER AllocDescriptor;
  //
  // Additional data pertaining to the "Name" Guid memory
  // may go here.
  //
}

///
/// Describes the memory stack that is produced by the HOB producer
/// phase and upon which all post-memory-installed executable
/// content in the HOB producer phase is executing.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_MEMORY_ALLOCATION_STACK
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_MEMORY_ALLOCATION.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// An instance of the EFI_HOB_MEMORY_ALLOCATION_HEADER that describes the
  /// various attributes of the logical memory allocation.
  ///
  public EFI_HOB_MEMORY_ALLOCATION_HEADER AllocDescriptor;
}

///
/// Defines the location of the boot-strap
/// processor (BSP) BSPStore ("Backing Store Pointer Store").
/// This HOB is valid for the Itanium processor family only
/// register overflow store.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_MEMORY_ALLOCATION_BSP_STORE
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_MEMORY_ALLOCATION.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// An instance of the EFI_HOB_MEMORY_ALLOCATION_HEADER that describes the
  /// various attributes of the logical memory allocation.
  ///
  public EFI_HOB_MEMORY_ALLOCATION_HEADER AllocDescriptor;
}

///
/// Defines the location and entry point of the HOB consumer phase.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_MEMORY_ALLOCATION_MODULE
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_MEMORY_ALLOCATION.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// An instance of the EFI_HOB_MEMORY_ALLOCATION_HEADER that describes the
  /// various attributes of the logical memory allocation.
  ///
  public EFI_HOB_MEMORY_ALLOCATION_HEADER MemoryAllocationHeader;
  ///
  /// The GUID specifying the values of the firmware file system name
  /// that contains the HOB consumer phase component.
  ///
  public EFI_GUID ModuleName;
  ///
  /// The address of the memory-mapped firmware volume
  /// that contains the HOB consumer phase firmware file.
  ///
  public EFI_PHYSICAL_ADDRESS EntryPoint;
}

///
/// The resource type.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_RESOURCE_TYPE { uint Value; public static implicit operator EFI_RESOURCE_TYPE(uint value) => new EFI_RESOURCE_TYPE() { Value = value }; public static implicit operator uint(EFI_RESOURCE_TYPE value) => value.Value; }

public unsafe partial class EFI
{
  //
  // Value of ResourceType in EFI_HOB_RESOURCE_DESCRIPTOR.
  //
  public const ulong EFI_RESOURCE_SYSTEM_MEMORY = 0x00000000;
  public const ulong EFI_RESOURCE_MEMORY_MAPPED_IO = 0x00000001;
  public const ulong EFI_RESOURCE_IO = 0x00000002;
  public const ulong EFI_RESOURCE_FIRMWARE_DEVICE = 0x00000003;
  public const ulong EFI_RESOURCE_MEMORY_MAPPED_IO_PORT = 0x00000004;
  public const ulong EFI_RESOURCE_MEMORY_RESERVED = 0x00000005;
  public const ulong EFI_RESOURCE_IO_RESERVED = 0x00000006;
  //
  // BZ3937_EFI_RESOURCE_MEMORY_UNACCEPTED is defined for unaccepted memory.
  // But this defitinion has not been officially in the PI spec. Base
  // on the code-first we define BZ3937_EFI_RESOURCE_MEMORY_UNACCEPTED at
  // MdeModulePkg/Include/Pi/PrePiHob.h and update EFI_RESOURCE_MAX_MEMORY_TYPE
  // to 8. After BZ3937_EFI_RESOURCE_MEMORY_UNACCEPTED is officially published
  // in PI spec, we will re-visit here.
  //
  public const ulong BZ3937_EFI_RESOURCE_MEMORY_UNACCEPTED = 0x00000007;
  public const ulong EFI_RESOURCE_MAX_MEMORY_TYPE = 0x00000008;
}

///
/// A type of recount attribute type.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_RESOURCE_ATTRIBUTE_TYPE { uint Value; public static implicit operator EFI_RESOURCE_ATTRIBUTE_TYPE(uint value) => new EFI_RESOURCE_ATTRIBUTE_TYPE() { Value = value }; public static implicit operator uint(EFI_RESOURCE_ATTRIBUTE_TYPE value) => value.Value; }

public unsafe partial class EFI
{
  //
  // These types can be ORed together as needed.
  //
  // The following attributes are used to describe settings
  //
  public const ulong EFI_RESOURCE_ATTRIBUTE_PRESENT = 0x00000001;
  public const ulong EFI_RESOURCE_ATTRIBUTE_INITIALIZED = 0x00000002;
  public const ulong EFI_RESOURCE_ATTRIBUTE_TESTED = 0x00000004;
  public const ulong EFI_RESOURCE_ATTRIBUTE_READ_PROTECTED = 0x00000080;
  //
  // This is typically used as memory cacheability attribute today.
  // NOTE: Since PI spec 1.4, please use EFI_RESOURCE_ATTRIBUTE_READ_ONLY_PROTECTED
  // as Physical write protected attribute, and EFI_RESOURCE_ATTRIBUTE_WRITE_PROTECTED
  // means Memory cacheability attribute: The memory supports being programmed with
  // a writeprotected cacheable attribute.
  //
  public const ulong EFI_RESOURCE_ATTRIBUTE_WRITE_PROTECTED = 0x00000100;
  public const ulong EFI_RESOURCE_ATTRIBUTE_EXECUTION_PROTECTED = 0x00000200;
  public const ulong EFI_RESOURCE_ATTRIBUTE_PERSISTENT = 0x00800000;
  //
  // The rest of the attributes are used to describe capabilities
  //
  public const ulong EFI_RESOURCE_ATTRIBUTE_SINGLE_BIT_ECC = 0x00000008;
  public const ulong EFI_RESOURCE_ATTRIBUTE_MULTIPLE_BIT_ECC = 0x00000010;
  public const ulong EFI_RESOURCE_ATTRIBUTE_ECC_RESERVED_1 = 0x00000020;
  public const ulong EFI_RESOURCE_ATTRIBUTE_ECC_RESERVED_2 = 0x00000040;
  public const ulong EFI_RESOURCE_ATTRIBUTE_UNCACHEABLE = 0x00000400;
  public const ulong EFI_RESOURCE_ATTRIBUTE_WRITE_COMBINEABLE = 0x00000800;
  public const ulong EFI_RESOURCE_ATTRIBUTE_WRITE_THROUGH_CACHEABLE = 0x00001000;
  public const ulong EFI_RESOURCE_ATTRIBUTE_WRITE_BACK_CACHEABLE = 0x00002000;
  public const ulong EFI_RESOURCE_ATTRIBUTE_16_BIT_IO = 0x00004000;
  public const ulong EFI_RESOURCE_ATTRIBUTE_32_BIT_IO = 0x00008000;
  public const ulong EFI_RESOURCE_ATTRIBUTE_64_BIT_IO = 0x00010000;
  public const ulong EFI_RESOURCE_ATTRIBUTE_UNCACHED_EXPORTED = 0x00020000;
  public const ulong EFI_RESOURCE_ATTRIBUTE_READ_PROTECTABLE = 0x00100000;
  //
  // This is typically used as memory cacheability attribute today.
  // NOTE: Since PI spec 1.4, please use EFI_RESOURCE_ATTRIBUTE_READ_ONLY_PROTECTABLE
  // as Memory capability attribute: The memory supports being protected from processor
  // writes, and EFI_RESOURCE_ATTRIBUTE_WRITE_PROTEC TABLE means Memory cacheability attribute:
  // The memory supports being programmed with a writeprotected cacheable attribute.
  //
  public const ulong EFI_RESOURCE_ATTRIBUTE_WRITE_PROTECTABLE = 0x00200000;
  public const ulong EFI_RESOURCE_ATTRIBUTE_EXECUTION_PROTECTABLE = 0x00400000;
  public const ulong EFI_RESOURCE_ATTRIBUTE_PERSISTABLE = 0x01000000;

  public const ulong EFI_RESOURCE_ATTRIBUTE_READ_ONLY_PROTECTED = 0x00040000;
  public const ulong EFI_RESOURCE_ATTRIBUTE_READ_ONLY_PROTECTABLE = 0x00080000;

  //
  // Physical memory relative reliability attribute. This
  // memory provides higher reliability relative to other
  // memory in the system. If all memory has the same
  // reliability, then this bit is not used.
  //
  public const ulong EFI_RESOURCE_ATTRIBUTE_MORE_RELIABLE = 0x02000000;
}

///
/// Describes the resource properties of all fixed,
/// nonrelocatable resource ranges found on the processor
/// host bus during the HOB producer phase.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_RESOURCE_DESCRIPTOR
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_RESOURCE_DESCRIPTOR.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// A GUID representing the owner of the resource. This GUID is used by HOB
  /// consumer phase components to correlate device ownership of a resource.
  ///
  public EFI_GUID Owner;
  ///
  /// The resource type enumeration as defined by EFI_RESOURCE_TYPE.
  ///
  public EFI_RESOURCE_TYPE ResourceType;
  ///
  /// Resource attributes as defined by EFI_RESOURCE_ATTRIBUTE_TYPE.
  ///
  public EFI_RESOURCE_ATTRIBUTE_TYPE ResourceAttribute;
  ///
  /// The physical start address of the resource region.
  ///
  public EFI_PHYSICAL_ADDRESS PhysicalStart;
  ///
  /// The number of bytes of the resource region.
  ///
  public ulong ResourceLength;
}

///
/// Allows writers of executable content in the HOB producer phase to
/// maintain and manage HOBs with specific GUID.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_GUID_TYPE
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_GUID_EXTENSION.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// A GUID that defines the contents of this HOB.
  ///
  public EFI_GUID Name;
  //
  // Guid specific data goes here
  //
}

///
/// Details the location of firmware volumes that contain firmware files.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_FIRMWARE_VOLUME
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_FV.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// The physical memory-mapped base address of the firmware volume.
  ///
  public EFI_PHYSICAL_ADDRESS BaseAddress;
  ///
  /// The length in bytes of the firmware volume.
  ///
  public ulong Length;
}

///
/// Details the location of a firmware volume that was extracted
/// from a file within another firmware volume.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_FIRMWARE_VOLUME2
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_FV2.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// The physical memory-mapped base address of the firmware volume.
  ///
  public EFI_PHYSICAL_ADDRESS BaseAddress;
  ///
  /// The length in bytes of the firmware volume.
  ///
  public ulong Length;
  ///
  /// The name of the firmware volume.
  ///
  public EFI_GUID FvName;
  ///
  /// The name of the firmware file that contained this firmware volume.
  ///
  public EFI_GUID FileName;
}

///
/// Details the location of a firmware volume that was extracted
/// from a file within another firmware volume.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_FIRMWARE_VOLUME3
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_FV3.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// The physical memory-mapped base address of the firmware volume.
  ///
  public EFI_PHYSICAL_ADDRESS BaseAddress;
  ///
  /// The length in bytes of the firmware volume.
  ///
  public ulong Length;
  ///
  /// The authentication status.
  ///
  public uint AuthenticationStatus;
  ///
  /// TRUE if the FV was extracted as a file within another firmware volume.
  /// FALSE otherwise.
  ///
  public bool ExtractedFv;
  ///
  /// The name of the firmware volume.
  /// Valid only if IsExtractedFv is TRUE.
  ///
  public EFI_GUID FvName;
  ///
  /// The name of the firmware file that contained this firmware volume.
  /// Valid only if IsExtractedFv is TRUE.
  ///
  public EFI_GUID FileName;
}

///
/// Describes processor information, such as address space and I/O space capabilities.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_CPU
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_CPU.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
  ///
  /// Identifies the maximum physical memory addressability of the processor.
  ///
  public byte SizeOfMemorySpace;
  ///
  /// Identifies the maximum physical I/O addressability of the processor.
  ///
  public byte SizeOfIoSpace;
  ///
  /// This field will always be set to zero.
  ///
  public fixed byte Reserved[6];
}

///
/// Describes pool memory allocations.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_MEMORY_POOL
{
  ///
  /// The HOB generic header. Header.HobType = EFI_HOB_TYPE_MEMORY_POOL.
  ///
  public EFI_HOB_GENERIC_HEADER Header;
}

///
/// Each UEFI capsule HOB details the location of a UEFI capsule. It includes a base address and length
/// which is based upon memory blocks with a EFI_CAPSULE_HEADER and the associated
/// CapsuleImageSize-based payloads. These HOB's shall be created by the PEI PI firmware
/// sometime after the UEFI UpdateCapsule service invocation with the
/// CAPSULE_FLAGS_POPULATE_SYSTEM_TABLE flag set in the EFI_CAPSULE_HEADER.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HOB_UEFI_CAPSULE
{
  ///
  /// The HOB generic header where Header.HobType = EFI_HOB_TYPE_UEFI_CAPSULE.
  ///
  public EFI_HOB_GENERIC_HEADER Header;

  ///
  /// The physical memory-mapped base address of an UEFI capsule. This value is set to
  /// point to the base of the contiguous memory of the UEFI capsule.
  /// The length of the contiguous memory in bytes.
  ///
  public EFI_PHYSICAL_ADDRESS BaseAddress;
  public ulong Length;
}

///
/// Union of all the possible HOB Types.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_PEI_HOB_POINTERS
{
  [FieldOffset(0)] public EFI_HOB_GENERIC_HEADER* Header;
  [FieldOffset(0)] public EFI_HOB_HANDOFF_INFO_TABLE* HandoffInformationTable;
  [FieldOffset(0)] public EFI_HOB_MEMORY_ALLOCATION* MemoryAllocation;
  [FieldOffset(0)] public EFI_HOB_MEMORY_ALLOCATION_BSP_STORE* MemoryAllocationBspStore;
  [FieldOffset(0)] public EFI_HOB_MEMORY_ALLOCATION_STACK* MemoryAllocationStack;
  [FieldOffset(0)] public EFI_HOB_MEMORY_ALLOCATION_MODULE* MemoryAllocationModule;
  [FieldOffset(0)] public EFI_HOB_RESOURCE_DESCRIPTOR* ResourceDescriptor;
  [FieldOffset(0)] public EFI_HOB_GUID_TYPE* Guid;
  [FieldOffset(0)] public EFI_HOB_FIRMWARE_VOLUME* FirmwareVolume;
  [FieldOffset(0)] public EFI_HOB_FIRMWARE_VOLUME2* FirmwareVolume2;
  [FieldOffset(0)] public EFI_HOB_FIRMWARE_VOLUME3* FirmwareVolume3;
  [FieldOffset(0)] public EFI_HOB_CPU* Cpu;
  [FieldOffset(0)] public EFI_HOB_MEMORY_POOL* Pool;
  [FieldOffset(0)] public EFI_HOB_UEFI_CAPSULE* Capsule;
  [FieldOffset(0)] public byte* Raw;
}

// #endif
