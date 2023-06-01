using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Platform TPM Profile Specification definition for TPM2.0.
  It covers both FIFO and CRB interface.

Copyright (c) 2016 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _TPM_PTP_H_
// #define _TPM_PTP_H_

//
// PTP FIFO definition
//

//
// Set structure alignment to 1-byte
//
// #pragma pack (1)

//
// Register set map as specified in PTP specification Chapter 5
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PTP_FIFO_REGISTERS
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
  public uint InterfaceCapability;                        // 14h
  ///
  /// Status Register. Provides status of the TPM.
  ///
  public byte Status;                                     // 18h
  ///
  /// Number of consecutive writes that can be done to the TPM.
  ///
  public ushort BurstCount;                                 // 19h
  ///
  /// Additional Status Register.
  ///
  public byte StatusEx;                                   // 1Bh
  public fixed byte Reserved3[8];
  ///
  /// Read or write FIFO, depending on transaction.
  ///
  public uint DataFifo;                                   // 24h
  public fixed byte Reserved4[8];                               // 28h
  ///
  /// Used to identify the Interface types supported by the TPM.
  ///
  public uint InterfaceId;                                // 30h
  public fixed byte Reserved5[0x4c];                            // 34h
  ///
  /// Extended ReadFIFO or WriteFIFO, depending on the current bus cycle (read or write)
  ///
  public uint XDataFifo;                                  // 80h
  public fixed byte Reserved6[0xe7c];                           // 84h
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
  public fixed byte Reserved[0xfb];                             // 0f05h
}

//
// Restore original structure alignment
//
// #pragma pack ()

//
// Define pointer types used to access TIS registers on PC
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PTP_FIFO_REGISTERS_PTR { PTP_FIFO_REGISTERS* Value; public static implicit operator PTP_FIFO_REGISTERS_PTR(PTP_FIFO_REGISTERS* value) => new PTP_FIFO_REGISTERS_PTR() { Value = value }; public static implicit operator PTP_FIFO_REGISTERS*(PTP_FIFO_REGISTERS_PTR value) => value.Value; }

//
// Define bits of FIFO Interface Identifier Register
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint InterfaceType = 4;
  [FieldOffset(0)] public uint InterfaceVersion = 4;
  [FieldOffset(0)] public uint CapLocality = 1;
  [FieldOffset(0)] public uint Reserved1 = 2;
  [FieldOffset(0)] public uint CapDataXferSizeSupport = 2;
  [FieldOffset(0)] public uint CapFIFO = 1;
  [FieldOffset(0)] public uint CapCRB = 1;
  [FieldOffset(0)] public uint CapIFRes = 2;
  [FieldOffset(0)] public uint InterfaceSelector = 2;
  [FieldOffset(0)] public uint IntfSelLock = 1;
  [FieldOffset(0)] public uint Reserved2 = 4;
  [FieldOffset(0)] public uint Reserved3 = 8;
}
uint Uint32;
} PTP_FIFO_INTERFACE_IDENTIFIER;

//
// Define bits of FIFO Interface Capability Register
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint DataAvailIntSupport = 1;
  [FieldOffset(0)] public uint StsValidIntSupport = 1;
  [FieldOffset(0)] public uint LocalityChangeIntSupport = 1;
  [FieldOffset(0)] public uint InterruptLevelHigh = 1;
  [FieldOffset(0)] public uint InterruptLevelLow = 1;
  [FieldOffset(0)] public uint InterruptEdgeRising = 1;
  [FieldOffset(0)] public uint InterruptEdgeFalling = 1;
  [FieldOffset(0)] public uint CommandReadyIntSupport = 1;
  [FieldOffset(0)] public uint BurstCountStatic = 1;
  [FieldOffset(0)] public uint DataTransferSizeSupport = 2;
  [FieldOffset(0)] public uint Reserved = 17;
  [FieldOffset(0)] public uint InterfaceVersion = 3;
  [FieldOffset(0)] public uint Reserved2 = 1;
}
uint Uint32;
} PTP_FIFO_INTERFACE_CAPABILITY;

///
/// InterfaceVersion
///
public const ulong INTERFACE_CAPABILITY_INTERFACE_VERSION_TIS_12 = 0x0;
public const ulong INTERFACE_CAPABILITY_INTERFACE_VERSION_TIS_13 = 0x2;
public const ulong INTERFACE_CAPABILITY_INTERFACE_VERSION_PTP = 0x3;

//
// Define bits of ACCESS and STATUS registers
//

