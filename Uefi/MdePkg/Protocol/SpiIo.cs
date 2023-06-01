using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file defines the SPI I/O Protocol.

  Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
    This Protocol was introduced in UEFI PI Specification 1.6.

**/

// #ifndef __SPI_IO_PROTOCOL_H__
// #define __SPI_IO_PROTOCOL_H__

// #include <Protocol/LegacySpiController.h>
// #include <Protocol/SpiConfiguration.h>

// typedef struct _EFI_SPI_IO_PROTOCOL EFI_SPI_IO_PROTOCOL;

///
/// Note: The UEFI PI 1.6 specification does not specify values for the
///       members below. The order matches the specification.
///
public enum EFI_SPI_TRANSACTION_TYPE
{
  ///
  /// Data flowing in both direction between the host and
  /// SPI peripheral.ReadBytes must equal WriteBytes and both ReadBuffer and
  /// WriteBuffer must be provided.
  ///
  SPI_TRANSACTION_FULL_DUPLEX,

  ///
  /// Data flowing from the host to the SPI peripheral.ReadBytes must be
  /// zero.WriteBytes must be non - zero and WriteBuffer must be provided.
  ///
  SPI_TRANSACTION_WRITE_ONLY,

  ///
  /// Data flowing from the SPI peripheral to the host.WriteBytes must be
  /// zero.ReadBytes must be non - zero and ReadBuffer must be provided.
  ///
  SPI_TRANSACTION_READ_ONLY,

  ///
  /// Data first flowing from the host to the SPI peripheral and then data
  /// flows from the SPI peripheral to the host.These types of operations get
  /// used for SPI flash devices when control data (opcode, address) must be
  /// passed to the SPI peripheral to specify the data to be read.
  ///
  SPI_TRANSACTION_WRITE_THEN_READ
}


















































































































///
/// The EFI_SPI_BUS_ TRANSACTION data structure contains the description of the
/// SPI transaction to perform on the host controller.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SPI_BUS_TRANSACTION
{
  ///
  /// Pointer to the SPI peripheral being manipulated.
  ///
  CONSTpublic EFI_SPI_PERIPHERAL    *SpiPeripheral;

  ///
  /// Type of transaction specified by one of the EFI_SPI_TRANSACTION_TYPE
  /// values.
  ///
 public EFI_SPI_TRANSACTION_TYPE TransactionType;

  ///
  /// TRUE if the transaction is being debugged. Debugging may be turned on for
  /// a single SPI transaction. Only this transaction will display debugging
  /// messages. All other transactions with this value set to FALSE will not
  /// display any debugging messages.
  ///
  public bool DebugTransaction;

  ///
  /// SPI bus width in bits: 1, 2, 4
  ///
  public uint BusWidth;

  ///
  /// Frame size in bits, range: 1 - 32
  ///
  public uint FrameSize;

  ///
  /// Length of the write buffer in bytes
  ///
  public uint WriteBytes;

  ///
  /// Buffer containing data to send to the SPI peripheral
  /// Frame sizes 1 - 8 bits: byte (one byte) per frame
  /// Frame sizes 7 - 16 bits : ushort (two bytes) per frame
  ///
  public byte* WriteBuffer;

  ///
  /// Length of the read buffer in bytes
  ///
  public uint ReadBytes;

  ///
  /// Buffer to receive the data from the SPI peripheral
  /// * Frame sizes 1 - 8 bits: byte (one byte) per frame
  /// * Frame sizes 7 - 16 bits : ushort (two bytes) per frame
  /// * Frame sizes 17 - 32 bits : uint (four bytes) per frame
  ///
  public byte* ReadBuffer;
}

