using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Platform Driver Override protocol as defined in the UEFI 2.1 specification.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __EFI_PLATFORM_DRIVER_OVERRIDE_PROTOCOL_H__
// #define __EFI_PLATFORM_DRIVER_OVERRIDE_PROTOCOL_H__

///
/// Global ID for the Platform Driver Override Protocol
///
public unsafe partial class EFI
{
  public static EFI_GUID EFI_PLATFORM_DRIVER_OVERRIDE_PROTOCOL_GUID = new GUID(
      0x6b30c738, 0xa391, 0x11d4, new byte[] { 0x9a, 0x3b, 0x00, 0x90, 0x27, 0x3f, 0xc1, 0x4d });

  // typedef struct _EFI_PLATFORM_DRIVER_OVERRIDE_PROTOCOL EFI_PLATFORM_DRIVER_OVERRIDE_PROTOCOL;

  //
  // Prototypes for the Platform Driver Override Protocol
  //

}

///
/// This protocol matches one or more drivers to a controller. A platform driver
/// produces this protocol, and it is installed on a separate handle. This protocol
/// is used by the ConnectController() boot service to select the best driver
/// for a controller. All of the drivers returned by this protocol have a higher
/// precedence than drivers found from an EFI Bus Specific Driver Override Protocol
/// or drivers found from the general UEFI driver Binding search algorithm. If more
/// than one driver is returned by this protocol, then the drivers are returned in
/// order from highest precedence to lowest precedence.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PLATFORM_DRIVER_OVERRIDE_PROTOCOL
{
  /**
    Retrieves the image handle of the platform override driver for a controller in the system.

    @param  This                  A pointer to the EFI_PLATFORM_DRIVER_OVERRIDE_
                                  PROTOCOL instance.
    @param  ControllerHandle      The device handle of the controller to check if a driver override
                                  exists.
    @param  DriverImageHandle     On input, a pointer to the previous driver image handle returned
                                  by GetDriver(). On output, a pointer to the next driver
                                  image handle.

    @retval EFI_SUCCESS           The driver override for ControllerHandle was returned in
                                  DriverImageHandle.
    @retval EFI_NOT_FOUND         A driver override for ControllerHandle was not found.
    @retval EFI_INVALID_PARAMETER The handle specified by ControllerHandle is NULL.
    @retval EFI_INVALID_PARAMETER DriverImageHandle is not a handle that was returned on a
                                  previous call to GetDriver().

  **/
  public readonly delegate* unmanaged<EFI_PLATFORM_DRIVER_OVERRIDE_PROTOCOL*, EFI_HANDLE, EFI_HANDLE*, EFI_STATUS> GetDriver;
  /**
    Retrieves the device path of the platform override driver for a controller in the system.

    @param  This                  A pointer to the EFI_PLATFORM_DRIVER_OVERRIDE_PROTOCOL instance.
    @param  ControllerHandle      The device handle of the controller to check if a driver override
                                  exists.
    @param  DriverImagePath       On input, a pointer to the previous driver device path returned by
                                  GetDriverPath(). On output, a pointer to the next driver
                                  device path. Passing in a pointer to NULL will return the first
                                  driver device path for ControllerHandle.

    @retval EFI_SUCCESS           The driver override for ControllerHandle was returned in
                                  DriverImageHandle.
    @retval EFI_UNSUPPORTED       The operation is not supported.
    @retval EFI_NOT_FOUND         A driver override for ControllerHandle was not found.
    @retval EFI_INVALID_PARAMETER The handle specified by ControllerHandle is NULL.
    @retval EFI_INVALID_PARAMETER DriverImagePath is not a device path that was returned on a
                                  previous call to GetDriverPath().

  **/
  public readonly delegate* unmanaged<EFI_PLATFORM_DRIVER_OVERRIDE_PROTOCOL*, EFI_HANDLE, EFI_DEVICE_PATH_PROTOCOL**, EFI_STATUS> GetDriverPath;
  /**
    Used to associate a driver image handle with a device path that was returned on a prior call to the
    GetDriverPath() service. This driver image handle will then be available through the
    GetDriver() service.

    @param  This                  A pointer to the EFI_PLATFORM_DRIVER_OVERRIDE_
                                  PROTOCOL instance.
    @param  ControllerHandle      The device handle of the controller.
    @param  DriverImagePath       A pointer to the driver device path that was returned in a prior
                                  call to GetDriverPath().
    @param  DriverImageHandle     The driver image handle that was returned by LoadImage()
                                  when the driver specified by DriverImagePath was loaded
                                  into memory.

    @retval EFI_SUCCESS           The association between DriverImagePath and
                                  DriverImageHandle was established for the controller specified
                                  by ControllerHandle.
    @retval EFI_UNSUPPORTED       The operation is not supported.
    @retval EFI_NOT_FOUND         DriverImagePath is not a device path that was returned on a prior
                                  call to GetDriverPath() for the controller specified by
                                  ControllerHandle.
    @retval EFI_INVALID_PARAMETER ControllerHandle is NULL.
    @retval EFI_INVALID_PARAMETER DriverImagePath is not a valid device path.
    @retval EFI_INVALID_PARAMETER DriverImageHandle is not a valid image handle.

  **/
  public readonly delegate* unmanaged<EFI_PLATFORM_DRIVER_OVERRIDE_PROTOCOL*, EFI_HANDLE, EFI_DEVICE_PATH_PROTOCOL*, EFI_HANDLE, EFI_STATUS> DriverLoaded;
}

// extern EFI_GUID  gEfiPlatformDriverOverrideProtocolGuid;

// #endif
