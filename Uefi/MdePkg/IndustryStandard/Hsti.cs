using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Support for HSTI 1.1a specification, defined at
  Microsoft Hardware Security Testability Specification.

  Copyright (c) 2015 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __HSTI_H__
// #define __HSTI_H__

// #pragma pack(1)

public unsafe partial class EFI
{
  public static EFI_GUID ADAPTER_INFO_PLATFORM_SECURITY_GUID => new GUID(0x6be272c7, 0x1320, 0x4ccd, 0x90, 0x17, 0xd4, 0x61, 0x2c, 0x01, 0x2b, 0x25);

  public const ulong PLATFORM_SECURITY_VERSION_VNEXTCS = 0x00000003;

  public const ulong PLATFORM_SECURITY_ROLE_PLATFORM_REFERENCE = 0x00000001; //  IHV
  public const ulong PLATFORM_SECURITY_ROLE_PLATFORM_IBV = 0x00000002;
  public const ulong PLATFORM_SECURITY_ROLE_IMPLEMENTOR_OEM = 0x00000003;
  public const ulong PLATFORM_SECURITY_ROLE_IMPLEMENTOR_ODM = 0x00000004;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct ADAPTER_INFO_PLATFORM_SECURITY
{
  //
  //  Return PLATFORM_SECURITY_VERSION_VNEXTCS
  //
  public uint Version;
  //
  // The role of the publisher of this interface.  Reference platform designers
  // such as IHVs and IBVs are expected to return PLATFORM_SECURITY_ROLE_PLATFORM_REFERENCE
  // and PLATFORM_SECURITY_ROLE_PLATFORM_IBV respectively.
  // If the test modules from the designers are unable to fully verify all
  // security features, then the platform implementers, OEMs and ODMs, will
  // need to publish this interface with a role of Implementer.
  //
  public uint Role;
  //
  // Human readable vendor, model, & version of this implementation.
  //
  public fixed char ImplementationID[256];
  //
  // The size in bytes of the SecurityFeaturesRequired and SecurityFeaturesEnabled arrays.
  // The arrays must be the same size.
  //
  public uint SecurityFeaturesSize;
  //
  // IHV-defined bitfield corresponding to all security features which must be
  // implemented to meet the security requirements defined by PLATFORM_SECURITY_VERSION Version.
  //
  // byte   SecurityFeaturesRequired[];     //Ignored for non-IHV
  //
  // Publisher-defined bitfield corresponding to all security features which
  // have implemented programmatic tests in this module.
  //
  // byte   SecurityFeaturesImplemented[];
  //
  // Publisher-defined bitfield corresponding to all security features which
  // have been verified implemented by this implementation.
  //
  // byte   SecurityFeaturesVerified[];
  //
  // A Null-terminated string, one failure per line (CR/LF terminated), with a
  // unique identifier that the OEM/ODM can use to locate the documentation
  // which will describe the steps to remediate the failure - a URL to the
  // documentation is recommended.
  //
  // char  ErrorString[];
}

// #pragma pack()

// extern EFI_GUID  gAdapterInfoPlatformSecurityGuid;

// #endif
