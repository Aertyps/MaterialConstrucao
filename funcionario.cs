using System;
using System.Linq;
using System.IO;
using System.Text;

class Funcionario:Pessoa{
  protected string departamento;
  protected DateTime dataAdmissao;
  private DateTime horarioEntrada;
  private DateTime horarioSaida;
  private int nivel;

  public Funcionario(Pessoa p,string dp,string a2,string d2,string m2, string h1,string s1, string h2,string s2){
    Pessoa pessoa = new Pessoa();
    pessoa = p;
    SetNome(pessoa.GetNome());
    SetDepartamento(dp);
    SetDataAdmissao(a2,d2,m2);
    SetHorarioEntrada(h1,s1);
    SetHorarioSaida(h2,s2);
  }

  public Funcionario(Pessoa p){
    Pessoa pessoa = new Pessoa();
    pessoa = p;
    SetNome(pessoa.GetNome());
    SetCpf(pessoa.GetCpf());
    SetDataNascimento(pessoa.GetDataNascimento());
    SetTelefone(""+pessoa.GetTelefone());
    SetLogin(pessoa.GetLogin());
    SetSenha(pessoa.GetSenha());
    SetAcesso(""+pessoa.GetAcesso());
    SetNivel("0");
  }

  public Funcionario(){

  }

  public int GetNivel(){
   return nivel;
 }

 public void SetNivel(string a){//nivel de acesso
   string valor = a;
   if(valor.All(char.IsDigit)){//se é numero
     nivel = Convert.ToInt32(valor);
    }else{
       Console.WriteLine (" nivel invalido!!!");
    }
 
  }

  public void SetDepartamento(string d){

    string entrada = d;

    if(entrada.Length > 4)//maior que 4 digitos
    {
      departamento = d;
    }else{
      Console.WriteLine ("departamento invalido!!!");
    }
  }

  public string SetDepartamento(){

    return departamento;
  }

  public void SetDataAdmissao(string ano,string dia,string mes){

      if(VerificaData(ano,4)){

        if(VerificaData(dia,2)){

            if(VerificaData(mes,2)){

                dataAdmissao = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
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
  public DateTime GetDataAdmissao(){
    return dataAdmissao;
  }

  public void SetHorarioEntrada(string h,string m){

    string hora = h;
    string minutos = m;
    DateTime data = DateTime.Now;

    if(VerificaData(hora,2)){//dois digitos hora

      if(VerificaData(minutos,2)){//dois digitos minuto

       horarioEntrada = new DateTime(data.Year, data.Day,data.Month, Convert.ToInt32(hora), Convert.ToInt32(minutos), 0);

      }else{

           Console.WriteLine ("minutos invalidos!!!");

      }

    }else{
       Console.WriteLine ("hora invalida!!!");
    }
    
  }

  public DateTime GetHorarioEntrada(){
    return horarioEntrada;
  }

  public void SetHorarioSaida(string h,string m){

    string hora = h;
    string minutos = m;
    DateTime data = DateTime.Now;

    if(VerificaData(hora,2)){//dois digitos hora

      if(VerificaData(minutos,2)){//dois digitos minuto

       horarioSaida = new DateTime(data.Year, data.Day,data.Month, Convert.ToInt32(hora), Convert.ToInt32(minutos), 0);

      }else{

           Console.WriteLine ("minutos invalidos!!!");

      }

    }else{
       Console.WriteLine ("hora invalida!!!");
    }

  }

  public DateTime GetHorarioSaida(){
    return horarioSaida;
  }

  public int GetTempodeCasa(){
 
    return CalcularIdade(dataAdmissao);
  }

}