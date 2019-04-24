using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HuffmanCoding
{
    public class Test
    {
        public static void runTestSuite()
        {
            bool same;
            HuffmanCodingMain obj = new HuffmanCodingMain();
            obj.compressFile("test1.txt", "compressed1.txt");
            obj.deCompressFile("compressed1.txt", "decompressed1.txt");
            same = File.ReadLines("decompressed1.txt").SequenceEqual(File.ReadLines("test1.txt"));
            if (!same){
                Console.WriteLine("\nTest Suite Failed!!!!!!\n");
                return;
            }
            obj = new HuffmanCodingMain();
            obj.compressFile("test2.txt", "compressed2.txt");
            obj.deCompressFile("compressed2.txt", "decompressed2.txt");
            same = File.ReadLines("decompressed2.txt").SequenceEqual(File.ReadLines("test2.txt"));
            if (!same){
                Console.WriteLine("\nTest Suite Failed!!!!!!\n");
                return;
            }
            obj = new HuffmanCodingMain();
            obj.compressFile("test3.txt", "compressed3.txt");
            obj.deCompressFile("compressed3.txt", "decompressed3.txt");
            same = File.ReadLines("decompressed3.txt").SequenceEqual(File.ReadLines("test3.txt"));
            if (!same){
                Console.WriteLine("\nTest Suite Failed!!!!!!\n");
                return;
            }
            obj = new HuffmanCodingMain();
            obj.compressFile("test4.txt", "compressed4.txt");
            obj.deCompressFile("compressed4.txt", "decompressed4.txt");
            same = File.ReadLines("decompressed4.txt").SequenceEqual(File.ReadLines("test4.txt"));
            if (!same){
                Console.WriteLine("\nTest Suite Failed!!!!!!\n");
                return;
            }
            obj = new HuffmanCodingMain();
            obj.compressFile("test5.txt", "compressed5.txt");
            obj.deCompressFile("compressed5.txt", "decompressed5.txt");
            same = File.ReadLines("decompressed5.txt").SequenceEqual(File.ReadLines("test5.txt"));
            if (!same){
                Console.WriteLine("\nTest Suite Failed!!!!!!\n");
                return;
            }

            Console.WriteLine("\nTest Suite Successfull!!!!!!\n");
        }
    }
}
