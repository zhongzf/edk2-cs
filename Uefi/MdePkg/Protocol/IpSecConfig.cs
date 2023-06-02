using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI IPsec Configuration Protocol Definition
  The EFI_IPSEC_CONFIG_PROTOCOL provides the mechanism to set and retrieve security and
  policy related information for the EFI IPsec protocol driver.

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.2

**/

// #ifndef __EFI_IPSE_CCONFIG_PROTOCOL_H__
// #define __EFI_IPSE_CCONFIG_PROTOCOL_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_IPSEC_CONFIG_PROTOCOL_GUID = new GUID(
      0xce5e5929, 0xc7a3, 0x4602, new byte[] { 0xad, 0x9e, 0xc9, 0xda, 0xf9, 0x4e, 0xbf, 0xcf });

  // typedef struct _EFI_IPSEC_CONFIG_PROTOCOL EFI_IPSEC_CONFIG_PROTOCOL;
}

///
/// EFI_IPSEC_CONFIG_DATA_TYPE
///
public enum EFI_IPSEC_CONFIG_DATA_TYPE
{
  ///
  /// The IPsec Security Policy Database (aka SPD) setting.  In IPsec,
  /// an essential element of Security Association (SA) processing is
  /// underlying SPD that specifies what services are to be offered to
  /// IP datagram and in what fashion. The SPD must be consulted
  /// during the processing of all traffic (inbound and outbound),
  /// including traffic not protected by IPsec, that traverses the IPsec
  /// boundary. With this DataType, SetData() function is to set
  /// the SPD entry information, which may add one new entry, delete
  /// one existed entry or flush the whole database according to the
  /// parameter values. The corresponding Data is of type
  /// EFI_IPSEC_SPD_DATA
  ///
  IPsecConfigDataTypeSpd,
  ///
  /// The IPsec Security Association Database (aka SAD) setting. A
  /// SA is a simplex connection that affords security services to the
  /// traffic carried by it. Security services are afforded to an SA by the
  /// use of AH, or ESP, but not both. The corresponding Data is of
  /// type EFI_IPSEC_SAD_DATA.
  ///
  IPsecConfigDataTypeSad,
  ///
  /// The IPsec Peer Authorization Database (aka PAD) setting, which
  /// provides the link between the SPD and a security association
  /// management protocol. The PAD entry specifies the
  /// authentication protocol (e.g. IKEv1, IKEv2) method used and the
  /// authentication data. The corresponding Data is of type
  /// EFI_IPSEC_PAD_DATA.
  ///
  IPsecConfigDataTypePad,
  IPsecConfigDataTypeMaximum
}

///
/// EFI_IP_ADDRESS_INFO
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IP_ADDRESS_INFO
{
  public EFI_IP_ADDRESS Address;      ///< The IPv4 or IPv6 address
  public byte PrefixLength; ///< The length of the prefix associated with the Address.
}

///
/// EFI_IPSEC_SPD_SELECTOR
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_SPD_SELECTOR
{
  ///
  /// Specifies the actual number of entries in LocalAddress.
  ///
  public uint LocalAddressCount;
  ///
  /// A list of ranges of IPv4 or IPv6 addresses, which refers to the
  /// addresses being protected by IPsec policy.
  ///
  public EFI_IP_ADDRESS_INFO* LocalAddress;
  ///
  /// Specifies the actual number of entries in RemoteAddress.
  ///
  public uint RemoteAddressCount;
  ///
  /// A list of ranges of IPv4 or IPv6 addresses, which are peer entities
  /// to LocalAddress.
  ///
  public EFI_IP_ADDRESS_INFO* RemoteAddress;
  ///
  /// Next layer protocol. Obtained from the IPv4 Protocol or the IPv6
  /// Next Header fields. The next layer protocol is whatever comes
  /// after any IP extension headers that are present. A zero value is a
  /// wildcard that matches any value in NextLayerProtocol field.
  ///
  public ushort NextLayerProtocol;
  ///
  /// Local Port if the Next Layer Protocol uses two ports (as do TCP,
  /// UDP, and others). A zero value is a wildcard that matches any
  /// value in LocalPort field.
  ///
  public ushort LocalPort;
  ///
  /// A designed port range size. The start port is LocalPort, and
  /// the total number of ports is described by LocalPortRange.
  /// This field is ignored if NextLayerProtocol does not use
  /// ports.
  ///
  public ushort LocalPortRange;
  ///
  /// Remote Port if the Next Layer Protocol uses two ports. A zero
  /// value is a wildcard that matches any value in RemotePort field.
  ///
  public ushort RemotePort;
  ///
  /// A designed port range size. The start port is RemotePort, and
  /// the total number of ports is described by RemotePortRange.
  /// This field is ignored if NextLayerProtocol does not use ports.
  ///
  public ushort RemotePortRange;
}

