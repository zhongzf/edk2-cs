using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI_DEVICE_PATH_UTILITIES_PROTOCOL as defined in UEFI 2.0.
  Use to create and manipulate device paths and device nodes.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __DEVICE_PATH_UTILITIES_PROTOCOL_H__
// #define __DEVICE_PATH_UTILITIES_PROTOCOL_H__

///
/// Device Path Utilities protocol
///
public static EFI_GUID EFI_DEVICE_PATH_UTILITIES_PROTOCOL_GUID = new GUID(
    0x379be4e, 0xd706, 0x437d, new byte[] { 0xb0, 0x37, 0xed, 0xb8, 0x2f, 0xb7, 0x72, 0xa4 });





















































































































































///
/// This protocol is used to creates and manipulates device paths and device nodes.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEVICE_PATH_UTILITIES_PROTOCOL
{
  /**
    Returns the size of the device path, in bytes.

    @param  DevicePath Points to the start of the EFI device path.

    @return Size  Size of the specified device path, in bytes, including the end-of-path tag.
    @retval 0     DevicePath is NULL

  **/
  public readonly delegate* unmanaged<CONST, EFI_STATUS> GetDevicePathSize;
  /**
    Create a duplicate of the specified path.

    @param  DevicePath Points to the source EFI device path.

    @retval Pointer    A pointer to the duplicate device path.
    @retval NULL       insufficient memory or DevicePath is NULL

  **/
  public readonly delegate* unmanaged<CONST, EFI_STATUS> DuplicateDevicePath;
  /**
    Create a new path by appending the second device path to the first.
    If Src1 is NULL and Src2 is non-NULL, then a duplicate of Src2 is returned.
    If Src1 is non-NULL and Src2 is NULL, then a duplicate of Src1 is returned.
    If Src1 and Src2 are both NULL, then a copy of an end-of-device-path is returned.

    @param  Src1 Points to the first device path.
    @param  Src2 Points to the second device path.

    @retval Pointer  A pointer to the newly created device path.
    @retval NULL     Memory could not be allocated

  **/
  public readonly delegate* unmanaged<CONST, CONST, EFI_STATUS> AppendDevicePath;
  /**
    Creates a new path by appending the device node to the device path.
    If DeviceNode is NULL then a copy of DevicePath is returned.
    If DevicePath is NULL then a copy of DeviceNode, followed by an end-of-device path device node is returned.
    If both DeviceNode and DevicePath are NULL then a copy of an end-of-device-path device node is returned.

    @param  DevicePath Points to the device path.
    @param  DeviceNode Points to the device node.

    @retval Pointer    A pointer to the allocated device node.
    @retval NULL       There was insufficient memory.

  **/
  public readonly delegate* unmanaged<CONST, CONST, EFI_STATUS> AppendDeviceNode;
  /**
    Creates a new path by appending the specified device path instance to the specified device path.

    @param  DevicePath         Points to the device path. If NULL, then ignored.
    @param  DevicePathInstance Points to the device path instance.

    @retval Pointer            A pointer to the newly created device path
    @retval NULL               Memory could not be allocated or DevicePathInstance is NULL.

  **/
  public readonly delegate* unmanaged<CONST, CONST, EFI_STATUS> AppendDevicePathInstance;
  /**
    Creates a copy of the current device path instance and returns a pointer to the next device path
    instance.

    @param  DevicePathInstance     On input, this holds the pointer to the current device path
                                   instance. On output, this holds the pointer to the next
                                   device path instance or NULL if there are no more device
                                   path instances in the device path.
    @param  DevicePathInstanceSize On output, this holds the size of the device path instance,
                                   in bytes or zero, if DevicePathInstance is NULL.
                                   If NULL, then the instance size is not output.

    @retval Pointer                A pointer to the copy of the current device path instance.
    @retval NULL                   DevicePathInstace was NULL on entry or there was insufficient memory.

  **/
  public readonly delegate* unmanaged<OUT, ulong*, EFI_STATUS> GetNextDevicePathInstance;
  /**
    Returns whether a device path is multi-instance.

    @param  DevicePath Points to the device path. If NULL, then ignored.

    @retval TRUE       The device path has more than one instance
    @retval FALSE      The device path is empty or contains only a single instance.

  **/
  public readonly delegate* unmanaged<CONST, EFI_STATUS> IsDevicePathMultiInstance;
  /**
    Creates a device node

    @param  NodeType    NodeType is the device node type (EFI_DEVICE_PATH.Type) for
                        the new device node.
    @param  NodeSubType NodeSubType is the device node sub-type
                        EFI_DEVICE_PATH.SubType) for the new device node.
    @param  NodeLength  NodeLength is the length of the device node
                        (EFI_DEVICE_PATH.Length) for the new device node.

    @retval Pointer     A pointer to the newly created device node.
    @retval NULL        NodeLength is less than
                        the size of the header or there was insufficient memory.

  **/
  public readonly delegate* unmanaged<byte, byte, ushort, EFI_STATUS> CreateDeviceNode;
}

// extern EFI_GUID  gEfiDevicePathUtilitiesProtocolGuid;

// #endif
