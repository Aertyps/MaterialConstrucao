using System;

class MainClass {

  public static void Main (string[] args) {
    
    Pessoa pessoa = new Pessoa();
    int op = 0;
    Console.WriteLine ("\nPrime Material de Construção Online");
    //Dados.CriarAquivo("12345");

    op = Menu();//opçoes iniciais
    Console.Clear();//limpar tela

    if(op == 1){
      CadastrarPessoa();//cadastro
      
    }else if(op == 2){

      pessoa = Login();//verifico login retorno a classe preechida
      
      if(pessoa.GetAcesso() == 0){//cliente2
       Console.Clear();//limpar tela
       Console.WriteLine ("\nTabela de Produtos");
       Venda(pessoa);

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

          }else if(decisao == 3){
              Console.Clear();//limpar tela
              Venda(pessoa);
          }else{

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

  public static int MenuFuncionario(){

    int num = 0;

     Console.WriteLine ("\nDigite ( 1 ) para cadastrar uma loja");
     Console.WriteLine ("Digite ( 2 ) para cadastrar um produto");
     Console.WriteLine ("Digite ( 3 ) para comprar");
     Console.WriteLine ("Digite ( 4 ) para verificar pedidos");
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

public static void Venda(Pessoa pessoa){

  bool trava = true;
  bool travaSup = true;
  int cod = 0;
  string dia ="";
  Produtos produto = new Produtos();
  DateTime data = DateTime.Now;
  Pedido pedido;

  if(data.Day <10)
  {
     dia = "0"+data.Day;

  }else{

     dia = ""+data.Day;
  }

 string mes="";

 if(data.Month<10){

    mes ="0"+data.Month;

  }else{

      mes =""+data.Month;
  }
        
  string ano =""+data.Year;
  cod = Convert.ToInt32(dia+""+mes+""+data.Minute);
  
  Console.Clear();//limpar tela
  Console.WriteLine (Dados.Catalogo());
  int codigo = 0;
  int quantidade = 0;

  while(travaSup){
      trava = true;

    while(trava){

      Console.WriteLine ("Digite o codigo do produto [indice] (6) desejado");
      Console.WriteLine ("Digite ( 1 ) para finalizar a compra");
      Console.WriteLine ("Digite ( 0 ) para voltar ao menu anterior");
     

      string testarCodigo = "";

      try{
        testarCodigo = Console.ReadLine();
        codigo = Convert.ToInt32(testarCodigo);
        trava = false;
      }

      catch (FormatException){

        Console.WriteLine ("\nFormato de numero incorreto!!");
        trava = true;
      }
      string cnpj = Dados.BuscarCodigo("produtos.txt",testarCodigo);
      if( cnpj == "0"){
        trava = true;

      }else{
        produto.SetCodigo(testarCodigo);
        produto.SetCnpj(cnpj);
        produto.SetValor(Dados.BuscarCodigoValor("produtos.txt",testarCodigo));
      }
      
      if(codigo == 0){
        trava = false;
        travaSup = false;

      }else if( codigo == 1){
      
        Finalizacao();
        trava = false;
        travaSup = false;

      }

    }

    if((codigo == 0)||(codigo == 1)){

      trava = false;
    }else{
      
      trava = true;
    }
    
    while(trava){

      Console.WriteLine ("Digite a quantidade desejada");

      try{
      
        quantidade = Convert.ToInt32(Console.ReadLine());
        trava = false;

        if(quantidade <= 0 ){
          trava = true;
        }
      }
      catch (FormatException){

          Console.WriteLine ("\nFormato de numero incorreto!!");
          trava = true;
      }

      if(trava == false){
        pedido = new Pedido(ano,dia,mes,cod,quantidade,produto);
        pedido.SetCpf(pessoa.GetCpf());
        pedido.SetNome(pessoa.GetNome());
        pedido.SetValorTotalCompras(pedido.GetValorTotalCompras()*quantidade);
        Dados.PedidoTemporario(pedido,"pedidoTemporario.txt");
      }
      
    }
  }

}

public static void Finalizacao(){

  // Pedido pedido = new Pedido();
  //  pedido = p;
    bool op = true;

      while(op){
        
        Console.WriteLine ("\nQual sera a forma de pagamento ?");
        Console.WriteLine ("\nDigite (1) para dinheiro");
        Console.WriteLine ("Digite (2) para cartao");
      
        int num = Convert.ToInt32(Console.ReadLine());

        if(num == 1){
          //NotaFiscal(pedido,"dinheiro");
          Console.WriteLine ("\nVenda Finalizada");
          Console.WriteLine ("Obrigado pela preferencia!");

          op = false;

        }else if(num == 2){

          //RegistrarCartao();
         // NotaFiscal(pedido,"Cartao");
          Console.WriteLine ("\nVenda Finalizada");
          Console.WriteLine ("Obrigado pela preferencia!");
          op = false;

        }else{
          Console.WriteLine ("Opçao invalida!!");
        }

      }
}

public static void NotaFiscal(Pedido p, string tipo){

  Pedido pedido = new Pedido();
  pedido = p;
  string texto ="";
  texto+="\n..................................................................................................................\n";
  Console.WriteLine (texto);
  Console.WriteLine ("\nNOTA FISCAL NUMERO "+(5000+pedido.GetNumeroPedido()));
  Console.WriteLine (texto);
  Console.WriteLine ("Comprador "+pedido.GetNome()+" Cpf "+pedido.GetCpf()+" Idade "+pedido.GetIdade()+"\n");
  Console.WriteLine ("Descrição da compra : ");
  //Console.WriteLine ("Valor Total da Compra R$"+ListaCompraTotal(pedido));
  Console.WriteLine ("Forma de Pagamento "+tipo);
  Console.WriteLine (texto);

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
      Console.WriteLine ("Bem vindo "+pessoa.GetNome());
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

    Console.WriteLine ("\nDigite o Cnpj - somente os numeros");

    if(loja.SetCnpj(Console.ReadLine())){
      op = false;
    }
  }

  Dados.CadastroLoja("loja.txt", loja, cpf);
  Dados.CriarAquivo(loja.GetCnpj());
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
}
