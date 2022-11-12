/*13) Escreva um programa que tenha uma fila cujo valores indicam prioridade, quanto maior o valor, maior a prioridade.
Seu programa deve inserir vários valores numa fila e solicitar um valor divisor. Em seguida, o programa deve dividir a fila inicial em duas novas filas, uma fila com valores menores que o divisor (menor prioridade) e outra fila com os valores maiores que o divisor (maior prioridade).
Por fim, informe os valores das duas novas filas.*/


const int MAX = 20;
int[] fila = new int[MAX];
int inicio = 0, fim = 0;
int[] filaMA = new int[MAX]; //fila dos numeros maiores
int iMA = 0, fimMA = 0;
int[] filaME = new int[MAX]; //fila dos numeros menores
int iME = 0, fimME = 0;
int V, VD; //v = quantidade de valores, vd = valor que vai dividir
V = 1;
while(V != 0)
{
    Console.Write("Digite um valor: ");
    V = Convert.ToInt32(Console.ReadLine());
    if(EstaCheia(fim) == false) // fim porque é o número que que vai me dizer se ainda posso inserir na fila
    {
        Insere(fila, ref fim, V);
    }
    else
    {
        Console.WriteLine("Fila Cheia");
        V = 0;
    }
}

Console.Write("\nDigite o valor para ser o divisor: ");
VD = Convert.ToInt32(Console.ReadLine());

while(!EstaVazia(inicio, fim))
{
    V = Remove(fila, ref inicio);
    if(V >= VD)
    {
        Insere(filaMA, ref fimMA, V);
    }
    else
    {
        Insere(filaME, ref fimME, V);
    }
}

Console.WriteLine("Fila com números menores que "+VD);
while(!EstaVazia(iMA, fimMA))
{
    Console.WriteLine(Remove(filaMA, ref iMA));
}

Console.WriteLine("Fila com números menores que "+VD);
while(!EstaVazia(iME, fimME))
{
    Console.WriteLine(Remove(filaME, ref iME));
}

void Insere(int[] q, ref int f, int v)
{
    q[f] = v;
    f = f + 1;
}

int Remove(int[] q, ref int i)
{
    int v = q[i];
    i = i + 1;
    return (v);
}

bool EstaVazia(int i, int f)
{
    if (i == f)
        return true;
    else
        return false;
}

bool EstaCheia(int f)
{
    if (f == MAX)
        return true;
    else
        return false;
}