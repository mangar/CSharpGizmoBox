using CSGizmoBox.Cep;
using CSGizmoBox.Cep.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSGizmoBox.Example.Cep
{
    public class CepExample
    {

        static void Main(string[] args) {

            Console.WriteLine(">>>");

            var cepExample = new CepExample();
            cepExample.Call();

            Thread.Sleep(2000);
            Console.WriteLine("<<<");

        }


        async void Call()
        {
            Console.WriteLine("  >");
            CepResponse response = await CepRepository.Instance(new CepConfigOptions()).GetCep("04515030");

            Console.WriteLine($" CepValue           :{response.CepValue}");
            Console.WriteLine($"    CepValue.Value       :{response.CepValue.Value}");
            Console.WriteLine($"    CepValue.Logradouro  :{response.CepValue.Logradouro}");
            Console.WriteLine($"    CepValue.Bairro      :{response.CepValue.Bairro}");
            Console.WriteLine($"    CepValue.Cidade      :{response.CepValue.Cidade}");
            Console.WriteLine($"    CepValue.Estado      :{response.CepValue.Estado}");
            Console.WriteLine($"    CepValue.DDD         :{response.CepValue.DDD}");

            Console.WriteLine($" Provider           :{response.Provider}");
            Console.WriteLine($" HttpStatusCode     :{response.HttpStatusCode}");
            Console.WriteLine($" HttpResponseMessage:{response.HttpResponseMessage}");
            Console.WriteLine($" Provider.Response  :{response.ProviderResponse}");
            Console.WriteLine($" RequestAt          :{response.RequestAt}");
            Console.WriteLine($" ResponseAt         :{response.ResponseAt}");

            Console.WriteLine("  <");

            


        }


    }
}
