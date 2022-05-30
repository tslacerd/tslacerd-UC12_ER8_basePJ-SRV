using CadastroPessoa.Interface;

namespace CadastroPessoa.Classes
{
    public abstract class Pessoa : IPessoa
    {
        public string? Nome { get;set; }

        public float rendimento { get;set; }


        public endereco? Endereco { get; set; }

        public abstract float PagarImposto(float rendimento);

        
        
    }
}