///
/// EFI_IPSEC_TRAFFIC_DIR
/// represents the directionality in an SPD entry.
///
public enum EFI_IPSEC_TRAFFIC_DIR
{
  ///
  /// The EfiIPsecInBound refers to traffic entering an IPsec implementation via
  /// the unprotected interface or emitted by the implementation on the unprotected
  /// side of the boundary and directed towards the protected interface.
  ///
  EfiIPsecInBound,
  ///
  /// The EfiIPsecOutBound refers to traffic entering the implementation via
  /// the protected interface, or emitted by the implementation on the protected side
  /// of the boundary and directed toward the unprotected interface.
  ///
  EfiIPsecOutBound
}

///
/// EFI_IPSEC_ACTION
/// represents three possible processing choices.
///
public enum EFI_IPSEC_ACTION
{
  ///
  /// Refers to traffic that is not allowed to traverse the IPsec boundary.
  ///
  EfiIPsecActionDiscard,
  ///
  /// Refers to traffic that is allowed to cross the IPsec boundary
  /// without protection.
  ///
  EfiIPsecActionBypass,
  ///
  /// Refers to traffic that is afforded IPsec protection, and for such
  /// traffic the SPD must specify the security protocols to be
  /// employed, their mode, security service options, and the
  /// cryptographic algorithms to be used.
  ///
  EfiIPsecActionProtect
}

///
/// EFI_IPSEC_SA_LIFETIME
/// defines the lifetime of an SA, which represents when a SA must be
/// replaced or terminated. A value of all 0 for each field removes
/// the limitation of a SA lifetime.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_SA_LIFETIME
{
  ///
  /// The number of bytes to which the IPsec cryptographic algorithm
  /// can be applied. For ESP, this is the encryption algorithm and for
  /// AH, this is the authentication algorithm. The ByteCount
  /// includes pad bytes for cryptographic operations.
  ///
  public ulong ByteCount;
  ///
  /// A time interval in second that warns the implementation to
  /// initiate action such as setting up a replacement SA.
  ///
  public ulong SoftLifetime;
  ///
  /// A time interval in second when the current SA ends and is
  /// destroyed.
  ///
  public ulong HardLifetime;
}

///
/// EFI_IPSEC_MODE
/// There are two modes of IPsec operation: transport mode and tunnel mode. In
/// EfiIPsecTransport mode, AH and ESP provide protection primarily for next layer protocols;
/// In EfiIPsecTunnel mode, AH and ESP are applied to tunneled IP packets.
///
public enum EFI_IPSEC_MODE
{
  EfiIPsecTransport,
  EfiIPsecTunnel
}

///
/// EFI_IPSEC_TUNNEL_DF_OPTION
/// The option of copying the DF bit from an outbound package to
/// the tunnel mode header that it emits, when traffic is carried
/// via a tunnel mode SA. This applies to SAs where both inner and
/// outer headers are IPv4.
///
public enum EFI_IPSEC_TUNNEL_DF_OPTION
{
  EfiIPsecTunnelClearDf,  ///< Clear DF bit from inner header.
  EfiIPsecTunnelSetDf,    ///< Set DF bit from inner header.
  EfiIPsecTunnelCopyDf    ///< Copy DF bit from inner header.
}

