/*24) Desenvolva um programa para inserir, pesquisar, remover e exibir os valores de uma árvore binária. Observe as opções a seguir:
a) Inserir um valor digitado pelo usuário
b) Pesquisar um valor digitado pelo usuário. Exiba uma mensagem informando se encontrou ou não
c) Remover um valor digitado pelo usuário. Exiba a mensagem se removido com sucesso ou não encontrado
d) Exibir todos os valores da árvore em ordem, pré ordem ou pós ordem*/

tp_no raiz = null;
Console.Clear();
while(true)
{
   int op = Menu();
   if(op == 1)
   {
      Console.WriteLine("************************ INSERINDO ************************");
      Console.Write("\nDigite um valor para ser incluído na árvore: ");
      int valor = Convert.ToInt32(Console.ReadLine());
      Insere(ref raiz, valor);
      Console.WriteLine("\nValor inserido!\n");
   }

   else if(op == 2)
   {
      Console.WriteLine("************************ PESQUISAR ************************");
      Console.Write("\nDigite o valor que deseja encontrar: ");
      int valor_pesq = int.Parse(Console.ReadLine());
      Busca(raiz, valor_pesq);
      if(valor_pesq == raiz.valor || valor_pesq == raiz.esq.valor || valor_pesq == raiz.dir.valor)
      {
         Console.WriteLine("\nValor encontrado!\n");
      }
      else
      {
         Console.WriteLine("\nValor não encontrado\n"); //quando não encontro o valor o programa quebra
      }
   }
   else if(op == 3)
   {
      Console.WriteLine("************************ REMOVER ************************");
      Console.Write("\nDigite o valor que deseja remover: ");
      int valor_remov = int.Parse(Console.ReadLine());
      Busca(raiz, valor_remov);
      if(valor_remov == raiz.valor || valor_remov == raiz.esq.valor || valor_remov == raiz.dir.valor)
      {
         Console.WriteLine("\nValor encontrado!");
         Remove(ref raiz, valor_remov);
         Thread.Sleep(1500);
         Console.WriteLine("\nO valor informado foi removido com sucesso!\n");
      }
      else
      {
         Console.WriteLine("\nValor não encontrado");
      }
   }
   else if(op == 4)
   {
      Console.WriteLine("************************ EXIBIR ************************");
      Console.WriteLine("\nComo deseja exibir os dados?\n");
      Console.WriteLine("[1] Em ordem");
      Console.WriteLine("[2] Pré ordem");
      Console.WriteLine("[3] Pós ordem");
      Console.WriteLine("[4] Digite 4 para sair");
      Console.Write("\nDigite a opção desejada: ");
      int op_exibicao = Convert.ToInt32(Console.ReadLine());
      if(raiz != null)
         if(op_exibicao == 1)
         {
            Console.WriteLine("\n************************ EXIBIR EM ORDEM ************************\n");
            EmOrdem(raiz);
            Console.WriteLine("");
            Console.WriteLine("");
         }
         else if(op_exibicao == 2)
         {
            Console.WriteLine("\n********************** EXIBIR EM PRÉ ORDEM **********************\n");
            PreOrdem(raiz);
            Console.WriteLine("");
            Console.WriteLine("");
         }
         else if(op_exibicao == 3)
         {
            Console.WriteLine("\n********************** EXIBIR EM PÓS ORDEM **********************\n");
            PosOrdem(raiz);
            Console.WriteLine("");
            Console.WriteLine("");
         }  
         else if(op_exibicao == 4)
         {
            Console.WriteLine("\nSaindo do modo de exibição\n");
         }       
      else
      {
         Console.WriteLine("\nA raiz esta vazia, náo ha nada a exibir\n");
      }   
   }
   else if(op == 5)
   {
      Console.WriteLine("Saindo...");
      Thread.Sleep(500);
      Console.WriteLine("Fim do programa!");
      break;
   }
}

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

tp_no Remove(ref tp_no raiz, int valor_remov)
{
   if (raiz == null)
      return null;     
   else if (valor_remov == raiz.valor)
   {       
      tp_no ponteiro = raiz;
      if (raiz.esq == null)        // nao tem filho esquerdo
         raiz = raiz.dir;
      else if (raiz.dir == null)  // nao tem filho direito
         raiz = raiz.esq;
      else                          // tem ambos os filhos
      {
         ponteiro = RetornaMaior(ref raiz.esq);
         raiz.valor = ponteiro.valor;
      }
      return ponteiro;
   }
   else if (valor_remov < raiz.valor)
      return Remove(ref raiz.esq, valor_remov);
   else
      return Remove(ref raiz.dir, valor_remov);
}

void EmOrdem(tp_no raiz)
{
   if (raiz != null)
   {
      EmOrdem(raiz.esq);
      Console.Write(raiz.valor+" ");
      EmOrdem(raiz.dir);
   }
}

void PreOrdem(tp_no raiz)
{
   if (raiz != null)
   {
      Console.Write(raiz.valor+" ");
      PreOrdem(raiz.esq);
      PreOrdem(raiz.dir);
   }
}

void PosOrdem(tp_no raiz)
{
   if (raiz != null)
   {
      PosOrdem(raiz.esq);
      PosOrdem(raiz.dir);
      Console.WriteLine(raiz.valor+" ");
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

class tp_no
{
   public tp_no esq;
   public int valor;
   public tp_no dir;
}