using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  TPM Interface Specification definition.
  It covers both TPM1.2 and TPM2.0.

Copyright (c) 2016 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _TPM_TIS_H_
// #define _TPM_TIS_H_

//
// Set structure alignment to 1-byte
//
// #pragma pack (1)

//
// Register set map as specified in TIS specification Chapter 10
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TIS_PC_REGISTERS
{
  ///
  /// Used to gain ownership for this particular port.
  ///
  public byte Access;                                     // 0
  public fixed byte Reserved1[7];                               // 1
  ///
  /// Controls interrupts.
  ///
  public uint IntEnable;                                  // 8
  ///
  /// SIRQ vector to be used by the TPM.
  ///
  public byte IntVector;                                  // 0ch
  public fixed byte Reserved2[3];                               // 0dh
  ///
  /// What caused interrupt.
  ///
  public uint IntSts;                                     // 10h
  ///
  /// Shows which interrupts are supported by that particular TPM.
  ///
  public uint IntfCapability;                             // 14h
  ///
  /// Status Register. Provides status of the TPM.
  ///
  public byte Status;                                     // 18h
  ///
  /// Number of consecutive writes that can be done to the TPM.
  ///
  public ushort BurstCount;                                 // 19h
  public fixed byte Reserved3[9];
  ///
  /// Read or write FIFO, depending on transaction.
  ///
  public uint DataFifo;                                   // 24h
  public fixed byte Reserved4[0xed8];                           // 28h
  ///
  /// Vendor ID
  ///
  public ushort Vid;                                        // 0f00h
  ///
  /// Device ID
  ///
  public ushort Did;                                        // 0f02h
  ///
  /// Revision ID
  ///
  public byte Rid;                                        // 0f04h
  public fixed byte Reserved[0x7b];                             // 0f05h
  ///
  /// Alias to I/O legacy space.
  ///
  public uint LegacyAddress1;                             // 0f80h
  ///
  /// Additional 8 bits for I/O legacy space extension.
  ///
  public uint LegacyAddress1Ex;                           // 0f84h
  ///
  /// Alias to second I/O legacy space.
  ///
  public uint LegacyAddress2;                             // 0f88h
  ///
  /// Additional 8 bits for second I/O legacy space extension.
  ///
  public uint LegacyAddress2Ex;                           // 0f8ch
  ///
  /// Vendor-defined configuration registers.
  ///
  public fixed byte VendorDefined[0x70];                        // 0f90h
}

//
// Restore original structure alignment
//
// #pragma pack ()

//
// Define pointer types used to access TIS registers on PC
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TIS_PC_REGISTERS_PTR { TIS_PC_REGISTERS* Value; public static implicit operator TIS_PC_REGISTERS_PTR(TIS_PC_REGISTERS* value) => new TIS_PC_REGISTERS_PTR() { Value = value }; public static implicit operator TIS_PC_REGISTERS*(TIS_PC_REGISTERS_PTR value) => value.Value; }

//
// Define bits of ACCESS and STATUS registers
//

public unsafe partial class EFI
{
  ///
  /// This bit is a 1 to indicate that the other bits in this register are valid.
  ///
  public const ulong TIS_PC_VALID = BIT7;
  ///
  /// Indicate that this locality is active.
  ///
  public const ulong TIS_PC_ACC_ACTIVE = BIT5;
  ///
  /// Set to 1 to indicate that this locality had the TPM taken away while
  /// this locality had the TIS_PC_ACC_ACTIVE bit set.
  ///
  public const ulong TIS_PC_ACC_SEIZED = BIT4;
  ///
  /// Set to 1 to indicate that TPM MUST reset the
  /// TIS_PC_ACC_ACTIVE bit and remove ownership for localities less than the
  /// locality that is writing this bit.
  ///
  public const ulong TIS_PC_ACC_SEIZE = BIT3;
  ///
  /// When this bit is 1, another locality is requesting usage of the TPM.
  ///
  public const ulong TIS_PC_ACC_PENDIND = BIT2;
  ///
  /// Set to 1 to indicate that this locality is requesting to use TPM.
  ///
  public const ulong TIS_PC_ACC_RQUUSE = BIT1;
  ///
  /// A value of 1 indicates that a T/OS has not been established on the platform
  ///
  public const ulong TIS_PC_ACC_ESTABLISH = BIT0;

  ///
  /// Write a 1 to this bit to notify TPM to cancel currently executing command
  ///
  public const ulong TIS_PC_STS_CANCEL = BIT24;
  ///
  /// This field indicates that STS_DATA and STS_EXPECT are valid
  ///
  public const ulong TIS_PC_STS_VALID = BIT7;
  ///
  /// When this bit is 1, TPM is in the Ready state,
  /// indicating it is ready to receive a new command.
  ///
  public const ulong TIS_PC_STS_READY = BIT6;
  ///
  /// Write a 1 to this bit to cause the TPM to execute that command.
  ///
  public const ulong TIS_PC_STS_GO = BIT5;
  ///
  /// This bit indicates that the TPM has data available as a response.
  ///
  public const ulong TIS_PC_STS_DATA = BIT4;
  ///
  /// The TPM sets this bit to a value of 1 when it expects another byte of data for a command.
  ///
  public const ulong TIS_PC_STS_EXPECT = BIT3;
  ///
  /// Indicates that the TPM has completed all self-test actions following a TPM_ContinueSelfTest command.
  ///
  public const ulong TIS_PC_STS_SELFTEST_DONE = BIT2;
  ///
  /// Writes a 1 to this bit to force the TPM to re-send the response.
  ///
  public const ulong TIS_PC_STS_RETRY = BIT1;

  //
  // Default TimeOut value
  //
  public const ulong TIS_TIMEOUT_A = (750 * 1000)               // 750ms;
public const ulong TIS_TIMEOUT_B = (2000 * 1000)               // 2s;
public const ulong TIS_TIMEOUT_C = (750 * 1000)               // 750ms;
public const ulong TIS_TIMEOUT_D = (750 * 1000)               // 750ms;
}

// #endif
