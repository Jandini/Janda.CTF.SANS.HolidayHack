using Microsoft.Extensions.Logging;
using System;
using System.Buffers.Binary;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Type = "Objective", Number = 11, Name = "Naughty/Nice List with Blockchain Investigation Part 2", Points = 5,
        Brief = @"
            The SHA256 of Jack's altered block is: 58a3b9335a6ceb0234c12d35a0564c4e f0e90152d0eb2ce2082383b38028a90f. 
            If you're clever, you can recreate the original version of that block by changing the values of only 4 bytes. 
            Once you've recreated the original block, what is the SHA256 of that block?
        ")]
    public class BlockchainInvestigationPart2 : IChallenge
    {
        private readonly ILogger<BlockchainInvestigationPart2> _logger;

        public BlockchainInvestigationPart2(ILogger<BlockchainInvestigationPart2> logger)
        {
            _logger = logger;
        }
      

        private char[] ToHexCharArray(byte[] bytes)
        {
            int count = bytes.Length;
            char[] hex = new char[count * 2];
            byte b;

            for (int y = 0, x = 0; y < count; ++y, ++x)
            {
                b = ((byte)(bytes[y] >> 4));

                hex[x] = (char)(b > 9
                    ? b + 0x37 + 32
                    : b + 0x30);

                b = ((byte)(bytes[y] & 0xF));

                hex[++x] = (char)(b > 9
                    ? b + 0x37 + 32
                    : b + 0x30);
            }

            return hex;
        }

        public void Run()
        {
            @"
                Wow, it really was all about abusing the pseudo-random sequence!
                I've been thinking, do you think someone could try and cheat the Naughty/Nice Blockchain with this same technique?

                I remember you told us about how if you have control over to bytes in a file, it's easy to create MD5 hash collisions.

                But the nonce would have to be known ahead of time.
                We know that the blockchain works by ""chaining"" blocks together.
                There's no way you know who could change it without messing up the chain, right Santa?
                I'm going to look closer to spot if any of the blocks have been changed.


                https://github.com/corkami/collisions
                This one is interestring... https://github.com/corkami/collisions#shattered-sha1

            ".Blog(_logger, "Resources online");

            // 347979fece8d403e06f89f8633b5231a

            var bytes = File.ReadAllBytes(@"Challenges\Floor3\SantasOffice\BlockchainInvestigationPart2\129459.data.bin");
            var md5 = new MD5CryptoServiceProvider();
            var data = md5.ComputeHash(bytes);
            var original = string.Concat(ToHexCharArray(data));


            return;
            
            /* _logger.LogInformation("Searching for MD5 collision...");

            for (int b = 13100; b < bytes.Length - 1; b++)
            {
                var currentValue = BinaryPrimitives.ReadUInt16LittleEndian(bytes.AsSpan(b));
                   
                Parallel.ForEach(Enumerable.Range(0, 65535), new ParallelOptions() { MaxDegreeOfParallelism = 8 }, (i) =>
                {

                    var buffer = new byte[bytes.Length];
                    bytes.AsSpan().CopyTo(buffer);
                                     
                    //var b = BitConverter.GetBytes(i);
                    //var c = string.Format("{0:x8}", i);

                    //for (int j = 0; j < 8; j++)
                    //    bytes[65 + j] = (byte)c[j];

                    if (i != currentValue)
                    {

                        BinaryPrimitives.WriteUInt16LittleEndian(buffer.AsSpan(b), (ushort)i);
                        //buffer[b] = (byte)(i);

                        
                        var md5 = string.Concat(ToHexCharArray(new MD5CryptoServiceProvider().ComputeHash(buffer)));

                        if (md5 == "347979fece8d403e06f89f8633b5231a")
                        {
                            //_logger.LogInformation("Collision found at {i} for {c}", i, string.Concat(c));
                            _logger.LogInformation("Collision found at offset {b} for value {c}", b, i);
                        }
                    }                                          
                });

                Console.Title = $"Byte {b}";
            } */


        }
    }
}
