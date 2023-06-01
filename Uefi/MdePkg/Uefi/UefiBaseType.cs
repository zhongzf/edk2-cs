namespace Uefi;
/** @file
  Defines data types and constants introduced in UEFI.

Copyright (c) 2006 - 2021, Intel Corporation. All rights reserved.<BR>
Portions copyright (c) 2011 - 2016, ARM Ltd. All rights reserved.<BR>
Copyright (c) 2020, Hewlett Packard Enterprise Development LP. All rights reserved.<BR>
Copyright (c) 2022, Loongson Technology Corporation Limited. All rights reserved.<BR>

SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __UEFI_BASETYPE_H__
// #define __UEFI_BASETYPE_H__

// #include <Base.h>

//
// Basic data type definitions introduced in UEFI.
//

///
/// 128-bit buffer containing a unique identifier value.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_GUID { GUID Value; public static implicit operator EFI_GUID(GUID value) => new EFI_GUID() { Value = value }; public static implicit operator GUID(EFI_GUID value) => value.Value; }
///
/// Function return status for EFI API.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_STATUS { RETURN_STATUS Value; public static implicit operator EFI_STATUS(RETURN_STATUS value) => new EFI_STATUS() { Value = value }; public static implicit operator RETURN_STATUS(EFI_STATUS value) => value.Value; }
///
/// A collection of related interfaces.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HANDLE { void* Value; public static implicit operator EFI_HANDLE(void* value) => new EFI_HANDLE() { Value = value }; public static implicit operator void*(EFI_HANDLE value) => value.Value; }
///
/// Handle to an event structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_EVENT { void* Value; public static implicit operator EFI_EVENT(void* value) => new EFI_EVENT() { Value = value }; public static implicit operator void*(EFI_EVENT value) => value.Value; }
///
/// Task priority level.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TPL { ulong Value; public static implicit operator EFI_TPL(ulong value) => new EFI_TPL() { Value = value }; public static implicit operator ulong(EFI_TPL value) => value.Value; }
///
/// Logical block address.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LBA { ulong Value; public static implicit operator EFI_LBA(ulong value) => new EFI_LBA() { Value = value }; public static implicit operator ulong(EFI_LBA value) => value.Value; }

///
/// 64-bit physical memory address.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PHYSICAL_ADDRESS { ulong Value; public static implicit operator EFI_PHYSICAL_ADDRESS(ulong value) => new EFI_PHYSICAL_ADDRESS() { Value = value }; public static implicit operator ulong(EFI_PHYSICAL_ADDRESS value) => value.Value; }

///
/// 64-bit virtual memory address.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_VIRTUAL_ADDRESS { ulong Value; public static implicit operator EFI_VIRTUAL_ADDRESS(ulong value) => new EFI_VIRTUAL_ADDRESS() { Value = value }; public static implicit operator ulong(EFI_VIRTUAL_ADDRESS value) => value.Value; }

///
/// EFI Time Abstraction:
///  Year:       1900 - 9999
///  Month:      1 - 12
///  Day:        1 - 31
///  Hour:       0 - 23
///  Minute:     0 - 59
///  Second:     0 - 59
///  Nanosecond: 0 - 999,999,999
///  TimeZone:   -1440 to 1440 or 2047
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TIME
{
  public ushort Year;
  public byte Month;
  public byte Day;
  public byte Hour;
  public byte Minute;
  public byte Second;
  public byte Pad1;
  public uint Nanosecond;
  public short TimeZone;
  public byte Daylight;
  public byte Pad2;
}

///
/// 4-byte buffer. An IPv4 internet protocol address.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPv4_ADDRESS { IPv4_ADDRESS Value; public static implicit operator EFI_IPv4_ADDRESS(IPv4_ADDRESS value) => new EFI_IPv4_ADDRESS() { Value = value }; public static implicit operator IPv4_ADDRESS(EFI_IPv4_ADDRESS value) => value.Value; }

///
/// 16-byte buffer. An IPv6 internet protocol address.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPv6_ADDRESS { IPv6_ADDRESS Value; public static implicit operator EFI_IPv6_ADDRESS(IPv6_ADDRESS value) => new EFI_IPv6_ADDRESS() { Value = value }; public static implicit operator IPv6_ADDRESS(EFI_IPv6_ADDRESS value) => value.Value; }

///
/// 32-byte buffer containing a network Media Access Control address.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MAC_ADDRESS
{
  public fixed byte Addr[32];
}

///
/// 16-byte buffer aligned on a 4-byte boundary.
/// An IPv4 or IPv6 internet protocol address.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_IP_ADDRESS
{
  [FieldOffset(0)] public fixed uint Addr[4];
  [FieldOffset(0)] public EFI_IPv4_ADDRESS v4;
  [FieldOffset(0)] public EFI_IPv6_ADDRESS v6;
}

///
/// Enumeration of EFI_STATUS.
///@{
public static ulong EFI_SUCCESS = RETURN_SUCCESS;
public static ulong EFI_LOAD_ERROR = RETURN_LOAD_ERROR;
public static ulong EFI_INVALID_PARAMETER = RETURN_INVALID_PARAMETER;
public static ulong EFI_UNSUPPORTED = RETURN_UNSUPPORTED;
public static ulong EFI_BAD_BUFFER_SIZE = RETURN_BAD_BUFFER_SIZE;
public static ulong EFI_BUFFER_TOO_SMALL = RETURN_BUFFER_TOO_SMALL;
public static ulong EFI_NOT_READY = RETURN_NOT_READY;
public static ulong EFI_DEVICE_ERROR = RETURN_DEVICE_ERROR;
public static ulong EFI_WRITE_PROTECTED = RETURN_WRITE_PROTECTED;
public static ulong EFI_OUT_OF_RESOURCES = RETURN_OUT_OF_RESOURCES;
public static ulong EFI_VOLUME_CORRUPTED = RETURN_VOLUME_CORRUPTED;
public static ulong EFI_VOLUME_FULL = RETURN_VOLUME_FULL;
public static ulong EFI_NO_MEDIA = RETURN_NO_MEDIA;
public static ulong EFI_MEDIA_CHANGED = RETURN_MEDIA_CHANGED;
public static ulong EFI_NOT_FOUND = RETURN_NOT_FOUND;
public static ulong EFI_ACCESS_DENIED = RETURN_ACCESS_DENIED;
public static ulong EFI_NO_RESPONSE = RETURN_NO_RESPONSE;
public static ulong EFI_NO_MAPPING = RETURN_NO_MAPPING;
public static ulong EFI_TIMEOUT = RETURN_TIMEOUT;
public static ulong EFI_NOT_STARTED = RETURN_NOT_STARTED;
public static ulong EFI_ALREADY_STARTED = RETURN_ALREADY_STARTED;
public static ulong EFI_ABORTED = RETURN_ABORTED;
public static ulong EFI_ICMP_ERROR = RETURN_ICMP_ERROR;
public static ulong EFI_TFTP_ERROR = RETURN_TFTP_ERROR;
public static ulong EFI_PROTOCOL_ERROR = RETURN_PROTOCOL_ERROR;
public static ulong EFI_INCOMPATIBLE_VERSION = RETURN_INCOMPATIBLE_VERSION;
public static ulong EFI_SECURITY_VIOLATION = RETURN_SECURITY_VIOLATION;
public static ulong EFI_CRC_ERROR = RETURN_CRC_ERROR;
public static ulong EFI_END_OF_MEDIA = RETURN_END_OF_MEDIA;
public static ulong EFI_END_OF_FILE = RETURN_END_OF_FILE;
public static ulong EFI_INVALID_LANGUAGE = RETURN_INVALID_LANGUAGE;
public static ulong EFI_COMPROMISED_DATA = RETURN_COMPROMISED_DATA;
public static ulong EFI_HTTP_ERROR = RETURN_HTTP_ERROR;

public static ulong EFI_WARN_UNKNOWN_GLYPH = RETURN_WARN_UNKNOWN_GLYPH;
public static ulong EFI_WARN_DELETE_FAILURE = RETURN_WARN_DELETE_FAILURE;
public static ulong EFI_WARN_WRITE_FAILURE = RETURN_WARN_WRITE_FAILURE;
public static ulong EFI_WARN_BUFFER_TOO_SMALL = RETURN_WARN_BUFFER_TOO_SMALL;
public static ulong EFI_WARN_STALE_DATA = RETURN_WARN_STALE_DATA;
public static ulong EFI_WARN_FILE_SYSTEM = RETURN_WARN_FILE_SYSTEM;
///@}

///
/// Define macro to encode the status code.
///
public static ulong EFIERR = (_a)ENCODE_ERROR(_a);

public static ulong EFI_ERROR = (A)RETURN_ERROR(A);

///
/// ICMP error definitions
///@{
public static ulong EFI_NETWORK_UNREACHABLE = EFIERR(100);
public static ulong EFI_HOST_UNREACHABLE = EFIERR(101);
public static ulong EFI_PROTOCOL_UNREACHABLE = EFIERR(102);
public static ulong EFI_PORT_UNREACHABLE = EFIERR(103);
///@}

///
/// Tcp connection status definitions
///@{
public static ulong EFI_CONNECTION_FIN = EFIERR(104);
public static ulong EFI_CONNECTION_RESET = EFIERR(105);
public static ulong EFI_CONNECTION_REFUSED = EFIERR(106);
///@}

//
// The EFI memory allocation functions work in units of EFI_PAGEs that are
// 4KB. This should in no way be confused with the page size of the processor.
// An EFI_PAGE is just the quanta of memory in EFI.
//
public static ulong EFI_PAGE_SIZE = SIZE_4KB;
public static ulong EFI_PAGE_MASK = 0xFFF;
public static ulong EFI_PAGE_SHIFT = 12;

/**
  Macro that converts a size, in bytes, to a number of EFI_PAGESs.

  @param  Size      A size in bytes.  This parameter is assumed to be type UINTN.
                    Passing in a parameter that is larger than ulong may produce
                    unexpected results.

  @return  The number of EFI_PAGESs associated with the number of bytes specified
           by Size.

**/
public static ulong EFI_SIZE_TO_PAGES = (Size)(((Size) >> EFI_PAGE_SHIFT) + (((Size) & EFI_PAGE_MASK) ? 1 : 0));

