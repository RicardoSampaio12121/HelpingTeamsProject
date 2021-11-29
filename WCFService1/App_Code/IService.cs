using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Services;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService" no arquivo de código e configuração ao mesmo tempo.
[ServiceContract]
public interface ICases
{
	[OperationContract]
	void InsertDetectedCase(int cc);

	[OperationContract]
	void InsertUsersInContact(List<int> ccs, int cc);


	// TODO: Adicione suas operações de serviço aqui
}

// Use um contrato de dados como ilustrado no exemplo abaixo para adicionar tipos compostos a operações de serviço.
[DataContract]
public class infectedUser
{
	public int _cc;

	public infectedUser(int cc)
    {
		_cc = cc;
    }
}

[DataContract]
public class userInContact
{
	int cc;
}
