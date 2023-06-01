namespace Uefi;
/** @file
  The EFI_SD_MMC_PASS_THRU_PROTOCOL provides the ability to send SD/MMC Commands
  to any SD/MMC device attached to the SD compatible pci host controller.

  Copyright (c) 2015, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SD_MMC_PASS_THRU_H__
// #define __SD_MMC_PASS_THRU_H__

public static EFI_GUID EFI_SD_MMC_PASS_THRU_PROTOCOL_GUID = new GUID(
    0x716ef0d9, 0xff83, 0x4f69, new byte[] { 0x81, 0xe9, 0x51, 0x8b, 0xd3, 0x9a, 0x8e, 0x70 });

// typedef struct _EFI_SD_MMC_PASS_THRU_PROTOCOL EFI_SD_MMC_PASS_THRU_PROTOCOL;

public enum EFI_SD_MMC_COMMAND_TYPE
{
  SdMmcCommandTypeBc,  // Broadcast commands, no response
  SdMmcCommandTypeBcr, // Broadcast commands with response
  SdMmcCommandTypeAc,  // Addressed(point-to-point) commands
  SdMmcCommandTypeAdtc // Addressed(point-to-point) data transfer commands
}

public enum EFI_SD_MMC_RESPONSE_TYPE
{
  SdMmcResponseTypeR1,
  SdMmcResponseTypeR1b,
  SdMmcResponseTypeR2,
  SdMmcResponseTypeR3,
  SdMmcResponseTypeR4,
  SdMmcResponseTypeR5,
  SdMmcResponseTypeR5b,
  SdMmcResponseTypeR6,
  SdMmcResponseTypeR7
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SD_MMC_COMMAND_BLOCK
{
  public ushort CommandIndex;
  public uint CommandArgument;
  public uint CommandType;                              // One of the EFI_SD_MMC_COMMAND_TYPE values
  public uint ResponseType;                             // One of the EFI_SD_MMC_RESPONSE_TYPE values
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SD_MMC_STATUS_BLOCK
{
  public uint Resp0;
  public uint Resp1;
  public uint Resp2;
  public uint Resp3;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SD_MMC_PASS_THRU_COMMAND_PACKET
{
  public ulong Timeout;
  public EFI_SD_MMC_COMMAND_BLOCK* SdMmcCmdBlk;
  public EFI_SD_MMC_STATUS_BLOCK* SdMmcStatusBlk;
  public void* InDataBuffer;
  public void* OutDataBuffer;
  public uint InTransferLength;
  public uint OutTransferLength;
  public EFI_STATUS TransactionStatus;
}
























































































































































































[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SD_MMC_PASS_THRU_PROTOCOL
{
  public uint IoAlign;
  /**
    Sends SD command to an SD card that is attached to the SD controller.

    The PassThru() function sends the SD command specified by Packet to the SD card
    specified by Slot.

    If Packet is successfully sent to the SD card, then EFI_SUCCESS is returned.

    If a device error occurs while sending the Packet, then EFI_DEVICE_ERROR is returned.

    If Slot is not in a valid range for the SD controller, then EFI_INVALID_PARAMETER
    is returned.

    If Packet defines a data command but both InDataBuffer and OutDataBuffer are NULL,
    EFI_INVALID_PARAMETER is returned.

    @param[in]     This           A pointer to the EFI_SD_MMC_PASS_THRU_PROTOCOL instance.
    @param[in]     Slot           The slot number of the SD card to send the command to.
    @param[in,out] Packet         A pointer to the SD command data structure.
    @param[in]     Event          If Event is NULL, blocking I/O is performed. If Event is
                                  not NULL, then nonblocking I/O is performed, and Event
                                  will be signaled when the Packet completes.

    @retval EFI_SUCCESS           The SD Command Packet was sent by the host.
    @retval EFI_DEVICE_ERROR      A device error occurred while attempting to send the SD
                                  command Packet.
    @retval EFI_INVALID_PARAMETER Packet, Slot, or the contents of the Packet is invalid.
    @retval EFI_INVALID_PARAMETER Packet defines a data command but both InDataBuffer and
                                  OutDataBuffer are NULL.
    @retval EFI_NO_MEDIA          SD Device not present in the Slot.
    @retval EFI_UNSUPPORTED       The command described by the SD Command Packet is not
                                  supported by the host controller.
    @retval EFI_BAD_BUFFER_SIZE   The InTransferLength or OutTransferLength exceeds the
                                  limit supported by SD card ( i.e. if the number of bytes
                                  exceed the Last LBA).

  **/
  public readonly delegate* unmanaged<EFI_SD_MMC_PASS_THRU_PROTOCOL*, byte, EFI_SD_MMC_PASS_THRU_COMMAND_PACKET*, EFI_EVENT, EFI_STATUS> PassThru;
  /**
    Used to retrieve next slot numbers supported by the SD controller. The function
    returns information about all available slots (populated or not-populated).

    The GetNextSlot() function retrieves the next slot number on an SD controller.
    If on input Slot is 0xFF, then the slot number of the first slot on the SD controller
    is returned.

    If Slot is a slot number that was returned on a previous call to GetNextSlot(), then
    the slot number of the next slot on the SD controller is returned.

    If Slot is not 0xFF and Slot was not returned on a previous call to GetNextSlot(),
    EFI_INVALID_PARAMETER is returned.

    If Slot is the slot number of the last slot on the SD controller, then EFI_NOT_FOUND
    is returned.

    @param[in]     This           A pointer to the EFI_SD_MMMC_PASS_THRU_PROTOCOL instance.
    @param[in,out] Slot           On input, a pointer to a slot number on the SD controller.
                                  On output, a pointer to the next slot number on the SD controller.
                                  An input value of 0xFF retrieves the first slot number on the SD
                                  controller.

    @retval EFI_SUCCESS           The next slot number on the SD controller was returned in Slot.
    @retval EFI_NOT_FOUND         There are no more slots on this SD controller.
    @retval EFI_INVALID_PARAMETER Slot is not 0xFF and Slot was not returned on a previous call
                                  to GetNextSlot().

  **/
  public readonly delegate* unmanaged<EFI_SD_MMC_PASS_THRU_PROTOCOL*, byte*, EFI_STATUS> GetNextSlot;
  /**
    Used to allocate and build a device path node for an SD card on the SD controller.

    The BuildDevicePath() function allocates and builds a single device node for the SD
    card specified by Slot.

    If the SD card specified by Slot is not present on the SD controller, then EFI_NOT_FOUND
    is returned.

    If DevicePath is NULL, then EFI_INVALID_PARAMETER is returned.

    If there are not enough resources to allocate the device path node, then EFI_OUT_OF_RESOURCES
    is returned.

    Otherwise, DevicePath is allocated with the boot service AllocatePool(), the contents of
    DevicePath are initialized to describe the SD card specified by Slot, and EFI_SUCCESS is
    returned.

    @param[in]     This           A pointer to the EFI_SD_MMMC_PASS_THRU_PROTOCOL instance.
    @param[in]     Slot           Specifies the slot number of the SD card for which a device
                                  path node is to be allocated and built.
    @param[out]    DevicePath     A pointer to a single device path node that describes the SD
                                  card specified by Slot. This function is responsible for
                                  allocating the buffer DevicePath with the boot service
                                  AllocatePool(). It is the caller's responsibility to free
                                  DevicePath when the caller is finished with DevicePath.

    @retval EFI_SUCCESS           The device path node that describes the SD card specified by
                                  Slot was allocated and returned in DevicePath.
    @retval EFI_NOT_FOUND         The SD card specified by Slot does not exist on the SD controller.
    @retval EFI_INVALID_PARAMETER DevicePath is NULL.
    @retval EFI_OUT_OF_RESOURCES  There are not enough resources to allocate DevicePath.

  **/
  public readonly delegate* unmanaged<EFI_SD_MMC_PASS_THRU_PROTOCOL*, byte, EFI_DEVICE_PATH_PROTOCOL**, EFI_STATUS> BuildDevicePath;
  /**
    This function retrieves an SD card slot number based on the input device path.

    The GetSlotNumber() function retrieves slot number for the SD card specified by
    the DevicePath node. If DevicePath is NULL, EFI_INVALID_PARAMETER is returned.

    If DevicePath is not a device path node type that the SD Pass Thru driver supports,
    EFI_UNSUPPORTED is returned.

    @param[in]  This              A pointer to the EFI_SD_MMC_PASS_THRU_PROTOCOL instance.
    @param[in]  DevicePath        A pointer to the device path node that describes a SD
                                  card on the SD controller.
    @param[out] Slot              On return, points to the slot number of an SD card on
                                  the SD controller.

    @retval EFI_SUCCESS           SD card slot number is returned in Slot.
    @retval EFI_INVALID_PARAMETER Slot or DevicePath is NULL.
    @retval EFI_UNSUPPORTED       DevicePath is not a device path node type that the SD
                                  Pass Thru driver supports.

  **/
  public readonly delegate* unmanaged<EFI_SD_MMC_PASS_THRU_PROTOCOL*, EFI_DEVICE_PATH_PROTOCOL*, byte*, EFI_STATUS> GetSlotNumber;
  /**
    Resets an SD card that is connected to the SD controller.

    The ResetDevice() function resets the SD card specified by Slot.

    If this SD controller does not support a device reset operation, EFI_UNSUPPORTED is
    returned.

    If Slot is not in a valid slot number for this SD controller, EFI_INVALID_PARAMETER
    is returned.

    If the device reset operation is completed, EFI_SUCCESS is returned.

    @param[in]  This              A pointer to the EFI_SD_MMC_PASS_THRU_PROTOCOL instance.
    @param[in]  Slot              Specifies the slot number of the SD card to be reset.

    @retval EFI_SUCCESS           The SD card specified by Slot was reset.
    @retval EFI_UNSUPPORTED       The SD controller does not support a device reset operation.
    @retval EFI_INVALID_PARAMETER Slot number is invalid.
    @retval EFI_NO_MEDIA          SD Device not present in the Slot.
    @retval EFI_DEVICE_ERROR      The reset command failed due to a device error

  **/
  public readonly delegate* unmanaged<EFI_SD_MMC_PASS_THRU_PROTOCOL*, byte, EFI_STATUS> ResetDevice;
}

// extern EFI_GUID  gEfiSdMmcPassThruProtocolGuid;

// #endif
