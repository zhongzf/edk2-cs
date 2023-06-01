namespace Uefi;
/** @file
  The UEFI Smart Card Reader Protocol provides an abstraction for device to provide
  smart card reader support. This protocol is very close to Part 5 of PC/SC workgroup
  specifications and provides an API to applications willing to communicate with a
  smart card or a smart card reader.

  Copyright (c) 2015, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __SMART_CARD_READER_H__
// #define __SMART_CARD_READER_H__

public static EFI_GUID EFI_SMART_CARD_READER_PROTOCOL_GUID = new GUID(
      0x2a4d1adf, 0x21dc, 0x4b81, new byte[] { 0xa4, 0x2f, 0x8b, 0x8e, 0xe2, 0x38, 0x00, 0x60 });

// typedef struct _EFI_SMART_CARD_READER_PROTOCOL EFI_SMART_CARD_READER_PROTOCOL;

//
// Codes for access mode
//
public const ulong SCARD_AM_READER = 0x0001             // Exclusive access to reader;
public const ulong SCARD_AM_CARD = 0x0002             // Exclusive access to card;
//
// Codes for card action
//
public const ulong SCARD_CA_NORESET = 0x0000          // Don't reset card;
public const ulong SCARD_CA_COLDRESET = 0x0001          // Perform a cold reset;
public const ulong SCARD_CA_WARMRESET = 0x0002          // Perform a warm reset;
public const ulong SCARD_CA_UNPOWER = 0x0003          // Power off the card;
public const ulong SCARD_CA_EJECT = 0x0004          // Eject the card;
//
// Protocol types
//
public const ulong SCARD_PROTOCOL_UNDEFINED = 0x0000;
public const ulong SCARD_PROTOCOL_T0 = 0x0001;
public const ulong SCARD_PROTOCOL_T1 = 0x0002;
public const ulong SCARD_PROTOCOL_RAW = 0x0004;
//
// Codes for state type
//
public const ulong SCARD_UNKNOWN = 0x0000              /* state is unknown */;
public const ulong SCARD_ABSENT = 0x0001              /* Card is absent */;
public const ulong SCARD_INACTIVE = 0x0002              /* Card is present and not powered*/;
public const ulong SCARD_ACTIVE = 0x0003              /* Card is present and powered */;
//
// Macro to generate a ControlCode & PC/SC part 10 control code
//
public const ulong SCARD_CTL_CODE = (code)(0x42000000 + (code));
public const ulong CM_IOCTL_GET_FEATURE_REQUEST = SCARD_CTL_CODE(3400);

























































































































































































































































