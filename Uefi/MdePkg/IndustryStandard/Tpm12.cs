using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  TPM Specification data structures (TCG TPM Specification Version 1.2 Revision 103)
  See http://trustedcomputinggroup.org for latest specification updates

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _TPM12_H_
// #define _TPM12_H_

public unsafe partial class EFI
{
  ///
  /// The start of TPM return codes
  ///
  public const ulong TPM_BASE = 0;

  //
  // All structures MUST be packed on a byte boundary.
  //

  // #pragma pack (1)
}

//
// Part 2, section 2.2.3: Helper redefinitions
//
///
/// Indicates the conditions where it is required that authorization be presented
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_AUTH_DATA_USAGE { byte Value; public static implicit operator TPM_AUTH_DATA_USAGE(byte value) => new TPM_AUTH_DATA_USAGE() { Value = value }; public static implicit operator byte(TPM_AUTH_DATA_USAGE value) => value.Value; }
///
/// The information as to what the payload is in an encrypted structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PAYLOAD_TYPE { byte Value; public static implicit operator TPM_PAYLOAD_TYPE(byte value) => new TPM_PAYLOAD_TYPE() { Value = value }; public static implicit operator byte(TPM_PAYLOAD_TYPE value) => value.Value; }
///
/// The version info breakdown
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_VERSION_BYTE { byte Value; public static implicit operator TPM_VERSION_BYTE(byte value) => new TPM_VERSION_BYTE() { Value = value }; public static implicit operator byte(TPM_VERSION_BYTE value) => value.Value; }
///
/// The state of the dictionary attack mitigation logic
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DA_STATE { byte Value; public static implicit operator TPM_DA_STATE(byte value) => new TPM_DA_STATE() { Value = value }; public static implicit operator byte(TPM_DA_STATE value) => value.Value; }
///
/// The request or response authorization type
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_TAG { ushort Value; public static implicit operator TPM_TAG(ushort value) => new TPM_TAG() { Value = value }; public static implicit operator ushort(TPM_TAG value) => value.Value; }
///
/// The protocol in use
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PROTOCOL_ID { ushort Value; public static implicit operator TPM_PROTOCOL_ID(ushort value) => new TPM_PROTOCOL_ID() { Value = value }; public static implicit operator ushort(TPM_PROTOCOL_ID value) => value.Value; }
///
/// Indicates the start state
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STARTUP_TYPE { ushort Value; public static implicit operator TPM_STARTUP_TYPE(ushort value) => new TPM_STARTUP_TYPE() { Value = value }; public static implicit operator ushort(TPM_STARTUP_TYPE value) => value.Value; }
///
/// The definition of the encryption scheme
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_ENC_SCHEME { ushort Value; public static implicit operator TPM_ENC_SCHEME(ushort value) => new TPM_ENC_SCHEME() { Value = value }; public static implicit operator ushort(TPM_ENC_SCHEME value) => value.Value; }
///
/// The definition of the signature scheme
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_SIG_SCHEME { ushort Value; public static implicit operator TPM_SIG_SCHEME(ushort value) => new TPM_SIG_SCHEME() { Value = value }; public static implicit operator ushort(TPM_SIG_SCHEME value) => value.Value; }
///
/// The definition of the migration scheme
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_MIGRATE_SCHEME { ushort Value; public static implicit operator TPM_MIGRATE_SCHEME(ushort value) => new TPM_MIGRATE_SCHEME() { Value = value }; public static implicit operator ushort(TPM_MIGRATE_SCHEME value) => value.Value; }
///
/// Sets the state of the physical presence mechanism
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PHYSICAL_PRESENCE { ushort Value; public static implicit operator TPM_PHYSICAL_PRESENCE(ushort value) => new TPM_PHYSICAL_PRESENCE() { Value = value }; public static implicit operator ushort(TPM_PHYSICAL_PRESENCE value) => value.Value; }
///
/// Indicates the types of entity that are supported by the TPM
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_ENTITY_TYPE { ushort Value; public static implicit operator TPM_ENTITY_TYPE(ushort value) => new TPM_ENTITY_TYPE() { Value = value }; public static implicit operator ushort(TPM_ENTITY_TYPE value) => value.Value; }
///
/// Indicates the permitted usage of the key
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_KEY_USAGE { ushort Value; public static implicit operator TPM_KEY_USAGE(ushort value) => new TPM_KEY_USAGE() { Value = value }; public static implicit operator ushort(TPM_KEY_USAGE value) => value.Value; }
///
/// The type of asymmetric encrypted structure in use by the endorsement key
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_EK_TYPE { ushort Value; public static implicit operator TPM_EK_TYPE(ushort value) => new TPM_EK_TYPE() { Value = value }; public static implicit operator ushort(TPM_EK_TYPE value) => value.Value; }
///
/// The tag for the structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STRUCTURE_TAG { ushort Value; public static implicit operator TPM_STRUCTURE_TAG(ushort value) => new TPM_STRUCTURE_TAG() { Value = value }; public static implicit operator ushort(TPM_STRUCTURE_TAG value) => value.Value; }
///
/// The platform specific spec to which the information relates to
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PLATFORM_SPECIFIC { ushort Value; public static implicit operator TPM_PLATFORM_SPECIFIC(ushort value) => new TPM_PLATFORM_SPECIFIC() { Value = value }; public static implicit operator ushort(TPM_PLATFORM_SPECIFIC value) => value.Value; }
///
/// The command ordinal
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_COMMAND_CODE { uint Value; public static implicit operator TPM_COMMAND_CODE(uint value) => new TPM_COMMAND_CODE() { Value = value }; public static implicit operator uint(TPM_COMMAND_CODE value) => value.Value; }
///
/// Identifies a TPM capability area
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CAPABILITY_AREA { uint Value; public static implicit operator TPM_CAPABILITY_AREA(uint value) => new TPM_CAPABILITY_AREA() { Value = value }; public static implicit operator uint(TPM_CAPABILITY_AREA value) => value.Value; }
///
/// Indicates information regarding a key
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_KEY_FLAGS { uint Value; public static implicit operator TPM_KEY_FLAGS(uint value) => new TPM_KEY_FLAGS() { Value = value }; public static implicit operator uint(TPM_KEY_FLAGS value) => value.Value; }
///
/// Indicates the type of algorithm
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_ALGORITHM_ID { uint Value; public static implicit operator TPM_ALGORITHM_ID(uint value) => new TPM_ALGORITHM_ID() { Value = value }; public static implicit operator uint(TPM_ALGORITHM_ID value) => value.Value; }
///
/// The locality modifier
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_MODIFIER_INDICATOR { uint Value; public static implicit operator TPM_MODIFIER_INDICATOR(uint value) => new TPM_MODIFIER_INDICATOR() { Value = value }; public static implicit operator uint(TPM_MODIFIER_INDICATOR value) => value.Value; }
///
/// The actual number of a counter
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_ACTUAL_COUNT { uint Value; public static implicit operator TPM_ACTUAL_COUNT(uint value) => new TPM_ACTUAL_COUNT() { Value = value }; public static implicit operator uint(TPM_ACTUAL_COUNT value) => value.Value; }
///
/// Attributes that define what options are in use for a transport session
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_TRANSPORT_ATTRIBUTES { uint Value; public static implicit operator TPM_TRANSPORT_ATTRIBUTES(uint value) => new TPM_TRANSPORT_ATTRIBUTES() { Value = value }; public static implicit operator uint(TPM_TRANSPORT_ATTRIBUTES value) => value.Value; }
///
/// Handle to an authorization session
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_AUTHHANDLE { uint Value; public static implicit operator TPM_AUTHHANDLE(uint value) => new TPM_AUTHHANDLE() { Value = value }; public static implicit operator uint(TPM_AUTHHANDLE value) => value.Value; }
///
/// Index to a DIR register
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DIRINDEX { uint Value; public static implicit operator TPM_DIRINDEX(uint value) => new TPM_DIRINDEX() { Value = value }; public static implicit operator uint(TPM_DIRINDEX value) => value.Value; }
///
/// The area where a key is held assigned by the TPM
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_KEY_HANDLE { uint Value; public static implicit operator TPM_KEY_HANDLE(uint value) => new TPM_KEY_HANDLE() { Value = value }; public static implicit operator uint(TPM_KEY_HANDLE value) => value.Value; }
///
/// Index to a PCR register
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PCRINDEX { uint Value; public static implicit operator TPM_PCRINDEX(uint value) => new TPM_PCRINDEX() { Value = value }; public static implicit operator uint(TPM_PCRINDEX value) => value.Value; }
///
/// The return code from a function
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_RESULT { uint Value; public static implicit operator TPM_RESULT(uint value) => new TPM_RESULT() { Value = value }; public static implicit operator uint(TPM_RESULT value) => value.Value; }
///
/// The types of resources that a TPM may have using internal resources
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_RESOURCE_TYPE { uint Value; public static implicit operator TPM_RESOURCE_TYPE(uint value) => new TPM_RESOURCE_TYPE() { Value = value }; public static implicit operator uint(TPM_RESOURCE_TYPE value) => value.Value; }
///
/// Allows for controlling of the key when loaded and how to handle TPM_Startup issues
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_KEY_CONTROL { uint Value; public static implicit operator TPM_KEY_CONTROL(uint value) => new TPM_KEY_CONTROL() { Value = value }; public static implicit operator uint(TPM_KEY_CONTROL value) => value.Value; }
///
/// The index into the NV storage area
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_NV_INDEX { uint Value; public static implicit operator TPM_NV_INDEX(uint value) => new TPM_NV_INDEX() { Value = value }; public static implicit operator uint(TPM_NV_INDEX value) => value.Value; }
///
/// The family ID. Family IDs are automatically assigned a sequence number by the TPM.
/// A trusted process can set the FamilyID value in an individual row to NULL, which
/// invalidates that row. The family ID resets to NULL on each change of TPM Owner.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_FAMILY_ID { uint Value; public static implicit operator TPM_FAMILY_ID(uint value) => new TPM_FAMILY_ID() { Value = value }; public static implicit operator uint(TPM_FAMILY_ID value) => value.Value; }
///
/// IA value used as a label for the most recent verification of this family. Set to zero when not in use.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_FAMILY_VERIFICATION { uint Value; public static implicit operator TPM_FAMILY_VERIFICATION(uint value) => new TPM_FAMILY_VERIFICATION() { Value = value }; public static implicit operator uint(TPM_FAMILY_VERIFICATION value) => value.Value; }
///
/// How the TPM handles var
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STARTUP_EFFECTS { uint Value; public static implicit operator TPM_STARTUP_EFFECTS(uint value) => new TPM_STARTUP_EFFECTS() { Value = value }; public static implicit operator uint(TPM_STARTUP_EFFECTS value) => value.Value; }
///
/// The mode of a symmetric encryption
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_SYM_MODE { uint Value; public static implicit operator TPM_SYM_MODE(uint value) => new TPM_SYM_MODE() { Value = value }; public static implicit operator uint(TPM_SYM_MODE value) => value.Value; }
///
/// The family flags
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_FAMILY_FLAGS { uint Value; public static implicit operator TPM_FAMILY_FLAGS(uint value) => new TPM_FAMILY_FLAGS() { Value = value }; public static implicit operator uint(TPM_FAMILY_FLAGS value) => value.Value; }
///
/// The index value for the delegate NV table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DELEGATE_INDEX { uint Value; public static implicit operator TPM_DELEGATE_INDEX(uint value) => new TPM_DELEGATE_INDEX() { Value = value }; public static implicit operator uint(TPM_DELEGATE_INDEX value) => value.Value; }
///
/// The restrictions placed on delegation of CMK commands
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CMK_DELEGATE { uint Value; public static implicit operator TPM_CMK_DELEGATE(uint value) => new TPM_CMK_DELEGATE() { Value = value }; public static implicit operator uint(TPM_CMK_DELEGATE value) => value.Value; }
///
/// The ID value of a monotonic counter
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_COUNT_ID { uint Value; public static implicit operator TPM_COUNT_ID(uint value) => new TPM_COUNT_ID() { Value = value }; public static implicit operator uint(TPM_COUNT_ID value) => value.Value; }
///
/// A command to execute
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_REDIT_COMMAND { uint Value; public static implicit operator TPM_REDIT_COMMAND(uint value) => new TPM_REDIT_COMMAND() { Value = value }; public static implicit operator uint(TPM_REDIT_COMMAND value) => value.Value; }
///
/// A transport session handle
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_TRANSHANDLE { uint Value; public static implicit operator TPM_TRANSHANDLE(uint value) => new TPM_TRANSHANDLE() { Value = value }; public static implicit operator uint(TPM_TRANSHANDLE value) => value.Value; }
///
/// A generic handle could be key, transport etc
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_HANDLE { uint Value; public static implicit operator TPM_HANDLE(uint value) => new TPM_HANDLE() { Value = value }; public static implicit operator uint(TPM_HANDLE value) => value.Value; }
///
/// What operation is happening
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_FAMILY_OPERATION { uint Value; public static implicit operator TPM_FAMILY_OPERATION(uint value) => new TPM_FAMILY_OPERATION() { Value = value }; public static implicit operator uint(TPM_FAMILY_OPERATION value) => value.Value; }

public unsafe partial class EFI
{
  //
  // Part 2, section 2.2.4: Vendor specific
  // The following defines allow for the quick specification of a
  // vendor specific item.
  //
  public const ulong TPM_Vendor_Specific32 = ((uint)0x00000400);
  public const ulong TPM_Vendor_Specific8 = ((byte)0x80);

