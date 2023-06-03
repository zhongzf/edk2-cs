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

public unsafe partial class EFI
{
  ///
  /// GUID definitions
  ///
  public static EFI_GUID EFI_REST_JSON_STRUCTURE_PROTOCOL_GUID = new GUID(
      0xa9a048f6, 0x48a0, 0x4714, new byte[] { 0xb7, 0xda, 0xa9, 0xad, 0x87, 0xd4, 0xda, 0xc9 });
}

//typedef struct _EFI_REST_JSON_STRUCTURE_PROTOCOL  EFI_REST_JSON_STRUCTURE_PROTOCOL;
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

// /**
//   JSON-IN C Structure-OUT function. Convert the given REST JSON resource into structure.
// 
//   @param[in]    This                This is the EFI_REST_JSON_STRUCTURE_PROTOCOL instance.
//   @param[in]    JsonRsrcIdentifier  This indicates the resource type and version is given in
//                                     ResourceJsonText.
//   @param[in]    ResourceJsonText    REST JSON resource in text format.
//   @param[out]   JsonStructure       Pointer to receive the pointer to EFI_REST_JSON_STRUCTURE_HEADER
// 
//   @retval EFI_SUCCESS
//   @retval Others
// --*/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_REST_JSON_STRUCTURE_TO_STRUCTURE)(
//   IN  EFI_REST_JSON_STRUCTURE_PROTOCOL        *This,
//   IN  EFI_REST_JSON_RESOURCE_TYPE_IDENTIFIER *JsonRsrcIdentifier OPTIONAL,
//   IN  byte                                   *ResourceJsonText,
//   OUT  EFI_REST_JSON_STRUCTURE_HEADER         **JsonStructure
//   );

// /**
//   Convert the given REST JSON structure into JSON text.
// 
//   @param[in]    This                 This is the EFI_REST_JSON_STRUCTURE_PROTOCOL instance.
//   @param[in]    JsonStructureHeader  The point to EFI_REST_JSON_STRUCTURE_HEADER  structure.
//   @param[out]   ResourceJsonText     Pointer to receive REST JSON resource in text format.
// 
//   @retval EFI_SUCCESS
//   @retval Others
// 
// --*/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_REST_JSON_STRUCTURE_TO_JSON)(
//   IN EFI_REST_JSON_STRUCTURE_PROTOCOL     *This,
//   IN EFI_REST_JSON_STRUCTURE_HEADER       *JsonStructureHeader,
//   OUT byte                               **ResourceJsonText
//   );

// /**
//   This function destroys the REST JSON structure.
// 
//   @param[in]    This                 This is the EFI_REST_JSON_STRUCTURE_PROTOCOL instance.
//   @param[in]    JsonStructureHeader  JSON structure to destroy.
// 
//   @retval EFI_SUCCESS
//   @retval Others
// 
// --*/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_REST_JSON_STRUCTURE_DESTORY_STRUCTURE)(
//   IN EFI_REST_JSON_STRUCTURE_PROTOCOL   *This,
//   IN EFI_REST_JSON_STRUCTURE_HEADER     *JsonStructureHeader
//   );

// /**
//   This function provides REST JSON resource to structure converter registration.
// 
//   @param[in]    This                     This is the EFI_REST_JSON_STRUCTURE_PROTOCOL instance.
//   @param[in]    JsonStructureSupported   The type and version of REST JSON resource which this converter
//                                          supports.
//   @param[in]    ToStructure              The function to convert REST JSON resource to structure.
//   @param[in]    ToJson                   The function to convert REST JSON structure to JSON in text format.
//   @param[in]    DestroyStructure         Destroy REST JSON structure returned in ToStructure() function.
// 
//   @retval EFI_SUCCESS             Register successfully.
//   @retval Others                  Fail to register.
// 
// --*/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_REST_JSON_STRUCTURE_REGISTER)(
//   IN EFI_REST_JSON_STRUCTURE_PROTOCOL       *This,
//   IN EFI_REST_JSON_STRUCTURE_SUPPORTED      *JsonStructureSupported,
//   IN EFI_REST_JSON_STRUCTURE_TO_STRUCTURE   ToStructure,
//   IN EFI_REST_JSON_STRUCTURE_TO_JSON        ToJson,
//   IN EFI_REST_JSON_STRUCTURE_DESTORY_STRUCTURE DestroyStructure
//   );

///
/// EFI REST JSON to C structure protocol definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_REST_JSON_STRUCTURE_PROTOCOL
{
  public readonly delegate* unmanaged</* IN */EFI_REST_JSON_STRUCTURE_PROTOCOL* /*This*/,/* IN */EFI_REST_JSON_STRUCTURE_SUPPORTED* /*JsonStructureSupported*/,/* IN */EFI_REST_JSON_STRUCTURE_TO_STRUCTURE /*ToStructure*/,/* IN */EFI_REST_JSON_STRUCTURE_TO_JSON /*ToJson*/,/* IN */EFI_REST_JSON_STRUCTURE_DESTORY_STRUCTURE /*DestroyStructure*/, EFI_STATUS> /*EFI_REST_JSON_STRUCTURE_REGISTER*/ Register;
  public readonly delegate* unmanaged</* IN */EFI_REST_JSON_STRUCTURE_PROTOCOL* /*This*/,/* IN */EFI_REST_JSON_RESOURCE_TYPE_IDENTIFIER* /*JsonRsrcIdentifier*/,/* IN */byte* /*ResourceJsonText*/,/* OUT */EFI_REST_JSON_STRUCTURE_HEADER** /*JsonStructure*/, EFI_STATUS> /*EFI_REST_JSON_STRUCTURE_TO_STRUCTURE*/ ToStructure;
  public readonly delegate* unmanaged</* IN */EFI_REST_JSON_STRUCTURE_PROTOCOL* /*This*/,/* IN */EFI_REST_JSON_STRUCTURE_HEADER* /*JsonStructureHeader*/,/* OUT */byte** /*ResourceJsonText*/, EFI_STATUS> /*EFI_REST_JSON_STRUCTURE_TO_JSON*/ ToJson;
  public readonly delegate* unmanaged</* IN */EFI_REST_JSON_STRUCTURE_PROTOCOL* /*This*/,/* IN */EFI_REST_JSON_STRUCTURE_HEADER* /*JsonStructureHeader*/, EFI_STATUS> /*EFI_REST_JSON_STRUCTURE_DESTORY_STRUCTURE*/ DestoryStructure;
}

// #endif
