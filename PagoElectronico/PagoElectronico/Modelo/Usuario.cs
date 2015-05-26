using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Usuario
    {
        public int id;
        public String username;
        public String password;
        public String preguntaSecreta;
        public String respuestaSecreta;
        public Rol rol;

        public Usuario(
            int id,
            String username,
            String password,
            String preguntaSecreta,
            String respuestaSecreta,
            Rol rol)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.preguntaSecreta = preguntaSecreta;
            this.respuestaSecreta = respuestaSecreta;
            this.rol = rol;
        }
    }
}
