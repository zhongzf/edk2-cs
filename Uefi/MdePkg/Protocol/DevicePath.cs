using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  The device path protocol as defined in UEFI 2.0.

  The device path represents a programmatic path to a device,
  from a software point of view. The path must persist from boot to boot, so
  it can not contain things like PCI bus numbers that change from boot to boot.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __EFI_DEVICE_PATH_PROTOCOL_H__
// #define __EFI_DEVICE_PATH_PROTOCOL_H__

// #include <Guid/PcAnsi.h>
// #include <IndustryStandard/Bluetooth.h>
// #include <IndustryStandard/Acpi60.h>

public unsafe partial class EFI
{
  ///
  /// Device Path protocol.
  ///
  public static EFI_GUID EFI_DEVICE_PATH_PROTOCOL_GUID = new GUID(
      0x9576e91, 0x6d3f, 0x11d2, new byte[] { 0x8e, 0x39, 0x0, 0xa0, 0xc9, 0x69, 0x72, 0x3b });

  ///
  /// Device Path guid definition for backward-compatible with EFI1.1.
  ///
  public const ulong DEVICE_PATH_PROTOCOL = EFI_DEVICE_PATH_PROTOCOL_GUID;

  // #pragma pack(1)
}

/**
  This protocol can be used on any device handle to obtain generic path/location
  information concerning the physical device or logical device. If the handle does
  not logically map to a physical device, the handle may not necessarily support
  the device path protocol. The device path describes the location of the device
  the handle is for. The size of the Device Path can be determined from the structures
  that make up the Device Path.
**/
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEVICE_PATH_PROTOCOL
{
  public byte Type;    ///< 0x01 Hardware Device Path.
                       ///< 0x02 ACPI Device Path.
                       ///< 0x03 Messaging Device Path.
                       ///< 0x04 Media Device Path.
                       ///< 0x05 BIOS Boot Specification Device Path.
                       ///< 0x7F End of Hardware Device Path.

  public byte SubType; ///< Varies by Type
                       ///< 0xFF End Entire Device Path, or
                       ///< 0x01 End This Instance of a Device Path and start a new
                       ///< Device Path.

  public fixed byte Length[2]; ///< Specific Device Path data. Type and Sub-Type define
                               ///< type of data. Size of data is included in Length.
}

///
/// Device Path protocol definition for backward-compatible with EFI1.1.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEVICE_PATH { EFI_DEVICE_PATH_PROTOCOL Value; public static implicit operator EFI_DEVICE_PATH(EFI_DEVICE_PATH_PROTOCOL value) => new EFI_DEVICE_PATH() { Value = value }; public static implicit operator EFI_DEVICE_PATH_PROTOCOL(EFI_DEVICE_PATH value) => value.Value; }

public unsafe partial class EFI
{
  ///
  /// Hardware Device Paths.
  ///
  public const ulong HARDWARE_DEVICE_PATH = 0x01;

  ///
  /// PCI Device Path SubType.
  ///
  public const ulong HW_PCI_DP = 0x01;
}

///
/// PCI Device Path.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// PCI Function Number.
  ///
  public byte Function;
  ///
  /// PCI Device Number.
  ///
  public byte Device;
}

public unsafe partial class EFI
{
  ///
  /// PCCARD Device Path SubType.
  ///
  public const ulong HW_PCCARD_DP = 0x02;
}

///
/// PCCARD Device Path.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCCARD_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Function Number (0 = First Function).
  ///
  public byte FunctionNumber;
}

public unsafe partial class EFI
{
  ///
  /// Memory Mapped Device Path SubType.
  ///
  public const ulong HW_MEMMAP_DP = 0x03;
}

///
/// Memory Mapped Device Path.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEMMAP_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// EFI_MEMORY_TYPE
  ///
  public uint MemoryType;
  ///
  /// Starting Memory Address.
  ///
  public EFI_PHYSICAL_ADDRESS StartingAddress;
  ///
  /// Ending Memory Address.
  ///
  public EFI_PHYSICAL_ADDRESS EndingAddress;
}

public unsafe partial class EFI
{
  ///
  /// Hardware Vendor Device Path SubType.
  ///
  public const ulong HW_VENDOR_DP = 0x04;
}

///
/// The Vendor Device Path allows the creation of vendor-defined Device Paths. A vendor must
/// allocate a Vendor GUID for a Device Path. The Vendor GUID can then be used to define the
/// contents on the n bytes that follow in the Vendor Device Path node.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct VENDOR_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Vendor-assigned GUID that defines the data that follows.
  ///
  public EFI_GUID Guid;
  ///
  /// Vendor-defined variable size data.
  ///
}

public unsafe partial class EFI
{
  ///
  /// Controller Device Path SubType.
  ///
  public const ulong HW_CONTROLLER_DP = 0x05;
}

///
/// Controller Device Path.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CONTROLLER_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Controller number.
  ///
  public uint ControllerNumber;
}

public unsafe partial class EFI
{
  ///
  /// BMC Device Path SubType.
  ///
  public const ulong HW_BMC_DP = 0x06;
}

///
/// BMC Device Path.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BMC_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Interface Type.
  ///
  public byte InterfaceType;
  ///
  /// Base Address.
  ///
  public fixed byte BaseAddress[8];
}

public unsafe partial class EFI
{
  ///
  /// ACPI Device Paths.
  ///
  public const ulong ACPI_DEVICE_PATH = 0x02;
}

///
/// ACPI Device Path SubType.
///
public const ulong ACPI_DP = 0x01;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ACPI_HID_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Device's PnP hardware ID stored in a numeric 32-bit
  /// compressed EISA-type ID. This value must match the
  /// corresponding _HID in the ACPI name space.
  ///
  public uint HID;
  ///
  /// Unique ID that is required by ACPI if two devices have the
  /// same _HID. This value must also match the corresponding
  /// _UID/_HID pair in the ACPI name space. Only the 32-bit
  /// numeric value type of _UID is supported. Thus, strings must
  /// not be used for the _UID in the ACPI name space.
  ///
  public uint UID;
}