/**
  Macro that converts a number of EFI_PAGEs to a size in bytes.

  @param  Pages     The number of EFI_PAGES.  This parameter is assumed to be
                    type UINTN.  Passing in a parameter that is larger than
                    ulong may produce unexpected results.

  @return  The number of bytes associated with the number of EFI_PAGEs specified
           by Pages.

**/
public static ulong EFI_PAGES_TO_SIZE = (Pages)((Pages) << EFI_PAGE_SHIFT);

///
/// PE32+ Machine type for IA32 UEFI images.
///
public static ulong EFI_IMAGE_MACHINE_IA32 = 0x014C;

///
/// PE32+ Machine type for IA64 UEFI images.
///
public static ulong EFI_IMAGE_MACHINE_IA64 = 0x0200;

///
/// PE32+ Machine type for EBC UEFI images.
///
public static ulong EFI_IMAGE_MACHINE_EBC = 0x0EBC;

///
/// PE32+ Machine type for X64 UEFI images.
///
public static ulong EFI_IMAGE_MACHINE_X64 = 0x8664;

///
/// PE32+ Machine type for ARM mixed ARM and Thumb/Thumb2 images.
///
public static ulong EFI_IMAGE_MACHINE_ARMTHUMB_MIXED = 0x01C2;

///
/// PE32+ Machine type for AARCH64 A64 images.
///
public static ulong EFI_IMAGE_MACHINE_AARCH64 = 0xAA64;

