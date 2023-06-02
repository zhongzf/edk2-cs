namespace Uefi;
/** @file
  The file lists the PCI class codes only defined in PCI code and ID assignment specification
  revision 1.3.

  Copyright (c) 2012 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __PCI_CODE_ID_H__
// #define __PCI_CODE_ID_H__

///
/// PCI_CLASS_MASS_STORAGE, Base Class 01h.
///
///@{
public unsafe partial class EFI
{
  public const ulong PCI_IF_MASS_STORAGE_SCSI_VENDOR_SPECIFIC = 0x00;
  public const ulong PCI_IF_MASS_STORAGE_SCSI_DEVICE_PQI = 0x11;
  public const ulong PCI_IF_MASS_STORAGE_SCSI_CONTROLLER_PQI = 0x12;
  public const ulong PCI_IF_MASS_STORAGE_SCSI_DEVICE_CONTROLLER_PQI = 0x13;
  public const ulong PCI_IF_MASS_STORAGE_SCSI_DEVICE_NVM_EXPRESS = 0x21;
  public const ulong PCI_IF_MASS_STORAGE_SATA_SERIAL_BUS = 0x02;
  public const ulong PCI_CLASS_MASS_STORAGE_SAS = 0x07;
  public const ulong PCI_IF_MASS_STORAGE_SAS = 0x00;
  public const ulong PCI_IF_MASS_STORAGE_SAS_SERIAL_BUS = 0x01;
  public const ulong PCI_CLASS_MASS_STORAGE_SOLID_STATE = 0x08;
  public const ulong PCI_IF_MASS_STORAGE_SOLID_STATE = 0x00;
  public const ulong PCI_IF_MASS_STORAGE_SOLID_STATE_NVMHCI = 0x01;
  public const ulong PCI_IF_MASS_STORAGE_SOLID_STATE_ENTERPRISE_NVMHCI = 0x02;
  ///@}

  ///
  /// PCI_CLASS_NETWORK, Base Class 02h.
  ///
  ///@{
  public const ulong PCI_CLASS_NETWORK_INFINIBAND = 0x07;
  ///@}

  ///
  /// PCI_CLASS_MEDIA, Base Class 04h.
  ///
  ///@{
  public const ulong PCI_CLASS_MEDIA_MIXED_MODE = 0x03;
  ///@}

  ///
  /// PCI_CLASS_BRIDGE, Base Class 06h.
  ///
  ///@{
  public const ulong PCI_CLASS_BRIDGE_ADVANCED_SWITCHING_TO_PCI = 0x0B;
  public const ulong PCI_IF_BRIDGE_ADVANCED_SWITCHING_TO_PCI_CUSTOM = 0x00;
  public const ulong PCI_IF_BRIDGE_ADVANCED_SWITCHING_TO_PCI_ASI_SIG = 0x01;
  ///@}

  ///
  /// PCI_CLASS_SYSTEM_PERIPHERAL, Base Class 08h.
  ///
  ///@{
  public const ulong PCI_IF_HPET = 0x03;
  public const ulong PCI_SUBCLASS_SD_HOST_CONTROLLER = 0x05;
  public const ulong PCI_SUBCLASS_IOMMU = 0x06;
  ///@}

  ///
  /// PCI_CLASS_PROCESSOR, Base Class 0Bh.
  ///
  ///@{
  public const ulong PCI_SUBCLASS_PROC_OTHER = 0x80;
  ///@}

  ///
  /// PCI_CLASS_SERIAL, Base Class 0Ch.
  ///
  ///@{
  public const ulong PCI_IF_XHCI = 0x30;
  public const ulong PCI_CLASS_SERIAL_OTHER = 0x80;
  ///@}

  ///
  /// PCI_CLASS_SATELLITE, Base Class 0Fh.
  ///
  ///@{
  public const ulong PCI_SUBCLASS_SATELLITE_OTHER = 0x80;
  ///@}

  ///
  /// PCI_CLASS_PROCESSING_ACCELERATOR, Base Class 12h.
  ///
  ///@{
  public const ulong PCI_CLASS_PROCESSING_ACCELERATOR = 0x12;
  ///@}
}

// #endif