public unsafe partial class EFI
{
  ///
  /// Expanded ACPI Device Path SubType.
  ///
  public const ulong ACPI_EXTENDED_DP = 0x02;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ACPI_EXTENDED_HID_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Device's PnP hardware ID stored in a numeric 32-bit
  /// compressed EISA-type ID. This value must match the
  /// corresponding _HID in the ACPI name space.
  ///
  public uint HID;
  ///
  /// Unique ID that is required by ACPI if two devices have the
  /// same _HID. This value must also match the corresponding
  /// _UID/_HID pair in the ACPI name space.
  ///
  public uint UID;
  ///
  /// Device's compatible PnP hardware ID stored in a numeric
  /// 32-bit compressed EISA-type ID. This value must match at
  /// least one of the compatible device IDs returned by the
  /// corresponding _CID in the ACPI name space.
  ///
  public uint CID;
  ///
  /// Optional variable length _HIDSTR.
  /// Optional variable length _UIDSTR.
  /// Optional variable length _CIDSTR.
  ///
}

public unsafe partial class EFI
{
  //
  //  EISA ID Macro
  //  EISA ID Definition 32-bits
  //   bits[15:0] - three character compressed ASCII EISA ID.
  //   bits[31:16] - binary number
  //    Compressed ASCII is 5 bits per character 0b00001 = 'A' 0b11010 = 'Z'
  //
  public const ulong PNP_EISA_ID_CONST = 0x41d0;
  public const ulong EISA_ID = (_Name, _Num)((uint)((_Name) | (_Num) << 16));
  public const ulong EISA_PNP_ID = (_PNPId)(EISA_ID(PNP_EISA_ID_CONST, (_PNPId)));
  public const ulong EFI_PNP_ID = (_PNPId)(EISA_ID(PNP_EISA_ID_CONST, (_PNPId)));

  public const ulong PNP_EISA_ID_MASK = 0xffff;
  public const ulong EISA_ID_TO_NUM = (_Id)((_Id) >> 16);

  ///
  /// ACPI _ADR Device Path SubType.
  ///
  public const ulong ACPI_ADR_DP = 0x03;
}

///
/// The _ADR device path is used to contain video output device attributes to support the Graphics
/// Output Protocol. The device path can contain multiple _ADR entries if multiple video output
/// devices are displaying the same output.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ACPI_ADR_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// _ADR value. For video output devices the value of this
  /// field comes from Table B-2 of the ACPI 3.0 specification. At
  /// least one _ADR value is required.
  ///
  public uint ADR;
  //
  // This device path may optionally contain more than one _ADR entry.
  //
}

public unsafe partial class EFI
{
  ///
  /// ACPI NVDIMM Device Path SubType.
  ///
  public const ulong ACPI_NVDIMM_DP = 0x04;
  ///
  ///
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ACPI_NVDIMM_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// NFIT Device Handle, the _ADR of the NVDIMM device.
  /// The value of this field comes from Section 9.20.3 of the ACPI 6.2A specification.
  ///
  public uint NFITDeviceHandle;
}

public unsafe partial class EFI
{
  public const ulong ACPI_ADR_DISPLAY_TYPE_OTHER = 0;
  public const ulong ACPI_ADR_DISPLAY_TYPE_VGA = 1;
  public const ulong ACPI_ADR_DISPLAY_TYPE_TV = 2;
  public const ulong ACPI_ADR_DISPLAY_TYPE_EXTERNAL_DIGITAL = 3;
  public const ulong ACPI_ADR_DISPLAY_TYPE_INTERNAL_DIGITAL = 4;

  public const ulong ACPI_DISPLAY_ADR = (_DeviceIdScheme, _HeadId, _NonVgaOutput, _BiosCanDetect, _VendorInfo, _Type, _Port, _Index) \;
  ((uint)(((uint)((_DeviceIdScheme) & 0x1) << 31) |  \
                      (((_HeadId)                 & 0x7) << 18) |  \
                      (((_NonVgaOutput)           & 0x1) << 17) |  \
                      (((_BiosCanDetect)          & 0x1) << 16) |  \
                      (((_VendorInfo)             & 0xf) << 12) |  \
                      (((_Type)                   & 0xf) << 8)  |  \
                      (((_Port)                   & 0xf) << 4)  |  \
                       ((_Index)                  & 0xf) ))

///
/// Messaging Device Paths.
/// This Device Path is used to describe the connection of devices outside the resource domain of the
/// system. This Device Path can describe physical messaging information like SCSI ID, or abstract
/// information like networking protocol IP addresses.
///
public const ulong MESSAGING_DEVICE_PATH = 0x03;
}

///
/// ATAPI Device Path SubType
///
public const ulong MSG_ATAPI_DP = 0x01;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Set to zero for primary, or one for secondary.
  ///
  public byte PrimarySecondary;
  ///
  /// Set to zero for master, or one for slave mode.
  ///
  public byte SlaveMaster;
  ///
  /// Logical Unit Number.
  ///
  public ushort Lun;
}

public unsafe partial class EFI
{
  ///
  /// SCSI Device Path SubType.
  ///
  public const ulong MSG_SCSI_DP = 0x02;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SCSI_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Target ID on the SCSI bus (PUN).
  ///
  public ushort Pun;
  ///
  /// Logical Unit Number (LUN).
  ///
  public ushort Lun;
}

public unsafe partial class EFI
{
  ///
  /// Fibre Channel SubType.
  ///
  public const ulong MSG_FIBRECHANNEL_DP = 0x03;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct FIBRECHANNEL_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Reserved for the future.
  ///
  public uint Reserved;
  ///
  /// Fibre Channel World Wide Number.
  ///
  public ulong WWN;
  ///
  /// Fibre Channel Logical Unit Number.
  ///
  public ulong Lun;
}

