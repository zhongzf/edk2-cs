using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file defines BMP file header data structures.

Copyright (c) 2006 - 2011, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _BMP_H_
// #define _BMP_H_

// #pragma pack(1)

[StructLayout(LayoutKind.Sequential)]
public unsafe struct BMP_COLOR_MAP
{
  public byte Blue;
  public byte Green;
  public byte Red;
  public byte Reserved;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct BMP_IMAGE_HEADER
{
  public byte CharB;
  public byte CharM;
  public uint Size;
  public fixed ushort Reserved[2];
  public uint ImageOffset;
  public uint HeaderSize;
  public uint PixelWidth;
  public uint PixelHeight;
  public ushort Planes;              ///< Must be 1
  public ushort BitPerPixel;         ///< 1, 4, 8, or 24
  public uint CompressionType;
  public uint ImageSize;           ///< Compressed image size in bytes
  public uint XPixelsPerMeter;
  public uint YPixelsPerMeter;
  public uint NumberOfColors;
  public uint ImportantColors;
}

// #pragma pack()

// #endif
