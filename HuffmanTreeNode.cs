using System;

namespace HuffmanCoding
{
    public class HuffmanTreeNode
    {
        public int frequency;
        public char ch;
        public HuffmanTreeNode left;
        public HuffmanTreeNode right;
        public string leftLeg;
        public string rightLeg;
        public bool isLeaf;

        public string huffmanCode;

        public HuffmanTreeNode(char c, int f, bool leaf){
            frequency = f;
            ch = c;
            isLeaf = leaf;
        }

    }
}
