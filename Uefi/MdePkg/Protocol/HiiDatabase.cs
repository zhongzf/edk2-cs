using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  The file provides Database manager for HII-related data
  structures.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in UEFI Specification 2.1.

**/

// #ifndef __HII_DATABASE_H__
// #define __HII_DATABASE_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_HII_DATABASE_PROTOCOL_GUID = new GUID(0xef9fc172, 0xa1b2, 0x4693, new byte[] { 0xb3, 0x27, 0x6d, 0x32, 0xfc, 0x41, 0x60, 0x42 });

  // typedef struct _EFI_HII_DATABASE_PROTOCOL EFI_HII_DATABASE_PROTOCOL;
}

///
/// EFI_HII_DATABASE_NOTIFY_TYPE.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_DATABASE_NOTIFY_TYPE { ulong Value; public static implicit operator EFI_HII_DATABASE_NOTIFY_TYPE(ulong value) => new EFI_HII_DATABASE_NOTIFY_TYPE() { Value = value }; public static implicit operator ulong(EFI_HII_DATABASE_NOTIFY_TYPE value) => value.Value; }

public unsafe partial class EFI
{
  public const ulong EFI_HII_DATABASE_NOTIFY_NEW_PACK = 0x00000001;
  public const ulong EFI_HII_DATABASE_NOTIFY_REMOVE_PACK = 0x00000002;
  public const ulong EFI_HII_DATABASE_NOTIFY_EXPORT_PACK = 0x00000004;
  public const ulong EFI_HII_DATABASE_NOTIFY_ADD_PACK = 0x00000008;

}

