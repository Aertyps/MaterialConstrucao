using System;

class MainClass {

  public static void Main (string[] args) {
    
    Pessoa pessoa = new Pessoa();
    int op = 0;

    op = Menu();//opçoes iniciais
    Console.Clear();//limpar tela

    if(op == 1){
      CadastrarPessoa();//cadastro
      
    }else if(op == 2){

      pessoa = Login();//verifico login retorno a classe preechida
      
      if(pessoa.GetAcesso() == 0){//cliente
      
      Cliente cliente = new Cliente(pessoa,0,0.0);
      Pedido(cliente);

      }else if(pessoa.GetAcesso() == 1){//funcionario -- tente login fulano senha 12345
       
        bool trava = true;

        while(trava){

          int decisao = MenuFuncionario();
        
          if(decisao == 1){

            Console.Clear();//limpar telaD

            if(Dados.BuscarLoja("loja.txt",pessoa.GetCpf()) != 0){

              Console.WriteLine ("Já tem loja cadastrada!!!");

            }else{

               CadastrarLoja(pessoa.GetCpf());//cadastrar uma loja
            }

           
            
          }else if(decisao == 2){

            Console.Clear();//limpar tela

            if(Dados.BuscarLoja("loja.txt",pessoa.GetCpf()) != 0){

              CadastrarProdutos(pessoa.GetCpf());//cadastrar um produto

            }else{

                Console.WriteLine ("Não tem loja cadastrada!!!");
            }

          }else if((decisao != 1)&&(decisao != 2)){
            
            trava = false;
          }

        }
      
      }else if(pessoa.GetAcesso() == 2){//adm

       Console.WriteLine ("\nDigite ( 1 ) para definir acesso");

      }
    } 

    Console.WriteLine ("Tudo ok !!! Continua....");

  }

  //..............................................................Funções

  public static int Menu(){

    int num = 0;

    Console.WriteLine ("\nDigite ( 1 ) : para Registrar-se");
    Console.WriteLine ("Digite ( 2 ) : para Logar");
    Console.WriteLine ("Digite qualquer numero para sair\n");

    try{
    
      num = Convert.ToInt32(Console.ReadLine()); 

    }

    catch (FormatException){

        Console.WriteLine ("\nFormato de numero incorreto!!");
        num = Menu();//loop origins
    }

    return num;
    
  }

  //public static int MenuCliente()
  //{
   // Pessoa pessoa = new Pessoa();
    //int num = 0;
//
  //    Console.WriteLine("\nDigite 1 para comprar um produto");
    //  Console.WriteLine("Digite qualquer número para sair\n");
      //num = Convert.ToInt32(Console.ReadLine());
      //if (num == 1)
      //{
       // Cliente cliente = new Cliente(pessoa,0,0.0);
        //Pedido(cliente);
      //}
    //return num;
  //}

