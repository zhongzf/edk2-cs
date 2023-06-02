namespace Uefi;
/** @file
  This file contains AML code definition in the latest ACPI spec.

  Copyright (c) 2011, Intel Corporation. All rights reserved.<BR>
  Copyright (c) 2019 - 2021, Arm Limited. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _ACPI_AML_H_
// #define _ACPI_AML_H_

//
// ACPI AML definition
//

public unsafe partial class EFI
{
  //
  // Primary OpCode
  //
  public const ulong AML_ZERO_OP = 0x00;
  public const ulong AML_ONE_OP = 0x01;
  public const ulong AML_ALIAS_OP = 0x06;
  public const ulong AML_NAME_OP = 0x08;
  public const ulong AML_BYTE_PREFIX = 0x0a;
  public const ulong AML_WORD_PREFIX = 0x0b;
  public const ulong AML_DWORD_PREFIX = 0x0c;
  public const ulong AML_STRING_PREFIX = 0x0d;
  public const ulong AML_QWORD_PREFIX = 0x0e;
  public const ulong AML_SCOPE_OP = 0x10;
  public const ulong AML_BUFFER_OP = 0x11;
  public const ulong AML_PACKAGE_OP = 0x12;
  public const ulong AML_VAR_PACKAGE_OP = 0x13;
  public const ulong AML_METHOD_OP = 0x14;
  public const ulong AML_EXTERNAL_OP = 0x15;
  public const ulong AML_DUAL_NAME_PREFIX = 0x2e;
  public const ulong AML_MULTI_NAME_PREFIX = 0x2f;
  public const ulong AML_NAME_CHAR_A = 0x41;
  public const ulong AML_NAME_CHAR_B = 0x42;
  public const ulong AML_NAME_CHAR_C = 0x43;
  public const ulong AML_NAME_CHAR_D = 0x44;
  public const ulong AML_NAME_CHAR_E = 0x45;
  public const ulong AML_NAME_CHAR_F = 0x46;
  public const ulong AML_NAME_CHAR_G = 0x47;
  public const ulong AML_NAME_CHAR_H = 0x48;
  public const ulong AML_NAME_CHAR_I = 0x49;
  public const ulong AML_NAME_CHAR_J = 0x4a;
  public const ulong AML_NAME_CHAR_K = 0x4b;
  public const ulong AML_NAME_CHAR_L = 0x4c;
  public const ulong AML_NAME_CHAR_M = 0x4d;
  public const ulong AML_NAME_CHAR_N = 0x4e;
  public const ulong AML_NAME_CHAR_O = 0x4f;
  public const ulong AML_NAME_CHAR_P = 0x50;
  public const ulong AML_NAME_CHAR_Q = 0x51;
  public const ulong AML_NAME_CHAR_R = 0x52;
  public const ulong AML_NAME_CHAR_S = 0x53;
  public const ulong AML_NAME_CHAR_T = 0x54;
  public const ulong AML_NAME_CHAR_U = 0x55;
  public const ulong AML_NAME_CHAR_V = 0x56;
  public const ulong AML_NAME_CHAR_W = 0x57;
  public const ulong AML_NAME_CHAR_X = 0x58;
  public const ulong AML_NAME_CHAR_Y = 0x59;
  public const ulong AML_NAME_CHAR_Z = 0x5a;
  public const ulong AML_ROOT_CHAR = 0x5c;
  public const ulong AML_PARENT_PREFIX_CHAR = 0x5e;
  public const ulong AML_NAME_CHAR__ = 0x5f;
  public const ulong AML_LOCAL0 = 0x60;
  public const ulong AML_LOCAL1 = 0x61;
  public const ulong AML_LOCAL2 = 0x62;
  public const ulong AML_LOCAL3 = 0x63;
  public const ulong AML_LOCAL4 = 0x64;
  public const ulong AML_LOCAL5 = 0x65;
  public const ulong AML_LOCAL6 = 0x66;
  public const ulong AML_LOCAL7 = 0x67;
  public const ulong AML_ARG0 = 0x68;
  public const ulong AML_ARG1 = 0x69;
  public const ulong AML_ARG2 = 0x6a;
  public const ulong AML_ARG3 = 0x6b;
  public const ulong AML_ARG4 = 0x6c;
  public const ulong AML_ARG5 = 0x6d;
  public const ulong AML_ARG6 = 0x6e;
  public const ulong AML_STORE_OP = 0x70;
  public const ulong AML_REF_OF_OP = 0x71;
  public const ulong AML_ADD_OP = 0x72;
  public const ulong AML_CONCAT_OP = 0x73;
  public const ulong AML_SUBTRACT_OP = 0x74;
  public const ulong AML_INCREMENT_OP = 0x75;
  public const ulong AML_DECREMENT_OP = 0x76;
  public const ulong AML_MULTIPLY_OP = 0x77;
  public const ulong AML_DIVIDE_OP = 0x78;
  public const ulong AML_SHIFT_LEFT_OP = 0x79;
  public const ulong AML_SHIFT_RIGHT_OP = 0x7a;
  public const ulong AML_AND_OP = 0x7b;
  public const ulong AML_NAND_OP = 0x7c;
  public const ulong AML_OR_OP = 0x7d;
  public const ulong AML_NOR_OP = 0x7e;
  public const ulong AML_XOR_OP = 0x7f;
  public const ulong AML_NOT_OP = 0x80;
  public const ulong AML_FIND_SET_LEFT_BIT_OP = 0x81;
  public const ulong AML_FIND_SET_RIGHT_BIT_OP = 0x82;
  public const ulong AML_DEREF_OF_OP = 0x83;
  public const ulong AML_CONCAT_RES_OP = 0x84;
  public const ulong AML_MOD_OP = 0x85;
  public const ulong AML_NOTIFY_OP = 0x86;
  public const ulong AML_SIZE_OF_OP = 0x87;
  public const ulong AML_INDEX_OP = 0x88;
  public const ulong AML_MATCH_OP = 0x89;
  public const ulong AML_CREATE_DWORD_FIELD_OP = 0x8a;
  public const ulong AML_CREATE_WORD_FIELD_OP = 0x8b;
  public const ulong AML_CREATE_BYTE_FIELD_OP = 0x8c;
  public const ulong AML_CREATE_BIT_FIELD_OP = 0x8d;
  public const ulong AML_OBJECT_TYPE_OP = 0x8e;
  public const ulong AML_CREATE_QWORD_FIELD_OP = 0x8f;
  public const ulong AML_LAND_OP = 0x90;
  public const ulong AML_LOR_OP = 0x91;
  public const ulong AML_LNOT_OP = 0x92;
  public const ulong AML_LEQUAL_OP = 0x93;
  public const ulong AML_LGREATER_OP = 0x94;
  public const ulong AML_LLESS_OP = 0x95;
  public const ulong AML_TO_BUFFER_OP = 0x96;
  public const ulong AML_TO_DEC_STRING_OP = 0x97;
  public const ulong AML_TO_HEX_STRING_OP = 0x98;
  public const ulong AML_TO_INTEGER_OP = 0x99;
  public const ulong AML_TO_STRING_OP = 0x9c;
  public const ulong AML_COPY_OBJECT_OP = 0x9d;
  public const ulong AML_MID_OP = 0x9e;
  public const ulong AML_CONTINUE_OP = 0x9f;
  public const ulong AML_IF_OP = 0xa0;
  public const ulong AML_ELSE_OP = 0xa1;
  public const ulong AML_WHILE_OP = 0xa2;
  public const ulong AML_NOOP_OP = 0xa3;
  public const ulong AML_RETURN_OP = 0xa4;
  public const ulong AML_BREAK_OP = 0xa5;
  public const ulong AML_BREAK_POINT_OP = 0xcc;
  public const ulong AML_ONES_OP = 0xff;

  //
  // Extended OpCode
  //
  public const ulong AML_EXT_OP = 0x5b;

  public const ulong AML_EXT_MUTEX_OP = 0x01;
  public const ulong AML_EXT_EVENT_OP = 0x02;
  public const ulong AML_EXT_COND_REF_OF_OP = 0x12;
  public const ulong AML_EXT_CREATE_FIELD_OP = 0x13;
  public const ulong AML_EXT_LOAD_TABLE_OP = 0x1f;
  public const ulong AML_EXT_LOAD_OP = 0x20;
  public const ulong AML_EXT_STALL_OP = 0x21;
  public const ulong AML_EXT_SLEEP_OP = 0x22;
  public const ulong AML_EXT_ACQUIRE_OP = 0x23;
  public const ulong AML_EXT_SIGNAL_OP = 0x24;
  public const ulong AML_EXT_WAIT_OP = 0x25;
  public const ulong AML_EXT_RESET_OP = 0x26;
  public const ulong AML_EXT_RELEASE_OP = 0x27;
  public const ulong AML_EXT_FROM_BCD_OP = 0x28;
  public const ulong AML_EXT_TO_BCD_OP = 0x29;
  public const ulong AML_EXT_UNLOAD_OP = 0x2a;
  public const ulong AML_EXT_REVISION_OP = 0x30;
  public const ulong AML_EXT_DEBUG_OP = 0x31;
  public const ulong AML_EXT_FATAL_OP = 0x32;
  public const ulong AML_EXT_TIMER_OP = 0x33;
  public const ulong AML_EXT_REGION_OP = 0x80;
  public const ulong AML_EXT_FIELD_OP = 0x81;
  public const ulong AML_EXT_DEVICE_OP = 0x82;
  public const ulong AML_EXT_PROCESSOR_OP = 0x83;
  public const ulong AML_EXT_POWER_RES_OP = 0x84;
  public const ulong AML_EXT_THERMAL_ZONE_OP = 0x85;
  public const ulong AML_EXT_INDEX_FIELD_OP = 0x86;
  public const ulong AML_EXT_BANK_FIELD_OP = 0x87;
  public const ulong AML_EXT_DATA_REGION_OP = 0x88;

  //
  // FieldElement OpCode
  //
  public const ulong AML_FIELD_RESERVED_OP = 0x00;
  public const ulong AML_FIELD_ACCESS_OP = 0x01;
  public const ulong AML_FIELD_CONNECTION_OP = 0x02;
  public const ulong AML_FIELD_EXT_ACCESS_OP = 0x03;

  //
  // AML Name segment definitions
  //
  public const ulong AML_NAME_SEG_SIZE = 4;
}

// #endif
