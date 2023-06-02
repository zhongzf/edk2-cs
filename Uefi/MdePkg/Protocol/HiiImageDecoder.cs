using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This protocol provides generic image decoder interfaces to various image formats.

(C) Copyright 2016 Hewlett Packard Enterprise Development LP<BR>
  Copyright (c) 2016-2018, Intel Corporation. All rights reserved.<BR>

SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in UEFI Specification 2.6.

**/

// #ifndef __HII_IMAGE_DECODER_H__
// #define __HII_IMAGE_DECODER_H__

// #include <Protocol/HiiImage.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_HII_IMAGE_DECODER_PROTOCOL_GUID = new GUID(0x9e66f251, 0x727c, 0x418c, new byte[] { 0xbf, 0xd6, 0xc2, 0xb4, 0x25, 0x28, 0x18, 0xea });

  public static EFI_GUID EFI_HII_IMAGE_DECODER_NAME_JPEG_GUID = new GUID(0xefefd093, 0xd9b, 0x46eb, new byte[] { 0xa8, 0x56, 0x48, 0x35, 0x7, 0x0, 0xc9, 0x8 });

  public static EFI_GUID EFI_HII_IMAGE_DECODER_NAME_PNG_GUID = new GUID(0xaf060190, 0x5e3a, 0x4025, new byte[] { 0xaf, 0xbd, 0xe1, 0xf9, 0x5, 0xbf, 0xaa, 0x4c });

  // typedef struct _EFI_HII_IMAGE_DECODER_PROTOCOL EFI_HII_IMAGE_DECODER_PROTOCOL;
}

public enum EFI_HII_IMAGE_DECODER_COLOR_TYPE
{
  EFI_HII_IMAGE_DECODER_COLOR_TYPE_RGB = 0x0,
  EFI_HII_IMAGE_DECODER_COLOR_TYPE_RGBA = 0x1,
  EFI_HII_IMAGE_DECODER_COLOR_TYPE_CMYK = 0x2,
  EFI_HII_IMAGE_DECODER_COLOR_TYPE_UNKNOWN = 0xFF
}

//
// EFI_HII_IMAGE_DECODER_IMAGE_INFO_HEADER
//
// DecoderName        Name of the decoder
// ImageInfoSize      The size of entire image information structure in bytes
// ImageWidth         The image width
// ImageHeight        The image height
// ColorType          The color type, see EFI_HII_IMAGE_DECODER_COLOR_TYPE.
// ColorDepthInBits   The color depth in bits
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IMAGE_DECODER_IMAGE_INFO_HEADER
{
  public EFI_GUID DecoderName;
  public ushort ImageInfoSize;
  public ushort ImageWidth;
  public ushort ImageHeight;
  public EFI_HII_IMAGE_DECODER_COLOR_TYPE ColorType;
  public byte ColorDepthInBits;
}

public unsafe partial class EFI
{
  public const ulong EFI_IMAGE_JPEG_SCANTYPE_PROGREESSIVE = 0x01;
  public const ulong EFI_IMAGE_JPEG_SCANTYPE_INTERLACED = 0x02;
}

//
// EFI_HII_IMAGE_DECODER_JPEG_INFO
// Header         The common header
// ScanType       The scan type of JPEG image
// Reserved       Reserved
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IMAGE_DECODER_JPEG_INFO
{
  public EFI_HII_IMAGE_DECODER_IMAGE_INFO_HEADER Header;
  public ushort ScanType;
  public ulong Reserved;
}

//
// EFI_HII_IMAGE_DECODER_PNG_INFO
// Header         The common header
// Channels       Number of channels in the PNG image
// Reserved       Reserved
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IMAGE_DECODER_PNG_INFO
{
  public EFI_HII_IMAGE_DECODER_IMAGE_INFO_HEADER Header;
  public ushort Channels;
  public ulong Reserved;
}