  //
  // Part 2, section 3.1: TPM_STRUCTURE_TAG
  //
  public const ulong TPM_TAG_CONTEXTBLOB = ((TPM_STRUCTURE_TAG)0x0001);
  public const ulong TPM_TAG_CONTEXT_SENSITIVE = ((TPM_STRUCTURE_TAG)0x0002);
  public const ulong TPM_TAG_CONTEXTPOINTER = ((TPM_STRUCTURE_TAG)0x0003);
  public const ulong TPM_TAG_CONTEXTLIST = ((TPM_STRUCTURE_TAG)0x0004);
  public const ulong TPM_TAG_SIGNINFO = ((TPM_STRUCTURE_TAG)0x0005);
  public const ulong TPM_TAG_PCR_INFO_LONG = ((TPM_STRUCTURE_TAG)0x0006);
  public const ulong TPM_TAG_PERSISTENT_FLAGS = ((TPM_STRUCTURE_TAG)0x0007);
  public const ulong TPM_TAG_VOLATILE_FLAGS = ((TPM_STRUCTURE_TAG)0x0008);
  public const ulong TPM_TAG_PERSISTENT_DATA = ((TPM_STRUCTURE_TAG)0x0009);
  public const ulong TPM_TAG_VOLATILE_DATA = ((TPM_STRUCTURE_TAG)0x000A);
  public const ulong TPM_TAG_SV_DATA = ((TPM_STRUCTURE_TAG)0x000B);
  public const ulong TPM_TAG_EK_BLOB = ((TPM_STRUCTURE_TAG)0x000C);
  public const ulong TPM_TAG_EK_BLOB_AUTH = ((TPM_STRUCTURE_TAG)0x000D);
  public const ulong TPM_TAG_COUNTER_VALUE = ((TPM_STRUCTURE_TAG)0x000E);
  public const ulong TPM_TAG_TRANSPORT_INTERNAL = ((TPM_STRUCTURE_TAG)0x000F);
  public const ulong TPM_TAG_TRANSPORT_LOG_IN = ((TPM_STRUCTURE_TAG)0x0010);
  public const ulong TPM_TAG_TRANSPORT_LOG_OUT = ((TPM_STRUCTURE_TAG)0x0011);
  public const ulong TPM_TAG_AUDIT_EVENT_IN = ((TPM_STRUCTURE_TAG)0x0012);
  public const ulong TPM_TAG_AUDIT_EVENT_OUT = ((TPM_STRUCTURE_TAG)0x0013);
  public const ulong TPM_TAG_CURRENT_TICKS = ((TPM_STRUCTURE_TAG)0x0014);
  public const ulong TPM_TAG_KEY = ((TPM_STRUCTURE_TAG)0x0015);
  public const ulong TPM_TAG_STORED_DATA12 = ((TPM_STRUCTURE_TAG)0x0016);
  public const ulong TPM_TAG_NV_ATTRIBUTES = ((TPM_STRUCTURE_TAG)0x0017);
  public const ulong TPM_TAG_NV_DATA_PUBLIC = ((TPM_STRUCTURE_TAG)0x0018);
  public const ulong TPM_TAG_NV_DATA_SENSITIVE = ((TPM_STRUCTURE_TAG)0x0019);
  public const ulong TPM_TAG_DELEGATIONS = ((TPM_STRUCTURE_TAG)0x001A);
  public const ulong TPM_TAG_DELEGATE_PUBLIC = ((TPM_STRUCTURE_TAG)0x001B);
  public const ulong TPM_TAG_DELEGATE_TABLE_ROW = ((TPM_STRUCTURE_TAG)0x001C);
  public const ulong TPM_TAG_TRANSPORT_AUTH = ((TPM_STRUCTURE_TAG)0x001D);
  public const ulong TPM_TAG_TRANSPORT_PUBLIC = ((TPM_STRUCTURE_TAG)0x001E);
  public const ulong TPM_TAG_PERMANENT_FLAGS = ((TPM_STRUCTURE_TAG)0x001F);
  public const ulong TPM_TAG_STCLEAR_FLAGS = ((TPM_STRUCTURE_TAG)0x0020);
  public const ulong TPM_TAG_STANY_FLAGS = ((TPM_STRUCTURE_TAG)0x0021);
  public const ulong TPM_TAG_PERMANENT_DATA = ((TPM_STRUCTURE_TAG)0x0022);
  public const ulong TPM_TAG_STCLEAR_DATA = ((TPM_STRUCTURE_TAG)0x0023);
  public const ulong TPM_TAG_STANY_DATA = ((TPM_STRUCTURE_TAG)0x0024);
  public const ulong TPM_TAG_FAMILY_TABLE_ENTRY = ((TPM_STRUCTURE_TAG)0x0025);
  public const ulong TPM_TAG_DELEGATE_SENSITIVE = ((TPM_STRUCTURE_TAG)0x0026);
  public const ulong TPM_TAG_DELG_KEY_BLOB = ((TPM_STRUCTURE_TAG)0x0027);
  public const ulong TPM_TAG_KEY12 = ((TPM_STRUCTURE_TAG)0x0028);
  public const ulong TPM_TAG_CERTIFY_INFO2 = ((TPM_STRUCTURE_TAG)0x0029);
  public const ulong TPM_TAG_DELEGATE_OWNER_BLOB = ((TPM_STRUCTURE_TAG)0x002A);
  public const ulong TPM_TAG_EK_BLOB_ACTIVATE = ((TPM_STRUCTURE_TAG)0x002B);
  public const ulong TPM_TAG_DAA_BLOB = ((TPM_STRUCTURE_TAG)0x002C);
  public const ulong TPM_TAG_DAA_CONTEXT = ((TPM_STRUCTURE_TAG)0x002D);
  public const ulong TPM_TAG_DAA_ENFORCE = ((TPM_STRUCTURE_TAG)0x002E);
  public const ulong TPM_TAG_DAA_ISSUER = ((TPM_STRUCTURE_TAG)0x002F);
  public const ulong TPM_TAG_CAP_VERSION_INFO = ((TPM_STRUCTURE_TAG)0x0030);
  public const ulong TPM_TAG_DAA_SENSITIVE = ((TPM_STRUCTURE_TAG)0x0031);
  public const ulong TPM_TAG_DAA_TPM = ((TPM_STRUCTURE_TAG)0x0032);
  public const ulong TPM_TAG_CMK_MIGAUTH = ((TPM_STRUCTURE_TAG)0x0033);
  public const ulong TPM_TAG_CMK_SIGTICKET = ((TPM_STRUCTURE_TAG)0x0034);
  public const ulong TPM_TAG_CMK_MA_APPROVAL = ((TPM_STRUCTURE_TAG)0x0035);
  public const ulong TPM_TAG_QUOTE_INFO2 = ((TPM_STRUCTURE_TAG)0x0036);
  public const ulong TPM_TAG_DA_INFO = ((TPM_STRUCTURE_TAG)0x0037);
  public const ulong TPM_TAG_DA_LIMITED = ((TPM_STRUCTURE_TAG)0x0038);
  public const ulong TPM_TAG_DA_ACTION_TYPE = ((TPM_STRUCTURE_TAG)0x0039);

  //
  // Part 2, section 4: TPM Types
  //

  //
  // Part 2, section 4.1: TPM_RESOURCE_TYPE
  //
  public const ulong TPM_RT_KEY = ((TPM_RESOURCE_TYPE)0x00000001); /// < The handle is a key handle and is the result of a LoadKey type operation
  public const ulong TPM_RT_AUTH = ((TPM_RESOURCE_TYPE)0x00000002); /// < The handle is an authorization handle. Auth handles come from TPM_OIAP, TPM_OSAP and TPM_DSAP
  public const ulong TPM_RT_HASH = ((TPM_RESOURCE_TYPE)0x00000003); /// < Reserved for hashes
  public const ulong TPM_RT_TRANS = ((TPM_RESOURCE_TYPE)0x00000004); /// < The handle is for a transport session. Transport handles come from TPM_EstablishTransport
  public const ulong TPM_RT_CONTEXT = ((TPM_RESOURCE_TYPE)0x00000005); /// < Resource wrapped and held outside the TPM using the context save/restore commands
  public const ulong TPM_RT_COUNTER = ((TPM_RESOURCE_TYPE)0x00000006); /// < Reserved for counters
  public const ulong TPM_RT_DELEGATE = ((TPM_RESOURCE_TYPE)0x00000007); /// < The handle is for a delegate row. These are the internal rows held in NV storage by the TPM
  public const ulong TPM_RT_DAA_TPM = ((TPM_RESOURCE_TYPE)0x00000008); /// < The value is a DAA TPM specific blob
  public const ulong TPM_RT_DAA_V0 = ((TPM_RESOURCE_TYPE)0x00000009); /// < The value is a DAA V0 parameter
  public const ulong TPM_RT_DAA_V1 = ((TPM_RESOURCE_TYPE)0x0000000A); /// < The value is a DAA V1 parameter

  //
  // Part 2, section 4.2: TPM_PAYLOAD_TYPE
  //
  public const ulong TPM_PT_ASYM = ((TPM_PAYLOAD_TYPE)0x01); /// < The entity is an asymmetric key
  public const ulong TPM_PT_BIND = ((TPM_PAYLOAD_TYPE)0x02); /// < The entity is bound data
  public const ulong TPM_PT_MIGRATE = ((TPM_PAYLOAD_TYPE)0x03); /// < The entity is a migration blob
  public const ulong TPM_PT_MAINT = ((TPM_PAYLOAD_TYPE)0x04); /// < The entity is a maintenance blob
  public const ulong TPM_PT_SEAL = ((TPM_PAYLOAD_TYPE)0x05); /// < The entity is sealed data
  public const ulong TPM_PT_MIGRATE_RESTRICTED = ((TPM_PAYLOAD_TYPE)0x06); /// < The entity is a restricted-migration asymmetric key
  public const ulong TPM_PT_MIGRATE_EXTERNAL = ((TPM_PAYLOAD_TYPE)0x07); /// < The entity is a external migratable key
  public const ulong TPM_PT_CMK_MIGRATE = ((TPM_PAYLOAD_TYPE)0x08); /// < The entity is a CMK migratable blob
  public const ulong TPM_PT_VENDOR_SPECIFIC = ((TPM_PAYLOAD_TYPE)0x80); /// < 0x80 - 0xFF Vendor specific payloads

  //
  // Part 2, section 4.3: TPM_ENTITY_TYPE
  //
  public const ulong TPM_ET_KEYHANDLE = ((ushort)0x0001); /// < The entity is a keyHandle or key
  public const ulong TPM_ET_OWNER = ((ushort)0x0002); /// < The entity is the TPM Owner
  public const ulong TPM_ET_DATA = ((ushort)0x0003); /// < The entity is some data
  public const ulong TPM_ET_SRK = ((ushort)0x0004); /// < The entity is the SRK
  public const ulong TPM_ET_KEY = ((ushort)0x0005); /// < The entity is a key or keyHandle
  public const ulong TPM_ET_REVOKE = ((ushort)0x0006); /// < The entity is the RevokeTrust value
  public const ulong TPM_ET_DEL_OWNER_BLOB = ((ushort)0x0007); /// < The entity is a delegate owner blob
  public const ulong TPM_ET_DEL_ROW = ((ushort)0x0008); /// < The entity is a delegate row
  public const ulong TPM_ET_DEL_KEY_BLOB = ((ushort)0x0009); /// < The entity is a delegate key blob
  public const ulong TPM_ET_COUNTER = ((ushort)0x000A); /// < The entity is a counter
  public const ulong TPM_ET_NV = ((ushort)0x000B); /// < The entity is a NV index
  public const ulong TPM_ET_OPERATOR = ((ushort)0x000C); /// < The entity is the operator
  public const ulong TPM_ET_RESERVED_HANDLE = ((ushort)0x0040); /// < Reserved. This value avoids collisions with the handle MSB setting.
  //
  // TPM_ENTITY_TYPE MSB Values: The MSB is used to indicate the ADIP encryption sheme when applicable
  //
  public const ulong TPM_ET_XOR = ((ushort)0x0000); /// < ADIP encryption scheme: XOR
  public const ulong TPM_ET_AES128 = ((ushort)0x0006); /// < ADIP encryption scheme: AES 128 bits

  //
  // Part 2, section 4.4.1: Reserved Key Handles
  //
  public const ulong TPM_KH_SRK = ((TPM_KEY_HANDLE)0x40000000); /// < The handle points to the SRK
  public const ulong TPM_KH_OWNER = ((TPM_KEY_HANDLE)0x40000001); /// < The handle points to the TPM Owner
  public const ulong TPM_KH_REVOKE = ((TPM_KEY_HANDLE)0x40000002); /// < The handle points to the RevokeTrust value
  public const ulong TPM_KH_TRANSPORT = ((TPM_KEY_HANDLE)0x40000003); /// < The handle points to the EstablishTransport static authorization
  public const ulong TPM_KH_OPERATOR = ((TPM_KEY_HANDLE)0x40000004); /// < The handle points to the Operator auth
  public const ulong TPM_KH_ADMIN = ((TPM_KEY_HANDLE)0x40000005); /// < The handle points to the delegation administration auth
  public const ulong TPM_KH_EK = ((TPM_KEY_HANDLE)0x40000006); /// < The handle points to the PUBEK, only usable with TPM_OwnerReadInternalPub

  //
  // Part 2, section 4.5: TPM_STARTUP_TYPE
  //
  public const ulong TPM_ST_CLEAR = ((TPM_STARTUP_TYPE)0x0001); /// < The TPM is starting up from a clean state
  public const ulong TPM_ST_STATE = ((TPM_STARTUP_TYPE)0x0002); /// < The TPM is starting up from a saved state
  public const ulong TPM_ST_DEACTIVATED = ((TPM_STARTUP_TYPE)0x0003); /// < The TPM is to startup and set the deactivated flag to TRUE

  //
  // Part 2, section 4.6: TPM_STATUP_EFFECTS
  // The table makeup is still an open issue.
  //

  //
  // Part 2, section 4.7: TPM_PROTOCOL_ID
  //
  public const ulong TPM_PID_OIAP = ((TPM_PROTOCOL_ID)0x0001); /// < The OIAP protocol.
  public const ulong TPM_PID_OSAP = ((TPM_PROTOCOL_ID)0x0002); /// < The OSAP protocol.
  public const ulong TPM_PID_ADIP = ((TPM_PROTOCOL_ID)0x0003); /// < The ADIP protocol.
  public const ulong TPM_PID_ADCP = ((TPM_PROTOCOL_ID)0x0004); /// < The ADCP protocol.
  public const ulong TPM_PID_OWNER = ((TPM_PROTOCOL_ID)0x0005); /// < The protocol for taking ownership of a TPM.
  public const ulong TPM_PID_DSAP = ((TPM_PROTOCOL_ID)0x0006); /// < The DSAP protocol
  public const ulong TPM_PID_TRANSPORT = ((TPM_PROTOCOL_ID)0x0007); /// < The transport protocol

  //
  // Part 2, section 4.8: TPM_ALGORITHM_ID
  //   The TPM MUST support the algorithms TPM_ALG_RSA, TPM_ALG_SHA, TPM_ALG_HMAC,
  //   TPM_ALG_MGF1
  //
  public const ulong TPM_ALG_RSA = ((TPM_ALGORITHM_ID)0x00000001); /// < The RSA algorithm.
  public const ulong TPM_ALG_DES = ((TPM_ALGORITHM_ID)0x00000002); /// < The DES algorithm
  public const ulong TPM_ALG_3DES = ((TPM_ALGORITHM_ID)0x00000003); /// < The 3DES algorithm in EDE mode
  public const ulong TPM_ALG_SHA = ((TPM_ALGORITHM_ID)0x00000004); /// < The SHA1 algorithm
  public const ulong TPM_ALG_HMAC = ((TPM_ALGORITHM_ID)0x00000005); /// < The RFC 2104 HMAC algorithm
  public const ulong TPM_ALG_AES128 = ((TPM_ALGORITHM_ID)0x00000006); /// < The AES algorithm, key size 128
  public const ulong TPM_ALG_MGF1 = ((TPM_ALGORITHM_ID)0x00000007); /// < The XOR algorithm using MGF1 to create a string the size of the encrypted block
  public const ulong TPM_ALG_AES192 = ((TPM_ALGORITHM_ID)0x00000008); /// < AES, key size 192
  public const ulong TPM_ALG_AES256 = ((TPM_ALGORITHM_ID)0x00000009); /// < AES, key size 256
  public const ulong TPM_ALG_XOR = ((TPM_ALGORITHM_ID)0x0000000A); /// < XOR using the rolling nonces

  //
  // Part 2, section 4.9: TPM_PHYSICAL_PRESENCE
  //
  public const ulong TPM_PHYSICAL_PRESENCE_HW_DISABLE = ((TPM_PHYSICAL_PRESENCE)0x0200); /// < Sets the physicalPresenceHWEnable to FALSE
  public const ulong TPM_PHYSICAL_PRESENCE_CMD_DISABLE = ((TPM_PHYSICAL_PRESENCE)0x0100); /// < Sets the physicalPresenceCMDEnable to FALSE
  public const ulong TPM_PHYSICAL_PRESENCE_LIFETIME_LOCK = ((TPM_PHYSICAL_PRESENCE)0x0080); /// < Sets the physicalPresenceLifetimeLock to TRUE
  public const ulong TPM_PHYSICAL_PRESENCE_HW_ENABLE = ((TPM_PHYSICAL_PRESENCE)0x0040); /// < Sets the physicalPresenceHWEnable to TRUE
  public const ulong TPM_PHYSICAL_PRESENCE_CMD_ENABLE = ((TPM_PHYSICAL_PRESENCE)0x0020); /// < Sets the physicalPresenceCMDEnable to TRUE
  public const ulong TPM_PHYSICAL_PRESENCE_NOTPRESENT = ((TPM_PHYSICAL_PRESENCE)0x0010); /// < Sets PhysicalPresence = FALSE
  public const ulong TPM_PHYSICAL_PRESENCE_PRESENT = ((TPM_PHYSICAL_PRESENCE)0x0008); /// < Sets PhysicalPresence = TRUE
  public const ulong TPM_PHYSICAL_PRESENCE_LOCK = ((TPM_PHYSICAL_PRESENCE)0x0004); /// < Sets PhysicalPresenceLock = TRUE

