using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Conector cn = new Conector();
            List<Persona> lista;
            Persona p1 = new Persona("Juan","Perez",23);
            

            //if (cn.TestConexion())
            //    Console.WriteLine("S");
            //else
            //    Console.WriteLine("N");

            //Console.WriteLine(cn.TraerInfo());

            cn.AgregarPersona(p1);
            lista = cn.TraerPersonas();

            Console.WriteLine("//Agrego");
            Console.WriteLine("Personas:");
            Console.WriteLine("ID       Nombre      Apellido  Edad");
            Console.WriteLine("- - - - - - - - - - - - - - - - - -");
            foreach (Persona p in lista)
            {
                Console.Write("{0,2}", p.ID);
                Console.Write("{0,13}", p.Nombre);
                Console.Write("{0,14}", p.Apellido);
                Console.WriteLine("{0,6}", p.Edad);
            }

            Persona p2 = new Persona(lista[4].ID, "Pedro", "Gomez", 45);
            Console.WriteLine("\n-----------------------------------\n");
            cn.ModificarPersona(p2);
            lista = cn.TraerPersonas();

            Console.WriteLine("//Modifico");
            Console.WriteLine("Personas:");
            Console.WriteLine("ID       Nombre      Apellido  Edad");
            Console.WriteLine("- - - - - - - - - - - - - - - - - -");
            foreach (Persona p in lista)
            {
                Console.Write("{0,2}", p.ID);
                Console.Write("{0,13}", p.Nombre);
                Console.Write("{0,14}", p.Apellido);
                Console.WriteLine("{0,6}", p.Edad);
            }

            Console.WriteLine("\n-----------------------------------\n");
            cn.BorrarPersona(lista[4]);
            lista = cn.TraerPersonas();

            Console.WriteLine("//Borro");
            Console.WriteLine("Personas:");
            Console.WriteLine("ID       Nombre      Apellido  Edad");
            Console.WriteLine("- - - - - - - - - - - - - - - - - -");
            foreach (Persona p in lista)
            {
                Console.Write("{0,2}", p.ID);
                Console.Write("{0,13}", p.Nombre);
                Console.Write("{0,14}", p.Apellido);
                Console.WriteLine("{0,6}", p.Edad);
            }

            Console.ReadLine();

        }
    }
}
