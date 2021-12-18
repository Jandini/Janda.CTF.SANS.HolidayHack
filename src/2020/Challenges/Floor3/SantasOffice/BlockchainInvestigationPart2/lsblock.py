#!/usr/bin/env python3

import random
from Crypto.Hash import MD5, SHA256
from Crypto.PublicKey import RSA
from Crypto.Signature import PKCS1_v1_5
from base64 import b64encode, b64decode
import binascii
import time

genesis_block_fake_hash = '00000000000000000000000000000000'

data_types = {1:'plaintext', 2:'jpeg image', 3:'bmp image', 4:'gif image', 5:'PDF', 6:'Word', 7:'PowerPoint', 8:'Excel', 9:'tiff image', 10:'MP4 video', 11:'MOV video', 12:'WMV video', 13:'FLV video', 14:'AVI video', 255:'Binary blob'}
data_extension = {1:'txt', 2:'jpg', 3:'bmp', 4:'gif', 5:'pdf', 6:'docx', 7:'pptx', 8:'xlsx', 9:'tiff', 10:'mp4', 11:'mov', 12:'wmv', 13:'flv', 14:'avi', 255:'bin'}

Naughty = 0
Nice = 1

class Block():
    def __init__(self, index=None, block_data=None, previous_hash=None, load=False, genesis=False):
        if(genesis == True):
            return None
        else:
            self.data = []
            if(load == False):
                if all(p is not None for p in [index, block_data['documents'], block_data['pid'], block_data['rid'], block_data['score'], block_data['sign'], previous_hash]):
                    self.index = index
                    if self.index == 0:
                        self.nonce = 0 # genesis block
                    else:
                        self.nonce = random.randrange(0xFFFFFFFFFFFFFFFF)                
                    self.data = block_data['documents']
                    self.previous_hash = previous_hash
                    self.doc_count = len(self.data)
                    self.pid = block_data['pid']
                    self.rid = block_data['rid']
                    self.score = block_data['score']
                    self.sign = block_data['sign']
                    now = time.gmtime()
                    self.month = now.tm_mon
                    self.day = now.tm_mday
                    self.hour = now.tm_hour
                    self.minute = now.tm_min
                    self.second = now.tm_sec
                    self.hash, self.sig = self.hash_n_sign()
                else:
                    return None

    def __eq__(self, other):
        if isinstance(other, self.__class__):
            return self.__dict__ == other.__dict__
        else:
            return False

    def sha_hash(self):
        sha = SHA256.new()
        sha.update(self.block_data_signed())
        return sha.hexdigest()


    def __repr__(self):
        s = '%i,%s' % (self.index, self.sha_hash()) 
        return(s)



    def full_hash(self):
        hash_obj = MD5.new()
        hash_obj.update(self.block_data_signed())
        return hash_obj.hexdigest()

    def hash_n_sign(self):
        hash_obj = MD5.new()
        hash_obj.update(self.block_data())
        signer = PKCS1_v1_5.new(private_key)
        return (hash_obj.hexdigest(), b64encode(signer.sign(hash_obj)))

    def block_data(self):
        s = (str('%016.016x' % (self.index)).encode('utf-8'))
        s += (str('%016.016x' % (self.nonce)).encode('utf-8'))
        s += (str('%016.016x' % (self.pid)).encode('utf-8'))
        s += (str('%016.016x' % (self.rid)).encode('utf-8'))
        s += (str('%1.1i' % (self.doc_count)).encode('utf-8'))
        s += (str(('%08.08x' % (self.score))).encode('utf-8'))
        s += (str('%1.1i' % (self.sign)).encode('utf-8'))
        for d in self.data:
            s += (str('%02.02x' % d['type']).encode('utf-8'))
            s += (str('%08.08x' % d['length']).encode('utf-8'))
            s += d['data']
        s += (str('%02.02i' % (self.month)).encode('utf-8'))
        s += (str('%02.02i' % (self.day)).encode('utf-8'))
        s += (str('%02.02i' % (self.hour)).encode('utf-8'))
        s += (str('%02.02i' % (self.minute)).encode('utf-8'))
        s += (str('%02.02i' % (self.second)).encode('utf-8'))
        s += (str(self.previous_hash).encode('utf-8'))
        return(s)

    def block_data_signed(self):
        s = self.block_data()
        s += bytes(self.hash.encode('utf-8'))
        s += self.sig
        return(s)

    def load_a_block(self, fh):
        self.index = int(fh.read(16), 16)
        self.nonce = int(fh.read(16), 16)
        self.pid = int(fh.read(16), 16)
        self.rid = int(fh.read(16), 16)
        self.doc_count = int(fh.read(1), 10)
        self.score = int(fh.read(8), 16)
        self.sign = int(fh.read(1), 10)
        count = self.doc_count
        while(count > 0):
            l_data = {}
            l_data['type'] = int(fh.read(2),16)
            l_data['length'] = int(fh.read(8), 16)
            l_data['data'] = fh.read(l_data['length'])
            self.data.append(l_data)
            count -= 1
        self.month = int(fh.read(2))
        self.day = int(fh.read(2))
        self.hour = int(fh.read(2))
        self.minute = int(fh.read(2))
        self.second = int(fh.read(2))
        self.previous_hash = str(fh.read(32))[2:-1]
        self.hash = str(fh.read(32))[2:-1]
        self.sig = fh.read(344)
        return self

    def create_genesis_block(self):
        block_data = {}
        documents = []
        doc = {}
        doc['data'] = bytes('Genesis Block'.encode('utf-8'))
        doc['type'] = 1
        doc['length'] = len(doc['data'])
        documents.append(doc)
        block_data['documents'] = documents
        block_data['pid'] = 0
        block_data['rid'] = 0
        block_data['score'] = 0
        block_data['sign'] = Nice
        b = Block(0, block_data, genesis_block_fake_hash)
        return b

    def verify_types(self):  # check data types of all info in a block
        rv = True
        instances = [self.index, self.nonce, self.pid, self.rid, self.month, self.day, self.hour, self.minute, self.second, self.previous_hash, self.score, self.sign]
        types = [int, int, int, int, int, int, int, int, int, str, int, int]
        if not sum(map(lambda inst_, type_: isinstance(inst_, type_), instances, types)) == len(instances):
            rv = False
        for d in self.data:
            if not isinstance(d['type'], int):
                rv = False
            if not isinstance(d['length'], int):
                rv = False
            if not isinstance(d['data'], bytes):
                rv = False
        return rv

    def dump_doc(self, doc_no):
        filename = '%s.%s' % (str(self.index), data_extension[self.data[doc_no - 1]['type']])
        with open(filename, 'wb') as fh:
            d = self.data[doc_no - 1]['data']
            fh.write(d)
        print('Document dumped as: %s' % (filename))


