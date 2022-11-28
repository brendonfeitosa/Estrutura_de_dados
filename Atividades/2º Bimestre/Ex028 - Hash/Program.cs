/*28) Implemente um programa com as seguintes opções: Sem tratamento de colisão, Tratamento de colisão Linear e Tratamento de colisão com Lista Encadeada.
Dentro de cada opção deve haver as funcionalidades: Inserir, Alterar e Relatar.
O vetor deve ser do tipo abstrato de dado composto por idade, nome e whats. Serão necessários 3 vetores, um para cada tipo de tratamento de colisão.
Para inserir um novo registro, solicite a idade, nome e whats. Utilize a idade como chave.
Para alterar solicite a idade (chave) para ser utilizada na busca. Caso encontrada, informe o nome e o whats da pessoa. Após a consulta, o usuário pode atualizar somente o nome e o whats.
Para relatar, percorra o vetor do inicio ao fim e exiba todos os registros.*/

Console.Clear();
const int V = 5;
Tipo_no[] vetor = new Tipo_no[V];









int Menu()
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

class Tipo_no
{
    public int idade;
    public string nome;
    public int whats;
}