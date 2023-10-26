using CSGizmoBox.Cep.Entity;
using CSGizmoBox.Cep.Services;

namespace CSGizmoBox.Test.Cep
{

    public class ImplTestAConsultarCEP : AConsultarCEP
    {
        public ImplTestAConsultarCEP(HttpClient httpClient) : base(httpClient)
        {
        }

        public override Task<CepResponse> GetCEP(string cep)
        {
            throw new NotImplementedException();
        }
    }


    public class AConsultarCEPTest
    {

        [Fact]
        public void NormalizarCep()
        {
            ImplTestAConsultarCEP consultarCep = new ImplTestAConsultarCEP(null);

            Assert.Equal("14055490", consultarCep.NormilizarCep("14055-490"));
            Assert.Equal("14055000", consultarCep.NormilizarCep("14055000"));
            Assert.Equal("14055000", consultarCep.NormilizarCep("14055"));
        }

        [Fact]
        public void AddSeparadorCep()
        {
            ImplTestAConsultarCEP consultarCep = new ImplTestAConsultarCEP(null);

            Assert.Equal("14055-490", consultarCep.AddSeparadorCep("14055-490"));
            Assert.Equal("14055-000", consultarCep.AddSeparadorCep("14055000"));
            Assert.Equal("14055-000", consultarCep.AddSeparadorCep("14055"));
        }

    }
}
