using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    // Clase principal con toda la lógica del algoritmo de Huffman
    public class Huffman
    {
        // Construye el árbol de Huffman a partir del texto
        public NodoHuffman ConstruirArbol(string texto)
        {
            var frecuencia = new Dictionary<char, int>();

            // Conteo de frecuencia por carácter
            foreach (char ch in texto)
            {
                if (!frecuencia.ContainsKey(ch)) 
                    frecuencia[ch] = 0;

                frecuencia[ch]++;
            }

            var cola = new PriorityQueue<NodoHuffman, int>();

            // Crea nodos hoja por cada carácter
            foreach (var par in frecuencia)
            {
                var nodo = new NodoHuffman
                {
                    Simbolo = par.Key,
                    Frecuencia = par.Value
                };
                cola.Enqueue(nodo, nodo.Frecuencia);
            }

            // Construcción del árbol binario al combinar nodos (izquierda y derecha)
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

            return cola.Dequeue(); // Devuelve la raíz del árbol
        }

        // Genera una tabla de códigos binarios para cada símbolo
        public Dictionary<char, string> ConstruirTabla(NodoHuffman raiz)
        {
            var mapa = new Dictionary<char, string>();
            GenerarCodigo(raiz, "", mapa);
            return mapa;
        }

        // Método recursivo para recorrer el árbol binario y asignar códigos binarios
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

        // Codifica el texto ingresado usando la tabla de códigos
        public string Codificar(string texto, Dictionary<char, string> mapa)
        {
            var resultado = new StringBuilder();
            foreach (char ch in texto)
            {
                resultado.Append(mapa[ch]);
            }
            return resultado.ToString();
        }

        // Decodifica el código binario y lo transforma a la entrada de texto
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