  //
  // Part 2, section 4.10: TPM_MIGRATE_SCHEME
  //
  public const ulong TPM_MS_MIGRATE = ((TPM_MIGRATE_SCHEME)0x0001); /// < A public key that can be used with all TPM migration commands other than 'ReWrap' mode.
  public const ulong TPM_MS_REWRAP = ((TPM_MIGRATE_SCHEME)0x0002); /// < A public key that can be used for the ReWrap mode of TPM_CreateMigrationBlob.
  public const ulong TPM_MS_MAINT = ((TPM_MIGRATE_SCHEME)0x0003); /// < A public key that can be used for the Maintenance commands
  public const ulong TPM_MS_RESTRICT_MIGRATE = ((TPM_MIGRATE_SCHEME)0x0004); /// < The key is to be migrated to a Migration Authority.
  public const ulong TPM_MS_RESTRICT_APPROVE_DOUBLE = ((TPM_MIGRATE_SCHEME)0x0005); /// < The key is to be migrated to an entity approved by a Migration Authority using double wrapping

  //
  // Part 2, section 4.11: TPM_EK_TYPE
  //
  public const ulong TPM_EK_TYPE_ACTIVATE = ((TPM_EK_TYPE)0x0001); /// < The blob MUST be TPM_EK_BLOB_ACTIVATE
  public const ulong TPM_EK_TYPE_AUTH = ((TPM_EK_TYPE)0x0002); /// < The blob MUST be TPM_EK_BLOB_AUTH

  //
  // Part 2, section 4.12: TPM_PLATFORM_SPECIFIC
  //
  public const ulong TPM_PS_PC_11 = ((TPM_PLATFORM_SPECIFIC)0x0001); /// < PC Specific version 1.1
  public const ulong TPM_PS_PC_12 = ((TPM_PLATFORM_SPECIFIC)0x0002); /// < PC Specific version 1.2
  public const ulong TPM_PS_PDA_12 = ((TPM_PLATFORM_SPECIFIC)0x0003); /// < PDA Specific version 1.2
  public const ulong TPM_PS_Server_12 = ((TPM_PLATFORM_SPECIFIC)0x0004); /// < Server Specific version 1.2
  public const ulong TPM_PS_Mobile_12 = ((TPM_PLATFORM_SPECIFIC)0x0005); /// < Mobil Specific version 1.2

  //
  // Part 2, section 5: Basic Structures
  //
}

///
/// Part 2, section 5.1: TPM_STRUCT_VER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STRUCT_VER
{
  public byte major;
  public byte minor;
  public byte revMajor;
  public byte revMinor;
}

///
/// Part 2, section 5.3: TPM_VERSION
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_VERSION
{
  public TPM_VERSION_BYTE major;
  public TPM_VERSION_BYTE minor;
  public byte revMajor;
  public byte revMinor;
}

public unsafe partial class EFI
{
  public const ulong TPM_SHA1_160_HASH_LEN = 0x14;
  public const ulong TPM_SHA1BASED_NONCE_LEN = TPM_SHA1_160_HASH_LEN;
}

///
/// Part 2, section 5.4: TPM_DIGEST
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DIGEST
{
  public fixed byte digest[TPM_SHA1_160_HASH_LEN];
}

///
/// This SHALL be the digest of the chosen identityLabel and privacyCA for a new TPM identity
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CHOSENID_HASH { TPM_DIGEST Value; public static implicit operator TPM_CHOSENID_HASH(TPM_DIGEST value) => new TPM_CHOSENID_HASH() { Value = value }; public static implicit operator TPM_DIGEST(TPM_CHOSENID_HASH value) => value.Value; }
///
/// This SHALL be the hash of a list of PCR indexes and PCR values that a key or data is bound to
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_COMPOSITE_HASH { TPM_DIGEST Value; public static implicit operator TPM_COMPOSITE_HASH(TPM_DIGEST value) => new TPM_COMPOSITE_HASH() { Value = value }; public static implicit operator TPM_DIGEST(TPM_COMPOSITE_HASH value) => value.Value; }
///
/// This SHALL be the value of a DIR register
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DIRVALUE { TPM_DIGEST Value; public static implicit operator TPM_DIRVALUE(TPM_DIGEST value) => new TPM_DIRVALUE() { Value = value }; public static implicit operator TPM_DIGEST(TPM_DIRVALUE value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_HMAC { TPM_DIGEST Value; public static implicit operator TPM_HMAC(TPM_DIGEST value) => new TPM_HMAC() { Value = value }; public static implicit operator TPM_DIGEST(TPM_HMAC value) => value.Value; }
///
/// The value inside of the PCR
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PCRVALUE { TPM_DIGEST Value; public static implicit operator TPM_PCRVALUE(TPM_DIGEST value) => new TPM_PCRVALUE() { Value = value }; public static implicit operator TPM_DIGEST(TPM_PCRVALUE value) => value.Value; }
///
/// This SHALL be the value of the current internal audit state
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_AUDITDIGEST { TPM_DIGEST Value; public static implicit operator TPM_AUDITDIGEST(TPM_DIGEST value) => new TPM_AUDITDIGEST() { Value = value }; public static implicit operator TPM_DIGEST(TPM_AUDITDIGEST value) => value.Value; }

///
/// Part 2, section 5.5: TPM_NONCE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_NONCE
{
  public fixed byte nonce[20];
}

///
/// This SHALL be a random value generated by a TPM immediately after the EK is installed
/// in that TPM, whenever an EK is installed in that TPM
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DAA_TPM_SEED { TPM_NONCE Value; public static implicit operator TPM_DAA_TPM_SEED(TPM_NONCE value) => new TPM_DAA_TPM_SEED() { Value = value }; public static implicit operator TPM_NONCE(TPM_DAA_TPM_SEED value) => value.Value; }
///
/// This SHALL be a random value
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DAA_CONTEXT_SEED { TPM_NONCE Value; public static implicit operator TPM_DAA_CONTEXT_SEED(TPM_NONCE value) => new TPM_DAA_CONTEXT_SEED() { Value = value }; public static implicit operator TPM_NONCE(TPM_DAA_CONTEXT_SEED value) => value.Value; }

//
// Part 2, section 5.6: TPM_AUTHDATA
//
///
/// The AuthData data is the information that is saved or passed to provide proof of ownership
/// 296 of an entity
///
typedef byte tdTPM_AUTHDATA[20];

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_AUTHDATA { tdTPM_AUTHDATA Value; public static implicit operator TPM_AUTHDATA(tdTPM_AUTHDATA value) => new TPM_AUTHDATA() { Value = value }; public static implicit operator tdTPM_AUTHDATA(TPM_AUTHDATA value) => value.Value; }
///
/// A secret plaintext value used in the authorization process
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_SECRET { TPM_AUTHDATA Value; public static implicit operator TPM_SECRET(TPM_AUTHDATA value) => new TPM_SECRET() { Value = value }; public static implicit operator TPM_AUTHDATA(TPM_SECRET value) => value.Value; }
///
/// A ciphertext (encrypted) version of AuthData data. The encryption mechanism depends on the context
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_ENCAUTH { TPM_AUTHDATA Value; public static implicit operator TPM_ENCAUTH(TPM_AUTHDATA value) => new TPM_ENCAUTH() { Value = value }; public static implicit operator TPM_AUTHDATA(TPM_ENCAUTH value) => value.Value; }

///
/// Part 2, section 5.7: TPM_KEY_HANDLE_LIST
/// Size of handle is loaded * sizeof(TPM_KEY_HANDLE)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_KEY_HANDLE_LIST
{
  public ushort loaded;
  public fixed TPM_KEY_HANDLE handle[1];
}

public unsafe partial class EFI
{
  //
  // Part 2, section 5.8: TPM_KEY_USAGE values
  //
  ///
  /// TPM_KEY_SIGNING SHALL indicate a signing key. The [private] key SHALL be
  /// used for signing operations, only. This means that it MUST be a leaf of the
  /// Protected Storage key hierarchy.
  ///
  public const ulong TPM_KEY_SIGNING = ((ushort)0x0010);
  ///
  /// TPM_KEY_STORAGE SHALL indicate a storage key. The key SHALL be used to wrap
  /// and unwrap other keys in the Protected Storage hierarchy
  ///
  public const ulong TPM_KEY_STORAGE = ((ushort)0x0011);
  ///
  /// TPM_KEY_IDENTITY SHALL indicate an identity key. The key SHALL be used for
  /// operations that require a TPM identity, only.
  ///
  public const ulong TPM_KEY_IDENTITY = ((ushort)0x0012);
  ///
  /// TPM_KEY_AUTHCHANGE SHALL indicate an ephemeral key that is in use during
  /// the ChangeAuthAsym process, only.
  ///
  public const ulong TPM_KEY_AUTHCHANGE = ((ushort)0x0013);
  ///
  /// TPM_KEY_BIND SHALL indicate a key that can be used for TPM_Bind and
  /// TPM_Unbind operations only.
  ///
  public const ulong TPM_KEY_BIND = ((ushort)0x0014);
  ///
  /// TPM_KEY_LEGACY SHALL indicate a key that can perform signing and binding
  /// operations. The key MAY be used for both signing and binding operations.
  /// The TPM_KEY_LEGACY key type is to allow for use by applications where both
  /// signing and encryption operations occur with the same key. The use of this
  /// key type is not recommended TPM_KEY_MIGRATE 0x0016 This SHALL indicate a
  /// key in use for TPM_MigrateKey
  ///
  public const ulong TPM_KEY_LEGACY = ((ushort)0x0015);
  ///
  /// TPM_KEY_MIGRAGE SHALL indicate a key in use for TPM_MigrateKey
  ///
  public const ulong TPM_KEY_MIGRATE = ((ushort)0x0016);

  //
  // Part 2, section 5.8.1: Mandatory Key Usage Schemes
  //

  public const ulong TPM_ES_NONE = ((TPM_ENC_SCHEME)0x0001);
  public const ulong TPM_ES_RSAESPKCSv15 = ((TPM_ENC_SCHEME)0x0002);
  public const ulong TPM_ES_RSAESOAEP_SHA1_MGF1 = ((TPM_ENC_SCHEME)0x0003);
  public const ulong TPM_ES_SYM_CNT = ((TPM_ENC_SCHEME)0x0004); /// < rev94 defined
  public const ulong TPM_ES_SYM_CTR = ((TPM_ENC_SCHEME)0x0004);
  public const ulong TPM_ES_SYM_OFB = ((TPM_ENC_SCHEME)0x0005);

  public const ulong TPM_SS_NONE = ((TPM_SIG_SCHEME)0x0001);
  public const ulong TPM_SS_RSASSAPKCS1v15_SHA1 = ((TPM_SIG_SCHEME)0x0002);
  public const ulong TPM_SS_RSASSAPKCS1v15_DER = ((TPM_SIG_SCHEME)0x0003);
  public const ulong TPM_SS_RSASSAPKCS1v15_INFO = ((TPM_SIG_SCHEME)0x0004);

  //
  // Part 2, section 5.9: TPM_AUTH_DATA_USAGE values
  //
  public const ulong TPM_AUTH_NEVER = ((TPM_AUTH_DATA_USAGE)0x00);
  public const ulong TPM_AUTH_ALWAYS = ((TPM_AUTH_DATA_USAGE)0x01);
  public const ulong TPM_AUTH_PRIV_USE_ONLY = ((TPM_AUTH_DATA_USAGE)0x03);
}

///
/// Part 2, section 5.10: TPM_KEY_FLAGS
///
public enum TPM_KEY_FLAGS_BITS
{
  redirection = 0x00000001,
  migratable = 0x00000002,
  isVolatile = 0x00000004,
  pcrIgnoredOnRead = 0x00000008,
  migrateAuthority = 0x00000010
}

///
/// Part 2, section 5.11: TPM_CHANGEAUTH_VALIDATE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CHANGEAUTH_VALIDATE
{
  public TPM_SECRET newAuthSecret;
  public TPM_NONCE n1;
}

///
/// Part 2, section 5.12: TPM_MIGRATIONKEYAUTH
///   declared after section 10 to catch declaration of TPM_PUBKEY
///
/// Part 2 section 10.1: TPM_KEY_PARMS
///   [size_is(parmSize)] BYTE* parms;
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_KEY_PARMS
{
  public TPM_ALGORITHM_ID algorithmID;
  public TPM_ENC_SCHEME encScheme;
  public TPM_SIG_SCHEME sigScheme;
  public uint parmSize;
  public byte* parms;
}

///
/// Part 2, section 10.4: TPM_STORE_PUBKEY
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STORE_PUBKEY
{
  public uint keyLength;
  public fixed byte key[1];
}

///
/// Part 2, section 10.5: TPM_PUBKEY
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PUBKEY
{
  public TPM_KEY_PARMS algorithmParms;
  public TPM_STORE_PUBKEY pubKey;
}

///
/// Part 2, section 5.12: TPM_MIGRATIONKEYAUTH
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_MIGRATIONKEYAUTH
{
  public TPM_PUBKEY migrationKey;
  public TPM_MIGRATE_SCHEME migrationScheme;
  public TPM_DIGEST digest;
}

///
/// Part 2, section 5.13: TPM_COUNTER_VALUE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_COUNTER_VALUE
{
  public TPM_STRUCTURE_TAG tag;
  public fixed byte label[4];
  public TPM_ACTUAL_COUNT counter;
}

///
/// Part 2, section 5.14: TPM_SIGN_INFO
///   Size of data indicated by dataLen
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_SIGN_INFO
{
  public TPM_STRUCTURE_TAG tag;
  public fixed byte                fixed[4];
  public TPM_NONCE replay;
  public uint dataLen;
  public byte* data;
}

///
/// Part 2, section 5.15: TPM_MSA_COMPOSITE
///   Number of migAuthDigest indicated by MSAlist
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_MSA_COMPOSITE
{
  public uint MSAlist;
  public fixed TPM_DIGEST migAuthDigest[1];
}

///
/// Part 2, section 5.16: TPM_CMK_AUTH
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CMK_AUTH
{
  public TPM_DIGEST migrationAuthorityDigest;
  public TPM_DIGEST destinationKeyDigest;
  public TPM_DIGEST sourceKeyDigest;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 5.17: TPM_CMK_DELEGATE
  //
  public const ulong TPM_CMK_DELEGATE_SIGNING = ((TPM_CMK_DELEGATE)BIT31);
  public const ulong TPM_CMK_DELEGATE_STORAGE = ((TPM_CMK_DELEGATE)BIT30);
  public const ulong TPM_CMK_DELEGATE_BIND = ((TPM_CMK_DELEGATE)BIT29);
  public const ulong TPM_CMK_DELEGATE_LEGACY = ((TPM_CMK_DELEGATE)BIT28);
  public const ulong TPM_CMK_DELEGATE_MIGRATE = ((TPM_CMK_DELEGATE)BIT27);
}

///
/// Part 2, section 5.18: TPM_SELECT_SIZE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_SELECT_SIZE
{
  public byte major;
  public byte minor;
  public ushort reqSize;
}

///
/// Part 2, section 5,19: TPM_CMK_MIGAUTH
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CMK_MIGAUTH
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DIGEST msaDigest;
  public TPM_DIGEST pubKeyDigest;
}

///
/// Part 2, section 5.20: TPM_CMK_SIGTICKET
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CMK_SIGTICKET
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DIGEST verKeyDigest;
  public TPM_DIGEST signedData;
}