///
/// This bit is a 1 to indicate that the other bits in this register are valid.
///
public const ulong PTP_FIFO_VALID = BIT7;
///
/// Indicate that this locality is active.
///
public const ulong PTP_FIFO_ACC_ACTIVE = BIT5;
///
/// Set to 1 to indicate that this locality had the TPM taken away while
/// this locality had the TIS_PC_ACC_ACTIVE bit set.
///
public const ulong PTP_FIFO_ACC_SEIZED = BIT4;
///
/// Set to 1 to indicate that TPM MUST reset the
/// TIS_PC_ACC_ACTIVE bit and remove ownership for localities less than the
/// locality that is writing this bit.
///
public const ulong PTP_FIFO_ACC_SEIZE = BIT3;
///
/// When this bit is 1, another locality is requesting usage of the TPM.
///
public const ulong PTP_FIFO_ACC_PENDIND = BIT2;
///
/// Set to 1 to indicate that this locality is requesting to use TPM.
///
public const ulong PTP_FIFO_ACC_RQUUSE = BIT1;
///
/// A value of 1 indicates that a T/OS has not been established on the platform
///
public const ulong PTP_FIFO_ACC_ESTABLISH = BIT0;

///
/// This field indicates that STS_DATA and STS_EXPECT are valid
///
public const ulong PTP_FIFO_STS_VALID = BIT7;
///
/// When this bit is 1, TPM is in the Ready state,
/// indicating it is ready to receive a new command.
///
public const ulong PTP_FIFO_STS_READY = BIT6;
///
/// Write a 1 to this bit to cause the TPM to execute that command.
///
public const ulong PTP_FIFO_STS_GO = BIT5;
///
/// This bit indicates that the TPM has data available as a response.
///
public const ulong PTP_FIFO_STS_DATA = BIT4;
///
/// The TPM sets this bit to a value of 1 when it expects another byte of data for a command.
///
public const ulong PTP_FIFO_STS_EXPECT = BIT3;
///
/// Indicates that the TPM has completed all self-test actions following a TPM_ContinueSelfTest command.
///
public const ulong PTP_FIFO_STS_SELFTEST_DONE = BIT2;
///
/// Writes a 1 to this bit to force the TPM to re-send the response.
///
public const ulong PTP_FIFO_STS_RETRY = BIT1;

///
/// TPM Family Identifier.
/// 00: TPM 1.2 Family
/// 01: TPM 2.0 Family
///
public const ulong PTP_FIFO_STS_EX_TPM_FAMILY = (BIT2 | BIT3);
public const ulong PTP_FIFO_STS_EX_TPM_FAMILY_OFFSET = (2);
public const ulong PTP_FIFO_STS_EX_TPM_FAMILY_TPM12 = (0);
public const ulong PTP_FIFO_STS_EX_TPM_FAMILY_TPM20 = (BIT2);
///
/// A write of 1 after tpmGo and before dataAvail aborts the currently executing command, resulting in a response of TPM_RC_CANCELLED.
/// A write of 1 after dataAvail and before tpmGo is ignored by the TPM.
///
public const ulong PTP_FIFO_STS_EX_CANCEL = BIT0;

//
// PTP CRB definition
//

//
// Set structure alignment to 1-byte
//
// #pragma pack (1)

//
// Register set map as specified in PTP specification Chapter 5
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PTP_CRB_REGISTERS
{
  ///
  /// Used to determine current state of Locality of the TPM.
  ///
  public uint LocalityState;                                     // 0
  public fixed byte Reserved1[4];                                      // 4
  ///
  /// Used to gain control of the TPM by this Locality.
  ///
  public uint LocalityControl;                                   // 8
  ///
  /// Used to determine whether Locality has been granted or Seized.
  ///
  public uint LocalityStatus;                                    // 0ch
  public fixed byte Reserved2[0x20];                                   // 10h
  ///
  /// Used to identify the Interface types supported by the TPM.
  ///
  public uint InterfaceId;                                       // 30h
  ///
  /// Vendor ID
  ///
  public ushort Vid;                                               // 34h
  ///
  /// Device ID
  ///
  public ushort Did;                                               // 36h
  ///
  /// Optional Register used in low memory environments prior to CRB_DATA_BUFFER availability.
  ///
  public ulong CrbControlExtension;                               // 38h
  ///
  /// Register used to initiate transactions for the CRB interface.
  ///
  public uint CrbControlRequest;                                 // 40h
  ///
  /// Register used by the TPM to provide status of the CRB interface.
  ///
  public uint CrbControlStatus;                                  // 44h
  ///
  /// Register used by software to cancel command processing.
  ///
  public uint CrbControlCancel;                                  // 48h
  ///
  /// Register used to indicate presence of command or response data in the CRB buffer.
  ///
  public uint CrbControlStart;                                   // 4Ch
  ///
  /// Register used to configure and respond to interrupts.
  ///
  public uint CrbInterruptEnable;                                // 50h
  public uint CrbInterruptStatus;                                // 54h
  ///
  /// Size of the Command buffer.
  ///
  public uint CrbControlCommandSize;                             // 58h
  ///
  /// Command buffer start address
  ///
  public uint CrbControlCommandAddressLow;                           // 5Ch
  public uint CrbControlCommandAddressHigh;                          // 60h
  ///
  /// Size of the Response buffer
  ///
  public uint CrbControlResponseSize;                            // 64h
  ///
  /// Address of the start of the Response buffer
  ///
  public ulong CrbControlResponseAddrss;                          // 68h
  public fixed byte Reserved4[0x10];                                   // 70h
  ///
  /// Command/Response Data may be defined as large as 3968 (0xF80).
  ///
  public fixed byte CrbDataBuffer[0xF80];                              // 80h
}

