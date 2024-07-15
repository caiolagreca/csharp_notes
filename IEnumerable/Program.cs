using System;
using System.Collections;


/* OLHAR EXEMPLO NO README USANDO ITERATOR YIELD (MUITO MAIS SIMPLIFCADO) */

namespace IEnumerables
{

    public class MyCollection : IEnumerable
    {
        private string[] itens = { "Item1", "Item2", "Item3" };

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(itens);
        }

        private class MyEnumerator : IEnumerator
        {
            private string[] _itens;
            private int _posicao = -1;

            public MyEnumerator(string[] itens)
            {
                _itens = itens;
            }

            public bool MoveNext()
            {
                _posicao++;
                return (_posicao < _itens.Length);
            }

            public void Reset()
            {
                _posicao = -1;
            }

            public object Current
            {
                get
                {
                    if (_posicao < 0 || _posicao >= _itens.Length) throw new InvalidOperationException();
                    return _itens[_posicao];
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyCollection colecao = new MyCollection();

            foreach (var item in colecao)
            {
                Console.WriteLine(item);
            }
            /* 
            Passo a Passo do foreach:
                O método GetEnumerator de MyCollection é chamado, retornando um MyEnumerator.
                foreach chama MoveNext repetidamente para avançar no enumerador.
                foreach acessa a propriedade Current para obter o item atual.
                Quando MoveNext retorna false, a iteração termina.
             */

            Console.ReadKey();
        }
    }
}
