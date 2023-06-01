namespace Uefi;
/** @file
  Block IO protocol as defined in the UEFI 2.0 specification.

  The Block IO protocol is used to abstract block devices like hard drives,
  DVD-ROMs and floppy drives.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __BLOCK_IO_H__
// #define __BLOCK_IO_H__

public static EFI_GUID EFI_BLOCK_IO_PROTOCOL_GUID = new GUID(
    0x964e5b21, 0x6459, 0x11d2, new byte[] { 0x8e, 0x39, 0x0, 0xa0, 0xc9, 0x69, 0x72, 0x3b });

// typedef struct _EFI_BLOCK_IO_PROTOCOL EFI_BLOCK_IO_PROTOCOL;

///
/// Protocol GUID name defined in EFI1.1.
///
public static ulong BLOCK_IO_PROTOCOL = EFI_BLOCK_IO_PROTOCOL_GUID;

///
/// Protocol defined in EFI1.1.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLOCK_IO { EFI_BLOCK_IO_PROTOCOL Value; public static implicit operator EFI_BLOCK_IO(EFI_BLOCK_IO_PROTOCOL value) => new EFI_BLOCK_IO() { Value = value }; public static implicit operator EFI_BLOCK_IO_PROTOCOL(EFI_BLOCK_IO value) => value.Value; }






























































































/**
  Block IO read only mode data and updated only via members of BlockIO
**/
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLOCK_IO_MEDIA
{
  ///
  /// The curent media Id. If the media changes, this value is changed.
  ///
  public uint MediaId;

  ///
  /// TRUE if the media is removable; otherwise, FALSE.
  ///
  public bool RemovableMedia;

  ///
  /// TRUE if there is a media currently present in the device;
  /// othersise, FALSE. THis field shows the media present status
  /// as of the most recent ReadBlocks() or WriteBlocks() call.
  ///
  public bool MediaPresent;

  ///
  /// TRUE if LBA 0 is the first block of a partition; otherwise
  /// FALSE. For media with only one partition this would be TRUE.
  ///
  public bool LogicalPartition;

  ///
  /// TRUE if the media is marked read-only otherwise, FALSE.
  /// This field shows the read-only status as of the most recent WriteBlocks () call.
  ///
  public bool ReadOnly;

  ///
  /// TRUE if the WriteBlock () function caches write data.
  ///
  public bool WriteCaching;

  ///
  /// The intrinsic block size of the device. If the media changes, then
  /// this field is updated.
  ///
  public uint BlockSize;

  ///
  /// Supplies the alignment requirement for any buffer to read or write block(s).
  ///
  public uint IoAlign;

  ///
  /// The last logical block address on the device.
  /// If the media changes, then this field is updated.
  ///
  public EFI_LBA LastBlock;

  ///
  /// Only present if EFI_BLOCK_IO_PROTOCOL.Revision is greater than or equal to
  /// EFI_BLOCK_IO_PROTOCOL_REVISION2. Returns the first LBA is aligned to
  /// a physical block boundary.
  ///
  public EFI_LBA LowestAlignedLba;

  ///
  /// Only present if EFI_BLOCK_IO_PROTOCOL.Revision is greater than or equal to
  /// EFI_BLOCK_IO_PROTOCOL_REVISION2. Returns the number of logical blocks
  /// per physical block.
  ///
  public uint LogicalBlocksPerPhysicalBlock;

  ///
  /// Only present if EFI_BLOCK_IO_PROTOCOL.Revision is greater than or equal to
  /// EFI_BLOCK_IO_PROTOCOL_REVISION3. Returns the optimal transfer length
  /// granularity as a number of logical blocks.
  ///
  public uint OptimalTransferLengthGranularity;
}

public static ulong EFI_BLOCK_IO_PROTOCOL_REVISION = 0x00010000;
public static ulong EFI_BLOCK_IO_PROTOCOL_REVISION2 = 0x00020001;
public static ulong EFI_BLOCK_IO_PROTOCOL_REVISION3 = 0x0002001F;

