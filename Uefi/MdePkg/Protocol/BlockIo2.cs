using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Block IO2 protocol as defined in the UEFI 2.3.1 specification.

  The Block IO2 protocol defines an extension to the Block IO protocol which
  enables the ability to read and write data at a block level in a non-blocking
  manner.

  Copyright (c) 2011 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __BLOCK_IO2_H__
// #define __BLOCK_IO2_H__

// #include <Protocol/BlockIo.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_BLOCK_IO2_PROTOCOL_GUID => new GUID(
      0xa77b2472, 0xe282, 0x4e9f, 0xa2, 0x45, 0xc2, 0xc0, 0xe2, 0x7b, 0xbc, 0xc1);

  // typedef struct _EFI_BLOCK_IO2_PROTOCOL EFI_BLOCK_IO2_PROTOCOL;
}

/**
  The struct of Block IO2 Token.
**/
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLOCK_IO2_TOKEN
{
  ///
  /// If Event is NULL, then blocking I/O is performed.If Event is not NULL and
  /// non-blocking I/O is supported, then non-blocking I/O is performed, and
  /// Event will be signaled when the read request is completed.
  ///
  public EFI_EVENT Event;

  ///
  /// Defines whether or not the signaled event encountered an error.
  ///
  public EFI_STATUS TransactionStatus;
}

// /**
//   Reset the block device hardware.
// 
//   @param[in]  This                 Indicates a pointer to the calling context.
//   @param[in]  ExtendedVerification Indicates that the driver may perform a more
//                                    exhausive verification operation of the device
//                                    during reset.
// 
//   @retval EFI_SUCCESS          The device was reset.
//   @retval EFI_DEVICE_ERROR     The device is not functioning properly and could
//                                not be reset.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLOCK_RESET_EX)(
//   IN EFI_BLOCK_IO2_PROTOCOL  *This,
//   IN bool                 ExtendedVerification
//   );

// /**
//   Read BufferSize bytes from Lba into Buffer.
// 
//   This function reads the requested number of blocks from the device. All the
//   blocks are read, or an error is returned.
//   If EFI_DEVICE_ERROR, EFI_NO_MEDIA,_or EFI_MEDIA_CHANGED is returned and
//   non-blocking I/O is being used, the Event associated with this request will
//   not be signaled.
// 
//   @param[in]       This       Indicates a pointer to the calling context.
//   @param[in]       MediaId    Id of the media, changes every time the media is
//                               replaced.
//   @param[in]       Lba        The starting Logical Block Address to read from.
//   @param[in, out]  Token      A pointer to the token associated with the transaction.
//   @param[in]       BufferSize Size of Buffer, must be a multiple of device block size.
//   @param[out]      Buffer     A pointer to the destination buffer for the data. The
//                               caller is responsible for either having implicit or
//                               explicit ownership of the buffer.
// 
//   @retval EFI_SUCCESS           The read request was queued if Token->Event is
//                                 not NULL.The data was read correctly from the
//                                 device if the Token->Event is NULL.
//   @retval EFI_DEVICE_ERROR      The device reported an error while performing
//                                 the read.
//   @retval EFI_NO_MEDIA          There is no media in the device.
//   @retval EFI_MEDIA_CHANGED     The MediaId is not for the current media.
//   @retval EFI_BAD_BUFFER_SIZE   The BufferSize parameter is not a multiple of the
//                                 intrinsic block size of the device.
//   @retval EFI_INVALID_PARAMETER The read request contains LBAs that are not valid,
//                                 or the buffer is not on proper alignment.
//   @retval EFI_OUT_OF_RESOURCES  The request could not be completed due to a lack
//                                 of resources.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLOCK_READ_EX)(
//   IN     EFI_BLOCK_IO2_PROTOCOL *This,
//   IN     uint                 MediaId,
//   IN     EFI_LBA                LBA,
//   IN OUT EFI_BLOCK_IO2_TOKEN    *Token,
//   IN     ulong                  BufferSize,
//   OUT void                  *Buffer
//   );