///
/// Support managed SPI data transactions between the SPI controller and a SPI
/// chip.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SPI_IO_PROTOCOL
{
  ///
  /// Address of an EFI_SPI_PERIPHERAL data structure associated with this
  /// protocol instance.
  ///
  CONSTpublic EFI_SPI_PERIPHERAL    *SpiPeripheral;

  ///
  /// Address of the original EFI_SPI_PERIPHERAL data structure associated with
  /// this protocol instance.
  ///
  CONSTpublic EFI_SPI_PERIPHERAL    *OriginalSpiPeripheral;

  ///
  /// Mask of frame sizes which the SPI 10 layer supports. Frame size of N-bits
  /// is supported when bit N-1 is set. The host controller must support a
  /// frame size of 8-bits. Frame sizes of 16, 24 and 32-bits are converted to
  /// 8-bit frame sizes by the SPI bus layer if the frame size is not supported
  /// by the SPI host controller.
  ///
 public uint FrameSizeSupportMask;

  ///
  /// Maximum transfer size in bytes: 1 - Oxffffffff
  ///
  public uint MaximumTransferBytes;

  ///
  /// Transaction attributes: One or more from:
  /// * SPI_10_SUPPORTS_2_B1T_DATA_BUS_W1DTH
  ///   - The SPI host and peripheral supports a 2-bit data bus
  /// * SPI_IO_SUPPORTS_4_BIT_DATA_BUS_W1DTH
  ///   - The SPI host and peripheral supports a 4-bit data bus
  /// * SPI_IO_TRANSFER_SIZE_INCLUDES_OPCODE
  ///   - Transfer size includes the opcode byte
  /// * SPI_IO_TRANSFER_SIZE_INCLUDES_ADDRESS
  ///   - Transfer size includes the 3 address bytes
  ///
  public uint Attributes;

  ///
  /// Pointer to legacy SPI controller protocol
  ///
  CONSTpublic EFI_LEGACY_SPI_CONTROLLER_PROTOCOL     *LegacySpiProtocol;

  ///
  /// Initiate a SPI transaction between the host and a SPI peripheral.
  ///
/**
  Initiate a SPI transaction between the host and a SPI peripheral.

  This routine must be called at or below TPL_NOTIFY.
  This routine works with the SPI bus layer to pass the SPI transaction to the
  SPI controller for execution on the SPI bus. There are four types of
  supported transactions supported by this routine:
  * Full Duplex: WriteBuffer and ReadBuffer are the same size.
  * Write Only: WriteBuffer contains data for SPI peripheral, ReadBytes = 0
  * Read Only: ReadBuffer to receive data from SPI peripheral, WriteBytes = 0
  * Write Then Read: WriteBuffer contains control data to write to SPI
                     peripheral before data is placed into the ReadBuffer.
                     Both WriteBytes and ReadBytes must be non-zero.

  @param[in]  This              Pointer to an EFI_SPI_IO_PROTOCOL structure.
  @param[in]  TransactionType   Type of SPI transaction.
  @param[in]  DebugTransaction  Set TRUE only when debugging is desired.
                                Debugging may be turned on for a single SPI
                                transaction. Only this transaction will display
                                debugging messages. All other transactions with
                                this value set to FALSE will not display any
                                debugging messages.
  @param[in]  ClockHz           Specify the ClockHz value as zero (0) to use
                                the maximum clock frequency supported by the
                                SPI controller and part. Specify a non-zero
                                value only when a specific SPI transaction
                                requires a reduced clock rate.
  @param[in]  BusWidth          Width of the SPI bus in bits: 1, 2, 4
  @param[in]  FrameSize         Frame size in bits, range: 1 - 32
  @param[in]  WriteBytes        The length of the WriteBuffer in bytes.
                                Specify zero for read-only operations.
  @param[in]  WriteBuffer       The buffer containing data to be sent from the
                                host to the SPI chip. Specify NULL for read
                                only operations.
                                * Frame sizes 1-8 bits: byte (one byte) per
                                  frame
                                * Frame sizes 7-16 bits: ushort (two bytes) per
                                  frame
                                * Frame sizes 17-32 bits: uint (four bytes)
                                  per frame The transmit frame is in the least
                                  significant N bits.
  @param[in]  ReadBytes         The length of the ReadBuffer in bytes.
                                Specify zero for write-only operations.
  @param[out] ReadBuffer        The buffer to receeive data from the SPI chip
                                during the transaction. Specify NULL for write
                                only operations.
                                * Frame sizes 1-8 bits: byte (one byte) per
                                  frame
                                * Frame sizes 7-16 bits: ushort (two bytes) per
                                  frame
                                * Frame sizes 17-32 bits: uint (four bytes)
                                  per frame The received frame is in the least
                                  significant N bits.

  @retval EFI_SUCCESS            The SPI transaction completed successfully
  @retval EFI_BAD_BUFFER_SIZE    The writeBytes value was invalid
  @retval EFI_BAD_BUFFER_SIZE    The ReadBytes value was invalid
  @retval EFI_INVALID_PARAMETER  TransactionType is not valid,
                                 or BusWidth not supported by SPI peripheral or
                                 SPI host controller,
                                 or WriteBytes non-zero and WriteBuffer is
                                 NULL,
                                 or ReadBytes non-zero and ReadBuffer is NULL,
                                 or ReadBuffer != WriteBuffer for full-duplex
                                 type,
                                 or WriteBuffer was NULL,
                                 or TPL is too high
  @retval EFI_OUT_OF_RESOURCES   Insufficient memory for SPI transaction
  @retval EFI_UNSUPPORTED        The FrameSize is not supported by the SPI bus
                                 layer or the SPI host controller
  @retval EFI_UNSUPPORTED        The SPI controller was not able to support

**/
public readonly delegate* unmanaged<CONST, EFI_SPI_TRANSACTION_TYPE, bool, uint, uint, uint, uint, byte*, uint, byte*, EFI_STATUS> Transaction;

  ///
  /// Update the SPI peripheral associated with this SPI 10 instance.
  ///
  /**
    Update the SPI peripheral associated with this SPI 10 instance.

    Support socketed SPI parts by allowing the SPI peripheral driver to replace
    the SPI peripheral after the connection is made. An example use is socketed
    SPI NOR flash parts, where the size and parameters change depending upon
    device is in the socket.

    @param[in] This           Pointer to an EFI_SPI_IO_PROTOCOL structure.
    @param[in] SpiPeripheral  Pointer to an EFI_SPI_PERIPHERAL structure.

    @retval EFI_SUCCESS            The SPI peripheral was updated successfully
    @retval EFI_INVALID_PARAMETER  The SpiPeripheral value is NULL,
                                   or the SpiPeripheral->SpiBus is NULL,
                                   or the SpiP eripheral - >SpiBus pointing at
                                   wrong bus,
                                   or the SpiP eripheral - >SpiPart is NULL

  **/
  public readonly delegate* unmanaged<CONST, EFI_STATUS> UpdateSpiPeripheral;
}

// #endif // __SPI_IO_PROTOCOL_H__
