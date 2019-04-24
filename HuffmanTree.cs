using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HuffmanCoding
{
    public class HuffmanTree
    {
        public Queue<HuffmanTreeNode> huffmanTreeQueue;

        public Dictionary<char, string> huffmanNodesMap = new Dictionary<char, string>();

        public Dictionary<byte, string> byteToBinaryStrMap = new Dictionary<byte, string>();

        public Dictionary<byte, string> getByteToBinaryStrMap() {
            return byteToBinaryStrMap;
        }

        public void setByteToBinaryStrMap(Dictionary<byte, string> map) {
            byteToBinaryStrMap = map;
        }

        public Queue<HuffmanTreeNode> getHuffmanTreeQueue(){
            return huffmanTreeQueue;
        }

        public Dictionary<char, string> getHuffmanNodesMap(){
            return huffmanNodesMap;
        }


        public void createHuffmanTree(Queue<HuffmanTreeNode> nodesList)
        { 
            // build the tree until list has one node.
            while (nodesList.Count > 1){
                HuffmanTreeNode left = (HuffmanTreeNode)nodesList.Dequeue();
                HuffmanTreeNode right = (HuffmanTreeNode)nodesList.Dequeue();
                HuffmanTreeNode root = new HuffmanTreeNode(' ', left.frequency + right.frequency, false);
                root.left = left;
                root.right = right;
                root.isLeaf = false;
                root.leftLeg = "1";
                root.rightLeg = "0";

                nodesList.Enqueue(root);

                //sort list to place the new node at right place in list.
                huffmanTreeQueue = sortQueue(nodesList);
            }
           
        }

        public void Preorder(HuffmanTreeNode root, string encoded){
            if (root != null){
                if (root.isLeaf){
                    root.huffmanCode = encoded;
                    if (!huffmanNodesMap.ContainsKey(root.ch)) {
                        huffmanNodesMap.Add(root.ch, root.huffmanCode);
                    }
                    return;
                }
                Preorder(root.left, encoded + root.leftLeg);
                Preorder(root.right, encoded + root.rightLeg);
            }
        }

        private Queue<HuffmanTreeNode> sortQueue(Queue<HuffmanTreeNode> queue){

            var q = queue.OrderBy(HuffmanTreeNode => HuffmanTreeNode.frequency);
            Queue<HuffmanTreeNode> qu = new Queue<HuffmanTreeNode>();
            foreach(HuffmanTreeNode huf in q){
                qu.Enqueue(huf);
            }
            return qu;
        }
    }
}
