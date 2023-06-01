namespace Uefi;
/** @file
  EFI PCI I/O Protocol provides the basic Memory, I/O, PCI configuration,
  and DMA interfaces that a driver uses to access its PCI controller.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __PCI_IO_H__
// #define __PCI_IO_H__

///
/// Global ID for the PCI I/O Protocol
///
public static EFI_GUID EFI_PCI_IO_PROTOCOL_GUID = new GUID( 
    0x4cf5b200, 0x68b8, 0x4ca5, new byte[] {0x9e, 0xec, 0xb2, 0x3e, 0x3f, 0x50, 0x2, 0x9a });

// typedef struct _EFI_PCI_IO_PROTOCOL EFI_PCI_IO_PROTOCOL;

///
/// *******************************************************
/// EFI_PCI_IO_PROTOCOL_WIDTH
/// *******************************************************
///
public enum EFI_PCI_IO_PROTOCOL_WIDTH {
  EfiPciIoWidthUint8 = 0,
  EfiPciIoWidthUint16,
  EfiPciIoWidthUint32,
  EfiPciIoWidthUint64,
  EfiPciIoWidthFifoUint8,
  EfiPciIoWidthFifoUint16,
  EfiPciIoWidthFifoUint32,
  EfiPciIoWidthFifoUint64,
  EfiPciIoWidthFillUint8,
  EfiPciIoWidthFillUint16,
  EfiPciIoWidthFillUint32,
  EfiPciIoWidthFillUint64,
  EfiPciIoWidthMaximum
}

//
// Complete PCI address generater
//
public static ulong EFI_PCI_IO_PASS_THROUGH_BAR = 0xff    ///< Special BAR that passes a memory or I/O cycle through unchanged;
public static ulong EFI_PCI_IO_ATTRIBUTE_MASK = 0x077f  ///< All the following I/O and Memory cycles;
public static ulong EFI_PCI_IO_ATTRIBUTE_ISA_MOTHERBOARD_IO = 0x0001  ///< I/O cycles 0x0000-0x00FF (10 bit decode);
public static ulong EFI_PCI_IO_ATTRIBUTE_ISA_IO = 0x0002  ///< I/O cycles 0x0100-0x03FF or greater (10 bit decode);
public static ulong EFI_PCI_IO_ATTRIBUTE_VGA_PALETTE_IO = 0x0004  ///< I/O cycles 0x3C6, 0x3C8, 0x3C9 (10 bit decode);
public static ulong EFI_PCI_IO_ATTRIBUTE_VGA_MEMORY = 0x0008  ///< MEM cycles 0xA0000-0xBFFFF (24 bit decode);
public static ulong EFI_PCI_IO_ATTRIBUTE_VGA_IO = 0x0010  ///< I/O cycles 0x3B0-0x3BB and 0x3C0-0x3DF (10 bit decode);
public static ulong EFI_PCI_IO_ATTRIBUTE_IDE_PRIMARY_IO = 0x0020  ///< I/O cycles 0x1F0-0x1F7, 0x3F6, 0x3F7 (10 bit decode);
public static ulong EFI_PCI_IO_ATTRIBUTE_IDE_SECONDARY_IO = 0x0040  ///< I/O cycles 0x170-0x177, 0x376, 0x377 (10 bit decode);
public static ulong EFI_PCI_IO_ATTRIBUTE_MEMORY_WRITE_COMBINE = 0x0080  ///< Map a memory range so writes are combined;
public static ulong EFI_PCI_IO_ATTRIBUTE_IO = 0x0100  ///< Enable the I/O decode bit in the PCI Config Header;
public static ulong EFI_PCI_IO_ATTRIBUTE_MEMORY = 0x0200  ///< Enable the Memory decode bit in the PCI Config Header;
public static ulong EFI_PCI_IO_ATTRIBUTE_BUS_MASTER = 0x0400  ///< Enable the DMA bit in the PCI Config Header;
public static ulong EFI_PCI_IO_ATTRIBUTE_MEMORY_CACHED = 0x0800  ///< Map a memory range so all r/w accesses are cached;
public static ulong EFI_PCI_IO_ATTRIBUTE_MEMORY_DISABLE = 0x1000  ///< Disable a memory range;
public static ulong EFI_PCI_IO_ATTRIBUTE_EMBEDDED_DEVICE = 0x2000  ///< Clear for an add-in PCI Device;
public static ulong EFI_PCI_IO_ATTRIBUTE_EMBEDDED_ROM = 0x4000  ///< Clear for a physical PCI Option ROM accessed through ROM BAR;
public static ulong EFI_PCI_IO_ATTRIBUTE_DUAL_ADDRESS_CYCLE = 0x8000  ///< Clear for PCI controllers that can not genrate a DAC;
public static ulong EFI_PCI_IO_ATTRIBUTE_ISA_IO_16 = 0x10000 ///< I/O cycles 0x0100-0x03FF or greater (16 bit decode);
public static ulong EFI_PCI_IO_ATTRIBUTE_VGA_PALETTE_IO_16 = 0x20000 ///< I/O cycles 0x3C6, 0x3C8, 0x3C9 (16 bit decode);
public static ulong EFI_PCI_IO_ATTRIBUTE_VGA_IO_16 = 0x40000 ///< I/O cycles 0x3B0-0x3BB and 0x3C0-0x3DF (16 bit decode);

public static ulong EFI_PCI_DEVICE_ENABLE = (EFI_PCI_IO_ATTRIBUTE_IO | EFI_PCI_IO_ATTRIBUTE_MEMORY | EFI_PCI_IO_ATTRIBUTE_BUS_MASTER);
public static ulong EFI_VGA_DEVICE_ENABLE = (EFI_PCI_IO_ATTRIBUTE_VGA_PALETTE_IO | EFI_PCI_IO_ATTRIBUTE_VGA_MEMORY | EFI_PCI_IO_ATTRIBUTE_VGA_IO | EFI_PCI_IO_ATTRIBUTE_IO);

///
/// *******************************************************
/// EFI_PCI_IO_PROTOCOL_OPERATION
/// *******************************************************
///
public enum EFI_PCI_IO_PROTOCOL_OPERATION {
  ///
  /// A read operation from system memory by a bus master.
  ///
  EfiPciIoOperationBusMasterRead,
  ///
  /// A write operation from system memory by a bus master.
  ///
  EfiPciIoOperationBusMasterWrite,
  ///
  /// Provides both read and write access to system memory by both the processor and a
  /// bus master. The buffer is coherent from both the processor's and the bus master's point of view.
  ///
  EfiPciIoOperationBusMasterCommonBuffer,
  EfiPciIoOperationMaximum
}

///
/// *******************************************************
/// EFI_PCI_IO_PROTOCOL_ATTRIBUTE_OPERATION
/// *******************************************************
///
public enum EFI_PCI_IO_PROTOCOL_ATTRIBUTE_OPERATION {
  ///
  /// Retrieve the PCI controller's current attributes, and return them in Result.
  ///
  EfiPciIoAttributeOperationGet,
  ///
  /// Set the PCI controller's current attributes to Attributes.
  ///
  EfiPciIoAttributeOperationSet,
  ///
  /// Enable the attributes specified by the bits that are set in Attributes for this PCI controller.
  ///
  EfiPciIoAttributeOperationEnable,
  ///
  /// Disable the attributes specified by the bits that are set in Attributes for this PCI controller.
  ///
  EfiPciIoAttributeOperationDisable,
  ///
  /// Retrieve the PCI controller's supported attributes, and return them in Result.
  ///
  EfiPciIoAttributeOperationSupported,
  EfiPciIoAttributeOperationMaximum
}



































































[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_IO_PROTOCOL_ACCESS {
  ///
  /// Read PCI controller registers in the PCI memory or I/O space.
  ///
/**
  Enable a PCI driver to access PCI controller registers in the PCI memory or I/O space.

  @param  This                  A pointer to the EFI_PCI_IO_PROTOCOL instance.
  @param  Width                 Signifies the width of the memory or I/O operations.
  @param  BarIndex              The BAR index of the standard PCI Configuration header to use as the
                                base address for the memory or I/O operation to perform.



























  @param  Buffer                For read operations, the destination buffer to store the results. For write
                                operations, the source buffer to write data from.


  @retval EFI_SUCCESS           The data was read from or written to the PCI controller.
  @retval EFI_UNSUPPORTED       The address range specified by Offset, Width, and Count is not
                                valid for the PCI configuration header of the PCI controller.
  @retval EFI_OUT_OF_RESOURCES  The request could not be completed due to a lack of resources.
  @retval EFI_INVALID_PARAMETER Buffer is NULL or Width is invalid.

**/
typedef







































  @retval EFI_UNSUPPORTED       SrcBarIndex not valid for this PCI controller.





























                                access the hosts HostAddress.
















  OUT    EFI_PHYSICAL_ADDRESS           *DeviceAddress,






























                                allocated range.




































  IN  ulong                        Pages,


















































  @param  Attributes            The mask of attributes that are used for Set, Enable, and Disable





























  @param  Resources             A pointer to the resource descriptors that describe the current

































  @retval EFI_SUCCESS           The set of attributes specified by Attributes for the resource
                                range specified by BarIndex, Offset, and Length were
                                set on the PCI controller, and the actual resource range is returned
                                in Offset and Length.
  @retval EFI_INVALID_PARAMETER Offset or Length is NULL.
  @retval EFI_UNSUPPORTED       BarIndex not valid for this PCI controller.
  @retval EFI_OUT_OF_RESOURCES  There are not enough resources to set the attributes on the
                                resource range specified by BarIndex, Offset, and
                                Length.