///
/// PE32+ Machine type for RISC-V 32/64/128
///
public static ulong EFI_IMAGE_MACHINE_RISCV32 = 0x5032;
public static ulong EFI_IMAGE_MACHINE_RISCV64 = 0x5064;
public static ulong EFI_IMAGE_MACHINE_RISCV128 = 0x5128;

///
/// PE32+ Machine type for LoongArch 32/64 images.
///
public static ulong EFI_IMAGE_MACHINE_LOONGARCH32 = 0x6232;
public static ulong EFI_IMAGE_MACHINE_LOONGARCH64 = 0x6264;

#if !defined (EFI_IMAGE_MACHINE_TYPE_VALUE) && !defined (EFI_IMAGE_MACHINE_CROSS_TYPE_VALUE)
#if defined (MDE_CPU_IA32)

public static ulong EFI_IMAGE_MACHINE_TYPE_SUPPORTED = (Machine) \;
  ((Machine) == EFI_IMAGE_MACHINE_IA32)

public static ulong EFI_IMAGE_MACHINE_CROSS_TYPE_SUPPORTED = (Machine)  ((Machine) == EFI_IMAGE_MACHINE_X64);

#elif defined (MDE_CPU_X64)

public static ulong EFI_IMAGE_MACHINE_TYPE_SUPPORTED = (Machine) \;
  ((Machine) == EFI_IMAGE_MACHINE_X64)

