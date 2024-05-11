namespace ArbolBinarioPalabras
{
    class Nodo
    {
        public string dato;
        public Nodo izq;
        public Nodo der;
        public Nodo(string dato)
        {
            this.dato = dato;
            izq = null;
            der = null;
        }
    }

    class ArbolBinario
    {
        public Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        public void Insertar()
        {
            raiz = InsertarRecursivo(raiz);
        }

        private Nodo InsertarRecursivo(Nodo raiz)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Contenido: ");
            string contenido = Console.ReadLine();
            raiz = new Nodo(contenido);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(contenido + " tiene elementos a la izquierda? (s/n): ");
            string izq = Console.ReadLine();
            if (izq == "s")
            {
                raiz.izq = InsertarRecursivo(raiz.izq);
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(contenido + " tiene elementos a la derecha? (s/n): ");
            string der = Console.ReadLine();
            if (der == "s")
            {
                raiz.der = InsertarRecursivo(raiz.der);
            }
            return raiz;
        }

        public void VerPreOrden()
        {
            PreOrdenRecursivo(raiz);
            Console.WriteLine();
        }

        public void PreOrdenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.dato + "  ");
                PreOrdenRecursivo(nodo.izq);
                PreOrdenRecursivo(nodo.der);
            }
        }

        public void VerInOrden()
        {
            InOrdenRecursivo(raiz);
            Console.WriteLine();
        }

        public void InOrdenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                InOrdenRecursivo(nodo.izq);
                Console.Write(nodo.dato + "  ");
                InOrdenRecursivo(nodo.der);
            }
        }

        public void VerPostOrden()
        {
            PostOrdenRecursivo(raiz);
            Console.WriteLine();
        }

        public void PostOrdenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                PostOrdenRecursivo(nodo.izq);
                PostOrdenRecursivo(nodo.der);
                Console.Write(nodo.dato + "  ");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool volverMenuPrincipal = false;
            bool salir = false;
            ArbolBinario arbol = new ArbolBinario();
            arbol.VerInOrden();
            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(@" 
░░╔█████████████████╗░░
░░█░░ARBOL BINARIO░░█░░
░░╚█████████████████╝░░
                ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n|| Menú ||");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Generar Arbol");
                Console.WriteLine("2. Imprimir PreOrden");
                Console.WriteLine("3. Imprimir InOrden");
                Console.WriteLine("4. Imprimir PostOrden");
                Console.WriteLine("5. Salir");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Ingrese la opción deseada: ");
                string opcion = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        arbol.Insertar();
                        break;

                    case "2":
                        Console.Clear();
                        arbol.VerPreOrden();
                        break;

                    case "3":
                        Console.Clear();
                        arbol.VerInOrden();
                        break;

                    case "4":
                        Console.Clear();
                        arbol.VerPostOrden();
                        break;

                    case "5":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Presione enter para continuar...");
                Console.ReadLine();
            }
        }
    }
}