///
/// Database manager for HII-related data structures.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_DATABASE_PROTOCOL
{
  /**

    This function adds the packages in the package list to the
    database and returns a handle. If there is a
    EFI_DEVICE_PATH_PROTOCOL associated with the DriverHandle, then
    this function will create a package of type
    EFI_PACKAGE_TYPE_DEVICE_PATH and add it to the package list. For
    each package in the package list, registered functions with the
    notification type NEW_PACK and having the same package type will
    be called. For each call to NewPackageList(), there should be a
    corresponding call to
    EFI_HII_DATABASE_PROTOCOL.RemovePackageList().

    @param This           A pointer to the EFI_HII_DATABASE_PROTOCOL instance.

    @param PackageList    A pointer to an EFI_HII_PACKAGE_LIST_HEADER structure.

    @param DriverHandle   Associate the package list with this EFI handle.
                          If a NULL is specified, this data will not be associate
                          with any drivers and cannot have a callback induced.

    @param Handle         A pointer to the EFI_HII_HANDLE instance.

    @retval EFI_SUCCESS           The package list associated with the
                                  Handle was added to the HII database.

    @retval EFI_OUT_OF_RESOURCES  Unable to allocate necessary
                                  resources for the new database
                                  contents.

    @retval EFI_INVALID_PARAMETER PackageList is NULL, or Handle is NULL.

  **/
  public readonly delegate* unmanaged<CONST, CONST, EFI_HANDLE, EFI_HII_HANDLE*, EFI_STATUS> NewPackageList;
  /**

    This function removes the package list that is associated with a
    handle Handle from the HII database. Before removing the
    package, any registered functions with the notification type
    REMOVE_PACK and the same package type will be called. For each
    call to EFI_HII_DATABASE_PROTOCOL.NewPackageList(), there should
    be a corresponding call to RemovePackageList.

    @param This             A pointer to the EFI_HII_DATABASE_PROTOCOL instance.

    @param Handle           The handle that was registered to the data
                            that is requested for removal.

    @retval EFI_SUCCESS     The data associated with the Handle was
                            removed from the HII database.
    @retval EFI_NOT_FOUND   The specified Handle is not in database.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_HANDLE, EFI_STATUS> RemovePackageList;
  /**

    This function updates the existing package list (which has the
    specified Handle) in the HII databases, using the new package
    list specified by PackageList. The update process has the
    following steps: Collect all the package types in the package
    list specified by PackageList. A package type consists of the
    Type field of EFI_HII_PACKAGE_HEADER and, if the Type is
    EFI_HII_PACKAGE_TYPE_GUID, the Guid field, as defined in
    EFI_HII_PACKAGE_GUID_HEADER. Iterate through the packages within
    the existing package list in the HII database specified by
    Handle. If a package's type matches one of the collected types collected
    in step 1, then perform the following steps:
    - Call any functions registered with the notification type
    REMOVE_PACK.
    - Remove the package from the package list and the HII
    database.
    Add all of the packages within the new package list specified
    by PackageList, using the following steps:
    - Add the package to the package list and the HII database.
    - Call any functions registered with the notification type
    ADD_PACK.

    @param This         A pointer to the EFI_HII_DATABASE_PROTOCOL instance.

    @param Handle       The handle that was registered to the data
                        that is requested for removal.

    @param PackageList  A pointer to an EFI_HII_PACKAGE_LIST
                        package.

    @retval EFI_SUCCESS            The HII database was successfully updated.

    @retval EFI_OUT_OF_RESOURCES   Unable to allocate enough memory
                                   for the updated database.

    @retval EFI_INVALID_PARAMETER  PackageList was NULL.
    @retval EFI_NOT_FOUND          The specified Handle is not in database.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_HANDLE, CONST, EFI_STATUS> UpdatePackageList;
  /**

    This function returns a list of the package handles of the
    specified type that are currently active in the database. The
    pseudo-type EFI_HII_PACKAGE_TYPE_ALL will cause all package
    handles to be listed.

    @param This                 A pointer to the EFI_HII_DATABASE_PROTOCOL instance.

    @param PackageType          Specifies the package type of the packages
                                to list or EFI_HII_PACKAGE_TYPE_ALL for
                                all packages to be listed.

    @param PackageGuid          If PackageType is
                                EFI_HII_PACKAGE_TYPE_GUID, then this is
                                the pointer to the GUID which must match
                                the Guid field of
                                EFI_HII_PACKAGE_GUID_HEADER. Otherwise, it
                                must be NULL.

    @param HandleBufferLength   On input, a pointer to the length
                                of the handle buffer. On output,
                                the length of the handle buffer
                                that is required for the handles found.

    @param Handle               An array of EFI_HII_HANDLE instances returned.

    @retval EFI_SUCCESS           The matching handles are outputted successfully.
                                  HandleBufferLength is updated with the actual length.
    @retval EFI_BUFFER_TOO_SMALL  The HandleBufferLength parameter
                                  indicates that Handle is too
                                  small to support the number of
                                  handles. HandleBufferLength is
                                  updated with a value that will
                                  enable the data to fit.
    @retval EFI_NOT_FOUND         No matching handle could be found in database.
    @retval EFI_INVALID_PARAMETER HandleBufferLength was NULL.
    @retval EFI_INVALID_PARAMETER The value referenced by HandleBufferLength was not
                                  zero and Handle was NULL.
    @retval EFI_INVALID_PARAMETER PackageType is not a EFI_HII_PACKAGE_TYPE_GUID but
                                  PackageGuid is not NULL, PackageType is a EFI_HII_
                                  PACKAGE_TYPE_GUID but PackageGuid is NULL.
  **/
  public readonly delegate* unmanaged<CONST, byte, CONST, ulong*, EFI_HII_HANDLE*, EFI_STATUS> ListPackageLists;
  /**

    This function will export one or all package lists in the
    database to a buffer. For each package list exported, this
    function will call functions registered with EXPORT_PACK and
    then copy the package list to the buffer. The registered
    functions may call EFI_HII_DATABASE_PROTOCOL.UpdatePackageList()
    to modify the package list before it is copied to the buffer. If
    the specified BufferSize is too small, then the status
    EFI_OUT_OF_RESOURCES will be returned and the actual package
    size will be returned in BufferSize.

    @param This         A pointer to the EFI_HII_DATABASE_PROTOCOL instance.

    @param Handle       An EFI_HII_HANDLE  that corresponds to the
                        desired package list in the HII database to
                        export or NULL to indicate all package lists
                        should be exported.

    @param BufferSize   On input, a pointer to the length of the
                        buffer. On output, the length of the
                        buffer that is required for the exported
                        data.

    @param Buffer       A pointer to a buffer that will contain the
                        results of the export function.

    @retval EFI_SUCCESS           Package exported.

    @retval EFI_OUT_OF_RESOURCES  BufferSize is too small to hold the package.

    @retval EFI_NOT_FOUND         The specified Handle could not be found in the
                                  current database.

    @retval EFI_INVALID_PARAMETER BufferSize was NULL.

    @retval EFI_INVALID_PARAMETER The value referenced by BufferSize was not zero
                                  and Buffer was NULL.
  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_HANDLE, ulong*, EFI_HII_PACKAGE_LIST_HEADER*, EFI_STATUS> ExportPackageLists;
  /**

    This function registers a function which will be called when
    specified actions related to packages of the specified type
    occur in the HII database. By registering a function, other
    HII-related drivers are notified when specific package types
    are added, removed or updated in the HII database. Each driver
    or application which registers a notification should use
    EFI_HII_DATABASE_PROTOCOL.UnregisterPackageNotify() before
    exiting.

    @param This             A pointer to the EFI_HII_DATABASE_PROTOCOL instance.

    @param PackageType      The package type. See
                            EFI_HII_PACKAGE_TYPE_x in EFI_HII_PACKAGE_HEADER.

    @param PackageGuid      If PackageType is
                            EFI_HII_PACKAGE_TYPE_GUID, then this is
                            the pointer to the GUID which must match
                            the Guid field of
                            EFI_HII_PACKAGE_GUID_HEADER. Otherwise, it
                            must be NULL.

    @param PackageNotifyFn  Points to the function to be called
                            when the event specified by
                            NotificationType occurs. See
                            EFI_HII_DATABASE_NOTIFY.

    @param NotifyType       Describes the types of notification which
                            this function will be receiving. See
                            EFI_HII_DATABASE_NOTIFY_TYPE for a
                            list of types.

    @param NotifyHandle     Points to the unique handle assigned to
                            the registered notification. Can be used
                            in EFI_HII_DATABASE_PROTOCOL.UnregisterPack
                            to stop notifications.

    @retval EFI_SUCCESS           Notification registered successfully.

    @retval EFI_OUT_OF_RESOURCES  Unable to allocate necessary
                                  data structures.

    @retval EFI_INVALID_PARAMETER PackageGuid is not NULL when
                                  PackageType is not
                                  EFI_HII_PACKAGE_TYPE_GUID.

  **/
  public readonly delegate* unmanaged<CONST, byte, CONST, EFI_HII_DATABASE_NOTIFY, EFI_HII_DATABASE_NOTIFY_TYPE, EFI_HANDLE*, EFI_STATUS> RegisterPackageNotify;
  /**

    Removes the specified HII database package-related notification.

    @param This                 A pointer to the EFI_HII_DATABASE_PROTOCOL instance.

    @param NotificationHandle   The handle of the notification
                                function being unregistered.

    @retval EFI_SUCCESS   Successsfully unregistered the notification.

    @retval EFI_NOT_FOUND The incoming notification handle does not exist
                          in the current hii database.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HANDLE, EFI_STATUS> UnregisterPackageNotify;
  /**

    This routine retrieves an array of GUID values for each keyboard
    layout that was previously registered in the system.

    @param This                 A pointer to the EFI_HII_PROTOCOL instance.

    @param KeyGuidBufferLength  On input, a pointer to the length
                                of the keyboard GUID buffer. On
                                output, the length of the handle
                                buffer that is required for the
                                handles found.

    @param KeyGuidBuffer        An array of keyboard layout GUID
                                instances returned.

    @retval EFI_SUCCESS           KeyGuidBuffer was updated successfully.

    @retval EFI_BUFFER_TOO_SMALL  The KeyGuidBufferLength
                                  parameter indicates that
                                  KeyGuidBuffer is too small to
                                  support the number of GUIDs.
                                  KeyGuidBufferLength is updated
                                  with a value that will enable
                                  the data to fit.
    @retval EFI_INVALID_PARAMETER The KeyGuidBufferLength is NULL.
    @retval EFI_INVALID_PARAMETER The value referenced by
                                  KeyGuidBufferLength is not
                                  zero and KeyGuidBuffer is NULL.
    @retval EFI_NOT_FOUND         There was no keyboard layout.

  **/
  public readonly delegate* unmanaged<CONST, ushort*, EFI_GUID*, EFI_STATUS> FindKeyboardLayouts;
  /**

    This routine retrieves the requested keyboard layout. The layout
    is a physical description of the keys on a keyboard, and the
    character(s) that are associated with a particular set of key
    strokes.

    @param This                   A pointer to the EFI_HII_PROTOCOL instance.

    @param KeyGuid                A pointer to the unique ID associated with a
                                  given keyboard layout. If KeyGuid is NULL then
                                  the current layout will be retrieved.

    @param KeyboardLayoutLength   On input, a pointer to the length of the
                                  KeyboardLayout buffer.  On output, the length of
                                  the data placed into KeyboardLayout.

    @param KeyboardLayout         A pointer to a buffer containing the
                                  retrieved keyboard layout.

    @retval EFI_SUCCESS   The keyboard layout was retrieved
                          successfully.

    @retval EFI_NOT_FOUND The requested keyboard layout was not found.

  **/
  public readonly delegate* unmanaged<CONST, CONST, ushort*, EFI_HII_KEYBOARD_LAYOUT*, EFI_STATUS> GetKeyboardLayout;
  /**

    This routine sets the default keyboard layout to the one
    referenced by KeyGuid. When this routine is called, an event
    will be signaled of the EFI_HII_SET_KEYBOARD_LAYOUT_EVENT_GUID
    group type. This is so that agents which are sensitive to the
    current keyboard layout being changed can be notified of this
    change.

    @param This      A pointer to the EFI_HII_PROTOCOL instance.

    @param KeyGuid   A pointer to the unique ID associated with a
                     given keyboard layout.

    @retval EFI_SUCCESS    The current keyboard layout was successfully set.

    @retval EFI_NOT_FOUND  The referenced keyboard layout was not
                           found, so action was taken.

  **/
  public readonly delegate* unmanaged<CONST, CONST, EFI_STATUS> SetKeyboardLayout;
  /**

    Return the EFI handle associated with a package list.

    @param This               A pointer to the EFI_HII_PROTOCOL instance.

    @param PackageListHandle  An EFI_HII_HANDLE  that corresponds
                              to the desired package list in the
                              HIIdatabase.

    @param DriverHandle       On return, contains the EFI_HANDLE which
                              was registered with the package list in
                              NewPackageList().

    @retval EFI_SUCCESS            The DriverHandle was returned successfully.

    @retval EFI_INVALID_PARAMETER  The PackageListHandle was not valid.

  **/
  public readonly delegate* unmanaged<CONST, EFI_HII_HANDLE, EFI_HANDLE*, EFI_STATUS> GetPackageListHandle;
}

// extern EFI_GUID  gEfiHiiDatabaseProtocolGuid;

// #endif
