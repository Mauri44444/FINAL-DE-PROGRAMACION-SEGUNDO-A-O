namespace Aaa;

class Program
{
    static void Main(string[] args)
    {
        #region CreaciónDeUsuarios
        Console.Clear();
        Usuario usuario = new Usuario();

        usuario.Nombre = "Mauricio";
        usuario.Dni = 46;
        usuario.Mail = "Mauri14200@gmail.com";
        #endregion

        #region CreacionDeCarreras
        Carrera carrera = new Carrera();
        carrera.Nombre = "Tecnicatura Superior en Analisis de Sistemas ";
        carrera.Sigla = "TSAS";
        carrera.Titulo = "Analista en Sistemas";
        carrera.Duracion = 3;
        #endregion

        #region AddUsuarios
        usuario.Add(usuario);
        #endregion

        #region AddCarreras
        carrera.Add(carrera);
        #endregion

        #region ListaUsuarios
        List<Usuario> listaUsuarios = usuario.List();

        foreach(Usuario u in listaUsuarios)
        {
            Console.WriteLine("\nNombre del usuario: " + u.Nombre);
            Console.WriteLine("Dni del usuario: " + u.Dni);
            Console.WriteLine("Mail del usuario: " + u.Mail);
        }
        #endregion

        #region ListaCarreras
        List<Carrera> listaCarrera = carrera.List();
        foreach(Carrera c in listaCarrera)
        {
            Console.WriteLine("\nNombre de la carrera: " + c.Nombre);
            Console.WriteLine("Siglas de la carrera: " + c.Sigla);
            Console.WriteLine("Titulo de la carrera: " + c.Titulo);
            Console.WriteLine("Duracion de la carrera: " + c.Duracion + " años");
        }
        #endregion
    }
}