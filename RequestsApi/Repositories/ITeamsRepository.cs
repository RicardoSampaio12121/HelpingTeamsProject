﻿using RequestsApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestsApi.Repositories
{
    public interface ITeamsRepository
    {
         Task<IEnumerable<TeamModel>> GetTeamsAsync();
    }
}
