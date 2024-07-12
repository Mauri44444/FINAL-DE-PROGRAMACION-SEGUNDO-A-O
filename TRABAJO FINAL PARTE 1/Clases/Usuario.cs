using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaa
{
    class Usuario : IABMC<Usuario>, IUsuario
    {
        static List<Usuario> Usuarios = new List<Usuario>();

        private static int lasId = 1;

        #region IID
        public int ID { get ; set ; }
        #endregion

        #region IUsuario 
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Mail { get; set; }
        public bool DniExist(int dni)
        {
            foreach(Usuario u in Usuarios)
            {
                if(u.Dni == dni)
                {
                    return true;
                }
            }
            return false;
        }
        public bool MailExist(string mail)
        {
            foreach(Usuario u in Usuarios)
            {
                if(u.Mail == mail)
                {
                    return true;
                }
            }
            return false;
        }
        public Usuario FindDni(int dni)
        {
            foreach (Usuario u in Usuarios)
            {
                if (u.Dni == dni)
                {
                    return u;
                }
            }
            throw new Exception("No se encontró usuario con DNI: " + dni);
        }

        public Usuario FindMail(string mail)
        {
            foreach (Usuario u in Usuarios)
            {
                if (u.Mail == mail)
                {
                    return u;
                }
            }
            throw new Exception("No se encontró usuario con el correo: " + mail);
        }


        public List<Usuario> List()
        {
            return Usuarios;
        }
        #endregion

        #region IABMC
        public void Add(Usuario usuario)
        {
            if(MailExist(usuario.Mail)) throw new Exception("Existe otro usuario con el mismo mail");
            if(DniExist(usuario.Dni)) throw new Exception("Existe otro usuario con el mismo DNI");

            usuario.ID = lasId;
            lasId++;
            Usuarios.Add(usuario);
        }
        
        public void Erase(Usuario usuario)
        {
            foreach(Usuario u in Usuarios)
            {
                if(u.Dni == usuario.Dni)
                {
                    Usuarios.Remove(u);
                    return;
                }
                throw new Exception("No se pudo borrar el usuario con ID: " + usuario.Dni);

            }
        }

        public Usuario Find(Usuario usuario)
        {
            foreach(Usuario u in Usuarios)
            {if(u.ID == usuario.ID)
                {
                    return u;
                }
            }
            throw new Exception("No se encontró usuario con ID: " + usuario.ID);
        }

        public void Modify(Usuario usuario)
        {
            Usuario u = Find(usuario);
            if (u == null) throw new Exception("El usuario a modificar no existe");
        }
        #endregion
    }
}