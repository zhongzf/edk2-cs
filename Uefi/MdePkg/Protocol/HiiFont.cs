using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  The file provides services to retrieve font information.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in UEFI Specification 2.1.

**/

// #ifndef __HII_FONT_H__
// #define __HII_FONT_H__

// #include <Protocol/GraphicsOutput.h>
// #include <Protocol/HiiImage.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_HII_FONT_PROTOCOL_GUID = new GUID(0xe9ca4775, 0x8657, 0x47fc, new byte[] { 0x97, 0xe7, 0x7e, 0xd6, 0x5a, 0x8, 0x43, 0x24 });

  // typedef struct _EFI_HII_FONT_PROTOCOL EFI_HII_FONT_PROTOCOL;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FONT_HANDLE { void* Value; public static implicit operator EFI_FONT_HANDLE(void* value) => new EFI_FONT_HANDLE() { Value = value }; public static implicit operator void*(EFI_FONT_HANDLE value) => value.Value; }

///
/// EFI_HII_OUT_FLAGS.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_OUT_FLAGS { uint Value; public static implicit operator EFI_HII_OUT_FLAGS(uint value) => new EFI_HII_OUT_FLAGS() { Value = value }; public static implicit operator uint(EFI_HII_OUT_FLAGS value) => value.Value; }

public unsafe partial class EFI
{
  public const ulong EFI_HII_OUT_FLAG_CLIP = 0x00000001;
  public const ulong EFI_HII_OUT_FLAG_WRAP = 0x00000002;
  public const ulong EFI_HII_OUT_FLAG_CLIP_CLEAN_Y = 0x00000004;
  public const ulong EFI_HII_OUT_FLAG_CLIP_CLEAN_X = 0x00000008;
  public const ulong EFI_HII_OUT_FLAG_TRANSPARENT = 0x00000010;
  public const ulong EFI_HII_IGNORE_IF_NO_GLYPH = 0x00000020;
  public const ulong EFI_HII_IGNORE_LINE_BREAK = 0x00000040;
  public const ulong EFI_HII_DIRECT_TO_SCREEN = 0x00000080;
}

/**
  Definition of EFI_HII_ROW_INFO.
**/
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_ROW_INFO
{
  ///
  /// The index of the first character in the string which is displayed on the line.
  ///
  public ulong StartIndex;
  ///
  /// The index of the last character in the string which is displayed on the line.
  /// If this is the same as StartIndex, then no characters are displayed.
  ///
  public ulong EndIndex;
  public ulong LineHeight; ///< The height of the line, in pixels.
  public ulong LineWidth;  ///< The width of the text on the line, in pixels.

                           ///
                           /// The font baseline offset in pixels from the bottom of the row, or 0 if none.
                           ///
  public ulong BaselineOffset;
}

///
/// Font info flag. All flags (FONT, SIZE, STYLE, and COLOR) are defined.
/// They are defined as EFI_FONT_INFO_***
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FONT_INFO_MASK { uint Value; public static implicit operator EFI_FONT_INFO_MASK(uint value) => new EFI_FONT_INFO_MASK() { Value = value }; public static implicit operator uint(EFI_FONT_INFO_MASK value) => value.Value; }

public unsafe partial class EFI
{
  public const ulong EFI_FONT_INFO_SYS_FONT = 0x00000001;
  public const ulong EFI_FONT_INFO_SYS_SIZE = 0x00000002;
  public const ulong EFI_FONT_INFO_SYS_STYLE = 0x00000004;
  public const ulong EFI_FONT_INFO_SYS_FORE_COLOR = 0x00000010;
  public const ulong EFI_FONT_INFO_SYS_BACK_COLOR = 0x00000020;
  public const ulong EFI_FONT_INFO_RESIZE = 0x00001000;
  public const ulong EFI_FONT_INFO_RESTYLE = 0x00002000;
  public const ulong EFI_FONT_INFO_ANY_FONT = 0x00010000;
  public const ulong EFI_FONT_INFO_ANY_SIZE = 0x00020000;
  public const ulong EFI_FONT_INFO_ANY_STYLE = 0x00040000;
}

//
// EFI_FONT_INFO
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FONT_INFO
{
  public EFI_HII_FONT_STYLE FontStyle;
  public ushort FontSize;   ///< character cell height in pixels
  public fixed char FontName[1];
}