///
/// Part 2, section 5.21: TPM_CMK_MA_APPROVAL
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CMK_MA_APPROVAL
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DIGEST migrationAuthorityDigest;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 6: Command Tags
  //
  public const ulong TPM_TAG_RQU_COMMAND = ((TPM_STRUCTURE_TAG)0x00C1);
  public const ulong TPM_TAG_RQU_AUTH1_COMMAND = ((TPM_STRUCTURE_TAG)0x00C2);
  public const ulong TPM_TAG_RQU_AUTH2_COMMAND = ((TPM_STRUCTURE_TAG)0x00C3);
  public const ulong TPM_TAG_RSP_COMMAND = ((TPM_STRUCTURE_TAG)0x00C4);
  public const ulong TPM_TAG_RSP_AUTH1_COMMAND = ((TPM_STRUCTURE_TAG)0x00C5);
  public const ulong TPM_TAG_RSP_AUTH2_COMMAND = ((TPM_STRUCTURE_TAG)0x00C6);
}

///
/// Part 2, section 7.1: TPM_PERMANENT_FLAGS
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PERMANENT_FLAGS
{
  public TPM_STRUCTURE_TAG tag;
  public bool disable;
  public bool ownership;
  public bool deactivated;
  public bool readPubek;
  public bool disableOwnerClear;
  public bool allowMaintenance;
  public bool physicalPresenceLifetimeLock;
  public bool physicalPresenceHWEnable;
  public bool physicalPresenceCMDEnable;
  public bool CEKPUsed;
  public bool TPMpost;
  public bool TPMpostLock;
  public bool FIPS;
  public bool operator;
  public bool enableRevokeEK;
  public bool nvLocked;
  public bool readSRKPub;
  public bool tpmEstablished;
  public bool maintenanceDone;
  public bool disableFullDALogicInfo;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 7.1.1: Flag Restrictions (of TPM_PERMANENT_FLAGS)
  //
  public const ulong TPM_PF_DISABLE = ((TPM_CAPABILITY_AREA)1);
  public const ulong TPM_PF_OWNERSHIP = ((TPM_CAPABILITY_AREA)2);
  public const ulong TPM_PF_DEACTIVATED = ((TPM_CAPABILITY_AREA)3);
  public const ulong TPM_PF_READPUBEK = ((TPM_CAPABILITY_AREA)4);
  public const ulong TPM_PF_DISABLEOWNERCLEAR = ((TPM_CAPABILITY_AREA)5);
  public const ulong TPM_PF_ALLOWMAINTENANCE = ((TPM_CAPABILITY_AREA)6);
  public const ulong TPM_PF_PHYSICALPRESENCELIFETIMELOCK = ((TPM_CAPABILITY_AREA)7);
  public const ulong TPM_PF_PHYSICALPRESENCEHWENABLE = ((TPM_CAPABILITY_AREA)8);
  public const ulong TPM_PF_PHYSICALPRESENCECMDENABLE = ((TPM_CAPABILITY_AREA)9);
  public const ulong TPM_PF_CEKPUSED = ((TPM_CAPABILITY_AREA)10);
  public const ulong TPM_PF_TPMPOST = ((TPM_CAPABILITY_AREA)11);
  public const ulong TPM_PF_TPMPOSTLOCK = ((TPM_CAPABILITY_AREA)12);
  public const ulong TPM_PF_FIPS = ((TPM_CAPABILITY_AREA)13);
  public const ulong TPM_PF_OPERATOR = ((TPM_CAPABILITY_AREA)14);
  public const ulong TPM_PF_ENABLEREVOKEEK = ((TPM_CAPABILITY_AREA)15);
  public const ulong TPM_PF_NV_LOCKED = ((TPM_CAPABILITY_AREA)16);
  public const ulong TPM_PF_READSRKPUB = ((TPM_CAPABILITY_AREA)17);
  public const ulong TPM_PF_TPMESTABLISHED = ((TPM_CAPABILITY_AREA)18);
  public const ulong TPM_PF_MAINTENANCEDONE = ((TPM_CAPABILITY_AREA)19);
  public const ulong TPM_PF_DISABLEFULLDALOGICINFO = ((TPM_CAPABILITY_AREA)20);
}

///
/// Part 2, section 7.2: TPM_STCLEAR_FLAGS
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STCLEAR_FLAGS
{
  public TPM_STRUCTURE_TAG tag;
  public bool deactivated;
  public bool disableForceClear;
  public bool physicalPresence;
  public bool physicalPresenceLock;
  public bool bGlobalLock;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 7.2.1: Flag Restrictions (of TPM_STCLEAR_FLAGS)
  //
  public const ulong TPM_SF_DEACTIVATED = ((TPM_CAPABILITY_AREA)1);
  public const ulong TPM_SF_DISABLEFORCECLEAR = ((TPM_CAPABILITY_AREA)2);
  public const ulong TPM_SF_PHYSICALPRESENCE = ((TPM_CAPABILITY_AREA)3);
  public const ulong TPM_SF_PHYSICALPRESENCELOCK = ((TPM_CAPABILITY_AREA)4);
  public const ulong TPM_SF_BGLOBALLOCK = ((TPM_CAPABILITY_AREA)5);
}

///
/// Part 2, section 7.3: TPM_STANY_FLAGS
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STANY_FLAGS
{
  public TPM_STRUCTURE_TAG tag;
  public bool postInitialise;
  public TPM_MODIFIER_INDICATOR localityModifier;
  public bool transportExclusive;
  public bool TOSPresent;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 7.3.1: Flag Restrictions (of TPM_STANY_FLAGS)
  //
  public const ulong TPM_AF_POSTINITIALISE = ((TPM_CAPABILITY_AREA)1);
  public const ulong TPM_AF_LOCALITYMODIFIER = ((TPM_CAPABILITY_AREA)2);
  public const ulong TPM_AF_TRANSPORTEXCLUSIVE = ((TPM_CAPABILITY_AREA)3);
  public const ulong TPM_AF_TOSPRESENT = ((TPM_CAPABILITY_AREA)4);

  //
  // All those structures defined in section 7.4, 7.5, 7.6 are not normative and
  // thus no definitions here
  //
  // Part 2, section 7.4: TPM_PERMANENT_DATA
  //
  public const ulong TPM_MIN_COUNTERS = 4; /// < the minimum number of counters is 4
  public const ulong TPM_DELEGATE_KEY = TPM_KEY;
  public const ulong TPM_NUM_PCR = 16;
  public const ulong TPM_MAX_NV_WRITE_NOOWNER = 64;

  //
  // Part 2, section 7.4.1: PERMANENT_DATA Subcap for SetCapability
  //
  public const ulong TPM_PD_REVMAJOR = ((TPM_CAPABILITY_AREA)1);
  public const ulong TPM_PD_REVMINOR = ((TPM_CAPABILITY_AREA)2);
  public const ulong TPM_PD_TPMPROOF = ((TPM_CAPABILITY_AREA)3);
  public const ulong TPM_PD_OWNERAUTH = ((TPM_CAPABILITY_AREA)4);
  public const ulong TPM_PD_OPERATORAUTH = ((TPM_CAPABILITY_AREA)5);
  public const ulong TPM_PD_MANUMAINTPUB = ((TPM_CAPABILITY_AREA)6);
  public const ulong TPM_PD_ENDORSEMENTKEY = ((TPM_CAPABILITY_AREA)7);
  public const ulong TPM_PD_SRK = ((TPM_CAPABILITY_AREA)8);
  public const ulong TPM_PD_DELEGATEKEY = ((TPM_CAPABILITY_AREA)9);
  public const ulong TPM_PD_CONTEXTKEY = ((TPM_CAPABILITY_AREA)10);
  public const ulong TPM_PD_AUDITMONOTONICCOUNTER = ((TPM_CAPABILITY_AREA)11);
  public const ulong TPM_PD_MONOTONICCOUNTER = ((TPM_CAPABILITY_AREA)12);
  public const ulong TPM_PD_PCRATTRIB = ((TPM_CAPABILITY_AREA)13);
  public const ulong TPM_PD_ORDINALAUDITSTATUS = ((TPM_CAPABILITY_AREA)14);
  public const ulong TPM_PD_AUTHDIR = ((TPM_CAPABILITY_AREA)15);
  public const ulong TPM_PD_RNGSTATE = ((TPM_CAPABILITY_AREA)16);
  public const ulong TPM_PD_FAMILYTABLE = ((TPM_CAPABILITY_AREA)17);
  public const ulong TPM_DELEGATETABLE = ((TPM_CAPABILITY_AREA)18);
  public const ulong TPM_PD_EKRESET = ((TPM_CAPABILITY_AREA)19);
  public const ulong TPM_PD_MAXNVBUFSIZE = ((TPM_CAPABILITY_AREA)20);
  public const ulong TPM_PD_LASTFAMILYID = ((TPM_CAPABILITY_AREA)21);
  public const ulong TPM_PD_NOOWNERNVWRITE = ((TPM_CAPABILITY_AREA)22);
  public const ulong TPM_PD_RESTRICTDELEGATE = ((TPM_CAPABILITY_AREA)23);
  public const ulong TPM_PD_TPMDAASEED = ((TPM_CAPABILITY_AREA)24);
  public const ulong TPM_PD_DAAPROOF = ((TPM_CAPABILITY_AREA)25);
}

///
/// Part 2, section 7.5: TPM_STCLEAR_DATA
///   available inside TPM only
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STCLEAR_DATA
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_NONCE contextNonceKey;
  public TPM_COUNT_ID countID;
  public uint ownerReference;
  public bool disableResetLock;
  public fixed TPM_PCRVALUE PCR[TPM_NUM_PCR];
  public uint deferredPhysicalPresence;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 7.5.1: STCLEAR_DATA Subcap for SetCapability
  //
  public const ulong TPM_SD_CONTEXTNONCEKEY = ((TPM_CAPABILITY_AREA)0x00000001);
  public const ulong TPM_SD_COUNTID = ((TPM_CAPABILITY_AREA)0x00000002);
  public const ulong TPM_SD_OWNERREFERENCE = ((TPM_CAPABILITY_AREA)0x00000003);
  public const ulong TPM_SD_DISABLERESETLOCK = ((TPM_CAPABILITY_AREA)0x00000004);
  public const ulong TPM_SD_PCR = ((TPM_CAPABILITY_AREA)0x00000005);
  public const ulong TPM_SD_DEFERREDPHYSICALPRESENCE = ((TPM_CAPABILITY_AREA)0x00000006);

  //
  // Part 2, section 7.6.1: STANY_DATA Subcap for SetCapability
  //
  public const ulong TPM_AD_CONTEXTNONCESESSION = ((TPM_CAPABILITY_AREA)1);
  public const ulong TPM_AD_AUDITDIGEST = ((TPM_CAPABILITY_AREA)2);
  public const ulong TPM_AD_CURRENTTICKS = ((TPM_CAPABILITY_AREA)3);
  public const ulong TPM_AD_CONTEXTCOUNT = ((TPM_CAPABILITY_AREA)4);
  public const ulong TPM_AD_CONTEXTLIST = ((TPM_CAPABILITY_AREA)5);
  public const ulong TPM_AD_SESSIONS = ((TPM_CAPABILITY_AREA)6);

  //
  // Part 2, section 8: PCR Structures
  //
}

///
/// Part 2, section 8.1: TPM_PCR_SELECTION
///   Size of pcrSelect[] indicated by sizeOfSelect
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PCR_SELECTION
{
  public ushort sizeOfSelect;
  public fixed byte pcrSelect[1];
}

///
/// Part 2, section 8.2: TPM_PCR_COMPOSITE
///   Size of pcrValue[] indicated by valueSize
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PCR_COMPOSITE
{
  public TPM_PCR_SELECTION select;
  public uint valueSize;
  public fixed TPM_PCRVALUE pcrValue[1];
}

///
/// Part 2, section 8.3: TPM_PCR_INFO
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PCR_INFO
{
  public TPM_PCR_SELECTION pcrSelection;
  public TPM_COMPOSITE_HASH digestAtRelease;
  public TPM_COMPOSITE_HASH digestAtCreation;
}

///
/// Part 2, section 8.6: TPM_LOCALITY_SELECTION
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_LOCALITY_SELECTION { byte Value; public static implicit operator TPM_LOCALITY_SELECTION(byte value) => new TPM_LOCALITY_SELECTION() { Value = value }; public static implicit operator byte(TPM_LOCALITY_SELECTION value) => value.Value; }

public unsafe partial class EFI
{
  public const ulong TPM_LOC_FOUR = ((byte)0x10);
  public const ulong TPM_LOC_THREE = ((byte)0x08);
  public const ulong TPM_LOC_TWO = ((byte)0x04);
  public const ulong TPM_LOC_ONE = ((byte)0x02);
  public const ulong TPM_LOC_ZERO = ((byte)0x01);
}

///
/// Part 2, section 8.4: TPM_PCR_INFO_LONG
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PCR_INFO_LONG
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_LOCALITY_SELECTION localityAtCreation;
  public TPM_LOCALITY_SELECTION localityAtRelease;
  public TPM_PCR_SELECTION creationPCRSelection;
  public TPM_PCR_SELECTION releasePCRSelection;
  public TPM_COMPOSITE_HASH digestAtCreation;
  public TPM_COMPOSITE_HASH digestAtRelease;
}

///
/// Part 2, section 8.5: TPM_PCR_INFO_SHORT
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PCR_INFO_SHORT
{
  public TPM_PCR_SELECTION pcrSelection;
  public TPM_LOCALITY_SELECTION localityAtRelease;
  public TPM_COMPOSITE_HASH digestAtRelease;
}

///
/// Part 2, section 8.8: TPM_PCR_ATTRIBUTES
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PCR_ATTRIBUTES
{
  public bool pcrReset;
  public TPM_LOCALITY_SELECTION pcrExtendLocal;
  public TPM_LOCALITY_SELECTION pcrResetLocal;
}

//
// Part 2, section 9: Storage Structures
//

///
/// Part 2, section 9.1: TPM_STORED_DATA
///   [size_is(sealInfoSize)] BYTE* sealInfo;
///   [size_is(encDataSize)] BYTE* encData;
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STORED_DATA
{
  public TPM_STRUCT_VER ver;
  public uint sealInfoSize;
  public byte* sealInfo;
  public uint encDataSize;
  public byte* encData;
}

///
/// Part 2, section 9.2: TPM_STORED_DATA12
///   [size_is(sealInfoSize)] BYTE* sealInfo;
///   [size_is(encDataSize)] BYTE* encData;
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STORED_DATA12
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_ENTITY_TYPE et;
  public uint sealInfoSize;
  public byte* sealInfo;
  public uint encDataSize;
  public byte* encData;
}

///
/// Part 2, section 9.3: TPM_SEALED_DATA
///   [size_is(dataSize)] BYTE* data;
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_SEALED_DATA
{
  public TPM_PAYLOAD_TYPE payload;
  public TPM_SECRET authData;
  public TPM_NONCE tpmProof;
  public TPM_DIGEST storedDigest;
  public uint dataSize;
  public byte* data;
}

///
/// Part 2, section 9.4: TPM_SYMMETRIC_KEY
///   [size_is(size)] BYTE* data;
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_SYMMETRIC_KEY
{
  public TPM_ALGORITHM_ID algId;
  public TPM_ENC_SCHEME encScheme;
  public ushort dataSize;
  public byte* data;
}

