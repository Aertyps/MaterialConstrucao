using System;
using System.IO;
using System.Text;

class PagamentoCliente:Pedido
{

  private DateTime dataPagamento;
  private string notaFiscal;
  private double valorTotal;
  private double Desconto;
  private DateTime dataPedido;
  public PagamentoCliente()
  {

  }

public PagamentoCliente(string ano, string dia, string mes)
{
  SetDataPagamento(ano,dia,mes);
}

public DateTime GetDataPagamento()
{
  return dataPagamento;
}

public string GetNotaFiscal()
{
  return notaFiscal;
}

public void SetNotaFiscal(string nf)
{
  notaFiscal = nf;
}

public double GetValorTotal()
{
  return valorTotal;
}

public void SetValorTotal(double valor)
{
  valorTotal = valor;
}

public double GetDesconto()
{
  return Desconto;
}

public void SetDesconto(double desc)
{
  Desconto = desc;
}

public void SetDataPagamento(string ano,string dia,string mes){

      if(VerificaData(ano,4)){

        if(VerificaData(dia,2)){

            if(VerificaData(mes,2)){

                dataPedido = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
            }else{
                    Console.WriteLine ("data invalida!!!");
                  }
      
        }else{
                Console.WriteLine ("data invalida!!!");
              }
      
    }else{
            Console.WriteLine ("data invalida!!!");
          }
  }
}