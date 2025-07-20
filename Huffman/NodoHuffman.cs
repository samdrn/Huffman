using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class NodoHuffman
    {
        public char? Simbolo { get; set; }
        public int Frecuencia { get; set; }
        public NodoHuffman Izquierda { get; set; }
        public NodoHuffman Derecha { get; set; }

        public bool EsHoja => Izquierda == null && Derecha == null; 
    }
}
