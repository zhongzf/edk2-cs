using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Service Processor Management Interface (SPMI) ACPI table definition from
  Intelligent Platform Management Interface Specification Second Generation.

  Copyright (c) 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
    - Intelligent Platform Management Interface Specification Second Generation
      v2.0 Revision 1.1, Dated October 2013.
      https://www.intel.com/content/dam/www/public/us/en/documents/specification-updates/ipmi-intelligent-platform-mgt-interface-spec-2nd-gen-v2-0-spec-update.pdf
**/

// #ifndef _SERVICE_PROCESSOR_MANAGEMENT_INTERFACE_TABLE_H_
// #define _SERVICE_PROCESSOR_MANAGEMENT_INTERFACE_TABLE_H_

// #include <IndustryStandard/Acpi.h>

// #pragma pack(1)

///
/// Definition for the device identification information used by the Service
/// Processor Management Interface Description Table
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_ACPI_SERVICE_PROCESSOR_MANAGEMENT_INTERFACE_TABLE_DEVICE_ID
{
  ///
  /// For PCI IPMI device
  ///
  /*   struct { */
  [FieldOffset(0)] public byte SegmentGroup;
  [FieldOffset(0)] public byte Bus;
  [FieldOffset(0)] public byte Device;
  [FieldOffset(0)] public byte Function;
  /*   } Pci; */
  ///
  /// For non-PCI IPMI device, the ACPI _UID value of the device
  ///
  [FieldOffset(0)] public uint Uid;
}

///
/// Definition for Service Processor Management Interface Description Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_ACPI_SERVICE_PROCESSOR_MANAGEMENT_INTERFACE_TABLE
{
  public EFI_ACPI_DESCRIPTION_HEADER Header;
  ///
  /// Indicates the type of IPMI interface.
  ///
  public byte InterfaceType;
  ///
  /// This field must always be 01h to be compatible with any software that
  /// implements previous versions of this spec.
  ///
  public byte Reserved1;
  ///
  /// Identifies the IPMI specification revision, in BCD format.
  ///
  public ushort SpecificationRevision;
  ///
  /// Interrupt type(s) used by the interface.
  ///
  public byte InterruptType;
  ///
  /// The bit assignment of the SCI interrupt within the GPEx_STS register of a
  /// GPE described if the FADT that the interface triggers.
  ///
  public byte Gpe;
  ///
  /// Reserved, must be 00h.
  ///
  public byte Reserved2;
  ///
  /// PCI Device Flag.
  ///
  public byte PciDeviceFlag;
  ///
  /// The I/O APIC or I/O SAPIC Global System Interrupt used by the interface.
  ///
  public uint GlobalSystemInterrupt;
  ///
  /// The base address of the interface register set described using the
  /// Generic Address Structure (GAS, See [ACPI 2.0] for the definition).
  ///
  public EFI_ACPI_2_0_GENERIC_ADDRESS_STRUCTURE BaseAddress;
  ///
  /// Device identification information.
  ///
  public EFI_ACPI_SERVICE_PROCESSOR_MANAGEMENT_INTERFACE_TABLE_DEVICE_ID DeviceId;
  ///
  /// This field must always be null (0x00) to be compatible with any software
  /// that implements previous versions of this spec.
  ///
  public byte Reserved3;
}

// #pragma pack()

// #endif
