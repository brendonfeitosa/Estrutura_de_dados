/* Atividade 1 - 1ºB - Recursividade
Crie um novo projeto para desenvolver um programa com um menu, cada opção do menu deve ser um exercício do 2 ao 6. Cada opção deve após receber entrada de dados, chamar uma função recursiva e exibir o resultado. O programa deve ser implementado em C# console.*/
string op = "0";
while (op != "6")
{
    Console.Clear(); //limpar tela
    Console.WriteLine("-------------- MENU --------------");
    Console.WriteLine();
    Console.WriteLine("1 - Ex.02 Potência");
    Console.WriteLine("2 - Ex.03 Cubos");
    Console.WriteLine("3 - Ex.04 Máximo Divisor Comum");
    Console.WriteLine("4 - Ex.05 Sequencia Fibonacci");
    Console.WriteLine("5 - Ex.06 Converter em binário");
    Console.WriteLine();
    Console.Write("Digite a opção desejada: ");
    op = Console.ReadLine();
    if (op == "1")
    {
        int b, e, resu = 0;
        Console.Write("Digite o número da base: ");
        b = int.Parse(Console.ReadLine());
        Console.Write("Digite o expoente: ");
        e = int.Parse(Console.ReadLine());
        resu = potencia(b, e);
        Console.Write("A potencia de ");
        Console.Write("["+b+"]");
        Console.Write(" elevado a ");
        Console.Write("["+ e+"]");
        Console.Write(" é: ");
        Console.WriteLine("["+resu+"]");
    }
    else if (op == "2")
    {
        int num = 0;
        Console.Write("Digite um número inteiro: ");
        num = int.Parse(Console.ReadLine());
        cubos(num);
    }
    else if (op == "3")
    {
        int x = 0,y = 0;
        Console.Write("Digite um número inteiro: ");
        x = int.Parse(Console.ReadLine());
        Console.Write("Digite outro número inteiro: ");
        y = int.Parse(Console.ReadLine());
        Console.WriteLine(mdc(x,y));
    }
    else if (op == "4")
    {
        int num;
        Console.Write("Digite um múmero inteiro para encontrar a série Fibonacci dele: ");
        num = int.Parse(Console.ReadLine());
        Console.WriteLine(fib_recursiva(num));
        Console.WriteLine($"Calculando Fibonacci iterativamente {num} vezes: ");
        fibonacciIterativa(num);
    }
    else if (op == "5")
    {
        int x, bin;
        Console.Write("informe o numero inteiro para conversão: ");
        x = int.Parse(Console.ReadLine());
        bin = int.Parse(conversorbin(x));
        Console.WriteLine($"O número: {x} em binário é: {bin}");
    }
    else if (op == "6")
    {
        break;
    }

    Console.ReadKey();
}
int potencia(int bas, int expoente)
{
    if (expoente == 0)
    {
        return 1;
    }
    else
    {
        return bas * potencia(bas, expoente - 1);
    }

}
void cubos(int n, int i = 1)
{
    if (n >= i)
    {
        Console.WriteLine(n * n * n);
        cubos(n - 1);
    }
}

int mdc(int x, int y)
{
    if (x == y)
    {
        return x;
    }
    else if (x > y)
    {
        return mdc(x - y, y);
    }
    else
    {
        return mdc(x, y - x);
    }
}
int fib_recursiva(int numero)
{
    if (numero == 0 || numero == 1)
    {
        return numero;
    }
    else if (numero == 2)
    {
        return 1;
    }
    else
    {
        return fib_recursiva(numero - 1) + fib_recursiva(numero - 2);
    }
}
void fibonacciIterativa(int x)
{
    int n1 = 0, n2 = 1, temporaria;
	for (int i = 0; i​​​​​​​ < x; i++)
	{
	temporaria = n1;
		n1 = n2;
		n2 = n1 + temporaria;
        Console.WriteLine(n2);
	}
}
string conversorbin(int n)
{
    if (n >= 1)
    {
        if (n % 2 == 1)
        {
            return "" + conversorbin((n - 1) / 2) + "1";
        }
        else
        {
            n = n / 2;
            return "" + conversorbin(n) + "0";
        }
    }
    return "0";
}