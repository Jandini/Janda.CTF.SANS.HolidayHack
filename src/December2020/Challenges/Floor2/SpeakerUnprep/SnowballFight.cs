using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Type = "Game", Name = "Snowball Fight")]
    public class SnowballFight : IChallenge
    {
        private readonly ILogger<SnowballFight> _logger;
        private readonly IWebBrowserService _webBrowser;

        public SnowballFight(ILogger<SnowballFight> logger, IWebBrowserService webBrowser)
        {
            _logger = logger;
            _webBrowser = webBrowser;
        }


        public void Talks()
        {
            @"
                Tom Liston, Random Facts About Mersenne Twisters | KringleCon 2020
                https://www.youtube.com/watch?v=Jo5Nlbqd-Vg&t=3s


            ".Blog(_logger, "Talks");
        }


        public void Run()
        {
            var random = new Random(0);
            var numbers = new List<int>();

            for (int i = 0; i < 10; i++)
                numbers.Add(random.Next() % 10);

            string.Join(",", numbers).Blog(_logger);


            @"
                                 4,0  5,0  6,0
             0,1
             0,2
             0,3
             0,4                 4,3  5,3

                  1,5  2,5  3,5  4,5  5,5
                            3,6  4,6  5,6

            ".Blog(_logger, "Player (seed) = 0... if i could only relate the random value to the position... less likely...");


            var comment =
            @"
            <!--
                Seeds attempted:
    
                3861918429 - Not random enough
                3322078092 - Not random enough
                3998220575 - Not random enough
                410534870 - Not random enough
                2070460525 - Not random enough
                1110836886 - Not random enough
                775883536 - Not random enough
                3191703455 - Not random enough
                3567083559 - Not random enough
                3682874082 - Not random enough
                3323768966 - Not random enough
                34188078 - Not random enough
                3006892870 - Not random enough
                2699594218 - Not random enough
                1505570164 - Not random enough
                3926645650 - Not random enough
                3319389438 - Not random enough
                80470376 - Not random enough
                2038495799 - Not random enough
                2517998051 - Not random enough
                1933955356 - Not random enough
                4067624188 - Not random enough
                510934693 - Not random enough
                4193633242 - Not random enough
                2970893064 - Not random enough
                755552815 - Not random enough
                939887943 - Not random enough
                4098000048 - Not random enough
                337562999 - Not random enough
                3611235529 - Not random enough
                46235549 - Not random enough
                3514063825 - Not random enough
                1439072023 - Not random enough
                3028677699 - Not random enough
                1932070958 - Not random enough
                843675790 - Not random enough
                4057897398 - Not random enough
                1601003324 - Not random enough
                4164819362 - Not random enough
                3957037662 - Not random enough
                2361676706 - Not random enough
                1107922325 - Not random enough
                807923360 - Not random enough
                4149294445 - Not random enough
                3071312533 - Not random enough
                1556384938 - Not random enough
                131547614 - Not random enough
                4150174309 - Not random enough
                984985671 - Not random enough
                3403809602 - Not random enough
                1286571435 - Not random enough
                361256371 - Not random enough
                1360476949 - Not random enough
                2008996374 - Not random enough
                2143750084 - Not random enough
                3148701348 - Not random enough
                2647131620 - Not random enough
                1923020231 - Not random enough
                3837635104 - Not random enough
                3741000832 - Not random enough
                2029646915 - Not random enough
                525851559 - Not random enough
                3182486595 - Not random enough
                568406468 - Not random enough
                1369229060 - Not random enough
                883904188 - Not random enough
                3741867857 - Not random enough
                3620965687 - Not random enough
                1165743158 - Not random enough
                952453502 - Not random enough
                1852398168 - Not random enough
                90719700 - Not random enough
                843261054 - Not random enough
                2563155661 - Not random enough
                759184857 - Not random enough
                252374427 - Not random enough
                1679692495 - Not random enough
                3876311979 - Not random enough
                2511489072 - Not random enough
                3870151746 - Not random enough
                889444849 - Not random enough
                2875938212 - Not random enough
                928832096 - Not random enough
                3193646113 - Not random enough
                3579450430 - Not random enough
                444131800 - Not random enough
                2683672789 - Not random enough
                330646992 - Not random enough
                1337347569 - Not random enough
                1473926849 - Not random enough
                4284262381 - Not random enough
                916556798 - Not random enough
                1717633509 - Not random enough
                215792150 - Not random enough
                991362734 - Not random enough
                3636884226 - Not random enough
                618165866 - Not random enough
                639668564 - Not random enough
                3093831895 - Not random enough
                2563955973 - Not random enough
                2388645153 - Not random enough
                3268302460 - Not random enough
                2499495620 - Not random enough
                3407934705 - Not random enough
                2284659283 - Not random enough
                1084455721 - Not random enough
                506035836 - Not random enough
                2868072196 - Not random enough
                3751371253 - Not random enough
                1105126058 - Not random enough
                2066017348 - Not random enough
                2433004239 - Not random enough
                1090419362 - Not random enough
                4007163819 - Not random enough
                3138771331 - Not random enough
                51158863 - Not random enough
                1096249409 - Not random enough
                2222273262 - Not random enough
                3251280015 - Not random enough
                955582350 - Not random enough
                2180682604 - Not random enough
                109894808 - Not random enough
                351085528 - Not random enough
                809814934 - Not random enough
                826380072 - Not random enough
                1239853808 - Not random enough
                3486555994 - Not random enough
                3807543273 - Not random enough
                3239768941 - Not random enough
                2442637941 - Not random enough
                659871445 - Not random enough
                4045316522 - Not random enough
                3478081244 - Not random enough
                1285595693 - Not random enough
                1676033003 - Not random enough
                2121166445 - Not random enough
                1123594030 - Not random enough
                1916242499 - Not random enough
                3463690744 - Not random enough
                76369436 - Not random enough
                2092369662 - Not random enough
                444172771 - Not random enough
                1401735748 - Not random enough
                2851950654 - Not random enough
                1212528578 - Not random enough
                3392390866 - Not random enough
                1049544381 - Not random enough
                1714218036 - Not random enough
                3639375418 - Not random enough
                1987713998 - Not random enough
                1128628277 - Not random enough
                2216165700 - Not random enough
                2059913948 - Not random enough
                1151929755 - Not random enough
                2145727301 - Not random enough
                3289960384 - Not random enough
                2890356076 - Not random enough
                1154257427 - Not random enough
                712709568 - Not random enough
                3735104719 - Not random enough
                806598864 - Not random enough
                2342412866 - Not random enough
                3924792215 - Not random enough
                3212213133 - Not random enough
                1837970086 - Not random enough
                4174182310 - Not random enough
                455177230 - Not random enough
                1651605384 - Not random enough
                2047958661 - Not random enough
                1939895333 - Not random enough
                3494723210 - Not random enough
                3970528706 - Not random enough
                654652579 - Not random enough
                3531686802 - Not random enough
                252136060 - Not random enough
                3625169179 - Not random enough
                1102673540 - Not random enough
                4121195157 - Not random enough
                3538716605 - Not random enough
                361244030 - Not random enough
                859017186 - Not random enough
                1098797068 - Not random enough
                1146446094 - Not random enough
                328214935 - Not random enough
                591130884 - Not random enough
                2385035876 - Not random enough
                466882398 - Not random enough
                1791266179 - Not random enough
                4100340394 - Not random enough
                356473570 - Not random enough
                1363057069 - Not random enough
                1485644200 - Not random enough
                1459541602 - Not random enough
                3841599764 - Not random enough
                351386806 - Not random enough
                1956367660 - Not random enough
                2993622963 - Not random enough
                1544852518 - Not random enough
                2504473804 - Not random enough
                1947294430 - Not random enough
                1919144853 - Not random enough
                3730378267 - Not random enough
                3292741402 - Not random enough
                3165248390 - Not random enough
                220401879 - Not random enough
                2138327337 - Not random enough
                1266505319 - Not random enough
                1277108249 - Not random enough
                2079997165 - Not random enough
                2319000009 - Not random enough
                3625138234 - Not random enough
                3660755337 - Not random enough
                3017321195 - Not random enough
                2687763114 - Not random enough
                3888989391 - Not random enough
                1034406963 - Not random enough
                1615657651 - Not random enough
                3815907668 - Not random enough
                2217997507 - Not random enough
                3910977721 - Not random enough
                1104411649 - Not random enough
                1278698643 - Not random enough
                1943527475 - Not random enough
                2155572283 - Not random enough
                821285839 - Not random enough
                2819834221 - Not random enough
                1189776569 - Not random enough
                4138819870 - Not random enough
                837042279 - Not random enough
                1452818392 - Not random enough
                264677987 - Not random enough
                783611586 - Not random enough
                981588504 - Not random enough
                3473111353 - Not random enough
                2365790143 - Not random enough
                2446787392 - Not random enough
                120143468 - Not random enough
                555588153 - Not random enough
                2426050823 - Not random enough
                3305653235 - Not random enough
                3294604498 - Not random enough
                2837385938 - Not random enough
                569422348 - Not random enough
                2609788239 - Not random enough
                826129348 - Not random enough
                1945617798 - Not random enough
                2752485382 - Not random enough
                3464997759 - Not random enough
                4228919848 - Not random enough
                1063805776 - Not random enough
                2116630610 - Not random enough
                1980378725 - Not random enough
                30862977 - Not random enough
                2911979461 - Not random enough
                769901851 - Not random enough
                3547415 - Not random enough
                819640801 - Not random enough
                2548162828 - Not random enough
                2665150241 - Not random enough
                1626776346 - Not random enough
                1323098485 - Not random enough
                3228660357 - Not random enough
                779744306 - Not random enough
                3567579321 - Not random enough
                2789102305 - Not random enough
                3375689963 - Not random enough
                257226926 - Not random enough
                1976495135 - Not random enough
                318673179 - Not random enough
                1991381844 - Not random enough
                2763762776 - Not random enough
                2598953932 - Not random enough
                3232391781 - Not random enough
                2131347419 - Not random enough
                345728627 - Not random enough
                3661605963 - Not random enough
                4087183816 - Not random enough
                1392948139 - Not random enough
                4230793109 - Not random enough
                1235143906 - Not random enough
                972852719 - Not random enough
                1918216743 - Not random enough
                1975156902 - Not random enough
                1273413866 - Not random enough
                673209367 - Not random enough
                1373472504 - Not random enough
                420711068 - Not random enough
                2740547271 - Not random enough
                3067420180 - Not random enough
                1937758621 - Not random enough
                1677185075 - Not random enough
                264709301 - Not random enough
                2498272571 - Not random enough
                66441731 - Not random enough
                3311920894 - Not random enough
                2018814559 - Not random enough
                601659198 - Not random enough
                2865638574 - Not random enough
                3827239189 - Not random enough
                3214881721 - Not random enough
                2172871511 - Not random enough
                2733050176 - Not random enough
                390410708 - Not random enough
                2152034017 - Not random enough
                4079688313 - Not random enough
                1634515544 - Not random enough
                4069901951 - Not random enough
                368133355 - Not random enough
                3175040345 - Not random enough
                2688452259 - Not random enough
                1071759351 - Not random enough
                1352570450 - Not random enough
                3698197156 - Not random enough
                2653060952 - Not random enough
                1201795846 - Not random enough
                971499778 - Not random enough
                3409001440 - Not random enough
                3950300876 - Not random enough
                66544575 - Not random enough
                2039028133 - Not random enough
                2368024338 - Not random enough
                2366915706 - Not random enough
                188399384 - Not random enough
                3471010844 - Not random enough
                2344838630 - Not random enough
                2476879285 - Not random enough
                1631516301 - Not random enough
                3192108782 - Not random enough
                725859452 - Not random enough
                4047438294 - Not random enough
                3422541916 - Not random enough
                2262378508 - Not random enough
                2094401345 - Not random enough
                2521434072 - Not random enough
                2407938914 - Not random enough
                1555359001 - Not random enough
                2074846365 - Not random enough
                1920637399 - Not random enough
                3300969533 - Not random enough
                2814379547 - Not random enough
                3049607562 - Not random enough
                2920017748 - Not random enough
                3383367694 - Not random enough
                114928526 - Not random enough
                816417207 - Not random enough
                181021968 - Not random enough
                1253622095 - Not random enough
                2088981867 - Not random enough
                4160852370 - Not random enough
                906421431 - Not random enough
                2234237933 - Not random enough
                3080434019 - Not random enough
                2337814491 - Not random enough
                604002489 - Not random enough
                2826795523 - Not random enough
                1308338159 - Not random enough
                1418591631 - Not random enough
                1495311069 - Not random enough
                2363894499 - Not random enough
                3129629763 - Not random enough
                681324040 - Not random enough
                1921983799 - Not random enough
                2285303510 - Not random enough
                3377442550 - Not random enough
                3071742289 - Not random enough
                3954581365 - Not random enough
                1565606633 - Not random enough
                2889794756 - Not random enough
                2183802562 - Not random enough
                3927913890 - Not random enough
                1920773832 - Not random enough
                1721788048 - Not random enough
                1199939665 - Not random enough
                2660528622 - Not random enough
                3792906606 - Not random enough
                3511218734 - Not random enough
                1764780800 - Not random enough
                157941071 - Not random enough
                2614676251 - Not random enough
                1256917897 - Not random enough
                3046627150 - Not random enough
                855805157 - Not random enough
                3217721580 - Not random enough
                2724868494 - Not random enough
                1915322717 - Not random enough
                1300108893 - Not random enough
                1309682099 - Not random enough
                4090421492 - Not random enough
                2476386161 - Not random enough
                375446260 - Not random enough
                1205101173 - Not random enough
                503811871 - Not random enough
                1972916495 - Not random enough
                951451491 - Not random enough
                4051455606 - Not random enough
                1169400267 - Not random enough
                3007241255 - Not random enough
                175942623 - Not random enough
                697836446 - Not random enough
                916582610 - Not random enough
                3547332319 - Not random enough
                340130749 - Not random enough
                3337856138 - Not random enough
                2799772539 - Not random enough
                1958128139 - Not random enough
                3594557261 - Not random enough
                2172782361 - Not random enough
                1627974580 - Not random enough
                410269864 - Not random enough
                2492714472 - Not random enough
                3633790221 - Not random enough
                336100740 - Not random enough
                3385771334 - Not random enough
                175113086 - Not random enough
                1123110818 - Not random enough
                4232977986 - Not random enough
                3742153381 - Not random enough
                930577410 - Not random enough
                35544564 - Not random enough
                2285503078 - Not random enough
                1928171665 - Not random enough
                2471414625 - Not random enough
                56660976 - Not random enough
                2583259438 - Not random enough
                3311469583 - Not random enough
                2880459653 - Not random enough
                4033189933 - Not random enough
                315983717 - Not random enough
                4107887722 - Not random enough
                1997363719 - Not random enough
                703566075 - Not random enough
                4138892550 - Not random enough
                1236819556 - Not random enough
                1409287002 - Not random enough
                3294118720 - Not random enough
                2232036019 - Not random enough
                4252794443 - Not random enough
                3224029294 - Not random enough
                805412867 - Not random enough
                4196647199 - Not random enough
                3849594068 - Not random enough
                516193195 - Not random enough
                1143408213 - Not random enough
                3020782016 - Not random enough
                1572843469 - Not random enough
                3565795289 - Not random enough
                2517795229 - Not random enough
                365917988 - Not random enough
                3618717273 - Not random enough
                4128413724 - Not random enough
                3694404542 - Not random enough
                1136474911 - Not random enough
                2872927814 - Not random enough
                4280373392 - Not random enough
                1871767761 - Not random enough
                1021418363 - Not random enough
                2765465906 - Not random enough
                2670150665 - Not random enough
                590091911 - Not random enough
                1785858804 - Not random enough
                458051424 - Not random enough
                2201618284 - Not random enough
                275102102 - Not random enough
                1139549773 - Not random enough
                3725563401 - Not random enough
                3705323012 - Not random enough
                1609240010 - Not random enough
                1018908542 - Not random enough
                169777000 - Not random enough
                2821410261 - Not random enough
                233108791 - Not random enough
                573389751 - Not random enough
                445216101 - Not random enough
                4161791947 - Not random enough
                2326016772 - Not random enough
                2965779346 - Not random enough
                2281985560 - Not random enough
                678538106 - Not random enough
                3663836113 - Not random enough
                1883170092 - Not random enough
                920051685 - Not random enough
                1957059034 - Not random enough
                3519778529 - Not random enough
                988380403 - Not random enough
                2249055855 - Not random enough
                1717849401 - Not random enough
                252153828 - Not random enough
                3266287920 - Not random enough
                500567297 - Not random enough
                928110840 - Not random enough
                609572845 - Not random enough
                3625392707 - Not random enough
                1935679396 - Not random enough
                1790536982 - Not random enough
                2853893474 - Not random enough
                2314329193 - Not random enough
                2771879946 - Not random enough
                3367480767 - Not random enough
                687358273 - Not random enough
                1990934973 - Not random enough
                3658111050 - Not random enough
                718597990 - Not random enough
                3017535367 - Not random enough
                3629971641 - Not random enough
                113356715 - Not random enough
                800657693 - Not random enough
                519105967 - Not random enough
                4229842693 - Not random enough
                1636161736 - Not random enough
                2541629363 - Not random enough
                1126694471 - Not random enough
                773624388 - Not random enough
                960355475 - Not random enough
                232685030 - Not random enough
                900048209 - Not random enough
                4148598359 - Not random enough
                3965250896 - Not random enough
                389400787 - Not random enough
                2444419809 - Not random enough
                2790432855 - Not random enough
                3913649798 - Not random enough
                2391140325 - Not random enough
                1816110006 - Not random enough
                1430912097 - Not random enough
                2640551182 - Not random enough
                3525173731 - Not random enough
                1287294936 - Not random enough
                2820882415 - Not random enough
                4141941152 - Not random enough
                3877674984 - Not random enough
                3127110607 - Not random enough
                1564926696 - Not random enough
                3682997714 - Not random enough
                2227664278 - Not random enough
                256502575 - Not random enough
                56420814 - Not random enough
                1992695811 - Not random enough
                1569195046 - Not random enough
                3947877688 - Not random enough
                2806881655 - Not random enough
                2537282961 - Not random enough
                766133020 - Not random enough
                1361877139 - Not random enough
                1609685925 - Not random enough
                1735188048 - Not random enough
                1968389174 - Not random enough
                1973952427 - Not random enough
                1155163341 - Not random enough
                996258510 - Not random enough
                3993333049 - Not random enough
                1635724600 - Not random enough
                1883772199 - Not random enough
                317110545 - Not random enough
                3992462514 - Not random enough
                3944826537 - Not random enough
                1084113462 - Not random enough
                3009173408 - Not random enough
                2078641908 - Not random enough
                710111455 - Not random enough
                4220383772 - Not random enough
                3419919314 - Not random enough
                1977660679 - Not random enough
                695736330 - Not random enough
                2217887042 - Not random enough
                4252811819 - Not random enough
                71013698 - Not random enough
                4049175189 - Not random enough
                555721613 - Not random enough
                3638239470 - Not random enough
                2852814399 - Not random enough
                2942542572 - Not random enough
                250013270 - Not random enough
                1741315255 - Not random enough
                3102489873 - Not random enough
                1875131133 - Not random enough
                3655113588 - Not random enough
                251233378 - Not random enough
                1096152540 - Not random enough
                1346886032 - Not random enough
                3210923884 - Not random enough
                2573802449 - Not random enough
                2723807227 - Not random enough
                856235443 - Not random enough
                474286843 - Not random enough
                2912255087 - Not random enough
                2442862422 - Not random enough
                2696335268 - Not random enough
                1104806072 - Not random enough
                4031577612 - Not random enough
                1918008896 - Not random enough
                2740693876 - Not random enough
                2954355216 - Not random enough
                67184979 - Not random enough
                4103074061 - Not random enough
                2464246130 - Not random enough
                656103009 - Not random enough
                3101120438 - Not random enough
                1569323020 - Not random enough
                4246981408 - Not random enough
                3624384284 - Not random enough
                210262579 - Not random enough
                694525916 - Not random enough
                2805339316 - Not random enough
                2091708111 - Not random enough
                3697883589 - Not random enough
                3408664018 - Not random enough
                1714044080 - Not random enough
                3669531111 - Not random enough
                2799877087 - Not random enough
                1357793940 - Not random enough
                2396725070 - Not random enough
                2808032626 - Not random enough
                3634251585 - Not random enough
                870420128 - Not random enough
                1051051219 - Not random enough
                2864477545 - Not random enough
                2697870780 - Not random enough
                1009820228 - Not random enough
                3046913404 - Not random enough
                3628354036 - Not random enough
                3280046336 - Not random enough
                705727807 - Not random enough
                1526890803 - Not random enough
                724601804 - Not random enough
                <Redacted!> - Perfect!
              -->
            ".Blog(_logger, "Found in page source when run with impossible difficulty level.");



            var regex = new Regex("\\d{1,10}");
            var seeds = new List<string>();
            foreach (var match in regex.Matches(comment))
                seeds.Add(match.ToString());

            ("seeds = [" + string.Join(",", seeds) + "]").Blog(_logger, "{0} random numbers. Use them to clone MT seed table and get the next `Player Name` number. ", seeds.Count);


        }
     
        public void OpenWebsites()
        {
            _webBrowser.Open("https://snowball2.kringlecastle.com/game");
            _webBrowser.Open("https://github.com/tliston/mt19937/blob/main/mt19937.py");
            _webBrowser.Open("https://www.youtube.com/watch?v=Jo5Nlbqd-Vg");
            _webBrowser.Open("https://github.com/kmyk/mersenne-twister-predictor/blob/master/readme.md");
        }
    }
}
