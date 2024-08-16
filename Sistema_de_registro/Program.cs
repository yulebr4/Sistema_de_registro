using System;
using System.Collections.Generic;

namespace SistemaRegistroClientes

{
    // Clase base Cliente que representa un cliente genérico
    public class Cliente
    {
        // Propiedades públicas para almacenar información básica del cliente

        // get y set se utilizan para definir propiedades en una clase.

        //get Permite obtener el valor de la propiedad.

        //set Permite establecer el valor de la propiedad.
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }


        // Método virtual para mostrar la información del cliente, puede ser sobrescrito en clases derivadas
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, Correo: {Correo}");
        }
    }


    // Clase derivada ClienteCorporativo que extiende Cliente para incluir clientes corporativos
    public class ClienteCorporativo : Cliente


    {
        // Propiedad adicional para almacenar el nombre de la empresa
        public string NombreEmpresa { get; set; }




        // Sobrescritura del método MostrarInformacion para incluir la información de la empresa
        public override void MostrarInformacion()
        {
            // Llamar al método base para mostrar la información general del cliente
            base.MostrarInformacion();
            // Mostrar la información adicional del cliente corporativo
            Console.WriteLine($"Nombre de la Empresa: {NombreEmpresa}");
        }
    }


    // Clase principal Program que contiene el método Main
    class Program
    {

        // Lista estática para almacenar todos los clientes
        static List<Cliente> listaClientes = new List<Cliente>();


        // Método principal que ejecuta el programa
        static void Main(string[] args)
        {

            // Variable booleana para controlar el ciclo del menú
            bool salir = false;


            // Ciclo principal del programa que muestra el menú hasta que el usuario decida salir
            while (!salir)
            {
                // Mostrar opciones del menú
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Agregar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();


                // Evaluar la opción seleccionada por el usuario
                switch (opcion)
                {
                    case "1":
                        // Llamar al método para agregar un nuevo cliente
                        AgregarCliente();
                        break;
                    case "2":
                        // Llamar al método para listar todos los clientes
                        ListarClientes();
                        break;
                    case "3":
                        // Cambiar el valor de `salir` para terminar el ciclo
                        salir = true;
                        break;
                    default:
                        // Mensaje de error si la opción no es válida
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }


        // Método para agregar un nuevo cliente a la lista
        static void AgregarCliente()
        {
            // Pedir al usuario los datos básicos del cliente
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la edad del cliente: ");
            int edad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el correo del cliente: ");
            string correo = Console.ReadLine();



            // Preguntar si el cliente es corporativo
            Console.Write("¿El cliente es corporativo? (s/n): ");
            string esCorporativo = Console.ReadLine().ToLower();


            // Verificar si el cliente es corporativo

            if (esCorporativo == "s")
            {
                // Si es corporativo, pedir el nombre de la empresa y crear un objeto ClienteCorporativo
                Console.Write("Ingrese el nombre de la empresa: ");
                string nombreEmpresa = Console.ReadLine();
                ClienteCorporativo clienteCorporativo = new ClienteCorporativo()
                {
                    Nombre = nombre,
                    Edad = edad,
                    Correo = correo,
                    NombreEmpresa = nombreEmpresa
                };
                // Agregar el cliente corporativo a la lista
                listaClientes.Add(clienteCorporativo);
            }
            else
            {
                // Si no es corporativo, crear un objeto Cliente genérico
                Cliente cliente = new Cliente()
                {
                    Nombre = nombre,
                    Edad = edad,
                    Correo = correo
                };
                // Agregar el cliente a la lista
                listaClientes.Add(cliente);
            }

            // Confirmar que el cliente fue agregado exitosamente
            Console.WriteLine("Cliente agregado con éxito.");
        }

        // Método para listar todos los clientes en la consola
        static void ListarClientes()
        {
            // Mostrar un encabezado para la lista de clientes
            Console.WriteLine("\nLista de Clientes:");

            // Recorrer la lista de clientes y mostrar la información de cada uno
            foreach (var cliente in listaClientes)
            {
                cliente.MostrarInformacion();  // Llama al método MostrarInformacion (polimorfismo)
                Console.WriteLine();  // Espacio adicional para mejor legibilidad
            }
        }
    }
}