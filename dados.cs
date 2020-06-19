using System;
using System.IO;
using System.Text;

class Dados{
  
 public Dados(){

 }

  public static void CadastroProduto(string arquivo,Produtos p){//arquivo = "dados.txt"

    string str ="";
    str = ConteudoDeArquivo(arquivo);//pego os dados do pessoa.txt,para nao apaga os dados existentes.
    Produtos produto = new Produtos();
    produto = p;
    string nom = produto.GetNomeProduto();
    string descricao = produto.GetDescricao();
    string marca = produto.GetMarca();
    string cod = GeraCodigoProduto();
    string nomeLoja = produto.GetNome();

    nom = AcertoEspaco(nom);
    descricao = AcertoEspaco(descricao);
    marca =  AcertoEspaco(marca);
    nomeLoja = AcertoEspaco(nomeLoja);
   
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);

    StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
   
    str += ""+nom+" "+descricao+" R$"+produto.GetValor()+" "+marca+" "+produto.GetQuantidade()+" "+cod+" "+nomeLoja+" "+produto.GetCnpj();
   

    sw.WriteLine(str);
    
    sw.Close();
    meuArq.Close();
 }

  public static string GeraCodigoProduto(){

    FileStream meuArq = new FileStream("produtos.txt", FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    int coluna = 0;
    string palavras ="";
    string codigo = "";

    while(!sr.EndOfStream){
      coluna++;
      string str = sr.ReadLine();
      i = 0;

      for(int i2 = 0;i2<str.Length; i2++)
      {
       
       if(str[i2] ==' '){
          i++;
          if(i == 6){
            codigo = palavras;
         }

          palavras="";

       }else{
         palavras+=str[i2];
       }  

      }

    }

    sr.Close();
    meuArq.Close();

    int numero = Convert.ToInt32(codigo);
    numero++;
    codigo =""+numero;
    return codigo;

  }

  public static void CadastroLoja(string arquivo,Loja l,string cpfP){//arquivo = "dados.txt"

    string str ="";
    str = ConteudoDeArquivo(arquivo);//pego os dados do pessoa.txt,para nao apaga os dados existentes.
    Loja loja = new Loja();
    loja = l;
    string cpf = cpfP;
    string nom = loja.GetNome();
    string endereco = loja.GetEndereco();
   

    nom = AcertoEspaco(nom);
    endereco = AcertoEspaco(endereco);
   

    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);

    StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
   
    str += ""+nom+" "+endereco+" "+loja.GetCnpj()+" "+loja.GetTelefone()+" "+cpf;
   

    sw.WriteLine(str);
    
    sw.Close();
    meuArq.Close();
 }

 public static string AcertoEspaco(string palavra){

   string nom = palavra;
   string nom2 ="";


    for(int i = 0;i < nom.Length ; i++)//reorganizando nome,coloco traço no lugar dos espacos pra facilitar leitura
      { 

          if(nom[i] == ' '){

            nom2 +='-';

          }else{

            nom2 +=nom[i];

          }
        
      }

      return nom2;
 }

 public static void Cadastro(string arquivo,Pessoa p){//arquivo = "dados.txt"
    
    Pessoa pessoa = new Pessoa();
    string str ="";
    string mes ="";
    string dia ="";
    pessoa = p;
    string ano = ""+pessoa.GetDataNascimento().Year;

    if(pessoa.GetDataNascimento().Day < 10){//corrigir um erro na escrita

       dia = "0"+pessoa.GetDataNascimento().Day;

    }else{

       dia = ""+pessoa.GetDataNascimento().Day;
    }

    if(pessoa.GetDataNascimento().Month < 10){//corrigir um erro na escrita

       mes = "0"+pessoa.GetDataNascimento().Month;

    }else{
      
       mes = ""+pessoa.GetDataNascimento().Month;
    }

    string nom = pessoa.GetNome();
    string nom2 = "";

    str = ConteudoDeArquivo(arquivo);//pego os dados do pessoa.txt,para nao apaga os dados existentes.

    for(int i = 0;i < nom.Length ; i++)//reorganizando nome,coloco traço no lugar dos espacos pra facilitar leitura
      { 

          if(nom[i] == ' '){

            nom2 +='-';

          }else{

            nom2 +=nom[i];

          }
        
      }

    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);

    StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
   
    str += ""+nom2+" "+pessoa.GetCpf()+" "+ano+" "+dia+" "+mes+" "+pessoa.GetTelefone()+" "+pessoa.GetLogin()+" "+pessoa.GetSenha()+" "+pessoa.GetAcesso();
   

    sw.WriteLine(str);
    
    sw.Close();
    meuArq.Close();
 }

 public static string ConteudoDeArquivo(string arquivo)//pega os dados existentes no arquivo
  {
      StreamReader streamReader = new StreamReader(arquivo);
      string text = streamReader.ReadToEnd();
      streamReader.Close();
      return text;
  }

  public static int BuscarLogin(string arquivo,string l){//faz a busca pelo Login retorna a coluna 
  
    string login = l;
  
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    int coluna = 0;
    string palavras ="";

    while(!sr.EndOfStream){
      coluna++;
      string str = sr.ReadLine();
      i = 0;

      for(int i2 = 0;i2<str.Length; i2++)
      {
       
       if(str[i2] ==' '){
          i++;
          if(i == 7){
           if(login == palavras){
                return coluna;
            }  
         }

          palavras="";

       }else{
         palavras+=str[i2];
       }  

      }

    }

    sr.Close();
    meuArq.Close();

    return 0;
  }

  public static int BuscarLoja(string arquivo,string l){//faz a busca pelo loja
  
    string cpf = l;
  
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    int coluna = 0;
    string palavras ="";

    while(!sr.EndOfStream){
      coluna++;
      string str = sr.ReadLine();
      i = 0;

      for(int i2 = 0;i2<str.Length; i2++)
      {
       
       if(str[i2] ==' '){
          i++;
          palavras="";

       }else{
         palavras+=str[i2];
       }  

      }

      if(cpf == palavras){
          return coluna;
       } 
    }

    sr.Close();
    meuArq.Close();
    
    return 0;
  }

