using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file defines the EFI Erase Block Protocol.

  Copyright (c) 2016, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.6

**/

// #ifndef __EFI_ERASE_BLOCK_PROTOCOL_H__
// #define __EFI_ERASE_BLOCK_PROTOCOL_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_ERASE_BLOCK_PROTOCOL_GUID => new GUID(
      0x95a9a93e, 0xa86e, 0x4926, 0xaa, 0xef, 0x99, 0x18, 0xe7, 0x72, 0xd9, 0x87);

  // typedef struct _EFI_ERASE_BLOCK_PROTOCOL EFI_ERASE_BLOCK_PROTOCOL;

  public const ulong EFI_ERASE_BLOCK_PROTOCOL_REVISION = ((2 << 16) | (60));
}

///
/// EFI_ERASE_BLOCK_TOKEN
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ERASE_BLOCK_TOKEN
{
  //
  // If Event is NULL, then blocking I/O is performed. If Event is not NULL and
  // non-blocking I/O is supported, then non-blocking I/O is performed, and
  // Event will be signaled when the erase request is completed.
  //
  public EFI_EVENT Event;
  //
  // Defines whether the signaled event encountered an error.
  //
  public EFI_STATUS TransactionStatus;
}

// /**
//   Erase a specified number of device blocks.
// 
//   @param[in]       This           Indicates a pointer to the calling context.
//   @param[in]       MediaId        The media ID that the erase request is for.
//   @param[in]       LBA            The starting logical block address to be
//                                   erased. The caller is responsible for erasing
//                                   only legitimate locations.
//   @param[in, out]  Token          A pointer to the token associated with the
//                                   transaction.
//   @param[in]       Size           The size in bytes to be erased. This must be
//                                   a multiple of the physical block size of the
//                                   device.
// 
//   @retval EFI_SUCCESS             The erase request was queued if Event is not
//                                   NULL. The data was erased correctly to the
//                                   device if the Event is NULL.to the device.
//   @retval EFI_WRITE_PROTECTED     The device cannot be erased due to write
//                                   protection.
//   @retval EFI_DEVICE_ERROR        The device reported an error while attempting
//                                   to perform the erase operation.
//   @retval EFI_INVALID_PARAMETER   The erase request contains LBAs that are not
//                                   valid.
//   @retval EFI_NO_MEDIA            There is no media in the device.
//   @retval EFI_MEDIA_CHANGED       The MediaId is not for the current media.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLOCK_ERASE)(
//   IN     EFI_ERASE_BLOCK_PROTOCOL      *This,
//   IN     uint                        MediaId,
//   IN     EFI_LBA                       LBA,
//   IN OUT EFI_ERASE_BLOCK_TOKEN         *Token,
//   IN     ulong                         Size
//   );

///
/// The EFI Erase Block Protocol provides the ability for a device to expose
/// erase functionality. This optional protocol is installed on the same handle
/// as the EFI_BLOCK_IO_PROTOCOL or EFI_BLOCK_IO2_PROTOCOL.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ERASE_BLOCK_PROTOCOL
{
  //
  // The revision to which the EFI_ERASE_BLOCK_PROTOCOL adheres. All future
  // revisions must be backwards compatible. If a future version is not
  // backwards compatible, it is not the same GUID.
  //
  public ulong Revision;
  //
  // Returns the erase length granularity as a number of logical blocks. A
  // value of 1 means the erase granularity is one logical block.
  //
  public uint EraseLengthGranularity;
  public readonly delegate* unmanaged</* IN */EFI_ERASE_BLOCK_PROTOCOL* /*This*/,/* IN */uint /*MediaId*/,/* IN */EFI_LBA /*LBA*/,/* IN OUT */EFI_ERASE_BLOCK_TOKEN* /*Token*/,/* IN */ulong /*Size*/, EFI_STATUS> /*EFI_BLOCK_ERASE*/ EraseBlocks;
}

// extern EFI_GUID  gEfiEraseBlockProtocolGuid;

// #endif
