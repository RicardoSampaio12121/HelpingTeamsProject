/*
 * This file contains a class that implements the methods of the interface
 */
using System.Collections.Generic;

public class Cases : ICases
{
    /// <summary>
    /// Calls a web method to insert the infected case into the database
    /// </summary>
    /// <param name="cc"></param>
    public void InsertDetectedCase(int cc)
    {
        CovidManagement cov = new CovidManagement();
        int a = cov.InsertInfectedUser(cc);
    }

    /// <summary>
    /// Calls a web method to insert the people in contact with the infected case in the database
    /// </summary>
    /// <param name="ccs"></param>
    /// <param name="cc"></param>
    public void InsertUsersInContact(List<int> ccs, int cc)
    {
        CovidManagement cov = new CovidManagement();
        int a = cov.InsertUsersInContact(ccs, cc);
    }
}
