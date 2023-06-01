namespace Uefi;
/** @file
  EFI_HASH2_SERVICE_BINDING_PROTOCOL as defined in UEFI 2.5.
  EFI_HASH2_PROTOCOL as defined in UEFI 2.5.
  The EFI Hash2 Service Binding Protocol is used to locate hashing services support
  provided by a driver and to create and destroy instances of the EFI Hash2 Protocol
  so that a multiple drivers can use the underlying hashing services.
  EFI_HASH2_PROTOCOL describes hashing functions for which the algorithm-required
  message padding and finalization are performed by the supporting driver.

Copyright (c) 2015, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __EFI_HASH2_PROTOCOL_H__
// #define __EFI_HASH2_PROTOCOL_H__

public static EFI_GUID EFI_HASH2_SERVICE_BINDING_PROTOCOL_GUID = new GUID( 
    0xda836f8d, 0x217f, 0x4ca0, new byte[] { 0x99, 0xc2, 0x1c, 0xa4, 0xe1, 0x60, 0x77, 0xea });

public static EFI_GUID EFI_HASH2_PROTOCOL_GUID = new GUID( 
    0x55b1d734, 0xc5e1, 0x49db, new byte[] { 0x96, 0x47, 0xb1, 0x6a, 0xfb, 0xe, 0x30, 0x5b });

// #include <Protocol/Hash.h>

//
// NOTE:
// Algorithms EFI_HASH_ALGORITHM_SHA1_NOPAD and
// EFI_HASH_ALGORITHM_SHA256_NOPAD_GUID are not compatible with
// EFI_HASH2_PROTOCOL and will return EFI_UNSUPPORTED if used with any
// EFI_HASH2_PROTOCOL function.
//

//
// Note: SHA-1 and MD5 are included for backwards compatibility.
// New driver implementations are encouraged to consider stronger algorithms.
//

// typedef struct _EFI_HASH2_PROTOCOL EFI_HASH2_PROTOCOL;

typedef byte EFI_MD5_HASH2[16];
typedef byte EFI_SHA1_HASH2[20];
typedef byte EFI_SHA224_HASH2[28];
typedef byte EFI_SHA256_HASH2[32];
typedef byte EFI_SHA384_HASH2[48];
typedef byte EFI_SHA512_HASH2[64];

[StructLayout(LayoutKind.Explicit)] public unsafe struct EFI_HASH2_OUTPUT {
 [FieldOffset(0)] public EFI_MD5_HASH2       Md5Hash;
 [FieldOffset(0)] public EFI_SHA1_HASH2      Sha1Hash;
 [FieldOffset(0)] public EFI_SHA224_HASH2    Sha224Hash;
 [FieldOffset(0)] public EFI_SHA256_HASH2    Sha256Hash;
 [FieldOffset(0)] public EFI_SHA384_HASH2    Sha384Hash;
 [FieldOffset(0)] public EFI_SHA512_HASH2    Sha512Hash;
}

























































































































///
/// This protocol describes hashing functions for which the algorithm-required message padding and
/// finalization are performed by the supporting driver.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_HASH2_PROTOCOL {
/**
  Returns the size of the hash which results from a specific algorithm.

  @param[in]  This                  Points to this instance of EFI_HASH2_PROTOCOL.
  @param[in]  HashAlgorithm         Points to the EFI_GUID which identifies the algorithm to use.
  @param[out] HashSize              Holds the returned size of the algorithm's hash.

  @retval EFI_SUCCESS           Hash size returned successfully.
  @retval EFI_INVALID_PARAMETER This or HashSize is NULL.
  @retval EFI_UNSUPPORTED       The algorithm specified by HashAlgorithm is not supported by this driver
                                or HashAlgorithm is null.

**/
public readonly delegate* unmanaged<CONST,CONST,ulong*, EFI_STATUS> GetHashSize;
/**
  Creates a hash for the specified message text. The hash is not extendable.
  The output is final with any algorithm-required padding added by the function.

  @param[in]  This          Points to this instance of EFI_HASH2_PROTOCOL.
  @param[in]  HashAlgorithm Points to the EFI_GUID which identifies the algorithm to use.
  @param[in]  Message       Points to the start of the message.
  @param[in]  MessageSize   The size of Message, in bytes.
  @param[in,out]  Hash      On input, points to a caller-allocated buffer of the size
                              returned by GetHashSize() for the specified HashAlgorithm.
                            On output, the buffer holds the resulting hash computed from the message.

  @retval EFI_SUCCESS           Hash returned successfully.
  @retval EFI_INVALID_PARAMETER This or Hash is NULL.
  @retval EFI_UNSUPPORTED       The algorithm specified by HashAlgorithm is not supported by this driver
                                or HashAlgorithm is Null.
  @retval EFI_OUT_OF_RESOURCES  Some resource required by the function is not available
                                or MessageSize is greater than platform maximum.

**/
public readonly delegate* unmanaged<CONST,CONST,CONST,ulong,EFI_HASH2_OUTPUT*, EFI_STATUS> Hash;
/**
  This function must be called to initialize a digest calculation to be subsequently performed using the
  EFI_HASH2_PROTOCOL functions HashUpdate() and HashFinal().

  @param[in]  This          Points to this instance of EFI_HASH2_PROTOCOL.
  @param[in]  HashAlgorithm Points to the EFI_GUID which identifies the algorithm to use.

  @retval EFI_SUCCESS           Initialized successfully.
  @retval EFI_INVALID_PARAMETER This is NULL.
  @retval EFI_UNSUPPORTED       The algorithm specified by HashAlgorithm is not supported by this driver
                                or HashAlgorithm is Null.
  @retval EFI_OUT_OF_RESOURCES  Process failed due to lack of required resource.
  @retval EFI_ALREADY_STARTED   This function is called when the operation in progress is still in processing Hash(),
                                or HashInit() is already called before and not terminated by HashFinal() yet on the same instance.

**/
public readonly delegate* unmanaged<CONST,CONST, EFI_STATUS> HashInit;
/**
  Updates the hash of a computation in progress by adding a message text.

  @param[in]  This          Points to this instance of EFI_HASH2_PROTOCOL.
  @param[in]  Message       Points to the start of the message.
  @param[in]  MessageSize   The size of Message, in bytes.

  @retval EFI_SUCCESS           Digest in progress updated successfully.
  @retval EFI_INVALID_PARAMETER This or Hash is NULL.
  @retval EFI_OUT_OF_RESOURCES  Some resource required by the function is not available
                                or MessageSize is greater than platform maximum.
  @retval EFI_NOT_READY         This call was not preceded by a valid call to HashInit(),
                                or the operation in progress was terminated by a call to Hash() or HashFinal() on the same instance.

**/
public readonly delegate* unmanaged<CONST,CONST,ulong, EFI_STATUS> HashUpdate;
/**
  Finalizes a hash operation in progress and returns calculation result.
  The output is final with any necessary padding added by the function.
  The hash may not be further updated or extended after HashFinal().

  @param[in]  This          Points to this instance of EFI_HASH2_PROTOCOL.
  @param[in,out]  Hash      On input, points to a caller-allocated buffer of the size
                              returned by GetHashSize() for the specified HashAlgorithm specified in preceding HashInit().
                            On output, the buffer holds the resulting hash computed from the message.

  @retval EFI_SUCCESS           Hash returned successfully.
  @retval EFI_INVALID_PARAMETER This or Hash is NULL.
  @retval EFI_NOT_READY         This call was not preceded by a valid call to HashInit() and at least one call to HashUpdate(),
                                or the operation in progress was canceled by a call to Hash() on the same instance.

**/
public readonly delegate* unmanaged<CONST,EFI_HASH2_OUTPUT*, EFI_STATUS> HashFinal;
}

// extern EFI_GUID  gEfiHash2ServiceBindingProtocolGuid;
// extern EFI_GUID  gEfiHash2ProtocolGuid;

// #endif
