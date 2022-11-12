/*15) Escreva um programa que simule o controle de uma pista de decolagem de aviões em um aeroporto. Os aviões são identificados pelos números digitados pelo usuário. Neste programa, o usuário deve ser capaz de realizar as seguintes operações:
a) Adicionar vários aviões à fila de espera para decolagem
b) Consultar a quantidade de aviões aguardando na fila
c) Autorizar a decolagem de um avião da fila
d) Listar os números de todos os aviões na fila
e) Consultar o número do primeiro avião da fila
Construa um menu principal para oferecer essas operações ao usuário.*/

const int MAX = 20;
int[] fila = new int[MAX];
int inicio = 0, fim = 0;
int op = 1, incluir;

while(true)
{
    Console.WriteLine("\n---------------------------MENU---------------------------\n");
    Console.WriteLine("1 - Adicionar vários aviões à fila de espera para decolagem");
    Console.WriteLine("2 - Consultar a quantidade de aviões aguardando na fila");
    Console.WriteLine("3 - Autorizar a decolagem de um avião da fila");
    Console.WriteLine("4 - Listar os números de todos os aviões na fila");
    Console.WriteLine("5 - Consultar o número do primeiro avião da fila");
    Console.WriteLine("6 - Sair");
    Console.Write("\nDigite a opção desejada: ");
    op = Convert.ToInt32(Console.ReadLine());
    if(op == 1)
    {
        Console.Write("\nDigite o número do avião que deseja incluir: ");
        incluir = Convert.ToInt32(Console.ReadLine());
        Insere(fila, ref fim, incluir);
        Console.WriteLine();
        Console.WriteLine($"Avião nº {incluir} incluído a fila de decolagem");
    }
    else if(op == 2)
    {
        Console.WriteLine();
        Console.WriteLine($"Existe(m) {consultarqtd(inicio, fim)} avião(ões) aguardando na fila de decolagem!");
    }
    else if(op == 3)
    {
        Console.WriteLine();
        Console.WriteLine($"Avião nº {Remove(fila, ref inicio)} autorizado para decolagem!");
    }
    else if(op == 4)
    {
        lista(fila, inicio, fim);
    }
    else if(op == 5)
    {
        primeiro(fila, inicio);
    }
    else if(op == 6)
    {
        break;
    }
    else
        Console.WriteLine("Digite uma opção válida......");
}

int consultarqtd(int inicio, int fim)
{
    int qtde = 0;
    for(int i = inicio; i < fim; i++)
    {
        qtde += 1;
    }
    return qtde;
}

void lista(int[] fila, int inicio, int fim)
{
    Console.WriteLine("Os seguintes aviões estão na fila: ");
    Console.WriteLine();
    for(int i = inicio; i < fim; i++)
    {
        Console.WriteLine($"Avião nº {fila[i]}");
    }
}
void primeiro(int[] fila, int inicio)
{
    Console.WriteLine();
    Console.WriteLine($"O número do primeiro avião da fila é: {fila[inicio]}");
}

void Insere(int[] fila, ref int fim, int valor)
{
    fila[fim] = valor;
    fim++;
}

int Remove(int[] fila, ref int inicio)
{
    int valor = fila[inicio];
    inicio++;
    return (valor);
}