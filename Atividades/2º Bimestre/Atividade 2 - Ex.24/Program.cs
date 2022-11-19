/*24) Desenvolva um programa para inserir, pesquisar, remover e exibir os valores de uma árvore binária. Observe as opções a seguir:
a) Inserir um valor digitado pelo usuário
b) Pesquisar um valor digitado pelo usuário. Exiba uma mensagem informando se encontrou ou não
c) Remover um valor digitado pelo usuário. Exiba a mensagem se removido com sucesso ou não encontrado
d) Exibir todos os valores da árvore em ordem, pré ordem ou pós ordem*/

void Insere(ref tp_no raiz, int valor)
{
   if (raiz == null)
   {
      raiz = new tp_no();
      raiz.valor = valor;
   }
   else if (valor < raiz.valor)
      Insere(ref raiz.esq, valor);
   else
      Insere(ref raiz.dir, valor);
}

tp_no Busca(tp_no raiz, int valor)
{
   if (raiz == null)
      return null;
   else if (valor == raiz.valor)
      return raiz;
   else if (valor < raiz.valor)
      return Busca(raiz.esq, valor);
   else
      return Busca(raiz.dir, valor);
}

tp_no RetornaMaior(ref tp_no raiz)
{
   if (raiz.dir == null)
   {
      tp_no p = raiz;
      raiz = raiz.esq;
      return p;
   }
   else
      return RetornaMaior(ref raiz.dir);
}

tp_no Remove(ref tp_no raiz, int x)
{
   if (raiz == null)
      return null;     
   else if (x == raiz.valor)
   {       
      tp_no p = raiz;
      if (raiz.esq == null)        // nao tem filho esquerdo
         raiz = raiz.dir;
      else if (raiz.dir == null)  // nao tem filho direito
         raiz = raiz.esq;
      else                          // tem ambos os filhos
      {
         p = RetornaMaior(ref raiz.esq);
         raiz.valor = p.valor;
      }
      return p;
   }
   else if (x < raiz.valor)
      return Remove(ref raiz.esq, x);
   else
      return Remove(ref raiz.dir, x);
}

void EmOrdem(tp_no r)
{
   if (r != null)
   {
      EmOrdem(r.esq);
      Console.WriteLine(r.valor);
      EmOrdem(r.dir);
   }
}

void PreOrdem(tp_no r)
{
   if (r != null)
   {
      Console.WriteLine(r.valor);
      PreOrdem(r.esq);
      PreOrdem(r.dir);
   }
}

void PosOrdem(tp_no r)
{
   if (r != null)
   {
      PosOrdem(r.esq);
      PosOrdem(r.dir);
      Console.WriteLine(r.valor);
   }
}
int Menu()
{
    int opcao = 0;
    Console.WriteLine("---------------------------MENU PRINCIPAL---------------------------\n");
    Console.WriteLine("[1] Inserir um valor digitado pelo usuário!");
    Console.WriteLine("[2] Pesquisar um valor digitado pelo usuário!");
    Console.WriteLine("[3] Remover um valor digitado pelo usuário!");
    Console.WriteLine("[4] Exibir todos os valores da árvore em ordem, pré ordem ou pós ordem!");
    Console.WriteLine("[5] Sair!");
    Console.Write("\nDigite a opção desejada: ");
    opcao = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n------------------------------------------------------------------\n");
    return opcao;
}
tp_no raiz = null;

class tp_no
{
   public tp_no esq;
   public int valor;
   public tp_no dir;
}




