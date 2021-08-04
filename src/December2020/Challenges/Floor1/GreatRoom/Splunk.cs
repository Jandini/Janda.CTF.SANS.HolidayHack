using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{

    [Challenge (Type = "Objective", Number = 6, Name = "Splunk Challenge", Points = 3, Flag = "The Lollipop Guild")]
    public class Splunk : IChallenge
    {
        private readonly ILogger<Splunk> _logger;
        readonly IWebBrowserService _webBrowser;

        public Splunk(ILogger<Splunk> logger, IWebBrowserService webBrowser)
        {
            _logger = logger;
            _webBrowser = webBrowser;
        }
        public void About()
        {

            @"
                Access the Splunk terminal in the Great Room. 
                What is the name of the adversary group that Santa feared would attack KringleCon?

            ".Blog(_logger, "About");
        }

        public void Run()
        {
            "https://splunk.kringlecastle.com/en-US/account/insecurelogin?username=santa&password=2f3a4fccca6406e35bcf33e92dd93135"
                .Blog(_logger, "Splunk url taken from java script page... before becomming Santa");


            @"
                | tstats count where index=* by index
                | metadata index=attack type=hosts

                index=attack

                index=attack | fields Technique | uniq

                index= * | mitremap

                | tstats values(sourcetypes) where index=*

                index=* sourcetype=wineventlog

                | metadata type=sourcetypes index=*

            ".Blog(_logger, "Learning random searches");


            @"
	                firstTime	lastTime	recentTime	sourcetype	totalCount	type
                1	1606762640	1606770257	1606770258	WinEventLog	10283	sourcetypes
                2	1606762873	1606769955	1606770075	wineventlog	220669	sourcetypes
                3	1606762638	1606770232	1606770234	xmlwineventlog	42499	sourcetypes
                4	1606758856	1606770255	1606770259	bro:conn:json	13921	sourcetypes
                5	1606762029	1606769631	1606769631	bro:dns:json	44	sourcetypes
                6	1606761928	1606770250	1606770252	bro:files:json	5812	sourcetypes
                7	1606762801	1606770250	1606770252	bro:http:json	2597	sourcetypes
                8	1606761921	1606770230	1606770236	bro:rdp:json	2363	sourcetypes
                9	1606763121	1606769601	1606769602	bro:smb_files:json	2	sourcetypes
                10	1606763121	1606769635	1606769635	bro:smb_mapping:json	8	sourcetypes
                11	1606769219	1606769219	1606769479	bro:software:json	1	sourcetypes
                12	1606761926	1606770230	1606770230	bro:ssl:json	2725	sourcetypes
                13	1606761927	1606770230	1606770230	bro:x509:json	2722	sourcetypes
                14	1606754786	1606769951	1606770027	csv	68	sourcetypes

            ".Blog(_logger, "| metadata type=sourcetypes index=*");

            @"
	                index	count
                1	attack	68
                2	t1033-main	3311
                3	t1033-win	21734
                4	t1057-win	18006
                5	t1059.003-main	1984
                6	t1059.003-win	18519
                7	t1059.005-main	1758
                8	t1059.005-win	18852
                9	t1071.001-main	2795
                10	t1071.001-win	20718
                11	t1082-win	18136
                12	t1105-main	1938
                13	t1105-win	15424
                14	t1106-main	1611
                15	t1106-win	18720
                16	t1123-main	4281
                17	t1123-win	20488
                18	t1204.002-main	1342
                19	t1204.002-win	20033
                20	t1547.001-main	1833
                21	t1547.001-win	19490
                22	t1548.002-main	7018
                23	t1548.002-win	21499
                24	t1559.002-main	2324
                25	t1559.002-win	22144
                26	t1566.001-win	19688
            ".Blog(_logger, "| tstats count where index=* by index");


            @"                
                Manual: 
                Count distinct from index list: t1033,t1057,t1059,t1071,t1082,t1105,t1106,t1123,t1204,t1547,t1548,t1559,t1566


                Hint from chat: 
                The search I used was:

                | tstats count where index=* by index 
                | search index=T*-win OR T*-main
                | rex field=index ""(?< technique > t\d +)[\.\-].0 * "" 
                | stats dc(technique)


            ".Blog(_logger, "Q1: How many distinct MITRE ATT & CK techniques did Alice emulate? {Answer}", 13);


            @"
                t1059.003-main t1059.003-win
            ".Blog(_logger, "Q2: What are the names of the two indexes that contain the results of emulating Enterprise ATT&CK technique 1059.003 ? (Put them in alphabetical order and separate them with a space) {Answer}", "t1059.003-main t1059.003-win");


            @"
                index=* ""system information discovery""

                Goggle ""system information discovery mirte""

                https://attack.mitre.org/techniques/T1082/
                https://atomicredteam.io/
                https://github.com/redcanaryco/atomic-red-team/tree/master/atomics 

                From: 

                https://github.com/redcanaryco/atomic-red-team/blob/master/atomics/T1082/T1082.md

                Atomic Test #8 - Windows MachineGUID Discovery
                Identify the Windows MachineGUID value for a system. Upon execution, the machine GUID will be displayed from registry.

                Supported Platforms: Windows

                Attack Commands: Run with command_prompt!
                REG QUERY HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Cryptography /v MachineGuid

            ".Blog(_logger, "Q3: One technique that Santa had us simulate deals with 'system information discovery'. What is the full name of the registry key that is queried to determine the MachineGuid? {Answer}", "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Cryptography");



            @"
                index=* OSTAP | sort +_time

                ""2020-11-30T17:44:15Z"",""2020-11-30T17:44:15"",""T1105"",""11"",""OSTAP Worming Activity"",""win-dc-748"",""attackrange\administrator"",""2ca61766-b456-4fcf-a35a-1233685e1cad""

              
            ".Blog(_logger, "Q4: According to events recorded by the Splunk Attack Range, when was the first OSTAP related atomic test executed? (Please provide the alphanumeric UTC timestamp.) {Answer}", "2020-11-30T17:44:15Z");


            @"
                index=* EventCode=1
                index=* ProcessID=*

                index=* ProcessID=* | stats dc(ProcessID) by ProcessID

                index=* ProcessId=* | stats dc(ProcessId) by ProcessId
                index=* ProcessId=* EventCode=1 ""Microsoft-Windows-Sysmon"" | stats dc(ProcessId) by ProcessId

                index=T* ProcessId=* EventCode=1 ""Microsoft-Windows-Sysmon"" | stats list(ProcessId) by ProcessId

                100
                1016
                1020
                1040
                1048
                1076
                1080
                1084
                1092
                1096
                1124
                ...
                2256
                2264
                2268
                2272
                2284
                2296
                2300
                ... 700ish hits... too many

                https://github.com/frgnca/AudioDeviceCmdlets
                https://github.com/redcanaryco/atomic-red-team/search?q=AudioDeviceCmdlets

                https://github.com/redcanaryco/atomic-red-team/blob/8eb52117b748d378325f7719554a896e37bccec7/atomics/T1123/T1123.md

                index=T1123* ProcessId=* ""Microsoft-Windows-Sysmon"" EventCode=1


                index=T1123* ProcessId=* ""Microsoft-Windows-Sysmon"" EventCode=1 powershell.exe -Command WindowsAudioDevice-Powershell-Cmdlet | sort +UtcTime

            ".Blog(_logger, "Q5: One Atomic Red Team test executed by the Attack Range makes use of an open source package authored by frgnca on GitHub. According to Sysmon (Event Code 1) events in Splunk, what was the ProcessId associated with the first use of this component? {Answer}", "3648");


            @"
                Find Atomic Test related to registry run keys...
                https://github.com/redcanaryco/atomic-red-team/search?q=registry+run+keys                
                https://github.com/redcanaryco/atomic-red-team/tree/5ff80f6f90c056b0bfe3a6ffa0f5015f215c56b0/atomics/T1547.001                
                https://github.com/redcanaryco/atomic-red-team/blob/5ff80f6f90c056b0bfe3a6ffa0f5015f215c56b0/atomics/T1547.001/T1547.001.md#atomic-test-6---suspicious-bat-file-run-from-startup-folder

                index=* batstartup.bat
                
                it was not this one... so went to find all bat files in atomice-red-team...
                https://github.com/redcanaryco/atomic-red-team/blob/8eb52117b748d378325f7719554a896e37bccec7/atomics/T1074.001/src/Discovery.bat
                
            ".Blog(_logger, "Q6: Alice ran a simulation of an attacker abusing Windows registry run keys. This technique leveraged a multi-line batch file that was also used by a few other techniques. What is the final command of this multi-line batch file used as part of this simulation? {Answer}", "quser");
      

            @"

                | tstats count where index=* groupby sourcetype _time

	                sourcetype	_time	count
                1	WinEventLog	2020-11-30	10283
                2	WinEventLog:Microsoft-Windows-PowerShell/Operational	2020-11-30	220669
                3	XmlWinEventLog:Microsoft-Windows-Sysmon/Operational	    2020-11-30	42499
                4	bro:conn:json	2020-11-30	13921
                5	bro:dns:json	2020-11-30	44
                6	bro:files:json	2020-11-30	5812
                7	bro:http:json	2020-11-30	2597
                8	bro:rdp:json	2020-11-30	2363
                9	bro:smb_files:json	2020-11-30	2
                10	bro:smb_mapping:json	2020-11-30	8
                11	bro:software:json	2020-11-30	1
                12	bro:ssl:json	2020-11-30	2725
                13	bro:x509:json	2020-11-30	2722
                14	csv	2020-11-30	68

                
                There's 2722 events for bro:x509:json

                index=* sourcetype=bro:x509*

                index=* sourcetype=bro:x509* win-dc | stats dc(certificate.serial) by certificate.serial

            ".Blog(_logger, "Q7: According to x509 certificate events captured by Zeek (formerly Bro), what is the serial number of the TLS certificate assigned to the Windows domain controller in the attack range? {answer}", "55FCEEBB21270D9249E86F4B9DC7AA60");


            @"
                This last one is encrypted using your favorite phrase! The base64 encoded ciphertext is:
                7FXjP1lyfKbyDK/MChyf36h7
                It's encrypted with an old algorithm that uses a key. We don't care about RFC 7465 up here! I leave it to the elves to determine which one!
                Santa (me)
                My favorite phrase?
                Alice Bluebird
                I can't believe the Splunk folks put it in their talk!

                Stay Frosty from https://www.youtube.com/watch?v=RxVgEFt08kU&t=511s
                RC4 from https://www.bing.com/search?q=RFC+7465&cvid=772218431bea44e08ecb8e6729a731e6&FORM=ANAB01&PC=U531

                https://gchq.github.io/CyberChef/#recipe=From_Base64('A-Za-z0-9%2B/%3D',true)RC4(%7B'option':'UTF8','string':'Stay%20Frosty'%7D,'Latin1','Latin1')&input=N0ZYalAxbHlmS2J5REsvTUNoeWYzNmg3

            ".Blog(_logger);
        }
    }
}