///
/// EFI_IPSEC_TUNNEL_OPTION
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_TUNNEL_OPTION
{
  ///
  /// Local tunnel address when IPsec mode is EfiIPsecTunnel.
  ///
  public EFI_IP_ADDRESS LocalTunnelAddress;
  ///
  /// Remote tunnel address when IPsec mode is EfiIPsecTunnel.
  ///
  public EFI_IP_ADDRESS RemoteTunnelAddress;
  ///
  /// The option of copying the DF bit from an outbound package
  /// to the tunnel mode header that it emits, when traffic is
  /// carried via a tunnel mode SA.
  ///
  public EFI_IPSEC_TUNNEL_DF_OPTION DF;
}

///
/// EFI_IPSEC_PROTOCOL_TYPE
///
public enum EFI_IPSEC_PROTOCOL_TYPE
{
  EfiIPsecAH,  ///< IP Authentication Header protocol which is specified in RFC 4302.
  EfiIPsecESP  ///< IP Encapsulating Security Payload which is specified in RFC 4303.
}

///
/// EFI_IPSEC_PROCESS_POLICY
/// describes a policy list for traffic processing.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_PROCESS_POLICY
{
  ///
  /// Extended Sequence Number. Is this SA using extended sequence
  /// numbers. 64 bit counter is used if TRUE.
  ///
  public bool ExtSeqNum;
  ///
  /// A flag indicating whether overflow of the sequence number
  /// counter should generate an auditable event and prevent
  /// transmission of additional packets on the SA, or whether rollover
  /// is permitted.
  ///
  public bool SeqOverflow;
  ///
  /// Is this SA using stateful fragment checking. TRUE represents
  /// stateful fragment checking.
  ///
  public bool FragCheck;
  ///
  /// A time interval after which a SA must be replaced with a new SA
  /// (and new SPI) or terminated.
  ///
  public EFI_IPSEC_SA_LIFETIME SaLifetime;
  ///
  /// IPsec mode: tunnel or transport.
  ///
  public EFI_IPSEC_MODE Mode;
  ///
  /// Tunnel Option. TunnelOption is ignored if Mode is EfiIPsecTransport.
  ///
  public EFI_IPSEC_TUNNEL_OPTION* TunnelOption;
  ///
  /// IPsec protocol: AH or ESP
  ///
  public EFI_IPSEC_PROTOCOL_TYPE Proto;
  ///
  /// Cryptographic algorithm type used for authentication.
  ///
  public byte AuthAlgoId;
  ///
  /// Cryptographic algorithm type used for encryption. EncAlgo is
  /// NULL when IPsec protocol is AH. For ESP protocol, EncAlgo
  /// can also be used to describe the algorithm if a combined mode
  /// algorithm is used.
  ///
  public byte EncAlgoId;
}

///
/// EFI_IPSEC_SA_ID
/// A triplet to identify an SA, consisting of the following members.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_SA_ID
{
  ///
  /// Security Parameter Index (aka SPI).  An arbitrary 32-bit value
  /// that is used by a receiver to identity the SA to which an incoming
  /// package should be bound.
  ///
  public uint Spi;
  ///
  /// IPsec protocol: AH or ESP
  ///
  public EFI_IPSEC_PROTOCOL_TYPE Proto;
  ///
  /// Destination IP address.
  ///
  public EFI_IP_ADDRESS DestAddress;
}

public unsafe partial class EFI
{
  public const ulong MAX_PEERID_LEN = 128;
}

///
/// EFI_IPSEC_SPD_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_SPD_DATA
{
  ///
  /// A null-terminated ASCII name string which is used as a symbolic
  /// identifier for an IPsec Local or Remote address.
  ///
  public fixed byte Name[MAX_PEERID_LEN];
  ///
  /// Bit-mapped list describing Populate from Packet flags. When
  /// creating a SA, if PackageFlag bit is set to TRUE, instantiate
  /// the selector from the corresponding field in the package that
  /// triggered the creation of the SA, else from the value(s) in the
  /// corresponding SPD entry. The PackageFlag bit setting for
  /// corresponding selector field of EFI_IPSEC_SPD_SELECTOR:
  ///     Bit 0: EFI_IPSEC_SPD_SELECTOR.LocalAddress
  ///     Bit 1: EFI_IPSEC_SPD_SELECTOR.RemoteAddress
  ///     Bit 2:
  /// EFI_IPSEC_SPD_SELECTOR.NextLayerProtocol
  ///     Bit 3: EFI_IPSEC_SPD_SELECTOR.LocalPort
  ///     Bit 4: EFI_IPSEC_SPD_SELECTOR.RemotePort
  ///     Others: Reserved.
  ///
  public uint PackageFlag;
  ///
  /// The traffic direction of data gram.
  ///
  public EFI_IPSEC_TRAFFIC_DIR TrafficDirection;
  ///
  /// Processing choices to indicate which action is required by this
  /// policy.
  ///
  public EFI_IPSEC_ACTION Action;
  ///
  /// The policy and rule information for a SPD entry.
  ///
  public EFI_IPSEC_PROCESS_POLICY* ProcessingPolicy;
  ///
  /// Specifies the actual number of entries in SaId list.
  ///
  public ulong SaIdCount;
  ///
  /// The SAD entry used for the traffic processing. The
  /// existed SAD entry links indicate this is the manual key case.
  ///
  public fixed EFI_IPSEC_SA_ID SaId[1];
}

