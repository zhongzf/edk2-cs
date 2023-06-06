using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  The firmware file related definitions in PI.

Copyright (c) 2006 - 2017, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  PI Version 1.6.

**/

// #ifndef __PI_FIRMWARE_FILE_H__
// #define __PI_FIRMWARE_FILE_H__

// #pragma pack(1)
///
/// Used to verify the integrity of the file.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_FFS_INTEGRITY_CHECK
{
  /*   struct { */
  ///
  /// The IntegrityCheck.Checksum.Header field is an 8-bit checksum of the file
  /// header. The State and IntegrityCheck.Checksum.File fields are assumed
  /// to be zero and the checksum is calculated such that the entire header sums to zero.
  ///
  [FieldOffset(0)] public byte Header;
  ///
  /// If the FFS_ATTRIB_CHECKSUM (see definition below) bit of the Attributes
  /// field is set to one, the IntegrityCheck.Checksum.File field is an 8-bit
  /// checksum of the file data.
  /// If the FFS_ATTRIB_CHECKSUM bit of the Attributes field is cleared to zero,
  /// the IntegrityCheck.Checksum.File field must be initialized with a value of
  /// 0xAA. The IntegrityCheck.Checksum.File field is valid any time the
  /// EFI_FILE_DATA_VALID bit is set in the State field.
  ///
  [FieldOffset(0)] public byte File;
  /*   } Checksum; */
  ///
  /// This is the full 16 bits of the IntegrityCheck field.
  ///
  [FieldOffset(0)] public ushort Checksum16;
}

