using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensajeroModel.DTO;

namespace MensajeroModel.DAL
{
    public class MensajeDALArchivo : IMensajeDAL
    {
        // ruta donde guardara el archivo, se puede poner 
        //directamente la ruta donde quiera guardar
        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "mensaje.csv";

        //Patron Singleton
        //1.Constructor privado
        private MensajeDALArchivo()
        {

        }
        //2. Un atributo de tipo estatico privado de la misma instancia
        private static IMensajeDAL instancia;
        //3.Un metodo estatico que permita obtener la unica instancia
        public static IMensajeDAL GetInstance()
        {
            if (instancia == null)
            { instancia = new MensajeDALArchivo(); }
                
            return instancia;
        }

        public List<Mensaje> GetAll()
        {
            List<Mensaje> lista = new List<Mensaje>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string linea = null;
                    do
                    {
                        linea = reader.ReadLine();
                        if(linea != null)
                        {
                            string[] textoArray = linea.Split(';');
                            Mensaje m = new Mensaje()
                            {
                                Nombre = textoArray[0],
                                Detalle = textoArray[1],
                                Tipo = textoArray[2]
                            };
                            lista.Add(m);
                        }
                    } while (linea != null);
                }

            }catch(IOException ex)
            {
                lista = null;
            }
            return lista;
        }

        public void Save(Mensaje m)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }

            }catch(IOException ex)
            {

            }
        }
    }
}
