/*27) Implemente um programa que conte a quantidade de colisões ocorridas durante o processo de inserção. Utilize o tratamento de colisão linear. O vetor deve ser de um tipo abstrato de dado composto por nota, nome e email. A nota deve ser um número inteiro e corresponderá a chave.
O menu deve conter as seguintes opções: Inserir, Recuperar e Informar. Na opção recuperar, solicite a nota e caso encontre-a no vetor, exiba o nome e o email correspondente, caso contrário, exiba a mensagem de nota não encontrada. A opção informar, informa a quantidade de colisões ocorridas até o momento.*/

Console.Clear();
const int N = 5;
tipo_no[] vetor = new tipo_no[N];
int qtd_colisoes = 0;
while(true)
{
    int op = Menu();
    if(op == 1)
    {
        Console.WriteLine("************************ INSERINDO ************************");
        Console.Write("\nDigite a nota: ");
        int nota = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o e-mail: ");
        string email = Console.ReadLine();
        InsereLinear(vetor, nota, nome, email, ref qtd_colisoes);
        Console.WriteLine("");
    }
    else if(op == 2)
    {
        Console.WriteLine("************************ RECUPERAR ************************");
        Console.Write("\nDigite a nota que quer consultar: ");
        int nota = Convert.ToInt32(Console.ReadLine());
        int posicao = RecuperarLinear(vetor, nota);
        if(posicao == -1)
        {
            Console.WriteLine("\nNota não encontrada!");
        }
        else
        {
            Console.WriteLine($"\nPara nota [{vetor[nota].nota}], encontramos o nome [{vetor[nota].nome}] e o e-mail [{vetor[nota].email}]\n");
        }
    }
    else if(op == 3)
    {
        Console.WriteLine($"A quantidade de colisões foi [{qtd_colisoes}]\n");
    }
    else if(op == 4)
    {
      Console.WriteLine("Saindo...");
      Thread.Sleep(500);
      Console.WriteLine("Fim do programa!");
      break;
    }
}

void InsereLinear(tipo_no[] vetor, int nota, string nome, string email, ref int qtd_colisoes)
{
    int posicao = Hash(nota);
    while(vetor[posicao] != null)
    {
        posicao ++;
        posicao = posicao % N;
        qtd_colisoes += 1;
    }
    vetor[posicao] = new tipo_no();
    vetor[posicao].nota = nota;
    vetor[posicao].nome = nome;
    vetor[posicao].email = email;
}

int Hash(int nota)
{
    return nota % N;
}

int RecuperarLinear(tipo_no[] vetor, int nota)
{
    int qtd_verificar = 0;
    int posicao = Hash(nota);
    while((vetor[posicao] == null || vetor[posicao].nota != nota) && qtd_verificar < N)
    {
        posicao ++;
        posicao = posicao % N;
    }
    if(qtd_verificar < N)
    {
        return posicao;
    }
    else
    {
        return -1;
    }
}

int Menu()
{
    int opcao = 0;
    Console.WriteLine("---------------------------MENU PRINCIPAL---------------------------\n");
    Console.WriteLine("[1] Inserir");
    Console.WriteLine("[2] Exibir resultados");
    Console.WriteLine("[3] Quantidade de colisões");
    Console.WriteLine("[4] Sair!");
    Console.Write("\nDigite a opção desejada: ");
    opcao = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n------------------------------------------------------------------\n");
    return opcao;
}

class tipo_no
{
    public int nota;
    public string nome;
    public string email;
}
