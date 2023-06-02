using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file defines the EFI REST JSON Structure Protocol interface.

  (C) Copyright 2020 Hewlett Packard Enterprise Development LP<BR>

  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.8

**/

// #ifndef EFI_REST_JSON_STRUCTURE_PROTOCOL_H_
// #define EFI_REST_JSON_STRUCTURE_PROTOCOL_H_

///
/// GUID definitions
///
public unsafe partial class EFI
{
  public static EFI_GUID EFI_REST_JSON_STRUCTURE_PROTOCOL_GUID = new GUID(
      0xa9a048f6, 0x48a0, 0x4714, new byte[] { 0xb7, 0xda, 0xa9, 0xad, 0x87, 0xd4, 0xda, 0xc9 });
}

typedef struct _EFI_REST_JSON_STRUCTURE_PROTOCOL  EFI_REST_JSON_STRUCTURE_PROTOCOL;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REST_JSON_RESOURCE_TYPE_DATATYPE { byte* Value; public static implicit operator EFI_REST_JSON_RESOURCE_TYPE_DATATYPE(byte* value) => new EFI_REST_JSON_RESOURCE_TYPE_DATATYPE() { Value = value }; public static implicit operator byte*(EFI_REST_JSON_RESOURCE_TYPE_DATATYPE value) => value.Value; }

///
/// Structure defintions of resource name space.
///
/// The fields declared in this structure define the
/// name and revision of payload delievered throught
/// REST API.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REST_JSON_RESOURCE_TYPE_NAMESPACE
{
  public byte* ResourceTypeName; ///< Resource type name
  public byte* MajorVersion;     ///< Resource major version
  public byte* MinorVersion;     ///< Resource minor version
  public byte* ErrataVersion;    ///< Resource errata version
}

///
/// REST resource type identifier
///
/// REST resource type consists of name space and data type.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REST_JSON_RESOURCE_TYPE_IDENTIFIER
{
  public EFI_REST_JSON_RESOURCE_TYPE_NAMESPACE NameSpace; ///< Namespace of this resource type.
  public EFI_REST_JSON_RESOURCE_TYPE_DATATYPE DataType;  ///< Name of data type declared in this
                                                         ///< resource type.
}

///
/// List of JSON to C structure conversions which this convertor supports.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REST_JSON_STRUCTURE_SUPPORTED
{
  public LIST_ENTRY NextSupportedRsrcInterp; ///< Linklist to next supported conversion.
  public EFI_REST_JSON_RESOURCE_TYPE_IDENTIFIER RestResourceInterp;      ///< JSON resource type this convertor supports.
}

///
/// The header file of JSON C structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REST_JSON_STRUCTURE_HEADER
{
  public EFI_REST_JSON_RESOURCE_TYPE_IDENTIFIER JsonRsrcIdentifier; ///< Resource identifier which use to
                                                                    ///< choice the proper interpreter.
                                                                    ///< Follow by a pointer points to JSON structure, the content in the
                                                                    ///< JSON structure is implementation-specific according to converter producer.
  public void* JsonStructurePointer;
}

///
/// EFI REST JSON to C structure protocol definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REST_JSON_STRUCTURE_PROTOCOL
{
  public EFI_REST_JSON_STRUCTURE_REGISTER Register;         ///< Register JSON to C structure convertor
  public EFI_REST_JSON_STRUCTURE_TO_STRUCTURE ToStructure;      ///< The function to convert JSON to C structure
  public EFI_REST_JSON_STRUCTURE_TO_JSON ToJson;           ///< The function to convert C structure to JSON
  public EFI_REST_JSON_STRUCTURE_DESTORY_STRUCTURE DestoryStructure; ///< Destory C structure.
}

// #endif
