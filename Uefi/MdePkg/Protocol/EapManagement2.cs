using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file defines the EFI EAP Management2 protocol.

  Copyright (c) 2015, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.5

**/

// #ifndef __EFI_EAP_MANAGEMENT2_PROTOCOL_H__
// #define __EFI_EAP_MANAGEMENT2_PROTOCOL_H__

// #include <Protocol/EapManagement.h>

public unsafe partial class EFI
{
  ///
  /// This EFI EAP Management2 protocol provides the ability to configure and control EAPOL
  /// state machine, and retrieve the information, status and the statistics information of
  /// EAPOL state machine.
  ///
  public static EFI_GUID EFI_EAP_MANAGEMENT2_PROTOCOL_GUID = new GUID(
      0x5e93c847, 0x456d, 0x40b3, new byte[] { 0xa6, 0xb4, 0x78, 0xb0, 0xc9, 0xcf, 0x7f, 0x20 });

  // typedef struct _EFI_EAP_MANAGEMENT2_PROTOCOL EFI_EAP_MANAGEMENT2_PROTOCOL;

  // /**
  //   Return key generated through EAP process.
  // 
  //   The GetKey() function return the key generated through EAP process, so that the 802.11
  //   MAC layer driver can use MSK to derive more keys, e.g. PMK (Pairwise Master Key).
  // 
  //   @param[in]       This           Pointer to the EFI_EAP_MANAGEMENT2_PROTOCOL instance.
  //   @param[in, out]  Msk            Pointer to MSK (Master Session Key) buffer.
  //   @param[in, out]  MskSize        MSK buffer size.
  //   @param[in, out]  Emsk           Pointer to EMSK (Extended Master Session Key) buffer.
  //   @param[in, out]  EmskSize       EMSK buffer size.
  // 
  //   @retval EFI_SUCCESS             The operation completed successfully.
  //   @retval EFI_INVALID_PARAMETER   One or more of the following conditions is TRUE:
  //                                   Msk is NULL.
  //                                   MskSize is NULL.
  //                                   Emsk is NULL.
  //                                   EmskSize is NULL.
  //   @retval EFI_NOT_READY           MSK and EMSK are not generated in current session yet.
  // 
  // **/
  // typedef
  // EFI_STATUS
  // (EFIAPI *EFI_EAP_GET_KEY)(
  //   IN EFI_EAP_MANAGEMENT2_PROTOCOL         *This,
  //   IN OUT byte                            *Msk,
  //   IN OUT ulong                            *MskSize,
  //   IN OUT byte                            *Emsk,
  //   IN OUT byte                            *EmskSize
  //   );
}

///
/// The EFI_EAP_MANAGEMENT2_PROTOCOL
/// is used to control, configure and monitor EAPOL state machine on a Port, and return
/// information of the Port. EAPOL state machine is built on a per-Port basis. Herein, a
/// Port means a NIC. For the details of EAPOL, please refer to IEEE 802.1x
/// specification.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_EAP_MANAGEMENT2_PROTOCOL
{
  //public EFI_EAP_GET_SYSTEM_CONFIGURATION GetSystemConfiguration;
  //public EFI_EAP_SET_SYSTEM_CONFIGURATION SetSystemConfiguration;
  //public EFI_EAP_INITIALIZE_PORT InitializePort;
  //public EFI_EAP_USER_LOGON UserLogon;
  //public EFI_EAP_USER_LOGOFF UserLogoff;
  //public EFI_EAP_GET_SUPPLICANT_STATUS GetSupplicantStatus;
  //public EFI_EAP_SET_SUPPLICANT_CONFIGURATION SetSupplicantConfiguration;
  //public EFI_EAP_GET_SUPPLICANT_STATISTICS GetSupplicantStatistics;
  public readonly delegate* unmanaged</* IN */EFI_EAP_MANAGEMENT2_PROTOCOL* /*This*/,/* IN OUT */byte* /*Msk*/,/* IN OUT */ulong* /*MskSize*/,/* IN OUT */byte* /*Emsk*/,/* IN OUT */byte* /*EmskSize*/, EFI_STATUS> /*EFI_EAP_GET_KEY*/ GetKey;
}

// extern EFI_GUID  gEfiEapManagement2ProtocolGuid;

// #endif
