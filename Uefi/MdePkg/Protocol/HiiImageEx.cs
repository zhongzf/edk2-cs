using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Protocol which allows access to the images in the images database.

(C) Copyright 2016-2018 Hewlett Packard Enterprise Development LP<BR>

SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in UEFI Specification 2.6.

**/

// #ifndef __EFI_HII_IMAGE_EX_H__
// #define __EFI_HII_IMAGE_EX_H__

// #include <Protocol/HiiImage.h>

public unsafe partial class EFI
{
  //
  // Global ID for the Hii Image Ex Protocol.
  //
  public static EFI_GUID EFI_HII_IMAGE_EX_PROTOCOL_GUID = new GUID(0x1a1241e6, 0x8f19, 0x41a9, new byte[] { 0xbc, 0xe, 0xe8, 0xef, 0x39, 0xe0, 0x65, 0x46 });

  // typedef struct _EFI_HII_IMAGE_EX_PROTOCOL EFI_HII_IMAGE_EX_PROTOCOL;

}

///
/// Protocol which allows access to the images in the images database.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_IMAGE_EX_PROTOCOL
{
  /**
    The prototype of this extension function is the same with EFI_HII_IMAGE_PROTOCOL.NewImage().
    This protocol invokes EFI_HII_IMAGE_PROTOCOL.NewImage() implicitly.

    @param  This                   A pointer to the EFI_HII_IMAGE_EX_PROTOCOL instance.
    @param  PackageList            Handle of the package list where this image will
                                   be added.
    @param  ImageId                On return, contains the new image id, which is
                                   unique within PackageList.
    @param  Image                  Points to the image.

    @retval EFI_SUCCESS            The new image was added successfully.
    @retval EFI_NOT_FOUND          The specified PackageList could not be found in
                                   database.
    @retval EFI_OUT_OF_RESOURCES   Could not add the image due to lack of resources.
    @retval EFI_INVALID_PARAMETER  Image is NULL or ImageId is NULL.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_HANDLE, EFI_IMAGE_ID*, CONST, EFI_STATUS> NewImageEx;
  /**
    Return the information about the image, associated with the package list.
    The prototype of this extension function is the same with EFI_HII_IMAGE_PROTOCOL.GetImage().

    This function is similar to EFI_HII_IMAGE_PROTOCOL.GetImage().The difference is that
    this function will locate all EFI_HII_IMAGE_DECODER_PROTOCOL instances installed in the
    system if the decoder of the certain image type is not supported by the
    EFI_HII_IMAGE_EX_PROTOCOL. The function will attempt to decode the image to the
    EFI_IMAGE_INPUT using the first EFI_HII_IMAGE_DECODER_PROTOCOL instance that
    supports the requested image type.

    @param  This                   A pointer to the EFI_HII_IMAGE_EX_PROTOCOL instance.
    @param  PackageList            The package list in the HII database to search for the
                                   specified image.
    @param  ImageId                The image's id, which is unique within PackageList.
    @param  Image                  Points to the image.

    @retval EFI_SUCCESS            The new image was returned successfully.
    @retval EFI_NOT_FOUND          The image specified by ImageId is not available. The specified
                                   PackageList is not in the Database.
    @retval EFI_INVALID_PARAMETER  Image was NULL or ImageId was 0.
    @retval EFI_OUT_OF_RESOURCES   The bitmap could not be retrieved because there
                                   was not enough memory.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_HANDLE, EFI_IMAGE_ID, EFI_IMAGE_INPUT*, EFI_STATUS> GetImageEx;
  /**
    Change the information about the image.

    Same with EFI_HII_IMAGE_PROTOCOL.SetImage(),this protocol invokes
    EFI_HII_IMAGE_PROTOCOL.SetImage()implicitly.

    @param  This                   A pointer to the EFI_HII_IMAGE_EX_PROTOCOL instance.
    @param  PackageList            The package list containing the images.
    @param  ImageId                The image's id, which is unique within PackageList.
    @param  Image                  Points to the image.

    @retval EFI_SUCCESS            The new image was successfully updated.
    @retval EFI_NOT_FOUND          The image specified by ImageId is not in the
                                   database. The specified PackageList is not in
                                   the database.
    @retval EFI_INVALID_PARAMETER  The Image was NULL, the ImageId was 0 or
                                   the Image->Bitmap was NULL.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_HANDLE, EFI_IMAGE_ID, CONST, EFI_STATUS> SetImageEx;
  /**
    Renders an image to a bitmap or to the display.

    The prototype of this extension function is the same with
    EFI_HII_IMAGE_PROTOCOL.DrawImage(). This protocol invokes
    EFI_HII_IMAGE_PROTOCOL.DrawImage() implicitly.

    @param  This                   A pointer to the EFI_HII_IMAGE_EX_PROTOCOL instance.
    @param  Flags                  Describes how the image is to be drawn.
    @param  Image                  Points to the image to be displayed.
    @param  Blt                    If this points to a non-NULL on entry, this points
                                   to the image, which is Width pixels wide and
                                   Height pixels high.  The image will be drawn onto
                                   this image and  EFI_HII_DRAW_FLAG_CLIP is implied.
                                   If this points to a NULL on entry, then a buffer
                                   will be allocated to hold the generated image and
                                   the pointer updated on exit. It is the caller's
                                   responsibility to free this buffer.
    @param  BltX                   Specifies the offset from the left and top edge of
                                   the output image of the first pixel in the image.
    @param  BltY                   Specifies the offset from the left and top edge of
                                   the output image of the first pixel in the image.

    @retval EFI_SUCCESS            The image was successfully drawn.
    @retval EFI_OUT_OF_RESOURCES   Unable to allocate an output buffer for Blt.
    @retval EFI_INVALID_PARAMETER  The Image or Blt was NULL.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_DRAW_FLAGS, CONST, EFI_IMAGE_OUTPUT**, ulong, ulong, EFI_STATUS> DrawImageEx;
  /**
    Renders an image to a bitmap or the screen containing the contents of the specified
    image.

    This function is similar to EFI_HII_IMAGE_PROTOCOL.DrawImageId(). The difference is that
    this function will locate all EFI_HII_IMAGE_DECODER_PROTOCOL instances installed in the
    system if the decoder of the certain image type is not supported by the
    EFI_HII_IMAGE_EX_PROTOCOL. The function will attempt to decode the image to the
    EFI_IMAGE_INPUT using the first EFI_HII_IMAGE_DECODER_PROTOCOL instance that
    supports the requested image type.

    @param  This                   A pointer to the EFI_HII_IMAGE_EX_PROTOCOL instance.
    @param  Flags                  Describes how the image is to be drawn.
    @param  PackageList            The package list in the HII database to search for
                                   the  specified image.
    @param  ImageId                The image's id, which is unique within PackageList.
    @param  Blt                    If this points to a non-NULL on entry, this points
                                   to the image, which is Width pixels wide and
                                   Height pixels high. The image will be drawn onto
                                   this image and EFI_HII_DRAW_FLAG_CLIP is implied.
                                   If this points to a NULL on entry, then a buffer
                                   will be allocated to hold  the generated image
                                   and the pointer updated on exit. It is the caller's
                                   responsibility to free this buffer.
    @param  BltX                   Specifies the offset from the left and top edge of
                                   the output image of the first pixel in the image.
    @param  BltY                   Specifies the offset from the left and top edge of
                                   the output image of the first pixel in the image.

    @retval EFI_SUCCESS            The image was successfully drawn.
    @retval EFI_OUT_OF_RESOURCES   Unable to allocate an output buffer for Blt.
    @retval EFI_INVALID_PARAMETER  The Blt was NULL or ImageId was 0.
    @retval EFI_NOT_FOUND          The image specified by ImageId is not in the database.
                                   The specified PackageList is not in the database.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_DRAW_FLAGS, EFI_HII_HANDLE, EFI_IMAGE_ID, EFI_IMAGE_OUTPUT**, ulong, ulong, EFI_STATUS> DrawImageIdEx;
  /**
    This function returns the image information to EFI_IMAGE_OUTPUT. Only the width
    and height are returned to the EFI_IMAGE_OUTPUT instead of decoding the image
    to the buffer. This function is used to get the geometry of the image. This function
    will try to locate all of the EFI_HII_IMAGE_DECODER_PROTOCOL installed on the
    system if the decoder of image type is not supported by the EFI_HII_IMAGE_EX_PROTOCOL.

    @param  This                   A pointer to the EFI_HII_IMAGE_EX_PROTOCOL instance.
    @param  PackageList            Handle of the package list where this image will
                                   be searched.
    @param  ImageId                The image's id, which is unique within PackageList.
    @param  Image                  Points to the image.

    @retval EFI_SUCCESS            The new image was returned successfully.
    @retval EFI_NOT_FOUND          The image specified by ImageId is not in the
                                   database. The specified PackageList is not in the database.
    @retval EFI_BUFFER_TOO_SMALL   The buffer specified by ImageSize is too small to
                                   hold the image.
    @retval EFI_INVALID_PARAMETER  The Image was NULL or the ImageId was 0.
    @retval EFI_OUT_OF_RESOURCES   The bitmap could not be retrieved because there
                                   was not enough memory.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_HANDLE, EFI_IMAGE_ID, EFI_IMAGE_OUTPUT*, EFI_STATUS> GetImageInfo;
}

// extern EFI_GUID  gEfiHiiImageExProtocolGuid;

// #endif
