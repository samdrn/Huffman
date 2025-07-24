# Huffman Compression en C#
## ¿Qué es Huffman Coding?
La técnica Huffman es un tipo de compresión sin perdida basada en frecuencias formando un Árbol Binario. Donde su principal característica es asignar los códigos/ símbolos más cortos a los caracteres más frecuentes, y los más largos a los menos frecuentes, formando de esta manera un árbol binario óptimo.
## Estructura del proyecto
- 'NodoHuffman.cs' - Define el nodo del árbol binario de Huffman.
- 'ComparadorHuffman.cs' - Comparador que ordena los nodos por frecuencia (menor a mayor).
- 'Huffman.cs' - Implementa la lógica de construcción del árbol, codificación y decodificación.
- 'Program.cs' - Punto de entrada de la aplicación, procesa varios ejemplos.
## Ejecución
Al ejecutar el programa, devolverá la codificación y decodificación de una lista de palabras usando Huffman.
## Ejemplo
- Original: Huffman
- Codificado: 110011101000010111
- Decodificado: Huffman
## Requisitos
- [.NET SDK](http://dotnet.microsoft.com/) instalado
- Visual Studio o cualquier editor con soporte para C#
