using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Platform Configuration Database (PCD) Protocol defined in PI 1.2 Vol3

  A platform database that contains a variety of current platform settings or
  directives that can be accessed by a driver or application.
  PI PCD protocol only provide the accessing interfaces for Dynamic-Ex type PCD.

  Callers to this protocol must be at a TPL_APPLICATION task priority level.
  This is the base PCD service API that provides an abstraction for accessing configuration content in
  the platform. It a seamless mechanism for extracting information regardless of where the
  information is stored (such as in Read-only data, or an EFI Variable).
  This protocol allows access to data through size-granular APIs and provides a mechanism for a
  firmware component to monitor specific settings and be alerted when a setting is changed.

  Copyright (c) 2009 - 2010, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  PI Version 1.2 Vol 3.
**/

// #ifndef __PI_PCD_H__
// #define __PI_PCD_H__

// extern EFI_GUID  gEfiPcdProtocolGuid;

public unsafe partial class EFI
{
  public static EFI_GUID EFI_PCD_PROTOCOL_GUID = new GUID(0x13a3f0f6, 0x264a, 0x3ef0, new byte[] { 0xf2, 0xe0, 0xde, 0xc5, 0x12, 0x34, 0x2f, 0x34 });

  public const ulong EFI_PCD_INVALID_TOKEN_NUMBER = ((ulong)0);

