using System;
using System.Linq;
using System.IO;
using System.Text;

class Cartao:PagamentoCliente
{
  private string tipoCartao;
  private int parcelas;
  private string numCartao;

  public Cartao(int parc)
  {
    SetParcelas(parc);
  }

  public Cartao()
  {

  }

  public string GetTipoCartao()
  {
    return tipoCartao;
  }

  public string SetTipoCartao(string tipocard)
  {
    tipoCartao = tipocard;
  }

  public int GetParcelas()
  {
    return parcelas;
  }

  public bool SetParcelas(int p)
  {
    int check = p;

    if(check > 0)
    {
      parcelas = check;
      return true;
    }
    else
    {
      Console.WriteLine("Parcelas inválidas");
      return false;
    }
  }

  public string GetNumCartao()
  {
    return numCartao;
  }

  public string SetNumCartao(string numc)
  {
    numCartao = numc;
  }
}