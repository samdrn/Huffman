using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class ComparadorHuffman : IComparer<NodoHuffman>
    {
        public int Compare(NodoHuffman x, NodoHuffman y)
        {
            return x.Frecuencia - y.Frecuencia;
        }
    }
}
