namespace Uefi;
/** @file
  This protocol provides services to display a popup window.
  The protocol is typically produced by the forms browser and consumed by a driver callback handler.

  Copyright (c) 2017-2021, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in UEFI Specification 2.7.

**/

// #ifndef __HII_POPUP_H__
// #define __HII_POPUP_H__

public static EFI_GUID EFI_HII_POPUP_PROTOCOL_GUID = new GUID(0x4311edc0, 0x6054, 0x46d4, new byte[] {0x9e, 0x40, 0x89, 0x3e, 0xa9, 0x52, 0xfc, 0xcc});

public static ulong EFI_HII_POPUP_PROTOCOL_REVISION = 1;

// typedef struct _EFI_HII_POPUP_PROTOCOL EFI_HII_POPUP_PROTOCOL;

public enum EFI_HII_POPUP_STYLE {
  EfiHiiPopupStyleInfo,
  EfiHiiPopupStyleWarning,
  EfiHiiPopupStyleError
}

public enum EFI_HII_POPUP_TYPE {
  EfiHiiPopupTypeOk,
  EfiHiiPopupTypeOkCancel,
  EfiHiiPopupTypeYesNo,
  EfiHiiPopupTypeYesNoCancel
}

public enum EFI_HII_POPUP_SELECTION {
  EfiHiiPopupSelectionOk,
  EfiHiiPopupSelectionCancel,
  EfiHiiPopupSelectionYes,
  EfiHiiPopupSelectionNo
}




























[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_POPUP_PROTOCOL {
 public ulong                  Revision;
/**
  Displays a popup window.

  @param  This           A pointer to the EFI_HII_POPUP_PROTOCOL instance.
  @param  PopupStyle     Popup style to use.
  @param  PopupType      Type of the popup to display.
  @param  HiiHandle      HII handle of the string pack containing Message
  @param  Message        A message to display in the popup box.
  @param  UserSelection  User selection.

  @retval EFI_SUCCESS            The popup box was successfully displayed.
  @retval EFI_INVALID_PARAMETER  HiiHandle and Message do not define a valid HII string.
  @retval EFI_INVALID_PARAMETER  PopupType is not one of the values defined by this specification.
  @retval EFI_OUT_OF_RESOURCES   There are not enough resources available to display the popup box.

**/
public readonly delegate* unmanaged<EFI_HII_POPUP_PROTOCOL*,EFI_HII_POPUP_STYLE,EFI_HII_POPUP_TYPE,EFI_HII_HANDLE,EFI_STRING_ID,EFI_HII_POPUP_SELECTION*, EFI_STATUS> CreatePopup;
}

// extern EFI_GUID  gEfiHiiPopupProtocolGuid;

// #endif