///
/// EFI_IPSEC_AH_ALGO_INFO
/// The security algorithm selection for IPsec AH authentication.
/// The required authentication algorithm is specified in RFC 4305.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_AH_ALGO_INFO
{
  public byte AuthAlgoId;
  public ulong AuthKeyLength;
  public void* AuthKey;
}

///
/// EFI_IPSEC_ESP_ALGO_INFO
/// The security algorithm selection for IPsec ESP encryption and authentication.
/// The required authentication algorithm is specified in RFC 4305.
/// EncAlgoId fields can also specify an ESP combined mode algorithm
/// (e.g. AES with CCM mode, specified in RFC 4309), which provides both
/// confidentiality and authentication services.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_ESP_ALGO_INFO
{
  public byte EncAlgoId;
  public ulong EncKeyLength;
  public void* EncKey;
  public byte AuthAlgoId;
  public ulong AuthKeyLength;
  public void* AuthKey;
}

///
/// EFI_IPSEC_ALGO_INFO
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_IPSEC_ALGO_INFO
{
  [FieldOffset(0)] public EFI_IPSEC_AH_ALGO_INFO AhAlgoInfo;
  [FieldOffset(0)] public EFI_IPSEC_ESP_ALGO_INFO EspAlgoInfo;
}

///
/// EFI_IPSEC_SA_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_SA_DATA
{
  ///
  /// IPsec mode: tunnel or transport.
  ///
  public EFI_IPSEC_MODE Mode;
  ///
  /// Sequence Number Counter. A 64-bit counter used to generate the
  /// sequence number field in AH or ESP headers.
  ///
  public ulong SNCount;
  ///
  /// Anti-Replay Window. A 64-bit counter and a bit-map used to
  /// determine whether an inbound AH or ESP packet is a replay.
  ///
  public byte AntiReplayWindows;
  ///
  /// AH/ESP cryptographic algorithm, key and parameters.
  ///
  public EFI_IPSEC_ALGO_INFO AlgoInfo;
  ///
  /// Lifetime of this SA.
  ///
  public EFI_IPSEC_SA_LIFETIME SaLifetime;
  ///
  /// Any observed path MTU and aging variables. The Path MTU
  /// processing is defined in section 8 of RFC 4301.
  ///
  public uint PathMTU;
  ///
  /// Link to one SPD entry.
  ///
  public EFI_IPSEC_SPD_SELECTOR* SpdSelector;
  ///
  /// Indication of whether it's manually set or negotiated automatically.
  /// If ManualSet is FALSE, the corresponding SA entry is inserted through
  /// IKE protocol negotiation.
  ///
  public bool ManualSet;
}