public unsafe partial class EFI
{
  ///
  /// Fibre Channel Ex SubType.
  ///
  public const ulong MSG_FIBRECHANNELEX_DP = 0x15;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct FIBRECHANNELEX_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Reserved for the future.
  ///
  public uint Reserved;
  ///
  /// 8 byte array containing Fibre Channel End Device Port Name.
  ///
  public fixed byte WWN[8];
  ///
  /// 8 byte array containing Fibre Channel Logical Unit Number.
  ///
  public fixed byte Lun[8];
}

public unsafe partial class EFI
{
  ///
  /// 1394 Device Path SubType
  ///
  public const ulong MSG_1394_DP = 0x04;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct F1394_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Reserved for the future.
  ///
  public uint Reserved;
  ///
  /// 1394 Global Unique ID (GUID).
  ///
  public ulong Guid;
}

public unsafe partial class EFI
{
  ///
  /// USB Device Path SubType.
  ///
  public const ulong MSG_USB_DP = 0x05;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct USB_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// USB Parent Port Number.
  ///
  public byte ParentPortNumber;
  ///
  /// USB Interface Number.
  ///
  public byte InterfaceNumber;
}

public unsafe partial class EFI
{
  ///
  /// USB Class Device Path SubType.
  ///
  public const ulong MSG_USB_CLASS_DP = 0x0f;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct USB_CLASS_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Vendor ID assigned by USB-IF. A value of 0xFFFF will
  /// match any Vendor ID.
  ///
  public ushort VendorId;
  ///
  /// Product ID assigned by USB-IF. A value of 0xFFFF will
  /// match any Product ID.
  ///
  public ushort ProductId;
  ///
  /// The class code assigned by the USB-IF. A value of 0xFF
  /// will match any class code.
  ///
  public byte DeviceClass;
  ///
  /// The subclass code assigned by the USB-IF. A value of
  /// 0xFF will match any subclass code.
  ///
  public byte DeviceSubClass;
  ///
  /// The protocol code assigned by the USB-IF. A value of
  /// 0xFF will match any protocol code.
  ///
  public byte DeviceProtocol;
}

public unsafe partial class EFI
{
  ///
  /// USB WWID Device Path SubType.
  ///
  public const ulong MSG_USB_WWID_DP = 0x10;
}

///
/// This device path describes a USB device using its serial number.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct USB_WWID_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// USB interface number.
  ///
  public ushort InterfaceNumber;
  ///
  /// USB vendor id of the device.
  ///
  public ushort VendorId;
  ///
  /// USB product id of the device.
  ///
  public ushort ProductId;
  ///
  /// Last 64-or-fewer UTF-16 characters of the USB
  /// serial number. The length of the string is
  /// determined by the Length field less the offset of the
  /// Serial Number field (10)
  ///
  /// char                     SerialNumber[...];
}

public unsafe partial class EFI
{
  ///
  /// Device Logical Unit SubType.
  ///
  public const ulong MSG_DEVICE_LOGICAL_UNIT_DP = 0x11;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct DEVICE_LOGICAL_UNIT_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Logical Unit Number for the interface.
  ///
  public byte Lun;
}

public unsafe partial class EFI
{
  ///
  /// SATA Device Path SubType.
  ///
  public const ulong MSG_SATA_DP = 0x12;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SATA_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// The HBA port number that facilitates the connection to the
  /// device or a port multiplier. The value 0xFFFF is reserved.
  ///
  public ushort HBAPortNumber;
  ///
  /// The Port multiplier port number that facilitates the connection
  /// to the device. Must be set to 0xFFFF if the device is directly
  /// connected to the HBA.
  ///
  public ushort PortMultiplierPortNumber;
  ///
  /// Logical Unit Number.
  ///
  public ushort Lun;
}

public unsafe partial class EFI
{
  ///
  /// Flag for if the device is directly connected to the HBA.
  ///
  public const ulong SATA_HBA_DIRECT_CONNECT_FLAG = 0x8000;
}

///
/// I2O Device Path SubType.
///
public const ulong MSG_I2O_DP = 0x06;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct I2O_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Target ID (TID) for a device.
  ///
  public uint Tid;
}

public unsafe partial class EFI
{
  ///
  /// MAC Address Device Path SubType.
  ///
  public const ulong MSG_MAC_ADDR_DP = 0x0b;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MAC_ADDR_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// The MAC address for a network interface padded with 0s.
  ///
  public EFI_MAC_ADDRESS MacAddress;
  ///
  /// Network interface type(i.e. 802.3, FDDI).
  ///
  public byte IfType;
}

public unsafe partial class EFI
{
  ///
  /// IPv4 Device Path SubType
  ///
  public const ulong MSG_IPv4_DP = 0x0c;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPv4_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// The local IPv4 address.
  ///
  public EFI_IPv4_ADDRESS LocalIpAddress;
  ///
  /// The remote IPv4 address.
  ///
  public EFI_IPv4_ADDRESS RemoteIpAddress;
  ///
  /// The local port number.
  ///
  public ushort LocalPort;
  ///
  /// The remote port number.
  ///
  public ushort RemotePort;
  ///
  /// The network protocol(i.e. UDP, TCP).
  ///
  public ushort Protocol;
  ///
  /// 0x00 - The Source IP Address was assigned though DHCP.
  /// 0x01 - The Source IP Address is statically bound.
  ///
  public bool StaticIpAddress;
  ///
  /// The gateway IP address
  ///
  public EFI_IPv4_ADDRESS GatewayIpAddress;
  ///
  /// The subnet mask
  ///
  public EFI_IPv4_ADDRESS SubnetMask;
}

