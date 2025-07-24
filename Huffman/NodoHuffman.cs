using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    // Esta clase representa un Nodo en el árbol binario de Huffman
    public class NodoHuffman
    {
        public char? Simbolo { get; set; } // Carácter que representa (si es una hoja) 
        public int Frecuencia { get; set; } // Frecuencia del carácter
        public NodoHuffman Izquierda { get; set; } // Rama Izquierda
        public NodoHuffman Derecha { get; set; } // Rama Derecha

        public bool EsHoja => Izquierda == null && Derecha == null; // Verifica si el nodo es una hoja
    }
}