///
/// Revision defined in EFI1.1.
///
public static ulong EFI_BLOCK_IO_INTERFACE_REVISION = EFI_BLOCK_IO_PROTOCOL_REVISION;

///
///  This protocol provides control over block devices.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BLOCK_IO_PROTOCOL
{
  ///
  /// The revision to which the block IO interface adheres. All future
  /// revisions must be backwards compatible. If a future version is not
  /// back wards compatible, it is not the same GUID.
  ///
  public ulong Revision;
  ///
  /// Pointer to the EFI_BLOCK_IO_MEDIA data for this device.
  ///
  public EFI_BLOCK_IO_MEDIA* Media;

  /**
    Reset the Block Device.

    @param  This                 Indicates a pointer to the calling context.
    @param  ExtendedVerification Driver may perform diagnostics on reset.

    @retval EFI_SUCCESS          The device was reset.
    @retval EFI_DEVICE_ERROR     The device is not functioning properly and could
                                 not be reset.

  **/
  public readonly delegate* unmanaged<EFI_BLOCK_IO_PROTOCOL*, bool, EFI_STATUS> Reset;
  /**
    Read BufferSize bytes from Lba into Buffer.

    @param  This       Indicates a pointer to the calling context.
    @param  MediaId    Id of the media, changes every time the media is replaced.
    @param  Lba        The starting Logical Block Address to read from
    @param  BufferSize Size of Buffer, must be a multiple of device block size.
    @param  Buffer     A pointer to the destination buffer for the data. The caller is
                       responsible for either having implicit or explicit ownership of the buffer.

    @retval EFI_SUCCESS           The data was read correctly from the device.
    @retval EFI_DEVICE_ERROR      The device reported an error while performing the read.
    @retval EFI_NO_MEDIA          There is no media in the device.
    @retval EFI_MEDIA_CHANGED     The MediaId does not matched the current device.
    @retval EFI_BAD_BUFFER_SIZE   The Buffer was not a multiple of the block size of the device.
    @retval EFI_INVALID_PARAMETER The read request contains LBAs that are not valid,
                                  or the buffer is not on proper alignment.

  **/
  public readonly delegate* unmanaged<EFI_BLOCK_IO_PROTOCOL*, uint, EFI_LBA, ulong, void*, EFI_STATUS> ReadBlocks;
  /**
    Write BufferSize bytes from Lba into Buffer.

    @param  This       Indicates a pointer to the calling context.
    @param  MediaId    The media ID that the write request is for.
    @param  Lba        The starting logical block address to be written. The caller is
                       responsible for writing to only legitimate locations.
    @param  BufferSize Size of Buffer, must be a multiple of device block size.
    @param  Buffer     A pointer to the source buffer for the data.

    @retval EFI_SUCCESS           The data was written correctly to the device.
    @retval EFI_WRITE_PROTECTED   The device can not be written to.
    @retval EFI_DEVICE_ERROR      The device reported an error while performing the write.
    @retval EFI_NO_MEDIA          There is no media in the device.
    @retval EFI_MEDIA_CHNAGED     The MediaId does not matched the current device.
    @retval EFI_BAD_BUFFER_SIZE   The Buffer was not a multiple of the block size of the device.
    @retval EFI_INVALID_PARAMETER The write request contains LBAs that are not valid,
                                  or the buffer is not on proper alignment.

  **/
  public readonly delegate* unmanaged<EFI_BLOCK_IO_PROTOCOL*, uint, EFI_LBA, ulong, void*, EFI_STATUS> WriteBlocks;
  /**
    Flush the Block Device.

    @param  This              Indicates a pointer to the calling context.

    @retval EFI_SUCCESS       All outstanding data was written to the device
    @retval EFI_DEVICE_ERROR  The device reported an error while writting back the data
    @retval EFI_NO_MEDIA      There is no media in the device.

  **/
  public readonly delegate* unmanaged<EFI_BLOCK_IO_PROTOCOL*, EFI_STATUS> FlushBlocks;
}

// extern EFI_GUID  gEfiBlockIoProtocolGuid;

// #endif