public unsafe partial class EFI
{
  ///
  /// IPv6 Device Path SubType.
  ///
  public const ulong MSG_IPv6_DP = 0x0d;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPv6_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// The local IPv6 address.
  ///
  public EFI_IPv6_ADDRESS LocalIpAddress;
  ///
  /// The remote IPv6 address.
  ///
  public EFI_IPv6_ADDRESS RemoteIpAddress;
  ///
  /// The local port number.
  ///
  public ushort LocalPort;
  ///
  /// The remote port number.
  ///
  public ushort RemotePort;
  ///
  /// The network protocol(i.e. UDP, TCP).
  ///
  public ushort Protocol;
  ///
  /// 0x00 - The Local IP Address was manually configured.
  /// 0x01 - The Local IP Address is assigned through IPv6
  /// stateless auto-configuration.
  /// 0x02 - The Local IP Address is assigned through IPv6
  /// stateful configuration.
  ///
  public byte IpAddressOrigin;
  ///
  /// The prefix length
  ///
  public byte PrefixLength;
  ///
  /// The gateway IP address
  ///
  public EFI_IPv6_ADDRESS GatewayIpAddress;
}

public unsafe partial class EFI
{
  ///
  /// InfiniBand Device Path SubType.
  ///
  public const ulong MSG_INFINIBAND_DP = 0x09;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct INFINIBAND_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Flags to help identify/manage InfiniBand device path elements:
  /// Bit 0 - IOC/Service (0b = IOC, 1b = Service).
  /// Bit 1 - Extend Boot Environment.
  /// Bit 2 - Console Protocol.
  /// Bit 3 - Storage Protocol.
  /// Bit 4 - Network Protocol.
  /// All other bits are reserved.
  ///
  public uint ResourceFlags;
  ///
  /// 128-bit Global Identifier for remote fabric port.
  ///
  public fixed byte PortGid[16];
  ///
  /// 64-bit unique identifier to remote IOC or server process.
  /// Interpretation of field specified by Resource Flags (bit 0).
  ///
  public ulong ServiceId;
  ///
  /// 64-bit persistent ID of remote IOC port.
  ///
  public ulong TargetPortId;
  ///
  /// 64-bit persistent ID of remote device.
  ///
  public ulong DeviceId;
}

public unsafe partial class EFI
{
  public const ulong INFINIBAND_RESOURCE_FLAG_IOC_SERVICE = 0x01;
  public const ulong INFINIBAND_RESOURCE_FLAG_EXTENDED_BOOT_ENVIRONMENT = 0x02;
  public const ulong INFINIBAND_RESOURCE_FLAG_CONSOLE_PROTOCOL = 0x04;
  public const ulong INFINIBAND_RESOURCE_FLAG_STORAGE_PROTOCOL = 0x08;
  public const ulong INFINIBAND_RESOURCE_FLAG_NETWORK_PROTOCOL = 0x10;
}

///
/// UART Device Path SubType.
///
public const ulong MSG_UART_DP = 0x0e;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct UART_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Reserved.
  ///
  public uint Reserved;
  ///
  /// The baud rate setting for the UART style device. A value of 0
  /// means that the device's default baud rate will be used.
  ///
  public ulong BaudRate;
  ///
  /// The number of data bits for the UART style device. A value
  /// of 0 means that the device's default number of data bits will be used.
  ///
  public byte DataBits;
  ///
  /// The parity setting for the UART style device.
  /// Parity 0x00 - Default Parity.
  /// Parity 0x01 - No Parity.
  /// Parity 0x02 - Even Parity.
  /// Parity 0x03 - Odd Parity.
  /// Parity 0x04 - Mark Parity.
  /// Parity 0x05 - Space Parity.
  ///
  public byte Parity;
  ///
  /// The number of stop bits for the UART style device.
  /// Stop Bits 0x00 - Default Stop Bits.
  /// Stop Bits 0x01 - 1 Stop Bit.
  /// Stop Bits 0x02 - 1.5 Stop Bits.
  /// Stop Bits 0x03 - 2 Stop Bits.
  ///
  public byte StopBits;
}

public unsafe partial class EFI
{
  ///
  /// NVDIMM Namespace Device Path SubType.
  ///
  public const ulong NVDIMM_NAMESPACE_DP = 0x20;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVDIMM_NAMESPACE_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Namespace unique label identifier UUID.
  ///
  public EFI_GUID Uuid;
}

public unsafe partial class EFI
{
  //
  // Use VENDOR_DEVICE_PATH struct
  //
  public const ulong MSG_VENDOR_DP = 0x0a;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct VENDOR_DEFINED_DEVICE_PATH { VENDOR_DEVICE_PATH Value; public static implicit operator VENDOR_DEFINED_DEVICE_PATH(VENDOR_DEVICE_PATH value) => new VENDOR_DEFINED_DEVICE_PATH() { Value = value }; public static implicit operator VENDOR_DEVICE_PATH(VENDOR_DEFINED_DEVICE_PATH value) => value.Value; }

public unsafe partial class EFI
{
  public const ulong DEVICE_PATH_MESSAGING_PC_ANSI = EFI_PC_ANSI_GUID;
  public const ulong DEVICE_PATH_MESSAGING_VT_100 = EFI_VT_100_GUID;
  public const ulong DEVICE_PATH_MESSAGING_VT_100_PLUS = EFI_VT_100_PLUS_GUID;
  public const ulong DEVICE_PATH_MESSAGING_VT_UTF8 = EFI_VT_UTF8_GUID;
}

///
/// A new device path node is defined to declare flow control characteristics.
/// UART Flow Control Messaging Device Path
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct UART_FLOW_CONTROL_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// DEVICE_PATH_MESSAGING_UART_FLOW_CONTROL GUID.
  ///
  public EFI_GUID Guid;
  ///
  /// Bitmap of supported flow control types.
  /// Bit 0 set indicates hardware flow control.
  /// Bit 1 set indicates Xon/Xoff flow control.
  /// All other bits are reserved and are clear.
  ///
  public uint FlowControlMap;
}

public unsafe partial class EFI
{
  public const ulong UART_FLOW_CONTROL_HARDWARE = 0x00000001;
  public const ulong UART_FLOW_CONTROL_XON_XOFF = 0x00000010;
}

