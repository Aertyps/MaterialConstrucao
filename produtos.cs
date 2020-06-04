using System;
using System.Linq;
using System.IO;
using System.Text;

class Produtos{
  private string nome;
  private string descricao;
  private double valor;
  private int quantidade;
  private string marca;
  private int codigo;

  Produtos(){

  }

 public bool SetCodigo(string num){

   string valor = num;

  if( valor.All(char.IsDigit)){//verifica se tem so numero
    codigo = Convert.ToInt32(num);
    return true;
    }

    return false;
  }

  public int GetCodigo(){
    return codigo;
  }
 
  public double GetValor(){

   return valor; 
  }

  public bool SetValor(string val){
    string valo = val;

    if( valo.All(char.IsDigit)){//verifica se tem so numero
      valor = Convert.ToSingle(valo);
      return true;
    }

    return false;
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

 public string GetDescricao(){
   return descricao;
 }

 public bool SetDescricao(string n){

   if(Pessoa.VerificaPalavra(n)){
     descricao = n;
     return true;

    }else{
       Console.WriteLine ("Descricao invalida!!!");
       return false;
    }
 
 }

  public int GetQuantidade(){
    return quantidade;
  }

 public bool SetQuantidade(string c){
  string valor = c;

  if( valor.All(char.IsDigit)){//verifica se tem so numero
    quantidade = Convert.ToInt32(valor);
    return true;
  }

  return false;
  }

   public bool SetMarca(string e){
   string mc = e;

   if(mc.Length > 0){
      marca = mc;
      return true;
   }
     return false;
 } 

 public string GetMarca(){
   return marca;
 } 

}