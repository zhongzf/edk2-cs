using System.Runtime.InteropServices;

namespace Uefi;
/** @file

  The EFI HII results processing protocol invokes this type of protocol
  when it needs to forward results to a driver's configuration handler.
  This protocol is published by drivers providing and requesting
  configuration data from HII. It may only be invoked by HII.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in UEFI Specification 2.1.

**/

// #ifndef __EFI_HII_CONFIG_ACCESS_H__
// #define __EFI_HII_CONFIG_ACCESS_H__

// #include <Protocol/FormBrowser2.h>

public static EFI_GUID EFI_HII_CONFIG_ACCESS_PROTOCOL_GUID = new GUID(0x330d4706, 0xf2a0, 0x4e4f, new byte[] { 0xa3, 0x69, 0xb6, 0x6f, 0xa8, 0xd5, 0x43, 0x85 });

// typedef struct _EFI_HII_CONFIG_ACCESS_PROTOCOL EFI_HII_CONFIG_ACCESS_PROTOCOL;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BROWSER_ACTION { ulong Value; public static implicit operator EFI_BROWSER_ACTION(ulong value) => new EFI_BROWSER_ACTION() { Value = value }; public static implicit operator ulong(EFI_BROWSER_ACTION value) => value.Value; }

public const ulong EFI_BROWSER_ACTION_CHANGING = 0;
public const ulong EFI_BROWSER_ACTION_CHANGED = 1;
public const ulong EFI_BROWSER_ACTION_RETRIEVE = 2;
public const ulong EFI_BROWSER_ACTION_FORM_OPEN = 3;
public const ulong EFI_BROWSER_ACTION_FORM_CLOSE = 4;
public const ulong EFI_BROWSER_ACTION_SUBMITTED = 5;
public const ulong EFI_BROWSER_ACTION_DEFAULT_STANDARD = 0x1000;
public const ulong EFI_BROWSER_ACTION_DEFAULT_MANUFACTURING = 0x1001;
public const ulong EFI_BROWSER_ACTION_DEFAULT_SAFE = 0x1002;
public const ulong EFI_BROWSER_ACTION_DEFAULT_PLATFORM = 0x2000;
public const ulong EFI_BROWSER_ACTION_DEFAULT_HARDWARE = 0x3000;
public const ulong EFI_BROWSER_ACTION_DEFAULT_FIRMWARE = 0x4000;






























































































































/**

  This function is called to provide results data to the driver.
  This data consists of a unique key that is used to identify
  which data is either being passed back or being asked for.

  @param  This                   Points to the EFI_HII_CONFIG_ACCESS_PROTOCOL.
  @param  Action                 Specifies the type of action taken by the browser.
  @param  QuestionId             A unique value which is sent to the original
                                 exporting driver so that it can identify the type
                                 of data to expect. The format of the data tends to
                                 vary based on the opcode that generated the callback.
  @param  Type                   The type of value for the question.
  @param  Value                  A pointer to the data being sent to the original
                                 exporting driver.
  @param  ActionRequest          On return, points to the action requested by the
                                 callback function.

  @retval EFI_SUCCESS            The callback successfully handled the action.
  @retval EFI_OUT_OF_RESOURCES   Not enough storage is available to hold the
                                 variable and its data.
  @retval EFI_DEVICE_ERROR       The variable could not be saved.
  @retval EFI_UNSUPPORTED        The specified Action is not supported by the
                                 callback.
**/
typedef
EFI_STATUS
(EFIAPI* EFI_HII_ACCESS_FORM_CALLBACK)(
  IN CONST EFI_HII_CONFIG_ACCESS_PROTOCOL   * This,
  IN     EFI_BROWSER_ACTION Action,
  IN     EFI_QUESTION_ID QuestionId,
  IN     byte Type,
  IN OUT EFI_IFR_TYPE_VALUE                     * Value,
  OUT    EFI_BROWSER_ACTION_REQUEST* ActionRequest
  )
;