**/
typedef
EFI_STATUS
(EFIAPI *EFI_PCI_IO_PROTOCOL_SET_BAR_ATTRIBUTES)(
  IN EFI_PCI_IO_PROTOCOL              *This,
  IN     ulong                       Attributes,
  IN     byte                        BarIndex,
  IN OUT ulong                       *Offset,
  IN OUT ulong                       *Length
  );

///
/// The EFI_PCI_IO_PROTOCOL provides the basic Memory, I/O, PCI configuration,
/// and DMA interfaces used to abstract accesses to PCI controllers.
/// There is one EFI_PCI_IO_PROTOCOL instance for each PCI controller on a PCI bus.
/// A device driver that wishes to manage a PCI controller in a system will have to
/// retrieve the EFI_PCI_IO_PROTOCOL instance that is associated with the PCI controller.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCI_IO_PROTOCOL {
/**
  Reads from the memory space of a PCI controller. Returns either when the polling exit criteria is
  satisfied or after a defined duration.

  @param  This                  A pointer to the EFI_PCI_IO_PROTOCOL instance.
  @param  Width                 Signifies the width of the memory or I/O operations.
  @param  BarIndex              The BAR index of the standard PCI Configuration header to use as the
                                base address for the memory operation to perform.
  @param  Offset                The offset within the selected BAR to start the memory operation.
  @param  Mask                  Mask used for the polling criteria.
  @param  Value                 The comparison value used for the polling exit criteria.
  @param  Delay                 The number of 100 ns units to poll.
  @param  Result                Pointer to the last value read from the memory location.

  @retval EFI_SUCCESS           The last data returned from the access matched the poll exit criteria.
  @retval EFI_UNSUPPORTED       BarIndex not valid for this PCI controller.
  @retval EFI_UNSUPPORTED       Offset is not valid for the BarIndex of this PCI controller.
  @retval EFI_TIMEOUT           Delay expired before a match occurred.
  @retval EFI_OUT_OF_RESOURCES  The request could not be completed due to a lack of resources.
  @retval EFI_INVALID_PARAMETER One or more parameters are invalid.

**/
public readonly delegate* unmanaged<EFI_PCI_IO_PROTOCOL*,EFI_PCI_IO_PROTOCOL_WIDTH,byte,ulong,ulong,ulong,ulong,ulong*, EFI_STATUS> PollMem;
 public EFI_PCI_IO_PROTOCOL_POLL_IO_MEM           PollIo;
 public EFI_PCI_IO_PROTOCOL_ACCESS                Mem;
 public EFI_PCI_IO_PROTOCOL_ACCESS                Io;
 public EFI_PCI_IO_PROTOCOL_CONFIG_ACCESS         Pci;
 public EFI_PCI_IO_PROTOCOL_COPY_MEM              CopyMem;
 public EFI_PCI_IO_PROTOCOL_MAP                   Map;
 public EFI_PCI_IO_PROTOCOL_UNMAP                 Unmap;
 public EFI_PCI_IO_PROTOCOL_ALLOCATE_BUFFER       AllocateBuffer;
 public EFI_PCI_IO_PROTOCOL_FREE_BUFFER           FreeBuffer;
