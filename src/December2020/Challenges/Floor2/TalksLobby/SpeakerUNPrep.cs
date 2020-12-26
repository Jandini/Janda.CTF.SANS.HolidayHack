﻿using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class SpeakerUNPrep : IChallenge
    {
        private readonly ILogger<SpeakerUNPrep> _logger;

        public SpeakerUNPrep(ILogger<SpeakerUNPrep> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            Door();
            Lights();

            VendingMachine();

        }


        public void Lights()
        {
            @"
                The speaker unpreparedness room sure is dark, you're thinking (assuming
                you've opened the door; otherwise, you wonder how dark it actually is)

                You wonder how to turn the lights on? If only you had some kind of hin---

                    >>> CONFIGURATION FILE LOADED, SELECT FIELDS DECRYPTED: /home/elf/lights.conf

                ---t to help figure out the password... I guess you'll just have to make do!

                The terminal just blinks: Welcome back, elf-technician

                What do you enter? > light
                Checking......
                Beep boop invalid password
            ".LogMessage(_logger, "---t is {a}?, hin--- is {b}", "---t", "hin---");


            @"
                password: E$ed633d885dcb9b2f3f0118361de4d57752712c27c5316a95d9e5e5b124
                name: elf-technician
            ".LogMessage(_logger, "cat /home/elf/lights.conf");


            @"
                PermissionDeniedAddrNotAvailableconnection resetentity not foundalready borrowed$
                passwordlightson
                    (bytes Overflowextern ""overflowNotFoundTimedOut
                NulErrorBox<Any> thread 'expected, found F
                E$Invalid nonce value!
                ERROR: Could not load Badly formatted line(expected: ""key: value""): Failed to parse key `lights.confnamethe NoneSome <= Zero    __ZNshim as u128i128charboolmut for< ->dyn
                mainkindcodeKindfull /
                at < no name provided > The speaker unpreparedness room sure is dark, you're thinking (assuming
                you've opened the door; otherwise, you wonder how dark it actually is)
                You wonder how to turn the lights on ? If only you had some kind of hin-- -

                >>> CONFIGURATION FILE LOADED, SELECT FIELDS DECRYPTED: ---t to help figure out the password... I guess you'll just have to make do!
                The terminal just blinks: Welcome back, What do you enter? > Lights on!
                That would have turned on the lights!
                If you've figured out the real password, be sure you run Beep boop invalid password
                Couldn't read config file: Password is missing from config file!
                src / liballoc / raw_vec.rscapacity overflowFromUtf8Errorbytesa formatting trait implementation returned an error / usr / src / rustc - 1.41.1 / src / libcore / fmt / mod.rsstack backtrace:
                            -
                            cannot panic during the backtrace function / usr / src / rustc - 1.41.1 / vendor / backtrace / src / lib.rsSomething went wrong: Checking...Something went wrong reading input: Something went wrong in the environment: couldn't get the executable name
                Something went wrong in the environment: Something went wrong in the environment: couldn't get the configuration file
                Something went wrong getting the parent directory
                RESOURCE_IDThe error message is: ask for help!
                or su or some other process that alters the environment.If this persists, please
                    environmental variable is missing - that can happen if you're using sudo
                There is something wrong with your environment; the most likely reason is that
                Something went wrong, please try again and report if this persists: a Display implementation returned an error unexpectedly00000000 - 0000 - 4000 - 0000 - 000000000000WARNING: The RESOURCE_ID is 00000000 - 0000 - 4000 - 0000 - 000000000000 - be sure to use a real one in production!
                resource_id is not a valid uuidv4! It's vresource_id is not a valid uuid (Couldn't get resource_id from the environmental variable "", ""action"": ""00010203040506070809101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899
                invalid utf-8 sequence of  bytes from index incomplete utf - 8 byte sequence from index[...] src/ libcore / str / mod.rsbyte index is not a char boundary; it is inside ) of `begin <= end( is out of bounds of `Utf8Errorvalid_up_toerror_lenParseIntErrorEmptyInvalidDigitUnderflowsrc / libcore / slice / mod.rs
                        ./?\]_
                )147:;= IJ]
                )14:; EFIJ ^ de
                )EIWde
                EIde
                INOWY ^ _
                FGNOXZ\^~
                / _ &./
                NOZ[
                no7 =? BE
                % _ m
                ';>NO
                        6=>V
                67VW
                )14:EFIJNOdeZ\
                ;> fi
                :?EQ
                ""%>?
                    #%&(38:HJLPSUVXZ\^`cefksx}
                no ^ ""{
                PI73
                G       '       u
                8889
                index  out of range for slice of length slice index starts at  but ends at src / libcore / result.rsattempted to index slice up to maximum usizesrc / libcore / fmt / mod.rssrc / libcore / option.rsErrorsrc / libcore / str / pattern.rs {
                                { } (
                                src / libcore / unicode / bool_trie.rsindex out of bounds: the len is g
                                        [assertion failed: PAGE_SIZE != 0failed to initiate panic, error  but the index is BorrowErrorBorrowMutError
                                        assertion failed: broken.is_empty()src / libcore / str / lossy.rsHash table capacity overflow / usr / src / rustc - 1.41.1 / vendor / hashbrown / src / raw / mod.rs
                                        Odd number of digitsInvalid character  at position Invalid string lengthInvalidStringLengthInvalidHexCharactercindexOddLengthdescription() is deprecated; use Display
                / root /.cargo / registry / src / github.com - 1ecc6299db9ec823 / hex - 0.4.2 / src / lib.rsattempt to divide by zero/ usr / src / rustc - 1.41.1 / src / libcore / slice / mod.rs_ZNZN_$SPBPRFLTGTLPRP @_RR__R?[]::{
                                closure:#}::<>, usizeu64u32u16u80x_'...!f64f32isizei64i32i16i8()str&*const ; (,> Cunsafe -"" fn( +  = punycode{/usr/src/rustc-1.41.1/vendor/rustc-demangle/src/v0.rs.llvm./root/.cargo/registry/src/github.com-1ecc6299db9ec823/salsa20-core-0.2.3/src/lib.rs/root/.cargo/registry/src/github.com-1ecc6299db9ec823/block-buffer-0.9.0/src/lib.rsassertion failed: end <= lensrc/libstd/sys/unix/stack_overflow.rsfailed to allocate an alternative stackstack overflowfailed to get environment variable `src/libstd/env.rsstream did not contain valid UTF-8fatal runtime error: 
                thread '' has overflowed its stack
                                                    environment variable was not valid unicode: environment variable not foundOnce instance has previously been poisonedassertion failed: state_and_queue & STATE_MASK == RUNNINGsrc / libstd / sync / once.rs..src / libstd / path.rsuse of std::thread::current() is not possible after the thread's local data has been destroyedsrc/libstd/thread/mod.rsinconsistent state in unparkinconsistent park statepark state changed unexpectedlythread name may not contain interior null bytesfailed to generate unique thread ID: bitspace exhausteddata provided contains a nul byteCustomUnexpectedEofConnectionRefusedConnectionResetConnectionAbortedNotConnectedAddrInUseBrokenPipeAlreadyExistsWouldBlockInvalidInputInvalidDataWriteZeroInterruptedOthererrorOsmessagefailed to write the buffered dataother os erroroperation interruptedwrite zerotimed outinvalid datainvalid input parameteroperation would blockentity already existsbroken pipeaddress not availableaddress in usenot connectedconnection abortedconnection refusedpermission deniedunexpected end of file (os error )assertion failed: queue != DONEsrc/libstd/sys_common/at_exit_imp.rs/dev/urandomfailed to open /dev/urandomfailed to read /dev/urandomsrc/libstd/sys/unix/rand.rsunexpected getrandom error: src/libstd/sys/unix/mod.rsassertion failed: signal(libc::SIGPIPE, libc::SIG_IGN) != libc::SIG_ERRcannot access stdin during shutdowncannot access stdout during shutdowncannot access stderr during shutdownstdoutsrc/libstd/io/stdio.rsfailed printing to stderrPoisonError { inner: .. }`: <::core::macros::panic macros>Tried to shrink to a larger capacityalready mutably borrowedAccessErrorcannot access a Thread Local Storage value during or after destructionsrc/libstd/sync/condvar.rsattempted to use a condition variable with two mutexessrc/libstd/sys_common/thread_info.rsassertion failed: c.borrow().is_none()assertion failed: key != 0src/libstd/sys/unix/thread_local.rsinvalid utf-8src/libstd/sys/unix/condvar.rs""
                                                    \x__rust_begin_short_backtrace / usr / src / rustc - 1.41.1 / src / libcore / str / pattern.rsformatter errorfailed to write whole bufferRUST_BACKTRACE0note: Some details are omitted, run with `RUST_BACKTRACE = full` for a verbose backtrace.
                                                                    < unknown >.memory allocation of  bytes failed
                                                                    attempt to calculate the remainder with a divisor of zerosrc / libstd / sys / unix / thread.rsinternal error: entered unreachable codesrc / libstd / sys / unix / fs.rscalled `Result::unwrap()` on an `Err` valuesrc / libstd / sys / unix / os.rsstrerror_r failure`/ proc / self / exeno / proc / self / exe available.Is / proc mounted ? failed to fill whole bufferrwlock maximum reader count exceededrwlock read lock would result in deadlockthread panicked while panicking.aborting.
                                                                                                        < unnamed > note: run with `RUST_BACKTRACE = 1` environment variable to display a backtrace.
                ' panicked at '', 
                                                    thread panicked while processing panic.aborting.
                                                    src / libstd / sys / unix / rwlock.rsassertion failed: `(left == right)`
                    left: ``,
                    right: `urn: uuid: called `Option::unwrap()` on a `None` value
                                                    0123456789abcdefABCDEF -/ root /.cargo / registry / src / github.com - 1ecc6299db9ec823 / uuid - 0.8.1 / src / parser / mod.rs / usr / src / rustc - 1.41.1 / src / libcore / macros / mod.rsinvalid group lengthinvalid number of groupsinvalid characterinvalid length an optional prefix of `urn: uuid:` followed byexpected  in group one of: invalid bytes length: expected / proc / curproc / file
                                                                                        / proc / self / exe
                                                                                        / proc /% ld / object / a.out
                failed to read executable information
                libbacktrace could not find executable to open
                                                    close
                                                    backtrace library does not support threads
                                                    no debug info in ELF executable
                                                    no symbol table in ELF executable
                .debug_info
                executable file is not ELF
                ELF section name out of range
                .note.gnu.build - id
                .gnu_debuglink
                .opd
                / usr / lib / debug /.build - id /
                .debug /
                / usr / lib / debug /
                fstat
                                                    executable file is unrecognized ELF version
                                                    executable file is unexpected ELF class
                                                    executable file has unknown endianness
                ELF symbol table strtab link out of range
                symbol string index out of range
                    n;^
                Qkkbal
                i]Wb
                9a&g
                MGiI
                wn>Jj
                #.zf
                +o*7
                .debug_line
                .debug_abbrev
                .debug_ranges
                .debug_str
                .zdebug_info
                .zdebug_line
                .zdebug_abbrev
                .zdebug_ranges
                .zdebug_str
                malloc
                realloc
                %s in %s at %d
                invalid abbreviation code
                DWARF underflow
                unrecognized address size
                LEB128 overflows uint64_t
                signed LEB128 overflows uint64_t
                DW_FORM_strp out of range
                unrecognized DWARF form
                ranges offset out of range
                abstract origin or specification out of range
                invalid abstract origin or specification
                invalid file number in DW_AT_call_file attribute
                function ranges offset out of range
                unit line offset out of range
                unsupported line number version
                invalid directory index in line number program header
                invalid directory index in line number program
                invalid file number in line number program
                unrecognized DWARF version
                abbrev offset out of range
                lseek
                read
                file too short
                ;*3$""
                zPLR
                ""#$%&
                ,-./0
                >?@ABCDEF
                GCC: (Debian 8.3.0-6) 8.3.0
                .shstrtab
                .interp
                .note.ABI-tag
                .note.gnu.build-id
                .gnu.hash
                .dynsym
                .dynstr
                .gnu.version
                .gnu.version_r
                .rela.dyn
                .rela.plt
                .init
                .plt.got
                .text
                .fini
                .rodata
                .eh_frame_hdr
                .eh_frame
                .gcc_except_table
                .tdata
                .tbss
                .init_array
                .fini_array
                .data.rel.ro
                .dynamic
                .data
                .bss
                .comment
                ".LogMessage(_logger, "strings lights");
        }


        [Challenge(Flag = "CandyCane1")]
        public void VendingMachine()
        {

            @"
                cd lab/
                rm vending-machines.json
                ./vending-machines                
                
            ".LogMessage(_logger, "Goto lab directory, delete vending-machines.json");

            @"                
                The elves are hungry!

                If the door's still closed or the lights are still off, you know because
                you can hear them complaining about the turned-off vending machines!
                You can probably make some friends if you can get them back on...

                Loading configuration from: /home/elf/lab/vending-machines.json

                I wonder what would happen if it couldn't find its config file? Maybe that's
                something you could figure out in the lab...

                ALERT! ALERT! Configuration file is missing! New Configuration File Creator Activated!

                Please enter the name >     
                Please enter the password > AAAAAAAAAAAAAAAAAAAAAAAA

                Welcome, ! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > AAAAAAAAAAAAAAAAAAAAAAAA
                Checking......
                That would have enabled the vending machines!

                If you have the real password, be sure to run /home/elf/vending-machines
                elf@aa086c750649 ~/lab $ cat ./vending-machines.json 
                {
                  ""name"": """",
                  ""password"": ""XiGRehmwXiGRehmwXiGRehmw""
                }
                elf @aa086c750649 ~/lab $             
            ".LogMessage(_logger, "We can run ./vending-machines, provide new password and then see how it looks like in the json file.");



            @"
                Please enter the password > C

                Welcome, ! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > 
                Checking......
                Beep boop invalid password
                elf@aa086c750649 ~/lab $ cat vending-machines.json 
                {
                    ""name"": """",
                    ""password"": ""L""
                }
            ".LogMessage(_logger, "Trying single letter... and viola first letter matches... ");





            @"                
                {
                  ""name"": ""elf - maintenance"",
                  ""password"": ""LVEdQPpBwr""                                
               }                                                
            ".LogMessage(_logger, "This is password we are looking for. {command}", "cat vending-machines.json");

         

            @"
                Please enter the name > 
                Please enter the password > Candies    

                Welcome, ! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > 
                Checking......
                Beep boop invalid password
                elf@aa086c750649 ~/lab $ cat vending-machines.json 
                {
                  ""name"": """",
                  ""password"": ""LVEd4Yb""
                }                       
            ".LogMessage(_logger, "Trying Candies");




            @"

                Please enter the name > 
                Please enter the password > Candyman

                Welcome, ! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > 
                Checking......
                Beep boop invalid password
                elf@aa086c750649 ~/lab $ cat vending-machines.json 
                {
                  ""name"": """",
                  ""password"": ""LVEdQRpB""
                }

            ".LogMessage(_logger, "Trying Candyman");




            @"
                The elves are hungry!

                If the door's still closed or the lights are still off, you know because
                you can hear them complaining about the turned-off vending machines!
                You can probably make some friends if you can get them back on...

                Loading configuration from: /home/elf/lab/vending-machines.json

                I wonder what would happen if it couldn't find its config file? Maybe that's
                something you could figure out in the lab...

                ALERT! ALERT! Configuration file is missing! New Configuration File Creator Activated!

                Please enter the name > 
                Please enter the password > Candymane1

                Welcome, ! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > 
                Checking......
                Beep boop invalid password
                {
                  ""name"": """",
                  ""password"": ""LVEdQRpBwr""
                }

            ".LogMessage(_logger, "rm vending-machines.json;./vending-machines;cat vending-machines.json");



            @"
                LVEdQPpBwr  -- CandyCane1
                LVEdQLpBwr  -- Candy1ane1
                LVEdQbpBwr     CandyLane1
            ".LogMessage(_logger, "Password was found.");



            @"
                The elves are hungry!

                If the door's still closed or the lights are still off, you know because
                you can hear them complaining about the turned-off vending machines!
                You can probably make some friends if you can get them back on...

                Loading configuration from: /home/elf/vending-machines.json

                I wonder what would happen if it couldn't find its config file? Maybe that's
                something you could figure out in the lab...

                Welcome, elf-maintenance! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > CandyCane1
                Checking......

                Vending machines enabled!!
            ".LogMessage(_logger, "./vending-machines");
        }




        [Challenge(Flag = "Op3nTheD00r")]
        public void Door()
        {
            @"
                    ��z9��z9���7��z9��z9��z9��z9���7���U��V��0V���U��V��MZ���Z��|Z���Z���Z��R[���[��~[���[���[��/home/
                    elf/doorYou look at the screen. It wants a password. You roll your eyes - the 
                    password is probably stored right in the binary. There's gotta be a
                    tool for this...
                    What do you enter? > opendoor   (bytes Overflowextern "" NulErrorBox<Any>thread 'expected, found Do
                    or opened!
                    That would have opened the door!
                    Be sure to finish the challenge in prod: And don't forget, the password is ""Op3nTheD00r""
                    Beep boop invalid password
                    src/liballoc/raw_vec.rscapacity overflowa formatting trait implementation returned an error/usr/sr
                    c/rustc-1.41.1/src/libcore/fmt/mod.rsstack backtrace:
                                      -       �cannot panic during the backtrace function/usr/src/rustc-1.41.1/vendor/
                    backtrace/src/lib.rsSomething went wrong: Checking...Something went wrong reading input: Something
                     went wrong in the environment: couldn't get the executable name
                    Something went wrong in the environment: RESOURCE_IDThe error message is: ask for help!
                    or su or some other process that alters the environment. If this persists, please
                    the NoneSome <= Zerokind    __ZNshim as u128i128charboolmut for< -> dyn  mainfull/ at  environment
                    al variable is missing - that can happen if you're using sudo

            ".LogMessage(_logger, "cat door");



            @"
                /lib64/ld-linux-x86-64.so.2
                @1(I
                libdl.so.2
                _ITM_deregisterTMCloneTable
                __gmon_start__
                _ITM_registerTMCloneTable
                dladdr
                libpthread.so.0
                nanosleep
                pthread_mutex_init
                pthread_cond_destroy
                pthread_mutexattr_settype
                pthread_rwlock_unlock
                pthread_getspecific
                pthread_condattr_init
                sigaction
                pthread_condattr_setclock
                8STs
                LwH'
                             at 0123456789abcdef
                ) when slicing `
                connection resetentity not foundalready borrowed$
                /home/elf/doorYou look at the screen. It wants a password. You roll your eyes - the 
                password is probably stored right in the binary. There's gotta be a
                tool for this...
                What do you enter? > 
                opendoor
                 (bytes Overflowextern ""
                NulErrorBox<Any>thread 'expected, found Door opened!
                That would have opened the door!
                Be sure to finish the challenge in prod: And don't forget, the password is ""Op3nTheD00r""
                Beep boop invalid password
                src/liballoc/raw_vec.rscapacity overflowa formatting trait implementation returned an error/usr/src/rustc-1.41.1/src/libcore/fmt/mod.rsstack backtrace:
                 -       
                cannot panic during the backtrace function/usr/src/rustc-1.41.1/vendor/backtrace/src/lib.rsSomething went wrong: Checking...Something went wrong reading input: Something went wrong in the environment: couldn't get the executable name
                Something went wrong in the environment: RESOURCE_IDThe error message is: ask for help!
                or su or some other process that alters the environment. If this persists, please
                the NoneSome <= Zerokind    __ZNshim as u128i128charboolmut for< -> dyn 
                mainfull/
                 at  environmental variable is missing - that can happen if you're using sudo
                There is something wrong with your environment; the most likely reason is that
                Something went wrong, please try again and report if this persists: a Display implementation returned an error unexpectedly00000000-0000-4000-0000-000000000000WARNING: The RESOURCE_ID is 00000000-0000-4000-0000-000000000000 - be sure to use a real one in production!
                resource_id is not a valid uuidv4! It's vresource_id is not a valid uuid (Couldn't get resource_id from the environmental variable "", ""action"": ""00010203040506070809101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899
                [...]src/libcore/str/mod.rsbyte index  is not a char boundary; it is inside ) of `begin <= end ( is out of bounds of `Utf8Errorvalid_up_toerror_lenParseIntErrorEmptyInvalidDigitUnderflowsrc/libcore/slice/mod.rs
                ./?\]_
                )147:;=IJ]
                )14:;EFIJ^de
                )EIWde
                EIde
                INOWY^_
                no^""{
                PI73
                G       '       u
                8889
                index  out of range for slice of length slice index starts at  but ends at src/libcore/result.rsattempted to index slice up to maximum usizesrc/libcore/fmt/mod.rssrc/libcore/option.rsErrorsrc/libcore/str/pattern.rs {
                 {  }(
                src/libcore/unicode/bool_trie.rsindex out of bounds: the len is g
                [assertion failed: PAGE_SIZE != 0failed to initiate panic, error  but the index is BorrowErrorBorrowMutError
                assertion failed: broken.is_empty()src/libcore/str/lossy.rs_ZNZN_$SPBPRFLTGTLPRP@_RR__R?[]::{closure:#}::<>, usizeu64u32u16u80x_'...!f64f32isizei64i32i16i8()str&*const ; (,> Cunsafe -"" fn( +  = punycode{/usr/src/rustc-1.41.1/vendor/rustc-demangle/src/v0.rs.llvm./root/.cargo/registry/src/github.com-1ecc6299db9ec823/block-buffer-0.9.0/src/lib.rsassertion failed: end <= lensrc/libstd/sys/unix/stack_overflow.rsfailed to allocate an alternative stackstack overflowfailed to get environment variable `src/libstd/env.rsstream did not contain valid UTF-8fatal runtime error: 
                thread '' has overflowed its stack
                environment variable was not valid unicode: environment variable not foundOnce instance has previously been poisonedassertion failed: state_and_queue & STATE_MASK == RUNNINGsrc/libstd/sync/once.rs..src/libstd/path.rsuse of std::thread::current() is not possible after the thread's local data has been destroyedsrc/libstd/thread/mod.rsinconsistent state in unparkinconsistent park statepark state changed unexpectedlythread name may not contain interior null bytesfailed to generate unique thread ID: bitspace exhausteddata provided contains a nul bytefailed to write the buffered dataother os erroroperation interruptedwrite zerotimed outinvalid datainvalid input parameteroperation would blockentity already existsbroken pipeaddress not availableaddress in usenot connectedconnection abortedconnection refusedpermission deniedunexpected end of file (os error )assertion failed: queue != DONEsrc/libstd/sys_common/at_exit_imp.rssrc/libstd/sys/unix/mod.rsassertion failed: signal(libc::SIGPIPE, libc::SIG_IGN) != libc::SIG_ERRcannot access stdin during shutdowncannot access stdout during shutdowncannot access stderr during shutdownstdoutsrc/libstd/io/stdio.rsfailed printing to stderrPoisonError { inner: .. }`: internal error: entered unreachable code<::core::macros::panic macros>Tried to shrink to a larger capacityalready mutably borrowedAccessErrorcannot access a Thread Local Storage value during or after destructionsrc/libstd/sync/condvar.rsattempted to use a condition variable with two mutexessrc/libstd/sys_common/thread_info.rsassertion failed: c.borrow().is_none()assertion failed: key != 0src/libstd/sys/unix/thread_local.rssrc/libstd/sys/unix/condvar.rs""
                \x__rust_begin_short_backtrace/usr/src/rustc-1.41.1/src/libcore/str/pattern.rsformatter errorfailed to write whole bufferRUST_BACKTRACE0note: Some details are omitted, run with `RUST_BACKTRACE=full` for a verbose backtrace.
                <unknown>.memory allocation of  bytes failed
                attempt to calculate the remainder with a divisor of zerosrc/libstd/sys/unix/thread.rscalled `Result::unwrap()` on an `Err` valuesrc/libstd/sys/unix/os.rsstrerror_r failure`/proc/self/exeno /proc/self/exe available. Is /proc mounted?rwlock maximum reader count exceededrwlock read lock would result in deadlockthread panicked while panicking. aborting.
                <unnamed>note: run with `RUST_BACKTRACE=1` environment variable to display a backtrace.
                ' panicked at '', 
                thread panicked while processing panic. aborting.
                src/libstd/sys/unix/rwlock.rsassertion failed: `(left == right)`
                  left: ``,
                 right: `urn:uuid:called `Option::unwrap()` on a `None` value
                0123456789abcdefABCDEF-/root/.cargo/registry/src/github.com-1ecc6299db9ec823/uuid-0.8.1/src/parser/mod.rs/usr/src/rustc-1.41.1/src/libcore/macros/mod.rsinvalid group lengthinvalid number of groupsinvalid characterinvalid length an optional prefix of `urn:uuid:` followed byexpected  in group one of  : invalid bytes length: expected /proc/curproc/file
                /proc/self/exe
                /proc/%ld/object/a.out
                failed to read executable information
                libbacktrace could not find executable to open
                close
                backtrace library does not support threads
                no debug info in ELF executable
                no symbol table in ELF executable
                .debug_info
                executable file is not ELF
                ELF section name out of range
                .note.gnu.build-id
                .gnu_debuglink
                .opd
                /usr/lib/debug/.build-id/
                .debug/
                /usr/lib/debug/
                fstat
                executable file is unrecognized ELF version
                executable file is unexpected ELF class
                executable file has unknown endianness
                ELF symbol table strtab link out of range
                symbol string index out of range
                 n;^
                Qkkbal
                .data
                .bss
                .comment
            ".LogMessage(_logger, "strings door");
        }
    }
}
