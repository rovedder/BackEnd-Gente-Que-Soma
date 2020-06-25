namespace TrabBackEndFinal.Entidades
{
    public class CaixaEletronico
    {
        public int NotaCinquenta { get; private set;}

        public int NotaVinte { get; private set;}

        public int NotaDez { get; private set;}

        public int NotaCinco { get; private set;}

        public int NotaDois { get; private set;}

        public CaixaEletronico()
        {
            NotaCinquenta = 0;
            NotaVinte = 0;
            NotaDez = 0;
            NotaCinco = 0;
            NotaDois = 0;
        }

        /// <summary>
        /// Depositar notas
        /// </summary>
        /// <param name="nota">Nota a ser depositada</param>
        /// <param name="quantidade">Quantidade de notas a serem depositadas</param>
        public void DepositarNotas(int nota, int quantidade)
        {
            switch(nota)
            {
                case 50:
                    NotaCinquenta += quantidade;
                    break;
                
                case 20:
                    NotaVinte += quantidade;
                    break;

                case 10:
                    NotaDez += quantidade;
                    break;

                case 5:
                    NotaCinco += quantidade;
                    break;

                case 2:
                    NotaDois += quantidade;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Sacar notas
        /// </summary>
        /// <param name="nota">Nota a ser sacada</param>
        /// <param name="quantidade">Quantidade de notas a serem sacadas</param>
        public void SacarNotas(int nota, int quantidade)
        {
            switch(nota)
            {
                case 50:
                    NotaCinquenta -= quantidade;
                    break;
                
                case 20:
                    NotaVinte -= quantidade;
                    break;

                case 10:
                    NotaDez -= quantidade;
                    break;

                case 5:
                    NotaCinco -= quantidade;
                    break;

                case 2:
                    NotaDois -= quantidade;
                    break;

                default:
                    break;
            }
        }
        
        /// <summary>
        /// Retorna saldo disponivel
        /// </summary>
        /// <returns></returns>
        public int RetornarSaldo()
        {
            int saldo = default(int);

            saldo += (50 * NotaCinquenta);
            saldo += (20 * NotaVinte);
            saldo += (10 * NotaDez);
            saldo += (5 * NotaCinco);
            saldo += (2 * NotaDois);

            return saldo;
        }

        public string RetornarQuantidadeNotas()
        {
            string retorno = default(string);
            retorno = $"Notas de 50: {NotaCinquenta} \n";
            retorno += $"Notas de 20: {NotaVinte} \n";
            retorno += $"Notas de 10: {NotaDez} \n";
            retorno += $"Notas de 5:  {NotaCinco} \n";
            retorno += $"Notas de 2:  {NotaDois}";
            return retorno;
        }

        /// <summary>
        /// Retorna as notas disponiveis, porem sem informas a quantidade
        /// </summary>
        /// <returns></returns>
        public string RetornarNotasDisponiveis()
        {
            string retorno = default(string);

            retorno += "Notas Disponiveis:";

            if(NotaCinquenta != 0)
                retorno += "\n 50";

            if(NotaVinte != 0)
                retorno += " \n 20";
            
            if(NotaDez != 0)
                retorno += " \n 10";

            if(NotaCinco != 0)
                retorno += " \n 5";

            if(NotaDois != 0)
                retorno += "\n 2";

            return retorno;
        }
    }
}