///
/// Part 2, section 9.5: TPM_BOUND_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_BOUND_DATA
{
  public TPM_STRUCT_VER ver;
  public TPM_PAYLOAD_TYPE payload;
  public fixed byte payloadData[1];
}

//
// Part 2 section 10: TPM_KEY complex
//

//
// Section 10.1, 10.4, and 10.5 have been defined previously
//

///
/// Part 2, section 10.2: TPM_KEY
///   [size_is(encDataSize)] BYTE* encData;
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_KEY
{
  public TPM_STRUCT_VER ver;
  public TPM_KEY_USAGE keyUsage;
  public TPM_KEY_FLAGS keyFlags;
  public TPM_AUTH_DATA_USAGE authDataUsage;
  public TPM_KEY_PARMS algorithmParms;
  public uint PCRInfoSize;
  public byte* PCRInfo;
  public TPM_STORE_PUBKEY pubKey;
  public uint encDataSize;
  public byte* encData;
}

///
/// Part 2, section 10.3: TPM_KEY12
///   [size_is(encDataSize)] BYTE* encData;
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_KEY12
{
  public TPM_STRUCTURE_TAG tag;
  public ushort fill;
  public TPM_KEY_USAGE keyUsage;
  public TPM_KEY_FLAGS keyFlags;
  public TPM_AUTH_DATA_USAGE authDataUsage;
  public TPM_KEY_PARMS algorithmParms;
  public uint PCRInfoSize;
  public byte* PCRInfo;
  public TPM_STORE_PUBKEY pubKey;
  public uint encDataSize;
  public byte* encData;
}

///
/// Part 2, section 10.7: TPM_STORE_PRIVKEY
///   [size_is(keyLength)] BYTE* key;
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STORE_PRIVKEY
{
  public uint keyLength;
  public byte* key;
}

///
/// Part 2, section 10.6: TPM_STORE_ASYMKEY
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_STORE_ASYMKEY
{
  // pos len total
  public TPM_PAYLOAD_TYPE payload;                     // 0    1   1
  public TPM_SECRET usageAuth;                   // 1    20  21
  public TPM_SECRET migrationAuth;               // 21   20  41
  public TPM_DIGEST pubDataDigest;               // 41   20  61
  public TPM_STORE_PRIVKEY privKey;                     // 61 132-151 193-214
}

///
/// Part 2, section 10.8: TPM_MIGRATE_ASYMKEY
///   [size_is(partPrivKeyLen)] BYTE* partPrivKey;
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_MIGRATE_ASYMKEY
{
  // pos  len  total
  public TPM_PAYLOAD_TYPE payload;                      //   0    1       1
  public TPM_SECRET usageAuth;                    //   1   20      21
  public TPM_DIGEST pubDataDigest;                //  21   20      41
  public uint partPrivKeyLen;               //  41    4      45
  public byte* partPrivKey;                 //  45 112-127 157-172
}

public unsafe partial class EFI
{
  ///
  /// Part 2, section 10.9: TPM_KEY_CONTROL
  ///
  public const ulong TPM_KEY_CONTROL_OWNER_EVICT = ((uint)0x00000001);

  //
  // Part 2, section 11: Signed Structures
  //
}

///
/// Part 2, section 11.1: TPM_CERTIFY_INFO Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CERTIFY_INFO
{
  public TPM_STRUCT_VER version;
  public TPM_KEY_USAGE keyUsage;
  public TPM_KEY_FLAGS keyFlags;
  public TPM_AUTH_DATA_USAGE authDataUsage;
  public TPM_KEY_PARMS algorithmParms;
  public TPM_DIGEST pubkeyDigest;
  public TPM_NONCE data;
  public bool parentPCRStatus;
  public uint PCRInfoSize;
  public byte* PCRInfo;
}

///
/// Part 2, section 11.2: TPM_CERTIFY_INFO2 Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CERTIFY_INFO2
{
  public TPM_STRUCTURE_TAG tag;
  public byte fill;
  public TPM_PAYLOAD_TYPE payloadType;
  public TPM_KEY_USAGE keyUsage;
  public TPM_KEY_FLAGS keyFlags;
  public TPM_AUTH_DATA_USAGE authDataUsage;
  public TPM_KEY_PARMS algorithmParms;
  public TPM_DIGEST pubkeyDigest;
  public TPM_NONCE data;
  public bool parentPCRStatus;
  public uint PCRInfoSize;
  public byte* PCRInfo;
  public uint migrationAuthoritySize;
  public byte* migrationAuthority;
}

///
/// Part 2, section 11.3 TPM_QUOTE_INFO Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_QUOTE_INFO
{
  public TPM_STRUCT_VER version;
  public fixed byte                 fixed[4];
  public TPM_COMPOSITE_HASH digestValue;
  public TPM_NONCE externalData;
}

///
/// Part 2, section 11.4 TPM_QUOTE_INFO2 Structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_QUOTE_INFO2
{
  public TPM_STRUCTURE_TAG tag;
  public fixed byte                 fixed[4];
  public TPM_NONCE externalData;
  public TPM_PCR_INFO_SHORT infoShort;
}

//
// Part 2, section 12: Identity Structures
//

///
/// Part 2, section 12.1 TPM_EK_BLOB
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_EK_BLOB
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_EK_TYPE ekType;
  public uint blobSize;
  public byte* blob;
}

///
/// Part 2, section 12.2 TPM_EK_BLOB_ACTIVATE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_EK_BLOB_ACTIVATE
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_SYMMETRIC_KEY sessionKey;
  public TPM_DIGEST idDigest;
  public TPM_PCR_INFO_SHORT pcrInfo;
}

///
/// Part 2, section 12.3 TPM_EK_BLOB_AUTH
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_EK_BLOB_AUTH
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_SECRET authValue;
}

///
/// Part 2, section 12.5 TPM_IDENTITY_CONTENTS
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_IDENTITY_CONTENTS
{
  public TPM_STRUCT_VER ver;
  public uint ordinal;
  public TPM_CHOSENID_HASH labelPrivCADigest;
  public TPM_PUBKEY identityPubKey;
}

///
/// Part 2, section 12.6 TPM_IDENTITY_REQ
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_IDENTITY_REQ
{
  public uint asymSize;
  public uint symSize;
  public TPM_KEY_PARMS asymAlgorithm;
  public TPM_KEY_PARMS symAlgorithm;
  public byte* asymBlob;
  public byte* symBlob;
}

///
/// Part 2, section 12.7 TPM_IDENTITY_PROOF
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_IDENTITY_PROOF
{
  public TPM_STRUCT_VER ver;
  public uint labelSize;
  public uint identityBindingSize;
  public uint endorsementSize;
  public uint platformSize;
  public uint conformanceSize;
  public TPM_PUBKEY identityKey;
  public byte* labelArea;
  public byte* identityBinding;
  public byte* endorsementCredential;
  public byte* platformCredential;
  public byte* conformanceCredential;
}

///
/// Part 2, section 12.8 TPM_ASYM_CA_CONTENTS
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_ASYM_CA_CONTENTS
{
  public TPM_SYMMETRIC_KEY sessionKey;
  public TPM_DIGEST idDigest;
}

///
/// Part 2, section 12.9 TPM_SYM_CA_ATTESTATION
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_SYM_CA_ATTESTATION
{
  public uint credSize;
  public TPM_KEY_PARMS algorithm;
  public byte* credential;
}

///
/// Part 2, section 15: Tick Structures
///   Placed here out of order because definitions are used in section 13.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CURRENT_TICKS
{
  public TPM_STRUCTURE_TAG tag;
  public ulong currentTicks;
  public ushort tickRate;
  public TPM_NONCE tickNonce;
}

///
/// Part 2, section 13: Transport structures
///

///
/// Part 2, section 13.1: TPM _TRANSPORT_PUBLIC
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_TRANSPORT_PUBLIC
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_TRANSPORT_ATTRIBUTES transAttributes;
  public TPM_ALGORITHM_ID algId;
  public TPM_ENC_SCHEME encScheme;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 13.1.1 TPM_TRANSPORT_ATTRIBUTES Definitions
  //
  public const ulong TPM_TRANSPORT_ENCRYPT = ((uint)BIT0);
  public const ulong TPM_TRANSPORT_LOG = ((uint)BIT1);
  public const ulong TPM_TRANSPORT_EXCLUSIVE = ((uint)BIT2);
}

///
/// Part 2, section 13.2 TPM_TRANSPORT_INTERNAL
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_TRANSPORT_INTERNAL
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_AUTHDATA authData;
  public TPM_TRANSPORT_PUBLIC transPublic;
  public TPM_TRANSHANDLE transHandle;
  public TPM_NONCE transNonceEven;
  public TPM_DIGEST transDigest;
}

///
/// Part 2, section 13.3 TPM_TRANSPORT_LOG_IN structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_TRANSPORT_LOG_IN
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DIGEST parameters;
  public TPM_DIGEST pubKeyHash;
}

///
/// Part 2, section 13.4 TPM_TRANSPORT_LOG_OUT structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_TRANSPORT_LOG_OUT
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_CURRENT_TICKS currentTicks;
  public TPM_DIGEST parameters;
  public TPM_MODIFIER_INDICATOR locality;
}

///
/// Part 2, section 13.5 TPM_TRANSPORT_AUTH structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_TRANSPORT_AUTH
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_AUTHDATA authData;
}

//
// Part 2, section 14: Audit Structures
//

///
/// Part 2, section 14.1 TPM_AUDIT_EVENT_IN structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_AUDIT_EVENT_IN
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DIGEST inputParms;
  public TPM_COUNTER_VALUE auditCount;
}

///
/// Part 2, section 14.2 TPM_AUDIT_EVENT_OUT structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_AUDIT_EVENT_OUT
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_COMMAND_CODE ordinal;
  public TPM_DIGEST outputParms;
  public TPM_COUNTER_VALUE auditCount;
  public TPM_RESULT returnCode;
}

//
// Part 2, section 16: Return Codes
//

public unsafe partial class EFI
{
  public const ulong TPM_VENDOR_ERROR = TPM_Vendor_Specific32;
  public const ulong TPM_NON_FATAL = 0x00000800;

  public const ulong TPM_SUCCESS = ((TPM_RESULT)TPM_BASE);
  public const ulong TPM_AUTHFAIL = ((TPM_RESULT)(TPM_BASE + 1));
  public const ulong TPM_BADINDEX = ((TPM_RESULT)(TPM_BASE + 2));
  public const ulong TPM_BAD_PARAMETER = ((TPM_RESULT)(TPM_BASE + 3));
  public const ulong TPM_AUDITFAILURE = ((TPM_RESULT)(TPM_BASE + 4));
  public const ulong TPM_CLEAR_DISABLED = ((TPM_RESULT)(TPM_BASE + 5));
  public const ulong TPM_DEACTIVATED = ((TPM_RESULT)(TPM_BASE + 6));
  public const ulong TPM_DISABLED = ((TPM_RESULT)(TPM_BASE + 7));
  public const ulong TPM_DISABLED_CMD = ((TPM_RESULT)(TPM_BASE + 8));
  public const ulong TPM_FAIL = ((TPM_RESULT)(TPM_BASE + 9));
  public const ulong TPM_BAD_ORDINAL = ((TPM_RESULT)(TPM_BASE + 10));
  public const ulong TPM_INSTALL_DISABLED = ((TPM_RESULT)(TPM_BASE + 11));
  public const ulong TPM_INVALID_KEYHANDLE = ((TPM_RESULT)(TPM_BASE + 12));
  public const ulong TPM_KEYNOTFOUND = ((TPM_RESULT)(TPM_BASE + 13));
  public const ulong TPM_INAPPROPRIATE_ENC = ((TPM_RESULT)(TPM_BASE + 14));
  public const ulong TPM_MIGRATEFAIL = ((TPM_RESULT)(TPM_BASE + 15));
  public const ulong TPM_INVALID_PCR_INFO = ((TPM_RESULT)(TPM_BASE + 16));
  public const ulong TPM_NOSPACE = ((TPM_RESULT)(TPM_BASE + 17));
  public const ulong TPM_NOSRK = ((TPM_RESULT)(TPM_BASE + 18));
  public const ulong TPM_NOTSEALED_BLOB = ((TPM_RESULT)(TPM_BASE + 19));
  public const ulong TPM_OWNER_SET = ((TPM_RESULT)(TPM_BASE + 20));
  public const ulong TPM_RESOURCES = ((TPM_RESULT)(TPM_BASE + 21));
  public const ulong TPM_SHORTRANDOM = ((TPM_RESULT)(TPM_BASE + 22));
  public const ulong TPM_SIZE = ((TPM_RESULT)(TPM_BASE + 23));
  public const ulong TPM_WRONGPCRVAL = ((TPM_RESULT)(TPM_BASE + 24));
  public const ulong TPM_BAD_PARAM_SIZE = ((TPM_RESULT)(TPM_BASE + 25));
  public const ulong TPM_SHA_THREAD = ((TPM_RESULT)(TPM_BASE + 26));
  public const ulong TPM_SHA_ERROR = ((TPM_RESULT)(TPM_BASE + 27));
  public const ulong TPM_FAILEDSELFTEST = ((TPM_RESULT)(TPM_BASE + 28));
  public const ulong TPM_AUTH2FAIL = ((TPM_RESULT)(TPM_BASE + 29));
  public const ulong TPM_BADTAG = ((TPM_RESULT)(TPM_BASE + 30));
  public const ulong TPM_IOERROR = ((TPM_RESULT)(TPM_BASE + 31));
  public const ulong TPM_ENCRYPT_ERROR = ((TPM_RESULT)(TPM_BASE + 32));
  public const ulong TPM_DECRYPT_ERROR = ((TPM_RESULT)(TPM_BASE + 33));
  public const ulong TPM_INVALID_AUTHHANDLE = ((TPM_RESULT)(TPM_BASE + 34));
  public const ulong TPM_NO_ENDORSEMENT = ((TPM_RESULT)(TPM_BASE + 35));
  public const ulong TPM_INVALID_KEYUSAGE = ((TPM_RESULT)(TPM_BASE + 36));
  public const ulong TPM_WRONG_ENTITYTYPE = ((TPM_RESULT)(TPM_BASE + 37));
  public const ulong TPM_INVALID_POSTINIT = ((TPM_RESULT)(TPM_BASE + 38));
  public const ulong TPM_INAPPROPRIATE_SIG = ((TPM_RESULT)(TPM_BASE + 39));
  public const ulong TPM_BAD_KEY_PROPERTY = ((TPM_RESULT)(TPM_BASE + 40));
  public const ulong TPM_BAD_MIGRATION = ((TPM_RESULT)(TPM_BASE + 41));
  public const ulong TPM_BAD_SCHEME = ((TPM_RESULT)(TPM_BASE + 42));
  public const ulong TPM_BAD_DATASIZE = ((TPM_RESULT)(TPM_BASE + 43));
  public const ulong TPM_BAD_MODE = ((TPM_RESULT)(TPM_BASE + 44));
  public const ulong TPM_BAD_PRESENCE = ((TPM_RESULT)(TPM_BASE + 45));
  public const ulong TPM_BAD_VERSION = ((TPM_RESULT)(TPM_BASE + 46));
  public const ulong TPM_NO_WRAP_TRANSPORT = ((TPM_RESULT)(TPM_BASE + 47));
  public const ulong TPM_AUDITFAIL_UNSUCCESSFUL = ((TPM_RESULT)(TPM_BASE + 48));
  public const ulong TPM_AUDITFAIL_SUCCESSFUL = ((TPM_RESULT)(TPM_BASE + 49));
  public const ulong TPM_NOTRESETABLE = ((TPM_RESULT)(TPM_BASE + 50));
  public const ulong TPM_NOTLOCAL = ((TPM_RESULT)(TPM_BASE + 51));
  public const ulong TPM_BAD_TYPE = ((TPM_RESULT)(TPM_BASE + 52));
  public const ulong TPM_INVALID_RESOURCE = ((TPM_RESULT)(TPM_BASE + 53));
  public const ulong TPM_NOTFIPS = ((TPM_RESULT)(TPM_BASE + 54));
  public const ulong TPM_INVALID_FAMILY = ((TPM_RESULT)(TPM_BASE + 55));
  public const ulong TPM_NO_NV_PERMISSION = ((TPM_RESULT)(TPM_BASE + 56));
  public const ulong TPM_REQUIRES_SIGN = ((TPM_RESULT)(TPM_BASE + 57));
  public const ulong TPM_KEY_NOTSUPPORTED = ((TPM_RESULT)(TPM_BASE + 58));
  public const ulong TPM_AUTH_CONFLICT = ((TPM_RESULT)(TPM_BASE + 59));
  public const ulong TPM_AREA_LOCKED = ((TPM_RESULT)(TPM_BASE + 60));
  public const ulong TPM_BAD_LOCALITY = ((TPM_RESULT)(TPM_BASE + 61));
  public const ulong TPM_READ_ONLY = ((TPM_RESULT)(TPM_BASE + 62));
  public const ulong TPM_PER_NOWRITE = ((TPM_RESULT)(TPM_BASE + 63));
  public const ulong TPM_FAMILYCOUNT = ((TPM_RESULT)(TPM_BASE + 64));
  public const ulong TPM_WRITE_LOCKED = ((TPM_RESULT)(TPM_BASE + 65));
  public const ulong TPM_BAD_ATTRIBUTES = ((TPM_RESULT)(TPM_BASE + 66));
  public const ulong TPM_INVALID_STRUCTURE = ((TPM_RESULT)(TPM_BASE + 67));
  public const ulong TPM_KEY_OWNER_CONTROL = ((TPM_RESULT)(TPM_BASE + 68));
  public const ulong TPM_BAD_COUNTER = ((TPM_RESULT)(TPM_BASE + 69));
  public const ulong TPM_NOT_FULLWRITE = ((TPM_RESULT)(TPM_BASE + 70));
  public const ulong TPM_CONTEXT_GAP = ((TPM_RESULT)(TPM_BASE + 71));
  public const ulong TPM_MAXNVWRITES = ((TPM_RESULT)(TPM_BASE + 72));
  public const ulong TPM_NOOPERATOR = ((TPM_RESULT)(TPM_BASE + 73));
  public const ulong TPM_RESOURCEMISSING = ((TPM_RESULT)(TPM_BASE + 74));
  public const ulong TPM_DELEGATE_LOCK = ((TPM_RESULT)(TPM_BASE + 75));
  public const ulong TPM_DELEGATE_FAMILY = ((TPM_RESULT)(TPM_BASE + 76));
  public const ulong TPM_DELEGATE_ADMIN = ((TPM_RESULT)(TPM_BASE + 77));
  public const ulong TPM_TRANSPORT_NOTEXCLUSIVE = ((TPM_RESULT)(TPM_BASE + 78));
  public const ulong TPM_OWNER_CONTROL = ((TPM_RESULT)(TPM_BASE + 79));
  public const ulong TPM_DAA_RESOURCES = ((TPM_RESULT)(TPM_BASE + 80));
  public const ulong TPM_DAA_INPUT_DATA0 = ((TPM_RESULT)(TPM_BASE + 81));
  public const ulong TPM_DAA_INPUT_DATA1 = ((TPM_RESULT)(TPM_BASE + 82));
  public const ulong TPM_DAA_ISSUER_SETTINGS = ((TPM_RESULT)(TPM_BASE + 83));
  public const ulong TPM_DAA_TPM_SETTINGS = ((TPM_RESULT)(TPM_BASE + 84));
  public const ulong TPM_DAA_STAGE = ((TPM_RESULT)(TPM_BASE + 85));
  public const ulong TPM_DAA_ISSUER_VALIDITY = ((TPM_RESULT)(TPM_BASE + 86));
  public const ulong TPM_DAA_WRONG_W = ((TPM_RESULT)(TPM_BASE + 87));
  public const ulong TPM_BAD_HANDLE = ((TPM_RESULT)(TPM_BASE + 88));
  public const ulong TPM_BAD_DELEGATE = ((TPM_RESULT)(TPM_BASE + 89));
  public const ulong TPM_BADCONTEXT = ((TPM_RESULT)(TPM_BASE + 90));
  public const ulong TPM_TOOMANYCONTEXTS = ((TPM_RESULT)(TPM_BASE + 91));
  public const ulong TPM_MA_TICKET_SIGNATURE = ((TPM_RESULT)(TPM_BASE + 92));
  public const ulong TPM_MA_DESTINATION = ((TPM_RESULT)(TPM_BASE + 93));
  public const ulong TPM_MA_SOURCE = ((TPM_RESULT)(TPM_BASE + 94));
  public const ulong TPM_MA_AUTHORITY = ((TPM_RESULT)(TPM_BASE + 95));
  public const ulong TPM_PERMANENTEK = ((TPM_RESULT)(TPM_BASE + 97));
  public const ulong TPM_BAD_SIGNATURE = ((TPM_RESULT)(TPM_BASE + 98));
  public const ulong TPM_NOCONTEXTSPACE = ((TPM_RESULT)(TPM_BASE + 99));