public const ulong DEVICE_PATH_MESSAGING_SAS = EFI_SAS_DEVICE_PATH_GUID;
///
/// Serial Attached SCSI (SAS) Device Path.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SAS_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// DEVICE_PATH_MESSAGING_SAS GUID.
  ///
  public EFI_GUID Guid;
  ///
  /// Reserved for future use.
  ///
  public uint Reserved;
  ///
  /// SAS Address for Serial Attached SCSI Target.
  ///
  public ulong SasAddress;
  ///
  /// SAS Logical Unit Number.
  ///
  public ulong Lun;
  ///
  /// More Information about the device and its interconnect.
  ///
  public ushort DeviceTopology;
  ///
  /// Relative Target Port (RTP).
  ///
  public ushort RelativeTargetPort;
}

public unsafe partial class EFI
{
  ///
  /// Serial Attached SCSI (SAS) Ex Device Path SubType
  ///
  public const ulong MSG_SASEX_DP = 0x16;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SASEX_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// 8-byte array of the SAS Address for Serial Attached SCSI Target Port.
  ///
  public fixed byte SasAddress[8];
  ///
  /// 8-byte array of the SAS Logical Unit Number.
  ///
  public fixed byte Lun[8];
  ///
  /// More Information about the device and its interconnect.
  ///
  public ushort DeviceTopology;
  ///
  /// Relative Target Port (RTP).
  ///
  public ushort RelativeTargetPort;
}

public unsafe partial class EFI
{
  ///
  /// NvmExpress Namespace Device Path SubType.
  ///
  public const ulong MSG_NVME_NAMESPACE_DP = 0x17;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NVME_NAMESPACE_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  public uint NamespaceId;
  public ulong NamespaceUuid;
}

public unsafe partial class EFI
{
  ///
  /// DNS Device Path SubType
  ///
  public const ulong MSG_DNS_DP = 0x1F;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct DNS_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Indicates the DNS server address is IPv4 or IPv6 address.
  ///
  public byte IsIPv6;
  ///
  /// Instance of the DNS server address.
  ///
  public fixed EFI_IP_ADDRESS DnsServerIp[];
}

public unsafe partial class EFI
{
  ///
  /// Uniform Resource Identifiers (URI) Device Path SubType
  ///
  public const ulong MSG_URI_DP = 0x18;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct URI_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Instance of the URI pursuant to RFC 3986.
  ///
  public fixed byte Uri[];
}

public unsafe partial class EFI
{
  ///
  /// Universal Flash Storage (UFS) Device Path SubType.
  ///
  public const ulong MSG_UFS_DP = 0x19;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct UFS_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Target ID on the UFS bus (PUN).
  ///
  public byte Pun;
  ///
  /// Logical Unit Number (LUN).
  ///
  public byte Lun;
}

public unsafe partial class EFI
{
  ///
  /// SD (Secure Digital) Device Path SubType.
  ///
  public const ulong MSG_SD_DP = 0x1A;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SD_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  public byte SlotNumber;
}

public unsafe partial class EFI
{
  ///
  /// EMMC (Embedded MMC) Device Path SubType.
  ///
  public const ulong MSG_EMMC_DP = 0x1D;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EMMC_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  public byte SlotNumber;
}

public unsafe partial class EFI
{
  ///
  /// iSCSI Device Path SubType
  ///
  public const ulong MSG_ISCSI_DP = 0x13;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ISCSI_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Network Protocol (0 = TCP, 1+ = reserved).
  ///
  public ushort NetworkProtocol;
  ///
  /// iSCSI Login Options.
  ///
  public ushort LoginOption;
  ///
  /// iSCSI Logical Unit Number.
  ///
  public ulong Lun;
  ///
  /// iSCSI Target Portal group tag the initiator intends
  /// to establish a session with.
  ///
  public ushort TargetPortalGroupTag;
  ///
  /// iSCSI NodeTarget Name. The length of the name
  /// is determined by subtracting the offset of this field from Length.
  ///
  /// byte                        iSCSI Target Name.
}

public unsafe partial class EFI
{
  public const ulong ISCSI_LOGIN_OPTION_NO_HEADER_DIGEST = 0x0000;
  public const ulong ISCSI_LOGIN_OPTION_HEADER_DIGEST_USING_CRC32C = 0x0002;
  public const ulong ISCSI_LOGIN_OPTION_NO_DATA_DIGEST = 0x0000;
  public const ulong ISCSI_LOGIN_OPTION_DATA_DIGEST_USING_CRC32C = 0x0008;
  public const ulong ISCSI_LOGIN_OPTION_AUTHMETHOD_CHAP = 0x0000;
  public const ulong ISCSI_LOGIN_OPTION_AUTHMETHOD_NON = 0x1000;
  public const ulong ISCSI_LOGIN_OPTION_CHAP_BI = 0x0000;
  public const ulong ISCSI_LOGIN_OPTION_CHAP_UNI = 0x2000;
}

///
/// VLAN Device Path SubType.
///
public const ulong MSG_VLAN_DP = 0x14;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct VLAN_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// VLAN identifier (0-4094).
  ///
  public ushort VlanId;
}

public unsafe partial class EFI
{
  ///
  /// Bluetooth Device Path SubType.
  ///
  public const ulong MSG_BLUETOOTH_DP = 0x1b;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BLUETOOTH_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// 48bit Bluetooth device address.
  ///
  public BLUETOOTH_ADDRESS BD_ADDR;
}

public unsafe partial class EFI
{
  ///
  /// Wi-Fi Device Path SubType.
  ///
  public const ulong MSG_WIFI_DP = 0x1C;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct WIFI_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Service set identifier. A 32-byte octets string.
  ///
  public fixed byte SSId[32];
}

public unsafe partial class EFI
{
  ///
  /// Bluetooth LE Device Path SubType.
  ///
  public const ulong MSG_BLUETOOTH_LE_DP = 0x1E;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BLUETOOTH_LE_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  public BLUETOOTH_LE_ADDRESS Address;
}

