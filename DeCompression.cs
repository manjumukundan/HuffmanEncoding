using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HuffmanCoding
{
    public class DeCompression
    {
        StreamReader reader;

        StreamWriter writer;

        public void deCompress(HuffmanTree huffmanTree, string asciiString, string compressFilename, string decompressFilename)
        {
            Console.WriteLine("\nDecCompression Started.........\n");
            // decompress.
            try {
                string encodedString = "";
                reader = new StreamReader(compressFilename);
                // get encoded string from compressed file mapping huffmantree
                List<byte> compressedByte = readCompressedFile();
                foreach(byte b in compressedByte){
                    encodedString += huffmanTree.getByteToBinaryStrMap().GetValueOrDefault(b);
                }
                writer = new StreamWriter(decompressFilename);
                // read the compressed bytes and traverse tree
                HuffmanTreeNode root = huffmanTree.getHuffmanTreeQueue().Peek();
                HuffmanTreeNode node = root;
                foreach (char c in encodedString){
                    node = traverseTree(node, c);
                    if (node.isLeaf){
                        Console.Write(node.ch);
                        writer.Write(node.ch);
                        node = root;
                    }
                }
                reader.Close();
                reader.Dispose();
                writer.Close();
                writer.Dispose();
            }
            catch (Exception ex){
                throw ex;
            }

            Console.WriteLine("\n\nDecCompression Done.........\n");
        }

        private List<byte> readCompressedFile()
        {
            List<byte> bytes = new List<byte>();
            string compressedStr = reader.ReadToEnd();
            string[] split = compressedStr.Split(" | ");
            foreach(string num in split){
                if (num != ""){
                    byte b = Convert.ToByte(num);
                    bytes.Add(b);
                }
            }
            return bytes;
        }

        private HuffmanTreeNode traverseTree(HuffmanTreeNode node, char c)
        {
            if (c == '1'){
                return node.left;
            }
            else {
                return node.right;
            }
        }
    }
}
