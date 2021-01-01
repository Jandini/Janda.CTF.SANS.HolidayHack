#!/usr/bin/env python3
#
# mt19937.py - a quick and dirty implementation of the MT19937 PRNG in Python
#
#    Copyright (C) 2020  Tom Liston - email: tom.liston@bad-wolf-sec.com
#                                   - twitter: @tliston
#
#    This program is free software: you can redistribute it and/or modify
#    it under the terms of the GNU General Public License as published by
#    the Free Software Foundation, either version 3 of the License, or
#    (at your option) any later version.
#
#    This program is distributed in the hope that it will be useful,
#    but WITHOUT ANY WARRANTY; without even the implied warranty of
#    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
#    GNU General Public License for more details.
#
#    You should have received a copy of the GNU General Public License
#    along with this program.  If not, see [http://www.gnu.org/licenses/].

import random

# this is simply a python implementation of a standard Mersenne Twister PRNG.
# the parameters used, implement the MT19937 variant of the PRNG, based on the
# Mersenne prime 2^19937−1
# see https://en.wikipedia.org/wiki/Mersenne_Twister for a very good explanation
# of the math behind this...

class mt19937():
    u, d = 11, 0xFFFFFFFF
    s, b = 7, 0x9D2C5680
    t, c = 15, 0xEFC60000
    l = 18
    n = 624

    def my_int32(self, x):
        return(x & 0xFFFFFFFF)

    def __init__(self, seed):
        w = 32
        r = 31
        f = 1812433253
        self.m = 397
        self.a = 0x9908B0DF
        self.MT = [0] * self.n
        self.index = self.n + 1
        self.lower_mask = (1 << r) - 1
        self.upper_mask = self.my_int32(~self.lower_mask)
        self.MT[0] = self.my_int32(seed)
        for i in range(1, self.n):
            self.MT[i] = self.my_int32((f * (self.MT[i - 1] ^ (self.MT[i - 1] >> (w - 2))) + i))

    def extract_number(self):
        if self.index >= self.n:
            self.twist()
            self.index = 0
        y = self.MT[self.index]
        # this implements the so-called "tempering matrix"
        # this, functionally, should alter the output to
        # provide a better, higher-dimensional distribution
        # of the most significant bits in the numbers extracted
        y = y ^ ((y >> self.u) & self.d)
        y = y ^ ((y << self.s) & self.b)
        y = y ^ ((y << self.t) & self.c)
        y = y ^ (y >> self.l)
        self.index += 1
        return self.my_int32(y)

    def twist(self):
        for i in range(0, self.n):
            x = (self.MT[i] & self.upper_mask) + (self.MT[(i + 1) % self.n] & self.lower_mask)
            xA = x >> 1
            if(x % 2) != 0:
                xA = xA ^ self.a
            self.MT[i] = self.MT[(i + self.m) % self.n] ^ xA


# so... guess what! while it isn't necessarily obvious, the
# functioning of the tempering matrix are mathematically
# reversible. this function impliments that...
#
# by using this, we can take the output of the MT PRNG, and turn
# it back into the actual values held within the MT[] array itself
# and therefore, we can "clone" the state of the PRNG from "n"
# generated random numbers...
#
# initially, figuring out the math to do this made my brain hurt.
# simplifying it caused even more pain.
# please don't ask me to explain it...
def untemper(y):
    y ^= y >> mt19937.l
    y ^= y << mt19937.t & mt19937.c
    for i in range(7):
        y ^= y << mt19937.s & mt19937.b
    for i in range(3):
        y ^= y >> mt19937.u & mt19937.d
    return y



def randrange(start, stop=None, step=1):
    """Choose a random item from range(start, stop[, step]).
    This fixes the problem with randint() which includes the
    endpoint; in Python this is usually not what you want.
    """

    # This code is a bit messy to make it fast for the
    # common case while still doing adequate error checking.
    istart = int(start)
    if istart != start:
        raise ValueError("non-integer arg 1 for randrange()")
    if stop is None:
        if istart > 0:
            return 0 #self._randbelow(istart)
        raise ValueError("empty range for randrange()")

    # stop argument supplied.
    istop = int(stop)
    if istop != stop:
        raise ValueError("non-integer stop for randrange()")
    width = istop - istart
    if step == 1 and width > 0:
        return istart + self._randbelow(width)
    if step == 1:
        raise ValueError("empty range for randrange() (%d, %d, %d)" % (istart, istop, width))

    # Non-unit step argument supplied.
    istep = int(step)
    if istep != step:
        raise ValueError("non-integer step for randrange()")
    if istep > 0:
        n = (width + istep - 1) // istep
    elif istep < 0:
        n = (width + istep + 1) // istep
    else:
        raise ValueError("zero step for randrange()")

    if n <= 0:
        raise ValueError("empty range for randrange()")

    return istart + istep * 1

