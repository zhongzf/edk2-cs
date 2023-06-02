using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI MM Access Protocol as defined in the PI 1.5 specification.

  This protocol is used to control the visibility of the MMRAM on the platform.
  It abstracts the location and characteristics of MMRAM.  The expectation is
  that the north bridge or memory controller would publish this protocol.

  The principal functionality found in the memory controller includes the following:
  - Exposing the MMRAM to all non-MM agents, or the "open" state
  - Shrouding the MMRAM to all but the MM agents, or the "closed" state
  - Preserving the system integrity, or "locking" the MMRAM, such that the settings cannot be
    perturbed by either boot service or runtime agents

  Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _MM_ACCESS_H_
// #define _MM_ACCESS_H_

public unsafe partial class EFI
{
  public static EFI_GUID EFI_MM_ACCESS_PROTOCOL_GUID = new GUID(
       0xc2702b74, 0x800c, 0x4131, new byte[] { 0x87, 0x46, 0x8f, 0xb5, 0xb8, 0x9c, 0xe4, 0xac });

  // typedef struct _EFI_MM_ACCESS_PROTOCOL EFI_MM_ACCESS_PROTOCOL;

}

///
///  EFI MM Access Protocol is used to control the visibility of the MMRAM on the platform.
///  It abstracts the location and characteristics of MMRAM. The platform should report all
///  MMRAM via EFI_MM_ACCESS_PROTOCOL. The expectation is that the north bridge or memory
///  controller would publish this protocol.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MM_ACCESS_PROTOCOL
{
  /**
    Opens the MMRAM area to be accessible by a boot-service driver.

    This function "opens" MMRAM so that it is visible while not inside of MM. The function should
    return EFI_UNSUPPORTED if the hardware does not support hiding of MMRAM. The function
    should return EFI_DEVICE_ERROR if the MMRAM configuration is locked.

    @param[in] This           The EFI_MM_ACCESS_PROTOCOL instance.

    @retval EFI_SUCCESS       The operation was successful.
    @retval EFI_UNSUPPORTED   The system does not support opening and closing of MMRAM.
    @retval EFI_DEVICE_ERROR  MMRAM cannot be opened, perhaps because it is locked.
  **/
  public readonly delegate* unmanaged<EFI_MM_ACCESS_PROTOCOL*, EFI_STATUS> Open;
  /**
    Inhibits access to the MMRAM.

    This function "closes" MMRAM so that it is not visible while outside of MM. The function should
    return EFI_UNSUPPORTED if the hardware does not support hiding of MMRAM.

    @param[in] This           The EFI_MM_ACCESS_PROTOCOL instance.

    @retval EFI_SUCCESS       The operation was successful.
    @retval EFI_UNSUPPORTED   The system does not support opening and closing of MMRAM.
    @retval EFI_DEVICE_ERROR  MMRAM cannot be closed.
  **/
  public readonly delegate* unmanaged<EFI_MM_ACCESS_PROTOCOL*, EFI_STATUS> Close;
  /**
    Inhibits access to the MMRAM.

    This function prohibits access to the MMRAM region.  This function is usually implemented such
    that it is a write-once operation.

    @param[in] This          The EFI_MM_ACCESS_PROTOCOL instance.

    @retval EFI_SUCCESS      The device was successfully locked.
    @retval EFI_UNSUPPORTED  The system does not support locking of MMRAM.
  **/
  public readonly delegate* unmanaged<EFI_MM_ACCESS_PROTOCOL*, EFI_STATUS> Lock;
  /**
    Queries the memory controller for the possible regions that will support MMRAM.

    @param[in]     This           The EFI_MM_ACCESS_PROTOCOL instance.
    @param[in,out] MmramMapSize   A pointer to the size, in bytes, of the MmramMemoryMap buffer.
    @param[in,out] MmramMap       A pointer to the buffer in which firmware places the current memory map.

    @retval EFI_SUCCESS           The chipset supported the given resource.
    @retval EFI_BUFFER_TOO_SMALL  The MmramMap parameter was too small.  The current buffer size
                                  needed to hold the memory map is returned in MmramMapSize.
  **/
  public readonly delegate* unmanaged<CONST, ulong*, EFI_MMRAM_DESCRIPTOR*, EFI_STATUS> GetCapabilities;
  ///
  /// Indicates the current state of the MMRAM. Set to TRUE if MMRAM is locked.
  ///
  public bool LockState;
  ///
  /// Indicates the current state of the MMRAM. Set to TRUE if MMRAM is open.
  ///
  public bool OpenState;
}

// extern EFI_GUID  gEfiMmAccessProtocolGuid;

// #endif
