using System;
using System.Linq;
using System.IO;
using System.Text;

class Loja{

  private string nome;
  private string endereco;
  protected int cnpj;
  private int telefone;
 
 public Loja(){

 }

  public int GetCnpj(){
    return cnpj;
  }

 public bool SetCnpj(string c){
  string valor = c;

  if( valor.All(char.IsDigit)){//verifica se tem so numero
    cnpj = Convert.ToInt32(valor);
    return true;
  }

  return false;
  }

 public bool SetEndereco(string e){
   string endere = e;

   if(endere.Length > 0){
      endereco = e;
      return true;
   }
     return false;
 } 

 public string GetEndereco(){
   return endereco;
 } 

 public string GetNome(){
   return nome;
 }

 public bool SetNome(string n){

   if(Pessoa.VerificaPalavra(n)){
     nome = n;
     return true;

    }else{
       Console.WriteLine ("Nome invalido!!!");
       return false;
    }
 
 }

 public int GetTelefone(){
  return telefone;
}

public bool SetTelefone(string t){

  if(Pessoa.VerificaTelefone(t)){

    telefone = Convert.ToInt32(t);
    return true;

  }else{

    return false;
  }
 
}

}