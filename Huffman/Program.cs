using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    class Program
    {
        static void Main()
        {
            var huffman = new Huffman();
            string texto = "Huffman";

            var arbol = huffman.ConstruirArbol(texto);
            var tabla = huffman.ConstruirTabla(arbol);

            string codificado = huffman.Codificar(texto, tabla);
            string decodificado = huffman.Decodificar(codificado, arbol);

            Console.WriteLine($"Original: {texto}");
            Console.WriteLine($"Codificado: {codificado}");
            Console.WriteLine($"Decodificado: {decodificado}");
        }
    }
}