///
/// EFI_IPSEC_SA_DATA2
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_SA_DATA2
{
  ///
  /// IPsec mode: tunnel or transport
  ///
  public EFI_IPSEC_MODE Mode;
  ///
  /// Sequence Number Counter. A 64-bit counter used to generate the sequence
  /// number field in AH or ESP headers.
  ///
  public ulong SNCount;
  ///
  /// Anti-Replay Window. A 64-bit counter and a bit-map used to determine
  /// whether an inbound AH or ESP packet is a replay.
  ///
  public byte AntiReplayWindows;
  ///
  /// AH/ESP cryptographic algorithm, key and parameters.
  ///
  public EFI_IPSEC_ALGO_INFO AlgoInfo;
  ///
  /// Lifetime of this SA.
  ///
  public EFI_IPSEC_SA_LIFETIME SaLifetime;
  ///
  /// Any observed path MTU and aging variables. The Path MTU processing is
  /// defined in section 8 of RFC 4301.
  ///
  public uint PathMTU;
  ///
  /// Link to one SPD entry
  ///
  public EFI_IPSEC_SPD_SELECTOR* SpdSelector;
  ///
  /// Indication of whether it's manually set or negotiated automatically.
  /// If ManualSet is FALSE, the corresponding SA entry is inserted through IKE
  /// protocol negotiation
  ///
  public bool ManualSet;
  ///
  /// The tunnel header IP source address.
  ///
  public EFI_IP_ADDRESS TunnelSourceAddress;
  ///
  /// The tunnel header IP destination address.
  ///
  public EFI_IP_ADDRESS TunnelDestinationAddress;
}

///
/// EFI_IPSEC_PAD_ID
/// specifies the identifier for PAD entry, which is also used for SPD lookup.
/// IpAddress Pointer to the IPv4 or IPv6 address range.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Id
{
  ///
  /// Flag to identify which type of PAD Id is used.
  ///
  public bool PeerIdValid;
  union {
    ///
    /// Pointer to the IPv4 or IPv6 address range.
    ///
   public EFI_IP_ADDRESS_INFO IpAddress;
  ///
  /// Pointer to a null terminated ASCII string
  /// representing the symbolic names. A PeerId can be a DNS
  /// name, Distinguished Name, RFC 822 email address or Key ID
  /// (specified in section 4.4.3.1 of RFC 4301)
  ///
  public fixed byte PeerId[MAX_PEERID_LEN];
}
} EFI_IPSEC_PAD_ID;

///
/// EFI_IPSEC_CONFIG_SELECTOR
/// describes the expected IPsec configuration data selector
/// of type EFI_IPSEC_CONFIG_DATA_TYPE.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_IPSEC_CONFIG_SELECTOR
{
  [FieldOffset(0)] public EFI_IPSEC_SPD_SELECTOR SpdSelector;
  [FieldOffset(0)] public EFI_IPSEC_SA_ID SaId;
  [FieldOffset(0)] public EFI_IPSEC_PAD_ID PadId;
}

///
/// EFI_IPSEC_AUTH_PROTOCOL_TYPE
/// defines the possible authentication protocol for IPsec
/// security association management.
///
public enum EFI_IPSEC_AUTH_PROTOCOL_TYPE
{
  EfiIPsecAuthProtocolIKEv1,
  EfiIPsecAuthProtocolIKEv2,
  EfiIPsecAuthProtocolMaximum
}

///
/// EFI_IPSEC_AUTH_METHOD
///
public enum EFI_IPSEC_AUTH_METHOD
{
  ///
  /// Using Pre-shared Keys for manual security associations.
  ///
  EfiIPsecAuthMethodPreSharedSecret,
  ///
  /// IKE employs X.509 certificates for SA establishment.
  ///
  EfiIPsecAuthMethodCertificates,
  EfiIPsecAuthMethodMaximum
}

///
/// EFI_IPSEC_PAD_DATA
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_PAD_DATA
{
  ///
  /// Authentication Protocol for IPsec security association  management.
  ///
  public EFI_IPSEC_AUTH_PROTOCOL_TYPE AuthProtocol;
  ///
  /// Authentication method used.
  ///
  public EFI_IPSEC_AUTH_METHOD AuthMethod;
  ///
  /// The IKE ID payload will be used as a symbolic name for SPD
  /// lookup if IkeIdFlag is TRUE. Otherwise, the remote IP
  /// address provided in traffic selector playloads will be used.
  ///
  public bool IkeIdFlag;
  ///
  /// The size of Authentication data buffer, in bytes.
  ///
  public ulong AuthDataSize;
  ///
  /// Buffer for Authentication data, (e.g., the pre-shared secret or the
  /// trust anchor relative to which the peer's certificate will be
  /// validated).
  ///
  public void* AuthData;
  ///
  /// The size of RevocationData, in bytes
  ///
  public ulong RevocationDataSize;
  ///
  /// Pointer to CRL or OCSP data, if certificates are used for
  /// authentication method.
  ///
  public void* RevocationData;
}

