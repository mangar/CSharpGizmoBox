using CSGizmoBox.Cep.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGizmoBox.Cep.Services
{
    public class ConsultarCepFactory
    {
        public static AConsultarCEP CreateConsultarCep(HttpClient httpClient, string providerKey)
        {
            ConsultarCepViaCep consultarCepViaCep = new ConsultarCepViaCep(httpClient);
            return consultarCepViaCep;
        }
    }
}
