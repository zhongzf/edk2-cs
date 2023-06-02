using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI VLAN Config protocol is to provide manageability interface for VLAN configuration.

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.2

**/

// #ifndef __EFI_VLANCONFIG_PROTOCOL_H__
// #define __EFI_VLANCONFIG_PROTOCOL_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_VLAN_CONFIG_PROTOCOL_GUID = new GUID(
      0x9e23d768, 0xd2f3, 0x4366, new byte[] { 0x9f, 0xc3, 0x3a, 0x7a, 0xba, 0x86, 0x43, 0x74 });

  // typedef struct _EFI_VLAN_CONFIG_PROTOCOL EFI_VLAN_CONFIG_PROTOCOL;
}

///
/// EFI_VLAN_FIND_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_VLAN_FIND_DATA
{
  public ushort VlanId;           ///< Vlan Identifier.
  public byte Priority;         ///< Priority of this VLAN.
}

///
/// EFI_VLAN_CONFIG_PROTOCOL
/// provide manageability interface for VLAN setting. The intended
/// VLAN tagging implementation is IEEE802.1Q.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_VLAN_CONFIG_PROTOCOL
{
  /**
    Create a VLAN device or modify the configuration parameter of an
    already-configured VLAN.

    The Set() function is used to create a new VLAN device or change the VLAN
    configuration parameters. If the VlanId hasn't been configured in the
    physical Ethernet device, a new VLAN device will be created. If a VLAN with
    this VlanId is already configured, then related configuration will be updated
    as the input parameters.

    If VlanId is zero, the VLAN device will send and receive untagged frames.
    Otherwise, the VLAN device will send and receive VLAN-tagged frames containing the VlanId.
    If VlanId is out of scope of (0-4094), EFI_INVALID_PARAMETER is returned.
    If Priority is out of the scope of (0-7), then EFI_INVALID_PARAMETER is returned.
    If there is not enough system memory to perform the registration, then
    EFI_OUT_OF_RESOURCES is returned.

    @param[in] This                Points to the EFI_VLAN_CONFIG_PROTOCOL.
    @param[in] VlanId              A unique identifier (1-4094) of the VLAN which is being created
                                   or modified, or zero (0).
    @param[in] Priority            3 bit priority in VLAN header. Priority 0 is default value. If
                                   VlanId is zero (0), Priority is ignored.

    @retval EFI_SUCCESS            The VLAN is successfully configured.
    @retval EFI_INVALID_PARAMETER  One or more of following conditions is TRUE:
                                   - This is NULL.
                                   - VlanId is an invalid VLAN Identifier.
                                   - Priority is invalid.
    @retval EFI_OUT_OF_RESOURCES   There is not enough system memory to perform the registration.

  **/
  public readonly delegate* unmanaged<EFI_VLAN_CONFIG_PROTOCOL*, ushort, byte, EFI_STATUS> Set;
  /**
    Find configuration information for specified VLAN or all configured VLANs.

    The Find() function is used to find the configuration information for matching
    VLAN and allocate a buffer into which those entries are copied.

    @param[in]  This               Points to the EFI_VLAN_CONFIG_PROTOCOL.
    @param[in]  VlanId             Pointer to VLAN identifier. Set to NULL to find all
                                   configured VLANs.
    @param[out] NumberOfVlan       The number of VLANs which is found by the specified criteria.
    @param[out] Entries            The buffer which receive the VLAN configuration.

    @retval EFI_SUCCESS            The VLAN is successfully found.
    @retval EFI_INVALID_PARAMETER  One or more of following conditions is TRUE:
                                   - This is NULL.
                                   - Specified VlanId is invalid.
    @retval EFI_NOT_FOUND          No matching VLAN is found.

  **/
  public readonly delegate* unmanaged<EFI_VLAN_CONFIG_PROTOCOL*, ushort*, ushort*, EFI_VLAN_FIND_DATA**, EFI_STATUS> Find;
  /**
    Remove the configured VLAN device.

    The Remove() function is used to remove the specified VLAN device.
    If the VlanId is out of the scope of (0-4094), EFI_INVALID_PARAMETER is returned.
    If specified VLAN hasn't been previously configured, EFI_NOT_FOUND is returned.

    @param[in] This                Points to the EFI_VLAN_CONFIG_PROTOCOL.
    @param[in] VlanId              Identifier (0-4094) of the VLAN to be removed.

    @retval EFI_SUCCESS            The VLAN is successfully removed.
    @retval EFI_INVALID_PARAMETER  One or more of following conditions is TRUE:
                                   - This is NULL.
                                   - VlanId  is an invalid parameter.
    @retval EFI_NOT_FOUND          The to-be-removed VLAN does not exist.

  **/
  public readonly delegate* unmanaged<EFI_VLAN_CONFIG_PROTOCOL*, ushort, EFI_STATUS> Remove;
}

// extern EFI_GUID  gEfiVlanConfigProtocolGuid;

// #endif
