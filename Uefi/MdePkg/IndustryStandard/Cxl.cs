namespace Uefi;
/** @file
  Support for the latest CXL standard

  The main header to reference all versions of CXL Base specification registers
  from the MDE

Copyright (c) 2020, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _CXL_MAIN_H_
// #define _CXL_MAIN_H_

// #include <IndustryStandard/Cxl11.h>
//
// CXL assigned new Vendor ID
//
public unsafe partial class EFI
{
  public const ulong CXL_DVSEC_VENDOR_ID = 0x1E98;
}

// #endif
