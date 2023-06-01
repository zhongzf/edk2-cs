namespace Uefi;
/** @file
  SimpleFileSystem protocol as defined in the UEFI 2.0 specification.

  The SimpleFileSystem protocol is the programmatic access to the FAT (12,16,32)
  file system specified in UEFI 2.0. It can also be used to abstract a file
  system other than FAT.

  UEFI 2.0 can boot from any valid EFI image contained in a SimpleFileSystem.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SIMPLE_FILE_SYSTEM_H__
// #define __SIMPLE_FILE_SYSTEM_H__

public static EFI_GUID EFI_SIMPLE_FILE_SYSTEM_PROTOCOL_GUID = new GUID( 
    0x964e5b22, 0x6459, 0x11d2, new byte[] {0x8e, 0x39, 0x0, 0xa0, 0xc9, 0x69, 0x72, 0x3b });

// typedef struct _EFI_SIMPLE_FILE_SYSTEM_PROTOCOL EFI_SIMPLE_FILE_SYSTEM_PROTOCOL;

// typedef struct _EFI_FILE_PROTOCOL EFI_FILE_PROTOCOL;
typedef struct _EFI_FILE_PROTOCOL *EFI_FILE_HANDLE;

///
/// Protocol GUID name defined in EFI1.1.
///
public static ulong SIMPLE_FILE_SYSTEM_PROTOCOL = EFI_SIMPLE_FILE_SYSTEM_PROTOCOL_GUID;

///
/// Protocol name defined in EFI1.1.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FILE_IO_INTERFACE { EFI_SIMPLE_FILE_SYSTEM_PROTOCOL Value; public static implicit operator EFI_FILE_IO_INTERFACE(EFI_SIMPLE_FILE_SYSTEM_PROTOCOL value) => new EFI_FILE_IO_INTERFACE() { Value = value }; public static implicit operator EFI_SIMPLE_FILE_SYSTEM_PROTOCOL(EFI_FILE_IO_INTERFACE value) => value.Value;}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FILE { EFI_FILE_PROTOCOL Value; public static implicit operator EFI_FILE(EFI_FILE_PROTOCOL value) => new EFI_FILE() { Value = value }; public static implicit operator EFI_FILE_PROTOCOL(EFI_FILE value) => value.Value;}




























public static ulong EFI_SIMPLE_FILE_SYSTEM_PROTOCOL_REVISION = 0x00010000;

///
/// Revision defined in EFI1.1
///
public static ulong EFI_FILE_IO_INTERFACE_REVISION = EFI_SIMPLE_FILE_SYSTEM_PROTOCOL_REVISION;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SIMPLE_FILE_SYSTEM_PROTOCOL {
  ///
  /// The version of the EFI_SIMPLE_FILE_SYSTEM_PROTOCOL. The version
  /// specified by this specification is 0x00010000. All future revisions
  /// must be backwards compatible.
  ///
 public ulong                                         Revision;
/**
  Open the root directory on a volume.








































  @retval EFI_MEDIA_CHANGED    The device has a different medium in it or the medium is no
                               longer supported.
  @retval EFI_DEVICE_ERROR     The device reported an error.
  @retval EFI_VOLUME_CORRUPTED The file system structures are corrupted.
  @retval EFI_WRITE_PROTECTED  An attempt was made to create a file, or open a file for write
                               when the media is write-protected.
  @retval EFI_ACCESS_DENIED    The service denied access to the file.
  @retval EFI_OUT_OF_RESOURCES Not enough resources were available to open the file.
  @retval EFI_VOLUME_FULL      The volume is full.

**/
typedef
EFI_STATUS
(EFIAPI *EFI_FILE_OPEN)(
  IN EFI_FILE_PROTOCOL        *This,
  OUT EFI_FILE_PROTOCOL       **NewHandle,
  IN char                   *FileName,
  IN ulong                   OpenMode,
  IN ulong                   Attributes














public static ulong EFI_FILE_SYSTEM = 0x0000000000000004;















EFI_STATUS



























  @param  Buffer     The buffer into which the data is read.



























  @param  Buffer     The buffer of data to write.






































  );




























  @param  Buffer          A pointer to the data buffer to return. The buffer's type is










































                               file that is already present.




