//
// Define pointer types used to access CRB registers on PTP
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PTP_CRB_REGISTERS_PTR { PTP_CRB_REGISTERS* Value; public static implicit operator PTP_CRB_REGISTERS_PTR(PTP_CRB_REGISTERS* value) => new PTP_CRB_REGISTERS_PTR() { Value = value }; public static implicit operator PTP_CRB_REGISTERS*(PTP_CRB_REGISTERS_PTR value) => value.Value; }

//
// Define bits of CRB Interface Identifier Register
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint InterfaceType = 4;
  [FieldOffset(0)] public uint InterfaceVersion = 4;
  [FieldOffset(0)] public uint CapLocality = 1;
  [FieldOffset(0)] public uint CapCRBIdleBypass = 1;
  [FieldOffset(0)] public uint Reserved1 = 1;
  [FieldOffset(0)] public uint CapDataXferSizeSupport = 2;
  [FieldOffset(0)] public uint CapFIFO = 1;
  [FieldOffset(0)] public uint CapCRB = 1;
  [FieldOffset(0)] public uint CapIFRes = 2;
  [FieldOffset(0)] public uint InterfaceSelector = 2;
  [FieldOffset(0)] public uint IntfSelLock = 1;
  [FieldOffset(0)] public uint Reserved2 = 4;
  [FieldOffset(0)] public uint Rid = 8;
}
uint Uint32;
} PTP_CRB_INTERFACE_IDENTIFIER;

///
/// InterfaceType
///
public const ulong PTP_INTERFACE_IDENTIFIER_INTERFACE_TYPE_FIFO = 0x0;
public const ulong PTP_INTERFACE_IDENTIFIER_INTERFACE_TYPE_CRB = 0x1;
public const ulong PTP_INTERFACE_IDENTIFIER_INTERFACE_TYPE_TIS = 0xF;

///
/// InterfaceVersion
///
public const ulong PTP_INTERFACE_IDENTIFIER_INTERFACE_VERSION_FIFO = 0x0;
public const ulong PTP_INTERFACE_IDENTIFIER_INTERFACE_VERSION_CRB = 0x1;

///
/// InterfaceSelector
///
public const ulong PTP_INTERFACE_IDENTIFIER_INTERFACE_SELECTOR_FIFO = 0x0;
public const ulong PTP_INTERFACE_IDENTIFIER_INTERFACE_SELECTOR_CRB = 0x1;

//
// Define bits of Locality State Register
//

///
/// This bit indicates whether all other bits of this register contain valid values, if it is a 1.
///
public const ulong PTP_CRB_LOCALITY_STATE_TPM_REG_VALID_STATUS = BIT7;

///
/// 000 - Locality 0
/// 001 - Locality 1
/// 010 - Locality 2
/// 011 - Locality 3
/// 100 - Locality 4
///
public const ulong PTP_CRB_LOCALITY_STATE_ACTIVE_LOCALITY_MASK = (BIT2 | BIT3 | BIT4);
public const ulong PTP_CRB_LOCALITY_STATE_ACTIVE_LOCALITY_0 = (0);
public const ulong PTP_CRB_LOCALITY_STATE_ACTIVE_LOCALITY_1 = (BIT2);
public const ulong PTP_CRB_LOCALITY_STATE_ACTIVE_LOCALITY_2 = (BIT3);
public const ulong PTP_CRB_LOCALITY_STATE_ACTIVE_LOCALITY_3 = (BIT2 | BIT3);
public const ulong PTP_CRB_LOCALITY_STATE_ACTIVE_LOCALITY_4 = (BIT4);

