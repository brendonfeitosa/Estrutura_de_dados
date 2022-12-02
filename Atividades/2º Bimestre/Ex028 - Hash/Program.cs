/*28) Implemente um programa com as seguintes opções: Sem tratamento de colisão, Tratamento de colisão Linear e Tratamento de colisão com Lista Encadeada.
Dentro de cada opção deve haver as funcionalidades: Inserir, Alterar e Relatar.
O vetor deve ser do tipo abstrato de dado composto por idade, nome e whats. Serão necessários 3 vetores, um para cada tipo de tratamento de colisão.
Para inserir um novo registro, solicite a idade, nome e whats. Utilize a idade como chave.
Para alterar solicite a idade (chave) para ser utilizada na busca. Caso encontrada, informe o nome e o whats da pessoa. Após a consulta, o usuário pode atualizar somente o nome e o whats.
Para relatar, percorra o vetor do inicio ao fim e exiba todos os registros.*/

Console.Clear();
const int V = 5;
Tipo_no[] vetor = new Tipo_no[V];
int qtd_colisoes = 0;

while(true)
{
    int op = Menu_Principal();
    if(op == 1)
    {
        Console.WriteLine("************************ INSERIR ************************\n");
        int op2 = Menu_Colisoes();
        while(op2 != 4)
        {
            if(op2 == 1)
            {
                //sem tratamento
            }
            else if(op2 == 2)
            {
                int idade = Convert.ToInt32(Console.ReadLine());
                Console.Write("Digite a idade: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o whats: ");
                int whats = Convert.ToInt32(Console.ReadLine());
                InserirLinear(vetor, idade, nome, whats, ref qtd_colisoes);
                Console.WriteLine("");
            }
            else if(op2 == 3)
            {
                //lista encadeada
            }
        }
    }
    else if(op == 2)
    {
        Console.WriteLine("************************ ALTERAR ************************\n");
        int op2 = Menu_Colisoes();
         while(op2 != 4)
        {
            if(op2 == 1)
            {
                //sem tratamento
            }
            else if(op2 == 2)
            {
                Console.Write("Digite a chave(idade) que deseja alterar: ");
                int idade_consultar = (Convert.ToInt32(Console.ReadLine()));
                int idade_alterar = ConsultarLinear(vetor, idade_consultar);
                if(idade_alterar == -1)
                {
                    Console.WriteLine("Idade não encontrada!");
                }
                else
                {
                    Console.WriteLine($"A chave digitada foi [{vetor[idade_consultar].idade}], para ela temos os seguintes dados: nome [{vetor[idade_consultar].nome}] e Whats [{vetor[idade_consultar].whats}]");
                }
                Console.WriteLine(""); //fazer a alteração, preciso de uma função especifica
            }
            else if(op2 == 3)
            {
                //lista encadeada
            }
        }       
    }
    else if(op == 3)
    {
        Console.WriteLine("************************ RELATAR COLISÕES ************************\n");
        int op2 = Menu_Colisoes();
         while(op2 != 4)
        {
            if(op2 == 1)
            {
                Console.WriteLine("Neste caso não houveram colisões");
            }
            else if(op2 == 2)
            {
                Console.WriteLine($"A quantidade de colisões para o tratamento linear de foi [{qtd_colisoes}]\n");
            }
            else if(op2 == 3)
            {
                //lista encadeada
            }
        }       
    }
    else if(op == 4)
    {
        Console.WriteLine("Saindo...");
        Thread.Sleep(500);
        Console.WriteLine("Fim do programa!");
        break;
    }
}




void InserirLinear(Tipo_no[] vetor, int idade, string nome, int whats, ref int qtd_colisoes)
{
    int posicao = Hash(idade);
    while(vetor[posicao] != null)
    {
        posicao ++;
        posicao = posicao % V;
        qtd_colisoes ++;
    }
    vetor[posicao] = new Tipo_no();
    vetor[posicao].idade = idade;
    vetor[posicao].nome = nome;
    vetor[posicao].whats = whats;
}

int ConsultarLinear(Tipo_no[]vetor, int idade)
{
    int qtd_verificar = 0;
    int posicao = Hash(idade);
    while((vetor[posicao] == null || vetor[posicao].idade != idade) && qtd_verificar < V)
    {
        posicao ++;
        posicao = posicao % V;
    }
    if(qtd_verificar < V)
    {
        return posicao;
    }
    else
    {
        return -1;
    }
}

int AlterarLinear()



int Hash(int idade)
{
    return idade % V;
}

int Menu_Principal()
{
    int opcao = 0;
    Console.WriteLine("---------------------------MENU PRINCIPAL---------------------------\n");
    Console.WriteLine("[1] Inserir");
    Console.WriteLine("[2] Alterar");
    Console.WriteLine("[3] Relatar colisões");
    Console.WriteLine("[4] Sair!");
    Console.Write("\nDigite a opção desejada: ");
    opcao = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n------------------------------------------------------------------\n");
    return opcao;
}

int Menu_Colisoes()
{
    int opcao = 0;
    Console.WriteLine("---------------------------MENU DE COLISÕES---------------------------\n");    
    Console.WriteLine("[1] Sem tratamento de colisão");
    Console.WriteLine("[2] Tratamento de colisão Linear");
    Console.WriteLine("[3] Tratamento de colisão com Lista Encadeada");
    Console.Write("\nDigite a opção desejada: ");
    opcao = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n------------------------------------------------------------------\n");
    return opcao;
}

class Tipo_no
{
    public int idade;
    public string nome;
    public int whats;
}