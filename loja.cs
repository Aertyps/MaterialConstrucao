using System;
using System.IO;
using System.Text;

class Loja{

  private string nome;
  private string endereco;
  protected string cnpj;
  private int telefone;
 
 public Loja(){

 }

  public string GetCnpj(){
    return cnpj;
  }

 public bool SetCnpj(string c){
  string valor = c;

  if( ValidaCnpj(valor)){//valida cnpj
    cnpj = valor;
    return true;
  }

  return false;
  }

  public void SetCnpjVerificado(string c){
    cnpj = c;
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

public static bool ValidaCnpj(string cnpj)
		{
			int[] multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
			int[] multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
			   return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for(int i=0; i<12; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if ( resto < 2)
			   resto = 0;
			else
			   resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
			    resto = 0;
			else
			   resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}

}