// /**
//   Write BufferSize bytes from Lba into Buffer.
// 
//   This function writes the requested number of blocks to the device. All blocks
//   are written, or an error is returned.If EFI_DEVICE_ERROR, EFI_NO_MEDIA,
//   EFI_WRITE_PROTECTED or EFI_MEDIA_CHANGED is returned and non-blocking I/O is
//   being used, the Event associated with this request will not be signaled.
// 
//   @param[in]       This       Indicates a pointer to the calling context.
//   @param[in]       MediaId    The media ID that the write request is for.
//   @param[in]       Lba        The starting logical block address to be written. The
//                               caller is responsible for writing to only legitimate
//                               locations.
//   @param[in, out]  Token      A pointer to the token associated with the transaction.
//   @param[in]       BufferSize Size of Buffer, must be a multiple of device block size.
//   @param[in]       Buffer     A pointer to the source buffer for the data.
// 
//   @retval EFI_SUCCESS           The write request was queued if Event is not NULL.
//                                 The data was written correctly to the device if
//                                 the Event is NULL.
//   @retval EFI_WRITE_PROTECTED   The device can not be written to.
//   @retval EFI_NO_MEDIA          There is no media in the device.
//   @retval EFI_MEDIA_CHNAGED     The MediaId does not matched the current device.
//   @retval EFI_DEVICE_ERROR      The device reported an error while performing the write.
//   @retval EFI_BAD_BUFFER_SIZE   The Buffer was not a multiple of the block size of the device.
//   @retval EFI_INVALID_PARAMETER The write request contains LBAs that are not valid,
//                                 or the buffer is not on proper alignment.
//   @retval EFI_OUT_OF_RESOURCES  The request could not be completed due to a lack
//                                 of resources.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLOCK_WRITE_EX)(
//   IN     EFI_BLOCK_IO2_PROTOCOL  *This,
//   IN     uint                 MediaId,
//   IN     EFI_LBA                LBA,
//   IN OUT EFI_BLOCK_IO2_TOKEN    *Token,
//   IN     ulong                  BufferSize,
//   IN     void                   *Buffer
//   );

// /**
//   Flush the Block Device.
// 
//   If EFI_DEVICE_ERROR, EFI_NO_MEDIA,_EFI_WRITE_PROTECTED or EFI_MEDIA_CHANGED
//   is returned and non-blocking I/O is being used, the Event associated with
//   this request will not be signaled.
// 
//   @param[in]      This     Indicates a pointer to the calling context.
//   @param[in,out]  Token    A pointer to the token associated with the transaction
// 
//   @retval EFI_SUCCESS          The flush request was queued if Event is not NULL.
//                                All outstanding data was written correctly to the
//                                device if the Event is NULL.
//   @retval EFI_DEVICE_ERROR     The device reported an error while writting back
//                                the data.
//   @retval EFI_WRITE_PROTECTED  The device cannot be written to.
//   @retval EFI_NO_MEDIA         There is no media in the device.
//   @retval EFI_MEDIA_CHANGED    The MediaId is not for the current media.
//   @retval EFI_OUT_OF_RESOURCES The request could not be completed due to a lack
//                                of resources.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_BLOCK_FLUSH_EX)(
//   IN     EFI_BLOCK_IO2_PROTOCOL   *This,
//   IN OUT EFI_BLOCK_IO2_TOKEN      *Token
//   );

///
///  The Block I/O2 protocol defines an extension to the Block I/O protocol which
///  enables the ability to read and write data at a block level in a non-blocking
//   manner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLOCK_IO2_PROTOCOL
{
  ///
  /// A pointer to the EFI_BLOCK_IO_MEDIA data for this device.
  /// Type EFI_BLOCK_IO_MEDIA is defined in BlockIo.h.
  ///
  public EFI_BLOCK_IO_MEDIA* Media;

  public readonly delegate* unmanaged</* IN */EFI_BLOCK_IO2_PROTOCOL* /*This*/,/* IN */bool /*ExtendedVerification*/, EFI_STATUS> /*EFI_BLOCK_RESET_EX*/ Reset;
  public readonly delegate* unmanaged</* IN */EFI_BLOCK_IO2_PROTOCOL* /*This*/,/* IN */uint /*MediaId*/,/* IN */EFI_LBA /*LBA*/,/* IN OUT */EFI_BLOCK_IO2_TOKEN* /*Token*/,/* IN */ulong /*BufferSize*/,/* OUT */void* /*Buffer*/, EFI_STATUS> /*EFI_BLOCK_READ_EX*/ ReadBlocksEx;
  public readonly delegate* unmanaged</* IN */EFI_BLOCK_IO2_PROTOCOL* /*This*/,/* IN */uint /*MediaId*/,/* IN */EFI_LBA /*LBA*/,/* IN OUT */EFI_BLOCK_IO2_TOKEN* /*Token*/,/* IN */ulong /*BufferSize*/,/* IN */void* /*Buffer*/, EFI_STATUS> /*EFI_BLOCK_WRITE_EX*/ WriteBlocksEx;
  public readonly delegate* unmanaged</* IN */EFI_BLOCK_IO2_PROTOCOL* /*This*/,/* IN OUT */EFI_BLOCK_IO2_TOKEN* /*Token*/, EFI_STATUS> /*EFI_BLOCK_FLUSH_EX*/ FlushBlocksEx;
}

// extern EFI_GUID  gEfiBlockIo2ProtocolGuid;

// #endif