public unsafe partial class EFI
{
  //
  // Media Device Path
  //
  public const ulong MEDIA_DEVICE_PATH = 0x04;

  ///
  /// Hard Drive Media Device Path SubType.
  ///
  public const ulong MEDIA_HARDDRIVE_DP = 0x01;
}

///
/// The Hard Drive Media Device Path is used to represent a partition on a hard drive.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct HARDDRIVE_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Describes the entry in a partition table, starting with entry 1.
  /// Partition number zero represents the entire device. Valid
  /// partition numbers for a MBR partition are [1, 4]. Valid
  /// partition numbers for a GPT partition are [1, NumberOfPartitionEntries].
  ///
  public uint PartitionNumber;
  ///
  /// Starting LBA of the partition on the hard drive.
  ///
  public ulong PartitionStart;
  ///
  /// Size of the partition in units of Logical Blocks.
  ///
  public ulong PartitionSize;
  ///
  /// Signature unique to this partition:
  /// If SignatureType is 0, this field has to be initialized with 16 zeros.
  /// If SignatureType is 1, the MBR signature is stored in the first 4 bytes of this field.
  /// The other 12 bytes are initialized with zeros.
  /// If SignatureType is 2, this field contains a 16 byte signature.
  ///
  public fixed byte Signature[16];
  ///
  /// Partition Format: (Unused values reserved).
  /// 0x01 - PC-AT compatible legacy MBR.
  /// 0x02 - GUID Partition Table.
  ///
  public byte MBRType;
  ///
  /// Type of Disk Signature: (Unused values reserved).
  /// 0x00 - No Disk Signature.
  /// 0x01 - 32-bit signature from address 0x1b8 of the type 0x01 MBR.
  /// 0x02 - GUID signature.
  ///
  public byte SignatureType;
}

public unsafe partial class EFI
{
  public const ulong MBR_TYPE_PCAT = 0x01;
  public const ulong MBR_TYPE_EFI_PARTITION_TABLE_HEADER = 0x02;

  public const ulong NO_DISK_SIGNATURE = 0x00;
  public const ulong SIGNATURE_TYPE_MBR = 0x01;
  public const ulong SIGNATURE_TYPE_GUID = 0x02;

  ///
  /// CD-ROM Media Device Path SubType.
  ///
  public const ulong MEDIA_CDROM_DP = 0x02;
}

///
/// The CD-ROM Media Device Path is used to define a system partition that exists on a CD-ROM.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CDROM_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Boot Entry number from the Boot Catalog. The Initial/Default entry is defined as zero.
  ///
  public uint BootEntry;
  ///
  /// Starting RBA of the partition on the medium. CD-ROMs use Relative logical Block Addressing.
  ///
  public ulong PartitionStart;
  ///
  /// Size of the partition in units of Blocks, also called Sectors.
  ///
  public ulong PartitionSize;
}

public unsafe partial class EFI
{
  //
  // Use VENDOR_DEVICE_PATH struct
  //
  public const ulong MEDIA_VENDOR_DP = 0x03           ///< Media vendor device path subtype.;
}

///
/// File Path Media Device Path SubType
///
public const ulong MEDIA_FILEPATH_DP = 0x04;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct FILEPATH_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// A NULL-terminated Path string including directory and file names.
  ///
  public fixed char PathName[1];
}

public unsafe partial class EFI
{
  public const ulong SIZE_OF_FILEPATH_DEVICE_PATH = OFFSET_OF(FILEPATH_DEVICE_PATH, PathName);

  ///
  /// Media Protocol Device Path SubType.
  ///
  public const ulong MEDIA_PROTOCOL_DP = 0x05;
}

///
/// The Media Protocol Device Path is used to denote the protocol that is being
/// used in a device path at the location of the path specified.
/// Many protocols are inherent to the style of device path.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEDIA_PROTOCOL_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// The ID of the protocol.
  ///
  public EFI_GUID Protocol;
}

public unsafe partial class EFI
{
  ///
  /// PIWG Firmware File SubType.
  ///
  public const ulong MEDIA_PIWG_FW_FILE_DP = 0x06;
}

///
/// This device path is used by systems implementing the UEFI PI Specification 1.0 to describe a firmware file.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEDIA_FW_VOL_FILEPATH_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Firmware file name
  ///
  public EFI_GUID FvFileName;
}

public unsafe partial class EFI
{
  ///
  /// PIWG Firmware Volume Device Path SubType.
  ///
  public const ulong MEDIA_PIWG_FW_VOL_DP = 0x07;
}

///
/// This device path is used by systems implementing the UEFI PI Specification 1.0 to describe a firmware volume.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEDIA_FW_VOL_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Firmware volume name.
  ///
  public EFI_GUID FvName;
}

public unsafe partial class EFI
{
  ///
  /// Media relative offset range device path.
  ///
  public const ulong MEDIA_RELATIVE_OFFSET_RANGE_DP = 0x08;
}

///
/// Used to describe the offset range of media relative.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEDIA_RELATIVE_OFFSET_RANGE_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  public uint Reserved;
  public ulong StartingOffset;
  public ulong EndingOffset;
}

public unsafe partial class EFI
{
  ///
  /// This GUID defines a RAM Disk supporting a raw disk format in volatile memory.
  ///
  public const ulong EFI_VIRTUAL_DISK_GUID = EFI_ACPI_6_0_NFIT_GUID_RAM_DISK_SUPPORTING_VIRTUAL_DISK_REGION_VOLATILE;

  // extern  EFI_GUID  gEfiVirtualDiskGuid;

  ///
  /// This GUID defines a RAM Disk supporting an ISO image in volatile memory.
  ///
  public const ulong EFI_VIRTUAL_CD_GUID = EFI_ACPI_6_0_NFIT_GUID_RAM_DISK_SUPPORTING_VIRTUAL_CD_REGION_VOLATILE;

