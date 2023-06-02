using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  TPM2.0 Specification data structures
  (Trusted Platform Module Library Specification, Family "2.0", Level 00, Revision 00.96,
  @http://www.trustedcomputinggroup.org/resources/tpm_library_specification)

  Check http://trustedcomputinggroup.org for latest specification updates.

Copyright (c) 2013 - 2015, Intel Corporation. All rights reserved. <BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _TPM20_H_
// #define _TPM20_H_

// #include <IndustryStandard/Tpm12.h>

// #pragma pack (1)

// Annex A Algorithm Constants

public unsafe partial class EFI
{
  // Table 205 - Defines for SHA1 Hash Values
  public const ulong SHA1_DIGEST_SIZE = 20;
  public const ulong SHA1_BLOCK_SIZE = 64;

  // Table 206 - Defines for SHA256 Hash Values
  public const ulong SHA256_DIGEST_SIZE = 32;
  public const ulong SHA256_BLOCK_SIZE = 64;

  // Table 207 - Defines for SHA384 Hash Values
  public const ulong SHA384_DIGEST_SIZE = 48;
  public const ulong SHA384_BLOCK_SIZE = 128;

  // Table 208 - Defines for SHA512 Hash Values
  public const ulong SHA512_DIGEST_SIZE = 64;
  public const ulong SHA512_BLOCK_SIZE = 128;

  // Table 209 - Defines for SM3_256 Hash Values
  public const ulong SM3_256_DIGEST_SIZE = 32;
  public const ulong SM3_256_BLOCK_SIZE = 64;

  // Table 210 - Defines for Architectural Limits Values
  public const ulong MAX_SESSION_NUMBER = 3;

  // Annex B Implementation Definitions

  // Table 211 - Defines for Logic Values
  public const ulong YES = 1;
  public const ulong NO = 0;
  public const ulong SET = 1;
  public const ulong CLEAR = 0;

  // Table 215 - Defines for RSA Algorithm Constants
  public const ulong MAX_RSA_KEY_BITS = 2048;
  public const ulong MAX_RSA_KEY_BYTES = ((MAX_RSA_KEY_BITS + 7) / 8);

  // Table 216 - Defines for ECC Algorithm Constants
  public const ulong MAX_ECC_KEY_BITS = 256;
  public const ulong MAX_ECC_KEY_BYTES = ((MAX_ECC_KEY_BITS + 7) / 8);

  // Table 217 - Defines for AES Algorithm Constants
  public const ulong MAX_AES_KEY_BITS = 128;
  public const ulong MAX_AES_BLOCK_SIZE_BYTES = 16;
  public const ulong MAX_AES_KEY_BYTES = ((MAX_AES_KEY_BITS + 7) / 8);

  // Table 218 - Defines for SM4 Algorithm Constants
  public const ulong MAX_SM4_KEY_BITS = 128;
  public const ulong MAX_SM4_BLOCK_SIZE_BYTES = 16;
  public const ulong MAX_SM4_KEY_BYTES = ((MAX_SM4_KEY_BITS + 7) / 8);

  // Table 219 - Defines for Symmetric Algorithm Constants
  public const ulong MAX_SYM_KEY_BITS = MAX_AES_KEY_BITS;
  public const ulong MAX_SYM_KEY_BYTES = MAX_AES_KEY_BYTES;
  public const ulong MAX_SYM_BLOCK_SIZE = MAX_AES_BLOCK_SIZE_BYTES;
}

// Table 220 - Defines for Implementation Values
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BSIZE { ushort Value; public static implicit operator BSIZE(ushort value) => new BSIZE() { Value = value }; public static implicit operator ushort(BSIZE value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong BUFFER_ALIGNMENT = 4;
  public const ulong IMPLEMENTATION_PCR = 24;
  public const ulong PLATFORM_PCR = 24;
  public const ulong DRTM_PCR = 17;
  public const ulong NUM_LOCALITIES = 5;
  public const ulong MAX_HANDLE_NUM = 3;
  public const ulong MAX_ACTIVE_SESSIONS = 64;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CONTEXT_SLOT { ushort Value; public static implicit operator CONTEXT_SLOT(ushort value) => new CONTEXT_SLOT() { Value = value }; public static implicit operator ushort(CONTEXT_SLOT value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CONTEXT_COUNTER { ulong Value; public static implicit operator CONTEXT_COUNTER(ulong value) => new CONTEXT_COUNTER() { Value = value }; public static implicit operator ulong(CONTEXT_COUNTER value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong MAX_LOADED_SESSIONS = 3;
  public const ulong MAX_SESSION_NUM = 3;
  public const ulong MAX_LOADED_OBJECTS = 3;
  public const ulong MIN_EVICT_OBJECTS = 2;
  public const ulong PCR_SELECT_MIN = ((PLATFORM_PCR + 7) / 8);
  public const ulong PCR_SELECT_MAX = ((IMPLEMENTATION_PCR + 7) / 8);
  public const ulong NUM_POLICY_PCR_GROUP = 1;
  public const ulong NUM_AUTHVALUE_PCR_GROUP = 1;
  public const ulong MAX_CONTEXT_SIZE = 4000;
  public const ulong MAX_DIGEST_BUFFER = 1024;
  public const ulong MAX_NV_INDEX_SIZE = 1024;
  public const ulong MAX_CAP_BUFFER = 1024;
  public const ulong NV_MEMORY_SIZE = 16384;
  public const ulong NUM_STATIC_PCR = 16;
  public const ulong MAX_ALG_LIST_SIZE = 64;
  public const ulong TIMER_PRESCALE = 100000;
  public const ulong PRIMARY_SEED_SIZE = 32;
  public const ulong CONTEXT_ENCRYPT_ALG = TPM_ALG_AES;
  public const ulong CONTEXT_ENCRYPT_KEY_BITS = MAX_SYM_KEY_BITS;
  public const ulong CONTEXT_ENCRYPT_KEY_BYTES = ((CONTEXT_ENCRYPT_KEY_BITS + 7) / 8);
  public const ulong CONTEXT_INTEGRITY_HASH_ALG = TPM_ALG_SHA256;
  public const ulong CONTEXT_INTEGRITY_HASH_SIZE = SHA256_DIGEST_SIZE;
  public const ulong PROOF_SIZE = CONTEXT_INTEGRITY_HASH_SIZE;
  public const ulong NV_CLOCK_UPDATE_INTERVAL = 12;
  public const ulong NUM_POLICY_PCR = 1;
  public const ulong MAX_COMMAND_SIZE = 4096;
  public const ulong MAX_RESPONSE_SIZE = 4096;
  public const ulong ORDERLY_BITS = 8;
  public const ulong MAX_ORDERLY_COUNT = ((1 << ORDERLY_BITS) - 1);
  public const ulong ALG_ID_FIRST = TPM_ALG_FIRST;
  public const ulong ALG_ID_LAST = TPM_ALG_LAST;
  public const ulong MAX_SYM_DATA = 128;
  public const ulong MAX_RNG_ENTROPY_SIZE = 64;
  public const ulong RAM_INDEX_SPACE = 512;
  public const ulong RSA_DEFAULT_PUBLIC_EXPONENT = 0x00010001;
  public const ulong CRT_FORMAT_RSA = YES;
  public const ulong PRIVATE_VENDOR_SPECIFIC_BYTES = ((MAX_RSA_KEY_BYTES / 2) * (3 + CRT_FORMAT_RSA * 2));

  // Capability related MAX_ value
  public const ulong MAX_CAP_DATA = (MAX_CAP_BUFFER - sizeof(TPM_CAP) - sizeof(uint));
  public const ulong MAX_CAP_ALGS = (MAX_CAP_DATA / sizeof(TPMS_ALG_PROPERTY));
  public const ulong MAX_CAP_HANDLES = (MAX_CAP_DATA / sizeof(TPM_HANDLE));
  public const ulong MAX_CAP_CC = (MAX_CAP_DATA / sizeof(TPM_CC));
  public const ulong MAX_TPM_PROPERTIES = (MAX_CAP_DATA / sizeof(TPMS_TAGGED_PROPERTY));
  public const ulong MAX_PCR_PROPERTIES = (MAX_CAP_DATA / sizeof(TPMS_TAGGED_PCR_SELECT));
  public const ulong MAX_ECC_CURVES = (MAX_CAP_DATA / sizeof(TPM_ECC_CURVE));

  //
  // Always set 5 here, because we want to support all hash algo in BIOS.
  //
  public const ulong HASH_COUNT = 5;

  // 5 Base Types
}

// Table 3 - Definition of Base Types
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BYTE { byte Value; public static implicit operator BYTE(byte value) => new BYTE() { Value = value }; public static implicit operator byte(BYTE value) => value.Value; }

// Table 4 - Definition of Types for Documentation Clarity
//
// NOTE: Comment because it has same name as TPM1.2 (value is same, so not runtime issue)
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_ALGORITHM_ID { uint Value; public static implicit operator TPM_ALGORITHM_ID(uint value) => new TPM_ALGORITHM_ID() { Value = value }; public static implicit operator uint(TPM_ALGORITHM_ID value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_MODIFIER_INDICATOR { uint Value; public static implicit operator TPM_MODIFIER_INDICATOR(uint value) => new TPM_MODIFIER_INDICATOR() { Value = value }; public static implicit operator uint(TPM_MODIFIER_INDICATOR value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_AUTHORIZATION_SIZE { uint Value; public static implicit operator TPM_AUTHORIZATION_SIZE(uint value) => new TPM_AUTHORIZATION_SIZE() { Value = value }; public static implicit operator uint(TPM_AUTHORIZATION_SIZE value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PARAMETER_SIZE { uint Value; public static implicit operator TPM_PARAMETER_SIZE(uint value) => new TPM_PARAMETER_SIZE() { Value = value }; public static implicit operator uint(TPM_PARAMETER_SIZE value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_KEY_SIZE { ushort Value; public static implicit operator TPM_KEY_SIZE(ushort value) => new TPM_KEY_SIZE() { Value = value }; public static implicit operator ushort(TPM_KEY_SIZE value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_KEY_BITS { ushort Value; public static implicit operator TPM_KEY_BITS(ushort value) => new TPM_KEY_BITS() { Value = value }; public static implicit operator ushort(TPM_KEY_BITS value) => value.Value; }

// 6 Constants

// Table 6 - TPM_GENERATED Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_GENERATED { uint Value; public static implicit operator TPM_GENERATED(uint value) => new TPM_GENERATED() { Value = value }; public static implicit operator uint(TPM_GENERATED value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_GENERATED_VALUE = (TPM_GENERATED)(0xff544347);
}

// Table 7 - TPM_ALG_ID Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_ALG_ID { ushort Value; public static implicit operator TPM_ALG_ID(ushort value) => new TPM_ALG_ID() { Value = value }; public static implicit operator ushort(TPM_ALG_ID value) => value.Value; }
public unsafe partial class EFI
{
  //
  // NOTE: Comment some algo which has same name as TPM1.2 (value is same, so not runtime issue)
  //
  public const ulong TPM_ALG_ERROR = (TPM_ALG_ID)(0x0000);
  public const ulong TPM_ALG_FIRST = (TPM_ALG_ID)(0x0001);
  public const ulong TPM_ALG_RSA = (TPM_ALG_ID)(0x0001);
  public const ulong TPM_ALG_SHA = (TPM_ALG_ID)(0x0004);
  public const ulong TPM_ALG_SHA1 = (TPM_ALG_ID)(0x0004);
  public const ulong TPM_ALG_HMAC = (TPM_ALG_ID)(0x0005);
  public const ulong TPM_ALG_AES = (TPM_ALG_ID)(0x0006);
  public const ulong TPM_ALG_MGF1 = (TPM_ALG_ID)(0x0007);
  public const ulong TPM_ALG_KEYEDHASH = (TPM_ALG_ID)(0x0008);
  public const ulong TPM_ALG_XOR = (TPM_ALG_ID)(0x000A);
  public const ulong TPM_ALG_SHA256 = (TPM_ALG_ID)(0x000B);
  public const ulong TPM_ALG_SHA384 = (TPM_ALG_ID)(0x000C);
  public const ulong TPM_ALG_SHA512 = (TPM_ALG_ID)(0x000D);
  public const ulong TPM_ALG_NULL = (TPM_ALG_ID)(0x0010);
  public const ulong TPM_ALG_SM3_256 = (TPM_ALG_ID)(0x0012);
  public const ulong TPM_ALG_SM4 = (TPM_ALG_ID)(0x0013);
  public const ulong TPM_ALG_RSASSA = (TPM_ALG_ID)(0x0014);
  public const ulong TPM_ALG_RSAES = (TPM_ALG_ID)(0x0015);
  public const ulong TPM_ALG_RSAPSS = (TPM_ALG_ID)(0x0016);
  public const ulong TPM_ALG_OAEP = (TPM_ALG_ID)(0x0017);
  public const ulong TPM_ALG_ECDSA = (TPM_ALG_ID)(0x0018);
  public const ulong TPM_ALG_ECDH = (TPM_ALG_ID)(0x0019);
  public const ulong TPM_ALG_ECDAA = (TPM_ALG_ID)(0x001A);
  public const ulong TPM_ALG_SM2 = (TPM_ALG_ID)(0x001B);
  public const ulong TPM_ALG_ECSCHNORR = (TPM_ALG_ID)(0x001C);
  public const ulong TPM_ALG_ECMQV = (TPM_ALG_ID)(0x001D);
  public const ulong TPM_ALG_KDF1_SP800_56a = (TPM_ALG_ID)(0x0020);
  public const ulong TPM_ALG_KDF2 = (TPM_ALG_ID)(0x0021);
  public const ulong TPM_ALG_KDF1_SP800_108 = (TPM_ALG_ID)(0x0022);
  public const ulong TPM_ALG_ECC = (TPM_ALG_ID)(0x0023);
  public const ulong TPM_ALG_SYMCIPHER = (TPM_ALG_ID)(0x0025);
  public const ulong TPM_ALG_CTR = (TPM_ALG_ID)(0x0040);
  public const ulong TPM_ALG_OFB = (TPM_ALG_ID)(0x0041);
  public const ulong TPM_ALG_CBC = (TPM_ALG_ID)(0x0042);
  public const ulong TPM_ALG_CFB = (TPM_ALG_ID)(0x0043);
  public const ulong TPM_ALG_ECB = (TPM_ALG_ID)(0x0044);
  public const ulong TPM_ALG_LAST = (TPM_ALG_ID)(0x0044);
}

// Table 8 - TPM_ECC_CURVE Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_ECC_CURVE { ushort Value; public static implicit operator TPM_ECC_CURVE(ushort value) => new TPM_ECC_CURVE() { Value = value }; public static implicit operator ushort(TPM_ECC_CURVE value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_ECC_NONE = (TPM_ECC_CURVE)(0x0000);
  public const ulong TPM_ECC_NIST_P192 = (TPM_ECC_CURVE)(0x0001);
  public const ulong TPM_ECC_NIST_P224 = (TPM_ECC_CURVE)(0x0002);
  public const ulong TPM_ECC_NIST_P256 = (TPM_ECC_CURVE)(0x0003);
  public const ulong TPM_ECC_NIST_P384 = (TPM_ECC_CURVE)(0x0004);
  public const ulong TPM_ECC_NIST_P521 = (TPM_ECC_CURVE)(0x0005);
  public const ulong TPM_ECC_BN_P256 = (TPM_ECC_CURVE)(0x0010);
  public const ulong TPM_ECC_BN_P638 = (TPM_ECC_CURVE)(0x0011);
  public const ulong TPM_ECC_SM2_P256 = (TPM_ECC_CURVE)(0x0020);
}

// Table 11 - TPM_CC Constants (Numeric Order)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CC { uint Value; public static implicit operator TPM_CC(uint value) => new TPM_CC() { Value = value }; public static implicit operator uint(TPM_CC value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_CC_FIRST = (TPM_CC)(0x0000011F);
  public const ulong TPM_CC_PP_FIRST = (TPM_CC)(0x0000011F);
  public const ulong TPM_CC_NV_UndefineSpaceSpecial = (TPM_CC)(0x0000011F);
  public const ulong TPM_CC_EvictControl = (TPM_CC)(0x00000120);
  public const ulong TPM_CC_HierarchyControl = (TPM_CC)(0x00000121);
  public const ulong TPM_CC_NV_UndefineSpace = (TPM_CC)(0x00000122);
  public const ulong TPM_CC_ChangeEPS = (TPM_CC)(0x00000124);
  public const ulong TPM_CC_ChangePPS = (TPM_CC)(0x00000125);
  public const ulong TPM_CC_Clear = (TPM_CC)(0x00000126);
  public const ulong TPM_CC_ClearControl = (TPM_CC)(0x00000127);
  public const ulong TPM_CC_ClockSet = (TPM_CC)(0x00000128);
  public const ulong TPM_CC_HierarchyChangeAuth = (TPM_CC)(0x00000129);
  public const ulong TPM_CC_NV_DefineSpace = (TPM_CC)(0x0000012A);
  public const ulong TPM_CC_PCR_Allocate = (TPM_CC)(0x0000012B);
  public const ulong TPM_CC_PCR_SetAuthPolicy = (TPM_CC)(0x0000012C);
  public const ulong TPM_CC_PP_Commands = (TPM_CC)(0x0000012D);
  public const ulong TPM_CC_SetPrimaryPolicy = (TPM_CC)(0x0000012E);
  public const ulong TPM_CC_FieldUpgradeStart = (TPM_CC)(0x0000012F);
  public const ulong TPM_CC_ClockRateAdjust = (TPM_CC)(0x00000130);
  public const ulong TPM_CC_CreatePrimary = (TPM_CC)(0x00000131);
  public const ulong TPM_CC_NV_GlobalWriteLock = (TPM_CC)(0x00000132);
  public const ulong TPM_CC_PP_LAST = (TPM_CC)(0x00000132);
  public const ulong TPM_CC_GetCommandAuditDigest = (TPM_CC)(0x00000133);
  public const ulong TPM_CC_NV_Increment = (TPM_CC)(0x00000134);
  public const ulong TPM_CC_NV_SetBits = (TPM_CC)(0x00000135);
  public const ulong TPM_CC_NV_Extend = (TPM_CC)(0x00000136);
  public const ulong TPM_CC_NV_Write = (TPM_CC)(0x00000137);
  public const ulong TPM_CC_NV_WriteLock = (TPM_CC)(0x00000138);
  public const ulong TPM_CC_DictionaryAttackLockReset = (TPM_CC)(0x00000139);
  public const ulong TPM_CC_DictionaryAttackParameters = (TPM_CC)(0x0000013A);
  public const ulong TPM_CC_NV_ChangeAuth = (TPM_CC)(0x0000013B);
  public const ulong TPM_CC_PCR_Event = (TPM_CC)(0x0000013C);
  public const ulong TPM_CC_PCR_Reset = (TPM_CC)(0x0000013D);
  public const ulong TPM_CC_SequenceComplete = (TPM_CC)(0x0000013E);
  public const ulong TPM_CC_SetAlgorithmSet = (TPM_CC)(0x0000013F);
  public const ulong TPM_CC_SetCommandCodeAuditStatus = (TPM_CC)(0x00000140);
  public const ulong TPM_CC_FieldUpgradeData = (TPM_CC)(0x00000141);
  public const ulong TPM_CC_IncrementalSelfTest = (TPM_CC)(0x00000142);
  public const ulong TPM_CC_SelfTest = (TPM_CC)(0x00000143);
  public const ulong TPM_CC_Startup = (TPM_CC)(0x00000144);
  public const ulong TPM_CC_Shutdown = (TPM_CC)(0x00000145);
  public const ulong TPM_CC_StirRandom = (TPM_CC)(0x00000146);
  public const ulong TPM_CC_ActivateCredential = (TPM_CC)(0x00000147);
  public const ulong TPM_CC_Certify = (TPM_CC)(0x00000148);
  public const ulong TPM_CC_PolicyNV = (TPM_CC)(0x00000149);
  public const ulong TPM_CC_CertifyCreation = (TPM_CC)(0x0000014A);
  public const ulong TPM_CC_Duplicate = (TPM_CC)(0x0000014B);
  public const ulong TPM_CC_GetTime = (TPM_CC)(0x0000014C);
  public const ulong TPM_CC_GetSessionAuditDigest = (TPM_CC)(0x0000014D);
  public const ulong TPM_CC_NV_Read = (TPM_CC)(0x0000014E);
  public const ulong TPM_CC_NV_ReadLock = (TPM_CC)(0x0000014F);
  public const ulong TPM_CC_ObjectChangeAuth = (TPM_CC)(0x00000150);
  public const ulong TPM_CC_PolicySecret = (TPM_CC)(0x00000151);
  public const ulong TPM_CC_Rewrap = (TPM_CC)(0x00000152);
  public const ulong TPM_CC_Create = (TPM_CC)(0x00000153);
  public const ulong TPM_CC_ECDH_ZGen = (TPM_CC)(0x00000154);
  public const ulong TPM_CC_HMAC = (TPM_CC)(0x00000155);
  public const ulong TPM_CC_Import = (TPM_CC)(0x00000156);
  public const ulong TPM_CC_Load = (TPM_CC)(0x00000157);
  public const ulong TPM_CC_Quote = (TPM_CC)(0x00000158);
  public const ulong TPM_CC_RSA_Decrypt = (TPM_CC)(0x00000159);
  public const ulong TPM_CC_HMAC_Start = (TPM_CC)(0x0000015B);
  public const ulong TPM_CC_SequenceUpdate = (TPM_CC)(0x0000015C);
  public const ulong TPM_CC_Sign = (TPM_CC)(0x0000015D);
  public const ulong TPM_CC_Unseal = (TPM_CC)(0x0000015E);
  public const ulong TPM_CC_PolicySigned = (TPM_CC)(0x00000160);
  public const ulong TPM_CC_ContextLoad = (TPM_CC)(0x00000161);
  public const ulong TPM_CC_ContextSave = (TPM_CC)(0x00000162);
  public const ulong TPM_CC_ECDH_KeyGen = (TPM_CC)(0x00000163);
  public const ulong TPM_CC_EncryptDecrypt = (TPM_CC)(0x00000164);
  public const ulong TPM_CC_FlushContext = (TPM_CC)(0x00000165);
  public const ulong TPM_CC_LoadExternal = (TPM_CC)(0x00000167);
  public const ulong TPM_CC_MakeCredential = (TPM_CC)(0x00000168);
  public const ulong TPM_CC_NV_ReadPublic = (TPM_CC)(0x00000169);
  public const ulong TPM_CC_PolicyAuthorize = (TPM_CC)(0x0000016A);
  public const ulong TPM_CC_PolicyAuthValue = (TPM_CC)(0x0000016B);
  public const ulong TPM_CC_PolicyCommandCode = (TPM_CC)(0x0000016C);
  public const ulong TPM_CC_PolicyCounterTimer = (TPM_CC)(0x0000016D);
  public const ulong TPM_CC_PolicyCpHash = (TPM_CC)(0x0000016E);
  public const ulong TPM_CC_PolicyLocality = (TPM_CC)(0x0000016F);
  public const ulong TPM_CC_PolicyNameHash = (TPM_CC)(0x00000170);
  public const ulong TPM_CC_PolicyOR = (TPM_CC)(0x00000171);
  public const ulong TPM_CC_PolicyTicket = (TPM_CC)(0x00000172);
  public const ulong TPM_CC_ReadPublic = (TPM_CC)(0x00000173);
  public const ulong TPM_CC_RSA_Encrypt = (TPM_CC)(0x00000174);
  public const ulong TPM_CC_StartAuthSession = (TPM_CC)(0x00000176);
  public const ulong TPM_CC_VerifySignature = (TPM_CC)(0x00000177);
  public const ulong TPM_CC_ECC_Parameters = (TPM_CC)(0x00000178);
  public const ulong TPM_CC_FirmwareRead = (TPM_CC)(0x00000179);
  public const ulong TPM_CC_GetCapability = (TPM_CC)(0x0000017A);
  public const ulong TPM_CC_GetRandom = (TPM_CC)(0x0000017B);
  public const ulong TPM_CC_GetTestResult = (TPM_CC)(0x0000017C);
  public const ulong TPM_CC_Hash = (TPM_CC)(0x0000017D);
  public const ulong TPM_CC_PCR_Read = (TPM_CC)(0x0000017E);
  public const ulong TPM_CC_PolicyPCR = (TPM_CC)(0x0000017F);
  public const ulong TPM_CC_PolicyRestart = (TPM_CC)(0x00000180);
  public const ulong TPM_CC_ReadClock = (TPM_CC)(0x00000181);
  public const ulong TPM_CC_PCR_Extend = (TPM_CC)(0x00000182);
  public const ulong TPM_CC_PCR_SetAuthValue = (TPM_CC)(0x00000183);
  public const ulong TPM_CC_NV_Certify = (TPM_CC)(0x00000184);
  public const ulong TPM_CC_EventSequenceComplete = (TPM_CC)(0x00000185);
  public const ulong TPM_CC_HashSequenceStart = (TPM_CC)(0x00000186);
  public const ulong TPM_CC_PolicyPhysicalPresence = (TPM_CC)(0x00000187);
  public const ulong TPM_CC_PolicyDuplicationSelect = (TPM_CC)(0x00000188);
  public const ulong TPM_CC_PolicyGetDigest = (TPM_CC)(0x00000189);
  public const ulong TPM_CC_TestParms = (TPM_CC)(0x0000018A);
  public const ulong TPM_CC_Commit = (TPM_CC)(0x0000018B);
  public const ulong TPM_CC_PolicyPassword = (TPM_CC)(0x0000018C);
  public const ulong TPM_CC_ZGen_2Phase = (TPM_CC)(0x0000018D);
  public const ulong TPM_CC_EC_Ephemeral = (TPM_CC)(0x0000018E);
  public const ulong TPM_CC_LAST = (TPM_CC)(0x0000018E);
}

// Table 15 - TPM_RC Constants (Actions)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_RC { uint Value; public static implicit operator TPM_RC(uint value) => new TPM_RC() { Value = value }; public static implicit operator uint(TPM_RC value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_RC_SUCCESS = (TPM_RC)(0x000);
  public const ulong TPM_RC_BAD_TAG = (TPM_RC)(0x030);
  public const ulong RC_VER1 = (TPM_RC)(0x100);
  public const ulong TPM_RC_INITIALIZE = (TPM_RC)(RC_VER1 + 0x000);
  public const ulong TPM_RC_FAILURE = (TPM_RC)(RC_VER1 + 0x001);
  public const ulong TPM_RC_SEQUENCE = (TPM_RC)(RC_VER1 + 0x003);
  public const ulong TPM_RC_PRIVATE = (TPM_RC)(RC_VER1 + 0x00B);
  public const ulong TPM_RC_HMAC = (TPM_RC)(RC_VER1 + 0x019);
  public const ulong TPM_RC_DISABLED = (TPM_RC)(RC_VER1 + 0x020);
  public const ulong TPM_RC_EXCLUSIVE = (TPM_RC)(RC_VER1 + 0x021);
  public const ulong TPM_RC_AUTH_TYPE = (TPM_RC)(RC_VER1 + 0x024);
  public const ulong TPM_RC_AUTH_MISSING = (TPM_RC)(RC_VER1 + 0x025);
  public const ulong TPM_RC_POLICY = (TPM_RC)(RC_VER1 + 0x026);
  public const ulong TPM_RC_PCR = (TPM_RC)(RC_VER1 + 0x027);
  public const ulong TPM_RC_PCR_CHANGED = (TPM_RC)(RC_VER1 + 0x028);
  public const ulong TPM_RC_UPGRADE = (TPM_RC)(RC_VER1 + 0x02D);
  public const ulong TPM_RC_TOO_MANY_CONTEXTS = (TPM_RC)(RC_VER1 + 0x02E);
  public const ulong TPM_RC_AUTH_UNAVAILABLE = (TPM_RC)(RC_VER1 + 0x02F);
  public const ulong TPM_RC_REBOOT = (TPM_RC)(RC_VER1 + 0x030);
  public const ulong TPM_RC_UNBALANCED = (TPM_RC)(RC_VER1 + 0x031);
  public const ulong TPM_RC_COMMAND_SIZE = (TPM_RC)(RC_VER1 + 0x042);
  public const ulong TPM_RC_COMMAND_CODE = (TPM_RC)(RC_VER1 + 0x043);
  public const ulong TPM_RC_AUTHSIZE = (TPM_RC)(RC_VER1 + 0x044);
  public const ulong TPM_RC_AUTH_CONTEXT = (TPM_RC)(RC_VER1 + 0x045);
  public const ulong TPM_RC_NV_RANGE = (TPM_RC)(RC_VER1 + 0x046);
  public const ulong TPM_RC_NV_SIZE = (TPM_RC)(RC_VER1 + 0x047);
  public const ulong TPM_RC_NV_LOCKED = (TPM_RC)(RC_VER1 + 0x048);
  public const ulong TPM_RC_NV_AUTHORIZATION = (TPM_RC)(RC_VER1 + 0x049);
  public const ulong TPM_RC_NV_UNINITIALIZED = (TPM_RC)(RC_VER1 + 0x04A);
  public const ulong TPM_RC_NV_SPACE = (TPM_RC)(RC_VER1 + 0x04B);
  public const ulong TPM_RC_NV_DEFINED = (TPM_RC)(RC_VER1 + 0x04C);
  public const ulong TPM_RC_BAD_CONTEXT = (TPM_RC)(RC_VER1 + 0x050);
  public const ulong TPM_RC_CPHASH = (TPM_RC)(RC_VER1 + 0x051);
  public const ulong TPM_RC_PARENT = (TPM_RC)(RC_VER1 + 0x052);
  public const ulong TPM_RC_NEEDS_TEST = (TPM_RC)(RC_VER1 + 0x053);
  public const ulong TPM_RC_NO_RESULT = (TPM_RC)(RC_VER1 + 0x054);
  public const ulong TPM_RC_SENSITIVE = (TPM_RC)(RC_VER1 + 0x055);
  public const ulong RC_MAX_FM0 = (TPM_RC)(RC_VER1 + 0x07F);
  public const ulong RC_FMT1 = (TPM_RC)(0x080);
  public const ulong TPM_RC_ASYMMETRIC = (TPM_RC)(RC_FMT1 + 0x001);
  public const ulong TPM_RC_ATTRIBUTES = (TPM_RC)(RC_FMT1 + 0x002);
  public const ulong TPM_RC_HASH = (TPM_RC)(RC_FMT1 + 0x003);
  public const ulong TPM_RC_VALUE = (TPM_RC)(RC_FMT1 + 0x004);
  public const ulong TPM_RC_HIERARCHY = (TPM_RC)(RC_FMT1 + 0x005);
  public const ulong TPM_RC_KEY_SIZE = (TPM_RC)(RC_FMT1 + 0x007);
  public const ulong TPM_RC_MGF = (TPM_RC)(RC_FMT1 + 0x008);
  public const ulong TPM_RC_MODE = (TPM_RC)(RC_FMT1 + 0x009);
  public const ulong TPM_RC_TYPE = (TPM_RC)(RC_FMT1 + 0x00A);
  public const ulong TPM_RC_HANDLE = (TPM_RC)(RC_FMT1 + 0x00B);
  public const ulong TPM_RC_KDF = (TPM_RC)(RC_FMT1 + 0x00C);
  public const ulong TPM_RC_RANGE = (TPM_RC)(RC_FMT1 + 0x00D);
  public const ulong TPM_RC_AUTH_FAIL = (TPM_RC)(RC_FMT1 + 0x00E);
  public const ulong TPM_RC_NONCE = (TPM_RC)(RC_FMT1 + 0x00F);
  public const ulong TPM_RC_PP = (TPM_RC)(RC_FMT1 + 0x010);
  public const ulong TPM_RC_SCHEME = (TPM_RC)(RC_FMT1 + 0x012);
  public const ulong TPM_RC_SIZE = (TPM_RC)(RC_FMT1 + 0x015);
  public const ulong TPM_RC_SYMMETRIC = (TPM_RC)(RC_FMT1 + 0x016);
  public const ulong TPM_RC_TAG = (TPM_RC)(RC_FMT1 + 0x017);
  public const ulong TPM_RC_SELECTOR = (TPM_RC)(RC_FMT1 + 0x018);
  public const ulong TPM_RC_INSUFFICIENT = (TPM_RC)(RC_FMT1 + 0x01A);
  public const ulong TPM_RC_SIGNATURE = (TPM_RC)(RC_FMT1 + 0x01B);
  public const ulong TPM_RC_KEY = (TPM_RC)(RC_FMT1 + 0x01C);
  public const ulong TPM_RC_POLICY_FAIL = (TPM_RC)(RC_FMT1 + 0x01D);
  public const ulong TPM_RC_INTEGRITY = (TPM_RC)(RC_FMT1 + 0x01F);
  public const ulong TPM_RC_TICKET = (TPM_RC)(RC_FMT1 + 0x020);
  public const ulong TPM_RC_RESERVED_BITS = (TPM_RC)(RC_FMT1 + 0x021);
  public const ulong TPM_RC_BAD_AUTH = (TPM_RC)(RC_FMT1 + 0x022);
  public const ulong TPM_RC_EXPIRED = (TPM_RC)(RC_FMT1 + 0x023);
  public const ulong TPM_RC_POLICY_CC = (TPM_RC)(RC_FMT1 + 0x024);
  public const ulong TPM_RC_BINDING = (TPM_RC)(RC_FMT1 + 0x025);
  public const ulong TPM_RC_CURVE = (TPM_RC)(RC_FMT1 + 0x026);
  public const ulong TPM_RC_ECC_POINT = (TPM_RC)(RC_FMT1 + 0x027);
  public const ulong RC_WARN = (TPM_RC)(0x900);
  public const ulong TPM_RC_CONTEXT_GAP = (TPM_RC)(RC_WARN + 0x001);
  public const ulong TPM_RC_OBJECT_MEMORY = (TPM_RC)(RC_WARN + 0x002);
  public const ulong TPM_RC_SESSION_MEMORY = (TPM_RC)(RC_WARN + 0x003);
  public const ulong TPM_RC_MEMORY = (TPM_RC)(RC_WARN + 0x004);
  public const ulong TPM_RC_SESSION_HANDLES = (TPM_RC)(RC_WARN + 0x005);
  public const ulong TPM_RC_OBJECT_HANDLES = (TPM_RC)(RC_WARN + 0x006);
  public const ulong TPM_RC_LOCALITY = (TPM_RC)(RC_WARN + 0x007);
  public const ulong TPM_RC_YIELDED = (TPM_RC)(RC_WARN + 0x008);
  public const ulong TPM_RC_CANCELED = (TPM_RC)(RC_WARN + 0x009);
  public const ulong TPM_RC_TESTING = (TPM_RC)(RC_WARN + 0x00A);
  public const ulong TPM_RC_REFERENCE_H0 = (TPM_RC)(RC_WARN + 0x010);
  public const ulong TPM_RC_REFERENCE_H1 = (TPM_RC)(RC_WARN + 0x011);
  public const ulong TPM_RC_REFERENCE_H2 = (TPM_RC)(RC_WARN + 0x012);
  public const ulong TPM_RC_REFERENCE_H3 = (TPM_RC)(RC_WARN + 0x013);
  public const ulong TPM_RC_REFERENCE_H4 = (TPM_RC)(RC_WARN + 0x014);
  public const ulong TPM_RC_REFERENCE_H5 = (TPM_RC)(RC_WARN + 0x015);
  public const ulong TPM_RC_REFERENCE_H6 = (TPM_RC)(RC_WARN + 0x016);
  public const ulong TPM_RC_REFERENCE_S0 = (TPM_RC)(RC_WARN + 0x018);
  public const ulong TPM_RC_REFERENCE_S1 = (TPM_RC)(RC_WARN + 0x019);
  public const ulong TPM_RC_REFERENCE_S2 = (TPM_RC)(RC_WARN + 0x01A);
  public const ulong TPM_RC_REFERENCE_S3 = (TPM_RC)(RC_WARN + 0x01B);
  public const ulong TPM_RC_REFERENCE_S4 = (TPM_RC)(RC_WARN + 0x01C);
  public const ulong TPM_RC_REFERENCE_S5 = (TPM_RC)(RC_WARN + 0x01D);
  public const ulong TPM_RC_REFERENCE_S6 = (TPM_RC)(RC_WARN + 0x01E);
  public const ulong TPM_RC_NV_RATE = (TPM_RC)(RC_WARN + 0x020);
  public const ulong TPM_RC_LOCKOUT = (TPM_RC)(RC_WARN + 0x021);
  public const ulong TPM_RC_RETRY = (TPM_RC)(RC_WARN + 0x022);
  public const ulong TPM_RC_NV_UNAVAILABLE = (TPM_RC)(RC_WARN + 0x023);
  public const ulong TPM_RC_NOT_USED = (TPM_RC)(RC_WARN + 0x7F);
  public const ulong TPM_RC_H = (TPM_RC)(0x000);
  public const ulong TPM_RC_P = (TPM_RC)(0x040);
  public const ulong TPM_RC_S = (TPM_RC)(0x800);
  public const ulong TPM_RC_1 = (TPM_RC)(0x100);
  public const ulong TPM_RC_2 = (TPM_RC)(0x200);
  public const ulong TPM_RC_3 = (TPM_RC)(0x300);
  public const ulong TPM_RC_4 = (TPM_RC)(0x400);
  public const ulong TPM_RC_5 = (TPM_RC)(0x500);
  public const ulong TPM_RC_6 = (TPM_RC)(0x600);
  public const ulong TPM_RC_7 = (TPM_RC)(0x700);
  public const ulong TPM_RC_8 = (TPM_RC)(0x800);
  public const ulong TPM_RC_9 = (TPM_RC)(0x900);
  public const ulong TPM_RC_A = (TPM_RC)(0xA00);
  public const ulong TPM_RC_B = (TPM_RC)(0xB00);
  public const ulong TPM_RC_C = (TPM_RC)(0xC00);
  public const ulong TPM_RC_D = (TPM_RC)(0xD00);
  public const ulong TPM_RC_E = (TPM_RC)(0xE00);
  public const ulong TPM_RC_F = (TPM_RC)(0xF00);
  public const ulong TPM_RC_N_MASK = (TPM_RC)(0xF00);
}

// Table 16 - TPM_CLOCK_ADJUST Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CLOCK_ADJUST { sbyte Value; public static implicit operator TPM_CLOCK_ADJUST(sbyte value) => new TPM_CLOCK_ADJUST() { Value = value }; public static implicit operator sbyte(TPM_CLOCK_ADJUST value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_CLOCK_COARSE_SLOWER = (TPM_CLOCK_ADJUST)(-3);
  public const ulong TPM_CLOCK_MEDIUM_SLOWER = (TPM_CLOCK_ADJUST)(-2);
  public const ulong TPM_CLOCK_FINE_SLOWER = (TPM_CLOCK_ADJUST)(-1);
  public const ulong TPM_CLOCK_NO_CHANGE = (TPM_CLOCK_ADJUST)(0);
  public const ulong TPM_CLOCK_FINE_FASTER = (TPM_CLOCK_ADJUST)(1);
  public const ulong TPM_CLOCK_MEDIUM_FASTER = (TPM_CLOCK_ADJUST)(2);
  public const ulong TPM_CLOCK_COARSE_FASTER = (TPM_CLOCK_ADJUST)(3);
}

// Table 17 - TPM_EO Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_EO { ushort Value; public static implicit operator TPM_EO(ushort value) => new TPM_EO() { Value = value }; public static implicit operator ushort(TPM_EO value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_EO_EQ = (TPM_EO)(0x0000);
  public const ulong TPM_EO_NEQ = (TPM_EO)(0x0001);
  public const ulong TPM_EO_SIGNED_GT = (TPM_EO)(0x0002);
  public const ulong TPM_EO_UNSIGNED_GT = (TPM_EO)(0x0003);
  public const ulong TPM_EO_SIGNED_LT = (TPM_EO)(0x0004);
  public const ulong TPM_EO_UNSIGNED_LT = (TPM_EO)(0x0005);
  public const ulong TPM_EO_SIGNED_GE = (TPM_EO)(0x0006);
  public const ulong TPM_EO_UNSIGNED_GE = (TPM_EO)(0x0007);
  public const ulong TPM_EO_SIGNED_LE = (TPM_EO)(0x0008);
  public const ulong TPM_EO_UNSIGNED_LE = (TPM_EO)(0x0009);
  public const ulong TPM_EO_BITSET = (TPM_EO)(0x000A);
  public const ulong TPM_EO_BITCLEAR = (TPM_EO)(0x000B);
}

// Table 18 - TPM_ST Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_ST { ushort Value; public static implicit operator TPM_ST(ushort value) => new TPM_ST() { Value = value }; public static implicit operator ushort(TPM_ST value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_ST_RSP_COMMAND = (TPM_ST)(0x00C4);
  public const ulong TPM_ST_NULL = (TPM_ST)(0X8000);
  public const ulong TPM_ST_NO_SESSIONS = (TPM_ST)(0x8001);
  public const ulong TPM_ST_SESSIONS = (TPM_ST)(0x8002);
  public const ulong TPM_ST_ATTEST_NV = (TPM_ST)(0x8014);
  public const ulong TPM_ST_ATTEST_COMMAND_AUDIT = (TPM_ST)(0x8015);
  public const ulong TPM_ST_ATTEST_SESSION_AUDIT = (TPM_ST)(0x8016);
  public const ulong TPM_ST_ATTEST_CERTIFY = (TPM_ST)(0x8017);
  public const ulong TPM_ST_ATTEST_QUOTE = (TPM_ST)(0x8018);
  public const ulong TPM_ST_ATTEST_TIME = (TPM_ST)(0x8019);
  public const ulong TPM_ST_ATTEST_CREATION = (TPM_ST)(0x801A);
  public const ulong TPM_ST_CREATION = (TPM_ST)(0x8021);
  public const ulong TPM_ST_VERIFIED = (TPM_ST)(0x8022);
  public const ulong TPM_ST_AUTH_SECRET = (TPM_ST)(0x8023);
  public const ulong TPM_ST_HASHCHECK = (TPM_ST)(0x8024);
  public const ulong TPM_ST_AUTH_SIGNED = (TPM_ST)(0x8025);
  public const ulong TPM_ST_FU_MANIFEST = (TPM_ST)(0x8029);
}

// Table 19 - TPM_SU Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_SU { ushort Value; public static implicit operator TPM_SU(ushort value) => new TPM_SU() { Value = value }; public static implicit operator ushort(TPM_SU value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_SU_CLEAR = (TPM_SU)(0x0000);
  public const ulong TPM_SU_STATE = (TPM_SU)(0x0001);
}

// Table 20 - TPM_SE Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_SE { byte Value; public static implicit operator TPM_SE(byte value) => new TPM_SE() { Value = value }; public static implicit operator byte(TPM_SE value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_SE_HMAC = (TPM_SE)(0x00);
  public const ulong TPM_SE_POLICY = (TPM_SE)(0x01);
  public const ulong TPM_SE_TRIAL = (TPM_SE)(0x03);
}

// Table 21 - TPM_CAP Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_CAP { uint Value; public static implicit operator TPM_CAP(uint value) => new TPM_CAP() { Value = value }; public static implicit operator uint(TPM_CAP value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_CAP_FIRST = (TPM_CAP)(0x00000000);
  public const ulong TPM_CAP_ALGS = (TPM_CAP)(0x00000000);
  public const ulong TPM_CAP_HANDLES = (TPM_CAP)(0x00000001);
  public const ulong TPM_CAP_COMMANDS = (TPM_CAP)(0x00000002);
  public const ulong TPM_CAP_PP_COMMANDS = (TPM_CAP)(0x00000003);
  public const ulong TPM_CAP_AUDIT_COMMANDS = (TPM_CAP)(0x00000004);
  public const ulong TPM_CAP_PCRS = (TPM_CAP)(0x00000005);
  public const ulong TPM_CAP_TPM_PROPERTIES = (TPM_CAP)(0x00000006);
  public const ulong TPM_CAP_PCR_PROPERTIES = (TPM_CAP)(0x00000007);
  public const ulong TPM_CAP_ECC_CURVES = (TPM_CAP)(0x00000008);
  public const ulong TPM_CAP_LAST = (TPM_CAP)(0x00000008);
  public const ulong TPM_CAP_VENDOR_PROPERTY = (TPM_CAP)(0x00000100);
}

// Table 22 - TPM_PT Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PT { uint Value; public static implicit operator TPM_PT(uint value) => new TPM_PT() { Value = value }; public static implicit operator uint(TPM_PT value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_PT_NONE = (TPM_PT)(0x00000000);
  public const ulong PT_GROUP = (TPM_PT)(0x00000100);
  public const ulong PT_FIXED = (TPM_PT)(PT_GROUP * 1);
  public const ulong TPM_PT_FAMILY_INDICATOR = (TPM_PT)(PT_FIXED + 0);
  public const ulong TPM_PT_LEVEL = (TPM_PT)(PT_FIXED + 1);
  public const ulong TPM_PT_REVISION = (TPM_PT)(PT_FIXED + 2);
  public const ulong TPM_PT_DAY_OF_YEAR = (TPM_PT)(PT_FIXED + 3);
  public const ulong TPM_PT_YEAR = (TPM_PT)(PT_FIXED + 4);
  public const ulong TPM_PT_MANUFACTURER = (TPM_PT)(PT_FIXED + 5);
  public const ulong TPM_PT_VENDOR_STRING_1 = (TPM_PT)(PT_FIXED + 6);
  public const ulong TPM_PT_VENDOR_STRING_2 = (TPM_PT)(PT_FIXED + 7);
  public const ulong TPM_PT_VENDOR_STRING_3 = (TPM_PT)(PT_FIXED + 8);
  public const ulong TPM_PT_VENDOR_STRING_4 = (TPM_PT)(PT_FIXED + 9);
  public const ulong TPM_PT_VENDOR_TPM_TYPE = (TPM_PT)(PT_FIXED + 10);
  public const ulong TPM_PT_FIRMWARE_VERSION_1 = (TPM_PT)(PT_FIXED + 11);
  public const ulong TPM_PT_FIRMWARE_VERSION_2 = (TPM_PT)(PT_FIXED + 12);
  public const ulong TPM_PT_INPUT_BUFFER = (TPM_PT)(PT_FIXED + 13);
  public const ulong TPM_PT_HR_TRANSIENT_MIN = (TPM_PT)(PT_FIXED + 14);
  public const ulong TPM_PT_HR_PERSISTENT_MIN = (TPM_PT)(PT_FIXED + 15);
  public const ulong TPM_PT_HR_LOADED_MIN = (TPM_PT)(PT_FIXED + 16);
  public const ulong TPM_PT_ACTIVE_SESSIONS_MAX = (TPM_PT)(PT_FIXED + 17);
  public const ulong TPM_PT_PCR_COUNT = (TPM_PT)(PT_FIXED + 18);
  public const ulong TPM_PT_PCR_SELECT_MIN = (TPM_PT)(PT_FIXED + 19);
  public const ulong TPM_PT_CONTEXT_GAP_MAX = (TPM_PT)(PT_FIXED + 20);
  public const ulong TPM_PT_NV_COUNTERS_MAX = (TPM_PT)(PT_FIXED + 22);
  public const ulong TPM_PT_NV_INDEX_MAX = (TPM_PT)(PT_FIXED + 23);
  public const ulong TPM_PT_MEMORY = (TPM_PT)(PT_FIXED + 24);
  public const ulong TPM_PT_CLOCK_UPDATE = (TPM_PT)(PT_FIXED + 25);
  public const ulong TPM_PT_CONTEXT_HASH = (TPM_PT)(PT_FIXED + 26);
  public const ulong TPM_PT_CONTEXT_SYM = (TPM_PT)(PT_FIXED + 27);
  public const ulong TPM_PT_CONTEXT_SYM_SIZE = (TPM_PT)(PT_FIXED + 28);
  public const ulong TPM_PT_ORDERLY_COUNT = (TPM_PT)(PT_FIXED + 29);
  public const ulong TPM_PT_MAX_COMMAND_SIZE = (TPM_PT)(PT_FIXED + 30);
  public const ulong TPM_PT_MAX_RESPONSE_SIZE = (TPM_PT)(PT_FIXED + 31);
  public const ulong TPM_PT_MAX_DIGEST = (TPM_PT)(PT_FIXED + 32);
  public const ulong TPM_PT_MAX_OBJECT_CONTEXT = (TPM_PT)(PT_FIXED + 33);
  public const ulong TPM_PT_MAX_SESSION_CONTEXT = (TPM_PT)(PT_FIXED + 34);
  public const ulong TPM_PT_PS_FAMILY_INDICATOR = (TPM_PT)(PT_FIXED + 35);
  public const ulong TPM_PT_PS_LEVEL = (TPM_PT)(PT_FIXED + 36);
  public const ulong TPM_PT_PS_REVISION = (TPM_PT)(PT_FIXED + 37);
  public const ulong TPM_PT_PS_DAY_OF_YEAR = (TPM_PT)(PT_FIXED + 38);
  public const ulong TPM_PT_PS_YEAR = (TPM_PT)(PT_FIXED + 39);
  public const ulong TPM_PT_SPLIT_MAX = (TPM_PT)(PT_FIXED + 40);
  public const ulong TPM_PT_TOTAL_COMMANDS = (TPM_PT)(PT_FIXED + 41);
  public const ulong TPM_PT_LIBRARY_COMMANDS = (TPM_PT)(PT_FIXED + 42);
  public const ulong TPM_PT_VENDOR_COMMANDS = (TPM_PT)(PT_FIXED + 43);
  public const ulong PT_VAR = (TPM_PT)(PT_GROUP * 2);
  public const ulong TPM_PT_PERMANENT = (TPM_PT)(PT_VAR + 0);
  public const ulong TPM_PT_STARTUP_CLEAR = (TPM_PT)(PT_VAR + 1);
  public const ulong TPM_PT_HR_NV_INDEX = (TPM_PT)(PT_VAR + 2);
  public const ulong TPM_PT_HR_LOADED = (TPM_PT)(PT_VAR + 3);
  public const ulong TPM_PT_HR_LOADED_AVAIL = (TPM_PT)(PT_VAR + 4);
  public const ulong TPM_PT_HR_ACTIVE = (TPM_PT)(PT_VAR + 5);
  public const ulong TPM_PT_HR_ACTIVE_AVAIL = (TPM_PT)(PT_VAR + 6);
  public const ulong TPM_PT_HR_TRANSIENT_AVAIL = (TPM_PT)(PT_VAR + 7);
  public const ulong TPM_PT_HR_PERSISTENT = (TPM_PT)(PT_VAR + 8);
  public const ulong TPM_PT_HR_PERSISTENT_AVAIL = (TPM_PT)(PT_VAR + 9);
  public const ulong TPM_PT_NV_COUNTERS = (TPM_PT)(PT_VAR + 10);
  public const ulong TPM_PT_NV_COUNTERS_AVAIL = (TPM_PT)(PT_VAR + 11);
  public const ulong TPM_PT_ALGORITHM_SET = (TPM_PT)(PT_VAR + 12);
  public const ulong TPM_PT_LOADED_CURVES = (TPM_PT)(PT_VAR + 13);
  public const ulong TPM_PT_LOCKOUT_COUNTER = (TPM_PT)(PT_VAR + 14);
  public const ulong TPM_PT_MAX_AUTH_FAIL = (TPM_PT)(PT_VAR + 15);
  public const ulong TPM_PT_LOCKOUT_INTERVAL = (TPM_PT)(PT_VAR + 16);
  public const ulong TPM_PT_LOCKOUT_RECOVERY = (TPM_PT)(PT_VAR + 17);
  public const ulong TPM_PT_NV_WRITE_RECOVERY = (TPM_PT)(PT_VAR + 18);
  public const ulong TPM_PT_AUDIT_COUNTER_0 = (TPM_PT)(PT_VAR + 19);
  public const ulong TPM_PT_AUDIT_COUNTER_1 = (TPM_PT)(PT_VAR + 20);
}

// Table 23 - TPM_PT_PCR Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PT_PCR { uint Value; public static implicit operator TPM_PT_PCR(uint value) => new TPM_PT_PCR() { Value = value }; public static implicit operator uint(TPM_PT_PCR value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_PT_PCR_FIRST = (TPM_PT_PCR)(0x00000000);
  public const ulong TPM_PT_PCR_SAVE = (TPM_PT_PCR)(0x00000000);
  public const ulong TPM_PT_PCR_EXTEND_L0 = (TPM_PT_PCR)(0x00000001);
  public const ulong TPM_PT_PCR_RESET_L0 = (TPM_PT_PCR)(0x00000002);
  public const ulong TPM_PT_PCR_EXTEND_L1 = (TPM_PT_PCR)(0x00000003);
  public const ulong TPM_PT_PCR_RESET_L1 = (TPM_PT_PCR)(0x00000004);
  public const ulong TPM_PT_PCR_EXTEND_L2 = (TPM_PT_PCR)(0x00000005);
  public const ulong TPM_PT_PCR_RESET_L2 = (TPM_PT_PCR)(0x00000006);
  public const ulong TPM_PT_PCR_EXTEND_L3 = (TPM_PT_PCR)(0x00000007);
  public const ulong TPM_PT_PCR_RESET_L3 = (TPM_PT_PCR)(0x00000008);
  public const ulong TPM_PT_PCR_EXTEND_L4 = (TPM_PT_PCR)(0x00000009);
  public const ulong TPM_PT_PCR_RESET_L4 = (TPM_PT_PCR)(0x0000000A);
  public const ulong TPM_PT_PCR_NO_INCREMENT = (TPM_PT_PCR)(0x00000011);
  public const ulong TPM_PT_PCR_DRTM_RESET = (TPM_PT_PCR)(0x00000012);
  public const ulong TPM_PT_PCR_POLICY = (TPM_PT_PCR)(0x00000013);
  public const ulong TPM_PT_PCR_AUTH = (TPM_PT_PCR)(0x00000014);
  public const ulong TPM_PT_PCR_LAST = (TPM_PT_PCR)(0x00000014);
}

// Table 24 - TPM_PS Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_PS { uint Value; public static implicit operator TPM_PS(uint value) => new TPM_PS() { Value = value }; public static implicit operator uint(TPM_PS value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_PS_MAIN = (TPM_PS)(0x00000000);
  public const ulong TPM_PS_PC = (TPM_PS)(0x00000001);
  public const ulong TPM_PS_PDA = (TPM_PS)(0x00000002);
  public const ulong TPM_PS_CELL_PHONE = (TPM_PS)(0x00000003);
  public const ulong TPM_PS_SERVER = (TPM_PS)(0x00000004);
  public const ulong TPM_PS_PERIPHERAL = (TPM_PS)(0x00000005);
  public const ulong TPM_PS_TSS = (TPM_PS)(0x00000006);
  public const ulong TPM_PS_STORAGE = (TPM_PS)(0x00000007);
  public const ulong TPM_PS_AUTHENTICATION = (TPM_PS)(0x00000008);
  public const ulong TPM_PS_EMBEDDED = (TPM_PS)(0x00000009);
  public const ulong TPM_PS_HARDCOPY = (TPM_PS)(0x0000000A);
  public const ulong TPM_PS_INFRASTRUCTURE = (TPM_PS)(0x0000000B);
  public const ulong TPM_PS_VIRTUALIZATION = (TPM_PS)(0x0000000C);
  public const ulong TPM_PS_TNC = (TPM_PS)(0x0000000D);
  public const ulong TPM_PS_MULTI_TENANT = (TPM_PS)(0x0000000E);
  public const ulong TPM_PS_TC = (TPM_PS)(0x0000000F);

  // 7 Handles
}

// Table 25 - Handles Types
//
// NOTE: Comment because it has same name as TPM1.2 (value is same, so not runtime issue)
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_HANDLE { uint Value; public static implicit operator TPM_HANDLE(uint value) => new TPM_HANDLE() { Value = value }; public static implicit operator uint(TPM_HANDLE value) => value.Value; }

// Table 26 - TPM_HT Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_HT { byte Value; public static implicit operator TPM_HT(byte value) => new TPM_HT() { Value = value }; public static implicit operator byte(TPM_HT value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_HT_PCR = (TPM_HT)(0x00);
  public const ulong TPM_HT_NV_INDEX = (TPM_HT)(0x01);
  public const ulong TPM_HT_HMAC_SESSION = (TPM_HT)(0x02);
  public const ulong TPM_HT_LOADED_SESSION = (TPM_HT)(0x02);
  public const ulong TPM_HT_POLICY_SESSION = (TPM_HT)(0x03);
  public const ulong TPM_HT_ACTIVE_SESSION = (TPM_HT)(0x03);
  public const ulong TPM_HT_PERMANENT = (TPM_HT)(0x40);
  public const ulong TPM_HT_TRANSIENT = (TPM_HT)(0x80);
  public const ulong TPM_HT_PERSISTENT = (TPM_HT)(0x81);
}

// Table 27 - TPM_RH Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_RH { uint Value; public static implicit operator TPM_RH(uint value) => new TPM_RH() { Value = value }; public static implicit operator uint(TPM_RH value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong TPM_RH_FIRST = (TPM_RH)(0x40000000);
  public const ulong TPM_RH_SRK = (TPM_RH)(0x40000000);
  public const ulong TPM_RH_OWNER = (TPM_RH)(0x40000001);
  public const ulong TPM_RH_REVOKE = (TPM_RH)(0x40000002);
  public const ulong TPM_RH_TRANSPORT = (TPM_RH)(0x40000003);
  public const ulong TPM_RH_OPERATOR = (TPM_RH)(0x40000004);
  public const ulong TPM_RH_ADMIN = (TPM_RH)(0x40000005);
  public const ulong TPM_RH_EK = (TPM_RH)(0x40000006);
  public const ulong TPM_RH_NULL = (TPM_RH)(0x40000007);
  public const ulong TPM_RH_UNASSIGNED = (TPM_RH)(0x40000008);
  public const ulong TPM_RS_PW = (TPM_RH)(0x40000009);
  public const ulong TPM_RH_LOCKOUT = (TPM_RH)(0x4000000A);
  public const ulong TPM_RH_ENDORSEMENT = (TPM_RH)(0x4000000B);
  public const ulong TPM_RH_PLATFORM = (TPM_RH)(0x4000000C);
  public const ulong TPM_RH_PLATFORM_NV = (TPM_RH)(0x4000000D);
  public const ulong TPM_RH_AUTH_00 = (TPM_RH)(0x40000010);
  public const ulong TPM_RH_AUTH_FF = (TPM_RH)(0x4000010F);
  public const ulong TPM_RH_LAST = (TPM_RH)(0x4000010F);
}

// Table 28 - TPM_HC Constants
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM_HC { TPM_HANDLE Value; public static implicit operator TPM_HC(TPM_HANDLE value) => new TPM_HC() { Value = value }; public static implicit operator TPM_HANDLE(TPM_HC value) => value.Value; }
public unsafe partial class EFI
{
  public const ulong HR_HANDLE_MASK = (TPM_HC)(0x00FFFFFF);
  public const ulong HR_RANGE_MASK = (TPM_HC)(0xFF000000);
  public const ulong HR_SHIFT = (TPM_HC)(24);
  public const ulong HR_PCR = (TPM_HC)((TPM_HC)TPM_HT_PCR << HR_SHIFT);
  public const ulong HR_HMAC_SESSION = (TPM_HC)((TPM_HC)TPM_HT_HMAC_SESSION << HR_SHIFT);
  public const ulong HR_POLICY_SESSION = (TPM_HC)((TPM_HC)TPM_HT_POLICY_SESSION << HR_SHIFT);
  public const ulong HR_TRANSIENT = (TPM_HC)((TPM_HC)TPM_HT_TRANSIENT << HR_SHIFT);
  public const ulong HR_PERSISTENT = (TPM_HC)((TPM_HC)TPM_HT_PERSISTENT << HR_SHIFT);
  public const ulong HR_NV_INDEX = (TPM_HC)((TPM_HC)TPM_HT_NV_INDEX << HR_SHIFT);
  public const ulong HR_PERMANENT = (TPM_HC)((TPM_HC)TPM_HT_PERMANENT << HR_SHIFT);
  public const ulong PCR_FIRST = (TPM_HC)(HR_PCR + 0);
  public const ulong PCR_LAST = (TPM_HC)(PCR_FIRST + IMPLEMENTATION_PCR - 1);
  public const ulong HMAC_SESSION_FIRST = (TPM_HC)(HR_HMAC_SESSION + 0);
  public const ulong HMAC_SESSION_LAST = (TPM_HC)(HMAC_SESSION_FIRST + MAX_ACTIVE_SESSIONS - 1);
  public const ulong LOADED_SESSION_FIRST = (TPM_HC)(HMAC_SESSION_FIRST);
  public const ulong LOADED_SESSION_LAST = (TPM_HC)(HMAC_SESSION_LAST);
  public const ulong POLICY_SESSION_FIRST = (TPM_HC)(HR_POLICY_SESSION + 0);
  public const ulong POLICY_SESSION_LAST = (TPM_HC)(POLICY_SESSION_FIRST + MAX_ACTIVE_SESSIONS - 1);
  public const ulong TRANSIENT_FIRST = (TPM_HC)(HR_TRANSIENT + 0);
  public const ulong ACTIVE_SESSION_FIRST = (TPM_HC)(POLICY_SESSION_FIRST);
  public const ulong ACTIVE_SESSION_LAST = (TPM_HC)(POLICY_SESSION_LAST);
  public const ulong TRANSIENT_LAST = (TPM_HC)(TRANSIENT_FIRST + MAX_LOADED_OBJECTS - 1);
  public const ulong PERSISTENT_FIRST = (TPM_HC)(HR_PERSISTENT + 0);
  public const ulong PERSISTENT_LAST = (TPM_HC)(PERSISTENT_FIRST + 0x00FFFFFF);
  public const ulong PLATFORM_PERSISTENT = (TPM_HC)(PERSISTENT_FIRST + 0x00800000);
  public const ulong NV_INDEX_FIRST = (TPM_HC)(HR_NV_INDEX + 0);
  public const ulong NV_INDEX_LAST = (TPM_HC)(NV_INDEX_FIRST + 0x00FFFFFF);
  public const ulong PERMANENT_FIRST = (TPM_HC)(TPM_RH_FIRST);
  public const ulong PERMANENT_LAST = (TPM_HC)(TPM_RH_LAST);

  // 8 Attribute Structures
}

// Table 29 - TPMA_ALGORITHM Bits
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMA_ALGORITHM
{
  public uint asymmetric = 1;
  public uint symmetric = 1;
  public uint hash = 1;
  public uint object        = 1;
 public uint reserved4_7 = 4;
  public uint signing = 1;
  public uint encrypting = 1;
  public uint method = 1;
  public uint reserved11_31 = 21;
}

// Table 30 - TPMA_OBJECT Bits
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMA_OBJECT
{
  public uint reserved1 = 1;
  public uint fixedTPM = 1;
  public uint stClear = 1;
  public uint reserved4 = 1;
  public uint fixedParent = 1;
  public uint sensitiveDataOrigin = 1;
  public uint userWithAuth = 1;
  public uint adminWithPolicy = 1;
  public uint reserved8_9 = 2;
  public uint noDA = 1;
  public uint encryptedDuplication = 1;
  public uint reserved12_15 = 4;
  public uint restricted = 1;
  public uint decrypt = 1;
  public uint sign = 1;
  public uint reserved19_31 = 13;
}

// Table 31 - TPMA_SESSION Bits
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMA_SESSION
{
  public byte continueSession = 1;
  public byte auditExclusive = 1;
  public byte auditReset = 1;
  public byte reserved3_4 = 2;
  public byte decrypt = 1;
  public byte encrypt = 1;
  public byte audit = 1;
}

// Table 32 - TPMA_LOCALITY Bits
//
// NOTE: Use low case here to resolve conflict
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMA_LOCALITY
{
  public byte locZero = 1;
  public byte locOne = 1;
  public byte locTwo = 1;
  public byte locThree = 1;
  public byte locFour = 1;
  public byte Extended = 3;
}

// Table 33 - TPMA_PERMANENT Bits
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMA_PERMANENT
{
  public uint ownerAuthSet = 1;
  public uint endorsementAuthSet = 1;
  public uint lockoutAuthSet = 1;
  public uint reserved3_7 = 5;
  public uint disableClear = 1;
  public uint inLockout = 1;
  public uint tpmGeneratedEPS = 1;
  public uint reserved11_31 = 21;
}

// Table 34 - TPMA_STARTUP_CLEAR Bits
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMA_STARTUP_CLEAR
{
  public uint phEnable = 1;
  public uint shEnable = 1;
  public uint ehEnable = 1;
  public uint reserved3_30 = 28;
  public uint orderly = 1;
}

// Table 35 - TPMA_MEMORY Bits
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMA_MEMORY
{
  public uint sharedRAM = 1;
  public uint sharedNV = 1;
  public uint objectCopiedToRam = 1;
  public uint reserved3_31 = 29;
}

// Table 36 - TPMA_CC Bits
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMA_CC
{
  public uint commandIndex = 16;
  public uint reserved16_21 = 6;
  public uint nv = 1;
  public uint extensive = 1;
  public uint flushed = 1;
  public uint cHandles = 3;
  public uint rHandle = 1;
  public uint V = 1;
  public uint Res = 2;
}

// 9 Interface Types

// Table 37 - TPMI_YES_NO Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_YES_NO { BYTE Value; public static implicit operator TPMI_YES_NO(BYTE value) => new TPMI_YES_NO() { Value = value }; public static implicit operator BYTE(TPMI_YES_NO value) => value.Value; }

// Table 38 - TPMI_DH_OBJECT Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_DH_OBJECT { TPM_HANDLE Value; public static implicit operator TPMI_DH_OBJECT(TPM_HANDLE value) => new TPMI_DH_OBJECT() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_DH_OBJECT value) => value.Value; }

// Table 39 - TPMI_DH_PERSISTENT Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_DH_PERSISTENT { TPM_HANDLE Value; public static implicit operator TPMI_DH_PERSISTENT(TPM_HANDLE value) => new TPMI_DH_PERSISTENT() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_DH_PERSISTENT value) => value.Value; }

// Table 40 - TPMI_DH_ENTITY Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_DH_ENTITY { TPM_HANDLE Value; public static implicit operator TPMI_DH_ENTITY(TPM_HANDLE value) => new TPMI_DH_ENTITY() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_DH_ENTITY value) => value.Value; }

// Table 41 - TPMI_DH_PCR Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_DH_PCR { TPM_HANDLE Value; public static implicit operator TPMI_DH_PCR(TPM_HANDLE value) => new TPMI_DH_PCR() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_DH_PCR value) => value.Value; }

// Table 42 - TPMI_SH_AUTH_SESSION Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_SH_AUTH_SESSION { TPM_HANDLE Value; public static implicit operator TPMI_SH_AUTH_SESSION(TPM_HANDLE value) => new TPMI_SH_AUTH_SESSION() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_SH_AUTH_SESSION value) => value.Value; }

// Table 43 - TPMI_SH_HMAC Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_SH_HMAC { TPM_HANDLE Value; public static implicit operator TPMI_SH_HMAC(TPM_HANDLE value) => new TPMI_SH_HMAC() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_SH_HMAC value) => value.Value; }

// Table 44 - TPMI_SH_POLICY Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_SH_POLICY { TPM_HANDLE Value; public static implicit operator TPMI_SH_POLICY(TPM_HANDLE value) => new TPMI_SH_POLICY() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_SH_POLICY value) => value.Value; }

// Table 45 - TPMI_DH_CONTEXT Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_DH_CONTEXT { TPM_HANDLE Value; public static implicit operator TPMI_DH_CONTEXT(TPM_HANDLE value) => new TPMI_DH_CONTEXT() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_DH_CONTEXT value) => value.Value; }

// Table 46 - TPMI_RH_HIERARCHY Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RH_HIERARCHY { TPM_HANDLE Value; public static implicit operator TPMI_RH_HIERARCHY(TPM_HANDLE value) => new TPMI_RH_HIERARCHY() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_RH_HIERARCHY value) => value.Value; }

// Table 47 - TPMI_RH_HIERARCHY_AUTH Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RH_HIERARCHY_AUTH { TPM_HANDLE Value; public static implicit operator TPMI_RH_HIERARCHY_AUTH(TPM_HANDLE value) => new TPMI_RH_HIERARCHY_AUTH() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_RH_HIERARCHY_AUTH value) => value.Value; }

// Table 48 - TPMI_RH_PLATFORM Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RH_PLATFORM { TPM_HANDLE Value; public static implicit operator TPMI_RH_PLATFORM(TPM_HANDLE value) => new TPMI_RH_PLATFORM() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_RH_PLATFORM value) => value.Value; }

// Table 49 - TPMI_RH_OWNER Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RH_OWNER { TPM_HANDLE Value; public static implicit operator TPMI_RH_OWNER(TPM_HANDLE value) => new TPMI_RH_OWNER() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_RH_OWNER value) => value.Value; }

// Table 50 - TPMI_RH_ENDORSEMENT Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RH_ENDORSEMENT { TPM_HANDLE Value; public static implicit operator TPMI_RH_ENDORSEMENT(TPM_HANDLE value) => new TPMI_RH_ENDORSEMENT() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_RH_ENDORSEMENT value) => value.Value; }

// Table 51 - TPMI_RH_PROVISION Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RH_PROVISION { TPM_HANDLE Value; public static implicit operator TPMI_RH_PROVISION(TPM_HANDLE value) => new TPMI_RH_PROVISION() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_RH_PROVISION value) => value.Value; }

// Table 52 - TPMI_RH_CLEAR Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RH_CLEAR { TPM_HANDLE Value; public static implicit operator TPMI_RH_CLEAR(TPM_HANDLE value) => new TPMI_RH_CLEAR() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_RH_CLEAR value) => value.Value; }

// Table 53 - TPMI_RH_NV_AUTH Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RH_NV_AUTH { TPM_HANDLE Value; public static implicit operator TPMI_RH_NV_AUTH(TPM_HANDLE value) => new TPMI_RH_NV_AUTH() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_RH_NV_AUTH value) => value.Value; }

// Table 54 - TPMI_RH_LOCKOUT Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RH_LOCKOUT { TPM_HANDLE Value; public static implicit operator TPMI_RH_LOCKOUT(TPM_HANDLE value) => new TPMI_RH_LOCKOUT() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_RH_LOCKOUT value) => value.Value; }

// Table 55 - TPMI_RH_NV_INDEX Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RH_NV_INDEX { TPM_HANDLE Value; public static implicit operator TPMI_RH_NV_INDEX(TPM_HANDLE value) => new TPMI_RH_NV_INDEX() { Value = value }; public static implicit operator TPM_HANDLE(TPMI_RH_NV_INDEX value) => value.Value; }

// Table 56 - TPMI_ALG_HASH Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_HASH { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_HASH(TPM_ALG_ID value) => new TPMI_ALG_HASH() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_HASH value) => value.Value; }

// Table 57 - TPMI_ALG_ASYM Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_ASYM { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_ASYM(TPM_ALG_ID value) => new TPMI_ALG_ASYM() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_ASYM value) => value.Value; }

// Table 58 - TPMI_ALG_SYM Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_SYM { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_SYM(TPM_ALG_ID value) => new TPMI_ALG_SYM() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_SYM value) => value.Value; }

// Table 59 - TPMI_ALG_SYM_OBJECT Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_SYM_OBJECT { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_SYM_OBJECT(TPM_ALG_ID value) => new TPMI_ALG_SYM_OBJECT() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_SYM_OBJECT value) => value.Value; }

// Table 60 - TPMI_ALG_SYM_MODE Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_SYM_MODE { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_SYM_MODE(TPM_ALG_ID value) => new TPMI_ALG_SYM_MODE() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_SYM_MODE value) => value.Value; }

// Table 61 - TPMI_ALG_KDF Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_KDF { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_KDF(TPM_ALG_ID value) => new TPMI_ALG_KDF() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_KDF value) => value.Value; }

// Table 62 - TPMI_ALG_SIG_SCHEME Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_SIG_SCHEME { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_SIG_SCHEME(TPM_ALG_ID value) => new TPMI_ALG_SIG_SCHEME() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_SIG_SCHEME value) => value.Value; }

// Table 63 - TPMI_ECC_KEY_EXCHANGE Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ECC_KEY_EXCHANGE { TPM_ALG_ID Value; public static implicit operator TPMI_ECC_KEY_EXCHANGE(TPM_ALG_ID value) => new TPMI_ECC_KEY_EXCHANGE() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ECC_KEY_EXCHANGE value) => value.Value; }

// Table 64 - TPMI_ST_COMMAND_TAG Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ST_COMMAND_TAG { TPM_ST Value; public static implicit operator TPMI_ST_COMMAND_TAG(TPM_ST value) => new TPMI_ST_COMMAND_TAG() { Value = value }; public static implicit operator TPM_ST(TPMI_ST_COMMAND_TAG value) => value.Value; }

// 10 Structure Definitions

// Table 65 - TPMS_ALGORITHM_DESCRIPTION Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_ALGORITHM_DESCRIPTION
{
  TPM_ALG_ID alg;
  TPMA_ALGORITHM attributes;
}

// Table 66 - TPMU_HA Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_HA
{
  [FieldOffset(0)] public fixed BYTE sha1[SHA1_DIGEST_SIZE];
  [FieldOffset(0)] public fixed BYTE sha256[SHA256_DIGEST_SIZE];
  [FieldOffset(0)] public fixed BYTE sm3_256[SM3_256_DIGEST_SIZE];
  [FieldOffset(0)] public fixed BYTE sha384[SHA384_DIGEST_SIZE];
  [FieldOffset(0)] public fixed BYTE sha512[SHA512_DIGEST_SIZE];
}

// Table 67 - TPMT_HA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_HA
{
  TPMI_ALG_HASH hashAlg;
  TPMU_HA digest;
}

// Table 68 - TPM2B_DIGEST Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_DIGEST
{
  public ushort size;
  public BYTEpublic public public buffer[sizeof(TPMU_HA)];
}

// Table 69 - TPM2B_DATA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_DATA
{
  public ushort size;
  public BYTEpublic public public buffer[sizeof(TPMT_HA)];
}

// Table 70 - TPM2B_NONCE Types
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_NONCE { TPM2B_DIGEST Value; public static implicit operator TPM2B_NONCE(TPM2B_DIGEST value) => new TPM2B_NONCE() { Value = value }; public static implicit operator TPM2B_DIGEST(TPM2B_NONCE value) => value.Value; }

// Table 71 - TPM2B_AUTH Types
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_AUTH { TPM2B_DIGEST Value; public static implicit operator TPM2B_AUTH(TPM2B_DIGEST value) => new TPM2B_AUTH() { Value = value }; public static implicit operator TPM2B_DIGEST(TPM2B_AUTH value) => value.Value; }

// Table 72 - TPM2B_OPERAND Types
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_OPERAND { TPM2B_DIGEST Value; public static implicit operator TPM2B_OPERAND(TPM2B_DIGEST value) => new TPM2B_OPERAND() { Value = value }; public static implicit operator TPM2B_DIGEST(TPM2B_OPERAND value) => value.Value; }

// Table 73 - TPM2B_EVENT Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_EVENT
{
  public ushort size;
  public fixed BYTE buffer[1024];
}

// Table 74 - TPM2B_MAX_BUFFER Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_MAX_BUFFER
{
  public ushort size;
  public fixed BYTE buffer[MAX_DIGEST_BUFFER];
}

// Table 75 - TPM2B_MAX_NV_BUFFER Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_MAX_NV_BUFFER
{
  public ushort size;
  public fixed BYTE buffer[MAX_NV_INDEX_SIZE];
}

// Table 76 - TPM2B_TIMEOUT Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_TIMEOUT
{
  public ushort size;
  public BYTEpublic public public buffer[sizeof(ulong)];
}

// Table 77 -- TPM2B_IV Structure <I/O>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_IV
{
  public ushort size;
  public fixed BYTE buffer[MAX_SYM_BLOCK_SIZE];
}

// Table 78 - TPMU_NAME Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_NAME
{
  TPMT_HA digest;
  TPM_HANDLE handle;
}

// Table 79 - TPM2B_NAME Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_NAME
{
  public ushort size;
  public BYTEpublic public public name[sizeof(TPMU_NAME)];
}

// Table 80 - TPMS_PCR_SELECT Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_PCR_SELECT
{
  public byte sizeofSelect;
  public fixed BYTE pcrSelect[PCR_SELECT_MAX];
}

// Table 81 - TPMS_PCR_SELECTION Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_PCR_SELECTION
{
  TPMI_ALG_HASH hash;
  public byte sizeofSelect;
  public fixed BYTE pcrSelect[PCR_SELECT_MAX];
}

// Table 84 - TPMT_TK_CREATION Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_TK_CREATION
{
  TPM_ST tag;
  TPMI_RH_HIERARCHY hierarchy;
  TPM2B_DIGEST digest;
}

// Table 85 - TPMT_TK_VERIFIED Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_TK_VERIFIED
{
  TPM_ST tag;
  TPMI_RH_HIERARCHY hierarchy;
  TPM2B_DIGEST digest;
}

// Table 86 - TPMT_TK_AUTH Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_TK_AUTH
{
  TPM_ST tag;
  TPMI_RH_HIERARCHY hierarchy;
  TPM2B_DIGEST digest;
}

// Table 87 - TPMT_TK_HASHCHECK Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_TK_HASHCHECK
{
  TPM_ST tag;
  TPMI_RH_HIERARCHY hierarchy;
  TPM2B_DIGEST digest;
}

// Table 88 - TPMS_ALG_PROPERTY Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_ALG_PROPERTY
{
  TPM_ALG_ID alg;
  TPMA_ALGORITHM algProperties;
}

// Table 89 - TPMS_TAGGED_PROPERTY Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_TAGGED_PROPERTY
{
  TPM_PT property;
  public uint value;
}

// Table 90 - TPMS_TAGGED_PCR_SELECT Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_TAGGED_PCR_SELECT
{
  TPM_PT tag;
  public byte sizeofSelect;
  public fixed BYTE pcrSelect[PCR_SELECT_MAX];
}

// Table 91 - TPML_CC Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_CC
{
  public uint count;
  TPM_CC commandCodes[MAX_CAP_CC];
}

// Table 92 - TPML_CCA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_CCA
{
  public uint count;
  TPMA_CC commandAttributes[MAX_CAP_CC];
}

// Table 93 - TPML_ALG Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_ALG
{
  public uint count;
  TPM_ALG_ID algorithms[MAX_ALG_LIST_SIZE];
}

// Table 94 - TPML_HANDLE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_HANDLE
{
  public uint count;
  TPM_HANDLE handle[MAX_CAP_HANDLES];
}

// Table 95 - TPML_DIGEST Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_DIGEST
{
  public uint count;
  TPM2B_DIGEST digests[8];
}

// Table 96 -- TPML_DIGEST_VALUES Structure <I/O>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_DIGEST_VALUES
{
  public uint count;
  TPMT_HA digests[HASH_COUNT];
}

// Table 97 - TPM2B_DIGEST_VALUES Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_DIGEST_VALUES
{
  public ushort size;
  public BYTEpublic public public buffer[sizeof(TPML_DIGEST_VALUES)];
}

// Table 98 - TPML_PCR_SELECTION Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_PCR_SELECTION
{
  public uint count;
  TPMS_PCR_SELECTION pcrSelections[HASH_COUNT];
}

// Table 99 - TPML_ALG_PROPERTY Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_ALG_PROPERTY
{
  public uint count;
  TPMS_ALG_PROPERTY algProperties[MAX_CAP_ALGS];
}

// Table 100 - TPML_TAGGED_TPM_PROPERTY Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_TAGGED_TPM_PROPERTY
{
  public uint count;
  TPMS_TAGGED_PROPERTY tpmProperty[MAX_TPM_PROPERTIES];
}

// Table 101 - TPML_TAGGED_PCR_PROPERTY Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_TAGGED_PCR_PROPERTY
{
  public uint count;
  TPMS_TAGGED_PCR_SELECT pcrProperty[MAX_PCR_PROPERTIES];
}

// Table 102 - TPML_ECC_CURVE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPML_ECC_CURVE
{
  public uint count;
  TPM_ECC_CURVE eccCurves[MAX_ECC_CURVES];
}

// Table 103 - TPMU_CAPABILITIES Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_CAPABILITIES
{
  TPML_ALG_PROPERTY algorithms;
  TPML_HANDLE handles;
  TPML_CCA command;
  TPML_CC ppCommands;
  TPML_CC auditCommands;
  TPML_PCR_SELECTION assignedPCR;
  TPML_TAGGED_TPM_PROPERTY tpmProperties;
  TPML_TAGGED_PCR_PROPERTY pcrProperties;
  TPML_ECC_CURVE eccCurves;
}

// Table 104 - TPMS_CAPABILITY_DATA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_CAPABILITY_DATA
{
  TPM_CAP capability;
  TPMU_CAPABILITIES data;
}

// Table 105 - TPMS_CLOCK_INFO Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_CLOCK_INFO
{
  public ulong clock;
  public uint resetCount;
  public uint restartCount;
  TPMI_YES_NO safe;
}

// Table 106 - TPMS_TIME_INFO Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_TIME_INFO
{
  public ulong time;
  TPMS_CLOCK_INFO clockInfo;
}

// Table 107 - TPMS_TIME_ATTEST_INFO Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_TIME_ATTEST_INFO
{
  TPMS_TIME_INFO time;
  public ulong firmwareVersion;
}

// Table 108 - TPMS_CERTIFY_INFO Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_CERTIFY_INFO
{
  TPM2B_NAME name;
  TPM2B_NAME qualifiedName;
}

// Table 109 - TPMS_QUOTE_INFO Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_QUOTE_INFO
{
  TPML_PCR_SELECTION pcrSelect;
  TPM2B_DIGEST pcrDigest;
}

// Table 110 - TPMS_COMMAND_AUDIT_INFO Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_COMMAND_AUDIT_INFO
{
  public ulong auditCounter;
  TPM_ALG_ID digestAlg;
  TPM2B_DIGEST auditDigest;
  TPM2B_DIGEST commandDigest;
}

// Table 111 - TPMS_SESSION_AUDIT_INFO Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SESSION_AUDIT_INFO
{
  TPMI_YES_NO exclusiveSession;
  TPM2B_DIGEST sessionDigest;
}

// Table 112 - TPMS_CREATION_INFO Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_CREATION_INFO
{
  TPM2B_NAME objectName;
  TPM2B_DIGEST creationHash;
}

// Table 113 - TPMS_NV_CERTIFY_INFO Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_NV_CERTIFY_INFO
{
  TPM2B_NAME indexName;
  public ushort offset;
  TPM2B_MAX_NV_BUFFER nvContents;
}

// Table 114 - TPMI_ST_ATTEST Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ST_ATTEST { TPM_ST Value; public static implicit operator TPMI_ST_ATTEST(TPM_ST value) => new TPMI_ST_ATTEST() { Value = value }; public static implicit operator TPM_ST(TPMI_ST_ATTEST value) => value.Value; }

// Table 115 - TPMU_ATTEST Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_ATTEST
{
  TPMS_CERTIFY_INFO certify;
  TPMS_CREATION_INFO creation;
  TPMS_QUOTE_INFO quote;
  TPMS_COMMAND_AUDIT_INFO commandAudit;
  TPMS_SESSION_AUDIT_INFO sessionAudit;
  TPMS_TIME_ATTEST_INFO time;
  TPMS_NV_CERTIFY_INFO nv;
}

// Table 116 - TPMS_ATTEST Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_ATTEST
{
  TPM_GENERATED magic;
  TPMI_ST_ATTEST type;
  TPM2B_NAME qualifiedSigner;
  TPM2B_DATA extraData;
  TPMS_CLOCK_INFO clockInfo;
  public ulong firmwareVersion;
  TPMU_ATTEST attested;
}

// Table 117 - TPM2B_ATTEST Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_ATTEST
{
  public ushort size;
  public BYTEpublic public public attestationData[sizeof(TPMS_ATTEST)];
}

// Table 118 - TPMS_AUTH_COMMAND Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_AUTH_COMMAND
{
  TPMI_SH_AUTH_SESSION sessionHandle;
  TPM2B_NONCE nonce;
  TPMA_SESSION sessionAttributes;
  TPM2B_AUTH hmac;
}

// Table 119 - TPMS_AUTH_RESPONSE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_AUTH_RESPONSE
{
  TPM2B_NONCE nonce;
  TPMA_SESSION sessionAttributes;
  TPM2B_AUTH hmac;
}

// 11 Algorithm Parameters and Structures

// Table 120 - TPMI_AES_KEY_BITS Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_AES_KEY_BITS { TPM_KEY_BITS Value; public static implicit operator TPMI_AES_KEY_BITS(TPM_KEY_BITS value) => new TPMI_AES_KEY_BITS() { Value = value }; public static implicit operator TPM_KEY_BITS(TPMI_AES_KEY_BITS value) => value.Value; }

// Table 121 - TPMI_SM4_KEY_BITS Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_SM4_KEY_BITS { TPM_KEY_BITS Value; public static implicit operator TPMI_SM4_KEY_BITS(TPM_KEY_BITS value) => new TPMI_SM4_KEY_BITS() { Value = value }; public static implicit operator TPM_KEY_BITS(TPMI_SM4_KEY_BITS value) => value.Value; }

// Table 122 - TPMU_SYM_KEY_BITS Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_SYM_KEY_BITS
{
  TPMI_AES_KEY_BITS aes;
  TPMI_SM4_KEY_BITS SM4;
  TPM_KEY_BITS sym;
  TPMI_ALG_HASH xor;
}

// Table 123 - TPMU_SYM_MODE Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_SYM_MODE
{
  TPMI_ALG_SYM_MODE aes;
  TPMI_ALG_SYM_MODE SM4;
  TPMI_ALG_SYM_MODE sym;
}

// Table 125 - TPMT_SYM_DEF Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_SYM_DEF
{
  TPMI_ALG_SYM algorithm;
  TPMU_SYM_KEY_BITS keyBits;
  TPMU_SYM_MODE mode;
}

// Table 126 - TPMT_SYM_DEF_OBJECT Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_SYM_DEF_OBJECT
{
  TPMI_ALG_SYM_OBJECT algorithm;
  TPMU_SYM_KEY_BITS keyBits;
  TPMU_SYM_MODE mode;
}

// Table 127 - TPM2B_SYM_KEY Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_SYM_KEY
{
  public ushort size;
  public fixed BYTE buffer[MAX_SYM_KEY_BYTES];
}

// Table 128 - TPMS_SYMCIPHER_PARMS Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SYMCIPHER_PARMS
{
  TPMT_SYM_DEF_OBJECT sym;
}

// Table 129 - TPM2B_SENSITIVE_DATA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_SENSITIVE_DATA
{
  public ushort size;
  public fixed BYTE buffer[MAX_SYM_DATA];
}

// Table 130 - TPMS_SENSITIVE_CREATE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SENSITIVE_CREATE
{
  TPM2B_AUTH userAuth;
  TPM2B_SENSITIVE_DATA data;
}

// Table 131 - TPM2B_SENSITIVE_CREATE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_SENSITIVE_CREATE
{
  public ushort size;
  TPMS_SENSITIVE_CREATE sensitive;
}

// Table 132 - TPMS_SCHEME_SIGHASH Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_SIGHASH
{
  TPMI_ALG_HASH hashAlg;
}

// Table 133 - TPMI_ALG_KEYEDHASH_SCHEME Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_KEYEDHASH_SCHEME { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_KEYEDHASH_SCHEME(TPM_ALG_ID value) => new TPMI_ALG_KEYEDHASH_SCHEME() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_KEYEDHASH_SCHEME value) => value.Value; }

// Table 134 - HMAC_SIG_SCHEME Types
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_HMAC { TPMS_SCHEME_SIGHASH Value; public static implicit operator TPMS_SCHEME_HMAC(TPMS_SCHEME_SIGHASH value) => new TPMS_SCHEME_HMAC() { Value = value }; public static implicit operator TPMS_SCHEME_SIGHASH(TPMS_SCHEME_HMAC value) => value.Value; }

// Table 135 - TPMS_SCHEME_XOR Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_XOR
{
  TPMI_ALG_HASH hashAlg;
  TPMI_ALG_KDF kdf;
}

// Table 136 - TPMU_SCHEME_KEYEDHASH Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_SCHEME_KEYEDHASH
{
  TPMS_SCHEME_HMAC hmac;
  TPMS_SCHEME_XOR xor;
}

// Table 137 - TPMT_KEYEDHASH_SCHEME Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_KEYEDHASH_SCHEME
{
  TPMI_ALG_KEYEDHASH_SCHEME scheme;
  TPMU_SCHEME_KEYEDHASH details;
}

// Table 138 - RSA_SIG_SCHEMES Types
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_RSASSA { TPMS_SCHEME_SIGHASH Value; public static implicit operator TPMS_SCHEME_RSASSA(TPMS_SCHEME_SIGHASH value) => new TPMS_SCHEME_RSASSA() { Value = value }; public static implicit operator TPMS_SCHEME_SIGHASH(TPMS_SCHEME_RSASSA value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_RSAPSS { TPMS_SCHEME_SIGHASH Value; public static implicit operator TPMS_SCHEME_RSAPSS(TPMS_SCHEME_SIGHASH value) => new TPMS_SCHEME_RSAPSS() { Value = value }; public static implicit operator TPMS_SCHEME_SIGHASH(TPMS_SCHEME_RSAPSS value) => value.Value; }

// Table 139 - ECC_SIG_SCHEMES Types
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_ECDSA { TPMS_SCHEME_SIGHASH Value; public static implicit operator TPMS_SCHEME_ECDSA(TPMS_SCHEME_SIGHASH value) => new TPMS_SCHEME_ECDSA() { Value = value }; public static implicit operator TPMS_SCHEME_SIGHASH(TPMS_SCHEME_ECDSA value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_SM2 { TPMS_SCHEME_SIGHASH Value; public static implicit operator TPMS_SCHEME_SM2(TPMS_SCHEME_SIGHASH value) => new TPMS_SCHEME_SM2() { Value = value }; public static implicit operator TPMS_SCHEME_SIGHASH(TPMS_SCHEME_SM2 value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_ECSCHNORR { TPMS_SCHEME_SIGHASH Value; public static implicit operator TPMS_SCHEME_ECSCHNORR(TPMS_SCHEME_SIGHASH value) => new TPMS_SCHEME_ECSCHNORR() { Value = value }; public static implicit operator TPMS_SCHEME_SIGHASH(TPMS_SCHEME_ECSCHNORR value) => value.Value; }

// Table 140 - TPMS_SCHEME_ECDAA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_ECDAA
{
  TPMI_ALG_HASH hashAlg;
  public ushort count;
}

// Table 141 - TPMU_SIG_SCHEME Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_SIG_SCHEME
{
  TPMS_SCHEME_RSASSA rsassa;
  TPMS_SCHEME_RSAPSS rsapss;
  TPMS_SCHEME_ECDSA ecdsa;
  TPMS_SCHEME_ECDAA ecdaa;
  TPMS_SCHEME_ECSCHNORR ecSchnorr;
  TPMS_SCHEME_HMAC hmac;
  TPMS_SCHEME_SIGHASH any;
}

// Table 142 - TPMT_SIG_SCHEME Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_SIG_SCHEME
{
  TPMI_ALG_SIG_SCHEME scheme;
  TPMU_SIG_SCHEME details;
}

// Table 143 - TPMS_SCHEME_OAEP Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_OAEP
{
  TPMI_ALG_HASH hashAlg;
}

// Table 144 - TPMS_SCHEME_ECDH Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_ECDH
{
  TPMI_ALG_HASH hashAlg;
}

// Table 145 - TPMS_SCHEME_MGF1 Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_MGF1
{
  TPMI_ALG_HASH hashAlg;
}

// Table 146 - TPMS_SCHEME_KDF1_SP800_56a Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_KDF1_SP800_56a
{
  TPMI_ALG_HASH hashAlg;
}

// Table 147 - TPMS_SCHEME_KDF2 Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_KDF2
{
  TPMI_ALG_HASH hashAlg;
}

// Table 148 - TPMS_SCHEME_KDF1_SP800_108 Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SCHEME_KDF1_SP800_108
{
  TPMI_ALG_HASH hashAlg;
}

// Table 149 - TPMU_KDF_SCHEME Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_KDF_SCHEME
{
  TPMS_SCHEME_MGF1 mgf1;
  TPMS_SCHEME_KDF1_SP800_56a kdf1_SP800_56a;
  TPMS_SCHEME_KDF2 kdf2;
  TPMS_SCHEME_KDF1_SP800_108 kdf1_sp800_108;
}

// Table 150 - TPMT_KDF_SCHEME Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_KDF_SCHEME
{
  TPMI_ALG_KDF scheme;
  TPMU_KDF_SCHEME details;
}

// Table 151 - TPMI_ALG_ASYM_SCHEME Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_ASYM_SCHEME { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_ASYM_SCHEME(TPM_ALG_ID value) => new TPMI_ALG_ASYM_SCHEME() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_ASYM_SCHEME value) => value.Value; }

// Table 152 - TPMU_ASYM_SCHEME Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_ASYM_SCHEME
{
  TPMS_SCHEME_RSASSA rsassa;
  TPMS_SCHEME_RSAPSS rsapss;
  TPMS_SCHEME_OAEP oaep;
  TPMS_SCHEME_ECDSA ecdsa;
  TPMS_SCHEME_ECDAA ecdaa;
  TPMS_SCHEME_ECSCHNORR ecSchnorr;
  TPMS_SCHEME_SIGHASH anySig;
}

// Table 153 - TPMT_ASYM_SCHEME Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_ASYM_SCHEME
{
  TPMI_ALG_ASYM_SCHEME scheme;
  TPMU_ASYM_SCHEME details;
}

// Table 154 - TPMI_ALG_RSA_SCHEME Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_RSA_SCHEME { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_RSA_SCHEME(TPM_ALG_ID value) => new TPMI_ALG_RSA_SCHEME() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_RSA_SCHEME value) => value.Value; }

// Table 155 - TPMT_RSA_SCHEME Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_RSA_SCHEME
{
  TPMI_ALG_RSA_SCHEME scheme;
  TPMU_ASYM_SCHEME details;
}

// Table 156 - TPMI_ALG_RSA_DECRYPT Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_RSA_DECRYPT { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_RSA_DECRYPT(TPM_ALG_ID value) => new TPMI_ALG_RSA_DECRYPT() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_RSA_DECRYPT value) => value.Value; }

// Table 157 - TPMT_RSA_DECRYPT Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_RSA_DECRYPT
{
  TPMI_ALG_RSA_DECRYPT scheme;
  TPMU_ASYM_SCHEME details;
}

// Table 158 - TPM2B_PUBLIC_KEY_RSA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_PUBLIC_KEY_RSA
{
  public ushort size;
  public fixed BYTE buffer[MAX_RSA_KEY_BYTES];
}

// Table 159 - TPMI_RSA_KEY_BITS Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_RSA_KEY_BITS { TPM_KEY_BITS Value; public static implicit operator TPMI_RSA_KEY_BITS(TPM_KEY_BITS value) => new TPMI_RSA_KEY_BITS() { Value = value }; public static implicit operator TPM_KEY_BITS(TPMI_RSA_KEY_BITS value) => value.Value; }

// Table 160 - TPM2B_PRIVATE_KEY_RSA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_PRIVATE_KEY_RSA
{
  public ushort size;
  public BYTEpublic public public buffer[MAX_RSA_KEY_BYTES / 2];
}

// Table 161 - TPM2B_ECC_PARAMETER Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_ECC_PARAMETER
{
  public ushort size;
  public fixed BYTE buffer[MAX_ECC_KEY_BYTES];
}

// Table 162 - TPMS_ECC_POINT Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_ECC_POINT
{
  TPM2B_ECC_PARAMETER x;
  TPM2B_ECC_PARAMETER y;
}

// Table 163 -- TPM2B_ECC_POINT Structure <I/O>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_ECC_POINT
{
  public ushort size;
  TPMS_ECC_POINT point;
}

// Table 164 - TPMI_ALG_ECC_SCHEME Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_ECC_SCHEME { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_ECC_SCHEME(TPM_ALG_ID value) => new TPMI_ALG_ECC_SCHEME() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_ECC_SCHEME value) => value.Value; }

// Table 165 - TPMI_ECC_CURVE Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ECC_CURVE { TPM_ECC_CURVE Value; public static implicit operator TPMI_ECC_CURVE(TPM_ECC_CURVE value) => new TPMI_ECC_CURVE() { Value = value }; public static implicit operator TPM_ECC_CURVE(TPMI_ECC_CURVE value) => value.Value; }

// Table 166 - TPMT_ECC_SCHEME Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_ECC_SCHEME
{
  TPMI_ALG_ECC_SCHEME scheme;
  TPMU_SIG_SCHEME details;
}

// Table 167 - TPMS_ALGORITHM_DETAIL_ECC Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_ALGORITHM_DETAIL_ECC
{
  TPM_ECC_CURVE curveID;
  public ushort keySize;
  TPMT_KDF_SCHEME kdf;
  TPMT_ECC_SCHEME sign;
  TPM2B_ECC_PARAMETER p;
  TPM2B_ECC_PARAMETER a;
  TPM2B_ECC_PARAMETER b;
  TPM2B_ECC_PARAMETER gX;
  TPM2B_ECC_PARAMETER gY;
  TPM2B_ECC_PARAMETER n;
  TPM2B_ECC_PARAMETER h;
}

// Table 168 - TPMS_SIGNATURE_RSASSA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SIGNATURE_RSASSA
{
  TPMI_ALG_HASH hash;
  TPM2B_PUBLIC_KEY_RSA sig;
}

// Table 169 - TPMS_SIGNATURE_RSAPSS Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SIGNATURE_RSAPSS
{
  TPMI_ALG_HASH hash;
  TPM2B_PUBLIC_KEY_RSA sig;
}

// Table 170 - TPMS_SIGNATURE_ECDSA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_SIGNATURE_ECDSA
{
  TPMI_ALG_HASH hash;
  TPM2B_ECC_PARAMETER signatureR;
  TPM2B_ECC_PARAMETER signatureS;
}

// Table 171 - TPMU_SIGNATURE Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_SIGNATURE
{
  TPMS_SIGNATURE_RSASSA rsassa;
  TPMS_SIGNATURE_RSAPSS rsapss;
  TPMS_SIGNATURE_ECDSA ecdsa;
  TPMS_SIGNATURE_ECDSA sm2;
  TPMS_SIGNATURE_ECDSA ecdaa;
  TPMS_SIGNATURE_ECDSA ecschnorr;
  TPMT_HA hmac;
  TPMS_SCHEME_SIGHASH any;
}

// Table 172 - TPMT_SIGNATURE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_SIGNATURE
{
  TPMI_ALG_SIG_SCHEME sigAlg;
  TPMU_SIGNATURE signature;
}

// Table 173 - TPMU_ENCRYPTED_SECRET Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_ENCRYPTED_SECRET
{
  [FieldOffset(0)] public BYTE[FieldOffset(0)] public  [FieldOffset(0)] public ecc[sizeof(TPMS_ECC_POINT)];
 [FieldOffset(0)] public fixed BYTE rsa[MAX_RSA_KEY_BYTES];
  [FieldOffset(0)] public BYTE[FieldOffset(0)] public  [FieldOffset(0)] public symmetric[sizeof(TPM2B_DIGEST)];
[FieldOffset(0)] public BYTE[FieldOffset(0)] public  [FieldOffset(0)] public keyedHash[sizeof(TPM2B_DIGEST)];
}

// Table 174 - TPM2B_ENCRYPTED_SECRET Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_ENCRYPTED_SECRET
{
  public ushort size;
  public BYTEpublic public public secret[sizeof(TPMU_ENCRYPTED_SECRET)];
}

// 12 Key/Object Complex

// Table 175 - TPMI_ALG_PUBLIC Type
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMI_ALG_PUBLIC { TPM_ALG_ID Value; public static implicit operator TPMI_ALG_PUBLIC(TPM_ALG_ID value) => new TPMI_ALG_PUBLIC() { Value = value }; public static implicit operator TPM_ALG_ID(TPMI_ALG_PUBLIC value) => value.Value; }

// Table 176 - TPMU_PUBLIC_ID Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_PUBLIC_ID
{
  TPM2B_DIGEST keyedHash;
  TPM2B_DIGEST sym;
  TPM2B_PUBLIC_KEY_RSA rsa;
  TPMS_ECC_POINT ecc;
}

// Table 177 - TPMS_KEYEDHASH_PARMS Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_KEYEDHASH_PARMS
{
  TPMT_KEYEDHASH_SCHEME scheme;
}

// Table 178 - TPMS_ASYM_PARMS Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_ASYM_PARMS
{
  TPMT_SYM_DEF_OBJECT symmetric;
  TPMT_ASYM_SCHEME scheme;
}

// Table 179 - TPMS_RSA_PARMS Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_RSA_PARMS
{
  TPMT_SYM_DEF_OBJECT symmetric;
  TPMT_RSA_SCHEME scheme;
  TPMI_RSA_KEY_BITS keyBits;
  public uint exponent;
}

// Table 180 - TPMS_ECC_PARMS Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_ECC_PARMS
{
  TPMT_SYM_DEF_OBJECT symmetric;
  TPMT_ECC_SCHEME scheme;
  TPMI_ECC_CURVE curveID;
  TPMT_KDF_SCHEME kdf;
}

// Table 181 - TPMU_PUBLIC_PARMS Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_PUBLIC_PARMS
{
  TPMS_KEYEDHASH_PARMS keyedHashDetail;
  TPMT_SYM_DEF_OBJECT symDetail;
  TPMS_RSA_PARMS rsaDetail;
  TPMS_ECC_PARMS eccDetail;
  TPMS_ASYM_PARMS asymDetail;
}

// Table 182 - TPMT_PUBLIC_PARMS Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_PUBLIC_PARMS
{
  TPMI_ALG_PUBLIC type;
  TPMU_PUBLIC_PARMS parameters;
}

// Table 183 - TPMT_PUBLIC Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_PUBLIC
{
  TPMI_ALG_PUBLIC type;
  TPMI_ALG_HASH nameAlg;
  TPMA_OBJECT objectAttributes;
  TPM2B_DIGEST authPolicy;
  TPMU_PUBLIC_PARMS parameters;
  TPMU_PUBLIC_ID unique;
}

// Table 184 - TPM2B_PUBLIC Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_PUBLIC
{
  public ushort size;
  TPMT_PUBLIC publicArea;
}

// Table 185 - TPM2B_PRIVATE_VENDOR_SPECIFIC Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_PRIVATE_VENDOR_SPECIFIC
{
  public ushort size;
  public fixed BYTE buffer[PRIVATE_VENDOR_SPECIFIC_BYTES];
}

// Table 186 - TPMU_SENSITIVE_COMPOSITE Union
[StructLayout(LayoutKind.Explicit)]
public unsafe struct TPMU_SENSITIVE_COMPOSITE
{
  TPM2B_PRIVATE_KEY_RSA rsa;
  TPM2B_ECC_PARAMETER ecc;
  TPM2B_SENSITIVE_DATA bits;
  TPM2B_SYM_KEY sym;
  TPM2B_PRIVATE_VENDOR_SPECIFIC any;
}

// Table 187 - TPMT_SENSITIVE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMT_SENSITIVE
{
  TPMI_ALG_PUBLIC sensitiveType;
  TPM2B_AUTH authValue;
  TPM2B_DIGEST seedValue;
  TPMU_SENSITIVE_COMPOSITE sensitive;
}

// Table 188 - TPM2B_SENSITIVE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_SENSITIVE
{
  public ushort size;
  TPMT_SENSITIVE sensitiveArea;
}

// Table 189 - _PRIVATE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct _PRIVATE
{
  TPM2B_DIGEST integrityOuter;
  TPM2B_DIGEST integrityInner;
  TPMT_SENSITIVE sensitive;
}

// Table 190 - TPM2B_PRIVATE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_PRIVATE
{
  public ushort size;
  public BYTEpublic public public buffer[sizeof(_PRIVATE)];
}

// Table 191 - _ID_OBJECT Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct _ID_OBJECT
{
  TPM2B_DIGEST integrityHMAC;
  TPM2B_DIGEST encIdentity;
}

// Table 192 - TPM2B_ID_OBJECT Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_ID_OBJECT
{
  public ushort size;
  public BYTEpublic public public credential[sizeof(_ID_OBJECT)];
}

// 13 NV Storage Structures

// Table 193 - TPM_NV_INDEX Bits
//
// NOTE: Comment here to resolve conflict
//
// typedef struct {
//  uint index : 22;
//  uint space : 2;
//  uint RH_NV : 8;
// } TPM_NV_INDEX;

// Table 195 - TPMA_NV Bits
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMA_NV
{
  public uint TPMA_NV_PPWRITE = 1;
  public uint TPMA_NV_OWNERWRITE = 1;
  public uint TPMA_NV_AUTHWRITE = 1;
  public uint TPMA_NV_POLICYWRITE = 1;
  public uint TPMA_NV_COUNTER = 1;
  public uint TPMA_NV_BITS = 1;
  public uint TPMA_NV_EXTEND = 1;
  public uint reserved7_9 = 3;
  public uint TPMA_NV_POLICY_DELETE = 1;
  public uint TPMA_NV_WRITELOCKED = 1;
  public uint TPMA_NV_WRITEALL = 1;
  public uint TPMA_NV_WRITEDEFINE = 1;
  public uint TPMA_NV_WRITE_STCLEAR = 1;
  public uint TPMA_NV_GLOBALLOCK = 1;
  public uint TPMA_NV_PPREAD = 1;
  public uint TPMA_NV_OWNERREAD = 1;
  public uint TPMA_NV_AUTHREAD = 1;
  public uint TPMA_NV_POLICYREAD = 1;
  public uint reserved20_24 = 5;
  public uint TPMA_NV_NO_DA = 1;
  public uint TPMA_NV_ORDERLY = 1;
  public uint TPMA_NV_CLEAR_STCLEAR = 1;
  public uint TPMA_NV_READLOCKED = 1;
  public uint TPMA_NV_WRITTEN = 1;
  public uint TPMA_NV_PLATFORMCREATE = 1;
  public uint TPMA_NV_READ_STCLEAR = 1;
}

// Table 196 - TPMS_NV_PUBLIC Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_NV_PUBLIC
{
  TPMI_RH_NV_INDEX nvIndex;
  TPMI_ALG_HASH nameAlg;
  TPMA_NV attributes;
  TPM2B_DIGEST authPolicy;
  public ushort dataSize;
}

// Table 197 - TPM2B_NV_PUBLIC Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_NV_PUBLIC
{
  public ushort size;
  TPMS_NV_PUBLIC nvPublic;
}

// 14 Context Data

// Table 198 - TPM2B_CONTEXT_SENSITIVE Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_CONTEXT_SENSITIVE
{
  public ushort size;
  public fixed BYTE buffer[MAX_CONTEXT_SIZE];
}

// Table 199 - TPMS_CONTEXT_DATA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_CONTEXT_DATA
{
  TPM2B_DIGEST integrity;
  TPM2B_CONTEXT_SENSITIVE encrypted;
}

// Table 200 - TPM2B_CONTEXT_DATA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_CONTEXT_DATA
{
  public ushort size;
  public BYTEpublic public public buffer[sizeof(TPMS_CONTEXT_DATA)];
}

// Table 201 - TPMS_CONTEXT Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_CONTEXT
{
  public ulong sequence;
  TPMI_DH_CONTEXT savedHandle;
  TPMI_RH_HIERARCHY hierarchy;
  TPM2B_CONTEXT_DATA contextBlob;
}

// 15 Creation Data

// Table 203 - TPMS_CREATION_DATA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPMS_CREATION_DATA
{
  TPML_PCR_SELECTION pcrSelect;
  TPM2B_DIGEST pcrDigest;
  TPMA_LOCALITY locality;
  TPM_ALG_ID parentNameAlg;
  TPM2B_NAME parentName;
  TPM2B_NAME parentQualifiedName;
  TPM2B_DATA outsideInfo;
}

// Table 204 - TPM2B_CREATION_DATA Structure
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2B_CREATION_DATA
{
  public ushort size;
  TPMS_CREATION_DATA creationData;
}

//
// Command Header
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2_COMMAND_HEADER
{
  TPM_ST tag;
  public uint paramSize;
  TPM_CC commandCode;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TPM2_RESPONSE_HEADER
{
  TPM_ST tag;
  public uint paramSize;
  TPM_RC responseCode;
}

// #pragma pack ()

public unsafe partial class EFI
{
  //
  // TCG Algorithm Registry
  //
  public const ulong HASH_ALG_SHA1 = 0x00000001;
  public const ulong HASH_ALG_SHA256 = 0x00000002;
  public const ulong HASH_ALG_SHA384 = 0x00000004;
  public const ulong HASH_ALG_SHA512 = 0x00000008;
  public const ulong HASH_ALG_SM3_256 = 0x00000010;
}

// #endif
