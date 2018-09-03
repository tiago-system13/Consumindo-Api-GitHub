using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste_desenvolvimento_2
{
    public class Program
    {
        public double mediaNumeros(int[] lista, int tamanho, double soma)
        {
            if (tamanho >=0)
            {
                soma = soma + lista[tamanho];
                return mediaNumeros(lista, tamanho - 1, soma);
            }

              return soma / lista.Length;

        }

        public int[] inverter(int[] lista,int tamanho, int posicao)
        {
            if (posicao < tamanho / 2)
            {
                int tmp = lista[posicao];
                int nova_posicao = tamanho - posicao - 1;
                lista[posicao] = lista[nova_posicao];
                lista[nova_posicao] = tmp;
             return  inverter(lista,tamanho,posicao + 1);
            }

            return lista;
        }

       public static void Main(string[] args)
        {
            int[] lista = { 5, 7, 8, 10, 6 };            

            var programa = new Program();

            var media = programa.mediaNumeros(lista, lista.Length-1, 0);
            Console.WriteLine("Média dos número:" + media);

            foreach (var item in lista.Where(x=>x > media)) Console.WriteLine("O número: " + item + " foi um dos elementos da lista maior que média");
            
            foreach (var item in lista) Console.WriteLine("Elementos da lista original: " + item);
            
            foreach (var item in programa.inverter(lista, lista.Length, 0)) Console.WriteLine("Elementos da lista invertidos: " + item);
            Console.ReadLine();
        }
    }
}
