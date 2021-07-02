using System;
using simple_crud_console_app.Enums;

namespace simple_crud_console_app.Classes
{
  public class Serie : BaseEntity
  {
    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Descricao { get; set; }
    private int Ano { get; set; }
    private bool Excluido { get; set; }

    public Serie(int id, Genero genero, string titulo, string descricao, int ano)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
      this.Excluido = false;
    }

    public override string ToString()
    {
      string serie = "";
      serie += "Gênero: " + this.Genero + Environment.NewLine;
      serie += "Título: " + this.Titulo + Environment.NewLine;
      serie += "Descrição: " + this.Descricao + Environment.NewLine;
      serie += "Ano de Início: " + this.Ano + Environment.NewLine;
      serie += "Excluído: " + this.Excluido + Environment.NewLine;
      return serie;
    }

    public string GetTitulo()
    {
      return this.Titulo;
    }

    public int GetId()
    {
      return this.Id;
    }

    public void SetDelete()
    {
      this.Excluido = true;
    }

    public bool GetDelete()
    {
      return this.Excluido;
    }
  }
}