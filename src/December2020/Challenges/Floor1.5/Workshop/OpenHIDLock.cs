using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Janda.CTF.SANS.HolidayHack
{
    public class OpenHIDLock : IChallenge
    {
        private readonly ILogger<OpenHIDLock> _logger;

        class HIDCard
        {
            public string Tag;
            public string Elf;
            public string Room;

            public override string ToString()
            {
                return Tag;
            }
        }

        public OpenHIDLock(ILogger<OpenHIDLock> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
        
            var cards = new HIDCard[]
            {
                new HIDCard() { Tag = "#db# TAG ID: 2006e22f0e (6023) - Format Len: 26 bit - FC: 113 - Card: 6023", Elf = "Bow Ninecandle", Room = "Talks Lobby" },
                new HIDCard() { Tag = "#db# TAG ID: 2006e22f08 (6020) - Format Len: 26 bit - FC: 113 - Card: 6020", Elf = "Noel Boetie", Room = "Wrapping Room" },
                new HIDCard() { Tag = "#db# TAG ID: 2006e22f0d (6022) - Format Len: 26 bit - FC: 113 - Card: 6022", Elf = "Sparkle Redberry", Room = "Entryway" },
                new HIDCard() { Tag = "#db# TAG ID: 2006e22f31 (6040) - Format Len: 26 bit - FC: 113 - Card: 6040", Elf = "Angel Candysalt", Room = "Great Room" },
                new HIDCard() { Tag = "#db# TAG ID: 2006e22f13 (6025) - Format Len: 26 bit - FC: 113 - Card: 6025", Elf = "Shinny Upatree", Room = "Front Lawn" },
                new HIDCard() { Tag = "", Elf = "", Room = "" },
                new HIDCard() { Tag = "", Elf = "", Room = "" },
            };

            foreach (var card in cards)
                card.ToString().LogNote(_logger, "Open proxmark and call {command} next to {elf} in {room}", "lf hid read", card.Elf, card.Room);


            @"
                [=] Simulating HID tag using raw 2006e22f0e
                [=] Stopping simulation after 10 seconds.

            ".LogNote(_logger, "Open proxmark CLI and type {command} next to the door in Workshop", "pm3 --> lf hid sim -r 2006e22f0e");
        }
    }
}
