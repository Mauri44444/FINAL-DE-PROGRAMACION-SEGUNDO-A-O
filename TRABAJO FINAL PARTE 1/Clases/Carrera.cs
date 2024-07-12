using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaa
{
    public class Carrera : IABMC<Carrera>, ICarrera
    {
        private static List<Carrera> carreras = new List<Carrera>();

        private static int lasSiglas = 1;
        
        #region IID
        public int ID { get; set;}
        #endregion
        
        #region ICarrera
        public string Nombre { get; set;}
        public string Sigla { get; set;}
        public string Titulo { get; set;}
        public int Duracion { get; set;}

        public Carrera FindBySigla(string sigla)
        {
            foreach (Carrera c in carreras)
            {
                if (c.Sigla == sigla)
                {
                 return c;
                }
            }
            throw new Exception("No se encontró carrera con esa sigla: " + sigla);
        }
        public List<Carrera> List()
        {
            return carreras;
        }
        public bool NameExists(string nombre)
        {
            foreach (Carrera c in carreras)
            {
                if (c.Nombre == nombre)
                {
                    return true;
                }
            }
            return false;
        }
        public bool SiglaExists(string sigla)
        {
            foreach (Carrera c in carreras)
            {
                if (c.Sigla == sigla)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        
        #region IABMC
        public void Add(Carrera carrera)
        {
            if (SiglaExists(carrera.Sigla))
            {
                throw new Exception("Existe una carrera con las mismas Siglas");
            }
            if (NameExists(carrera.Nombre))
            {
                throw new Exception("Existe una carrera con ese nombre");
            }
            carrera.ID = lasSiglas;
            lasSiglas++;
            carreras.Add(carrera);
        }

        public void Erase(Carrera carrera)
        {
            foreach (Carrera c in carreras)
            {
                if(c.Sigla== carrera.Sigla)
                {
                    carreras.Remove(c);
                    return;
                }
            }
        }

        public Carrera Find(Carrera carrera)
        {
            foreach (Carrera c in carreras)
            {
                if (c.ID == carrera.ID)
                {
                    return c;
                }
            }
            throw new Exception("No se encontro la Carrera con las Siglas:" + carrera.ID);
        }

        public void Modify(Carrera carrera)
        {
            Carrera c = Find(carrera);
            if (c == null)
            {
                throw new Exception("No existe el usuario que desea modificar.");
            }   
        }
        #endregion

    }
}