//
// EFI_HII_IMAGE_DECODER_OTHER_INFO
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IMAGE_DECODER_OTHER_INFO
{
  public EFI_HII_IMAGE_DECODER_IMAGE_INFO_HEADER Header;
  public fixed char ImageExtenion[1];
  //
  // Variable length of image file extension name.
  //
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IMAGE_DECODER_PROTOCOL
{
  /**
    There could be more than one EFI_HII_IMAGE_DECODER_PROTOCOL instances installed
    in the system for different image formats. This function returns the decoder
    name which callers can use to find the proper image decoder for the image. It
    is possible to support multiple image formats in one EFI_HII_IMAGE_DECODER_PROTOCOL.
    The capability of the supported image formats is returned in DecoderName and
    NumberOfDecoderName.

    @param This                    EFI_HII_IMAGE_DECODER_PROTOCOL instance.
    @param DecoderName             Pointer to a dimension to retrieve the decoder
                                   names in EFI_GUID format. The number of the
                                   decoder names is returned in NumberOfDecoderName.
    @param NumberofDecoderName     Pointer to retrieve the number of decoders which
                                   supported by this decoder driver.

    @retval EFI_SUCCESS            Get decoder name success.
    @retval EFI_UNSUPPORTED        Get decoder name fail.

  **/
  public readonly delegate* unmanaged<EFI_HII_IMAGE_DECODER_PROTOCOL*, EFI_GUID**, ushort*, EFI_STATUS> GetImageDecoderName;
  /**
    This function returns the image information of the given image raw data. This
    function first checks whether the image raw data is supported by this decoder
    or not. This function may go through the first few bytes in the image raw data
    for the specific data structure or the image signature. If the image is not supported
    by this image decoder, this function returns EFI_UNSUPPORTED to the caller.
    Otherwise, this function returns the proper image information to the caller.
    It is the caller?s responsibility to free the ImageInfo.

    @param This                    EFI_HII_IMAGE_DECODER_PROTOCOL instance.
    @param Image                   Pointer to the image raw data.
    @param SizeOfImage             Size of the entire image raw data.
    @param ImageInfo               Pointer to receive EFI_HII_IMAGE_DECODER_IMAGE_INFO_HEADER.

    @retval EFI_SUCCESS            Get image info success.
    @retval EFI_UNSUPPORTED        Unsupported format of image.
    @retval EFI_INVALID_PARAMETER  Incorrect parameter.
    @retval EFI_BAD_BUFFER_SIZE    Not enough memory.

  **/
  public readonly delegate* unmanaged<EFI_HII_IMAGE_DECODER_PROTOCOL*, void*, ulong, EFI_HII_IMAGE_DECODER_IMAGE_INFO_HEADER**, EFI_STATUS> GetImageInfo;
  /**
    This function decodes the image which the image type of this image is supported
    by this EFI_HII_IMAGE_DECODER_PROTOCOL. If **Bitmap is not NULL, the caller intends
    to put the image in the given image buffer. That allows the caller to put an
    image overlap on the original image. The transparency is handled by the image
    decoder because the transparency capability depends on the image format. Callers
    can set Transparent to FALSE to force disabling the transparency process on the
    image. Forcing Transparent to FALSE may also improve the performance of the image
    decoding because the image decoder can skip the transparency processing.  If **Bitmap
    is NULL, the image decoder allocates the memory buffer for the EFI_IMAGE_OUTPUT
    and decodes the image to the image buffer. It is the caller?s responsibility to
    free the memory for EFI_IMAGE_OUTPUT. Image decoder doesn?t have to handle the
    transparency in this case because there is no background image given by the caller.
    The background color in this case is all black (#00000000).

    @param This                    EFI_HII_IMAGE_DECODER_PROTOCOL instance.
    @param Image                   Pointer to the image raw data.
    @param ImageRawDataSize        Size of the entire image raw data.
    @param Blt                     EFI_IMAGE_OUTPUT to receive the image or overlap
                                   the image on the original buffer.
    @param Transparent             bool value indicates whether the image decoder
                                   has to handle the transparent image or not.

    @retval EFI_SUCCESS            Image decode success.
    @retval EFI_UNSUPPORTED        Unsupported format of image.
    @retval EFI_INVALID_PARAMETER  Incorrect parameter.
    @retval EFI_BAD_BUFFER_SIZE    Not enough memory.

  **/
  public readonly delegate* unmanaged<EFI_HII_IMAGE_DECODER_PROTOCOL*, void*, ulong, EFI_IMAGE_OUTPUT**, bool, EFI_STATUS> DecodeImage;
}

// extern EFI_GUID  gEfiHiiImageDecoderProtocolGuid;
// extern EFI_GUID  gEfiHiiImageDecoderNameJpegGuid;
// extern EFI_GUID  gEfiHiiImageDecoderNamePngGuid;

// #endif
