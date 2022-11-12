Console.Clear();
const int MAX = 20;
char[] pilha = new char[MAX];
int topo = 0;
int i = 0;
Console.Write("Digite uma frase: ");
string frase = Console.ReadLine();
while(i < frase.Length) //vai até o final da frase
{
    while(i <  frase.Length && frase[i] != ' ') 
    {
        Insere(pilha, ref topo, frase[i]);
        i += 1;
    }

    while(EstaVazia(topo) == false)
    {
        char c = Remove(pilha, ref topo);
        Console.Write(c);
    }
    i++;
    Console.Write(' ');
}

void Insere(char[] p, ref int t, char v)
{
    p[t] = v;
    t += 1;
}

char Remove(char[] p, ref int t)
{
    t -= 1;
    return(p[t]);
}

bool EstaVazia(int t)
{
    if(t == 0)
        return true;
    
    else
        return false;
}

/*bool EstaCheia(int t)
{
    if (t == MAX)
        return true;
    
    else
        return false;
}*/