  public const ulong TPM_RETRY = ((TPM_RESULT)(TPM_BASE + TPM_NON_FATAL));
  public const ulong TPM_NEEDS_SELFTEST = ((TPM_RESULT)(TPM_BASE + TPM_NON_FATAL + 1));
  public const ulong TPM_DOING_SELFTEST = ((TPM_RESULT)(TPM_BASE + TPM_NON_FATAL + 2));
  public const ulong TPM_DEFEND_LOCK_RUNNING = ((TPM_RESULT)(TPM_BASE + TPM_NON_FATAL + 3));

  //
  // Part 2, section 17: Ordinals
  //
  // Ordinals are 32 bit values. The upper byte contains values that serve as
  // flag indicators, the next byte contains values indicating what committee
  // designated the ordinal, and the final two bytes contain the Command
  // Ordinal Index.
  //      3                   2                   1
  //    1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0
  //   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
  //   |P|C|V| Reserved| Purview |     Command Ordinal Index           |
  //   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
  //
  //  Where:
  //
  //    * P is Protected/Unprotected command. When 0 the command is a Protected
  //      command, when 1 the command is an Unprotected command.
  //
  //    * C is Non-Connection/Connection related command. When 0 this command
  //      passes through to either the protected (TPM) or unprotected (TSS)
  //      components.
  //
  //    * V is TPM/Vendor command. When 0 the command is TPM defined, when 1 the
  //      command is vendor defined.
  //
  //    * All reserved area bits are set to 0.
  //

  public const ulong TPM_ORD_ActivateIdentity = ((TPM_COMMAND_CODE)0x0000007A);
  public const ulong TPM_ORD_AuthorizeMigrationKey = ((TPM_COMMAND_CODE)0x0000002B);
  public const ulong TPM_ORD_CertifyKey = ((TPM_COMMAND_CODE)0x00000032);
  public const ulong TPM_ORD_CertifyKey2 = ((TPM_COMMAND_CODE)0x00000033);
  public const ulong TPM_ORD_CertifySelfTest = ((TPM_COMMAND_CODE)0x00000052);
  public const ulong TPM_ORD_ChangeAuth = ((TPM_COMMAND_CODE)0x0000000C);
  public const ulong TPM_ORD_ChangeAuthAsymFinish = ((TPM_COMMAND_CODE)0x0000000F);
  public const ulong TPM_ORD_ChangeAuthAsymStart = ((TPM_COMMAND_CODE)0x0000000E);
  public const ulong TPM_ORD_ChangeAuthOwner = ((TPM_COMMAND_CODE)0x00000010);
  public const ulong TPM_ORD_CMK_ApproveMA = ((TPM_COMMAND_CODE)0x0000001D);
  public const ulong TPM_ORD_CMK_ConvertMigration = ((TPM_COMMAND_CODE)0x00000024);
  public const ulong TPM_ORD_CMK_CreateBlob = ((TPM_COMMAND_CODE)0x0000001B);
  public const ulong TPM_ORD_CMK_CreateKey = ((TPM_COMMAND_CODE)0x00000013);
  public const ulong TPM_ORD_CMK_CreateTicket = ((TPM_COMMAND_CODE)0x00000012);
  public const ulong TPM_ORD_CMK_SetRestrictions = ((TPM_COMMAND_CODE)0x0000001C);
  public const ulong TPM_ORD_ContinueSelfTest = ((TPM_COMMAND_CODE)0x00000053);
  public const ulong TPM_ORD_ConvertMigrationBlob = ((TPM_COMMAND_CODE)0x0000002A);
  public const ulong TPM_ORD_CreateCounter = ((TPM_COMMAND_CODE)0x000000DC);
  public const ulong TPM_ORD_CreateEndorsementKeyPair = ((TPM_COMMAND_CODE)0x00000078);
  public const ulong TPM_ORD_CreateMaintenanceArchive = ((TPM_COMMAND_CODE)0x0000002C);
  public const ulong TPM_ORD_CreateMigrationBlob = ((TPM_COMMAND_CODE)0x00000028);
  public const ulong TPM_ORD_CreateRevocableEK = ((TPM_COMMAND_CODE)0x0000007F);
  public const ulong TPM_ORD_CreateWrapKey = ((TPM_COMMAND_CODE)0x0000001F);
  public const ulong TPM_ORD_DAA_JOIN = ((TPM_COMMAND_CODE)0x00000029);
  public const ulong TPM_ORD_DAA_SIGN = ((TPM_COMMAND_CODE)0x00000031);
  public const ulong TPM_ORD_Delegate_CreateKeyDelegation = ((TPM_COMMAND_CODE)0x000000D4);
  public const ulong TPM_ORD_Delegate_CreateOwnerDelegation = ((TPM_COMMAND_CODE)0x000000D5);
  public const ulong TPM_ORD_Delegate_LoadOwnerDelegation = ((TPM_COMMAND_CODE)0x000000D8);
  public const ulong TPM_ORD_Delegate_Manage = ((TPM_COMMAND_CODE)0x000000D2);
  public const ulong TPM_ORD_Delegate_ReadTable = ((TPM_COMMAND_CODE)0x000000DB);
  public const ulong TPM_ORD_Delegate_UpdateVerification = ((TPM_COMMAND_CODE)0x000000D1);
  public const ulong TPM_ORD_Delegate_VerifyDelegation = ((TPM_COMMAND_CODE)0x000000D6);
  public const ulong TPM_ORD_DirRead = ((TPM_COMMAND_CODE)0x0000001A);
  public const ulong TPM_ORD_DirWriteAuth = ((TPM_COMMAND_CODE)0x00000019);
  public const ulong TPM_ORD_DisableForceClear = ((TPM_COMMAND_CODE)0x0000005E);
  public const ulong TPM_ORD_DisableOwnerClear = ((TPM_COMMAND_CODE)0x0000005C);
  public const ulong TPM_ORD_DisablePubekRead = ((TPM_COMMAND_CODE)0x0000007E);
  public const ulong TPM_ORD_DSAP = ((TPM_COMMAND_CODE)0x00000011);
  public const ulong TPM_ORD_EstablishTransport = ((TPM_COMMAND_CODE)0x000000E6);
  public const ulong TPM_ORD_EvictKey = ((TPM_COMMAND_CODE)0x00000022);
  public const ulong TPM_ORD_ExecuteTransport = ((TPM_COMMAND_CODE)0x000000E7);
  public const ulong TPM_ORD_Extend = ((TPM_COMMAND_CODE)0x00000014);
  public const ulong TPM_ORD_FieldUpgrade = ((TPM_COMMAND_CODE)0x000000AA);
  public const ulong TPM_ORD_FlushSpecific = ((TPM_COMMAND_CODE)0x000000BA);
  public const ulong TPM_ORD_ForceClear = ((TPM_COMMAND_CODE)0x0000005D);
  public const ulong TPM_ORD_GetAuditDigest = ((TPM_COMMAND_CODE)0x00000085);
  public const ulong TPM_ORD_GetAuditDigestSigned = ((TPM_COMMAND_CODE)0x00000086);
  public const ulong TPM_ORD_GetAuditEvent = ((TPM_COMMAND_CODE)0x00000082);
  public const ulong TPM_ORD_GetAuditEventSigned = ((TPM_COMMAND_CODE)0x00000083);
  public const ulong TPM_ORD_GetCapability = ((TPM_COMMAND_CODE)0x00000065);
  public const ulong TPM_ORD_GetCapabilityOwner = ((TPM_COMMAND_CODE)0x00000066);
  public const ulong TPM_ORD_GetCapabilitySigned = ((TPM_COMMAND_CODE)0x00000064);
  public const ulong TPM_ORD_GetOrdinalAuditStatus = ((TPM_COMMAND_CODE)0x0000008C);
  public const ulong TPM_ORD_GetPubKey = ((TPM_COMMAND_CODE)0x00000021);
  public const ulong TPM_ORD_GetRandom = ((TPM_COMMAND_CODE)0x00000046);
  public const ulong TPM_ORD_GetTestResult = ((TPM_COMMAND_CODE)0x00000054);
  public const ulong TPM_ORD_GetTicks = ((TPM_COMMAND_CODE)0x000000F1);
  public const ulong TPM_ORD_IncrementCounter = ((TPM_COMMAND_CODE)0x000000DD);
  public const ulong TPM_ORD_Init = ((TPM_COMMAND_CODE)0x00000097);
  public const ulong TPM_ORD_KeyControlOwner = ((TPM_COMMAND_CODE)0x00000023);
  public const ulong TPM_ORD_KillMaintenanceFeature = ((TPM_COMMAND_CODE)0x0000002E);
  public const ulong TPM_ORD_LoadAuthContext = ((TPM_COMMAND_CODE)0x000000B7);
  public const ulong TPM_ORD_LoadContext = ((TPM_COMMAND_CODE)0x000000B9);
  public const ulong TPM_ORD_LoadKey = ((TPM_COMMAND_CODE)0x00000020);
  public const ulong TPM_ORD_LoadKey2 = ((TPM_COMMAND_CODE)0x00000041);
  public const ulong TPM_ORD_LoadKeyContext = ((TPM_COMMAND_CODE)0x000000B5);
  public const ulong TPM_ORD_LoadMaintenanceArchive = ((TPM_COMMAND_CODE)0x0000002D);
  public const ulong TPM_ORD_LoadManuMaintPub = ((TPM_COMMAND_CODE)0x0000002F);
  public const ulong TPM_ORD_MakeIdentity = ((TPM_COMMAND_CODE)0x00000079);
  public const ulong TPM_ORD_MigrateKey = ((TPM_COMMAND_CODE)0x00000025);
  public const ulong TPM_ORD_NV_DefineSpace = ((TPM_COMMAND_CODE)0x000000CC);
  public const ulong TPM_ORD_NV_ReadValue = ((TPM_COMMAND_CODE)0x000000CF);
  public const ulong TPM_ORD_NV_ReadValueAuth = ((TPM_COMMAND_CODE)0x000000D0);
  public const ulong TPM_ORD_NV_WriteValue = ((TPM_COMMAND_CODE)0x000000CD);
  public const ulong TPM_ORD_NV_WriteValueAuth = ((TPM_COMMAND_CODE)0x000000CE);
  public const ulong TPM_ORD_OIAP = ((TPM_COMMAND_CODE)0x0000000A);
  public const ulong TPM_ORD_OSAP = ((TPM_COMMAND_CODE)0x0000000B);
  public const ulong TPM_ORD_OwnerClear = ((TPM_COMMAND_CODE)0x0000005B);
  public const ulong TPM_ORD_OwnerReadInternalPub = ((TPM_COMMAND_CODE)0x00000081);
  public const ulong TPM_ORD_OwnerReadPubek = ((TPM_COMMAND_CODE)0x0000007D);
  public const ulong TPM_ORD_OwnerSetDisable = ((TPM_COMMAND_CODE)0x0000006E);
  public const ulong TPM_ORD_PCR_Reset = ((TPM_COMMAND_CODE)0x000000C8);
  public const ulong TPM_ORD_PcrRead = ((TPM_COMMAND_CODE)0x00000015);
  public const ulong TPM_ORD_PhysicalDisable = ((TPM_COMMAND_CODE)0x00000070);
  public const ulong TPM_ORD_PhysicalEnable = ((TPM_COMMAND_CODE)0x0000006F);
  public const ulong TPM_ORD_PhysicalSetDeactivated = ((TPM_COMMAND_CODE)0x00000072);
  public const ulong TPM_ORD_Quote = ((TPM_COMMAND_CODE)0x00000016);
  public const ulong TPM_ORD_Quote2 = ((TPM_COMMAND_CODE)0x0000003E);
  public const ulong TPM_ORD_ReadCounter = ((TPM_COMMAND_CODE)0x000000DE);
  public const ulong TPM_ORD_ReadManuMaintPub = ((TPM_COMMAND_CODE)0x00000030);
  public const ulong TPM_ORD_ReadPubek = ((TPM_COMMAND_CODE)0x0000007C);
  public const ulong TPM_ORD_ReleaseCounter = ((TPM_COMMAND_CODE)0x000000DF);
  public const ulong TPM_ORD_ReleaseCounterOwner = ((TPM_COMMAND_CODE)0x000000E0);
  public const ulong TPM_ORD_ReleaseTransportSigned = ((TPM_COMMAND_CODE)0x000000E8);
  public const ulong TPM_ORD_Reset = ((TPM_COMMAND_CODE)0x0000005A);
  public const ulong TPM_ORD_ResetLockValue = ((TPM_COMMAND_CODE)0x00000040);
  public const ulong TPM_ORD_RevokeTrust = ((TPM_COMMAND_CODE)0x00000080);
  public const ulong TPM_ORD_SaveAuthContext = ((TPM_COMMAND_CODE)0x000000B6);
  public const ulong TPM_ORD_SaveContext = ((TPM_COMMAND_CODE)0x000000B8);
  public const ulong TPM_ORD_SaveKeyContext = ((TPM_COMMAND_CODE)0x000000B4);
  public const ulong TPM_ORD_SaveState = ((TPM_COMMAND_CODE)0x00000098);
  public const ulong TPM_ORD_Seal = ((TPM_COMMAND_CODE)0x00000017);
  public const ulong TPM_ORD_Sealx = ((TPM_COMMAND_CODE)0x0000003D);
  public const ulong TPM_ORD_SelfTestFull = ((TPM_COMMAND_CODE)0x00000050);
  public const ulong TPM_ORD_SetCapability = ((TPM_COMMAND_CODE)0x0000003F);
  public const ulong TPM_ORD_SetOperatorAuth = ((TPM_COMMAND_CODE)0x00000074);
  public const ulong TPM_ORD_SetOrdinalAuditStatus = ((TPM_COMMAND_CODE)0x0000008D);
  public const ulong TPM_ORD_SetOwnerInstall = ((TPM_COMMAND_CODE)0x00000071);
  public const ulong TPM_ORD_SetOwnerPointer = ((TPM_COMMAND_CODE)0x00000075);
  public const ulong TPM_ORD_SetRedirection = ((TPM_COMMAND_CODE)0x0000009A);
  public const ulong TPM_ORD_SetTempDeactivated = ((TPM_COMMAND_CODE)0x00000073);
  public const ulong TPM_ORD_SHA1Complete = ((TPM_COMMAND_CODE)0x000000A2);
  public const ulong TPM_ORD_SHA1CompleteExtend = ((TPM_COMMAND_CODE)0x000000A3);
  public const ulong TPM_ORD_SHA1Start = ((TPM_COMMAND_CODE)0x000000A0);
  public const ulong TPM_ORD_SHA1Update = ((TPM_COMMAND_CODE)0x000000A1);
  public const ulong TPM_ORD_Sign = ((TPM_COMMAND_CODE)0x0000003C);
  public const ulong TPM_ORD_Startup = ((TPM_COMMAND_CODE)0x00000099);
  public const ulong TPM_ORD_StirRandom = ((TPM_COMMAND_CODE)0x00000047);
  public const ulong TPM_ORD_TakeOwnership = ((TPM_COMMAND_CODE)0x0000000D);
  public const ulong TPM_ORD_Terminate_Handle = ((TPM_COMMAND_CODE)0x00000096);
  public const ulong TPM_ORD_TickStampBlob = ((TPM_COMMAND_CODE)0x000000F2);
  public const ulong TPM_ORD_UnBind = ((TPM_COMMAND_CODE)0x0000001E);
  public const ulong TPM_ORD_Unseal = ((TPM_COMMAND_CODE)0x00000018);
  public const ulong TSC_ORD_PhysicalPresence = ((TPM_COMMAND_CODE)0x4000000A);
  public const ulong TSC_ORD_ResetEstablishmentBit = ((TPM_COMMAND_CODE)0x4000000B);

