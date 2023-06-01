namespace Uefi;
/** @file
  This file defines the Legacy SPI Flash Protocol.

  Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
    This Protocol was introduced in UEFI PI Specification 1.6.

**/

// #ifndef __LEGACY_SPI_FLASH_PROTOCOL_H__
// #define __LEGACY_SPI_FLASH_PROTOCOL_H__

// #include <Protocol/SpiNorFlash.h>

///
/// Global ID for the Legacy SPI Flash Protocol
///
public static EFI_GUID EFI_LEGACY_SPI_FLASH_PROTOCOL_GUID = new GUID(0xf01bed57, 0x04bc, 0x4f3f,
    { 0x96, 0x60, 0xd6, 0xf2, 0xea, 0x22, 0x82, 0x59 });

// typedef struct _EFI_LEGACY_SPI_FLASH_PROTOCOL EFI_LEGACY_SPI_FLASH_PROTOCOL;































































































































///
/// The EFI_LEGACY_SPI_FLASH_PROTOCOL extends the EFI_SPI_NOR_FLASH_PROTOCOL
/// with APls to support the legacy SPI flash controller.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LEGACY_SPI_FLASH_PROTOCOL
{
  ///
  /// This protocol manipulates the SPI NOR flash parts using a common set of
  /// commands.
  ///
  public EFI_SPI_NOR_FLASH_PROTOCOL FlashProtocol;

  //
  // Legacy flash (SPI host) controller support
  //

  ///
  /// Set the BIOS base address.
  ///
  /**
    Set the BIOS base address.

    This routine must be called at or below TPL_NOTIFY.
    The BIOS base address works with the protect range registers to protect
    portions of the SPI NOR flash from erase and write operat ions.
    The BIOS calls this API prior to passing control to the OS loader.

    @param[in] This             Pointer to an EFI_LEGACY_SPI_FLASH_PROTOCOL data
                                structure.
    @param[in] BiosBaseAddress  The BIOS base address.

    @retval EFI_SUCCESS            The BIOS base address was properly set
    @retval EFI_ACCESS_ERROR       The SPI controller is locked
    @retval EFI_INVALID_PARAMETER  BiosBaseAddress > This->MaximumOffset
    @retval EFI_UNSUPPORTED        The BIOS base address was already set or not a
                                   legacy SPI host controller

  **/
  public readonly delegate* unmanaged<CONST, uint, EFI_STATUS> BiosBaseAddress;

  ///
  /// Clear the SPI protect range registers.
  ///
  /**
    Clear the SPI protect range registers.

    This routine must be called at or below TPL_NOTIFY.
    The BIOS uses this routine to set an initial condition on the SPI protect
    range registers.

    @param[in] This  Pointer to an EFI_LEGACY_SPI_FLASH_PROTOCOL data structure.

    @retval EFI_SUCCESS       The registers were successfully cleared
    @retval EFI_ACCESS_ERROR  The SPI controller is locked
    @retval EFI_UNSUPPORTED   Not a legacy SPI host controller

  **/
  public readonly delegate* unmanaged<, EFI_STATUS> ClearSpiProtect;

  ///
  /// Determine if the SPI range is protected.
  ///
  /**
    Determine if the SPI range is protected.

    This routine must be called at or below TPL_NOTIFY.
    The BIOS uses this routine to verify a range in the SPI is protected.

    @param[in] This             Pointer to an EFI_LEGACY_SPI_FLASH_PROTOCOL data
                                structure.
    @param[in] BiosAddress      Address within a 4 KiB block to start protecting.
    @param[in] BlocksToProtect  The number of 4 KiB blocks to protect.

    @retval TRUE   The range is protected
    @retval FALSE  The range is not protected

  **/
  public readonly delegate* unmanaged<CONST, uint, uint, EFI_STATUS> IsRangeProtected;

  ///
  /// Set the next protect range register.
  ///
  /**
    Set the next protect range register.

    This routine must be called at or below TPL_NOTIFY.
    The BIOS sets the protect range register to prevent write and erase
    operations to a portion of the SPI NOR flash device.

    @param[in] This             Pointer to an EFI_LEGACY_SPI_FLASH_PROTOCOL data
                                structure.
    @param[in] BiosAddress      Address within a 4 KiB block to start protecting.
    @param[in] BlocksToProtect  The number of 4 KiB blocks to protect.

    @retval EFI_SUCCESS            The register was successfully updated
    @retval EFI_ACCESS_ERROR       The SPI controller is locked
    @retval EFI_INVALID_PARAMETER  BiosAddress < This->BiosBaseAddress, or
    @retval EFI_INVALID_PARAMETER  BlocksToProtect * 4 KiB
                                     > This->MaximumRangeBytes, or
                                   BiosAddress - This->BiosBaseAddress
                                     + (BlocksToProtect * 4 KiB)
                                       > This->MaximumRangeBytes
    @retval EFI_OUT_OF_RESOURCES   No protect range register available
    @retval EFI_UNSUPPORTED        Call This->SetBaseAddress because the BIOS
                                   base address is not set Not a legacy SPI host
                                   controller

  **/
  public readonly delegate* unmanaged<CONST, uint, uint, EFI_STATUS> ProtectNextRange;

  ///
  /// Lock the SPI controller configuration.
  ///
  /**
    Lock the SPI controller configuration.

    This routine must be called at or below TPL_NOTIFY.
    This routine locks the SPI controller's configuration so that the software is
    no longer able to update:
    * Prefix table
    * Opcode menu
    * Opcode type table
    * BIOS base address
    * Protect range registers

    @param[in] This  Pointer to an EFI_LEGACY_SPI_FLASH_PROTOCOL data structure.

    @retval EFI_SUCCESS          The SPI controller was successfully locked
    @retval EFI_ALREADY_STARTED  The SPI controller was already locked
    @retval EFI_UNSUPPORTED      Not a legacy SPI host controller
  **/
  public readonly delegate* unmanaged<CONST, EFI_STATUS> LockController;
}

// extern EFI_GUID  gEfiLegacySpiFlashProtocolGuid;

// #endif // __LEGACY_SPI_FLASH_PROTOCOL_H__
