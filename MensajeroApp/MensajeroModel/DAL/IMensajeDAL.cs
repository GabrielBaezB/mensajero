using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensajeroModel.DTO;

namespace MensajeroModel.DAL
{
   public interface IMensajeDAL
    {
        void Save(Mensaje m);
        List<Mensaje> GetAll();
    }
}
