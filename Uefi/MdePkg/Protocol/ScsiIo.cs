namespace Uefi;
/** @file
  EFI_SCSI_IO_PROTOCOL as defined in UEFI 2.0.
  This protocol is used by code, typically drivers, running in the EFI boot
  services environment to access SCSI devices. In particular, functions for
  managing devices on SCSI buses are defined here.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __EFI_SCSI_IO_PROTOCOL_H__
// #define __EFI_SCSI_IO_PROTOCOL_H__

public static EFI_GUID EFI_SCSI_IO_PROTOCOL_GUID = new GUID(
    0x932f47e6, 0x2362, 0x4002, new byte[] { 0x80, 0x3e, 0x3c, 0xd5, 0x4b, 0x13, 0x8f, 0x85 });

///
/// Forward reference for pure ANSI compatability
///
// typedef struct _EFI_SCSI_IO_PROTOCOL EFI_SCSI_IO_PROTOCOL;

//
// SCSI Device type information, defined in the SCSI Primary Commands standard (e.g., SPC-4)
//
public static ulong EFI_SCSI_IO_TYPE_DISK = 0x00                           ///< Disk device;
public static ulong EFI_SCSI_IO_TYPE_TAPE = 0x01                           ///< Tape device;
public static ulong EFI_SCSI_IO_TYPE_PRINTER = 0x02                           ///< Printer;
public static ulong EFI_SCSI_IO_TYPE_PROCESSOR = 0x03                           ///< Processor;
public static ulong EFI_SCSI_IO_TYPE_WORM = 0x04                           ///< Write-once read-multiple;
public static ulong EFI_SCSI_IO_TYPE_CDROM = 0x05                           ///< CD or DVD device;
public static ulong EFI_SCSI_IO_TYPE_SCANNER = 0x06                           ///< Scanner device;
public static ulong EFI_SCSI_IO_TYPE_OPTICAL = 0x07                           ///< Optical memory device;
public static ulong EFI_SCSI_IO_TYPE_MEDIUMCHANGER = 0x08                           ///< Medium Changer device;
public static ulong EFI_SCSI_IO_TYPE_COMMUNICATION = 0x09                           ///< Communications device;
public static ulong MFI_SCSI_IO_TYPE_A = 0x0A                           ///< Obsolete;
public static ulong MFI_SCSI_IO_TYPE_B = 0x0B                           ///< Obsolete;
public static ulong MFI_SCSI_IO_TYPE_RAID = 0x0C                           ///< Storage array controller device (e.g., RAID);
public static ulong MFI_SCSI_IO_TYPE_SES = 0x0D                           ///< Enclosure services device;
public static ulong MFI_SCSI_IO_TYPE_RBC = 0x0E                           ///< Simplified direct-access device (e.g., magnetic disk);
public static ulong MFI_SCSI_IO_TYPE_OCRW = 0x0F                           ///< Optical card reader/writer device;
public static ulong MFI_SCSI_IO_TYPE_BRIDGE = 0x10                           ///< Bridge Controller Commands;
public static ulong MFI_SCSI_IO_TYPE_OSD = 0x11                           ///< Object-based Storage Device;
public static ulong EFI_SCSI_IO_TYPE_RESERVED_LOW = 0x12                           ///< Reserved (low);
public static ulong EFI_SCSI_IO_TYPE_RESERVED_HIGH = 0x1E                           ///< Reserved (high);
public static ulong EFI_SCSI_IO_TYPE_UNKNOWN = 0x1F                           ///< Unknown no device type;

//
// SCSI Data Direction definition
//
public static ulong EFI_SCSI_IO_DATA_DIRECTION_READ = 0;
public static ulong EFI_SCSI_IO_DATA_DIRECTION_WRITE = 1;
public static ulong EFI_SCSI_IO_DATA_DIRECTION_BIDIRECTIONAL = 2;

//
// SCSI Host Adapter Status definition
//
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_OK = 0x00;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_TIMEOUT_COMMAND = 0x09    ///< timeout when processing the command;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_TIMEOUT = 0x0b    ///< timeout when waiting for the command processing;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_MESSAGE_REJECT = 0x0d    ///< a message reject was received when processing command;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_BUS_RESET = 0x0e    ///< a bus reset was detected;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_PARITY_ERROR = 0x0f;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_REQUEST_SENSE_FAILED = 0x10    ///< the adapter failed in issuing request sense command;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_SELECTION_TIMEOUT = 0x11    ///< selection timeout;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_DATA_OVERRUN_UNDERRUN = 0x12    ///< data overrun or data underrun;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_BUS_FREE = 0x13    ///< Unexepected bus free;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_PHASE_ERROR = 0x14    ///< Target bus phase sequence failure;
public static ulong EFI_SCSI_IO_STATUS_HOST_ADAPTER_OTHER = 0x7f;

//
// SCSI Target Status definition
//
public static ulong EFI_SCSI_IO_STATUS_TARGET_GOOD = 0x00;
public static ulong EFI_SCSI_IO_STATUS_TARGET_CHECK_CONDITION = 0x02     ///< check condition;
public static ulong EFI_SCSI_IO_STATUS_TARGET_CONDITION_MET = 0x04     ///< condition met;
public static ulong EFI_SCSI_IO_STATUS_TARGET_BUSY = 0x08     ///< busy;
public static ulong EFI_SCSI_IO_STATUS_TARGET_INTERMEDIATE = 0x10     ///< intermediate;
public static ulong EFI_SCSI_IO_STATUS_TARGET_INTERMEDIATE_CONDITION_MET = 0x14     ///< intermediate-condition met;
public static ulong EFI_SCSI_IO_STATUS_TARGET_RESERVATION_CONFLICT = 0x18     ///< reservation conflict;
public static ulong EFI_SCSI_IO_STATUS_TARGET_COMMOND_TERMINATED = 0x22     ///< command terminated;
public static ulong EFI_SCSI_IO_STATUS_TARGET_QUEUE_FULL = 0x28     ///< queue full;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_IO_SCSI_REQUEST_PACKET
{
  ///
  /// The timeout, in 100 ns units, to use for the execution of this SCSI
  /// Request Packet. A Timeout value of 0 means that this function
  /// will wait indefinitely for the SCSI Request Packet to execute. If
  /// Timeout is greater than zero, then this function will return
  /// EFI_TIMEOUT if the time required to execute the SCSI Request
  /// Packet is greater than Timeout.
  ///
  public ulong Timeout;
  ///
  /// A pointer to the data buffer to transfer between the SCSI
  /// controller and the SCSI device for SCSI READ command
  ///
  public void* InDataBuffer;
  ///
  /// A pointer to the data buffer to transfer between the SCSI
  /// controller and the SCSI device for SCSI WRITE command.
  ///
  public void* OutDataBuffer;
  ///
  /// A pointer to the sense data that was generated by the execution of
  /// the SCSI Request Packet.
  ///
  public void* SenseData;
  ///
  /// A pointer to buffer that contains the Command Data Block to
  /// send to the SCSI device.
  ///
  public void* Cdb;
  ///
  /// On Input, the size, in bytes, of InDataBuffer. On output, the
  /// number of bytes transferred between the SCSI controller and the SCSI device.
  ///
  public uint InTransferLength;
  ///
  /// On Input, the size, in bytes of OutDataBuffer. On Output, the
  /// Number of bytes transferred between SCSI Controller and the SCSI device.
  ///
  public uint OutTransferLength;
  ///
  /// The length, in bytes, of the buffer Cdb. The standard values are
  /// 6, 10, 12, and 16, but other values are possible if a variable length CDB is used.
  ///
  public byte CdbLength;
  ///
  /// The direction of the data transfer. 0 for reads, 1 for writes. A
  /// value of 2 is Reserved for Bi-Directional SCSI commands.
  ///
  public byte DataDirection;
  ///
  /// The status of the SCSI Host Controller that produces the SCSI
  /// bus where the SCSI device attached when the SCSI Request
  /// Packet was executed on the SCSI Controller.
  ///
  public byte HostAdapterStatus;
  ///
  /// The status returned by the SCSI device when the SCSI Request
  /// Packet was executed.
  ///
  public byte TargetStatus;
  ///
  /// On input, the length in bytes of the SenseData buffer. On
  /// output, the number of bytes written to the SenseData buffer.
  ///
  public byte SenseDataLength;
}







































































































































///
/// Provides services to manage and communicate with SCSI devices.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_IO_PROTOCOL
{
  /**
    Retrieves the device type information of the SCSI Controller.

    @param  This       Protocol instance pointer.
    @param  DeviceType A pointer to the device type information
                       retrieved from the SCSI Controller.

    @retval EFI_SUCCESS           Retrieved the device type information successfully.
    @retval EFI_INVALID_PARAMETER The DeviceType is NULL.

  **/
  public readonly delegate* unmanaged<EFI_SCSI_IO_PROTOCOL*, byte*, EFI_STATUS> GetDeviceType;
  /**
    Retrieves the device location in the SCSI channel.

    @param  This   Protocol instance pointer.
    @param  Target A pointer to the Target ID of a SCSI device
                   on the SCSI channel.
    @param  Lun    A pointer to the LUN of the SCSI device on
                   the SCSI channel.

    @retval EFI_SUCCESS           Retrieves the device location successfully.
    @retval EFI_INVALID_PARAMETER The Target or Lun is NULL.

  **/
  public readonly delegate* unmanaged<EFI_SCSI_IO_PROTOCOL*, byte**, ulong*, EFI_STATUS> GetDeviceLocation;
  /**
    Resets the SCSI Bus that the SCSI Controller is attached to.

    @param  This Protocol instance pointer.

    @retval EFI_SUCCESS      The SCSI bus is reset successfully.
    @retval EFI_DEVICE_ERROR Errors encountered when resetting the SCSI bus.
    @retval EFI_UNSUPPORTED  The bus reset operation is not supported by the
                             SCSI Host Controller.
    @retval EFI_TIMEOUT      A timeout occurred while attempting to reset
                              the SCSI bus.

  **/
  public readonly delegate* unmanaged<EFI_SCSI_IO_PROTOCOL*, EFI_STATUS> ResetBus;
  /**
    Resets the SCSI Controller that the device handle specifies.

    @param  This Protocol instance pointer.

    @retval EFI_SUCCESS      Reset the SCSI controller successfully.
    @retval EFI_DEVICE_ERROR Errors were encountered when resetting the
                             SCSI Controller.
    @retval EFI_UNSUPPORTED  The SCSI bus does not support a device
                             reset operation.
    @retval EFI_TIMEOUT      A timeout occurred while attempting to
                             reset the SCSI Controller.

  **/
  public readonly delegate* unmanaged<EFI_SCSI_IO_PROTOCOL*, EFI_STATUS> ResetDevice;
  /**
    Sends a SCSI Request Packet to the SCSI Controller for execution.

    @param  This    Protocol instance pointer.
    @param  Packet  The SCSI request packet to send to the SCSI
                    Controller specified by the device handle.
    @param  Event   If the SCSI bus to which the SCSI device is attached
                    does not support non-blocking I/O, then Event is
                    ignored, and blocking I/O is performed.
                    If Event is NULL, then blocking I/O is performed.
                    If Event is not NULL and non-blocking I/O is
                    supported, then non-blocking I/O is performed,
                    and Event will be signaled when the SCSI Request
                    Packet completes.

    @retval EFI_SUCCESS               The SCSI Request Packet was sent by the host
                                      successfully, and TransferLength bytes were
                                      transferred to/from DataBuffer. See
                                      HostAdapterStatus, TargetStatus,
                                      SenseDataLength, and SenseData in that order
                                      for additional status information.
    @retval EFI_BAD_BUFFER_SIZE       The SCSI Request Packet was executed,
                                      but the entire DataBuffer could not be transferred.
                                      The actual number of bytes transferred is returned
                                      in TransferLength. See HostAdapterStatus,
                                      TargetStatus, SenseDataLength, and SenseData in
                                      that order for additional status information.
    @retval EFI_NOT_READY             The SCSI Request Packet could not be sent because
                                      there are too many SCSI Command Packets already
                                      queued.The caller may retry again later.
    @retval EFI_DEVICE_ERROR          A device error occurred while attempting to send
                                      the SCSI Request Packet. See HostAdapterStatus,
                                      TargetStatus, SenseDataLength, and SenseData in
                                      that order for additional status information.
    @retval EFI_INVALID_PARAMETER     The contents of CommandPacket are invalid.
                                      The SCSI Request Packet was not sent, so no
                                      additional status information is available.
    @retval EFI_UNSUPPORTED           The command described by the SCSI Request Packet
                                      is not supported by the SCSI initiator(i.e., SCSI
                                      Host Controller). The SCSI Request Packet was not
                                      sent, so no additional status information is
                                      available.
    @retval EFI_TIMEOUT               A timeout occurred while waiting for the SCSI
                                      Request Packet to execute. See HostAdapterStatus,
                                      TargetStatus, SenseDataLength, and SenseData in
                                      that order for additional status information.

  **/
  public readonly delegate* unmanaged<EFI_SCSI_IO_PROTOCOL*, EFI_SCSI_IO_SCSI_REQUEST_PACKET*, EFI_EVENT, EFI_STATUS> ExecuteScsiCommand;

  ///
  /// Supplies the alignment requirement for any buffer used in a data transfer.
  /// IoAlign values of 0 and 1 mean that the buffer can be placed anywhere in memory.
  /// Otherwise, IoAlign must be a power of 2, and the requirement is that the
  /// start address of a buffer must be evenly divisible by IoAlign with no remainder.
  ///
  public uint IoAlign;
}

// extern EFI_GUID  gEfiScsiIoProtocolGuid;

// #endif