if __name__ == "__main__":

    myprng = mt19937(0)        
    #seeds = [3861918429,3322078092,3998220575,410534870,2070460525,1110836886,775883536,3191703455,3567083559,3682874082,3323768966,34188078,3006892870,2699594218,1505570164,3926645650,3319389438,80470376,2038495799,2517998051,1933955356,4067624188,510934693,4193633242,2970893064,755552815,939887943,4098000048,337562999,3611235529,46235549,3514063825,1439072023,3028677699,1932070958,843675790,4057897398,1601003324,4164819362,3957037662,2361676706,1107922325,807923360,4149294445,3071312533,1556384938,131547614,4150174309,984985671,3403809602,1286571435,361256371,1360476949,2008996374,2143750084,3148701348,2647131620,1923020231,3837635104,3741000832,2029646915,525851559,3182486595,568406468,1369229060,883904188,3741867857,3620965687,1165743158,952453502,1852398168,90719700,843261054,2563155661,759184857,252374427,1679692495,3876311979,2511489072,3870151746,889444849,2875938212,928832096,3193646113,3579450430,444131800,2683672789,330646992,1337347569,1473926849,4284262381,916556798,1717633509,215792150,991362734,3636884226,618165866,639668564,3093831895,2563955973,2388645153,3268302460,2499495620,3407934705,2284659283,1084455721,506035836,2868072196,3751371253,1105126058,2066017348,2433004239,1090419362,4007163819,3138771331,51158863,1096249409,2222273262,3251280015,955582350,2180682604,109894808,351085528,809814934,826380072,1239853808,3486555994,3807543273,3239768941,2442637941,659871445,4045316522,3478081244,1285595693,1676033003,2121166445,1123594030,1916242499,3463690744,76369436,2092369662,444172771,1401735748,2851950654,1212528578,3392390866,1049544381,1714218036,3639375418,1987713998,1128628277,2216165700,2059913948,1151929755,2145727301,3289960384,2890356076,1154257427,712709568,3735104719,806598864,2342412866,3924792215,3212213133,1837970086,4174182310,455177230,1651605384,2047958661,1939895333,3494723210,3970528706,654652579,3531686802,252136060,3625169179,1102673540,4121195157,3538716605,361244030,859017186,1098797068,1146446094,328214935,591130884,2385035876,466882398,1791266179,4100340394,356473570,1363057069,1485644200,1459541602,3841599764,351386806,1956367660,2993622963,1544852518,2504473804,1947294430,1919144853,3730378267,3292741402,3165248390,220401879,2138327337,1266505319,1277108249,2079997165,2319000009,3625138234,3660755337,3017321195,2687763114,3888989391,1034406963,1615657651,3815907668,2217997507,3910977721,1104411649,1278698643,1943527475,2155572283,821285839,2819834221,1189776569,4138819870,837042279,1452818392,264677987,783611586,981588504,3473111353,2365790143,2446787392,120143468,555588153,2426050823,3305653235,3294604498,2837385938,569422348,2609788239,826129348,1945617798,2752485382,3464997759,4228919848,1063805776,2116630610,1980378725,30862977,2911979461,769901851,3547415,819640801,2548162828,2665150241,1626776346,1323098485,3228660357,779744306,3567579321,2789102305,3375689963,257226926,1976495135,318673179,1991381844,2763762776,2598953932,3232391781,2131347419,345728627,3661605963,4087183816,1392948139,4230793109,1235143906,972852719,1918216743,1975156902,1273413866,673209367,1373472504,420711068,2740547271,3067420180,1937758621,1677185075,264709301,2498272571,66441731,3311920894,2018814559,601659198,2865638574,3827239189,3214881721,2172871511,2733050176,390410708,2152034017,4079688313,1634515544,4069901951,368133355,3175040345,2688452259,1071759351,1352570450,3698197156,2653060952,1201795846,971499778,3409001440,3950300876,66544575,2039028133,2368024338,2366915706,188399384,3471010844,2344838630,2476879285,1631516301,3192108782,725859452,4047438294,3422541916,2262378508,2094401345,2521434072,2407938914,1555359001,2074846365,1920637399,3300969533,2814379547,3049607562,2920017748,3383367694,114928526,816417207,181021968,1253622095,2088981867,4160852370,906421431,2234237933,3080434019,2337814491,604002489,2826795523,1308338159,1418591631,1495311069,2363894499,3129629763,681324040,1921983799,2285303510,3377442550,3071742289,3954581365,1565606633,2889794756,2183802562,3927913890,1920773832,1721788048,1199939665,2660528622,3792906606,3511218734,1764780800,157941071,2614676251,1256917897,3046627150,855805157,3217721580,2724868494,1915322717,1300108893,1309682099,4090421492,2476386161,375446260,1205101173,503811871,1972916495,951451491,4051455606,1169400267,3007241255,175942623,697836446,916582610,3547332319,340130749,3337856138,2799772539,1958128139,3594557261,2172782361,1627974580,410269864,2492714472,3633790221,336100740,3385771334,175113086,1123110818,4232977986,3742153381,930577410,35544564,2285503078,1928171665,2471414625,56660976,2583259438,3311469583,2880459653,4033189933,315983717,4107887722,1997363719,703566075,4138892550,1236819556,1409287002,3294118720,2232036019,4252794443,3224029294,805412867,4196647199,3849594068,516193195,1143408213,3020782016,1572843469,3565795289,2517795229,365917988,3618717273,4128413724,3694404542,1136474911,2872927814,4280373392,1871767761,1021418363,2765465906,2670150665,590091911,1785858804,458051424,2201618284,275102102,1139549773,3725563401,3705323012,1609240010,1018908542,169777000,2821410261,233108791,573389751,445216101,4161791947,2326016772,2965779346,2281985560,678538106,3663836113,1883170092,920051685,1957059034,3519778529,988380403,2249055855,1717849401,252153828,3266287920,500567297,928110840,609572845,3625392707,1935679396,1790536982,2853893474,2314329193,2771879946,3367480767,687358273,1990934973,3658111050,718597990,3017535367,3629971641,113356715,800657693,519105967,4229842693,1636161736,2541629363,1126694471,773624388,960355475,232685030,900048209,4148598359,3965250896,389400787,2444419809,2790432855,3913649798,2391140325,1816110006,1430912097,2640551182,3525173731,1287294936,2820882415,4141941152,3877674984,3127110607,1564926696,3682997714,2227664278,256502575,56420814,1992695811,1569195046,3947877688,2806881655,2537282961,766133020,1361877139,1609685925,1735188048,1968389174,1973952427,1155163341,996258510,3993333049,1635724600,1883772199,317110545,3992462514,3944826537,1084113462,3009173408,2078641908,710111455,4220383772,3419919314,1977660679,695736330,2217887042,4252811819,71013698,4049175189,555721613,3638239470,2852814399,2942542572,250013270,1741315255,3102489873,1875131133,3655113588,251233378,1096152540,1346886032,3210923884,2573802449,2723807227,856235443,474286843,2912255087,2442862422,2696335268,1104806072,4031577612,1918008896,2740693876,2954355216,67184979,4103074061,2464246130,656103009,3101120438,1569323020,4246981408,3624384284,210262579,694525916,2805339316,2091708111,3697883589,3408664018,1714044080,3669531111,2799877087,1357793940,2396725070,2808032626,3634251585,870420128,1051051219,2864477545,2697870780,1009820228,3046913404,3628354036,3280046336,705727807,1526890803,724601804]
    
    #for i in range(mt19937.n):
    #    myprng.MT[i] = untemper(seeds[i])

    randrange(0xFFFFFFFFFFFFFFFF)

    random.seed()
    #print("randrange : %s " % ('%016.016x' % (random.randrange(0xFFFFFFFF))))
    random.random()
    print(random.getstate())

    pass
    random.seed()
    print("randrange : %s " % ('%016.016x' % (random.randrange(0xFFFFFFFFFFFFFFFF))))
    print(random.getstate())

    print("extract   : %s " % ('%016.016x' % (myprng.extract_number())))
    
    print("Run easy level with player name: %i" % myprng.extract_number())
        
