using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 8:");
        Ejercicio8();

        Console.WriteLine("\n-----------------------------\n");

        Console.WriteLine("Ejercicio 9:");
        Ejercicio9();

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    // Funciones para leer y validar entrada
    static int LeerEntero(string mensaje)
    {
        int valor;
        Console.WriteLine(mensaje);
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.WriteLine("Entrada inválida. Por favor ingrese un número entero válido:");
        }
        return valor;
    }

    static double LeerDouble(string mensaje)
    {
        double valor;
        Console.WriteLine(mensaje);
        while (!double.TryParse(Console.ReadLine(), out valor))
        {
            Console.WriteLine("Entrada inválida. Por favor ingrese un número real válido:");
        }
        return valor;
    }

    // Ejercicio 8
    static void Ejercicio8()
    {
        LinkedList<double> listaDatos = new LinkedList<double>();

        int n = LeerEntero("Ingrese la cantidad de datos reales a cargar:");

        for (int i = 0; i < n; i++)
        {
            double dato = LeerDouble($"Dato {i + 1}:");
            listaDatos.AddLast(dato);
        }

        // Calcular promedio
        double suma = 0;
        foreach (var dato in listaDatos)
        {
            suma += dato;
        }
        double promedio = suma / n;

        // Crear las dos listas separadas
        LinkedList<double> listaMenorIgual = new LinkedList<double>();
        LinkedList<double> listaMayor = new LinkedList<double>();

        foreach (var dato in listaDatos)
        {
            if (dato <= promedio)
                listaMenorIgual.AddLast(dato);
            else
                listaMayor.AddLast(dato);
        }

        // Mostrar resultados
        Console.WriteLine("\nDatos cargados en la lista original:");
        MostrarLista(listaDatos);

        Console.WriteLine($"\nPromedio: {promedio:F2}");

        Console.WriteLine("\nDatos <= promedio:");
        MostrarLista(listaMenorIgual);

        Console.WriteLine("\nDatos > promedio:");
        MostrarLista(listaMayor);
    }

    // Ejercicio 9
    static void Ejercicio9()
    {
        LinkedList<int> lista1 = new LinkedList<int>();
        LinkedList<int> lista2 = new LinkedList<int>();

        int n1 = LeerEntero("Carga de datos para la primera lista (enteros):\nIngrese cantidad de datos para la primera lista:");
        for (int i = 0; i < n1; i++)
        {
            int dato = LeerEntero($"Dato {i + 1}:");
            lista1.AddFirst(dato);  // carga por inicio
        }

        int n2 = LeerEntero("Carga de datos para la segunda lista (enteros):\nIngrese cantidad de datos para la segunda lista:");
        for (int i = 0; i < n2; i++)
        {
            int dato = LeerEntero($"Dato {i + 1}:");
            lista2.AddFirst(dato);  // carga por inicio
        }

        // Comparar tamaño
        if (lista1.Count != lista2.Count)
        {
            Console.WriteLine("\nLas listas NO tienen el mismo tamaño ni contenido.");
            return;
        }

        // Comparar contenido en orden
        bool sonIgualesContenido = true;

        var nodo1 = lista1.First;
        var nodo2 = lista2.First;

        while (nodo1 != null && nodo2 != null)
        {
            if (nodo1.Value != nodo2.Value)
            {
                sonIgualesContenido = false;
                break;
            }
            nodo1 = nodo1.Next;
            nodo2 = nodo2.Next;
        }

        if (sonIgualesContenido)
        {
            Console.WriteLine("\nLas listas son iguales en tamaño y en contenido.");
        }
        else
        {
            Console.WriteLine("\nLas listas son iguales en tamaño, pero NO en contenido.");
        }
    }

    static void MostrarLista<T>(LinkedList<T> lista)
    {
        foreach (var item in lista)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
}

