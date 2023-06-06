using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Include file matches things in PI for multiple module types.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  These elements are defined in UEFI Platform Initialization Specification 1.2.

**/

// #ifndef __PI_MULTIPHASE_H__
// #define __PI_MULTIPHASE_H__

// #include <Pi/PiFirmwareVolume.h>
// #include <Pi/PiFirmwareFile.h>
// #include <Pi/PiBootMode.h>
// #include <Pi/PiHob.h>
// #include <Pi/PiDependency.h>
// #include <Pi/PiStatusCode.h>
// #include <Pi/PiS3BootScript.h>

/**
  Produces an error code in the range reserved for use by the Platform Initialization
  Architecture Specification.

  The supported 32-bit range is 0xA0000000-0xBFFFFFFF
  The supported 64-bit range is 0xA000000000000000-0xBFFFFFFFFFFFFFFF

  @param  StatusCode    The status code value to convert into a warning code.
                        StatusCode must be in the range 0x00000000..0x1FFFFFFF.

  @return The value specified by StatusCode in the PI reserved range.

**/
public unsafe partial class EFI
{
  //public const ulong DXE_ERROR = (StatusCode)  (MAX_BIT | (MAX_BIT >> 2) | StatusCode);

  ///
  /// If this value is returned by an EFI image, then the image should be unloaded.
  ///
  //public const ulong EFI_REQUEST_UNLOAD_IMAGE = DXE_ERROR (1);

  ///
  /// If this value is returned by an API, it means the capability is not yet
  /// installed/available/ready to use.
  ///
  //public const ulong EFI_NOT_AVAILABLE_YET = DXE_ERROR (2);

  ///
  /// Success and warning codes reserved for use by PI.
  /// Supported 32-bit range is 0x20000000-0x3fffffff.
  /// Supported 64-bit range is 0x2000000000000000-0x3fffffffffffffff.
  ///
  //public const ulong PI_ENCODE_WARNING = (a)  ((MAX_BIT >> 2) | (a));

  ///
  /// Error codes reserved for use by PI.
  /// Supported 32-bit range is 0xa0000000-0xbfffffff.
  /// Supported 64-bit range is 0xa000000000000000-0xbfffffffffffffff.
  ///
  //public const ulong PI_ENCODE_ERROR = (a)  (MAX_BIT | (MAX_BIT >> 2) | (a));

  ///
  /// Return status codes defined in SMM CIS.
  ///
  //public const ulong EFI_INTERRUPT_PENDING = PI_ENCODE_ERROR (0);

  //public const ulong EFI_WARN_INTERRUPT_SOURCE_PENDING = PI_ENCODE_WARNING (0);
  //public const ulong EFI_WARN_INTERRUPT_SOURCE_QUIESCED = PI_ENCODE_WARNING (1);

  ///
  /// Bitmask of values for Authentication Status.
  /// Authentication Status is returned from EFI_GUIDED_SECTION_EXTRACTION_PROTOCOL
  /// and the EFI_PEI_GUIDED_SECTION_EXTRACTION_PPI
  ///
  /// xx00 Image was not signed.
  /// xxx1 Platform security policy override. Assumes the same meaning as 0010 (the image was signed, the
  ///      signature was tested, and the signature passed authentication test).
  /// 0010 Image was signed, the signature was tested, and the signature passed authentication test.
  /// 0110 Image was signed and the signature was not tested.
  /// 1010 Image was signed, the signature was tested, and the signature failed the authentication test.
  ///
  ///@{
  public const ulong EFI_AUTH_STATUS_PLATFORM_OVERRIDE = 0x01;
  public const ulong EFI_AUTH_STATUS_IMAGE_SIGNED = 0x02;
  public const ulong EFI_AUTH_STATUS_NOT_TESTED = 0x04;
  public const ulong EFI_AUTH_STATUS_TEST_FAILED = 0x08;
  public const ulong EFI_AUTH_STATUS_ALL = 0x0f;
  ///@}

  ///
  /// MMRAM states and capabilities
  ///
  public const ulong EFI_MMRAM_OPEN = 0x00000001;
  public const ulong EFI_MMRAM_CLOSED = 0x00000002;
  public const ulong EFI_MMRAM_LOCKED = 0x00000004;
  public const ulong EFI_CACHEABLE = 0x00000008;
  public const ulong EFI_ALLOCATED = 0x00000010;
  public const ulong EFI_NEEDS_TESTING = 0x00000020;
  public const ulong EFI_NEEDS_ECC_INITIALIZATION = 0x00000040;

