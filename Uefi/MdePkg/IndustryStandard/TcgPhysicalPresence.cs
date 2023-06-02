namespace Uefi;
/** @file
  TCG Physical Presence definition.

Copyright (c) 2015 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _TCG_PHYSICAL_PRESENCE_H_
// #define _TCG_PHYSICAL_PRESENCE_H_

public unsafe partial class EFI
{
  //
  // TCG PP definition for physical presence ACPI function
  //
  public const ulong TCG_ACPI_FUNCTION_GET_PHYSICAL_PRESENCE_INTERFACE_VERSION = 1;
  public const ulong TCG_ACPI_FUNCTION_SUBMIT_REQUEST_TO_BIOS = 2;
  public const ulong TCG_ACPI_FUNCTION_GET_PENDING_REQUEST_BY_OS = 3;
  public const ulong TCG_ACPI_FUNCTION_GET_PLATFORM_ACTION_TO_TRANSITION_TO_BIOS = 4;
  public const ulong TCG_ACPI_FUNCTION_RETURN_REQUEST_RESPONSE_TO_OS = 5;
  public const ulong TCG_ACPI_FUNCTION_SUBMIT_PREFERRED_USER_LANGUAGE = 6;
  public const ulong TCG_ACPI_FUNCTION_SUBMIT_REQUEST_TO_BIOS_2 = 7;
  public const ulong TCG_ACPI_FUNCTION_GET_USER_CONFIRMATION_STATUS_FOR_REQUEST = 8;

  //
  // TCG PP definition for TPM Operation Response to OS Environment
  //
  public const ulong TCG_PP_OPERATION_RESPONSE_SUCCESS = 0x0;
  public const ulong TCG_PP_OPERATION_RESPONSE_USER_ABORT = 0xFFFFFFF0;
  public const ulong TCG_PP_OPERATION_RESPONSE_BIOS_FAILURE = 0xFFFFFFF1;

  //
  // TCG PP definition of return code for Return TPM Operation Response to OS Environment
  //
  public const ulong TCG_PP_RETURN_TPM_OPERATION_RESPONSE_SUCCESS = 0;
  public const ulong TCG_PP_RETURN_TPM_OPERATION_RESPONSE_FAILURE = 1;

  //
  // TCG PP definition of return code for Submit TPM Request to Pre-OS Environment
  // and Submit TPM Request to Pre-OS Environment 2
  //
  public const ulong TCG_PP_SUBMIT_REQUEST_TO_PREOS_SUCCESS = 0;
  public const ulong TCG_PP_SUBMIT_REQUEST_TO_PREOS_NOT_IMPLEMENTED = 1;
  public const ulong TCG_PP_SUBMIT_REQUEST_TO_PREOS_GENERAL_FAILURE = 2;
  public const ulong TCG_PP_SUBMIT_REQUEST_TO_PREOS_BLOCKED_BY_BIOS_SETTINGS = 3;

  //
  // TCG PP definition of return code for Get User Confirmation Status for Operation
  //
  public const ulong TCG_PP_GET_USER_CONFIRMATION_NOT_IMPLEMENTED = 0;
  public const ulong TCG_PP_GET_USER_CONFIRMATION_BIOS_ONLY = 1;
  public const ulong TCG_PP_GET_USER_CONFIRMATION_BLOCKED_BY_BIOS_CONFIGURATION = 2;
  public const ulong TCG_PP_GET_USER_CONFIRMATION_ALLOWED_AND_PPUSER_REQUIRED = 3;
  public const ulong TCG_PP_GET_USER_CONFIRMATION_ALLOWED_AND_PPUSER_NOT_REQUIRED = 4;

  //
  // TCG PP definition of physical presence operation actions for TPM12
  //
  public const ulong TCG_PHYSICAL_PRESENCE_NO_ACTION = 0;
  public const ulong TCG_PHYSICAL_PRESENCE_ENABLE = 1;
  public const ulong TCG_PHYSICAL_PRESENCE_DISABLE = 2;
  public const ulong TCG_PHYSICAL_PRESENCE_ACTIVATE = 3;
  public const ulong TCG_PHYSICAL_PRESENCE_DEACTIVATE = 4;
  public const ulong TCG_PHYSICAL_PRESENCE_CLEAR = 5;
  public const ulong TCG_PHYSICAL_PRESENCE_ENABLE_ACTIVATE = 6;
  public const ulong TCG_PHYSICAL_PRESENCE_DEACTIVATE_DISABLE = 7;
  public const ulong TCG_PHYSICAL_PRESENCE_SET_OWNER_INSTALL_TRUE = 8;
  public const ulong TCG_PHYSICAL_PRESENCE_SET_OWNER_INSTALL_FALSE = 9;
  public const ulong TCG_PHYSICAL_PRESENCE_ENABLE_ACTIVATE_OWNER_TRUE = 10;
  public const ulong TCG_PHYSICAL_PRESENCE_DEACTIVATE_DISABLE_OWNER_FALSE = 11;
  public const ulong TCG_PHYSICAL_PRESENCE_DEFERRED_PP_UNOWNERED_FIELD_UPGRADE = 12;
  public const ulong TCG_PHYSICAL_PRESENCE_SET_OPERATOR_AUTH = 13;
  public const ulong TCG_PHYSICAL_PRESENCE_CLEAR_ENABLE_ACTIVATE = 14;
  public const ulong TCG_PHYSICAL_PRESENCE_SET_NO_PPI_PROVISION_FALSE = 15;
  public const ulong TCG_PHYSICAL_PRESENCE_SET_NO_PPI_PROVISION_TRUE = 16;
  public const ulong TCG_PHYSICAL_PRESENCE_SET_NO_PPI_CLEAR_FALSE = 17;
  public const ulong TCG_PHYSICAL_PRESENCE_SET_NO_PPI_CLEAR_TRUE = 18;
  public const ulong TCG_PHYSICAL_PRESENCE_SET_NO_PPI_MAINTENANCE_FALSE = 19;
  public const ulong TCG_PHYSICAL_PRESENCE_SET_NO_PPI_MAINTENANCE_TRUE = 20;
  public const ulong TCG_PHYSICAL_PRESENCE_ENABLE_ACTIVATE_CLEAR = 21;
  public const ulong TCG_PHYSICAL_PRESENCE_ENABLE_ACTIVATE_CLEAR_ENABLE_ACTIVATE = 22;

  public const ulong TCG_PHYSICAL_PRESENCE_VENDOR_SPECIFIC_OPERATION = 128;

  //
  // TCG PP definition of physical presence operation actions for TPM2
  //
  public const ulong TCG2_PHYSICAL_PRESENCE_NO_ACTION = 0;
  public const ulong TCG2_PHYSICAL_PRESENCE_ENABLE = 1;
  public const ulong TCG2_PHYSICAL_PRESENCE_DISABLE = 2;
  public const ulong TCG2_PHYSICAL_PRESENCE_CLEAR = 5;
  public const ulong TCG2_PHYSICAL_PRESENCE_ENABLE_CLEAR = 14;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_CLEAR_TRUE = 17;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_CLEAR_FALSE = 18;
  public const ulong TCG2_PHYSICAL_PRESENCE_ENABLE_CLEAR_2 = 21;
  public const ulong TCG2_PHYSICAL_PRESENCE_ENABLE_CLEAR_3 = 22;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PCR_BANKS = 23;
  public const ulong TCG2_PHYSICAL_PRESENCE_CHANGE_EPS = 24;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_CHANGE_PCRS_FALSE = 25;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_CHANGE_PCRS_TRUE = 26;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_TURN_ON_FALSE = 27;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_TURN_ON_TRUE = 28;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_TURN_OFF_FALSE = 29;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_TURN_OFF_TRUE = 30;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_CHANGE_EPS_FALSE = 31;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_CHANGE_EPS_TRUE = 32;
  public const ulong TCG2_PHYSICAL_PRESENCE_LOG_ALL_DIGESTS = 33;
  public const ulong TCG2_PHYSICAL_PRESENCE_DISABLE_ENDORSEMENT_ENABLE_STORAGE_HIERARCHY = 34;
  public const ulong TCG2_PHYSICAL_PRESENCE_NO_ACTION_MAX = 34;

  //
  // TCG PP definition of physical presence operation actions for storage management
  //
  public const ulong TCG2_PHYSICAL_PRESENCE_STORAGE_MANAGEMENT_BEGIN = 96;
  public const ulong TCG2_PHYSICAL_PRESENCE_ENABLE_BLOCK_SID = 96;
  public const ulong TCG2_PHYSICAL_PRESENCE_DISABLE_BLOCK_SID = 97;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_ENABLE_BLOCK_SID_FUNC_TRUE = 98;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_ENABLE_BLOCK_SID_FUNC_FALSE = 99;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_DISABLE_BLOCK_SID_FUNC_TRUE = 100;
  public const ulong TCG2_PHYSICAL_PRESENCE_SET_PP_REQUIRED_FOR_DISABLE_BLOCK_SID_FUNC_FALSE = 101;

  public const ulong TCG2_PHYSICAL_PRESENCE_VENDOR_SPECIFIC_OPERATION = 128;
}

// #endif
