using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  PCI Root Bridge I/O protocol as defined in the UEFI 2.0 specification.

  PCI Root Bridge I/O protocol is used by PCI Bus Driver to perform PCI Memory, PCI I/O,
  and PCI Configuration cycles on a PCI Root Bridge. It also provides services to perform
  defferent types of bus mastering DMA.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __PCI_ROOT_BRIDGE_IO_H__
// #define __PCI_ROOT_BRIDGE_IO_H__

// #include <Library/BaseLib.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_GUID = new GUID(
      0x2f707ebb, 0x4a1a, 0x11d4, new byte[] { 0x9a, 0x38, 0x00, 0x90, 0x27, 0x3f, 0xc1, 0x4d });

  // typedef struct _EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL;
}

///
/// *******************************************************
/// EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH
/// *******************************************************
///
public enum EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH
{
  EfiPciWidthUint8,
  EfiPciWidthUint16,
  EfiPciWidthUint32,
  EfiPciWidthUint64,
  EfiPciWidthFifoUint8,
  EfiPciWidthFifoUint16,
  EfiPciWidthFifoUint32,
  EfiPciWidthFifoUint64,
  EfiPciWidthFillUint8,
  EfiPciWidthFillUint16,
  EfiPciWidthFillUint32,
  EfiPciWidthFillUint64,
  EfiPciWidthMaximum
}

///
/// *******************************************************
/// EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_OPERATION
/// *******************************************************
///
public enum EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_OPERATION
{
  ///
  /// A read operation from system memory by a bus master that is not capable of producing
  /// PCI dual address cycles.
  ///
  EfiPciOperationBusMasterRead,
  ///
  /// A write operation from system memory by a bus master that is not capable of producing
  /// PCI dual address cycles.
  ///
  EfiPciOperationBusMasterWrite,
  ///
  /// Provides both read and write access to system memory by both the processor and a bus
  /// master that is not capable of producing PCI dual address cycles.
  ///
  EfiPciOperationBusMasterCommonBuffer,
  ///
  /// A read operation from system memory by a bus master that is capable of producing PCI
  /// dual address cycles.
  ///
  EfiPciOperationBusMasterRead64,
  ///
  /// A write operation to system memory by a bus master that is capable of producing PCI
  /// dual address cycles.
  ///
  EfiPciOperationBusMasterWrite64,
  ///
  /// Provides both read and write access to system memory by both the processor and a bus
  /// master that is capable of producing PCI dual address cycles.
  ///
  EfiPciOperationBusMasterCommonBuffer64,
  EfiPciOperationMaximum
}

public unsafe partial class EFI
{
  public const ulong EFI_PCI_ATTRIBUTE_ISA_MOTHERBOARD_IO = 0x0001;
  public const ulong EFI_PCI_ATTRIBUTE_ISA_IO = 0x0002;
  public const ulong EFI_PCI_ATTRIBUTE_VGA_PALETTE_IO = 0x0004;
  public const ulong EFI_PCI_ATTRIBUTE_VGA_MEMORY = 0x0008;
  public const ulong EFI_PCI_ATTRIBUTE_VGA_IO = 0x0010;
  public const ulong EFI_PCI_ATTRIBUTE_IDE_PRIMARY_IO = 0x0020;
  public const ulong EFI_PCI_ATTRIBUTE_IDE_SECONDARY_IO = 0x0040;
  public const ulong EFI_PCI_ATTRIBUTE_MEMORY_WRITE_COMBINE = 0x0080;
  public const ulong EFI_PCI_ATTRIBUTE_MEMORY_CACHED = 0x0800;
  public const ulong EFI_PCI_ATTRIBUTE_MEMORY_DISABLE = 0x1000;
  public const ulong EFI_PCI_ATTRIBUTE_DUAL_ADDRESS_CYCLE = 0x8000;
  public const ulong EFI_PCI_ATTRIBUTE_ISA_IO_16 = 0x10000;
  public const ulong EFI_PCI_ATTRIBUTE_VGA_PALETTE_IO_16 = 0x20000;
  public const ulong EFI_PCI_ATTRIBUTE_VGA_IO_16 = 0x40000;

  public const ulong EFI_PCI_ATTRIBUTE_VALID_FOR_ALLOCATE_BUFFER = (EFI_PCI_ATTRIBUTE_MEMORY_WRITE_COMBINE | EFI_PCI_ATTRIBUTE_MEMORY_CACHED | EFI_PCI_ATTRIBUTE_DUAL_ADDRESS_CYCLE);

