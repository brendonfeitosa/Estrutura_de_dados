/*28) Implemente um programa com as seguintes opções: Sem tratamento de colisão, Tratamento de colisão Linear e Tratamento de colisão com Lista Encadeada.
Dentro de cada opção deve haver as funcionalidades: Inserir, Alterar e Relatar.
O vetor deve ser do tipo abstrato de dado composto por idade, nome e whats. Serão necessários 3 vetores, um para cada tipo de tratamento de colisão.
Para inserir um novo registro, solicite a idade, nome e whats. Utilize a idade como chave.
Para alterar solicite a idade (chave) para ser utilizada na busca. Caso encontrada, informe o nome e o whats da pessoa. Após a consulta, o usuário pode atualizar somente o nome e o whats.
Para relatar, percorra o vetor do inicio ao fim e exiba todos os registros.*/

Console.Clear();
const int VL = 5;
Tipo_no[] vetor_linear = new Tipo_no[VL];
int qtd_colisoes = 0;

while(true)
{
    int op = Menu_Principal();
    if(op == 1)
    {
        Console.WriteLine("************************ INSERIR ************************\n");
        int op2 = Menu_Tratamento();
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
                InserirLinear(vetor_linear, idade, nome, whats, ref qtd_colisoes);
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
        int op2 = Menu_Tratamento();
         while(op2 != 4)
        {
            if(op2 == 1)
            {
                //sem tratamento
            }
            else if(op2 == 2)
            {
                Console.Write("Digite a chave(idade) que deseja alterar: ");
                int idade_alterar = (Convert.ToInt32(Console.ReadLine()));
                AlterarLinear(vetor_linear, ref idade_alterar);
                Console.WriteLine(""); 
            }
            else if(op2 == 3)
            {
                //lista encadeada
            }
        }       
    }
    else if(op == 3)
    {
        Console.WriteLine("************************ RELATAR ************************\n");
        int op2 = Menu_Tratamento();
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
        posicao = posicao % VL;
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
    while((vetor[posicao] == null || vetor[posicao].idade != idade) && qtd_verificar < VL)
    {
        posicao ++;
        posicao = posicao % VL;
    }
    if(qtd_verificar < VL)
    {
        return posicao;
    }
    else
    {
        return -1;
    }
}

void AlterarLinear(Tipo_no[] vetor, ref int idade)
{
    int posicao = ConsultarLinear(vetor, idade);
    if(posicao != -1)
    {
        Console.WriteLine("Dados atuais: ");
        Console.WriteLine($"A chave digitada foi [{vetor_linear[posicao].idade}], para ela temos os seguintes dados: nome [{vetor_linear[posicao].nome}] e Whats [{vetor_linear[posicao].whats}]");
        Console.Write("Deseja alterar algum dado? Digite [1] Sim ou [2] Não ");
        int op3 = int.Parse(Console.ReadLine());
        if(op3 == 1)
        {
            Console.Write("Digite o novo nome: ");
            vetor[posicao].nome = Console.ReadLine();
            Console.Write("Digite o novo Whats: ");
            vetor[posicao].whats = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nDados alterados:");
            Console.WriteLine($"A chave digitada foi [{vetor_linear[posicao].idade}], e seus novos dados são: nome [{vetor_linear[posicao].nome}], Whats [{vetor_linear[posicao].whats}]");
        }
    }
    else
    {
        Console.WriteLine("Idade não encontrada!");
    }
}


int Hash(int idade)
{
    return idade % VL;
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

int Menu_Tratamento()
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