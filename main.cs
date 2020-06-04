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
  
  }  
}
