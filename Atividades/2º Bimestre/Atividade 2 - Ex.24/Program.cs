/*24) Desenvolva um programa para inserir, pesquisar, remover e exibir os valores de uma árvore binária. Observe as opções a seguir:
a) Inserir um valor digitado pelo usuário
b) Pesquisar um valor digitado pelo usuário. Exiba uma mensagem informando se encontrou ou não
c) Remover um valor digitado pelo usuário. Exiba a mensagem se removido com sucesso ou não encontrado
d) Exibir todos os valores da árvore em ordem, pré ordem ou pós ordem*/





int Menu()
{
    int opcao = 0;
    Console.WriteLine("---------------------------MENU PRINCIPAL---------------------------\n");
    Console.WriteLine("[1] Inserir um valor digitado pelo usuário!");
    Console.WriteLine("[2] Pesquisar um valor digitado pelo usuário!");
    Console.WriteLine("[3] Remover um valor digitado pelo usuário!");
    Console.WriteLine("[4] Exibir todos os valores da árvore em ordem, pré ordem ou pós ordem!");
    Console.WriteLine("[5] Sair!");
    Console.Write("\nDigite a opção desejada: ");
    opcao = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n------------------------------------------------------------------\n");
    return opcao;
}