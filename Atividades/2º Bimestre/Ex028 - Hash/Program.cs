/*28) Implemente um programa com as seguintes opções: Sem tratamento de colisão, Tratamento de colisão Linear e Tratamento de colisão com Lista Encadeada.
Dentro de cada opção deve haver as funcionalidades: Inserir, Alterar e Relatar.
O vetor deve ser do tipo abstrato de dado composto por idade, nome e whats. Serão necessários 3 vetores, um para cada tipo de tratamento de colisão.
Para inserir um novo registro, solicite a idade, nome e whats. Utilize a idade como chave.
Para alterar solicite a idade (chave) para ser utilizada na busca. Caso encontrada, informe o nome e o whats da pessoa. Após a consulta, o usuário pode atualizar somente o nome e o whats.
Para relatar, percorra o vetor do inicio ao fim e exiba todos os registros.*/

Console.Clear();
const int VL = 5;
const int VST = 5;
const int VE = 5;
Tipo_no[] vetor_linear = new Tipo_no[VL];
Tipo_no[] vetor_s_tratamento = new Tipo_no[VST];
Tipo_no[] vetor_encadeado = new Tipo_no[VE];
int qtd_colisoes = 0;

while(true)
{
    int op = Menu_Principal();
    if(op == 1)
    {
        Console.WriteLine("******************************* INSERIR *****************************\n");
        int op2 = 0;
        while(op2 != 4)
        {
            op2 = Menu_Tratamento();
            if(op2 == 1)
            {
                Console.Write("Digite a idade: ");
                int idade = Convert.ToInt32(Console.ReadLine());
                Console.Write("Digite o nome: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o whats: ");
                int whats = Convert.ToInt32(Console.ReadLine());
                InserirSTratamento(vetor_s_tratamento, idade, nome, whats);
                Console.WriteLine("");
            }
            else if(op2 == 2)
            {
                Console.Write("Digite a idade: ");
                int idade = Convert.ToInt32(Console.ReadLine());
                Console.Write("Digite o nome: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o whats: ");
                int whats = Convert.ToInt32(Console.ReadLine());
                InserirLinear(vetor_linear, idade, nome, whats);
                Console.WriteLine("");
            }
            else if(op2 == 3)
            {
                Console.Write("Digite a idade: ");
                int idade = Convert.ToInt32(Console.ReadLine());
                Console.Write("Digite o nome: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o whats: ");
                int whats = Convert.ToInt32(Console.ReadLine());
                InserirEncadeada(vetor_linear, idade, nome, whats);
                Console.WriteLine("");
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
                Console.Write("Digite a chave(idade) que deseja alterar: ");
                int idade_alterar = (Convert.ToInt32(Console.ReadLine()));
                AlterarSTratamento(ref vetor_s_tratamento, idade_alterar);
                Console.WriteLine("");          
            }
            else if(op2 == 2)
            {
                Console.Write("Digite a chave(idade) que deseja alterar: ");
                int idade_alterar = (Convert.ToInt32(Console.ReadLine()));
                AlterarLinear(ref vetor_linear, idade_alterar);
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
        Console.WriteLine("************************ EXIBIR ************************\n");
        int op2 = Menu_Tratamento();
         while(op2 != 4)
        {
            if(op2 == 1)
            {
                ExibirSTratamento(vetor_s_tratamento);
            }
            else if(op2 == 2)
            {
                ExibirLinear(vetor_linear);
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

void InserirSTratamento(Tipo_no[] vetor, int idade, string nome, int whats)
{
    int posicao = Hash(idade);
    vetor[posicao] = new Tipo_no();
    vetor[posicao].idade = idade;
    vetor[posicao].nome = nome;
    vetor[posicao].whats = whats;
}

void InserirLinear(Tipo_no[] vetor, int idade, string nome, int whats)
{
    int posicao = Hash(idade);
    while(vetor[posicao] != null)
    {
        posicao ++;
        posicao = posicao % VL;
    }
    vetor[posicao] = new Tipo_no();
    vetor[posicao].idade = idade;
    vetor[posicao].nome = nome;
    vetor[posicao].whats = whats;
}

void InserirEncadeada(Tipo_no[] vetor, int idade, string nome, int whats)
{
    int posicao = Hash(idade);
    while(vetor[posicao] != null)
    {

    }
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

void AlterarSTratamento(ref Tipo_no[] vetor, int idade)
{
    int posicao = Hash(idade);
    if(posicao != -1)
    {
        Console.WriteLine("Dados atuais: ");
        Console.WriteLine($"A chave digitada foi [{vetor[posicao].idade}], para ela temos os seguintes dados: Nome [{vetor[posicao].nome}] e Whats [{vetor[posicao].whats}]");
        Console.WriteLine("\nAlterar dados");
        vetor[posicao].nome = " ";
        vetor[posicao].whats = 0;
        Console.Write("Digite o novo nome: ");
        vetor[posicao].nome = Console.ReadLine();
        Console.Write("Digite o novo Whats: ");
        vetor[posicao].whats = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nDados alterados:");
        Console.WriteLine($"A chave digitada foi [{vetor[posicao].idade}], e seus novos dados são: nome [{vetor[posicao].nome}], Whats [{vetor[posicao].whats}]");
    }
    else
    {
        Console.WriteLine("Idade não encontrada!");
    }   
}

void AlterarLinear(ref Tipo_no[] vetor, int idade)
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

void ExibirSTratamento(Tipo_no[] vetor)
{
    int contador = 0;
    int idade = 0;
    int posicao = Hash(vetor[idade].idade);
    if(posicao != -1)
    {
        while((vetor[posicao ] != null || vetor[posicao].idade == idade) && contador < VST)
        {
            Console.WriteLine("\n****************** EXIBIÇÃO DE TODOS OS REGISTROS ******************\n");
            Console.WriteLine($"Para idade: [{vetor[posicao].idade}], temos os seguintes dados: Nome [{vetor[posicao].nome}] e Whats [{vetor[posicao].whats}]");
            contador ++; //com problema aqui
        }
    }
    else
    {
        Console.WriteLine("Nenhum valor encontrado!");
    } // não para de repetir
}

void ExibirLinear(Tipo_no[] vetor)
{
    Console.WriteLine("\n****************** EXIBIÇÃO DE TODOS OS REGISTROS ******************\n");
    Tipo_no[] auxiliar = vetor;
    if(auxiliar != null)
    {
        while(auxiliar != null)
        {
            int posicao = 0;
            int pos = Hash(vetor[posicao].idade);
            Console.WriteLine($"Para idade: [{auxiliar[pos].idade}], para ela temos os seguintes dados: nome [{auxiliar[pos].nome}] e Whats [{auxiliar[pos].whats}]");
        }
    }
    else
    {
        Console.WriteLine("Nenhum valor encontrado!");
    }   
}

int Hash(int idade)
{
    return idade % VL;
}

int Menu_Principal()
{
    int opcao = 0;
    Console.WriteLine("--------------------------- MENU PRINCIPAL---------------------------\n");
    Console.WriteLine("[1] Inserir");
    Console.WriteLine("[2] Alterar");
    Console.WriteLine("[3] Exibir todos os resultados");
    Console.WriteLine("[4] Sair!");
    Console.Write("\nDigite a opção desejada: ");
    opcao = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n---------------------------------------------------------------------\n");
    return opcao;
}

int Menu_Tratamento()
{
    int opcao = 0;
    Console.WriteLine("---------------------- MENU TIPOS DE TRATAMENTO ---------------------\n");    
    Console.WriteLine("[1] Sem tratamento de colisão");
    Console.WriteLine("[2] Tratamento de colisão Linear");
    Console.WriteLine("[3] Tratamento de colisão com Lista Encadeada");
    Console.WriteLine("[4] Sair das funções de tratamento");
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