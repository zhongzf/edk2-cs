namespace Uefi;
/** @file
  Native Platform Configuration Database (PCD) Protocol

  Different with the EFI_PCD_PROTOCOL defined in PI 1.2 specification, the native
  PCD protocol provide interfaces for dynamic and dynamic-ex type PCD.
  The interfaces in dynamic type PCD do not require the token space guid as parameter,
  but interfaces in dynamic-ex type PCD require token space guid as parameter.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol was introduced in PI Specification 1.2.

**/

// #ifndef __PCD_H__
// #define __PCD_H__

// extern EFI_GUID  gPcdProtocolGuid;

public static EFI_GUID PCD_PROTOCOL_GUID = new GUID(0x11b34006, 0xd85b, 0x4d0a, new byte[] { 0xa2, 0x90, 0xd5, 0xa5, 0x71, 0x31, 0xe, 0xf7 });

public const ulong PCD_INVALID_TOKEN_NUMBER = ((ulong)0);


























































































































































































































































































































































































































































































































































































































































































































































///
/// This service abstracts the ability to set/get Platform Configuration Database (PCD).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCD_PROTOCOL
{
  /**
    Sets the SKU value for subsequent calls to set or get PCD token values.

    SetSku() sets the SKU Id to be used for subsequent calls to set or get PCD values.
    SetSku() is normally called only once by the system.

    For each item (token), the database can hold a single value that applies to all SKUs,
    or multiple values, where each value is associated with a specific SKU Id. Items with multiple,
    SKU-specific values are called SKU enabled.

    The SKU Id of zero is reserved as a default. The valid SkuId range is 1 to 255.
    For tokens that are not SKU enabled, the system ignores any set SKU Id and works with the
    single value for that token. For SKU-enabled tokens, the system will use the SKU Id set by the
    last call to SetSku(). If no SKU Id is set or the currently set SKU Id isn't valid for the specified token,
    the system uses the default SKU Id. If the system attempts to use the default SKU Id and no value has been
    set for that Id, the results are unpredictable.

    @param[in]  SkuId The SKU value that will be used when the PCD service will retrieve and
                      set values associated with a PCD token.


  **/
  public readonly delegate* unmanaged<ulong, EFI_STATUS> SetSku;

  /**
    Retrieves an 8-bit value for a given PCD token.

    Retrieves the current byte-sized value for a PCD token number.
    If the TokenNumber is invalid, the results are unpredictable.

    @param[in]  TokenNumber The PCD token number.

    @return The byte value.

  **/
  public readonly delegate* unmanaged<ulong, EFI_STATUS> Get8;
  /**
    Retrieves a 16-bit value for a given PCD token.

    Retrieves the current 16-bit value for a PCD token number.
    If the TokenNumber is invalid, the results are unpredictable.

    @param[in]  TokenNumber The PCD token number.

    @return The ushort value.

  **/
  public readonly delegate* unmanaged<ulong, EFI_STATUS> Get16;
  /**
    Retrieves a 32-bit value for a given PCD token.

    Retrieves the current 32-bit value for a PCD token number.
    If the TokenNumber is invalid, the results are unpredictable.

    @param[in]  TokenNumber The PCD token number.

    @return The uint value.

  **/
  public readonly delegate* unmanaged<ulong, EFI_STATUS> Get32;
  /**
    Retrieves a 64-bit value for a given PCD token.

    Retrieves the current 64-bit value for a PCD token number.
    If the TokenNumber is invalid, the results are unpredictable.

    @param[in]  TokenNumber The PCD token number.

    @return The ulong value.

  **/
  public readonly delegate* unmanaged<ulong, EFI_STATUS> Get64;
  /**
    Retrieves a pointer to a value for a given PCD token.

    Retrieves the current pointer to the buffer for a PCD token number.
    Do not make any assumptions about the alignment of the pointer that
    is returned by this function call.  If the TokenNumber is invalid,
    the results are unpredictable.

    @param[in]  TokenNumber The PCD token number.

    @return The pointer to the buffer to be retrived.

  **/
  public readonly delegate* unmanaged<ulong, EFI_STATUS> GetPtr;
  /**
    Retrieves a Boolean value for a given PCD token.

    Retrieves the current boolean value for a PCD token number.
    Do not make any assumptions about the alignment of the pointer that
    is returned by this function call.  If the TokenNumber is invalid,
    the results are unpredictable.

    @param[in]  TokenNumber The PCD token number.

    @return The Boolean value.

  **/
  public readonly delegate* unmanaged<ulong, EFI_STATUS> GetBool;
  /**
    Retrieves the size of the value for a given PCD token.

    Retrieves the current size of a particular PCD token.
    If the TokenNumber is invalid, the results are unpredictable.

    @param[in]  TokenNumber The PCD token number.

    @return The size of the value for the PCD token.

  **/
  public readonly delegate* unmanaged<ulong, EFI_STATUS> GetSize;

  /**
    Retrieves an 8-bit value for a given PCD token.

    Retrieves the 8-bit value of a particular PCD token.
    If the TokenNumber is invalid or the token space
    specified by Guid does not exist, the results are
    unpredictable.

    @param[in]  Guid        The token space for the token number.
    @param[in]  TokenNumber The PCD token number.

    @return The size 8-bit value for the PCD token.

  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> Get8Ex;
  /**
    Retrieves a 16-bit value for a given PCD token.

    Retrieves the 16-bit value of a particular PCD token.
    If the TokenNumber is invalid or the token space
    specified by Guid does not exist, the results are
    unpredictable.

    @param[in]  Guid        The token space for the token number.
    @param[in]  TokenNumber The PCD token number.

    @return The size 16-bit value for the PCD token.

  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> Get16Ex;
  /**
    Retrieves a 32-bit value for a given PCD token.

    Retrieves the 32-bit value of a particular PCD token.
    If the TokenNumber is invalid or the token space
    specified by Guid does not exist, the results are
    unpredictable.

    @param[in]  Guid        The token space for the token number.
    @param[in]  TokenNumber The PCD token number.

    @return The size 32-bit value for the PCD token.

  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> Get32Ex;
  /**
    Retrieves an 64-bit value for a given PCD token.

    Retrieves the 64-bit value of a particular PCD token.
    If the TokenNumber is invalid or the token space
    specified by Guid does not exist, the results are
    unpredictable.

    @param[in]  Guid        The token space for the token number.
    @param[in]  TokenNumber The PCD token number.

    @return The size 64-bit value for the PCD token.

  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> Get64Ex;
  /**
    Retrieves a pointer to a value for a given PCD token.

    Retrieves the current pointer to the buffer for a PCD token number.
    Do not make any assumptions about the alignment of the pointer that
    is returned by this function call.  If the TokenNumber is invalid,
    the results are unpredictable.

    @param[in]  Guid        The token space for the token number.
    @param[in]  TokenNumber The PCD token number.

    @return The pointer to the buffer to be retrieved.

  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> GetPtrEx;
  /**
    Retrieves a Boolean value for a given PCD token.

    Retrieves the Boolean value of a particular PCD token.
    If the TokenNumber is invalid or the token space
    specified by Guid does not exist, the results are
    unpredictable.

    @param[in]  Guid        The token space for the token number.
    @param[in]  TokenNumber The PCD token number.

    @return The size Boolean value for the PCD token.

  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> GetBoolEx;
  /**
    Retrieves the size of the value for a given PCD token.

    Retrieves the current size of a particular PCD token.
    If the TokenNumber is invalid, the results are unpredictable.

    @param[in]  Guid        The token space for the token number.
    @param[in]  TokenNumber The PCD token number.

    @return The size of the value for the PCD token.

  **/
  public readonly delegate* unmanaged<CONST, ulong, EFI_STATUS> GetSizeEx;

  /**
    Sets an 8-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  TokenNumber The PCD token number.
    @param[in]  Value       The value to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<ulong, byte, EFI_STATUS> Set8;
  /**
    Sets a 16-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  TokenNumber The PCD token number.
    @param[in]  Value       The value to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<ulong, ushort, EFI_STATUS> Set16;
  /**
    Sets a 32-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  TokenNumber The PCD token number.
    @param[in]  Value       The value to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<ulong, uint, EFI_STATUS> Set32;
  /**
    Sets a 64-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  TokenNumber The PCD token number.
    @param[in]  Value       The value to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<ulong, ulong, EFI_STATUS> Set64;
  /**
    Sets a value of a specified size for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]      TokenNumber  The PCD token number.
    @param[in, out] SizeOfBuffer A pointer to the length of the value being set for the PCD token.
                                 On input, if the SizeOfValue is greater than the maximum size supported
                                 for this TokenNumber then the output value of SizeOfValue will reflect
                                 the maximum size supported for this TokenNumber.
    @param[in]      Buffer       The buffer to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<ulong, ulong*, void*, EFI_STATUS> SetPtr;
  /**
    Sets a Boolean value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  TokenNumber The PCD token number.
    @param[in]  Value       The value to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<ulong, bool, EFI_STATUS> SetBool;

  /**
    Sets an 8-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]  TokenNumber The PCD token number.
    @param[in]  Value       The value to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<CONST, ulong, byte, EFI_STATUS> Set8Ex;
  /**
    Sets an 16-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]  TokenNumber The PCD token number.
    @param[in]  Value       The value to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<CONST, ulong, ushort, EFI_STATUS> Set16Ex;
  /**
    Sets a 32-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]  TokenNumber The PCD token number.
    @param[in]  Value       The value to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<CONST, ulong, uint, EFI_STATUS> Set32Ex;
  /**
    Sets a 64-bit value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]  TokenNumber The PCD token number.
    @param[in]  Value       The value to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<CONST, ulong, ulong, EFI_STATUS> Set64Ex;
  /**
    Sets a value of a specified size for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  Guid            The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]  TokenNumber     The PCD token number.
    @param[in, out] SizeOfBuffer A pointer to the length of the value being set for the PCD token.
                                On input, if the SizeOfValue is greater than the maximum size supported
                                for this TokenNumber then the output value of SizeOfValue will reflect
                                the maximum size supported for this TokenNumber.
    @param[in]  Buffer          The buffer to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<CONST, ulong, ulong*, void*, EFI_STATUS> SetPtrEx;
  /**
    Sets a Boolean value for a given PCD token.

    When the PCD service sets a value, it will check to ensure that the
    size of the value being set is compatible with the Token's existing definition.
    If it is not, an error will be returned.

    @param[in]  Guid        The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]  TokenNumber The PCD token number.
    @param[in]  Value       The value to set for the PCD token.

    @retval EFI_SUCCESS  The procedure returned successfully.
    @retval EFI_INVALID_PARAMETER The PCD service determined that the size of the data
                                    being set was incompatible with a call to this function.
                                    Use GetSize() to retrieve the size of the target data.
    @retval EFI_NOT_FOUND The PCD service could not find the requested token number.

  **/
  public readonly delegate* unmanaged<CONST, ulong, bool, EFI_STATUS> SetBoolEx;

  /**
    Specifies a function to be called anytime the value of a designated token is changed.

    @param[in]  TokenNumber       The PCD token number.
    @param[in]  Guid              The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]  CallBackFunction  The function prototype called when the value associated with the CallBackToken is set.

    @retval EFI_SUCCESS   The PCD service has successfully established a call event
                          for the CallBackToken requested.
    @retval EFI_NOT_FOUND The PCD service could not find the referenced token number.

  **/
  public readonly delegate* unmanaged<CONST, ulong, PCD_PROTOCOL_CALLBACK, EFI_STATUS> CallbackOnSet;
  /**
    Cancels a previously set callback function for a particular PCD token number.

    @param[in]  TokenNumber      The PCD token number.
    @param[in]  Guid             The 128-bit unique value that designates the namespace from which to extract the value.
    @param[in]  CallBackFunction The function prototype called when the value associated with the CallBackToken is set.

    @retval EFI_SUCCESS   The PCD service has successfully established a call event
                          for the CallBackToken requested.
    @retval EFI_NOT_FOUND The PCD service could not find the referenced token number.

  **/
  public readonly delegate* unmanaged<CONST, ulong, PCD_PROTOCOL_CALLBACK, EFI_STATUS> CancelCallback;
  /**
    Retrieves the next valid token number in a given namespace.

    This is useful since the PCD infrastructure contains a sparse list of token numbers,
    and one cannot a priori know what token numbers are valid in the database.

    If TokenNumber is 0 and Guid is not NULL, then the first token from the token space specified by Guid is returned.
    If TokenNumber is not 0 and Guid is not NULL, then the next token in the token space specified by Guid is returned.
    If TokenNumber is 0 and Guid is NULL, then the first token in the default token space is returned.
    If TokenNumber is not 0 and Guid is NULL, then the next token in the default token space is returned.
    The token numbers in the default token space may not be related to token numbers in token spaces that are named by Guid.
    If the next token number can be retrieved, then it is returned in TokenNumber, and EFI_SUCCESS is returned.
    If TokenNumber represents the last token number in the token space specified by Guid, then EFI_NOT_FOUND is returned.
    If TokenNumber is not present in the token space specified by Guid, then EFI_NOT_FOUND is returned.


    @param[in]      Guid    The 128-bit unique value that designates the namespace from which to retrieve the next token.
                            This is an optional parameter that may be NULL. If this parameter is NULL, then a request is
                            being made to retrieve tokens from the default token space.
    @param[in,out]  TokenNumber
                            A pointer to the PCD token number to use to find the subsequent token number.

    @retval EFI_SUCCESS   The PCD service has retrieved the next valid token number.
    @retval EFI_NOT_FOUND The PCD service could not find data from the requested token number.

  **/
  public readonly delegate* unmanaged<CONST, ulong*, EFI_STATUS> GetNextToken;
  /**
    Retrieves the next valid PCD token namespace for a given namespace.

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
  public readonly delegate* unmanaged<OUT, EFI_STATUS> GetNextTokenSpace;
}

// #endif
