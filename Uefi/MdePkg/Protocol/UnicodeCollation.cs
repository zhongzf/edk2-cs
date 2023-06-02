using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Unicode Collation protocol that follows the UEFI 2.0 specification.
  This protocol is used to allow code running in the boot services environment
  to perform lexical comparison functions on Unicode strings for given languages.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __UNICODE_COLLATION_H__
// #define __UNICODE_COLLATION_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_UNICODE_COLLATION_PROTOCOL_GUID = new GUID(
      0x1d85cd7f, 0xf43d, 0x11d2, new byte[] { 0x9a, 0xc, 0x0, 0x90, 0x27, 0x3f, 0xc1, 0x4d });

  public static EFI_GUID EFI_UNICODE_COLLATION_PROTOCOL2_GUID = new GUID(
      0xa4c751fc, 0x23ae, 0x4c3e, new byte[] { 0x92, 0xe9, 0x49, 0x64, 0xcf, 0x63, 0xf3, 0x49 });

  // typedef struct _EFI_UNICODE_COLLATION_PROTOCOL EFI_UNICODE_COLLATION_PROTOCOL;

  ///
  /// Protocol GUID name defined in EFI1.1.
  ///
  public const ulong UNICODE_COLLATION_PROTOCOL = EFI_UNICODE_COLLATION_PROTOCOL_GUID;
}

///
/// Protocol defined in EFI1.1.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct UNICODE_COLLATION_INTERFACE { EFI_UNICODE_COLLATION_PROTOCOL Value; public static implicit operator UNICODE_COLLATION_INTERFACE(EFI_UNICODE_COLLATION_PROTOCOL value) => new UNICODE_COLLATION_INTERFACE() { Value = value }; public static implicit operator EFI_UNICODE_COLLATION_PROTOCOL(UNICODE_COLLATION_INTERFACE value) => value.Value; }

public unsafe partial class EFI
{
  ///
  /// Protocol data structures and defines
  ///
  public const ulong EFI_UNICODE_BYTE_ORDER_MARK = (char)(0xfeff);

  //
  // Protocol member functions
  //

}

///
/// The EFI_UNICODE_COLLATION_PROTOCOL is used to perform case-insensitive
/// comparisons of strings.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_UNICODE_COLLATION_PROTOCOL
{
  /**
    Performs a case-insensitive comparison of two Null-terminated strings.

    @param  This A pointer to the EFI_UNICODE_COLLATION_PROTOCOL instance.
    @param  Str1 A pointer to a Null-terminated string.
    @param  Str2 A pointer to a Null-terminated string.

    @retval 0   Str1 is equivalent to Str2.
    @retval >0  Str1 is lexically greater than Str2.
    @retval <0  Str1 is lexically less than Str2.

  **/
  public readonly delegate* unmanaged<EFI_UNICODE_COLLATION_PROTOCOL*, char*, char*, EFI_STATUS> StriColl;
  /**
    Performs a case-insensitive comparison of a Null-terminated
    pattern string and a Null-terminated string.

    @param  This    A pointer to the EFI_UNICODE_COLLATION_PROTOCOL instance.
    @param  String  A pointer to a Null-terminated string.
    @param  Pattern A pointer to a Null-terminated pattern string.

    @retval TRUE    Pattern was found in String.
    @retval FALSE   Pattern was not found in String.

  **/
  public readonly delegate* unmanaged<EFI_UNICODE_COLLATION_PROTOCOL*, char*, char*, EFI_STATUS> MetaiMatch;
  /**
    Converts all the characters in a Null-terminated string to
    lower case characters.

    @param  This   A pointer to the EFI_UNICODE_COLLATION_PROTOCOL instance.
    @param  String A pointer to a Null-terminated string.

  **/
  public readonly delegate* unmanaged<EFI_UNICODE_COLLATION_PROTOCOL*, char*, EFI_STATUS> StrLwr;
  /**
    Converts all the characters in a Null-terminated string to upper
    case characters.

    @param  This   A pointer to the EFI_UNICODE_COLLATION_PROTOCOL instance.
    @param  String A pointer to a Null-terminated string.

  **/
  public readonly delegate* unmanaged<EFI_UNICODE_COLLATION_PROTOCOL*, char*, EFI_STATUS> StrUpr;

  //
  // for supporting fat volumes
  //
  /**
    Converts an 8.3 FAT file name in an OEM character set to a Null-terminated
    string.

    @param  This    A pointer to the EFI_UNICODE_COLLATION_PROTOCOL instance.
    @param  FatSize The size of the string Fat in bytes.
    @param  Fat     A pointer to a Null-terminated string that contains an 8.3 file
                    name using an 8-bit OEM character set.
    @param  String  A pointer to a Null-terminated string. The string must
                    be allocated in advance to hold FatSize characters.

  **/
  public readonly delegate* unmanaged<EFI_UNICODE_COLLATION_PROTOCOL*, ulong, byte*, char*, EFI_STATUS> FatToStr;
  /**
    Converts a Null-terminated string to legal characters in a FAT
    filename using an OEM character set.

    @param  This    A pointer to the EFI_UNICODE_COLLATION_PROTOCOL instance.
    @param  String  A pointer to a Null-terminated string.
    @param  FatSize The size of the string Fat in bytes.
    @param  Fat     A pointer to a string that contains the converted version of
                    String using legal FAT characters from an OEM character set.

    @retval TRUE    One or more conversions failed and were substituted with '_'
    @retval FALSE   None of the conversions failed.

  **/
  public readonly delegate* unmanaged<EFI_UNICODE_COLLATION_PROTOCOL*, char*, ulong, byte*, EFI_STATUS> StrToFat;

  ///
  /// A Null-terminated ASCII string array that contains one or more language codes.
  /// When this field is used for UnicodeCollation2, it is specified in RFC 4646 format.
  /// When it is used for UnicodeCollation, it is specified in ISO 639-2 format.
  ///
  public byte* SupportedLanguages;
}

// extern EFI_GUID  gEfiUnicodeCollationProtocolGuid;
// extern EFI_GUID  gEfiUnicodeCollation2ProtocolGuid;

// #endif
