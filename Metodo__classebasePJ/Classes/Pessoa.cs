using CadastroPessoa.Interface;

namespace CadastroPessoa.Classes
{
    public abstract class Pessoa : IPessoa
    {
        public string? Nome { get;set; }

        public float rendimento { get;set; }


        public endereco? Endereco { get; set; }

        public abstract float PagarImposto(float rendimento);

        public void verificarPastaArquivo (string caminho){

            string pasta = caminho.Split("/")[0];
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(caminho))
            {
                using(File.Create(caminho)){}
                
                
            }

        }
        
    }
}