///
/// EFI_IPSEC_CONFIG_PROTOCOL
/// provides the ability to set and lookup the IPsec SAD (Security Association Database),
/// SPD (Security Policy Database) data entry and configure the security association
/// management protocol such as IKEv2. This protocol is used as the central
/// repository of any policy-specific configuration for EFI IPsec driver.
/// EFI_IPSEC_CONFIG_PROTOCOL can be bound to both IPv4 and IPv6 stack. User can use this
/// protocol for IPsec configuration in both IPv4 and IPv6 environment.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IPSEC_CONFIG_PROTOCOL
{
  /**
    Set the security association, security policy and peer authorization configuration
    information for the EFI IPsec driver.

    This function is used to set the IPsec configuration information of type DataType for
    the EFI IPsec driver.
    The IPsec configuration data has a unique selector/identifier separately to identify
    a data entry. The selector structure depends on DataType's definition.
    Using SetData() with a Data of NULL causes the IPsec configuration data entry identified
    by DataType and Selector to be deleted.

    @param[in] This               Pointer to the EFI_IPSEC_CONFIG_PROTOCOL instance.
    @param[in] DataType           The type of data to be set.
    @param[in] Selector           Pointer to an entry selector on operated configuration data
                                  specified by DataType. A NULL Selector causes the entire
                                  specified-type configuration information to be flushed.
    @param[in] Data               The data buffer to be set. The structure of the data buffer is
                                  associated with the DataType.
    @param[in] InsertBefore       Pointer to one entry selector which describes the expected
                                  position the new data entry will be added. If InsertBefore is NULL,
                                  the new entry will be appended the end of database.

    @retval EFI_SUCCESS           The specified configuration entry data is set successfully.
    @retval EFI_INVALID_PARAMETER One or more of the following are TRUE:
                                  - This is NULL.
    @retval EFI_UNSUPPORTED       The specified DataType is not supported.
    @retval EFI_OUT_OF_RESOURCED  The required system resource could not be allocated.

  **/
  public readonly delegate* unmanaged<EFI_IPSEC_CONFIG_PROTOCOL*, EFI_IPSEC_CONFIG_DATA_TYPE, EFI_IPSEC_CONFIG_SELECTOR*, void*, EFI_IPSEC_CONFIG_SELECTOR*, EFI_STATUS> SetData;
  /**
    Return the configuration value for the EFI IPsec driver.

    This function lookup the data entry from IPsec database or IKEv2 configuration
    information. The expected data type and unique identification are described in
    DataType and Selector parameters.

    @param[in]      This          Pointer to the EFI_IPSEC_CONFIG_PROTOCOL instance.
    @param[in]      DataType      The type of data to retrieve.
    @param[in]      Selector      Pointer to an entry selector which is an identifier of the IPsec
                                  configuration data entry.
    @param[in, out] DataSize      On output the size of data returned in Data.
    @param[out]     Data          The buffer to return the contents of the IPsec configuration data.
                                  The type of the data buffer is associated with the DataType.

    @retval EFI_SUCCESS           The specified configuration data is got successfully.
    @retval EFI_INVALID_PARAMETER One or more of the followings are TRUE:
                                  - This is NULL.
                                  - Selector is NULL.
                                  - DataSize is NULL.
                                  - Data is NULL and *DataSize is not zero
    @retval EFI_NOT_FOUND         The configuration data specified by Selector is not found.
    @retval EFI_UNSUPPORTED       The specified DataType is not supported.
    @retval EFI_BUFFER_TOO_SMALL  The DataSize is too small for the result. DataSize has been
                                  updated with the size needed to complete the request.

  **/
  public readonly delegate* unmanaged<EFI_IPSEC_CONFIG_PROTOCOL*, EFI_IPSEC_CONFIG_DATA_TYPE, EFI_IPSEC_CONFIG_SELECTOR*, ulong*, void*, EFI_STATUS> GetData;
  /**
    Enumerates the current selector for IPsec configuration data entry.

    This function is called multiple times to retrieve the entry Selector in IPsec
    configuration database. On each call to GetNextSelector(), the next entry
    Selector are retrieved into the output interface.

    If the entire IPsec configuration database has been iterated, the error
    EFI_NOT_FOUND is returned.
    If the Selector buffer is too small for the next Selector copy, an
    EFI_BUFFER_TOO_SMALL error is returned, and SelectorSize is updated to reflect
    the size of buffer needed.

    On the initial call to GetNextSelector() to start the IPsec configuration database
    search, a pointer to the buffer with all zero value is passed in Selector. Calls
    to SetData() between calls to GetNextSelector may produce unpredictable results.

    @param[in]      This          Pointer to the EFI_IPSEC_CONFIG_PROTOCOL instance.
    @param[in]      DataType      The type of IPsec configuration data to retrieve.
    @param[in, out] SelectorSize  The size of the Selector buffer.
    @param[in, out] Selector      On input, supplies the pointer to last Selector that was
                                  returned by GetNextSelector().
                                  On output, returns one copy of the current entry Selector
                                  of a given DataType.

    @retval EFI_SUCCESS           The specified configuration data is got successfully.
    @retval EFI_INVALID_PARAMETER One or more of the followings are TRUE:
                                  - This is NULL.
                                  - SelectorSize is NULL.
                                  - Selector is NULL.
    @retval EFI_NOT_FOUND         The next configuration data entry was not found.
    @retval EFI_UNSUPPORTED       The specified DataType is not supported.
    @retval EFI_BUFFER_TOO_SMALL  The SelectorSize is too small for the result. This parameter
                                  has been updated with the size needed to complete the search
                                  request.

  **/
  public readonly delegate* unmanaged<EFI_IPSEC_CONFIG_PROTOCOL*, EFI_IPSEC_CONFIG_DATA_TYPE, ulong*, EFI_IPSEC_CONFIG_SELECTOR*, EFI_STATUS> GetNextSelector;
  /**
    Register an event that is to be signaled whenever a configuration process on the
    specified IPsec configuration information is done.

    This function registers an event that is to be signaled whenever a configuration
    process on the specified IPsec configuration data is done (e.g. IPsec security
    policy database configuration is ready). An event can be registered for different
    DataType simultaneously and the caller is responsible for determining which type
    of configuration data causes the signaling of the event in such case.

    @param[in] This               Pointer to the EFI_IPSEC_CONFIG_PROTOCOL instance.
    @param[in] DataType           The type of data to be registered the event for.
    @param[in] Event              The event to be registered.

    @retval EFI_SUCCESS           The event is registered successfully.
    @retval EFI_INVALID_PARAMETER This is NULL or Event is NULL.
    @retval EFI_ACCESS_DENIED     The Event is already registered for the DataType.
    @retval EFI_UNSUPPORTED       The notify registration unsupported or the specified
                                  DataType is not supported.

  **/
  public readonly delegate* unmanaged<EFI_IPSEC_CONFIG_PROTOCOL*, EFI_IPSEC_CONFIG_DATA_TYPE, EFI_EVENT, EFI_STATUS> RegisterDataNotify;
  /**
    Remove the specified event that is previously registered on the specified IPsec
    configuration data.

    This function removes a previously registered event for the specified configuration data.

    @param[in] This               Pointer to the EFI_IPSEC_CONFIG_PROTOCOL instance.
    @param[in] DataType           The configuration data type to remove the registered event for.
    @param[in] Event              The event to be unregistered.

    @retval EFI_SUCCESS           The event is removed successfully.
    @retval EFI_NOT_FOUND         The Event specified by DataType could not be found in the
                                  database.
    @retval EFI_INVALID_PARAMETER This is NULL or Event is NULL.
    @retval EFI_UNSUPPORTED       The notify registration unsupported or the specified
                                  DataType is not supported.

  **/
  public readonly delegate* unmanaged<EFI_IPSEC_CONFIG_PROTOCOL*, EFI_IPSEC_CONFIG_DATA_TYPE, EFI_EVENT, EFI_STATUS> UnregisterDataNotify;
}

// extern EFI_GUID  gEfiIpSecConfigProtocolGuid;

// #endif
