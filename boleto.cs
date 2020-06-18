using System;
using System.IO;
using System.Text;

class Boleto:PagamentoCliente
{
  private string codigo;

  public Boleto()
  {

  }

  public string GetCodigo()
  {
    return codigo;
  }

  public string SetCodigo(string cod)
  {
    codigo = cod;
    return codigo;
  }
}