  // extern  EFI_GUID  gEfiVirtualCdGuid;

  ///
  /// This GUID defines a RAM Disk supporting a raw disk format in persistent memory.
  ///
  public const ulong EFI_PERSISTENT_VIRTUAL_DISK_GUID = EFI_ACPI_6_0_NFIT_GUID_RAM_DISK_SUPPORTING_VIRTUAL_DISK_REGION_PERSISTENT;

  // extern  EFI_GUID  gEfiPersistentVirtualDiskGuid;

  ///
  /// This GUID defines a RAM Disk supporting an ISO image in persistent memory.
  ///
  public const ulong EFI_PERSISTENT_VIRTUAL_CD_GUID = EFI_ACPI_6_0_NFIT_GUID_RAM_DISK_SUPPORTING_VIRTUAL_CD_REGION_PERSISTENT;

  // extern  EFI_GUID  gEfiPersistentVirtualCdGuid;

  ///
  /// Media ram disk device path.
  ///
  public const ulong MEDIA_RAM_DISK_DP = 0x09;
}

///
/// Used to describe the ram disk device path.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MEDIA_RAM_DISK_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Starting Memory Address.
  ///
  public fixed uint StartingAddr[2];
  ///
  /// Ending Memory Address.
  ///
  public fixed uint EndingAddr[2];
  ///
  /// GUID that defines the type of the RAM Disk.
  ///
  public EFI_GUID TypeGuid;
  ///
  /// RAM Diskinstance number, if supported. The default value is zero.
  ///
  public ushort Instance;
}

public unsafe partial class EFI
{
  ///
  /// BIOS Boot Specification Device Path.
  ///
  public const ulong BBS_DEVICE_PATH = 0x05;

  ///
  /// BIOS Boot Specification Device Path SubType.
  ///
  public const ulong BBS_BBS_DP = 0x01;
}

///
/// This Device Path is used to describe the booting of non-EFI-aware operating systems.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BBS_BBS_DEVICE_PATH
{
  public EFI_DEVICE_PATH_PROTOCOL Header;
  ///
  /// Device Type as defined by the BIOS Boot Specification.
  ///
  public ushort DeviceType;
  ///
  /// Status Flags as defined by the BIOS Boot Specification.
  ///
  public ushort StatusFlag;
  ///
  /// Null-terminated ASCII string that describes the boot device to a user.
  ///
  public fixed byte String[1];
}

public unsafe partial class EFI
{
  //
  // DeviceType definitions - from BBS specification
  //
  public const ulong BBS_TYPE_FLOPPY = 0x01;
  public const ulong BBS_TYPE_HARDDRIVE = 0x02;
  public const ulong BBS_TYPE_CDROM = 0x03;
  public const ulong BBS_TYPE_PCMCIA = 0x04;
  public const ulong BBS_TYPE_USB = 0x05;
  public const ulong BBS_TYPE_EMBEDDED_NETWORK = 0x06;
  public const ulong BBS_TYPE_BEV = 0x80;
  public const ulong BBS_TYPE_UNKNOWN = 0xFF;
}

