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

public static EFI_GUID EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_GUID = new GUID(
    0x2f707ebb, 0x4a1a, 0x11d4, new byte[] { 0x9a, 0x38, 0x00, 0x90, 0x27, 0x3f, 0xc1, 0x4d });

// typedef struct _EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL;

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

public static ulong EFI_PCI_ATTRIBUTE_ISA_MOTHERBOARD_IO = 0x0001;
public static ulong EFI_PCI_ATTRIBUTE_ISA_IO = 0x0002;
public static ulong EFI_PCI_ATTRIBUTE_VGA_PALETTE_IO = 0x0004;
public static ulong EFI_PCI_ATTRIBUTE_VGA_MEMORY = 0x0008;
public static ulong EFI_PCI_ATTRIBUTE_VGA_IO = 0x0010;
public static ulong EFI_PCI_ATTRIBUTE_IDE_PRIMARY_IO = 0x0020;
public static ulong EFI_PCI_ATTRIBUTE_IDE_SECONDARY_IO = 0x0040;
public static ulong EFI_PCI_ATTRIBUTE_MEMORY_WRITE_COMBINE = 0x0080;
public static ulong EFI_PCI_ATTRIBUTE_MEMORY_CACHED = 0x0800;
public static ulong EFI_PCI_ATTRIBUTE_MEMORY_DISABLE = 0x1000;
public static ulong EFI_PCI_ATTRIBUTE_DUAL_ADDRESS_CYCLE = 0x8000;
public static ulong EFI_PCI_ATTRIBUTE_ISA_IO_16 = 0x10000;
public static ulong EFI_PCI_ATTRIBUTE_VGA_PALETTE_IO_16 = 0x20000;
public static ulong EFI_PCI_ATTRIBUTE_VGA_IO_16 = 0x40000;

public static ulong EFI_PCI_ATTRIBUTE_VALID_FOR_ALLOCATE_BUFFER = (EFI_PCI_ATTRIBUTE_MEMORY_WRITE_COMBINE | EFI_PCI_ATTRIBUTE_MEMORY_CACHED | EFI_PCI_ATTRIBUTE_DUAL_ADDRESS_CYCLE);

public static ulong EFI_PCI_ATTRIBUTE_INVALID_FOR_ALLOCATE_BUFFER = (~EFI_PCI_ATTRIBUTE_VALID_FOR_ALLOCATE_BUFFER);

public static ulong EFI_PCI_ADDRESS = (bus, dev, func, reg) \;
  (ulong) ( \
  (((ulong) bus) << 24) | \
  (((ulong) dev) << 16) | \
  (((ulong) func) << 8) | \
  (((ulong) (reg)) < 256 ? ((ulong) (reg)) : (ulong) (LShiftU64 ((ulong) (reg), 32))))

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_PCI_ADDRESS
{
  public byte Register;
  public byte Function;
  public byte Device;
  public byte Bus;
  public uint ExtendedRegister;
}
























































[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ACCESS
{
  ///
  /// Read PCI controller registers in the PCI root bridge memory space.
  ///
  /**
    Enables a PCI driver to access PCI controller registers in the PCI root bridge memory space.

    @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
    @param  Width                 Signifies the width of the memory operations.
    @param  Address               The base address of the memory operations.
    @param  Count                 The number of memory operations to perform.























































    @retval EFI_INVALID_PARAMETER One or more parameters are invalid.
















































                                  MEMORY_WRITE_COMBINE and MEMORY_CACHED.



















    @param  Pages                 The number of pages to free.
















    Flushes all PCI posted write transactions from a PCI host bridge to system memory.

























    @retval EFI_SUCCESS           If Supports is not NULL, then the attributes that the PCI root





























    @retval EFI_UNSUPPORTED       A bit is set in Attributes that is not supported by the PCI Root




















    @param  Resources             A pointer to the resource descriptors that describe the current
                                  configuration of this PCI root bridge.

    @retval EFI_SUCCESS           The current configuration of this PCI root bridge was returned in
                                  Resources.
    @retval EFI_UNSUPPORTED       The current configuration of this PCI root bridge could not be
                                  retrieved.

  **/
  typedef
  EFI_STATUS
  (EFIAPI* EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_CONFIGURATION)(
    IN EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL          * This,
    OUT void** Resources
  );

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
    /**
      Reads from the I/O space of a PCI Root Bridge. Returns when either the polling exit criteria is
      satisfied or after a defined duration.

      @param  This                  A pointer to the EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL.
      @param  Width                 Signifies the width of the memory or I/O operations.
      @param  Address               The base address of the memory or I/O operations.
      @param  Mask                  Mask used for the polling criteria.
      @param  Value                 The comparison value used for the polling exit criteria.
      @param  Delay                 The number of 100 ns units to poll.
      @param  Result                Pointer to the last value read from the memory location.

      @retval EFI_SUCCESS           The last data returned from the access matched the poll exit criteria.
      @retval EFI_TIMEOUT           Delay expired before a match occurred.
      @retval EFI_OUT_OF_RESOURCES  The request could not be completed due to a lack of resources.
      @retval EFI_INVALID_PARAMETER One or more parameters are invalid.

    **/
    public readonly delegate* unmanaged<EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL*, EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_WIDTH, ulong, ulong, ulong, ulong, ulong*, EFI_STATUS> PollMem;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_POLL_IO_MEM PollIo;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ACCESS Mem;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ACCESS Io;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ACCESS Pci;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_COPY_MEM CopyMem;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_MAP Map;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_UNMAP Unmap;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_ALLOCATE_BUFFER AllocateBuffer;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_FREE_BUFFER FreeBuffer;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_FLUSH Flush;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_GET_ATTRIBUTES GetAttributes;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_SET_ATTRIBUTES SetAttributes;
    public EFI_PCI_ROOT_BRIDGE_IO_PROTOCOL_CONFIGURATION Configuration;

    ///
    /// The segment number that this PCI root bridge resides.
    ///
    public uint SegmentNumber;
  }

// extern EFI_GUID  gEfiPciRootBridgeIoProtocolGuid;

// #endif
