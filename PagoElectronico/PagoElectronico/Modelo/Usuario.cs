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
        public String preguntaSecreta;
        public String respuestaSecreta;
        public Rol rol;
        private String passwordEncriptado;
        public String password
        {
            set { passwordEncriptado = SHA256.GetSHA256(value); }
            get { return passwordEncriptado; }
        }

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

        public bool tieneMismoUsernameQue(Usuario usuario)
        {
            return username == usuario.username;
        }

        internal bool laPasswordEs(String password)
        {
            return this.password == SHA256.GetSHA256(password);
        }
    }
}