class Chain():
    index = 0
    initial_index = 0
    last_hash_value = ''
    def __init__(self, load=False, filename=None):
        if not load:
            self.blocks = [Block(genesis=True).create_genesis_block()]
            self.last_hash_value = self.blocks[0].full_hash()
        else:
            self.blocks = []
            self.load_chain(filename)
            self.index = self.blocks[-1].index
            self.initial_index = self.blocks[0].index

    def __eq__(self, other):
        if isinstance(other, self.__class__):
            return self.__dict__ == other.__dict__
        else:
            return False

    def add_block(self, block_data):
        self.index += 1
        b = Block(self.index, block_data, self.last_hash_value)
        self.blocks.append(b)
        self.last_hash_value = b.full_hash() 

    def verify_chain(self, publickey, previous_hash=None):
        flag = True
        # unless we're explicitly told what the initial last hash should be, we assume that
        # the initial block will be the genesis block and will have a fixed previous_hash
        if previous_hash is None:
            previous_hash = genesis_block_fake_hash
        for i in range(0, len(self.blocks)):  # assume Genesis block integrity
            block_no = self.blocks[i].index
            if not self.blocks[i].verify_types():
                flag = False
                print(f'\n*** WARNING *** Wrong data type(s) at block {block_no}.')
            if self.blocks[i].index != i + self.initial_index:
                flag = False
                print(f'\n*** WARNING *** Wrong block index at what should be block {i + self.initial_index}: {block_no}.')
            if self.blocks[i].previous_hash != previous_hash:
                flag = False
                print(f'\n*** WARNING *** Wrong previous hash at block {block_no}.')
            hash_obj = MD5.new()
            hash_obj.update(self.blocks[i].block_data())
            signer = PKCS1_v1_5.new(publickey)
            if signer.verify(hash_obj, b64decode(self.blocks[i].sig)) is False:
                flag = False
                print(f'\n*** WARNING *** Bad signature at block {block_no}.')
            if flag == False:
                print(f'\n*** WARNING *** Blockchain invalid from block {block_no} onward.\n')
                return False
            previous_hash = self.blocks[i].full_hash()
        return True

    def save_a_block(self, index, filename=None):
        if filename is None:
            filename = 'block.dat'
        with open(filename, 'wb') as fh:                                    
            fh.write(self.blocks[index].block_data_signed())

    def save_a_block_data(self, index, filename=None):
        if filename is None:
            filename = 'block.dat'
        with open(filename, 'wb') as fh:                                    
            fh.write(self.blocks[index].block_data())

    def save_chain(self, filename=None):
        if filename is None:
            filname = 'blockchain.dat'
        with open(filename, 'wb') as fh:
            i = 0
            while(i < len(self.blocks)):
                fh.write(self.blocks[i].block_data_signed())
                i += 1

    def load_chain(self, filename=None):        
        count = 0
        if filename is None:
            filename = 'blockchain.dat'
        with open(filename, 'rb') as fh:
            while(1):
                try:
                    self.blocks.append(Block(load=True).load_a_block(fh))
                    self.index = self.blocks[-1].index
                    count += 1
                except ValueError:
                    return count

if __name__ == '__main__':
    chain = Chain(load=True)    
    FIRST_INDEX_IN_CHAIN = 128449
    with open("blocks_sha256", "w") as f:
        for b in chain.blocks:            
            f.write("%s\n" % (b))            
            if (b.sha_hash() == "58a3b9335a6ceb0234c12d35a0564c4ef0e90152d0eb2ce2082383b38028a90f"):
                print(b)
                i = b.index - FIRST_INDEX_IN_CHAIN
                chain.save_a_block(i, str(b.index))
                chain.save_a_block_data(i, "%i.data" % (b.index))