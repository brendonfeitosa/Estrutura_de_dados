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
Tipo_no[] vetor_encadeada = new Tipo_no[VE];
int idade = 0;

while(true)
{
    int op = Menu_Principal();
    if(op == 1)
    {
        int op2 = 0;
        while(op2 != 4)
        {
            Console.WriteLine("\n******************************* INSERINDO *****************************");
            op2 = Menu_Tratamento();
            if(op2 == 1)
            {
                Console.Write("Digite a idade: ");
                idade = Convert.ToInt32(Console.ReadLine());
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
                idade = Convert.ToInt32(Console.ReadLine());
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
                idade = Convert.ToInt32(Console.ReadLine());
                Console.Write("Digite o nome: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o whats: ");
                int whats = Convert.ToInt32(Console.ReadLine());
                InserirEncadeada(vetor_encadeada, idade, nome, whats);
                Console.WriteLine("");
            }
        }
    }

    else if(op == 2)
    {
        int op2 = 0;
         while(op2 != 4)
        {
            Console.WriteLine("\n************************ ALTERARANDO ************************");
            op2 = Menu_Tratamento();
            if(op2 == 1)
            {
                AlterarSTratamento(ref vetor_s_tratamento);
                Console.WriteLine("");          
            }
            else if(op2 == 2)
            {
                AlterarLinear(ref vetor_linear);
                Console.WriteLine(""); 
            }
            else if(op2 == 3)
            {
                AlterarEncadeada(ref vetor_encadeada);
                Console.WriteLine("");          

            }
        }       
    }

    else if(op == 3)
    {
        int op2 = 0;
         while(op2 != 4)
        {
            Console.WriteLine("************************ EXIBINDO ************************\n");
            op2 = Menu_Tratamento();
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
                ExibirEncadeada(vetor_encadeada);
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
    if(posicao != -1)
    {
        Tipo_no no = new Tipo_no();
        no.idade = idade;
        no.nome = nome;
        no.whats = whats;
        if(vetor[posicao] != null)
        {
            no.proximo = vetor[posicao];
        }
        vetor[posicao] = no;
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

void ConsultarEncadeada(Tipo_no[] vetor, int idade, ref Tipo_no anterior, ref Tipo_no atual)
{
    int posicao = Hash(idade);
    atual = vetor[posicao];
    anterior = null;
    while(atual != null && idade != atual.idade)
    {
        anterior = atual;
        atual = atual.proximo;
    }
}

void AlterarSTratamento(ref Tipo_no[] vetor)
{
    Console.Write("Digite a chave(idade) que deseja alterar: ");
    int idade_alterar = (Convert.ToInt32(Console.ReadLine()));
    int posicao = Hash(idade_alterar);
    if(posicao != -1)
    {
        Console.WriteLine("\nDados atuais!\n");
        Console.WriteLine($"A chave digitada foi [{vetor[posicao].idade}], para ela temos os seguintes dados: Nome [{vetor[posicao].nome}] e Whats [{vetor[posicao].whats}]");
        Console.WriteLine("\nAlterar dados!");
        vetor[posicao].nome = " ";
        vetor[posicao].whats = 0;
        Console.Write("Digite o novo nome: ");
        vetor[posicao].nome = Console.ReadLine();
        Console.Write("Digite o novo Whats: ");
        vetor[posicao].whats = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nDados alterados!");
        Console.WriteLine($"A chave digitada foi [{vetor[posicao].idade}], e seus novos dados são: nome [{vetor[posicao].nome}], Whats [{vetor[posicao].whats}]");
    }
    else
    {
        Console.WriteLine("Idade não encontrada!");
    }   
}

void AlterarLinear(ref Tipo_no[] vetor)
{
    Console.Write("Digite a chave(idade) que deseja alterar: ");
    int idade_alterar = (Convert.ToInt32(Console.ReadLine()));
    int posicao = ConsultarLinear(vetor, idade_alterar);
    if(posicao != -1)
    {
        Console.WriteLine("Dados atuais: ");
        Console.WriteLine($"A chave digitada foi [{vetor_linear[posicao].idade}], para ela temos os seguintes dados: nome [{vetor_linear[posicao].nome}] e Whats [{vetor_linear[posicao].whats}]");
            Console.Write("Digite o novo nome: ");
            vetor[posicao].nome = Console.ReadLine();
            Console.Write("Digite o novo Whats: ");
            vetor[posicao].whats = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nDados alterados:");
            Console.WriteLine($"A chave digitada foi [{vetor_linear[posicao].idade}], e seus novos dados são: nome [{vetor_linear[posicao].nome}], Whats [{vetor_linear[posicao].whats}]");
        
    }
    else
    {
        Console.WriteLine("Idade não encontrada!");
    }
}

void AlterarEncadeada(ref Tipo_no[] vetor)
{
    Tipo_no atual = null;
    Tipo_no anterior = null;
    Console.Write("Digite a chave(idade) que deseja alterar: ");
    int idade_alterar = (Convert.ToInt32(Console.ReadLine()));
    int posicao = Hash(idade_alterar);
    if(posicao != -1)
    {
        ConsultarEncadeada(vetor, idade_alterar, ref anterior, ref atual);
        if(atual != null)
        {
            Console.WriteLine("Alterando dados: ");
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
}

void ExibirSTratamento(Tipo_no[] vetor) 
{
    int contador = 0;
    if(vetor != null && contador < VST)
    {
        Console.WriteLine("\n****************** EXIBIÇÃO DE TODOS OS REGISTROS ******************\n");
        while(contador < VST)
        {
            if(vetor[contador] != null)
            {
                Console.WriteLine($"Para idade: [{vetor[contador].idade}], temos os seguintes dados: Nome [{vetor[contador].nome}] e Whats [{vetor[contador].whats}]\n");
            }
            contador ++;
        }
    }
    else
    {
        Console.WriteLine("Nenhum valor encontrado!\n");
    }
}

void ExibirLinear(Tipo_no[] vetor)
{
    Console.WriteLine("\n****************** EXIBIÇÃO DE TODOS OS REGISTROS ******************\n");
    int contador = 0;
    if(vetor != null)
    {
        while(contador < VL)
        {
            if(vetor[contador] != null)
            {
                Console.WriteLine($"Para idade: [{vetor[contador].idade}], temos os seguintes dados: Nome [{vetor[contador].nome}] e Whats [{vetor[contador].whats}]\n");
            }
            contador ++;
        }
    }
    else
    {
        Console.WriteLine("Nenhum valor encontrado!\n");
    }
}

void ExibirEncadeada(Tipo_no[] vetor)
{
    Console.WriteLine("\n****************** EXIBIÇÃO DE TODOS OS REGISTROS ******************\n");
    int contador = 0;
    Tipo_no auxiliar = vetor[contador];
    if(auxiliar != null)
    {
        while(auxiliar != null && contador < 5)
        {
            Console.WriteLine($"Para idade: [{auxiliar.idade}], temos os seguintes dados: Nome [{auxiliar.nome}] e Whats [{auxiliar.whats}]\n");
            contador ++;
            auxiliar = auxiliar.proximo;
        }
    }
    else
    {
        Console.WriteLine("Nenhum valor encontrado!\n");
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
    Console.WriteLine("\n---------------------------------------------------------------------");
    return opcao;
}

int Menu_Tratamento()
{
    int opcao = 0;
    Console.WriteLine("\n---------------------- MENU TIPOS DE TRATAMENTO ---------------------\n");    
    Console.WriteLine("[1] Sem tratamento de colisão");
    Console.WriteLine("[2] Tratamento de colisão Linear");
    Console.WriteLine("[3] Tratamento de colisão com Lista Encadeada");
    Console.WriteLine("[4] Voltar ao menu anterior");
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
    public Tipo_no proximo;
}