using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file defines the encoding for the VFR (Visual Form Representation) language.
  IFR is primarily consumed by the EFI presentation engine, and produced by EFI
  internal application and drivers as well as all add-in card option-ROM drivers

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
(C) Copyright 2016 Hewlett Packard Enterprise Development LP<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  These definitions are from UEFI 2.1 and 2.2.

**/

// #ifndef __UEFI_INTERNAL_FORMREPRESENTATION_H__
// #define __UEFI_INTERNAL_FORMREPRESENTATION_H__

// #include <Guid/HiiFormMapMethodGuid.h>

///
/// The following types are currently defined:
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_HANDLE { void* Value; public static implicit operator EFI_HII_HANDLE(void* value) => new EFI_HII_HANDLE() { Value = value }; public static implicit operator void*(EFI_HII_HANDLE value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_STRING { char* Value; public static implicit operator EFI_STRING(char* value) => new EFI_STRING() { Value = value }; public static implicit operator char*(EFI_STRING value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_ID { ushort Value; public static implicit operator EFI_IMAGE_ID(ushort value) => new EFI_IMAGE_ID() { Value = value }; public static implicit operator ushort(EFI_IMAGE_ID value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_QUESTION_ID { ushort Value; public static implicit operator EFI_QUESTION_ID(ushort value) => new EFI_QUESTION_ID() { Value = value }; public static implicit operator ushort(EFI_QUESTION_ID value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_STRING_ID { ushort Value; public static implicit operator EFI_STRING_ID(ushort value) => new EFI_STRING_ID() { Value = value }; public static implicit operator ushort(EFI_STRING_ID value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FORM_ID { ushort Value; public static implicit operator EFI_FORM_ID(ushort value) => new EFI_FORM_ID() { Value = value }; public static implicit operator ushort(EFI_FORM_ID value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_VARSTORE_ID { ushort Value; public static implicit operator EFI_VARSTORE_ID(ushort value) => new EFI_VARSTORE_ID() { Value = value }; public static implicit operator ushort(EFI_VARSTORE_ID value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ANIMATION_ID { ushort Value; public static implicit operator EFI_ANIMATION_ID(ushort value) => new EFI_ANIMATION_ID() { Value = value }; public static implicit operator ushort(EFI_ANIMATION_ID value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEFAULT_ID { ushort Value; public static implicit operator EFI_DEFAULT_ID(ushort value) => new EFI_DEFAULT_ID() { Value = value }; public static implicit operator ushort(EFI_DEFAULT_ID value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_FONT_STYLE { uint Value; public static implicit operator EFI_HII_FONT_STYLE(uint value) => new EFI_HII_FONT_STYLE() { Value = value }; public static implicit operator uint(EFI_HII_FONT_STYLE value) => value.Value; }

// #pragma pack(1)

//
// Definitions for Package Lists and Package Headers
// Section 27.3.1
//

///
/// The header found at the start of each package list.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_PACKAGE_LIST_HEADER
{
  public EFI_GUID PackageListGuid;
  public uint PackageLength;
}

///
/// The header found at the start of each package.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_PACKAGE_HEADER
{
  public uint Length = 24;
  public uint Type = 8;
  // byte  Data[...];
}

//
// Value of HII package type
//
public unsafe partial class EFI
{
  public const ulong EFI_HII_PACKAGE_TYPE_ALL = 0x00;
  public const ulong EFI_HII_PACKAGE_TYPE_GUID = 0x01;
  public const ulong EFI_HII_PACKAGE_FORMS = 0x02;
  public const ulong EFI_HII_PACKAGE_STRINGS = 0x04;
  public const ulong EFI_HII_PACKAGE_FONTS = 0x05;
  public const ulong EFI_HII_PACKAGE_IMAGES = 0x06;
  public const ulong EFI_HII_PACKAGE_SIMPLE_FONTS = 0x07;
  public const ulong EFI_HII_PACKAGE_DEVICE_PATH = 0x08;
  public const ulong EFI_HII_PACKAGE_KEYBOARD_LAYOUT = 0x09;
  public const ulong EFI_HII_PACKAGE_ANIMATIONS = 0x0A;
  public const ulong EFI_HII_PACKAGE_END = 0xDF;
  public const ulong EFI_HII_PACKAGE_TYPE_SYSTEM_BEGIN = 0xE0;
  public const ulong EFI_HII_PACKAGE_TYPE_SYSTEM_END = 0xFF;

  //
  // Definitions for Simplified Font Package
  //

  ///
  /// Contents of EFI_NARROW_GLYPH.Attributes.
  ///@{
  public const ulong EFI_GLYPH_NON_SPACING = 0x01;
  public const ulong EFI_GLYPH_WIDE = 0x02;
  public const ulong EFI_GLYPH_HEIGHT = 19;
  public const ulong EFI_GLYPH_WIDTH = 8;
  ///@}
}

///
/// The EFI_NARROW_GLYPH has a preferred dimension (w x h) of 8 x 19 pixels.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_NARROW_GLYPH
{
  ///
  /// The Unicode representation of the glyph. The term weight is the
  /// technical term for a character code.
  ///
  public char UnicodeWeight;
  ///
  /// The data element containing the glyph definitions.
  ///
  public byte Attributes;
  ///
  /// The column major glyph representation of the character. Bits
  /// with values of one indicate that the corresponding pixel is to be
  /// on when normally displayed; those with zero are off.
  ///
  public fixed byte GlyphCol1[EFI_GLYPH_HEIGHT];
}

///
/// The EFI_WIDE_GLYPH has a preferred dimension (w x h) of 16 x 19 pixels, which is large enough
/// to accommodate logographic characters.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_WIDE_GLYPH
{
  ///
  /// The Unicode representation of the glyph. The term weight is the
  /// technical term for a character code.
  ///
  public char UnicodeWeight;
  ///
  /// The data element containing the glyph definitions.
  ///
  public byte Attributes;
  ///
  /// The column major glyph representation of the character. Bits
  /// with values of one indicate that the corresponding pixel is to be
  /// on when normally displayed; those with zero are off.
  ///
  public fixed byte GlyphCol1[EFI_GLYPH_HEIGHT];
  ///
  /// The column major glyph representation of the character. Bits
  /// with values of one indicate that the corresponding pixel is to be
  /// on when normally displayed; those with zero are off.
  ///
  public fixed byte GlyphCol2[EFI_GLYPH_HEIGHT];
  ///
  /// Ensures that sizeof (EFI_WIDE_GLYPH) is twice the
  /// sizeof (EFI_NARROW_GLYPH). The contents of Pad must
  /// be zero.
  ///
  public fixed byte Pad[3];
}

///
/// A simplified font package consists of a font header
/// followed by a series of glyph structures.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIMPLE_FONT_PACKAGE_HDR
{
  public EFI_HII_PACKAGE_HEADER Header;
  public ushort NumberOfNarrowGlyphs;
  public ushort NumberOfWideGlyphs;
  // EFI_NARROW_GLYPH       NarrowGlyphs[];
  // EFI_WIDE_GLYPH         WideGlyphs[];
}

//
// Definitions for Font Package
// Section 27.3.3
//

//
// Value for font style
//
public unsafe partial class EFI
{
  public const ulong EFI_HII_FONT_STYLE_NORMAL = 0x00000000;
  public const ulong EFI_HII_FONT_STYLE_BOLD = 0x00000001;
  public const ulong EFI_HII_FONT_STYLE_ITALIC = 0x00000002;
  public const ulong EFI_HII_FONT_STYLE_EMBOSS = 0x00010000;
  public const ulong EFI_HII_FONT_STYLE_OUTLINE = 0x00020000;
  public const ulong EFI_HII_FONT_STYLE_SHADOW = 0x00040000;
  public const ulong EFI_HII_FONT_STYLE_UNDERLINE = 0x00080000;
  public const ulong EFI_HII_FONT_STYLE_DBL_UNDER = 0x00100000;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GLYPH_INFO
{
  public ushort Width;
  public ushort Height;
  public short OffsetX;
  public short OffsetY;
  public short AdvanceX;
}

///
/// The fixed header consists of a standard record header,
/// then the character values in this section, the flags
/// (including the encoding method) and the offsets of the glyph
/// information, the glyph bitmaps and the character map.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_FONT_PACKAGE_HDR
{
  public EFI_HII_PACKAGE_HEADER Header;
  public uint HdrSize;
  public uint GlyphBlockOffset;
  public EFI_HII_GLYPH_INFO Cell;
  public EFI_HII_FONT_STYLE FontStyle;
  public fixed char FontFamily[1];
}

//
// Value of different glyph info block types
//
public unsafe partial class EFI
{
  public const ulong EFI_HII_GIBT_END = 0x00;
  public const ulong EFI_HII_GIBT_GLYPH = 0x10;
  public const ulong EFI_HII_GIBT_GLYPHS = 0x11;
  public const ulong EFI_HII_GIBT_GLYPH_DEFAULT = 0x12;
  public const ulong EFI_HII_GIBT_GLYPHS_DEFAULT = 0x13;
  public const ulong EFI_HII_GIBT_GLYPH_VARIABILITY = 0x14;
  public const ulong EFI_HII_GIBT_DUPLICATE = 0x20;
  public const ulong EFI_HII_GIBT_SKIP2 = 0x21;
  public const ulong EFI_HII_GIBT_SKIP1 = 0x22;
  public const ulong EFI_HII_GIBT_DEFAULTS = 0x23;
  public const ulong EFI_HII_GIBT_EXT1 = 0x30;
  public const ulong EFI_HII_GIBT_EXT2 = 0x31;
  public const ulong EFI_HII_GIBT_EXT4 = 0x32;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GLYPH_BLOCK
{
  public byte BlockType;
}

//
// Definition of different glyph info block types
//

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_DEFAULTS_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public EFI_HII_GLYPH_INFO Cell;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_DUPLICATE_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public char CharValue;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_GLYPH_GIBT_END_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_EXT1_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public byte BlockType2;
  public byte Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_EXT2_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public byte BlockType2;
  public ushort Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_EXT4_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public byte BlockType2;
  public uint Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_GLYPH_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public EFI_HII_GLYPH_INFO Cell;
  public fixed byte BitmapData[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_GLYPHS_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public EFI_HII_GLYPH_INFO Cell;
  public ushort Count;
  public fixed byte BitmapData[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_GLYPH_DEFAULT_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public fixed byte BitmapData[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_GLYPHS_DEFAULT_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public ushort Count;
  public fixed byte BitmapData[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_VARIABILITY_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public EFI_HII_GLYPH_INFO Cell;
  public byte GlyphPackInBits;
  public fixed byte BitmapData[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_SKIP1_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public byte SkipCount;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GIBT_SKIP2_BLOCK
{
  public EFI_HII_GLYPH_BLOCK Header;
  public ushort SkipCount;
}

//
// Definitions for Device Path Package
// Section 27.3.4
//

///
/// The device path package is used to carry a device path
/// associated with the package list.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_DEVICE_PATH_PACKAGE_HDR
{
  public EFI_HII_PACKAGE_HEADER Header;
  // EFI_DEVICE_PATH_PROTOCOL DevicePath[];
}

//
// Definitions for GUID Package
// Section 27.3.5
//

///
/// The GUID package is used to carry data where the format is defined by a GUID.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_GUID_PACKAGE_HDR
{
  public EFI_HII_PACKAGE_HEADER Header;
  public EFI_GUID Guid;
  // Data per GUID definition may follow
}

//
// Definitions for String Package
// Section 27.3.6
//

public unsafe partial class EFI
{
  public const ulong UEFI_CONFIG_LANG = "x-UEFI";
  public const ulong UEFI_CONFIG_LANG_2 = "x-i-UEFI";
}

///
/// The fixed header consists of a standard record header and then the string identifiers
/// contained in this section and the offsets of the string and language information.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_STRING_PACKAGE_HDR
{
  public EFI_HII_PACKAGE_HEADER Header;
  public uint HdrSize;
  public uint StringInfoOffset;
  public fixed char LanguageWindow[16];
  public EFI_STRING_ID LanguageName;
  public fixed byte Language[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_STRING_BLOCK
{
  public byte BlockType;
}

//
// Value of different string information block types
//
public unsafe partial class EFI
{
  public const ulong EFI_HII_SIBT_END = 0x00;
  public const ulong EFI_HII_SIBT_STRING_SCSU = 0x10;
  public const ulong EFI_HII_SIBT_STRING_SCSU_FONT = 0x11;
  public const ulong EFI_HII_SIBT_STRINGS_SCSU = 0x12;
  public const ulong EFI_HII_SIBT_STRINGS_SCSU_FONT = 0x13;
  public const ulong EFI_HII_SIBT_STRING_UCS2 = 0x14;
  public const ulong EFI_HII_SIBT_STRING_UCS2_FONT = 0x15;
  public const ulong EFI_HII_SIBT_STRINGS_UCS2 = 0x16;
  public const ulong EFI_HII_SIBT_STRINGS_UCS2_FONT = 0x17;
  public const ulong EFI_HII_SIBT_DUPLICATE = 0x20;
  public const ulong EFI_HII_SIBT_SKIP2 = 0x21;
  public const ulong EFI_HII_SIBT_SKIP1 = 0x22;
  public const ulong EFI_HII_SIBT_EXT1 = 0x30;
  public const ulong EFI_HII_SIBT_EXT2 = 0x31;
  public const ulong EFI_HII_SIBT_EXT4 = 0x32;
  public const ulong EFI_HII_SIBT_FONT = 0x40;

  //
  // Definition of different string information block types
  //
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_DUPLICATE_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public EFI_STRING_ID StringId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_END_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_EXT1_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public byte BlockType2;
  public byte Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_EXT2_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public byte BlockType2;
  public ushort Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_EXT4_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public byte BlockType2;
  public uint Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_FONT_BLOCK
{
  public EFI_HII_SIBT_EXT2_BLOCK Header;
  public byte FontId;
  public ushort FontSize;
  public EFI_HII_FONT_STYLE FontStyle;
  public fixed char FontName[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_SKIP1_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public byte SkipCount;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_SKIP2_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public ushort SkipCount;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_STRING_SCSU_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public fixed byte StringText[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_STRING_SCSU_FONT_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public byte FontIdentifier;
  public fixed byte StringText[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_STRINGS_SCSU_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public ushort StringCount;
  public fixed byte StringText[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_STRINGS_SCSU_FONT_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public byte FontIdentifier;
  public ushort StringCount;
  public fixed byte StringText[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_STRING_UCS2_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public fixed char StringText[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_STRING_UCS2_FONT_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public byte FontIdentifier;
  public fixed char StringText[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_STRINGS_UCS2_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public ushort StringCount;
  public fixed char StringText[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_SIBT_STRINGS_UCS2_FONT_BLOCK
{
  public EFI_HII_STRING_BLOCK Header;
  public byte FontIdentifier;
  public ushort StringCount;
  public fixed char StringText[1];
}

//
// Definitions for Image Package
// Section 27.3.7
//

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IMAGE_PACKAGE_HDR
{
  public EFI_HII_PACKAGE_HEADER Header;
  public uint ImageInfoOffset;
  public uint PaletteInfoOffset;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IMAGE_BLOCK
{
  public byte BlockType;
}

//
// Value of different image information block types
//
public unsafe partial class EFI
{
  public const ulong EFI_HII_IIBT_END = 0x00;
  public const ulong EFI_HII_IIBT_IMAGE_1BIT = 0x10;
  public const ulong EFI_HII_IIBT_IMAGE_1BIT_TRANS = 0x11;
  public const ulong EFI_HII_IIBT_IMAGE_4BIT = 0x12;
  public const ulong EFI_HII_IIBT_IMAGE_4BIT_TRANS = 0x13;
  public const ulong EFI_HII_IIBT_IMAGE_8BIT = 0x14;
  public const ulong EFI_HII_IIBT_IMAGE_8BIT_TRANS = 0x15;
  public const ulong EFI_HII_IIBT_IMAGE_24BIT = 0x16;
  public const ulong EFI_HII_IIBT_IMAGE_24BIT_TRANS = 0x17;
  public const ulong EFI_HII_IIBT_IMAGE_JPEG = 0x18;
  public const ulong EFI_HII_IIBT_IMAGE_PNG = 0x19;
  public const ulong EFI_HII_IIBT_DUPLICATE = 0x20;
  public const ulong EFI_HII_IIBT_SKIP2 = 0x21;
  public const ulong EFI_HII_IIBT_SKIP1 = 0x22;
  public const ulong EFI_HII_IIBT_EXT1 = 0x30;
  public const ulong EFI_HII_IIBT_EXT2 = 0x31;
  public const ulong EFI_HII_IIBT_EXT4 = 0x32;

  //
  // Definition of different image information block types
  //
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_END_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_EXT1_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public byte BlockType2;
  public byte Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_EXT2_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public byte BlockType2;
  public ushort Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_EXT4_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public byte BlockType2;
  public uint Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_1BIT_BASE
{
  public ushort Width;
  public ushort Height;
  public fixed byte Data[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_1BIT_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public byte PaletteIndex;
  public EFI_HII_IIBT_IMAGE_1BIT_BASE Bitmap;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_1BIT_TRANS_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public byte PaletteIndex;
  public EFI_HII_IIBT_IMAGE_1BIT_BASE Bitmap;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_RGB_PIXEL
{
  public byte b;
  public byte g;
  public byte r;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_24BIT_BASE
{
  public ushort Width;
  public ushort Height;
  public fixed EFI_HII_RGB_PIXEL Bitmap[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_24BIT_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public EFI_HII_IIBT_IMAGE_24BIT_BASE Bitmap;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_24BIT_TRANS_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public EFI_HII_IIBT_IMAGE_24BIT_BASE Bitmap;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_4BIT_BASE
{
  public ushort Width;
  public ushort Height;
  public fixed byte Data[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_4BIT_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public byte PaletteIndex;
  public EFI_HII_IIBT_IMAGE_4BIT_BASE Bitmap;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_4BIT_TRANS_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public byte PaletteIndex;
  public EFI_HII_IIBT_IMAGE_4BIT_BASE Bitmap;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_8BIT_BASE
{
  public ushort Width;
  public ushort Height;
  public fixed byte Data[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_8BIT_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public byte PaletteIndex;
  public EFI_HII_IIBT_IMAGE_8BIT_BASE Bitmap;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_IMAGE_8BIT_TRAN_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public byte PaletteIndex;
  public EFI_HII_IIBT_IMAGE_8BIT_BASE Bitmap;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_DUPLICATE_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public EFI_IMAGE_ID ImageId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_JPEG_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public uint Size;
  public fixed byte Data[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_PNG_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public uint Size;
  public fixed byte Data[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_SKIP1_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public byte SkipCount;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IIBT_SKIP2_BLOCK
{
  public EFI_HII_IMAGE_BLOCK Header;
  public ushort SkipCount;
}

//
// Definitions for Palette Information
//

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IMAGE_PALETTE_INFO_HEADER
{
  public ushort PaletteCount;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IMAGE_PALETTE_INFO
{
  public ushort PaletteSize;
  public fixed EFI_HII_RGB_PIXEL PaletteValue[1];
}

//
// Definitions for Forms Package
// Section 27.3.8
//

///
/// The Form package is used to carry form-based encoding data.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_FORM_PACKAGE_HDR
{
  public EFI_HII_PACKAGE_HEADER Header;
  // EFI_IFR_OP_HEADER         OpCodeHeader;
  // More op-codes follow
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_TIME
{
  public byte Hour;
  public byte Minute;
  public byte Second;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_DATE
{
  public ushort Year;
  public byte Month;
  public byte Day;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_REF
{
  public EFI_QUESTION_ID QuestionId;
  public EFI_FORM_ID FormId;
  public EFI_GUID FormSetGuid;
  public EFI_STRING_ID DevicePath;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_IFR_TYPE_VALUE
{
  [FieldOffset(0)] public byte u8;
  [FieldOffset(0)] public ushort u16;
  [FieldOffset(0)] public uint u32;
  [FieldOffset(0)] public ulong u64;
  [FieldOffset(0)] public bool b;
  [FieldOffset(0)] public EFI_HII_TIME time;
  [FieldOffset(0)] public EFI_HII_DATE date;
  [FieldOffset(0)] public EFI_STRING_ID string; ///< EFI_IFR_TYPE_STRING, EFI_IFR_TYPE_ACTION
 [FieldOffset(0)] public EFI_HII_REF ref;    ///< EFI_IFR_TYPE_REF
  // byte buffer[];      ///< EFI_IFR_TYPE_BUFFER
}

//
// IFR Opcodes
//
public unsafe partial class EFI
{
  public const ulong EFI_IFR_FORM_OP = 0x01;
  public const ulong EFI_IFR_SUBTITLE_OP = 0x02;
  public const ulong EFI_IFR_TEXT_OP = 0x03;
  public const ulong EFI_IFR_IMAGE_OP = 0x04;
  public const ulong EFI_IFR_ONE_OF_OP = 0x05;
  public const ulong EFI_IFR_CHECKBOX_OP = 0x06;
  public const ulong EFI_IFR_NUMERIC_OP = 0x07;
  public const ulong EFI_IFR_PASSWORD_OP = 0x08;
  public const ulong EFI_IFR_ONE_OF_OPTION_OP = 0x09;
  public const ulong EFI_IFR_SUPPRESS_IF_OP = 0x0A;
  public const ulong EFI_IFR_LOCKED_OP = 0x0B;
  public const ulong EFI_IFR_ACTION_OP = 0x0C;
  public const ulong EFI_IFR_RESET_BUTTON_OP = 0x0D;
  public const ulong EFI_IFR_FORM_SET_OP = 0x0E;
  public const ulong EFI_IFR_REF_OP = 0x0F;
  public const ulong EFI_IFR_NO_SUBMIT_IF_OP = 0x10;
  public const ulong EFI_IFR_INCONSISTENT_IF_OP = 0x11;
  public const ulong EFI_IFR_EQ_ID_VAL_OP = 0x12;
  public const ulong EFI_IFR_EQ_ID_ID_OP = 0x13;
  public const ulong EFI_IFR_EQ_ID_VAL_LIST_OP = 0x14;
  public const ulong EFI_IFR_AND_OP = 0x15;
  public const ulong EFI_IFR_OR_OP = 0x16;
  public const ulong EFI_IFR_NOT_OP = 0x17;
  public const ulong EFI_IFR_RULE_OP = 0x18;
  public const ulong EFI_IFR_GRAY_OUT_IF_OP = 0x19;
  public const ulong EFI_IFR_DATE_OP = 0x1A;
  public const ulong EFI_IFR_TIME_OP = 0x1B;
  public const ulong EFI_IFR_STRING_OP = 0x1C;
  public const ulong EFI_IFR_REFRESH_OP = 0x1D;
  public const ulong EFI_IFR_DISABLE_IF_OP = 0x1E;
  public const ulong EFI_IFR_ANIMATION_OP = 0x1F;
  public const ulong EFI_IFR_TO_LOWER_OP = 0x20;
  public const ulong EFI_IFR_TO_UPPER_OP = 0x21;
  public const ulong EFI_IFR_MAP_OP = 0x22;
  public const ulong EFI_IFR_ORDERED_LIST_OP = 0x23;
  public const ulong EFI_IFR_VARSTORE_OP = 0x24;
  public const ulong EFI_IFR_VARSTORE_NAME_VALUE_OP = 0x25;
  public const ulong EFI_IFR_VARSTORE_EFI_OP = 0x26;
  public const ulong EFI_IFR_VARSTORE_DEVICE_OP = 0x27;
  public const ulong EFI_IFR_VERSION_OP = 0x28;
  public const ulong EFI_IFR_END_OP = 0x29;
  public const ulong EFI_IFR_MATCH_OP = 0x2A;
  public const ulong EFI_IFR_GET_OP = 0x2B;
  public const ulong EFI_IFR_SET_OP = 0x2C;
  public const ulong EFI_IFR_READ_OP = 0x2D;
  public const ulong EFI_IFR_WRITE_OP = 0x2E;
  public const ulong EFI_IFR_EQUAL_OP = 0x2F;
  public const ulong EFI_IFR_NOT_EQUAL_OP = 0x30;
  public const ulong EFI_IFR_GREATER_THAN_OP = 0x31;
  public const ulong EFI_IFR_GREATER_EQUAL_OP = 0x32;
  public const ulong EFI_IFR_LESS_THAN_OP = 0x33;
  public const ulong EFI_IFR_LESS_EQUAL_OP = 0x34;
  public const ulong EFI_IFR_BITWISE_AND_OP = 0x35;
  public const ulong EFI_IFR_BITWISE_OR_OP = 0x36;
  public const ulong EFI_IFR_BITWISE_NOT_OP = 0x37;
  public const ulong EFI_IFR_SHIFT_LEFT_OP = 0x38;
  public const ulong EFI_IFR_SHIFT_RIGHT_OP = 0x39;
  public const ulong EFI_IFR_ADD_OP = 0x3A;
  public const ulong EFI_IFR_SUBTRACT_OP = 0x3B;
  public const ulong EFI_IFR_MULTIPLY_OP = 0x3C;
  public const ulong EFI_IFR_DIVIDE_OP = 0x3D;
  public const ulong EFI_IFR_MODULO_OP = 0x3E;
  public const ulong EFI_IFR_RULE_REF_OP = 0x3F;
  public const ulong EFI_IFR_QUESTION_REF1_OP = 0x40;
  public const ulong EFI_IFR_QUESTION_REF2_OP = 0x41;
  public const ulong EFI_IFR_UINT8_OP = 0x42;
  public const ulong EFI_IFR_UINT16_OP = 0x43;
  public const ulong EFI_IFR_UINT32_OP = 0x44;
  public const ulong EFI_IFR_UINT64_OP = 0x45;
  public const ulong EFI_IFR_TRUE_OP = 0x46;
  public const ulong EFI_IFR_FALSE_OP = 0x47;
  public const ulong EFI_IFR_TO_UINT_OP = 0x48;
  public const ulong EFI_IFR_TO_STRING_OP = 0x49;
  public const ulong EFI_IFR_TO_BOOLEAN_OP = 0x4A;
  public const ulong EFI_IFR_MID_OP = 0x4B;
  public const ulong EFI_IFR_FIND_OP = 0x4C;
  public const ulong EFI_IFR_TOKEN_OP = 0x4D;
  public const ulong EFI_IFR_STRING_REF1_OP = 0x4E;
  public const ulong EFI_IFR_STRING_REF2_OP = 0x4F;
  public const ulong EFI_IFR_CONDITIONAL_OP = 0x50;
  public const ulong EFI_IFR_QUESTION_REF3_OP = 0x51;
  public const ulong EFI_IFR_ZERO_OP = 0x52;
  public const ulong EFI_IFR_ONE_OP = 0x53;
  public const ulong EFI_IFR_ONES_OP = 0x54;
  public const ulong EFI_IFR_UNDEFINED_OP = 0x55;
  public const ulong EFI_IFR_LENGTH_OP = 0x56;
  public const ulong EFI_IFR_DUP_OP = 0x57;
  public const ulong EFI_IFR_THIS_OP = 0x58;
  public const ulong EFI_IFR_SPAN_OP = 0x59;
  public const ulong EFI_IFR_VALUE_OP = 0x5A;
  public const ulong EFI_IFR_DEFAULT_OP = 0x5B;
  public const ulong EFI_IFR_DEFAULTSTORE_OP = 0x5C;
  public const ulong EFI_IFR_FORM_MAP_OP = 0x5D;
  public const ulong EFI_IFR_CATENATE_OP = 0x5E;
  public const ulong EFI_IFR_GUID_OP = 0x5F;
  public const ulong EFI_IFR_SECURITY_OP = 0x60;
  public const ulong EFI_IFR_MODAL_TAG_OP = 0x61;
  public const ulong EFI_IFR_REFRESH_ID_OP = 0x62;
  public const ulong EFI_IFR_WARNING_IF_OP = 0x63;
  public const ulong EFI_IFR_MATCH2_OP = 0x64;

  //
  // Definitions of IFR Standard Headers
  // Section 27.3.8.2
  //
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_OP_HEADER
{
  public byte OpCode;
  public byte Length = 7;
  public byte Scope = 1;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_STATEMENT_HEADER
{
  public EFI_STRING_ID Prompt;
  public EFI_STRING_ID Help;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VarStoreInfo
{
  public EFI_IFR_STATEMENT_HEADER Header;
  public EFI_QUESTION_ID QuestionId;
  public EFI_VARSTORE_ID VarStoreId;
  union {
   public EFI_STRING_ID VarName;
  public ushort VarOffset;
}
byte Flags;
} EFI_IFR_QUESTION_HEADER;

//
// Flag values of EFI_IFR_QUESTION_HEADER
//
public unsafe partial class EFI
{
  public const ulong EFI_IFR_FLAG_READ_ONLY = 0x01;
  public const ulong EFI_IFR_FLAG_CALLBACK = 0x04;
  public const ulong EFI_IFR_FLAG_RESET_REQUIRED = 0x10;
  public const ulong EFI_IFR_FLAG_REST_STYLE = 0x20;
  public const ulong EFI_IFR_FLAG_RECONNECT_REQUIRED = 0x40;
  public const ulong EFI_IFR_FLAG_OPTIONS_ONLY = 0x80;
}

//
// Definition for Opcode Reference
// Section 27.3.8.3
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_DEFAULTSTORE
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_STRING_ID DefaultName;
  public ushort DefaultId;
}

//
// Default Identifier of default store
//
public unsafe partial class EFI
{
  public const ulong EFI_HII_DEFAULT_CLASS_STANDARD = 0x0000;
  public const ulong EFI_HII_DEFAULT_CLASS_MANUFACTURING = 0x0001;
  public const ulong EFI_HII_DEFAULT_CLASS_SAFE = 0x0002;
  public const ulong EFI_HII_DEFAULT_CLASS_PLATFORM_BEGIN = 0x4000;
  public const ulong EFI_HII_DEFAULT_CLASS_PLATFORM_END = 0x7fff;
  public const ulong EFI_HII_DEFAULT_CLASS_HARDWARE_BEGIN = 0x8000;
  public const ulong EFI_HII_DEFAULT_CLASS_HARDWARE_END = 0xbfff;
  public const ulong EFI_HII_DEFAULT_CLASS_FIRMWARE_BEGIN = 0xc000;
  public const ulong EFI_HII_DEFAULT_CLASS_FIRMWARE_END = 0xffff;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_VARSTORE
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_GUID Guid;
  public EFI_VARSTORE_ID VarStoreId;
  public ushort Size;
  public fixed byte Name[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_VARSTORE_EFI
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_VARSTORE_ID VarStoreId;
  public EFI_GUID Guid;
  public uint Attributes;
  public ushort Size;
  public fixed byte Name[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_VARSTORE_NAME_VALUE
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_VARSTORE_ID VarStoreId;
  public EFI_GUID Guid;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_FORM_SET
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_GUID Guid;
  public EFI_STRING_ID FormSetTitle;
  public EFI_STRING_ID Help;
  public byte Flags;
  // EFI_GUID              ClassGuid[];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_END
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_FORM
{
  public EFI_IFR_OP_HEADER Header;
  public ushort FormId;
  public EFI_STRING_ID FormTitle;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_IMAGE
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IMAGE_ID Id;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_MODAL_TAG
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_LOCKED
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_RULE
{
  public EFI_IFR_OP_HEADER Header;
  public byte RuleId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_DEFAULT
{
  public EFI_IFR_OP_HEADER Header;
  public ushort DefaultId;
  public byte Type;
  public EFI_IFR_TYPE_VALUE Value;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_DEFAULT_2
{
  public EFI_IFR_OP_HEADER Header;
  public ushort DefaultId;
  public byte Type;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_VALUE
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_SUBTITLE
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_STATEMENT_HEADER Statement;
  public byte Flags;
}

public unsafe partial class EFI
{
  public const ulong EFI_IFR_FLAGS_HORIZONTAL = 0x01;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_CHECKBOX
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public byte Flags;
}

public unsafe partial class EFI
{
  public const ulong EFI_IFR_CHECKBOX_DEFAULT = 0x01;
  public const ulong EFI_IFR_CHECKBOX_DEFAULT_MFG = 0x02;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_TEXT
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_STATEMENT_HEADER Statement;
  public EFI_STRING_ID TextTwo;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_REF
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public EFI_FORM_ID FormId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_REF2
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public EFI_FORM_ID FormId;
  public EFI_QUESTION_ID QuestionId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_REF3
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public EFI_FORM_ID FormId;
  public EFI_QUESTION_ID QuestionId;
  public EFI_GUID FormSetId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_REF4
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public EFI_FORM_ID FormId;
  public EFI_QUESTION_ID QuestionId;
  public EFI_GUID FormSetId;
  public EFI_STRING_ID DevicePath;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_REF5
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_RESET_BUTTON
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_STATEMENT_HEADER Statement;
  public EFI_DEFAULT_ID DefaultId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_ACTION
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public EFI_STRING_ID QuestionConfig;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_ACTION_1
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_DATE
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public byte Flags;
}

//
// Flags that describe the behavior of the question.
//
public unsafe partial class EFI
{
  public const ulong EFI_QF_DATE_YEAR_SUPPRESS = 0x01;
  public const ulong EFI_QF_DATE_MONTH_SUPPRESS = 0x02;
  public const ulong EFI_QF_DATE_DAY_SUPPRESS = 0x04;

  public const ulong EFI_QF_DATE_STORAGE = 0x30;
  public const ulong QF_DATE_STORAGE_NORMAL = 0x00;
  public const ulong QF_DATE_STORAGE_TIME = 0x10;
  public const ulong QF_DATE_STORAGE_WAKEUP = 0x20;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct u8
{
  struct {
   [FieldOffset(0)] public byte MinValue;
  [FieldOffset(0)] public byte MaxValue;
  [FieldOffset(0)] public byte Step;
}
struct {
    ushort MinValue;
ushort MaxValue;
ushort Step;
  } u16;
struct {
    uint MinValue;
uint MaxValue;
uint Step;
  } u32;
struct {
    ulong MinValue;
ulong MaxValue;
ulong Step;
  } u64;
} MINMAXSTEP_DATA;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_NUMERIC
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public byte Flags;
  public MINMAXSTEP_DATA data;
}

//
// Flags related to the numeric question
//
public unsafe partial class EFI
{
  public const ulong EFI_IFR_NUMERIC_SIZE = 0x03;
  public const ulong EFI_IFR_NUMERIC_SIZE_1 = 0x00;
  public const ulong EFI_IFR_NUMERIC_SIZE_2 = 0x01;
  public const ulong EFI_IFR_NUMERIC_SIZE_4 = 0x02;
  public const ulong EFI_IFR_NUMERIC_SIZE_8 = 0x03;

  public const ulong EFI_IFR_DISPLAY = 0x30;
  public const ulong EFI_IFR_DISPLAY_INT_DEC = 0x00;
  public const ulong EFI_IFR_DISPLAY_UINT_DEC = 0x10;
  public const ulong EFI_IFR_DISPLAY_UINT_HEX = 0x20;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_ONE_OF
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public byte Flags;
  public MINMAXSTEP_DATA data;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_STRING
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public byte MinSize;
  public byte MaxSize;
  public byte Flags;
}

public unsafe partial class EFI
{
  public const ulong EFI_IFR_STRING_MULTI_LINE = 0x01;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_PASSWORD
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public ushort MinSize;
  public ushort MaxSize;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_ORDERED_LIST
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public byte MaxContainers;
  public byte Flags;
}

public unsafe partial class EFI
{
  public const ulong EFI_IFR_UNIQUE_SET = 0x01;
  public const ulong EFI_IFR_NO_EMPTY_SET = 0x02;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_TIME
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_IFR_QUESTION_HEADER Question;
  public byte Flags;
}

//
// A bit-mask that determines which unique settings are active for this opcode.
//
public unsafe partial class EFI
{
  public const ulong QF_TIME_HOUR_SUPPRESS = 0x01;
  public const ulong QF_TIME_MINUTE_SUPPRESS = 0x02;
  public const ulong QF_TIME_SECOND_SUPPRESS = 0x04;

  public const ulong QF_TIME_STORAGE = 0x30;
  public const ulong QF_TIME_STORAGE_NORMAL = 0x00;
  public const ulong QF_TIME_STORAGE_TIME = 0x10;
  public const ulong QF_TIME_STORAGE_WAKEUP = 0x20;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_DISABLE_IF
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_SUPPRESS_IF
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_GRAY_OUT_IF
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_INCONSISTENT_IF
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_STRING_ID Error;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_NO_SUBMIT_IF
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_STRING_ID Error;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_WARNING_IF
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_STRING_ID Warning;
  public byte TimeOut;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_REFRESH
{
  public EFI_IFR_OP_HEADER Header;
  public byte RefreshInterval;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_VARSTORE_DEVICE
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_STRING_ID DevicePath;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_ONE_OF_OPTION
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_STRING_ID Option;
  public byte Flags;
  public byte Type;
  public EFI_IFR_TYPE_VALUE Value;
}

//
// Types of the option's value.
//
public unsafe partial class EFI
{
  public const ulong EFI_IFR_TYPE_NUM_SIZE_8 = 0x00;
  public const ulong EFI_IFR_TYPE_NUM_SIZE_16 = 0x01;
  public const ulong EFI_IFR_TYPE_NUM_SIZE_32 = 0x02;
  public const ulong EFI_IFR_TYPE_NUM_SIZE_64 = 0x03;
  public const ulong EFI_IFR_TYPE_BOOLEAN = 0x04;
  public const ulong EFI_IFR_TYPE_TIME = 0x05;
  public const ulong EFI_IFR_TYPE_DATE = 0x06;
  public const ulong EFI_IFR_TYPE_STRING = 0x07;
  public const ulong EFI_IFR_TYPE_OTHER = 0x08;
  public const ulong EFI_IFR_TYPE_UNDEFINED = 0x09;
  public const ulong EFI_IFR_TYPE_ACTION = 0x0A;
  public const ulong EFI_IFR_TYPE_BUFFER = 0x0B;
  public const ulong EFI_IFR_TYPE_REF = 0x0C;

  public const ulong EFI_IFR_OPTION_DEFAULT = 0x10;
  public const ulong EFI_IFR_OPTION_DEFAULT_MFG = 0x20;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_GUID
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_GUID Guid;
  // Optional Data Follows
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_REFRESH_ID
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_GUID RefreshEventGroupId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_DUP
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_EQ_ID_ID
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_QUESTION_ID QuestionId1;
  public EFI_QUESTION_ID QuestionId2;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_EQ_ID_VAL
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_QUESTION_ID QuestionId;
  public ushort Value;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_EQ_ID_VAL_LIST
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_QUESTION_ID QuestionId;
  public ushort ListLength;
  public fixed ushort ValueList[1];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_UINT8
{
  public EFI_IFR_OP_HEADER Header;
  public byte Value;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_UINT16
{
  public EFI_IFR_OP_HEADER Header;
  public ushort Value;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_UINT32
{
  public EFI_IFR_OP_HEADER Header;
  public uint Value;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_UINT64
{
  public EFI_IFR_OP_HEADER Header;
  public ulong Value;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_QUESTION_REF1
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_QUESTION_ID QuestionId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_QUESTION_REF2
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_QUESTION_REF3
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_QUESTION_REF3_2
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_STRING_ID DevicePath;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_QUESTION_REF3_3
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_STRING_ID DevicePath;
  public EFI_GUID Guid;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_RULE_REF
{
  public EFI_IFR_OP_HEADER Header;
  public byte RuleId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_STRING_REF1
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_STRING_ID StringId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_STRING_REF2
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_THIS
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_TRUE
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_FALSE
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_ONE
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_ONES
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_ZERO
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_UNDEFINED
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_VERSION
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_LENGTH
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_NOT
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_BITWISE_NOT
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_TO_BOOLEAN
{
  public EFI_IFR_OP_HEADER Header;
}

///
/// For EFI_IFR_TO_STRING, when converting from
/// unsigned integers, these flags control the format:
/// 0 = unsigned decimal.
/// 1 = signed decimal.
/// 2 = hexadecimal (lower-case alpha).
/// 3 = hexadecimal (upper-case alpha).
///@{
public unsafe partial class EFI
{
  public const ulong EFI_IFR_STRING_UNSIGNED_DEC = 0;
  public const ulong EFI_IFR_STRING_SIGNED_DEC = 1;
  public const ulong EFI_IFR_STRING_LOWERCASE_HEX = 2;
  public const ulong EFI_IFR_STRING_UPPERCASE_HEX = 3;
  ///@}

  ///
  /// When converting from a buffer, these flags control the format:
  /// 0 = ASCII.
  /// 8 = Unicode.
  ///@{
  public const ulong EFI_IFR_STRING_ASCII = 0;
  public const ulong EFI_IFR_STRING_UNICODE = 8;
  ///@}
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_TO_STRING
{
  public EFI_IFR_OP_HEADER Header;
  public byte Format;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_TO_UINT
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_TO_UPPER
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_TO_LOWER
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_ADD
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_AND
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_BITWISE_AND
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_BITWISE_OR
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_CATENATE
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_DIVIDE
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_EQUAL
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_GREATER_EQUAL
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_GREATER_THAN
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_LESS_EQUAL
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_LESS_THAN
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_MATCH
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_MATCH2
{
  public EFI_IFR_OP_HEADER Header;
  public EFI_GUID SyntaxType;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_MULTIPLY
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_MODULO
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_NOT_EQUAL
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_OR
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_SHIFT_LEFT
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_SHIFT_RIGHT
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_SUBTRACT
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_CONDITIONAL
{
  public EFI_IFR_OP_HEADER Header;
}

//
// Flags governing the matching criteria of EFI_IFR_FIND
//
public unsafe partial class EFI
{
  public const ulong EFI_IFR_FF_CASE_SENSITIVE = 0x00;
  public const ulong EFI_IFR_FF_CASE_INSENSITIVE = 0x01;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_FIND
{
  public EFI_IFR_OP_HEADER Header;
  public byte Format;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_MID
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_TOKEN
{
  public EFI_IFR_OP_HEADER Header;
}

//
// Flags specifying whether to find the first matching string
// or the first non-matching string.
//
public unsafe partial class EFI
{
  public const ulong EFI_IFR_FLAGS_FIRST_MATCHING = 0x00;
  public const ulong EFI_IFR_FLAGS_FIRST_NON_MATCHING = 0x01;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_SPAN
{
  public EFI_IFR_OP_HEADER Header;
  public byte Flags;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_SECURITY
{
  ///
  /// Standard opcode header, where Header.Op = EFI_IFR_SECURITY_OP.
  ///
  public EFI_IFR_OP_HEADER Header;
  ///
  /// Security permission level.
  ///
  public EFI_GUID Permissions;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_FORM_MAP_METHOD
{
  ///
  /// The string identifier which provides the human-readable name of
  /// the configuration method for this standards map form.
  ///
  public EFI_STRING_ID MethodTitle;
  ///
  /// Identifier which uniquely specifies the configuration methods
  /// associated with this standards map form.
  ///
  public EFI_GUID MethodIdentifier;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_FORM_MAP
{
  ///
  /// The sequence that defines the type of opcode as well as the length
  /// of the opcode being defined. Header.OpCode = EFI_IFR_FORM_MAP_OP.
  ///
  public EFI_IFR_OP_HEADER Header;
  ///
  /// The unique identifier for this particular form.
  ///
  public EFI_FORM_ID FormId;
  ///
  /// One or more configuration method's name and unique identifier.
  ///
  // EFI_IFR_FORM_MAP_METHOD  Methods[];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VarStoreInfo
{
  ///
  /// The sequence that defines the type of opcode as well as the length
  /// of the opcode being defined. Header.OpCode = EFI_IFR_SET_OP.
  ///
  public EFI_IFR_OP_HEADER Header;
  ///
  /// Specifies the identifier of a previously declared variable store to
  /// use when storing the question's value.
  ///
  public EFI_VARSTORE_ID VarStoreId;
  union {
    ///
    /// A 16-bit Buffer Storage offset.
    ///
   public EFI_STRING_ID VarName;
  ///
  /// A Name Value or EFI Variable name (VarName).
  ///
  public ushort VarOffset;
}
///
/// Specifies the type used for storage.
///
byte VarStoreType;
} EFI_IFR_SET;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VarStoreInfo
{
  ///
  /// The sequence that defines the type of opcode as well as the length
  /// of the opcode being defined. Header.OpCode = EFI_IFR_GET_OP.
  ///
  public EFI_IFR_OP_HEADER Header;
  ///
  /// Specifies the identifier of a previously declared variable store to
  /// use when retrieving the value.
  ///
  public EFI_VARSTORE_ID VarStoreId;
  union {
    ///
    /// A 16-bit Buffer Storage offset.
    ///
   public EFI_STRING_ID VarName;
  ///
  /// A Name Value or EFI Variable name (VarName).
  ///
  public ushort VarOffset;
}
///
/// Specifies the type used for storage.
///
byte VarStoreType;
} EFI_IFR_GET;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_READ
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_WRITE
{
  public EFI_IFR_OP_HEADER Header;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_MAP
{
  public EFI_IFR_OP_HEADER Header;
}
//
// Definitions for Keyboard Package
// Releated definitions are in Section of EFI_HII_DATABASE_PROTOCOL
//

///
/// Each enumeration values maps a physical key on a keyboard.
///
public enum EFI_KEY
{
  EfiKeyLCtrl,
  EfiKeyA0,
  EfiKeyLAlt,
  EfiKeySpaceBar,
  EfiKeyA2,
  EfiKeyA3,
  EfiKeyA4,
  EfiKeyRCtrl,
  EfiKeyLeftArrow,
  EfiKeyDownArrow,
  EfiKeyRightArrow,
  EfiKeyZero,
  EfiKeyPeriod,
  EfiKeyEnter,
  EfiKeyLShift,
  EfiKeyB0,
  EfiKeyB1,
  EfiKeyB2,
  EfiKeyB3,
  EfiKeyB4,
  EfiKeyB5,
  EfiKeyB6,
  EfiKeyB7,
  EfiKeyB8,
  EfiKeyB9,
  EfiKeyB10,
  EfiKeyRShift,
  EfiKeyUpArrow,
  EfiKeyOne,
  EfiKeyTwo,
  EfiKeyThree,
  EfiKeyCapsLock,
  EfiKeyC1,
  EfiKeyC2,
  EfiKeyC3,
  EfiKeyC4,
  EfiKeyC5,
  EfiKeyC6,
  EfiKeyC7,
  EfiKeyC8,
  EfiKeyC9,
  EfiKeyC10,
  EfiKeyC11,
  EfiKeyC12,
  EfiKeyFour,
  EfiKeyFive,
  EfiKeySix,
  EfiKeyPlus,
  EfiKeyTab,
  EfiKeyD1,
  EfiKeyD2,
  EfiKeyD3,
  EfiKeyD4,
  EfiKeyD5,
  EfiKeyD6,
  EfiKeyD7,
  EfiKeyD8,
  EfiKeyD9,
  EfiKeyD10,
  EfiKeyD11,
  EfiKeyD12,
  EfiKeyD13,
  EfiKeyDel,
  EfiKeyEnd,
  EfiKeyPgDn,
  EfiKeySeven,
  EfiKeyEight,
  EfiKeyNine,
  EfiKeyE0,
  EfiKeyE1,
  EfiKeyE2,
  EfiKeyE3,
  EfiKeyE4,
  EfiKeyE5,
  EfiKeyE6,
  EfiKeyE7,
  EfiKeyE8,
  EfiKeyE9,
  EfiKeyE10,
  EfiKeyE11,
  EfiKeyE12,
  EfiKeyBackSpace,
  EfiKeyIns,
  EfiKeyHome,
  EfiKeyPgUp,
  EfiKeyNLck,
  EfiKeySlash,
  EfiKeyAsterisk,
  EfiKeyMinus,
  EfiKeyEsc,
  EfiKeyF1,
  EfiKeyF2,
  EfiKeyF3,
  EfiKeyF4,
  EfiKeyF5,
  EfiKeyF6,
  EfiKeyF7,
  EfiKeyF8,
  EfiKeyF9,
  EfiKeyF10,
  EfiKeyF11,
  EfiKeyF12,
  EfiKeyPrint,
  EfiKeySLck,
  EfiKeyPause
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_KEY_DESCRIPTOR
{
  ///
  /// Used to describe a physical key on a keyboard.
  ///
  public EFI_KEY Key;
  ///
  /// Unicode character code for the Key.
  ///
  public char Unicode;
  ///
  /// Unicode character code for the key with the shift key being held down.
  ///
  public char ShiftedUnicode;
  ///
  /// Unicode character code for the key with the Alt-GR being held down.
  ///
  public char AltGrUnicode;
  ///
  /// Unicode character code for the key with the Alt-GR and shift keys being held down.
  ///
  public char ShiftedAltGrUnicode;
  ///
  /// Modifier keys are defined to allow for special functionality that is not necessarily
  /// accomplished by a printable character. Many of these modifier keys are flags to toggle
  /// certain state bits on and off inside of a keyboard driver.
  ///
  public ushort Modifier;
  public ushort AffectedAttribute;
}

///
/// A key which is affected by all the standard shift modifiers.
/// Most keys would be expected to have this bit active.
///
public unsafe partial class EFI
{
  public const ulong EFI_AFFECTED_BY_STANDARD_SHIFT = 0x0001;

  ///
  /// This key is affected by the caps lock so that if a keyboard driver
  /// would need to disambiguate between a key which had a "1" defined
  /// versus an "a" character.  Having this bit turned on would tell
  /// the keyboard driver to use the appropriate shifted state or not.
  ///
  public const ulong EFI_AFFECTED_BY_CAPS_LOCK = 0x0002;

  ///
  /// Similar to the case of CAPS lock, if this bit is active, the key
  /// is affected by the num lock being turned on.
  ///
  public const ulong EFI_AFFECTED_BY_NUM_LOCK = 0x0004;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_KEYBOARD_LAYOUT
{
  public ushort LayoutLength;
  public EFI_GUID Guid;
  public uint LayoutDescriptorStringOffset;
  public byte DescriptorCount;
  // EFI_KEY_DESCRIPTOR    Descriptors[];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_KEYBOARD_PACKAGE_HDR
{
  public EFI_HII_PACKAGE_HEADER Header;
  public ushort LayoutCount;
  // EFI_HII_KEYBOARD_LAYOUT Layout[];
}

//
// Modifier values
//
public unsafe partial class EFI
{
  public const ulong EFI_NULL_MODIFIER = 0x0000;
  public const ulong EFI_LEFT_CONTROL_MODIFIER = 0x0001;
  public const ulong EFI_RIGHT_CONTROL_MODIFIER = 0x0002;
  public const ulong EFI_LEFT_ALT_MODIFIER = 0x0003;
  public const ulong EFI_RIGHT_ALT_MODIFIER = 0x0004;
  public const ulong EFI_ALT_GR_MODIFIER = 0x0005;
  public const ulong EFI_INSERT_MODIFIER = 0x0006;
  public const ulong EFI_DELETE_MODIFIER = 0x0007;
  public const ulong EFI_PAGE_DOWN_MODIFIER = 0x0008;
  public const ulong EFI_PAGE_UP_MODIFIER = 0x0009;
  public const ulong EFI_HOME_MODIFIER = 0x000A;
  public const ulong EFI_END_MODIFIER = 0x000B;
  public const ulong EFI_LEFT_SHIFT_MODIFIER = 0x000C;
  public const ulong EFI_RIGHT_SHIFT_MODIFIER = 0x000D;
  public const ulong EFI_CAPS_LOCK_MODIFIER = 0x000E;
  public const ulong EFI_NUM_LOCK_MODIFIER = 0x000F;
  public const ulong EFI_LEFT_ARROW_MODIFIER = 0x0010;
  public const ulong EFI_RIGHT_ARROW_MODIFIER = 0x0011;
  public const ulong EFI_DOWN_ARROW_MODIFIER = 0x0012;
  public const ulong EFI_UP_ARROW_MODIFIER = 0x0013;
  public const ulong EFI_NS_KEY_MODIFIER = 0x0014;
  public const ulong EFI_NS_KEY_DEPENDENCY_MODIFIER = 0x0015;
  public const ulong EFI_FUNCTION_KEY_ONE_MODIFIER = 0x0016;
  public const ulong EFI_FUNCTION_KEY_TWO_MODIFIER = 0x0017;
  public const ulong EFI_FUNCTION_KEY_THREE_MODIFIER = 0x0018;
  public const ulong EFI_FUNCTION_KEY_FOUR_MODIFIER = 0x0019;
  public const ulong EFI_FUNCTION_KEY_FIVE_MODIFIER = 0x001A;
  public const ulong EFI_FUNCTION_KEY_SIX_MODIFIER = 0x001B;
  public const ulong EFI_FUNCTION_KEY_SEVEN_MODIFIER = 0x001C;
  public const ulong EFI_FUNCTION_KEY_EIGHT_MODIFIER = 0x001D;
  public const ulong EFI_FUNCTION_KEY_NINE_MODIFIER = 0x001E;
  public const ulong EFI_FUNCTION_KEY_TEN_MODIFIER = 0x001F;
  public const ulong EFI_FUNCTION_KEY_ELEVEN_MODIFIER = 0x0020;
  public const ulong EFI_FUNCTION_KEY_TWELVE_MODIFIER = 0x0021;

  //
  // Keys that have multiple control functions based on modifier
  // settings are handled in the keyboard driver implementation.
  // For instance, PRINT_KEY might have a modifier held down and
  // is still a nonprinting character, but might have an alternate
  // control function like SYSREQUEST
  //
  public const ulong EFI_PRINT_MODIFIER = 0x0022;
  public const ulong EFI_SYS_REQUEST_MODIFIER = 0x0023;
  public const ulong EFI_SCROLL_LOCK_MODIFIER = 0x0024;
  public const ulong EFI_PAUSE_MODIFIER = 0x0025;
  public const ulong EFI_BREAK_MODIFIER = 0x0026;

  public const ulong EFI_LEFT_LOGO_MODIFIER = 0x0027;
  public const ulong EFI_RIGHT_LOGO_MODIFIER = 0x0028;
  public const ulong EFI_MENU_MODIFIER = 0x0029;
}

///
/// Animation IFR opcode
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IFR_ANIMATION
{
  ///
  /// Standard opcode header, where Header.OpCode is
  /// EFI_IFR_ANIMATION_OP.
  ///
  public EFI_IFR_OP_HEADER Header;
  ///
  /// Animation identifier in the HII database.
  ///
  public EFI_ANIMATION_ID Id;
}

///
/// HII animation package header.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_ANIMATION_PACKAGE_HDR
{
  ///
  /// Standard package header, where Header.Type = EFI_HII_PACKAGE_ANIMATIONS.
  ///
  public EFI_HII_PACKAGE_HEADER Header;
  ///
  /// Offset, relative to this header, of the animation information. If
  /// this is zero, then there are no animation sequences in the package.
  ///
  public uint AnimationInfoOffset;
}

///
/// Animation information is encoded as a series of blocks,
/// with each block prefixed by a single byte header EFI_HII_ANIMATION_BLOCK.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_ANIMATION_BLOCK
{
  public byte BlockType;
  // byte  BlockBody[];
}

///
/// Animation block types.
///
public unsafe partial class EFI
{
  public const ulong EFI_HII_AIBT_END = 0x00;
  public const ulong EFI_HII_AIBT_OVERLAY_IMAGES = 0x10;
  public const ulong EFI_HII_AIBT_CLEAR_IMAGES = 0x11;
  public const ulong EFI_HII_AIBT_RESTORE_SCRN = 0x12;
  public const ulong EFI_HII_AIBT_OVERLAY_IMAGES_LOOP = 0x18;
  public const ulong EFI_HII_AIBT_CLEAR_IMAGES_LOOP = 0x19;
  public const ulong EFI_HII_AIBT_RESTORE_SCRN_LOOP = 0x1A;
  public const ulong EFI_HII_AIBT_DUPLICATE = 0x20;
  public const ulong EFI_HII_AIBT_SKIP2 = 0x21;
  public const ulong EFI_HII_AIBT_SKIP1 = 0x22;
  public const ulong EFI_HII_AIBT_EXT1 = 0x30;
  public const ulong EFI_HII_AIBT_EXT2 = 0x31;
  public const ulong EFI_HII_AIBT_EXT4 = 0x32;

  ///
  /// Extended block headers used for variable sized animation records
  /// which need an explicit length.
  ///
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_EXT1_BLOCK
{
  ///
  /// Standard animation header, where Header.BlockType = EFI_HII_AIBT_EXT1.
  ///
  public EFI_HII_ANIMATION_BLOCK Header;
  ///
  /// The block type.
  ///
  public byte BlockType2;
  ///
  /// Size of the animation block, in bytes, including the animation block header.
  ///
  public byte Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_EXT2_BLOCK
{
  ///
  /// Standard animation header, where Header.BlockType = EFI_HII_AIBT_EXT2.
  ///
  public EFI_HII_ANIMATION_BLOCK Header;
  ///
  /// The block type
  ///
  public byte BlockType2;
  ///
  /// Size of the animation block, in bytes, including the animation block header.
  ///
  public ushort Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_EXT4_BLOCK
{
  ///
  /// Standard animation header, where Header.BlockType = EFI_HII_AIBT_EXT4.
  ///
  public EFI_HII_ANIMATION_BLOCK Header;
  ///
  /// The block type
  ///
  public byte BlockType2;
  ///
  /// Size of the animation block, in bytes, including the animation block header.
  ///
  public uint Length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_ANIMATION_CELL
{
  ///
  /// The X offset from the upper left hand corner of the logical
  /// window to position the indexed image.
  ///
  public ushort OffsetX;
  ///
  /// The Y offset from the upper left hand corner of the logical
  /// window to position the indexed image.
  ///
  public ushort OffsetY;
  ///
  /// The image to display at the specified offset from the upper left
  /// hand corner of the logical window.
  ///
  public EFI_IMAGE_ID ImageId;
  ///
  /// The number of milliseconds to delay after displaying the indexed
  /// image and before continuing on to the next linked image.  If value
  /// is zero, no delay.
  ///
  public ushort Delay;
}

///
/// An animation block to describe an animation sequence that does not cycle, and
/// where one image is simply displayed over the previous image.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_OVERLAY_IMAGES_BLOCK
{
  ///
  /// This is image that is to be reference by the image protocols, if the
  /// animation function is not supported or disabled. This image can
  /// be one particular image from the animation sequence (if any one
  /// of the animation frames has a complete image) or an alternate
  /// image that can be displayed alone. If the value is zero, no image
  /// is displayed.
  ///
  public EFI_IMAGE_ID DftImageId;
  ///
  /// The overall width of the set of images (logical window width).
  ///
  public ushort Width;
  ///
  /// The overall height of the set of images (logical window height).
  ///
  public ushort Height;
  ///
  /// The number of EFI_HII_ANIMATION_CELL contained in the
  /// animation sequence.
  ///
  public ushort CellCount;
  ///
  /// An array of CellCount animation cells.
  ///
  public fixed EFI_HII_ANIMATION_CELL AnimationCell[1];
}

///
/// An animation block to describe an animation sequence that does not cycle,
/// and where the logical window is cleared to the specified color before
/// the next image is displayed.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_CLEAR_IMAGES_BLOCK
{
  ///
  /// This is image that is to be reference by the image protocols, if the
  /// animation function is not supported or disabled. This image can
  /// be one particular image from the animation sequence (if any one
  /// of the animation frames has a complete image) or an alternate
  /// image that can be displayed alone. If the value is zero, no image
  /// is displayed.
  ///
  public EFI_IMAGE_ID DftImageId;
  ///
  /// The overall width of the set of images (logical window width).
  ///
  public ushort Width;
  ///
  /// The overall height of the set of images (logical window height).
  ///
  public ushort Height;
  ///
  /// The number of EFI_HII_ANIMATION_CELL contained in the
  /// animation sequence.
  ///
  public ushort CellCount;
  ///
  /// The color to clear the logical window to before displaying the
  /// indexed image.
  ///
  public EFI_HII_RGB_PIXEL BackgndColor;
  ///
  /// An array of CellCount animation cells.
  ///
  public fixed EFI_HII_ANIMATION_CELL AnimationCell[1];
}

///
/// An animation block to describe an animation sequence that does not cycle,
/// and where the screen is restored to the original state before the next
/// image is displayed.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_RESTORE_SCRN_BLOCK
{
  ///
  /// This is image that is to be reference by the image protocols, if the
  /// animation function is not supported or disabled. This image can
  /// be one particular image from the animation sequence (if any one
  /// of the animation frames has a complete image) or an alternate
  /// image that can be displayed alone. If the value is zero, no image
  /// is displayed.
  ///
  public EFI_IMAGE_ID DftImageId;
  ///
  /// The overall width of the set of images (logical window width).
  ///
  public ushort Width;
  ///
  /// The overall height of the set of images (logical window height).
  ///
  public ushort Height;
  ///
  /// The number of EFI_HII_ANIMATION_CELL contained in the
  /// animation sequence.
  ///
  public ushort CellCount;
  ///
  /// An array of CellCount animation cells.
  ///
  public fixed EFI_HII_ANIMATION_CELL AnimationCell[1];
}

///
/// An animation block to describe an animation sequence that continuously cycles,
/// and where one image is simply displayed over the previous image.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_OVERLAY_IMAGES_LOOP_BLOCK { EFI_HII_AIBT_OVERLAY_IMAGES_BLOCK Value; public static implicit operator EFI_HII_AIBT_OVERLAY_IMAGES_LOOP_BLOCK(EFI_HII_AIBT_OVERLAY_IMAGES_BLOCK value) => new EFI_HII_AIBT_OVERLAY_IMAGES_LOOP_BLOCK() { Value = value }; public static implicit operator EFI_HII_AIBT_OVERLAY_IMAGES_BLOCK(EFI_HII_AIBT_OVERLAY_IMAGES_LOOP_BLOCK value) => value.Value; }

///
/// An animation block to describe an animation sequence that continuously cycles,
/// and where the logical window is cleared to the specified color before
/// the next image is displayed.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_CLEAR_IMAGES_LOOP_BLOCK { EFI_HII_AIBT_CLEAR_IMAGES_BLOCK Value; public static implicit operator EFI_HII_AIBT_CLEAR_IMAGES_LOOP_BLOCK(EFI_HII_AIBT_CLEAR_IMAGES_BLOCK value) => new EFI_HII_AIBT_CLEAR_IMAGES_LOOP_BLOCK() { Value = value }; public static implicit operator EFI_HII_AIBT_CLEAR_IMAGES_BLOCK(EFI_HII_AIBT_CLEAR_IMAGES_LOOP_BLOCK value) => value.Value; }

///
/// An animation block to describe an animation sequence that continuously cycles,
/// and where the screen is restored to the original state before
/// the next image is displayed.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_RESTORE_SCRN_LOOP_BLOCK { EFI_HII_AIBT_RESTORE_SCRN_BLOCK Value; public static implicit operator EFI_HII_AIBT_RESTORE_SCRN_LOOP_BLOCK(EFI_HII_AIBT_RESTORE_SCRN_BLOCK value) => new EFI_HII_AIBT_RESTORE_SCRN_LOOP_BLOCK() { Value = value }; public static implicit operator EFI_HII_AIBT_RESTORE_SCRN_BLOCK(EFI_HII_AIBT_RESTORE_SCRN_LOOP_BLOCK value) => value.Value; }

///
/// Assigns a new character value to a previously defined animation sequence.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_DUPLICATE_BLOCK
{
  ///
  /// The previously defined animation ID with the exact same
  /// animation information.
  ///
  public EFI_ANIMATION_ID AnimationId;
}

///
/// Skips animation IDs.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_SKIP1_BLOCK
{
  ///
  /// The unsigned 8-bit value to add to AnimationIdCurrent.
  ///
  public byte SkipCount;
}

///
/// Skips animation IDs.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_AIBT_SKIP2_BLOCK
{
  ///
  /// The unsigned 16-bit value to add to AnimationIdCurrent.
  ///
  public ushort SkipCount;
}

// #pragma pack()

///
/// References to string tokens must use this macro to enable scanning for
/// token usages.
///
///
/// STRING_TOKEN is not defined in UEFI specification. But it is placed
/// here for the easy access by C files and VFR source files.
///
public unsafe partial class EFI
{
  public const ulong STRING_TOKEN = (t)t;

  ///
  /// IMAGE_TOKEN is not defined in UEFI specification. But it is placed
  /// here for the easy access by C files and VFR source files.
  ///
  public const ulong IMAGE_TOKEN = (t)t;
}

// #endif
