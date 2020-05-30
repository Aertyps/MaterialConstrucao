using System;
using System.Linq;
using System.IO;
using System.Text;

class Pessoa{
 private string nome;
 private string cpf;
 private DateTime dataNascimento;
 private int telefone;
 private string login;
 private string senha;
 private int acesso;

 public Pessoa(){

 }

 public string GetLogin(){
   return login;
 }

 public bool SetLogin(string l){

   string valor = l;

   if(valor.Length > 4){//login maior que 4 digitos
     login = l;
     return true;

    }else{
       Console.WriteLine ("Login invalido,quantidade de caracteres menor que  5 !!!");
       return false;
    }
 
 }

 public int GetAcesso(){
   return acesso;
 }

 public void SetAcesso(string a){
   string valor = a;
   if(valor.All(char.IsDigit)){//se é numero
     acesso = Convert.ToInt32(valor);
    }else{
       Console.WriteLine (" acesso invalido!!!");
    }
 
 }
 
public string GetSenha(){
   return senha;
 }

 public bool SetSenha(string s){

   string valor = s;

   if(valor.Length == 4){//senha igual a 4 digitos

      senha = s;
      return true;

    }else{

       Console.WriteLine ("senha invalida!!!");
       return false;
    }
 
 }

 public string GetNome(){
   return nome;
 }

 public bool SetNome(string n){

   if(VerificaPalavra(n)){
     nome = n;
     return true;

    }else{
       Console.WriteLine ("Nome invalido!!!");
       return false;
    }
 
 }
 
  public string GetCpf(){
   return cpf;
 }

 public bool SetCpf(string c){

   if(VerificarCpf(c)){
      cpf = c;
      return true;

   }else{
      return false;

   }
   
 }

 public DateTime GetDataNascimento(){
   return dataNascimento;
 }
 
 public bool SetDataNascimento(string ano,string dia,string mes){

  if(VerificaData(ano,4)){

    if(VerificaData(dia,2)){

      if(VerificaData(mes,2)){

          dataNascimento = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
      }else{
         Console.WriteLine ("data invalida!!!");
         return false;
      }
   
    }else{
       Console.WriteLine ("data invalida!!!");
       return false;
    }
    
  }else{
     Console.WriteLine ("data invalida!!!");
     return false;
  }

  return true;
   
 }

 public void SetDataNascimento(DateTime data){//vem do txt
  dataNascimento = data;
 }

public int GetTelefone(){
  return telefone;
}

public bool SetTelefone(string t){

  if(VerificaTelefone(t)){

    telefone = Convert.ToInt32(t);
    return true;

  }else{

    return false;
  }
 
}

public static bool VerificaData(string data,int tam){

  string valor = data;

    if(valor.Length == tam && valor.All(char.IsDigit)){//verifica se tem so numero

      return true;

    }else{

      return false;
    }

}

public static bool VerificaPalavra(string letra){

  string valor = letra;

    if( valor.Length != 0){//verifica se tem so letra
      
    
      for(int i = 0;i < valor.Length; i++)
      {
       if(!(char.IsLetter(valor[i])||valor[i]==' ')){
          return false;
       }
      
      }
      return true;

    }else{

      return false;
    }

}

public static bool VerificaTelefone(string tel){

  string valor = tel;

    if( valor.Length == 9 && valor.All(char.IsDigit)){//verifica se tem so numero

      return true;

    }else{

      return false;
    }

}

public int GetIdade(){

    return CalcularIdade(dataNascimento);
}

public static int CalcularIdade(DateTime ano){

    int anoNasc = ano.Year;// pego o ano do nascimento
    DateTime data = DateTime.Now;//pego a data agora
    return (data.Year - anoNasc);//subtraio o ano de agora pelo nascimento
}

public static bool VerificarCpf(string cpFentrada) {
    string entrada = cpFentrada;
    int[] cpf = new int[11];
    int[] digto1 = new int[10];
    int ind = 10,soma = 0,digVerif1 = 0;
  
    if(entrada.Length == 11)
    {
      for(int i = 0;i < 11; i++)
      {
       cpf[i] = (int)char.GetNumericValue(entrada[i]);
      
      }

      for(int i2 = 0;i2 < 9; i2++)
      {
       digto1[i2] = cpf[i2]*ind;
       ind--;
       soma += digto1[i2];
      }

     
      digVerif1 = (soma -((soma/11)*11));

      if(digVerif1 >= 2){
        digVerif1 = (11 - digVerif1);
      }else{
        digVerif1 = 0;
      }
    
     if(cpf[9] == digVerif1)
     {

       

        ind = 11;
        soma = 0;
        for(int i3 = 0;i3 < 10; i3++)
        {
        digto1[i3] = cpf[i3]*ind;
        ind--;
        soma += digto1[i3];
        }

      
        digVerif1 = (soma -((soma/11)*11));

        if(digVerif1 >= 2){
          digVerif1 = (11 - digVerif1);
        }else{
          digVerif1 = 0;
        }

       if(cpf[10] == digVerif1)
        {
         
         return true;

        }else{
        
          return false;
        }

     }else{
        Console.WriteLine ("O primeiro digito verificador é "+cpf[9]+" esta incorreto!");
        Console.WriteLine ("deveria ser "+digVerif1);
        return false;
     }

    }else{
      Console.WriteLine ("numero de digitos do cpf incorreto");
       return false;
    }
  
  }

}