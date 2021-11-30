using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    /// <summary>
    /// Model of an object to create a team
    /// </summary>
    public record CreateTeamModel
    {
        public string Location { get; init; }
    }
}
