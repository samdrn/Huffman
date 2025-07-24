using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    // Comparador que permite ordenar Nodos por frecuencia ascendente (de menor a mayor)
    public class ComparadorHuffman : IComparer<NodoHuffman>
    {
        public int Compare(NodoHuffman x, NodoHuffman y)
        {
            return x.Frecuencia - y.Frecuencia;
        }
    }
}
