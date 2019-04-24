using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HuffmanCoding
{
    public class HuffmanCodingMain
    {
        string inputFilename;
        public Dictionary<char, int> dict = new Dictionary<char, int>();
        public Queue<HuffmanTreeNode> nodesList = new Queue<HuffmanTreeNode>();
        public HuffmanTree tree;
        public Compression compress;
        public DeCompression deCompress;

        public string asciiString;

        static void Main(string[] args)
        {
            HuffmanCodingMain obj = new HuffmanCodingMain();
            if(null != args && args.Length != 0){
                obj.compressFile(args[0], "compressed.txt");
                obj.deCompressFile("compressed.txt", "decompressed.txt");
            }
            else {
                throw new Exception("Input ascii file not avaialable!!!");
            }

            // start testing the test cases.
            Console.WriteLine("\nDo you want to run the test suite? Type Y for yes and N to exit");
            string input = Console.ReadLine();
            if (input.Equals("Y")){
                Console.WriteLine("\n=================================================================================");
                Console.WriteLine("\nRunning Tests!!!");
                Test.runTestSuite();
            }
        }

        public void compressFile(string inputFilename, string compressFilename)
        {
            compress = new Compression();
            deCompress = new DeCompression();
            tree = new HuffmanTree();

            // read ascii file.
            readCharFrequency(inputFilename);

            //sort the dictionary.
            sortFreqDictionary();

            // create sorted list of huffman tree nodes.
            createSortedNodesList();

            // create the tree.
            tree.createHuffmanTree(nodesList);

            // compress the file.
            compress.compress(tree, asciiString, compressFilename);
        }

        public void deCompressFile(string compressFilename, string decompressFilename) {
            // decompress the compressed file.
            deCompress.deCompress(tree, asciiString, compressFilename, decompressFilename);
        }

        private void readCharFrequency(string inputFilename)
        {
            try {
                if(null != inputFilename){
                    StreamReader reader = new StreamReader(inputFilename);
                    do {
                        char ch = (char)reader.Read();
                        asciiString += ch;
                        // get frequency of characters
                        if (dict.ContainsKey(ch)) {
                            int count = dict.GetValueOrDefault(ch);
                            dict[ch] = ++count;
                        } else {
                            dict.Add(ch, 1);
                        }
                    }
                    while(!reader.EndOfStream);
                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
        }

        private void createSortedNodesList()
        {
            foreach (KeyValuePair<char, int> pair in dict)
            {
                nodesList.Enqueue(new HuffmanTreeNode(pair.Key, pair.Value, true));
            }
        }

        private void sortFreqDictionary()
        {
            var map = from pair in dict
                    orderby pair.Value ascending
                    select pair;
            dict = map.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
        }
    }
}