  public const ulong EFI_PCI_ATTRIBUTE_INVALID_FOR_ALLOCATE_BUFFER = (~EFI_PCI_ATTRIBUTE_VALID_FOR_ALLOCATE_BUFFER);

  //public const ulong EFI_PCI_ADDRESS = (bus, dev, func, reg) \;
  //(ulong) ( \
  //(((ulong) bus) << 24) | \
  //(((ulong) dev) << 16) | \
  //(((ulong) func) << 8) | \
  //(((ulong) (reg)) < 256 ? ((ulong) (reg)) : (ulong) (LShiftU64 ((ulong) (reg), 32))))
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_PCI_ADDRESS
{
  public byte Register;
  public byte Function;
  public byte Device;
  public byte Bus;
  public uint ExtendedRegister;
}

// /**
//   Reads from the I/O space of a PCI Root Bridge. Returns when either the polling exit criteria is
//   satisfied or after a defined duration.
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
//   @param  Width                 Signifies the width of the memory or I/O operations.
//   @param  Address               The base address of the memory or I/O operations.
//   @param  Mask                  Mask used for the polling criteria.
//   @param  Value                 The comparison value used for the polling exit criteria.
//   @param  Delay                 The number of 100 ns units to poll.
//   @param  Result                Pointer to the last value read from the memory location.
// 
//   @retval EFI_SUCCESS           The last data returned from the access matched the poll exit criteria.
//   @retval EFI_TIMEOUT           Delay expired before a match occurred.
//   @retval EFI_OUT_OF_RESOURCES  The request could not be completed due to a lack of resources.
//   @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_POLL_IO_MEM)(
//   IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL           *This,
//   IN  EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH    Width,
//   IN  ulong                                   Address,
//   IN  ulong                                   Mask,
//   IN  ulong                                   Value,
//   IN  ulong                                   Delay,
//   OUT ulong                                   *Result
//   );

// /**
//   Enables a PCI driver to access PCI controller registers in the PCI root bridge memory space.
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
//   @param  Width                 Signifies the width of the memory operations.
//   @param  Address               The base address of the memory operations.
//   @param  Count                 The number of memory operations to perform.
//   @param  Buffer                For read operations, the destination buffer to store the results. For write
//                                 operations, the source buffer to write data from.
// 
//   @retval EFI_SUCCESS           The data was read from or written to the PCI root bridge.
//   @retval EFI_OUT_OF_RESOURCES  The request could not be completed due to a lack of resources.
//   @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_IO_MEM)(
//   IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL              *This,
//   IN     EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH    Width,
//   IN     ulong                                   Address,
//   IN     ulong                                    Count,
//   IN OUT void                                     *Buffer
//   );

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ACCESS
{
  ///
  /// Read PCI controller registers in the PCI root bridge memory space.
  ///
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH /*Width*/,/* IN */ulong /*Address*/,/* IN */ulong /*Count*/,/* IN OUT */void* /*Buffer*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_IO_MEM*/ Read;
  ///
  /// Write PCI controller registers in the PCI root bridge memory space.
  ///
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH /*Width*/,/* IN */ulong /*Address*/,/* IN */ulong /*Count*/,/* IN OUT */void* /*Buffer*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_IO_MEM*/ Write;
}

// /**
//   Enables a PCI driver to copy one region of PCI root bridge memory space to another region of PCI
//   root bridge memory space.
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL instance.
//   @param  Width                 Signifies the width of the memory operations.
//   @param  DestAddress           The destination address of the memory operation.
//   @param  SrcAddress            The source address of the memory operation.
//   @param  Count                 The number of memory operations to perform.
// 
//   @retval EFI_SUCCESS           The data was copied from one memory region to another memory region.
//   @retval EFI_INVALID_PARAMETER Width is invalid for this PCI root bridge.
//   @retval EFI_OUT_OF_RESOURCES  The request could not be completed due to a lack of resources.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_COPY_MEM)(
//   IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL              *This,
//   IN     EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH    Width,
//   IN     ulong                                   DestAddress,
//   IN     ulong                                   SrcAddress,
//   IN     ulong                                    Count
//   );

// /**
//   Provides the PCI controller-specific addresses required to access system memory from a
//   DMA bus master.
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
//   @param  Operation             Indicates if the bus master is going to read or write to system memory.
//   @param  HostAddress           The system memory address to map to the PCI controller.
//   @param  NumberOfBytes         On input the number of bytes to map. On output the number of bytes
//                                 that were mapped.
//   @param  DeviceAddress         The resulting map address for the bus master PCI controller to use to
//                                 access the hosts HostAddress.
//   @param  Mapping               A resulting value to pass to Unmap().
// 
//   @retval EFI_SUCCESS           The range was mapped for the returned NumberOfBytes.
//   @retval EFI_UNSUPPORTED       The HostAddress cannot be mapped as a common buffer.
//   @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
//   @retval EFI_OUT_OF_RESOURCES  The request could not be completed due to a lack of resources.
//   @retval EFI_DEVICE_ERROR      The system hardware could not map the requested address.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_MAP)(
//   IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL                *This,
//   IN     EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_OPERATION  Operation,
//   IN     void                                       *HostAddress,
//   IN OUT ulong                                      *NumberOfBytes,
//   OUT    EFI_PHYSICAL_ADDRESS                       *DeviceAddress,
//   OUT    void                                       **Mapping
//   );

// /**
//   Completes the Map() operation and releases any corresponding resources.
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
//   @param  Mapping               The mapping value returned from Map().
// 
//   @retval EFI_SUCCESS           The range was unmapped.
//   @retval EFI_INVALID_PARAMETER Mapping is not a value that was returned by Map().
//   @retval EFI_DEVICE_ERROR      The data was not committed to the target system memory.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_UNMAP)(
//   IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL           *This,
//   IN  void                                     *Mapping
//   );

// /**
//   Allocates pages that are suitable for an EfiPciOperationBusMasterCommonBuffer or
//   EfiPciOperationBusMasterCommonBuffer64 mapping.
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
//   @param  Type                  This parameter is not used and must be ignored.
//   @param  MemoryType            The type of memory to allocate, EfiBootServicesData or
//                                 EfiRuntimeServicesData.
//   @param  Pages                 The number of pages to allocate.
//   @param  HostAddress           A pointer to store the base system memory address of the
//                                 allocated range.
//   @param  Attributes            The requested bit mask of attributes for the allocated range.
// 
//   @retval EFI_SUCCESS           The requested memory pages were allocated.
//   @retval EFI_UNSUPPORTED       Attributes is unsupported. The only legal attribute bits are
//                                 MEMORY_WRITE_COMBINE and MEMORY_CACHED.
//   @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
//   @retval EFI_OUT_OF_RESOURCES  The memory pages could not be allocated.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ALLOCATE_BUFFER)(
//   IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL              *This,
//   IN     EFI_ALLOCATE_TYPE                        Type,
//   IN     EFI_MEMORY_TYPE                          MemoryType,
//   IN     ulong                                    Pages,
//   IN OUT void                                     **HostAddress,
//   IN     ulong                                   Attributes
//   );

// /**
//   Frees memory that was allocated with AllocateBuffer().
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
//   @param  Pages                 The number of pages to free.
//   @param  HostAddress           The base system memory address of the allocated range.
// 
//   @retval EFI_SUCCESS           The requested memory pages were freed.
//   @retval EFI_INVALID_PARAMETER The memory range specified by HostAddress and Pages
//                                 was not allocated with AllocateBuffer().
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_FREE_BUFFER)(
//   IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL           *This,
//   IN  ulong                                    Pages,
//   IN  void                                     *HostAddress
//   );

// /**
//   Flushes all PCI posted write transactions from a PCI host bridge to system memory.
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
// 
//   @retval EFI_SUCCESS           The PCI posted write transactions were flushed from the PCI host
//                                 bridge to system memory.
//   @retval EFI_DEVICE_ERROR      The PCI posted write transactions were not flushed from the PCI
//                                 host bridge due to a hardware error.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_FLUSH)(
//   IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL  *This
//   );

// /**
//   Gets the attributes that a PCI root bridge supports setting with SetAttributes(), and the
//   attributes that a PCI root bridge is currently using.
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
//   @param  Supports              A pointer to the mask of attributes that this PCI root bridge supports
//                                 setting with SetAttributes().
//   @param  Attributes            A pointer to the mask of attributes that this PCI root bridge is currently
//                                 using.
// 
//   @retval EFI_SUCCESS           If Supports is not NULL, then the attributes that the PCI root
//                                 bridge supports is returned in Supports. If Attributes is
//                                 not NULL, then the attributes that the PCI root bridge is currently
//                                 using is returned in Attributes.
//   @retval EFI_INVALID_PARAMETER Both Supports and Attributes are NULL.
// 
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_GET_ATTRIBUTES)(
//   IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL           *This,
//   OUT ulong                                   *Supports,
//   OUT ulong                                   *Attributes
//   );

// /**
//   Sets attributes for a resource range on a PCI root bridge.
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
//   @param  Attributes            The mask of attributes to set.
//   @param  ResourceBase          A pointer to the base address of the resource range to be modified by the
//                                 attributes specified by Attributes.
//   @param  ResourceLength        A pointer to the length of the resource range to be modified by the
//                                 attributes specified by Attributes.
// 
//   @retval EFI_SUCCESS           The set of attributes specified by Attributes for the resource
//                                 range specified by ResourceBase and ResourceLength
//                                 were set on the PCI root bridge, and the actual resource range is
//                                 returned in ResuourceBase and ResourceLength.
//   @retval EFI_UNSUPPORTED       A bit is set in Attributes that is not supported by the PCI Root
//                                 Bridge.
//   @retval EFI_OUT_OF_RESOURCES  There are not enough resources to set the attributes on the
//                                 resource range specified by BaseAddress and Length.
//   @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_SET_ATTRIBUTES)(
//   IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL              *This,
//   IN     ulong                                   Attributes,
//   IN OUT ulong                                   *ResourceBase,
//   IN OUT ulong                                   *ResourceLength
//   );

// /**
//   Retrieves the current resource settings of this PCI root bridge in the form of a set of ACPI
//   resource descriptors.
// 
//   @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
//   @param  Resources             A pointer to the resource descriptors that describe the current
//                                 configuration of this PCI root bridge.
// 
//   @retval EFI_SUCCESS           The current configuration of this PCI root bridge was returned in
//                                 Resources.
//   @retval EFI_UNSUPPORTED       The current configuration of this PCI root bridge could not be
//                                 retrieved.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_CONFIGURATION)(
//   IN  EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL          *This,
//   OUT void                                     **Resources
//   );

///
/// Provides the basic Memory, I/O, PCI configuration, and DMA interfaces that are
/// used to abstract accesses to PCI controllers behind a PCI Root Bridge Controller.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL
{
  ///
  /// The EFI_HANDLE of the PCI Host Bridge of which this PCI Root Bridge is a member.
  ///
  public EFI_HANDLE ParentHandle;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH /*Width*/,/* IN */ulong /*Address*/,/* IN */ulong /*Mask*/,/* IN */ulong /*Value*/,/* IN */ulong /*Delay*/,/* OUT */ulong* /*Result*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_POLL_IO_MEM*/ PollMem;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH /*Width*/,/* IN */ulong /*Address*/,/* IN */ulong /*Mask*/,/* IN */ulong /*Value*/,/* IN */ulong /*Delay*/,/* OUT */ulong* /*Result*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_POLL_IO_MEM*/ PollIo;
  public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ACCESS Mem;
  public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ACCESS Io;
  public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ACCESS Pci;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH /*Width*/,/* IN */ulong /*DestAddress*/,/* IN */ulong /*SrcAddress*/,/* IN */ulong /*Count*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_COPY_MEM*/ CopyMem;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_OPERATION /*Operation*/,/* IN */void* /*HostAddress*/,/* IN OUT */ulong* /*NumberOfBytes*/,/* OUT */EFI_PHYSICAL_ADDRESS* /*DeviceAddress*/,/* OUT */void** /*Mapping*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_MAP*/ Map;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* IN */void* /*Mapping*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_UNMAP*/ Unmap;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* IN */EFI_ALLOCATE_TYPE /*Type*/,/* IN */EFI_MEMORY_TYPE /*MemoryType*/,/* IN */ulong /*Pages*/,/* IN OUT */void** /*HostAddress*/,/* IN */ulong /*Attributes*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ALLOCATE_BUFFER*/ AllocateBuffer;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* IN */ulong /*Pages*/,/* IN */void* /*HostAddress*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_FREE_BUFFER*/ FreeBuffer;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_FLUSH*/ Flush;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* OUT */ulong* /*Supports*/,/* OUT */ulong* /*Attributes*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_GET_ATTRIBUTES*/ GetAttributes;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* IN */ulong /*Attributes*/,/* IN OUT */ulong* /*ResourceBase*/,/* IN OUT */ulong* /*ResourceLength*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_SET_ATTRIBUTES*/ SetAttributes;
  public readonly delegate* unmanaged</* IN */EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL* /*This*/,/* OUT */void** /*Resources*/, EFI_STATUS> /*EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_CONFIGURATION*/ Configuration;

  ///
  /// The segment number that this PCI root bridge resides.
  ///
  public uint SegmentNumber;
}

// extern EFI_GUID  gEfiPciRootBridgeIoProtocolGuid;

// #endif
