/*1) Faça um programa que apresente um menu inicial com as seguintes opções:
MENU PRINCIPAL
1 – Funções sem vetor
2 – Funções com vetor
Digite a opção desejada: */

string op = "0", op2;
//int soma = 0;
while (op != "3")
{
    Console.Clear(); //limpar a tela
    Console.WriteLine("MENU 1");
    Console.WriteLine("1 - Funções sem vetor");
    Console.WriteLine("2 - Funções com vetor");
    Console.WriteLine("3 - Sair");
    Console.Write("Digite a opção desejada: "); //não coloco WriteLine para que o cursor não pule de linha
    op = Console.ReadLine();
    if (op == "1")
    {
        int nI, nF;
        Console.Write("Número Inicial: ");
        nI = int.Parse(Console.ReadLine());
        Console.Write("Número Final: ");
        nF = int.Parse(Console.ReadLine()); //coloco int.Parse, pois o ReadLine só lê como str
        Console.WriteLine("MENU 2");
        Console.WriteLine("1 - Crescente");
        Console.WriteLine("2 - Decrescente");
        Console.WriteLine("3 - Impares");
        Console.WriteLine("4 - Somatório");
        Console.Write("Digite a opção desejada: ");
        op2 = Console.ReadLine();
        if (op2 == "1")
        {
            crescente_recursiva(nI, nF);
        }
        else if (op2 == "2")
        {
            decrescente(nI, nF);
        }
        else if (op2 == "3")
        {
            impares(nI, nF);
        }
        else if (op2 == "4")
        {
            int soma = somatorio(nI, nF);
            Console.WriteLine("Soma = "+soma);
        }
        /*{
            soma = 0;
            Console.WriteLine(somatorio(nI, nF));

        }*/
    }
    Console.ReadKey();
}
void crescente_recursiva(int nI, int nF)
{
    if(nI <= nF)
    {
        Console.WriteLine(nI);
        crescente_recursiva(nI + 1, nF);
    }
}
void decrescente(int nI, int nF)
{
    if (nF >= nI)
    {
        Console.WriteLine(nF);
        decrescente(nI, nF - 1);
    }    
}
void impares(int nI, int nF)
{
    if (nI <= nF)
    {
        if (nI % 2 != 0)
        {
            Console.WriteLine(nI);
        }
        impares(nI + 1, nF);
    }
}
/*int somatorio(int nI, int nF)
{
    if (nI <= nF)
    {
        soma += nI;
        somatorio(nI + 1, nF);
    }
    return soma;
}*/
int somatorio(int nI, int nF)
{
    if(nI < nF)
    {
        return somatorio(nI + 1, nF) + nI;
    }
    else
    {
        return nI;
    }
}
