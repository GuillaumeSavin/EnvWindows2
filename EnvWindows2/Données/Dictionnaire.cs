using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvWindows2.Données
{
    class Dictionnaire
    {
        private Dictionary<String, String> credentials = new Dictionary<string, string>();

        public void chargementDictionnaire()
        {
            this.credentials.Add("guisav", "motdepassedeguisav");
            this.credentials.Add("pegcalde", "motdepassedepegcalde");
            this.credentials.Add("lecat", "motdepassedelecat");
            this.credentials.Add("kanade", "motdepassedekanade");
            this.credentials.Add("yuzuru", "motdepassedeyuzuru");
        }

        public Boolean checkCredentials(String login, String mdp)
        {
            foreach(var credential in credentials)
            {
                if(credential.Key == login)
                {
                    if(credential.Value == mdp)
                    {
                        return true;        
                    }

                    return false;
                }

            }

            return false;
        }

    }
}