public unsafe partial class EFI
{
  ///
  /// FFS_FIXED_CHECKSUM is the checksum value used when the
  /// FFS_ATTRIB_CHECKSUM attribute bit is clear.
  ///
  public const ulong FFS_FIXED_CHECKSUM = 0xAA;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FV_FILETYPE { byte Value; public static implicit operator EFI_FV_FILETYPE(byte value) => new EFI_FV_FILETYPE() { Value = value }; public static implicit operator byte(EFI_FV_FILETYPE value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FFS_FILE_ATTRIBUTES { byte Value; public static implicit operator EFI_FFS_FILE_ATTRIBUTES(byte value) => new EFI_FFS_FILE_ATTRIBUTES() { Value = value }; public static implicit operator byte(EFI_FFS_FILE_ATTRIBUTES value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FFS_FILE_STATE { byte Value; public static implicit operator EFI_FFS_FILE_STATE(byte value) => new EFI_FFS_FILE_STATE() { Value = value }; public static implicit operator byte(EFI_FFS_FILE_STATE value) => value.Value; }

public unsafe partial class EFI
{
  ///
  /// File Types Definitions
  ///
  public const ulong EFI_FV_FILETYPE_ALL = 0x00;
  public const ulong EFI_FV_FILETYPE_RAW = 0x01;
  public const ulong EFI_FV_FILETYPE_FREEFORM = 0x02;
  public const ulong EFI_FV_FILETYPE_SECURITY_CORE = 0x03;
  public const ulong EFI_FV_FILETYPE_PEI_CORE = 0x04;
  public const ulong EFI_FV_FILETYPE_DXE_CORE = 0x05;
  public const ulong EFI_FV_FILETYPE_PEIM = 0x06;
  public const ulong EFI_FV_FILETYPE_DRIVER = 0x07;
  public const ulong EFI_FV_FILETYPE_COMBINED_PEIM_DRIVER = 0x08;
  public const ulong EFI_FV_FILETYPE_APPLICATION = 0x09;
  public const ulong EFI_FV_FILETYPE_MM = 0x0A;
  public const ulong EFI_FV_FILETYPE_SMM = EFI_FV_FILETYPE_MM;
  public const ulong EFI_FV_FILETYPE_FIRMWARE_VOLUME_IMAGE = 0x0B;
  public const ulong EFI_FV_FILETYPE_COMBINED_MM_DXE = 0x0C;
  public const ulong EFI_FV_FILETYPE_COMBINED_SMM_DXE = EFI_FV_FILETYPE_COMBINED_MM_DXE;
  public const ulong EFI_FV_FILETYPE_MM_CORE = 0x0D;
  public const ulong EFI_FV_FILETYPE_SMM_CORE = EFI_FV_FILETYPE_MM_CORE;
  public const ulong EFI_FV_FILETYPE_MM_STANDALONE = 0x0E;
  public const ulong EFI_FV_FILETYPE_MM_CORE_STANDALONE = 0x0F;
  public const ulong EFI_FV_FILETYPE_OEM_MIN = 0xc0;
  public const ulong EFI_FV_FILETYPE_OEM_MAX = 0xdf;
  public const ulong EFI_FV_FILETYPE_DEBUG_MIN = 0xe0;
  public const ulong EFI_FV_FILETYPE_DEBUG_MAX = 0xef;
  public const ulong EFI_FV_FILETYPE_FFS_MIN = 0xf0;
  public const ulong EFI_FV_FILETYPE_FFS_MAX = 0xff;
  public const ulong EFI_FV_FILETYPE_FFS_PAD = 0xf0;
  ///
  /// FFS File Attributes.
  ///
  public const ulong FFS_ATTRIB_LARGE_FILE = 0x01;
  public const ulong FFS_ATTRIB_DATA_ALIGNMENT_2 = 0x02;
  public const ulong FFS_ATTRIB_FIXED = 0x04;
  public const ulong FFS_ATTRIB_DATA_ALIGNMENT = 0x38;
  public const ulong FFS_ATTRIB_CHECKSUM = 0x40;

  ///
  /// FFS File State Bits.
  ///
  public const ulong EFI_FILE_HEADER_CONSTRUCTION = 0x01;
  public const ulong EFI_FILE_HEADER_VALID = 0x02;
  public const ulong EFI_FILE_DATA_VALID = 0x04;
  public const ulong EFI_FILE_MARKED_FOR_UPDATE = 0x08;
  public const ulong EFI_FILE_DELETED = 0x10;
  public const ulong EFI_FILE_HEADER_INVALID = 0x20;
}

///
/// Each file begins with the header that describe the
/// contents and state of the files.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FFS_FILE_HEADER
{
  ///
  /// This GUID is the file name. It is used to uniquely identify the file.
  ///
  public EFI_GUID Name;
  ///
  /// Used to verify the integrity of the file.
  ///
  public EFI_FFS_INTEGRITY_CHECK IntegrityCheck;
  ///
  /// Identifies the type of file.
  ///
  public EFI_FV_FILETYPE Type;
  ///
  /// Declares various file attribute bits.
  ///
  public EFI_FFS_FILE_ATTRIBUTES Attributes;
  ///
  /// The length of the file in bytes, including the FFS header.
  ///
  public fixed byte Size[3];
  ///
  /// Used to track the state of the file throughout the life of the file from creation to deletion.
  ///
  public EFI_FFS_FILE_STATE State;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FFS_FILE_HEADER2
{
  ///
  /// This GUID is the file name. It is used to uniquely identify the file. There may be only
  /// one instance of a file with the file name GUID of Name in any given firmware
  /// volume, except if the file type is EFI_FV_FILETYPE_FFS_PAD.
  ///
  public EFI_GUID Name;

  ///
  /// Used to verify the integrity of the file.
  ///
  public EFI_FFS_INTEGRITY_CHECK IntegrityCheck;

  ///
  /// Identifies the type of file.
  ///
  public EFI_FV_FILETYPE Type;

  ///
  /// Declares various file attribute bits.
  ///
  public EFI_FFS_FILE_ATTRIBUTES Attributes;

  ///
  /// The length of the file in bytes, including the FFS header.
  /// The length of the file data is either (Size - sizeof(EFI_FFS_FILE_HEADER)). This calculation means a
  /// zero-length file has a Size of 24 bytes, which is sizeof(EFI_FFS_FILE_HEADER).
  /// Size is not required to be a multiple of 8 bytes. Given a file F, the next file header is
  /// located at the next 8-byte aligned firmware volume offset following the last byte of the file F.
  ///
  public fixed byte Size[3];

  ///
  /// Used to track the state of the file throughout the life of the file from creation to deletion.
  ///
  public EFI_FFS_FILE_STATE State;

  ///
  /// If FFS_ATTRIB_LARGE_FILE is set in Attributes, then ExtendedSize exists and Size must be set to zero.
  /// If FFS_ATTRIB_LARGE_FILE is not set then EFI_FFS_FILE_HEADER is used.
  ///
  public ulong ExtendedSize;
}

public unsafe partial class EFI
{
  //public const ulong IS_FFS_FILE2 = (FfsFileHeaderPtr) \;
  //    (((((EFI_FFS_FILE_HEADER *) (ulong) FfsFileHeaderPtr)->Attributes) & FFS_ATTRIB_LARGE_FILE) == FFS_ATTRIB_LARGE_FILE)

  ///
  /// The argument passed as the FfsFileHeaderPtr parameter to the
  /// FFS_FILE_SIZE() function-like macro below must not have side effects:
  /// FfsFileHeaderPtr is evaluated multiple times.
  ///
  //public const ulong FFS_FILE_SIZE = (FfsFileHeaderPtr)  ((uint) (\;
  //    (((EFI_FFS_FILE_HEADER *) (ulong) (FfsFileHeaderPtr))->Size[0]      ) | \
  //    (((EFI_FFS_FILE_HEADER *) (ulong) (FfsFileHeaderPtr))->Size[1] <<  8) | \
  //    (((EFI_FFS_FILE_HEADER *) (ulong) (FfsFileHeaderPtr))->Size[2] << 16)))

  //public const ulong FFS_FILE2_SIZE = (FfsFileHeaderPtr) \;
  //    ((uint) (((EFI_FFS_FILE_HEADER2 *) (ulong) FfsFileHeaderPtr)->ExtendedSize))
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SECTION_TYPE { byte Value; public static implicit operator EFI_SECTION_TYPE(byte value) => new EFI_SECTION_TYPE() { Value = value }; public static implicit operator byte(EFI_SECTION_TYPE value) => value.Value; }

public unsafe partial class EFI
{
  ///
  /// Pseudo type. It is used as a wild card when retrieving sections.
  ///  The section type EFI_SECTION_ALL matches all section types.
  ///
  public const ulong EFI_SECTION_ALL = 0x00;

  ///
  /// Encapsulation section Type values.
  ///
  public const ulong EFI_SECTION_COMPRESSION = 0x01;

  public const ulong EFI_SECTION_GUID_DEFINED = 0x02;

  public const ulong EFI_SECTION_DISPOSABLE = 0x03;

  ///
  /// Leaf section Type values.
  ///
  public const ulong EFI_SECTION_PE32 = 0x10;
  public const ulong EFI_SECTION_PIC = 0x11;
  public const ulong EFI_SECTION_TE = 0x12;
  public const ulong EFI_SECTION_DXE_DEPEX = 0x13;
  public const ulong EFI_SECTION_VERSION = 0x14;
  public const ulong EFI_SECTION_USER_INTERFACE = 0x15;
  public const ulong EFI_SECTION_COMPATIBILITY16 = 0x16;
  public const ulong EFI_SECTION_FIRMWARE_VOLUME_IMAGE = 0x17;
  public const ulong EFI_SECTION_FREEFORM_SUBTYPE_GUID = 0x18;
  public const ulong EFI_SECTION_RAW = 0x19;
  public const ulong EFI_SECTION_PEI_DEPEX = 0x1B;
  public const ulong EFI_SECTION_MM_DEPEX = 0x1C;
  public const ulong EFI_SECTION_SMM_DEPEX = EFI_SECTION_MM_DEPEX;
}

///
/// Common section header.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_COMMON_SECTION_HEADER
{
  ///
  /// A 24-bit unsigned integer that contains the total size of the section in bytes,
  /// including the EFI_COMMON_SECTION_HEADER.
  ///
  public fixed byte Size[3];
  public EFI_SECTION_TYPE Type;
  ///
  /// Declares the section type.
  ///
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_COMMON_SECTION_HEADER2
{
  ///
  /// A 24-bit unsigned integer that contains the total size of the section in bytes,
  /// including the EFI_COMMON_SECTION_HEADER.
  ///
  public fixed byte Size[3];

  public EFI_SECTION_TYPE Type;

  ///
  /// If Size is 0xFFFFFF, then ExtendedSize contains the size of the section. If
  /// Size is not equal to 0xFFFFFF, then this field does not exist.
  ///
  public uint ExtendedSize;
}

///
/// Leaf section type that contains an
/// IA-32 16-bit executable image.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_COMPATIBILITY16_SECTION { EFI_COMMON_SECTION_HEADER Value; public static implicit operator EFI_COMPATIBILITY16_SECTION(EFI_COMMON_SECTION_HEADER value) => new EFI_COMPATIBILITY16_SECTION() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER(EFI_COMPATIBILITY16_SECTION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_COMPATIBILITY16_SECTION2 { EFI_COMMON_SECTION_HEADER2 Value; public static implicit operator EFI_COMPATIBILITY16_SECTION2(EFI_COMMON_SECTION_HEADER2 value) => new EFI_COMPATIBILITY16_SECTION2() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER2(EFI_COMPATIBILITY16_SECTION2 value) => value.Value; }

public unsafe partial class EFI
{
  ///
  /// CompressionType of EFI_COMPRESSION_SECTION.
  ///
  public const ulong EFI_NOT_COMPRESSED = 0x00;
  public const ulong EFI_STANDARD_COMPRESSION = 0x01;
  ///
  /// An encapsulation section type in which the
  /// section data is compressed.
  ///
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_COMPRESSION_SECTION
{
  ///
  /// Usual common section header. CommonHeader.Type = EFI_SECTION_COMPRESSION.
  ///
  public EFI_COMMON_SECTION_HEADER CommonHeader;
  ///
  /// The uint that indicates the size of the section data after decompression.
  ///
  public uint UncompressedLength;
  ///
  /// Indicates which compression algorithm is used.
  ///
  public byte CompressionType;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_COMPRESSION_SECTION2
{
  ///
  /// Usual common section header. CommonHeader.Type = EFI_SECTION_COMPRESSION.
  ///
  public EFI_COMMON_SECTION_HEADER2 CommonHeader;
  ///
  /// uint that indicates the size of the section data after decompression.
  ///
  public uint UncompressedLength;
  ///
  /// Indicates which compression algorithm is used.
  ///
  public byte CompressionType;
}

///
/// An encapsulation section type in which the section data is disposable.
/// A disposable section is an encapsulation section in which the section data may be disposed of during
/// the process of creating or updating a firmware image without significant impact on the usefulness of
/// the file. The Type field in the section header is set to EFI_SECTION_DISPOSABLE. This
/// allows optional or descriptive data to be included with the firmware file which can be removed in
/// order to conserve space. The contents of this section are implementation specific, but might contain
/// debug data or detailed integration instructions.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DISPOSABLE_SECTION { EFI_COMMON_SECTION_HEADER Value; public static implicit operator EFI_DISPOSABLE_SECTION(EFI_COMMON_SECTION_HEADER value) => new EFI_DISPOSABLE_SECTION() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER(EFI_DISPOSABLE_SECTION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DISPOSABLE_SECTION2 { EFI_COMMON_SECTION_HEADER2 Value; public static implicit operator EFI_DISPOSABLE_SECTION2(EFI_COMMON_SECTION_HEADER2 value) => new EFI_DISPOSABLE_SECTION2() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER2(EFI_DISPOSABLE_SECTION2 value) => value.Value; }

///
/// The leaf section which could be used to determine the dispatch order of DXEs.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DXE_DEPEX_SECTION { EFI_COMMON_SECTION_HEADER Value; public static implicit operator EFI_DXE_DEPEX_SECTION(EFI_COMMON_SECTION_HEADER value) => new EFI_DXE_DEPEX_SECTION() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER(EFI_DXE_DEPEX_SECTION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DXE_DEPEX_SECTION2 { EFI_COMMON_SECTION_HEADER2 Value; public static implicit operator EFI_DXE_DEPEX_SECTION2(EFI_COMMON_SECTION_HEADER2 value) => new EFI_DXE_DEPEX_SECTION2() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER2(EFI_DXE_DEPEX_SECTION2 value) => value.Value; }

///
/// The leaf section which contains a PI FV.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_VOLUME_IMAGE_SECTION { EFI_COMMON_SECTION_HEADER Value; public static implicit operator EFI_FIRMWARE_VOLUME_IMAGE_SECTION(EFI_COMMON_SECTION_HEADER value) => new EFI_FIRMWARE_VOLUME_IMAGE_SECTION() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER(EFI_FIRMWARE_VOLUME_IMAGE_SECTION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_VOLUME_IMAGE_SECTION2 { EFI_COMMON_SECTION_HEADER2 Value; public static implicit operator EFI_FIRMWARE_VOLUME_IMAGE_SECTION2(EFI_COMMON_SECTION_HEADER2 value) => new EFI_FIRMWARE_VOLUME_IMAGE_SECTION2() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER2(EFI_FIRMWARE_VOLUME_IMAGE_SECTION2 value) => value.Value; }

///
/// The leaf section which contains a single GUID.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FREEFORM_SUBTYPE_GUID_SECTION
{
  ///
  /// Common section header. CommonHeader.Type = EFI_SECTION_FREEFORM_SUBTYPE_GUID.
  ///
  public EFI_COMMON_SECTION_HEADER CommonHeader;
  ///
  /// This GUID is defined by the creator of the file. It is a vendor-defined file type.
  ///
  public EFI_GUID SubTypeGuid;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FREEFORM_SUBTYPE_GUID_SECTION2
{
  ///
  /// The common section header. CommonHeader.Type = EFI_SECTION_FREEFORM_SUBTYPE_GUID.
  ///
  public EFI_COMMON_SECTION_HEADER2 CommonHeader;
  ///
  /// This GUID is defined by the creator of the file. It is a vendor-defined file type.
  ///
  public EFI_GUID SubTypeGuid;
}

public unsafe partial class EFI
{
  ///
  /// Attributes of EFI_GUID_DEFINED_SECTION.
  ///
  public const ulong EFI_GUIDED_SECTION_PROCESSING_REQUIRED = 0x01;
  public const ulong EFI_GUIDED_SECTION_AUTH_STATUS_VALID = 0x02;
  ///
  /// The leaf section which is encapsulation defined by specific GUID.
  ///
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_GUID_DEFINED_SECTION
{
  ///
  /// The common section header. CommonHeader.Type = EFI_SECTION_GUID_DEFINED.
  ///
  public EFI_COMMON_SECTION_HEADER CommonHeader;
  ///
  /// The GUID that defines the format of the data that follows. It is a vendor-defined section type.
  ///
  public EFI_GUID SectionDefinitionGuid;
  ///
  /// Contains the offset in bytes from the beginning of the common header to the first byte of the data.
  ///
  public ushort DataOffset;
  ///
  /// The bit field that declares some specific characteristics of the section contents.
  ///
  public ushort Attributes;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_GUID_DEFINED_SECTION2
{
  ///
  /// The common section header. CommonHeader.Type = EFI_SECTION_GUID_DEFINED.
  ///
  public EFI_COMMON_SECTION_HEADER2 CommonHeader;
  ///
  /// The GUID that defines the format of the data that follows. It is a vendor-defined section type.
  ///
  public EFI_GUID SectionDefinitionGuid;
  ///
  /// Contains the offset in bytes from the beginning of the common header to the first byte of the data.
  ///
  public ushort DataOffset;
  ///
  /// The bit field that declares some specific characteristics of the section contents.
  ///
  public ushort Attributes;
}

///
/// The leaf section which contains PE32+ image.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PE32_SECTION { EFI_COMMON_SECTION_HEADER Value; public static implicit operator EFI_PE32_SECTION(EFI_COMMON_SECTION_HEADER value) => new EFI_PE32_SECTION() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER(EFI_PE32_SECTION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PE32_SECTION2 { EFI_COMMON_SECTION_HEADER2 Value; public static implicit operator EFI_PE32_SECTION2(EFI_COMMON_SECTION_HEADER2 value) => new EFI_PE32_SECTION2() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER2(EFI_PE32_SECTION2 value) => value.Value; }

///
/// The leaf section used to determine the dispatch order of PEIMs.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PEI_DEPEX_SECTION { EFI_COMMON_SECTION_HEADER Value; public static implicit operator EFI_PEI_DEPEX_SECTION(EFI_COMMON_SECTION_HEADER value) => new EFI_PEI_DEPEX_SECTION() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER(EFI_PEI_DEPEX_SECTION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PEI_DEPEX_SECTION2 { EFI_COMMON_SECTION_HEADER2 Value; public static implicit operator EFI_PEI_DEPEX_SECTION2(EFI_COMMON_SECTION_HEADER2 value) => new EFI_PEI_DEPEX_SECTION2() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER2(EFI_PEI_DEPEX_SECTION2 value) => value.Value; }

///
/// A leaf section type that contains a position-independent-code (PIC) image.
/// A PIC image section is a leaf section that contains a position-independent-code (PIC) image.
/// In addition to normal PE32+ images that contain relocation information, PEIM executables may be
/// PIC and are referred to as PIC images. A PIC image is the same as a PE32+ image except that all
/// relocation information has been stripped from the image and the image can be moved and will
/// execute correctly without performing any relocation or other fix-ups. EFI_PIC_SECTION2 must
/// be used if the section is 16MB or larger.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PIC_SECTION { EFI_COMMON_SECTION_HEADER Value; public static implicit operator EFI_PIC_SECTION(EFI_COMMON_SECTION_HEADER value) => new EFI_PIC_SECTION() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER(EFI_PIC_SECTION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PIC_SECTION2 { EFI_COMMON_SECTION_HEADER2 Value; public static implicit operator EFI_PIC_SECTION2(EFI_COMMON_SECTION_HEADER2 value) => new EFI_PIC_SECTION2() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER2(EFI_PIC_SECTION2 value) => value.Value; }

///
/// The leaf section which constains the position-independent-code image.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TE_SECTION { EFI_COMMON_SECTION_HEADER Value; public static implicit operator EFI_TE_SECTION(EFI_COMMON_SECTION_HEADER value) => new EFI_TE_SECTION() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER(EFI_TE_SECTION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TE_SECTION2 { EFI_COMMON_SECTION_HEADER2 Value; public static implicit operator EFI_TE_SECTION2(EFI_COMMON_SECTION_HEADER2 value) => new EFI_TE_SECTION2() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER2(EFI_TE_SECTION2 value) => value.Value; }

///
/// The leaf section which contains an array of zero or more bytes.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_RAW_SECTION { EFI_COMMON_SECTION_HEADER Value; public static implicit operator EFI_RAW_SECTION(EFI_COMMON_SECTION_HEADER value) => new EFI_RAW_SECTION() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER(EFI_RAW_SECTION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_RAW_SECTION2 { EFI_COMMON_SECTION_HEADER2 Value; public static implicit operator EFI_RAW_SECTION2(EFI_COMMON_SECTION_HEADER2 value) => new EFI_RAW_SECTION2() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER2(EFI_RAW_SECTION2 value) => value.Value; }

///
/// The SMM dependency expression section is a leaf section that contains a dependency expression that
/// is used to determine the dispatch order for SMM drivers. Before the SMRAM invocation of the
/// SMM driver's entry point, this dependency expression must evaluate to TRUE. See the Platform
/// Initialization Specification, Volume 2, for details regarding the format of the dependency expression.
/// The dependency expression may refer to protocols installed in either the UEFI or the SMM protocol
/// database. EFI_SMM_DEPEX_SECTION2 must be used if the section is 16MB or larger.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_DEPEX_SECTION { EFI_COMMON_SECTION_HEADER Value; public static implicit operator EFI_SMM_DEPEX_SECTION(EFI_COMMON_SECTION_HEADER value) => new EFI_SMM_DEPEX_SECTION() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER(EFI_SMM_DEPEX_SECTION value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_DEPEX_SECTION2 { EFI_COMMON_SECTION_HEADER2 Value; public static implicit operator EFI_SMM_DEPEX_SECTION2(EFI_COMMON_SECTION_HEADER2 value) => new EFI_SMM_DEPEX_SECTION2() { Value = value }; public static implicit operator EFI_COMMON_SECTION_HEADER2(EFI_SMM_DEPEX_SECTION2 value) => value.Value; }

///
/// The leaf section which contains a unicode string that
/// is human readable file name.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_USER_INTERFACE_SECTION
{
  public EFI_COMMON_SECTION_HEADER CommonHeader;

  ///
  /// Array of unicode string.
  ///
  public fixed char FileNameString[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_USER_INTERFACE_SECTION2
{
  public EFI_COMMON_SECTION_HEADER2 CommonHeader;
  public fixed char FileNameString[1];
}

///
/// The leaf section which contains a numeric build number and
/// an optional unicode string that represents the file revision.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_VERSION_SECTION
{
  public EFI_COMMON_SECTION_HEADER CommonHeader;
  public ushort BuildNumber;

  ///
  /// Array of unicode string.
  ///
  public fixed char VersionString[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_VERSION_SECTION2
{
  public EFI_COMMON_SECTION_HEADER2 CommonHeader;
  ///
  /// A ushort that represents a particular build. Subsequent builds have monotonically
  /// increasing build numbers relative to earlier builds.
  ///
  public ushort BuildNumber;
  public fixed char VersionString[1];
}

public unsafe partial class EFI
{
  ///
  /// The argument passed as the SectionHeaderPtr parameter to the SECTION_SIZE()
  /// and IS_SECTION2() function-like macros below must not have side effects:
  /// SectionHeaderPtr is evaluated multiple times.
  ///
  //public const ulong SECTION_SIZE = (SectionHeaderPtr)  ((uint) (\;
  //    (((EFI_COMMON_SECTION_HEADER *) (ulong) (SectionHeaderPtr))->Size[0]      ) | \
  //    (((EFI_COMMON_SECTION_HEADER *) (ulong) (SectionHeaderPtr))->Size[1] <<  8) | \
  //    (((EFI_COMMON_SECTION_HEADER *) (ulong) (SectionHeaderPtr))->Size[2] << 16)))

  //public const ulong IS_SECTION2 = (SectionHeaderPtr) \;
  //    (SECTION_SIZE (SectionHeaderPtr) == 0x00ffffff)

  //public const ulong SECTION2_SIZE = (SectionHeaderPtr) \;
  //    (((EFI_COMMON_SECTION_HEADER2 *) (ulong) SectionHeaderPtr)->ExtendedSize)

  // #pragma pack()
}

// #endif
