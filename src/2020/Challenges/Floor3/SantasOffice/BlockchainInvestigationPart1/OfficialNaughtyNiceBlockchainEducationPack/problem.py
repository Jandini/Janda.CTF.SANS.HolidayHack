import time
import random


class mt19937():
    u, d = 11, 0xFFFFFFFF
    s, b = 7, 0x9D2C5680
    t, c = 15, 0xEFC60000
    l = 18
    n = 624



def untemper(y):
    y ^= y >> mt19937.l
    y ^= y << mt19937.t & mt19937.c
    for i in range(7):
        y ^= y << mt19937.s & mt19937.b
    for i in range(3):
        y ^= y >> mt19937.u & mt19937.d
    return y

if __name__ == '__main__':

    r = random.Random(0)

    #print(r.randrange(0xFFFFFFFF)) # this will generate 3626764237
    #print(r.randrange(0xFFFFFFFF)) # this will generate 1654615998

    print(r.randrange(0xFFFFFFFFFFFFFFFF)) # this will generate 7106521602475165645

    print("     %i, %i" % (untemper(3626764237), untemper(1654615998)))
    print(r.getstate())
    

    # how 7106521602475165645 is made of 3626764237 and 1654615998

    # 3626764237 = 11011000001011000000011111001101
    # 1654615998 = 01100010100111110110111110111110

    # 7106521602475165645 = 0110001010011111011011111011111011011000001011000000011111001101


    # Find the current value of INDEX
    old_index = r.getstate()[1][-1]
    # Call one of the module's methods
    #n = r.random()

    n = r.randrange(0xFFFFFFFF)

    new_index = r.getstate()[1][-1]

    # the random() method used 2 32-bit integers
    print((new_index - old_index) % 624)


    
    random.seed(0)    
    with open("un.txt", "w+") as f:
        for i in range(32):
            v = r.randrange(0xFFFFFFFF)
            # int.from_bytes(random._urandom(4), 'big')
            f.write("%i\n" % (v))
    