///
/// Smart card aware application invokes this protocol to get access to an inserted
/// smart card in the reader or to the reader itself.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMART_CARD_READER_PROTOCOL
{
  /**
    This function requests connection to the smart card or the reader, using the
    appropriate reset type and protocol.

    The SCardConnectfunction requests access to the smart card or the reader. Upon
    success, it is then possible to call SCardTransmit.

    If AccessMode is set to SCARD_AM_READER, PreferredProtocols must be set to
    SCARD_PROTOCOL_UNDEFINED and CardAction to SCARD_CA_NORESET else function
    fails with EFI_INVALID_PARAMETER.

    @param[in]  This               Indicates a pointer to the calling context.
    @param[in]  AccessMode         Codes of access mode.
    @param[in]  CardAction         SCARD_CA_NORESET, SCARD_CA_COLDRESET or
                                   SCARD_CA_WARMRESET.
    @param[in]  PreferredProtocols Bitmask of acceptable protocols.
    @param[out] ActiveProtocol     A flag that indicates the active protocol.

    @retval EFI_SUCCESS            The requested command completed successfully.
    @retval EFI_INVALID_PARAMETER  This is NULL
    @retval EFI_INVALID_PARAMETER  AccessMode is not valid.
    @retval EFI_INVALID_PARAMETER  CardAction is not valid.
    @retval EFI_INVALID_PARAMETER  Invalid combination of AccessMode/CardAction/
                                   PreferredProtocols.
    @retval EFI_NOT_READY          A smart card is inserted but failed to return an ATR.
    @retval EFI_UNSUPPORTED        PreferredProtocols does not contain an available
                                   protocol to use.
    @retval EFI_NO_MEDIA           AccessMode is set to SCARD_AM_CARD but there is
                                   no smart card inserted.
    @retval EFI_ACCESS_DENIED      Access is already locked by a previous SCardConnectcall.
    @retval EFI_DEVICE_ERROR       Any other error condition, typically a reader removal.

  **/
  public readonly delegate* unmanaged<EFI_SMART_CARD_READER_PROTOCOL*, uint, uint, uint, uint*, EFI_STATUS> SCardConnect;
  /**
    This function releases a connection previously taken by SCardConnect.

    The SCardDisconnect function releases the lock previously taken by SCardConnect.
    In case the smart card has been removed before this call, thisfunction
    returns EFI_SUCCESS. If there is no previous call to SCardConnect, this
    function returns EFI_SUCCESS.

    @param[in]  This               Indicates a pointer to the calling context.
    @param[in]  CardAction         Codes for card action.

    @retval EFI_SUCCESS            The requested command completed successfully.
    @retval EFI_INVALID_PARAMETER  This is NULL
    @retval EFI_INVALID_PARAMETER  CardAction value is unknown.
    @retval EFI_UNSUPPORTED        Reader does not support Eject card feature
                                   (disconnect was not performed).
    @retval EFI_DEVICE_ERROR       Any other error condition, typically a reader removal.

  **/
  public readonly delegate* unmanaged<EFI_SMART_CARD_READER_PROTOCOL*, uint, EFI_STATUS> SCardDisconnect;
  /**
    This function retrieves some basic information about the smart card and reader.

    The SCardStatusfunction retrieves basic reader and card information.

    If ReaderName, State, CardProtocolor Atris NULL, the function does not fail but
    does not fill in such variables.

    If EFI_SUCCESS is not returned, ReaderName and Atr contents shall not be considered
    as valid.

    @param[in]      This             Indicates a pointer to the calling context.
    @param[out]     ReaderName       A pointer to a NULL terminated string that will
                                     contain the reader name.
    @param[in, out] ReaderNameLength On input, a pointer to the variablethat holds the
                                     maximal size, in bytes,of ReaderName.
                                     On output, the required size, in bytes, for ReaderName.
    @param[out]     State            Current state of the smart card reader.
    @param[out]     CardProtocol     Current protocol used to communicate with the smart card.
    @param[out]     Atr              A pointer to retrieve the ATR of the smart card.
    @param[in, out] AtrLength        On input, a pointer to hold the maximum size, in bytes,
                                     of Atr(usually 33).
                                     On output, the required size, inbytes, for the smart
                                     card ATR.

    @retval EFI_SUCCESS            The requested command completed successfully.
    @retval EFI_INVALID_PARAMETER  This is NULL
    @retval EFI_INVALID_PARAMETER  ReaderName is not NULL but ReaderNameLength is NULL
    @retval EFI_INVALID_PARAMETER  Atr is not NULL but AtrLength is NULL
    @retval EFI_BUFFER_TOO_SMALL   ReaderNameLength is not big enough to hold the reader name.
                                   ReaderNameLength has been updated to the required value.
    @retval EFI_BUFFER_TOO_SMALL   AtrLength is not big enough to hold the ATR.
                                   AtrLength has been updated to the required value.
    @retval EFI_DEVICE_ERROR       Any other error condition, typically a reader removal.

  **/
  public readonly delegate* unmanaged<EFI_SMART_CARD_READER_PROTOCOL*, char*, ulong*, uint*, uint*, byte*, ulong*, EFI_STATUS> SCardStatus;
  /**
    This function sends a command to the card or reader and returns its response.

    The protocol to use to communicate with the smart card has been selected through
    SCardConnectcall.

    In case RAPDULength indicates a buffer too small to holdthe response APDU, the
    function fails with EFI_BUFFER_TOO_SMALL.

    @param[in]      This          A pointer to the EFI_USBFN_IO_PROTOCOLinstance.
    @param[in]      CAPDU         A pointer to a byte array thatcontains the Command
                                  APDU to send to the smart card or reader.
    @param[in]      CAPDULength   Command APDU size, in bytes.
    @param[out]     RAPDU         A pointer to a byte array that will contain the
                                  Response APDU.
    @param[in, out] RAPDULength   On input, the maximum size, inbytes, of the Response
                                  APDU.
                                  On output, the size, in bytes, of the Response APDU.

    @retval EFI_SUCCESS           The requested command completed successfully.
    @retval EFI_INVALID_PARAMETER This is NULL.
    @retval EFI_INVALID_PARAMETER CAPDU is NULL or CAPDULength is 0.
    @retval EFI_BUFFER_TOO_SMALL  RAPDULength is not big enough to hold the response APDU.
                                  RAPDULength has been updated to the required value.
    @retval EFI_NO_MEDIA          There is no card in the reader.
    @retval EFI_NOT_READY         Card is not powered.
    @retval EFI_PROTOCOL_ERROR    A protocol error has occurred.
    @retval EFI_TIMEOUT           The reader did not respond.
    @retval EFI_ACCESS_DENIED     A communication with the reader/card is already pending.
    @retval EFI_DEVICE_ERROR      Any other error condition, typically a reader removal.

  **/
  public readonly delegate* unmanaged<EFI_SMART_CARD_READER_PROTOCOL*, byte*, ulong, byte*, ulong*, EFI_STATUS> SCardTransmit;
  /**
    This function provides direct access to the reader.

    This function gives direct control to send commands to the driver or the reader.
    The ControlCode to use is vendor dependant; the only standard code defined is
    the one to get PC/SC part 10 features.

    InBuffer and Outbuffer may be NULL when ControlCode operation does not require
    them.

    @param[in]      This             Indicates a pointer to the calling context.
    @param[in]      ControlCode      The control code for the operation to perform.
    @param[in]      InBuffer         A pointer to the input parameters.
    @param[in]      InBufferLength   Size, in bytes, of input parameters.
    @param[out]     OutBuffer        A pointer to the output parameters.
    @param[in, out] OutBufferLength  On input, maximal size, in bytes, to store output
                                     parameters.
                                     On output, the size, in bytes, of output parameters.

    @retval EFI_SUCCESS           The requested command completed successfully.
    @retval EFI_INVALID_PARAMETER This is NULL.
    @retval EFI_INVALID_PARAMETER ControlCode requires input parameters but:
                                    InBuffer is NULL or InBufferLenth is NULL or
                                    InBuffer is not NULL but InBufferLenth is less than
                                    expected.
    @retval EFI_INVALID_PARAMETER OutBuffer is not NULL but OutBufferLength is NULL.
    @retval EFI_UNSUPPORTED       ControlCode is not supported.
    @retval EFI_BUFFER_TOO_SMALL  OutBufferLength is not big enough to hold the output
                                  parameters.
                                  OutBufferLength has been updated to the required value.
    @retval EFI_NO_MEDIA          There is no card in the reader and the control code
                                  specified requires one.
    @retval EFI_NOT_READY         ControlCode requires a powered card to operate.
    @retval EFI_PROTOCOL_ERROR    A protocol error has occurred.
    @retval EFI_TIMEOUT           The reader did not respond.
    @retval EFI_ACCESS_DENIED     A communication with the reader/card is already pending.
    @retval EFI_DEVICE_ERROR      Any other error condition, typically a reader removal.

  **/
  public readonly delegate* unmanaged<EFI_SMART_CARD_READER_PROTOCOL*, uint, byte*, ulong, byte*, ulong*, EFI_STATUS> SCardControl;
  /**
    This function retrieves a reader or smart card attribute.

    Possibly supported attrib values are listed in "PC/SC specification, Part 3:
    Requirements for PC-Connected Interface Devices".

    @param[in]      This             Indicates a pointer to the calling context.
    @param[in]      Attrib           Identifier for the attribute to retrieve.
    @param[out]     OutBuffer        A pointer to a buffer that will contain
                                     attribute data.
    @param[in, out] OutBufferLength  On input, maximal size, in bytes, to store
                                     attribute data.
                                     On output, the size, in bytes, of attribute
                                     data.

    @retval EFI_SUCCESS           The requested command completed successfully.
    @retval EFI_INVALID_PARAMETER This is NULL.
    @retval EFI_INVALID_PARAMETER OutBuffer is NULL or OutBufferLength is 0.
    @retval EFI_BUFFER_TOO_SMALL  OutBufferLength is not big enough to hold the output
                                  parameters.
                                  OutBufferLength has been updated to the required value.
    @retval EFI_UNSUPPORTED       Attribis not supported
    @retval EFI_NO_MEDIA          There is no card in the reader and Attrib value
                                  requires one.
    @retval EFI_NOT_READY         Attrib requires a powered card to operate.
    @retval EFI_PROTOCOL_ERROR    A protocol error has occurred.
    @retval EFI_TIMEOUT           The reader did not respond.
    @retval EFI_DEVICE_ERROR      Any other error condition, typically a reader removal.

  **/
  public readonly delegate* unmanaged<EFI_SMART_CARD_READER_PROTOCOL*, uint, byte*, ulong*, EFI_STATUS> SCardGetAttrib;
}

// extern EFI_GUID  gEfiSmartCardReaderProtocolGuid;

// #endif
