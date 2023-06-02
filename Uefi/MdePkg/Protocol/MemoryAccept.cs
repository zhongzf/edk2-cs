using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  The file provides the protocol to provide interface to accept memory.

  Copyright (c) 2021 - 2022, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef MEMORY_ACCEPT_H_
// #define MEMORY_ACCEPT_H_

public unsafe partial class EFI
{
  public static EFI_GUID EDKII_MEMORY_ACCEPT_PROTOCOL_GUID = new GUID(0x38c74800, 0x5590, 0x4db4, new byte[] { 0xa0, 0xf3, 0x67, 0x5d, 0x9b, 0x8e, 0x80, 0x26 });;

// typedef struct _EDKII_MEMORY_ACCEPT_PROTOCOL EDKII_MEMORY_ACCEPT_PROTOCOL;

}

///
/// The EDKII_MEMORY_ACCEPT_PROTOCOL provides the ability for memory services
/// to accept memory.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EDKII_MEMORY_ACCEPT_PROTOCOL
{
  /**
    @param This                   A pointer to a EDKII_MEMORY_ACCEPT_PROTOCOL.
  **/
  public readonly delegate* unmanaged<EDKII_MEMORY_ACCEPT_PROTOCOL*, EFI_PHYSICAL_ADDRESS, ulong, EFI_STATUS> AcceptMemory;
}

// extern EFI_GUID  gEdkiiMemoryAcceptProtocolGuid;

// #endif