/**
  Flushes all modified data associated with a file to a device.

  @param  This A pointer to the EFI_FILE_PROTOCOL instance that is the file
               handle to flush.

  @retval EFI_SUCCESS          The data was flushed.
  @retval EFI_NO_MEDIA         The device has no medium.
  @retval EFI_DEVICE_ERROR     The device reported an error.
  @retval EFI_VOLUME_CORRUPTED The file system structures are corrupted.
  @retval EFI_WRITE_PROTECTED  The file or medium is write-protected.
  @retval EFI_ACCESS_DENIED    The file was opened read-only.
  @retval EFI_VOLUME_FULL      The volume is full.

**/
typedef
EFI_STATUS
(EFIAPI *EFI_FILE_FLUSH)(
  IN EFI_FILE_PROTOCOL  *This
  );

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FILE_IO_TOKEN {
  //
  // If Event is NULL, then blocking I/O is performed.
  // If Event is not NULL and non-blocking I/O is supported, then non-blocking I/O is performed,
  // and Event will be signaled when the read request is completed.
  // The caller must be prepared to handle the case where the callback associated with Event
  // occurs before the original asynchronous I/O request call returns.
  //
 public EFI_EVENT     Event;

  //
  // Defines whether or not the signaled event encountered an error.
  //
 public EFI_STATUS    Status;










































                               longer supported.










































































  @param  Token A pointer to the token associated with the transaction.

  @retval EFI_SUCCESS          If Event is NULL (blocking I/O): The data was read successfully.
                               If Event is not NULL (asynchronous I/O): The request was successfully
                                                                        queued for processing.
  @retval EFI_NO_MEDIA         The device has no medium.
  @retval EFI_DEVICE_ERROR     The device reported an error.
  @retval EFI_VOLUME_CORRUPTED The file system structures are corrupted.
  @retval EFI_WRITE_PROTECTED  The file or medium is write-protected.
  @retval EFI_ACCESS_DENIED    The file was opened read-only.
  @retval EFI_VOLUME_FULL      The volume is full.
  @retval EFI_OUT_OF_RESOURCES Unable to queue the request due to lack of resources.

**/
typedef
EFI_STATUS
(EFIAPI *EFI_FILE_FLUSH_EX)(
  IN EFI_FILE_PROTOCOL        *This,
  IN OUT EFI_FILE_IO_TOKEN    *Token
  );

public static ulong EFI_FILE_PROTOCOL_REVISION = 0x00010000;
public static ulong EFI_FILE_PROTOCOL_REVISION2 = 0x00020000;
public static ulong EFI_FILE_PROTOCOL_LATEST_REVISION = EFI_FILE_PROTOCOL_REVISION2;

//
// Revision defined in EFI1.1.
//
public static ulong EFI_FILE_REVISION = EFI_FILE_PROTOCOL_REVISION;

///
/// The EFI_FILE_PROTOCOL provides file IO access to supported file systems.
/// An EFI_FILE_PROTOCOL provides access to a file's or directory's contents,
/// and is also a reference to a location in the directory tree of the file system
/// in which the file resides. With any given file handle, other files may be opened
/// relative to this file's location, yielding new file handles.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FILE_PROTOCOL {
  ///
  /// The version of the EFI_FILE_PROTOCOL interface. The version specified
  /// by this specification is EFI_FILE_PROTOCOL_LATEST_REVISION.
  /// Future versions are required to be backward compatible to version 1.0.
  ///
 public ulong                   Revision;
 public EFI_FILE_OPEN            Open;
 public EFI_FILE_CLOSE           Close;
/**
  Closes a specified file handle.

  @param  This          A pointer to the EFI_FILE_PROTOCOL instance that is the file
                        handle to close.

  @retval EFI_SUCCESS   The file was closed.

**/
public readonly delegate* unmanaged<, EFI_STATUS> Delete;
 public EFI_FILE_READ            Read;
 public EFI_FILE_WRITE           Write;
/**
  Sets a file's current position.

  @param  This            A pointer to the EFI_FILE_PROTOCOL instance that is the
                          file handle to set the requested position on.
  @param  Position        The byte position from the start of the file to set.

  @retval EFI_SUCCESS      The position was set.
  @retval EFI_UNSUPPORTED  The seek request for nonzero is not valid on open
                           directories.
  @retval EFI_DEVICE_ERROR An attempt was made to set the position of a deleted file.

**/
public readonly delegate* unmanaged<EFI_FILE_PROTOCOL*,ulong, EFI_STATUS> GetPosition;
 public EFI_FILE_SET_POSITION    SetPosition;
 public EFI_FILE_GET_INFO        GetInfo;
 public EFI_FILE_SET_INFO        SetInfo;
 public EFI_FILE_FLUSH           Flush;
 public EFI_FILE_OPEN_EX         OpenEx;
 public EFI_FILE_READ_EX         ReadEx;
 public EFI_FILE_WRITE_EX        WriteEx;
 public EFI_FILE_FLUSH_EX        FlushEx;
}

// extern EFI_GUID  gEfiSimpleFileSystemProtocolGuid;

// #endif
