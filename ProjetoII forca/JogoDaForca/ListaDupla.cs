//23015 e 24459
using System;
using System.Collections.Generic;
using System.IO;

public enum Direcao { paraFrente, paraTras };

public class ListaDupla<Dado>
             where Dado : IComparable<Dado>, IRegistro
{
    NoDuplo<Dado> primeiro, ultimo, atual;   

    int quantosNos;
    bool primeiroAcessoDoPercurso;
    int numeroDoNoAtual;

    public void PosicionarNoInicio()
    {
        if (primeiro != null)
        {
            atual = primeiro;
            numeroDoNoAtual = 0;
        }
        else {
            atual = null;
        }
    }

    public void PosicionarNoFinal()
    {
        if (ultimo != null) { 
            atual = ultimo;
            numeroDoNoAtual = quantosNos;
        }
    }

    public void Avancar()
    {
        if (atual != null && atual != ultimo) {
            atual = atual.Prox;
            numeroDoNoAtual++;
        }
    }

    public void Retroceder()
    {
        if (atual != null && atual.Ant != null) {
            atual = atual.Ant;
            numeroDoNoAtual--;
        }
    }

    public void PosicionarEm(int indice)
    {
        if (indice >= 00 && indi
            ce < quantosNos) {
            atual = primeiro;
            for (int i = 0; i < indice; i++) {
                atual = atual.Prox;
            }
            numeroDoNoAtual = indice;
        }
    }

    public Dado this[int indice]
    {
        get
        {
            PosicionarEm(indice);
            return atual.Info;
        }
        set
        {
            PosicionarEm(indice);
            atual.Info = value;
        }
    }

    public List<Dado> Listagem(Direcao qualDirecao)
    {
        var dados = new List<Dado>();
        if (qualDirecao == Direcao.paraFrente)
        {
            atual = primeiro;     
            while (atual != null) 
            {
                dados.Add(atual.Info);  
                atual = atual.Prox;     
            }
        }
        else
        {
            atual = ultimo;       
            while (atual != null) 
            {
                dados.Add(atual.Info);  
                atual = atual.Ant;      
            }
        }
        return dados;
    }

    public ListaDupla()
    {
        primeiro = ultimo = atual = null;
        quantosNos = numeroDoNoAtual = 0;
        primeiroAcessoDoPercurso = false;
    }

    public bool EstaVazia
    {
        get => primeiro == null;
    }
    public NoDuplo<Dado> Primeiro
    {
        get => primeiro;
    }
    public NoDuplo<Dado> Ultimo
    {
        get => ultimo;
    }
    public int QuantosNos
    {
        get => quantosNos;
    }

    public void InserirAntesDoInicio(Dado novoDado)
    {
        var novoNo = new NoDuplo<Dado>(novoDado);

        if (EstaVazia)
            ultimo = novoNo;

        novoNo.Prox = primeiro;
        primeiro = novoNo;
        quantosNos++;
    }

    public void InserirAposFim(Dado novoDado)
    {
        var novoNo = new NoDuplo<Dado>(novoDado);

        if (EstaVazia)
            primeiro = novoNo;
        else
            ultimo.Prox = novoNo;

        ultimo = novoNo;
        quantosNos++;
    }

    public void InserirAposFim(NoDuplo<Dado> noExistente)
    {
        if (noExistente != null)
        {
            if (EstaVazia)
                primeiro = noExistente;
            else
                ultimo.Prox = noExistente;

            ultimo = noExistente;
            noExistente.Prox = null;
            quantosNos++;
        }
    }

    public bool Existe(Dado outroProcurado)
    {
        //anterior = null;
        atual = primeiro;

        if (EstaVazia)
            return false;

        if (outroProcurado.CompareTo(primeiro.Info) < 0)
            return false;

        if (outroProcurado.CompareTo(ultimo.Info) > 0)
        {
            // anterior = ultimo;
            atual = null;
            return false;
        }

        bool achou = false;
        bool fim = false;

        while (!achou && !fim)
            if (atual == null)
                fim = true;
            else
              if (outroProcurado.CompareTo(atual.Info) == 0)
                achou = true;
            else
                if (atual.Info.CompareTo(outroProcurado) > 0)
                fim = true;
            else
            {
                //anterior = atual;
                atual = atual.Prox;
            }
        return achou;
    }

    public NoDuplo<Dado> Atual => atual;

    public int NumeroDoNoAtual { get => numeroDoNoAtual; set => numeroDoNoAtual = value; }

    public bool InserirEmOrdem(Dado dados)
    {
        if (Existe(dados))
            return false;

        
        if (EstaVazia)                  	
            InserirAntesDoInicio(dados); 
        else
            if (/*anterior == null && */ atual != null)
            InserirAntesDoInicio(dados);
        else
              if (/*anterior != null && */ atual == null)
            InserirAposFim(dados);
        else
            InserirNoMeio(dados);

        return true; 
    }

    private void InserirNoMeio(Dado dados)
    {

        var novo = new NoDuplo<Dado>(dados);
        anterior.Prox = novo;   
        novo.Prox = atual;      

        if (anterior == ultimo)  
            ultimo = novo;        
        quantosNos++;            	
    }

    public bool Remover(Dado dadoARemover)
    {
        if (EstaVazia)
            return false;

        if (!Existe(dadoARemover))
            return false;

        if (atual == primeiro)
        {
            primeiro = primeiro.Prox;
            if (primeiro == null)  
                ultimo = null;
        }
        else
          if (atual == ultimo)
        {
            anterior.Prox = null;  
            ultimo = anterior;
        }
        else
        {
            anterior.Prox = atual.Prox;
        }

        quantosNos--;
        return true;
    }

    public void GravarDados(string nomeArq)
    {
        var arquivo = new StreamWriter(nomeArq);
        atual = primeiro;
        while (atual != null)
        {
            arquivo.WriteLine(atual.Info.FormatoDeArquivo());
            atual = atual.Prox;
        }
        arquivo.Close();
    }

}
