using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltitudeAngelWings.Models;

namespace MissionPlanner.plugins
{
    public class stanag4586
    {
        public class MessageWrapper
        {
            /// <summary>
            /// Each message shall contain the version identification of the Interface Definition
            /// Document (IDD) from which its structure was defined. This version identification
            /// shall be placed in a fixed 10 byte field and filled with a null-terminated string of ASCII
            /// characters. Version identification management shall be used by error checking
            /// functions to validate format consistency. Table B1-3 shows the current version of
            /// the IDD that has been assigned. 
            /// </summary>
            public uint IDD = Convert.ToUInt32("9");
            /// <summary>
            /// The instance identifier shall uniquely identify every instance of a message of a given
            /// type. Instance identifiers are used by the system to keep streaming data
            /// coordinated, and to identify dropped messages of a given type at the application
            /// level. Instance identifier numbers shall not be reused unless other provisions for
            /// avoiding identifier ambiguity are provided in the message body. 
            /// </summary>
            public uint MsgInstance;
            /// <summary>
            /// The message type is the integer value associated with the defined messages types
            /// below. Message types shall be numbered sequentially from 1 to n, where n is any
            /// integer less than 2000 and represents the highest approved message type. It is
            /// anticipated that the number of standard message types may grow and that NATO will
            /// establish a commission to maintain configuration control on changes to the standard
            /// message list. For vehicle specific messages (private), the type numbers shall be
            /// greater than 2000. 
            /// </summary>
            public uint MessageType;
            /// <summary>
            /// The length shall be a 32-bit unsigned integer of the number of bytes in the “Message
            /// Data”. The length shall be any number between 1 and 538.
            /// Note the UDP protocol under IPv4 has a guaranteed minimum datagram size of 576
            /// bytes that must be supported by all implementations. Subtracting the IPv4 header
            /// size of 20 bytes and the UDP header size of 8 bytes, leaves 548 bytes as the
            /// maximum amount data that can be sent in a datagram that will guarantee
            /// interoperability. Therefore, no message or multi-message datagram shall exceed
            /// this data limit. Subtracting the message wrapper size of 24 bytes, gives 524 bytes as
            /// the maximum message length of a single message with no room for another
            /// message in the datagram. Extra care should be taken when packing multiple
            /// messages in the same datagram. 
            /// </summary>
            public uint MessageLength;
            /// <summary>
            /// The purpose of Stream IDs is to provide a means for separating flows of data among
            /// various processes sharing a single communications channel, and among messages
            /// from a given source to multiple destinations. Future capability. 
            /// </summary>
            public uint StreamID;

            /// <summary>
            /// The purpose of Packet Sequence Number was to provide a means for segmenting
            /// data from a single message into sequences of blocks of a maximum length. This
            /// field is not used and shall contain “- 1”
            /// </summary>
            public uint PacketSeqNo = unchecked((uint) -1);
            public byte[] MessageData;
            /// <summary>
            /// Checksum shall be employed to determine the presence of errors during
            /// transmission or handling of messages. The checksum shall be a 4-byte unsigned
            /// integer and calculated by simple, byte-wise unsigned binary addition of all data
            /// contained in the message excluding the checksum, and truncated to four bytes. 
            /// </summary>
            public uint Checksum;
        }
    }
}