/**
  Frees memory that was allocated with AllocateBuffer().

  @param  This                  A pointer to the EFI_PCI_IO_PROTOCOL instance.
  @param  Pages                 The number of pages to free.
  @param  HostAddress           The base system memory address of the allocated range.

  @retval EFI_SUCCESS           The requested memory pages were freed.
  @retval EFI_INVALID_PARAMETER The memory range specified by HostAddress and Pages
                                was not allocated with AllocateBuffer().

**/
public readonly delegate* unmanaged<EFI_PCI_IO_PROTOCOL*, EFI_STATUS> Flush;
 public EFI_PCI_IO_PROTOCOL_GET_LOCATION          GetLocation;
 public EFI_PCI_IO_PROTOCOL_ATTRIBUTES            Attributes;
 public EFI_PCI_IO_PROTOCOL_GET_BAR_ATTRIBUTES    GetBarAttributes;
 public EFI_PCI_IO_PROTOCOL_SET_BAR_ATTRIBUTES    SetBarAttributes;

  ///
  /// The size, in bytes, of the ROM image.
  ///
 public ulong                                    RomSize;

  ///
  /// A pointer to the in memory copy of the ROM image. The PCI Bus Driver is responsible
  /// for allocating memory for the ROM image, and copying the contents of the ROM to memory.
  /// The contents of this buffer are either from the PCI option ROM that can be accessed
  /// through the ROM BAR of the PCI controller, or it is from a platform-specific location.
  /// The Attributes() function can be used to determine from which of these two sources
  /// the RomImage buffer was initialized.
  ///
 public void    *RomImage;
}

// extern EFI_GUID  gEfiPciIoProtocolGuid;

// #endif
