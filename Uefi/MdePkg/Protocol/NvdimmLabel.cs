namespace Uefi;
/** @file
  EFI NVDIMM Label Protocol Definition

  The EFI NVDIMM Label Protocol is used to Provides services that allow management
  of labels contained in a Label Storage Area that are associated with a specific
  NVDIMM Device Path.

Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in UEFI Specification 2.7.

**/

// #ifndef __EFI_NVDIMM_LABEL_PROTOCOL_H__
// #define __EFI_NVDIMM_LABEL_PROTOCOL_H__

public static EFI_GUID EFI_NVDIMM_LABEL_PROTOCOL_GUID = new GUID(
    0xd40b6b80, 0x97d5, 0x4282, new byte[] { 0xbb, 0x1d, 0x22, 0x3a, 0x16, 0x91, 0x80, 0x58 });

// typedef struct _EFI_NVDIMM_LABEL_PROTOCOL EFI_NVDIMM_LABEL_PROTOCOL;

public const ulong EFI_NVDIMM_LABEL_INDEX_SIG_LEN = 16;
public const ulong EFI_NVDIMM_LABEL_INDEX_ALIGN = 256;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_NVDIMM_LABEL_INDEX_BLOCK
{
  ///
  /// Signature of the Index Block data structure. Must be "NAMESPACE_INDEX\0".
  ///
  public fixed byte Sig[EFI_NVDIMM_LABEL_INDEX_SIG_LEN];

  ///
  /// Attributes of this Label Storage Area.
  ///
  public fixed byte Flags[3];

  ///
  /// Size of each label in bytes, 128 bytes << LabelSize.
  /// 1 means 256 bytes, 2 means 512 bytes, etc. Shall be 1 or greater.
  ///
  public byte LabelSize;

  ///
  /// Sequence number used to identify which of the two Index Blocks is current.
  ///
  public uint Seq;

  ///
  /// The offset of this Index Block in the Label Storage Area.
  ///
  public ulong MyOff;

  ///
  /// The size of this Index Block in bytes.
  /// This field must be a multiple of the EFI_NVDIMM_LABEL_INDEX_ALIGN.
  ///
  public ulong MySize;

  ///
  /// The offset of the other Index Block paired with this one.
  ///
  public ulong OtherOff;

  ///
  /// The offset of the first slot where labels are stored in this Label Storage Area.
  ///
  public ulong LabelOff;

  ///
  /// The total number of slots for storing labels in this Label Storage Area.
  ///
  public uint NSlot;

  ///
  /// Major version number. Value shall be 1.
  ///
  public ushort Major;

  ///
  /// Minor version number. Value shall be 2.
  ///
  public ushort Minor;

  ///
  /// 64-bit Fletcher64 checksum of all fields in this Index Block.
  ///
  public ulong Checksum;

  ///
  /// Array of unsigned bytes implementing a bitmask that tracks which label slots are free.
  /// A bit value of 0 indicates in use, 1 indicates free.
  /// The size of this field is the number of bytes required to hold the bitmask with NSlot bits,
  /// padded with additional zero bytes to make the Index Block size a multiple of EFI_NVDIMM_LABEL_INDEX_ALIGN.
  /// Any bits allocated beyond NSlot bits must be zero.
  ///
  public fixed byte Free[];
}

public const ulong EFI_NVDIMM_LABEL_NAME_LEN = 64;

///
/// The label is read-only.
///
public const ulong EFI_NVDIMM_LABEL_FLAGS_ROLABEL = 0x00000001;

///
/// When set, the complete label set is local to a single NVDIMM Label Storage Area.
/// When clear, the complete label set is contained on multiple NVDIMM Label Storage Areas.
///
public const ulong EFI_NVDIMM_LABEL_FLAGS_LOCAL = 0x00000002;

///
/// This reserved flag is utilized on older implementations and has been deprecated.
/// Do not use.
//
public const ulong EFI_NVDIMM_LABEL_FLAGS_RESERVED = 0x00000004;

///
/// When set, the label set is being updated.
///
public const ulong EFI_NVDIMM_LABEL_FLAGS_UPDATING = 0x00000008;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_NVDIMM_LABEL
{
  ///
  /// Unique Label Identifier UUID per RFC 4122.
  ///
  public EFI_GUID Uuid;

  ///
  /// NULL-terminated string using UTF-8 character formatting.
  ///
  public fixed byte Name[EFI_NVDIMM_LABEL_NAME_LEN];

  ///
  /// Attributes of this namespace.
  ///
  public uint Flags;

  ///
  /// Total number of labels describing this namespace.
  ///
  public ushort NLabel;

  ///
  /// Position of this label in list of labels for this namespace.
  ///
  public ushort Position;

  ///
  /// The SetCookie is utilized by SW to perform consistency checks on the Interleave Set to verify the current
  /// physical device configuration matches the original physical configuration when the labels were created
  /// for the set.The label is considered invalid if the actual label set cookie doesn't match the cookie stored here.
  ///
  public ulong SetCookie;

  ///
  /// This is the default logical block size in bytes and may be superseded by a block size that is specified
  /// in the AbstractionGuid.
  ///
  public ulong LbaSize;

  ///
  /// The DPA is the DIMM Physical address where the NVM contributing to this namespace begins on this NVDIMM.
  ///
  public ulong Dpa;

  ///
  /// The extent of the DPA contributed by this label.
  ///
  public ulong RawSize;

  ///
  /// Current slot in the Label Storage Area where this label is stored.
  ///
  public uint Slot;

  ///
  /// Alignment hint used to advertise the preferred alignment of the data from within the namespace defined by this label.
  ///
  public byte Alignment;

  ///
  /// Shall be 0.
  ///
  public fixed byte Reserved[3];

  ///
  /// Range Type GUID that describes the access mechanism for the specified DPA range.
  ///
  public EFI_GUID TypeGuid;

  ///
  /// Identifies the address abstraction mechanism for this namespace. A value of 0 indicates no mechanism used.
  ///
  public EFI_GUID AddressAbstractionGuid;

  ///
  /// Shall be 0.
  ///
  public fixed byte Reserved1[88];

  ///
  /// 64-bit Fletcher64 checksum of all fields in this Label.
  /// This field is considered zero when the checksum is computed.
  ///
  public ulong Checksum;
}