///
/// Union of all possible Device Paths and pointers to Device Paths.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_DEV_PATH
{
  [FieldOffset(0)] public EFI_DEVICE_PATH_PROTOCOL DevPath;
  [FieldOffset(0)] public PCI_DEVICE_PATH Pci;
  [FieldOffset(0)] public PCCARD_DEVICE_PATH PcCard;
  [FieldOffset(0)] public MEMMAP_DEVICE_PATH MemMap;
  [FieldOffset(0)] public VENDOR_DEVICE_PATH Vendor;

  [FieldOffset(0)] public CONTROLLER_DEVICE_PATH Controller;
  [FieldOffset(0)] public BMC_DEVICE_PATH Bmc;
  [FieldOffset(0)] public ACPI_HID_DEVICE_PATH Acpi;
  [FieldOffset(0)] public ACPI_EXTENDED_HID_DEVICE_PATH ExtendedAcpi;
  [FieldOffset(0)] public ACPI_ADR_DEVICE_PATH AcpiAdr;

  [FieldOffset(0)] public ATAPI_DEVICE_PATH Atapi;
  [FieldOffset(0)] public SCSI_DEVICE_PATH Scsi;
  ISCSI_DEVICE_PATH Iscsi;
  [FieldOffset(0)] public FIBRECHANNEL_DEVICE_PATH FibreChannel;
  [FieldOffset(0)] public FIBRECHANNELEX_DEVICE_PATH FibreChannelEx;

  [FieldOffset(0)] public F1394_DEVICE_PATH F1394;
  USB_DEVICE_PATH Usb;
  [FieldOffset(0)] public SATA_DEVICE_PATH Sata;
  USB_CLASS_DEVICE_PATH UsbClass;
  USB_WWID_DEVICE_PATH UsbWwid;
  [FieldOffset(0)] public DEVICE_LOGICAL_UNIT_DEVICE_PATH LogicUnit;
  I2O_DEVICE_PATH I2O;
  [FieldOffset(0)] public MAC_ADDR_DEVICE_PATH MacAddr;
  IPv4_DEVICE_PATH Ipv4;
  IPv6_DEVICE_PATH Ipv6;
  [FieldOffset(0)] public VLAN_DEVICE_PATH Vlan;
  INFINIBAND_DEVICE_PATH InfiniBand;
  UART_DEVICE_PATH Uart;
  UART_FLOW_CONTROL_DEVICE_PATH UartFlowControl;
  [FieldOffset(0)] public SAS_DEVICE_PATH Sas;
  [FieldOffset(0)] public SASEX_DEVICE_PATH SasEx;
  NVME_NAMESPACE_DEVICE_PATH NvmeNamespace;
  [FieldOffset(0)] public DNS_DEVICE_PATH Dns;
  URI_DEVICE_PATH Uri;
  [FieldOffset(0)] public BLUETOOTH_DEVICE_PATH Bluetooth;
  [FieldOffset(0)] public WIFI_DEVICE_PATH WiFi;
  UFS_DEVICE_PATH Ufs;
  [FieldOffset(0)] public SD_DEVICE_PATH Sd;
  [FieldOffset(0)] public EMMC_DEVICE_PATH Emmc;
  [FieldOffset(0)] public HARDDRIVE_DEVICE_PATH HardDrive;
  [FieldOffset(0)] public CDROM_DEVICE_PATH CD;

  [FieldOffset(0)] public FILEPATH_DEVICE_PATH FilePath;
  [FieldOffset(0)] public MEDIA_PROTOCOL_DEVICE_PATH MediaProtocol;

  [FieldOffset(0)] public MEDIA_FW_VOL_DEVICE_PATH FirmwareVolume;
  [FieldOffset(0)] public MEDIA_FW_VOL_FILEPATH_DEVICE_PATH FirmwareFile;
  [FieldOffset(0)] public MEDIA_RELATIVE_OFFSET_RANGE_DEVICE_PATH Offset;
  [FieldOffset(0)] public MEDIA_RAM_DISK_DEVICE_PATH RamDisk;
  [FieldOffset(0)] public BBS_BBS_DEVICE_PATH Bbs;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_DEV_PATH_PTR
{
  [FieldOffset(0)] public EFI_DEVICE_PATH_PROTOCOL* DevPath;
  [FieldOffset(0)] public PCI_DEVICE_PATH* Pci;
  [FieldOffset(0)] public PCCARD_DEVICE_PATH* PcCard;
  [FieldOffset(0)] public MEMMAP_DEVICE_PATH* MemMap;
  [FieldOffset(0)] public VENDOR_DEVICE_PATH* Vendor;

  [FieldOffset(0)] public CONTROLLER_DEVICE_PATH* Controller;
  [FieldOffset(0)] public BMC_DEVICE_PATH* Bmc;
  [FieldOffset(0)] public ACPI_HID_DEVICE_PATH* Acpi;
  [FieldOffset(0)] public ACPI_EXTENDED_HID_DEVICE_PATH* ExtendedAcpi;
  [FieldOffset(0)] public ACPI_ADR_DEVICE_PATH* AcpiAdr;

  [FieldOffset(0)] public ATAPI_DEVICE_PATH* Atapi;
  [FieldOffset(0)] public SCSI_DEVICE_PATH* Scsi;
  ISCSI_DEVICE_PATH* Iscsi;
  [FieldOffset(0)] public FIBRECHANNEL_DEVICE_PATH* FibreChannel;
  [FieldOffset(0)] public FIBRECHANNELEX_DEVICE_PATH* FibreChannelEx;

  [FieldOffset(0)] public F1394_DEVICE_PATH* F1394;
  USB_DEVICE_PATH* Usb;
  [FieldOffset(0)] public SATA_DEVICE_PATH* Sata;
  USB_CLASS_DEVICE_PATH* UsbClass;
  USB_WWID_DEVICE_PATH* UsbWwid;
  [FieldOffset(0)] public DEVICE_LOGICAL_UNIT_DEVICE_PATH* LogicUnit;
  I2O_DEVICE_PATH* I2O;
  [FieldOffset(0)] public MAC_ADDR_DEVICE_PATH* MacAddr;
  IPv4_DEVICE_PATH* Ipv4;
  IPv6_DEVICE_PATH* Ipv6;
  [FieldOffset(0)] public VLAN_DEVICE_PATH* Vlan;
  INFINIBAND_DEVICE_PATH* InfiniBand;
  UART_DEVICE_PATH* Uart;
  UART_FLOW_CONTROL_DEVICE_PATH* UartFlowControl;
  [FieldOffset(0)] public SAS_DEVICE_PATH* Sas;
  [FieldOffset(0)] public SASEX_DEVICE_PATH* SasEx;
  NVME_NAMESPACE_DEVICE_PATH* NvmeNamespace;
  [FieldOffset(0)] public DNS_DEVICE_PATH* Dns;
  URI_DEVICE_PATH* Uri;
  [FieldOffset(0)] public BLUETOOTH_DEVICE_PATH* Bluetooth;
  [FieldOffset(0)] public WIFI_DEVICE_PATH* WiFi;
  UFS_DEVICE_PATH* Ufs;
  [FieldOffset(0)] public SD_DEVICE_PATH* Sd;
  [FieldOffset(0)] public EMMC_DEVICE_PATH* Emmc;
  [FieldOffset(0)] public HARDDRIVE_DEVICE_PATH* HardDrive;
  [FieldOffset(0)] public CDROM_DEVICE_PATH* CD;

  [FieldOffset(0)] public FILEPATH_DEVICE_PATH* FilePath;
  [FieldOffset(0)] public MEDIA_PROTOCOL_DEVICE_PATH* MediaProtocol;

  [FieldOffset(0)] public MEDIA_FW_VOL_DEVICE_PATH* FirmwareVolume;
  [FieldOffset(0)] public MEDIA_FW_VOL_FILEPATH_DEVICE_PATH* FirmwareFile;
  [FieldOffset(0)] public MEDIA_RELATIVE_OFFSET_RANGE_DEVICE_PATH* Offset;
  [FieldOffset(0)] public MEDIA_RAM_DISK_DEVICE_PATH* RamDisk;
  [FieldOffset(0)] public BBS_BBS_DEVICE_PATH* Bbs;
  [FieldOffset(0)] public byte* Raw;
}

// #pragma pack()

public unsafe partial class EFI
{
  public const ulong END_DEVICE_PATH_TYPE = 0x7f;
  public const ulong END_ENTIRE_DEVICE_PATH_SUBTYPE = 0xFF;
  public const ulong END_INSTANCE_DEVICE_PATH_SUBTYPE = 0x01;

  // extern EFI_GUID  gEfiDevicePathProtocolGuid;
}

// #endif