  typedef
  VOID
  (EFIAPI* EFI_PCD_PROTOCOL_CALLBACK)(
    IN EFI_GUID * Guid           OPTIONAL,
  IN ulong CallBackToken,
  IN OUT void* TokenData,
  IN     ulong TokenDataSize
  );

}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PCD_PROTOCOL
{
  /**
    SetSku() sets the SKU Id to be used for subsequent calls to set or get PCD values. SetSku() is
    normally called only once by the system.
    For each item (token), the database can hold a single value that applies to all SKUs, or multiple
    values, where each value is associated with a specific SKU Id. Items with multiple, SKU-specific
    values are called SKU enabled.
    The SKU Id of zero is reserved as a default. The valid SkuId range is 1 to 255. For tokens that are
    not SKU enabled, the system ignores any set SKU Id and works with the single value for that token.
    For SKU-enabled tokens, the system will use the SKU Id set by the last call to SetSku(). If no SKU
    Id is set or the currently set SKU Id isn't valid for the specified token, the system uses the default
    SKU Id. If the system attempts to use the default SKU Id and no value has been set for that Id, the
    results are unpredictable.

    @param[in]  SkuId   The SKU value to set.
  **/
  public readonly delegate* unmanaged<ulong, EFI_STATUS> SetSku;
  /**
    Retrieves an 8-bit value for a given PCD token.
    If the TokenNumber is invalid, the results are unpredictable.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.

    @return 8-bit value for a given PCD token.
  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> Get8;
  /**
    Retrieves the current word-sized value for a PCD token number.
    If the TokenNumber is invalid, the results are unpredictable.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.

    @return word-sized value for a given PCD token.
  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> Get16;
  /**
    Retrieves the current 32-bit sized value for a PCD token number.
    If the TokenNumber is invalid, the results are unpredictable.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.

    @return 32-bit value for a given PCD token.
  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> Get32;
  /**
    Retrieves the 64-bit sized value for a PCD token number.
    If the TokenNumber is invalid, the results are unpredictable.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.

    @return 64-bit value for a given PCD token.

  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> Get64;
  /**
    Retrieves the current pointer to the value for a PCD token number. Do not make any assumptions
    about the alignment of the pointer that is returned by this function call. If the TokenNumber is
    invalid, the results are unpredictable.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.

    @return pointer to a value for a given PCD token.
  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> GetPtr;
  /**
    Retrieves the current BOOLEAN-sized value for a PCD token number. If the TokenNumber is
    invalid, the results are unpredictable.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.

    @return Boolean value for a given PCD token.
  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> GetBool;
  /**
    Retrieves the current size of a particular PCD token. If the TokenNumber is invalid, the results are
    unpredictable.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.

    @return the size of the value for a given PCD token.
  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> GetSize;
  /**
    Sets an 8-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the size of the value being set is
    compatible with the Token's existing definition. If it is not, an error will be returned.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.
    @param[in]    Value       The value to set for the PCD token.

    @retval   EFI_SUCCESS             The PCD service has set the value requested
    @retval   EFI_INVALID_PARAMETER   The PCD service determined that the size of the data being set was
                                      incompatible with a call to this function. Use GetSizeEx() to
                                      retrieve the size of the target data.
    @retval   EFI_NOT_FOUND           The PCD service could not find the requested token number.
  **/
  public readonly delegate* unmanaged<CONST, ulong, byte, EFI_STATUS> Set8;
  /**
    Sets an 16-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the size of the value being set is
    compatible with the Token's existing definition. If it is not, an error will be returned.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.
    @param[in]    Value       The value to set for the PCD token.

    @retval   EFI_SUCCESS             The PCD service has set the value requested
    @retval   EFI_INVALID_PARAMETER   The PCD service determined that the size of the data being set was
                                      incompatible with a call to this function. Use GetSizeEx() to
                                      retrieve the size of the target data.
    @retval   EFI_NOT_FOUND           The PCD service could not find the requested token number.
  **/
  public readonly delegate* unmanaged<CONST, ulong, ushort, EFI_STATUS> Set16;
  /**
    Sets an 32-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the size of the value being set is
    compatible with the Token's existing definition. If it is not, an error will be returned.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.
    @param[in]    Value       The value to set for the PCD token.

    @retval   EFI_SUCCESS             The PCD service has set the value requested
    @retval   EFI_INVALID_PARAMETER   The PCD service determined that the size of the data being set was
                                      incompatible with a call to this function. Use GetSizeEx() to
                                      retrieve the size of the target data.
    @retval   EFI_NOT_FOUND           The PCD service could not find the requested token number.
  **/
  public readonly delegate* unmanaged<CONST, ulong, uint, EFI_STATUS> Set32;
  /**
    Sets an 64-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the size of the value being set is
    compatible with the Token's existing definition. If it is not, an error will be returned.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.
    @param[in]    Value       The value to set for the PCD token.

    @retval   EFI_SUCCESS             The PCD service has set the value requested
    @retval   EFI_INVALID_PARAMETER   The PCD service determined that the size of the data being set was
                                      incompatible with a call to this function. Use GetSizeEx() to
                                      retrieve the size of the target data.
    @retval   EFI_NOT_FOUND           The PCD service could not find the requested token number.
  **/
  public readonly delegate* unmanaged<CONST, ulong, ulong, EFI_STATUS> Set64;
  /**
    Sets a value of a specified size for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the size of the value being set is
    compatible with the Token's existing definition. If it is not, an error will be returned.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.
    @param[in]    SizeOfValue The length of the value being set for the PCD token. If too large of a length is
                              specified, upon return from this function the value of SizeOfValue will
                              reflect the maximum size for the PCD token.
    @param[in]    Buffer      A pointer to the buffer containing the value to set for the PCD token.

    @retval   EFI_SUCCESS             The PCD service has set the value requested
    @retval   EFI_INVALID_PARAMETER   The PCD service determined that the size of the data being set was
                                      incompatible with a call to this function. Use GetSizeEx() to
                                      retrieve the size of the target data.
    @retval   EFI_NOT_FOUND           The PCD service could not find the requested token number.
  **/
  public readonly delegate* unmanaged<CONST, ulong, ulong*, void*, EFI_STATUS> SetPtr;
  /**
    Sets a Boolean value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the size of the value being set is
    compatible with the Token's existing definition. If it is not, an error will be returned.

    @param[in]    Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    TokenNumber The PCD token number.
    @param[in]    Value       The value to set for the PCD token.

    @retval   EFI_SUCCESS             The PCD service has set the value requested
    @retval   EFI_INVALID_PARAMETER   The PCD service determined that the size of the data being set was
                                      incompatible with a call to this function. Use GetSizeEx() to
                                      retrieve the size of the target data.
    @retval   EFI_NOT_FOUND           The PCD service could not find the requested token number.
  **/
  public readonly delegate* unmanaged<CONST, ulong, bool, EFI_STATUS> SetBool;
  /**
    Specifies a function to be called anytime the value of a designated token is changed.

    @param[in]    Guid              The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    CallBackToken     The PCD token number to monitor.
    @param[in]    CallBackFunction  The function prototype called when the value associated with the CallBackToken is set.

    @retval EFI_SUCCESS     The PCD service has successfully established a call event for the CallBackToken requested.
    @retval EFI_NOT_FOUND   The PCD service could not find the referenced token number.
  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_PCD_PROTOCOL_CALLBACK, EFI_STATUS> CallbackOnSet;
  /**
    Cancels a callback function that was set through a previous call to the CallBackOnSet function.

    @param[in]    Guid              The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]    CallBackToken     The PCD token number to monitor.
    @param[in]    CallBackFunction  The function prototype called when the value associated with the CallBackToken is set.

    @retval EFI_SUCCESS     The PCD service has successfully established a call event for the CallBackToken requested.
    @retval EFI_NOT_FOUND   The PCD service could not find the referenced token number.
  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_PCD_PROTOCOL_CALLBACK, EFI_STATUS> CancelCallback;
  /**
    Gets the next valid token number in a given namespace. This is useful since the PCD infrastructure
    contains a sparse list of token numbers, and one cannot a priori know what token numbers are valid
    in the database.

    @param[in]    Guid              The 128-bit unique value that designates the namespace from which to retrieve the next token.
    @param[in]    TokenNumber       A pointer to the PCD token number to use to find the subsequent token number. To
                                    retrieve the "first" token, have the pointer reference a TokenNumber value of 0.
    @retval EFI_SUCCESS           The PCD service has retrieved the value requested
    @retval EFI_NOT_FOUND         The PCD service could not find data from the requested token number.
  **/
  public readonly delegate* unmanaged<CONST, ulong*, EFI_STATUS> GetNextToken;
  /**
    Gets the next valid token namespace for a given namespace. This is useful to traverse the valid
    token namespaces on a platform.

    @param[in, out]   Guid    An indirect pointer to EFI_GUID. On input it designates a known token namespace
                              from which the search will start. On output, it designates the next valid token
                              namespace on the platform. If *Guid is NULL, then the GUID of the first token
                              space of the current platform is returned. If the search cannot locate the next valid
                              token namespace, an error is returned and the value of *Guid is undefined.

    @retval   EFI_SUCCESS   The PCD service retrieved the value requested.
    @retval   EFI_NOT_FOUND The PCD service could not find the next valid token namespace.
  **/
  public readonly delegate* unmanaged<CONST, EFI_STATUS> GetNextTokenSpace;
}

// #endif
