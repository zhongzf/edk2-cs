using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  UGA Draw protocol from the EFI 1.10 specification.

  Abstraction of a very simple graphics device.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __UGA_DRAW_H__
// #define __UGA_DRAW_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_UGA_DRAW_PROTOCOL_GUID = new GUID(
      0x982c298b, 0xf4fa, 0x41cb, new byte[] { 0xb8, 0x38, 0x77, 0xaa, 0x68, 0x8f, 0xb8, 0x39 });

  // typedef struct _EFI_UGA_DRAW_PROTOCOL EFI_UGA_DRAW_PROTOCOL;

  // /**
  //   Return the current video mode information.
  // 
  //   @param  This                  The EFI_UGA_DRAW_PROTOCOL instance.
  //   @param  HorizontalResolution  The size of video screen in pixels in the X dimension.
  //   @param  VerticalResolution    The size of video screen in pixels in the Y dimension.
  //   @param  ColorDepth            Number of bits per pixel, currently defined to be 32.
  //   @param  RefreshRate           The refresh rate of the monitor in Hertz.
  // 
  //   @retval EFI_SUCCESS           Mode information returned.
  //   @retval EFI_NOT_STARTED       Video display is not initialized. Call SetMode ()
  //   @retval EFI_INVALID_PARAMETER One of the input args was NULL.
  // 
  // **/
  // typedef
  // EFI_STATUS
  // (EFIAPI *EFI_UGA_DRAW_PROTOCOL_GET_MODE)(
  //   IN  EFI_UGA_DRAW_PROTOCOL *This,
  //   OUT uint                *HorizontalResolution,
  //   OUT uint                *VerticalResolution,
  //   OUT uint                *ColorDepth,
  //   OUT uint                *RefreshRate
  //   );

  // /**
  //   Set the current video mode information.
  // 
  //   @param  This                 The EFI_UGA_DRAW_PROTOCOL instance.
  //   @param  HorizontalResolution The size of video screen in pixels in the X dimension.
  //   @param  VerticalResolution   The size of video screen in pixels in the Y dimension.
  //   @param  ColorDepth           Number of bits per pixel, currently defined to be 32.
  //   @param  RefreshRate          The refresh rate of the monitor in Hertz.
  // 
  //   @retval EFI_SUCCESS          Mode information returned.
  //   @retval EFI_NOT_STARTED      Video display is not initialized. Call SetMode ()
  // 
  // **/
  // typedef
  // EFI_STATUS
  // (EFIAPI *EFI_UGA_DRAW_PROTOCOL_SET_MODE)(
  //   IN  EFI_UGA_DRAW_PROTOCOL *This,
  //   IN  uint                HorizontalResolution,
  //   IN  uint                VerticalResolution,
  //   IN  uint                ColorDepth,
  //   IN  uint                RefreshRate
  //   );
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_UGA_PIXEL
{
  public byte Blue;
  public byte Green;
  public byte Red;
  public byte Reserved;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_UGA_PIXEL_UNION
{
  [FieldOffset(0)] public EFI_UGA_PIXEL Pixel;
  [FieldOffset(0)] public uint Raw;
}

///
/// Enumration value for actions of Blt operations.
///
public enum EFI_UGA_BLT_OPERATION
{
  EfiUgaVideoFill,          ///< Write data from the  BltBuffer pixel (SourceX, SourceY)
                            ///< directly to every pixel of the video display rectangle
                            ///< (DestinationX, DestinationY) (DestinationX + Width, DestinationY + Height).
                            ///< Only one pixel will be used from the BltBuffer. Delta is NOT used.

  EfiUgaVideoToBltBuffer,   ///< Read data from the video display rectangle
                            ///< (SourceX, SourceY) (SourceX + Width, SourceY + Height) and place it in
                            ///< the BltBuffer rectangle (DestinationX, DestinationY )
                            ///< (DestinationX + Width, DestinationY + Height). If DestinationX or
                            ///< DestinationY is not zero then Delta must be set to the length in bytes
                            ///< of a row in the BltBuffer.

  EfiUgaBltBufferToVideo,   ///< Write data from the  BltBuffer rectangle
                            ///< (SourceX, SourceY) (SourceX + Width, SourceY + Height) directly to the
                            ///< video display rectangle (DestinationX, DestinationY)
                            ///< (DestinationX + Width, DestinationY + Height). If SourceX or SourceY is
                            ///< not zero then Delta must be set to the length in bytes of a row in the
                            ///< BltBuffer.

  EfiUgaVideoToVideo,       ///< Copy from the video display rectangle (SourceX, SourceY)
                            ///< (SourceX + Width, SourceY + Height) .to the video display rectangle
                            ///< (DestinationX, DestinationY) (DestinationX + Width, DestinationY + Height).
                            ///< The BltBuffer and Delta  are not used in this mode.

  EfiUgaBltMax              ///< Maxmimum value for enumration value of Blt operation. If a Blt operation
                            ///< larger or equal to this enumration value, it is invalid.
}

// /**
//     Blt a rectangle of pixels on the graphics screen.
// 
//     @param[in] This          - Protocol instance pointer.
//     @param[in] BltBuffer     - Buffer containing data to blit into video buffer. This
//                                buffer has a size of Width*Height*sizeof(EFI_UGA_PIXEL)
//     @param[in] BltOperation  - Operation to perform on BlitBuffer and video memory
//     @param[in] SourceX       - X coordinate of source for the BltBuffer.
//     @param[in] SourceY       - Y coordinate of source for the BltBuffer.
//     @param[in] DestinationX  - X coordinate of destination for the BltBuffer.
//     @param[in] DestinationY  - Y coordinate of destination for the BltBuffer.
//     @param[in] Width         - Width of rectangle in BltBuffer in pixels.
//     @param[in] Height        - Hight of rectangle in BltBuffer in pixels.
//     @param[in] Delta         - OPTIONAL
// 
//     @retval EFI_SUCCESS           - The Blt operation completed.
//     @retval EFI_INVALID_PARAMETER - BltOperation is not valid.
//     @retval EFI_DEVICE_ERROR      - A hardware error occurred writting to the video buffer.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_UGA_DRAW_PROTOCOL_BLT)(
//   IN  EFI_UGA_DRAW_PROTOCOL                   *This,
//   IN  EFI_UGA_PIXEL                           *BltBuffer  OPTIONAL,
//   IN  EFI_UGA_BLT_OPERATION                   BltOperation,
//   IN  ulong                                   SourceX,
//   IN  ulong                                   SourceY,
//   IN  ulong                                   DestinationX,
//   IN  ulong                                   DestinationY,
//   IN  ulong                                   Width,
//   IN  ulong                                   Height,
//   IN  ulong                                   Delta         OPTIONAL
//   );

///
/// This protocol provides a basic abstraction to set video modes and
/// copy pixels to and from the graphics controller's frame buffer.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_UGA_DRAW_PROTOCOL
{
  public readonly delegate* unmanaged</* IN */EFI_UGA_DRAW_PROTOCOL* /*This*/,/* OUT */uint* /*HorizontalResolution*/,/* OUT */uint* /*VerticalResolution*/,/* OUT */uint* /*ColorDepth*/,/* OUT */uint* /*RefreshRate*/, EFI_STATUS> /*EFI_UGA_DRAW_PROTOCOL_GET_MODE*/ GetMode;
  public readonly delegate* unmanaged</* IN */EFI_UGA_DRAW_PROTOCOL* /*This*/,/* IN */uint /*HorizontalResolution*/,/* IN */uint /*VerticalResolution*/,/* IN */uint /*ColorDepth*/,/* IN */uint /*RefreshRate*/, EFI_STATUS> /*EFI_UGA_DRAW_PROTOCOL_SET_MODE*/ SetMode;
  public readonly delegate* unmanaged</* IN */EFI_UGA_DRAW_PROTOCOL* /*This*/,/* IN */EFI_UGA_PIXEL* /*BltBuffer*/,/* IN */EFI_UGA_BLT_OPERATION /*BltOperation*/,/* IN */ulong /*SourceX*/,/* IN */ulong /*SourceY*/,/* IN */ulong /*DestinationX*/,/* IN */ulong /*DestinationY*/,/* IN */ulong /*Width*/,/* IN */ulong /*Height*/,/* IN */ulong /*Delta*/, EFI_STATUS> /*EFI_UGA_DRAW_PROTOCOL_BLT*/ Blt;
}

// extern EFI_GUID  gEfiUgaDrawProtocolGuid;

// #endif
