using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Gestion
    {
        private basebicisEntities biciEntities = new basebicisEntities();

        public string registrarse(string nombre, string email, string movilstr, string contasena, string numCuentaStr, out bool errores)
        {
            int movil = 0;
            int numCuenta = 0;
            errores = false;

            if (movilstr.Length != 9)
            {
                errores = true;
                return "El telefono debe tener 9 dígitos";

            }

            bool boleano = int.TryParse(movilstr, out movil);
            if (boleano == false)
            {
                errores = true;
                return "El telefono debe ser numérico";
            }

            bool booleanoCuenta = int.TryParse(numCuentaStr, out numCuenta);

            if (!booleanoCuenta)
            {
                errores = true;
                return "El número de cuenta debe ser numérico";
            }


            var usuario = biciEntities.Usuarios.Where(drUser => drUser.Email.Equals(email)).FirstOrDefault();

            if (usuario != null)
            {
                errores = true;
                return "Correo ya en uso";
            }
            else
            {
                Usuario usu = new Usuario(nombre, email, movil, contasena, numCuenta);
                biciEntities.Usuarios.Add(usu);
                int nFilas = biciEntities.SaveChanges();
                return $"Bienvenido {nombre}";
            }

        }
        public string Login(string email, string contrasena)
        {
            try
            {
                var user = biciEntities.Usuarios.Where(drUser => drUser.Email.Equals(email)).SingleOrDefault();


                if (user != null && user.Contraseña == contrasena)
                {
                    return $"Bienvenido {user.Nombre}";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Email o contraseña incorrectos";
        }
        public string recargarDinero(Usuario user, double cantidad)
        {
            String error = "";
            Usuario usuario = biciEntities.Usuarios.Find(user.Id);

            if (usuario != null)
            {
                usuario.Monedero = usuario.Monedero + cantidad;
                try
                {
                    int cambios = biciEntities.SaveChanges();
                    error = "Listo, monedero recargado";
                }
                catch (Exception e)
                {
                    error = "Error al guardar los cambios";
                }
            }
            return error;
        }
    }
}

