namespace Uefi;
/** @file
  Device IO protocol as defined in the EFI 1.10 specification.

  Device IO is used to abstract hardware access to devices. It includes
  memory mapped IO, IO, PCI Config space, and DMA.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __DEVICE_IO_H__
// #define __DEVICE_IO_H__

public static EFI_GUID EFI_DEVICE_IO_PROTOCOL_GUID = new GUID( 
    0xaf6ac311, 0x84c3, 0x11d2, new byte[] {0x8e, 0x3c, 0x00, 0xa0, 0xc9, 0x69, 0x72, 0x3b });

// typedef struct _EFI_DEVICE_IO_PROTOCOL EFI_DEVICE_IO_PROTOCOL;

///
/// Protocol GUID name defined in EFI1.1.
///
public static ulong DEVICE_IO_PROTOCOL = EFI_DEVICE_IO_PROTOCOL_GUID;

///
/// Protocol defined in EFI1.1.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEVICE_IO_INTERFACE { EFI_DEVICE_IO_PROTOCOL Value; public static implicit operator EFI_DEVICE_IO_INTERFACE(EFI_DEVICE_IO_PROTOCOL value) => new EFI_DEVICE_IO_INTERFACE() { Value = value }; public static implicit operator EFI_DEVICE_IO_PROTOCOL(EFI_DEVICE_IO_INTERFACE value) => value.Value;}

///
/// Device IO Access Width
///
public enum EFI_IO_WIDTH {
  IO_UINT8  = 0,
  IO_UINT16 = 1,
  IO_UINT32 = 2,
  IO_UINT64 = 3,
  //
  // Below enumerations are added in "Extensible Firmware Interface Specification,
  // Version 1.10, Specification Update, Version 001".
  //
  MMIO_COPY_UINT8  = 4,
  MMIO_COPY_UINT16 = 5,
  MMIO_COPY_UINT32 = 6,
  MMIO_COPY_UINT64 = 7
}





























[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IO_ACCESS {
/**
  Enables a driver to access device registers in the appropriate memory or I/O space.

  @param  This                  A pointer to the EFI_DEVICE_IO_INTERFACE instance.





















  @param  This                  A pointer to the EFI_DEVICE_IO_INTERFACE instance.
  @param  PciAddress            The PCI configuration space address of the device whose Device Path
                                is going to be returned.
  @param  PciDevicePath         A pointer to the pointer for the EFI Device Path for PciAddress.
                                Memory for the Device Path is allocated from the pool.

  @retval EFI_SUCCESS           The PciDevicePath returns a pointer to a valid EFI Device Path.
  @retval EFI_OUT_OF_RESOURCES  The request could not be completed due to a lack of resources.
  @retval EFI_UNSUPPORTED       The PciAddress does not map to a valid EFI Device Path.

**/
typedef
EFI_STATUS
(EFIAPI *EFI_PCI_DEVICE_PATH)(
  IN EFI_DEVICE_IO_PROTOCOL           *This,
  IN ulong                           PciAddress,
  IN OUT EFI_DEVICE_PATH_PROTOCOL     **PciDevicePath
  );

public enum EFI_IO_OPERATION_TYPE {
  ///














































  );


























  @param  HostAddress           A pointer to store the base address of the allocated range.














  IN ulong                            Pages,





















  @param  This                  A pointer to the EFI_DEVICE_IO_INTERFACE instance.
  @param  Pages                 The number of pages to free.
  @param  HostAddress           The base address of the range to free.

  @retval EFI_SUCCESS           The requested memory pages were allocated.
  @retval EFI_NOT_FOUND         The requested memory pages were not allocated with
                                AllocateBuffer().
  @retval EFI_INVALID_PARAMETER HostAddress is not page aligned or Pages is invalid.

**/
typedef
EFI_STATUS
(EFIAPI *EFI_IO_FREE_BUFFER)(
  IN EFI_DEVICE_IO_PROTOCOL           *This,
  IN ulong                            Pages,
  IN EFI_PHYSICAL_ADDRESS             HostAddress
  );

///
/// This protocol provides the basic Memory, I/O, and PCI interfaces that
/// are used to abstract accesses to devices.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEVICE_IO_PROTOCOL {
  ///
  /// Allows reads and writes to memory mapped I/O space.
  ///
 public EFI_IO_ACCESS             Mem;
  ///
  /// Allows reads and writes to I/O space.
  ///
 public EFI_IO_ACCESS             Io;
  ///
  /// Allows reads and writes to PCI configuration space.
  ///
 public EFI_IO_ACCESS             Pci;
 public EFI_IO_MAP                Map;
 public EFI_PCI_DEVICE_PATH       PciDevicePath;
 public EFI_IO_UNMAP              Unmap;
 public EFI_IO_ALLOCATE_BUFFER    AllocateBuffer;
 public EFI_IO_FLUSH              Flush;
 public EFI_IO_FREE_BUFFER        FreeBuffer;
}

// extern EFI_GUID  gEfiDeviceIoProtocolGuid;

// #endif