/**
  Describes font output-related information.

  This structure is used for describing the way in which a string
  should be rendered in a particular font. FontInfo specifies the
  basic font information and ForegroundColor and BackgroundColor
  specify the color in which they should be displayed. The flags
  in FontInfoMask describe where the system default should be
  supplied instead of the specified information. The flags also
  describe what options can be used to make a match between the
  font requested and the font available.
**/
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FONT_DISPLAY_INFO
{
  public EFI_GRAPHICS_OUTPUT_BLT_PIXEL ForegroundColor;
  public EFI_GRAPHICS_OUTPUT_BLT_PIXEL BackgroundColor;
  public EFI_FONT_INFO_MASK FontInfoMask;
  public EFI_FONT_INFO FontInfo;
}

///
/// The protocol provides the service to retrieve the font informations.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_FONT_PROTOCOL
{
  /**

    This function renders a string to a bitmap or the screen using
    the specified font, color and options. It either draws the
    string and glyphs on an existing bitmap, allocates a new bitmap,
    or uses the screen. The strings can be clipped or wrapped.
    Optionally, the function also returns the information about each
    row and the character position on that row. If
    EFI_HII_OUT_FLAG_CLIP is set, then text will be formatted only
    based on explicit line breaks and all pixels which would lie
    outside the bounding box specified by Width and Height are
    ignored. The information in the RowInfoArray only describes
    characters which are at least partially displayed. For the final
    row, the LineHeight and BaseLine may describe pixels that are
    outside the limit specified by Height (unless
    EFI_HII_OUT_FLAG_CLIP_CLEAN_Y is specified) even though those
    pixels were not drawn. The LineWidth may describe pixels which
    are outside the limit specified by Width (unless
    EFI_HII_OUT_FLAG_CLIP_CLEAN_X is specified) even though those
    pixels were not drawn. If EFI_HII_OUT_FLAG_CLIP_CLEAN_X is set,
    then it modifies the behavior of EFI_HII_OUT_FLAG_CLIP so that
    if a character's right-most on pixel cannot fit, then it will
    not be drawn at all. This flag requires that
    EFI_HII_OUT_FLAG_CLIP be set. If EFI_HII_OUT_FLAG_CLIP_CLEAN_Y
    is set, then it modifies the behavior of EFI_HII_OUT_FLAG_CLIP
    so that if a row's bottom-most pixel cannot fit, then it will
    not be drawn at all. This flag requires that
    EFI_HII_OUT_FLAG_CLIP be set. If EFI_HII_OUT_FLAG_WRAP is set,
    then text will be wrapped at the right-most line-break
    opportunity prior to a character whose right-most extent would
    exceed Width. If no line-break opportunity can be found, then
    the text will behave as if EFI_HII_OUT_FLAG_CLIP_CLEAN_X is set.
    This flag cannot be used with EFI_HII_OUT_FLAG_CLIP_CLEAN_X. If
    EFI_HII_OUT_FLAG_TRANSPARENT is set, then BackgroundColor is
    ignored and all 'off' pixels in the character's drawn
    will use the pixel value from Blt. This flag cannot be used if
    Blt is NULL upon entry. If EFI_HII_IGNORE_IF_NO_GLYPH is set,
    then characters which have no glyphs are not drawn. Otherwise,
    they are replaced with Unicode character code 0xFFFD (REPLACEMENT
    CHARACTER). If EFI_HII_IGNORE_LINE_BREAK is set, then explicit
    line break characters will be ignored. If
    EFI_HII_DIRECT_TO_SCREEN is set, then the string will be written
    directly to the output device specified by Screen. Otherwise the
    string will be rendered to the bitmap specified by Bitmap.

    @param This             A pointer to the EFI_HII_FONT_PROTOCOL instance.

    @param Flags            Describes how the string is to be drawn.

    @param String           Points to the null-terminated string to be

    @param StringInfo       Points to the string output information,
                            including the color and font. If NULL, then
                            the string will be output in the default
                            system font and color.

    @param Blt              If this points to a non-NULL on entry, this points
                            to the image, which is Width pixels wide and
                            Height pixels high. The string will be drawn onto
                            this image and EFI_HII_OUT_FLAG_CLIP is implied.
                            If this points to a NULL on entry, then a buffer
                            will be allocated to hold the generated image and
                            the pointer updated on exit. It is the caller's
                            responsibility to free this buffer.

    @param BltX, BltY       Specifies the offset from the left and top
                            edge of the image of the first character
                            cell in the image.

    @param RowInfoArray     If this is non-NULL on entry, then on
                            exit, this will point to an allocated buffer
                            containing row information and
                            RowInfoArraySize will be updated to contain
                            the number of elements. This array describes
                            the characters that were at least partially
                            drawn and the heights of the rows. It is the
                            caller's responsibility to free this buffer.

    @param RowInfoArraySize If this is non-NULL on entry, then on
                            exit it contains the number of
                            elements in RowInfoArray.

    @param ColumnInfoArray  If this is non-NULL, then on return it
                            will be filled with the horizontal
                            offset for each character in the
                            string on the row where it is
                            displayed. Non-printing characters
                            will have the offset ~0. The caller is
                            responsible for allocating a buffer large
                            enough so that there is one entry for
                            each character in the string, not
                            including the null-terminator. It is
                            possible when character display is
                            normalized that some character cells
                            overlap.

    @retval EFI_SUCCESS           The string was successfully updated.

    @retval EFI_OUT_OF_RESOURCES  Unable to allocate an output buffer for RowInfoArray or Blt.

    @retval EFI_INVALID_PARAMETER The String or Blt was NULL.

    @retval EFI_INVALID_PARAMETER Flags were invalid combination.
  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_OUT_FLAGS, CONST, CONST, EFI_IMAGE_OUTPUT**, ulong, ulong, EFI_HII_ROW_INFO**, ulong*, ulong*, EFI_STATUS> StringToImage;
  /**

    This function renders a string as a bitmap or to the screen
    and can clip or wrap the string. The bitmap is either supplied
    by the caller or allocated by the function. The
    strings are drawn with the font, size and style specified and
    can be drawn transparently or opaquely. The function can also
    return information about each row and each character's
    position on the row. If EFI_HII_OUT_FLAG_CLIP is set, then
    text will be formatted based only on explicit line breaks, and
    all pixels that would lie outside the bounding box specified
    by Width and Height are ignored. The information in the
    RowInfoArray only describes characters which are at least
    partially displayed. For the final row, the LineHeight and
    BaseLine may describe pixels which are outside the limit
    specified by Height (unless EFI_HII_OUT_FLAG_CLIP_CLEAN_Y is
    specified) even though those pixels were not drawn. If
    EFI_HII_OUT_FLAG_CLIP_CLEAN_X is set, then it modifies the
    behavior of EFI_HII_OUT_FLAG_CLIP so that if a character's
    right-most on pixel cannot fit, then it will not be drawn at
    all. This flag requires that EFI_HII_OUT_FLAG_CLIP be set. If
    EFI_HII_OUT_FLAG_CLIP_CLEAN_Y is set, then it modifies the
    behavior of EFI_HII_OUT_FLAG_CLIP so that if a row's bottom
    most pixel cannot fit, then it will not be drawn at all. This
    flag requires that EFI_HII_OUT_FLAG_CLIP be set. If
    EFI_HII_OUT_FLAG_WRAP is set, then text will be wrapped at the
    right-most line-break opportunity prior to a character whose
    right-most extent would exceed Width. If no line-break
    opportunity can be found, then the text will behave as if
    EFI_HII_OUT_FLAG_CLIP_CLEAN_X is set. This flag cannot be used
    with EFI_HII_OUT_FLAG_CLIP_CLEAN_X. If
    EFI_HII_OUT_FLAG_TRANSPARENT is set, then BackgroundColor is
    ignored and all off" pixels in the character's glyph will
    use the pixel value from Blt. This flag cannot be used if Blt
    is NULL upon entry. If EFI_HII_IGNORE_IF_NO_GLYPH is set, then
    characters which have no glyphs are not drawn. Otherwise, they
    are replaced with Unicode character code 0xFFFD (REPLACEMENT
    CHARACTER). If EFI_HII_IGNORE_LINE_BREAK is set, then explicit
    line break characters will be ignored. If
    EFI_HII_DIRECT_TO_SCREEN is set, then the string will be
    written directly to the output device specified by Screen.
    Otherwise the string will be rendered to the bitmap specified
    by Bitmap.

    @param This       A pointer to the EFI_HII_FONT_PROTOCOL instance.

    @param Flags      Describes how the string is to be drawn.

    @param PackageList
                      The package list in the HII database to
                      search for the specified string.

    @param StringId   The string's id, which is unique within
                      PackageList.

    @param Language   Points to the language for the retrieved
                      string. If NULL, then the current system
                      language is used.

    @param StringInfo Points to the string output information,
                      including the color and font. If NULL, then
                      the string will be output in the default
                      system font and color.

    @param Blt        If this points to a non-NULL on entry, this points
                      to the image, which is Width pixels wide and
                      Height pixels high. The string will be drawn onto
                      this image and EFI_HII_OUT_FLAG_CLIP is implied.
                      If this points to a NULL on entry, then a buffer
                      will be allocated to hold the generated image and
                      the pointer updated on exit. It is the caller's
                      responsibility to free this buffer.

    @param BltX, BltY Specifies the offset from the left and top
                      edge of the output image of the first
                      character cell in the image.

    @param RowInfoArray     If this is non-NULL on entry, then on
                            exit, this will point to an allocated
                            buffer containing row information and
                            RowInfoArraySize will be updated to
                            contain the number of elements. This array
                            describes the characters which were at
                            least partially drawn and the heights of
                            the rows. It is the caller's
                            responsibility to free this buffer.

    @param RowInfoArraySize If this is non-NULL on entry, then on
                            exit it contains the number of
                            elements in RowInfoArray.

    @param ColumnInfoArray  If non-NULL, on return it is filled
                            with the horizontal offset for each
                            character in the string on the row
                            where it is displayed. Non-printing
                            characters will have the offset ~0.
                            The caller is responsible to allocate
                            a buffer large enough so that there is
                            one entry for each character in the
                            string, not including the
                            null-terminator. It is possible when
                            character display is normalized that
                            some character cells overlap.

    @retval EFI_SUCCESS           The string was successfully updated.

    @retval EFI_OUT_OF_RESOURCES  Unable to allocate an output
                                  buffer for RowInfoArray or Blt.

    @retval EFI_INVALID_PARAMETER The String, or Blt, or Height, or
                                  Width was NULL.
    @retval EFI_INVALID_PARAMETER The Blt or PackageList was NULL.
    @retval EFI_INVALID_PARAMETER Flags were invalid combination.
    @retval EFI_NOT_FOUND         The specified PackageList is not in the Database,
                                  or the stringid is not in the specified PackageList.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_OUT_FLAGS, EFI_HII_HANDLE, EFI_STRING_ID, CONST, CONST, EFI_IMAGE_OUTPUT**, ulong, ulong, EFI_HII_ROW_INFO**, ulong*, ulong*, EFI_STATUS> StringIdToImage;
  /**

    Convert the glyph for a single character into a bitmap.

    @param This       A pointer to the EFI_HII_FONT_PROTOCOL instance.

    @param Char       The character to retrieve.

    @param StringInfo Points to the string font and color
                      information or NULL if the string should use
                      the default system font and color.

    @param Blt        This must point to a NULL on entry. A buffer will
                      be allocated to hold the output and the pointer
                      updated on exit. It is the caller's responsibility
                      to free this buffer.

    @param Baseline   The number of pixels from the bottom of the bitmap
                      to the baseline.

    @retval EFI_SUCCESS             The glyph bitmap created.

    @retval EFI_OUT_OF_RESOURCES    Unable to allocate the output buffer Blt.

    @retval EFI_WARN_UNKNOWN_GLYPH  The glyph was unknown and was
                                    replaced with the glyph for
                                    Unicode character code 0xFFFD.

    @retval EFI_INVALID_PARAMETER   Blt is NULL, or Width is NULL, or
                                    Height is NULL

  **/
  public readonly delegate* unmanaged<CONST, CONST, CONST, EFI_IMAGE_OUTPUT**, ulong*, EFI_STATUS> GetGlyph;
  /**

    This function iterates through fonts which match the specified
    font, using the specified criteria. If String is non-NULL, then
    all of the characters in the string must exist in order for a
    candidate font to be returned.

    @param This           A pointer to the EFI_HII_FONT_PROTOCOL instance.

    @param FontHandle     On entry, points to the font handle returned
                          by a previous call to GetFontInfo() or NULL
                          to start with the first font. On return,
                          points to the returned font handle or points
                          to NULL if there are no more matching fonts.

    @param StringInfoIn   Upon entry, points to the font to return
                          information about. If NULL, then the information
                          about the system default font will be returned.

    @param  StringInfoOut Upon return, contains the matching font's information.
                          If NULL, then no information is returned. This buffer
                          is allocated with a call to the Boot Service AllocatePool().
                          It is the caller's responsibility to call the Boot
                          Service FreePool() when the caller no longer requires
                          the contents of StringInfoOut.

    @param String         Points to the string which will be tested to
                          determine if all characters are available. If
                          NULL, then any font is acceptable.

    @retval EFI_SUCCESS            Matching font returned successfully.

    @retval EFI_NOT_FOUND          No matching font was found.

    @retval EFI_OUT_OF_RESOURCES   There were insufficient resources to complete the request.

  **/
  public readonly delegate* unmanaged<CONST, EFI_FONT_HANDLE*, CONST, EFI_FONT_DISPLAY_INFO**, CONST, EFI_STATUS> GetFontInfo;
}

// extern EFI_GUID  gEfiHiiFontProtocolGuid;

// #endif
