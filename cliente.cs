using System;
using System.Linq;
using System.IO;
using System.Text;

class Cliente:Pessoa{

  private int comprasRealizadas;
  private double valorTotalCompras;

   public Cliente(Pessoa p,int n2,double v){
    Pessoa pessoa = new Pessoa();
    pessoa = p;
    SetComprasRealizadas(n2);
    SetValorTotalCompras(v);
    SetNome(pessoa.GetNome());
    SetCpf(pessoa.GetCpf());
    SetDataNascimento(pessoa.GetDataNascimento());
    SetTelefone(""+pessoa.GetTelefone());
    SetLogin(pessoa.GetLogin());
    SetSenha(pessoa.GetSenha());
    SetAcesso(""+pessoa.GetAcesso());
    
  }

  public Cliente(){

  }

  public void SetComprasRealizadas(int nc){

    int novaCompra = nc;

    if(novaCompra > 0){

      comprasRealizadas += novaCompra;
    }
    
  }

  public int GetComprasRealizadas(){
    return comprasRealizadas;
  }

  public double GetValorTotalCompras(){
    return valorTotalCompras;
  }

  public void SetValorTotalCompras(double vt){

    double valorTotal = vt;

    if(valorTotal >= 0){

      valorTotalCompras += valorTotal;
    }else{
       Console.WriteLine ("Valor total invalido!!!");
    }
    
  }

}