typedef struct  {
  ///
  /// The Region Offset field from the ACPI NFIT NVDIMM Region Mapping Structure for a given entry.
  ///
  ulong RegionOffset;

///
/// The serial number of the NVDIMM, assigned by the module vendor.
///
uint SerialNumber;

///
/// The identifier indicating the vendor of the NVDIMM.
///
ushort VendorId;

///
/// The manufacturing date of the NVDIMM, assigned by the module vendor.
///
ushort ManufacturingDate;

///
/// The manufacturing location from for the NVDIMM, assigned by the module vendor.
///
byte ManufacturingLocation;

///
/// Shall be 0.
///
byte Reserved[31];
} EFI_NVDIMM_LABEL_SET_COOKIE_MAP;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_NVDIMM_LABEL_SET_COOKIE_INFO
{
  ///
  /// Array size is 1 if EFI_NVDIMM_LABEL_FLAGS_LOCAL is set indicating a Local Namespaces.
  ///
  public fixed EFI_NVDIMM_LABEL_SET_COOKIE_MAP Mapping[0];
}





















































































///
/// Provides services that allow management of labels contained in a Label Storage Area.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_NVDIMM_LABEL_PROTOCOL
{
  /**
    Retrieves the Label Storage Area size and the maximum transfer size for the LabelStorageRead and
    LabelStorageWrite methods.

    @param  This                   A pointer to the EFI_NVDIMM_LABEL_PROTOCOL instance.
    @param  SizeOfLabelStorageArea The size of the Label Storage Area for the NVDIMM in bytes.
    @param  MaxTransferLength      The maximum number of bytes that can be transferred in a single call to
                                   LabelStorageRead or LabelStorageWrite.

    @retval EFI_SUCCESS            The size of theLabel Storage Area and maximum transfer size returned are valid.
    @retval EFI_ACCESS_DENIED      The Label Storage Area for the NVDIMM device is not currently accessible.
    @retval EFI_DEVICE_ERROR       A physical device error occurred and the data transfer failed to complete.
  **/
  public readonly delegate* unmanaged<EFI_NVDIMM_LABEL_PROTOCOL*, uint*, uint*, EFI_STATUS> LabelStorageInformation;
  /**
    Retrieves the label data for the requested offset and length from within the Label Storage Area for
    the NVDIMM.

    @param  This                   A pointer to the EFI_NVDIMM_LABEL_PROTOCOL instance.
    @param  Offset                 The byte offset within the Label Storage Area to read from.
    @param  TransferLength         Number of bytes to read from the Label Storage Area beginning at the byte
                                   Offset specified. A TransferLength of 0 reads no data.
    @param  LabelData              The return label data read at the requested offset and length from within
                                   the Label Storage Area.

    @retval EFI_SUCCESS            The label data from the Label Storage Area for the NVDIMM was read successfully
                                   at the specified Offset and TransferLength and LabelData contains valid data.
    @retval EFI_INVALID_PARAMETER  Any of the following are true:
                                   - Offset > SizeOfLabelStorageArea reported in the LabelStorageInformation return data.
                                   - Offset + TransferLength is > SizeOfLabelStorageArea reported in the
                                     LabelStorageInformation return data.
                                   - TransferLength is > MaxTransferLength reported in the LabelStorageInformation return
                                     data.
    @retval EFI_ACCESS_DENIED      The Label Storage Area for the NVDIMM device is not currently accessible and labels
                                   cannot be read at this time.
    @retval EFI_DEVICE_ERROR       A physical device error occurred and the data transfer failed to complete.
  **/
  public readonly delegate* unmanaged<CONST, uint, uint, byte*, EFI_STATUS> LabelStorageRead;
  /**
    Writes the label data for the requested offset and length in to the Label Storage Area for the NVDIMM.

    @param  This                   A pointer to the EFI_NVDIMM_LABEL_PROTOCOL instance.
    @param  Offset                 The byte offset within the Label Storage Area to write to.
    @param  TransferLength         Number of bytes to write to the Label Storage Area beginning at the byte
                                   Offset specified. A TransferLength of 0 writes no data.
    @param  LabelData              The return label data write at the requested offset and length from within
                                   the Label Storage Area.

    @retval EFI_SUCCESS            The label data from the Label Storage Area for the NVDIMM written read successfully
                                   at the specified Offset and TransferLength.
    @retval EFI_INVALID_PARAMETER  Any of the following are true:
                                   - Offset > SizeOfLabelStorageArea reported in the LabelStorageInformation return data.
                                   - Offset + TransferLength is > SizeOfLabelStorageArea reported in the
                                     LabelStorageInformation return data.
                                   - TransferLength is > MaxTransferLength reported in the LabelStorageInformation return
                                     data.
    @retval EFI_ACCESS_DENIED      The Label Storage Area for the NVDIMM device is not currently accessible and labels
                                   cannot be written at this time.
    @retval EFI_DEVICE_ERROR       A physical device error occurred and the data transfer failed to complete.
  **/
  public readonly delegate* unmanaged<CONST, uint, uint, byte*, EFI_STATUS> LabelStorageWrite;
}

// extern EFI_GUID  gEfiNvdimmLabelProtocolGuid;

// #endif
