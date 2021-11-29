using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;


// OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service" no arquivo de código, svc e configuração ao mesmo tempo.
public class Cases : ICases
{
    public void InsertDetectedCase(int cc)
    {
        CovidManagement cov = new CovidManagement();
        int a = cov.InsertInfectedUser(cc);
    }

    public void InsertUsersInContact(List<int> ccs, int cc)
    {
        CovidManagement cov = new CovidManagement();
        int a = cov.InsertUsersInContact(ccs, cc);
    }
}
