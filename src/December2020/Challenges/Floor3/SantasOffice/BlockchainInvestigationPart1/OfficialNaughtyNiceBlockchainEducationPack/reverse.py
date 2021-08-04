import time
import random



N = 624
M = 397
A = 0x9908b0df
# Upper 1 bit (w - r = 1)
UPPER_MASK = 0x80000000
# Lower 31 bits (r = 31)
LOWER_MASK = 0x7fffffff

def twist_state_map(state):
    res = []
    for i in range(N):
        y = (state[i] & UPPER_MASK) | (state[(i+1) % N] & LOWER_MASK)
        next_item = state[(i + M) % N] ^ (y >> 1) ^ (0 if y % 2 == 0 else A)
        res.append(next_item)

    return res

W = 32 # Word size, defined by MT19937


def undo_right_transform(value, shift):
    res = value

    for i in range(0, W, shift):
        # Work on the next shift sized portion at a time by generating a mask for it.
        portion_mask = '0' * i + '1' * shift + '0' * (W - shift - i)
        portion_mask = int(portion_mask[:W], 2)
        portion = res & portion_mask

        res ^= portion >> shift

    return res

def undo_left_transform(value, shift, mask):
    res = value
    for i in range(0, W, shift):
        # Work on the next shift sized portion at a time by generating a mask for it.
        portion_mask = '0' * (W - shift - i) + '1' * shift + '0' * i
        portion_mask = int(portion_mask, 2)
        portion = res & portion_mask

        res ^= ((portion << shift) & mask)

    return int(res)


def reverse()

    # Constants for MT19937, from the table above
    L = 18
    T = 15
    C = 0xefc60000
    S = 7
    B = 0x9d2c5680
    U = 11

    for sample in samples:
        y = undo_right_transform(sample, L)
        y = undo_left_transform(y, T, C)
        y = undo_left_transform(y, S, B)
        y = undo_right_transform(y, U)
        state.append(y)        

if __name__ == '__main__':
    random.seed(31337)
    print(random.getstate())
    with open("un.txt", "w+") as f:
        for i in range(624):
            f.write("%i\n" % (int.from_bytes(random._urandom(4), 'big')))