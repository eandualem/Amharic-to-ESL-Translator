import os
import io
from struct import calcsize, pack, unpack
from Crypto.Cipher import AES
from Crypto.Hash import SHA256


class Cipher:

    def __init__(self):
        pass

    def HASH32B(self, message):
        """ Generate a 32-byte(256 bit) digest of a message.

            Parameters
            ----------
            message : str
                String that is being digested into 32-byte binary

            Return
            ------
            bytes
                A 32-byte binary digest of the message that has been hashed
        """
        return SHA256.new(message.encode('utf-8')).digest()

    def encrypt_buffer(self, key, in_buffer, chunksize=64*1024):
        """ Encrypts an input buffer using AES (CBC mode) with the
            given key.

            Parameters
            ----------
            key : str
                The encryption key - a string that must be
                either 16, 24 or 32 bytes long.

            in_buffer : bytes
                Input buffer that is being encrypted

            chunksize : int
                Sets the size of the chunk which the function
                uses to read and encrypt the file. Larger chunk
                sizes can be faster for some files and machines.
                chunksize must be divisible by 16.

            Return
            ------
            bytes
                Output encrypted buffer
        """

        """ hash encryption key to base  """
        hashed_key = self.HASH32B(key)
        iv = os.urandom(16)

        encryptor = AES.new(hashed_key, AES.MODE_CBC, iv)

        buffer_size = len(in_buffer)

        out_buffer = b''
        out_buffer += pack('<Q', buffer_size)
        out_buffer += iv

        # create stream of bytes to better manage chunk read
        in_buffer_stream = io.BytesIO(in_buffer)

        while True:
            chunk = in_buffer_stream.read(chunksize)

            if len(chunk) == 0:
                break
            elif len(chunk) % 16 != 0:
                chunk += b' ' * (16 - len(chunk) % 16)
            out_buffer += encryptor.encrypt(chunk)

        return out_buffer

    def encrypt_file(self, key, in_filename, out_filename=None, chunksize=64*1024):
        """ Encrypts a file using AES (CBC mode) with the
            given key.

            key:
                The encryption key - a string that must be
                either 16, 24 or 32 bytes long.

            in_filename:
                Name of the input file

            out_filename:
                If None, '<in_filename>.enc' will be used.

            chunksize:
                Sets the size of the chunk which the function
                uses to read and encrypt the file. Larger chunk
                sizes can be faster for some files and machines.
                chunksize must be divisible by 16.
        """
        if not out_filename:
            out_filename = in_filename + '.enc'

        """ hash encryption key to base  """
        hashed_key = self.HASH32B(key)
        iv = os.urandom(16)

        encryptor = AES.new(hashed_key, AES.MODE_CBC, iv)
        filesize = os.path.getsize(in_filename)

        with open(in_filename, 'rb') as infile:
            with open(out_filename, 'wb') as outfile:
                outfile.write(pack('<Q', filesize))
                outfile.write(iv)

                while True:
                    chunk = infile.read(chunksize)

                    if len(chunk) == 0:
                        break
                    elif len(chunk) % 16 != 0:
                        chunk += b' ' * (16 - len(chunk) % 16)
                    outfile.write(encryptor.encrypt(chunk))

    def decrypt_buffer(self, key, in_buffer, chunksize=64*1024):
        """ Decrypts a buffer using AES (CBC mode) with the
            given key. Parameters are similar to encrypt_buffer
        """
        hashed_key = self.HASH32B(key)

        in_buffer_stream = io.BytesIO(in_buffer)

        origsize = unpack('<Q', in_buffer_stream.read(calcsize('Q')))[0]
        iv = in_buffer_stream.read(16)

        decryptor = AES.new(hashed_key, AES.MODE_CBC, iv)

        out_buffer = b''
        while True:
            chunk = in_buffer_stream.read(chunksize)
            if len(chunk) == 0:
                break
            out_buffer += decryptor.decrypt(chunk)
        return out_buffer[:origsize]

    def decrypt_file(self, key, in_filename, out_filename=None, chunksize=64*1024):
        """ Decrypts a file using AES (CBC mode) with the
            given key. Parameters are similar to encrypt_file,
            with one difference: out_filename, if not supplied
            will be in_filename without its last extension
            (i.e. if in_filename is 'aaa.zip.enc' then
            out_filename will be 'aaa.zip')
        """
        if not out_filename:
            out_filename = os.path.splitext(in_filename)[0]

        hashed_key = self.HASH32B(key)

        with open(in_filename, 'rb') as in_file:
            origsize = unpack('<Q', in_file.read(calcsize('Q')))[0]
            iv = in_file.read(16)

            decryptor = AES.new(hashed_key, AES.MODE_CBC, iv)

            with open(out_filename, 'wb') as outfile:
                while True:
                    chunk = in_file.read(chunksize)
                    if len(chunk) == 0:
                        break
                    outfile.write(decryptor.decrypt(chunk))

                outfile.truncate(origsize)
