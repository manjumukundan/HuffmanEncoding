using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HuffmanCoding
{
    public class Compression
    {
        string encodedStr;
        HuffmanTree tree;
        StreamWriter writer;

        public void compress(HuffmanTree tree, string asciiString, string compressFilename)
        {
            this.tree = tree;
            Queue<HuffmanTreeNode> nodesList = tree.getHuffmanTreeQueue();
            try {
                Console.WriteLine("Compression Started.........\n");
                writer = new StreamWriter(compressFilename);
                int len = nodesList.Count;
                if (len == 1) {   
                    // create the huffman codes.
                    createEncodingMap(nodesList);
                    encode(asciiString, nodesList);
                }
                else {
                    throw new Exception("Huffman Tree creation Failed!!!");
                }
                writer.Dispose();
            }
            catch(Exception e){
                throw e;
            }
            Console.WriteLine("\n\nCompression Done.........");
        }

        private void encode(string asciiString, Queue<HuffmanTreeNode> nodesList)
        {
            // create the encoded bits string
            encodedStr = "";
            string binaryStr = "";
            Dictionary<byte, string> byteToBinaryStrMap = new Dictionary<byte, string>();
            Dictionary<char, string> codes = tree.getHuffmanNodesMap();
            foreach (char c in asciiString){
                encodedStr += codes.GetValueOrDefault(c);
            }
            
            BitArray bitArray = new BitArray(encodedStr.Length);
            bool bit = false;
            byte value = 0;
            for(int k = 0; k < encodedStr.Length; k++){
                char c = encodedStr[k];
                if (c == '1'){
                    bit = true;
                }
                else {
                    bit = false;
                }
                bitArray[k] = bit;


                // calculate value if bit is enabled.
                if (bitArray[k]) {
                    value += (byte)Math.Pow(2, k%8);
                }
                binaryStr += c;
                // write value to file.
                if (k % 8 ==  7 || k == encodedStr.Length - 1){
                    createCompressedFile(value);
                    if (!byteToBinaryStrMap.ContainsKey(value)) {
                        byteToBinaryStrMap.Add(value, binaryStr);
                    }
                    value = 0;
                    binaryStr = "";
                }
            }
            tree.setByteToBinaryStrMap(byteToBinaryStrMap);
        }

        private void createCompressedFile(int value)
        {  
            Console.Write(Convert.ToString(value) + " | ");
            writer.Write(Convert.ToString(value) + " | ");
        }

        private void createEncodingMap(Queue<HuffmanTreeNode> nodesList)
        {
            tree.Preorder(nodesList.Peek(), "");
        }

        
    }
}
