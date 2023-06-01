namespace Uefi;
/** @file
  SCSI Pass Through protocol as defined in EFI 1.1.
  This protocol allows information about a SCSI channel to be collected,
  and allows SCSI Request Packets to be sent to any SCSI devices on a SCSI
  channel even if those devices are not boot devices. This protocol is attached
  to the device handle of each SCSI channel in a system that the protocol
  supports, and can be used for diagnostics. It may also be used to build
  a Block I/O driver for SCSI hard drives and SCSI CD-ROM or DVD drives to
  allow those devices to become boot devices.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SCSI_PASS_THROUGH_H__
// #define __SCSI_PASS_THROUGH_H__

public static EFI_GUID EFI_SCSI_PASS_THRU_PROTOCOL_GUID = new GUID(
    0xa59e8fcf, 0xbda0, 0x43bb, new byte[] { 0x90, 0xb1, 0xd3, 0x73, 0x2e, 0xca, 0xa8, 0x77 });

///
/// Forward reference for pure ANSI compatability
///
// typedef struct _EFI_SCSI_PASS_THRU_PROTOCOL EFI_SCSI_PASS_THRU_PROTOCOL;

public const ulong EFI_SCSI_PASS_THRU_ATTRIBUTES_PHYSICAL = 0x0001;
public const ulong EFI_SCSI_PASS_THRU_ATTRIBUTES_LOGICAL = 0x0002;
public const ulong EFI_SCSI_PASS_THRU_ATTRIBUTES_NONBLOCKIO = 0x0004;

//
// SCSI Host Adapter Status definition
//
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_OK = 0x00;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_TIMEOUT_COMMAND = 0x09  // timeout when processing the command;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_TIMEOUT = 0x0b  // timeout when waiting for the command processing;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_MESSAGE_REJECT = 0x0d  // a message reject was received when processing command;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_BUS_RESET = 0x0e  // a bus reset was detected;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_PARITY_ERROR = 0x0f;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_REQUEST_SENSE_FAILED = 0x10  // the adapter failed in issuing request sense command;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_SELECTION_TIMEOUT = 0x11  // selection timeout;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_DATA_OVERRUN_UNDERRUN = 0x12  // data overrun or data underrun;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_BUS_FREE = 0x13  // Unexepected bus free;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_PHASE_ERROR = 0x14  // Target bus phase sequence failure;
public const ulong EFI_SCSI_STATUS_HOST_ADAPTER_OTHER = 0x7f;

//
// SCSI Target Status definition
//
public const ulong EFI_SCSI_STATUS_TARGET_GOOD = 0x00;
public const ulong EFI_SCSI_STATUS_TARGET_CHECK_CONDITION = 0x02 // check condition;
public const ulong EFI_SCSI_STATUS_TARGET_CONDITION_MET = 0x04 // condition met;
public const ulong EFI_SCSI_STATUS_TARGET_BUSY = 0x08 // busy;
public const ulong EFI_SCSI_STATUS_TARGET_INTERMEDIATE = 0x10 // intermediate;
public const ulong EFI_SCSI_STATUS_TARGET_INTERMEDIATE_CONDITION_MET = 0x14 // intermediate-condition met;
public const ulong EFI_SCSI_STATUS_TARGET_RESERVATION_CONFLICT = 0x18 // reservation conflict;
public const ulong EFI_SCSI_STATUS_TARGET_COMMOND_TERMINATED = 0x22 // command terminated;
public const ulong EFI_SCSI_STATUS_TARGET_QUEUE_FULL = 0x28 // queue full;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_PASS_THRU_SCSI_REQUEST_PACKET
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
  /// controller and the SCSI device. Must be aligned to the boundary
  /// specified in the IoAlign field of the
  /// EFI_SCSI_PASS_THRU_MODE structure.
  ///
  public void* DataBuffer;
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
  public uint TransferLength;
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

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_PASS_THRU_MODE
{
  ///
  /// A Null-terminated Unicode string that represents the printable name of the SCSI controller.
  ///
  public char* ControllerName;
  ///
  /// A Null-terminated Unicode string that represents the printable name of the SCSI channel.
  ///
  public char* ChannelName;
  ///
  /// The Target ID of the host adapter on the SCSI channel.
  ///
  public uint AdapterId;
  ///
  /// Additional information on the attributes of the SCSI channel.
  ///
  public uint Attributes;
  ///
  /// Supplies the alignment requirement for any buffer used in a data transfer.
  ///
  public uint IoAlign;
}



















































































































































































































///
/// The EFI_SCSI_PASS_THRU_PROTOCOL provides information about a SCSI channel and
/// the ability to send SCSI Request Packets to any SCSI device attached to that SCSI channel. The
/// information includes the Target ID of the host controller on the SCSI channel, the attributes of
/// the SCSI channel, the printable name for the SCSI controller, and the printable name of the
/// SCSI channel.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SCSI_PASS_THRU_PROTOCOL
{
  ///
  /// A pointer to the EFI_SCSI_PASS_THRU_MODE data for this SCSI channel.
  ///
  public EFI_SCSI_PASS_THRU_MODE* Mode;
  /**
    Sends a SCSI Request Packet to a SCSI device that is attached to
    the SCSI channel. This function supports both blocking I/O and
    non-blocking I/O.  The blocking I/O functionality is required,
    and the non-blocking I/O functionality is optional.

    @param  This   Protocol instance pointer.
    @param  Target The Target ID of the SCSI device to
                   send the SCSI Request Packet.
    @param  Lun    The LUN of the SCSI device to send the
                   SCSI Request Packet.
    @param  Packet A pointer to the SCSI Request Packet to send
                   to the SCSI device specified by Target and Lun.
    @param  Event  If non-blocking I/O is not supported then Event
                   is ignored, and blocking I/O is performed.
                   If Event is NULL, then blocking I/O is performed.
                   If Event is not NULL and non blocking I/O is
                   supported, then non-blocking I/O is performed,
                   and Event will be signaled when the SCSI Request
                   Packet completes

    @retval EFI_SUCCESS               The SCSI Request Packet was sent by the host, and
                                      TransferLength bytes were transferred to/from
                                      DataBuffer. See HostAdapterStatus, TargetStatus,
                                      SenseDataLength, and SenseData in that order
                                      for additional status information.
    @retval EFI_BAD_BUFFER_SIZE       The SCSI Request Packet was executed, but the
                                      entire DataBuffer could not be transferred.
                                      The actual number of bytes transferred is returned
                                      in TransferLength. See HostAdapterStatus,
                                      TargetStatus, SenseDataLength, and SenseData in
                                      that order for additional status information.
    @retval EFI_NOT_READY             The SCSI Request Packet could not be sent because
                                      there are too many SCSI Request Packets already
                                      queued.  The caller may retry again later.
    @retval EFI_DEVICE_ERROR          A device error occurred while attempting to send
                                      the SCSI Request Packet. See HostAdapterStatus,
                                      TargetStatus, SenseDataLength, and SenseData in
                                      that order for additional status information.
    @retval EFI_INVALID_PARAMETER     Target, Lun, or the contents of ScsiRequestPacket
                                      are invalid. The SCSI Request Packet was not sent,
                                      so no additional status information is available.
    @retval EFI_UNSUPPORTED           The command described by the SCSI Request Packet
                                      is not supported by the host adapter. The SCSI
                                      Request Packet was not sent, so no additional
                                      status information is available.
    @retval EFI_TIMEOUT               A timeout occurred while waiting for the SCSI
                                      Request Packet to execute. See HostAdapterStatus,
                                      TargetStatus, SenseDataLength, and SenseData in
                                      that order for additional status information.

  **/
  public readonly delegate* unmanaged<EFI_SCSI_PASS_THRU_PROTOCOL*, uint, ulong, EFI_SCSI_PASS_THRU_SCSI_REQUEST_PACKET*, EFI_EVENT, EFI_STATUS> PassThru;
  /**
    Used to retrieve the list of legal Target IDs for SCSI devices
    on a SCSI channel.

    @param  This   Protocol instance pointer.
    @param  Target On input, a pointer to the Target ID of a
                   SCSI device present on the SCSI channel.
                   On output, a pointer to the Target ID of
                   the next SCSI device present on a SCSI channel.
                   An input value of 0xFFFFFFFF retrieves the
                   Target ID of the first SCSI device present on
                   a SCSI channel.
    @param  Lun    On input, a pointer to the LUN of a SCSI device
                   present on the SCSI channel. On output, a pointer
                   to the LUN of the next SCSI device present on a
                   SCSI channel.

    @retval EFI_SUCCESS           The Target ID of the next SCSI device on the SCSI
                                  channel was returned in Target and Lun.
    @retval EFI_NOT_FOUND         There are no more SCSI devices on this SCSI channel.
    @retval EFI_INVALID_PARAMETER Target is not 0xFFFFFFFF, and Target and Lun were
                                   not returned on a previous call to GetNextDevice().

  **/
  public readonly delegate* unmanaged<EFI_SCSI_PASS_THRU_PROTOCOL*, uint*, ulong*, EFI_STATUS> GetNextDevice;
  /**
    Used to allocate and build a device path node for a SCSI device
    on a SCSI channel.

    @param  This       Protocol instance pointer.
    @param  Target     The Target ID of the SCSI device for which
                       a device path node is to be allocated and built.
    @param  Lun        The LUN of the SCSI device for which a device
                       path node is to be allocated and built.
    @param  DevicePath A pointer to a single device path node that
                       describes the SCSI device specified by
                       Target and Lun. This function is responsible
                       for allocating the buffer DevicePath with the boot
                       service AllocatePool().  It is the caller's
                       responsibility to free DevicePath when the caller
                       is finished with DevicePath.

    @retval EFI_SUCCESS           The device path node that describes the SCSI device
                                  specified by Target and Lun was allocated and
                                  returned in DevicePath.
    @retval EFI_NOT_FOUND         The SCSI devices specified by Target and Lun does
                                  not exist on the SCSI channel.
    @retval EFI_INVALID_PARAMETER DevicePath is NULL.
    @retval EFI_OUT_OF_RESOURCES  There are not enough resources to allocate
                                  DevicePath.

  **/
  public readonly delegate* unmanaged<EFI_SCSI_PASS_THRU_PROTOCOL*, uint, ulong, EFI_DEVICE_PATH_PROTOCOL**, EFI_STATUS> BuildDevicePath;
  /**
    Used to translate a device path node to a Target ID and LUN.

    @param  This       Protocol instance pointer.
    @param  DevicePath A pointer to the device path node that
                       describes a SCSI device on the SCSI channel.
    @param  Target     A pointer to the Target ID of a SCSI device
                       on the SCSI channel.
    @param  Lun        A pointer to the LUN of a SCSI device on
                       the SCSI channel.

    @retval EFI_SUCCESS           DevicePath was successfully translated to a
                                  Target ID and LUN, and they were returned
                                  in Target and Lun.
    @retval EFI_INVALID_PARAMETER DevicePath is NULL.
    @retval EFI_INVALID_PARAMETER Target is NULL.
    @retval EFI_INVALID_PARAMETER Lun is NULL.
    @retval EFI_UNSUPPORTED       This driver does not support the device path
                                  node type in DevicePath.
    @retval EFI_NOT_FOUND         A valid translation from DevicePath to a
                                  Target ID and LUN does not exist.

  **/
  public readonly delegate* unmanaged<EFI_SCSI_PASS_THRU_PROTOCOL*, EFI_DEVICE_PATH_PROTOCOL*, uint*, ulong*, EFI_STATUS> GetTargetLun;
  /**
    Resets a SCSI channel.This operation resets all the
    SCSI devices connected to the SCSI channel.

    @param  This Protocol instance pointer.

    @retval EFI_SUCCESS      The SCSI channel was reset.
    @retval EFI_UNSUPPORTED  The SCSI channel does not support
                             a channel reset operation.
    @retval EFI_DEVICE_ERROR A device error occurred while
                             attempting to reset the SCSI channel.
    @retval EFI_TIMEOUT      A timeout occurred while attempting
                             to reset the SCSI channel.

  **/
  public readonly delegate* unmanaged<EFI_SCSI_PASS_THRU_PROTOCOL*, EFI_STATUS> ResetChannel;
  /**
    Resets a SCSI device that is connected to a SCSI channel.

    @param  This   Protocol instance pointer.
    @param  Target The Target ID of the SCSI device to reset.
    @param  Lun    The LUN of the SCSI device to reset.

    @retval EFI_SUCCESS           The SCSI device specified by Target and
                                  Lun was reset.
    @retval EFI_UNSUPPORTED       The SCSI channel does not support a target
                                  reset operation.
    @retval EFI_INVALID_PARAMETER Target or Lun are invalid.
    @retval EFI_DEVICE_ERROR      A device error occurred while attempting
                                  to reset the SCSI device specified by Target
                                  and Lun.
    @retval EFI_TIMEOUT           A timeout occurred while attempting to reset
                                  the SCSI device specified by Target and Lun.

  **/
  public readonly delegate* unmanaged<EFI_SCSI_PASS_THRU_PROTOCOL*, uint, ulong, EFI_STATUS> ResetTarget;
}

// extern EFI_GUID  gEfiScsiPassThruProtocolGuid;

// #endif
