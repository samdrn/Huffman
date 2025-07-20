using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class Huffman
    {
        public NodoHuffman ConstruirArbol(string texto)
        {
            var frecuencia = new Dictionary<char, int>();

            foreach (char ch in texto)
            {
                if (!frecuencia.ContainsKey(ch)) 
                    frecuencia[ch] = 0;

                frecuencia[ch]++;
            }

            var cola = new PriorityQueue<NodoHuffman, int>();

            foreach (var par in frecuencia)
            {
                var nodo = new NodoHuffman
                {
                    Simbolo = par.Key,
                    Frecuencia = par.Value
                };
                cola.Enqueue(nodo, nodo.Frecuencia);
            }

            while (cola.Count > 1)
            {
                var izq = cola.Dequeue();
                var der = cola.Dequeue();

                var nuevo = new NodoHuffman
                {
                    Frecuencia = izq.Frecuencia + der.Frecuencia,
                    Izquierda = izq,
                    Derecha = der
                };
                cola.Enqueue(nuevo, nuevo.Frecuencia);
            }

            return cola.Dequeue();
        }

        public Dictionary<char, string> ConstruirTabla(NodoHuffman raiz)
        {
            var mapa = new Dictionary<char, string>();
            GenerarCodigo(raiz, "", mapa);
            return mapa;
        }

        private void GenerarCodigo(NodoHuffman nodo, string codigo, Dictionary<char, string> mapa)
        {
            if (nodo.EsHoja)
            {
                mapa[nodo.Simbolo.Value] = codigo;
                return;
            }

            GenerarCodigo(nodo.Izquierda, codigo + "0", mapa);
            GenerarCodigo(nodo.Derecha, codigo + "1", mapa);
        }

        public string Codificar(string texto, Dictionary<char, string> mapa)
        {
            var resultado = new StringBuilder();
            foreach (char ch in texto)
            {
                resultado.Append(mapa[ch]);
            }
            return resultado.ToString();
        }
        public string Decodificar(string binario, NodoHuffman raiz)
        {
            var resultado = new StringBuilder();
            var nodo = raiz;

            foreach (char bit in binario)
            {
                nodo = bit == '0' ? nodo.Izquierda : nodo.Derecha;

                if (nodo.EsHoja)
                {
                    resultado.Append(nodo.Simbolo.Value);
                    nodo = raiz;
                }
            }

            return resultado.ToString();
        }
    }
}