public static ulong EFI_IMAGE_MACHINE_CROSS_TYPE_SUPPORTED = (Machine)  ((Machine) == EFI_IMAGE_MACHINE_IA32);

#elif defined (MDE_CPU_ARM)

public static ulong EFI_IMAGE_MACHINE_TYPE_SUPPORTED = (Machine)  ((Machine) == EFI_IMAGE_MACHINE_ARMTHUMB_MIXED);

public static ulong EFI_IMAGE_MACHINE_CROSS_TYPE_SUPPORTED = (Machine)  (FALSE);

#elif defined (MDE_CPU_AARCH64)

public static ulong EFI_IMAGE_MACHINE_TYPE_SUPPORTED = (Machine) \;
  ((Machine) == EFI_IMAGE_MACHINE_AARCH64)

public static ulong EFI_IMAGE_MACHINE_CROSS_TYPE_SUPPORTED = (Machine)  (FALSE);

#elif defined (MDE_CPU_RISCV64)
public static ulong EFI_IMAGE_MACHINE_TYPE_SUPPORTED = (Machine) \;
  ((Machine) == EFI_IMAGE_MACHINE_RISCV64)

public static ulong EFI_IMAGE_MACHINE_CROSS_TYPE_SUPPORTED = (Machine)  (FALSE);

#elif defined (MDE_CPU_LOONGARCH64)

public static ulong EFI_IMAGE_MACHINE_TYPE_SUPPORTED = (Machine) \;
    ((Machine) == EFI_IMAGE_MACHINE_LOONGARCH64)

public static ulong EFI_IMAGE_MACHINE_CROSS_TYPE_SUPPORTED = (Machine)  (FALSE);

#elif defined (MDE_CPU_EBC)

///
/// This is just to make sure you can cross compile with the EBC compiler.
/// It does not make sense to have a PE loader coded in EBC.
///
public static ulong EFI_IMAGE_MACHINE_TYPE_SUPPORTED = (Machine)  ((Machine) == EFI_IMAGE_MACHINE_EBC);

public static ulong EFI_IMAGE_MACHINE_CROSS_TYPE_SUPPORTED = (Machine)  (FALSE);

#else
#error Unknown Processor Type
#endif
#else
#if defined (EFI_IMAGE_MACHINE_TYPE_VALUE)
public static ulong EFI_IMAGE_MACHINE_TYPE_SUPPORTED = (Machine)  ((Machine) == EFI_IMAGE_MACHINE_TYPE_VALUE);
#else
public static ulong EFI_IMAGE_MACHINE_TYPE_SUPPORTED = (Machine)  (FALSE);
#endif
#if defined (EFI_IMAGE_MACHINE_CROSS_TYPE_VALUE)
public static ulong EFI_IMAGE_MACHINE_CROSS_TYPE_SUPPORTED = (Machine)  ((Machine) == EFI_IMAGE_MACHINE_CROSS_TYPE_VALUE);
#else
public static ulong EFI_IMAGE_MACHINE_CROSS_TYPE_SUPPORTED = (Machine)  (FALSE);
#endif
// #endif

// #endif