  //
  // Part 2, section 18: Context structures
  //
}

///
/// Part 2, section 18.1: TPM_CONTEXT_BLOB
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CONTEXT_BLOB
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_RESOURCE_TYPE resourceType;
  public TPM_HANDLE handle;
  public fixed byte label[16];
  public uint contextCount;
  public TPM_DIGEST integrityDigest;
  public uint additionalSize;
  public byte* additionalData;
  public uint sensitiveSize;
  public byte* sensitiveData;
}

///
/// Part 2, section 18.2 TPM_CONTEXT_SENSITIVE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CONTEXT_SENSITIVE
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_NONCE contextNonce;
  public uint internalSize;
  public byte* internalData;
}

//
// Part 2, section 19: NV Structures
//

public unsafe partial class EFI
{
  //
  // Part 2, section 19.1.1: Required TPM_NV_INDEX values
  //
  public const ulong TPM_NV_INDEX_LOCK = ((uint)0xffffffff);
  public const ulong TPM_NV_INDEX0 = ((uint)0x00000000);
  public const ulong TPM_NV_INDEX_DIR = ((uint)0x10000001);
  public const ulong TPM_NV_INDEX_EKCert = ((uint)0x0000f000);
  public const ulong TPM_NV_INDEX_TPM_CC = ((uint)0x0000f001);
  public const ulong TPM_NV_INDEX_PlatformCert = ((uint)0x0000f002);
  public const ulong TPM_NV_INDEX_Platform_CC = ((uint)0x0000f003);
  //
  // Part 2, section 19.1.2: Reserved Index values
  //
  public const ulong TPM_NV_INDEX_TSS_BASE = ((uint)0x00011100);
  public const ulong TPM_NV_INDEX_PC_BASE = ((uint)0x00011200);
  public const ulong TPM_NV_INDEX_SERVER_BASE = ((uint)0x00011300);
  public const ulong TPM_NV_INDEX_MOBILE_BASE = ((uint)0x00011400);
  public const ulong TPM_NV_INDEX_PERIPHERAL_BASE = ((uint)0x00011500);
  public const ulong TPM_NV_INDEX_GROUP_RESV_BASE = ((uint)0x00010000);
}

///
/// Part 2, section 19.2: TPM_NV_ATTRIBUTES
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_NV_ATTRIBUTES
{
  public TPM_STRUCTURE_TAG tag;
  public uint attributes;
}

public unsafe partial class EFI
{
  public const ulong TPM_NV_PER_READ_STCLEAR = (BIT31);
  public const ulong TPM_NV_PER_AUTHREAD = (BIT18);
  public const ulong TPM_NV_PER_OWNERREAD = (BIT17);
  public const ulong TPM_NV_PER_PPREAD = (BIT16);
  public const ulong TPM_NV_PER_GLOBALLOCK = (BIT15);
  public const ulong TPM_NV_PER_WRITE_STCLEAR = (BIT14);
  public const ulong TPM_NV_PER_WRITEDEFINE = (BIT13);
  public const ulong TPM_NV_PER_WRITEALL = (BIT12);
  public const ulong TPM_NV_PER_AUTHWRITE = (BIT2);
  public const ulong TPM_NV_PER_OWNERWRITE = (BIT1);
  public const ulong TPM_NV_PER_PPWRITE = (BIT0);
}

///
/// Part 2, section 19.3: TPM_NV_DATA_PUBLIC
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_NV_DATA_PUBLIC
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_NV_INDEX nvIndex;
  public TPM_PCR_INFO_SHORT pcrInfoRead;
  public TPM_PCR_INFO_SHORT pcrInfoWrite;
  public TPM_NV_ATTRIBUTES permission;
  public bool bReadSTClear;
  public bool bWriteSTClear;
  public bool bWriteDefine;
  public uint dataSize;
}

//
// Part 2, section 20: Delegate Structures
//

public unsafe partial class EFI
{
  public const ulong TPM_DEL_OWNER_BITS = ((uint)0x00000001);
  public const ulong TPM_DEL_KEY_BITS = ((uint)0x00000002);
  ///
  /// Part 2, section 20.2: Delegate Definitions
  ///
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DELEGATIONS
{
  public TPM_STRUCTURE_TAG tag;
  public uint delegateType;
  public uint per1;
  public uint per2;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 20.2.1: Owner Permission Settings
  //
  public const ulong TPM_DELEGATE_SetOrdinalAuditStatus = (BIT30);
  public const ulong TPM_DELEGATE_DirWriteAuth = (BIT29);
  public const ulong TPM_DELEGATE_CMK_ApproveMA = (BIT28);
  public const ulong TPM_DELEGATE_NV_WriteValue = (BIT27);
  public const ulong TPM_DELEGATE_CMK_CreateTicket = (BIT26);
  public const ulong TPM_DELEGATE_NV_ReadValue = (BIT25);
  public const ulong TPM_DELEGATE_Delegate_LoadOwnerDelegation = (BIT24);
  public const ulong TPM_DELEGATE_DAA_Join = (BIT23);
  public const ulong TPM_DELEGATE_AuthorizeMigrationKey = (BIT22);
  public const ulong TPM_DELEGATE_CreateMaintenanceArchive = (BIT21);
  public const ulong TPM_DELEGATE_LoadMaintenanceArchive = (BIT20);
  public const ulong TPM_DELEGATE_KillMaintenanceFeature = (BIT19);
  public const ulong TPM_DELEGATE_OwnerReadInteralPub = (BIT18);
  public const ulong TPM_DELEGATE_ResetLockValue = (BIT17);
  public const ulong TPM_DELEGATE_OwnerClear = (BIT16);
  public const ulong TPM_DELEGATE_DisableOwnerClear = (BIT15);
  public const ulong TPM_DELEGATE_NV_DefineSpace = (BIT14);
  public const ulong TPM_DELEGATE_OwnerSetDisable = (BIT13);
  public const ulong TPM_DELEGATE_SetCapability = (BIT12);
  public const ulong TPM_DELEGATE_MakeIdentity = (BIT11);
  public const ulong TPM_DELEGATE_ActivateIdentity = (BIT10);
  public const ulong TPM_DELEGATE_OwnerReadPubek = (BIT9);
  public const ulong TPM_DELEGATE_DisablePubekRead = (BIT8);
  public const ulong TPM_DELEGATE_SetRedirection = (BIT7);
  public const ulong TPM_DELEGATE_FieldUpgrade = (BIT6);
  public const ulong TPM_DELEGATE_Delegate_UpdateVerification = (BIT5);
  public const ulong TPM_DELEGATE_CreateCounter = (BIT4);
  public const ulong TPM_DELEGATE_ReleaseCounterOwner = (BIT3);
  public const ulong TPM_DELEGATE_DelegateManage = (BIT2);
  public const ulong TPM_DELEGATE_Delegate_CreateOwnerDelegation = (BIT1);
  public const ulong TPM_DELEGATE_DAA_Sign = (BIT0);

  //
  // Part 2, section 20.2.3: Key Permission settings
  //
  public const ulong TPM_KEY_DELEGATE_CMK_ConvertMigration = (BIT28);
  public const ulong TPM_KEY_DELEGATE_TickStampBlob = (BIT27);
  public const ulong TPM_KEY_DELEGATE_ChangeAuthAsymStart = (BIT26);
  public const ulong TPM_KEY_DELEGATE_ChangeAuthAsymFinish = (BIT25);
  public const ulong TPM_KEY_DELEGATE_CMK_CreateKey = (BIT24);
  public const ulong TPM_KEY_DELEGATE_MigrateKey = (BIT23);
  public const ulong TPM_KEY_DELEGATE_LoadKey2 = (BIT22);
  public const ulong TPM_KEY_DELEGATE_EstablishTransport = (BIT21);
  public const ulong TPM_KEY_DELEGATE_ReleaseTransportSigned = (BIT20);
  public const ulong TPM_KEY_DELEGATE_Quote2 = (BIT19);
  public const ulong TPM_KEY_DELEGATE_Sealx = (BIT18);
  public const ulong TPM_KEY_DELEGATE_MakeIdentity = (BIT17);
  public const ulong TPM_KEY_DELEGATE_ActivateIdentity = (BIT16);
  public const ulong TPM_KEY_DELEGATE_GetAuditDigestSigned = (BIT15);
  public const ulong TPM_KEY_DELEGATE_Sign = (BIT14);
  public const ulong TPM_KEY_DELEGATE_CertifyKey2 = (BIT13);
  public const ulong TPM_KEY_DELEGATE_CertifyKey = (BIT12);
  public const ulong TPM_KEY_DELEGATE_CreateWrapKey = (BIT11);
  public const ulong TPM_KEY_DELEGATE_CMK_CreateBlob = (BIT10);
  public const ulong TPM_KEY_DELEGATE_CreateMigrationBlob = (BIT9);
  public const ulong TPM_KEY_DELEGATE_ConvertMigrationBlob = (BIT8);
  public const ulong TPM_KEY_DELEGATE_CreateKeyDelegation = (BIT7);
  public const ulong TPM_KEY_DELEGATE_ChangeAuth = (BIT6);
  public const ulong TPM_KEY_DELEGATE_GetPubKey = (BIT5);
  public const ulong TPM_KEY_DELEGATE_UnBind = (BIT4);
  public const ulong TPM_KEY_DELEGATE_Quote = (BIT3);
  public const ulong TPM_KEY_DELEGATE_Unseal = (BIT2);
  public const ulong TPM_KEY_DELEGATE_Seal = (BIT1);
  public const ulong TPM_KEY_DELEGATE_LoadKey = (BIT0);

  //
  // Part 2, section 20.3: TPM_FAMILY_FLAGS
  //
  public const ulong TPM_DELEGATE_ADMIN_LOCK = (BIT1);
  public const ulong TPM_FAMFLAG_ENABLE = (BIT0);
}

///
/// Part 2, section 20.4: TPM_FAMILY_LABEL
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_FAMILY_LABEL
{
  public byte label;
}

///
/// Part 2, section 20.5: TPM_FAMILY_TABLE_ENTRY
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_FAMILY_TABLE_ENTRY
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_FAMILY_LABEL label;
  public TPM_FAMILY_ID familyID;
  public TPM_FAMILY_VERIFICATION verificationCount;
  public TPM_FAMILY_FLAGS flags;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 20.6: TPM_FAMILY_TABLE
  //
  public const ulong TPM_NUM_FAMILY_TABLE_ENTRY_MIN = 8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_FAMILY_TABLE
{
  public fixed TPM_FAMILY_TABLE_ENTRY famTableRow[TPM_NUM_FAMILY_TABLE_ENTRY_MIN];
}

///
/// Part 2, section 20.7: TPM_DELEGATE_LABEL
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DELEGATE_LABEL
{
  public byte label;
}

///
/// Part 2, section 20.8: TPM_DELEGATE_PUBLIC
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DELEGATE_PUBLIC
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DELEGATE_LABEL label;
  public TPM_PCR_INFO_SHORT pcrInfo;
  public TPM_DELEGATIONS permissions;
  public TPM_FAMILY_ID familyID;
  public TPM_FAMILY_VERIFICATION verificationCount;
}

