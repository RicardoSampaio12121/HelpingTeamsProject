/*
 * This interface containts the available methods to communicate with the database
 */

using System.Collections.Generic;
using System.ServiceModel;

[ServiceContract]
public interface ICases
{
	[OperationContract]
	void InsertDetectedCase(int cc);

	[OperationContract]
	void InsertUsersInContact(List<int> ccs, int cc);
}