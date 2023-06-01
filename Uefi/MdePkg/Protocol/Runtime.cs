namespace Uefi;
/** @file
  Runtime Architectural Protocol as defined in PI Specification VOLUME 2 DXE

  Allows the runtime functionality of the DXE Foundation to be contained
  in a separate driver. It also provides hooks for the DXE Foundation to
  export information that is needed at runtime. As such, this protocol allows
  services to the DXE Foundation to manage runtime drivers and events.
  This protocol also implies that the runtime services required to transition
  to virtual mode, SetVirtualAddressMap() and ConvertPointer(), have been
  registered into the UEFI Runtime Table in the UEFI System Table. This protocol
  must be produced by a runtime DXE driver and may only be consumed by the DXE Foundation.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __ARCH_PROTOCOL_RUNTIME_H__
// #define __ARCH_PROTOCOL_RUNTIME_H__

///
/// Global ID for the Runtime Architectural Protocol
///
public static EFI_GUID EFI_RUNTIME_ARCH_PROTOCOL_GUID = new GUID(0xb7dfb4e1, 0x52f, 0x449f, new byte[] { 0x87, 0xbe, 0x98, 0x18, 0xfc, 0x91, 0xb7, 0x33 });

// typedef struct _EFI_RUNTIME_ARCH_PROTOCOL EFI_RUNTIME_ARCH_PROTOCOL;

///
/// LIST_ENTRY from BaseType
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LIST_ENTRY { LIST_ENTRY Value; public static implicit operator EFI_LIST_ENTRY(LIST_ENTRY value) => new EFI_LIST_ENTRY() { Value = value }; public static implicit operator LIST_ENTRY(EFI_LIST_ENTRY value) => value.Value; }

// typedef struct _EFI_RUNTIME_IMAGE_ENTRY EFI_RUNTIME_IMAGE_ENTRY;

///
/// EFI_RUNTIME_IMAGE_ENTRY
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_RUNTIME_IMAGE_ENTRY
{
  ///
  /// Start of image that has been loaded in memory. It is a pointer
  /// to either the DOS header or PE header of the image.
  ///
  public void* ImageBase;
  ///
  /// Size in bytes of the image represented by ImageBase.
  ///
  public ulong ImageSize;
  ///
  /// Information about the fix-ups that were performed on ImageBase when it was
  /// loaded into memory.
  ///
  public void* RelocationData;
  ///
  /// The ImageHandle passed into ImageBase when it was loaded.
  ///
  public EFI_HANDLE Handle;
  ///
  /// Entry for this node in the EFI_RUNTIME_ARCHITECTURE_PROTOCOL.ImageHead list.
  ///
  public EFI_LIST_ENTRY Link;
}

// typedef struct _EFI_RUNTIME_EVENT_ENTRY EFI_RUNTIME_EVENT_ENTRY;

///
/// EFI_RUNTIME_EVENT_ENTRY
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_RUNTIME_EVENT_ENTRY
{
  ///
  /// The same as Type passed into CreateEvent().
  ///
  public uint Type;
  ///
  /// The same as NotifyTpl passed into CreateEvent().
  ///
  public EFI_TPL NotifyTpl;
  ///
  /// The same as NotifyFunction passed into CreateEvent().
  ///
  public EFI_EVENT_NOTIFY NotifyFunction;
  ///
  /// The same as NotifyContext passed into CreateEvent().
  ///
  public void* NotifyContext;
  ///
  /// The EFI_EVENT returned by CreateEvent(). Event must be in runtime memory.
  ///
  public EFI_EVENT* Event;
  ///
  /// Entry for this node in the
  /// EFI_RUNTIME_ARCHITECTURE_PROTOCOL.EventHead list.
  ///
  public EFI_LIST_ENTRY Link;
}

///
/// Allows the runtime functionality of the DXE Foundation to be contained in a
/// separate driver. It also provides hooks for the DXE Foundation to export
/// information that is needed at runtime. As such, this protocol allows the DXE
/// Foundation to manage runtime drivers and events. This protocol also implies
/// that the runtime services required to transition to virtual mode,
/// SetVirtualAddressMap() and ConvertPointer(), have been registered into the
/// EFI Runtime Table in the EFI System Partition.  This protocol must be produced
/// by a runtime DXE driver and may only be consumed by the DXE Foundation.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_RUNTIME_ARCH_PROTOCOL
{
  public EFI_LIST_ENTRY ImageHead;              ///< A list of type EFI_RUNTIME_IMAGE_ENTRY.
  public EFI_LIST_ENTRY EventHead;              ///< A list of type EFI_RUNTIME_EVENT_ENTRY.
  public ulong MemoryDescriptorSize;   ///< Size of a memory descriptor that is returned by GetMemoryMap().
  public uint MemoryDesciptorVersion; ///< Version of a memory descriptor that is returned by GetMemoryMap().
  public ulong MemoryMapSize;          ///< Size of the memory map in bytes contained in MemoryMapPhysical and MemoryMapVirtual.
  public EFI_MEMORY_DESCRIPTOR* MemoryMapPhysical;     ///< Pointer to a runtime buffer that contains a copy of
                                                       ///< the memory map returned via GetMemoryMap().
  public EFI_MEMORY_DESCRIPTOR* MemoryMapVirtual;      ///< Pointer to MemoryMapPhysical that is updated to virtual mode after SetVirtualAddressMap().
  public bool VirtualMode;            ///< Boolean that is TRUE if SetVirtualAddressMap() has been called.
  public bool AtRuntime;              ///< Boolean that is TRUE if ExitBootServices () has been called.
}

// extern EFI_GUID  gEfiRuntimeArchProtocolGuid;

// #endif
