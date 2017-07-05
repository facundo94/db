using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private int _edad;

        #region Properties

        public int ID
        {
            get { return this._id; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }

        public int Edad
        {
            get { return this._edad; }
            set { this._edad = value; }
        }

        #endregion

        #region Metodos

        public Persona(string nombre, string apellido, int edad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._edad = edad;
        }

        public Persona(int id, string nombre, string apellido, int edad)
            :this(nombre,apellido,edad)
        {
            this._id = id;
        }

        #endregion
    }
}