///
/// A 0 indicates to the host that no locality is assigned.
/// A 1 indicates a locality has been assigned.
///
public const ulong PTP_CRB_LOCALITY_STATE_LOCALITY_ASSIGNED = BIT1;

///
/// The TPM clears this bit to 0 upon receipt of _TPM_Hash_End
/// The TPM sets this bit to a 1 when the TPM_LOC_CTRL_x.resetEstablishment field is set to 1.
///
public const ulong PTP_CRB_LOCALITY_STATE_TPM_ESTABLISHED = BIT0;

//
// Define bits of Locality Control Register
//

///
/// Writes (1): Reset TPM_LOC_STATE_x.tpmEstablished bit if the write occurs from Locality 3 or 4.
///
public const ulong PTP_CRB_LOCALITY_CONTROL_RESET_ESTABLISHMENT_BIT = BIT3;

///
/// Writes (1): The TPM gives control of the TPM to the locality setting this bit if it is the higher priority locality.
///
public const ulong PTP_CRB_LOCALITY_CONTROL_SEIZE = BIT2;

///
/// Writes (1): The active Locality is done with the TPM.
///
public const ulong PTP_CRB_LOCALITY_CONTROL_RELINQUISH = BIT1;

///
/// Writes (1): Interrupt the TPM and generate a locality arbitration algorithm.
///
public const ulong PTP_CRB_LOCALITY_CONTROL_REQUEST_ACCESS = BIT0;

//
// Define bits of Locality Status Register
//

///
/// 0: A higher locality has not initiated a Seize arbitration process.
/// 1: A higher locality has Seized the TPM from this locality.
///
public const ulong PTP_CRB_LOCALITY_STATUS_BEEN_SEIZED = BIT1;

///
/// 0: Locality has not been granted to the TPM.
/// 1: Locality has been granted access to the TPM
///
public const ulong PTP_CRB_LOCALITY_STATUS_GRANTED = BIT0;

//
// Define bits of CRB Control Area Request Register
//

///
/// Used by Software to indicate transition the TPM to and from the Idle state
/// 1: Set by Software to indicate response has been read from the response buffer and TPM can transition to Idle
/// 0: Cleared to 0 by TPM to acknowledge the request when TPM enters Idle state.
/// TPM SHALL complete this transition within TIMEOUT_C.
///
public const ulong PTP_CRB_CONTROL_AREA_REQUEST_GO_IDLE = BIT1;

///
/// Used by Software to request the TPM transition to the Ready State.
/// 1: Set to 1 by Software to indicate the TPM should be ready to receive a command.
/// 0: Cleared to 0 by TPM to acknowledge the request.
/// TPM SHALL complete this transition within TIMEOUT_C.
///
public const ulong PTP_CRB_CONTROL_AREA_REQUEST_COMMAND_READY = BIT0;

//
// Define bits of CRB Control Area Status Register
//

///
/// Used by TPM to indicate it is in the Idle State
/// 1: Set by TPM when in the Idle State
/// 0: Cleared by TPM on receipt of TPM_CRB_CTRL_REQ_x.cmdReady when TPM transitions to the Ready State.
/// SHALL be cleared by TIMEOUT_C.
///
public const ulong PTP_CRB_CONTROL_AREA_STATUS_TPM_IDLE = BIT1;

///
/// Used by the TPM to indicate current status.
/// 1: Set by TPM to indicate a FATAL Error
/// 0: Indicates TPM is operational
///
public const ulong PTP_CRB_CONTROL_AREA_STATUS_TPM_STATUS = BIT0;

//
// Define bits of CRB Control Cancel Register
//

///
/// Used by software to cancel command processing Reads return correct value
/// Writes (0000 0001h): Cancel a command
/// Writes (0000 0000h): Clears field when command has been cancelled
///
public const ulong PTP_CRB_CONTROL_CANCEL = BIT0;

//
// Define bits of CRB Control Start Register
//

///
/// When set by software, indicates a command is ready for processing.
/// Writes (0000 0001h): TPM transitions to Command Execution
/// Writes (0000 0000h): TPM clears this field and transitions to Command Completion
///
public const ulong PTP_CRB_CONTROL_START = BIT0;

//
// Restore original structure alignment
//
// #pragma pack ()

//
// Default TimeOut value
//
public const ulong PTP_TIMEOUT_A = (750 * 1000)                // 750ms;
public const ulong PTP_TIMEOUT_B = (2000 * 1000)               // 2s;
public const ulong PTP_TIMEOUT_C = (200 * 1000)                // 200ms;
public const ulong PTP_TIMEOUT_D = (30 * 1000)                 // 30ms;

// #endif