  public static int MenuFuncionario(){

    int num = 0;

     Console.WriteLine ("\nDigite ( 1 ) para cadastrar uma loja");
     Console.WriteLine ("Digite ( 2 ) para cadastrar um produto");
     Console.WriteLine ("Digite ( 3 ) para comprar");
     Console.WriteLine ("Digite qualquer numero para sair\n");

    try{
    
      num = Convert.ToInt32(Console.ReadLine()); 

    }

    catch (FormatException){

        Console.WriteLine ("\nFormato de numero incorreto!!");
        num = MenuFuncionario();//loop origins
    }

    return num;
    
  }

public static Pessoa Login(){//faz o login

  Pessoa pessoa = new Pessoa();
  bool op = true;
  string senha = "";

  while(op){

    try{
      
    Console.WriteLine ("Digite seu login");
    pessoa = Dados.DadosPessoa("pessoa.txt",Console.ReadLine());
    senha = pessoa.GetSenha();//tento pega a senha se vir null da erro
    op = false;

    }

    catch (NullReferenceException){

      Console.WriteLine ("\nLogin incorreto!!");
      op = true;
    }

  }
  
  op = true;

  while(op){

    Console.WriteLine ("Digite sua senha");

    if(senha == Console.ReadLine()){
      Console.Clear();//limpar tela
      Console.WriteLine ("Bem vindo,"+pessoa.GetNome());
      op = false;
    }
  }

  return pessoa;
}

public static void CadastrarLoja(string cpf1){

  string cpf = cpf1;
  Loja loja = new Loja();
  bool op = true;

  while(op){

    Console.WriteLine ("\nDigite Nome da Loja");

    if(loja.SetNome(Console.ReadLine())){
      op = false;
    }
  }

  op = true;

  while(op){

    Console.WriteLine ("\nDigite o Endereço");

    if(loja.SetEndereco(Console.ReadLine())){
      op = false;
    }
  }

   op = true;

  while(op){

    Console.WriteLine ("\nDigite o Telefone 8 digitos");

    if(loja.SetTelefone(Console.ReadLine())){
      op = false;
    }
  }

 op = true;

  while(op){

    Console.WriteLine ("\nDigite o Cnpj");

    if(loja.SetCnpj(Console.ReadLine())){
      op = false;
    }
  }

  Dados.CadastroLoja("loja.txt", loja, cpf);
  Console.WriteLine ("\nCadastro Realizado!");

}

public static void CadastrarProdutos(string cpf1){

  Produtos produto = new Produtos();
  bool op = true;
  
  produto = Dados.Loja(cpf1);
  Console.WriteLine ("Nome da loja: "+produto.GetNome());
  Console.WriteLine ("Cnpj : "+produto.GetCnpj());
  Console.WriteLine ("Cpf : "+cpf1);

  while(op){

    Console.WriteLine ("\nDigite Nome do produto");

    if(produto.SetNomeProduto(Console.ReadLine())){
      op = false;
    }
  }

  op = true;

  while(op){

    Console.WriteLine ("\nDigite a descrição do produto");

    if(produto.SetDescricao(Console.ReadLine())){
      op = false;
    }
  }

  op = true;

  while(op){

    Console.WriteLine ("\nDigite o valor produto");

    if(produto.SetValor(Console.ReadLine())){
      op = false;
    }
  }

  op = true;

  while(op){

    Console.WriteLine ("\nDigite a quantidade do produto");

    if(produto.SetQuantidade(Console.ReadLine())){
      op = false;
    }
  }
  op = true;

  while(op){

    Console.WriteLine ("\nDigite a marca do produto");

    if(produto.SetMarca(Console.ReadLine())){
      op = false;
    }
  }

  Dados.CadastroProduto("produtos.txt",produto);
  Console.WriteLine ("\nCadastro Realizado!");
}

public static void CadastrarPessoa(){

  Pessoa pessoa = new Pessoa();
  bool op = true;

  while(op){

    Console.WriteLine ("\nDigite seu Nome completo");
    if(pessoa.SetNome(Console.ReadLine())){
      op = false;
    }
  }
       
 op = true;

  while(op){

  Console.WriteLine ("\nDigite seu Cpf");
  if(pessoa.SetCpf(Console.ReadLine())){
    op = false;
  }

  }

      op = true;

  Console.WriteLine ("Digite sua Data de Nascimento :");

  while(op){

    Console.WriteLine ("\nDigite o dia de nascimento - 2 digitos");
    string dia = Console.ReadLine();

    Console.WriteLine ("\nDigite o mes - 2 digitos");
    string mes = Console.ReadLine();

    Console.WriteLine ("\nDigite o ano - 4 digitos");
      string ano = Console.ReadLine();

    if(pessoa.SetDataNascimento(ano,dia,mes)){
      op = false;
    }
        
  }
        
    op = true;

  while(op){
    Console.WriteLine ("\nDigite seu Telefone - sem o ddd 8 digitos");

      if(pessoa.SetTelefone(Console.ReadLine())){
          op = false;
      }
  }
      op = true;

  while(op){
    Console.WriteLine ("\nDeseja vender produtos - ( s ) para sim ou ( n ) para não");//se sim libero o acesso 2 tipo funcionario
      string tipo = Console.ReadLine();

      if(tipo == "n"){
        pessoa.SetAcesso("0");
        op = false;
         

      }else if(tipo == "s"){
        pessoa.SetAcesso("1");
        op = false;
      }
      
      
     
  }
        
  op = true;

  while(op){

   Console.WriteLine ("\nDigite seu Login - maior que 4 digitos");
      if(pessoa.SetLogin(Console.ReadLine())){
          op = false;
      }

  }

  op = true;

  while(op){
    Console.WriteLine ("\nDigite sua Senha - maior que 4 digitos");
      if(pessoa.SetSenha(Console.ReadLine())){
            op = false;
      }
  }
        

   Dados.Cadastro("pessoa.txt",pessoa);
   Console.WriteLine ("\nCadastro Realizado!");
   
  }  


  public static bool Pedido(Cliente c)
  {
    
    double valorTotal = 0;
    Cliente cliente = new Cliente();
    cliente = c;
    bool oper=true;
    int num = 0;

   Console.Clear();
   Console.WriteLine("\nOlá, bem vindo a tela de pedidos! Gostaria de ver o catálogo de produtos?");
   while (oper)
   {
     Console.WriteLine("\nDigite 1 para ver o catálogo");
     Console.WriteLine("\nDigite 0 para sair");
     num = Convert.ToInt32(Console.ReadLine());
    
     if(num == 1)
     {
       oper = MostrarProdutos(cliente);
     }
     else if(num == 0)
     {
       return true;
     }
   }
   return true;
  }
 public static bool MostrarProdutos(Cliente c)
 {
  Console.Clear();
  Cliente cliente = new Cliente();
  cliente = c;
  Console.WriteLine("\nSegue abaixo nosso catálogo de produtos\n");
  Console.WriteLine(Dados.CatalogoProd("produtos.txt",0));
  return true;
 }
}



