using CadastroPessoa.Classes;

Console.Clear();

Console.WriteLine(@$"
##########################################
|   Bem vindo ao sistema de cadastro de  |
|      Pessoas Físicas e Jurídicas       |
##########################################
");

// Barracarregamento ("Carregando", 600);

// void Barracarregamento(string v1, int v2)
// {
// throw new NotImplementedException();
// }

// {
//     throw new NotImplementedException();
// }

List<PessoaFisica> listaPf = new List<PessoaFisica>();

List<PessoaJuridica> listaPj = new List<PessoaJuridica>();




string? opcao;

do
{
    Console.Clear();
    Console.WriteLine(@$"
 ===================================
|   Escolha uma das opções abaixo   |
|-----------------------------------|
|       1 - Pessoa Física           |
|       2 - Pessoa Jurídica         |
|       0 - Sair                    |
 ===================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            PessoaFisica metodoPF = new PessoaFisica();
            string? opcaoPf;

            do
            {


                Console.Clear();
                Console.WriteLine(@$"
  ===================================
|   Escolha uma das opções abaixo     |
| ----------------------------------- |
|     1 - Cadastrar pessoa Física     |
|     2 - Listar Pessoa Física        |
|     0 - Retornar ao menu anterior   |
  ===================================
");
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novaPf = new PessoaFisica();

                        endereco novoEnd = new endereco();

                        Console.WriteLine($"Digite o nome do usuário");
                        novaPf.Nome = Console.ReadLine();

                        bool dataValida;

                        do
                        {
                            Console.WriteLine($"Digite data de nascimento Ex.:DD/MM/AAAA");
                            string? dataNasc = Console.ReadLine();


                            dataValida = metodoPF.ValidarDataNasc(dataNasc);

                            if (dataValida)
                            {
                                novaPf.dataNasc = dataNasc;
                            }
                            else
                            {
                                Console.WriteLine($"Data inválida, digite data válida por favor");

                            }

                        } while (!dataValida);



                        Console.WriteLine($"Digite cpf apenas com números");
                        novaPf.Cpf = Console.ReadLine();

                        Console.WriteLine($"Digite rendimento mensal apenas com números");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite logradouro");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte enter para vazio)");
                        novoEnd.Complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEnd.endComercial = true;

                        }
                        else
                        {
                            novoEnd.endComercial = false;
                        }


                        novaPf.Endereco = novoEnd;

                        listaPf.Add(novaPf);


                        //tarefa txt
                        using (StreamWriter sw = new StreamWriter($"{novaPf.Nome}.txt"))
                        {
                            sw.WriteLine(novaPf.Nome);
                            sw.WriteLine(novaPf.Cpf);
                            sw.WriteLine(novaPf.rendimento);
                            sw.WriteLine(novoEnd.logradouro);
                            sw.WriteLine(novoEnd.numero);
                            sw.WriteLine(novoEnd.Complemento);
                        }




                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Thread.Sleep(3000);


                        break;

                    case "2":
                        Console.Clear();

                        // tarefa txt
                        using (StreamReader sr = new StreamReader("Lacerda.txt"))
                        {
                            string? linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                                Console.WriteLine($"{linha}");

                            }
                        }

                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.WriteLine(@$"

        Nome: {cadaPessoa.Nome}
        CPF: {cadaPessoa.Cpf}
        Endereço: {cadaPessoa.Endereco.logradouro}, {cadaPessoa.Endereco.numero}
        Rendimento: {cadaPessoa.rendimento.ToString("C")}
        Taxa de imposto R$: {metodoPF.PagarImposto(cadaPessoa.rendimento).ToString("C")}

        ");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia");
                            Thread.Sleep(3000);

                        }

                        Console.WriteLine($"Enter para continuar");
                        Console.ReadLine();
                        break;

                    case "0":
                        break;

                    default:

                        Console.Clear();
                        Console.WriteLine($"Digite um opção válida!!!");
                        Console.WriteLine($"Enter para continuar");
                        Thread.Sleep(3000);
                        break;
                }

            } while (opcaoPf != "0");


            break;

        case "2":
            PessoaJuridica metodoPj = new PessoaJuridica();
            string? opcaoPj;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
            =====================================
            |  Escolha uma das opções abaixo    |
            |-----------------------------------|
            |   1 - Cadastrar pessoa jurídica   |
            |   2 - Listar pessoa jurídica      |
            |   0 - Voltar ao menu anterior     |
            =====================================
            ");

                opcaoPj = Console.ReadLine();

                switch (opcaoPj)
                {
                    case "1":
                        PessoaJuridica novaPj = new PessoaJuridica();
                        endereco novoEnd = new endereco();

                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digite o CNPJ da empresa");
                            string? cnpj = Console.ReadLine();
                            cnpjValido = metodoPj.ValidarCnpj(cnpj);
                            if (cnpjValido)
                            {
                                novaPj.Cnpj = cnpj;
                            }
                            else
                            {
                                Console.WriteLine($"CNPJ inválido. Digite um novo CNPJ.");

                            }
                        } while (!cnpjValido);

                        Console.WriteLine($"Digite razão social");
                        novaPj.razaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (somente números)");
                        novaPj.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte ENTER para vazio)");
                        novoEnd.Complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial S/N");
                        string endCom = Console.ReadLine().ToUpper();
                        if (endCom == "S")
                        {
                            novoEnd.endComercial = true;
                        }
                        else
                        {
                            novoEnd.endComercial = false;
                        }

                        novaPj.Endereco = novoEnd;
                        listaPj.Add(novaPj);
                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Thread.Sleep(3000);

                        break;



                    case "2":
                        Console.Clear();

                        if (listaPj.Count > 0)
                        {
                            foreach (PessoaJuridica cadaPessoaJ in listaPj)
                            {
                                Console.WriteLine(@$"
                                Nome: {cadaPessoaJ.Nome}
                                CNPJ: {cadaPessoaJ.Cnpj}
                                Endereço: {cadaPessoaJ.Endereco.logradouro}, {cadaPessoaJ.Endereco.numero}
                                ");
                            }

                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia!");
                            Thread.Sleep(3000);
                        }

                        Console.WriteLine($"Enter para continuar");
                        Console.ReadLine();

                        break;

                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida! Por favor, digite um número válido.");
                        Thread.Sleep(3000);
                        break;
                }


            } while (opcaoPj != "0");
            break;
        case "0":

            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar o sistema");


            // Barracarregamento("Finalizando", 500);

            // for (var i = 0; i < 6; i++)
            // {
            //     Console.Write(".");
            //     Thread.Sleep(500);
            // }

            // Console.ResetColor();

            break;

        default:
            Console.Clear();
            Console.WriteLine($"Digite um opção válida!!!");
            Console.WriteLine($"Enter para continuar");
            Console.ReadLine();
            break;

    }
} while (opcao != "0");



