Console.Clear();
const int MAX = 20;
void Insere(int[] p, ref int t, int v)
{
    p[t] = v;
    t = t + 1;
}

int Remove(int[] p, ref int t)
{
    t = t - 1;
    return (p[t]);
}
bool EstaVazia(int t) //serve para verificar se o vetor esta vazio
{
    if (t == 0)
        return true;
    else
        return false;
}

bool EstaCheia(int t) //serve para verificar se o vetor esta cheio
{
    if (t == MAX)
        return true;
    else
        return false;
}

int[] pilha = new int[MAX];
int topo = 0;

Console.Write("Digite um número inteiro: ");
int num = int.Parse(Console.ReadLine());

while(num != 0)
{
    Insere(pilha, ref topo, num%2); //pilha é um vetor, topo é passado por referencia, num%2 é o numero que o usuário vai digitar
    num = num / 2;
}
int resto;
//while(!EstaVazia(topo))
while(EstaVazia(topo) == false) //enquanto a função estavazia não estiver vazia ele vai exibir o resultado na tela
{
    resto = Remove(pilha, ref topo);
    Console.Write(resto);
}
