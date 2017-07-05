using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public class Conector
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        #region Metodos

        public Conector()
        {
            this._connection = new SqlConnection(Properties.Settings.Default.CadenaConeccion);
            this._command = new SqlCommand();
        }

        public bool TestConexion()
        {
            try
            {
                this._connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                this._connection.Close();
            }
        }

        public string TraerInfo()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                //Le paso una coneccion instanciada
                this._command.Connection = this._connection;

                //Le indico el tipo de consulta
                this._command.CommandType = CommandType.Text;

                //Le paso la consulta
                this._command.CommandText = "SELECT * FROM Personas";

                this._connection.Open();

                //Se instancia con el metedo
                SqlDataReader oDr = this._command.ExecuteReader();                

                while (oDr.Read())
                {
                    sb.AppendLine("\nID: " + oDr["ID"].ToString());
                    sb.AppendLine("Nombre: " + oDr["Nombre"].ToString());
                    sb.AppendLine("Apellido: " + oDr["Apellido"].ToString());
                    sb.AppendLine("Edad:" + oDr["Edad"].ToString());
                }
                oDr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {                
                this._connection.Close();
            }

            return sb.ToString();
        }

        public List<Persona> TraerPersonas()
        {
            List<Persona> lista = new List<Persona>();

            try
            {
                //Le paso una coneccion instanciada
                this._command.Connection = this._connection;

                //Le indico el tipo de consulta
                this._command.CommandType = CommandType.Text;

                //Le paso la consulta
                this._command.CommandText = "SELECT * FROM Personas";

                this._connection.Open();

                //Se instancia con el metedo
                SqlDataReader oDr = this._command.ExecuteReader();

                while (oDr.Read())
                {
                    lista.Add(new Persona(int.Parse(oDr["ID"].ToString()),oDr["Nombre"].ToString(),
                        oDr["Apellido"].ToString(),int.Parse(oDr["Edad"].ToString())));
                }
                oDr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }

            return lista;
        }

        public bool AgregarPersona(Persona p)
        {
            try
            {
                //Le paso una coneccion instanciada
                this._command.Connection = this._connection;

                //Le indico el tipo de consulta
                this._command.CommandType = CommandType.Text;

                //Le paso la consulta
                this._command.CommandText = "Insert into Personas (nombre,apellido,edad) VALUES('"
                    +p.Nombre+"','"+p.Apellido+"',"+p.Edad+")";

                this._connection.Open();

                //Se instancia con el metedo
                this._command.ExecuteNonQuery();

                return true;                
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                this._connection.Close();
            }            
        }

        public bool ModificarPersona(Persona p)
        {
            try
            {
                //Le paso una coneccion instanciada
                this._command.Connection = this._connection;

                //Le indico el tipo de consulta
                this._command.CommandType = CommandType.Text;

                //Le paso la consulta
                this._command.CommandText = "UPDATE Personas set nombre='"+p.Nombre+
                    "', apellido='"+p.Apellido+"', Edad="+p.Edad+" where ID ="+p.ID;

                this._connection.Open();

                //Se instancia con el metedo
                this._command.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                this._connection.Close();
            }
        }

        public bool BorrarPersona(Persona p)
        {
            try
            {
                //Le paso una coneccion instanciada
                this._command.Connection = this._connection;

                //Le indico el tipo de consulta
                this._command.CommandType = CommandType.Text;

                //Le paso la consulta
                this._command.CommandText = "DELETE FROM Personas where ID =" +p.ID ;

                this._connection.Open();

                //Se instancia con el metedo
                this._command.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                this._connection.Close();
            }
        }

        #endregion

    }
}