public static Produtos Loja(string cpf1){ //retorno a classe pessoa preechida
  
   string l  = cpf1;
   string arq = "loja.txt";
   Produtos produto = new Produtos();
   int col = BuscarLoja(arq,l);

  if(col == 0 ){

    return null;

  }else{

    FileStream meuArq = new FileStream(arq, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    int coluna1 = 0;
    int coluna = col;
    string palavras ="";
    
    while(!sr.EndOfStream){

      coluna1++;
      string str = sr.ReadLine();

      if(coluna == coluna1){

        for(int i2 = 0;i2<str.Length; i2++)
        {

          if(str[i2] ==' '){
              i++;
              if(i == 1){
                produto.SetNome(palavras);
              //  Console.WriteLine (palavras);

              }else if(i == 2){

                produto.SetEndereco(palavras);
              //  Console.WriteLine (palavras);

              }else if(i == 3){

                produto.SetCnpj(palavras);


              }else if(i == 4){
                
                produto.SetTelefone(palavras);

              }
            
            palavras ="";

          }else{

              if(str[i2] =='-'){

                if(i != 2){
                  palavras +=' ';
                }else{
                  palavras +=str[i2];
                }
                
                }else{

                palavras +=str[i2];
              }
            
          }
        
        }
        
        
      }
    
    }
    sr.Close();
    meuArq.Close();

   
    
  }

  return produto;

  }

  public static Pessoa DadosPessoa(string arquivo,string login){ //retorno a classe pessoa preechida
  
   string l  = login;
   string arq = arquivo;
   Pessoa pessoa = new Pessoa();
   int col = BuscarLogin(arq,l);

  if(col == 0 ){

    return null;

  }else{

    FileStream meuArq = new FileStream(arq, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    int coluna1 = 0;
    int coluna = col;
    string palavras ="";
    string ano ="";
    string dia ="";
    //string mes ="";
    
    while(!sr.EndOfStream){

      coluna1++;
      string str = sr.ReadLine();

      if(coluna == coluna1){

        for(int i2 = 0;i2<str.Length; i2++)
        {
        
            if(str[i2] ==' '){
              i++;

            if(i == 1){
              pessoa.SetNome(palavras);

            }else if(i == 2){

              pessoa.SetCpf(palavras);

            }else if(i == 3){

              ano = palavras;

            }else if(i == 4){
              
              dia = palavras;

            }else if(i == 5){

              pessoa.SetDataNascimento(ano,dia,palavras);

            }else if(i == 6){

              pessoa.SetTelefone(palavras);

            }else if(i == 7){

              pessoa.SetLogin(palavras);

            }else if(i == 8){

              pessoa.SetSenha(palavras);

            }

            palavras = "";

        }else{

            if(str[i2] =='-'){

              palavras +=' ';

            }else{

              palavras +=str[i2];
            }
          
        }
        
        }
        //ultimo dado
        pessoa.SetAcesso(palavras);
      }
    
    }
    sr.Close();
    meuArq.Close();

    return pessoa;
    
  }

  }

//<<<<<<< Douglas
  /*public static string CatalogoProd(string arquivo, int tipo2)
  {
    int tipo = tipo2;
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
    int espaco = 0;
    string produtos = "";

    produtos = "(1) Nome \n(2) Descrição \n(3) Valor \n(4) Quantidade \n(5) Marca \n(6) Código \n\n";

    produtos+="\n..................................................................................................................\n";

    while(!sr.EndOfStream)
   // {
    //  string str = sr.ReadLine();
     // string palavras ="";
  //    espaco = 0;*/
///=======
  public static string Catalogo(){//catalogo de produtos
   
    FileStream meuArq = new FileStream("produtos.txt", FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
    int espaco = 0;
    string  texto  = "";

    texto +="\n......................................................................................................................";

      texto  ="| (1) Nome  \n| (2) Descrição  \n| (3) Valor Unitário \n| (4) Marca \n| (5) Quantidade \n| (6) Codigo \n| (7) Loja \n| (8) Cnpj\n\n";
    
    
    texto +="......................................................................................................................\n";
    
    while(!sr.EndOfStream){
      string str = sr.ReadLine();
      string palavras =" ";
      espaco = 0;

      for(int i2 = 0;i2<str.Length; i2++)
      {

        if(str[i2] ==' '){

          espaco++;
          texto  +="("+espaco+")"+palavras+"  ";
          palavras="";

       }else{
           if(str[i2] =='-'){

              palavras +=' ';

            }else{

              palavras +=str[i2];
            }
       }  

      }

      espaco++;
      texto +="("+espaco+")"+palavras+"  ";
      texto +="\n......................................................................................................................\n";
    }      
    sr.Close();
    meuArq.Close();
    
    return texto ;
  }

  public static string CatalogoProd(string arquivo, int tipo2)
  {
    int tipo = tipo2;
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
    int espaco = 0;
    string produtos = "";

    produtos = "(1) Nome \n(2) Descrição \n(3) Valor \n(4) Quantidade \n(5) Marca \n(6) Código \n\n";

    produtos+="\n..................................................................................................................\n";

    while(!sr.EndOfStream)
    {
      string str = sr.ReadLine();
      string palavras ="";
      espaco = 0;


      for(int i2 = 0;i2<str.Length; i2++)
      {

        if(str[i2] ==' '){

          espaco++;
          produtos  +="("+espaco+")"+palavras+"  ";
          palavras="";

       }else{
           if(str[i2] =='-'){

              palavras +=' ';

            }else{

              palavras +=str[i2];
            }
       }  

      }

      espaco++;
      produtos +="("+espaco+")"+palavras+"  ";
      produtos +="\n......................................................................................................................\n";
    }      
    sr.Close();
    meuArq.Close();
    
    return produtos ;
  }

  public static void PedidoTemporario(Pedido p, string arq){

   Pedido pedido = new Pedido();
   pedido = p;
   string arquivo = arq;
   string str ="";

	 str = ConteudoDeArquivo(arquivo);

   FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);
   StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
	 
    str += ""+pedido.GetNumeroPedido()+" "+pedido.GetCpf()+" "+pedido.GetQtd()+" "+pedido.GetDataPedido().Day+"/"+pedido.GetDataPedido().Month+"/"+pedido.GetDataPedido().Year+" "+pedido.GetCodigo()+" R$"+pedido.GetValorTotalCompras()+" "+pedido.GetCnpj();

   sw.WriteLine(str);
     
   sw.Close();
   meuArq.Close();

   }

  public static void GerarPedido(){

   string arquivo = "pedidos.txt";
   string str ="";
   string str2 = ConteudoDeArquivo(arquivo);
	 str = ConteudoDeArquivo("pedidoTemporario.txt");

   FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);
   StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
   str += str2;
   sw.WriteLine(str);
     
   sw.Close();
   meuArq.Close();

   }

public static void LimparArquivo(string arq){

    string arquivo = arq;
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);
    StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
    meuArq.SetLength(0);
    
    sw.Close();    
    meuArq.Close();
   
  }

  public static string BuscarCodigo(string arquivo,string c){
  
    string codigo = c;
  
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    string cnpj = "0";
    string palavras ="";
    bool certo = false;

    while(!sr.EndOfStream){
     
      string str = sr.ReadLine();
      i = 0;

      for(int i2 = 0;i2<str.Length; i2++)
      {
       
       if(str[i2] ==' '){
          i++;
          if(i == 6){
           if(codigo == palavras){
                certo = true;
            }  
         }

          palavras="";

       }else{
         palavras+=str[i2];
       }  

      }
      if(certo){
        cnpj = palavras;
        certo = false;
      }

    }

    sr.Close();
    meuArq.Close();

    return cnpj;
  }

