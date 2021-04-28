using MensajeroModel.DTO;
using MensajeroModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp
{
    class Program
    {
        static IMensajeDAL dal = MensajeDALFactory.CreateDal();

        static void Main(string[] args)
        {
            Mensaje m = new Mensaje()
            {
                Nombre = "Gabriel",
                Detalle = "Estoy Volao",
                Tipo = "Estado de coma",

            };
            dal.Save(m);
        }
    }
}