///
/// Part 2, section 20.9: TPM_DELEGATE_TABLE_ROW
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DELEGATE_TABLE_ROW
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DELEGATE_PUBLIC pub;
  public TPM_SECRET authValue;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 20.10: TPM_DELEGATE_TABLE
  //
  public const ulong TPM_NUM_DELEGATE_TABLE_ENTRY_MIN = 2;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DELEGATE_TABLE
{
  public fixed TPM_DELEGATE_TABLE_ROW delRow[TPM_NUM_DELEGATE_TABLE_ENTRY_MIN];
}

///
/// Part 2, section 20.11: TPM_DELEGATE_SENSITIVE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DELEGATE_SENSITIVE
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_SECRET authValue;
}

///
/// Part 2, section 20.12: TPM_DELEGATE_OWNER_BLOB
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DELEGATE_OWNER_BLOB
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DELEGATE_PUBLIC pub;
  public TPM_DIGEST integrityDigest;
  public uint additionalSize;
  public byte* additionalArea;
  public uint sensitiveSize;
  public byte* sensitiveArea;
}

///
/// Part 2, section 20.13: TTPM_DELEGATE_KEY_BLOB
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DELEGATE_KEY_BLOB
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DELEGATE_PUBLIC pub;
  public TPM_DIGEST integrityDigest;
  public TPM_DIGEST pubKeyDigest;
  public uint additionalSize;
  public byte* additionalArea;
  public uint sensitiveSize;
  public byte* sensitiveArea;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 20.14: TPM_FAMILY_OPERATION Values
  //
  public const ulong TPM_FAMILY_CREATE = ((uint)0x00000001);
  public const ulong TPM_FAMILY_ENABLE = ((uint)0x00000002);
  public const ulong TPM_FAMILY_ADMIN = ((uint)0x00000003);
  public const ulong TPM_FAMILY_INVALIDATE = ((uint)0x00000004);

  //
  // Part 2, section 21.1: TPM_CAPABILITY_AREA for GetCapability
  //
  public const ulong TPM_CAP_ORD = ((TPM_CAPABILITY_AREA)0x00000001);
  public const ulong TPM_CAP_ALG = ((TPM_CAPABILITY_AREA)0x00000002);
  public const ulong TPM_CAP_PID = ((TPM_CAPABILITY_AREA)0x00000003);
  public const ulong TPM_CAP_FLAG = ((TPM_CAPABILITY_AREA)0x00000004);
  public const ulong TPM_CAP_PROPERTY = ((TPM_CAPABILITY_AREA)0x00000005);
  public const ulong TPM_CAP_VERSION = ((TPM_CAPABILITY_AREA)0x00000006);
  public const ulong TPM_CAP_KEY_HANDLE = ((TPM_CAPABILITY_AREA)0x00000007);
  public const ulong TPM_CAP_CHECK_LOADED = ((TPM_CAPABILITY_AREA)0x00000008);
  public const ulong TPM_CAP_SYM_MODE = ((TPM_CAPABILITY_AREA)0x00000009);
  public const ulong TPM_CAP_KEY_STATUS = ((TPM_CAPABILITY_AREA)0x0000000C);
  public const ulong TPM_CAP_NV_LIST = ((TPM_CAPABILITY_AREA)0x0000000D);
  public const ulong TPM_CAP_MFR = ((TPM_CAPABILITY_AREA)0x00000010);
  public const ulong TPM_CAP_NV_INDEX = ((TPM_CAPABILITY_AREA)0x00000011);
  public const ulong TPM_CAP_TRANS_ALG = ((TPM_CAPABILITY_AREA)0x00000012);
  public const ulong TPM_CAP_HANDLE = ((TPM_CAPABILITY_AREA)0x00000014);
  public const ulong TPM_CAP_TRANS_ES = ((TPM_CAPABILITY_AREA)0x00000015);
  public const ulong TPM_CAP_AUTH_ENCRYPT = ((TPM_CAPABILITY_AREA)0x00000017);
  public const ulong TPM_CAP_SELECT_SIZE = ((TPM_CAPABILITY_AREA)0x00000018);
  public const ulong TPM_CAP_VERSION_VAL = ((TPM_CAPABILITY_AREA)0x0000001A);

  public const ulong TPM_CAP_FLAG_PERMANENT = ((TPM_CAPABILITY_AREA)0x00000108);
  public const ulong TPM_CAP_FLAG_VOLATILE = ((TPM_CAPABILITY_AREA)0x00000109);

  //
  // Part 2, section 21.2: CAP_PROPERTY Subcap values for GetCapability
  //
  public const ulong TPM_CAP_PROP_PCR = ((TPM_CAPABILITY_AREA)0x00000101);
  public const ulong TPM_CAP_PROP_DIR = ((TPM_CAPABILITY_AREA)0x00000102);
  public const ulong TPM_CAP_PROP_MANUFACTURER = ((TPM_CAPABILITY_AREA)0x00000103);
  public const ulong TPM_CAP_PROP_KEYS = ((TPM_CAPABILITY_AREA)0x00000104);
  public const ulong TPM_CAP_PROP_MIN_COUNTER = ((TPM_CAPABILITY_AREA)0x00000107);
  public const ulong TPM_CAP_PROP_AUTHSESS = ((TPM_CAPABILITY_AREA)0x0000010A);
  public const ulong TPM_CAP_PROP_TRANSESS = ((TPM_CAPABILITY_AREA)0x0000010B);
  public const ulong TPM_CAP_PROP_COUNTERS = ((TPM_CAPABILITY_AREA)0x0000010C);
  public const ulong TPM_CAP_PROP_MAX_AUTHSESS = ((TPM_CAPABILITY_AREA)0x0000010D);
  public const ulong TPM_CAP_PROP_MAX_TRANSESS = ((TPM_CAPABILITY_AREA)0x0000010E);
  public const ulong TPM_CAP_PROP_MAX_COUNTERS = ((TPM_CAPABILITY_AREA)0x0000010F);
  public const ulong TPM_CAP_PROP_MAX_KEYS = ((TPM_CAPABILITY_AREA)0x00000110);
  public const ulong TPM_CAP_PROP_OWNER = ((TPM_CAPABILITY_AREA)0x00000111);
  public const ulong TPM_CAP_PROP_CONTEXT = ((TPM_CAPABILITY_AREA)0x00000112);
  public const ulong TPM_CAP_PROP_MAX_CONTEXT = ((TPM_CAPABILITY_AREA)0x00000113);
  public const ulong TPM_CAP_PROP_FAMILYROWS = ((TPM_CAPABILITY_AREA)0x00000114);
  public const ulong TPM_CAP_PROP_TIS_TIMEOUT = ((TPM_CAPABILITY_AREA)0x00000115);
  public const ulong TPM_CAP_PROP_STARTUP_EFFECT = ((TPM_CAPABILITY_AREA)0x00000116);
  public const ulong TPM_CAP_PROP_DELEGATE_ROW = ((TPM_CAPABILITY_AREA)0x00000117);
  public const ulong TPM_CAP_PROP_DAA_MAX = ((TPM_CAPABILITY_AREA)0x00000119);
  public const ulong CAP_PROP_SESSION_DAA = ((TPM_CAPABILITY_AREA)0x0000011A);
  public const ulong TPM_CAP_PROP_CONTEXT_DIST = ((TPM_CAPABILITY_AREA)0x0000011B);
  public const ulong TPM_CAP_PROP_DAA_INTERRUPT = ((TPM_CAPABILITY_AREA)0x0000011C);
  public const ulong TPM_CAP_PROP_SESSIONS = ((TPM_CAPABILITY_AREA)0x0000011D);
  public const ulong TPM_CAP_PROP_MAX_SESSIONS = ((TPM_CAPABILITY_AREA)0x0000011E);
  public const ulong TPM_CAP_PROP_CMK_RESTRICTION = ((TPM_CAPABILITY_AREA)0x0000011F);
  public const ulong TPM_CAP_PROP_DURATION = ((TPM_CAPABILITY_AREA)0x00000120);
  public const ulong TPM_CAP_PROP_ACTIVE_COUNTER = ((TPM_CAPABILITY_AREA)0x00000122);
  public const ulong TPM_CAP_PROP_MAX_NV_AVAILABLE = ((TPM_CAPABILITY_AREA)0x00000123);
  public const ulong TPM_CAP_PROP_INPUT_BUFFER = ((TPM_CAPABILITY_AREA)0x00000124);

  //
  // Part 2, section 21.4: TPM_CAPABILITY_AREA for SetCapability
  //
  public const ulong TPM_SET_PERM_FLAGS = ((TPM_CAPABILITY_AREA)0x00000001);
  public const ulong TPM_SET_PERM_DATA = ((TPM_CAPABILITY_AREA)0x00000002);
  public const ulong TPM_SET_STCLEAR_FLAGS = ((TPM_CAPABILITY_AREA)0x00000003);
  public const ulong TPM_SET_STCLEAR_DATA = ((TPM_CAPABILITY_AREA)0x00000004);
  public const ulong TPM_SET_STANY_FLAGS = ((TPM_CAPABILITY_AREA)0x00000005);
  public const ulong TPM_SET_STANY_DATA = ((TPM_CAPABILITY_AREA)0x00000006);
}

///
/// Part 2, section 21.6: TPM_CAP_VERSION_INFO
///   [size_is(vendorSpecificSize)] BYTE* vendorSpecific;
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CAP_VERSION_INFO
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_VERSION version;
  public ushort specLevel;
  public byte errataRev;
  public fixed byte tpmVendorID[4];
  public ushort vendorSpecificSize;
  public byte* vendorSpecific;
}

///
/// Part 2, section 21.10: TPM_DA_ACTION_TYPE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DA_ACTION_TYPE
{
  public TPM_STRUCTURE_TAG tag;
  public uint actions;
}

public unsafe partial class EFI
{
  public const ulong TPM_DA_ACTION_FAILURE_MODE = (((uint)1) << 3);
  public const ulong TPM_DA_ACTION_DEACTIVATE = (((uint)1) << 2);
  public const ulong TPM_DA_ACTION_DISABLE = (((uint)1) << 1);
  public const ulong TPM_DA_ACTION_TIMEOUT = (((uint)1) << 0);
}

///
/// Part 2, section 21.7: TPM_DA_INFO
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DA_INFO
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DA_STATE state;
  public ushort currentCount;
  public ushort thresholdCount;
  public TPM_DA_ACTION_TYPE actionAtThreshold;
  public uint actionDependValue;
  public uint vendorDataSize;
  public byte* vendorData;
}

///
/// Part 2, section 21.8: TPM_DA_INFO_LIMITED
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DA_INFO_LIMITED
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DA_STATE state;
  public TPM_DA_ACTION_TYPE actionAtThreshold;
  public uint vendorDataSize;
  public byte* vendorData;
}

public unsafe partial class EFI
{
  //
  // Part 2, section 21.9: CAP_PROPERTY Subcap values for GetCapability
  //
  public const ulong TPM_DA_STATE_INACTIVE = ((byte)0x00);
  public const ulong TPM_DA_STATE_ACTIVE = ((byte)0x01);

  //
  // Part 2, section 22: DAA Structures
  //

  //
  // Part 2, section 22.1: Size definitions
  //
  public const ulong TPM_DAA_SIZE_r0 = (43);
  public const ulong TPM_DAA_SIZE_r1 = (43);
  public const ulong TPM_DAA_SIZE_r2 = (128);
  public const ulong TPM_DAA_SIZE_r3 = (168);
  public const ulong TPM_DAA_SIZE_r4 = (219);
  public const ulong TPM_DAA_SIZE_NT = (20);
  public const ulong TPM_DAA_SIZE_v0 = (128);
  public const ulong TPM_DAA_SIZE_v1 = (192);
  public const ulong TPM_DAA_SIZE_NE = (256);
  public const ulong TPM_DAA_SIZE_w = (256);
  public const ulong TPM_DAA_SIZE_issuerModulus = (256);
  //
  // Part 2, section 22.2: Constant definitions
  //
  public const ulong TPM_DAA_power0 = (104);
  public const ulong TPM_DAA_power1 = (1024);
}

///
/// Part 2, section 22.3: TPM_DAA_ISSUER
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DAA_ISSUER
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DIGEST DAA_digest_R0;
  public TPM_DIGEST DAA_digest_R1;
  public TPM_DIGEST DAA_digest_S0;
  public TPM_DIGEST DAA_digest_S1;
  public TPM_DIGEST DAA_digest_n;
  public TPM_DIGEST DAA_digest_gamma;
  public fixed byte DAA_generic_q[26];
}

///
/// Part 2, section 22.4: TPM_DAA_TPM
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DAA_TPM
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DIGEST DAA_digestIssuer;
  public TPM_DIGEST DAA_digest_v0;
  public TPM_DIGEST DAA_digest_v1;
  public TPM_DIGEST DAA_rekey;
  public uint DAA_count;
}

///
/// Part 2, section 22.5: TPM_DAA_CONTEXT
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DAA_CONTEXT
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_DIGEST DAA_digestContext;
  public TPM_DIGEST DAA_digest;
  public TPM_DAA_CONTEXT_SEED DAA_contextSeed;
  public fixed byte DAA_scratch[256];
  public byte DAA_stage;
}

///
/// Part 2, section 22.6: TPM_DAA_JOINDATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DAA_JOINDATA
{
  public fixed byte DAA_join_u0[128];
  public fixed byte DAA_join_u1[138];
  public TPM_DIGEST DAA_digest_n0;
}

///
/// Part 2, section 22.8: TPM_DAA_BLOB
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DAA_BLOB
{
  public TPM_STRUCTURE_TAG tag;
  public TPM_RESOURCE_TYPE resourceType;
  public fixed byte label[16];
  public TPM_DIGEST blobIntegrity;
  public uint additionalSize;
  public byte* additionalData;
  public uint sensitiveSize;
  public byte* sensitiveData;
}

///
/// Part 2, section 22.9: TPM_DAA_SENSITIVE
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_DAA_SENSITIVE
{
  public TPM_STRUCTURE_TAG tag;
  public uint internalSize;
  public byte* internalData;
}

//
// Part 2, section 23: Redirection
//

public unsafe partial class EFI
{
  ///
  /// Part 2 section 23.1: TPM_REDIR_COMMAND
  /// This section defines exactly one value but does not
  /// give it a name. The definition of TPM_SetRedirection in Part3
  /// refers to exactly one name but does not give its value. We join
  /// them here.
  ///
  public const ulong TPM_REDIR_GPIO = (0x00000001);
}

///
/// TPM Command Headers defined in Part 3
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_RQU_COMMAND_HDR
{
  public TPM_STRUCTURE_TAG tag;
  public uint paramSize;
  public TPM_COMMAND_CODE ordinal;
}

///
/// TPM Response Headers defined in Part 3
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_RSP_COMMAND_HDR
{
  public TPM_STRUCTURE_TAG tag;
  public uint paramSize;
  public TPM_RESULT returnCode;
}

// #pragma pack ()

// #endif
