using System.Text.RegularExpressions;
using CadastroPessoa.Interface;

namespace CadastroPessoa.Classes
{
    public class PessoaJuridica : Pessoa , IPessoaJuridica
    {
       public string? Cnpj { get; set; }

       public string? razaoSocial { get; set; }

       public string caminho {get; private set; } = "Database/PessoaJuridica.csv";


        public override float PagarImposto(float rendimento)
        {
            //throw new NotImplementedException();
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f;
                
            }
            else if (rendimento <= 6000)
            {
                return rendimento * 0.05f;
            
            }
            else if (rendimento <= 10000)
            {
                return rendimento * 0.07f;
            }
            else 
            {
                return rendimento * 0.09f;
            }
        }

        public bool ValidarCnpj(string cnpj)
        {
          if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
          {
              if (cnpj.Length == 18)
              {
                if (cnpj.Substring(11, 4) =="0001")
              {
                 return true; 
              }
          } else if (cnpj.Length == 14)
          {
              if (cnpj.Substring(8, 4) == "0001")
              {
                  return true;
              }

          }
          
                    
        } 
        return false;
    }

    public void Inserir(PessoaJuridica pj){

            verificarPastaArquivo(caminho);


            string [] pjString = {$"{pj.Nome}; {pj.Cnpj}; {pj.razaoSocial}"};

            File.AppendAllLines(caminho, pjString);
    }

    public List <PessoaJuridica> LerArquivo(){
        List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

        string[] linhas = File.ReadAllLines(caminho);

        foreach (string cadalinha in linhas)
        {
            string[] atributos = cadalinha.Split(",");

            PessoaJuridica cadapj = new PessoaJuridica();

            cadapj.Nome = atributos[0];
            cadapj.Cnpj = atributos[1];
            cadapj.razaoSocial = atributos[2];

            listaPj.Add(cadapj);
        }

        return listaPj;
    }

        internal List<PessoaJuridica> LerArquivo();
        {
            throw new NotImplementedException();
        }

        internal object ValidarCnpj(object cnpj)
        {
            throw new NotImplementedException();
        }
    }
}