public static string BuscarCodigoValor(string arquivo,string c){
  
    string codigo = c;
  
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    string valor = "0";
    string palavras ="";
    bool certo = false;

    while(!sr.EndOfStream){
     
      string str = sr.ReadLine();
      i = 0;

      for(int i2 = 0;i2<str.Length; i2++)
      {
       
       if(str[i2] ==' '){
          i++;
          
          if(i == 6){

           if(codigo == palavras){
                return valor;
            }  
         }
        
          if(i == 3){
            valor = palavras;  
          }

          palavras="";

       }else{
         if((str[i2] =='R')||(str[i2] =='$')){

             // palavras +=' ';

            }else{

              palavras +=str[i2];
            }
       }  

      }
     
    }

    sr.Close();
    meuArq.Close();

    return valor;
  }

  public static void CriarAquivo(string texto){//usado na hora de criar loja
     string path = @""+texto+".txt";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        FileStream fs = File.Create(path);
  }

  public static string ListarPedido(string cnpj){

    FileStream meuArq = new FileStream("pedidos.txt", FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
    int espaco = 0;
    string  texto  = "";
    string texto2  = "";

    texto +="\n......................................................................................................................";

      texto  ="| (1) Numero do pedido  \n| (2) Cpf  \n| (3) Quantidade \n| (4) Data \n| (5) Codigo do produto \n| (6) Valor \n| (7) Cnpj \n\n";
    
    
    texto +="......................................................................................................................\n";
    
    while(!sr.EndOfStream){
      string str = sr.ReadLine();
      string palavras =" ";
      espaco = 0;
      texto2 = "";

      for(int i2 = 0;i2<str.Length; i2++)
      {

        if(str[i2] ==' '){

          espaco++;
          texto2 +="("+espaco+")"+palavras+"  ";
          palavras="";

       }else{
           if(str[i2] =='-'){

              palavras +=' ';

            }else{

              palavras +=str[i2];
            }
       }  

      }

      espaco++;

      if(palavras == cnpj){

         texto2 +="("+espaco+")"+palavras+"  ";
         texto += texto2;
         texto+="\n......................................................................................................................\n";
      }
     
    }      
    sr.Close();
    meuArq.Close();
    
    return texto ;

  }

   public static string NotaPedido(){

    FileStream meuArq = new FileStream("pedidoTemporario.txt", FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
    int espaco = 0;
    string  texto  = "";
    string texto2  = "";

    texto +="\n......................................................................................................................";

      texto  ="| (1) Numero do pedido  \n| (2) Cpf  \n| (3) Quantidade \n| (4) Data \n| (5) Codigo do produto \n| (6) Valor \n| (7) Cnpj \n\n";
    
    
    texto +="......................................................................................................................\n";
    
    while(!sr.EndOfStream){
      string str = sr.ReadLine();
      string palavras =" ";
      espaco = 0;
      texto2 = "";


      for(int i2 = 0;i2<str.Length; i2++)
      {

        if(str[i2] ==' '){

          espaco++;/*
<<<<<< Douglas
          produtos +="("+espaco+")"+palavras+"  ";
          palavras="";

       }else{
         palavras+=str[i2];
       }  

      }
      produtos +="("+(espaco + 1)+")"+palavras+"  ";
      produtos+="\n..................................................................................................................\n";
=======*/
          texto2 +="("+espaco+")"+palavras+"  ";
          palavras="";

       }else{
           if(str[i2] =='-'){

              palavras +=' ';

            }else{

              palavras +=str[i2];
            }
       }  

      }

     espaco++;
     texto2 +="("+espaco+")"+palavras+"  ";
     texto += texto2;
     texto+="\n......................................................................................................................\n";
      
     

    }      
    sr.Close();
    meuArq.Close();
    
/*<<<<<< Douglas
    return produtos;
=======*/
    return texto ;


  }

}