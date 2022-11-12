int opcao = 0;
int incluir = 0;
tipo_no lista = null;

while (opcao != 3)
{
    Console.WriteLine("\n---------------------------MENU---------------------------\n");
    Console.WriteLine("1 - Inserir valores na lista");
    Console.WriteLine("2 - Remover valores da lista");
    Console.WriteLine("3 - Sair!");
    Console.Write("\nDigite a opção desejada: ");
    opcao = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n----------------------------------------------------------");
    if (opcao == 1)
    {
        Console.WriteLine("\n*************** Inserir valores ***************\n");
        Console.Write("Digite o valor que deseja incluir na lista: ");
        incluir = Convert.ToInt32(Console.ReadLine());
        Insere(ref lista, incluir);
    }
    
    else if (opcao == 2)
    {
        Console.WriteLine("\n*************** Remover valores ***************\n");
        if (lista != null)
        {
            tipo_no remover = Remove(ref lista);
            Console.WriteLine(remover.valor);
        }
        else
        {
            Console.WriteLine("Lista Vazia!");
        }
    }
    else if (opcao == 3)
    {
        break;
    }
}

tipo_no Remove(ref tipo_no lista)
{
    tipo_no no = null;
    if (lista != null)
    {
        no = lista;
        lista = lista.proximo;
        no.proximo = null;
    }
    return no;
}

void Insere(ref tipo_no lista, int v)
{
    tipo_no no = new tipo_no();
    no.valor = v;
    if (lista != null)
        no.proximo = lista;
    lista = no;
}
class tipo_no
{
    public int valor;
    public tipo_no proximo;
}