  public const ulong EFI_SMRAM_OPEN = EFI_MMRAM_OPEN;
  public const ulong EFI_SMRAM_CLOSED = EFI_MMRAM_CLOSED;
  public const ulong EFI_SMRAM_LOCKED = EFI_MMRAM_LOCKED;
}

///
/// Structure describing a MMRAM region and its accessibility attributes.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MMRAM_DESCRIPTOR
{
  ///
  /// Designates the physical address of the MMRAM in memory. This view of memory is
  /// the same as seen by I/O-based agents, for example, but it may not be the address seen
  /// by the processors.
  ///
  public EFI_PHYSICAL_ADDRESS PhysicalStart;
  ///
  /// Designates the address of the MMRAM, as seen by software executing on the
  /// processors. This address may or may not match PhysicalStart.
  ///
  public EFI_PHYSICAL_ADDRESS CpuStart;
  ///
  /// Describes the number of bytes in the MMRAM region.
  ///
  public ulong PhysicalSize;
  ///
  /// Describes the accessibility attributes of the MMRAM.  These attributes include the
  /// hardware state (e.g., Open/Closed/Locked), capability (e.g., cacheable), logical
  /// allocation (e.g., allocated), and pre-use initialization (e.g., needs testing/ECC
  /// initialization).
  ///
  public ulong RegionState;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMRAM_DESCRIPTOR { EFI_MMRAM_DESCRIPTOR Value; public static implicit operator EFI_SMRAM_DESCRIPTOR(EFI_MMRAM_DESCRIPTOR value) => new EFI_SMRAM_DESCRIPTOR() { Value = value }; public static implicit operator EFI_MMRAM_DESCRIPTOR(EFI_SMRAM_DESCRIPTOR value) => value.Value; }

///
/// Structure describing a MMRAM region which cannot be used for the MMRAM heap.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MM_RESERVED_MMRAM_REGION
{
  ///
  /// Starting address of the reserved MMRAM area, as it appears while MMRAM is open.
  /// Ignored if MmramReservedSize is 0.
  ///
  public EFI_PHYSICAL_ADDRESS MmramReservedStart;
  ///
  /// Number of bytes occupied by the reserved MMRAM area. A size of zero indicates the
  /// last MMRAM area.
  ///
  public ulong MmramReservedSize;
}

public enum EFI_PCD_TYPE
{
  EFI_PCD_TYPE_8,
  EFI_PCD_TYPE_16,
  EFI_PCD_TYPE_32,
  EFI_PCD_TYPE_64,
  EFI_PCD_TYPE_BOOL,
  EFI_PCD_TYPE_PTR
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCD_INFO
{
  ///
  /// The returned information associated with the requested TokenNumber. If
  /// TokenNumber is 0, then PcdType is set to EFI_PCD_TYPE_8.
  ///
  public EFI_PCD_TYPE PcdType;
  ///
  /// The size of the data in bytes associated with the TokenNumber specified. If
  /// TokenNumber is 0, then PcdSize is set 0.
  ///
  public ulong PcdSize;
  ///
  /// The null-terminated ASCII string associated with a given token. If the
  /// TokenNumber specified was 0, then this field corresponds to the null-terminated
  /// ASCII string associated with the token's namespace Guid. If NULL, there is no
  /// name associated with this request.
  ///
  public byte* PcdName;
}

// /**
//   The function prototype for invoking a function on an Application Processor.
// 
//   This definition is used by the UEFI MP Serices Protocol, and the
//   PI SMM System Table.
// 
//   @param[in,out] Buffer  The pointer to private data buffer.
// **/
// typedef
// VOID
// (EFIAPI *EFI_AP_PROCEDURE)(
//   IN OUT void  *Buffer
//   );

// /**
//   The function prototype for invoking a function on an Application Processor.
// 
//   This definition is used by the UEFI MM MP Serices Protocol.
// 
//   @param[in] ProcedureArgument    The pointer to private data buffer.
// 
//   @retval EFI_SUCCESS             Excutive the procedure successfully
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_AP_PROCEDURE2)(
//   IN void  *ProcedureArgument
//   );

// #endif
