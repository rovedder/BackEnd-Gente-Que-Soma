using TrabBackEndFinal.Entidades;

namespace TrabBackEndFinal.Telas
{
    public class TelaCaixaEletronico : TelaBase
    {
        private CaixaEletronico Caixa = new CaixaEletronico();

        /// <summary>
        /// Executa a tela principal do caixa eletronico
        /// </summary>
        public void Executar()
        {
            bool executando = true;

            int opcao = default(int);

            do 
            {
                LimparTela();

                Escrever("1 - Depositar");
                Escrever("2 - Sacar");
                Escrever("3 - Verificar Saldo");
                Escrever("4 - Sair");
                opcao = EscreverLerInt("Escolha uma opcao");

                switch(opcao) 
                {
                    case 1:
                        Depositar();
                        break;

                    case 2:
                        Sacar();
                        break;

                    case 3:
                        VerificarSaldo();
                        break;

                    case 4:
                        executando = false;
                        break;

                    default:
                        Escrever("Opcao invalida.");
                        break;
                }
            } while(executando);
        }

        /// <summary>
        /// Tela de depositos
        /// </summary>
        private void Depositar()
        {
            LimparTela();

            int quantidade = default(int);

            Escrever("Informe quantas notas deseja depositar");

            quantidade = EscreverLerInt("Notas de 50:");
            Caixa.DepositarNotas(50, quantidade);

            quantidade = EscreverLerInt("Notas de 20:");
            Caixa.DepositarNotas(20, quantidade);

            quantidade = EscreverLerInt("Notas de 10:");
            Caixa.DepositarNotas(10, quantidade);

            quantidade = EscreverLerInt("Notas de 5:");
            Caixa.DepositarNotas(5, quantidade);

            quantidade = EscreverLerInt("Notas de 2:");
            Caixa.DepositarNotas(2, quantidade);

            Escrever("Deposito efetuado com sucesso!");
            AguardarTecla("Aperte qualquer tecla para voltar.");
        }

        /// <summary>
        /// Tela para realizacao de saques
        /// </summary>
        private void Sacar()
        {
            LimparTela();

            int valor = default(int);

            Escrever(Caixa.RetornarNotasDisponiveis());

            valor = EscreverLerInt("Informe o valor que deseja sacar - 0 para voltar");

            if (valor == 0)
            {
                return;
            }
            else if (valor < 0) 
            {
                Escrever("Valor invalido.");
                AguardarTecla("Aperte qualque tecla para voltar.");
                return;
            }
            else if (valor > Caixa.RetornarSaldo()) 
            {
                Escrever("Saldo insuficiente.");
                AguardarTecla("Aperte qualque tecla para voltar.");
                return;
            }
            else 
            {
                int quantidadeNotasCinquenta = default(int);
                int quantidadeNotasVinte = default(int);
                int quantidadeNotasDez = default(int);
                int quantidadeNotasCinco = default(int);
                int quantidadeNotasDois = default(int);

                while(valor > 1)
                {
                    // São realizadas as seguintes verificações:
                    // 1 - Quantidade de notas maior que 0
                    // 2 - Quantidade de notas a ser sacada menor que quantidade de notas disponiveis
                    // 3 - Valor deve ser maior que o valor da Nota
                    if (Caixa.NotaCinquenta > 0 && 
                        quantidadeNotasCinquenta < Caixa.NotaCinquenta &&
                        valor >= 50
                        )
                    {
                        quantidadeNotasCinquenta++;
                        valor -= 50;
                    }
                    else if(Caixa.NotaVinte > 0 && 
                            quantidadeNotasVinte < Caixa.NotaVinte &&
                            valor >= 20)
                    {
                        quantidadeNotasVinte++;
                        valor -= 20;
                    }
                    else if(Caixa.NotaDez > 0 && 
                            quantidadeNotasDez < Caixa.NotaDez &&
                            valor >= 10)
                    {
                        quantidadeNotasDez++;
                        valor -= 10;
                    }
                    // O resto do valor dividido por 5 não pode ser impar
                    // Senão buga em casos como 58 (1 nota- 50 / 1 nota- 5 / 4 notas- 2)
                    else if(Caixa.NotaCinco > 0 && 
                            quantidadeNotasCinco < Caixa.NotaCinco &&
                            (valor % 5) % 2 == 0 &&
                            valor >= 5)
                    {
                        quantidadeNotasCinco++;
                        valor -= 5;
                    }
                    else if(Caixa.NotaDois > 0 && 
                            quantidadeNotasDois < Caixa.NotaDois &&
                            valor >= 2)
                    {
                        quantidadeNotasDois++;
                        valor -= 2;
                    }
                    else
                    {
                        break;
                    }
                }
               
               // Se no final o valor ainda for maior (unica opção é ser 1)
               // Operação não pode ser efetuada
                if (valor != 0)
                {
                    Escrever("Operacao nao pode ser efetuada.");
                    AguardarTecla("Aperte qualquer tecla para voltar.");
                    return;
                }
                else
                {
                    // Efetiva o saque com as quantidades pré definidas
                    Caixa.SacarNota(50, quantidadeNotasCinquenta);
                    Caixa.SacarNota(20, quantidadeNotasVinte);
                    Caixa.SacarNota(10, quantidadeNotasDez);
                    Caixa.SacarNota(5, quantidadeNotasCinco);
                    Caixa.SacarNota(2, quantidadeNotasDois);

                    Escrever("Saque efetuado com sucesso!");
                    Escrever($"50 - {quantidadeNotasCinquenta} | 20 - {quantidadeNotasVinte} | 10 - {quantidadeNotasDez} | 5 - {quantidadeNotasCinco} | 2 - {quantidadeNotasDois}");
                    AguardarTecla("Aperte qualquer tecla para voltar");
                    return;
                }
            }
        }

        /// <summary>
        /// Tela para verificar saldo e quatidade de notas disponiveis
        /// </summary>
        private void VerificarSaldo()
        {
            LimparTela();

            Escrever($"Saldo total {Caixa.RetornarSaldo()}");
            Escrever(Caixa.RetornarQuantidadeNotas());

            AguardarTecla("Aperte qualquer tecla para voltar.");
        }
    }
}