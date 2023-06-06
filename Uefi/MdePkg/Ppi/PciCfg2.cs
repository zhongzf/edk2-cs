using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file declares PciCfg2 PPI.

  This ppi Provides platform or chipset-specific access to
  the PCI configuration space for a specific PCI segment.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This PPI is introduced in PI Version 1.0.

**/

// #ifndef __PEI_PCI_CFG2_H__
// #define __PEI_PCI_CFG2_H__

// #include <Library/BaseLib.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_PEI_PCI_CFG2_PPI_GUID => new GUID(0x57a449a, 0x1fdc, 0x4c06, 0xbf, 0xc9, 0xf5, 0x3f, 0x6a, 0x99, 0xbb, 0x92);

  // typedef struct _EFI_PEI_PCI_CFG2_PPI EFI_PEI_PCI_CFG2_PPI;

  //public const ulong EFI_PEI_PCI_CFG_ADDRESS = (bus, dev, func, reg) \;
  //  (ulong) ( \
  //  (((ulong) bus) << 24) | \
  //  (((ulong) dev) << 16) | \
  //  (((ulong) func) << 8) | \
  //  (((ulong) (reg)) < 256 ? ((ulong) (reg)) : (ulong) (LShiftU64 ((ulong) (reg), 32))))
}

///
/// EFI_PEI_PCI_CFG_PPI_WIDTH
///
public enum EFI_PEI_PCI_CFG_PPI_WIDTH
{
  ///
  ///  8-bit access
  ///
  EfiPeiPciCfgWidthUint8 = 0,
  ///
  /// 16-bit access
  ///
  EfiPeiPciCfgWidthUint16 = 1,
  ///
  /// 32-bit access
  ///
  EfiPeiPciCfgWidthUint32 = 2,
  ///
  /// 64-bit access
  ///
  EfiPeiPciCfgWidthUint64 = 3,
  EfiPeiPciCfgWidthMaximum
}

///
/// EFI_PEI_PCI_CFG_PPI_PCI_ADDRESS
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PEI_PCI_CFG_PPI_PCI_ADDRESS
{
  ///
  /// 8-bit register offset within the PCI configuration space for a given device's function
  /// space.
  ///
  public byte Register;
  ///
  /// Only the 3 least-significant bits are used to encode one of 8 possible functions within a
  /// given device.
  ///
  public byte Function;
  ///
  /// Only the 5 least-significant bits are used to encode one of 32 possible devices.
  ///
  public byte Device;
  ///
  /// 8-bit value to encode between 0 and 255 buses.
  ///
  public byte Bus;
  ///
  /// Register number in PCI configuration space. If this field is zero, then Register is used
  /// for the register number. If this field is non-zero, then Register is ignored and this field
  /// is used for the register number.
  ///
  public uint ExtendedRegister;
}

// /**
//   Reads from or write to a given location in the PCI configuration space.
// 
//   @param  PeiServices     An indirect pointer to the PEI Services Table published by the PEI Foundation.
// 
//   @param  This            Pointer to local data for the interface.
// 
//   @param  Width           The width of the access. Enumerated in bytes.
//                           See EFI_PEI_PCI_CFG_PPI_WIDTH above.
// 
//   @param  Address         The physical address of the access. The format of
//                           the address is described by EFI_PEI_PCI_CFG_PPI_PCI_ADDRESS.
// 
//   @param  Buffer          A pointer to the buffer of data..
// 
// 
//   @retval EFI_SUCCESS           The function completed successfully.
// 
//   @retval EFI_DEVICE_ERROR      There was a problem with the transaction.
// 
//   @retval EFI_DEVICE_NOT_READY  The device is not capable of supporting the operation at this
//                                 time.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PEI_PCI_CFG2_PPI_IO)(
//   IN CONST  EFI_PEI_SERVICES          **PeiServices,
//   IN CONST  EFI_PEI_PCI_CFG2_PPI      *This,
//   IN        EFI_PEI_PCI_CFG_PPI_WIDTH Width,
//   IN        ulong                    Address,
//   IN OUT    void                      *Buffer
//   );

// /**
//   Performs a read-modify-write operation on the contents
//   from a given location in the PCI configuration space.
// 
//   @param  PeiServices     An indirect pointer to the PEI Services Table
//                           published by the PEI Foundation.
// 
//   @param  This            Pointer to local data for the interface.
// 
//   @param  Width           The width of the access. Enumerated in bytes. Type
//                           EFI_PEI_PCI_CFG_PPI_WIDTH is defined in Read().
// 
//   @param  Address         The physical address of the access.
// 
//   @param  SetBits         Points to value to bitwise-OR with the read configuration value.
// 
//                           The size of the value is determined by Width.
// 
//   @param  ClearBits       Points to the value to negate and bitwise-AND with the read configuration value.
//                           The size of the value is determined by Width.
// 
// 
//   @retval EFI_SUCCESS           The function completed successfully.
// 
//   @retval EFI_DEVICE_ERROR      There was a problem with the transaction.
// 
//   @retval EFI_DEVICE_NOT_READY  The device is not capable of supporting
//                                 the operation at this time.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_PEI_PCI_CFG2_PPI_RW)(
//   IN CONST  EFI_PEI_SERVICES          **PeiServices,
//   IN CONST  EFI_PEI_PCI_CFG2_PPI      *This,
//   IN        EFI_PEI_PCI_CFG_PPI_WIDTH Width,
//   IN        ulong                    Address,
//   IN        void                      *SetBits,
//   IN        void                      *ClearBits
//   );

///
/// The EFI_PEI_PCI_CFG_PPI interfaces are used to abstract accesses to PCI
/// controllers behind a PCI root bridge controller.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PEI_PCI_CFG2_PPI
{
  public readonly delegate* unmanaged</* IN CONST */EFI_PEI_SERVICES** /*PeiServices*/,/* IN CONST */EFI_PEI_PCI_CFG2_PPI* /*This*/,/* IN */EFI_PEI_PCI_CFG_PPI_WIDTH /*Width*/,/* IN */ulong /*Address*/,/* IN OUT */void* /*Buffer*/, EFI_STATUS> /*EFI_PEI_PCI_CFG2_PPI_IO*/ Read;
  public readonly delegate* unmanaged</* IN CONST */EFI_PEI_SERVICES** /*PeiServices*/,/* IN CONST */EFI_PEI_PCI_CFG2_PPI* /*This*/,/* IN */EFI_PEI_PCI_CFG_PPI_WIDTH /*Width*/,/* IN */ulong /*Address*/,/* IN OUT */void* /*Buffer*/, EFI_STATUS> /*EFI_PEI_PCI_CFG2_PPI_IO*/ Write;
  public readonly delegate* unmanaged</* IN CONST */EFI_PEI_SERVICES** /*PeiServices*/,/* IN CONST */EFI_PEI_PCI_CFG2_PPI* /*This*/,/* IN */EFI_PEI_PCI_CFG_PPI_WIDTH /*Width*/,/* IN */ulong /*Address*/,/* IN */void* /*SetBits*/,/* IN */void* /*ClearBits*/, EFI_STATUS> /*EFI_PEI_PCI_CFG2_PPI_RW*/ Modify;
  ///
  /// The PCI bus segment which the specified functions will access.
  ///
  public ushort Segment;
}

// extern EFI_GUID  gEfiPciCfg2PpiGuid;

// #endif
