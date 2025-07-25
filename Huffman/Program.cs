using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    // Programa de ejecución para las pruebas para Huffman
    class Program
    {
        static void Main()
        {
            var huffman = new Huffman();

            // Palabras a codificar y decodificar
            string[] texto = new string[]
            { 
            "Huffman",
            "Compresion",
            "Algoritmo",
            "Vaca",
            "Bob Esponja",
            "Gorilas",
            "Tetraedro",
            "Mouse",
            "Coffee"
            };

            // Procesamiento de cada palabra
            foreach (var tex in texto)
            {
                var arbol = huffman.ConstruirArbol(tex);
                var tabla = huffman.ConstruirTabla(arbol);

                string codificado = huffman.Codificar(tex, tabla);
                string decodificado = huffman.Decodificar(codificado, arbol);

                Console.WriteLine($"Original: {tex}");
                Console.WriteLine($"Codificado: {codificado}");
                Console.WriteLine($"Decodificado: {decodificado}");
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