///
/// This protocol provides a callable interface between the HII and
/// drivers. Only drivers which provide IFR data to HII are required
/// to publish this protocol.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HII_CONFIG_ACCESS_PROTOCOL
{
  /**

    This function allows the caller to request the current
    configuration for one or more named elements. The resulting
    string is in <ConfigAltResp> format. Any and all alternative
    configuration strings shall also be appended to the end of the
    current configuration string. If they are, they must appear
    after the current configuration. They must contain the same
    routing (GUID, NAME, PATH) as the current configuration string.
    They must have an additional description indicating the type of
    alternative configuration the string represents,
    "ALTCFG=<StringToken>". That <StringToken> (when
    converted from Hex UNICODE to binary) is a reference to a
    string in the associated string pack.

    @param This       Points to the EFI_HII_CONFIG_ACCESS_PROTOCOL.

    @param Request    A null-terminated Unicode string in
                      <ConfigRequest> format. Note that this
                      includes the routing information as well as
                      the configurable name / value pairs. It is
                      invalid for this string to be in
                      <MultiConfigRequest> format.
                      If a NULL is passed in for the Request field,
                      all of the settings being abstracted by this function
                      will be returned in the Results field.  In addition,
                      if a ConfigHdr is passed in with no request elements,
                      all of the settings being abstracted for that particular
                      ConfigHdr reference will be returned in the Results Field.

    @param Progress   On return, points to a character in the
                      Request string. Points to the string's null
                      terminator if request was successful. Points
                      to the most recent "&" before the first
                      failing name / value pair (or the beginning
                      of the string if the failure is in the first
                      name / value pair) if the request was not
                      successful.

    @param Results    A null-terminated Unicode string in
                      <MultiConfigAltResp> format which has all values
                      filled in for the names in the Request string.
                      String to be allocated by the called function.

    @retval EFI_SUCCESS             The Results string is filled with the
                                    values corresponding to all requested
                                    names.

    @retval EFI_OUT_OF_RESOURCES    Not enough memory to store the
                                    parts of the results that must be
                                    stored awaiting possible future
                                    protocols.

    @retval EFI_NOT_FOUND           A configuration element matching
                                    the routing data is not found.
                                    Progress set to the first character
                                    in the routing header.

    @retval EFI_INVALID_PARAMETER   Illegal syntax. Progress set
                                    to most recent "&" before the
                                    error or the beginning of the
                                    string.

    @retval EFI_INVALID_PARAMETER   Unknown name. Progress points
                                    to the & before the name in
                                    question.

  **/
  public readonly delegate* unmanaged<CONST, CONST, EFI_STRING*, EFI_STRING*, EFI_STATUS> ExtractConfig;
  /**

    This function applies changes in a driver's configuration.
    Input is a Configuration, which has the routing data for this
    driver followed by name / value configuration pairs. The driver
    must apply those pairs to its configurable storage. If the
    driver's configuration is stored in a linear block of data
    and the driver's name / value pairs are in <BlockConfig>
    format, it may use the ConfigToBlock helper function (above) to
    simplify the job.

    @param This           Points to the EFI_HII_CONFIG_ACCESS_PROTOCOL.

    @param Configuration  A null-terminated Unicode string in
                          <ConfigString> format.

    @param Progress       A pointer to a string filled in with the
                          offset of the most recent '&' before the
                          first failing name / value pair (or the
                          beginn ing of the string if the failure
                          is in the first name / value pair) or
                          the terminating NULL if all was
                          successful.

    @retval EFI_SUCCESS             The results have been distributed or are
                                    awaiting distribution.

    @retval EFI_OUT_OF_RESOURCES    Not enough memory to store the
                                    parts of the results that must be
                                    stored awaiting possible future
                                    protocols.

    @retval EFI_INVALID_PARAMETERS  Passing in a NULL for the
                                    Results parameter would result
                                    in this type of error.

    @retval EFI_NOT_FOUND           Target for the specified routing data
                                    was not found

  **/
  public readonly delegate* unmanaged<CONST, CONST, EFI_STRING*, EFI_STATUS> RouteConfig;
  public EFI_HII_ACCESS_FORM_CALLBACK Callback;
}

// extern EFI_GUID  gEfiHiiConfigAccessProtocolGuid;

// #endif
